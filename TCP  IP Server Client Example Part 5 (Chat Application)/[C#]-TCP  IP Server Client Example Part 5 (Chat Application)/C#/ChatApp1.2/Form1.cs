using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ChatApp1._2.Forms;
using NetComm;

namespace ChatApp1._2
{
    public partial class FrmChatMain : Form
    {
        private NetComm.Client client = new Client();
        private int cID = 0;
        private string message = "";

        public FrmChatMain()
        {
            InitializeComponent();
            client.Connected += ClientConnected;
            client.DataReceived += ClientDataReceived;
            client.Disconnected += ClientDisconnected;
            client.errEncounter += ClientErrEncounter;
           }

        void ClientErrEncounter(Exception ex)
        {
            throw new NotImplementedException();
        }

        void ClientDisconnected()
        {
            lblOnlineStatusImage.Image = Properties.Resources.red_47690_640;
         }

        void ClientDataReceived(byte[] data, string iD)
        {
            string message = ConvertBytesToString(data);

            if (iD == null) // Message from the server
            {
                if (message == "ERROR:That email is already registered.")
                {
                    MessageBox.Show(message);
                }
                else if (message == "ERROR:Login Details Not Recognized")
                {
                    MessageBox.Show(message);
                }
                else if (message == "SUCCESS:Logged On")
                {
                    // SendFriendsList();
                    // GetMyID();
                    // 
                }
            }
            else
            {
                // Message from a friend
            }
        }

        void ClientConnected()
        {
            lblOnlineStatusImage.Image = Properties.Resources.green_circle_md;
         
            //  LOGIN:<USERNAME>:<PASSWORD>
            client.SendData(ConvertStringToBytes(message));
        }

        // Connect to the Service
        private void BtnConnectClick(object sender, EventArgs e)
        {
            Connect();
        }

        private void MenuConnectClick(object sender, EventArgs e)
        {
            Connect();
        }

        private void Connect()
        {
            FrmLogin login = new FrmLogin();
            DialogResult dr = new DialogResult();
            dr = login.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                client.Connect("127.0.0.1", 3333, cID.ToString());
                //  LOGIN:<USERNAME>:<PASSWORD>
                message = "LOGIN:" + login.EmailAddress + ":" + login.Password;
               
            }
            else if (login.IsRegistered)
            {
                client.Connect("127.0.0.1", 3333, cID.ToString());
                //  REGISTRATION:<USERNAME>:<PASSWORD>
                message = "REGISTRATION:" + login.EmailAddress + ":" + login.Password;
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


    }
}
