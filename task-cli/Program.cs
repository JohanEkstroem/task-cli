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
                    input = input.Trim().ToLower();
                    switch (input)
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
                            todoService.DoSomeWonkyStuff(input);
                            break;
                    }
                }
            }
        }
    }
}