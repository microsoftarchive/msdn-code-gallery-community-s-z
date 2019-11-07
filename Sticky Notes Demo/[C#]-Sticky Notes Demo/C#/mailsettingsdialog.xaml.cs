using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;


namespace StickyNotes
{
    /// <summary>
    /// Interaction logic for MailSettingsDialog.xaml
    /// </summary>

    public partial class MailSettingsDialog : Window
    {
        public MailSettingsDialog()
        {
            this.WindowStyle = WindowStyle.None;
            this.Height = 250;
            this.Width = 600;
            this.Title = "SetUp Email Server";
            this.BorderBrush = Brushes.Transparent;
            this.BorderThickness = new Thickness(0);
            this.Background = Brushes.Transparent;


            StackPanel sp = new StackPanel();
            sp.Background = Brushes.Transparent;

            Button b = new Button();
            b.Background = Window2.ChangeBackgroundColor(Colors.SkyBlue);
            b.Height = 245;

            TextBlock tb = new TextBlock();
            tb.Background = Brushes.Transparent;
            tb.TextWrapping = TextWrapping.Wrap;
            tb.FontFamily = new FontFamily("Bickham Script Pro");
            tb.Typography.StylisticSet1= true;
            tb.FontSize = 50;
            tb.HorizontalAlignment = HorizontalAlignment.Center;
            tb.TextAlignment = TextAlignment.Center;
            tb.Text = "Enter Mail Server Info In \r\nPreferences Window";

            b.Content = tb;
            b.Click += new RoutedEventHandler(b_Click);

            sp.Children.Add(b);

            TimerClock = TimerClock = new System.Windows.Threading.DispatcherTimer();
            TimerClock.Interval = new TimeSpan(0, 0, 5);
            TimerClock.IsEnabled = true;
            TimerClock.Tick += new EventHandler(TimerClock_Tick);

            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Content = sp;
            this.Closing += new System.ComponentModel.CancelEventHandler(MailSettingsDialog_Closing);
            this.ShowDialog();
        }

        void MailSettingsDialog_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }

        void b_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        void TimerClock_Tick(object sender, EventArgs e)
        {
            TimerClock.IsEnabled = false;
            this.Close();
        }

        private System.Windows.Threading.DispatcherTimer TimerClock;
        // To use Loaded event put Loaded="WindowLoaded" attribute in root element of .xaml file.
        // private void WindowLoaded(object sender, RoutedEventArgs e) {}

        // Sample event handler:  
        // private void ButtonClick(object sender, RoutedEventArgs e) {}

    }
}