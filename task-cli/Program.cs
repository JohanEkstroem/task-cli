using System.Data;
using System.Text.Json;
namespace task_cli
{

    internal class Program
    {
        private static void Main(string[] args)
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("task-cli ");

                Console.ForegroundColor = ConsoleColor.Yellow;
                string? input = Console.ReadLine();
                if (input != null)
                {
                    switch (input.Trim().ToLower())
                    {

                        case "list":
                            DisplayAllTasks();
                            break;

                        case "man":
                            DisplayManualInfo();
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

        private static void DisplayAllTasks()
        {
            string filePath = "data.json";
            var jsonFile = File.ReadAllText(filePath);
            List<Todo>? people = JsonSerializer.Deserialize<List<Todo>>(jsonFile);
            people?.ForEach(t =>
            {
                Console.WriteLine($"ID:             {t.Id}");
                Console.WriteLine($"Description:    {t.Description}");
                Console.WriteLine();
            });

        }

        private static void DisplayManualInfo()
        {
            Console.WriteLine("Available commands:");
            Console.WriteLine("  add <task>                     - Add new task.");
            Console.WriteLine("  update <id> <task>             - Update existing task.");
            Console.WriteLine("  delete <id>                    - Delete task.");
            Console.WriteLine("  mark-in-progress <id>          - Mark task as in-progress.");
            Console.WriteLine("  mark-done <id>                 - Mark task as done.");
            Console.WriteLine("  list                           - List all tasks.");
            Console.WriteLine("  list done                      - List all completed tasks.");
            Console.WriteLine("  list todo                      - List tasks not in-progress.");
            Console.WriteLine("  list in-progress               - List tasks in-progress.");
            Console.WriteLine();
        }
    }
}