using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Security;
using System.Text;
using System.Xml;

namespace Microsoft.WindowsAzure.ActiveDirectory.GraphHelper
{
    /// <summary>
    /// Class that will be instantiated using the token value fetched from Azure AD for talking to Graph.
    /// </summary>
    [DataContract]
    public class AADJWTToken
    {
        [DataMember(Name = "token_type")]
        public string TokenType { get; set; }

        [DataMember(Name = "access_token")]
        public string AccessToken { get; set; }

        [DataMember(Name = "not_before")]
        public ulong NotBefore { get; set; }

        [DataMember(Name = "expires_on")]
        public ulong ExpiresOn { get; set; }

        [DataMember(Name = "expires_in")]
        public ulong ExpiresIn { get; set; }

        /// <summary>
        /// Returns true if the token is expired and false otherwise.
        /// </summary>
        public bool IsExpired
        {
            get
            {
                return WillExpireIn(0);
            }
        }

        /// <summary>
        /// Returns true if the token will expire in the number of minutes passed in to the method.
        /// </summary>
        /// <param name="minutes">minutes in which the token is checked for expiration.</param>
        /// <returns></returns>
        public bool WillExpireIn(int minutes)
        {
            return GenerateTimeStamp(minutes) > ExpiresOn;
        }

        /// <summary>
        /// Generates the timestap value for the number of minutes passed in.
        /// </summary>
        /// <param name="minutes"></param>
        /// <returns></returns>
        private static ulong GenerateTimeStamp(int minutes)
        {
            // Default implementation of epoch time
            TimeSpan ts = DateTime.UtcNow.AddMinutes(minutes) - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToUInt64(ts.TotalSeconds);
        }
    }
}
