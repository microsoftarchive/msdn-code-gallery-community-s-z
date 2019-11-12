using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmMobileSample
{
    public interface IService
    {
        Task<AuthenticationResult> Authenticate(string authority, string resource, string clientId, Uri redirectUri);
    }
}
