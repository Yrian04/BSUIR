using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Editor_Console
{
    internal class HelpCommand : Command
    {
        public override string Name => "HELP";

        public override string[] Help => new string[] { "HELP [command]" };

        public override bool CanExecute() => true;

        public override void Execute(params string[] args)
        {
            if (args.Length > 1)
            {
                Console.WriteLine("Too mane arguments");
                return;
            }

            if (args.Length == 0)
                foreach (var command in Shell.Commands.Values)
                    ViewCommand(command);
            else
                ViewCommand(Shell.Commands[args[0]]);
        }

        private void ViewCommand(Command command)
        {
            Console.WriteLine("\t" + command.Name);
            Console.WriteLine(string.Join("\r\n",command.Help));
        }
    }
}
