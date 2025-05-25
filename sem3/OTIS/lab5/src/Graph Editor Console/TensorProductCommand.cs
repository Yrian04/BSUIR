using Graph_Editor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Editor_Console
{
    internal class TensorProductCommand : Command
    {
        public override string Name => "TENS";

        public override string[] Help => new string[] { "TENS [graph1] [graph2]" };

        public override bool CanExecute() => Shell.Graphs.Count > 1;

        public override void Execute(params string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Invalid number of arguments");
                return;
            }

            Graph? graph1, graph2;

            if (!Shell.Graphs.TryGetValue(args[0], out graph1))
            {
                Console.WriteLine("There is no graph " + args[0]);
                return;
            }

            if (!Shell.Graphs.TryGetValue(args[1], out graph2))
            {
                Console.WriteLine("There is no graph " + args[1]);
                return;
            }

            string name = $"TENS_{args[0]}_{args[1]}";
            Shell.Graphs.Add(name, Graph.TensorProduct(graph1, graph2));
            Shell.Graphs[name].Name = name;
        }
    }
}
