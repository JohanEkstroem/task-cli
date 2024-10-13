namespace task_cli.Services.PrintService;

public interface IPrintService
{
    void PrintAllTasks();
    void PrintCompletedTasks();
    void PrintInprogressTasks();
    void PrintTodoTasks();
    void PrintHelpInfo();
}
