using Graph_Editor.Exceptions;

namespace Graph_Editor.Model
{
    [Serializable]
    public class UndirectedEdge : Edge
    {
        public UndirectedEdge(Node node1, Node node2) : base(node1, node2) { }

        public override Node Source
        {
            get => source_ ?? throw new EdgeIncidentNullException(nameof(Source));
            set
            {
                if (source_ is not null)
                    source_.IncidentEdges.Remove(this);

                source_ = value;

                if (source_ is not null)
                    source_.IncidentEdges.Add(this);
            }
        }
        public override Node Target
        {
            get => target_ ?? throw new EdgeIncidentNullException(nameof(Target));
            set
            {
                if (target_ is not null)
                    target_.IncidentEdges.Remove(this);

                target_ = value;

                if (target_ is not null)
                    target_.IncidentEdges.Add(this);
            }
        }

        public override string ToString() => $"{source_} = {target_}";
    }
}
