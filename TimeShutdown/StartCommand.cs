using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using TimeShutdown;

internal class StartCommand : ICommand
{
    private MainWindowViewModel parent;

    public event EventHandler CanExecuteChanged;

    public StartCommand(MainWindowViewModel parent)
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
        int num = this.parent.SelectedHours * 3600 + this.parent.SelectedMinutes * 60;
        MessageBox.Show(string.Format("Uruchamiam wyłączanie komputera za {0} godzin i {1} minut !", this.parent.SelectedHours, this.parent.SelectedMinutes));
        Process.Start("shutdown", string.Format("/s /t {0}", num));
    }
}