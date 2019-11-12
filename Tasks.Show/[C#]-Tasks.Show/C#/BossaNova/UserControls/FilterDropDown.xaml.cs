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
using Tasks.Show.Models;
using Tasks.Show.ViewModels;

namespace Tasks.Show.UserControls
{
    /// <summary>
    /// Interaction logic for FilterDropDown.xaml
    /// </summary>
    public partial class FilterDropDown : UserControl
    {

        #region Constructors

        public FilterDropDown()
        {
            InitializeComponent();
            LayoutRoot.DataContext = this;
            this.PreviewKeyDown += UserControl_KeyDown;

            this.FilterDescription = App.Root.Filters.Current;
        }

        #endregion Constructors

        #region Event Handlers

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //FilterColor f = (sender as Button).DataContext as FilterColor;
            this.FilterDescription = (sender as FrameworkElement).DataContext.ToString();
            Close();
        }


        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.Popup.IsOpen)
            {
                if (e.Key == Key.Enter || e.Key == Key.Return || e.Key == Key.Escape)
                {
                    Close();
                }
            }
        }

        #endregion Event Handlers

        #region Private Methods

        private void Close()
        {
            this.Popup.IsOpen = false;
        }

        #endregion Private Methods

        #region FilterDescription

        public static readonly DependencyProperty FilterDescriptionProperty =
            DependencyProperty.Register("FilterDescription", typeof(string), typeof(FilterDropDown),
                new FrameworkPropertyMetadata((string)null));

        public string FilterDescription
        {
            get { return (string)GetValue(FilterDescriptionProperty); }
            set { SetValue(FilterDescriptionProperty, value); }
        }

        #endregion

    }
}
