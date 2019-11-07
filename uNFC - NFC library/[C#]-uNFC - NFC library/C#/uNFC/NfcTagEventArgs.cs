#if (MF_FRAMEWORK_VERSION_V4_2 || MF_FRAMEWORK_VERSION_V4_3)
using Microsoft.SPOT;
#else
using System;
#endif

namespace uPLibrary.Nfc
{
    public class NfcTagEventArgs : EventArgs
    {
        /// <summary>
        /// NFC tag type
        /// </summary>
        public NfcTagType NfcTagType { get; private set; }

        /// <summary>
        /// Connection instance to NFC tag
        /// </summary>
        public NfcTagConnection Connection { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="nfcTagType">NFC tag type</param>
        /// <param name="conn">Connection instance to NFC tag</param>
        public NfcTagEventArgs(NfcTagType nfcTagType, NfcTagConnection conn)
        {
            this.NfcTagType = nfcTagType;
            this.Connection = conn;
        }
    }
}
