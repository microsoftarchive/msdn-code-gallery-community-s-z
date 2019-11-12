using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using Tasks.Show.ViewModels;

namespace Tasks.Show
{
    /// <summary>
    /// Interaction logic for Welcome.xaml
    /// </summary>
    public partial class Welcome : UserControl
    {
		#region Fields 

        private int currentPage = -1;
        private const int pageCount = 5;
        private const int pageWidth = 760;

		#endregion Fields 

		#region Constructors 

        public Welcome()
        {
            // this value should be loaded from settings
            bool isSettingsEnabled = Tasks.Show.Properties.Settings.Default.ShowWelcome;
            this.Visibility = Visibility.Collapsed;

            InitializeComponent();

            if (isSettingsEnabled)
            {
                this.Loaded += new RoutedEventHandler(Welcome_Loaded);
            }
        }

		#endregion Constructors 

		#region Event Handlers 

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            GotoPage(currentPage - 1);
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            GotoPage(currentPage + 1);
        }

        private void NoThanksButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        void Welcome_Loaded(object sender, RoutedEventArgs e)
        {
            Show();
        }

		#endregion Event Handlers 

		#region Public Methods 

        public void Show()
        {
            GotoPage(0);
            this.Visibility = Visibility.Visible;
        }

		#endregion Public Methods 

		#region Private Methods 

        private void Close()
        {
            Tasks.Show.Properties.Settings.Default.ShowWelcome = (bool) ShowWelcomeCheckBox.IsChecked;
            Tasks.Show.Properties.Settings.Default.Save();

            this.Visibility = Visibility.Collapsed;
        }

        private void GotoPage(int index)
        {
            index = Math.Min(index, pageCount);
            index = Math.Max(index, 0);

            if (index == pageCount)
            {
                Close();
                return;
            }

            if (currentPage == 0 && index != 0)
            {
                // hide the first page controls
                Storyboard hideFirst = this.Resources["HideFirstPageControls"] as Storyboard;
                hideFirst.Begin();
            }

            if (index == 0 && currentPage != 0)
            {
                // show the first page controls
                Storyboard showFirst = this.Resources["ShowFirstPageControls"] as Storyboard;
                showFirst.Begin();
            }

            if (index == pageCount - 1)
            {
                NextArrow.Visibility = Visibility.Collapsed;
                NextTextBlock.Text = "Done";
            }
            else
            {
                NextArrow.Visibility = Visibility.Visible;
                NextTextBlock.Text = "Next";
            }

            currentPage = index;
            double calculatedOffset = pageWidth * index * -1;

            Storyboard sb = this.Resources["GotoPageStoryboard"] as Storyboard;
            (sb.Children[0] as DoubleAnimationUsingKeyFrames).KeyFrames[0].Value = calculatedOffset;

            EventHandler handler = null;
            handler = delegate(object s, EventArgs e)
            {
                // remove the handler 
                sb.Completed -= handler;
                Canvas.SetLeft(ImageHost, calculatedOffset);
            };

            sb.Completed += handler;
            this.BeginStoryboard(sb);
        }

		#endregion Private Methods 
    }
}
