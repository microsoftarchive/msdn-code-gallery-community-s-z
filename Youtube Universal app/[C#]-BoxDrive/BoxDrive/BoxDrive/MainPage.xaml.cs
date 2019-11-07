using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using BoxDrive.ViewModel;
using BoxDrive.View;
using Windows.System.Profile;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BoxDrive
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Frame fr = Window.Current.Content as Frame;
        public MainPage()
        {
            this.InitializeComponent();
            
            lsvMain.DataContext = new MenuMainViewModel();
        }

        private void lsvMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lsvMain.SelectedIndex==0)
            {
               
                 fr.Navigate(typeof(Youtube));
            }
        }
    }
}
