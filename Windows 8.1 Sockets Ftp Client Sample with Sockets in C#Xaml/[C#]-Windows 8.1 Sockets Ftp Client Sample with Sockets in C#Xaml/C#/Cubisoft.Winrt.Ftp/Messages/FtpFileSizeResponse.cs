namespace Cubisoft.Winrt.Ftp.Messages
{
    public class FtpFileSizeResponse : FtpResponse
    {
        private long m_Size;

        public long Size
        {
            get
            {
                if (m_Size == default(long) && Success)
                {
                    ParseMessage();
                }

                return m_Size;
            }
        }

        private void ParseMessage()
        {
            if (!long.TryParse(Message.TrimEnd('\r', '\n'), out m_Size))
                m_Size = -1;
        }
    }
}