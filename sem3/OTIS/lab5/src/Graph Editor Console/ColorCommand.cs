using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph_Editor.Model;
using Graph_Editor_Console;

namespace Graph_Editor_Console
{
    internal class ColorCommand : TargetCommand<IColored>
    {
        public override string Name => "COLOR";

        public override string[] Help => new string[] { "COLOR [color number]" };

        public override bool CanExecute() => Shell.Graphs.Count > 0;

        public override void Execute(params string[] args)
        {
            if (args.Length > 1)
            {
                Console.WriteLine("Too many arguments");
                return;
            }

            ConsoleColor color = (ConsoleColor)(Convert.ToInt32(args[0]) % 16);
            Target.Color = color;
        }
    }
}
