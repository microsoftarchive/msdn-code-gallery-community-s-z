using SQLiteSample.Helpers;
using SQLiteSample.Servcies;
using SQLiteSample.Views;
using Xamarin.Forms;

namespace SQLiteSample
{
    public partial class App : Application
    {
        IContactRepository _contactRepository;
        public App()
        {
            InitializeComponent();
            _contactRepository = new ContactRepository();
            OnAppStart();
        }

        public void OnAppStart()
        {
            var getLocalDB = _contactRepository.GetAllContactsData();

            if (getLocalDB.Count > 0)
            {
                MainPage = new NavigationPage(new ContactList());
            }
            else
            {
                MainPage = new NavigationPage(new AddContact());
            }

        }

        protected override void OnStart()
        {
            // Handle when your app launch
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
