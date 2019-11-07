using System.Threading.Tasks;
using System.Windows.Input;
using SQLiteSample.Helpers;
using SQLiteSample.Models;
using SQLiteSample.Servcies;
using SQLiteSample.Validator;
using Xamarin.Forms;

namespace SQLiteSample.ViewModels {
    public class DetailsViewModel: BaseContactViewModel {

        public ICommand UpdateContactCommand { get; private set; }
        public ICommand DeleteContactCommand { get; private set; }

        public DetailsViewModel(INavigation navigation, int selectedContactID) {
            _navigation = navigation;
            _contactValidator = new ContactValidator();
            _contact = new ContactInfo();
            _contact.Id = selectedContactID;
            _contactRepository = new ContactRepository();

            UpdateContactCommand = new Command(async () => await UpdateContact());
            DeleteContactCommand = new Command(async () => await DeleteContact());

            FetchContactDetails();
        }

        void FetchContactDetails(){
            _contact = _contactRepository.GetContactData(_contact.Id);
        }

        async Task UpdateContact() {
            var validationResults = _contactValidator.Validate(_contact);

            if (validationResults.IsValid) {
                bool isUserAccept = await Application.Current.MainPage.DisplayAlert("Contact Details", "Update Contact Details", "OK", "Cancel");
                if (isUserAccept) {
                    _contactRepository.UpdateContact(_contact);
                    await _navigation.PopAsync();
                }
            }
            else {
                await Application.Current.MainPage.DisplayAlert("Add Contact", validationResults.Errors[0].ErrorMessage, "Ok");
            }
        }

        async Task DeleteContact() {
            bool isUserAccept = await Application.Current.MainPage.DisplayAlert("Contact Details", "Delete Contact Details", "OK", "Cancel");
            if (isUserAccept) {
                _contactRepository.DeleteContact(_contact.Id);
                await _navigation.PopAsync();
            }
        }
    }
}

