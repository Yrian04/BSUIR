using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuffixTree
{
    public class Mark<T>
    {
        public int Id { get; init; }
        public Mark<T>? Parent { get; set; }
        public int Position { get; set; }
        public int Length { get; set; }
        public Dictionary<T, Mark<T>> Link { get; init; } = new();
        public Dictionary<T, Mark<T>> Children { get; init; } = new();
        public Mark(int id, Mark<T>? parent) : this(id, parent, 0, 0) { }
        public Mark(int id, Mark<T>? parent, int position, int length)
        {
            this.Id = id;
            this.Parent = parent;
            this.Position = position;
            this.Length = length;
        }
        public IList<T> GetValue(IList<T> str)
        {
            List<T> list = new();
            for (int i = Position - Length; i < Position; i++)
                list.Add(str[i]);

            return list;
        }
        public void Attach(Mark<T> child, T c, int childLength)
        {
            if(!Children.TryAdd(c, child))
                Children[c] = child; 
            child.Length = childLength;
            child.Parent = this;
        }

        public override string ToString() => $"{Id}({Position}, {Length})";
    }
}
