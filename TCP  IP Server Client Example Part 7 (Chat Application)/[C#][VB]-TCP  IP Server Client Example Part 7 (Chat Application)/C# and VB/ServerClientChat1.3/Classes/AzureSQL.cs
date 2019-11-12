using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace ServerClientChat1._3.Classes
{
    /// <summary>
    /// All our methods to interact with the SQL Server
    /// Information about connecting to Azure SQL: http://www.windowsazure.com/EN-US/develop/net/how-to-guides/sql-database/
    /// Read the information provided.
    /// </summary>
    class AzureSQL
    {
        public string ConnectionString { get; set; }
        public SqlConnection conn { get; set; }

        public string LastError { get; set; }

        public delegate void SQLInfoMessageHandler(string Message);
        public event SQLInfoMessageHandler SQLInfoMessage;
        public delegate void SQLStateChangedHandler(System.Data.ConnectionState State);
        public event SQLStateChangedHandler SQLStateChanged;

        /// <summary>
        /// Main Connection Method
        /// </summary>
        /// <returns>
        /// Fake Bool: Hard Coded to True
        /// </returns>
        internal bool Connect()
        {
            Task tConnectAsync = new Task(() => ConnectAsync());
            tConnectAsync.Start();
            return true;
        }

        /// <summary>
        /// TODO: Keep retrying connection on Fail.
        /// </summary>
        private void ConnectAsync()
        {
            if (!string.IsNullOrWhiteSpace(ConnectionString))
            {
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                conn.InfoMessage += conn_InfoMessage;
                conn.StateChange += conn_StateChange;

                switch (conn.State)
                {
                    case System.Data.ConnectionState.Broken:
                        SQLStateChanged(conn.State);
                        break;

                    case System.Data.ConnectionState.Closed:
                        SQLStateChanged(conn.State);
                        break;

                    case System.Data.ConnectionState.Connecting:
                        SQLStateChanged(conn.State);
                        break;

                    case System.Data.ConnectionState.Executing:
                        SQLStateChanged(conn.State);
                        break;

                    case System.Data.ConnectionState.Fetching:
                        SQLStateChanged(conn.State);
                        break;

                    case System.Data.ConnectionState.Open:
                        SQLStateChanged(conn.State);
                        break;

                    default:
                        SQLStateChanged(conn.State);
                        break;

                }
            }

        }

        void conn_StateChange(object sender, System.Data.StateChangeEventArgs e)
        {
            SQLStateChanged(e.CurrentState);
        }

        void conn_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            SQLInfoMessage(e.Message);
        }

        public bool RegisterUser(string email, string password)
        {
            try
            {
                string emailValue = email;
                string passwordValue = password;
                string screenNameValue = "";  // Not currently used
                bool onlineStatusValue = true;
                string queryString = "INSERT INTO dbo.Users (ScreenName, EmailAddress, Password, Online) Values (@screenName, @email, @password, @Online);";
                SqlCommand command = new SqlCommand(queryString, conn);
                command.Parameters.AddWithValue("@email", emailValue);
                command.Parameters.AddWithValue("@password", passwordValue);
                command.Parameters.AddWithValue("@screenName", screenNameValue);
                command.Parameters.AddWithValue("@Online", onlineStatusValue);

                int RowsAffected = (int)command.ExecuteNonQuery();
                if (RowsAffected > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                SQLInfoMessage("Error RegisterUser " + ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Get the User's ID. Sent by server back to connecting client so that all communications are unique.
        /// Should all be in a Try Catch Block
        /// </summary>
        /// <param name="emailAddress">
        /// The EmailAddress of the User Who's ID we want
        /// </param>
        /// <returns>
        /// int: ClientID from dbo.Users
        /// </returns>
        internal int GetUsersID(string emailAddress)
        {
            try
            {
                int userID = 0;
                string paramValue = emailAddress;
                string queryString = "SELECT ClientID FROM dbo.Users WHERE EmailAddress = @emailAddress;";
                SqlCommand command = new SqlCommand(queryString, conn);
                command.Parameters.AddWithValue("@emailAddress", paramValue);
                userID = (int)command.ExecuteScalar();

                return userID;
            }
            catch (Exception ex)
            {
                SQLInfoMessage("Error GetUsersID " + ex.Message);
            }
            return -1;
        }

        /// <summary>
        /// Is this user Registered?
        /// </summary>
        /// <param name="p">
        /// string: The User Name
        /// </param>
        /// <returns>
        /// bool:   True = they are registered
        ///         false = they are not registered
        /// </returns>
        internal bool RegisterUserExists(string emailAddress)
        {
            try
            {
                int userId = 0;
                string paramValue = emailAddress;
                string queryString = "SELECT ClientID FROM dbo.Users WHERE EmailAddress = @emailAddress;";
                SqlCommand command = new SqlCommand(queryString, conn);
                command.Parameters.AddWithValue("@emailAddress", paramValue);
                userId = (int)command.ExecuteScalar();

                return true;
            }
            catch (Exception ex)
            {
                SQLInfoMessage("Error RegisterUserExists " + ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Now log the user is
        /// </summary>
        /// <param name="p1">
        /// string: Username
        /// </param>
        /// <param name="p2">
        /// string: Password
        /// We would use the password in production to decrypt the user's data before updating and re-encrypt it afterwards. Thus
        /// ensuring that their data is totally private and that we do not have the decryption key for their data
        /// </param>
        /// <returns>
        /// bool:   True if successful
        ///         False if failed
        /// </returns>
        internal bool LoginUser(string p1, string p2)
        {
            try
            {
                string emailValue = p1;

                bool onlineStatusValue = true;
                string queryString = "UPDATE dbo.Users SET Online = @Online WHERE EmailAddress = @EmailValue";
                SqlCommand command = new SqlCommand(queryString, conn);

                command.Parameters.AddWithValue("@Online", onlineStatusValue);
                command.Parameters.AddWithValue("@EmailValue", emailValue);

                int RowsAffected = (int)command.ExecuteNonQuery();
                if (RowsAffected > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                SQLInfoMessage("Error LoginUser " + ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Discovers how many users are Registered with our chat server
        /// </summary>
        /// <returns>
        /// int: Number of registered users (In production this may need to be a long)
        /// </returns>
        internal int GetRegisteredUsers()
        {
            try
            {
                int Total = 0;
                string queryString = "Select Coalesce(Sum(ClientID), 0) From dbo.Users"; // Converts a Null value to 0
                SqlCommand command = new SqlCommand(queryString, conn);
                
                Total = (int)command.ExecuteScalar();

                return Total;
            }
            catch (Exception ex)
            {
                SQLInfoMessage("Error GetRegisteredUsers " + ex.Message);
            }
            return 0;
        }

        internal void LogOffClient(string Sender)
        {
            try
            {
                string UserID = Sender;

                bool onlineStatusValue = false;
                string queryString = "UPDATE dbo.Users SET Online = @Online WHERE ClientID = @UserIDValue";
                SqlCommand command = new SqlCommand(queryString, conn);

                command.Parameters.AddWithValue("@Online", onlineStatusValue);
                command.Parameters.AddWithValue("@UserIDValue", UserID);

                int RowsAffected = (int)command.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
               // If the User does not exist as a registered user - they will not be Logged in, so this will raise an error which
                // we don't care about.
                SQLInfoMessage("Error LogOggClient " + ex.Message);
            }
            
        }

        /// <summary>
        /// Is this client Logged in?
        /// </summary>
        /// <param name="id">
        /// String: The ClientID to check
        /// </param>
        /// <returns>
        /// Bool: True if the client is logged in
        ///         False if the client is not logged in
        /// </returns>
        internal bool ClientIsLoggedIn(string id)
        {
            try
            {
                
                string queryString = "SELECT Online FROM dbo.Users WHERE ClientID = @clientID;";
                SqlCommand command = new SqlCommand(queryString, conn);
                command.Parameters.AddWithValue("@clientID", id);
                bool result = (bool)command.ExecuteScalar();

                return result;
            }
            catch (Exception ex)
            {
                SQLInfoMessage("Error ClientIsLoggedIn " + ex.Message);
            }
            return false; // Eeek hate lying :P
        }

        /// <summary>
        /// Add this friend to the Senders list of friends
        /// </summary>
        /// <param name="Sender">
        /// The Sender who is adding a new friend
        /// </param>
        /// <param name="friendsEmail"></param>
        /// <returns></returns>
        internal bool AddFriend(string Sender, string friendsEmail)
        {
            try
            {
                int FriendsID = GetUsersID(friendsEmail);
                int SendersId = int.Parse(Sender);
                string queryString = "INSERT INTO dbo.Friends (UserID, FriendsUserID) Values (@SendersId, @FriendsID);";
                SqlCommand command = new SqlCommand(queryString, conn);
                command.Parameters.AddWithValue("@SendersId", SendersId);
                command.Parameters.AddWithValue("@FriendsID", FriendsID);
                

                int RowsAffected = (int)command.ExecuteNonQuery();
                if (RowsAffected > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                SQLInfoMessage("Error RegisterUser " + ex.Message);
            }
            return false;
        }
    }
}
