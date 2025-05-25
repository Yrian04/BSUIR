namespace Graph_Editor
{
    internal class Graph : Undirected_graph.UndirectedGraph<string>
    {
        public string Name { get; set; }
        public List<List<ConsoleColor>> EdgesColors { get; }
        public List<ConsoleColor> VertexesColors { get; }
        public Graph(string name) : this(name, new List<string>()) { }
        public Graph(string name, List<string> vertexes) : this(name, vertexes.ToArray()) { }
        public Graph(string name, params string[] vertexes) : this(name, new bool[vertexes.Length, vertexes.Length], vertexes) { }
        public Graph(string name, bool[,] IncidenceMatrix, params string[] vertexes) : base(IncidenceMatrix, vertexes)
        {
            Name = name;
            VertexesColors = new List<ConsoleColor>(vertexes.Length) { };
            EdgesColors = new List<List<ConsoleColor>>();
            for (int i = 0; i < EdgesColors.Count; i++)
            {
                VertexesColors.Add(ConsoleColor.White);
                EdgesColors.Add(new List<ConsoleColor>());
                EdgesColors[i] = new List<ConsoleColor>(vertexes.Length) { };
                for (int j = 0; j < VertexesColors.Count; j++)
                    EdgesColors[i][j] = ConsoleColor.Black;
            }
        }

        public void AddVertex(string vertex)
        {
            Add(vertex);
            VertexesColors.Add(ConsoleColor.White);
            for (int i = 0; i < EdgesColors.Count; i++)
            {
                List<ConsoleColor>? item = EdgesColors[i];
                item.Add(ConsoleColor.Black);
            }

            EdgesColors.Add(new List<ConsoleColor>(Vertexes.Count));
            for (int i = 0; i < EdgesColors.Count; i++)
                EdgesColors.Last().Add(ConsoleColor.Black);
        }

        public bool AddDirectedEdge(string subj, string obj)
        {
            if (!(Vertexes.Contains(obj) && Vertexes.Contains(subj)))
                return false;

            this[subj, obj] = true;

            return true;
        }

        public bool AddUndirectedEdge(string obj1, string obj2) => AddDirectedEdge(obj1, obj2) && AddDirectedEdge(obj2, obj1);

        public bool RemoveVertex(string vertex) => Remove(vertex);

        public bool RemoveEdge(string v1, string v2)
        {
            if (!(Vertexes.Contains(v1) && Vertexes.Contains(v2)))
                return false;

            this[v1, v2] = false;
            this[v2, v1] = false;

            return true;
        }

        public int IndexOf(string vertex) => Vertexes.IndexOf(vertex);

        public void Print()
        {
            if (Vertexes.Count == 0 || IncidenceMatrix is null)
            {
                Console.WriteLine("Empty graph");
                return;
            }

            Console.Write("V");
            for (int i = 0; i < Vertexes.Count; i++)
            {
                string? vertex = Vertexes[i];
                Console.Write("\t");
                Console.ForegroundColor = VertexesColors[i];
                Console.Write(vertex);
                Console.ForegroundColor = ConsoleColor.White;
            }

            for (var i = 0; i < IncidenceMatrix.GetLength(0); i++)
            {
                Console.Write("\r\n");
                Console.ForegroundColor = VertexesColors[i];
                Console.Write(Vertexes[i]);
                Console.ForegroundColor = ConsoleColor.White;

                for (var j = 0; j < IncidenceMatrix.GetLength(1); j++)
                {
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.Write("\t");
                    Console.ForegroundColor = EdgesColors[i][j];
                    Console.Write(IncidenceMatrix[i, j] ? '1' : '0');
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }
            Console.WriteLine();
        }

        public int GetEccentricity(string v)
        {
            int k = IndexOf(v);
            int[] a = new int[Count];
            bool[] bools = new bool[Count];

            for(int i = 0; i < Count; i++)
            {
                a[i] = i == k ? 0 : int.MaxValue;
                bools[i] = true;
            }

            bool flag = false;

            while (!flag)
            {
                bools[k] = false;

                for (int i = 0; i < Count; i++)
                    if (bools[i] && this[k, i])
                        a[i] = Math.Min(a[i], a[k] + 1);

                for (int i = 0; i < Count; i++)
                    flag &= bools[i];
            }

            int max = 0;
            foreach(var i in a)
                max = Math.Max(max, i);

            return max;
        }

        public int GetRadius()
        {
            if (IsEmpty) return 0;

            int[] e = new int[Count];
            for (int i = 0; i < e.Length; i++)
                e[i] = GetEccentricity(this[i]);
            int max = e[0];
            foreach (var item in e)
                max = Math.Max(max, item);
            return max;
        }
    }
}
