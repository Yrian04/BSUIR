using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph_Editor.Model;

namespace Graph_Editor_Console
{
    internal class DiameterCommand : TargetCommand<Graph>
    {
        public override string Name => "DMR";

        public override string[] Help => new string[] {"DRM"};

        public override bool CanExecute() => Shell.Target is Graph;

        public override void Execute(params string[] args)
        {
            Console.WriteLine(Target.Diameter);
        }
    }
}
