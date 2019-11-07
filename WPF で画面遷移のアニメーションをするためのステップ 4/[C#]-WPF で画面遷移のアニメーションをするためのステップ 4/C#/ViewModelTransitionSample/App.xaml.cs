namespace ViewModelTransitionSample
{
    using ViewModelTransitionSample.View;
    using ViewModelTransitionSample.ViewModel;
    using System.Windows;

    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var window = new MainFrameView();
            var viewModel = new MainFrameViewModel();

            window.DataContext = viewModel;
            window.Show();
        }
    }
}
