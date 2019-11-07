using SQLiteSample.ViewModels;
using Xamarin.Forms;

namespace SQLiteSample.Views
{
    public partial class AddContact : ContentPage {
        public AddContact() {
            InitializeComponent();
            BindingContext = new AddContactViewModel(Navigation);
        }
    }
}
