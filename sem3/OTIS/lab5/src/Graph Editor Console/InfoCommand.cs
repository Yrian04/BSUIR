using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph_Editor.Model;

namespace Graph_Editor_Console
{
    internal class InfoCommand : TargetCommand<Graph>
    {
        public override string Name => "INFO";

        public override string[] Help => new string[] {"INFO", "INFO [node]"};

        public override bool CanExecute() => Shell.Graphs.Count > 0;

        public override void Execute(params string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine($"Count of nodes: {Target.Count}");
                Console.WriteLine($"Count of edges: {Target.CountOfEdges}");
                Console.WriteLine(Target.IsComplete ? "Graph is complete" : "Graph is not complete");
                Console.WriteLine($"Diameter: {Target.Diameter}");
                Console.WriteLine($"Radius: {Target.Radius}");
                Console.WriteLine($"Center: {string.Join(' ', Target.Center)}");
                return;
            }
            foreach (string arg in args)
            {
                var node = Target.Find(x => ((StringContainer)x).Name == arg);
                if (node == null)
                {
                    Console.WriteLine("Graph not have this node");
                    return;
                }

                Console.WriteLine($"Degree: {node.Degree}");
                Console.WriteLine($"Eccentricity: {Target.GetEccentricity(node)}");
            }
        }
    }
}
