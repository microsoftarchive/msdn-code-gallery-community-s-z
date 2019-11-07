using System;
using System.IO;
using Xamarin.Forms;
using SQLite.Net;
using SQLiteSample.Helpers;
using SQLiteSample.iOS.Implementaions;

[assembly: Dependency(typeof(IOSSQLite))]
namespace SQLiteSample.iOS.Implementaions {
    public class IOSSQLite : ISQLite {
        public SQLiteConnection GetConnection() {
			string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
			string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
            var path = Path.Combine(libraryPath, DatabaseHelper.DbFileName);
			// Create the connection
			var plat = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
			var conn = new SQLiteConnection(plat, path);
			// Return the database connection
			return conn;
		}
	}
}
