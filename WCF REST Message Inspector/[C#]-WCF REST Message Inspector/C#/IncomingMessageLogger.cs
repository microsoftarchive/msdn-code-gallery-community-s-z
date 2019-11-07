using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading;
using System.Xml;

namespace InspectNonXmlMessages
{
    public class IncomingMessageLogger : IDispatchMessageInspector, IEndpointBehavior
    {
        const string MessageLogFolder = @"c:\temp\";
        static int messageLogFileIndex = 0;

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(this);
        }

        public void Validate(ServiceEndpoint endpoint)
        {
        }

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            string messageFileName = string.Format("{0}Log{1:000}_Incoming.txt", MessageLogFolder, Interlocked.Increment(ref messageLogFileIndex));
            Uri requestUri = request.Headers.To;
            using (StreamWriter sw = File.CreateText(messageFileName))
            {
                HttpRequestMessageProperty httpReq = (HttpRequestMessageProperty)request.Properties[HttpRequestMessageProperty.Name];

                sw.WriteLine("{0} {1}", httpReq.Method, requestUri);
                foreach (var header in httpReq.Headers.AllKeys)
                {
                    sw.WriteLine("{0}: {1}", header, httpReq.Headers[header]);
                }

                if (!request.IsEmpty)
                {
                    sw.WriteLine();
                    sw.WriteLine(this.MessageToString(ref request));
                }
            }

            return requestUri;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            string messageFileName = string.Format("{0}Log{1:000}_Outgoing.txt", MessageLogFolder, Interlocked.Increment(ref messageLogFileIndex));

            using (StreamWriter sw = File.CreateText(messageFileName))
            {
                sw.WriteLine("Response to request to {0}:", (Uri)correlationState);
                HttpResponseMessageProperty httpResp = (HttpResponseMessageProperty)reply.Properties[HttpResponseMessageProperty.Name];
                sw.WriteLine("{0} {1}", (int)httpResp.StatusCode, httpResp.StatusCode);

                if (!reply.IsEmpty)
                {
                    sw.WriteLine();
                    sw.WriteLine(this.MessageToString(ref reply));
                }
            }
        }

        private WebContentFormat GetMessageContentFormat(Message message)
        {
            WebContentFormat format = WebContentFormat.Default;
            if (message.Properties.ContainsKey(WebBodyFormatMessageProperty.Name))
            {
                WebBodyFormatMessageProperty bodyFormat;
                bodyFormat = (WebBodyFormatMessageProperty)message.Properties[WebBodyFormatMessageProperty.Name];
                format = bodyFormat.Format;
            }

            return format;
        }

        private string MessageToString(ref Message message)
        {
            WebContentFormat messageFormat = this.GetMessageContentFormat(message);
            MemoryStream ms = new MemoryStream();
            XmlDictionaryWriter writer = null;
            switch (messageFormat)
            {
                case WebContentFormat.Default:
                case WebContentFormat.Xml:
                    writer = XmlDictionaryWriter.CreateTextWriter(ms);
                    break;
                case WebContentFormat.Json:
                    writer = JsonReaderWriterFactory.CreateJsonWriter(ms);
                    break;
                case WebContentFormat.Raw:
                    // special case for raw, easier implemented separately
                    return this.ReadRawBody(ref message);
            }

            message.WriteMessage(writer);
            writer.Flush();
            string messageBody = Encoding.UTF8.GetString(ms.ToArray());

            // Here would be a good place to change the message body, if so desired.

            // now that the message was read, it needs to be recreated.
            ms.Position = 0;

            // if the message body was modified, needs to reencode it, as show below
            // ms = new MemoryStream(Encoding.UTF8.GetBytes(messageBody));

            XmlDictionaryReader reader;
            if (messageFormat == WebContentFormat.Json)
            {
                reader = JsonReaderWriterFactory.CreateJsonReader(ms, XmlDictionaryReaderQuotas.Max);
            }
            else
            {
                reader = XmlDictionaryReader.CreateTextReader(ms, XmlDictionaryReaderQuotas.Max);
            }

            Message newMessage = Message.CreateMessage(reader, int.MaxValue, message.Version);
            newMessage.Properties.CopyProperties(message.Properties);
            message = newMessage;

            return messageBody;
        }

        private string ReadRawBody(ref Message message)
        {
            XmlDictionaryReader bodyReader = message.GetReaderAtBodyContents();
            bodyReader.ReadStartElement("Binary");
            byte[] bodyBytes = bodyReader.ReadContentAsBase64();
            string messageBody = Encoding.UTF8.GetString(bodyBytes);

            // Now to recreate the message
            MemoryStream ms = new MemoryStream();
            XmlDictionaryWriter writer = XmlDictionaryWriter.CreateBinaryWriter(ms);
            writer.WriteStartElement("Binary");
            writer.WriteBase64(bodyBytes, 0, bodyBytes.Length);
            writer.WriteEndElement();
            writer.Flush();
            ms.Position = 0;
            XmlDictionaryReader reader = XmlDictionaryReader.CreateBinaryReader(ms, XmlDictionaryReaderQuotas.Max);
            Message newMessage = Message.CreateMessage(reader, int.MaxValue, message.Version);
            newMessage.Properties.CopyProperties(message.Properties);
            message = newMessage;

            return messageBody;
        }
    }
}
