using System.Text.RegularExpressions;
using Windows.Networking;

namespace Cubisoft.Winrt.Ftp.Messages
{
    public class FtpPassiveModeResponse : FtpResponse
    {
        protected HostName m_HostName;

        private string m_ServiceName;

        public HostName HostName
        {
            get
            {
                if(Success && m_HostName == null) ParseMessage();

                return m_HostName;
            }
        }

        public string ServiceName
        {
            get
            {
                if(Success && m_ServiceName == null) ParseMessage();

                return m_ServiceName;
            }
            protected set { m_ServiceName = value; }
        }

        protected virtual void ParseMessage()
        {
            var matches = Regex.Match(Message,
                                      @"(?<quad1>\d+)," +
                                      @"(?<quad2>\d+)," +
                                      @"(?<quad3>\d+)," +
                                      @"(?<quad4>\d+)," +
                                      @"(?<port1>\d+)," +
                                      @"(?<port2>\d+)"
                );

            if (!matches.Success || matches.Groups.Count != 7)
                throw new FtpException(string.Format("Malformed PASV response: {0}", Message));

            m_HostName = new HostName(string.Format("{0}.{1}.{2}.{3}",
                                                    matches.Groups["quad1"].Value,
                                                    matches.Groups["quad2"].Value,
                                                    matches.Groups["quad3"].Value,
                                                    matches.Groups["quad4"].Value));

            m_ServiceName = ((int.Parse(matches.Groups["port1"].Value) << 8) + int.Parse(matches.Groups["port2"].Value)).ToString();
        }
    }
}