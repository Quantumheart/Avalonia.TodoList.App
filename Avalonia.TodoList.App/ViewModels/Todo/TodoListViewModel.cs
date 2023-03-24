using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia.TodoList.App.Models;

namespace Avalonia.TodoList.App.ViewModels.Todo;

public class TodoListViewModel : ViewModelBase
{
    public ObservableCollection<TodoItem> Items { get; }

    public TodoListViewModel(IEnumerable<TodoItem> items)
    {
        Items = new ObservableCollection<TodoItem>(items);
    }
}