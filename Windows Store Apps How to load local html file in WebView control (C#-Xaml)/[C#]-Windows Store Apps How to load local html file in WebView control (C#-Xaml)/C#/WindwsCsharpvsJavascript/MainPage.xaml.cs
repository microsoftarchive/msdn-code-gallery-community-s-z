using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace WindwsCsharpvsJavascript
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }
        private void BtnLoadHtml_Click(object sender, RoutedEventArgs e)
        {
            //Load local file using 'NavigateToLocalStreamUri' method
            Uri url = WebBrowserName.BuildLocalStreamUri("MyTag", "HTMLPage.html");
            StreamUriWinRTResolver myResolver = new StreamUriWinRTResolver();

            // Pass the resolver object to the navigate call.
            WebBrowserName.NavigateToLocalStreamUri(url, myResolver);
        }
    }
    
}
