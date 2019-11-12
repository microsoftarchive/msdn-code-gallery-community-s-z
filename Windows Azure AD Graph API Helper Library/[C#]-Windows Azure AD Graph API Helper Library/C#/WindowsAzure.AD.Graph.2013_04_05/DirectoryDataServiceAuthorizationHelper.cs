using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Web;

namespace Microsoft.WindowsAzure.ActiveDirectory.GraphHelper
{
    /// <summary>
    /// Helper class to fetch tokens from AAD for talking to AAD Graph Service.
    /// </summary>
    public static class DirectoryDataServiceAuthorizationHelper
    {
        /// <summary>
        /// Function for getting a token from ACS using Application Service principal Id and Password.
        /// </summary>
        public static AADJWTToken GetAuthorizationToken(string tenantName, string appPrincipalId, string password)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format(StringConstants.AzureADSTSURL, tenantName));
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            string postData = "grant_type=client_credentials";            
            postData += "&resource=" + HttpUtility.UrlEncode(StringConstants.GraphPrincipalId);
            postData += "&client_id=" + HttpUtility.UrlEncode(appPrincipalId);
            postData += "&client_secret=" + HttpUtility.UrlEncode(password);
            byte[] data = encoding.GetBytes(postData);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            using (var response = request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(AADJWTToken));
                    AADJWTToken token = (AADJWTToken)(ser.ReadObject(stream));
                    return token;
                }
            }
        }
    }
} 