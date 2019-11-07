using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using UserManagement.Models;

namespace UserManagement.Utilities
{
    public class EmailUserValidator:IUserValidator<User>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user)
        {
            if (user.Email.ToLower().EndsWith("@example.com"))
            {
                return Task.FromResult(IdentityResult.Failed(new IdentityError
                {
                    Code = "EmailDomainError",
                    Description = "example.com email addresses are NOT allowed."
                }));
            }
            else
            {
                return Task.FromResult(IdentityResult.Success);
            }
        }
    }
}
