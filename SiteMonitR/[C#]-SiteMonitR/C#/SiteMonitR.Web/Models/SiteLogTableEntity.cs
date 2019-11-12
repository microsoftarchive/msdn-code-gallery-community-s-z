using Microsoft.WindowsAzure.Storage.Table;
using SiteMonitR.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteMonitR.Web.Models
{
    public class SiteLogTableEntity : TableEntity
    {
        public string Uri { get; set; }
        public string Status { get; set; }
    }
}