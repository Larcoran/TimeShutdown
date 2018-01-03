using System;
using System.Diagnostics;
using System.Threading;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
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

        DispatcherTimer hoursTimer = new DispatcherTimer();
        hoursTimer.Interval = new TimeSpan(1, 0, 0);
        hoursTimer.Tick += hoursTicker;
        hoursTimer.Start();

        DispatcherTimer minutesTimer = new DispatcherTimer();
        minutesTimer.Interval = new TimeSpan(0, 1, 0);
        minutesTimer.Tick += minutesTicker;
        minutesTimer.Start();

        DispatcherTimer secondsTimer = new DispatcherTimer();
        secondsTimer.Interval = new TimeSpan(0, 0, 1);
        secondsTimer.Tick += secondsTicker;
        secondsTimer.Start();

        Process.Start("shutdown", string.Format("/s /t {0}", num));
    }

    private void hoursTicker(object sender, EventArgs e)
    {
        parent.SelectedHours--;
    }

    private void minutesTicker(object sender, EventArgs e)
    {
        parent.SelectedMinutes--;
    }

    private void secondsTicker(object sender, EventArgs e)
    {
        if (parent.SelectedSeconds == 00)
        { parent.SelectedSeconds = 59; }
        else
        {
            parent.SelectedSeconds--;
        }
    }

    private void t_Tick(object sender, EventArgs e)
    {

    }
}