namespace Graph_Editor.Model
{
    public class Container<T> : Node
    {
        public T Value { get; set; }
        public Container(T value) => Value = value;
    }
}
