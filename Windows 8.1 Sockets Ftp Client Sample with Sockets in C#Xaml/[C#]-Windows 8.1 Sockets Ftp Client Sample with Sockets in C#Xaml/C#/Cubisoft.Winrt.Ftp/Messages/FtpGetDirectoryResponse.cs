using System;
using System.Text.RegularExpressions;

namespace Cubisoft.Winrt.Ftp.Messages
{
    public class FtpGetDirectoryResponse : FtpResponse
    {
        private string m_Directory = string.Empty;

        public FtpGetDirectoryResponse()
        {
        }

        public string Directory 
        {
            get 
            { 
                if (m_Directory == string.Empty) m_Directory = ParseResponse();
                return m_Directory;
            }
        }

        private string ParseResponse()
        {
            Match match;

            if (!(match = Regex.Match(Message, "\"(?<pwd>.*)\"")).Success)
                throw new Exception("Failed to parse working directory from: " + Message);

            return match.Groups["pwd"].Value;
        }
    }
}