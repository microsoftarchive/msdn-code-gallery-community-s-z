# Simple Asp.net Identity Core Without Entity Framework
## Requires
- Visual Studio 2013
## License
- MS-LPL
## Technologies
- ASP.NET 4.5
- ASP.NET Identity
## Topics
- Custom authentication
- ASP.NET Security
## Updated
- 07/06/2014
## Description

<h1>Introduction</h1>
<ol>
<li><em>&nbsp;Sample Demo Project with Simple Asp.net Identity Core just a Login functionality.</em>
</li><li><em>&nbsp;No Entity Framework, Custom approach to suit our own database table user object.</em>
</li><li><em>&nbsp;No Role based login, a simple login with custom password hashing and user details.</em>
</li></ol>
<h1><span>Technical Details</span></h1>
<p style="text-align:justify">Suppose we have one User table which holds UserID-GUID, password, UserName , first Name, last Name, Birth Date and so on. In such case below asp.net identity best works for us. It is independent of Entity Framework&nbsp;and we
 can leverage the design of Asp.net Identity for our user authentication.&nbsp;The&nbsp;end objective&nbsp;is to use the our custom database user detail table for user credential and align Asp.net Identity core to do authentication. Moreover it also helps with
 password hashing where one can easily migrate password without asking user to change password or create new one for existing stored password.</p>
<p><strong>Model</strong></p>
<ol>
<li>ApplicationUser is custom User object that implements IUser. </li><li>IUser has two field Id and UserName. ID=GUID only Get . </li><li>CustomUserManager implements UserManager. </li><li>UserManager also have IUserStore object which exposed methods to Create,Update and delete user account.
</li><li>CustomUserManager constructor have CustomUserStore as Input Parameter. Which extends IUserStore
</li><li>Importantly UserManager has passwordhashing class object which provides us provision to define our own hashing password logic.
</li></ol>
<p><strong>&nbsp;</strong></p>
<p><strong>&nbsp;</strong></p>
<p><span style="font-size:20px; font-weight:bold">Code Implementation</span></p>
<p><strong><span style="font-size:small">&nbsp;CustomUserManager</span></strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public class CustomUserManager:UserManager&lt;ApplicationUser&gt;
    {        
        public CustomUserManager() : base(new CustomUserSore&lt;ApplicationUser&gt;())
        {            
            //We can retrieve Old System Hash Password and can encypt or decrypt old password using custom approach.
	    //When we want to reuse old system password as it would be difficult for all users to initiate pwd change as per Idnetity Core hashing.
            this.PasswordHasher = new OldSystemPasswordHasher();           
        }
       
        public override System.Threading.Tasks.Task&lt;ApplicationUser&gt; FindAsync(string userName, string password)
        {
            Task&lt;ApplicationUser&gt; taskInvoke = Task&lt;ApplicationUser&gt;.Factory.StartNew(() =&gt;
                {
                    //First Verify Password...
                    PasswordVerificationResult result = this.PasswordHasher.VerifyHashedPassword(userName, password);
                    if (result == PasswordVerificationResult.SuccessRehashNeeded)
                    {
                        //Return User Profile Object...
                        //So this data object will come from Database we can write custom ADO.net to retrieve details/
                        ApplicationUser applicationUser = new ApplicationUser();
                        applicationUser.UserName = &quot;san&quot;;                                              
                        return applicationUser;
                    }
                    return null;
                });
            return taskInvoke;
        }      
    }

    /// &lt;summary&gt;
    /// Use Custom approach to verify password
    /// &lt;/summary&gt;
    public class OldSystemPasswordHasher : PasswordHasher
    {
        public override string HashPassword(string password)
        {
            return base.HashPassword(password);
        }

        public override PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {

            //Here we will place the code of password hashing that is there in our current solucion.This will take cleartext anad hash
	    //Just for demonstration purpose I always return true.	
            if (true)
            {


                return PasswordVerificationResult.SuccessRehashNeeded;
            }
            else
            {
                return PasswordVerificationResult.Failed;
            }
        }
    }</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;CustomUserManager:UserManager&lt;ApplicationUser&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;CustomUserManager()&nbsp;:&nbsp;<span class="cs__keyword">base</span>(<span class="cs__keyword">new</span>&nbsp;CustomUserSore&lt;ApplicationUser&gt;())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//We&nbsp;can&nbsp;retrieve&nbsp;Old&nbsp;System&nbsp;Hash&nbsp;Password&nbsp;and&nbsp;can&nbsp;encypt&nbsp;or&nbsp;decrypt&nbsp;old&nbsp;password&nbsp;using&nbsp;custom&nbsp;approach.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//When&nbsp;we&nbsp;want&nbsp;to&nbsp;reuse&nbsp;old&nbsp;system&nbsp;password&nbsp;as&nbsp;it&nbsp;would&nbsp;be&nbsp;difficult&nbsp;for&nbsp;all&nbsp;users&nbsp;to&nbsp;initiate&nbsp;pwd&nbsp;change&nbsp;as&nbsp;per&nbsp;Idnetity&nbsp;Core&nbsp;hashing.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.PasswordHasher&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;OldSystemPasswordHasher();&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;System.Threading.Tasks.Task&lt;ApplicationUser&gt;&nbsp;FindAsync(<span class="cs__keyword">string</span>&nbsp;userName,&nbsp;<span class="cs__keyword">string</span>&nbsp;password)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Task&lt;ApplicationUser&gt;&nbsp;taskInvoke&nbsp;=&nbsp;Task&lt;ApplicationUser&gt;.Factory.StartNew(()&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//First&nbsp;Verify&nbsp;Password...</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PasswordVerificationResult&nbsp;result&nbsp;=&nbsp;<span class="cs__keyword">this</span>.PasswordHasher.VerifyHashedPassword(userName,&nbsp;password);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(result&nbsp;==&nbsp;PasswordVerificationResult.SuccessRehashNeeded)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Return&nbsp;User&nbsp;Profile&nbsp;Object...</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//So&nbsp;this&nbsp;data&nbsp;object&nbsp;will&nbsp;come&nbsp;from&nbsp;Database&nbsp;we&nbsp;can&nbsp;write&nbsp;custom&nbsp;ADO.net&nbsp;to&nbsp;retrieve&nbsp;details/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ApplicationUser&nbsp;applicationUser&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ApplicationUser();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;applicationUser.UserName&nbsp;=&nbsp;<span class="cs__string">&quot;san&quot;</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;applicationUser;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;taskInvoke;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Use&nbsp;Custom&nbsp;approach&nbsp;to&nbsp;verify&nbsp;password</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;OldSystemPasswordHasher&nbsp;:&nbsp;PasswordHasher&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;HashPassword(<span class="cs__keyword">string</span>&nbsp;password)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">base</span>.HashPassword(password);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;PasswordVerificationResult&nbsp;VerifyHashedPassword(<span class="cs__keyword">string</span>&nbsp;hashedPassword,&nbsp;<span class="cs__keyword">string</span>&nbsp;providedPassword)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Here&nbsp;we&nbsp;will&nbsp;place&nbsp;the&nbsp;code&nbsp;of&nbsp;password&nbsp;hashing&nbsp;that&nbsp;is&nbsp;there&nbsp;in&nbsp;our&nbsp;current&nbsp;solucion.This&nbsp;will&nbsp;take&nbsp;cleartext&nbsp;anad&nbsp;hash</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Just&nbsp;for&nbsp;demonstration&nbsp;purpose&nbsp;I&nbsp;always&nbsp;return&nbsp;true.&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">true</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;PasswordVerificationResult.SuccessRehashNeeded;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;PasswordVerificationResult.Failed;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<h1><span style="font-size:small">CustomUserStore- </span></h1>
<h1><span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public class CustomUserSore&lt;T&gt; : IUserStore&lt;T&gt; where T : ApplicationUser
    {

        System.Threading.Tasks.Task IUserStore&lt;T&gt;.CreateAsync(T user)
        {
            //Create /Register New User
            throw new NotImplementedException();
        }

        System.Threading.Tasks.Task IUserStore&lt;T&gt;.DeleteAsync(T user)
        {
            //Delete User
            throw new NotImplementedException();
        }

        System.Threading.Tasks.Task&lt;T&gt; IUserStore&lt;T&gt;.FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        System.Threading.Tasks.Task&lt;T&gt; IUserStore&lt;T&gt;.FindByNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        System.Threading.Tasks.Task IUserStore&lt;T&gt;.UpdateAsync(T user)
        {
            //Update User Profile
            throw new NotImplementedException();
        }

        void IDisposable.Dispose()
        {
            // throw new NotImplementedException();

        }
    }</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;CustomUserSore&lt;T&gt;&nbsp;:&nbsp;IUserStore&lt;T&gt;&nbsp;where&nbsp;T&nbsp;:&nbsp;ApplicationUser&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Threading.Tasks.Task&nbsp;IUserStore&lt;T&gt;.CreateAsync(T&nbsp;user)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Create&nbsp;/Register&nbsp;New&nbsp;User</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;NotImplementedException();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Threading.Tasks.Task&nbsp;IUserStore&lt;T&gt;.DeleteAsync(T&nbsp;user)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Delete&nbsp;User</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;NotImplementedException();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Threading.Tasks.Task&lt;T&gt;&nbsp;IUserStore&lt;T&gt;.FindByIdAsync(<span class="cs__keyword">string</span>&nbsp;userId)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;NotImplementedException();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Threading.Tasks.Task&lt;T&gt;&nbsp;IUserStore&lt;T&gt;.FindByNameAsync(<span class="cs__keyword">string</span>&nbsp;userName)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;NotImplementedException();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Threading.Tasks.Task&nbsp;IUserStore&lt;T&gt;.UpdateAsync(T&nbsp;user)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Update&nbsp;User&nbsp;Profile</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;NotImplementedException();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">void</span>&nbsp;IDisposable.Dispose()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;throw&nbsp;new&nbsp;NotImplementedException();</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">&nbsp;ApplicationUser</span></div>
</span></h1>
<h1><span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public class ApplicationUser : IUser
    {
        public DateTime CreateDate { get; set; }
        public DateTime BirthDate { get; set; }

        public ApplicationUser()
        {
            CreateDate = DateTime.Now;           
        }
        public string Id
        {
            get { return &quot;GUID&quot;; }
        }

        public string UserName
        {
            get
            {
                return &quot;san&quot;;
            }
            set
            {
               ;
            }
        }
    }</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;ApplicationUser&nbsp;:&nbsp;IUser&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;DateTime&nbsp;CreateDate&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;DateTime&nbsp;BirthDate&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ApplicationUser()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CreateDate&nbsp;=&nbsp;DateTime.Now;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Id&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__string">&quot;GUID&quot;</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;UserName&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__string">&quot;san&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">In Models we have just made use of reference of&nbsp; Microsoft.AspNet.Identity;</span></div>
</span></h1>
<h1><span style="font-size:x-small"><em><em>For login you download the code and it is self explanatory.</em></em></span></h1>
<h1>References</h1>
<p><em>If you have confusion for claimbased authentication then you must look into below blogpost to clarify your doubts.I tried to use simple login authentication without claim /token or role based authentication. So IUser and IUserStore just give user profile
 level of authentication and access point.</em></p>
<h2><br>
<span style="text-decoration:underline"><strong><span style="font-size:small">Some Known Issues-</span></strong></span></h2>
<p><span style="font-size:small">If GetOwinContext() throws Null Reference Error- Do follow below instructions.</span></p>
<p>&nbsp;</p>
<li><span style="font-size:small">Set <span style="font-size:medium"><code>httpRuntime.targetFramework</code></span> to<span style="font-size:medium">
<code>4.5</code></span>, or </span></li><li><span style="font-size:small">In your <span style="font-size:medium"><code>appSettings</code></span>, set<span style="font-size:medium">
<code>aspnet:UseTaskFriendlySynchronizationContext</code> </span>to <span style="font-size:medium">
<code>true</code></span>. </span>
<p>&nbsp;</p>
<p><a href="http://bartwullems.blogspot.se/2013/09/aspnet-web-api-httpcontextcurrent-is.html">http://bartwullems.blogspot.se/2013/09/aspnet-web-api-httpcontextcurrent-is.html</a><br>
<br>
<a href="http://vegetarianprogrammer.blogspot.se/2012/12/understanding-synchronizationcontext-in.html">http://vegetarianprogrammer.blogspot.se/2012/12/understanding-synchronizationcontext-in.html</a></p>
<p>&nbsp;</p>
<p><span style="font-size:small">Owin Open web Interface pipeline issue w.r.t IIS pipeline</span></p>
<p>&nbsp;</p>
</li><li style="text-align:left"><span style="font-size:small">Check if your IIS application pool is in Integrated mode. Note: Running of an OWIN middleware is supported only on IIS Integrated pipeline. Classic pool is not supported.&nbsp;
</span></li><li style="text-align:left"><span style="font-size:small">Check if you have Microsoft.Owin.Host.SystemWeb Nuget package installed. This package is required for the OWIN startup class detection.
</span></li><li style="text-align:left"><span style="font-size:small">If your Startup class is still not detected in IIS, try it again by clearing the ASP.net temporary files.&nbsp;
</span></li><li style="text-align:left"><span style="font-size:small">&nbsp;Sometimes Owin works well with VS IISexpress .
</span>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">appSettings&gt;





 &lt;

add key=&quot;owin:AppStartup&quot; value=&quot;[AssemblyNamespace].Startup,[AssemblyName]&quot; /&gt;


 &lt;/

appSettings&gt;</pre>
<div class="preview">
<pre class="xml">appSettings&gt;&nbsp;
&nbsp;
&nbsp;
&nbsp;
&nbsp;
&nbsp;
&nbsp;&lt;&nbsp;
&nbsp;
add&nbsp;key=&quot;owin:AppStartup&quot;&nbsp;value=&quot;[AssemblyNamespace].Startup,[AssemblyName]&quot;&nbsp;<span class="xml__tag_end">/&gt;</span>&nbsp;
&nbsp;
&nbsp;
&nbsp;&lt;/&nbsp;
&nbsp;
appSettings&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>There are two class one<br>
IUserClaimStore and IUserStore. So we are using IUserStore .</p>
<p><a href="http://odetocode.com/blogs/scott/archive/2013/11/25/asp-net-core-identity.aspx">http://odetocode.com/blogs/scott/archive/2013/11/25/asp-net-core-identity.aspx</a></p>
<p><a href="http://www.tuicool.com/articles/zaeu2m">http://www.tuicool.com/articles/zaeu2m</a></p>
<p><a href="http://www.santoshpoojari.blogspot.com">www.santoshpoojari.blogspot.com</a></p>
<p>&nbsp;</p>
</li>