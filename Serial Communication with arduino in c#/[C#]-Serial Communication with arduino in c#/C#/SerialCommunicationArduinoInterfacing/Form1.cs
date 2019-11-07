using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;


namespace SerialCommunicationArduinoInterfacing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string portNum = "";
            string port="";
            serialPort1.Close();
            foreach (string ports in SerialPort.GetPortNames())
            {
                portNum = ports.ToString();
                textBox1.Text = portNum;
                port = textBox1.Text;
            }
            try
            {
                serialPort1.PortName = (port);
                serialPort1.BaudRate = 9600;
                serialPort1.DataBits = 8;
                serialPort1.Parity = Parity.None;
                serialPort1.StopBits = StopBits.One;
                serialPort1.Handshake = Handshake.None;
                serialPort1.Encoding = System.Text.Encoding.Default;
            }
            catch
            {
                label2.Text = "port not avaiable !";
            }
        }

        private void btnOn_Click(object sender, EventArgs e)
        {
            serialPort1.Open();
            serialPort1.Write("1");
            serialPort1.Close();
        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            serialPort1.Open();
            serialPort1.Write("0");
            serialPort1.Close();
        }
    }
}
