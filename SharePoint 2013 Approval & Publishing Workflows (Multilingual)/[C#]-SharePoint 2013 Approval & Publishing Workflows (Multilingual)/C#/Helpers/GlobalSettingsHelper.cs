using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomApprovalWorkflows.Helpers
{
    class GlobalSettingsHelper
    {
        public static string GetValue(string key)
        {
            // Validate input parameters
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("Input parameters cannot be null or empty.");
            }

            // Declare locals
            SPList list = null;
            string value = string.Empty;
            Guid rootSiteId = SPContext.Current.Site.WebApplication.Sites[0].ID;

            SPSecurity.RunWithElevatedPrivileges(delegate
           {
               using (SPSite site = new SPSite(rootSiteId))
               {
                   using (SPWeb web = site.RootWeb)
                   {

                       // Try get Global Settings list
                       list = web.Lists.TryGetList(ListConstants.GlobalSettingsListName);

                       // Test for NULL list value
                       if (list == null)
                       {
                           throw new FileNotFoundException(string.Format("Cannot find the Global Settings configuration list in Web: {0}, with name: {1}.", web.Url, ListConstants.GlobalSettingsListName));
                       }
                       else
                       {
                           // Construct query.
                           SPQuery query = new SPQuery();
                           query.Query = string.Format("<Where><Eq><FieldRef Name= \"{0}\"/><Value Type= \"Text\">{1}</Value></Eq></Where>", ListConstants.GlobalSettingsListItemTitle, key);
                           query.RowLimit = 1;
                           query.ViewFields = @"<FieldRef Name='" + ListConstants.GlobalSettingsListItemTitle + "' /><FieldRef Name='" + ListConstants.GlobalSettingsListItemValue + "' />";

                           // Query the list.
                           SPListItemCollection items = list.GetItems(query);

                           if (items == null || items.Count == 0)
                           {
                               throw new FileNotFoundException(
                                   string.Format("Cannot find a value with key: {0}, in the Global Settings configuration list in Web: {1}, with name: {2}.", key, web.Url, ListConstants.GlobalSettingsListName));
                           }
                           else
                           {
                               // Get the value from the list item.
                               value = Convert.ToString(items[0][ListConstants.GlobalSettingsListItemValue]);
                           }
                       }
                   }
               }
           });

            // Clean-up Locals
            list = null;

            // Return value
            return value;
        }
    }
}
