using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using PixelLab.Common;
using Tasks.Show.Models;

namespace Tasks.Show.ViewModels
{
    public class TaskListViewModel : INotifyPropertyChanged
    {
        #region Fields

        private EditTask m_newTask;
        private readonly CommandWrapper<Task> m_deleteTaskCommand;
        private readonly Func<Task, bool> m_filter;
        private readonly TaskData m_taskList;
        private readonly ObservableCollectionPlus<TaskViewModel> m_unfilteredTaskList;

        #endregion Fields

        #region Constructors

        public TaskListViewModel(TaskData taskList, Func<Task, bool> filter)
        {
            Util.RequireNotNull(taskList, "taskList");
            m_taskList = taskList;
            ((INotifyCollectionChanged)m_taskList.Tasks).CollectionChanged += (sender, args) => RefreshFilter();

            Util.RequireNotNull(filter, "filter");
            m_filter = filter;

            m_unfilteredTaskList = new ObservableCollectionPlus<TaskViewModel>();
            m_taskList.Tasks.ForEach(t => m_unfilteredTaskList.Add(new TaskViewModel(t)));

            // Tasks
            m_newTaskCommand = new CommandWrapper(ShowNewTask, () => m_newTask == null);
            m_cancelNewTaskCommand = new CommandWrapper(() => CancelNewTask(), () => m_newTask != null);
            m_deleteTaskCommand = new CommandWrapper<Task>(task => DeleteTask(task), task => true);
        }

        #endregion Constructors

        #region Properties

        public ReadOnlyObservableCollection<TaskViewModel> AllTasks
        {
            get { return m_unfilteredTaskList.ReadOnly; }
        }

        public ICommand CancelNewCommand { get { return m_cancelNewTaskCommand.Command; } }

        public ICommand DeleteTaskCommand { get { return m_deleteTaskCommand.Command; } }

        public EditTask NewTask
        {
            get { return m_newTask; }
            private set
            {
                if (m_newTask != value)
                {
                    if (m_newTask != null)
                    {
                        m_newTask.Committed -= new_task_committed;
                    }
                    m_newTask = value;
                    if (m_newTask != null)
                    {
                        m_newTask.Committed += new_task_committed;
                    }

                    m_newTaskCommand.UpdateCanExecute();
                    m_cancelNewTaskCommand.UpdateCanExecute();

                    OnPropertyChanged(new PropertyChangedEventArgs("NewTask"));
                }
            }
        }

        public ICommand NewTaskCommand { get { return m_newTaskCommand.Command; } }

        #endregion Properties

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Events

        #region Event Handlers

        private void new_task_committed(object sender, EventArgs e)
        {
            Debug.Assert(m_newTask != null);
            var newTask = m_taskList.AddTask(m_newTask.Task, App.Root.FolderColorOptions);
            m_unfilteredTaskList.Add(new TaskViewModel(newTask));
            m_taskList.CurrentFolder = newTask.EffectiveFolder;

            CancelNewTask();
        }

        #endregion Event Handlers

        #region Public Methods

        public void CancelNewTask()
        {
            NewTask = null;
        }

        public void DeleteTask(Task task)
        {
            TaskViewModel tvm = m_unfilteredTaskList.First(t => t.Task == task);
            m_unfilteredTaskList.Remove(tvm);

            m_taskList.RemoveTask(task);
        }

        public void MoveTask(Task item, Task toItem)
        {
            var itemIndex = m_taskList.Tasks.IndexOf(item);
            var toIndex = m_taskList.Tasks.IndexOf(toItem);
            m_taskList.ReorderTasks(item, toItem);
            m_unfilteredTaskList.Move(itemIndex, toIndex);
        }

        public void RefreshFilter()
        {
            m_unfilteredTaskList.ForEach(tm => tm.IsVisible = m_filter(tm.Task));
        }

        public void ShowNewTask()
        {
            if (m_newTask == null)
            {
                NewTask = new EditTask();
            }
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

        private readonly CommandWrapper m_newTaskCommand, m_cancelNewTaskCommand;
    }
}
