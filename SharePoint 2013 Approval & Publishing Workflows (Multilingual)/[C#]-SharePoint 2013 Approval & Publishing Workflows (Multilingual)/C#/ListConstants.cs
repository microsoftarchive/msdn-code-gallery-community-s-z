using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomApprovalWorkflows
{
    public class ListConstants
    {
        /// <summary>
        /// Global Settings List Name
        /// </summary>
        public const string GlobalSettingsListName = "Global Settings";

        /// <summary>
        /// Global Settings List Item Title
        /// </summary>
        public const string GlobalSettingsListItemTitle = "Title";

        /// <summary>
        /// Global Settings List Item Value
        /// </summary>
        public const string GlobalSettingsListItemValue = "Value";

        /// <summary>
        /// The prefix of user identity token
        /// </summary>
        public const string UserTokenPrefix = "UserTokenPrefix";

        /// <summary>
        /// Role resolver uri
        /// </summary>
        public const string RoleResolverUri = "RoleResolverUri";

        /// <summary>
        /// The Approval Approvers SharePoint Group
        /// </summary>
        public const string ApprovalWorkflowApproversSharePointGroup = "ApprovalWorkflowApproversSharePointGroup";

        /// <summary>
        /// The Approval Approvers Default Duration in Days
        /// </summary>
        public const string ApprovalWorkflowDefaultDurationDays = "ApprovalWorkflowDefaultDurationDays";

        /// <summary>
        /// Approval Workflow Moderation Comment
        /// </summary>
         public const string ApprovalWorkflowModerationComment = "Updated by Custom Approval Workflow";

         /// <summary>
         /// Enable Publishing Approval Workflow on Lists
         /// </summary>
         public const string EnablePublishingApprovalWorkflowOnLists = "EnablePublishingApprovalWorkflowOnLists";

         /// <summary>
         /// Whether to Use SAML Workflow For Publishing Approval
         /// </summary>
         public const string UseSAMLWorkflowForPublishingApproval = "UseSAMLWorkflowForPublishingApproval";
    }
}
