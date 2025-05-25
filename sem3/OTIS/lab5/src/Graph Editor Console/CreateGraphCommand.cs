using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph_Editor.Model;

namespace Graph_Editor_Console
{
    internal class CreateGraphCommand : Command
    {
        public override string Name => "CREATE";

        public override string[] Help => new string[] 
        {
            "CREATE [name_of_graph]"
        };

        public override bool CanExecute() => true;

        public override void Execute(params string[] args)
        {
            foreach (var arg in args)
            {
                if (arg == "" || arg.Contains(' ') || arg.Contains('/') || arg.Contains('\\') || arg.Contains('&'))
                {
                    Console.WriteLine("Invalid name graph");
                    return;
                }
                if (Shell.Graphs.ContainsKey(arg))
                {
                    Console.WriteLine("Graph wish this name already exists");
                    return;
                }
                var graph = new Graph() { Name = arg };
                Shell.Graphs.Add(arg, graph);
            }
        }
    }
}
