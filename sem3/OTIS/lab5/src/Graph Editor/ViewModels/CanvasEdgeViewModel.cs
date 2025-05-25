using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using System.Xml.Linq;
using Graph_Editor.Model;
using System.Collections.ObjectModel;

namespace Graph_Editor.ViewModels
{
    public class CanvasEdgeViewModel : INotifyPropertyChanged
    {
        private static Vector wind = new(-10, -3);

        public static Vector Wind
        {
            get => wind;
            set => wind = value;
        }

        private readonly CanvasEdge _edge; 

        public CanvasEdgeViewModel(CanvasEdge edge)
        {
            _edge = edge;

            edge.Subject.PropertyChanged += Edge_PropertyChanged;
            edge.Object.PropertyChanged += Edge_PropertyChanged;
        }

        private void Edge_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(CanvasNode.Position):
                    OnPropertyChanged(nameof(Start));
                    OnPropertyChanged(nameof(End));
                    OnPropertyChanged(nameof(NamePosition));
                    OnPropertyChanged(nameof(RightWind));
                    OnPropertyChanged(nameof(LeftWind));
                    break;
            }
        }

        public string Name
        {
            get => _edge.Name;
            set
            {
                _edge.Name = value;
                OnPropertyChanged();
            }
        }

        public CanvasEdge Edge => _edge;

        protected static Vector Alignment() => new(CanvasNodeViewModel.Diameter / 2, CanvasNodeViewModel.Diameter / 2);

        public Vector AsVector
        {
            get => _edge.End - _edge.Start;
        }

        public Vector Scale => new(Math.Abs(AsVector.X), Math.Abs(AsVector.Y));

        public Point NamePosition
        {
            get => Start + AsVector / 2;
        }

        public Vector Direction
        {
            get
            {
                var v = AsVector;
                v.Normalize();

                return v;
            }
        }

        protected Vector ScalingStart() => Direction * CanvasNodeViewModel.Diameter / 2;
        protected Vector ScalingEnd()
        {
            var v = _edge.Start - _edge.End;
            v.Normalize();
            v *= CanvasNodeViewModel.Diameter / 2;

            return v;
        }

        public Point Start
        {
            get => _edge.Start + Alignment() + ScalingStart();
            set
            {
                _edge.Subject.Position = value;
                OnPropertyChanged();
            }
        }

        public Point End
        {
            get => _edge.End + Alignment() + ScalingEnd();
            set
            {
                _edge.Object.Position = value;
                OnPropertyChanged();
            }
        }

        public Point RightWind
        {
            get
            {
                var v = new Vector(
                    Wind.X * Direction.X + Wind.Y * Direction.Y,
                    -(Wind.Y * Direction.X - Wind.X * Direction.Y)
                );

                return End + v;
            }
        }
        public Point LeftWind
        {
            get
            {
                var v = new Vector(
                    Wind.X * Direction.X + Wind.Y * -Direction.Y,
                    -(Wind.Y * -Direction.X - Wind.X * Direction.Y)
                );

                return End + v;
            }
        }

        public Brush Brush
        {
            get => _edge.Brush;
            set
            {
                _edge.Brush = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        public override string ToString() => $"{Name}";
    }
}
