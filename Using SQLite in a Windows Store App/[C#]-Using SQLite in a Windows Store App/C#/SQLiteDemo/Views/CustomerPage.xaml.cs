using SQLiteDemo.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;

namespace SQLiteDemo.Views
{
    public sealed partial class CustomerPage : SQLiteDemo.Common.LayoutAwarePage
    {
        CustomerViewModel customer = null;

        public CustomerPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter == null)
            {
                customer = new CustomerViewModel();
                PageTitle.Text = "New customer";
            }
            else
            {
                customer = (CustomerViewModel)e.Parameter;
                PageTitle.Text = customer.Name;
                App.CurrentCustomerId = customer.Id;
           }
            this.DataContext = customer;

            base.OnNavigatedTo(e);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string result = customer.SaveCustomer(customer);
            App.CurrentCustomerId = customer.Id;
            if (result.Contains("Success"))
            {
                this.Frame.Navigate(typeof(MainPage));
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            string result = customer.DeleteCustomer(customer.Id);
            if (result.Contains("Success"))
            {
                this.Frame.Navigate(typeof(MainPage));
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

    }
}
