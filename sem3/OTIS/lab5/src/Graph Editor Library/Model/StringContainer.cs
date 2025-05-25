using System.Drawing;

namespace Graph_Editor.Model
{
    public class StringContainer : Container<string>, ICloneable, INamed
    {
        public StringContainer() : base(string.Empty) { }

        public string Name { get => Value; set => Value = value; }

        public object Clone() => new StringContainer() { Value = Value };

        public override string ToString() => Value;
    }
}
