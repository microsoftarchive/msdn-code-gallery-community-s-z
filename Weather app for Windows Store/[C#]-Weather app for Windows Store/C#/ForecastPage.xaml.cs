/* 
    Copyright (c) 2011 Microsoft Corporation.  All rights reserved.
    Use of this sample source code is subject to the terms of the Microsoft license 
    agreement under which you licensed this sample source code and is provided AS-IS.
    If you did not accept the terms of the license agreement, you are not authorized 
    to use this sample source code.  For the terms of the license, please see the 
    license agreement between you and Microsoft.
  
    To see all Code Samples for Windows Phone, visit http://go.microsoft.com/fwlink/?LinkID=219604 
  
*/
//using System.Windows.Controls;
//using Microsoft.Phone.Controls;
//using System.Windows.Navigation;
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


namespace WindowsVersion
{
    public partial class ForecastPage : WindowsVersion.Common.LayoutAwarePage
    {
        Forecast forecast;

        public ForecastPage()
        {
            InitializeComponent();
        }

        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            if (navigationParameter != null)
            {
                // get the city, latitude, and longitude out of the query string 
                string[] parameters = (string[])navigationParameter;
                string cityName = parameters[0];
                string latitude = parameters[1];
                string longitude = parameters[2];

                forecast = new Forecast();

                // get the forecast for the given latitude and longitude
                forecast.GetForecast(latitude, longitude);

                // set data context for page to this forecast
                DataContext = forecast;

                // set source for ForecastList box in page to our list of forecast time periods
                ForecastList.ItemsSource = forecast.ForecastList;
            }
        }

        /// <summary>
        /// Make sure no item can be selected in the forecast list box
        /// </summary>
        private void ForecastList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ForecastList.SelectedIndex = -1;
            ForecastList.SelectedItem = null;
        }

    }
}
