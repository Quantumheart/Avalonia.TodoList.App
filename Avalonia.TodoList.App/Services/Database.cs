using System.Collections;
using System.Collections.Generic;
using Avalonia.TodoList.App.Models;

namespace Avalonia.TodoList.App.Services;

public class Database
{
    public IEnumerable<TodoItem> GetItems() => new[]
    {

        new TodoItem { Description = "Walk the dog" },
        new TodoItem { Description = "Bath the dog" },
        new TodoItem { Description = "Feed the dog", IsChecked = true},
    };
}