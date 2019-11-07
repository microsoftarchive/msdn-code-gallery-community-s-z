using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace CrmMobileSample
{
    public partial class TasksPage : ContentPage
    {
        public TasksPage()
        {
            InitializeComponent();

            ToolbarItems.Add(new ToolbarItem()
            {
                Command = new Command(() => Navigation.PushAsync(new CreateTaskPage())),
                Icon = "Plus48.png"
            });

            LoadTasks();
        }

        public async Task LoadTasks()
        {
            var tasks = await OrganizationServiceProxy.GetTasks();

            TasksView.ItemsSource = tasks.Select<CrmTask, string>(x => x.subject);
        }
    }
}
