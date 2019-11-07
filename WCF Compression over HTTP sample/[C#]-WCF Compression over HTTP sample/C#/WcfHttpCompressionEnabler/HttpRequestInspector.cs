using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Channels;
using System.ServiceModel;
using System.Net;
using System.ServiceModel.Configuration;
using System.ServiceModel.Dispatcher;

namespace WcfHttpCompressionEnabler
{
    public class HttpRequestInspector : IClientMessageInspector
    {        
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            var buffer = request.CreateBufferedCopy(Int32.MaxValue);
            var tempRequest = buffer.CreateMessage();
            

            HttpRequestMessageProperty httpRequest = GetHttpRequestProp(tempRequest);
            if (httpRequest != null)
            {
                if (string.IsNullOrEmpty(httpRequest.Headers[HttpRequestHeader.AcceptEncoding]))
                {
                    //httpRequest.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
                }

            }

            request = tempRequest;
            request.Properties[HttpRequestMessageProperty.Name] = httpRequest;

            return null;
        }

        private static HttpRequestMessageProperty GetHttpRequestProp(Message request)
        {
            if (!request.Properties.ContainsKey(HttpRequestMessageProperty.Name))
            {
                request.Properties.Add(HttpRequestMessageProperty.Name, new HttpRequestMessageProperty());
            }

            return request.Properties[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty;
        }

        #region IClientMessageInspector Members

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            
        }

        #endregion
    }
}
