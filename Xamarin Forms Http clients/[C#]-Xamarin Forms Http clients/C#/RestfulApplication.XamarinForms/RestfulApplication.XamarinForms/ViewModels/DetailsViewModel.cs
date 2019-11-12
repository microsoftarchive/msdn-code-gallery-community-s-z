using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using RestfulApplication.Clients.Core.Services;
using RestfulApplication.Models;

namespace RestfulApplication.Clients.Core.ViewModels
{

    public class DetailsViewModel : INotifyPropertyChanged
    {
        private Employee _selectedEmployee;

        public Employee SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                _selectedEmployee = value; 
                OnPropertyChanged();
            }
        }

        public ICommand AddEmployeeCommand { get; set; }

        public ICommand EditEmployeeCommand { get; set; }

        public ICommand DeleteEmployeeCommand { get; set; }

        public DetailsViewModel()
        {
            _selectedEmployee = new Employee();

            var dataServices = new DataServices();

            AddEmployeeCommand = new RelayCommand(async () => await dataServices.AddEmployeeAsync(SelectedEmployee));

            EditEmployeeCommand = new RelayCommand(async () => await dataServices.EditEmployeeAsync(SelectedEmployee));

            DeleteEmployeeCommand = new RelayCommand(async () => await dataServices.DeleteEmmployeeAsync(SelectedEmployee));

            Messenger.Default.Register<Employee>(this, OnEmployeeMessageReceived);
        }

        private void OnEmployeeMessageReceived(Employee employee)
        {
            SelectedEmployee = employee;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
