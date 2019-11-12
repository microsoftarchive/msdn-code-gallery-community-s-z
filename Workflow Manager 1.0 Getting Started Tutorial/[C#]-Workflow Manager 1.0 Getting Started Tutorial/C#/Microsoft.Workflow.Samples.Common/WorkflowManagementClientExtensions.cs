//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

using Microsoft.Activities;
using Microsoft.Activities.Messaging;
using Microsoft.Workflow.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;

namespace Microsoft.Workflow.Samples.Common
{
    public static class WorkflowManagementClientExtensions
    {
        public static void PublishActivity(this WorkflowManagementClient client, string name, string xamlFilePath)
        {
            client.Activities.Publish(
                new ActivityDescription(WorkflowUtils.Translate(xamlFilePath))
                {
                    Name = name
                });
        }

        public static void PublishWorkflow(this WorkflowManagementClient client, string workflowName, string xamlFilePath, SubscriptionFilter activationFilter = null)
        {
            PublishWorkflow(client, workflowName, xamlFilePath, null, null, activationFilter);
        }

        public static void PublishWorkflow(this WorkflowManagementClient client, string workflowName, string xamlFilePath, Collection<ExternalVariable> externalVariables, SubscriptionFilter activationFilter = null)
        {
            PublishWorkflow(client, workflowName, xamlFilePath, externalVariables, null, activationFilter);
        }

        public static void PublishWorkflow(this WorkflowManagementClient client, string workflowName, string xamlFilePath, IDictionary<string, string> configValues, SubscriptionFilter activationFilter = null)
        {
            PublishWorkflow(client, workflowName, xamlFilePath, null, configValues, activationFilter);
        }

        public static void PublishWorkflow(this WorkflowManagementClient client, string workflowName, string xamlFilePath, Collection<ExternalVariable> externalVariables, IDictionary<string, string> configValues, SubscriptionFilter activationFilter = null)
        {
            // publish the activity description related with the workflow
            client.Activities.Publish(
                new ActivityDescription(WorkflowUtils.Translate(xamlFilePath)) { Name = workflowName });

            // now, publish the workflow description
            WorkflowDescription description = new WorkflowDescription
            {
                Name = workflowName,
                ActivityPath = workflowName,
            };

            // add external variables
            if (externalVariables != null)
            {
                externalVariables
                    .ToList()
                    .ForEach(ev => description.ExternalVariables.Add(ev));
            }

            // add config
            if (configValues != null)
            {
                description.Configuration = new WorkflowConfiguration();
                configValues
                    .ToList()
                    .ForEach(c => description.Configuration.AppSettings.Add(c));
            }

            // add activation filter
            if (activationFilter != null)
            {
                description.ActivationDescription = new SubscriptionActivationDescription
                {
                    Filter = activationFilter
                };
            }

            // publish!
            client.Workflows.Publish(description);
        }

        public static void CleanUp(this WorkflowManagementClient client)
        {
            client.CurrentScope.Delete();
        }

        public static string WaitForWorkflowCompletion(this WorkflowManagementClient client, string workflowName, string instanceId, int pollingInterval = 0)
        {
            string currentStatus = string.Empty;
            string lastStatus = string.Empty;

            WorkflowInstanceInfo instanceInfo = client.Instances.Get(workflowName, instanceId);

            while (true)
            {
                instanceInfo = client.Instances.Get(workflowName, instanceId);

                currentStatus = instanceInfo.UserStatus;

                if (currentStatus != lastStatus && !string.IsNullOrWhiteSpace(currentStatus))
                {
                    Console.Write("   Current Status: ");
                    WorkflowUtils.Print(currentStatus, ConsoleColor.Cyan);
                    lastStatus = currentStatus;
                }

                if (instanceInfo.WorkflowStatus == WorkflowInstanceStatus.Started || instanceInfo.WorkflowStatus == WorkflowInstanceStatus.NotStarted)
                {
                    Thread.Sleep(pollingInterval);
                    continue;
                }

                if (instanceInfo.WorkflowStatus == WorkflowInstanceStatus.Completed)
                {
                    Console.WriteLine("\nWorkflow instance completed");
                }

                break;
            }

            return instanceInfo.UserStatus;
        }
    }
}
