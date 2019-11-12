namespace ClientWorkflow.WPF
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Input;

    using ClientWorkflow.Model;

    public class CounterViewModel : INotifyPropertyChanged
    {
        #region Constants and Fields

        public Action CountCanceled;

        public Action CountCompleted;

        public Action CountStarted;

        private readonly RelayCommand cancelCommand;

        private readonly ICountModel model = CountModelFactory.CreateModel();

        private readonly RelayCommand startCommand;

        private IAsyncResult cancelAsr;

        private int countTo;

        private int currentCount;

        private bool isCounting;

        private string status;

        #endregion

        #region Constructors and Destructors

        public CounterViewModel()
        {
            this.startCommand = new RelayCommand(
                param => this.StartCounting(),
                param => this.CanStartCounting());

            this.cancelCommand = new RelayCommand(
                param => this.CancelCounting(),
                param => this.CanCancelCounting());

            this.CountTo = 100;
            this.Status = "Ready!";

            // Register callbacks for the model
            this.model.CountCanceled = this.OnCountCanceled;
            this.model.CountCompleted = this.OnCountCompleted;
            this.model.CountStarted = this.OnCountStarted;
            this.model.CountUpdated = this.OnCountUpdated;
        }

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        public ICommand CancelCommand
        {
            get
            {
                return this.cancelCommand;
            }
        }

        public int CountTo
        {
            get
            {
                return this.countTo;
            }
            set
            {
                // Can't change while counting
                if (this.IsCounting)
                {
                    throw new InvalidOperationException();
                }

                this.countTo = value;
                this.RaisePropertyChanged("CountTo");
            }
        }

        public int CurrentCount
        {
            get
            {
                return this.currentCount;
            }
            private set
            {
                this.currentCount = value;
                this.RaisePropertyChanged("CurrentCount");
            }
        }

        public bool IsCounting
        {
            get
            {
                return this.isCounting;
            }
            private set
            {
                this.isCounting = value;
                // Commands need to be updated when this value changes
                RequeryCommands();
                this.RaisePropertyChanged("IsCounting");
            }
        }

        public ICommand StartCommand
        {
            get
            {
                return this.startCommand;
            }
        }

        public string Status
        {
            get
            {
                return this.status;
            }
            private set
            {
                this.status = value;
                this.RaisePropertyChanged("Status");
                Debug.WriteLine(this.status);
            }
        }

        #endregion

        #region Public Methods

        public bool CanCancelCounting()
        {
            return this.isCounting;
        }

        public bool CanStartCounting()
        {
            return !this.isCounting;
        }

        public void CancelCounting()
        {
            this.model.CancelCounting();
        }

        public void StartCounting()
        {
            this.model.StartCounting(this.CountTo);
        }

        #endregion

        #region Methods

        internal void ViewClosed(object sender, EventArgs e)
        {
            this.model.EndCancelCounting(this.cancelAsr);
        }

        internal void ViewClosing(object sender, CancelEventArgs e)
        {
            this.cancelAsr = this.model.BeginCancelCounting(null, null);
        }

        private static void RequeryCommands()
        {
            // May be called at shutdown
            if (Application.Current != null)
            {
                Application.Current.Dispatcher.Invoke(
                    (Action)(CommandManager.InvalidateRequerySuggested));
            }
        }

        private void OnCountCanceled()
        {
            this.Status = "Count Canceled";
            this.IsCounting = false;

            if (this.CountCanceled != null)
            {
                this.CountCanceled();
            }
        }

        private void OnCountCompleted()
        {
            this.Status = "Count Completed";
            this.IsCounting = false;

            if (this.CountCompleted != null)
            {
                this.CountCompleted();
            }
        }

        private void OnCountStarted()
        {
            this.Status = "Count Started";
            this.IsCounting = true;

            if (this.CountStarted != null)
            {
                this.CountStarted();
            }
        }

        private void OnCountUpdated(int count)
        {
            this.Status = string.Format("Count is {0}", count);
            this.CurrentCount = count;
        }

        private void RaisePropertyChanged(string prop)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        #endregion
    }
}