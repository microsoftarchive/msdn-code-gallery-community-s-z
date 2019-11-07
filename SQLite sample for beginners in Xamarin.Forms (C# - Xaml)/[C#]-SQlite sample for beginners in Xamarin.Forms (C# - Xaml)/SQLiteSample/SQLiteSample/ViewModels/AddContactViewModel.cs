using System.Threading.Tasks;
using System.Windows.Input;
using SQLiteSample.Helpers;
using SQLiteSample.Models;
using SQLiteSample.Servcies;
using SQLiteSample.Validator;
using SQLiteSample.Views;
using Xamarin.Forms;

namespace SQLiteSample.ViewModels {
    public class AddContactViewModel : BaseContactViewModel {

        public ICommand AddContactCommand { get; private set; }
        public ICommand ViewAllContactsCommand { get; private set; }

        public AddContactViewModel(INavigation navigation){
            _navigation = navigation;
            _contactValidator = new ContactValidator();
            _contact = new ContactInfo();
            _contactRepository = new ContactRepository();

            AddContactCommand = new Command(async () => await AddContact()); 
            ViewAllContactsCommand = new Command(async () => await ShowContactList()); 
        }

        async Task AddContact() {
            var validationResults = _contactValidator.Validate(_contact);    
    
            if (validationResults.IsValid){
                bool isUserAccept = await Application.Current.MainPage.DisplayAlert("Add Contact", "Do you want to save Contact details?", "OK", "Cancel");
                if (isUserAccept) {
                    _contactRepository.InsertContact(_contact);
                    await _navigation.PushAsync(new ContactList());
                }
            }    
            else {    
                await Application.Current.MainPage.DisplayAlert("Add Contact", validationResults.Errors[0].ErrorMessage, "Ok");    
            }     
        }

        async Task ShowContactList(){ 
            await _navigation.PushAsync(new ContactList());
        }

        public bool IsViewAll => _contactRepository.GetAllContactsData().Count > 0 ? true : false;
    }
}
