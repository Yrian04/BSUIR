using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pioivis_lr1_1
{
    public class DirGraph
    {
        readonly List<Node> nodes;

        Node StartNode;

        public DirGraph(params string[] ids)
        {
            List<Node> nodes = new();
            foreach (string id in ids)
            {

                nodes.Add(new Node(id));
            }
            this.nodes = nodes;
            StartNode = nodes[0];
            this.nodes.Sort();
        }

        public bool AddNode(string id)
        {
            if (nodes.Exists(node => id.Equals(node.Id)))
            {
                return false;
            }
            nodes.Add(new Node(id));
            this.nodes.Sort();
            return true;
        }

        public bool Contains(string id)
        {
            return nodes.Exists(node => id.Equals(node.Id));
        }

        public bool AddEdge(string startId, string endId)
        {
            Node? start = nodes.Find(node => startId.Equals(node.Id));
            Node? end = nodes.Find(node => endId.Equals(node.Id));
            if (start is null || end is null)
            {
                return false;
            }
            return start.AddNeighbour(end);
        }

        public bool RemoveEdge(string startId, string endId)
        {
            Node? start = nodes.Find(node => startId.Equals(node.Id));
            Node? end = nodes.Find(node => endId.Equals(node.Id));
            if (start is null || end is null)
            {
                return false;
            }
            return start.RemoveNeighbour(end);
        }
        void RemoveAllNeighbours(Node node)
        {
            foreach(Node node2 in nodes)
            {
                node2.RemoveNeighbour(node);
            }
        }

        public bool RemoveNode(string id)
        {
            Node? node = nodes.Find(node => id.Equals(node.Id));
            if (node is null)
            {
                return false;
            }
            RemoveAllNeighbours(node);
            return nodes.Remove(node);
        }

        public DirGraph TreeOfBFS(string rootId)
        {
            Node? processingNode = nodes.Find(node => rootId.Equals(node.Id));
            if (processingNode is null)
            {
                throw new NullReferenceException();
            }
            DirGraph tree = new(rootId);
            Queue<Node> queue = new();
            List<Node> processedNodes = new()
            {
                processingNode
            };
            do
            {
                foreach (Node child in processingNode.Neighbours.FindAll(node => !processedNodes.Contains(node)))
                {
                    queue.Enqueue(child);
                    tree.AddNode(child.Id);
                    tree.AddEdge(processingNode.Id, child.Id);
                    processedNodes.Add(child);
                }
            } while (queue.TryDequeue(out processingNode));
            return tree;
        }

        public static DirGraph ReadFromFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }
            using StreamReader sr = new(path);
            DirGraph graph = new(sr.ReadLine()!.Split(' ', '\n'));
            string? line = sr.ReadLine();
            do
            {
                string[] ids = line!.Split(' ', '\n');
                graph.AddEdge(ids[0], ids[1]);
                line = sr.ReadLine();
            } while (line != null);
            return graph;
        }

        public override string ToString()
        {
            string str = string.Empty;
            Node processingNode = StartNode;
            List<Node> processedNodes = new();
            Stack<Node> stack = new();
            do
            {
                foreach (Node neighbour in processingNode.Neighbours)
                {
                    if (!processedNodes.Contains(neighbour))
                    {
                        stack.Push(neighbour);
                    }
                    str += processingNode.ToString() + "->" + neighbour.ToString() + "\n\r";
                }
                processedNodes.Add(processingNode);
            } while (stack.TryPop(out processingNode!));
            return str;
        }

        public override bool Equals(object? obj)
        {
            if (obj is DirGraph)
            {
                DirGraph graph = (DirGraph)obj;
                if (!this.nodes.SequenceEqual(graph.nodes))
                {
                    return false;
                }
                foreach (Node node in this.nodes)
                {
                    if (!node.Neighbours.SequenceEqual(graph.nodes.Find(n => (n.Id == node.Id)).Neighbours))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hash = 1;
            foreach (Node node in nodes)
            {
                int h = node.GetHashCode();
                foreach (Node child in node.Neighbours)
                {
                    h *= (int)Math.Log10(child.GetHashCode());
                }
                hash *= h;
            }
            return hash;
        }
    }
}
