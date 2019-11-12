using System;
using System.ComponentModel;
using Tasks.Show.Helpers;
using PixelLab.Common;

namespace Tasks.Show.Models
{
    public abstract class BaseTask : INotifyPropertyChanged
    {
        #region Properties

        public Nullable<DateTime> Completed
        {
            get { return m_completed; }
            set
            {
                if (value != m_completed)
                {
                    m_completed = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Completed"));
                    OnPropertyChanged(new PropertyChangedEventArgs("IsComplete"));
                }
            }
        }

        public string Description
        {
            get { return m_description; }
            set
            {
                value = value.SuperTrim();
                if (value != m_description)
                {
                    m_description = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Description"));
                }
            }
        }

        public Nullable<DateTime> Due
        {
            get { return m_due; }
            set
            {
                if (value != m_due)
                {
                    m_due = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Due"));
                }
            }
        }

        public Nullable<TimeSpan> Estimate
        {
            get { return m_estimate; }
            set
            {
                Util.RequireArgument(!value.HasValue || value.Value.Ticks >= 0, "value");
                if (value != m_estimate)
                {
                    m_estimate = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Estimate"));
                }
            }
        }

        public bool IsComplete
        {
            get { return m_completed.HasValue; }
        }

        public bool? IsImportant
        {
            get { return m_isImportant; }
            set
            {
                if (value != m_isImportant)
                {
                    m_isImportant = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("IsImportant"));
                }
            }
        }

        public DateTime? RelevantDate
        {
            get { return this.IsComplete ? this.Completed : this.Due; }
        }

        public abstract string FolderName { get; set; }

        #endregion Properties

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Events

        #region Public Methods

        public Task CloneWithFolder(Folder folder)
        {
            return new Task() { Completed = this.Completed, Description = this.Description, Due = this.Due, Estimate = this.Estimate, Folder = folder, IsImportant = this.IsImportant };
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}",
                base.ToString(),
                m_description);
        }

        #endregion Public Methods

        #region Protected Methods

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion Protected Methods

        #region private instance impl

        private string m_description;
        private Nullable<DateTime> m_due;
        private Nullable<DateTime> m_completed;
        private Nullable<TimeSpan> m_estimate;
        private bool? m_isImportant = null;

        #endregion
    }
}
