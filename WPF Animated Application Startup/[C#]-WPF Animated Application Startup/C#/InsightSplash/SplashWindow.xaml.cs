using System;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Media.Animation;

namespace InsightSplash
{
    /// <summary>
    /// Interaction logic for SplashWindow.xaml
    /// </summary>
    public partial class SplashWindow : Window
    {
        private MainWindow m_mainWindow;

        private DispatcherTimer splashAnimationTimer;

        private const string Loading = "Loading";

        public SplashWindow()
        {
            InitializeComponent();

            splashAnimationTimer = new DispatcherTimer();
            splashAnimationTimer.Interval = TimeSpan.FromMilliseconds(500);
            splashAnimationTimer.Tick += new EventHandler(splashAnimationTimer_Tick);
            splashAnimationTimer.Start();

            m_mainWindow = new MainWindow();

            m_mainWindow.ReadyToShow += new MainWindow.ReadyToShowDelegate(m_mainWindow_ReadyToShow);

            m_mainWindow.Closed += new EventHandler(m_mainWindow_Closed);
        }

        void splashAnimationTimer_Tick(object sender, EventArgs e)
        {
            // Show the increasing amount of dots in "Loading...".

            int dotsCount = lblProgress.Content.ToString().Replace(Loading, string.Empty).Length;

            if (dotsCount < 6)
            {
                dotsCount++;
            }
            else
            {
                dotsCount = 0;
            }

            lblProgress.Content = Loading.PadRight(Loading.Length + dotsCount, '.');
        }

        void m_mainWindow_ReadyToShow(object sender, EventArgs args)
        {
            // When the main window is done with its time-consuming tasks, 
            // hide the splash screen and show the main window.

            #region Animate the splash screen fading

            Storyboard sb = new Storyboard();
            //
            DoubleAnimation da = new DoubleAnimation
            {
                From = 1,
                To = 0,
                Duration = new Duration(TimeSpan.FromSeconds(1))
            };
            //
            Storyboard.SetTarget(da, this);
            Storyboard.SetTargetProperty(da, new PropertyPath(OpacityProperty));
            sb.Children.Add(da);
            //
            sb.Completed += new EventHandler(sb_Completed);
            //
            sb.Begin();

            #endregion // Animate the splash screen fading
        }

        void sb_Completed(object sender, EventArgs e)
        {
            // When the splash screen fades out, we can show the main window:
            m_mainWindow.Visibility = System.Windows.Visibility.Visible;
        }

        void m_mainWindow_Closed(object sender, EventArgs e)
        {
            // When the MainWindow is closed, the app does not exit: SplashScreen is its real "main" window.
            // This handler ensures that the MainWindow closing works as expected: exit from teh app.

            this.Close();
        }
    }
}
