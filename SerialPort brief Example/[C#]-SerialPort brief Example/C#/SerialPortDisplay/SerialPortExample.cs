namespace SerialPortExample
{
    using System;
    using System.IO.Ports;
    using System.Text;

    public delegate void dataReceived(object sender, SerialPortEventArgs arg);
    public class SerialPortEventArgs : EventArgs
    {
        public string ReceivedData { get; private set; }
        public SerialPortEventArgs(string data)
        {
            ReceivedData = data;
        }
    }
    /// <summary>
    /// Interfaces with a serial port. There should only be one instance
    /// of this class for each serial port to be used.
    /// </summary>
    public class SerialPortInterface
    {
        public event dataReceived DataReceived;
        /// <summary>
        /// Serial port class
        /// </summary>
        private SerialPort serialPort = new SerialPort();

        /// <summary>
        /// BaudRate set to default for Serial Port Class
        /// </summary>
        private int baudRate = 9600;

        /// <summary>
        /// DataBits set to default for Serial Port Class
        /// </summary>
        private int dataBits = 8;

        /// <summary>
        /// Handshake set to default for Serial Port Class
        /// </summary>
        private Handshake handshake = Handshake.None;

        /// <summary>
        /// Parity set to default for Serial Port Class
        /// </summary>
        private Parity parity = Parity.None;

        /// <summary>
        /// Communication Port name, not default in SerialPort. Defaulted to COM1
        /// </summary>
        private string portName = "COM1";

        /// <summary>
        /// StopBits set to default for Serial Port Class
        /// </summary>
        private StopBits stopBits = StopBits.One;

        /// <summary>
        /// Holds data received until we get a terminator.
        /// </summary>
        private string tString = string.Empty;

        /// <summary>
        /// End of transmition byte in this case EOT (ASCII 4).
        /// </summary>
        private byte terminator = 0x4;

        /// <summary>
        /// Gets or sets BaudRate (Default: 9600)
        /// </summary>
        public int BaudRate { get { return this.baudRate; } set { this.baudRate = value; } }

        /// <summary>
        /// Gets or sets DataBits (Default: 8)
        /// </summary>
        public int DataBits { get { return this.dataBits; } set { this.dataBits = value; } }

        /// <summary>
        /// Gets or sets Handshake (Default: None)
        /// </summary>
        public Handshake Handshake { get { return this.handshake; } set { this.handshake = value; } }

        /// <summary>
        /// Gets or sets Parity (Default: None)
        /// </summary>
        public Parity Parity { get { return this.parity; } set { this.parity = value; } }

        /// <summary>
        /// Gets or sets PortName (Default: COM1)
        /// </summary>
        public string PortName { get { return this.portName; } set { this.portName = value; } }

        /// <summary>
        /// Gets or sets StopBits (Default: One}
        /// </summary>
        public StopBits StopBits { get { return this.stopBits; } set { this.stopBits = value; } }
        /// <summary>
        /// Sets the current settings for the Comport and tries to open it.
        /// </summary>
        /// <returns>True if successful, false otherwise</returns>
        public bool Open()
        {
            try
            {
                this.serialPort.BaudRate = this.baudRate;
                this.serialPort.DataBits = this.dataBits;
                this.serialPort.Handshake = this.handshake;
                this.serialPort.Parity = this.parity;
                this.serialPort.PortName = this.portName;
                this.serialPort.StopBits = this.stopBits;
                this.serialPort.DataReceived += new SerialDataReceivedEventHandler(this._serialPort_DataReceived);

            }
            catch
            {
                return false;
            }
            try { serialPort.DtrEnable = true; }
            catch { }
            try { serialPort.RtsEnable = true; }
            catch { }

            return true;
        }
        public bool Send(byte[] data)
        {
            try
            {
                serialPort.Write(data, 0, data.Length);
            }
            catch { return false; }
            return true;
        }
        public bool Send(string data)
        {
            try
            {
                serialPort.Write(data);
            }
            catch { return false; }
            return true;
        }
        /// <summary>
        /// Handles DataReceived Event from SerialPort
        /// </summary>
        /// <param name="sender">Serial Port</param>
        /// <param name="e">Event arguments</param>
        private void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // Initialize a buffer to hold the received data
            byte[] buffer = new byte[this.serialPort.ReadBufferSize];

            // There is no accurate method for checking how many bytes are read
            // unless you check the return from the Read method
            int bytesRead = this.serialPort.Read(buffer, 0, buffer.Length);

            // For the example assume the data we are received is ASCII data.
            this.tString += Encoding.ASCII.GetString(buffer, 0, bytesRead);

            // Check if string contains the terminator 
            if (this.tString.IndexOf((char)this.terminator) > -1)
            {
                // If tString does contain terminator we cannot assume that it is the last character received
                string workingString = this.tString.Substring(0, this.tString.IndexOf((char)this.terminator));

                // Remove the data up to the terminator from tString
                this.tString = this.tString.Substring(this.tString.IndexOf((char)this.terminator));

                // Do something with workingString
                if (this.DataReceived != null)
                {
                    SerialPortEventArgs args = new SerialPortEventArgs(workingString);
                    this.DataReceived(this, args);
                }
            }
        }

        public void Close()
        {
            serialPort.DataReceived -= _serialPort_DataReceived;
            serialPort.Close();
        }
    }
}