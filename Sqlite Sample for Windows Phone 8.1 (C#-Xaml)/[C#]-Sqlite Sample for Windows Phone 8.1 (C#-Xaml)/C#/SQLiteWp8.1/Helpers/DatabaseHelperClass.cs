using SQLite;
using SQLiteWp8._1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteWp8._1.Helpers
{
    public class DatabaseHelperClass
    {
        SQLiteConnection dbConn;

        //Create Tabble 
        public async Task<bool> onCreate(string DB_PATH)
        {
            try
            {
                if (!CheckFileExists(DB_PATH).Result)
                {
                    using (dbConn = new SQLiteConnection(DB_PATH))
                    {
                        dbConn.CreateTable<Contacts>();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        private async Task<bool> CheckFileExists(string fileName)
        {
            try
            {
                var store = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Retrieve the specific contact from the database. 
        public Contacts ReadContact(int contactid)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                var existingconact = dbConn.Query<Contacts>("select * from Contacts where Id =" + contactid).FirstOrDefault();
                return existingconact;
            }
        }
        // Retrieve the all contact list from the database. 
        public ObservableCollection<Contacts> ReadContacts()
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                List<Contacts> myCollection = dbConn.Table<Contacts>().ToList<Contacts>();
                ObservableCollection<Contacts> ContactsList = new ObservableCollection<Contacts>(myCollection);
                return ContactsList;
            }
        }

        //Update existing conatct 
        public void UpdateContact(Contacts contact)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                var existingconact = dbConn.Query<Contacts>("select * from Contacts where Id =" + contact.Id).FirstOrDefault();
                if (existingconact != null)
                {
                    existingconact.Name = contact.Name;
                    existingconact.PhoneNumber = contact.PhoneNumber;
                    existingconact.CreationDate = contact.CreationDate;
                    dbConn.RunInTransaction(() =>
                    {
                        dbConn.Update(existingconact);
                    });
                }
            }
        }
        // Insert the new contact in the Contacts table. 
        public void Insert(Contacts newcontact)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                dbConn.RunInTransaction(() =>
                {
                    dbConn.Insert(newcontact);
                });
            }
        }

        //Delete specific contact 
        public void DeleteContact(int Id)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                var existingconact = dbConn.Query<Contacts>("select * from Contacts where Id =" + Id).FirstOrDefault();
                if (existingconact != null)
                {
                    dbConn.RunInTransaction(() =>
                    {
                        dbConn.Delete(existingconact);
                    });
                }
            }
        }
        //Delete all contactlist or delete Contacts table 
        public void DeleteAllContact()
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                //dbConn.RunInTransaction(() => 
                //   { 
                dbConn.DropTable<Contacts>();
                dbConn.CreateTable<Contacts>();
                dbConn.Dispose();
                dbConn.Close();
                //}); 
            }
        }
    }
}
