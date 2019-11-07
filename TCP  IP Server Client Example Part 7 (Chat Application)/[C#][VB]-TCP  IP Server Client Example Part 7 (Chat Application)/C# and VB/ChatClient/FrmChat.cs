using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatClient.Properties;

namespace ChatClient
{
    public partial class FrmChat : Form
    {
        private NetComm.Client client = new NetComm.Client();
        private string cID = "-1" + Guid.NewGuid().ToString();       // Temporary Client ID - Replaced by Server on Successful Login
        private string message = ""; // The Message We are sending to the Server or our Friends.

        private string username = null;
        private string password = null;

        #region CONSTNANTS
        private const string RegistrationCommand = "REGISTRATION:"; // I want to Register
        private const string ErrorCommand = "ERROR:";   // Eeek there is an Error
        private const string IDCommand = "ID:"; // My Unique ID
        private const string SuccessLoggedOnCommand = "SUCCESS:Logged On";  // Yay! I have logged on
        private const string ClientCommand = "Client: ";    // 
        private const string LoginCommand = "LOGIN:";   // I want to Login please
        private const string ClosingCommand = "CLOSING";    // Bye bye Server
        private const string ForServer = "0";   // The Server's ClientID
        private const string AddFriendCommand = "AddFriend:";   // Messages for the server only
        private const string NoSuchUserCommand = "NoSuchUser:";// The User requested friend does not exist
        private const string FriendAddedCommand = "FriendAdded:";
        private const string GetFriendListCommand = "GetFriendsList:";
        private const string YourLastCommandIsNotImplementedYetCommand = "Your last command is not Implemented Yet"; // The user's friend exists and has been added to their friends list
        #endregion

        #region Threading Delegates

        public delegate void UpdateFormTitleDelegate(string Title);
        public delegate void UpdateBtnConectEnabledDelegate(bool enabled);
        public delegate void UpdateConnectionIconDelegate(Bitmap img);
        public delegate void UpdateStatusMessageStringDelegate(string message);
        public delegate void UpdateToolStripMessageBoolDelegate(bool message);

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmClient"/> class.
        /// </summary>
        public FrmChat()
        {
            InitializeComponent();
            SubscribeToClientEvents();
        }


        #region Client Events

        /// <summary>
        /// Now we are connected we should log in. Or if we are logging in with a valid ID then Relogin
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
            UpdateAddFriendButton(true);
            UpdateStatusMessage(Resources.Connected);
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
            MessageBox.Show(Resources.Error + ex.Message);
        }

        /// <summary>
        /// We have Disconnected 
        /// TODO: Not sure why we disconnected - need to add checks for this later
        /// </summary>
        void client_Disconnected()
        {
            UpdateBtnConectEnabled(true);
            UpdateConnectionIcon(ChatClient.Properties.Resources.red_x_icon);
            UpdateAddFriendButton(false);
        }

        /// <summary>
        /// We have recieved information from either the Server or, a friend!
        /// </summary>
        /// <param name="Data">
        /// Bye[]: The Raw data we have received
        /// </param>
        /// <param name="ID">
        /// String: The ID of the person who sent it to us
        /// </param>
        void client_DataReceived(byte[] Data, string ID)
        {
            // ERROR:Login Details Not Recognized
            string message = ConvertBytesToString(Data);
            if (this.message.StartsWith(ErrorCommand))
            {
                MessageBox.Show(Resources.Error, "");   // ??
            }
            else if (message.StartsWith(IDCommand))   // New Client ID
            {
                RestartWithNewID(message);
            }
            else if (message.StartsWith(SuccessLoggedOnCommand))
            {
                btnAddFriend.Enabled = true;

            }
            else if (message.StartsWith(NoSuchUserCommand))
            {
                MessageBox.Show(Resources.SorryTheEmailAddress + message.Split(':')[1].ToString() + Resources.WasNotFound);
            }
            else if(message.StartsWith(FriendAddedCommand))
            {
                GetFriendsList();
            }
            else if(message.StartsWith(YourLastCommandIsNotImplementedYetCommand))
            {
                MessageBox.Show(message);
            }
        }

        /// <summary>
        /// Asks the server to send my friends list
        /// </summary>
        private void GetFriendsList()
        {
            SendMessage(GetFriendListCommand, ForServer);
        }

        #endregion

        #region Main Form Events

        /// <summary>
        /// Send the Closing command When window is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            SendCloseMessage();

        }

        #endregion

        #region Utilities

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

        /// <summary>
        /// Updates the Title of the Client
        /// </summary>
        /// <param name="NewTitle">
        /// String: The new Title of the Form
        /// </param>
        private void UpdateFormTitle(string NewTitle)
        {
            if (this.InvokeRequired)
            {
                UpdateFormTitleDelegate d = new UpdateFormTitleDelegate(UpdateFormTitle);
                this.Invoke(d, new object[] { NewTitle });
            }
            else
            {
                this.Text = NewTitle;

            }
        }

        #endregion

        #region Send Messages

        /// <summary>
        /// Tell the Server we are closing
        /// </summary>
        private void SendCloseMessage()
        {
            UpdateBtnConectEnabled(true);
            UpdateConnectionIcon(ChatClient.Properties.Resources.red_x_icon);
            SendMessage(ClosingCommand, ForServer);
            UpdateStatusMessage(Resources.ConnectionLost);
        }

        /// <summary>
        /// Send a Message to a named recipient
        /// </summary>
        /// <param name="message">
        /// String: The message to be formatted and sent
        /// </param>
        /// <param name="SendTo">
        /// String: The Recipients ID
        /// </param>
        private void SendMessage(string message, string SendTo)
        {
            this.client.SendData(ConvertStringToBytes(message), SendTo);
        }

        #endregion

        #region Login

        /// <summary>
        /// Tell Server we are Re-Logging in with New ID
        /// </summary>
        private void ReLogin()
        {
            this.message = Resources.RELOGIN + username + ":" + password; // Send the Login Details
            this.client.SendData(ConvertStringToBytes(message), ForServer);
            UpdateConnectionIcon(ChatClient.Properties.Resources.green_tick);
            UpdateBtnConectEnabled(false);
            UpdateStatusMessage(Resources.Connected);
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
                this.message = LoginCommand + login.EmailAddress + ":" + login.Password; // Send the Login Details
                this.username = login.EmailAddress;
                this.password = login.Password;
                SendMessage(message, ForServer);
                lblStatus.Text = Resources.LoggingIn;
            }
            else if (login.IsRegistered)
            {
                //  REGISTRATION:<USERNAME>:<PASSWORD>
                this.message = RegistrationCommand + login.EmailAddress + ":" + login.Password; // Send the Registration Details
                this.username = login.EmailAddress;
                this.password = login.Password;
                SendMessage(message, ForServer);
                lblStatus.Text = Resources.Registering;
            }
            else
            {
                SendCloseMessage(); // Must have canceled the login
            }
        }

        /// <summary>
        /// Reconnects to the Server with our official ID
        /// </summary>
        /// <param name="message">
        /// String: Our New Valid Unique cID
        /// </param>
        private void RestartWithNewID(string message)
        {
            // Temporarily ignore these events
            this.client.Connected -= client_Connected;
            this.client.Disconnected -= client_Disconnected;
            this.cID = message.Split(':')[1].ToString();
            UpdateFormTitle(ClientCommand + cID);
            SendCloseMessage();
            this.client.Disconnect();
            this.client.Connect("127.0.0.1", 3000, cID);

            // Start Listening for these events again
            this.client.Connected += client_Connected;
            this.client.Disconnected += client_Disconnected;

        }

        #endregion

        #region ToolStrip

        /// <summary>
        /// Update the Connection Button's Enable Property
        /// </summary>
        /// <param name="IsEnabled">
        /// Bool: True if the Button is to be enabled
        ///         False if the button is not to be enabled
        /// </param>
        private void UpdateBtnConectEnabled(bool IsEnabled)
        {

            if (toolStrip1.InvokeRequired)
            {
                UpdateBtnConectEnabledDelegate d = new UpdateBtnConectEnabledDelegate(UpdateBtnConectEnabled);
                toolStrip1.Invoke(d, new object[] { IsEnabled });
            }
            else
            {
                btnConnect.Enabled = IsEnabled;
            }
        }

        /// <summary>
        /// Let the EU Add a Friend
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddFriend_Click(object sender, EventArgs e)
        {
            UpdateAddFriendButton(false);
            FrmAddFriend AddFriend = new FrmAddFriend();
            AddFriend.MyEmailAddress = username;
            DialogResult dr = AddFriend.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                SendMessage(AddFriendCommand + AddFriend.FriendsEmailAddress,ForServer);
            }
            UpdateAddFriendButton(true);
        }

        /// <summary>
        /// Connect to the Chat Server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            this.client.Connect("127.0.0.1", 3000, cID.ToString());
            UpdateConnectionIcon(ChatClient.Properties.Resources.green_tick);
            UpdateBtnConectEnabled(false);
            UpdateStatusMessage(Resources.Connected);
        }

        /// <summary>
        /// Update the AddFriend Button to a new Enabled State
        /// </summary>
        /// <param name="IsEnabled">
        /// Bool: True enabled the button
        ///         False Disables the button
        /// </param>
        private void UpdateAddFriendButton(bool IsEnabled)
        {
            if (statusStrip1.InvokeRequired)
            {
                UpdateToolStripMessageBoolDelegate d = new UpdateToolStripMessageBoolDelegate(UpdateAddFriendButton);
                statusStrip1.Invoke(d, new object[] { IsEnabled });
            }
            else
            {
                btnAddFriend.Enabled = IsEnabled;
            }
        }

        #endregion

        #region StatusStrip

        /// <summary>
        /// If the Icon in the bottom right of the Chat client is Green - and double clicked
        /// close the connection... Will be improved later.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblConnectionStatus_DoubleClick(object sender, EventArgs e)
        {
            if (lblConnectionStatus.Image == ChatClient.Properties.Resources.green_tick)
            {
                SendCloseMessage();
            }
        }

        /// <summary>
        /// Change the Connection Icon
        /// </summary>
        /// <param name="bitmap">
        /// Bitmap: The New Icon to display located in the Resources File
        /// </param>
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

        /// <summary>
        /// Update the EU's Status Message
        /// </summary>
        /// <param name="Message">
        /// String: The status message to show the user
        /// </param>
        private void UpdateStatusMessage(string Message)
        {
            if (statusStrip1.InvokeRequired)
            {
                UpdateStatusMessageStringDelegate d = new UpdateStatusMessageStringDelegate(UpdateStatusMessage);
                statusStrip1.Invoke(d, new object[] { Message });
            }
            else
            {
                lblStatus.Text = Message;

            }

        }

        #endregion
    }
}
