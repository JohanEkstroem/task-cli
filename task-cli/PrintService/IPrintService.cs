using System;
using System.Text.Json;

namespace task_cli.Printservice;

public interface IPrintService
{
    void DisplayAllTasks();
    void DisplayCompletedTasks();
    void DisplayInprogressTasks();
    void DisplayTodoTasks();
    void DisplayManualInfo();
}
