using System;
using task_cli.Models;

namespace task_cli.Services.Todoservice;

public interface ITodoService
{
    void AddTodo(string input);
    // void DeleteTodo(int id);
    // void UpdateTodo(Todo todo);
    // void MarkInprogress(int id);
    // void MarkDone(int id);
}
