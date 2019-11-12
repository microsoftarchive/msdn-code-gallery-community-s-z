using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using SiteMonitR.Common;
using SiteMonitR.Web.Hubs;
using SiteMonitR.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SiteMonitR.Web.Controllers
{
    public class SitesController : ApiController
    {
        AzureStorageHelper _helper;

        public SitesController()
        {
            _helper = AzureStorageHelper.Connect(
                ConfigurationManager.ConnectionStrings["AzureJobsStorage"]
                    .ConnectionString
                );
        }

        public IEnumerable<SiteRecordViewModel> Get()
        {
            var siteList = _helper.GetSites();

            var ret = siteList.Select(x =>
                {
                    var logEntry = _helper.GetLatestLogForSite(x.Uri);

                    return new SiteRecordViewModel
                    {
                        Uri = x.Uri,
                        Status = logEntry != null ? logEntry.Status : "Unchecked"
                    };
                });

            return ret;
        }

        public bool Post(SiteRecord site)
        {
            try
            {
                _helper.QueueNewTrackedSite(new SiteRecordTableEntity
                    {
                        Uri = site.Uri
                    });

                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpDelete]
        public bool Delete([FromBody]SiteResult siteResult)
        {
            try
            {
                _helper.QueueSiteForDeletion(siteResult.Uri);
                return true;
            }
            catch
            {
                return false;
            }
        }

        [Route("api/updatedashboard")]
        [HttpPost]
        public void UpdateDashboard(SiteResult status)
        {
            var hub = GlobalHost.ConnectionManager.GetHubContext<SiteMonitRHub>();

            hub.Clients.All.siteStatusReceived(new
            {
                Uri = status.Uri,
                Status = status.Status
            });
        }

        [Route("api/refreshdashboard")]
        [HttpGet]
        public void RefreshDashboard()
        {
            var hub = GlobalHost.ConnectionManager.GetHubContext<SiteMonitRHub>();

            hub.Clients.All.refreshDashboard();
        }





    }
}