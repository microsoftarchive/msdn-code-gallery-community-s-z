using System;

namespace uPLibrary.Nfc
{
    /// <summary>
    /// Connection to an NFC Mifare Classic tag
    /// </summary>
    public class NfcMifareTagConnection : NfcTagConnection
    {
        #region Constants ...

        private const byte MIFARE_AUTH_KEYA = 0x60;
        private const byte MIFARE_AUTH_KEYB = 0x61;
        private const byte MIFARE_READ = 0x30;
        private const byte MIFARE_WRITE = 0xA0;

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reader">Reference to NFC reader</param>
        /// <param name="id">Tag ID connected</param>
        public NfcMifareTagConnection(INfcReader reader, byte[] id)
        {
            this.reader = reader;
            this.id = id;
        }

        /// <summary>
        /// Authenticate access to a block
        /// </summary>
        /// <param name="keyAuth">Authorization type (Key A or Key B)</param>
        /// <param name="block">Block number</param>
        /// <param name="key">Key bytes value</param>
        /// <returns>Result of authentication</returns>
        public bool Authenticate(MifareKeyAuth keyAuth, byte block, byte[] key)
        {
            byte[] dataOut = new byte[8 + id.Length]; // 8 -> fixed part (key type, block number, key bytes value)

            // key auth command (type A or B)
            dataOut[0] = (keyAuth == MifareKeyAuth.KeyA) ? MIFARE_AUTH_KEYA : MIFARE_AUTH_KEYB;
            // block number
            dataOut[1] = block;
            // key value
            Array.Copy(key, 0, dataOut, 2, key.Length);
            
            // tag ID
            for (int i = 8; i < dataOut.Length; i++)
                dataOut[i] = this.id[i - 8];

            byte[] dataIn = this.reader.WriteRead(dataOut);

            // check error code byte (pn532um.pdf, pag. 67)
            return (dataIn[0] == 0x00);
        }

        /// <summary>
        /// Read a block
        /// </summary>
        /// <param name="block">Block number</param>
        /// <returns>Bytes read</returns>
        public byte[] Read(byte block)
        {
            byte[] dataOut = new byte[2];
            // read command
            dataOut[0] = MIFARE_READ;
            // block number
            dataOut[1] = block;

            byte[] dataIn = this.reader.WriteRead(dataOut);
            
            // check error byte
            if (dataIn[0] != 0x00)
                return null;
            else
            {
                byte[] data = new byte[dataIn.Length - 1];
                Array.Copy(dataIn, 1, data, 0, data.Length);
                return data;
            }
        }

        /// <summary>
        /// Write a block (16 bytes)
        /// </summary>
        /// <param name="block">Block number</param>
        /// <param name="data">Data bytes (16 bytes)</param>
        public bool Write(byte block, byte[] data)
        {
            byte[] dataOut = new byte[2 + data.Length];

            // write command
            dataOut[0] = MIFARE_WRITE;
            // block number
            dataOut[1] = block;

            // copy data bytes
            for (int i = 0; i < data.Length; i++)
                dataOut[i + 2] = data[i];

            byte[] dataIn = this.reader.WriteRead(dataOut);

            // check error code byte (pn532um.pdf, pag. 67)
            return (dataIn[0] == 0x00);
        }
    }

    /// <summary>
    /// Authorization key to use
    /// </summary>
    public enum MifareKeyAuth
    {
        KeyA,
        KeyB
    }
}
