using System.Collections.Immutable;
using System.Net.Mail;
using System.Reflection.Metadata.Ecma335;

namespace SuffixTree
{
    public class SuffixTree<T>
    {
        IList<T> Array { get; init; }
        List<Mark<T>> Marks { get; init; } = new List<Mark<T>>();
        int Size => Marks.Count;

        public Mark<T> Root
        {
            get
            {
                if (Size < 2)
                    throw new InvalidOperationException();

                return Marks[1];
            }
        }

        public SuffixTree(IList<T> str)
        {
            this.Array = str;
            var zero = new Mark<T>(0, null);
            Marks.Add(zero);
            var first = new Mark<T>(1, zero, -1, 1);
            Marks.Add(first);
            foreach (var c in str)
                zero.Link.TryAdd(c, first);

            for (int i = str.Count - 1; i >= 0; i--)
                Extend(i);
        }

        void Extend(int index)
        {
            var path = new Stack<Mark<T>>();
            Mark<T>? v, old = Marks.Last();
            int vlen = Array.Count - index;
            for (v = old; !v!.Link.ContainsKey(Array[index]); v = v.Parent)
            {
                vlen -= v.Length;
                path.Push(v);
            }
            Mark<T> w = v.Link[Array[index]];
            if (w.Children.ContainsKey(Array[index + vlen]))
            {
                Mark<T> u = w.Children[Array[index + vlen]];
                Mark<T> sz = new(Size, null);
                Marks.Add(sz);
                for (sz.Position = u.Position - u.Length; Array[sz.Position]!.Equals(Array[index + vlen]); sz.Position += v.Length)
                {
                    v = path.Pop();
                    vlen += v.Length;
                }
                w.Attach(sz, Array[u.Position - u.Length], u.Length - (u.Position - sz.Position));
                sz.Attach(u, Array[sz.Position], u.Position - sz.Position);
                w = v.Link[Array[index]] = sz;

            }
            var newList = new Mark<T>(Size, null);
            Marks.Add(newList);
            old.Link[Array[index]] = newList;
            w.Attach(newList, Array[index + vlen], Array.Count - (index + vlen));
            newList.Position = Array.Count;
        }
    }
}