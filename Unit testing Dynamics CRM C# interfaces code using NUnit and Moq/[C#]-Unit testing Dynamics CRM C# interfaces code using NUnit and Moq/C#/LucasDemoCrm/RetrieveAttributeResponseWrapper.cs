using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Messages;
using System.Runtime.Serialization;

namespace LucasDemoCrm
{
    /// <summary>
    /// Wrapper class for the Xrm.Sdk.Messages.RetrieveAttributeResponse class. Primarily used to support Moq injection during testing.
    /// </summary>
    [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
    public class RetrieveAttributeResponseWrapper : OrganizationResponse
    {
        /// <summary>
        /// private field to hold the RetrieveAttributeResponse AttributeMetadata
        /// </summary>
        private AttributeMetadata _metadata;

        /// <summary>
        /// constructor for the wrapper
        /// </summary>
        /// <param name="response">accepts an object that derives from the OrganizationResponse class</param>
        public RetrieveAttributeResponseWrapper(OrganizationResponse response)
        {

            try
            {
                _metadata = ((RetrieveAttributeResponseWrapper)response).AttributeMetadata;
            }
            catch
            {
                _metadata = ((RetrieveAttributeResponse)response).AttributeMetadata;
            }
        }

        /// <summary>
        /// property to access the RetrieveAttributeResponse AttributeMetadata
        /// </summary>
        public AttributeMetadata AttributeMetadata
        {
            get
            {
                return _metadata;
            }
            set
            {
                _metadata = value;
            }
        }
    }
}
