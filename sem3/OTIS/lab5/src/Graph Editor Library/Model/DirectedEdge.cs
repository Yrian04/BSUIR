using Graph_Editor.Exceptions;

namespace Graph_Editor.Model
{
    [Serializable]
    public class DirectedEdge : Edge
    {
        public DirectedEdge(Node subj, Node obj) : base(subj, obj) { }


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
                {
                    if (source_ is not null)
                        target_.AdjacentNodes.Remove(Target);

                    target_.IncidentEdges.Remove(this);
                }

                target_ = value;

                if (source_ is not null)
                {
                    if (source_ is not null)
                        target_.AdjacentNodes.Add(Target);

                    target_.IncidentEdges.Add(this);
                }
            }
        }
        public override string ToString() => $"{source_} => {target_}";
    }
}
