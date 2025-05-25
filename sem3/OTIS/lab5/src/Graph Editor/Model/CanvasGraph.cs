using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Graph_Editor.Model
{
    [Serializable, XmlRoot("Graph")]
    public class CanvasGraph : INotifyPropertyChanged, INotifyCollectionChanged
    {
        private string _name = "";
        private Graph? _graph;

        public ObservableCollection<CanvasNode> Nodes { get; } = new ObservableCollection<CanvasNode>();

        public ObservableCollection<CanvasEdge> Edges { get; } = new ObservableCollection<CanvasEdge>();

        public CanvasGraph() { }
        public Graph Graph
        {
            get
            {
                if (_graph == null)
                    throw new InvalidOperationException($"Attribute {nameof(Graph)} was null");

                return _graph;
            }
            set
            {
                _graph = value;
                
                Nodes.Clear();
                Edges.Clear();

                foreach (Node node in _graph)
                    Nodes.Add(new CanvasNode { Node = node });

                foreach (Edge edge in (IEnumerable<Edge>)_graph)
                {
                    CanvasNode? subj = null, obj = null;

                    foreach (CanvasNode node in Nodes)
                        if (node.Node == edge.Source)
                            subj = node;
                        else if (node.Node == edge.Target)
                            obj = node;

                    if (subj is null || obj is null)
                        throw new ArgumentException("Edge connects a node that is out of graph");

                    Edges.Add(new CanvasEdge 
                    { 
                        Edge = edge,
                        Subject = subj,
                        Object = obj
                    });
                }

                OnPropertyChanged();
                OnPropertyChanged(nameof(Nodes));
                OnPropertyChanged(nameof(Edges));
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public int Count => Nodes.Count;

        public bool IsReadOnly => ((ICollection<CanvasNode>)Nodes).IsReadOnly;

        public event PropertyChangedEventHandler? PropertyChanged;
        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        public void OnCollectionChanged(NotifyCollectionChangedAction action)
            => CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(action));
        public void OnCollectionChanged(NotifyCollectionChangedAction action, object? item)
            => CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(action, item));

        public void Add(CanvasNode item)
        {
            Nodes.Add(item);
            _graph?.Add(item.Node);
            OnCollectionChanged(NotifyCollectionChangedAction.Add, item);
        }

        public void Add(CanvasEdge item)
        {
            Edges.Add(item);
            _graph?.Add(item.Edge);
            OnCollectionChanged(NotifyCollectionChangedAction.Add, item);
        }

        public void Clear()
        {
            Nodes.Clear();
            OnCollectionChanged(NotifyCollectionChangedAction.Reset);
        }

        public bool Contains(CanvasNode item) => Nodes.Contains(item);

        public void CopyTo(CanvasNode[] array, int arrayIndex)
        {
            Nodes.CopyTo(array, arrayIndex);
        }

        public bool Remove(CanvasNode item)
        {
            var flag = Nodes.Remove(item);
            _graph?.Remove(item.Node);
            foreach (CanvasEdge edge in Edges)
                if (edge.Subject == item || edge.Object == item)
                {
                    _graph?.Remove(item.Node);
                }
            OnCollectionChanged(NotifyCollectionChangedAction.Remove, item);

            return flag;
        }

        public bool Remove(CanvasEdge item)
        {
            var flag = Edges.Remove(item);
            _graph?.Remove(item.Edge);
            OnCollectionChanged(NotifyCollectionChangedAction.Remove, item);

            return flag;
        }

        public override string ToString() => Name;
    }
}
