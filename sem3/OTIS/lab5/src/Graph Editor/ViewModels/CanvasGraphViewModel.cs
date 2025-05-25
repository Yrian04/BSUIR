using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Graph_Editor.Model;

namespace Graph_Editor.ViewModels
{
    public class CanvasGraphViewModel : INotifyPropertyChanged
    {
        private int _edgeCount = 0;
        private int _nodeCount = 0;
        private CanvasGraph? _canvasGraph;
        private readonly ObservableCollection<CanvasNodeViewModel> _nodes = new();
        private readonly ObservableCollection<CanvasEdgeViewModel> _edges = new();
        private CanvasNodeViewModel? _selectedNode = null;
        private CanvasNodeViewModel? _targetNode = null;
        private CanvasEdgeViewModel? _selectedEdge = null;
        private double _step = 20;
        private Brush _nodeBrush = new SolidColorBrush(Colors.White);

        public ObservableCollection<CanvasNodeViewModel> CanvasNodes => _nodes;
        public ObservableCollection<CanvasEdgeViewModel> CanvasEdges => _edges;

        public string Name
        {
            get
            {
                if (_canvasGraph is null)
                    throw new InvalidOperationException();

                return _canvasGraph.Name;
            }

            set
            {
                if (_canvasGraph is null)
                    throw new InvalidOperationException();

                _canvasGraph.Name = value;
                OnPropertyChanged();
            }
        }

        public double Step
        {
            get => _step;
            set
            {
                _step = value;
                OnPropertyChanged();
            }
        }

        public CanvasGraph? CanvasGraph
        {
            get => _canvasGraph;
            set
            {
                _nodes.Clear();
                _edges.Clear();

                _canvasGraph = value;

                if (_canvasGraph != null)
                {
                    foreach (var node in _canvasGraph.Nodes)
                    {
                        var vm = new CanvasNodeViewModel(node);
                        _nodes.Add(vm);
                    }

                    foreach (var edge in _canvasGraph.Edges)
                    {
                        var vm = new CanvasEdgeViewModel(edge);
                        _edges.Add(vm);
                    }
                }

                OnPropertyChanged(nameof(CanvasEdges));
                OnPropertyChanged(nameof(CanvasNodes));
                OnPropertyChanged(nameof(CanvasGraph));
            }
        }
        public bool HaveGraph => _canvasGraph is not null;

        public CanvasNodeViewModel? SelectedNode
        {
            get => _selectedNode;
            set
            {
                _selectedNode = value;
                OnPropertyChanged();
            }
        }
        public CanvasNodeViewModel? TargetNode
        {
            get => _targetNode;
            set
            {
                _targetNode = value;
                OnPropertyChanged();
            }
        }
        public CanvasEdgeViewModel? SelectedEdge 
        {
            get => _selectedEdge;
            set
            {
                _selectedEdge = value;
                OnPropertyChanged();
            }
        }

        public Brush NodeBrush
        {
            get => _nodeBrush;
            set
            {
                _nodeBrush = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand? _changeSelectedNode;
        public RelayCommand ChangeSelectedNode => _changeSelectedNode ??= new RelayCommand(obj =>
        {
            if (obj is CanvasNode node)
            {
                CanvasNodeViewModel? nodeVM = (CanvasNodeViewModel?)obj;

                foreach (var vm in _nodes)
                    if (vm.Node == node)
                        nodeVM = vm;

                SelectedNode = nodeVM;
            } 
        });

        private RelayCommand? _addNode;
        public RelayCommand AddNode => _addNode ??= new RelayCommand(obj =>
        {
            var node = new CanvasNodeViewModel
            {
                Position = new System.Windows.Point(30, 30),
                Name = $"{_nodeCount++}",
                Brush = NodeBrush,
            };
            _nodes.Add(node);
            _canvasGraph!.Add(node.Node);
            SelectedNode = node;
        }, obj => HaveGraph);

        private RelayCommand? _addUEdge;
        public RelayCommand AddUndirectedEdge => _addUEdge ??= new RelayCommand(obj =>
        {
            var edge = new CanvasEdgeViewModel(new CanvasEdge()
            {
                Subject = _selectedNode!.Node,
                Object = _targetNode!.Node,
                Edge = new UndirectedEdge(_selectedNode!.Node.Node, _targetNode!.Node.Node),
                Name = $"{_edgeCount++}",
            });
            _edges.Add(edge);
            _canvasGraph!.Add(edge.Edge);
        }, obj => HaveGraph && _selectedNode is not null && _targetNode is not null && _selectedNode != _targetNode);

        private RelayCommand? _addDEdge;
        public RelayCommand AddDirectedEdge => _addDEdge ??= new RelayCommand(obj =>
        {
            var edge = new CanvasEdgeViewModel(new CanvasEdge()
            {
                Subject = _selectedNode!.Node,
                Object = _targetNode!.Node,
                Edge = new DirectedEdge(_selectedNode!.Node.Node, _targetNode!.Node.Node),
                Name = $"{_edgeCount++}",
            });
            _edges.Add(edge);
            _canvasGraph!.Add(edge.Edge);
        }, obj => HaveGraph && _selectedNode is not null && _targetNode is not null && _selectedNode != _targetNode);

        private RelayCommand? _removeNode;
        public RelayCommand RemoveNode => _removeNode ??= new RelayCommand(obj =>
        {
            for (int i = 0; i < _edges.Count; i++)
            {
                CanvasEdgeViewModel? edge = _edges[i];
                if (edge.Edge.Subject == _selectedNode!.Node || edge.Edge.Object == _selectedNode.Node)
                {
                    _edges.Remove(edge);
                    i--;
                }
            }
            _canvasGraph!.Remove(_selectedNode!.Node);
            _nodes.Remove(_selectedNode!);
        }, obj => HaveGraph && _selectedNode is not null);


        private RelayCommand? _removeEdge;
        public RelayCommand RemoveEdge => _removeEdge ??= new RelayCommand(obj =>
        {
            _canvasGraph!.Remove(_selectedEdge!.Edge);
            if (_selectedEdge is CanvasEdgeViewModel edge)
                _edges.Remove(edge);
        }, obj => HaveGraph && _selectedEdge is not null);

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        public override string ToString() => _canvasGraph?.ToString() ?? "null";
    }
}
