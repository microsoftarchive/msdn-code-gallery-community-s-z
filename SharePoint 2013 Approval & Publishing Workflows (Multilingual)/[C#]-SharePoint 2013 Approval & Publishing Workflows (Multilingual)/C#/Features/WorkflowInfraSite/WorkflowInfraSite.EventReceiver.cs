using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System;
using System.Runtime.InteropServices;

namespace CustomApprovalWorkflows.Features.WorkflowInfraSite
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("ccefd3c9-7de4-414b-bb83-580fedf69e37")]
    public class WorkflowInfraSiteEventReceiver : SPFeatureReceiver
    {
        // Uncomment the method below to handle the event raised after a feature has been activated.

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            SPSite site = properties.Feature.Parent as SPSite;

            if (site != null && !site.Url.Contains("sites"))
            {
                SPList list = site.RootWeb.Lists.TryGetList(ListConstants.GlobalSettingsListName);

                if (list != null)
                {
                    SPListItem item = list.AddItem();

                    item[ListConstants.GlobalSettingsListItemTitle] = ListConstants.UserTokenPrefix;
                    item[ListConstants.GlobalSettingsListItemValue] = this.GetSamlUserNamePrefix(site.RootWeb);
                    item.Update();
                }
            }
            else
            {
                throw new SPException("This feature can only be activated on Web Application's Root Site Collection");
            }
        }

        /// <summary>
        /// Gets the SAML user name prefix.
        /// </summary>
        /// <param name="currentWeb">The current web.</param>
        /// <returns>User Name Prefix</returns>
        private string GetSamlUserNamePrefix(SPWeb currentWeb)
        {
            // Delcare local
            string originalIssuer = string.Empty;
            SPIisSettings iis = currentWeb.Site.WebApplication.IisSettings[SPUrlZone.Default];

            string userNamePrefix = string.Empty;

            foreach (SPAuthenticationProvider ap in iis.ClaimsAuthenticationProviders)
            {
                SPTrustedAuthenticationProvider tap = ap as SPTrustedAuthenticationProvider;
                if (tap != null)
                {
                    userNamePrefix = string.Format("i:0e.t|{0}|", tap.LoginProviderName);
                    break;
                }
            }

            // Return value
            return userNamePrefix;
        }
    }
}
