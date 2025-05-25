using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Graph_Editor.Model;

namespace Graph_Editor.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private CanvasGraph? _targetCanvasGraph;
        public ObservableCollection<CanvasGraph> CanvasGraphs { get; init; } = new();
        public CanvasGraphViewModel CanvasGraphViewModel { get; init; } = new();
        public CanvasGraph? SelectedCanvasGraph
        {
            get => CanvasGraphViewModel.CanvasGraph;
            set
            {
                CanvasGraphViewModel.CanvasGraph = value;
                OnPropertyChanged();
            }
        }

        public CanvasGraph? TargetCanvasGraph
        {
            get => _targetCanvasGraph;
            set
            {
                _targetCanvasGraph = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand? _create;
        public RelayCommand Create => _create ??= new(obj =>
        {
            var graph = new CanvasGraph 
            { 
                Name = $"new_graph{CanvasGraphs.Count}",
                Graph = new()
            };
            CanvasGraphs.Add(graph);
            SelectedCanvasGraph = graph;

            var w = new GetGraphDataWindow
            {
                DataContext = CanvasGraphViewModel
            };
            w.Show();

            OnPropertyChanged(nameof(SelectedCanvasGraph));
        });

        private RelayCommand? _cartesianProduct;
        public RelayCommand CartesianProduct => _cartesianProduct ??= new(obj =>
        {
            var result = new CanvasGraph
            {
                Name = $"Cartesian product of {SelectedCanvasGraph!.Name} and {TargetCanvasGraph!.Name}",
                Graph = Graph.CartesianProduct(SelectedCanvasGraph.Graph, TargetCanvasGraph.Graph)
            };
            CanvasGraphs.Add(result);
            SelectedCanvasGraph = result;
        });

        private RelayCommand? _save;
        public RelayCommand Save => _save ??= new(obj =>
        {
            var serializer = new XmlSerializer(typeof(CanvasGraph));
            using FileStream fs = new($"{SelectedCanvasGraph?.Name}.xml", FileMode.OpenOrCreate);
            serializer.Serialize(fs, SelectedCanvasGraph);
        }, obj => SelectedCanvasGraph is not null);

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
