namespace uPLibrary.Hardware.Nfc
{
    /// <summary>
    /// Interface for communication layer with PN532
    /// (eg. HSU, I2C or SPI)
    /// </summary>
    public interface IPN532CommunicationLayer
    {
        /// <summary>
        /// Send a normal frame to the PN532 (pn532um.pdf, pag. 28)
        /// </summary>
        /// <param name="frame">Frame bytes to send</param>
        bool SendNormalFrame(byte[] frame);

        /// <summary>
        /// Read a normal frame from PN532 (pn532um.pdf, pag. 28)
        /// </summary>
        /// <returns>Normal frame read (or null for timeout)</returns>
        byte[] ReadNormalFrame();

        /// <summary>
        /// Execute wake up procedure for PN532 (pn532um.pdf, from pag. 99)
        /// </summary>
        void WakeUp();
    }
}
