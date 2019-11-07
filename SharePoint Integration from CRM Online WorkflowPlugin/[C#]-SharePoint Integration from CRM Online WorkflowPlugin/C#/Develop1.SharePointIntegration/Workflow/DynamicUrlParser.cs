
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata.Query;
using Microsoft.Xrm.Sdk.Query;
using System;
namespace Develop1.Workflow
{
    /// <summary> 
    /// Used to parse the Dynamics CRM 'Record Url (Dynamic)' that can be created by workflows and dialogs 
    /// </summary> 
    public class DynamicUrlParser
    {
        public string Url { get; set; }
        public int? EntityTypeCode { get; set; }
        public Guid? Id { get; set; }

        /// <summary> 
        /// Parse the dynamic url in constructor 
        /// </summary> 
        /// <param name="url"></param> 
        public DynamicUrlParser(string url)
        {
            if (url==null)
            {
                Id = null;
                EntityTypeCode = null;
                return;
            }
            try
            {
                Url = url;
                var uri = new Uri(url);
                int found = 0;

                string[] parameters = uri.Query.TrimStart('?').Split('&');
                foreach (string param in parameters)
                {
                    var nameValue = param.Split('=');
                    switch (nameValue[0])
                    {
                        case "etc":
                            EntityTypeCode = int.Parse(nameValue[1]);
                            found++;
                            break;
                        case "id":
                            Id = new Guid(nameValue[1]);
                            found++;
                            break;
                    }
                    if (found > 1) break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Url '{0}' is incorrectly formated for a Dynamics CRM Dynamics Url", url), ex);
            }
        }

        /// <summary> 
        /// Find the Logical Name from the entity type code - this needs a reference to the Organization Service to look up metadata 
        /// </summary> 
        /// <param name="service"></param> 
        /// <returns></returns> 
        public string GetEntityLogicalName(IOrganizationService service)
        {
            var entityFilter = new MetadataFilterExpression(LogicalOperator.And);
            entityFilter.Conditions.Add(new MetadataConditionExpression("ObjectTypeCode ", MetadataConditionOperator.Equals, this.EntityTypeCode));
            var propertyExpression = new MetadataPropertiesExpression { AllProperties = false };
            propertyExpression.PropertyNames.Add("LogicalName");
            var entityQueryExpression = new EntityQueryExpression()
            {
                Criteria = entityFilter,
                Properties = propertyExpression
            };

            var retrieveMetadataChangesRequest = new RetrieveMetadataChangesRequest()
            {
                Query = entityQueryExpression
            };

            var response = (RetrieveMetadataChangesResponse)service.Execute(retrieveMetadataChangesRequest);

            if (response.EntityMetadata.Count == 1)
            {
                return response.EntityMetadata[0].LogicalName;
            }
            return null;
        }

        public EntityReference ToEntityReference(IOrganizationService service)
        {
            return new EntityReference(this.GetEntityLogicalName(service), this.Id.Value);
        }
    } 
}