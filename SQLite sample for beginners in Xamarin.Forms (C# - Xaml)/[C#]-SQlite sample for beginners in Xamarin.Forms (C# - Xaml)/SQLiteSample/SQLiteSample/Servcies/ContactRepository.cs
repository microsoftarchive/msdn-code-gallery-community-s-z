using System.Collections.Generic;
using SQLiteSample.Helpers;
using SQLiteSample.Models;

namespace SQLiteSample.Servcies
{
    public class ContactRepository : IContactRepository
    {
        DatabaseHelper _databaseHelper;
        public ContactRepository(){
            _databaseHelper = new DatabaseHelper();
        }

        public void DeleteContact(int contactID)
        {
            _databaseHelper.DeleteContact(contactID);
        }

        public void DeleteAllContacts()
        {
            _databaseHelper.DeleteAllContacts();
        }

        public List<ContactInfo> GetAllContactsData()
        {
            return _databaseHelper.GetAllContactsData();
        }

        public ContactInfo GetContactData(int contactID)
        {
            return _databaseHelper.GetContactData(contactID);
        }

        public void InsertContact(ContactInfo contact)
        {
            _databaseHelper.InsertContact(contact);
        }

        public void UpdateContact(ContactInfo contact)
        {
            _databaseHelper.UpdateContact(contact);
        }
    }
}
