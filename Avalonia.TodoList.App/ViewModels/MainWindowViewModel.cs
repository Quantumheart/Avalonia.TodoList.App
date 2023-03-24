using System;
using System.Reactive.Linq;
using Avalonia.TodoList.App.Models;
using Avalonia.TodoList.App.Services;
using Avalonia.TodoList.App.ViewModels.Todo;
using ReactiveUI;

namespace Avalonia.TodoList.App.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private ViewModelBase _content;
    public TodoListViewModel ListViewModel { get; }
    public MainWindowViewModel(Database db)
    {
        Content = ListViewModel = new TodoListViewModel(db.GetItems());
    }

    public ViewModelBase Content
    {
        get => _content;
        private set => this.RaiseAndSetIfChanged(ref _content, value);
    }

    public void AddTodoItem()
    {
        var vm = new AddItemViewModel();
        Observable.Merge(vm.Ok, vm.Cancel.Select(d => (TodoItem)null))
                  .Take(1)
                  .Subscribe(new Action<TodoItem>(model =>
                  {
                      if (model != null)
                      {
                          ListViewModel.Items.Add(model);
                      }

                      Content = ListViewModel;
                  }));
        Content = vm;
    }
}