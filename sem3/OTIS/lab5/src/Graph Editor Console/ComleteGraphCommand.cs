using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph_Editor.Model;

namespace Graph_Editor_Console
{
    internal class CompleteGraphCommand : TargetCommand<Graph>
    {
        public override string Name => "COMP";

        public override string[] Help => new string[] { "COMP" };

        public override bool CanExecute() => Shell.Graphs.Count > 0;

        public override void Execute(params string[] args)
        {
            Target.CompleteGraph();
        }
    }
}
