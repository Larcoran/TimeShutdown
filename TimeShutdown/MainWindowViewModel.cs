using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Input;
using System.Windows.Threading;
using TimeShutdown;

namespace TimeShutdown
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        private int mSelectedMinutes;
        private int mSelectedSeconds;
        private int mSelectedHours;

        public ICommand StartCommand
        {
            get;
            private set;
        }

        public ICommand StopCommand
        {
            get;
            private set;
        }

        public ObservableCollection<int> myHours
        {
            get;
            set;
        } = new ObservableCollection<int>(Enumerable.Range(00, 24));


        public ObservableCollection<int> myMinutes
        {
            get;
            set;
        } = new ObservableCollection<int>(Enumerable.Range(00, 60));


        public int SelectedMinutes
        {
            get
            {
                return this.mSelectedMinutes;
            }
            set
            {
                if (value != this.mSelectedMinutes)
                {
                    this.mSelectedMinutes = value;
                    this.OnPropertyChanged("SelectedMinutes");
                }
            }
        }

        public int SelectedSeconds
        {
            get
            {
                return this.mSelectedSeconds;
            }
            set
            {
                if (value != this.mSelectedSeconds)
                {
                    this.mSelectedSeconds = value;
                    this.OnPropertyChanged("SelectedSeconds");
                }
            }
        }

        public int SelectedHours
        {
            get
            {
                return this.mSelectedHours;
            }
            set
            {
                if (value != this.mSelectedHours)
                {
                    this.mSelectedHours = value;
                    this.OnPropertyChanged("SelectedHours");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowViewModel()
        {
            this.StartCommand = new StartCommand(this);
            this.StopCommand = new StopCommand(this);
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void timerOne()
        {
            Timer t = new Timer();
            t.
         }
    }
}

