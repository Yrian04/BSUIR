using Graph_Editor;
using Microsoft.VisualBasic.FileIO;

[System.Runtime.Versioning.SupportedOSPlatform("windows")]
internal class Program
{
    static readonly List<Graph> open_graphs = new List<Graph>();
    static int current_graph = -1;
    static bool ShowDegrees = true;
    static int CurrentGraph
    {
        get => current_graph;
        set => current_graph = (value >= 0 && value < open_graphs.Count) ? value : current_graph;
    }
    private static void Main(string[] args)
    {
        Start();
        while (true)
        {
            PrintScreen();
            DoAction();
        }
    }

    private static void DoAction()
    {
        char c = Console.ReadKey(true).KeyChar;
        switch (c)
        {
            case 'n':
                CreateGraph();
                break;
            case 'a':
                Add();
                break;
            case 'r':
                Rename();
                break;
            case 'x':
                Delete();
                break;
            case 'c':
                ChooseColor();
                break;
            case '0':
            case '1':
            case '2':
            case '3':
            case '4':
            case '5':
            case '6':
            case '7':
            case '8':
            case '9':
                CurrentGraph = Convert.ToInt32(c) - 48;
                break;

        }
    }

    private static void ChooseColor()
    {
        if (current_graph == -1)
            return;
        Console.WriteLine("Покрасить: v - вершину    e - ребро");
        switch (Console.ReadKey(true).KeyChar)
        {
            case 'v':
                ColorNode();
                break;
            case 'e':
                ColorEdge();
                break;
        }
    }

    private static void ColorEdge()
    {
        if (current_graph == -1)
            return;

        Console.Write("Введите название вершины, из которой выходит ребро: ");
        string? subj = Console.ReadLine();
        if (subj == null || !open_graphs[current_graph].Contains(subj))
        {
            Console.WriteLine($"Такой вершины нет в {open_graphs[current_graph].Name}");

            Console.ReadKey();
            return;
        }

        Console.Write("Введите название вершины, в которую входит ребро: ");
        string? obj = Console.ReadLine();
        if (obj == null || !open_graphs[current_graph].Contains(obj))
        {
            Console.WriteLine($"Такой вершины нет в {open_graphs[current_graph]}");

            Console.ReadKey();
            return;
        }

        Console.WriteLine("Выберите цвет: r - красный    g - зелёный     b - синий    w - белые");
        ConsoleColor color = ConsoleColor.White;
        switch (Console.ReadKey(true).KeyChar)
        {
            case 'r':
                color = ConsoleColor.Red;
                break;
            case 'g':
                color = ConsoleColor.Green;
                break;
            case 'b':
                color = ConsoleColor.Blue;
                break;
            case 'w':
                color = ConsoleColor.White;
                break;
        }

        open_graphs[current_graph].EdgesColors[open_graphs[current_graph].IndexOf(subj)][open_graphs[current_graph].IndexOf(obj)] = color;
    }

    private static void ColorNode()
    {
        if (current_graph == -1)
            return;

        Console.Write("Введите название вершины: ");
        string? name = Console.ReadLine();

        if (name == null || !open_graphs[current_graph].Contains(name))
        {
            Console.WriteLine($"Такой вершины нет в {open_graphs[current_graph].Name}");
            return;
        }

        Console.WriteLine("Выберите цвет: r - красный    g - зелёный     b - синий    w - белые");
        ConsoleColor color = ConsoleColor.White;
        switch (Console.ReadKey(true).KeyChar)
        {
            case 'r':
                color = ConsoleColor.Red;
                break;
            case 'g':
                color = ConsoleColor.Green;
                break;
            case 'b':
                color = ConsoleColor.Blue;
                break;
            case 'w':
                color = ConsoleColor.White;
                break;
        }

        open_graphs[current_graph].VertexesColors[open_graphs[current_graph].IndexOf(name)] = color;
    }

    private static void Rename()
    {
        if (current_graph == -1)
            return;
        Console.WriteLine("Переименовать: v - вершину    g - граф");
        switch (Console.ReadKey(true).KeyChar)
        {
            case 'v':
                RenameNode();
                break;
            case 'g':
                RenameGraph();
                break;
        }
    }

    private static void RenameGraph()
    {
        if (current_graph == -1)
            return;

        Console.Write("Введите новое название графа: ");
        string name = Console.ReadLine() ?? ("graph" + open_graphs[current_graph].Count);

        open_graphs[current_graph].Name = name;
    }

    private static void RenameNode()
    {
        if (current_graph == -1)
            return;

        Console.Write("Введите старое название вершины: ");
        string? name = Console.ReadLine();

        if (name == null || !open_graphs[current_graph].Contains(name))
        {
            Console.WriteLine($"Такой вершины нет в {open_graphs[current_graph].Name}");
            return;
        }

        Console.Write("Введите новое название вершины: ");
        string newName = Console.ReadLine() ?? ("node" + open_graphs[current_graph].Count);

        for (int i = 0; i < open_graphs[current_graph].Count; i++)
            if (open_graphs[current_graph][i] == name)
                open_graphs[current_graph][i] = newName;
    }

    private static void Delete()
    {
        if (current_graph == -1)
            return;
        Console.WriteLine("Удалить: v - вершину    e - ребро");
        switch (Console.ReadKey(true).KeyChar)
        {
            case 'v':
                RemoveNode();
                break;
            case 'e':
                RemoveEdge();
                break;
        }
    }

    private static void RemoveEdge()
    {
        if (current_graph == -1 || open_graphs[current_graph].IsEmpty)
            return;

        Console.Write("Введите название вершины, из которой выходит ребро: ");
        string? subj = Console.ReadLine();
        if (subj == null || !open_graphs[current_graph].Contains(subj))
        {
            Console.WriteLine($"Такой вершины нет в {open_graphs[current_graph].Name}");

            Console.ReadKey();
            return;
        }

        Console.Write("Введите название вершины, в которую входит ребро: ");
        string? obj = Console.ReadLine();
        if (obj == null || !open_graphs[current_graph].Contains(obj))
        {
            Console.WriteLine($"Такой вершины нет в {open_graphs[current_graph]}");

            Console.ReadKey();
            return;
        }

        open_graphs[current_graph].RemoveEdge(subj, obj);
    }

    private static void RemoveNode()
    {
        if (current_graph == -1)
            return;
        Console.Write("Введите название вершины: ");
        string name = Console.ReadLine() ?? ("node" + open_graphs[current_graph].Count);

        open_graphs[current_graph].RemoveVertex(name);
    }

    private static void Add()
    {
        if (current_graph == -1)
            return;
        Console.WriteLine("Добавить: v - вершину    d - направленное ребро    u - ненаправленное ребро");
        switch (Console.ReadKey(true).KeyChar)
        {
            case 'v':
                AddNode();
                break;
            case 'd':
                AddDirEdge();
                break;
            case 'u':
                AddUndirEdge();
                break;
        }
    }

    private static void AddUndirEdge()
    {
        if (current_graph == -1 || open_graphs[current_graph].IsEmpty)
            return;

        Console.Write("Введите название вершины, из которой выходит ребро: ");
        string? subj = Console.ReadLine();
        if (subj == null || !open_graphs[current_graph].Contains(subj))
        {
            Console.WriteLine($"Такой вершины нет в {open_graphs[current_graph].Name}");

            Console.ReadKey();
            return;
        }

        Console.Write("Введите название вершины, в которую входит ребро: ");
        string? obj = Console.ReadLine();
        if (obj == null || !open_graphs[current_graph].Contains(obj))
        {
            Console.WriteLine($"Такой вершины нет в {open_graphs[current_graph]}");

            Console.ReadKey();
            return;
        }

        open_graphs[current_graph].AddUndirectedEdge(subj, obj);
    }

    private static void AddDirEdge()
    {
        if (current_graph == -1 || open_graphs[current_graph].IsEmpty)
            return;

        Console.Write("Введите название вершины, из которой выходит ребро: ");
        string? subj = Console.ReadLine();
        if (subj == null || !open_graphs[current_graph].Contains(subj))
        {
            Console.WriteLine($"Такой вершины нет в {open_graphs[current_graph].Name}");

            Console.ReadKey();
            return;
        }

        Console.Write("Введите название вершины, в которую входит ребро: ");
        string? obj = Console.ReadLine();
        if (obj == null || !open_graphs[current_graph].Contains(obj))
        {
            Console.WriteLine($"Такой вершины нет в {open_graphs[current_graph]}");

            Console.ReadKey();
            return;
        }

        open_graphs[current_graph].AddDirectedEdge(subj, obj);
    }

    private static void AddNode()
    {
        if (current_graph == -1)
            return;
        Console.Write("Введите название вершины: ");
        string name = Console.ReadLine() ?? ("node" + open_graphs[current_graph].Count);

        if (open_graphs[current_graph].Contains(name))
        {
            Console.WriteLine("Такая вершина уже есть");

            Console.ReadKey();
            return;
        }

        open_graphs[current_graph].AddVertex(name);
    }

    private static void CreateGraph()
    {
        Console.Write("Введите имя графа: ");
        string name = Console.ReadLine() ?? ("graph" + open_graphs.FindAll(x => x.Name.StartsWith("graph")).Count);
        open_graphs.Add(new Graph(name));
    }

    private static void PrintScreen()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("n - создать новый граф    o - открыть существующий граф" +
            "    a - добавить    r - переименовать    x - удалить    c - цвет\n" +
            "");
        Console.ForegroundColor = ConsoleColor.Red;
        for (int i = 0; i < open_graphs.Count; i++)
        {
            if (i == current_graph)
                Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write($"{i} - {open_graphs[i].Name}    ");
            Console.ForegroundColor = ConsoleColor.Red;
        }

        Console.WriteLine("\b\b\b\b");
        Console.ForegroundColor = ConsoleColor.White;

        if (current_graph != -1)
        {
            open_graphs[CurrentGraph].Print();

            int n = 0, m = 0;
            foreach (var p in open_graphs[current_graph].GetPair())
                n++;

            foreach (var p in open_graphs[current_graph].GetPair())
                if (open_graphs[current_graph][p.Item2, p.Item1])
                    m++;
            m /= 2;

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"Count of vertexes: {open_graphs[current_graph].Count}    Count of edges: {n - m}");
            Console.ForegroundColor = ConsoleColor.White;

            if (ShowDegrees)
                PrintDegree();

            Console.Write("Graph is complete: ");

            bool isComplete = true;
            for (int i = 0; i < open_graphs[current_graph].Count; i++)
                for (int j = i; j < open_graphs[current_graph].Count; j++)
                    isComplete &= open_graphs[current_graph][i, j] || open_graphs[current_graph][j, i];
            Console.WriteLine(isComplete);

            Console.WriteLine($"Radius of graph: {open_graphs[current_graph].GetRadius()}");
        }
    }

    private static void PrintDegree()
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("Degrees:");

        for (int k = 0; k < open_graphs[current_graph].Count; k++)
        {
            int degree = 0;
            for (int i = 0; i < open_graphs[current_graph].Count; i++)
                for (int j = 0; j < open_graphs[current_graph].Count; j++)
                    if ((k == i || k == j) && open_graphs[current_graph][i, j])
                        degree++;

            int m = 0;
            for (int i = 0; i < open_graphs[current_graph].Count; i++)
                for (int j = i; j < open_graphs[current_graph].Count; j++)
                    if ((k == i || k == j) && open_graphs[current_graph][i, j] && open_graphs[current_graph][j, i])
                        m++;

            if (open_graphs[current_graph][k, k])
                m--;

            Console.WriteLine($"\t{open_graphs[current_graph][k]}\t{degree - m}");
        }
        Console.ForegroundColor = ConsoleColor.White;
    }

    private static void Start()
    {
        Console.SetWindowPosition(0, 0);
        Console.SetBufferSize(120, 40);
        Console.SetWindowSize(120, 40);
        Console.Title = "Graph Editor";

        Console.SetCursorPosition(0, 10);
    }
}