using SQLiteDemo.Models;
using System.Linq;

namespace SQLiteDemo.ViewModels
{
    public class CustomerViewModel : ViewModelBase
    {
        #region Properties

        private int id = 0;
        public int Id
        {
            get
            { return id; }

            set
            {
                if (id == value)
                { return; }

                id = value;
                RaisePropertyChanged("Id");
            }
        }

        private string name = string.Empty;
        public string Name
        {
            get
            { return name; }

            set
            {
                if (name == value)
                { return; }

                name = value;
                isDirty = true;
                RaisePropertyChanged("Name");
            }
        }

        private string city = string.Empty;
        public string City
        {
            get
            { return city; }

            set
            {
                if (city == value)
                { return; }

                city = value;
                isDirty = true;
                RaisePropertyChanged("City");
            }
        }

        private string contact = string.Empty;
        public string Contact
        {
            get
            { return contact; }

            set
            {
                if (contact == value)
                { return; }

                contact = value;
                isDirty = true;
                RaisePropertyChanged("Contact");
            }
        }

        private bool isDirty = false;
        public bool IsDirty
        {
            get
            {
                return isDirty;
            }

            set
            {
                isDirty = value;
                RaisePropertyChanged("IsDirty");
            }
        }

        #endregion "Properties"

        public CustomerViewModel GetCustomer(int customerId)
        {
            var customer = new CustomerViewModel();
            using (var db = new SQLite.SQLiteConnection(App.DBPath))
            {
                var _customer = (db.Table<Customer>().Where(
                    c => c.Id == customerId)).Single();
                customer.Id = _customer.Id;
                customer.Name = _customer.Name;
                customer.City = _customer.City;
                customer.Contact = _customer.Contact;
            }
            return customer;
        }

        public string GetCustomerName(int customerId)
        {
            string customerName = "Unknown";
            using (var db = new SQLite.SQLiteConnection(App.DBPath))
            {
                var customer = (db.Table<Customer>().Where(
                    c => c.Id == customerId)).Single();
                customerName = customer.Name;
            }
            return customerName;
        }

        public string SaveCustomer(CustomerViewModel customer)
        {
            string result = string.Empty;
            using (var db = new SQLite.SQLiteConnection(App.DBPath))
            {
                try
                {
                    var existingCustomer = (db.Table<Customer>().Where(
                        c => c.Id == customer.Id)).SingleOrDefault();

                    if (existingCustomer != null)
                    {
                        existingCustomer.Name = customer.Name;
                        existingCustomer.City = customer.City;
                        existingCustomer.Contact = customer.Contact;
                        int success = db.Update(existingCustomer);
                    }
                    else
                    {
                        int success = db.Insert(new Customer()
                        {
                            Name = customer.Name,
                            City = customer.City,
                            Contact = customer.Contact
                        });
                    }
                        result = "Success";
                }
                catch
                {
                    result = "This customer was not saved.";
                }
            }
            return result;
        }

        public string DeleteCustomer(int customerId)
        {
            string result = string.Empty;
            using (var db = new SQLite.SQLiteConnection(App.DBPath))
            {
                var projects = db.Table<Project>().Where(
                    p => p.CustomerId == customerId);
                var existingCustomer = (db.Table<Customer>().Where(
                    c => c.Id == customerId)).Single();

                db.RunInTransaction(() => 
                {
                    foreach (Project project in projects)
                    {
                        db.Delete(project);
                    }

                    if (db.Delete(existingCustomer) > 0)
                    {
                        result = "Success";
                    }
                    else
                    {
                        result = "This customer was not removed";
                    }
                });
            }
            return result;
        }

    }
}
