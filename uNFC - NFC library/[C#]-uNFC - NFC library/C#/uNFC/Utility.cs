using System.Text;

namespace uPLibrary.Utilities
{
    internal class Utility
    {
        static private string hexChars = "0123456789ABCDEF";

        /// <summary>
        /// Reverse bits order inside a byte (MSB to LSB and viceversa)
        /// </summary>
        /// <param name="value">Byte value to reverse</param>
        /// <returns>Byte value after reverse</returns>
        static internal byte ReverseBits(byte value)
        {
            byte reversed = 0x00;

            int i = 7, j = 0;

            while (i >= 0)
            {
                reversed |= (byte)(((value >> i) & 0x01) << j);
                i--;
                j++;
            }
            return reversed;
        }

        /// <summary>
        /// Reverse bits order of all a byte (MSB to LSB and viceversa) inside array
        /// </summary>
        /// <param name="data">Byte array to reverse order</param>
        /// <returns>Byte array reversed</returns>
        static internal byte[] ReverseBytes(byte[] data)
        {
            byte[] reversed = new byte[data.Length];

            for (int i = 0; i < data.Length; i++)
                reversed[i] = ReverseBits(data[i]);

            return reversed;
        }

        /// <summary>
        /// Convert hex byte array in a hex string
        /// </summary>
        /// <param name="value">Byte array with hex values</param>
        /// <returns>Hex string</returns>
        static internal string HexToString(byte[] value)
        {
            StringBuilder hexString = new StringBuilder();
            for (int i = 0; i < value.Length; i++)
            {
                hexString.Append(hexChars[(value[i] >> 4) & 0x0F]);
                hexString.Append(hexChars[value[i] & 0x0F]);
            }
            return hexString.ToString();
        }
    }
}
