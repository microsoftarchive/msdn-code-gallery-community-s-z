using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Channels;

namespace WcfHelpers.SoapWithAttachments
{
    public class SwaEncoderFactory : MessageEncoderFactory
    {
        protected readonly SwaEncoder _Encoder;

        public override MessageEncoder Encoder
        {
            get { return _Encoder; }
        }

        public override MessageVersion MessageVersion
        {
            get { return _Encoder.MessageVersion; }
        }

        public SwaEncoderFactory(MessageEncoderFactory encoderFactory, string attachmentContentType)
        {
            if (encoderFactory == null)
            {
                throw new ArgumentNullException("encoderFactory",
                    "You need to pass an inner encoder to the SwaEncoderFactory to support SOAP-message processing!");
            }
            else if (string.IsNullOrEmpty(attachmentContentType) || attachmentContentType.Trim().Equals(string.Empty))
            {
                throw new ArgumentException("attachmentContentType",
                    "You need to pass an attachment content type to the SwaEncoderFactory!");
            }
            else
            {
                _Encoder = new SwaEncoder(encoderFactory.Encoder, this, attachmentContentType);
            }
        }

        public override MessageEncoder CreateSessionEncoder()
        {
            return base.CreateSessionEncoder();
        }
    }
}
