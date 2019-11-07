using SQLiteDemo.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;

namespace SQLiteDemo.Views
{
    public sealed partial class ProjectPage : SQLiteDemo.Common.LayoutAwarePage
    {
        ProjectViewModel project = null;
        CustomerViewModel customer = null;

        public ProjectPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            customer = new CustomerViewModel();
            if (e.Parameter == null)
            {
                project = new ProjectViewModel();
                project.CustomerId = App.CurrentCustomerId;
                PageTitle.Text = string.Format("{0} new project",
                    customer.GetCustomerName(project.CustomerId));
            }
            else
            {
                project = (ProjectViewModel)e.Parameter;
                PageTitle.Text = string.Format("{0} project",
                    customer.GetCustomerName(project.CustomerId));
            }
            this.DataContext = project;

            base.OnNavigatedTo(e);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string result = project.SaveProject(project);
            if (result.Contains("Success"))
            {
                this.Frame.Navigate(typeof(ProjectsPage),
                    customer.GetCustomer(project.CustomerId));
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            string result = project.DeleteProject(project.Id);
            if (result.Contains("Success"))
            {
                this.Frame.Navigate(typeof(ProjectsPage),
                    customer.GetCustomer(project.CustomerId));
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ProjectsPage),
                customer.GetCustomer(project.CustomerId));
        }

    }
}
