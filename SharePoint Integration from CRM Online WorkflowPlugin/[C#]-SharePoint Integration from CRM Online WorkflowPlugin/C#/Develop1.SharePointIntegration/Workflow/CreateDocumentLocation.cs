// <copyright file="CreateDocumentLocation.cs" company="">
// Copyright (c) 2014 All Rights Reserved
// </copyright>
// <author></author>
// <date>7/22/2014 7:18:46 PM</date>
// <summary>Implements the CreateDocumentLocation Workflow Activity.</summary>
namespace Develop1.Workflow.SharePoint
{
    using System;
    using System.Activities;
    using System.ServiceModel;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Workflow;
    using Microsoft.Xrm.Sdk.Client;
    using System.Linq;
    using Microsoft.Xrm.Sdk.Query;
   

    public sealed class CreateDocumentLocation : CodeActivity
    {

        [Input("Site")]
        [ReferenceTarget("sharepointsite")]
        [RequiredArgument]
        public InArgument<EntityReference> Site { get; set; }

        [Input("Record Dynamic Url")]
        [RequiredArgument]
        public InArgument<string> RecordUrl { get; set; }

        [Input("Document Library Name")]
        [RequiredArgument]
        public InArgument<string> DocumentLibraryName { get; set; }

        [Input("Record Folder Name")]
        [RequiredArgument]
        public InArgument<string> RecordFolderName { get; set; }

        [Output("Document Location Created")]
        [ReferenceTarget("sharepointdocumentlocation")]
        public OutArgument<EntityReference> DocumentLocation { get; set; }

        [Output("Document Folder Created")]
        public OutArgument<string> DocumentFolder { get; set; }
      
        /// <summary>
        /// Executes the workflow activity.
        /// </summary>
        /// <param name="executionContext">The execution context.</param>
        protected override void Execute(CodeActivityContext executionContext)
        {
            // Create the tracing service
            ITracingService tracingService = executionContext.GetExtension<ITracingService>();

            if (tracingService == null)
            {
                throw new InvalidPluginExecutionException("Failed to retrieve tracing service.");
            }

            tracingService.Trace("Entered CreateDocumentLocation.Execute(), Activity Instance Id: {0}, Workflow Instance Id: {1}",
                executionContext.ActivityInstanceId,
                executionContext.WorkflowInstanceId);

            // Create the context
            IWorkflowContext context = executionContext.GetExtension<IWorkflowContext>();

            if (context == null)
            {
                throw new InvalidPluginExecutionException("Failed to retrieve workflow context.");
            }

            tracingService.Trace("CreateDocumentLocation.Execute(), Correlation Id: {0}, Initiating User: {1}",
                context.CorrelationId,
                context.InitiatingUserId);

            IOrganizationServiceFactory serviceFactory = executionContext.GetExtension<IOrganizationServiceFactory>();
            IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);
            IOrganizationService privService = serviceFactory.CreateOrganizationService(null);

            try
            {
                var url = RecordUrl.Get<string>(executionContext);
                var recordRef = new DynamicUrlParser(url).ToEntityReference(privService);
                string config = GetSecureConfigValue(privService, "PrivSharePointUser"); ;
                string[] user = config.Split(';');

                // Create a new sharepoint service using the given priv sharepoint user credentials
                SPService spService = new SPService(user[0], user[1]);
                var docLocation = new DocumentLocationHelper(privService, spService);

                // Get the site passed into the workflow activity
                var siteId = Site.Get(executionContext);
                var site = (SharePointSite)service.Retrieve(SharePointSite.EntityLogicalName, siteId.Id, new ColumnSet("sharepointsiteid", "absoluteurl")); 

                if (site != null)
                {
                    // Set the name of the folder
                    recordRef.Name = RecordFolderName.Get<string>(executionContext);
                    var newLocation = docLocation.CreateDocumentLocation(site,DocumentLibraryName.Get(executionContext),recordRef);

                    DocumentLocation.Set(executionContext, newLocation.ToEntityReference());
                    DocumentFolder.Set(executionContext, newLocation.AbsoluteURL);
                }
                else
                    DocumentLocation.Set(executionContext, null);

            }
            catch (FaultException<OrganizationServiceFault> e)
            {
                tracingService.Trace("Exception: {0}", e.ToString());

                // Handle the exception.
                throw;
            }

            tracingService.Trace("Exiting CreateDocumentLocation.Execute(), Correlation Id: {0}", context.CorrelationId);
        }

        /// <summary>
        /// Get a config value - using your chosen technique!
        /// </summary>
        /// <param name="privService"></param>
        /// <param name="configName"></param>
        /// <returns></returns>
        private static string GetSecureConfigValue(IOrganizationService privService, string configName)
        {

           // TODO: Add you chosen method of storing secure config!
            switch (configName)
            {
                case "PrivSharePointUser":
                    // Username and password separated by ;
                    return "username;password";
                    
                default:
                    return null;
            }
        }
    }
}