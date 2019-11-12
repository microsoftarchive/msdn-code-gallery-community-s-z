using SQLiteDemo.ViewModels;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace SQLiteDemo.Views
{
    public sealed partial class MainPage : SQLiteDemo.Common.LayoutAwarePage
    {
        CustomersViewModel customersViewModel = null;
        ObservableCollection<CustomerViewModel> customers = null;

        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            customersViewModel = new CustomersViewModel();
            customers = customersViewModel.GetCustomers();
            CustomersViewSource.Source = customers;
            CustomersGridView.SelectedItem = null;

            base.OnNavigatedTo(e);
        }

        private void CustomersGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(ProjectsPage), e.ClickedItem);
        }

        private void CustomersGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CustomersGridView.SelectedItems.Count() > 0)
            {
                MainPageAppBar.IsOpen = true;
                MainPageAppBar.IsSticky = true;
                AddButton.Visibility = Visibility.Collapsed;
                EditButton.Visibility = Visibility.Visible;
            }
            else
            {
                MainPageAppBar.IsOpen = false;
                MainPageAppBar.IsSticky = false;
                AddButton.Visibility = Visibility.Visible;
                EditButton.Visibility = Visibility.Collapsed;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CustomerPage));
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CustomerPage), CustomersGridView.SelectedItem);
        }

    }
}
