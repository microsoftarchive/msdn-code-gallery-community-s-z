using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using SiteMonitR.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteMonitR.Web.Models
{
    public class AzureStorageHelper
    {
        private CloudStorageAccount _storageAccount;
        private Microsoft.WindowsAzure.Storage.Table.CloudTableClient _tableClient;
        private Microsoft.WindowsAzure.Storage.Queue.CloudQueueClient _queueClient;

        public static AzureStorageHelper Connect(string connectionString)
        {
            return new AzureStorageHelper(connectionString);
        }

        private AzureStorageHelper(string connectionString)
        {
            _storageAccount = CloudStorageAccount.Parse(connectionString);
            _tableClient = _storageAccount.CreateCloudTableClient();
            _queueClient = _storageAccount.CreateCloudQueueClient();
        }

        private CloudTable GetSitesTable()
        {
            return GetTable(SiteMonitRConfiguration.TABLE_NAME_SITES);
        }

        private CloudTable GetSiteLogTable()
        {
            return GetTable(SiteMonitRConfiguration.TABLE_NAME_SITE_LOGS);
        }

        private CloudTable GetTable(string tableName)
        {
            var table = _tableClient.GetTableReference(tableName);
            table.CreateIfNotExists();
            return table;
        }

        public IEnumerable<SiteRecordTableEntity> GetSites()
        {
            var sites = GetSitesTable().CreateQuery<SiteRecordTableEntity>().ToList();
            return sites;
        }

        public void QueueNewTrackedSite(SiteRecordTableEntity siteRecord)
        {
            var queue = _queueClient.GetQueueReference(SiteMonitRConfiguration.QUEUE_NAME_NEW_SITE);
            queue.CreateIfNotExists();

            queue.AddMessage(new CloudQueueMessage(siteRecord.Uri));
        }

        public void QueueSiteForDeletion(string url)
        {
            var queue = _queueClient.GetQueueReference(SiteMonitRConfiguration.QUEUE_NAME_DELETE_SITE);
            queue.CreateIfNotExists();

            queue.AddMessage(new CloudQueueMessage(url));
        }

        public SiteLogTableEntity GetLatestLogForSite(string uri)
        {
            var partitionKey = SiteMonitRConfiguration.CleanUrlForRowKey(uri);

            var query = new TableQuery<SiteLogTableEntity>().Where(
                TableQuery.GenerateFilterCondition("Uri", QueryComparisons.Equal, uri)
                );

            var tbl = GetSiteLogTable();

            var ret = tbl.ExecuteQuery<SiteLogTableEntity>(query)
                .OrderByDescending(x => x.Timestamp)
                    .FirstOrDefault();

            return ret;
        }
    }
}