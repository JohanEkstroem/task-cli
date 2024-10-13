using System.Text.Json;
using System.Text.Json.Serialization;
using task_cli.Printservice;
namespace task_cli
{

    internal class Program
    {
        private static void Main(string[] args)
        {
            PrintService printService = new PrintService();
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
                            printService.DisplayTodoTasks();
                            break;

                        case "list in-progress":
                            printService.DisplayInprogressTasks();
                            break;

                        case "list done":
                            printService.DisplayCompletedTasks();
                            break;

                        case "list":
                            printService.DisplayAllTasks();
                            break;

                        case "man":
                            printService.DisplayManualInfo();
                            break;

                        case "exit":
                            isRunning = false;
                            Console.WriteLine("Program shutdown");
                            break;

                        default:
                            break;
                    }
                }
            }
        }
    }
}