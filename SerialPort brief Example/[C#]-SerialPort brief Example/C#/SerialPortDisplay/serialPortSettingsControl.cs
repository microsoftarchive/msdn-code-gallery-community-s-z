using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SerialPortExample;
using System.IO.Ports;

namespace SerialPortSample
{
    public partial class serialPortSettingsControl : UserControl
    {
        private SerialPortInterface _workingObject = null;

        public SerialPortInterface WorkingObject { get { return _workingObject; } set { _workingObject = value; PopulateControl(); } }

        private void PopulateControl()
        {
            if (_workingObject == null) return;
            comPortComboBox1.SelectedText = _workingObject.PortName;
            baudRateUpDown2.Value = _workingObject.BaudRate;
            dataBits1.Value = _workingObject.DataBits;
            handShakeComboBox1.SelectedItem = _workingObject.Handshake;
            stopBitsComboBox1.SelectedItem = _workingObject.StopBits;
        }
        private void Save()
        {
            _workingObject.PortName = comPortComboBox1.SelectedText;
            _workingObject.BaudRate = (int)baudRateUpDown2.Value ;
            _workingObject.DataBits =  (int)  dataBits1.Value;
            _workingObject.Handshake = (Handshake) handShakeComboBox1.SelectedItem;
            _workingObject.StopBits = (StopBits)stopBitsComboBox1.SelectedItem;
        }
        public serialPortSettingsControl()
        {
            InitializeComponent();
        }
    }
}
