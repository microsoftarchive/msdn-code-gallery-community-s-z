namespace uPLibrary.Nfc
{
    /// <summary>
    /// Abstract class for connection to NFC tag
    /// </summary>
    public abstract class NfcTagConnection
    {
        // nfc tag id
        protected byte[] id;
        // reference to NFC reader
        protected INfcReader reader;

        /// <summary>
        /// Tag ID
        /// </summary>
        public byte[] ID
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }
    }
}
