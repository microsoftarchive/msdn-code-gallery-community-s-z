using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace PrintingStuff
{
    public partial class Window1 : Window
    {
        Storyboard sb;
        bool? isRunning;

        public string ButtonContent
        {
            get { return (string)GetValue(ButtonContentProperty); }
            set { SetValue(ButtonContentProperty, value); }
        }

        public static readonly DependencyProperty ButtonContentProperty =
            DependencyProperty.Register("ButtonContent", typeof(string), typeof(Window1), new UIPropertyMetadata(null));


        public Window1()
        {
            InitializeComponent();
            sb = (Storyboard)FindResource("Storyboard1");
            StartAnimation();
            DataContext = this;
        }

        private void StartAnimation()
        {
            if (isRunning == null)
                sb.Begin();
            else
                sb.Resume();
            ButtonContent = "||";
            isRunning = true;
        }

        private void StopAnimation()
        {
            sb.Pause();
            ButtonContent = ">";
            isRunning = false;
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog dialog = new PrintDialog();

            if (dialog.ShowDialog() != true) return;

            printGrid.Measure(new Size(dialog.PrintableAreaWidth, dialog.PrintableAreaHeight));
            printGrid.Arrange(new Rect(new Point(50, 50), printGrid.DesiredSize));

            dialog.PrintVisual(printGrid, "A WPF printing");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var win = new Window2();
            win.Show();
            this.Close();
        }

        private void btnAction_Click(object sender, RoutedEventArgs e)
        {
            if (isRunning.Value)
                StopAnimation();
            else
                StartAnimation();
        }
    }
}
