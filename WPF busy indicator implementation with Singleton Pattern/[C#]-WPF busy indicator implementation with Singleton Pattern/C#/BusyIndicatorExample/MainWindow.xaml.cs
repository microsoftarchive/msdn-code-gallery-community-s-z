using System.Windows;

namespace BusyIndicatorExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            busyIndicator.DataContext = BusyIndicatorManager.Instance;
        }

        private void btnRunBusy_Click(object sender, RoutedEventArgs e)
        {
            BusyIndicatorManager.Instance.ShowBusy(1, "Please wait...");            
        }

        private void btnCloseBusy_Click(object sender, RoutedEventArgs e)
        {
            BusyIndicatorManager.Instance.CloseBusy(1);
        }
    }
}
