using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestfulApplication.Clients.Core.ViewModels;
using Xamarin.Forms;

namespace RestfulApplication.XamarinForms.Views
{
    public partial class DetailsPageView : ContentPage
    {
        public DetailsPageView()
        {
            InitializeComponent();

            BindingContext = new DetailsViewModel();
        }
    }
}
