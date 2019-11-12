using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomApprovalWorkflows.Helpers
{
    public class ResourcesHelper
    {
        /// <summary>
        /// Resource file Key
        /// </summary>
        private const string ResxFileKey = "$Resources:CustomApprovalWorkflows,";

        private const string ResxFileName = "CustomApprovalWorkflows";

        public static string GetLocalizedString(string key)
        {
            return SPUtility.GetLocalizedString(string.Format("{0}{1}", ResxFileKey, key), ResxFileName, SPContext.Current.Web.Language);
        }

        public static string GetLocalizedString(string key, SPWeb web)
        {
            return SPUtility.GetLocalizedString(string.Format("{0}{1}", ResxFileKey, key), ResxFileName, web.Language);
        }
    }
}
