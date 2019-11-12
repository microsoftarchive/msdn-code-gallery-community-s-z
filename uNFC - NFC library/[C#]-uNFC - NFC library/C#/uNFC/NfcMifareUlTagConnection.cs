using System;

namespace uPLibrary.Nfc
{
    /// <summary>
    /// Connection to an NFC Mifare Ultralight tag
    /// </summary>
    public class NfcMifareUlTagConnection : NfcTagConnection
    {
        #region Constants ...

        private const byte MIFARE_UL_READ = 0x30;
        private const byte MIFARE_UL_WRITE = 0xA2;

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reader">Reference to NFC reader</param>
        /// <param name="id">Tag ID connected</param>
        public NfcMifareUlTagConnection(INfcReader reader, byte[] id)
        {
            this.reader = reader;
            this.id = id;
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
            dataOut[0] = MIFARE_UL_READ;
            // block number
            dataOut[1] = block;
                        
            byte[] dataIn = this.reader.WriteRead(dataOut);

            // the command return 16 byte (compatibility with Mifare Classic) but
            // we have to get only first 4 byte for the page requested
            byte[] page = new byte[4];
            Array.Copy(dataIn, 2, page, 0, page.Length); // offest 2

            return page;
        }

        /// <summary>
        /// Write a block (4 bytes)
        /// </summary>
        /// <param name="block">Block number</param>
        /// <param name="data">Data bytes (4 bytes)</param>
        public void Write(byte block, byte[] data)
        {
            byte[] dataOut = new byte[2 + data.Length];

            // write command
            dataOut[0] = MIFARE_UL_WRITE;
            // block number
            dataOut[1] = block;

            // copy data bytes
            for (int i = 0; i < data.Length; i++)
                dataOut[i + 2] = data[i];

            byte[] dataIn = this.reader.WriteRead(dataOut);
        }
    }
}
