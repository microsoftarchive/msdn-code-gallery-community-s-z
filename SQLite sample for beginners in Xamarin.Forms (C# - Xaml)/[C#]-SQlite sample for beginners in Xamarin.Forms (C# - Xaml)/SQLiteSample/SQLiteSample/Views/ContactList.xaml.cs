using System;
using SQLiteSample.Helpers;
using SQLiteSample.Models;
using SQLiteSample.ViewModels;
using Xamarin.Forms;

namespace SQLiteSample.Views {
    public partial class ContactList : ContentPage {
        public ContactList() {
            InitializeComponent();
        }

		protected override void OnAppearing() {
            this.BindingContext = new ContactListViewModel(Navigation);
		}
    }
}
