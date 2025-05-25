using Graph_Editor.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Graph_Editor.ViewModels;
using System.CodeDom;

namespace Graph_Editor.Selectors
{
    public class EdgeTemplateSelector : DataTemplateSelector
    {
        public DataTemplate? UndirectedEdgeDataTemplate { get; set; }
        public DataTemplate? DirectedEdgeClassDataTemplate { get; set; }
        public override DataTemplate? SelectTemplate(object item, DependencyObject container)
        {
            var edge = (CanvasEdgeViewModel)item;

            if (edge.Edge.Edge is UndirectedEdge)
                return UndirectedEdgeDataTemplate;
            if (edge.Edge.Edge is DirectedEdge)
                return DirectedEdgeClassDataTemplate;

            return base.SelectTemplate(item, container);
        }
    } 
}
