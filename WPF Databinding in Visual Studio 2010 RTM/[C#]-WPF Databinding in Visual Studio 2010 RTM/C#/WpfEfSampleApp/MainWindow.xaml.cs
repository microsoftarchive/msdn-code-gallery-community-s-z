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
using System.Windows.Shapes;

namespace WpfEfSampleApp
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ListBoxBinding frm = new ListBoxBinding();
            frm.Show();
        }

        private void Button2_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SimpleDataEntry frm = new SimpleDataEntry();
            frm.Show();
        }

        private void Button3_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SimpleDataGrid frm = new SimpleDataGrid();
            frm.Show();
        }

        private void Button4_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SimpleValidation frm = new SimpleValidation();
            frm.Show();
        }

        private void Button5_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            LookupComboboxBinding frm = new LookupComboboxBinding();
            frm.Show();
        }

        private void Button6_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MasterDetailBinding frm = new MasterDetailBinding();
            frm.Show();
        }

        private void Button7_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            FormattingAndValidation frm = new FormattingAndValidation();
            frm.Show();
        }
    }
}
