//-----------------------------------------------------------------------
// <copyright file="ApprovalWorkflowItemsEventReceivers.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation &amp;
// All rights reserved.
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY 
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
// </copyright>
//-----------------------------------------------------------------------
namespace CustomApprovalWorkflows.EventReceivers
{
    using System;
    using System.Collections;
    using System.Security.Permissions;
    using Microsoft.SharePoint;
    using Microsoft.SharePoint.Utilities;
    using Microsoft.SharePoint.Workflow;
    using CustomApprovalWorkflows.Helpers;

    /// <summary>
    /// List Item Events
    /// </summary>
    public class ApprovalWorkflowItemsEventReceivers : SPItemEventReceiver
    {
        /// <summary>
        /// Asynchronous After event that occurs after an item is checked in.
        /// </summary>
        /// <param name="properties">event properties</param>
        public override void ItemCheckedIn(SPItemEventProperties properties)
        {
            try
            {
                base.ItemCheckedIn(properties);
                if (properties.ListItem.ModerationInformation.Status == SPModerationStatusType.Pending)
                {
                    WorkflowHelper2013.StartApprovalWorkflowOnListItem(properties.ListItem, true);
                }
            }
            catch (Exception ex) 
            {
                //Log exception
            }
        }

        /// <summary>
        /// Synchronous Before event that occurs when an existing item is changed, for example, when the user changes data in one or more fields.
        /// </summary>
        /// <param name="properties">An <see cref="T:Microsoft.SharePoint.SPItemEventProperties" /> object that represents properties of the event handler.</param>
        public override void ItemUpdating(SPItemEventProperties properties)
        {
            try
            {
                base.ItemUpdating(properties);
                object levelbefore = properties.BeforeProperties["vti_level"];
                object levelafter = properties.AfterProperties["vti_level"];
                object doclibmodstatbefore = properties.BeforeProperties["vti_doclibmodstat"];
                object doclibmodstatafter = properties.AfterProperties["vti_doclibmodstat"];

                if (levelbefore != null && levelafter != null)
                {
                    int levelBefore, levelAfter, doclibmodstatBefore = -1, doclibmodstatAfter = -1;
                    bool levelBeforeParsed, levelAfterParsed, doclibmodstatBeforeParsed = false, doclibmodstatAfterParsed = false;

                    levelBeforeParsed = int.TryParse(levelbefore.ToString(), out levelBefore);
                    levelAfterParsed = int.TryParse(levelafter.ToString(), out levelAfter);

                    if (doclibmodstatbefore != null)
                    {
                        doclibmodstatBeforeParsed = int.TryParse(doclibmodstatbefore.ToString(), out doclibmodstatBefore);
                    }

                    if (doclibmodstatafter != null)
                    {
                        doclibmodstatAfterParsed = int.TryParse(doclibmodstatafter.ToString(), out doclibmodstatAfter);
                    }

                    if (levelBeforeParsed && levelAfterParsed && doclibmodstatAfterParsed)
                    {
                        if (doclibmodstatbefore == null)
                        {
                            // Check to Trigger workflow on Submit button click after minor check in.
                            // Must have levelbefore =2, levelAfter = 2, doclibmodstatbefore = null and doclibmodstatafter = 2
                            if (levelBefore == 2 && levelAfter == 2 && doclibmodstatAfter == 2)
                            {
                                WorkflowHelper2013.StartApprovalWorkflowOnListItem(properties.ListItem, true);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Log exception
            }
        }

        /// <summary>
        /// Asynchronous After event that occurs after an existing item is changed, for example, when the user changes data in one or more fields.
        /// </summary>
        /// <param name="properties">An <see cref="T:Microsoft.SharePoint.SPItemEventProperties" /> object that represents properties of the event handler.</param>
        public override void ItemUpdated(SPItemEventProperties properties)
        {
            try
            {
                base.ItemUpdated(properties);
                object levelbefore = properties.BeforeProperties["vti_level"];
                object levelafter = properties.AfterProperties["vti_level"];
                object doclibmodstatbefore = properties.BeforeProperties["vti_doclibmodstat"];
                object doclibmodstatafter = properties.AfterProperties["vti_doclibmodstat"];

                if (levelbefore != null && levelafter != null)
                {
                    int levelBefore, levelAfter, doclibmodstatBefore = -1, doclibmodstatAfter = -1;
                    bool levelBeforeParsed, levelAfterParsed, doclibmodstatBeforeParsed = false, doclibmodstatAfterParsed = false;

                    levelBeforeParsed = int.TryParse(levelbefore.ToString(), out levelBefore);
                    levelAfterParsed = int.TryParse(levelafter.ToString(), out levelAfter);

                    if (doclibmodstatbefore != null)
                    {
                        doclibmodstatBeforeParsed = int.TryParse(doclibmodstatbefore.ToString(), out doclibmodstatBefore);
                    }

                    if (doclibmodstatafter != null)
                    {
                        doclibmodstatAfterParsed = int.TryParse(doclibmodstatafter.ToString(), out doclibmodstatAfter);
                    }

                    if (levelBeforeParsed && levelAfterParsed && doclibmodstatAfterParsed && doclibmodstatBeforeParsed)
                    {
                        if (string.IsNullOrEmpty(properties.ListItem.ModerationInformation.Comment) || !properties.ListItem.ModerationInformation.Comment.Equals(ListConstants.ApprovalWorkflowModerationComment))
                        {
                            // Check to cancel workflow on Direct Approval/Rejection.
                            // Must have levelbefore =2, levelAfter = 2, doclibmodstatbefore = 2 and (doclibmodstatafter = 0 or doclibmodstatafter = 1)
                            if (levelBefore == 2 && levelAfter == 2 && doclibmodstatBefore == 2 && (doclibmodstatAfter == 0 || doclibmodstatAfter == 1))
                            {
                                WorkflowHelper2013.CancelApprovalWorkflowOnListItem(properties.ListItem);

                                this.UpdateWorkflowStatus(properties.ListItem);
                            }
                        }
                    }
                    else if (doclibmodstatbefore == null)
                    {
                        if (levelBefore == 2 && levelAfter == 2 && doclibmodstatAfter == 3)
                        {
                            // Check to cancel workflow on cancel approvl button click.
                            // Must have levelbefore = 2, levelAfter = 2, doclibmodstatbefore = null and 
                            WorkflowHelper2013.CancelApprovalWorkflowOnListItem(properties.ListItem);

                            this.UpdateWorkflowStatus(properties.ListItem);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               //logging
            }
        }

        /// <summary>
        /// Updates the workflow status.
        /// </summary>
        /// <param name="item">The item.</param>
        private void UpdateWorkflowStatus(SPListItem item)
        {
            try
            {
                string workflowInstanceFieldName =  ResourcesHelper.GetLocalizedString("workflow_approval_instancename", item.Web);
                string statusInProgress = ResourcesHelper.GetLocalizedString("workflow_approvaltaskstatus_inprogress", item.Web);
                string statusCancelled = ResourcesHelper.GetLocalizedString("workflow_approvaltaskstatus_cancelled", item.Web);

                if (item.Fields.ContainsField(workflowInstanceFieldName))
                {
                    if (item[workflowInstanceFieldName] != null)
                    {
                        string currentStatus = item[workflowInstanceFieldName].ToString().ToLower();
                        if (currentStatus.Contains("in progress") || currentStatus.Contains(statusInProgress))
                        {
                            string toReplace = currentStatus.Contains("in progress") ? "in progress" : statusInProgress;
                            currentStatus = currentStatus.Replace(toReplace, statusCancelled);
                            this.EventFiringEnabled = false;
                            item[workflowInstanceFieldName] = currentStatus;
                            item.SystemUpdate();
                            this.EventFiringEnabled = true;
                        }
                    }
                }
            }
            catch
            {
            }
        }
    }
}