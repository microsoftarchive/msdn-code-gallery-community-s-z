using System;

namespace uPLibrary.Hardware.Nfc
{
    /// <summary>
    /// Driver for PN532 NFC chip (from NXP)
    /// </summary>
    public class PN532
    {
        #region PN532 Constants ...

        // constants for normal information frame (pn532um.pdf, pag. 28)
        internal const byte PN532_PREAMBLE = 0x00;
        internal const byte PN532_STARTCODE_1 = 0x00;
        internal const byte PN532_STARTCODE_2 = 0xFF;
        internal const byte PN532_POSTAMBLE = 0x00;
        internal const byte PN532_HOST_TO_PN532 = 0xD4;
        internal const byte PN532_PN532_TO_HOST = 0xD5;

        // offset of bytes inside normal information frame
        internal const byte PN532_PREAMBLE_OFFSET = 0;
        internal const byte PN532_STARTCODE_1_OFFSET = 1;
        internal const byte PN532_STARTCODE_2_OFFSET = 2;
        internal const byte PN532_LEN_OFFSET = 3;
        internal const byte PN532_LCS_OFFSET = 4;
        internal const byte PN532_TFI_OFFSET = 5;
        internal const byte PN532_DATA_OFFSET = 6;
        // NOTE : DCS and POSTAMBLE haven't an offset because they depend on DATA (PD0...PDn) length

        // bytes for data ready or not from PN532 (I2C and SPI communication)
        internal const byte PN532_NOT_READY = 0x00;
        internal const byte PN532_READY = 0x01;
        // default timeout to wait PN532 ready
        internal const int PN532_READY_TIMEOUT = 500;

        // ack and nack packet code
        internal static readonly byte[] ACK_PACKET_CODE = { 0x00, 0xFF };
        internal static readonly byte[] NACK_PACKET_CODE = { 0xFF, 0x00 };
        internal const byte ACK_PACKET_SIZE = 6;

        // command code
        private const byte PN532_FIRMWARE_VERSION = 0x02;
        private const byte PN532_SAM_CONFIGURATION = 0x14;
        private const byte PN532_IN_LIST_PASSIVE_TARGET = 0x4A;
        private const byte PN532_IN_DATAEXCHANGE = 0x40;

        // offset in InListPassiveTarget command for ISO14443A
        public const byte ISO14443A_TG_OFFSET = 0;
        public const byte ISO14443A_SENS_RES_OFFSET = 1;
        public const byte ISO14443A_SEL_RES_OFFSET = 3;
        public const byte ISO14443A_IDLEN_OFFSET = 4;

        // max size for extended frame
        public const int PN532_EXTENDED_FRAME_MAX_LEN = 264;

        // 1 tick = 0.1 us (10 ticks = 1 us = 100 ns, as .Net MF documentation)
        internal const long TICKS_PER_MILLISECONDS = 10000;

        #endregion

        // object for thread safety on executing command
        private object cmdLock = new object();
        // reference to communication layer
        private IPN532CommunicationLayer commLayer;

        // power mode
        private PowerMode powerMode;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="commLayer">Communication layer to use</param>
        public PN532(IPN532CommunicationLayer commLayer)
        {
            this.commLayer = commLayer;
            this.powerMode = PowerMode.LowVbat;
        }

        /// <summary>
        /// Get firmware information
        /// </summary>
        /// <returns>Bytes with firmwarre information</returns>
        public byte[] GetFirmwareVersion()
        {
            byte[] cmd = { PN532_FIRMWARE_VERSION };

            return this.ExecuteCmd(cmd);
        }

        /// <summary>
        /// Set SAM configuration
        /// </summary>
        /// <param name="mode">Mode to use SAM</param>
        /// <param name="isIRQ">Use IRQ pin</param>
        /// <returns>Result from SAM configuration</returns>
        public byte[] SAMConfiguration(SamMode mode, bool isIRQ)
        {
            byte irq = isIRQ ? (byte)0x01 : (byte)0x00;
            byte[] cmd = { PN532_SAM_CONFIGURATION, (byte)mode, 0x00, irq };

            return this.ExecuteCmd(cmd);
        }

        /// <summary>
        /// Detect a target in passive mode
        /// </summary>
        /// <param name="type">Target type (baud rate)</param>
        /// <returns>Bytes with target detected information</returns>
        public byte[] InListPassiveTarget(TargetType type)
        {
            byte[] cmd = { PN532_IN_LIST_PASSIVE_TARGET, 0x01, (byte)type };

            return this.ExecuteCmd(cmd);
        }

        /// <summary>
        /// Execute data exchange between chip and target
        /// </summary>
        /// <param name="tg">Target logical number</param>
        /// <param name="dataOut">Raw data to send to the target</param>
        /// <returns></returns>
        public byte[] InDataExchange(byte tg, byte[] dataOut)
        {
            byte[] cmd = new byte[dataOut.Length + 2];  // +2 -> command code and Tg
            cmd[0] = PN532_IN_DATAEXCHANGE;
            cmd[1] = tg;
            Array.Copy(dataOut, 0, cmd, 2, dataOut.Length);

            return this.ExecuteCmd(cmd);
        }

        /// <summary>
        /// Execute a command
        /// </summary>
        /// <param name="cmd">Bytes command to execute</param>
        /// <returns>Response from command</returns>
        private byte[] ExecuteCmd(byte[] cmd)
        {
            lock (this.cmdLock)
            {
                // verify power mode and execute wake up if necessary
                this.WakeUp();

                // send cmd and check acknowledge
                if (this.SendNormalFrame(cmd))
                {
                    byte[] response = this.ReadNormalFrame();
                    return response;
                }
                else
                    return null;
            }
        }

        /// <summary>
        /// Read a normal frame
        /// </summary>
        /// <returns>Normal frame bytes received</returns>
        private byte[] ReadNormalFrame()
        {
            byte[] frame = this.commLayer.ReadNormalFrame();

            if (frame != null)
            {
                // response doesn't contain TFI (so response length is LEN - 1, because LEN includes TFI)
                byte[] response = new byte[frame[PN532_LEN_OFFSET] - 1];

                // get only DATA (PD0...PDn -> command code and data)
                Array.Copy(frame, PN532_DATA_OFFSET, response, 0, response.Length);

                return response;
            }
            else
                return null;
        }

        /// <summary>
        /// Send a normal frame (cmd)
        /// </summary>
        /// <param name="cmd">Normal frame (cmd) bytes to send</param>
        /// <returns>Command acked/nacked</returns>
        private bool SendNormalFrame(byte[] cmd)
        {
            // cmd = PD0...PDn (PD0 = command code, PD1...PDn = data)

            // prepare command
            byte[] frame = new byte[cmd.Length + 8];    // PD0...PDn = cmd.Length
                                                        // PREAMBLE + 2*STARCODE + LEN + LCS + TFI + DCS + POSTAMBLE = 8
            
            byte len = (byte)(cmd.Length + 1);          // PD0...PDn = cmd.Length + TFI           

            frame[PN532_PREAMBLE_OFFSET] = PN532_PREAMBLE;
            frame[PN532_STARTCODE_1_OFFSET] = PN532_STARTCODE_1;
            frame[PN532_STARTCODE_2_OFFSET] = PN532_STARTCODE_2;
            frame[PN532_LEN_OFFSET] = len;
            frame[PN532_LCS_OFFSET] = (byte)(~len + 1); // [LEN + LCS] = 0x00
            frame[PN532_TFI_OFFSET] = PN532_HOST_TO_PN532;
            Array.Copy(cmd, 0, frame, PN532_DATA_OFFSET, cmd.Length);

            byte dcs = 0x00;
            dcs += PN532_HOST_TO_PN532;
            for (int i = 0; i < cmd.Length; i++)
                dcs += cmd[i];
            dcs = (byte)(~dcs + 1);                     // [TFI + PD0 + PD1 + … + PDn + DCS] = 0x00

            frame[PN532_DATA_OFFSET + cmd.Length] = dcs;
            frame[frame.Length - 1] = PN532_POSTAMBLE;

            // send frame through communication layer
            return this.commLayer.SendNormalFrame(frame);
        }

        /// <summary>
        /// Wake up procedure
        /// </summary>
        private void WakeUp()
        {
            switch (this.powerMode)
            {
                case PowerMode.Normal:
                    
                    // nothing
                    break;

                case PowerMode.PowerDown:
                    
                    // TODO : wake up needed or nothing ?
                    // this.commLayer.WakeUp();
                    break;

                case PowerMode.LowVbat:

                    // PN532 Application Note C106 pag. 23

                    // wake up needed
                    this.commLayer.WakeUp();

                    // SAM Configuration in normal mode command is needed (pn532um.pdf, pag. 13)
                    byte[] cmd = { PN532_SAM_CONFIGURATION, (byte)SamMode.NormalMode, 0x00, 0x00 };
                    // send cmd and check acknowledge
                    if (this.SendNormalFrame(cmd))
                    {
                        byte[] response = this.ReadNormalFrame();
                    }
                    break;

                default:
                    break;
            }

            this.powerMode = PowerMode.Normal;
        }

        /// <summary>
        /// Target type (baud rate)
        /// </summary>
        public enum TargetType : byte
        {
            /// <summary>
            /// 106 kbps type A (ISO/IEC14443 Type A)
            /// </summary>
            Iso14443TypeA = 0x00,

            /// <summary>
            /// 212 kbps (FeliCa polling)
            /// </summary>
            Felica212 = 0x01,

            /// <summary>
            /// 424 kbps (FeliCa polling)
            /// </summary>
            Felica424 = 0x02,

            /// <summary>
            /// 106 kbps type B (ISO/IEC14443-3B)
            /// </summary>
            Iso14443TypeB = 0x03,

            /// <summary>
            /// 106 kbps Innovision Jewel tag
            /// </summary>
            Jewel = 0x04
        }

        /// <summary>
        /// Way to use SAM (Security Access Module)
        /// </summary>
        public enum SamMode : byte
        {
            /// <summary>
            /// SAM not used
            /// </summary>
            NormalMode = 0x01,

            VirtualCard = 0x02,
            WiredCard = 0x03,
            DualMode = 0x04
        }

        /// <summary>
        /// Power modes
        /// </summary>
        internal enum PowerMode
        {
            Normal,
            PowerDown,
            LowVbat
        }
    }   
}
