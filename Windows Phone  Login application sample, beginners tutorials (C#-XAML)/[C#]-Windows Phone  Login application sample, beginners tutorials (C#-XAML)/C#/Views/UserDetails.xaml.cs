using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;
using System.Runtime.Serialization;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using LoginApp.Model;

namespace LoginApp.Views
{
    public partial class UserDetails : PhoneApplicationPage
    {
        IsolatedStorageFile ISOFile = IsolatedStorageFile.GetUserStoreForApplication();
        UserData ObjUserData = new UserData();
        public UserDetails()
        {
            InitializeComponent();
            List<ListData> ObjListDataList = new List<ListData>();
            ObjListDataList.Add(new ListData { Name = "Windows and WindowsPhone Store", Desc = "This blog is the latest in a recurring series that provides details about recent Store trends across categories, markets, and more. Understanding these trends can help you determine what types of apps to build or where to focus your development efforts. Data from the Windows Store is presented alongside the Windows Phone Store, allowing you…" });
            ObjListDataList.Add(new ListData { Name = "Windows Store is first to bring carrier billing to China, India and Brazil", Desc = "It is estimated that 93% of people who live in fast-growth emerging markets around the world do not have a credit card (Source: Measuring Financial Inclusion, The Global Findex Database), making it difficult or impossible to purchase apps from most global app stores. Today we announced that Windows Store has become the first global smartphone…" });
            ObjListDataList.Add(new ListData { Name = "Enhanced Windows Dev Center reporting", Desc = "This week, Windows Dev Center is releasing enhancements to two reports for Windows Store: Downloads and In-app purchase. We know having data as soon as possible is important to make decisions about your apps, so in this release, the Dev Center Download and In-app purchase reports have been optimized to deliver information faster: the goal…" });
            ObjListDataList.Add(new ListData { Name = "Use free “house ads” to promote your Windows apps", Desc = "Today Microsoft Advertising released ‘house ads,’ a new capability that enables developers that have two or more Windows or Windows Phone apps in the Store, to promote one of the apps in the other apps, using the Microsoft Ad SDK. For example, let’s say you have a car game, and an airplane game. Both apps…" });
            ObjListDataList.Add(new ListData { Name = "Jethro Tull superfan builds app with Windows App Studio", Desc = "More than 50,000 apps have been published using Windows App Studio Beta. We’ve seen a number of musicians, artists, and bands who build apps to connect with their fans and share their craft with a larger audience. We’ve also seen fans create apps that help spread the word about their favorite artists. Here, we showcase" });
            ObjListDataList.Add(new ListData { Name = "Inside Windows Platform – Inside Microsoft OCR Libraries", Desc = "In this episode of Inside Windows Platform, we talked with Ivan Stojiljkovic, the Dev Lead of the OCR team at Microsoft. OCR is acompelling developer scenario which can empower all sorts of useful mobile apps. Microsoft has been developing OCR functionality for its apps for some time now. In order to get real world data, the OCR team first published" });
            ObjListDataList.Add(new ListData { Name = "AllJoyn in Windows 10", Desc = "Starting today, makers and software developers who have engaged in our Windows Insider program will get their first chance to develop applications that use AllJoyn capability in Windows 10 by downloading the SDK for Windows from the AllSeen Alliance.  You can learn more at the MS Open Tech blog" });
            ListBoxDetails.ItemsSource = ObjListDataList;
            this.Loaded += UserDetailsPage_Loaded;
        }

        private void UserDetailsPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (ISOFile.FileExists("CurrentLoginUserDetails"))//read current user login details  
            {
                using (IsolatedStorageFileStream fileStream = ISOFile.OpenFile("CurrentLoginUserDetails", FileMode.Open))
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(UserData));
                    ObjUserData = (UserData)serializer.ReadObject(fileStream);

                }
                StckUserDetailsUI.DataContext = ObjUserData;//Bind current login details to UI
            }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
          
            //ObjUserData.UserName = NavigationContext.QueryString["UserName"].ToString();
            //ObjUserData.Address = NavigationContext.QueryString["Address"].ToString();
            //ObjUserData.Gender = NavigationContext.QueryString["Gender"].ToString();
            //ObjUserData.PhoneNo = NavigationContext.QueryString["PhoneNo"].ToString();
            //ObjUserData.Email = NavigationContext.QueryString["Email"].ToString();
          
            //TxtUserName.Text = username;
        }
        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            var Result = MessageBox.Show("Are you sure you want to exit?", "", MessageBoxButton.OKCancel);
            if (Result == MessageBoxResult.OK)
            {
                if (NavigationService.CanGoBack)
                {
                    while (NavigationService.RemoveBackEntry() != null)
                    {
                        NavigationService.RemoveBackEntry();
                    }
                }
            }
            else
            {
                e.Cancel = true;
            }
        }
        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            SignOut();
        }

        private void ImgSignOut_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            SignOut();
        }
        public void SignOut()
        {
            var Result = MessageBox.Show("Are you sure you want to signout from this page?", "", MessageBoxButton.OKCancel);
            if (Result == MessageBoxResult.OK)
            {
                var Settings = IsolatedStorageSettings.ApplicationSettings;
                Settings.Remove("CheckLogin");
                NavigationService.Navigate(new Uri("/Views/LoginPage.xaml", UriKind.Relative));
            }
        }
        private void ImgUserProfile_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            StckUserDetailsUI.Visibility = Visibility.Visible;
            ListBoxDetails.Visibility = Visibility.Collapsed;
        }

        private void Links_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            StckUserDetailsUI.Visibility = Visibility.Collapsed;
            ListBoxDetails.Visibility = Visibility.Visible;
        }

        private void ListBoxDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var SelectedItem = ListBoxDetails.SelectedItem as ListData;
            if (SelectedItem != null)
            {
                if (ISOFile.FileExists("CurrentPageInfo"))
                {
                    ISOFile.DeleteFile("CurrentPageInfo");
                }
                using (IsolatedStorageFileStream fileStream = ISOFile.OpenFile("CurrentPageInfo", FileMode.Create))
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(ListData));

                    serializer.WriteObject(fileStream, SelectedItem);
                }
                NavigationService.Navigate(new Uri("/Views/LinkInfo.xaml", UriKind.Relative));
                ListBoxDetails.SelectedItem = null;
            }
        }
    }
}