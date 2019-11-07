using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using NetComm;

namespace ChatApp.Forms
{
    public partial class FrmClient : Form
    {
        public string Name { get; set; } // What will we call this Client?
        private NetComm.Client client = new Client();
        private ArrayList clientList = new ArrayList();


        public FrmClient()
        {
            InitializeComponent();
            
        }

        private void FrmClient_Load(object sender, EventArgs e)
        {
            client.Connected += ClientConnected;
            client.DataReceived += ClientDataReceived;
            client.Disconnected += ClientDisconnected;
            client.errEncounter += ClientErrEncounter;
            client.Connect("127.0.0.1", 3330, Name); // Port needs to match the Server's port as does the IP Address.
            this.Text = Name;
        }

        void ClientErrEncounter(Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message);
        }

        void ClientDisconnected()
        {
            MessageBox.Show("You have been Disconnected");
        }

        void ClientDataReceived(byte[] data, string iD)
        {
            //CList::
            string msg = ConvertBytesToString(data);
            if (msg.StartsWith("CList::"))
            {
                string msgs = msg.Replace("CList::","");
                rtbConOut.AppendText("Clients online Now are " + msgs + Environment.NewLine);
            }
            else
            {
                rtbConOut.AppendText(msg  + Environment.NewLine);
            }
        }

        void ClientConnected()
        {
            rtbConOut.AppendText("Connected " + Environment.NewLine);
        }

        string ConvertBytesToString(byte[] bytes)
        {
            return ASCIIEncoding.ASCII.GetString(bytes);
        }

        byte[] ConvertStringToBytes(string str)
        {
            return ASCIIEncoding.ASCII.GetBytes(str);
        }

        private void FrmClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            client.SendData(ConvertStringToBytes("CLOSING"), "0");
            client.Disconnect();
        }

        private void TbInputKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Return) // If the user has pressed the enter key
            {
                if (tbInput.Text.Length > 0) // If there is something to send
                {
                    client.SendData(ConvertStringToBytes(tbInput.Text), "0");
                    rtbConOut.AppendText(tbInput.Text + Environment.NewLine);
                    tbInput.Text = "";
                }
            }
        }

        private void BtnSendClick(object sender, EventArgs e)
        {
            if (tbInput.Text.Length > 0) // If there is something to send
            {
                client.SendData(ConvertStringToBytes(tbInput.Text), "0");
                rtbConOut.AppendText(tbInput.Text + Environment.NewLine);
                tbInput.Text = "";
            }
        }
    }
}
