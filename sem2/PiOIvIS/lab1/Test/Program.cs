using pioivis_lr1_1;
using static System.Console; 

string? test;
while (true)
{
    Write("Enter name of test: ");
    test = Environment.CurrentDirectory + "\\tests\\" + ReadLine();
    if (!File.Exists(test + ".in"))
    {
        WriteLine("Try again...");
        continue;
    }
    break;
}

DirGraph graph = DirGraph.ReadFromFile(test + ".in");
Write(graph.ToString());
string? root;
while (true) { 
    Write("Enter root of BFS: ");
    root = ReadLine();
    if (!graph.Contains(root!))
    {
        WriteLine("Try again...");
        continue;
    }
    break;
}
DirGraph tree = graph.TreeOfBFS(root!);
Write(tree.ToString());
DirGraph testTree = DirGraph.ReadFromFile(test + ".tst");
WriteLine("Result: " + (tree.Equals(testTree) ? "OK" : "fail"));