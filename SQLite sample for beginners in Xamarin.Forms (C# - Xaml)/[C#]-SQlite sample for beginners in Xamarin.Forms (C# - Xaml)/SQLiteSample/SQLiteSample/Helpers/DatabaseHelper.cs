using SQLite.Net;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;
using SQLiteSample.Models;
using System;

namespace SQLiteSample.Helpers {
    public class DatabaseHelper {
        
        static SQLiteConnection sqliteconnection;
        public const string DbFileName = "Contacts.db";

        public DatabaseHelper() {
            sqliteconnection = DependencyService.Get<ISQLite>().GetConnection();
            sqliteconnection.CreateTable<ContactInfo>();
        }

        // Get All Contact data    
        public List<ContactInfo> GetAllContactsData() {
            return (from data in sqliteconnection.Table<ContactInfo>()
                    select data).ToList();
        }

		//Get Specific Contact data
        public ContactInfo GetContactData(int id) {
            return sqliteconnection.Table<ContactInfo>().FirstOrDefault(t => t.Id == id);
        }

        // Delete all Contacts Data
        public void DeleteAllContacts() {
            sqliteconnection.DeleteAll<ContactInfo>();
        }

        // Delete Specific Contact
        public void DeleteContact(int id) {
            sqliteconnection.Delete<ContactInfo>(id);
        }

        // Insert new Contact to DB 
        public void InsertContact(ContactInfo contact) {
            sqliteconnection.Insert(contact);
        }

        // Update Contact Data
        public void UpdateContact(ContactInfo contact) {
            sqliteconnection.Update(contact);
        }
    }
}