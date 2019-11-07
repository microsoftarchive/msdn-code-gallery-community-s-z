using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class FrmChat : Form
    {
        private NetComm.Client client = new NetComm.Client();
        private string cID = "-1" + Guid.NewGuid().ToString();       // Temporary Client ID - Replaced by Server on Successful Login
        private readonly string ForServer = "0"; // Messages for the server only
        private string message = ""; // The Message We are sending to the Server or our Friends.

        private string username = null;
        private string password = null;

        public delegate void UpdateFormTitleDelegate(string Title);
        public delegate void UpdateBtnConectEnabledDelegate(bool enabled);
        public delegate void UpdateConnectionIconDelegate(Bitmap img);
        public delegate void UpdateStatusMessageDelegate(string message);

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmClient"/> class.
        /// </summary>
        public FrmChat()
        {
            InitializeComponent();
            SubscribeToClientEvents();
        }

        /// <summary>
        /// Subscribes to client events.
        /// </summary>
        private void SubscribeToClientEvents()
        {
            this.client.Connected += client_Connected;
            this.client.DataReceived += client_DataReceived;
            this.client.Disconnected += client_Disconnected;
            this.client.errEncounter += client_errEncounter;
        }

        /// <summary>
        /// Shows Client Errors to EU
        /// </summary>
        /// <param name="ex">The ex.</param>
        void client_errEncounter(Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message);
        }

        void client_Disconnected()
        {
           UpdateBtnConectEnabled(true);
           UpdateConnectionIcon(ChatClient.Properties.Resources.red_x_icon);
        }

        void client_DataReceived(byte[] Data, string ID)
        {
            // ERROR:Login Details Not Recognized
            string message = ConvertBytesToString(Data);
            if (this.message.StartsWith("ERROR:"))
            {
                MessageBox.Show(this.message.Replace("ERROR:", ""));
            }
            else if (message.StartsWith("ID"))   // New Client ID
            {
                // Temporarily ignore these events
                this.client.Connected -= client_Connected;
                this.client.Disconnected -= client_Disconnected;
                this.cID = message.Split(':')[1].ToString();
                UpdateFormTitle("Client: " + cID);
                SendCloseMessage();
                this.client.Disconnect();
                this.client.Connect("127.0.0.1", 3000, cID);

                // Start Listening for these events again
                this.client.Connected += client_Connected;
                this.client.Disconnected += client_Disconnected;
            }
        }

        /// <summary>
        /// Updates the Title of the Client
        /// </summary>
        /// <param name="p">
        /// String: The new Title of the Form
        /// </param>
        private void UpdateFormTitle(string p)
        {
            if (this.InvokeRequired)
            {
                UpdateFormTitleDelegate d = new UpdateFormTitleDelegate(UpdateFormTitle);
                this.Invoke(d, new object[] { p });
            }
            else
            {
                this.Text = p;

            }
        }

        /// <summary>
        /// Now we are connected we should log in.
        /// </summary>
        void client_Connected()
        {
            if (this.username == null) // We haven't logged on this session
            {
                Login();
            }
            else
            {
                ReLogin();
            }
        }

        private void ReLogin()
        {
            this.message = "RELOGIN:" + username + ":" + password; // Send the Login Details
            this.client.SendData(ConvertStringToBytes(message), ForServer);
            UpdateConnectionIcon(ChatClient.Properties.Resources.green_tick);
            UpdateBtnConectEnabled(false);
            UpdateStatusMessage("Connected");
          
        }

        private void UpdateStatusMessage(string p)
        {
            if (statusStrip1.InvokeRequired)
            {
                UpdateStatusMessageDelegate d = new UpdateStatusMessageDelegate(UpdateStatusMessage);
                statusStrip1.Invoke(d, new object[] { p });
            }
            else
            {
                lblStatus.Text = p;

            }
           
        }

        /// <summary>
        /// Log the EU in
        /// </summary>
        private void Login()
        {
            FrmLogin login = new FrmLogin();
            DialogResult dr = new DialogResult();
            dr = login.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {

                //  LOGIN:<USERNAME>:<PASSWORD>
                this.message = "LOGIN:" + login.EmailAddress + ":" + login.Password; // Send the Login Details
                this.username = login.EmailAddress;
                this.password = login.Password;
                this.client.SendData(ConvertStringToBytes(message), ForServer);
                lblStatus.Text = "Loging In";
            }
            else if (login.IsRegistered)
            {
                //  REGISTRATION:<USERNAME>:<PASSWORD>
                this.message = "REGISTRATION:" + login.EmailAddress + ":" + login.Password; // Send the Registration Details
                this.username = login.EmailAddress;
                this.password = login.Password;
                this.client.SendData(ConvertStringToBytes(message), ForServer);
                lblStatus.Text = "Registering";
            }
            else
            {
                SendCloseMessage(); // Must have canceled the login
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            this.client.Connect("127.0.0.1", 3000, cID.ToString());
            UpdateConnectionIcon( ChatClient.Properties.Resources.green_tick);
            UpdateBtnConectEnabled(false);
           UpdateStatusMessage("Connected");
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

        private void FrmClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            SendCloseMessage();
        }

        /// <summary>
        /// Tell the Server we are closing
        /// </summary>
        private void SendCloseMessage()
        {
            UpdateBtnConectEnabled(true);
            UpdateConnectionIcon(ChatClient.Properties.Resources.red_x_icon);
           
            this.client.SendData(ConvertStringToBytes("CLOSING"), ForServer);
        }

        private void UpdateConnectionIcon(Bitmap bitmap)
        {
            if (statusStrip1.InvokeRequired)
            {
                UpdateConnectionIconDelegate d = new UpdateConnectionIconDelegate(UpdateConnectionIcon);
                statusStrip1.Invoke(d, new object[] { bitmap });
            }
            else
            {
                this.lblConnectionStatus.Image = bitmap;

            }
        }

        private void UpdateBtnConectEnabled(bool p)
        {
         
             if (toolStrip1.InvokeRequired)
            {
                UpdateBtnConectEnabledDelegate d = new UpdateBtnConectEnabledDelegate(UpdateBtnConectEnabled);
                toolStrip1.Invoke(d, new object[] { p });
            }
            else
            {
                btnConnect.Enabled = p;

            }
        }

        /// <summary>
        /// If the Icon in the bottom right of the Chat client is Green - and double clicked
        /// close the connection... Will be improved later.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblConnectionStatus_DoubleClick(object sender, EventArgs e)
        {
            if(lblConnectionStatus.Image == ChatClient.Properties.Resources.green_tick)
            {
                UpdateBtnConectEnabled(true);
                UpdateConnectionIcon(ChatClient.Properties.Resources.red_x_icon);
                this.client.SendData(ConvertStringToBytes("CLOSING"), ForServer);
               UpdateStatusMessage("Connection Lost");
            }
        }

        /// <summary>
        /// Let the EU Add a Friend
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddFriend_Click(object sender, EventArgs e)
        {

        }
    }
}
