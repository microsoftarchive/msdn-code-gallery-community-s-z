using System;
using System.Windows;
using System.Windows.Threading;
namespace InsightSplash
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public delegate void ReadyToShowDelegate(object sender, EventArgs args);

        public event ReadyToShowDelegate ReadyToShow;

        private DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(7);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            // This timer imitates a time-consuming operation (or a whole bunch of
            // such operations).
            // When done, it raises a custom event to let the splash screen know that its time is up.

            timer.Stop();

            if (ReadyToShow != null)
            {
                ReadyToShow(this, null);
            }
        }
    }
}
