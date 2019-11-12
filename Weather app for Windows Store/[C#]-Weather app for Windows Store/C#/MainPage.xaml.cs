using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace WindowsVersion
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class MainPage : WindowsVersion.Common.LayoutAwarePage
    {
        public MainPage()
        {
            this.InitializeComponent();
            CityList.ItemsSource = App.cityList;
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
        }


        private void CityList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // if an item is selected
            if (CityList.SelectedIndex != -1)
            {
                // get the currently selected city and pass the information to the 
                // forecast details page
                City curCity = (City)CityList.SelectedItem;
                if (this.Frame != null)
                {
                    string[] parameter = {curCity.CityName, curCity.Latitude, curCity.Longitude};
                    this.Frame.Navigate(typeof(ForecastPage), parameter);
                }
            }
        }

        /// <summary>
        /// Event handler called when user navigates away from this page
        /// </summary>
        protected override void OnNavigatedFrom(NavigationEventArgs args)
        {
            base.OnNavigatedFrom(args);
            // make sure no item is highlighted in the list of cities
            CityList.SelectedIndex = -1;
            CityList.SelectedItem = null;
        }


    }
}
