using Microsoft.IdentityModel.S2S.Protocols.OAuth2;
using Newtonsoft.Json.Linq;
using SPAPI_SAMPLE_CODE.Authentication;
using SPAPI_SAMPLE_CODE.Objects;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace SPAPI_SAMPLE_CODE.Repository {
    public class SPAPIHandler {

        private string contenttype = "application/json;odata=verbose";

        private string acceptHeader = "application/json;odata=verbose";

        /// <summary>
        /// Gets or sets the client identifier.
        /// </summary>
        /// <value>
        /// The client identifier.
        /// </value>
        private string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the client secret.
        /// </summary>
        /// <value>
        /// The client secret.
        /// </value>
        private string ClientSecret { get; set; }

        public SPAPIHandler(string clientId, string clientSecret) {
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        public string Get(string url) {
            var accessToken = GetAccessTokenResponse(url);

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "GET";
            request.Accept = acceptHeader;
            request.Headers.Add("Authorization", accessToken.TokenType + " " + accessToken.AccessToken);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();


            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NoContent) {
                using (var reader = new System.IO.StreamReader(response.GetResponseStream())) {
                    return reader.ReadToEnd();
                }
            }

            return null;
        }

        public string Post(string url) {
            var accessToken = GetAccessTokenResponse(url);

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "POST";
            request.ContentLength = 0;
            request.Accept = acceptHeader;
            request.Headers.Add("Authorization", accessToken.TokenType + " " + accessToken.AccessToken);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();


            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NoContent) {
                using (var reader = new System.IO.StreamReader(response.GetResponseStream())) {
                    return reader.ReadToEnd();
                }
            }

            return (null);
        }

        public string Merge(string url, Document doc) {

            var accessToken = GetAccessTokenResponse(url);

            var postData = new JObject {
                ["__metadata"] = new JObject { ["type"] = "SP.File" }
            };

            foreach(string key in doc.MetaData.Keys) {
                postData.Add(key, doc.MetaData[key]);
            }

            byte[] listPostData = Encoding.ASCII.GetBytes(postData.ToString());

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "POST";
            request.ContentLength = postData.ToString().Length;
            request.ContentType = contenttype;
            request.Accept = acceptHeader;
            request.Headers.Add("Authorization", accessToken.TokenType + " " + accessToken.AccessToken);
            request.Headers.Add("If-Match", "*");
            request.Headers.Add("X-Http-Method", "MERGE");

            Stream listRequestStream = request.GetRequestStream();
            listRequestStream.Write(listPostData, 0, listPostData.Length);
            listRequestStream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();


            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NoContent) {
                using (var reader = new System.IO.StreamReader(response.GetResponseStream())) {
                 return reader.ReadToEnd();
                }
            }

            return null;
        }

        public string PostDocument(string url, byte[] document) {
            var accessToken = GetAccessTokenResponse(url);

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "POST";
            request.ContentLength = document.Length;
            request.ContentType = contenttype;
            request.Accept = acceptHeader;
            request.Headers.Add("Authorization", accessToken.TokenType + " " + accessToken.AccessToken);

            Stream listRequestStream = request.GetRequestStream();
            listRequestStream.Write(document, 0, document.Length);
            listRequestStream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();


            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NoContent) {
                using (var reader = new System.IO.StreamReader(response.GetResponseStream())) {
                    return reader.ReadToEnd();
                }
            }

            return (null);
        }


        private OAuth2AccessTokenResponse GetAccessTokenResponse(string url) {
            Uri targetWeb = new Uri(url);
            string targetRealm = TokenHelper.GetRealmFromTargetUrl(targetWeb);
            var responseToken = TokenHelper.GetAppOnlyAccessToken(TokenHelper.SharePointPrincipal, targetWeb.Authority, targetRealm, ClientId, ClientSecret);

            return responseToken;
        }
    }
}
