using System.Reactive;
using Avalonia.TodoList.App.Models;
using ReactiveUI;

namespace Avalonia.TodoList.App.ViewModels.Todo;

public class AddItemViewModel : ViewModelBase
{
    private string _description;

    public AddItemViewModel()
    {
        var saved = this.WhenAnyValue(d => d.Description,
            d => !string.IsNullOrWhiteSpace(d));
        Ok = ReactiveCommand.Create(() => new TodoItem(){Description = Description}, saved);
        Cancel = ReactiveCommand.Create(() => { });
    }
    
    public string Description
    {
        get => _description;
        set => this.RaiseAndSetIfChanged(ref _description, value);
    }

    public ReactiveCommand<Unit,TodoItem> Ok { get; }
    public ReactiveCommand<Unit, Unit> Cancel { get; }
}