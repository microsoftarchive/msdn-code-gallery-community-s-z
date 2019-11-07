using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;
using System.Collections.Generic;
using CustomApprovalWorkflows.Helpers;
using Microsoft.SharePoint.Publishing;

namespace CustomApprovalWorkflows.Features.ApplyPublishingApprovalWorkflows
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("0fb512c4-dead-4060-90b7-5c19603fc64c")]
    public class PublishingApprovalWorkflowsEventReceiver : SPFeatureReceiver
    {
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            // SharePoint Objects
            SPWeb web = (SPWeb)properties.Feature.Parent;

            CommonHelper.EnsurePublishingWorkflows(web, false, false);
        }


        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            try
            {
                // SharePoint Objects
                SPWeb web = (SPWeb)properties.Feature.Parent;
                CommonHelper.EnsurePublishingWorkflows(web, false, true);
            }
            catch
            {
            }
        }
    }
}
