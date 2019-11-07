using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace CrmMobileSample
{
    public partial class CreateTaskPage : ContentPage
    {
        public CreateTaskPage()
        {
            InitializeComponent();
        }

        public async void btnCreate_Click(object sender, EventArgs e)
        {
            await OrganizationServiceProxy.CreateTask(new CrmTask()
            {
                activityid = Guid.NewGuid(),
                subject = subject.Text,
                description = description.Text
            });

            await DisplayAlert("Success", "Task successfully created!", "OK");
            await Navigation.PopAsync();
        }
    }
}
