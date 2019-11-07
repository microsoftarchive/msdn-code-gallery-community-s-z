using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace SerialPortExample
{
    public partial class Form1 : Form
    {
        SerialPortInterface _workingObject = new SerialPortInterface();
        public Form1()
        {
            InitializeComponent();
            serialPortSettingsControl1.WorkingObject = _workingObject;
            _workingObject.DataReceived += new dataReceived(_workingObject_DataReceived);


        }

        void _workingObject_DataReceived(object sender, SerialPortEventArgs arg)
        {
            this.ReceivedText.Text += arg.ReceivedData;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            _workingObject.Send(this.SendText.Text);
        }
        //Open Button
        private void button1_Click(object sender, EventArgs e)
        {
            if (_workingObject.Open())
                MessageBox.Show("Port Opened Successfuly");
            else MessageBox.Show("Port could not be opened");
        }
        //Close button
        private void button2_Click(object sender, EventArgs e)
        {
            _workingObject.Close();
        }

       
    }
}
