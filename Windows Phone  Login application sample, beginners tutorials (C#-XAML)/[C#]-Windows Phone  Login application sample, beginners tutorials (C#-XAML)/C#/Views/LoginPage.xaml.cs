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
    public partial class LoginPage : PhoneApplicationPage
    {
        IsolatedStorageFile ISOFile = IsolatedStorageFile.GetUserStoreForApplication();
        List<UserData> ObjUserDataList = new List<UserData>();
        public LoginPage()
        {
            InitializeComponent();
            this.Loaded += LoginPage_Loaded;
        }
        private void LoginPage_Loaded(object sender, RoutedEventArgs e)
        {
            var Settings = IsolatedStorageSettings.ApplicationSettings;
            //Check if user already login,so we need to direclty navigate to details page instead of showing login page when user launch the app.
            if (Settings.Contains("CheckLogin"))
            {
                NavigationService.Navigate(new Uri("/Views/UserDetails.xaml", UriKind.Relative));
            }
            else
            {
                if (ISOFile.FileExists("RegistrationDetails"))//loaded previous items into list
                {
                    using (IsolatedStorageFileStream fileStream = ISOFile.OpenFile("RegistrationDetails", FileMode.Open))
                    {
                        DataContractSerializer serializer = new DataContractSerializer(typeof(List<UserData>));
                        ObjUserDataList = (List<UserData>)serializer.ReadObject(fileStream);

                    }
                }
            }
           
        }
        public void Login_Click(object sender, RoutedEventArgs e)
        {
            if (UserName.Text != "" && PassWord.Password != "")
            {
                int Temp = 0;
                foreach (var UserLogin in ObjUserDataList)
                {
                    if (UserName.Text == UserLogin.UserName && PassWord.Password == UserLogin.Password)
                    {
                        Temp = 1;
                        var Settings = IsolatedStorageSettings.ApplicationSettings;
                        Settings["CheckLogin"] = "Login sucess";// store some temporery value when user successfully login with his details, so on next app launch we need to check 'CheckLogin' variable value. If it is having value means user already logined.

                        if (ISOFile.FileExists("CurrentLoginUserDetails"))
                        {
                            ISOFile.DeleteFile("CurrentLoginUserDetails");
                        }
                        using (IsolatedStorageFileStream fileStream = ISOFile.OpenFile("CurrentLoginUserDetails", FileMode.Create))
                        {
                            DataContractSerializer serializer = new DataContractSerializer(typeof(UserData));

                            serializer.WriteObject(fileStream, UserLogin);

                        }
                       // NavigationService.Navigate(new Uri("/UserDetails.xaml?UserName=" + UserLogin.UserName + "&Address=" + UserLogin.Address + "&Gender=" + UserLogin.Gender + "&PhoneNo=" + UserLogin.PhoneNo + "&Email=" + UserLogin.Email, UriKind.RelativeOrAbsolute));
                        NavigationService.Navigate(new Uri("/Views/UserDetails.xaml", UriKind.Relative));
                    }
                }
                if (Temp == 0)
                {
                    MessageBox.Show("Invalid UserID/Password");
                }
            }
            else
            {
                MessageBox.Show("Enter UserID/Password");
            }
        }
       
       
        public void SignUp_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/SignUpPage.xaml", UriKind.Relative));
        }
        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
           var Result=MessageBox.Show("Are you sure you want to exit?","",MessageBoxButton.OKCancel);
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
        private void UserName_GotFocus(object sender, RoutedEventArgs e)
        {
            UserName.BorderBrush = new SolidColorBrush(Colors.LightGray);
            PassWord.BorderBrush = new SolidColorBrush(Colors.LightGray);
        }
        
    }
}