using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmMobileSample.UWP
{
    public class Service : IService
    {
        public async Task<AuthenticationResult> Authenticate(string authority, string resource, string clientId, Uri returnUri)
        {
            var authContext = new AuthenticationContext(authority);
            var platformParams = new PlatformParameters(PromptBehavior.RefreshSession, false);
            var authResult = await authContext.AcquireTokenAsync(resource, clientId, returnUri, platformParams);

            return authResult;
        }
    }
}
