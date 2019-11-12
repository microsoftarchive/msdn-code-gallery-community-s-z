using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpf_Notify_User
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private Storyboard SBMarquee;
        private DoubleAnimation XAnimation;
        private void Window_ContentRendered(object sender, EventArgs e)
        {
            SBMarquee = this.Resources["SBmarquee"] as Storyboard;
            XAnimation = SBMarquee.Children[0] as DoubleAnimation;
            XAnimation.To = MarqueeContainer.ActualWidth * -1;
            this.SizeChanged += Window_SizeChanged;
        }
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            XAnimation.To = MarqueeContainer.ActualWidth * -1;
            MarqueeContainer.Visibility = Visibility.Hidden;
            SBMarquee.Begin();
            MarqueeContainer.Visibility = Visibility.Visible;
        }
    }
}
