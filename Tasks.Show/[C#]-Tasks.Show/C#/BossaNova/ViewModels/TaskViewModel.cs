using System;
using System.ComponentModel;
using PixelLab.Common;
using Tasks.Show.Models;

namespace Tasks.Show.ViewModels
{
    public class TaskViewModel : INotifyPropertyChanged
    {
        #region Fields

        private bool m_isVisible = true;

        #endregion Fields

        #region Constructors

        public TaskViewModel(Task task)
        {
            Util.RequireNotNull(task, "task");
            Task = task;

            task.PropertyChanged += (sender, args) =>
                {
                    if (args.PropertyName.Equals("Completed") || args.PropertyName.Equals("Due"))
                    {
                        OnPropertyChanged(new PropertyChangedEventArgs("SignificantDate"));
                    }
                };
        }

        #endregion Constructors

        #region Properties

        public bool IsVisible
        {
            get { return m_isVisible; }
            set
            {
                m_isVisible = value;
                OnPropertyChanged(new PropertyChangedEventArgs("IsVisible"));
            }
        }

        public DateTime? SignificantDate
        {
            get
            {
                if (this.Task.Due.HasValue)
                {
                    return this.Task.Due;
                }
                else
                {
                    return DateTime.Today;
                }
            }
        }

        public Task Task { get; private set; }

        #endregion Properties

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Events

        #region Protected Methods

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, args);
            }
        }

        #endregion Protected Methods
    }
}
