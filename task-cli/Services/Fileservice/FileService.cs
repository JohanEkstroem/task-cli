using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using task_cli.Models;

namespace task_cli.Services.Fileservice;

public class FileService : IFileService
{

    private readonly string dataFilePath = "Data/data.json";
    private readonly JsonSerializerOptions options = new()
    {
        Converters = { new JsonStringEnumConverter() },
        WriteIndented = true
    };

    public List<Todo> GetTodoList()
    {
        return ReadFile(dataFilePath, options);
    }

    public void SaveTodoList(List<Todo> todos)
    {
        WriteFile(dataFilePath, todos, options);
    }

    private static void WriteFile(string dataFilePath, IList<Todo> todoList, JsonSerializerOptions options)
    {
        string updatedJson = JsonSerializer.Serialize(todoList, options);
        File.WriteAllText(dataFilePath, updatedJson);
    }

    private static List<Todo> ReadFile(string dataFilePath, JsonSerializerOptions options)
    {
        // TODO: add handling for missing data.json
        var jsonFile = File.ReadAllText(dataFilePath);
        List<Todo>? tasks = [.. JsonSerializer.Deserialize<List<Todo>>(jsonFile, options)];
        return tasks ?? [];
    }

}
