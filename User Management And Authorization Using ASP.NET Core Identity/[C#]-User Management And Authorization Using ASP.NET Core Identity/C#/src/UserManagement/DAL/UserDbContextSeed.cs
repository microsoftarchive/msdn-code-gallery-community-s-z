using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UserManagement.Controllers;
using UserManagement.Models;

namespace UserManagement.DAL
{
    public static class UserDbContextSeed
    {
        public static async Task Seed(IServiceProvider serviceProvider)
        {
            UserManager<User> userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // User Info
            string userName = "SuperAdmin";
            string email = "superadmin@gmail.com";
            string password = "Secret0107$";
            string role = "SuperAdmins";

            if (await userManager.FindByNameAsync(userName) == null)
            {
                // Create SuperAdmins role if it doesn't exist
                if (await roleManager.FindByNameAsync(role) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }

                // Create user account if it doesn't exist
                User user = new User
                {
                    UserName = userName,
                    Email = email
                };

                IdentityResult result = await userManager.CreateAsync(user, password);

                // Assign role to the user
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
        }
    }
}
