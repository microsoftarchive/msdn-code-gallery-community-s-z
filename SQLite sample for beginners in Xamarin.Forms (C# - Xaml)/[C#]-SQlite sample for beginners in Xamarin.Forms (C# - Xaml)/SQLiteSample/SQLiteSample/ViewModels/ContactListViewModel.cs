using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using SQLiteSample.Helpers;
using SQLiteSample.Models;
using SQLiteSample.Servcies;
using SQLiteSample.Views;
using Xamarin.Forms;

namespace SQLiteSample.ViewModels {
    public class ContactListViewModel : BaseContactViewModel {

        public ICommand AddCommand { get; private set; }
        public ICommand DeleteAllContactsCommand { get; private set; }

        public ContactListViewModel(INavigation navigation) {
            _navigation = navigation;
            _contactRepository = new ContactRepository();

            AddCommand = new Command(async () => await ShowAddContact()); 
            DeleteAllContactsCommand = new Command(async () => await DeleteAllContacts());

            FetchContacts();
        }

        void FetchContacts(){
            ContactList = _contactRepository.GetAllContactsData();
        }

        async Task ShowAddContact() {
            await _navigation.PushAsync(new AddContact());
        }

        async Task DeleteAllContacts(){
            bool isUserAccept = await Application.Current.MainPage.DisplayAlert("Contact List", "Delete All Contacts Details ?", "OK", "Cancel");
            if (isUserAccept){
                _contactRepository.DeleteAllContacts();
                await _navigation.PushAsync(new AddContact());
            }
        }

        async void ShowContactDetails(int selectedContactID){
            await _navigation.PushAsync(new DetailsPage(selectedContactID));
        }

        ContactInfo _selectedContactItem;
        public ContactInfo SelectedContactItem {
            get => _selectedContactItem;
            set {
                if (value != null){
                    _selectedContactItem = value;
                    NotifyPropertyChanged("SelectedContactItem");
                    ShowContactDetails(value.Id);
                }
            }
        }
    }
}
