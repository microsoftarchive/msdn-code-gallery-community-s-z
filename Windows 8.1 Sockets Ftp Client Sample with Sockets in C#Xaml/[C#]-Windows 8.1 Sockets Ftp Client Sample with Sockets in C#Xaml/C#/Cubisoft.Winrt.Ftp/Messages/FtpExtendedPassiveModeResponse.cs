using System.Text.RegularExpressions;
using Windows.Networking;

namespace Cubisoft.Winrt.Ftp.Messages
{
    public class FtpExtendedPassiveModeResponse : FtpPassiveModeResponse
    {
        public new HostName HostName
        {
            get { return m_HostName; }
            set { m_HostName = value; }
        }

        protected override void ParseMessage()
        {
            var matches = Regex.Match(Message, @"\(\|\|\|(?<port>\d+)\|\)");

            if (!matches.Success)
            {
                throw new FtpException("Failed to get the EPSV port from: " + Message);
            }

            ServiceName = matches.Groups["port"].Value;
        }
    }
}