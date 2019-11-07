using Microsoft.Azure.Jobs;
using Microsoft.WindowsAzure.Storage.Table;
using SiteMonitR.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace SiteMonitR.WebJobs.EventDriven
{
    class Program
    {
        public static void AddSite(

            // the incoming queue
            [QueueTrigger(SiteMonitRConfiguration.QUEUE_NAME_NEW_SITE)] string url,
            
            // the list of all sites
            [Table(SiteMonitRConfiguration.TABLE_NAME_SITES)] 
            IQueryable<SiteRecord> listOfSiteRecords,

            // the table into which sites should be saved
            [Table(SiteMonitRConfiguration.TABLE_NAME_SITES)] 
            CloudTable table
            )
        {
            var cleansedUrl = SiteMonitRConfiguration.CleanUrlForRowKey(url);
            var siteRecord = new SiteRecord();
            siteRecord.RowKey = SiteMonitRConfiguration.GetPartitionKey();
            siteRecord.PartitionKey = cleansedUrl;
            siteRecord.Uri = url;
            if (!listOfSiteRecords.ToList().Any(entity => entity.PartitionKey == siteRecord.PartitionKey))
            {
                table.Execute(TableOperation.InsertOrReplace(siteRecord));
            }
        }

        public static void DeleteSite(

            // the incoming queue
            [QueueTrigger(SiteMonitRConfiguration.QUEUE_NAME_DELETE_SITE)] string url,

            // the list of all sites
            [Table(SiteMonitRConfiguration.TABLE_NAME_SITES)] 
            IQueryable<SiteRecord> listofSiteRecords,

            // the list of all site logs
            [Table(SiteMonitRConfiguration.TABLE_NAME_SITE_LOGS)] 
            IQueryable<SiteResult> listofSiteResults,

            // the site list table from which data should be deleted
            [Table(SiteMonitRConfiguration.TABLE_NAME_SITES)] 
            CloudTable recordTable,

            // the site log table from which data should be deleted
            [Table(SiteMonitRConfiguration.TABLE_NAME_SITE_LOGS)] 
            CloudTable resultTable
            )
        {
            var cleansedUrl = SiteMonitRConfiguration.CleanUrlForRowKey(url);

            if (listofSiteRecords.ToList().Any(entity => entity.PartitionKey == cleansedUrl))
            {
                var siteRecord = listofSiteRecords.ToList().Where(entity => entity.RowKey == cleansedUrl).FirstOrDefault();
                recordTable.Execute(TableOperation.Delete(siteRecord));
            }
            // delete all the site's logs
            foreach (var siteResult in listofSiteResults)
            {
                if (siteResult.PartitionKey == cleansedUrl)
                {
                    resultTable.Execute(TableOperation.Delete(siteResult));
                }
            }
        }

        public static void SaveSiteLogEntry(

            // the incoming queue
            [QueueTrigger(SiteMonitRConfiguration.QUEUE_NAME_INCOMING_SITE_LOG)] 
                SiteResult siteResult,

            // the site log table, into which data will be saved
            [Table(SiteMonitRConfiguration.TABLE_NAME_SITE_LOGS)] 
            CloudTable resultTable
            )
        {
            siteResult.RowKey = SiteMonitRConfiguration.CleanUrlForRowKey(siteResult.Uri);
            siteResult.PartitionKey = Path.GetFileNameWithoutExtension(Path.GetRandomFileName());
            resultTable.Execute(TableOperation.InsertOrReplace(siteResult));
        }

        static void Main(string[] args)
        {
            JobHost host = new JobHost();
            host.RunAndBlock();
        }
    }
}
