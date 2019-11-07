using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace SiteMonitR.Common
{
    public class SiteRecord : TableEntity
    {
        public string Uri { get; set; }
    }

    public class SiteResult : TableEntity
    {
        public string Uri { get; set; }
        public string Status { get; set; }
    }

    public class RefreshDashboardParameters
    {
        public SiteResult SiteResult { get; set; }
    }
}