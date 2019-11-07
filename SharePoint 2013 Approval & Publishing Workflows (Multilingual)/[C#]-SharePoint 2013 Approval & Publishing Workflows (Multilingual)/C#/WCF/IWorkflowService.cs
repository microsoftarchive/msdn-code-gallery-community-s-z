// -----------------------------------------------------------------------
// <copyright file="IWorkflowService.cs" company="Microsoft">
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
    using System.ServiceModel;
    using System.ServiceModel.Web;
    
    /// <summary>
    /// Defines the social services WCF services
    /// </summary>
    [ServiceContract]
    public interface IWorkflowService
    {
        /// <summary>
        /// Updates the workflow status.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <returns>update status</returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/UpdateItemStatus")]
        bool UpdateItemWorkflowStatus(WorkflowItemInfo status);

        /// <summary>
        /// Gets the configuration info from the platform site
        /// </summary>
        /// <param name="title">Title of the item to be fetched from configuration list</param>
        /// <returns>Response object</returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Config?title={title}")]
        ConfigResponse GetConfigData(string title);

        /// <summary>
        /// Ensures list of users in the given site
        /// </summary>
        /// <param name="request">Content of the request</param>
        /// <returns>Response object</returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/EnsureUsers")]
        EnsureUserRequestResponse EnsureUsers(EnsureUserRequestResponse request);

        /// <summary>
        /// Approves a list item
        /// </summary>
        /// <param name="listIdStr">The list id GUID, in string form</param>
        /// <param name="itemId">The item id</param>
        /// <returns>True if the operation is successful; false, otherwise</returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Approve?list={listIdStr}&item={itemId}")]
        bool ApproveItem(string listIdStr, int itemId);

        /// <summary>
        /// Rejects a list item
        /// </summary>
        /// <param name="listIdStr">The list id GUID, in string form</param>
        /// <param name="itemId">The item id</param>
        /// <returns>True if the operation is successful; false, otherwise</returns>
        [OperationContract]
         [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Reject?list={listIdStr}&item={itemId}")]
        bool RejectItem(string listIdStr, int itemId);
    }
}
