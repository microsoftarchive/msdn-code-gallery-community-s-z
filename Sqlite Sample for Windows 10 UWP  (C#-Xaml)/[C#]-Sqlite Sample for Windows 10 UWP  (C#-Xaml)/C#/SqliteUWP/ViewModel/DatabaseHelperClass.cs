using SqliteUWP.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteUWP.ViewModel
{
    class DatabaseHelperClass
    {
        //Create Tabble 
        public void CreateDatabase(string DB_PATH)
        {
            if (!CheckFileExists(DB_PATH).Result)
            {
                using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), DB_PATH))
                {
                    conn.CreateTable<Contacts>();

                }
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
        // Insert the new contact in the Contacts table. 
        public void Insert(Contacts objContact)
        {
            using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), App.DB_PATH))
            {
                conn.RunInTransaction(() =>
                {
                    conn.Insert(objContact);
                });
            }
        }
        // Retrieve the specific contact from the database.   
        public Contacts ReadContact(int contactid)
        {
            using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), App.DB_PATH))
            {
                var existingconact = conn.Query<Contacts>("select * from Contacts where Id =" + contactid).FirstOrDefault();
                return existingconact;
            }
        }
        public ObservableCollection<Contacts> ReadAllContacts()
        {
            try
            {
                using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), App.DB_PATH))
                {
                    List<Contacts> myCollection = conn.Table<Contacts>().ToList<Contacts>();
                    ObservableCollection<Contacts> ContactsList = new ObservableCollection<Contacts>(myCollection);
                    return ContactsList;
                }
            }
            catch
            {
                return null;
            }

        }
        //Update existing conatct 
        public void UpdateDetails(Contacts ObjContact)
        {
            using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), App.DB_PATH))
            {

                var existingconact = conn.Query<Contacts>("select * from Contacts where Id =" + ObjContact.Id).FirstOrDefault();
                if (existingconact != null)
                {

                    conn.RunInTransaction(() =>
                    {
                        conn.Update(ObjContact);
                    });
                }

            }
        }
        //Delete all contactlist or delete Contacts table   
        public void DeleteAllContact()
        {
            using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), App.DB_PATH))
            {

                conn.DropTable<Contacts>();
                conn.CreateTable<Contacts>();
                conn.Dispose();
                conn.Close();

            }
        }
        //Delete specific contact   
        public void DeleteContact(int Id)
        {
            using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), App.DB_PATH))
            {

                var existingconact = conn.Query<Contacts>("select * from Contacts where Id =" + Id).FirstOrDefault();
                if (existingconact != null)
                {
                    conn.RunInTransaction(() =>
                    {
                        conn.Delete(existingconact);
                    });
                }
            }
        }
    }
}
