using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Media;
using System.Windows.Threading;
using Tasks.Show.Helpers;
using Tasks.Show.Models;
using PixelLab.Common;
using System.Collections.ObjectModel;

namespace Tasks.Show.ViewModels
{
    public class Root : INotifyPropertyChanged
    {
        #region Fields

        private readonly TaskData m_taskData;
        private readonly ReadOnlyCollection<Color> m_folderColorOptions;

        #endregion Fields

        #region Constructors

        public Root(TaskData taskData, IEnumerable<Color> folderColorOptions)
        {
            Util.RequireNotNull(taskData, "taskData");
            m_taskData = taskData;

            Util.RequireNotNull(folderColorOptions, "folderColorOptions");
            m_folderColorOptions = folderColorOptions.ToReadOnlyCollection();

            Tasks = new TaskListViewModel(taskData, filter);
            Timeline = new TimelineViewModel(Tasks.AllTasks);

            Filters = new Filters(taskData);
            Folders = new Folders(taskData);

            taskData.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == "CurrentFolder" || args.PropertyName == "Filter")
                {
                    Tasks.RefreshFilter();
                }
            };

            DispatcherTimer dateChanger = new DispatcherTimer();
            dateChanger.Interval = TimeSpan.FromMinutes(1);
            dateChanger.Tick += new EventHandler(dateChanger_Tick);
            Tasks.RefreshFilter();
        }

        #endregion Constructors

        #region Properties

        public TaskData TaskData { get { return m_taskData; } }

        public IList<Color> FolderColorOptions { get { return m_folderColorOptions; } }

        public Filters Filters { get; private set; }

        public Folders Folders { get; private set; }

        public TaskListViewModel Tasks { get; private set; }

        public TimelineViewModel Timeline { get; private set; }

        public DateTime Now { get { return DateTime.Now; } }

        public DateTime Today { get { return DateTime.Today; } }

        #endregion Properties

        #region Event Handlers

        void dateChanger_Tick(object sender, EventArgs e)
        {
            var handler = PropertyChanged;
            if (handler != null)
        {
                handler(this, new PropertyChangedEventArgs("Today"));
                handler(this, new PropertyChangedEventArgs("Now"));
        }
        }

        #endregion Event Handlers

        #region Private Methods

        private bool filter(Task task)
        {
            return Filters.InCurrent(task) && TaskData.CurrentFolder.ContainsTask(task);
        }

        #endregion Private Methods

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
