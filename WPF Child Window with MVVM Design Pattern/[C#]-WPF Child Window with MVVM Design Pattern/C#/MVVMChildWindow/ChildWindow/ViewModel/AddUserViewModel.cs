using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVVMChildWindow.ChildWindow.ViewModel
{
    public class AddUserViewModel : BaseViewModel
    {
        #region Events

        public event Action<Person> Closed;

        #endregion

        #region Constructor
        public AddUserViewModel(int personId)
        {
            persons = new List<Person>()
            {
                new Person(){Id=1,Address="Blk 244/A",Email="email1@gmail.com",FirstName="FirstNameA",LastName="LastNameA"},
                new Person(){Id=2,Address="Blk 244/B",Email="email2@gmail.com",FirstName="FirstNameB",LastName="LastNameB"},
                new Person(){Id=3,Address="Blk 244/C",Email="email3@gmail.com",FirstName="FirstNameC",LastName="LastNameC"},
                new Person(){Id=4,Address="Blk 244/D",Email="email4@gmail.com",FirstName="FirstNameD",LastName="LastNameD"},
                new Person(){Id=5,Address="Blk 244/E",Email="email5@gmail.com",FirstName="FirstNameE",LastName="LastNameE"},
                new Person(){Id=6,Address="Blk 244/F",Email="email6@gmail.com",FirstName="FirstNameF",LastName="LastNameF"},
                new Person(){Id=7,Address="Blk 244/G",Email="email7@gmail.com",FirstName="FirstNameG",LastName="LastNameG"},
                new Person(){Id=8,Address="Blk 244/H",Email="email8@gmail.com",FirstName="FirstNameH",LastName="LastNameH"},
            };

            okCommand = new DelegateCommand(SavePerson);

            this.PersonId = personId;

            Init();
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

        private List<Person> persons;
        public List<Person> Persons
        {
            get { return persons; }
            set { persons = value; }
        }
        

        #endregion

        #region Command Properties

        private DelegateCommand okCommand;
        public DelegateCommand OkCommand
        {
            get { return okCommand; }
        }

        #endregion

        #region Private Methods
        private void SavePerson()
        {
            if (Closed != null)
            {
                var person = new Person()
                {
                    Address = address,
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    Id = PersonId
                };

                Closed(person);
            }
        }

        private void Init()
        {
            var person = persons.FirstOrDefault(p => p.Id == PersonId);
            FirstName = person.FirstName;
            RaisePropertyChanged("FirstName");
            LastName = person.LastName;
            RaisePropertyChanged("LastName");
            Email = person.Email;
            RaisePropertyChanged("Email");
            Address = person.Address;
            RaisePropertyChanged("Address");
        }

        #endregion
    }
}
