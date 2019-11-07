using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace MailConfigurationLibrary
{
    /// <summary>
    /// Responsible for retrieving settings for use when sending Smtp email messages in the app
    /// and also in unit test.
    /// </summary>
    /// <remarks>
    /// - variable smtpSection provides the ability to read elements from app.config or web.config
    /// - MailConfigurationTest provides a unit test for testing this class.
    /// </remarks>
    public class MailConfiguration
    {
        private SmtpSection smtpSection = (ConfigurationManager.GetSection("system.net/mailSettings/smtp") as SmtpSection);
        /// <summary>
        /// Location of configuration file
        /// </summary>
        public string ConfigurationFileName {
            get
            {
                try
                {
                    return smtpSection.ElementInformation.Source;
                }
                catch (Exception)
                {

                    return "";
                }

            } }
        /// <summary>
        /// Email address for the system
        /// </summary>
        public string FromAddress { get { return smtpSection.From; } }
        /// <summary>
        /// Gets the name or IP address of the host used for SMTP transactions.
        /// </summary>
        public string Host { get { return smtpSection.Network.Host; } }
        /// <summary>
        /// Gets the port used for SMTP transactions
        /// </summary>
        /// <remarks>default host is 25</remarks>
        public int Port { get { return smtpSection.Network.Port; } }
        /// <summary>
        /// Gets a value that specifies the amount of time after 
        /// which a synchronous Send call times out.
        /// </summary>
        public int TimeOut { get { return 2000; } }
        public override string ToString()
        {
            return "From: [" + FromAddress + "] Host: [" + Host + "] Port: [" + Port + "]";
        }
    }
}
