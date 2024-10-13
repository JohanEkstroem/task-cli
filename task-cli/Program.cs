using System.Text.Json;
using System.Text.Json.Serialization;
using task_cli.Services.PrintService;
using task_cli.Services.Todoservice;
namespace task_cli
{

    internal class Program
    {
        private static void Main(string[] args)
        {
            var printService = new PrintService();
            var todoService = new TodoService();
            bool isRunning = true;

            while (isRunning)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("task-cli ");

                Console.ForegroundColor = ConsoleColor.Yellow;
                string? input = Console.ReadLine();
                Console.ResetColor();

                if (input != null)
                {
                    input = input.Trim();
                    switch (input)
                    {
                        case var _ when input.StartsWith("list todo", StringComparison.OrdinalIgnoreCase):
                            printService.PrintTodoTasks();
                            break;

                        case var _ when input.StartsWith("list in-progress", StringComparison.OrdinalIgnoreCase):
                            printService.PrintInprogressTasks();
                            break;

                        case var _ when input.StartsWith("list done", StringComparison.OrdinalIgnoreCase):
                            printService.PrintCompletedTasks();
                            break;

                        case var _ when input.StartsWith("list", StringComparison.OrdinalIgnoreCase):
                            printService.PrintAllTasks();
                            break;

                        case var _ when input.StartsWith("help", StringComparison.OrdinalIgnoreCase):
                            printService.PrintHelpInfo();
                            break;

                        case var _ when input.StartsWith("exit", StringComparison.OrdinalIgnoreCase):
                            isRunning = false;
                            Console.WriteLine("Program shutdown");
                            break;

                        default:
                            todoService.DoSomeWonkyStuff(input);
                            break;
                    }
                }
            }
        }
    }
}