using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TimeShutdown;

namespace TimeShutdown
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        private int mSelectedMinutes;

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
        } = new ObservableCollection<int>(Enumerable.Range(0, 24));


        public ObservableCollection<int> myMinutes
        {
            get;
            set;
        } = new ObservableCollection<int>(Enumerable.Range(0, 60));


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
    }
}

