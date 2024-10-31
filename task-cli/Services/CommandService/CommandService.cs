using System;
using System.Windows.Input;
using task_cli.Models;

namespace task_cli.Services.CommandService;

public class CommandService : ICommandService
{
    public Command ConvertInputToCommand(string input)
    {

        return new Command("apa", 1, "apa");
    }
}