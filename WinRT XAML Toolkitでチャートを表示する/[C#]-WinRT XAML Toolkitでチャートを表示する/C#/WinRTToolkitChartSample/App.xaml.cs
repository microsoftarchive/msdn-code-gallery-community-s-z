using Microsoft.Practices.Prism.StoreApps;
using WinRTToolkitChartSample.ViewModels;
using WinRTToolkitChartSample.Views;
using Windows.ApplicationModel.Activation;

namespace WinRTToolkitChartSample
{
    sealed partial class App : MvvmAppBase
    {
        public App()
        {
            this.InitializeComponent();
        }

        protected override void OnLaunchApplication(LaunchActivatedEventArgs args)
        {
            NavigationService.Navigate("Main", null);
        }
    }
}
