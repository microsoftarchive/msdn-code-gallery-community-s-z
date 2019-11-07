using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using UserManagement.Models;

namespace UserManagement.Utilities
{
    public class NoNamePasswordValidator : IPasswordValidator<User>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user, string password)
        {

            if (password.ToLower().Contains(user.UserName.ToLower()))
            {
                return Task.FromResult(IdentityResult.Failed(new IdentityError
                {
                    Code = "PasswordContainsUserName",
                    Description = "Password cannot contain your user name."
                }));
            }
            else
            {
                return Task.FromResult(IdentityResult.Success);
            }
            
        }

    }
}
