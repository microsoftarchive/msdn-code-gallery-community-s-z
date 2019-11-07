using SQLiteDemo.Models;
using System.Collections.ObjectModel;

namespace SQLiteDemo.ViewModels
{
    public class CustomersViewModel : ViewModelBase
    {
        private ObservableCollection<CustomerViewModel> customers;
        public ObservableCollection<CustomerViewModel> Customers
        {
            get
            {
                return customers;
            }

            set
            {
                customers = value;
                RaisePropertyChanged("Customers");
            }
        }

        public ObservableCollection<CustomerViewModel> GetCustomers()
        {
            customers = new ObservableCollection<CustomerViewModel>();
            using (var db = new SQLite.SQLiteConnection(App.DBPath))
            {
                var query = db.Table<Customer>().OrderBy(c => c.Name);
                foreach (var _customer in query)
                {
                    var customer = new CustomerViewModel()
                    {
                        Id = _customer.Id,
                        Name = _customer.Name,
                        City = _customer.City,
                        Contact = _customer.Contact
                    };
                    customers.Add(customer);
                }
            }
            return customers;
        }

    }
}
