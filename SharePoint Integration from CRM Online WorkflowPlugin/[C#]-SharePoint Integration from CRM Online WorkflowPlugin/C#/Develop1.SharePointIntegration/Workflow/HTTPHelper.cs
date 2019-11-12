using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Develop1.Workflow;


namespace Develop1
{
   
    public static class HttpHelper
    {
        /// <summary>
        /// Sends a JSON OData request appending SPO auth cookies to the request header.
        /// </summary>
        /// <param name="uri">The request uri</param>
        /// <param name="method">The http method</param>
        /// <param name="requestContent">A stream containing the request content</param>
        /// <param name="clientHandler">The request client handler</param>
        /// <param name="authUtility">An instance of the auth helper to perform authenticated calls to SPO</param>
        /// <param name="headers">The http headers to append to the request</param>
        public static byte[] SendODataJsonRequest(Uri uri, String method, byte[] requestContent, HttpWebRequest clientHandler, SpoAuthUtility authUtility, Dictionary<string, string> headers = null)
        {
            if (clientHandler.CookieContainer == null)
                clientHandler.CookieContainer = new CookieContainer();

            CookieContainer cookieContainer = authUtility.GetCookieContainer(); // get the auth cookies from SPO after authenticating with Microsoft Online Services STS

            foreach (Cookie c in cookieContainer.GetCookies(uri))
            {
                clientHandler.CookieContainer.Add(uri, c); // apppend SPO auth cookies to the request
            }

            return SendHttpRequest(
                uri,
                method,
                requestContent,
                "application/json;odata=verbose;charset=utf-8", // the http content type for the JSON flavor of SP REST services 
                clientHandler,
                headers);
        }


        /// <summary>
        /// Sends an http request to the specified uri and returns the response as a byte array 
        /// </summary>
        /// <param name="uri">The request uri</param>
        /// <param name="method">The http method</param>
        /// <param name="requestContent">A stream containing the request content</param>
        /// <param name="contentType">The content type of the http request</param>
        /// <param name="clientHandler">The request client handler</param>
        /// <param name="headers">The http headers to append to the request</param>
        public static byte[] SendHttpRequest(Uri uri, String method, byte[] requestContent = null, string contentType = null, HttpWebRequest clientHandler = null, Dictionary<string, string> headers = null)
        {
            HttpWebRequest request = clientHandler == null ?  (HttpWebRequest)HttpWebRequest.Create(uri): clientHandler;

            byte[] responseStream;


            request.Method = method;
            request.Accept = contentType;
            request.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)"; // This must be here as you will receive 403 otherwise
            request.AllowAutoRedirect = false; // This is key, otherwise it will redirect to failed login SP page
            
            // append additional headers to the request
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    if (request.Headers.AllKeys.Contains(header.Key))
                    {
                        request.Headers.Remove(header.Key);
                    }

                    request.Headers.Add(header.Key, header.Value);
                }
            }


            if (requestContent != null && (method == "POST" || method == "PUT" || method == "DELETE"))
            {
                if (!string.IsNullOrEmpty(contentType))
                {
                    request.ContentType = contentType; // if the request has a body set the MIME type
                }

                request.ContentLength = requestContent.Length;
                using (Stream s = request.GetRequestStream())
                {
                    s.Write(requestContent, 0, requestContent.Length);
                    s.Close();

                }
            }
            
            // Not using Using here as you may still like to access the reponse outside of this method
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8"));
            responseStream = Encoding.UTF8.GetBytes(sr.ReadToEnd());
            
            return responseStream;
        }


       

    }
}