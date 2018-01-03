using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using TimeShutdown;

internal class StopCommand : ICommand
{
    private MainWindowViewModel parent;

    public event EventHandler CanExecuteChanged;

    public StopCommand(MainWindowViewModel parent)
    {
        this.parent = parent;
        parent.PropertyChanged += delegate
        {
            EventHandler canExecuteChanged = this.CanExecuteChanged;
            if (canExecuteChanged != null)
            {
                canExecuteChanged(this, EventArgs.Empty);
            }
        };
    }

    public bool CanExecute(object parameter)
    {
        return true;
    }

    public void Execute(object parameter)
    {
        MessageBox.Show("Wyłączanie komputera zatrzymane !");
        Process.Start("shutdown", string.Format("/a", Array.Empty<object>()));
    }
}