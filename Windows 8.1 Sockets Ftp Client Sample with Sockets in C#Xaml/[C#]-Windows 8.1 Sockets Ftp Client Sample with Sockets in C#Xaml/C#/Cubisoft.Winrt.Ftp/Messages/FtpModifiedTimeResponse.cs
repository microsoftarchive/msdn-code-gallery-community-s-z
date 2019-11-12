using System;
using System.Globalization;

namespace Cubisoft.Winrt.Ftp.Messages
{
    public class FtpModifiedTimeResponse : FtpResponse
    {
        private DateTime m_Modified;

        public DateTime Modified
        {
            get
            {
                if (m_Modified == default(DateTime) && Success)
                {
                    ParseMessage();
                }

                return m_Modified;
            }
        }

        private void ParseMessage()
        {
            m_Modified = Message.TrimEnd('\r', '\n').GetFtpDate(DateTimeStyles.AssumeUniversal);
        }
    }
}