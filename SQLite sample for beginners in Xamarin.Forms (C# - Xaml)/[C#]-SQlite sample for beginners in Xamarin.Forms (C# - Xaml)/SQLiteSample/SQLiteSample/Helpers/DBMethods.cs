using System;
using SQLite.Net;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;

namespace SQLiteSample.Helpers
{
    public class DatabaseMethods
    {
        static SQLiteConnection sqliteconnection;

        public DatabaseMethods()
        {
            sqliteconnection = DependencyService.Get<ISQLite>().GetConnection();
            sqliteconnection.CreateTable<ContactInfo>();
        }
        // Get All Contact data    

        public List<ContactInfo> GetAllContactsData()
        {
            return (from data in sqliteconnection.Table<ContactInfo>()
                    select data).ToList();
        }

        //Get Specific Contact data

        public ContactInfo GetContactData(int id)
        {
            return sqliteconnection.Table<ContactInfo>().FirstOrDefault(t => t.Id == id);
        }
        // Delete TotalContacts Data

        public void DeleteTotalContacts()
        {
            sqliteconnection.DeleteAll<ContactInfo>();
        }
        // Delete Specific Contact

        public void DeleteContact(int id)
        {
            sqliteconnection.Delete<ContactInfo>(id);
        }
        // Insert new Contact to DB    

        public void InsertContact(ContactInfo patient)
        {
            sqliteconnection.Insert(patient);
        }
        // Update Contact Data

        public void UpdateEmploee(ContactInfo patient)
        {
            sqliteconnection.Update(patient);
        }
    }
}