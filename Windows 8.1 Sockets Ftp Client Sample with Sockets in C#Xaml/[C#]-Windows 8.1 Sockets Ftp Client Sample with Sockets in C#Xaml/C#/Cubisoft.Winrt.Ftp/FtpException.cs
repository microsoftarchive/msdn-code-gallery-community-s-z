using System;
using Cubisoft.Winrt.Ftp.Messages;

namespace Cubisoft.Winrt.Ftp
{
    /// <summary>
    /// FTP related error
    /// </summary>
    public class FtpException : Exception
    {
        /// <summary>
        /// Initializes the exception object
        /// </summary>
        /// <param name="message">The error message</param>
        public FtpException(string message) : base(message) { }
    }

    /// <summary>
    /// Exception triggered on command failures
    /// </summary>
    public class FtpCommandException : FtpException
    {
        string m_Code;

        /// <summary>
        /// Gets the completion code associated with the response
        /// </summary>
        public string CompletionCode
        {
            get { return m_Code; }
            private set { m_Code = value; }
        }

        /// <summary>
        /// The type of response received from the last command executed
        /// </summary>
        public FtpResponseType ResponseType
        {
            get
            {
                if (m_Code != null)
                {
                    // we only care about error types, if an exception
                    // is being thrown for a successful response there
                    // is a problem.
                    switch (m_Code[0])
                    {
                        case '4':
                            return FtpResponseType.TransientNegativeCompletion;
                        case '5':
                            return FtpResponseType.PermanentNegativeCompletion;
                    }
                }

                return FtpResponseType.None;
            }
        }

        /// <summary>
        /// Initalizes a new instance of a FtpResponseException
        /// </summary>
        /// <param name="code">Status code</param>
        /// <param name="message">Associated message</param>
        public FtpCommandException(string code, string message)
            : base(message)
        {
            CompletionCode = code;
        }

        /// <summary>
        /// Initalizes a new instance of a FtpResponseException
        /// </summary>
        /// <param name="reply">The FtpReply to build the exception from</param>
        public FtpCommandException(FtpResponse reply)
            : this(reply.Code, reply.Message)
        {
        }
    }

    /// <summary>
    /// Exception is thrown when encryption could not be negotiated by the server
    /// </summary>
    public class FtpSecrutiyNotAvailableException : FtpException
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public FtpSecrutiyNotAvailableException()
            : base("Security is not available on the server.")
        {
        }

        /// <summary>
        /// Custom error message
        /// </summary>
        /// <param name="message">Error message</param>
        public FtpSecrutiyNotAvailableException(string message)
            : base(message)
        {
        }
    }
}
