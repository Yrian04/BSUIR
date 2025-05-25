using Graph_Editor.Model;
using Graph_Editor_Console;

internal class Program
{
    private static void Main(string[] args)
    {
        Shell.RegisterCommand(new CreateGraphCommand());
        Shell.RegisterCommand(new AddCommand());
        Shell.RegisterCommand(new IncidentMatrixCommand());
        Shell.RegisterCommand(new ViewGraphListCommand());
        Shell.RegisterCommand(new ChangeTargetCommand());
        Shell.RegisterCommand(new RunCommand());
        Shell.RegisterCommand(new HelpCommand());
        Shell.RegisterCommand(new SaveCommand());
        Shell.RegisterCommand(new AdjacencyMatrixCommand());
        Shell.RegisterCommand(new DiameterCommand());
        Shell.RegisterCommand(new RemoveCommand());
        Shell.RegisterCommand(new RenameCommand());
        Shell.RegisterCommand(new InfoCommand());
        Shell.RegisterCommand(new CartesianProductCommand());
        Shell.RegisterCommand(new CompleteGraphCommand());
        Shell.RegisterCommand(new TensorProductCommand());
        Shell.RegisterCommand(new HamiltonianCircleCommand());
        Shell.RegisterCommand(new ColorCommand());
        while (true)
        {
            Console.Write($"{Shell.Target ?? ""}\\");
            string? str = Console.ReadLine();
            if (str == null)
                continue;
            if (str == "x")
                break;
            Shell.Execute(str);
        }
    }
}