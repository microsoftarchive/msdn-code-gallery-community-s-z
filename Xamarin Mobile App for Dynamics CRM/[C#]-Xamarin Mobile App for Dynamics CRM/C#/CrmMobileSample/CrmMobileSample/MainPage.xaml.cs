using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CrmMobileSample
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();

            masterPage = new MasterPage();
            Master = masterPage;
            Detail = new NavigationPage(new TasksPage());
        }
    }
}
