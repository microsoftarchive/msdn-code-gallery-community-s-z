using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Configuration;
using System.Configuration;
using System.ServiceModel.Channels;

namespace WcfHelpers.SoapWithAttachments
{
    public class SwaMessageEncodingElement : BindingElementExtensionElement
    {
        [ConfigurationProperty("innerMessageEncoding", DefaultValue = "textMessageEncoding")]
        public string InnerMessageEncoding 
        {
            get { return (string)base["innerMessageEncoding"]; }
            set { base["innerMessageEncoding"] = value; } 
        }

        [ConfigurationProperty("attachmentContentType", DefaultValue = "application/zip")]
        public string AttachmentContentType
        {
            get { return (string)base["attachmentContentType"]; }
            set { base["attachmentContentType"] = value; }
        }

        public override Type BindingElementType
        {
            get { return typeof(SwaEncodingBindingElement); }
        }

        public override void ApplyConfiguration(System.ServiceModel.Channels.BindingElement bindingElement)
        {
            // Base configuration
            base.ApplyConfiguration(bindingElement);

            // Now process the own configuration
            SwaEncodingBindingElement Binding = (SwaEncodingBindingElement)bindingElement;

            PropertyInformationCollection PropertyInfos = ElementInformation.Properties;
            if (PropertyInfos["innerMessageEncoding"].ValueOrigin != PropertyValueOrigin.Default)
            {
                switch (this.InnerMessageEncoding)
                {
                    case "textMessageEncoding":
                        Binding.InnerBindingElement = new TextMessageEncodingBindingElement();
                        break;
                    case "binaryMessageEncoding":
                        Binding.InnerBindingElement = new BinaryMessageEncodingBindingElement();
                        break;
                    default:
                        throw new ConfigurationErrorsException("Inner message encoding can be binary or text, only!");
                }
            }

            Binding.AttachmentContentType = AttachmentContentType;
        }

        protected override System.ServiceModel.Channels.BindingElement CreateBindingElement()
        {
            SwaEncodingBindingElement BindingElement = new SwaEncodingBindingElement();
            ApplyConfiguration(BindingElement);
            return BindingElement;
        }
    }
}
