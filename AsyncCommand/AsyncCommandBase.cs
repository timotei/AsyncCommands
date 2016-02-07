using System;
using System.ComponentModel;
using System.Threading.Tasks;

public abstract class AsyncCommandBase : IAsyncCommand
{
    public abstract bool CanExecute(object parameter);

    public abstract Task ExecuteAsync(object parameter);

    public async void Execute(object parameter)
    {
        await ExecuteAsync(parameter);
    }

    public event EventHandler CanExecuteChanged;

    protected void RaiseCanExecuteChanged()
    {
        var handler = CanExecuteChanged;
        if (handler != null) handler(this, new PropertyChangedEventArgs("CanExecute"));
    }
}
