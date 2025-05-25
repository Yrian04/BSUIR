using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Graph_Editor.Model;

namespace Graph_Editor_Console
{
    internal class RemoveCommand : TargetCommand<Graph>
    {
        public override string Name => "REMOVE";

        public override string[] Help => new string[] { "REMOVE NODE [node]", "REMOVE EDGE [source] [target]" };

        public override bool CanExecute() => Shell.Graphs.Count > 0;

        public override void Execute(params string[] args)
        {
            switch (args[0])
            {
                case "NODE":
                    foreach (var name in args[1..])
                        RemoveNode(name);
                    break;
                case "EDGE":
                    for (int i = 1; i < args.Length; i++)
                        RemoveEdge(args[i], args[++i]);
                    break;
                case "GRAPH":
                    foreach (var name in args[1..])
                        if (Shell.Graphs.ContainsKey(name))
                            Shell.Graphs.Remove(args[1]);
                        else
                            Console.WriteLine("There is not graph "+ name);
                    break;
            }

            Shell.Target = Shell.Graphs.FirstOrDefault();
        }

        private void RemoveNode(string name)
        {
            var node = Target.Find(x => ((StringContainer)x).Value == name);
            if (node == null)
            {
                Console.WriteLine($"Graph not have {name} node");
                return;
            }

            Target.Remove(node);
        }

        private void RemoveEdge(string sourceName, string targetName)
        {
            var source = Target.Find(x => ((StringContainer)x).Value == sourceName);
            if (source == null)
            {
                Console.WriteLine($"Graph not have {sourceName} node");
                return;
            }

            var target = Target.Find(x => ((StringContainer)x).Value == targetName);
            if (target == null)
            {
                Console.WriteLine($"Graph not have {targetName} node");
                return;
            }

            var edge = source.IncidentEdges.ToList().Find(x => x.Target.Equals(target));
            if (edge == null)
            {
                Console.WriteLine($"Graph not have this edge");
                return;
            }

            Target.Remove(edge);
        }
    }
}
