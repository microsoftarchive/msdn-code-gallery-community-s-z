using SqliteUWP.Model;
using SqliteUWP.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class HomePage : Page
    {
        ObservableCollection<Contacts> DB_ContactList = new ObservableCollection<Contacts>();
        public HomePage()
        {
            this.InitializeComponent();
            this.Loaded += ReadContactList_Loaded;
        }
        private void ReadContactList_Loaded(object sender, RoutedEventArgs e)
        {
            ReadAllContactsList dbcontacts = new ReadAllContactsList();
            DB_ContactList = dbcontacts.GetAllContacts();//Get all DB contacts  
            if (DB_ContactList.Count > 0)
            {
                btnDelete.IsEnabled = true;
            }
            listBoxobj.ItemsSource = DB_ContactList.OrderByDescending(i => i.Id).ToList();//Binding DB data to LISTBOX and Latest contact ID can Display first.  
        }

        private void listBoxobj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBoxobj.SelectedIndex != -1)
            {
                Contacts listitem = listBoxobj.SelectedItem as Contacts;//Get slected listbox item contact ID
                Frame.Navigate(typeof(DetailsPage), listitem);
            }
        }

        private void DeleteAll_Click(object sender, RoutedEventArgs e)
        {
            DatabaseHelperClass delete = new DatabaseHelperClass();
            delete.DeleteAllContact();//delete all DB contacts
            DB_ContactList.Clear();//Clear collections
            btnDelete.IsEnabled = false;
            listBoxobj.ItemsSource = DB_ContactList;
        }
        private void AddContact_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddPage));
        }
    }
}
