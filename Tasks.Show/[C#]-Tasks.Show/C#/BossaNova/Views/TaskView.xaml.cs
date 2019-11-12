using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using Tasks.Show.Models;
using Tasks.Show.ViewModels;

namespace Tasks.Show.Views
{
    public partial class TaskView : UserControl
    {
        #region Constructors

        public TaskView()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Event Handlers

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Opacity = 0.85;
            this.IsEnabled = false;

            Action a = () =>
                {
                    Task t = (this.DataContext as TaskViewModel).Task;
                    if (t != null)
                    {
                        ApplicationCommands.Delete.Execute(t, this as IInputElement);
                    }
                };

            Dispatcher.Invoke(a, DispatcherPriority.Background);
        }

        private void FolderComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // we set the new value manually to avoid a two way binding (the two
            // way binding had some timing issues with the Folders.RefreshFolders 
            // method that caused us to lose folder data

            if (e.AddedItems != null && e.AddedItems.Count > 0)
            {
                Folder folder = e.AddedItems[0] as Folder;
                if (folder == null) return;

                // get the folder object from the datacontext and set the new folder
                TaskViewModel tvm = (sender as FrameworkElement).DataContext as TaskViewModel;
                tvm.Task.Folder = folder;
            }
        }

        #endregion Event Handlers

        private void FolderDropDown_RequestFolderChange(object sender, UserControls.RequestFolderChangeEventArgs e)
        {
            TaskViewModel v = DataContext as TaskViewModel;
            if (v != null)
            {
                Debug.Assert(v.Task == e.Task);
                var destination = App.Root.TaskData.MoveTask(v.Task, e.FolderName, App.Root.FolderColorOptions);
                App.Root.TaskData.CurrentFolder = destination;
            }
        }
    }
}
