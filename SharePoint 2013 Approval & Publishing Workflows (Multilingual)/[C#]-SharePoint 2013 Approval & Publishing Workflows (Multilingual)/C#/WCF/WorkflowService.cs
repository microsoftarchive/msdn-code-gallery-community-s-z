// -----------------------------------------------------------------------
// <copyright file="WorkflowService.cs" company="Microsoft">
// Copyright (c) Microsoft Corporation &amp;.
// All rights reserved.
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY 
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
// </copyright>
// -----------------------------------------------------------------------
namespace CustomApprovalWorkflows.WCF
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Net.Mail;
    using System.ServiceModel.Activation;
    using System.Text;
    using System.Web;
    using Microsoft.SharePoint;
    using Microsoft.SharePoint.Administration;
    using Microsoft.SharePoint.Client.Services;
    using Microsoft.SharePoint.Utilities;
    using Microsoft.SharePoint.Workflow;
    using CustomApprovalWorkflows.Helpers;

    /// <summary>
    /// The social services WCF services implementation
    /// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]

   public class WorkflowService : IWorkflowService
    {
        /// <summary>
        /// Gets the configuration info from the platform site
        /// </summary>
        /// <param name="title">Title of the item to be fetched from configuration list</param>
        /// <returns>Response object</returns>
        public ConfigResponse GetConfigData(string title)
        {
            ConfigResponse response = new ConfigResponse();

            if (!string.IsNullOrEmpty(title))
            {
                response.Value = CustomApprovalWorkflows.Helpers.GlobalSettingsHelper.GetValue(title);
            }

            return response;
        }

        /// <summary>
        /// Ensures the users.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>Ensure User Response Object</returns>
        public EnsureUserRequestResponse EnsureUsers(EnsureUserRequestResponse request)
        {
            EnsureUserRequestResponse response = new EnsureUserRequestResponse();

            if (request != null && request.Users != null && request.Users.Count > 0)
            {
                Guid siteId = SPContext.Current.Site.ID;
                Guid webId = SPContext.Current.Web.ID;

                List<User> users = new List<User>();
                SPSecurity.RunWithElevatedPrivileges(delegate
                {
                    using (SPSite site = new SPSite(siteId))
                    {
                        using (SPWeb web = site.OpenWeb(webId))
                        {
                            bool unsafeUpdateStatus = web.AllowUnsafeUpdates;
                            try
                            {
                                web.AllowUnsafeUpdates = true;

                                foreach (var user in request.Users)
                                {
                                    SPUser spuser = default(SPUser);

                                    if (user.LoginName.Contains("|"))
                                    {
                                        spuser = web.EnsureUser(user.LoginName);
                                    }
                                    else
                                    {
                                        spuser = web.EnsureUser(user.EmailId);
                                    }

                                    if (spuser != null)
                                    {
                                        if (string.IsNullOrEmpty(spuser.Email) && !string.IsNullOrEmpty(user.EmailId))
                                        {
                                            spuser.Email = user.EmailId;
                                            spuser.Update();
                                        }

                                        user.LoginName = spuser.LoginName;

                                        users.Add(user);
                                    }
                                }

                                response.Users = users;
                            }
                            catch
                            {
                                throw;
                            }
                            finally
                            {
                                web.AllowUnsafeUpdates = unsafeUpdateStatus;
                            }
                        }
                    }
                });
            }

            return response;
        }

        /// <summary>
        /// Approves a list item
        /// </summary>
        /// <param name="listIdStr">The list id GUID, in string form</param>
        /// <param name="itemId">The item id</param>
        /// <returns>
        /// True if the operation is successful; false, otherwise
        /// </returns>
        public bool ApproveItem(string listIdStr, int itemId)
        {
            Guid listId;

            if (!Guid.TryParse(listIdStr, out listId))
            {
                throw new ArgumentException("listIdStr");
            }

            return this.InnerApproveReject(listId, itemId, SPModerationStatusType.Approved);
        }

        /// <summary>
        /// Rejects a list item
        /// </summary>
        /// <param name="listIdStr">The list id GUID, in string form</param>
        /// <param name="itemId">The item id</param>
        /// <returns>
        /// True if the operation is successful; false, otherwise
        /// </returns>
        public bool RejectItem(string listIdStr, int itemId)
        {
            Guid listId;

            if (!Guid.TryParse(listIdStr, out listId))
            {
                throw new ArgumentException("listIdStr");
            }

            return this.InnerApproveReject(listId, itemId, SPModerationStatusType.Denied);
        }

        /// <summary>
        /// Updates the item workflow status.
        /// </summary>
        /// <param name="itemInfo">The item info.</param>
        /// <returns>update status</returns>
        public bool UpdateItemWorkflowStatus(WorkflowItemInfo itemInfo)
        {
            var result = false;

            Guid siteId = SPContext.Current.Site.ID;
            Guid webId = SPContext.Current.Web.ID;

            SPSecurity.RunWithElevatedPrivileges(delegate
            {
                using (SPSite site = new SPSite(siteId))
                {
                    using (SPWeb web = site.OpenWeb(webId))
                    {
                        bool allowUnsafeUpdates = web.AllowUnsafeUpdates;

                        try
                        {
                            var list = web.Lists[itemInfo.ListId];

                            if (list != null)
                            {
                                var item = list.GetItemById(itemInfo.ItemId);

                                if (item != null)
                                {
                                    string fieldName = ResourcesHelper.GetLocalizedString("workflow_approval_instancename", web);
                                    if (item.Fields.ContainsField(fieldName))
                                    {
                                        web.AllowUnsafeUpdates = true;
                                        string status = this.GetWorkflowStatusString(itemInfo, web);
                                        string statusLink = string.Format("{0}/_layouts/15/wrkstat.aspx?List={1}&WorkflowInstanceName={2}, {3}", web.Url, itemInfo.ListId, itemInfo.WorkflowInstanceId, status);
                                        item[fieldName] = statusLink;
                                        item.SystemUpdate();

                                        if (itemInfo.Status.Equals("Cancelled", StringComparison.OrdinalIgnoreCase) && item.Tasks != null)
                                        {
                                            foreach (SPWorkflowTask taskItem in item.Tasks)
                                            {
                                                taskItem["Status"] = "Canceled";
                                                taskItem.SystemUpdate();
                                            }
                                        }

                                        result = true;
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            throw;
                        }
                        finally
                        {
                            web.AllowUnsafeUpdates = allowUnsafeUpdates;
                        }
                    }
                }
            });

            return result;
        }

        /// <summary>
        /// Gets the workflow status string.
        /// </summary>
        /// <param name="itemInfo">The item info.</param>
        /// <param name="web">The web.</param>
        /// <returns>status string</returns>
        private string GetWorkflowStatusString(WorkflowItemInfo itemInfo, SPWeb web)
        {
            string output = string.Empty;
            switch (itemInfo.Status.ToLower())
            {
                case "in progress":
                    output = ResourcesHelper.GetLocalizedString("workflow_approvaltaskstatus_inprogress", web);
                    break;
                case "cancelled":
                    output = ResourcesHelper.GetLocalizedString("workflow_approvaltaskstatus_cancelled", web);
                    break;
                case "completed":
                    output = ResourcesHelper.GetLocalizedString("workflow_approvaltaskstatus_completed", web);
                    break;
            }

            if (string.IsNullOrEmpty(output))
            {
                output = ResourcesHelper.GetLocalizedString("workflow_approvaltaskstatus_completed", web);
            }

            return output;
        }

        /// <summary>
        /// Handles the actual approval or rejection
        /// </summary>
        /// <param name="listId">The list id</param>
        /// <param name="itemId">The item id</param>
        /// <param name="newStatus">The new moderation status</param>
        /// <returns>True if the operation is successful; false, otherwise</returns>
        private bool InnerApproveReject(Guid listId, int itemId, SPModerationStatusType newStatus)
        {
            var result = false;

            Guid siteId = SPContext.Current.Site.ID;
            Guid webId = SPContext.Current.Web.ID;

            SPSecurity.RunWithElevatedPrivileges(delegate
            {
                using (SPSite site = new SPSite(siteId))
                {
                    using (SPWeb web = site.OpenWeb(webId))
                    {
                        bool allowUnsafeUpdates = web.AllowUnsafeUpdates;

                        try
                        {
                            var list = web.Lists[listId];

                            var item = list.GetItemById(itemId);

                            if (item.ModerationInformation.Status != SPModerationStatusType.Pending)
                            {
                                result = true;
                                return;
                            }

                            item.ModerationInformation.Status = newStatus;
                            item.ModerationInformation.Comment = ListConstants.ApprovalWorkflowModerationComment;

                            web.AllowUnsafeUpdates = true;

                            item.Update();                            

                            result = true;
                        }
                        catch (Exception err)
                        {
                            throw;
                        }
                        finally
                        {
                            web.AllowUnsafeUpdates = allowUnsafeUpdates;
                        }
                    }
                }
            });

            return result;
        }
    }
}
