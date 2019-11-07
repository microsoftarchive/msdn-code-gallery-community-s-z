namespace Cubisoft.Winrt.Ftp
{
    public class FtpClientConfiguration
    {
        int m_ConnectTimeout = 15000;

        int m_ReadTimeout = 15000;

        int m_DataConnectionConnectTimeout = 15000;

        int m_DataConnectionReadTimeout = 15000;

        #region Configuration Values

        /// <summary>
        /// Gets or sets the length of time in miliseconds to wait for a connection 
        /// attempt to succeed before giving up. Default is 15000 (15 seconds).
        /// </summary>
        public int ConnectTimeout
        {
            get
            {
                return m_ConnectTimeout;
            }
            set
            {
                m_ConnectTimeout = value;
            }
        }

        /// <summary>
        /// Gets or sets the length of time wait in miliseconds for data to be
        /// read from the underlying stream. The default value is 15000 (15 seconds).
        /// </summary>
        public int ReadTimeout
        {
            get
            {
                return m_ReadTimeout;
            }
            set
            {
                m_ReadTimeout = value;
            }
        }

        /// <summary>
        /// Gets or sets the length of time in miliseconds for a data connection
        /// to be established before giving up. Default is 15000 (15 seconds).
        /// </summary>
        public int DataConnectionConnectTimeout
        {
            get
            {
                return m_DataConnectionConnectTimeout;
            }
            set
            {
                m_DataConnectionConnectTimeout = value;
            }
        }

        /// <summary>
        /// Gets or sets the length of time in miliseconds the data channel
        /// should wait for the server to send data. Default value is 
        /// 15000 (15 seconds).
        /// </summary>
        public int DataConnectionReadTimeout
        {
            get
            {
                return m_DataConnectionReadTimeout;
            }
            set
            {
                m_DataConnectionReadTimeout = value;
            }
        }

        #endregion
    }
}
