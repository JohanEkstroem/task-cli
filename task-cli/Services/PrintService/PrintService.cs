using System.Text.Json;
using task_cli.Models;
using task_cli.Services.Fileservice;

namespace task_cli.Services.PrintService;

public class PrintService : IPrintService
{
    private readonly FileService fileService = new();

    public void PrintAllTasks()
    {
        PrintStuff();
    }

    public void PrintCompletedTasks()
    {
        PrintStuff(Status.Done);
    }

    public void PrintInprogressTasks()
    {
        PrintStuff(Status.Inprogress);
    }

    public void PrintTodoTasks()
    {
        PrintStuff(Status.Todo);
    }

    private void PrintStuff(Status? todo = null)
    {
        var todoList = fileService.GetTodoList().ToList();

        if (todo is null)
        {
            todoList.ForEach(PrintTask);
        }
        else
        {
            todoList?.Where(x => x.Status.Equals(todo)).ToList().ForEach(PrintTask);
        }
    }
    public void PrintHelpInfo()
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
        Console.WriteLine("  exit                           - Close program. No shit?");
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
