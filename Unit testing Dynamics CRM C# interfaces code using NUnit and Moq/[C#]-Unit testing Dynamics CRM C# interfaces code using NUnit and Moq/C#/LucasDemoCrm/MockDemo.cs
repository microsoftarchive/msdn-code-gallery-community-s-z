using System;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Messages;

namespace LucasDemoCrm
{
    /// <summary>
    /// This class holds the interface business logic we want to test
    /// </summary>
    public class MockDemo
    {
        /// <summary>
        /// Creates a new account with a given name using the supplied organization service
        /// </summary>
        /// <param name="accountName">account name</param>
        /// <param name="service">organization service</param>
        /// <returns>id of the new account</returns>
        public static Guid CreateCrmAccount(string accountName, IOrganizationService service)
        {
            Entity account = new Entity("account");
            account["name"] = accountName;
            Guid newId = service.Create(account);
            return newId;
        }

        /// <summary>
        /// Creates a new account with a given name and then creates a follow-up task linked to the account
        /// </summary>
        /// <param name="accountName">account name</param>
        /// <param name="service">organization service</param>
        public static void CreateCrmAccount2(string accountName, IOrganizationService service)
        {
            //create the account
            Entity account = new Entity("account");
            account["name"] = accountName;
            Guid newId = service.Create(account);

            //get the account number
            account = service.Retrieve("account", newId, new Microsoft.Xrm.Sdk.Query.ColumnSet(new string[] { "name", "accountid", "accountnumber" }));
            string accountNumber = account["accountnumber"].ToString();

            //create the task
            Entity task = new Entity("task");
            task["subject"] = "Finish account set up for " + accountName + " - " + accountNumber;
            task["regardingobjectid"] = new Microsoft.Xrm.Sdk.EntityReference("account", newId);
            service.Create(task);
        }

        /// <summary>
        /// Returns the number of options for a picklist
        /// </summary>
        /// <param name="entityName">name of the entity</param>
        /// <param name="picklistName">name of the picklist</param>
        /// <param name="service">CRM service</param>
        /// <returns>integer count</returns>
        public static int GetPicklistOptionCount(string entityName, string picklistName, IOrganizationService service)
        {
            RetrieveAttributeRequest retrieveAttributeRequest = new RetrieveAttributeRequest
            {
                EntityLogicalName = entityName,
                LogicalName = picklistName,
                RetrieveAsIfPublished = true
            };

            // Execute the request.
            RetrieveAttributeResponseWrapper retrieveAttributeResponse = (new RetrieveAttributeResponseWrapper(service.Execute(retrieveAttributeRequest))); //this is the only change from before
            // Access the retrieved attribute.

            PicklistAttributeMetadata retrievedPicklistAttributeMetadata = (PicklistAttributeMetadata)retrieveAttributeResponse.AttributeMetadata;
            OptionMetadata[] optionList = retrievedPicklistAttributeMetadata.OptionSet.Options.ToArray();
            return optionList.Length;
        }

    }
}