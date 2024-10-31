using System;
using task_cli.Models;

namespace task_cli.Services.CommandService;

public interface ICommandService
{
    Command ConvertInputToCommand(string input);
}
