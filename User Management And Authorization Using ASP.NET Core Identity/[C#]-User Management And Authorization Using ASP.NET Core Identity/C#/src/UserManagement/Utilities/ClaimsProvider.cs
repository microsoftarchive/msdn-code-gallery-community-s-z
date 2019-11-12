using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace UserManagement.Utilities
{
    public static class ClaimsProvider
    {
        public static Task<ClaimsPrincipal> AddClaims(ClaimsTransformationContext context)
        {
            string userName = "Joe";
            // new claim for userName
            string issuer = "Simulator";
            string valueType = ClaimValueTypes.String;
            string type1 = ClaimTypes.Country;
            string value1 = "New Zealand";
            string type2 = ClaimTypes.StateOrProvince;
            string value2 = "Wellington";

            // new claim for non-userName
            string value = "Null";

            ClaimsPrincipal principal = context.Principal;

            if (principal != null && !principal.HasClaim(c => c.Type == ClaimTypes.Country))
            {
                ClaimsIdentity identity = principal.Identity as ClaimsIdentity;
                if (identity != null && identity.IsAuthenticated && identity.Name != null)
                {
                    if (identity.Name.ToLower() == userName.ToLower())
                    {
                        identity.AddClaims(new Claim[]
                        {
                            new Claim(type1, value1, valueType, issuer),
                            new Claim(type2, value2, valueType, issuer)
                        });
                    }
                    else // Not Joe
                    {
                        identity.AddClaims(new Claim[]
                        {
                            new Claim(type1, value, valueType, issuer),
                            new Claim(type2, value, valueType, issuer),
                        });
                    }
                }
            }

            return Task.FromResult(principal);
        }
    }
}
