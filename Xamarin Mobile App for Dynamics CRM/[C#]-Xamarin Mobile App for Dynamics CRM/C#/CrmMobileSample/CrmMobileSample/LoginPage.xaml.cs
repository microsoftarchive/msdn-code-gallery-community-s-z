using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace CrmMobileSample
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        public async void btnSignIn_Click(object sender, EventArgs e)
        {
            await OrganizationServiceProxy.Authenticate();
            await Navigation.PushModalAsync(new MainPage());
        }
    }
}
