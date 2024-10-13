using System;
using task_cli.Models;
using task_cli.Services.Fileservice;

namespace task_cli.Services.Todoservice;

public class TodoService : ITodoService
{
    private FileService fileService = new FileService();
    public void AddTodo(string input)
    {
        // Validate input
        // if valid: 
        // read data.json
        var todolist = fileService.GetTodoList();

        // add a new todo
        var description = input.Substring(input.IndexOf(' ') + 1);
        int newId = todolist.Count != 0 ? todolist.Max(obj => obj.Id) + 1 : 1;
        var newTodo = new Todo { Id = newId, Description = description, Status = Status.Todo, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now };
        todolist.Add(newTodo);

        fileService.SaveTodoList(todolist);
        Console.WriteLine($"Successfully added task: {newId}");
    }
    internal void DoSomeWonkyStuff(string input)
    {
        // Handle user input
        // Does the user want to:
        //  - add stuff?
        //  - update stuff?
        //  - delete stuff?
        //  - mark stuff?
        if (input == string.Empty)
        {
            Console.WriteLine("Invalid input. Type 'help' to show available commands.");
            return;
        }
        var inputCommand = input.Split(' ').First();
        switch (inputCommand)
        {
            case "add":
                AddTodo(input);
                break;

            default:
                break;
        }
    }
}
