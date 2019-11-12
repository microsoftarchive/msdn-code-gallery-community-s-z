//---------------------------------------------------------------------------------
// Copyright 2010 Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License"); 
// You may not use this file except in compliance with the License. 
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0 

// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, EITHER EXPRESS OR IMPLIED, 
// INCLUDING WITHOUT LIMITATION ANY IMPLIED WARRANTIES OR 
// CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE, 
// MERCHANTABLITY OR NON-INFRINGEMENT. 

// See the Apache 2 License for the specific language governing 
// permissions and limitations under the License.
//---------------------------------------------------------------------------------


using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Net;
using System.Xml.Linq;
using System.Xml;

namespace SL.Phone.Federation.Utilities
{
    /// <summary>
    /// Contains the data returned in a RequestSecurityTokenResponse
    /// </summary>
    [DataContract]
    public class RequestSecurityTokenResponse
    {
        static string wsSecuritySecExtNamespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd";
        static string binarySecurityTokenName = "BinarySecurityToken";

        string _token = null;
        string _tokenType = null;
        long _tokenExpiration = 0;
        long _tokenCreated = 0;
        
        

        /// <summary>
        /// The raw string value of the security token contained in the RequestSecurityTokenResponse
        /// </summary>
        [DataMember]
        public string securityToken
        {
            get
            {
               return _token;
            }
            set
            {
                _token = value;
            }
        }

        /// <summary>
        /// The uri which uniquely identifies the type of token contained in the RequestSecurityTokenResponse
        /// </summary>
        [DataMember]
        public string tokenType
        {
            get
            {
                return _tokenType;
            }
            set
            {
                _tokenType = value;
            }
        }

        /// <summary>
        /// The expiration time of the token in the RequestSecurityTokenResponse
        /// </summary>
        [DataMember]
        public long expires
        {
            get
            {
                return _tokenExpiration;
            }
            set
            {
                _tokenExpiration = value;
            }
        }

        /// <summary>
        /// The creation time of the token in the RequestSecurityTokenResponse
        /// </summary>
        [DataMember]
        public long created
        {
            get
            {
                return _tokenCreated;
            }
            set
            {
                _tokenCreated = value;
            }
        }

        internal static RequestSecurityTokenResponse FromJSON(string jsonRequestSecurityTokenService)
        {
            RequestSecurityTokenResponse returnToken;

            MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(jsonRequestSecurityTokenService));
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(RequestSecurityTokenResponse));
            returnToken = serializer.ReadObject(memoryStream) as RequestSecurityTokenResponse;

            returnToken.securityToken = HttpUtility.HtmlDecode( returnToken.securityToken );

            using ( StringReader sr = new StringReader( returnToken.securityToken ) )
            {
                using ( XmlReader reader = XmlReader.Create( sr ) )
                {
                    
                    reader.MoveToContent();                    
                    string binaryToken = reader.ReadElementContentAsString( binarySecurityTokenName, wsSecuritySecExtNamespace );
                    byte[] tokenBytes = Convert.FromBase64String(binaryToken);
                    returnToken._token = Encoding.UTF8.GetString(tokenBytes, 0, tokenBytes.Length);
                    
                }
            }

            memoryStream.Close();

            return returnToken;
        }
    }
}
