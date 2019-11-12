using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Channels;
using System.Xml;

namespace WcfHelpers.SoapWithAttachments
{
    public class SwaEncodingBindingElement : MessageEncodingBindingElement
    {
        private XmlDictionaryReaderQuotas _ReaderQuotas;

        public SwaEncodingBindingElement()
            : this(new TextMessageEncodingBindingElement(), string.Empty)
        {
            _ReaderQuotas = new XmlDictionaryReaderQuotas();
        }

        public SwaEncodingBindingElement(MessageEncodingBindingElement innerBindingElement, string attachmentContentType)
        {
            AttachmentContentType = attachmentContentType;
            innerBindingElement.MessageVersion = MessageVersion.Soap11;
            if (innerBindingElement == null)
            {
                throw new ArgumentNullException("innerBindingElement",
                    "The inner binding element cannot be null, please specify a valid binding element!");
            }
            else
            {
                InnerBindingElement = innerBindingElement;
            }
        }

        public MessageEncodingBindingElement InnerBindingElement 
        { 
            get; 
            set; 
        }

        public override MessageVersion MessageVersion
        {
            get
            {
                return InnerBindingElement.MessageVersion;
            }
            set
            {
                InnerBindingElement.MessageVersion = value;
            }
        }

        public XmlDictionaryReaderQuotas ReaderQuotas
        {
            get
            {
                return _ReaderQuotas;
            }
        }

        public override BindingElement Clone()
        {
            return new SwaEncodingBindingElement(InnerBindingElement, AttachmentContentType);
        }

        public override MessageEncoderFactory CreateMessageEncoderFactory()
        {
            return new SwaEncoderFactory(InnerBindingElement.CreateMessageEncoderFactory(), AttachmentContentType);
        }

        public override IChannelFactory<TChannel> BuildChannelFactory<TChannel>(BindingContext context)
        {
            if (context == null)
                throw new ArgumentException("context", "Context cannot be null, please pass a BindingContext!");

            context.BindingParameters.Add(this);
            return base.BuildChannelFactory<TChannel>(context);
        }

        public override bool CanBuildChannelFactory<TChannel>(BindingContext context)
        {
            if (context == null)
                throw new ArgumentException("context", "Context cannot be null, please pass a BindingContext!");

            return context.CanBuildInnerChannelFactory<TChannel>();
        }

        public override IChannelListener<TChannel> BuildChannelListener<TChannel>(BindingContext context)
        {
            if (context == null)
                throw new ArgumentException("context", "Context cannot be null, please pass a BindingContext!");

            context.BindingParameters.Add(this);
            return base.BuildChannelListener<TChannel>(context);
        }

        public override bool CanBuildChannelListener<TChannel>(BindingContext context)
        {
            if (context == null)
                throw new ArgumentException("context", "Context cannot be null, please pass a BindingContext!");

            context.BindingParameters.Add(this);
            return base.CanBuildChannelListener<TChannel>(context);
        }

        public override T GetProperty<T>(BindingContext context)
        {
            if (typeof(T) == typeof(XmlDictionaryReaderQuotas))
            {
                return (T)(object)this.ReaderQuotas;
            }
            else
            {
                return base.GetProperty<T>(context);
            }
        }

        public string AttachmentContentType { get; set; }
    }
}
