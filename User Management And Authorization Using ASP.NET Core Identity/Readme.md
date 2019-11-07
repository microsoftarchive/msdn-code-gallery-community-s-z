# User Management And Authorization Using ASP.NET Core Identity
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- ASP.NET Core
- Entity Framework Core 1.0
- ASP.NET Core MVC
- ASP.NET Core Identity API
## Topics
- Authentication
- Authorization
- User Account Management
- bulit-in/custom password/user info validation
## Updated
- 01/16/2017
## Description

<h1>Introduction</h1>
<p><span style="font-size:x-small">This sample shows how to create a user account administration tool, and perform authentication and authorization using ASP.NET Core Identity API.</span></p>
<ol>
<li><span style="font-size:x-small">Configure a web application for ASP.NET Identity API and EF Core</span>
</li><li><span style="font-size:x-small">Create a user database in the project folder AppData</span>
</li><li><span style="font-size:x-small">Seed the database to create a SuperAdmin account</span>
</li><li><span style="font-size:x-small">Validate passwords and other user info&nbsp; using built-in validation</span>
</li><li><span style="font-size:x-small">Implement custom password validation and custom user validation</span>
</li><li><span style="font-size:x-small">Create custom identity error messages for built-in validation</span>
</li><li><span style="font-size:x-small">Implement CRUD user accounts( Remember to validate password before hashing it)</span>
</li><li><span style="font-size:x-small">Authenticate users</span> </li><li><span style="font-size:x-small">Create, delete and manage roles</span> </li><li><span style="font-size:x-small">Authorize users with roles </span></li><li><span style="font-size:x-small">Handle unauthorized situations</span> </li><li><span style="font-size:x-small">Apply custom user properties </span></li><li><span style="font-size:x-small">Perform claim-based authorization through policies</span>
</li><li><span style="font-size:x-small">Implement custom policy requirements</span> </li><li><span style="font-size:x-small">Perform resource-based authorization through policies</span>
</li></ol>
<p>&nbsp;</p>
<h1><strong>Prerequisites:</strong></h1>
<ol>
<li><span style="font-size:x-small">Visual Studio 2015 Update 3</span> </li><li><span style="font-size:x-small">.Net Core 1.0.1</span> </li><li><span style="font-size:x-small">EF Core 1.1.0</span> </li></ol>
<h1><span>Running the Sample</span></h1>
<p><span style="font-size:x-small">Step 1: Create the database using NuGet Package Manager Console</span><span>&nbsp;</span></p>
<p><img id="167955" src="167955-1_pm_2.jpg" alt="" width="616" height="390"></p>
<p><span style="font-size:x-small">Step 2: A SuperAdmin account is seeded the first time you run it. Log in as a SuperAdmin (Password: Secret0107$)</span></p>
<p><span style="font-size:x-small">Note: please <strong>clear all the cookies</strong> of the browser before this step</span></p>
<p><em><img id="167956" src="167956-2_login_superadmin_2.jpg" alt="" width="620" height="277"></em></p>
<p><span style="font-size:x-small">Step 3: Go to Users and change the password since it is hardcoded: authorized by role</span></p>
<p><img id="167957" src="167957-3_home_superadmin_2.jpg" alt="" width="620" height="388"></p>
<p><img id="167958" src="167958-4_users_superadmin_2.jpg" alt="" width="620" height="238"></p>
<p><img id="167959" src="167959-5_edituser_superadmin_2.jpg" alt="" width="620" height="427"></p>
<p><span style="font-size:x-small">Step 4: Create users: authorized by role</span></p>
<p><img id="167960" src="167960-6_userscreate_superadmin_2.jpg" alt="" width="620" height="238"></p>
<p><span style="font-size:x-small">Password validation messages pop up if the password is &ldquo;joe&rdquo;</span></p>
<p><img id="167961" src="167961-7_validatepassword_superadmin_2.jpg" alt="" width="620" height="455"></p>
<p><span style="font-size:x-small">User info validation messages pop up if the password is valid</span></p>
<p><img id="167962" src="167962-8_validateuserinfo_superadmin_2.jpg" alt="" width="620" height="455"></p>
<p><span style="font-size:x-small">A valid user account is created.</span></p>
<p><img id="167964" src="167964-9_createuser_superadmin_2.jpg" alt="" width="620" height="304"></p>
<p><span style="font-size:x-small">Let&rsquo;s create more users.</span></p>
<p><img id="167965" src="167965-10_createuser_superadmin_2.jpg" alt="" width="620" height="430"></p>
<p><span style="font-size:x-small">Step 5: Create and assign roles: authorized by role</span></p>
<p><span style="font-size:x-small">Go back to &ldquo;Home&rdquo; and go to &ldquo;Roles&rdquo;</span></p>
<p><img id="167966" src="167966-11_role_superadmin_2.jpg" alt="" width="620" height="235"></p>
<p><span style="font-size:x-small">Let&rsquo;s create two roles: Customers and Staff</span></p>
<p><em><img id="167968" src="167968-12_createrole_superadmin_2.jpg" alt="" width="620" height="227"></em></p>
<p><img id="167969" src="167969-13_roles_superadmin_2.jpg" alt="" width="620" height="302"></p>
<p><span style="font-size:x-small">Assign roles</span></p>
<p><img id="167970" src="167970-14_assignroles_superadmin_2.jpg" alt="" width="620" height="466"></p>
<p><img id="167971" src="167971-15_assignroles_superadmin_2.jpg" alt="" width="620" height="280"></p>
<p><span style="font-size:x-small">Step 6: This SuperAdmin account has access to &ldquo;Not in New Zealand&rdquo;: authorized by custom policy</span></p>
<p><span style="font-size:x-small">Go back to &ldquo;Home&rdquo; and go to &ldquo;Claims&rdquo;. As we can see, SuperAdmin is not in New Zealand.</span></p>
<p><img id="167972" src="167972-16_claims_superadmin_2.jpg" alt="" width="620" height="316"></p>
<p><img id="167973" src="167973-17_notnzl_superadmin_2.jpg" alt="" width="620" height="217"></p>
<p><span style="font-size:x-small">Step 7: Log out and log in as Joe</span></p>
<p><img id="167974" src="167974-18_home_joe_2.jpg" alt="" width="620" height="388"></p>
<p><span style="font-size:x-small">Step 8: Assign custom user properties</span></p>
<p><img id="167975" src="167975-19_customeuserprop_joe_2.jpg" alt="" width="620" height="260"></p>
<p><img id="167976" src="167976-20_home_joe_2.jpg" alt="" width="620" height="328"></p>
<p><span style="font-size:x-small">Step 9: Joe has access to &ldquo;NZL customers&rdquo;: authorized by role and claim</span></p>
<p><span style="font-size:x-small">As you can see in the second image of step 8, Joe is in Customers role. According to the image below, he is in New Zealand.&nbsp;</span></p>
<p><img id="167977" src="167977-21_claims_joe_2.jpg" alt="" width="620" height="328"></p>
<p><span style="font-size:x-small">So he has access to &ldquo;NZL Customers&rdquo;</span></p>
<p><img id="167978" src="167978-22_nzlcustomer_joe_2.jpg" alt="" width="620" height="196"></p>
<p><span style="font-size:x-small">Step 10: Log out and log in as Bob</span></p>
<p><img id="167979" src="167979-23_home_bob_2.jpg" alt="" width="620" height="507"></p>
<p><span style="font-size:x-small">Step 11: Bob has access to &ldquo;Schedule&rdquo;, and can edit the schedule of Sales department: authorized by role and resource.</span></p>
<p><span style="font-size:x-small">Bob is in Staff role. He is also the assistant of Sales department (hard-coded). So he has full access to the schedule of Sales department. But he cannot edit the schedule of Finance department.&nbsp;</span></p>
<p><img id="167980" src="167980-24_schedule_bob_2.jpg" alt="" width="620" height="275"></p>
<p><img id="167981" src="167981-25_sales_bob_2.jpg" alt="" width="620" height="275"></p>
<p><span style="font-size:x-small">He can also access to &ldquo;Not in NZL&rdquo;.</span></p>
<p><span style="font-size:x-small">Step 12: Try unauthorized cases</span></p>
<p><span style="font-size:x-small"><em><img id="167982" src="167982-26_accessdenied_2.jpg" alt="" width="620" height="275"><br>
</em></span></p>
<p>&nbsp;</p>
<p><span style="font-size:20px; font-weight:bold">Sample Code</span></p>
<p><span style="font-size:20px; font-weight:bold">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">namespace UserManagement.Controllers
{
    [Authorize]
    public class UserAccountController : Controller
    {
        private UserManager&lt;User&gt; userManager;
        private SignInManager&lt;User&gt; signInManager;

        public UserAccountController(UserManager&lt;User&gt; userMgr, SignInManager&lt;User&gt; signInMgr)
        {
            userManager = userMgr;
            signInManager = signInMgr;
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task&lt;IActionResult&gt; Login(LoginVm login, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                User user = await userManager.FindByEmailAsync(login.Email);

                if (user != null)
                {
                    // Cancel existing session
                    await signInManager.SignOutAsync();

                    // Perform the authentication
                    Microsoft.AspNetCore.Identity.SignInResult result = 
                        await signInManager.PasswordSignInAsync(user, login.Password, false, false);

                    if (result.Succeeded)
                    {
                        return Redirect(returnUrl ?? &quot;/&quot;);
                    }
                }
                else // user is null
                {
                    ModelState.AddModelError(nameof(LoginVm.Email), &quot;Invalid user or password&quot;);
                }
            }

            return View(login); // user is null or fail authentication (result.Succeeded = false)
        }

        [Authorize]
        public async Task&lt;IActionResult&gt; Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction(&quot;Index&quot;, &quot;Home&quot;);
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()  // Fired when a user cannot access an action
        {
            return View();
        }
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">namespace</span>&nbsp;UserManagement.Controllers&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[Authorize]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;UserAccountController&nbsp;:&nbsp;Controller&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;UserManager&lt;User&gt;&nbsp;userManager;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;SignInManager&lt;User&gt;&nbsp;signInManager;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;UserAccountController(UserManager&lt;User&gt;&nbsp;userMgr,&nbsp;SignInManager&lt;User&gt;&nbsp;signInMgr)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;userManager&nbsp;=&nbsp;userMgr;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;signInManager&nbsp;=&nbsp;signInMgr;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[AllowAnonymous]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;IActionResult&nbsp;Login(<span class="cs__keyword">string</span>&nbsp;returnUrl)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ViewBag.returnUrl&nbsp;=&nbsp;returnUrl;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpPost]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[AllowAnonymous]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[ValidateAntiForgeryToken]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;async&nbsp;Task&lt;IActionResult&gt;&nbsp;Login(LoginVm&nbsp;login,&nbsp;<span class="cs__keyword">string</span>&nbsp;returnUrl)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(ModelState.IsValid)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;User&nbsp;user&nbsp;=&nbsp;await&nbsp;userManager.FindByEmailAsync(login.Email);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(user&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Cancel&nbsp;existing&nbsp;session</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;signInManager.SignOutAsync();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Perform&nbsp;the&nbsp;authentication</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Microsoft.AspNetCore.Identity.SignInResult&nbsp;result&nbsp;=&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;signInManager.PasswordSignInAsync(user,&nbsp;login.Password,&nbsp;<span class="cs__keyword">false</span>,&nbsp;<span class="cs__keyword">false</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(result.Succeeded)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;Redirect(returnUrl&nbsp;??&nbsp;<span class="cs__string">&quot;/&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__com">//&nbsp;user&nbsp;is&nbsp;null</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ModelState.AddModelError(nameof(LoginVm.Email),&nbsp;<span class="cs__string">&quot;Invalid&nbsp;user&nbsp;or&nbsp;password&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View(login);&nbsp;<span class="cs__com">//&nbsp;user&nbsp;is&nbsp;null&nbsp;or&nbsp;fail&nbsp;authentication&nbsp;(result.Succeeded&nbsp;=&nbsp;false)</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Authorize]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;async&nbsp;Task&lt;IActionResult&gt;&nbsp;Logout()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;signInManager.SignOutAsync();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;RedirectToAction(<span class="cs__string">&quot;Index&quot;</span>,&nbsp;<span class="cs__string">&quot;Home&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[AllowAnonymous]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;IActionResult&nbsp;AccessDenied()&nbsp;&nbsp;<span class="cs__com">//&nbsp;Fired&nbsp;when&nbsp;a&nbsp;user&nbsp;cannot&nbsp;access&nbsp;an&nbsp;action</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
