using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml.Serialization;

namespace Graph_Editor.Model
{
    [Serializable]
    public class CanvasNode : CanvasElement, INotifyPropertyChanged
    {
        private System.Windows.Point _position = new(0, 0);
        private Node? _node;

        public CanvasNode() { }

        public override System.Windows.Point Position
        {
            get => _position;
            set
            {
                _position = value;
                OnPropertyChanged();
            }
        }

        public Node Node
        {
            get
            {
                if (_node == null)
                    throw new InvalidOperationException($"Attribute {nameof(_node)} was null");

                return _node;
            }
            set
            {
                _node = value;
                OnPropertyChanged();
            }
        }
    }
}
