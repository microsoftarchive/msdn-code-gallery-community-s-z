using NetComm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ServerClientChat1._3.Classes;
using ServerClientChat1._3.Forms;

namespace ServerClientChat1._3
{
    public partial class FrmServer : Form
    {

        private static readonly int OurPort = 3000;         // The Server's Port
        private NetComm.Host server = new Host(OurPort);    // Listens on port 3330.
        private PublicIP pip = new PublicIP();              // Class to get Server's Public IP Address
        private AzureSQL AzureDB = new AzureSQL();          // Class for communicating with Azure Database
      
        private int TotalConnectedUsers = 0;                // In production you may want to use longs instead of ints.
        private int TotalRegisteredUsers = 0;               // In production you may want to use longs instead of ints.
        private int TotalLoggedInUsers = 0;               // In production you may want to use longs instead of ints.

        private delegate void UpdateConnectedUsersDelegate(string s);
        public delegate void UpdateLogDelegate(string txt);
        public delegate void IPAddressDelegate(string ip);
        public delegate void UpdateTotalLoggedInUsersDelegate(string number);
        public delegate void UpdateTotalRegisteredUsersDelegate(int number);

        public FrmServer()
        {
            InitializeComponent();
           }

        /// <summary>
        /// Start The server and Setup initial variables and connections
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmServer_Load(object sender, EventArgs e)
        {
            // Get Azure Server Name, Table Name, User name and Password

            FrmAzureDatabaseLogin AzureLogin = new FrmAzureDatabaseLogin();
            DialogResult dr = AzureLogin.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {

                AzureDB.SQLInfoMessage += AzureDB_SQLInfoMessage; // Get any messages from the SQL Database
                AzureDB.SQLStateChanged += AzureDB_SQLStateChanged; // Keep track of Database Connection Changes

                AzureDB.ConnectionString = "Server=tcp:" + AzureLogin.ServerName + ";Database=ChatApp;User ID=" + AzureLogin.UserName + ";Password=" + AzureLogin.Password + ";Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
                if (AzureDB.Connect())
                {
                    // Display our Public IP Address and the port we are listening to.
                    pip = new PublicIP();
                    pip.PublicIPKnown += pip_PublicIPKnown; // Get's the Public IP Address of the Server (Event)
                    pip.PublicIPError += pip_PublicIPError; // Notifies us of any Errors Getting the Public IP
                    pip.GetPublicIpAddress(); // Will Raise the above event
                    lblPort.Text = OurPort.ToString();

                    // Subscribe to Server Events
                    server.ConnectionClosed += server_ConnectionClosed;
                    server.DataReceived += server_DataReceived;
                    server.DataTransferred += server_DataTransferred;
                    server.errEncounter += server_errEncounter;
                    server.lostConnection += server_lostConnection;
                    server.onConnection += server_onConnection;
                    server.StartConnection(); // Don't forget to start your server !!

                    // Now get total number of Registered Users.
                    TotalRegisteredUsers = AzureDB.GetRegisteredUsers();
                    UpdateTotalRegisteredUsers(TotalRegisteredUsers);
                }
                else
                {
                    MessageBox.Show("Azure Database Error: " + AzureDB.LastError);
                    lblConnectionState.Image = ServerClientChat1._3.Properties.Resources.database_red;
                }

            }
            else
            {
                MessageBox.Show("The Server cannot run unless connected to the Server's Azure SQL Database \n\rClosing Application");
                this.Close();
            }
        }

       

        void pip_PublicIPError(string Message)
        {
            Log("Public IP: " + Message);
        }

        void server_onConnection(string id)
        {
            this.TotalConnectedUsers++;
            UpdateConnectedUser(TotalConnectedUsers.ToString("N0"));

        }

        private void UpdateConnectedUser(string s)
        {
            if (this.lblTotalConnectedUsers.InvokeRequired)
            {
                UpdateConnectedUsersDelegate d = new UpdateConnectedUsersDelegate(UpdateConnectedUser);
                this.lblTotalConnectedUsers.Invoke(d, new object[] { s });
            }
            else
            {
                this.lblTotalConnectedUsers.Text = s;

            }
        }

        private void UpdateTotalRegisteredUsers(int TotalRegisteredUsers)
        {
            if (this.lblTotalRegisteredUsers.InvokeRequired)
            {
                UpdateTotalRegisteredUsersDelegate d = new UpdateTotalRegisteredUsersDelegate(UpdateTotalRegisteredUsers);
                this.lblTotalConnectedUsers.Invoke(d, new object[] { TotalRegisteredUsers });
            }
            else
            {
                this.lblTotalRegisteredUsers.Text = TotalRegisteredUsers.ToString("N0");

            }
        }

        void server_lostConnection(string id)
        {
            UpdateLoggedInUsers(TotalLoggedInUsers.ToString("N0"));
            UpdateConnectedUser(TotalConnectedUsers.ToString("N0"));
        }

        void server_errEncounter(Exception ex)
        {
            throw new NotImplementedException();
        }

        void server_DataTransferred(string Sender, string Recipient, byte[] Data)
        {
            string message = ConvertBytesToString(Data);
            if (Recipient == "0") // The Server's ID
            {
                Log("Received Command From Client " + Sender + " for this Server");


                if (message.StartsWith("CLOSING"))
                {
                    DoClientClosing(Sender);
                }
                else if (message.StartsWith("REGISTRATION"))
                {
                    DoRegistration(Sender, message);
                }
                else if (message.StartsWith("LOGIN"))
                {
                    DoLogin(Sender, message);
                }
                else if (message.StartsWith("RELOGIN"))
                {
                    DoRelogin(Sender, message);
                }
                else
                {
                    this.Log("Received Command From Client " + Sender + " for this Server: " + message);
                }


            }
            else
            {
                this.Log("Received Command From Client " + Sender + " for this Server: " + message);
            }
        }

        private void DoClientClosing(string Sender)
        {
            this.TotalConnectedUsers--;
            UpdateConnectedUser(TotalConnectedUsers.ToString("N0"));
            this.Log("Client " + Sender + " is Closing");
        }

        private void DoRegistration(string Sender, string message)
        {
            // Message = REGISTRATION:<USERNAME>:<PASSWORD>

            if (!AzureDB.RegisterUser(message.Split(':')[1].ToString(), message.Split(':')[2].ToString()))
            {
                this.server.SendData(Sender, ConvertStringToBytes("ERROR:That email is already registered."));
                this.Log("Client " + Sender + "ERROR:That email is already registered.");
            }
            else
            {
                int cID = AzureDB.GetUsersID(message.Split(':')[1].ToString());
                this.TotalLoggedInUsers++; // Add this user to the logged in user count
                this.TotalRegisteredUsers++;
                UpdateTotalRegisteredUsers(TotalRegisteredUsers);
                this.server.SendData(Sender, ConvertStringToBytes("SUCCESS:Logged On " + cID));
                this.Log("Client " + Sender + "SUCCESS registered.");
            }
        }

        private void DoRelogin(string Sender, string message)
        {
            // Message = RELOGIN:<USERNAME>:<PASSWORD>
            string[] parts = message.Split(':');
            if (AzureDB.LoginUser(message.Split(':')[1].ToString(), message.Split(':')[2].ToString()))
            {
                // Successfully logged in With Correct User ID
                this.TotalLoggedInUsers++;
                UpdateLoggedInUsers(TotalLoggedInUsers.ToString("N0"));

                this.Log("Client " + parts[1].ToString() + " SUCCESS Logged in.");
            }
            else
            {
                this.server.SendData(Sender, ConvertStringToBytes("ERROR:Login Details Not Recognized"));
                this.Log("Client " + Sender + "ERROR:Login Details Not Recognized");
            }
        }

        private void DoLogin(string Sender, string message)
        {
            // Message = LOGIN:<USERNAME>:<PASSWORD>
            string[] parts = message.Split(':');
            if (AzureDB.RegisterUserExists(parts[1].ToString()))
            {

                if (AzureDB.LoginUser(message.Split(':')[1].ToString(), message.Split(':')[2].ToString()))
                {
                    // Successfully logged in
                    int newSenderId = AzureDB.GetUsersID(message.Split(':')[1].ToString()); // Get this user's client ID
                    this.server.SendData(Sender, ConvertStringToBytes("ID:" + newSenderId.ToString())); // Send the correct ID to the Client
                    this.TotalLoggedInUsers++;
                    UpdateLoggedInUsers(TotalLoggedInUsers.ToString("N0"));

                    this.Log("Client " + parts[1].ToString() + " SUCCESS Logged in.");
                }
                else
                {
                    this.server.SendData(Sender, ConvertStringToBytes("ERROR:Login Details Not Recognized"));
                    this.Log("Client " + Sender + "ERROR:Login Details Not Recognized");
                }
            }
            else
            {
                this.server.SendData(Sender, ConvertStringToBytes("ERROR:Login Details Not Recognized"));
                this.Log("Client " + Sender + "ERROR:Login Details Not Recognized");
            }
        }

       

        private void server_DataReceived(string ID, byte[] Data)
        {
            throw new NotImplementedException();
        }

        void server_ConnectionClosed()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The Azure Database Connection has changed.
        /// </summary>
        /// <param name="State"></param>
        void AzureDB_SQLStateChanged(ConnectionState State)
        {
            switch (State)
            {
                case ConnectionState.Broken:
                    lblConnectionState.Image = ServerClientChat1._3.Properties.Resources.database_red; // Show Database connection is off
                    lblConnectionState.ToolTipText = "Connection to Azure DB is " + State.ToString();
                    Progress.Enabled = false;
                    break;
                case ConnectionState.Closed:
                    lblConnectionState.Image = ServerClientChat1._3.Properties.Resources.database_red; // Show Database connection is off
                    lblConnectionState.ToolTipText = "Connection to Azure DB is " + State.ToString();
                    Progress.Enabled = false;
                    break;
                case ConnectionState.Connecting:
                    lblConnectionState.Image = ServerClientChat1._3.Properties.Resources.database_blue; // Show Database connection is Connecting
                    lblConnectionState.ToolTipText = "Connection to Azure DB is " + State.ToString();
                    Progress.Enabled = true;
                    break;
                case ConnectionState.Executing:
                    lblConnectionState.Image = ServerClientChat1._3.Properties.Resources.database_blue; // Show Database connection is Connecting
                    lblConnectionState.ToolTipText = "Connection to Azure DB is " + State.ToString();
                    Progress.Enabled = true;
                    break;
                case ConnectionState.Fetching:
                    lblConnectionState.Image = ServerClientChat1._3.Properties.Resources.database_blue; // Show Database connection is Connecting
                    lblConnectionState.ToolTipText = "Connection to Azure DB is " + State.ToString();
                    Progress.Enabled = true;
                    break;
                case ConnectionState.Open:
                    lblConnectionState.Image = ServerClientChat1._3.Properties.Resources.database_green; // Show Database connection is Connected
                    lblConnectionState.ToolTipText = "Connection to Azure DB is " + State.ToString();
                    Progress.Enabled = true;
                    break;
                default:
                    lblConnectionState.Image = ServerClientChat1._3.Properties.Resources.database_red; // Show Database connection is off
                    lblConnectionState.ToolTipText = "Connection to Azure DB is " + State.ToString();
                    Progress.Enabled = false;
                    break;
            }
        }

        /// <summary>
        /// We have a new MEssage from the Azure Database
        /// </summary>
        /// <param name="Message"></param>
        void AzureDB_SQLInfoMessage(string Message)
        {
            Log(Message);
        }

        /// <summary>
        /// Display Logging Messages to Admin
        /// </summary>
        /// <param name="Message"></param>
        private void Log(string Message)
        {
            if (this.rtbConOut.InvokeRequired)
            {
                UpdateLogDelegate d = new UpdateLogDelegate(Log);
                this.rtbConOut.Invoke(d, new object[] { Message });
            }
            else
            {
                rtbConOut.AppendText(Message + Environment.NewLine);
                rtbConOut.Focus();
            }
        }

        private void UpdateLoggedInUsers(string p)
        {
            if (this.lblTotalLoggedInUsers.InvokeRequired)
            {
                UpdateTotalLoggedInUsersDelegate d = new UpdateTotalLoggedInUsersDelegate(UpdateLoggedInUsers);
                this.lblTotalLoggedInUsers.Invoke(d, new object[] { p });
            }
            else
            {
                lblTotalLoggedInUsers.Text = p;
              
            }
        }

        /// <summary>
        /// Sets the Public IP Address Label
        /// </summary>
        /// <param name="PublicIP">
        /// String: The public IP Address that the Server is showing the world
        /// </param>
        void pip_PublicIPKnown(string PublicIP)
        {
            if (this.lblIPAddress.InvokeRequired)
            {
                IPAddressDelegate d = new IPAddressDelegate(pip_PublicIPKnown);
                this.lblIPAddress.Invoke(d, new object[] { PublicIP });
            }
            else
            {
                lblIPAddress.Text = PublicIP;
            }
        }

        /// <summary>
        /// Do house maintenance before closing.
        /// Including Notifying all users if possible
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Unsubscribe to Server Events
            server.ConnectionClosed -= server_ConnectionClosed;
            server.DataReceived -= server_DataReceived;
            server.DataTransferred -= server_DataTransferred;
            server.errEncounter -= server_errEncounter;
            server.lostConnection -= server_lostConnection;
            server.onConnection -= server_onConnection;

            // Unsubscribe to PublicIP Events
            pip.PublicIPKnown -= pip_PublicIPKnown;
            pip.PublicIPError -= pip_PublicIPError;

            // Unsubscribe to AzureDB Events
            AzureDB.SQLInfoMessage -= AzureDB_SQLInfoMessage;
            AzureDB.SQLStateChanged -= AzureDB_SQLStateChanged;
        }

             

        /// <summary>
        /// Convert Messages from the Server into English
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        string ConvertBytesToString(byte[] bytes)
        {
            return ASCIIEncoding.ASCII.GetString(bytes);
        }

        /// <summary>
        /// Convert English messages into Messages for the server
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        byte[] ConvertStringToBytes(string str)
        {
            return ASCIIEncoding.ASCII.GetBytes(str);
        }
    }
}
