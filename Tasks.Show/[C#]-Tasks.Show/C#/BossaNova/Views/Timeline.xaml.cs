using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Tasks.Show.ViewModels;

namespace Tasks.Show.Views
{
    public partial class Timeline : UserControl
    {
        public Timeline()
        {
            InitializeComponent();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TaskViewModel tvm = (sender as FrameworkElement).DataContext as TaskViewModel;
            if (tvm != null)
            {
                App.Root.TaskData.CurrentFolder = tvm.Task.EffectiveFolder;
            }
        }

    }
}
