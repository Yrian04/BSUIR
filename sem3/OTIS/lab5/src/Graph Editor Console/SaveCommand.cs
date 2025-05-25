using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph_Editor.Model;

namespace Graph_Editor_Console
{
    internal class SaveCommand : Command
    {
        public override string Name => "SAVE";

        public override string[] Help => new string[] { "SAVE [file] [graphs]" };

        public override bool CanExecute() => Shell.Graphs.Count > 0;

        public override void Execute(params string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Too few arguments");
                return;
            }

            filePath = args[0];

            foreach (string arg in args[1..])
            {
                Graph? graph;
                if (!Shell.Graphs.TryGetValue(arg, out graph))
                {
                    Console.WriteLine("There is no graph with name " + arg);
                    return;
                }

                SaveGraph(graph);
            }

        }
        private string? filePath;
        private void SaveGraph(Graph graph)
        {
            var tw = File.AppendText(filePath ?? $"{graph.Name}.graph");
            tw.WriteLine($"{new CreateGraphCommand().Name} {graph.Name}");
            tw.WriteLine($"{new ChangeTargetCommand().Name} {graph.Name}");

            tw.Write($"{new AddCommand().Name} NODE");
            foreach (var node in graph)
                tw.Write(" " + ((StringContainer)node).Value);

            tw.WriteLine();

            foreach (var edge in (IEnumerable<Edge>)graph)
                if (edge is UndirectedEdge)
                    tw.WriteLine($"{new AddCommand().Name} UEDGE {((StringContainer)edge.Source).Value} {((StringContainer)edge.Target).Value}");
            
            foreach (var edge in (IEnumerable<Edge>)graph)
                if (edge is DirectedEdge)
                    tw.WriteLine($"{new AddCommand().Name} DEDGE {((StringContainer)edge.Source).Value} {((StringContainer)edge.Target).Value}");
            
            tw.Close();
        }
    }
}
