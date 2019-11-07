using Microsoft.WindowsAzure.Storage.Table;
using SiteMonitR.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteMonitR.Web.Models
{
    public class SiteRecordTableEntity : TableEntity
    {
        public SiteRecordTableEntity()
        {
            this.PartitionKey = SiteMonitRConfiguration.GetPartitionKey();
        }

        private string _Uri;
        public string Uri 
        {
            get
            {
                return _Uri;
            }
            set
            {
                _Uri = value;
                this.RowKey = SiteMonitRConfiguration.CleanUrlForRowKey(_Uri);
            }
        }
    }
}