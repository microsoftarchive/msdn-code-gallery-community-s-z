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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPCalenderControl
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            SetMinMaxDate();
            setSelectedDate();
        }
        private void setSelectedDate()
        {
           // MyCalendarView.SelectedDates.Add(new DateTime(2016, 3, 11));// Set selected date is March 3rd 2016);
            MyCalendarDatePicker.Date = new DateTime(2016, 3, 11);//March 3rd 2016
        }
        private void SetMinMaxDate()
        {

            //MyCalendarView.MinDate = new DateTime(2016, 2, 28);//Min date is FEB 28th 2016
            //MyCalendarView.MaxDate = DateTime.Now.AddMonths(3);
            MyCalendarView.NumberOfWeeksInView = 8;//Month view show 8 weeks at a time

            MyCalendarDatePicker.Date = new DateTime(2016, 3, 11);//Selected date is March 3rd 2016
            MyCalendarDatePicker.MinDate = new DateTime(2016, 2, 28);//FEB 28th 2016
            MyCalendarDatePicker.MaxDate = DateTime.Now.AddMonths(3);//Max date is 3 months from current date
        }
        private void MyCalendarDatePicker_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            //Checking selected date is null
            if (args.NewDate != null)
            {
                /* Getting selected new date value*/
                DisplayDate(args.NewDate.Value.ToString());
            }
        }
        private async void DisplayDate(string SelectedDate)
        {
            ContentDialog noWifiDialog = new ContentDialog()
            {
                Title = "Windows 10 Calendar Control",
                Content = "Selected date is: " + SelectedDate,
                PrimaryButtonText = "Ok"
            };
            noWifiDialog.Margin = new Thickness(0, 100, 0, 0);
            await noWifiDialog.ShowAsync();
        }
    }
}

