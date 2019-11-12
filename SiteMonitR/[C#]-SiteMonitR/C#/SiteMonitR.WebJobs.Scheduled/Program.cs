using Microsoft.Azure.Jobs;
using Microsoft.WindowsAzure.Storage.Table;
using SiteMonitR.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace SiteMonitR.WebJobs.Scheduled
{

    class Program
    {
        [NoAutomaticTrigger]
        public static void CheckSitesFunction(

            // the table containing the list of sites
            [Table(SiteMonitRConfiguration.TABLE_NAME_SITES)] 
            IQueryable<SiteRecord> siteRecords,
          
            // update the site results table
            [Table(SiteMonitRConfiguration.TABLE_NAME_SITES)] 
            CloudTable recordTable,
          
            // the queue that will receive site results
            [Queue(SiteMonitRConfiguration.QUEUE_NAME_INCOMING_SITE_LOG)] 
                ICollection<SiteResult> siteResults
            )
        {
            foreach (var nv in siteRecords)
            {
                // create a new result for this site
                var siteResult = new SiteResult
                {
                    Uri = nv.Uri,
                    Status = SiteMonitRConfiguration.DASHBOARD_SITE_CHECKING
                };

                // update the UX to let the user know we're checking the site
                SiteMonitRConfiguration.UpdateDashboard(siteResult);

                // check the site
                var request = (HttpWebRequest)HttpWebRequest.Create(siteResult.Uri);

                try
                {
                    // the site is up
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    siteResult.Status = SiteMonitRConfiguration.DASHBOARD_SITE_UP;
                }
                catch (Exception)
                {
                    // the site is down
                    siteResult.Status = SiteMonitRConfiguration.DASHBOARD_SITE_DOWN;
                }

                // add the result to the list
                // send the messages into the queue individually once this function completes
                siteResults.Add(siteResult);

                // update the UX to let the user know we're done checking this site
                SiteMonitRConfiguration.UpdateDashboard(siteResult);
            }
        }

        static void Main(string[] args)
        {
            JobHost host = new JobHost();
            var methodInfo = typeof(Program).GetMethod("CheckSitesFunction");
            host.Call(methodInfo);
        }
    }
}
