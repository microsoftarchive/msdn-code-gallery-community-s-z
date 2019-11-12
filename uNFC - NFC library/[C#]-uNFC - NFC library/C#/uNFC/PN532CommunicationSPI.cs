using System;
using Microsoft.SPOT.Hardware;
using System.Threading;

// class alias to avoid ambiguous reference with Microsoft.SPOT.Hardware.Utility
using upUtility = uPLibrary.Utilities.Utility;

namespace uPLibrary.Hardware.Nfc
{
    /// <summary>
    /// SPI communication layer
    /// </summary>
    public class PN532CommunicationSPI : IPN532CommunicationLayer
    {
        #region SPI Constants ...

        private const bool SPI_CS_ACTIVE_STATE = false; // LOW (pn532um.pdf, pag. 25)
        private const uint SPI_CS_SETUP_TIME = 2;
        private const uint SPI_CS_HOLD_TIME = 2;
        private const bool SPI_CLK_IDLE_STATE = false;  // LOW (pn532um.pdf, pag. 25)
        private const bool SPI_CLK_EDGE = true;         // LOW (pn532um.pdf, pag. 25)
        private const uint SPI_CLK_RATE = 1000;         // 1 Mhz (up to 5 Mhz as pn532um.pdf, pag. 45)

        // (pn532um.pdf, pag. 45)
        private const byte PN532_SPI_DATAWRITE = 0x01;
        private const byte PN532_SPI_STATREAD = 0x02;
        private const byte PN532_SPI_DATAREAD = 0x03;

        #endregion

        // spi interface
        private SPI spi;
        // spi slave selection port
        private OutputPort nssPort;

        // irq interrupt port and event related
        InterruptPort irq;
        AutoResetEvent whIrq;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="spiModule">SPI device module</param>
        /// <param name="nss">Slave Selection</param>
        public PN532CommunicationSPI(SPI.SPI_module spiModule, Cpu.Pin nss)
            : this(spiModule, nss, Cpu.Pin.GPIO_NONE)
        {
        }
        

        public PN532CommunicationSPI(SPI.SPI_module spiModule, Cpu.Pin nss, Cpu.Pin irq)
        {
            SPI.Configuration spiCfg = new SPI.Configuration(Cpu.Pin.GPIO_NONE,     // chip select pin
                                                             SPI_CS_ACTIVE_STATE,   // chip select active state
                                                             SPI_CS_SETUP_TIME,     // chip select setup time
                                                             SPI_CS_HOLD_TIME,      // chip select hold time
                                                             SPI_CLK_IDLE_STATE,    // clock idle state
                                                             SPI_CLK_EDGE,          // clock edge
                                                             SPI_CLK_RATE,          // clock rate (Khz)
                                                             spiModule);            // spi module used

            this.spi = new SPI(spiCfg);

            this.nssPort = new OutputPort(nss, true);

            this.irq = null;
            // use advanced handshake with IRQ pin (pn532um.pdf, pag. 47)
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
            byte[] write = upUtility.ReverseBytes(frame);

            // send frame
            this.nssPort.Write(false);
            Thread.Sleep(2);

            this.spi.Write(new byte[] { upUtility.ReverseBits(PN532_SPI_DATAWRITE) });
            this.spi.Write(write);

            this.nssPort.Write(true);

            // using IRQ enabled
            if (this.irq != null)
            {
                // wait for IRQ from PN532 if enabled
                if (!this.whIrq.WaitOne(PN532.PN532_READY_TIMEOUT, false))
                    return false;

                // IRQ signaled, read status byte
                //if (this.ReadStatus() != PN532.PN532_READY)
                //    return false;
            }
            else
            {
                long start = DateTime.Now.Ticks;
                // waiting for status ready
                while (this.ReadStatus() != PN532.PN532_READY)
                {
                    // check timeout
                    if ((DateTime.Now.Ticks - start) / PN532.TICKS_PER_MILLISECONDS < PN532.PN532_READY_TIMEOUT)
                        Thread.Sleep(10);
                    else
                        return false;
                }
            }

            // read acknowledge
            byte[] acknowledge = this.ReadAcknowledge();

            // return true or flase if ACK or NACK
            if ((acknowledge[0] == PN532.ACK_PACKET_CODE[0] && 
                 acknowledge[1] == PN532.ACK_PACKET_CODE[1]))
                return true;
            else
                return false;
        }

        public byte[] ReadNormalFrame()
        {
            // using IRQ enabled
            if (this.irq != null)
            {
                // wait for IRQ from PN532 if enabled
                if (!this.whIrq.WaitOne(PN532.PN532_READY_TIMEOUT, false))
                    return null;
            }
            else
            {
                long start = DateTime.Now.Ticks;
                // waiting for status ready
                while (this.ReadStatus() != PN532.PN532_READY)
                {
                    // check timeout
                    if ((DateTime.Now.Ticks - start) / PN532.TICKS_PER_MILLISECONDS < PN532.PN532_READY_TIMEOUT)
                        Thread.Sleep(10);
                    else
                        return null;
                }
            }

            // dummy bytes from master to force clock a reading from slave
            byte[] write = { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
            byte[] read = new byte[PN532.PN532_LCS_OFFSET + 1];

            this.nssPort.Write(false);
            Thread.Sleep(2);

            // send data reading request and read response
            this.spi.Write(new byte[] { upUtility.ReverseBits(PN532_SPI_DATAREAD) });
            // write 5 (PN532_LCS_OFFSET + 1) dummy bytes to read until LCS byte
            this.spi.WriteRead(write, read);

            // extract data len
            byte len = upUtility.ReverseBits(read[PN532.PN532_LEN_OFFSET]);

            // create buffer for all frame bytes
            byte[] frame = new byte[5 + len + 2];
            // save first part of received frame (first 5 bytes until LCS)
            Array.Copy(read, frame, read.Length);

            write = new byte[len + 2]; // dummy bytes for reading remaining bytes (data + DCS + POSTAMBLE)
            for (int i = 0; i < write.Length; i++)
                write[i] = 0xFF;

            read = new byte[len + 2];

            // write dummy bytes to read data, DCS and POSTAMBLE
            this.spi.WriteRead(write, read);

            this.nssPort.Write(true);

            // copy last part of the frame (data + DCS + POSTAMBLE)
            Array.Copy(read, 0, frame, 5, read.Length);
            byte[] reversed = upUtility.ReverseBytes(frame);

            return reversed;
        }

        public void WakeUp()
        {
            // TODO : SPI need wake up ?? Is there a 2 ms delay after SS goes low..it is alredy weak up !
        }

        #endregion

        void irq_OnInterrupt(uint data1, uint data2, DateTime time)
        {
            this.whIrq.Set();
        }

        /// <summary>
        /// Read status from PN532
        /// </summary>
        /// <returns>Status byte</returns>
        private byte ReadStatus()
        {
            // prepare
            byte[] write = { upUtility.ReverseBits(PN532_SPI_STATREAD) };
            byte[] read = new byte[1];

            this.nssPort.Write(false);
            Thread.Sleep(2);

            this.spi.WriteRead(write, read);

            this.nssPort.Write(true);

            byte[] status = upUtility.ReverseBytes(read);

            return status[0];
        }

        /// <summary>
        /// Read ACK/NACK frame fromPN532
        /// </summary>
        /// <returns>ACK/NACK frame</returns>
        private byte[] ReadAcknowledge()
        {
            // dummy bytes from master to force clock a reading from slave
            byte[] write = { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
            byte[] read = new byte[PN532.ACK_PACKET_SIZE];

            // send data reading request and read response
            this.nssPort.Write(false);
            Thread.Sleep(2);

            this.spi.Write(new byte[] { upUtility.ReverseBits(PN532_SPI_DATAREAD) });
            this.spi.WriteRead(write, read);

            this.nssPort.Write(true);

            byte[] acknowledge = upUtility.ReverseBytes(read);

            // return only ACK/NACK packet code from frame received
            return new byte[] { acknowledge[3], acknowledge[4] };
        }
    }
}
