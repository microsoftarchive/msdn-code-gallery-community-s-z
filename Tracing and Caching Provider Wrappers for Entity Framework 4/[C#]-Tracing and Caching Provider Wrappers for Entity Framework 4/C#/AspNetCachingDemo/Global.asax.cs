using System;
using EFCachingProvider;
using EFCachingProvider.Caching;
using EFCachingProvider.Web;
using EFTracingProvider;

namespace AspNetCachingDemo
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            EFTracingProviderConfiguration.LogToFile = Server.MapPath("~/sqllog.txt");

            EFCachingProviderConfiguration.DefaultCache = new AspNetCache();
            EFCachingProviderConfiguration.DefaultCachingPolicy = CachingPolicy.CacheAll;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}