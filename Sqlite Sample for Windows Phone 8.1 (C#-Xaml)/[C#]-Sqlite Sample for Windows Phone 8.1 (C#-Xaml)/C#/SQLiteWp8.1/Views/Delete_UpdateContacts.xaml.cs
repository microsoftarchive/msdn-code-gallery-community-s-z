using SQLiteWp8._1.Helpers;
using SQLiteWp8._1.Model;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace SQLiteWp8._1.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Delete_UpdateContacts : Page
    {
        int Selected_ContactId = 0;
        DatabaseHelperClass Db_Helper = new DatabaseHelperClass();
        Contacts currentcontact = new Contacts();
        public Delete_UpdateContacts()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Selected_ContactId = int.Parse(e.Parameter.ToString());
            currentcontact = Db_Helper.ReadContact(Selected_ContactId);//Read selected DB contact
            NametxtBx.Text = currentcontact.Name;//get contact Name
            PhonetxtBx.Text = currentcontact.PhoneNumber;//get contact PhoneNumber
        }

        private void UpdateContact_Click(object sender, RoutedEventArgs e)
        {
            currentcontact.Name = NametxtBx.Text;
            currentcontact.PhoneNumber = PhonetxtBx.Text;
            Db_Helper.UpdateContact(currentcontact);//Update selected DB contact Id
            Frame.Navigate(typeof(ReadContactList));
        }
        private void DeleteContact_Click(object sender, RoutedEventArgs e)
        {
            Db_Helper.DeleteContact(Selected_ContactId);//Delete selected DB contact Id.
            Frame.Navigate(typeof(ReadContactList));
        }
    }
}
