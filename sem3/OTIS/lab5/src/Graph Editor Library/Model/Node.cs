using System.Drawing;

namespace Graph_Editor.Model
{
    [Serializable]
    public class Node : IColored
    {
        public ConsoleColor Color { get; set; } = ConsoleColor.White;
        public HashSet<Edge> IncidentEdges { get; } = new HashSet<Edge>();
        public HashSet<Node> AdjacentNodes 
        { 
            get 
            {
                var adjacentNodes = new HashSet<Node>();
                foreach (var edge in IncidentEdges)
                    adjacentNodes.Add(edge.GetAdjacentNode(this) ?? throw new Exception());

                return adjacentNodes;
            } 
        }

        public int Degree => IncidentEdges.Count;
        public bool IsLeaf => Degree == 1;
        public bool IsIsolated => Degree == 0;

        public virtual bool IsIncident(Edge node) => IncidentEdges.Contains(node);
        public virtual bool IsAdjacent(Node node) => AdjacentNodes.Contains(node);
    }
}
