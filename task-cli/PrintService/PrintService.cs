using System.Text.Json;
using System.Text.Json.Serialization;
using task_cli.Models;

namespace task_cli.Printservice;

public class PrintService : IPrintService
{
    private JsonSerializerOptions options = new()
    {
        Converters = { new JsonStringEnumConverter() }
    };
    private readonly string dataFilePath = "Data/data.json";

    public void DisplayAllTasks()
    {
        PrintStuff(dataFilePath, options);
    }

    public void DisplayCompletedTasks()
    {
        PrintStuff(dataFilePath, options, Status.Done);
    }

    public void DisplayInprogressTasks()
    {
        PrintStuff(dataFilePath, options, Status.Inprogress);
    }

    public void DisplayTodoTasks()
    {
        PrintStuff(dataFilePath, options, Status.Todo);
    }

    private static void PrintStuff(string dataFilePath, JsonSerializerOptions options, Status? todo = null)
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
    public void DisplayManualInfo()
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
    private static void PrintTask(Todo t)
    {
        Console.WriteLine($"ID:             {t.Id}");
        Console.WriteLine($"Description:    {t.Description}");
        Console.WriteLine($"Status:         {t.Status}");
        Console.WriteLine($"Created At:     {t.CreatedAt}");
        Console.WriteLine($"Updated At:     {t.UpdatedAt}");
        Console.WriteLine();
    }
}
