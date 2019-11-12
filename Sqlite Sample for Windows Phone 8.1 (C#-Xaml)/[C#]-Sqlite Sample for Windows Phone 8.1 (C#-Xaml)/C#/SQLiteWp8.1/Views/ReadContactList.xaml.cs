using SQLiteWp8._1.Helpers;
using SQLiteWp8._1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    public sealed partial class ReadContactList : Page
    {
        ObservableCollection<Contacts> DB_ContactList = new ObservableCollection<Contacts>();
        public ReadContactList()
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
                Btn_Delete.IsEnabled = true;
            }
            listBoxobj.ItemsSource = DB_ContactList.OrderByDescending(i => i.Id).ToList();//Binding DB data to LISTBOX and Latest contact ID can Display first. 
        }
        private void AddContact_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddConatct));
        }
        private async void DeleteAll_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("Are you sure you want to remove all your data ?");
            dialog.Commands.Add(new UICommand("No", new UICommandInvokedHandler(Command)));
            dialog.Commands.Add(new UICommand("Yes", new UICommandInvokedHandler(Command)));
            await dialog.ShowAsync();
        }
        private void Command(IUICommand command)
        {
            if (command.Label.Equals("Yes"))
            {
                DatabaseHelperClass Db_Helper = new DatabaseHelperClass();
                Db_Helper.DeleteAllContact();//delete all DB contacts 
                DB_ContactList.Clear();//Clear collections 
                Btn_Delete.IsEnabled = false;
                listBoxobj.ItemsSource = DB_ContactList;
            }
        }
        private void listBoxobj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int SelectedContactID = 0;
            if (listBoxobj.SelectedIndex != -1)
            {
                Contacts listitem = listBoxobj.SelectedItem as Contacts;//Get slected listbox item contact ID 
                Frame.Navigate(typeof(Delete_UpdateContacts),SelectedContactID=listitem.Id);        

            }
        }
    }
}
