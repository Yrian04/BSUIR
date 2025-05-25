using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Editor_Console
{
    internal class ViewGraphListCommand : Command
    {
        public override string Name => "LISTGRAPH";

        public override string[] Help => new string[] { "LISTGRAPH" };

        public override bool CanExecute() => true;

        public override void Execute(params string[] args)
        {
            foreach (var name in Shell.Graphs.Keys)
                Console.WriteLine(name);
        }
    }
}
