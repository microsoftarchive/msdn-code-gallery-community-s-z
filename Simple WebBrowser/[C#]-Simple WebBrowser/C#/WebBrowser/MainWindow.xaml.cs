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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WebBrowser
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

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {         
            if (string.IsNullOrEmpty(urlTxtBox.Text) || urlTxtBox.Text.Equals("about:blank"))
            {
                MessageBox.Show("enter a valid url");
                urlTxtBox.Focus();
                return;
            }

            openLink(urlTxtBox.Text);

        }

       private void openLink(string url)
        {  

            if(!url.StartsWith("http://") && !url.StartsWith("https://"))
            {
                url = "http:\\" + url;
            }
            try
            {
                webBrowser1.Navigate(new Uri(url));
            }
            catch(System.UriFormatException)
            {
                return;
            }
            
        }

        private void btnBackward_Click(object sender, RoutedEventArgs e)
        {
            if (webBrowser1.CanGoBack)
            {
                webBrowser1.GoBack();
            }
        }

        private void btnForward_Click(object sender, RoutedEventArgs e)
        {
            if (webBrowser1.CanGoForward)
            {
                webBrowser1.GoForward();
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            webBrowser1.Refresh();
        }
    }
}
