using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Graph_Editor.Model;

namespace Graph_Editor_Console
{
    internal class HamiltonianCircleCommand : TargetCommand<Graph>
    {
        public override string Name => "HAMILTON";

        public override string[] Help => new string[] { "HAMILTON" };

        public override bool CanExecute() => Shell.Graphs.Count > 0;

        public override void Execute(params string[] args)
        {
            foreach (var node in Target.HamiltonCircle())
            {
                Console.WriteLine(node);
            }
        }
    }
}
