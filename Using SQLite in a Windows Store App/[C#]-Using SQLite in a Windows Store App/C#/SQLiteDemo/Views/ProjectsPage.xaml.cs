using SQLiteDemo.ViewModels;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace SQLiteDemo.Views
{
    public sealed partial class ProjectsPage : SQLiteDemo.Common.LayoutAwarePage
    {
        ProjectsViewModel projectsViewModel = null;
        ObservableCollection<ProjectViewModel> projects = null;

        public ProjectsPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var customer = (CustomerViewModel)e.Parameter;
            App.CurrentCustomerId = customer.Id;
            projectsViewModel = new ProjectsViewModel();
            projects = projectsViewModel.GetProjects(customer.Id);
            ProjectsViewSource.Source = projects;
            ProjectsGridView.SelectedItem = null;
            PageTitle.Text = string.Format("{0} projects", customer.Name);

            base.OnNavigatedTo(e);
        }

        private void ProjectsGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(ProjectPage), e.ClickedItem);
        }

        private void ProjectsGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProjectsGridView.SelectedItems.Count() > 0)
            {
                ProjectsPageAppBar.IsOpen = true;
                ProjectsPageAppBar.IsSticky = true;
                AddButton.Visibility = Visibility.Collapsed;
                EditButton.Visibility = Visibility.Visible;
            }
            else
            {
                ProjectsPageAppBar.IsOpen = false;
                ProjectsPageAppBar.IsSticky = false;
                AddButton.Visibility = Visibility.Visible;
                EditButton.Visibility = Visibility.Collapsed;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ProjectPage));
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ProjectPage), ProjectsGridView.SelectedItem);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

    }
}
