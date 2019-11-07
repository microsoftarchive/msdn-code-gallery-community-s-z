using System;
using System.Activities;
using System.ServiceModel;
using System.Globalization;
using System.Runtime.Serialization;
using System.IO;
using System.Text;
using System.Net;
using Microsoft.Xrm.Sdk;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Workflow;
using Microsoft.Xrm.Sdk.Query;
using System.Linq;

namespace LucasWorkflowTools
{
    public sealed class StartScheduledWorkflows : CodeActivity
    {
        [Input("FetchXML query")]
        public InArgument<String> FetchXMLQuery { get; set; }

        [Input("Workflow")]
        [ReferenceTarget("workflow")]
        public InArgument<EntityReference> Workflow { get; set; }

        //name of your custom workflow activity for tracing/error logging
        private string _activityName = "RunDailyProcess";

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

            tracingService.Trace("Entered " + _activityName + ".Execute(), Activity Instance Id: {0}, Workflow Instance Id: {1}",
                executionContext.ActivityInstanceId,
                executionContext.WorkflowInstanceId);

            // Create the context
            IWorkflowContext context = executionContext.GetExtension<IWorkflowContext>();

            if (context == null)
            {
                throw new InvalidPluginExecutionException("Failed to retrieve workflow context.");
            }

            tracingService.Trace(_activityName + ".Execute(), Correlation Id: {0}, Initiating User: {1}",
                context.CorrelationId,
                context.InitiatingUserId);

            IOrganizationServiceFactory serviceFactory = executionContext.GetExtension<IOrganizationServiceFactory>();
            IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);



            try
            {
                EntityCollection recordsToProcess = service.RetrieveMultiple(new FetchExpression(FetchXMLQuery.Get(executionContext)));
                recordsToProcess.Entities.ToList().ForEach(a =>
                {
                    ExecuteWorkflowRequest request = new ExecuteWorkflowRequest
                    {
                        EntityId = a.Id,
                        WorkflowId = (Workflow.Get(executionContext)).Id
                    };

                    service.Execute(request);  //run the workflow
                });


            }
            catch (FaultException<OrganizationServiceFault> e)
            {
                tracingService.Trace("Exception: {0}", e.ToString());

                // Handle the exception.
                throw;
            }
            catch (Exception e)
            {
                tracingService.Trace("Exception: {0}", e.ToString());
                throw;
            }

            tracingService.Trace("Exiting " + _activityName + ".Execute(), Correlation Id: {0}", context.CorrelationId);
        }
    }

}