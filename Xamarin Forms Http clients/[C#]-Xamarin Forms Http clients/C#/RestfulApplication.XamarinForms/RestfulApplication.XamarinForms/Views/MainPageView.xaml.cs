using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestfulApplication.Clients.Core.ViewModels;
using RestfulApplication.Models;
using Xamarin.Forms;

namespace RestfulApplication.XamarinForms.Views
{
    public partial class MainPageView : ContentPage
    {
        public MainPageView()
        {
            InitializeComponent();

            BindingContext = new MainViewModel();
        }

        private async void NavigateToDetailsPageView(object sender, EventArgs e)
        {
            try
            {
                var detailsPage = new DetailsPageView();

                var mainViewModel = BindingContext as MainViewModel;

                var selectedEmployee = ((ListView) sender).SelectedItem as Employee;

                mainViewModel.SendEmployeeMessageCommand.Execute(selectedEmployee);

                await Navigation.PushModalAsync(detailsPage);
            }
            catch(Exception exc)
            {
                throw;
            }
        }

        private async void NavigateToDetailsPage(object sender, EventArgs e)
        {
            try
            {
                var detailsPage = new DetailsPageView();
             
                await Navigation.PushModalAsync(detailsPage);
            }
            catch(Exception exc)
            {
                throw;
            }
        }
    }
}
