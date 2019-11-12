using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace ClientApp
{
    public partial class Form1 : Form
    {
        private string myMessage = "";
       private TcpClient client = new TcpClient();
        private IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 3000);

        public Form1()
        {
            InitializeComponent();
            client.Connect(serverEndPoint);
            
        }

        private void RtbClientKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter || e.KeyData != Keys.Return)
            {
                myMessage += (char)e.KeyValue;
            }
            else
            {
                SendMessage(myMessage);
                myMessage = "";
            
            }
        }

        private void SendMessage(string msg)
        {
            NetworkStream clientStream = client.GetStream();

            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] buffer = encoder.GetBytes(msg);

            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();

            // Receive the TcpServer.response.

            // Buffer to store the response bytes.
            Byte[]  data = new Byte[256];

            // String to store the response ASCII representation.
            String responseData = String.Empty;

            // Read the first batch of the TcpServer response bytes.
            Int32 bytes = clientStream.Read(data, 0, data.Length);
            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            
            rtbClient.AppendText(Environment.NewLine + "From Server: " + responseData);
        }


    }
}
