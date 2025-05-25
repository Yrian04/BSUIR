using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Graph_Editor.Model;

namespace Graph_Editor_Console
{
    internal class IncidentMatrixCommand : TargetCommand<Graph>
    {
        public override string Name => "INCMAT";

        public override string[] Help => new string[] { "INCMAT" };

        public override bool CanExecute() => Shell.Graphs.Count > 0;

        public override void Execute(params string[] args)
        {
            if (args.Length == 0)
            {
                Graph? graph = Target;
                var matrix = graph.IncidenceMatrix;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    var node = graph[i];
                    if (node is IColored colored)
                        Console.ForegroundColor = colored.Color;
                    Console.Write($"{graph[i]}: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    for (int j = 0; j < matrix.GetLength(1); j++)
                        Console.Write($"{(int)matrix[i, j]}\t");
                    Console.WriteLine();
                }
            }

            foreach (var name in args)
            {
                Graph? graph;
                if (!Shell.Graphs.TryGetValue(name, out graph))
                {
                    Console.WriteLine($"There is no graph with name {name}");
                    return;
                }
                var matrix = graph.IncidenceMatrix;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    var node = graph[i];
                    if (node is IColored colored)
                        Console.ForegroundColor = colored.Color;
                    Console.Write($"{graph[i]}: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    for (int j = 0; j < matrix.GetLength(1); j++)
                        Console.Write($"{(int)matrix[i, j]}\t");
                    Console.WriteLine();
                }
            }
        }
    }
}
