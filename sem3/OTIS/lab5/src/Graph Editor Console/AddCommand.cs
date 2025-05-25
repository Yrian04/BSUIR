using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph_Editor.Model;

namespace Graph_Editor_Console
{
    internal class AddCommand : TargetCommand<Graph>
    {
        public override string Name => "ADD";

        public override string[] Help => new string[]
        {
            "ADD [NODE/UEDGE/DEDGE] [name of nodes]"
        };

        public override bool CanExecute() => Shell.Graphs.Count > 0;

        public override void Execute(params string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Too few arguments");
                return;
            }

            Graph graph = Target;

            switch (args[0])
            {
                case "NODE":
                    foreach (var name in args[1..])
                    {
                        Node node = new StringContainer()
                        {
                            Value = name,
                        };
                        graph.Add(node);
                    }
                    break;
                case "DEDGE":
                    if (args.Length % 2 == 0)
                    {
                        Console.WriteLine("Invalid number of argument");
                        return;
                    }
                    for (int i = 1; i < args.Length; i++)
                    {
                        Node? source = graph.Find(x => ((INamed)x).Name == args[i]);
                        if (source == null)
                        {
                            Console.WriteLine("Graph not contains node " + args[i--]);
                            return;
                        }

                        i++;

                        Node? target = graph.Find(x => ((INamed)x).Name == args[i]);
                        if (target == null)
                        {
                            Console.WriteLine("Graph not contains node " + args[i]);
                            return;
                        }

                        Edge edge = new DirectedEdge(source, target);
                        graph.Add(edge);
                    }
                    break;
                case "UEDGE":
                    if (args.Length % 2 == 0)
                    {
                        Console.WriteLine("Invalid number of argument");
                        return;
                    }
                    for (int i = 1; i < args.Length; i++)
                    {
                        Node? source = graph.Find(x => ((INamed)x).Name == args[i]);
                        if (source == null)
                        {
                            Console.WriteLine("Graph not contains node " + args[i--]);
                            return;
                        }

                        i++;

                        Node? target = graph.Find(x => ((INamed)x).Name == args[i]);
                        if (target == null)
                        {
                            Console.WriteLine("Graph not contains node " + args[i]);
                            return;
                        }

                        Edge edge = new UndirectedEdge(source, target);
                        graph.Add(edge);
                    }
                    break;
                default:
                    Console.WriteLine("There is no that type of element");
                    break;
            }
        }
    }
}
