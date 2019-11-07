using Microsoft.Practices.Prism.Commands;
using MVVMChildWindow.ChildWindow;

namespace MVVMChildWindow
{
    public class MainViewModel:BaseViewModel
    {
        #region Construction
        public MainViewModel()
        {
            showChildWindowCommand = new DelegateCommand(ShowChildWindow);
        } 

        #endregion

        #region Public Properties

        public int PersonId { get; set; }

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                RaisePropertyChanged("FirstName");
            }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                RaisePropertyChanged("LastName");
            }
        }

        private string address;
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                RaisePropertyChanged("Address");
            }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                RaisePropertyChanged("Email");
            }
        }

        private DelegateCommand showChildWindowCommand;
        public DelegateCommand ShowChildWindowCommand
        {
            get { return showChildWindowCommand; }
        } 

        #endregion

        #region Private Methods

        private void ShowChildWindow()
        {
            var childWindow = new ChildWindowView();
            childWindow.Closed += (r =>
                {
                    FirstName = r.FirstName;
                    RaisePropertyChanged("FirstName");

                    LastName = r.LastName;
                    RaisePropertyChanged("LastName");

                    Email = r.Email;
                    RaisePropertyChanged("Email");

                    Address = r.Address;
                    RaisePropertyChanged("Address");
                });
            childWindow.Show(1);
        } 

        #endregion   
    }
}
