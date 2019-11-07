using System.IO.Ports;
using System.Threading;
using System.Collections;

namespace uPLibrary.Hardware.Nfc
{
    /// <summary>
    /// HSU communication layer
    /// </summary>
    public class PN532CommunicationHSU : IPN532CommunicationLayer
    {
        // default timeout to wait PN532
        private const int WAIT_TIMEOUT = 500;

        #region HSU Constants ...

        private const int HSU_BAUD_RATE = 115200;
        private const Parity HSU_PARITY = Parity.None;
        private const int HSU_DATA_BITS = 8;
        private const StopBits HSU_STOP_BITS = StopBits.One;

        #endregion

        // hsu interface
        private SerialPort port;
        // event on received frame
        private AutoResetEvent received;

        // frame parser state
        private HsuParserState state;
        private bool isFirstStartCode;
        private bool isWaitingAck;
        // frame buffer
        private IList frame;
        private int length;
        // internal buffer from serial port
        private IList inputBuffer;

        // frames queue received
        private Queue queueFrame;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="portName">Serial port name</param>
        public PN532CommunicationHSU(string portName)
        {
            this.length = 0;
            this.isFirstStartCode = false;
            this.isWaitingAck = false;

            this.frame = new ArrayList();
            this.inputBuffer = new ArrayList();
            this.queueFrame = new Queue();
            
            this.state = HsuParserState.Preamble;
            this.received = new AutoResetEvent(false);

            // create and open serial port
            this.port = new SerialPort(portName, HSU_BAUD_RATE, HSU_PARITY, HSU_DATA_BITS, HSU_STOP_BITS);
            this.port.DataReceived += port_DataReceived;
            this.port.Open();
        }

        void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            lock (this.inputBuffer)
            {
                // read bytes from serial port and load them in the internal buffer
                byte[] buffer = new byte[this.port.BytesToRead];
                this.port.Read(buffer, 0, buffer.Length);

                for (int i = 0; i < buffer.Length; i++)
                    this.inputBuffer.Add(buffer[i]);
            }

            // frame parsing
            this.ExtractFrame();
        }

        void ExtractFrame()
        {
            lock (this.inputBuffer)
            {
                foreach (byte byteRx in this.inputBuffer)
                {
                    switch (this.state)
                    {
                        case HsuParserState.Preamble:

                            // preamble arrived, frame started
                            if (byteRx == PN532.PN532_PREAMBLE)
                            {
                                this.length = 0;
                                this.isFirstStartCode = false;
                                this.frame.Clear();

                                this.frame.Add(byteRx);
                                this.state = HsuParserState.StartCode;
                            }
                            break;

                        case HsuParserState.StartCode:

                            // first start code byte not received yet
                            if (!this.isFirstStartCode)
                            {
                                if (byteRx == PN532.PN532_STARTCODE_1)
                                {
                                    this.frame.Add(byteRx);
                                    this.isFirstStartCode = true;
                                }
                            }
                            // first start code byte already received
                            else
                            {
                                if (byteRx == PN532.PN532_STARTCODE_2)
                                {
                                    this.frame.Add(byteRx);
                                    this.state = HsuParserState.Length;
                                }
                            }
                            break;

                        case HsuParserState.Length:

                            // not waiting ack, the byte is LEN
                            if (!this.isWaitingAck)
                            {
                                // save data length (TFI + PD0...PDn) for counting received data
                                this.length = byteRx;
                                this.frame.Add(byteRx);
                                this.state = HsuParserState.LengthChecksum;
                            }
                            // waiting ack, the byte is first of ack/nack code
                            else
                            {
                                this.frame.Add(byteRx);
                                this.state = HsuParserState.AckCode;
                            }
                            break;

                        case HsuParserState.LengthChecksum:

                            // arrived LCS
                            this.frame.Add(byteRx);
                            this.state = HsuParserState.FrameIdentifierAndData;
                            break;

                        case HsuParserState.FrameIdentifierAndData:

                            this.frame.Add(byteRx);
                            // count received data bytes (TFI + PD0...PDn)
                            this.length--;

                            // all data bytes received
                            if (this.length == 0)
                                this.state = HsuParserState.DataChecksum;
                            break;

                        case HsuParserState.DataChecksum:

                            // arrived DCS
                            this.frame.Add(byteRx);
                            this.state = HsuParserState.Postamble;
                            break;

                        case HsuParserState.Postamble:

                            // postamble received, frame end
                            if (byteRx == PN532.PN532_POSTAMBLE)
                            {
                                this.frame.Add(byteRx);
                                this.state = HsuParserState.Preamble;

                                // enqueue received frame
                                byte[] frameReceived = new byte[this.frame.Count];
                                this.frame.CopyTo(frameReceived, 0);
                                this.queueFrame.Enqueue(frameReceived);

                                this.received.Set();
                            }
                            break;

                        case HsuParserState.AckCode:

                            // second byte of ack/nack code
                            this.frame.Add(byteRx);
                            this.state = HsuParserState.Postamble;
                            
                            this.isWaitingAck = false;
                            break;

                        default:
                            break;
                    }
                }

                // clear internal buffer
                this.inputBuffer.Clear();
            }
        }

        #region IPN532CommunicationLayer interface ...

        public bool SendNormalFrame(byte[] frame)
        {
            //this.frame.Clear();
            this.isWaitingAck = true;
            // send frame...
            this.port.Write(frame, 0, frame.Length);

            // wait for ack/nack
            if (this.received.WaitOne(WAIT_TIMEOUT, false))
            {
                this.isWaitingAck = false;

                // dequeue received frame
                byte[] frameReceived = (byte[])this.queueFrame.Dequeue();

                // read acknowledge
                byte[] acknowledge = { (byte)frameReceived[3], (byte)frameReceived[4] };

                // return true or flase if ACK or NACK
                if ((acknowledge[0] == PN532.ACK_PACKET_CODE[0] &&
                     acknowledge[1] == PN532.ACK_PACKET_CODE[1]))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public byte[] ReadNormalFrame()
        {
            this.isWaitingAck = false;

            if (this.received.WaitOne(WAIT_TIMEOUT, false))
            {
                byte[] received = (byte[])this.queueFrame.Dequeue();

                return received;
            }
            else
                return null;
        }

        public void WakeUp()
        {
            // PN532 Application Note C106 pag. 23
            
            // HSU wake up consist to send a SAM configuration command with a "long" preamble 
            // here we send preamble that will be followed by regular SAM configuration command
            byte[] preamble = { 0x55, 0x55, 0x00, 0x00, 0x00 };
            this.port.Write(preamble, 0, preamble.Length);
        }

        #endregion
    }

    /// <summary>
    /// HSU frame parser state
    /// </summary>
    internal enum HsuParserState
    {
        Preamble,
        StartCode,
        Length,
        LengthChecksum,
        FrameIdentifierAndData,
        DataChecksum,
        Postamble,
        AckCode
    }
}
