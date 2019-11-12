using SqliteUWP.Model;
using SqliteUWP.ViewModel;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SqliteUWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DetailsPage : Page
    {
        DatabaseHelperClass Db_Helper = new DatabaseHelperClass();
        Contacts currentStudent = new Contacts();
        public DetailsPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            currentStudent = e.Parameter as Contacts;
            //currentcontact = Db_Helper.ReadContact(Selected_ContactId);//Read selected DB contact
            NametxtBx.Text = currentStudent.Name;//get contact Name
            PhonetxtBx.Text = currentStudent.PhoneNumber;//get contact PhoneNumber
        }

        private void UpdateContact_Click(object sender, RoutedEventArgs e)
        {
            currentStudent.Name = NametxtBx.Text;
            currentStudent.PhoneNumber = PhonetxtBx.Text;
            Db_Helper.UpdateDetails(currentStudent);//Update selected DB contact Id
            Frame.Navigate(typeof(HomePage));
        }
        private void DeleteContact_Click(object sender, RoutedEventArgs e)
        {
            Db_Helper.DeleteContact(currentStudent.Id);//Delete selected DB contact Id.
            Frame.Navigate(typeof(HomePage));
        }
    }
}

