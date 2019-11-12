using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using CrmMobileSample;

using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(CrmMobileSample.Droid.Service))]
namespace CrmMobileSample.Droid
{
    public class Service : IService
    {
        public async Task<AuthenticationResult> Authenticate(string authority, string resource, string clientId, Uri returnUri)
        {
            var authContext = new AuthenticationContext(authority);
            var platformParams = new PlatformParameters((Activity)Forms.Context);
            var authResult = await authContext.AcquireTokenAsync(resource, clientId, returnUri, platformParams);
            return authResult;
        }
    }
}