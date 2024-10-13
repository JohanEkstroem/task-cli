using System;
using task_cli.Models;

namespace task_cli.Services.Fileservice;

public interface IFileService
{
    List<Todo> GetTodoList();
    void SaveTodoList(List<Todo> todo);
}
