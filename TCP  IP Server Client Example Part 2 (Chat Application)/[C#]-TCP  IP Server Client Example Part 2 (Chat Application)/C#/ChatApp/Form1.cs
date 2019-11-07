using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ChatApp.Forms;

using NetComm;

namespace ChatApp
{
    public partial class Form1 : Form
    {
        private NetComm.Host server = new Host(3330); // Listens on port 3330.
        private int activeConnections = 0;
        private delegate void DisplayInformationDelegate(string s);
        private ArrayList clientList = new ArrayList(); // Share amongst all instances of the Clients

        public Form1()
        {
            InitializeComponent();
            server.ConnectionClosed += Server_ConnectionClosed;
            server.DataReceived += Server_DataReceived;
            server.DataTransferred += Server_DataTransferred;
            server.errEncounter += ServerErrEncounter;
            server.lostConnection += ServerLostConnection;
            server.onConnection += ServerOnConnection;
            server.StartConnection();
            rtbConOut.AppendText(Environment.NewLine);
        }

        void ServerOnConnection(string id)
        {
            activeConnections++;
            lblConnections.Text = activeConnections.ToString();
            DisplayInformation(String.Format("Client {0} Connected", id));
            clientList.Add(id);
            SendClientList();
        }
  
        private void SendClientList()
        {
            DisplayInformation("Sending All Clients a list of currently available clients"); // This is not how we would normally do this
            foreach (string cid in clientList)
            {
                foreach (string cid2 in clientList)
                {
                    byte[] d = ConvertStringToBytes("CList::" + cid);
                    server.SendData(cid2, d);
                }
            }
        }

        void ServerLostConnection(string id)
        {
            activeConnections--;
            lblConnections.Text = activeConnections.ToString();
            DisplayInformation(String.Format("Client {0} Lost Connection", id));
            clientList.Remove(id);
        }

        void ServerErrEncounter(Exception ex)
        {
            DisplayInformation("Server Error " + ex.Message);
        }

        void Server_DataTransferred(string sender, string recipient, byte[] data)
        {
            string senderId = (string)sender;
            if (recipient == "0")
            {
                DisplayInformation("Received Command From Client " + senderId + " for this Server");
                switch (ConvertBytesToString(data))
                {
                    case "CLOSING":
                        activeConnections--;
                        lblConnections.Text = activeConnections.ToString();
                        DisplayInformation("Client " + senderId + " is Closing");
                        clientList.Remove(senderId);
                        SendClientList();
                        break;
                   
                    default:
                        foreach (string id in clientList)
                        {
                            if (id != senderId) // Don't send this message to the client that sent the message in the first place
                            {
                                server.SendData(id, data);
                            }
                        }
                        break;
                }
            }
            else
            {
                DisplayInformation("Received Command From Client " + senderId + " for Client " + recipient);
            }
        }

        void Server_DataReceived(string iD, byte[] data)
        {
            if (ConvertBytesToString(data) == "CLOSING")
            {
                DisplayInformation("Client " + iD + " has closed");
            }
        }

        void Server_ConnectionClosed()
        {
            DisplayInformation("Connection Was Closed");
        }

        private void BtnNewClient_Click(object sender, EventArgs e)
        {
            FrmClient client = new FrmClient();
            client.Name = (activeConnections + 1).ToString();
            client.Show();
        }

        string ConvertBytesToString(byte[] bytes)
        {
            return ASCIIEncoding.ASCII.GetString(bytes);
        }

        byte[] ConvertStringToBytes(string str)
        {
            return ASCIIEncoding.ASCII.GetBytes(str);
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
                this.rtbConOut.AppendText(s + Environment.NewLine);
            }
        }
    }
}
