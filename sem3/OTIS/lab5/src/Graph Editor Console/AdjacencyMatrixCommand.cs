using Graph_Editor_Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph_Editor.Model;
using System.Xml.Linq;

namespace Graph_Editor.Model
{
    internal class AdjacencyMatrixCommand : TargetCommand<Graph>
    {
        public override string Name => "ADJMAT";

        public override string[] Help => new string[] { "ADJMAT" };

        public override bool CanExecute() => Shell.Target is Graph;

        public override void Execute(params string[] args)
        {
            Graph graph = Target;

            foreach (var node in graph)
            {
                if (node is IColored colored)
                    Console.ForegroundColor = colored.Color;
                Console.Write($"\t{node}");
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine();

            for (int i = 0; i < graph.Count; i++)
            {
                var node = graph[i];
                if (node is IColored colored)
                    Console.ForegroundColor = colored.Color;
                Console.Write($"{node}");
                Console.ForegroundColor = ConsoleColor.White;
                for (int j = 0; j < graph.Count; j++)
                    Console.Write($"\t{(graph[i, j] ? 1 : 0)}");
                Console.WriteLine();
            }
        }
    }
}
