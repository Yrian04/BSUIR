using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph_Editor.Model;

namespace Graph_Editor_Console
{
    internal class ChangeTargetCommand : Command
    {
        public override string Name => "CT";

        public override string[] Help => new string[] 
        {
            "CT [graph]",
            "CT [graph] [node in graph]"
        };

        public override bool CanExecute() => Shell.Graphs.Count > 0;

        public override void Execute(params string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Too few arguments");
                return;
            } 
            
            if (args.Length > 2)
            {
                Console.WriteLine("Too many arguments");
                return;
            }

            Graph? graph;
            if (!Shell.Graphs.TryGetValue(args[0], out graph))
            {
                Console.WriteLine("There is no graph with this name");
                return;
            }

            if (args.Length == 2)
            {
                Node? node = graph.Find(x => ((StringContainer)x).Value == args[1]);
                if (node == null)
                {
                    Console.WriteLine("There is no node with this name in " + args[0]);
                    return;
                }

                Shell.Target = node;
                return;
            }

            Shell.Target = graph;
        }
    }
}
