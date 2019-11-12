namespace Cubisoft.Winrt.Ftp.Messages
{
    public class FtpResponse
    {
        string m_RespCode;

        private string m_RespMessage;

        private string m_InfoMessages;

        private FtpRequest m_Request;

        /// <summary>
        /// The type of response received from the last command executed
        /// </summary>
        public FtpResponseType Type
        {
            get
            {
                int code;

                if (!string.IsNullOrEmpty(Code) && int.TryParse(Code[0].ToString(), out code))
                {
                    return (FtpResponseType)code;
                }

                return FtpResponseType.None;
            }
        }

        /// <summary>
        /// The status code of the response
        /// </summary>
        public string Code
        {
            get
            {
                return m_RespCode;
            }
            set
            {
                m_RespCode = value;
            }
        }

        /// <summary>
        /// The message, if any, that the server sent with the response
        /// </summary>
        public string Message
        {
            get
            {
                return m_RespMessage;
            }
            set
            {
                m_RespMessage = value;
            }
        }

        /// <summary>
        /// Informational messages sent from the server
        /// </summary>
        public string InfoMessages
        {
            get
            {
                return m_InfoMessages;
            }
            set
            {
                m_InfoMessages = value;
            }
        }

        /// <summary>
        /// General success or failure of the last command executed
        /// </summary>
        public bool Success
        {
            get
            {
                if (!string.IsNullOrEmpty(Code))
                {
                    int i;

                    // 1xx, 2xx, 3xx indicate success
                    // 4xx, 5xx are failures
                    if (int.TryParse(Code[0].ToString(), out i) && i >= 1 && i <= 3)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public FtpRequest Request
        {
            get { return m_Request; }
            set { m_Request = value; }
        }
    }
}
