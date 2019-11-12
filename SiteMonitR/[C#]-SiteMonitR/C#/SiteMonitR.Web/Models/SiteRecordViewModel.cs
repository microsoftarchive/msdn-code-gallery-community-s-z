using SiteMonitR.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace SiteMonitR.Web.Models
{
    public class SiteRecordViewModel
    {
        public string Uri { get; set; }
        public string Status { get; set; }
    }
}