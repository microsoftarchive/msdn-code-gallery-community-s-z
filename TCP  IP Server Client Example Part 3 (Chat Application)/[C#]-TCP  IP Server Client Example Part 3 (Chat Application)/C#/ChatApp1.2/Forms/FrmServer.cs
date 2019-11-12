using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NetComm;

namespace ChatApp1._2.Forms
{
    public partial class FrmServer : Form
    {
        private NetComm.Host server = new Host(3333); // Listens on port 3330.
        private int activeConnections = 0;
        private delegate void DisplayInformationDelegate(string s);
        private Dictionary<string, string> registeredUsers = new Dictionary<string, string>();
        private Dictionary<string, string> loggedInUsers = new Dictionary<string, string>();


        public FrmServer()
        {
            InitializeComponent();
            server.ConnectionClosed += Server_ConnectionClosed;
            server.DataReceived += Server_DataReceived;
            server.DataTransferred += Server_DataTransferred;
            server.errEncounter += ServerErrEncounter;
            server.lostConnection += ServerLostConnection;
            server.onConnection += ServerOnConnection;

        }

        private void ServerOnConnection(string id)
        {
            lblConnections.Text = loggedInUsers.Count.ToString();
            DisplayInformation(String.Format("Client {0} Connected", id));
        }

        private void ServerLostConnection(string id)
        {
            lblConnections.Text = loggedInUsers.Count.ToString();
            DisplayInformation(String.Format("Client {0} Lost Connection", id));
        }

        private void ServerErrEncounter(Exception ex)
        {
            DisplayInformation("Server Error " + ex.Message);
        }

        private void Server_DataTransferred(string sender, string recipient, byte[] data)
        {

        }

        private void Server_DataReceived(string iD, byte[] data)
        {
            string message = ConvertBytesToString(data);
            if (iD == "0")
            {
                DisplayInformation("Received Command From Client " + iD + " for this Server");


                if (message.StartsWith("CLOSING"))
                {
                    loggedInUsers.Remove(iD);
                    lblConnections.Text = loggedInUsers.Count.ToString();
                    DisplayInformation("Client " + iD + " is Closing");
                }
                else if (message.StartsWith("REGISTRATION"))
                {
                    // Message = REGISTRATION:<USERNAME>:<PASSWORD>
                    if (registeredUsers.ContainsKey(message.Split(':')[1].ToString()))
                    {
                        server.SendData(iD, ConvertStringToBytes("ERROR:That email is already registered."));
                        DisplayInformation("Client " + iD +  "ERROR:That email is already registered.");
                    }
                    else
                    {
                        registeredUsers.Add(message.Split(':')[1].ToString(), message.Split(':')[2].ToString());
                        loggedInUsers.Add(iD, DateTime.Now.ToString());
                        lblConnections.Text = loggedInUsers.Count.ToString();
                        server.SendData(iD, ConvertStringToBytes("SUCCESS"));
                        DisplayInformation("Client " + iD + "SUCCESS registered.");
                    }
                }
                else if (message.StartsWith("LOGIN"))
                {
                    // Message = LOGIN:<USERNAME>:<PASSWORD>
                    if (registeredUsers.ContainsKey(message.Split(':')[1].ToString()))
                    {
                        string res = "";
                        if (registeredUsers.TryGetValue(iD, out res))
                        {
                            // Successfully logged in
                            int newSenderId = (loggedInUsers.Count + 1);
                            server.SendData(iD, ConvertStringToBytes("ID:" + newSenderId.ToString()));
                            loggedInUsers.Add(newSenderId.ToString(), DateTime.Now.ToString());
                            lblConnections.Text = loggedInUsers.Count.ToString();
                            DisplayInformation("Client " + iD + "SUCCESS Logged in.");
                        }
                    }
                    else
                    {
                        server.SendData(iD, ConvertStringToBytes("ERROR:Login Details Not Recognized"));
                        DisplayInformation("Client " + iD + "ERROR:Login Details Not Recognized");
                    }
                }
                else
                {
                    DisplayInformation("Received Command From Client " + iD + " for this Server: " + message);
                }


            }
            else
            {
                DisplayInformation("Received Command From Client " + iD + " for this Server: " + message);
            }
        }

        private void Server_ConnectionClosed()
        {
            DisplayInformation("Connection Was Closed");
        }

        private void NewToolStripMenuItemClick(object sender, EventArgs e)
        {
            server.StartConnection();
            lblConnectionStatusImage.Image = Properties.Resources.green_circle_md;
        }

        void DisplayInformation(string s)
        {
            if (this.rtbConOut.InvokeRequired)
            {
                DisplayInformationDelegate d = new DisplayInformationDelegate(DisplayInformation);
                this.rtbConOut.Invoke(d, new object[] { s });
            }
            else
            {
                this.rtbConOut.AppendText(Environment.NewLine + s);
                this.rtbConOut.Focus();
            }
        }

        string ConvertBytesToString(byte[] bytes)
        {
            return ASCIIEncoding.ASCII.GetString(bytes);
        }

        byte[] ConvertStringToBytes(string str)
        {
            return ASCIIEncoding.ASCII.GetBytes(str);
        }

        private void OpenToolStripMenuItemClick(object sender, EventArgs e)
        {
            server.CloseConnection();
            lblConnectionStatusImage.Image = Properties.Resources.red_47690_640;
        }

        private void BtnNewClient_Click(object sender, EventArgs e)
        {
            FrmChatMain chat = new FrmChatMain();
            chat.Show();
        }
    }
}
