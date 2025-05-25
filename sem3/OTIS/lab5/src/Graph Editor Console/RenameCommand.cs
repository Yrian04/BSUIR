using Graph_Editor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Editor_Console
{
    internal class RenameCommand : TargetCommand<INamed>
    {
        public override string Name => "RENAME";

        public override string[] Help => new string[] {"RENAME [new_name]"};

        public override bool CanExecute() => Shell.Graphs.Count > 0;

        public override void Execute(params string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Too many arguments");
                return;
            }

            if (Target is Graph)
            {
                Shell.Graphs.Remove(Target.Name);
                Shell.Graphs.Add(args[0], (Graph)Target);
            }
            Target.Name = args[0];
        }
    }
}
