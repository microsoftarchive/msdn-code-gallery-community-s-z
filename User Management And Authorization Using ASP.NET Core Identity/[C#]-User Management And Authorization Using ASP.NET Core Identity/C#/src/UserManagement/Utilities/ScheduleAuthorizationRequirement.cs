using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using UserManagement.Models;

namespace UserManagement.Utilities
{
    public class ScheduleAuthorizationRequirement: IAuthorizationRequirement
    {
        public bool AllowManager { get; set; }

        public bool AllowAssistant { get; set; }
    }

    public class ScheduleAuthorizationHandler : AuthorizationHandler<ScheduleAuthorizationRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            ScheduleAuthorizationRequirement requirement)
        {
            Schedule schedule = context.Resource as Schedule;

            string user = context.User.Identity.Name;

            if (schedule != null &&
                ((requirement.AllowManager && schedule.Manager.Equals(user, StringComparison.OrdinalIgnoreCase))
                 || requirement.AllowAssistant && schedule.Assistant.Equals(user, StringComparison.OrdinalIgnoreCase)
                ))
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
            return Task.CompletedTask;
        }
    }
}
