using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace UserManagement.Utilities
{
    public class BlockCountriesRequirement: IAuthorizationRequirement
    {
        public string[] countries;
        public BlockCountriesRequirement(string[] countriesBlocked)
        {
            countries = countriesBlocked;
        }
    }

    public class BlockCountriesHandler : AuthorizationHandler<BlockCountriesRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            BlockCountriesRequirement requirement)
        {
            if (context.User.Identity == null || context.User.Identity.Name == null)
            {
                context.Fail();
                return Task.CompletedTask;
            }

            if (!context.User.HasClaim(c => c.Type == ClaimTypes.Country))
            {
                context.Succeed(requirement);
            }
            else
            {
                if (
                    requirement.countries.Any(
                        country =>
                            country.Equals(context.User.FindFirst(c => c.Type == ClaimTypes.Country).Value,
                                StringComparison.OrdinalIgnoreCase)))
                {
                    context.Fail();
                }
                else
                {
                    context.Succeed(requirement);
                }
            }

            return Task.CompletedTask;
        }
    }
}
