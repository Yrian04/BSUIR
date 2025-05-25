using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Xml.Serialization;

namespace Graph_Editor.Model
{
    [Serializable]
    public abstract class CanvasElement : INotifyPropertyChanged
    {
        private string _name = "";
        private Brush _brush = new SolidColorBrush(Colors.Black);

        public CanvasElement() { }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public virtual System.Windows.Point Position { get; set; }

        public Brush Brush
        {
            get => _brush;
            set
            {
                _brush = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string prop = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        public override string ToString() => $"{Name}";
    }
}
