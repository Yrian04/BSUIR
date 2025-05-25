using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Editor_Console
{
    internal class RunCommand : Command
    {
        public override string Name => "RUN";

        public override string[] Help => new string[] {"RUN [script file]"};

        public override bool CanExecute() => true;

        public override void Execute(params string[] args)
        {
            if(!File.Exists(args[0]))
            {
                Console.WriteLine("File not exist");
                return;
            }
            string[] commandLine = File.ReadAllLines(args[0]);
            foreach (string line in commandLine)
                Shell.Execute(line);
        }
    }
}
