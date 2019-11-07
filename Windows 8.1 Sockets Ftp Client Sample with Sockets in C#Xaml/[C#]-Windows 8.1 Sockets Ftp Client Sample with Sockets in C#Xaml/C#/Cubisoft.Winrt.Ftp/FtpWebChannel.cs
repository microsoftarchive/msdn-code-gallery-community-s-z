using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Networking;
using Cubisoft.Winrt.Ftp.Messages;

namespace Cubisoft.Winrt.Ftp
{
    public class FtpWebChannel : IFtpChannel
    {
        public HostName RemoteHost { get; set; }

        public NetworkCredential Credentials { get; set; }

        public Task<FtpFeaturesResponse> GetFeaturesAsync()
        {
            return ExecuteAsync<FtpFeaturesResponse>(new FtpFeaturesRequest());
        }

        public Task<FtpResponse> SetOptionsAsync(string option)
        {
            throw new NotImplementedException();
        }

        public Task<FtpResponse> SetDataTypeAsync(FtpDataType dataType)
        {
            throw new NotImplementedException();
        }

        public Task<FtpResponse> SetDirectoryAsync(string path)
        {
            throw new NotImplementedException();
        }

        public Task<FtpGetDirectoryResponse> GetDirectoryAsync()
        {
            throw new NotImplementedException();
        }

        public Task<FtpResponse> CreateDirectoryAsync(string path)
        {
            throw new NotImplementedException();
        }

        public Task<FtpResponse> DeleteDirectoryAsync(string path)
        {
            throw new NotImplementedException();
        }

        public Task<FtpResponse> DeleteFileAsync(string path)
        {
            throw new NotImplementedException();
        }

        public Task<FtpFileSizeResponse> GetFileSizeAsync(string path)
        {
            throw new NotImplementedException();
        }

        public Task<FtpModifiedTimeResponse> GetModifiedTimeAsync(string path)
        {
            return ExecuteAsync<FtpModifiedTimeResponse>(new FtpModifiedTimeRequest(path));
        }

        public Task<FtpGetListingResponse> GetListingAsync(string path = null)
        {
            throw new NotImplementedException();
        }

        public static string EncodeUrl(string url)
        {

            string encodedUrl = System.Net.WebUtility.UrlEncode(url);
            encodedUrl = encodedUrl.Replace("+", "%20").Replace("%2b", "+");
            return encodedUrl;
        }

        public async Task<T> ExecuteAsync<T>(FtpRequest request) where T : FtpResponse
        {

            var uri = string.Format("ftp://{0}{1}", RemoteHost.CanonicalName, EncodeUrl(request.Arguments[0].GetFtpPath())).Replace("%2F", "/");
            // This request is FtpWebRequest in fact.
            WebRequest webRequest = WebRequest.Create(new Uri(uri));

            if (Credentials != null)
            {
                webRequest.Credentials = Credentials;
            }

            webRequest.Proxy = WebRequest.DefaultWebProxy;

            // Set the method to Upload File
            webRequest.Method = request.CommandName;

            // Get response.
            using (WebResponse response = await webRequest.GetResponseAsync())
            {

                var dynamicType = (dynamic) response;

                var value = dynamicType.StatusDescription;
                var ftpType = response.GetType();

                var statusField = ftpType.GetRuntimeField("m_StatusLine");
                var statusDescriptionProp = ftpType.GetRuntimeProperty("StatusDescription");

                var statusDescription = statusDescriptionProp.GetValue(response) as string;

                return GetReply<T>(statusDescription);
            }
        }

        internal T GetReply<T>(string responseMessage) where T : FtpResponse
        {
            var reply = Activator.CreateInstance<T>();

            System.Diagnostics.Debug.WriteLine(responseMessage);

            Match m;

            if ((m = Regex.Match(responseMessage, "^(?<code>[0-9]{3}) (?<message>.*)$")).Success)
            {
                reply.Code = m.Groups["code"].Value;
                reply.Message = m.Groups["message"].Value;
            }

            reply.InfoMessages += string.Format("{0}\n", responseMessage);

            return reply;
        }

        /// <summary>
        /// Retreives a reply from the server. Do not execute this method
        /// unless you are sure that a reply has been sent, i.e., you
        /// executed a command. Doing so will cause the code to hang
        /// indefinitely waiting for a server reply that is never comming.
        /// </summary>
        /// <returns>FtpReply representing the response from the server</returns>
        internal async Task<T> GetReplyAsync<T>(Stream responseStream) where T : FtpResponse
        {
            var reply = Activator.CreateInstance<T>();


            string buf;

            using (var reader = new StreamReader(responseStream))
            {
                while ((buf = reader.ReadLine()) != null)
                {
                    Match m;


                    // TODO: Do this inside the response.
                    System.Diagnostics.Debug.WriteLine(buf);

                    if ((m = Regex.Match(buf, "^(?<code>[0-9]{3}) (?<message>.*)$")).Success)
                    {
                        reply.Code = m.Groups["code"].Value;
                        reply.Message = m.Groups["message"].Value;
                        break;
                    }

                    reply.InfoMessages += string.Format("{0}\n", buf);
                }
            }

            return reply;
        }
    }
}
