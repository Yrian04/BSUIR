using SuffixTree;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("Enter string: ");
        var str = Console.ReadLine();
        var tree = new SuffixTree<char>(str.ToList());

        Print(tree.Root, 0);        

        void Print(Mark<char> mark, int level)
        {
            var tab = new string('\t', level);
            Console.WriteLine($"{tab}{mark.Id}");
            foreach (var child in mark.Children.Values)
            {
                Console.WriteLine(tab + string.Join(' ',child.GetValue(str.ToList())));
                Print(child, level+1);
            }
        }
    }
}