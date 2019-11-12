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
    public class MainViewModel : INotifyPropertyChanged
    {
        private List<Employee> _employeesList;

        public List<Employee> EmployeesList
        {
            get { return _employeesList; }
            set
            {
                _employeesList = value; 
                OnPropertyChanged();
            }
        }

        public ICommand RefreshCommand { get; set; }

        public ICommand SendEmployeeMessageCommand { get; set; }

        public MainViewModel()
        {
            RefreshCommand = new RelayCommand(async() => await DownloadDataAsync());
            
            SendEmployeeMessageCommand = new RelayCommand<Employee>(SendEmployeeMessage);

            DownloadDataAsync();
        }

        private void SendEmployeeMessage(Employee employee)
        {
            Messenger.Default.Send(employee);
        }

        private async Task DownloadDataAsync()
        {
            var dataServices = new DataServices();

            EmployeesList = await  dataServices.GetEmployeesAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;
       
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if(handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
