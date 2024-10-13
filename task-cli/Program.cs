using System.Text.Json;
using System.Text.Json.Serialization;
using task_cli.Services.PrintService;
namespace task_cli
{

    internal class Program
    {
        private static void Main(string[] args)
        {
            var printService = new PrintService();
            bool isRunning = true;

            while (isRunning)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("task-cli ");

                Console.ForegroundColor = ConsoleColor.Yellow;
                string? input = Console.ReadLine();
                if (input != null)
                {
                    Console.ResetColor();
                    switch (input.Trim().ToLower())
                    {
                        case "list todo":
                            printService.PrintTodoTasks();
                            break;

                        case "list in-progress":
                            printService.PrintInprogressTasks();
                            break;

                        case "list done":
                            printService.PrintCompletedTasks();
                            break;

                        case "list":
                            printService.PrintAllTasks();
                            break;

                        case "help":
                            printService.PrintHelpInfo();
                            break;

                        case "exit":
                            isRunning = false;
                            Console.WriteLine("Program shutdown");
                            break;

                        default:
                            Console.WriteLine("Invalid input. Type 'help' for available commands");
                            break;
                    }
                }
            }
        }
    }
}