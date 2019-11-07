using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using UserManagement.DAL;
using UserManagement.Models;
using UserManagement.Utilities;

namespace UserManagement
{
    public class Startup
    {
        private IConfigurationRoot Configuration;

        private string currentPath;
        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();

            currentPath = env.ContentRootPath;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            // Ser up EF Core
            string replacedConnection = Configuration.GetSection("Data:SkiShop")?["SkiShopIdentityConnection"];
            string newConnection = replacedConnection.Replace("{path}", currentPath);
            services.AddDbContext<UserDbContext>(options => options.UseSqlServer(newConnection));

            // Set up Identity services
            services.AddIdentity<User, IdentityRole>(opts =>
                {
                    opts.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    opts.User.RequireUniqueEmail = true;

                    opts.Password.RequireNonAlphanumeric = true;
                    opts.Password.RequireLowercase = true;
                    opts.Password.RequireUppercase = true;
                    opts.Password.RequireDigit = true;
                    opts.Password.RequiredLength = 6;

                    // Auth 1/2: Allow cookie authentication
                    opts.Cookies.ApplicationCookie.AuthenticationScheme = "Cookie";
                    opts.Cookies.ApplicationCookie.AutomaticAuthenticate = true;
                    opts.Cookies.ApplicationCookie.AutomaticChallenge = true;
                    opts.Cookies.ApplicationCookie.LoginPath = "/UserAccount/Login";
                    opts.Cookies.ApplicationCookie.AccessDeniedPath = "/UserAccount/AccessDenied";


                })
                .AddEntityFrameworkStores<UserDbContext>()
                .AddDefaultTokenProviders()
                .AddErrorDescriber<CustomIdentityErrorDescriber>();

            // Register a custom password validator
            // Have to add after AddIdentity Service. Otherwise the built-in password validation won't work
            services.AddTransient<IPasswordValidator<User>, NoNamePasswordValidator>();

            // Register a custom user validator
            services.AddTransient<IUserValidator<User>, EmailUserValidator>();

            // Register a custom policy
            services.AddTransient<IAuthorizationHandler, BlockCountriesHandler>();

            //Register a resource policy
            services.AddTransient<IAuthorizationHandler, ScheduleAuthorizationHandler>();

            // Auth 2/2: Use Cookies (step 1) to create the default authorization policy
            services.AddAuthorization(opts =>
            {
                opts.DefaultPolicy = new AuthorizationPolicyBuilder("Cookie")
                    .RequireAuthenticatedUser().Build();

                opts.AddPolicy("NewZealandCustomers", policy =>
                {
                    policy.RequireRole("Customers");
                    policy.RequireClaim(ClaimTypes.Country, "New Zealand");
                });

                opts.AddPolicy("NotNewZealand", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.AddRequirements(new BlockCountriesRequirement(new string[]
                    {
                        "new Zealand"
                    }));
                });

                opts.AddPolicy("Schedule", policy =>
                {
                    policy.AddRequirements(new ScheduleAuthorizationRequirement
                    {
                        AllowManager = true,
                        AllowAssistant = true
                    })
;                });
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();

                app.UseBrowserLink();
            }

            app.UseStaticFiles( );

            // Add Identity which allows user info to be excluded from the requests and responses
            app.UseIdentity();

            // Auth 1/2: Allow cookie authentication
            //app.UseCookieAuthentication(new CookieAuthenticationOptions
            //{
            //    AuthenticationScheme = "Cookie",
            //    AutomaticAuthenticate = true,
            //    AutomaticChallenge = true,
            //    LoginPath = new PathString("/UserAccount/Login"),
            //    AccessDeniedPath = new PathString("/UserAccount/AccessDenied")
            //});

            app.UseClaimsTransformation(ClaimsProvider.AddClaims);

            app.UseMvcWithDefaultRoute();

            UserDbContextSeed.Seed(app.ApplicationServices).Wait();

        }
    }
}
