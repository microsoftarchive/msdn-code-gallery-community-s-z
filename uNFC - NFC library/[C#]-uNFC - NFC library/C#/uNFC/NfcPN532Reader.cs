using System;
using System.Threading;
using uPLibrary.Hardware.Nfc;

namespace uPLibrary.Nfc
{
    /// <summary>
    /// NFC reader class for NXP PN532 ic
    /// </summary>
    public class NfcPN532Reader : INfcReader
    {
        // reference to NFC PN532 ic
        private PN532 pn532;

        // thread for listening tag detection
        private Thread detectionThread;
        private bool isRunning;

        // current PN532 target type listening (baud rate/protocol)
        private PN532.TargetType targetType;

        // current NFC tag type
        private NfcTagType nfcTagType;
        // current NFC connection to a tag
        private NfcTagConnection nfcTagConn;       
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="commLayer">Communication layer to use with PN532 ic</param>
        public NfcPN532Reader(IPN532CommunicationLayer commLayer)
        {
            this.pn532 = new PN532(commLayer);
        }

        #region INfcReader interface ...

        public event TagEventHandler TagDetected;
        public event TagEventHandler TagLost;

        public void Open(NfcTagType nfcTagType)
        {
            this.nfcTagType = nfcTagType;
            // map NFC tag type to PN532 target type (baud rate/protocol)
            this.targetType = this.NfcToPN532Type(nfcTagType);

            this.isRunning = true;
            this.nfcTagConn = null;

            // get info and configure PN532 ic
            this.pn532.GetFirmwareVersion();
            this.pn532.SAMConfiguration(PN532.SamMode.NormalMode, false);

            // start thread for tag detection
            this.detectionThread = new Thread(this.DetectionThread);
            this.detectionThread.Start();
        }

        public void Close()
        {
            this.nfcTagConn = null;
            this.isRunning = false;
        }

        public byte[] WriteRead(byte[] data)
        {
            byte[] output = this.pn532.InDataExchange(1, data);
            
            byte[] dataIn = new byte[output.Length - 1]; // -1 -> remove command code response
            Array.Copy(output, 1, dataIn, 0, dataIn.Length);
            return dataIn;
        }

        #endregion

        /// <summary>
        /// Map NFC tag type to PN532 target type (baud rate/protocol)
        /// </summary>
        /// <param name="nfcTagType">NFC target type</param>
        /// <returns>Target type (baud rate)</returns>
        private PN532.TargetType NfcToPN532Type(NfcTagType nfcTagType)
        {
            switch (nfcTagType)
            {
                case NfcTagType.MifareClassic4k:
                case NfcTagType.MifareUltralight:
                    return PN532.TargetType.Iso14443TypeA;
                default:
                    return PN532.TargetType.Iso14443TypeA;
            }
        }
        
        /// <summary>
        /// Raise tag detected event
        /// </summary>
        /// <param name="nfcTagType">NFC tag type</param>
        /// <param name="conn">Connection instance to NFC tag</param>
        private void OnTagDetected(NfcTagType nfcTagType, NfcTagConnection conn)
        {
            if (this.TagDetected != null)
                this.TagDetected(this, new NfcTagEventArgs(nfcTagType, conn));
        }

        /// <summary>
        /// Raise tag lost event
        /// </summary>
        /// <param name="nfcTagType">NFC tag type</param>
        /// <param name="conn">Connection instance to NFC tag</param>
        private void OnTagLost(NfcTagType nfcTagType, NfcTagConnection conn)
        {
            if (this.TagLost != null)
                this.TagLost(this, new NfcTagEventArgs(nfcTagType, conn));
        }

        /// <summary>
        /// Thread for tag detecting
        /// </summary>
        private void DetectionThread()
        {
            while (this.isRunning)
            {
                byte[] target = this.pn532.InListPassiveTarget(this.targetType);

                // target detected
                if (target != null)
                {
                    switch (this.targetType)
                    {
                        case PN532.TargetType.Iso14443TypeA:

                            // no current tag set
                            if (this.nfcTagConn == null)
                            {
                                // get ATQA and SAK
                                byte[] ATQA = new byte[2];
                                Array.Copy(target, PN532.ISO14443A_SENS_RES_OFFSET + 2, ATQA, 0, ATQA.Length); // +2 for 4B and NbTg (pn532um.pdf, pag. 116)
                                byte SAK = target[PN532.ISO14443A_SEL_RES_OFFSET + 2]; // +2 for 4B and NbTg (pn532um.pdf, pag. 116)

                                // get tag ID
                                byte[] tagId = new byte[target[PN532.ISO14443A_IDLEN_OFFSET + 2]]; // +2 for 4B and NbTg (pn532um.pdf, pag. 116)
                                Array.Copy(target, PN532.ISO14443A_IDLEN_OFFSET + 2 + 1, tagId, 0, tagId.Length);

                                // check ATQA and SAK for Mifare Classic 1k
                                if (ATQA[0] == 0x00 && ATQA[1] == 0x04 && SAK == 0x08)
                                {
                                    this.nfcTagType = NfcTagType.MifareClassic1k;
                                    this.nfcTagConn = new NfcMifareTagConnection(this, tagId);
                                    this.OnTagDetected(this.nfcTagType, this.nfcTagConn);
                                }
                                // check ATQA and SAK for Mifare Ultralight
                                else if (ATQA[0] == 0x00 && ATQA[1] == 0x44 && SAK == 0x00)
                                {
                                    this.nfcTagType = NfcTagType.MifareUltralight;
                                    this.nfcTagConn = new NfcMifareUlTagConnection(this, tagId);
                                    this.OnTagDetected(this.nfcTagType, this.nfcTagConn);
                                }
                            }
                            break;

                        default: 
                            break;
                    }
                }
                // no target detected
                else
                {
                    // if current tag set and no target detected...
                    if (this.nfcTagConn != null)
                    {
                        // ...current tag is lost
                        this.OnTagLost(this.nfcTagType, this.nfcTagConn);
                        this.nfcTagConn = null;
                    }
                }
            }
        }       
    }

    /// <summary>
    /// NFC tag type
    /// </summary>
    public enum NfcTagType
    {
        /// <summary>
        /// Mifare Classic 1 KB
        /// </summary>
        MifareClassic1k,

        /// <summary>
        /// Mifare Classic 4 KB
        /// </summary>
        MifareClassic4k,

        /// <summary>
        /// Mifare Ultralight
        /// </summary>
        MifareUltralight
    }
}
