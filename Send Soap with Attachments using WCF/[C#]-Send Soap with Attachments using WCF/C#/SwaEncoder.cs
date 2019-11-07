using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Channels;
using WcfHelpers.SoapWithAttachments.Mime;
using System.Diagnostics;
using System.ServiceModel;
using System.IO;
using System.Xml;
using System.ServiceModel.Web;

namespace WcfHelpers.SoapWithAttachments
{
    public class SwaEncoder : MessageEncoder
    {
        private string _ContentType;
        private string _MediaType;

        protected MimeContent _MyContent;
        protected MimePart _SoapMimeContent;
        protected MimePart _AttachmentMimeContent;

        protected readonly MimeParser _MimeParser;
        protected readonly SwaEncoderFactory _Factory;
        protected readonly MessageEncoder _InnerEncoder;

        public SwaEncoder(MessageEncoder innerEncoder, SwaEncoderFactory factory, string attachmentContentType)
        {
            //
            // Initialize general fields
            //
            _ContentType = "multipart/related";
            _MediaType = _ContentType;

            //
            // Create owned objects
            //
            _Factory = factory;
            _InnerEncoder = innerEncoder;
            _MimeParser = new MimeParser();

            //
            // Create object for the mime content message
            // 
            _SoapMimeContent = new MimePart()
            {
                ContentType = "text/xml",
                ContentId = "<EFD659EE6BD5F31EA7BC0D59403AF049>",   // TODO: make content id dynamic or configurable?
                CharSet = "UTF-8",                                  // TODO: make charset configurable?
                TransferEncoding = "binary"                         // TODO: make transfer-encoding configurable?
            };
            _AttachmentMimeContent = new MimePart()
            {
                ContentType = attachmentContentType,
                ContentId = "<UZE_26123_>",                         // TODO: AttachmentMimeContent.ContentId configurable/dynamic?
                TransferEncoding = "binary"                         // TODO: AttachmentMimeContent.TransferEncoding dynamic/configurable?
            };
            _MyContent = new MimeContent()
            {
                Boundary = "------=_Part_0_21714745.1249640163820"  // TODO: MimeContent.Boundary configurable/dynamic?
            };
            _MyContent.Parts.Add(_SoapMimeContent);
            _MyContent.Parts.Add(_AttachmentMimeContent);
            _MyContent.SetAsStartPart(_SoapMimeContent);
        }

        public override string ContentType
        {
            get
            {
                VerifyOperationContext();

                if (OperationContext.Current.OutgoingMessageProperties.ContainsKey(SwaEncoderConstants.AttachmentProperty))
                    return _MyContent.ContentType;
                else
                    return _InnerEncoder.ContentType;
            }
        }

        public override string MediaType
        {
            get { return _MediaType; }
        }

        public override MessageVersion MessageVersion
        {
            get { return MessageVersion.Soap11; }
        }

        public override bool IsContentTypeSupported(string contentType)
        {
            if (contentType.ToLower().StartsWith("multipart/related"))
                return true;
            else if (contentType.ToLower().StartsWith("text/xml"))
                return true;
            else
                return false;
        }

        public override Message ReadMessage(ArraySegment<byte> buffer, BufferManager bufferManager, string contentType)
        {
            VerifyOperationContext();

            //
            // Verify the content type
            //
            byte[] MsgContents = new byte[buffer.Count];
            Array.Copy(buffer.Array, buffer.Offset, MsgContents, 0, MsgContents.Length);
            bufferManager.ReturnBuffer(buffer.Array);

            // Debug code
#if DEBUG
            string Contents = Encoding.UTF8.GetString(MsgContents);
            Debug.WriteLine("-------------------");
            Debug.WriteLine(Contents);
            Debug.WriteLine("-------------------");
#endif

            MemoryStream ms = new MemoryStream(MsgContents);
            return ReadMessage(ms, int.MaxValue, contentType);
        }

        public override Message ReadMessage(System.IO.Stream stream, int maxSizeOfHeaders, string contentType)
        {
            VerifyOperationContext();

            if (contentType.ToLower().StartsWith("multipart/related"))
            {
                byte[] ContentBytes = new byte[stream.Length];
                stream.Read(ContentBytes, 0, ContentBytes.Length);
                MimeContent Content = _MimeParser.DeserializeMimeContent(contentType, ContentBytes);

                if (Content.Parts.Count >= 2)
                {
                    MemoryStream ms = new MemoryStream(Content.Parts[0].Content);
                    Message Msg = ReadMessage(ms, int.MaxValue, Content.Parts[0].ContentType);
                    Msg.Properties.Add(SwaEncoderConstants.AttachmentProperty, Content.Parts[1].Content);
                    return Msg;
                }
                else
                {
                    throw new ApplicationException("Invalid mime message sent! Soap with attachments makes sense, only, with at least 2 mime message content parts!");
                }
            }
            else if (contentType.ToLower().StartsWith("text/xml"))
            {
                XmlReader Reader = XmlReader.Create(stream);
                return Message.CreateMessage(Reader, maxSizeOfHeaders, MessageVersion);
            }
            else
            {
                throw new ApplicationException(
                    string.Format(
                        "Invalid content type for reading message: {0}! Supported content types are multipart/related and text/xml!",
                        contentType));
            }
        }

        public override void WriteMessage(Message message, System.IO.Stream stream)
        {
            VerifyOperationContext();

            message.Properties.Encoder = this._InnerEncoder;

            byte[] Attachment = null;
            if (OperationContext.Current.OutgoingMessageProperties.ContainsKey(SwaEncoderConstants.AttachmentProperty))
                Attachment = (byte[])OperationContext.Current.OutgoingMessageProperties[SwaEncoderConstants.AttachmentProperty];

            if (Attachment == null)
            {
                _InnerEncoder.WriteMessage(message, stream);
            }
            else
            {
                // Associate the contents to the mime-part
                _SoapMimeContent.Content = Encoding.UTF8.GetBytes(message.GetBody<string>());
                _AttachmentMimeContent.Content = (byte[])OperationContext.Current.OutgoingMessageProperties[SwaEncoderConstants.AttachmentProperty];

                // Now create the message content for the stream
                _MimeParser.SerializeMimeContent(_MyContent, stream);
            }
        }

        public override ArraySegment<byte> WriteMessage(Message message, int maxMessageSize, BufferManager bufferManager, int messageOffset)
        {
            VerifyOperationContext();

            message.Properties.Encoder = this._InnerEncoder;

            byte[] Attachment = null;
            if (OperationContext.Current.OutgoingMessageProperties.ContainsKey(SwaEncoderConstants.AttachmentProperty))
                Attachment = (byte[])OperationContext.Current.OutgoingMessageProperties[SwaEncoderConstants.AttachmentProperty];

            if (Attachment == null)
            {
                return _InnerEncoder.WriteMessage(message, maxMessageSize, bufferManager, messageOffset);
            }
            else
            {
                // Associate the contents to the mime-part
                _SoapMimeContent.Content = Encoding.UTF8.GetBytes(message.ToString());
                _AttachmentMimeContent.Content = (byte[])OperationContext.Current.OutgoingMessageProperties[SwaEncoderConstants.AttachmentProperty];

                // Now create the message content for the stream
                byte[] MimeContentBytes = _MimeParser.SerializeMimeContent(_MyContent);
                int MimeContentLength = MimeContentBytes.Length;

                // Write the mime content into the section of the buffer passed into the method
                byte[] TargetBuffer = bufferManager.TakeBuffer(MimeContentLength + messageOffset);
                Array.Copy(MimeContentBytes, 0, TargetBuffer, messageOffset, MimeContentLength);

                // Return the segment of the buffer to the framework
                return new ArraySegment<byte>(TargetBuffer, messageOffset, MimeContentLength);
            }
        }

        private void VerifyOperationContext()
        {
            if (OperationContext.Current == null)
            {
                throw new ApplicationException
                (
                    "No current OperationContext available! On clients please use OperationScope as follows to establish " +
                    "an operation context: " + Environment.NewLine + Environment.NewLine +
                    "using(OperationScope Scope = new OperationScope(YourProxy.InnerChannel) { YouProxy.MethodCall(...); }"
                );
            }
            else if (OperationContext.Current.OutgoingMessageProperties.ContainsKey(SwaEncoderConstants.AttachmentProperty))
            {
                if (OperationContext.Current.OutgoingMessageProperties[SwaEncoderConstants.AttachmentProperty] != null)
                {
                    if (!(OperationContext.Current.OutgoingMessageProperties[SwaEncoderConstants.AttachmentProperty] is byte[]))
                    {
                        throw new ArgumentException(string.Format(
                            "OperationContext.Current.OutgoingMessageProperties[\"{0}\"] needs to be a byte[] array with the attachment content!",
                                SwaEncoderConstants.AttachmentProperty));
                    }
                }
            }
        }
    }
}
