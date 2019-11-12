using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SiteMonitR.Common
{
    public class SiteMonitRConfiguration
    {
        public const string TABLE_NAME_SITES = "SiteMonitRSites";
        public const string TABLE_NAME_SITE_LOGS = "SiteMonitRSiteLog";
        public const string QUEUE_NAME_NEW_SITE = "sitemonitr-site-create";
        public const string QUEUE_NAME_INCOMING_SITE_LOG = "sitemonitr-site-result";
        public const string QUEUE_NAME_DELETE_SITE = "sitemonitr-site-delete";
        public const string DASHBOARD_SITE_UP = "Up";
        public const string DASHBOARD_SITE_DOWN = "Down";
        public const string DASHBOARD_SITE_CHECKING = "Checking";
        public const string DASHBOARD_SITE_UNCHECKED = "Unchecked";

        public static string CleanUrlForRowKey(string url)
        {
            var regexp = new System.Text.RegularExpressions.Regex(@"([{}\(\)\^$&._%#!@=<>:;,~`'\’\*\?\/\+\|\[\\\\]|\]|\-)");
            var cleansedUrl = regexp.Replace(url, string.Empty);
            return cleansedUrl;
        }

        private static string GetAppSetting(string key, string defaultValue)
        {
            var config = ConfigurationManager.AppSettings[key];

            if (config == null)
                return defaultValue;
            else
                return config;
        }

        public static string GetPartitionKey()
        {
            return GetAppSetting("SiteMonitR.PartitionKey", "default");
        }

        public static string GetDashboardUrl()
        {
            return GetAppSetting("SiteMonitR.DashboardUrl", "http://localhost:9675");
        }

        private static HttpClient GetWebApiClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(GetDashboardUrl());
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        public static async void UpdateDashboard(SiteResult status)
        {
            using (var client = GetWebApiClient())
            {
                await client.PostAsJsonAsync<SiteResult>("api/updatedashboard", status);
            }
        }

        public static async void RefreshDashboard()
        {
            using (var client = GetWebApiClient())
            {
                await client.GetAsync("api/refreshdashboard");
            }
        }



    }
}
