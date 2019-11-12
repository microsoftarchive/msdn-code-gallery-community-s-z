
using Xamarin.Forms;

namespace Calculator
{
    public partial class App : Application
    {
        private OperationViewModel operationViewModel;

        public App()
        {
            //InitializeComponent();

            operationViewModel = new OperationViewModel();
            operationViewModel.RestoreState(Current.Properties);

            MainPage = new Calculator(operationViewModel);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            operationViewModel.SaveState(Current.Properties);
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
