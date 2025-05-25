using Graph_Editor.Exceptions;

namespace Graph_Editor.Model
{
    [Serializable]
    public abstract class Edge : Node
    {
        protected Node? source_;
        protected Node? target_;

        public abstract Node Source { get; set; }
        public abstract Node Target { get; set; }
        public bool IsLoop => Source.Equals(Target);

        public Edge() { }
        public Edge(Node source, Node target)
        {
            Source = source;
            Target = target;
        }

        public bool IsIncident(Node node) => Source.Equals(node) || Target.Equals(node);

        public Node? GetAdjacentNode(Node node)
        {
            if (node.Equals(Source))
                return Target;

            if (node.Equals(Target))
                return Source;

            return null;
        }

        public override string ToString() => $"{source_} - {target_}";
    }
}
