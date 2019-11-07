using System;
using Microsoft.SPOT.Hardware;
using System.Threading;

namespace uPLibrary.Hardware.Nfc
{
    /// <summary>
    /// I2C communication layer
    /// </summary>
    public class PN532CommunicationI2C : IPN532CommunicationLayer
    {
        #region I2C Constants ...

        // NOTE : in pn532um.pdf on pag. 43 the following addresses are reported :
        //        Write = 0x48, Read = 0x49
        //        These addresses already consider the last bit of I2C (0 = W, 1 = R) but the address of
        //        a I2C device is 7 bit so we have to consider only the first 7 bit -> 0x24 is PN532 unique address
        private const ushort PN532_I2C_ADDRESS = 0x24;
        private const int PN532_I2C_CLOCK_RATE_KHZ = 200;
        private const int PN532_I2C_TIMEOUT = 1000;

        #endregion

        // i2c interface
        I2CDevice i2c;

        // irq interrupt port and event related
        InterruptPort irq;
        AutoResetEvent whIrq;

        /// <summary>
        /// Constructor
        /// </summary>
        public PN532CommunicationI2C()
            : this(Cpu.Pin.GPIO_NONE)
        {
        }
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="irq">Pin related to IRQ from PN532</param>
        public PN532CommunicationI2C(Cpu.Pin irq)
        {
            this.i2c = new I2CDevice(new I2CDevice.Configuration(PN532_I2C_ADDRESS, PN532_I2C_CLOCK_RATE_KHZ));
            this.irq = null;

            // use advanced handshake with IRQ pin (pn532um.pdf, pag. 44)
            if (irq != Cpu.Pin.GPIO_NONE)
            {
                this.irq = new InterruptPort(irq, true, Port.ResistorMode.Disabled, Port.InterruptMode.InterruptEdgeLow);
                this.irq.OnInterrupt += irq_OnInterrupt;
                this.whIrq = new AutoResetEvent(false);
            }
        }

        #region IPN532CommunicationLayer interface ...

        public bool SendNormalFrame(byte[] frame)
        {
            this.I2CWrite(frame);

            // read acknowledge
            byte[] acknowledge = this.ReadAcknowledge();

            // if null, timeout waiting READY byte
            if (acknowledge == null)
                return false;

            // return true or flase if ACK or NACK
            if ((acknowledge[0] == PN532.ACK_PACKET_CODE[0] &&
                 acknowledge[1] == PN532.ACK_PACKET_CODE[1]))
                return true;
            else
                return false;
        }

        public byte[] ReadNormalFrame()
        {
            byte[] read = new byte[PN532.PN532_EXTENDED_FRAME_MAX_LEN];

            // using IRQ enabled
            if (this.irq != null)
            {
                // wait for IRQ from PN532 if enabled
                if (!this.whIrq.WaitOne(PN532.PN532_READY_TIMEOUT, false))
                    return null;

                this.I2CRead(read);
            }
            else
            {
                long start = DateTime.Now.Ticks;
                // waiting for status ready
                while (read[0] != PN532.PN532_READY)
                {
                    this.I2CRead(read);

                    // check timeout
                    if ((DateTime.Now.Ticks - start) / PN532.TICKS_PER_MILLISECONDS < PN532.PN532_READY_TIMEOUT)
                        Thread.Sleep(10);
                    else
                        return null;
                }
            }

            // extract data len
            byte len = read[PN532.PN532_LEN_OFFSET + 1]; // + 1, first byte is READY BYTE

            // create buffer for all frame bytes
            byte[] frame = new byte[5 + len + 2];
            // save first part of received frame (first 5 bytes until LCS)
            Array.Copy(read, 1, frame, 0, PN532.PN532_LCS_OFFSET + 1); // sourceIndex = 1, first byte is READY BYTE

            // copy last part of the frame (data + DCS + POSTAMBLE)
            Array.Copy(read, PN532.PN532_LCS_OFFSET + 1 + 1, frame, 5, len + 2); // sourceIndex = (PN532.PN532_LCS_OFFSET + 1) + 1, first byte is READY BYTE

            return frame;
        }

        public void WakeUp()
        {
            // not needed (pn532um.pdf, pag. 100)
        }

        #endregion

        void irq_OnInterrupt(uint data1, uint data2, DateTime time)
        {
            this.whIrq.Set();
        }

        /// <summary>
        /// Read ACK/NACK frame fromPN532
        /// </summary>
        /// <returns>ACK/NACK frame</returns>
        private byte[] ReadAcknowledge()
        {
            byte[] read = new byte[PN532.ACK_PACKET_SIZE + 1]; // + 1, first byte is READY BYTE

            // using IRQ enabled
            if (this.irq != null)
            {
                // wait for IRQ from PN532 if enabled
                if (!this.whIrq.WaitOne(PN532.PN532_READY_TIMEOUT, false))
                    return null;

                this.I2CRead(read);
            }
            else
            {
                long start = DateTime.Now.Ticks;
                // waiting for status ready
                while (read[0] != PN532.PN532_READY)
                {
                    this.I2CRead(read);

                    // check timeout
                    if ((DateTime.Now.Ticks - start) / PN532.TICKS_PER_MILLISECONDS < PN532.PN532_READY_TIMEOUT)
                        Thread.Sleep(10);
                    else
                        return null;
                }
            }

            return new byte[] { read[3 + 1], read[4 + 1] }; // + 1, first byte is READY BYTE
        }

        /// <summary>
        /// Execute an I2C read transaction
        /// </summary>
        /// <param name="data">Output buffer with bytes read</param>
        /// <returns>Number of bytes read</returns>
        private int I2CRead(byte[] data)
        {
            // create a I2C read transaction
            I2CDevice.I2CTransaction[] i2cTx = new I2CDevice.I2CTransaction[1];
            i2cTx[0] = I2CDevice.CreateReadTransaction(data);

            // receive data from PN532
            int read = this.i2c.Execute(i2cTx, PN532_I2C_TIMEOUT);

            // make sure the data was received.
            if (read != data.Length)
                throw new Exception("Error executing I2C reading from PN532");

            return read;
        }

        /// <summary>
        /// Execute an I2C write transaction
        /// </summary>
        /// <param name="data">Input buffer with bytes to write</param>
        /// <returns>Number of bytes written</returns>
        private int I2CWrite(byte[] data)
        {
            // create a I2C write transaction
            I2CDevice.I2CTransaction[] i2cTx = new I2CDevice.I2CTransaction[1];
            i2cTx[0] = I2CDevice.CreateWriteTransaction(data);

            // write data to PN532
            int write = this.i2c.Execute(i2cTx, PN532_I2C_TIMEOUT);

            // make sure the data was sent.
            if (write != data.Length)
                throw new Exception("Error executing I2C writing from PN532");

            return write;
        }
    }
}
