using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;
using MVVMValidation.Commands;
using MVVMValidation.Model;
using MVVMValidation.Notification;

namespace MVVMValidation.ViewModel
{
    public class CustomerViewModel : PropertyChangedNotification
    {
        private static CustomerViewModel customerViewModel;
        private static string Filename = Directory.GetCurrentDirectory() + "\\Output.xml";

        public ObservableCollection<Customer> Customers
        {
            get { return GetValue(() => Customers); }
            set { SetValue(() => Customers, value); }
        }

        public Customer NewCustomer
        {
            get { return GetValue(() => NewCustomer); }
            set { SetValue(() => NewCustomer, value); }
        }

        public RelayCommand SaveCommand { get; set; }

        public RelayCommand ClearCommand { get; set; }

        public RelayCommand SaveDataCommand { get; set; }

        public static int Errors { get; set; }

        public static CustomerViewModel SharedViewModel()
        {
            return customerViewModel ?? (customerViewModel = new CustomerViewModel());
        }

        private CustomerViewModel()
        {
            if (File.Exists(Filename))
            {
                Customers = Deserialize<ObservableCollection<Customer>>();
            }
            else
            {
                Customers = new ObservableCollection<Customer>();
                Customers.Add(new Customer { Id = 1, Name = "William", Email = "william@hotmail.com", RepeatEmail = "william@hotmail.com", Age = 23, Gender = Gender.Male });
            }
            NewCustomer = new Customer();
            SaveCommand = new RelayCommand(Save, CanSave);
            ClearCommand = new RelayCommand(Clear);
            SaveDataCommand = new RelayCommand(SaveData);
        }

        public void Save(object parameter)
        {
            Customers.Add(NewCustomer);
            Clear(this);
        }

        public bool CanSave(object parameter)
        {
            if (Errors == 0)
                return true;
            else
                return false;
        }

        public void Clear(object parameter)
        {
            NewCustomer = new Customer();
        }

        public void SaveData(object parameter)
        {
            var result = Serialize<ObservableCollection<Customer>>(Customers);
            if (result) MessageBox.Show("Data Saved Successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            else MessageBox.Show("Data Not Saved", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private bool Serialize<T>(T value)
        {
            if (value == null)
            {
                return false;
            }
            try
            {
                XmlSerializer _xmlserializer = new XmlSerializer(typeof(T));
                Stream stream = new FileStream(Filename, FileMode.CreateNew);
                _xmlserializer.Serialize(stream, value);
                stream.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private T Deserialize<T>()
        {
            if (string.IsNullOrEmpty(Filename))
            {
                return default(T);
            }
            try
            {
                XmlSerializer _xmlSerializer = new XmlSerializer(typeof(T));
                Stream stream = new FileStream(Filename, FileMode.Open, FileAccess.Read);
                var result = (T)_xmlSerializer.Deserialize(stream);
                stream.Close();
                return result;
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }
    }
}
