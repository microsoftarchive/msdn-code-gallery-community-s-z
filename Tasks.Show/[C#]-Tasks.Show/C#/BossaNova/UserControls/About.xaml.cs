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
using System.Diagnostics;

namespace Tasks.Show.UserControls
{
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : UserControl
    {
        public About()
        {
            InitializeComponent();
        }



        #region CloseRequested

        public event RoutedEventHandler CloseRequested;

        private void RaiseCloseRequested()
        {
            if (CloseRequested != null)
            {
                CloseRequested(this, new RoutedEventArgs());
            }
        }

        #endregion
        


        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            RaiseCloseRequested();
        }

        private void SelaButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("http://www.selagroup.com/"));
            RaiseCloseRequested();
        }

        private void PixelLabButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("http://www.thinkpixellab.com/"));
            RaiseCloseRequested();
        }
    }
}
