using System.Windows;
using System.Windows.Media;

namespace WpfSample
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += (o, sender) => ((App)Application.Current).CreateJumpList();
        }

        internal void SetColor(Color color)
        {
            mainText.Background = new SolidColorBrush(color);
        }
    }
}
