using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;

namespace Graph_Editor.Model
{
    public enum ConnectionStatus
    {
        GoOut = -1,
        NotConnected = 0,
        GoIn = 1
    }

    [Serializable]
    public class Graph : ICollection<Node>, IEnumerable<Edge>, INamed
    {
        public static Graph CartesianProduct(Graph g1, Graph g2)
        {
            Graph result = new();

            for (int i = 0; i < g1.Count; i++)
                for (int j = 0; j < g2.Count; j++)
                    result.Add((Node)new UndirectedEdge(g1[i], g2[j]));

            for (int i = 0; i < result.Count; i++)
                for (int j = 0; j < result.Count; j++)
                    if (result[i] is UndirectedEdge p1 && result[j] is UndirectedEdge p2)
                        if (p1.Source == p2.Source && g2[p1.Target, p2.Target])
                            result.Add(new DirectedEdge(p1, p2));
                        else if (p1.Target == p2.Target && g1[p1.Source, p2.Source])
                            result.Add(new DirectedEdge(p1, p2));
            return result;
        }
        public static Graph TensorProduct(Graph g1, Graph g2)
        {
            Graph result = new();

            for (int i = 0; i < g1.Count; i++)
                for (int j = 0; j < g2.Count; j++)
                    result.Add((Node)new UndirectedEdge(g1[i], g2[j]));

            for (int i = 0; i < result.Count; i++)
                for (int j = 0; j < result.Count; j++)
                    if (result[i] is UndirectedEdge p1 && result[j] is UndirectedEdge p2)
                        if (g1[p1.Source, p2.Source] && g2[p1.Target, p2.Target])
                            result.Add(new DirectedEdge(p1, p2));

            return result;
        }

        public string Name { get; set; } = "";

        private readonly List<Node> nodes_ = new();
        private readonly List<Edge> edges_ = new();

        public event PropertyChangedEventHandler? PropertyChanged;

        public int Count => nodes_.Count;
        public int CountOfEdges => edges_.Count;
        public bool IsReadOnly => ((ICollection<Node>)nodes_).IsReadOnly;
        public ConnectionStatus[,] IncidenceMatrix
        {
            get
            {
                int n = Count;
                int m = CountOfEdges;
                ConnectionStatus[,] matrix = new ConnectionStatus[n, m];

                for (int i = 0; i < n; i++)
                {
                    Node node = nodes_[i];
                    for (int j = 0; j < m; j++)
                    {
                        Edge edge = edges_[j];
                        if (edge is DirectedEdge)
                            if (edge.Source.Equals(node))
                                matrix[i, j] = ConnectionStatus.GoOut;
                            else if (edge.Target.Equals(node))
                                matrix[i, j] = ConnectionStatus.GoIn;
                            else
                                matrix[i, j] = ConnectionStatus.NotConnected;
                        else if (edge is UndirectedEdge)
                            if (edge.Source.Equals(node))
                                matrix[i, j] = ConnectionStatus.GoIn;
                            else if (edge.Target.Equals(node))
                                matrix[i, j] = ConnectionStatus.GoIn;
                            else
                                matrix[i, j] = ConnectionStatus.NotConnected;
                    }
                }

                return matrix;
            }
        }
        public bool[,] AdjacencyMatrix
        {
            get
            {
                int n = Count;

                bool[,] matrix = new bool[n, n];

                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                    {
                        var source = nodes_[i];
                        var target = nodes_[j];
                        var edge = source.IncidentEdges.ToList().Find(x => x.Source.Equals(source) && x.Target.Equals(target) || x.Target.Equals(source) && x.Source.Equals(target));

                        matrix[i, j] = edge is UndirectedEdge || edge is DirectedEdge && edge.Source.Equals(source) && edge.Target.Equals(target);
                    }

                return matrix;
            }
        }
        public bool IsComplete
        {
            get
            {
                foreach (var i in IncidenceMatrix)
                    if (i == ConnectionStatus.NotConnected)
                        return false;

                return true;
            }
        }
        public bool IsEmpty => Count is 0;
        public int? Diameter
        {
            get
            {
                if (!IsWeakConnected)
                    return null;

                var d = 0;
                foreach (var node in nodes_)
                    d = Math.Max(d, TimeOfBFS(node).Max(x => x.Value));

                return d;
            }
        }
        public bool IsStrongConnected
        {
            get
            {
                if (IsEmpty)
                    return false;

                return !TimeOfBFS(nodes_[0]).ContainsValue(-1);
            }
        }
        public bool IsWeakConnected
        {
            get
            {
                if (IsEmpty)
                    return false;

                var graph = GetUndirectedGraph();

                return !graph.TimeOfBFS(graph.nodes_[0]).ContainsValue(-1);
            }
        }
        public int Radius
        {
            get
            {
                int r = int.MaxValue;

                foreach (var n in nodes_)
                    r = Math.Min(r, GetEccentricity(n));

                return r;
            }
        }
        public List<Node> Center => nodes_.FindAll(x => Radius == GetEccentricity(x));

        public Graph GetUndirectedGraph()
        {
            var graph = new Graph();

            var queue = new Queue<Node>();
            queue.Enqueue(nodes_[0]);

            Node? node;
            var rel = new Dictionary<Node, Node>();
            while (queue.TryDequeue(out node))
            {
                rel.TryAdd(node, new Node());
                graph.Add(rel[node]);

                foreach (var adjNode in node.AdjacentNodes)
                    if (rel.ContainsKey(adjNode))
                        graph.Add(new UndirectedEdge(rel[node], rel[adjNode]));
                    else if (!queue.Contains(adjNode))
                        queue.Enqueue(adjNode);
            }

            return graph;
        }

        public void CompleteGraph()
        {
            foreach (var source in nodes_)
                foreach (var target in nodes_)
                    if (!this[source, target] && !this[target, source])
                        Add(new UndirectedEdge(source, target));
        }

        public int Distance(Node start, Node end)
        {
            if (start == null)
                throw new ArgumentNullException(nameof(start));
            if (end == null)
                throw new ArgumentNullException(nameof(end));

            if (!nodes_.Contains(start))
                throw new ArgumentException("Graph is not have start node", nameof(start));
            if (!nodes_.Contains(end))
                throw new ArgumentException("Graph is not have end nodes", nameof(end));

            return TimeOfBFS(start)[end];
        }

        public int GetEccentricity(Node node) => TimeOfBFS(node).Max(x => x.Value);

        public List<Node> HamiltonCircle()
        {
            var path = new List<Node>();
            var visited = new Dictionary<Node, bool>();

            foreach (var node in nodes_)
                visited.Add(node, false);

            Hamilton(nodes_[0]);

            if (path.Count != 0)
                path.Add(nodes_[0]);

            return path;

            bool Hamilton(Node curr)
            {
                path.Add(curr);
                if (path.Count == Count)
                    if (AdjacencyMatrix[nodes_.IndexOf(path.Last()), nodes_.IndexOf(path.First())])
                        return true;
                    else
                    {
                        path.Remove(path.Last());
                        return false;
                    }
                visited[curr] = true;
                for (int next = 0; next < Count; ++next)
                    if (AdjacencyMatrix[nodes_.IndexOf(curr), next] && !visited[nodes_[next]])
                        if (Hamilton(nodes_[next]))
                            return true;
                visited[curr] = false;
                path.Remove(path.Last());
                return false;
            }
        }

        #region Collection Methods
        public Node this[int index] => nodes_[index];
        public bool this[int index1, int index2] => AdjacencyMatrix[index1, index2];
        public bool this[Node subj, Node obj] => AdjacencyMatrix[nodes_.IndexOf(subj), nodes_.IndexOf(obj)];
        public void Add(Node item)
        {
            ((ICollection<Node>)nodes_).Add(item);
        }

        public void Add(Edge item)
        {
            ((ICollection<Edge>)edges_).Add(item);
        }

        public void Clear()
        {
            ((ICollection<Node>)nodes_).Clear();
            ((ICollection<Edge>)edges_).Clear();
        }

        public bool Contains(Node item)
        {
            return ((ICollection<Node>)nodes_).Contains(item);
        }

        public bool Contains(Edge item)
        {
            return ((ICollection<Edge>)edges_).Contains(item);
        }

        public void CopyTo(Node[] array, int arrayIndex)
        {
            ((ICollection<Node>)nodes_).CopyTo(array, arrayIndex);
        }

        public void CopyTo(Edge[] array, int arrayIndex)
        {
            ((ICollection<Edge>)edges_).CopyTo(array, arrayIndex);
        }

        public bool Remove(Edge item)
        {
            var flag = ((ICollection<Edge>)edges_).Remove(item);
            OnPropertyChanged("edges");
            return flag;
        }

        public bool Remove(Node item)
        {
            var flag1 = true;

            foreach (var edge in item.IncidentEdges)
                flag1 &= Remove(edge);

            var flag2 = nodes_.Remove(item);

            return flag1 && flag2;
        }

        public IEnumerator<Node> GetEnumerator()
        {
            return ((IEnumerable<Node>)nodes_).GetEnumerator();
        }
        public void OnPropertyChanged([CallerMemberName] string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)nodes_).GetEnumerator();
        }

        IEnumerator<Edge> IEnumerable<Edge>.GetEnumerator()
        {
            return ((IEnumerable<Edge>)edges_).GetEnumerator();
        }

        public Node? Find(Predicate<Node> predicate) => nodes_.Find(predicate);
        #endregion 

        private Dictionary<Node, int> TimeOfBFS(Node start)
        {
            if (start == null)
                throw new ArgumentNullException(nameof(start));

            if (!nodes_.Contains(start))
                throw new ArgumentException("Graph don't have the start node", nameof(start));

            var distances = new Dictionary<Node, int>
            {
                { start, 0 }
            };
            var queue = new Queue<Node>();
            queue.Enqueue(start);
            Node? node;
            while (queue.TryDequeue(out node))
            {
                foreach (var edge in node.IncidentEdges)
                {
                    var child = edge.GetAdjacentNode(node) ?? throw new Exception();
                    if (distances.ContainsKey(child) || (edge is DirectedEdge && node == edge.Target))
                        continue;
                    distances.Add(child, distances[node] + 1);
                    queue.Enqueue(child);
                }
            }

            return distances;
        }


        public override string ToString() => $"Graph:{Name}";
    }
}