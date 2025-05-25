using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Graph_Editor.Model
{
    [Serializable]
    public class CanvasEdge : CanvasElement, INotifyPropertyChanged
    {
        private Edge? _edge;
        private CanvasElement? _subj;
        private CanvasElement? _obj;

        public CanvasEdge() { }

        public Edge Edge
        {
            get
            {
                if (_edge == null)
                    throw new InvalidOperationException($"Attribute {nameof(_edge)} was null");

                return _edge;
            }
            set
            {
                _edge = value;
                OnPropertyChanged();
            }
        }

        public CanvasElement Object
        {
            get
            {
                if (_obj == null)
                    throw new InvalidOperationException($"Attribute {nameof(_obj)} was null");

                return _obj;
            }
            set
            {
                _obj = value;
                OnPropertyChanged();
            }
        }

        public CanvasElement Subject
        {
            get
            {
                if (_subj == null)
                    throw new InvalidOperationException($"Attribute {nameof(_subj)} was null");

                return _subj;
            }
            set
            {
                _subj = value;
                OnPropertyChanged();
            }
        }

        public override System.Windows.Point Position 
        {
            get => Start + (End - Start) / 2;
            set => base.Position = value; 
        }

        public System.Windows.Point Start => Subject.Position;
        public System.Windows.Point End => Object.Position;
    }
}
