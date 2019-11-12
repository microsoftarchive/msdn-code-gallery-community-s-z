using System.IO;
using System.Data.OleDb;
using System.Collections.Generic;

namespace AccessConnections_cs
{
    public static class ConnectionsAccess
    {
        private static Dictionary<string, string> providers = new Dictionary<string, string>()
        {
            { ".accdb" , "Microsoft.ACE.OLEDB.12.0" },
            { ".mdb" , "Microsoft.Jet.OLEDB.4.0" }
        };

        public static string BuildConnectionString(this string DatabaseName)
        {

            OleDbConnectionStringBuilder Builder = new OleDbConnectionStringBuilder
            {
                Provider = providers[Path.GetExtension(DatabaseName).ToLower()],
                DataSource = DatabaseName
            };

            return Builder.ConnectionString;

        }
    }
}
