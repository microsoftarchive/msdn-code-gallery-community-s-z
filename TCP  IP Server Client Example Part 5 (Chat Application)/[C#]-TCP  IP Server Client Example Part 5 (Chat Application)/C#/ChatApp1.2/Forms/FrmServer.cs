using System;
using System.Collections.Generic;
using System.IO;
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

        private delegate void DisplayConnectionsDelegate(string s);

        private Dictionary<string, string> registeredUsers = new Dictionary<string, string>();
        private Dictionary<string, string> loggedInUsers = new Dictionary<string, string>();

        string startupPath = Application.StartupPath.ToString();

        public FrmServer()
        {
            InitializeComponent();
            startupPath = Path.Combine(startupPath, "users.db");
            LoadRegisteredUsers(); // for very large FlatFile databases this should be done on a separate thread. But really you should use a Database
            server.ConnectionClosed += Server_ConnectionClosed;
            server.DataReceived += Server_DataReceived;
            server.DataTransferred += Server_DataTransferred;
            server.errEncounter += ServerErrEncounter;
            server.lostConnection += ServerLostConnection;
            server.onConnection += ServerOnConnection;
            this.FormClosing += FrmServer_FormClosing;
        }

        void FrmServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveRegisteredUsers();
        }

        private void SaveRegisteredUsers()
        {
            // Not the best way to save the users.
            FileStream fs = null;
            StreamWriter sw = null;
            try
            {
                fs = new FileStream(startupPath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Inheritable);
                sw = new StreamWriter(fs);

                sw.WriteLine("# Updated Last on: " + DateTime.UtcNow.ToString());
                foreach (KeyValuePair<string, string> entry in registeredUsers)
                {
                    string line = entry.Key + "," + entry.Value; // longer appendings to string should be done through StringBuilder as it is so much faster!
                    sw.WriteLine(line);
                }

                sw.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("SaveRegisteredUsers: Failed to load registered users" + Environment.NewLine + ex.Message);
                if (sw != null) sw.Close();
                if (fs != null) fs.Close();
            }
        }

        private void LoadRegisteredUsers()
        {
            FileStream fs = null;
            StreamReader sr = null;

            try
            {
                fs = new FileStream(startupPath, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Inheritable);
                sr = new StreamReader(fs);
                while (!sr.EndOfStream) // While there is something to read.
                {
                    string line = sr.ReadLine();
                    if (line.StartsWith("#"))
                    {
                        // Ignore comments for just now
                    }
                    else if (string.IsNullOrWhiteSpace(line))
                    {
                        // ignore blank lines
                    }
                    else
                    {
                        // Process the line.
                        string[] parts = line.Split(','); // separate each value in the line into their respective parts.
                        // Part[0] is always the user's email address
                        // Part[1] is always the password for the user
                        try
                        {
                            registeredUsers.Add(parts[0].ToString(), parts[1].ToString());
                        }
                        catch (Exception ex)
                        {
                            // If we get here the database is probably corrupt!
                            MessageBox.Show("LoadRegisteredUsers: User's Database may be corrupt!" + Environment.NewLine + ex.Message);
                        }
                    }
                }
                sr.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadRegisteredUsers: Failed to load registered users" + Environment.NewLine + ex.Message);
                if (sr != null) sr.Close();
                if (fs != null) fs.Close();
            }
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
                    DisplayConnection(loggedInUsers.Count.ToString());
                    DisplayInformation("Client " + iD + " is Closing");
                }
                else if (message.StartsWith("REGISTRATION"))
                {
                    // Message = REGISTRATION:<USERNAME>:<PASSWORD>
                    if (registeredUsers.ContainsKey(message.Split(':')[1].ToString()))
                    {
                        server.SendData(iD, ConvertStringToBytes("ERROR:That email is already registered."));
                        DisplayInformation("Client " + iD + "ERROR:That email is already registered.");
                    }
                    else
                    {
                        registeredUsers.Add(message.Split(':')[1].ToString(), message.Split(':')[2].ToString());
                        loggedInUsers.Add(iD, DateTime.Now.ToString());
                        DisplayConnection(loggedInUsers.Count.ToString());
                        server.SendData(iD, ConvertStringToBytes("SUCCESS:Logged On"));
                        DisplayInformation("Client " + iD + "SUCCESS registered.");
                    }
                }
                else if (message.StartsWith("LOGIN"))
                {
                    // Message = LOGIN:<USERNAME>:<PASSWORD>
                    string[] parts = message.Split(':');
                    if (registeredUsers.ContainsKey(parts[1].ToString()))
                    {
                        string res = "";
                        if (registeredUsers.TryGetValue(parts[1].ToString(), out res))
                        {
                            if (res == parts[2])
                            {
                                // Successfully logged in
                                int newSenderId = (loggedInUsers.Count + 1);
                                server.SendData(iD, ConvertStringToBytes("ID:" + newSenderId.ToString()));
                                loggedInUsers.Add(newSenderId.ToString(), DateTime.Now.ToString());
                                DisplayConnection(loggedInUsers.Count.ToString());
                                DisplayInformation("Client " + parts[1].ToString() + " SUCCESS Logged in.");

                                
                            }
                            else
                            {
                                server.SendData(iD, ConvertStringToBytes("ERROR:Login Details Not Recognized"));
                                DisplayInformation("Client " + iD + "ERROR:Login Details Not Recognized");
                            }
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

        void DisplayConnection(string s)
        {
            if (this.toolStrip1.InvokeRequired)
            {
                DisplayConnectionsDelegate d = new DisplayConnectionsDelegate(DisplayConnection);
                this.toolStrip1.Invoke(d, new object[] { s });
            }
            else
            {
                lblConnections.Text = s;
            }

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
