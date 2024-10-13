using System.Text.Json;
using System.Text.Json.Serialization;
namespace task_cli
{

    internal class Program
    {

        private static void Main(string[] args)
        {
            string dataFilePath = "data.json";
            bool isRunning = true;
            JsonSerializerOptions options = new()
            {
                Converters = { new JsonStringEnumConverter() }
            };

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
                            DisplayTodoTasks(dataFilePath, options);
                            break;

                        case "list in-progress":
                            DisplayInprogressTasks(dataFilePath, options);
                            break;

                        case "list done":
                            DisplayCompletedTasks(dataFilePath, options);
                            break;

                        case "list":
                            DisplayAllTasks(dataFilePath, options);
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

        private static void DisplayTodoTasks(string dataFilePath, JsonSerializerOptions options)
        {
            PrintStuff(dataFilePath, options, Status.Todo);
        }

        private static void PrintStuff(string dataFilePath, JsonSerializerOptions options, Status? todo)
        {
            var jsonFile = File.ReadAllText(dataFilePath);
            List<Todo>? people = JsonSerializer.Deserialize<List<Todo>>(jsonFile, options);
            if (todo is null)
            {
                people?.ForEach(PrintTask);
            }
            else
            {
                people?.Where(x => x.Status.Equals(todo)).ToList().ForEach(PrintTask);
            }
        }

        private static void DisplayInprogressTasks(string dataFilePath, JsonSerializerOptions options)
        {
            PrintStuff(dataFilePath, options, Status.Inprogress);
        }

        private static void DisplayCompletedTasks(string dataFilePath, JsonSerializerOptions options)
        {
            PrintStuff(dataFilePath, options, Status.Done);
        }

        private static void DisplayAllTasks(string filePath, JsonSerializerOptions options)
        {
            var jsonFile = File.ReadAllText(filePath);
            List<Todo>? people = JsonSerializer.Deserialize<List<Todo>>(jsonFile, options);
            people?.ForEach(t => PrintTask(t));
        }

        private static void PrintTask(Todo t)
        {
            Console.WriteLine($"ID:             {t.Id}");
            Console.WriteLine($"Description:    {t.Description}");
            Console.WriteLine($"Status:         {t.Status}");
            Console.WriteLine($"Created At:     {t.CreatedAt}");
            Console.WriteLine($"Updated At:     {t.UpdatedAt}");
            Console.WriteLine();
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