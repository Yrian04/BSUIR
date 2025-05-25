using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph_Editor.Model;

namespace Graph_Editor_Console
{
    internal static class Shell
    {
        public static Dictionary<string, Command> Commands { get; } = new();
        public static Dictionary<string, Graph> Graphs { get; } = new();
        public static List<string[]> History { get; } = new();
        public static object? Target { get; set; }
        public static void Execute(string consoleLine)
        {
            string[] words = consoleLine.Split(' ');
            History.Add(words);
            Command? command;

            if (!Commands.TryGetValue(words[0], out command))
            {
                Console.WriteLine("Invalid command");
                return;
            }

            if (command is TargetCommand<Graph> tg)
            {
                if (Target is not Graph)
                {
                    Console.WriteLine("No target");
                    return;
                }
                tg.Target = (Graph)Target;
            }

            if (command is TargetCommand<Node> tn)
            {
                if (Target == null)
                {
                    Console.WriteLine("No target");
                    return;
                }
                tn.Target = (Node)Target;
            }

            if (command is TargetCommand<INamed> tnd)
            {
                if (Target == null)
                {
                    Console.WriteLine("No target");
                    return;
                }
                tnd.Target = (INamed)Target;
            }

            if (command is TargetCommand<IColored> tc)
            {
                if (Target == null)
                {
                    Console.WriteLine("No target");
                    return;
                }
                tc.Target = (IColored)Target;
            }

            if (!command!.CanExecute())
            {
                Console.WriteLine("Command can't be executed");
                return;
            }

            command.Execute(words[1..]);
        }
        public static void RegisterCommand(Command command) => Commands.Add(command.Name, command);
    }
}
