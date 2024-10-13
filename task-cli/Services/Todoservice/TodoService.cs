using System;
using task_cli.Models;

namespace task_cli.Services.Todoservice;

public class TodoService : ITodoService
{
    public void AddTodo(string input)
    {
        // Validate input
        // if valid: 
        // read data.json
        // add a new todo
        // write to file
        // print successful message

        // else print error message
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
