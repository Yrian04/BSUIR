using lr_2;
using System.Transactions;

internal class Program
{
    private static void Main(string[] args)
    {
        int n;
        List<Set> sets = new List<Set>();
        if (args.Length == 0)
        {
            n = Convert.ToInt32(args[0].Trim());
            for (int i = 0; i < n+1; i++)
            {
                Console.Write($"Enter {i} set: ");
                sets.Add(Set.GetFromString(Console.ReadLine().Split('=')[1]));
            }
        }
        else
        {
            Console.Write("Enter number of sets: ");
            n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Enter {i} set: ");
                sets.Add(Set.GetFromString(Console.ReadLine().Split('=')[1]));
            }
        }
        Set result = sets[0];
        sets.Remove(result);
        foreach (Set set in sets)
            result = Set.SymmetricDifference(set, result);
        Console.Write(result);
    }
}