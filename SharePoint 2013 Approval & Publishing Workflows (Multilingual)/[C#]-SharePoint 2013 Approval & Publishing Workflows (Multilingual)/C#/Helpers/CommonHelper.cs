using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Administration.Claims;
using Microsoft.SharePoint.Publishing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomApprovalWorkflows.Helpers
{
    public class CommonHelper
    {
        public static void EnsurePublishingWorkflows(SPWeb web, bool useSAMLWorkflow, bool remove)
        {
            if (PublishingWeb.IsPublishingWeb(web))
            {
                PublishingWeb pubweb = PublishingWeb.GetPublishingWeb(web);

                if (pubweb != null)
                {
                    string listNames = GlobalSettingsHelper.GetValue(ListConstants.EnablePublishingApprovalWorkflowOnLists);

                    if (!string.IsNullOrEmpty(listNames))
                    {
                        string[] lists = listNames.ToLower().Split(new char[] { ',' });
                        foreach (string listName in lists)
                        {
                            SPList list = null;
                            switch (listName)
                            {
                                case ("pages"):
                                    list = pubweb.PagesList;
                                    break;
                                case ("images"):
                                    list = pubweb.ImagesLibrary;
                                    break;
                                case ("documents"):
                                    list = pubweb.DocumentsLibrary;
                                    break;
                            }

                            if (list != null)
                            {
                                if (remove)
                                {
                                    WorkflowHelper2013.RemoveApprovalWorkflowOnList(web, list, useSAMLWorkflow);
                                }
                                else
                                {
                                    List<WorkflowHelper2013.WorkflowStartEventType> events = new List<WorkflowHelper2013.WorkflowStartEventType>() { WorkflowHelper2013.WorkflowStartEventType.Manual };

                                    WorkflowHelper2013.EnsureApprovalWorkflowOnList(web, list, events, useSAMLWorkflow);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                throw new SPException("This feature can only be enabled on a Publishing Web. However you can configure the approval workflows thru list workflow settings.");
            }
        }

        public static bool IsSamlClaimsBasedEnvironment(SPWeb web)
        {
            // Delcare locals
            bool IsSamlClaimsBased = false;
            SPIisSettings iis = web.Site.WebApplication.IisSettings[SPUrlZone.Default];
            foreach (SPAuthenticationProvider ap in iis.ClaimsAuthenticationProviders)
            {
                SPTrustedAuthenticationProvider tap = ap as SPTrustedAuthenticationProvider;
                if (tap != null)
                {
                    IsSamlClaimsBased = true;
                    break;
                }
            }

            return IsSamlClaimsBased;
        }
    }
}
