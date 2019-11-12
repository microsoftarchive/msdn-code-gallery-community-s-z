//-----------------------------------------------------------------------
// <copyright file="WorkflowHelper2013.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation &amp;
// All rights reserved.
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY 
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
// </copyright>
//-----------------------------------------------------------------------

namespace CustomApprovalWorkflows.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using System.Resources;
    using System.Text;
    using Microsoft.SharePoint;
    using Microsoft.SharePoint.WorkflowServices;
    using Microsoft.SharePoint.Workflow;
    using Microsoft.SharePoint.Utilities;
    using CustomApprovalWorkflows.EventReceivers;

    /// <summary>
    /// SharePoint 2013 workflow helper
    /// </summary>
    public class WorkflowHelper2013
    {
        /// <summary>
        /// id of ContentType Workflow Task SharePoint 2013
        /// </summary>
        private const string ContentTypeWorkflowTaskSharePoint2013 = "0x0108003365C4474CAE8C42BCE396314E88E51F";

        /// <summary>
        /// ApprovalWorkflow Definition Id
        /// </summary>
        private static Guid approvalWorkflowDefinitionId = new Guid("73C27777-198F-43B4-A7C0-FE6753ADA4C4");

        /// <summary>
        /// SAML ApprovalWorkflow Definition Id [Not available as part of this solution, will be published as a diff solution]
        /// </summary>
        private static Guid approvalSamlWorkflowDefinitionId = new Guid("65BE55E6-B0AF-4CB3-BBD7-535FCBB3C5E4");

        /// <summary>
        /// custom Workflow Feature Id
        /// </summary>
        private static Guid customWorkflowFeatureId = new Guid("49faa188-cb77-490f-9225-c95ad56c6193");

        /// <summary>
        /// custom Workflow activities Feature Id
        /// </summary>
        private static Guid customWorkflowActivitiesFeatureId = new Guid("5d3b4ca1-21e1-4d29-9605-066b3e77e94a");

        /// <summary>
        /// custom Workflow Definition Ids
        /// </summary>
        private static List<Guid> customApprovalWorkflowDefinitionIds = new List<Guid>() { approvalSamlWorkflowDefinitionId, approvalWorkflowDefinitionId };

        /// <summary>
        ///  Enumeration of workflow start event type
        /// </summary>
        public enum WorkflowStartEventType
        {
            /// <summary>
            /// The item added
            /// </summary>
            ItemAdded,

            /// <summary>
            /// The item updated
            /// </summary>
            ItemUpdated,

            /// <summary>
            /// The manual
            /// </summary>
            Manual
        }

        /// <summary>
        /// The app principal scope
        /// </summary>
        private enum AppPrincipalScope
        {
            /// <summary>
            /// The site
            /// </summary>
            Site,

            /// <summary>
            /// The web
            /// </summary>
            Web,

            /// <summary>
            /// The list
            /// </summary>
            List,

            /// <summary>
            /// The site subscription
            /// </summary>
            SiteSubscription,

            /// <summary>
            /// The site content subscription
            /// </summary>
            SiteContentSubscription
        }

        /// <summary>
        /// Removes the approval workflow on list.
        /// </summary>
        /// <param name="web">The web.</param>
        /// <param name="list">The list.</param>
        /// <param name="isSamlWorkflow">Is Saml Workflow.</param>
        /// <returns>The status</returns>
        public static bool RemoveApprovalWorkflowOnList(SPWeb web, SPList list, bool isSamlWorkflow)
        {
            Guid subscriptionId = Guid.Empty;

            try
            {
                Guid workflowDefId = isSamlWorkflow ? approvalSamlWorkflowDefinitionId : approvalWorkflowDefinitionId;
                subscriptionId = EnsureWorkflowOnList(web, list, workflowDefId, null, null, null, null, null, true);
                SubscribeToEventReceivers(list, true);
            }
            catch
            {
            }

            return subscriptionId != Guid.Empty;
        }

        /// <summary>
        /// Ensures the approval workflow on list.
        /// </summary>
        /// <param name="web">The web.</param>
        /// <param name="list">The list.</param>
        /// <param name="events">The events.</param>
        /// <param name="useSamlWorkflow">Whether to use the SAML Approval workflow</param>
        /// <returns>
        /// The workflow subscription id
        /// </returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static Guid EnsureApprovalWorkflowOnList(SPWeb web, SPList list, List<WorkflowStartEventType> events, bool useSamlWorkflow)
        {
            Guid subscriptionId = Guid.Empty;

            if (list == null)
            {
                throw new ArgumentNullException("list");
            }

            // Remove existing 2010 workflow associations
            SPWorkflowAssociationCollection existingWorkflows = list.WorkflowAssociations;
            if (existingWorkflows != null)
            {
                for (int i = 0; i < existingWorkflows.Count; i++)
                {
                    list.WorkflowAssociations.Remove(existingWorkflows[i]);
                }
            }

            //SPFeature customWorkflowActivitiesFeature = web.Features[customWorkflowActivitiesFeatureId];

            //if (customWorkflowActivitiesFeature == null)
            //{
            //    customWorkflowActivitiesFeature = web.Features.Add(customWorkflowActivitiesFeatureId);
            //}

            SPFeature customWorkflowFeature = web.Features[customWorkflowFeatureId];

            if (customWorkflowFeature == null)
            {
                customWorkflowFeature = web.Features.Add(customWorkflowFeatureId);
            }

            if (customWorkflowFeature != null)
            {
                if (!list.EnableModeration || !list.ForceCheckout)
                {
                    list.EnableModeration = true;
                    list.ForceCheckout = true;
                    list.EnableVersioning = true;
                    list.Update();
                }

                Dictionary<string, string> workflowPropertyData = GetApprovalWorkflowSettings(web, list.Title);

                SPList taskList = EnsureWorkflowTaskList(web, "/lists/workflowtasks", string.Empty);

                SPList historyList = EnsureWorkflowHistoryList(web, "/workflowhistory", string.Empty);

                if (taskList != null && historyList != null)
                {
                    bool workflowTaskContentTypeAssociated = false;
                    foreach (SPContentType contentType in taskList.ContentTypes)
                    {
                        if (contentType.Parent.Id.ToString().Equals(ContentTypeWorkflowTaskSharePoint2013, StringComparison.OrdinalIgnoreCase))
                        {
                            workflowTaskContentTypeAssociated = true;
                            break;
                        }
                    }

                    if (!workflowTaskContentTypeAssociated)
                    {
                        SPContentType wftaskContentType = default(SPContentType);
                        SPContentTypeCollection contentTypes = web.ContentTypes.Count == 0 ? web.Site.RootWeb.ContentTypes : web.ContentTypes;

                        wftaskContentType = contentTypes.Cast<SPContentType>().FirstOrDefault<SPContentType>(c => c.Id.ToString().Equals(ContentTypeWorkflowTaskSharePoint2013, StringComparison.OrdinalIgnoreCase));

                        if (wftaskContentType != null)
                        {
                            taskList.ContentTypes.Add(wftaskContentType);
                        }
                    }

                    string displayName = ResourcesHelper.GetLocalizedString("workflow_approval_instancename");

                    Guid workflowDefId = useSamlWorkflow ? approvalSamlWorkflowDefinitionId : approvalWorkflowDefinitionId;

                    subscriptionId = EnsureWorkflowOnList(web, list, workflowDefId, displayName, events, taskList, historyList, workflowPropertyData, false);

                    EnableWorkflowsRunAsAnApp(web);

                    SubscribeToEventReceivers(list, false);
                }
            }

            return subscriptionId;
        }

        /// <summary>
        /// Ensures that a workflow from the supplied definition id exists on the list, either updating or adding the subscription.
        /// </summary>
        /// <param name="web">The web</param>
        /// <param name="list">The list on which we are ensuring the workflow</param>
        /// <param name="workflowDefinitionId">The workflow definition id</param>
        /// <param name="displayName">The workflow display name</param>
        /// <param name="eventList">The list of events we are registering { possible: ["ItemAdded", "ItemUpdated", "WorkflowStart"] }</param>
        /// <param name="taskList">The task list.</param>
        /// <param name="historyList">The history list.</param>
        /// <param name="workflowPropertyData">The workflow property data.</param>
        /// <param name="remove">If true the workflow is removed, if false it is added or updated.</param>
        /// <returns>The workflow subscription id</returns>
        public static Guid EnsureWorkflowOnList(SPWeb web, SPList list, Guid workflowDefinitionId, string displayName, List<WorkflowStartEventType> eventList, SPList taskList, SPList historyList, Dictionary<string, string> workflowPropertyData, bool remove)
        {
            Guid subscriptionId = Guid.Empty;
            if (list == null)
            {
                throw new ArgumentNullException("list");
            }

            // get our manager and services
            var workflowServicesManager = new WorkflowServicesManager(web);

            if (!workflowServicesManager.IsConnected)
            {
                var notConnectedEx = new NotConnectedException();
                throw notConnectedEx;
            }

            var workflowDeploymentService = workflowServicesManager.GetWorkflowDeploymentService();
            var workflowSubscriptionService = workflowServicesManager.GetWorkflowSubscriptionService();

            var workflowDefinition = workflowDeploymentService.GetDefinition(workflowDefinitionId);

            if (workflowDefinition == null)
            {
                var ex = new SPException("Failed to load workflow definition with id: " + workflowDefinitionId);
                throw ex;
            }

            var workflowSubscriptions = workflowSubscriptionService.EnumerateSubscriptionsByList(list.ID);
            var workflowSubscription = default(WorkflowSubscription);

            if (workflowSubscriptions != null)
            {
                workflowSubscription = workflowSubscriptions.FirstOrDefault((s) => s.DefinitionId.Equals(workflowDefinitionId));
            }

            // remove the workflow based on the supplied flag
            if (remove)
            {
                if (workflowSubscription != null)
                {
                    workflowSubscriptionService.DeleteSubscription(workflowSubscription.Id);
                }

                return subscriptionId;
            }

            if (workflowSubscription == null)
            {
                workflowSubscription = new WorkflowSubscription();
                workflowSubscription.EventSourceId = list.ID;
                workflowSubscription.DefinitionId = workflowDefinition.Id;
                workflowSubscription.Id = Guid.NewGuid();
            }

            if (workflowPropertyData == null)
            {
                workflowPropertyData = new Dictionary<string, string>();
            }

            workflowPropertyData["TaskListId"] = (taskList != null) ? taskList.ID.ToString("D") : string.Empty;
            workflowPropertyData["HistoryListId"] = (historyList != null) ? historyList.ID.ToString("D") : string.Empty;
            workflowPropertyData["FormData"] = string.Empty;

            try
            {
                foreach (string propDataKey in workflowPropertyData.Keys)
                {
                    workflowSubscription.PropertyDefinitions[propDataKey] = workflowPropertyData[propDataKey];
                }

                List<string> events = TransformEvents(eventList);

                workflowSubscription.Name = displayName;
                workflowSubscription.EventTypes = events;

                subscriptionId = workflowSubscriptionService.PublishSubscriptionForList(workflowSubscription, list.ID);
            }
            catch (Exception err)
            {
                throw;
            }

            return subscriptionId;
        }

        /// <summary>
        /// Starts the workflow on list item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="cancelExisting">if set to <c>true</c> [cancel existing].</param>
        /// <returns>
        /// the status
        /// </returns>
        public static bool StartApprovalWorkflowOnListItem(SPListItem item, bool cancelExisting)
        {
            return StartWorkflowOnListItem(item, customApprovalWorkflowDefinitionIds, null, cancelExisting);
        }

        /// <summary>
        /// Starts the workflow on item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="workflowDefinitionId">The workflow definition id.</param>
        /// <param name="payload">The payload.</param>
        /// <param name="cancelExisting">if set to <c>true</c> [cancel existing].</param>
        /// <returns>
        /// the status
        /// </returns>
        public static bool StartWorkflowOnListItem(SPListItem item, Guid workflowDefinitionId, Dictionary<string, object> payload, bool cancelExisting)
        {
            return StartWorkflowOnListItem(item, new List<Guid>() { workflowDefinitionId }, payload, cancelExisting);
        }

        /// <summary>
        /// Cancels the workflow on list item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>
        /// the status
        /// </returns>
        public static bool CancelApprovalWorkflowOnListItem(SPListItem item)
        {
            return CancelWorkflowOnListItem(item, customApprovalWorkflowDefinitionIds);
        }

        /// <summary>
        /// Cancels the workflow on list item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="workflowDefinitionId">The workflow definition id.</param>
        /// <returns>the status</returns>
        public static bool CancelWorkflowOnListItem(SPListItem item, Guid workflowDefinitionId)
        {
            return CancelWorkflowOnListItem(item, new List<Guid>() { workflowDefinitionId });
        }

        /// <summary>
        /// Ensures the workflow task list.
        /// </summary>
        /// <param name="web">The web.</param>
        /// <param name="taskListRelativeUrl">The task list relative URL.</param>
        /// <param name="description">The description.</param>
        /// <returns>
        /// The workflow task list
        /// </returns>
        public static SPList EnsureWorkflowTaskList(SPWeb web, string taskListRelativeUrl, string description)
        {
            return EnsureWorkflowTaskAndHistoryList(web, taskListRelativeUrl, description, true);
        }

        /// <summary>
        /// Ensures the workflow history list.
        /// </summary>
        /// <param name="web">The web.</param>
        /// <param name="historyListRelativeUrl">The history list relative URL.</param>
        /// <param name="description">The description.</param>
        /// <returns>
        /// The workflow history list
        /// </returns>
        public static SPList EnsureWorkflowHistoryList(SPWeb web, string historyListRelativeUrl, string description)
        {
            return EnsureWorkflowTaskAndHistoryList(web, historyListRelativeUrl, description, false);
        }

        /// <summary>
        /// Enables trust for the workflow app on the web
        /// </summary>
        /// <param name="web">SPWeb to enable trust on</param>
        /// <param name="permissionKind">Kind of trust to grant</param>
        /// <returns>True if the permission is granted successfully</returns>
        public static bool TrustWorkflowApp(SPWeb web, SPAppPrincipalPermissionKind permissionKind)
        {
            bool permissionGranted = false;

            if (web != null)
            {
                var appPrincipals = web.GetSiteAppPrincipals();

                SPAppPrincipalManager manager = SPAppPrincipalManager.GetManager(web);
                SPAppPrincipalPermissionsManager perm = new SPAppPrincipalPermissionsManager(web);
                Assembly assembly = Assembly.Load("Microsoft.SharePoint.WorkflowServices.Intl, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c");
                ResourceManager resourceManager = new ResourceManager("Microsoft.SharePoint.WorkflowServices.Strings", assembly);
                string workflowAppName = resourceManager.GetString("ApplicationDisplayName", web.Locale);

                foreach (SPSiteAppPrincipalInfo info in appPrincipals)
                {
                    if (info.DisplayName.ToLower().Equals(workflowAppName.ToLower()))
                    {
                        string appPrincipalIdentifier = GetAppIdentifier(info.EncodedIdentityClaim);

                        SPAppPrincipalName name = SPAppPrincipalName.CreateFromAppPrincipalIdentifier(appPrincipalIdentifier);
                        SPAppPrincipal p = manager.LookupAppPrincipal(SPAppPrincipalIdentityProvider.External, name);
                        object urls = GetInstanceField(typeof(SPAppPrincipal), p, "RedirectAddresses");
                        ReadOnlyCollection<Uri> uris = urls as ReadOnlyCollection<Uri>;

                        // Trust the workflow app scoped that this web only
                        if (uris != null && uris.FirstOrDefault(u => u.AbsoluteUri.ToLower().Equals(web.Url.ToLower())) != null)
                        {
                            perm.AddAppPrincipalToSite(p, SPAppPrincipalPermissionKind.FullControl);
                        }

                        permissionGranted = true;
                    }
                }
            }

            return permissionGranted;
        }

        /// <summary>
        /// Ensures the workflow runs as an app feature is activated in the web
        /// </summary>
        /// <param name="web">Web on which the feature needs to be ensured</param>
        public static void EnableWorkflowsRunAsAnApp(SPWeb web)
        {
            Guid workflowAsAnAppFeatureId = new Guid("EC918931-C874-4033-BD09-4F36B2E31FEF");
            if (web != null && web.Features.FirstOrDefault(f => f.DefinitionId.Equals(workflowAsAnAppFeatureId)) == null)
            {
                web.Features.Add(workflowAsAnAppFeatureId);
            }

            TrustWorkflowApp(web, SPAppPrincipalPermissionKind.FullControl);
        }

        /// <summary>
        /// Uses reflection to get the field value from an object.
        /// </summary>
        /// <param name="type">The instance type.</param>
        /// <param name="instance">The instance object.</param>
        /// <param name="fieldName">The field's name which is to be fetched.</param>
        /// <returns>The field value from the object.</returns>
        internal static object GetInstanceField(Type type, object instance, string fieldName)
        {
            BindingFlags bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;
            PropertyInfo infoP = type.GetProperty(fieldName, bindFlags);
            return infoP.GetValue(instance);
        }

        /// <summary>
        /// Ensures the workflow task and history list.
        /// </summary>
        /// <param name="web">The web.</param>
        /// <param name="listRelativeUrl">The list relative URL.</param>
        /// <param name="description">The description.</param>
        /// <param name="isTasklist">if set to <c>true</c> [is task list].</param>
        /// <returns>
        /// The workflow task or history list
        /// </returns>
        private static SPList EnsureWorkflowTaskAndHistoryList(SPWeb web, string listRelativeUrl, string description, bool isTasklist)
        {
            SPList list = default(SPList);

            if (web != null)
            {
                try
                {
                    if (!listRelativeUrl.Contains("sites"))
                    {
                        listRelativeUrl = string.Format("{0}{1}", web.Url, listRelativeUrl);
                    }

                    list = web.GetList(listRelativeUrl);
                }
                catch (System.IO.FileNotFoundException)
                {
                    // if the list doesn't exist
                }

                if (list == null)
                {
                    Guid listid = Guid.Empty;
                    string listname = listRelativeUrl;
                    if (listRelativeUrl.Contains('/'))
                    {
                        listname = listRelativeUrl.Substring(listRelativeUrl.LastIndexOf('/') + 1);
                    }

                    list = web.Lists.TryGetList(listname);

                    if (list == null)
                    {
                        listid = web.Lists.Add(listname, description, isTasklist ? SPListTemplateType.Tasks : SPListTemplateType.WorkflowHistory);

                        if (listid != Guid.Empty)
                        {
                            list = web.Lists.TryGetList(listname);

                            if (!isTasklist)
                            {
                                list.Hidden = true;
                                list.Update();
                            }
                        }
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// Transforms the events.
        /// </summary>
        /// <param name="eventList">The event list.</param>
        /// <returns>List of event strings</returns>
        private static List<string> TransformEvents(List<WorkflowStartEventType> eventList)
        {
            List<string> events = new List<string>();

            foreach (WorkflowStartEventType eventtype in eventList)
            {
                string eventName = default(string);

                switch (eventtype)
                {
                    case WorkflowStartEventType.ItemAdded:
                        eventName = WorkflowStartEventType.ItemAdded.ToString();
                        break;
                    case WorkflowStartEventType.ItemUpdated:
                        eventName = WorkflowStartEventType.ItemUpdated.ToString();
                        break;
                    case WorkflowStartEventType.Manual:
                        eventName = "WorkflowStart";
                        break;
                }

                if (!string.IsNullOrEmpty(eventName) && !events.Contains(eventName))
                {
                    events.Add(eventName);
                }
            }

            return events;
        }

        /// <summary>
        /// Gets the approval workflow settings.
        /// </summary>
        /// <param name="web">The web.</param>
        /// <param name="taskName">Name of the task.</param>
        /// <returns>
        /// The dictionary of workflow settings
        /// </returns>
        /// <exception cref="Microsoft.SharePoint.SPException"></exception>
        private static Dictionary<string, string> GetApprovalWorkflowSettings(SPWeb web, string taskName)
        {
            Dictionary<string, string> payLoad = new Dictionary<string, string>();

            string value = string.Empty;

            try
            {
                value = GlobalSettingsHelper.GetValue(ListConstants.ApprovalWorkflowApproversSharePointGroup);

                string approvers = ParseContentApproverGroups(web, value);

                if (approvers.Length == 0)
                {
                    throw new SPException("No SharePoint Approver Groups found");
                }

                payLoad.Add("Approvers", approvers);
            }
            catch (Exception ex)
            {
                throw new SPException(string.Format("Error in SharePoint Approver Group resolution{0}{1}", Environment.NewLine, ex.Message), ex);
            }

            try
            {
                value = GlobalSettingsHelper.GetValue(ListConstants.ApprovalWorkflowDefaultDurationDays);
                if (!string.IsNullOrEmpty(value))
                {
                    payLoad.Add("Duration", value);
                }
            }
            catch
            {
            }

            value = ResourcesHelper.GetLocalizedString("workflow_ApprovalTaskDefaultTitle");
            if (!string.IsNullOrEmpty(value))
            {
                payLoad.Add("TaskTitle", string.Format(value, taskName));
            }

            value = ResourcesHelper.GetLocalizedString("workflow_ApprovalTaskAssignedEmailSubject");
            if (!string.IsNullOrEmpty(value))
            {
                payLoad.Add("TaskAssignmentEmailSubject", string.Format(value, taskName));
            }

            value = ResourcesHelper.GetLocalizedString("workflow_ApprovalTaskAssignedEmailBodyHtml");
            if (!string.IsNullOrEmpty(value))
            {
                payLoad.Add("TaskAssignmentEmailBodyHtml", value);
            }

            value = ResourcesHelper.GetLocalizedString("workflow_ApprovalTaskCancelledEmailSubject");
            if (!string.IsNullOrEmpty(value))
            {
                payLoad.Add("TaskCancellationEmailSubject", string.Format(value, taskName));
            }

            value = ResourcesHelper.GetLocalizedString("workflow_ApprovalTaskCancelledEmailBodyHtml");
            if (!string.IsNullOrEmpty(value))
            {
                payLoad.Add("TaskCancellationEmailBodyHtml", value);
            }

            value = ResourcesHelper.GetLocalizedString("workflow_ApprovalTaskOverdueEmailSubject");
            if (!string.IsNullOrEmpty(value))
            {
                payLoad.Add("TaskOverdueEmailSubject", string.Format(value, taskName));
            }

            value = ResourcesHelper.GetLocalizedString("workflow_ApprovalTaskOverdueEmailBodyHtml");
            if (!string.IsNullOrEmpty(value))
            {
                payLoad.Add("TaskOverdueEmailBodyHtml", value);
            }

            value = ResourcesHelper.GetLocalizedString("workflow_approvaltaskstatus_completed");
            if (!string.IsNullOrEmpty(value))
            {
                payLoad.Add("TaskCompletionStatus", value);
            }

            payLoad.Add("EndonFirstApproval", "true");
            payLoad.Add("EnableContentApproval", "true");

            return payLoad;
        }

        /// <summary>
        /// Parses the content approver groups.
        /// </summary>
        /// <param name="web">The web.</param>
        /// <param name="groupValue">The group value.</param>
        /// <returns>Parsed Content approver groups</returns>
        private static string ParseContentApproverGroups(SPWeb web, string groupValue)
        {
            string returnValue = string.Empty;

            if (!string.IsNullOrEmpty(groupValue))
            {
                StringBuilder approvers = new StringBuilder();

                string[] groups = new string[10];
                bool isOrOperator = false;

                if (groupValue.Contains('&') || groupValue.Contains('|'))
                {
                    char[] splitBy = new char[1];
                    if (groupValue.Contains('&'))
                    {
                        splitBy[0] = '&';
                    }
                    else
                    {
                        splitBy[0] = '|';
                        isOrOperator = true;
                    }

                    groups = groupValue.Split(splitBy);
                }
                else
                {
                    groups[0] = groupValue;
                }

                foreach (string group in groups)
                {
                    foreach (SPGroup spgroup in web.Groups)
                    {
                        if (spgroup.Name.Equals(group, StringComparison.OrdinalIgnoreCase))
                        {
                            approvers.AppendFormat("{0};", group);
                            if (isOrOperator)
                            {
                                break;
                            }
                        }
                    }

                    if (isOrOperator && approvers.Length > 0)
                    {
                        break;
                    }
                }

                if (approvers.Length > 0)
                {
                    returnValue = approvers.ToString(0, approvers.Length - 1);
                }
            }

            return returnValue;
        }

        /// <summary>
        /// Extracts the app principal identifier from the encoded identifier
        /// </summary>
        /// <param name="encodedAppPrincipal">Encoded identifier</param>
        /// <returns>App principal identifier</returns>
        private static string GetAppIdentifier(string encodedAppPrincipal)
        {
            string result = string.Empty;

            string inm = encodedAppPrincipal.Substring(0, encodedAppPrincipal.IndexOf("@"));
            result = inm.Substring(inm.LastIndexOf("|") + 1);

            return result;
        }

        /// <summary>
        /// Subscribes to event receivers.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="remove">if set to <c>true</c> [remove].</param>
        private static void SubscribeToEventReceivers(SPList list, bool remove)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string className = typeof(ApprovalWorkflowItemsEventReceivers).FullName;

            if (remove)
            {
                for (int i = 0; i < list.EventReceivers.Count; i++)
                {
                    SPEventReceiverDefinition receiver = list.EventReceivers[i];
                    if (receiver.Assembly.Equals(assembly.FullName, StringComparison.OrdinalIgnoreCase) &&
                        (receiver.Type == SPEventReceiverType.ItemCheckedIn || receiver.Type == SPEventReceiverType.ItemUpdating || receiver.Type == SPEventReceiverType.ItemUpdated))
                    {
                        receiver.Delete();
                    }
                }
            }
            else
            {
                list.EventReceivers.Add(SPEventReceiverType.ItemCheckedIn, assembly.FullName, className);
                list.EventReceivers.Add(SPEventReceiverType.ItemUpdating, assembly.FullName, className);
                list.EventReceivers.Add(SPEventReceiverType.ItemUpdated, assembly.FullName, className);
            }
        }

        /// <summary>
        /// Starts the workflow on item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="workflowDefinitionIds">The workflow definition id collection to check.</param>
        /// <param name="payload">The payload.</param>
        /// <param name="cancelExisting">if set to <c>true</c> [cancel existing].</param>
        /// <returns>
        /// the status
        /// </returns>
        private static bool StartWorkflowOnListItem(SPListItem item, List<Guid> workflowDefinitionIds, Dictionary<string, object> payload, bool cancelExisting)
        {
            var result = false;

            if (payload == null)
            {
                payload = new Dictionary<string, object>();
            }

            try
            {
                Guid siteId = item.Web.Site.ID;
                Guid webId = item.Web.ID;

                SPSecurity.RunWithElevatedPrivileges(delegate
                {
                    using (SPSite site = new SPSite(siteId))
                    {
                        using (SPWeb web = site.OpenWeb(webId))
                        {
                            // get our manager and services
                            var workflowServicesManager = new WorkflowServicesManager(web);

                            if (!workflowServicesManager.IsConnected)
                            {
                                throw new NotConnectedException();
                            }

                            var workflowSubscriptionService = workflowServicesManager.GetWorkflowSubscriptionService();
                            var workflowInstanceService = workflowServicesManager.GetWorkflowInstanceService();

                            // get our subscription
                            WorkflowSubscription workflowSubscription = default(WorkflowSubscription);
                            var workflowSubscriptionCollection = workflowSubscriptionService.EnumerateSubscriptionsByList(item.ParentList.ID);
                            foreach (var wfSubscription in workflowSubscriptionCollection)
                            {
                                foreach (Guid inputId in workflowDefinitionIds)
                                {
                                    if (wfSubscription.DefinitionId.Equals(inputId))
                                    {
                                        workflowSubscription = wfSubscription;
                                        break;
                                    }
                                }

                                if (workflowSubscription != null)
                                {
                                    break;
                                }
                            }

                            if (workflowSubscription == null)
                            {
                                throw new Exception("Could not load subscription.  Please ensure workflow is attached to list: " + item.ParentList.RootFolder.ServerRelativeUrl);
                            }

                            var itemGuid = Guid.Empty;
                            if (item.Fields.ContainsField("GUID") && item["GUID"] != null)
                            {
                                itemGuid = new Guid(item["GUID"].ToString());
                            }

                            var listGuid = Guid.Parse(workflowSubscription.GetProperty("Microsoft.SharePoint.ActivationProperties.ListId"));

                            if (cancelExisting)
                            {
                                WorkflowInstanceCollection instances = workflowInstanceService.EnumerateInstancesForListItem(listGuid, item.ID);

                                if (instances != null && instances.Count > 0)
                                {
                                    foreach (var instance in instances)
                                    {
                                        workflowInstanceService.CancelWorkflow(instance);
                                    }
                                }
                            }

                            workflowInstanceService.StartWorkflowOnListItem(workflowSubscription, item.ID, payload);

                            result = true;
                        }
                    }
                });
            }
            catch (Exception err)
            {
                result = false;
            }

            return result;
        }

        private static bool CancelWorkflowOnListItem(SPListItem item, List<Guid> workflowDefinitionIds)
        {
            var result = false;

            try
            {
                Guid siteId = item.Web.Site.ID;
                Guid webId = item.Web.ID;

                SPSecurity.RunWithElevatedPrivileges(delegate
                {
                    using (SPSite site = new SPSite(siteId))
                    {
                        using (SPWeb web = site.OpenWeb(webId))
                        {
                            // get our manager and services
                            var workflowServicesManager = new WorkflowServicesManager(web);

                            if (!workflowServicesManager.IsConnected)
                            {
                                throw new NotConnectedException();
                            }

                            var workflowSubscriptionService = workflowServicesManager.GetWorkflowSubscriptionService();
                            var workflowInstanceService = workflowServicesManager.GetWorkflowInstanceService();

                            // get our subscription
                            WorkflowSubscription workflowSubscription = default(WorkflowSubscription);
                            var workflowSubscriptionCollection = workflowSubscriptionService.EnumerateSubscriptionsByList(item.ParentList.ID);
                            foreach (var wfSubscription in workflowSubscriptionCollection)
                            {
                                foreach (Guid inputId in workflowDefinitionIds)
                                {
                                    if (wfSubscription.DefinitionId.Equals(inputId))
                                    {
                                        workflowSubscription = wfSubscription;
                                        break;
                                    }
                                }

                                if (workflowSubscription != null)
                                {
                                    break;
                                }
                            }

                            if (workflowSubscription == null)
                            {
                                throw new Exception("Could not load subscription.  Please ensure workflow is attached to list: " + item.ParentList.RootFolder.ServerRelativeUrl);
                            }

                            var itemGuid = Guid.Empty;
                            if (item.Fields.ContainsField("GUID") && item["GUID"] != null)
                            {
                                itemGuid = new Guid(item["GUID"].ToString());
                            }

                            var listGuid = Guid.Parse(workflowSubscription.GetProperty("Microsoft.SharePoint.ActivationProperties.ListId"));

                            WorkflowInstanceCollection instances = workflowInstanceService.EnumerateInstancesForListItem(listGuid, item.ID);

                            if (instances != null && instances.Count > 0)
                            {
                                foreach (var instance in instances)
                                {
                                    workflowInstanceService.CancelWorkflow(instance);
                                }
                            }

                            result = true;
                        }
                    }
                });
            }
            catch (Exception err)
            {
                result = false;
            }

            return result;
        }
    }
}
