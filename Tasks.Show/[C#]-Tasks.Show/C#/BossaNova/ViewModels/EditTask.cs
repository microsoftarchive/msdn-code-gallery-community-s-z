using System;
using System.Collections.Generic;
using System.ComponentModel;
using Tasks.Show.Models;
using Tasks.Show.Utils;
using PixelLab.Common;
using Tasks.Show.Helpers;

namespace Tasks.Show.ViewModels
{
    public class EditTask : INotifyPropertyChanged, IDataErrorInfo
    {
		#region Constructors 

        public EditTask()
        {
            m_task = new DraftTask();
            m_task.PropertyChanged += task_propertyChanged;
            validateDescription();
        }

		#endregion Constructors 

		#region Properties 

        public string DescriptionString
        {
            get { return (Task == null) ? null : Task.Description; }
            set { Task.Description = value; }
        }

        public string DueString
        {
            get
            {
                if (Task == null) return null;
                return PrettyDateConverter.Convert(Task.Due, false);
            }
            set
            {
                string errorMessage = null;
                value = value.SuperTrim();
                if (value == null)
                {
                    Task.Due = null;
                }
                else
                {
                    Task.Due = DateParser.ParseDate(value);
                    if (Task.Due == null) errorMessage = "Could not parse the inputted value";
                }

                setError("DueString", errorMessage);

            }
        }

        public bool HasErrors
        {
            get
            {
                validateDescription();
                return !m_propertyErrors.IsEmpty();
            }
        }

        public DraftTask Task
        {
            get
            {
                return m_task;
            }
            private set
            {
                if (m_task != null) m_task.PropertyChanged -= task_propertyChanged;
                m_task = value;
                if (m_task != null) m_task.PropertyChanged += task_propertyChanged;
                //TODO: re-parse the task string

                validateDescription();

                OnPropertyChanged(new PropertyChangedEventArgs("Task"));
                OnPropertyChanged(new PropertyChangedEventArgs("DueString"));
                OnPropertyChanged(new PropertyChangedEventArgs("DescriptionString"));
            }
        }

        public string TaskString
        {
            get { return m_taskString; }
            set
            {
                if (value != m_taskString)
                {
                    m_taskString = value;
                    string parseError = null;
                    Task = TaskParser.TryParse(value, out parseError);
                    setError("TaskString", parseError);
                    OnPropertyChanged(new PropertyChangedEventArgs("TaskString"));
                }
            }
        }

		#endregion Properties 

		#region Events 

        public event EventHandler Committed;

        public event PropertyChangedEventHandler PropertyChanged;

		#endregion Events 

		#region Public Methods 

        public void Commit()
        {
            OnCommitted(EventArgs.Empty);
        }

		#endregion Public Methods 

		#region Protected Methods 

        protected virtual void OnCommitted(EventArgs e)
        {
            var handler = Committed;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

		#endregion Protected Methods 

        #region IDataErrorInfo Members

        string IDataErrorInfo.Error
        {
            get { throw new NotImplementedException(); }
        }

        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                string error = null;
                m_propertyErrors.TryGetValue(columnName, out error);
                return error;
            }
        }

        #endregion

        #region Private Instance Implementation

        private void setError(string columnName, string errorString)
        {
            Util.RequireNotNullOrEmpty(columnName, "columnName");
            if (errorString == null)
            {
                m_propertyErrors.Remove(columnName);
            }
            else
            {
                m_propertyErrors[columnName] = errorString;
            }
        }

        private void task_propertyChanged(object sender, PropertyChangedEventArgs args)
        {
            switch (args.PropertyName)
            {
                case "Due":
                    OnPropertyChanged(new PropertyChangedEventArgs("DueString"));
                    return;
                case "Description":
                    validateDescription();
                    OnPropertyChanged(new PropertyChangedEventArgs("DescriptionString"));
                    return;
            }
            m_taskString = null;
            OnPropertyChanged(new PropertyChangedEventArgs("TaskString"));
        }

        private void validateDescription()
        {
            if (Task == null) return;
            string errorMessage = null;
            if (Task.Description == null)
            {
                errorMessage = "Description shouldn't be null";
            }
            setError("DescriptionString", errorMessage);
        }

        private string m_taskString;
        private DraftTask m_task;
        private readonly Dictionary<string, string> m_propertyErrors =
          new Dictionary<string, string>();

        #endregion
    }
}
