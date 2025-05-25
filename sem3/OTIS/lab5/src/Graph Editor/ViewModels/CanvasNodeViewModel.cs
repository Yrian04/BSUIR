using Graph_Editor.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Graph_Editor.ViewModels
{
    public class CanvasNodeViewModel : INotifyPropertyChanged
    {
        private readonly CanvasNode _node;
        private static double diameter = 30;
        
        public static double Diameter
        {
            get => diameter;
            set
            {
                diameter = value;
            }
        }

        public CanvasNodeViewModel(CanvasNode node)
        {
            _node = node;
        }
        public CanvasNodeViewModel() : this(new CanvasNode())
        {
            _node.Node = new Node();
        }

        public string Name
        {
            get => _node.Name;
            set
            {
                _node.Name = value;
                OnPropertyChanged();
            }
        }

        public System.Windows.Point Position
        {
            get => _node.Position;
            set
            {
                _node.Position = value;
                OnPropertyChanged();
            }
        }

        public System.Windows.Media.Brush Brush
        {
            get => _node.Brush;
            set
            {
                _node.Brush = value;
                OnPropertyChanged();
            }
        }

        public CanvasNode Node => _node;

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        public override string ToString() => $"{Name}";
    }
}
