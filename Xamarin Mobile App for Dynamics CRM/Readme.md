# Xamarin Mobile App for Dynamics CRM
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- Xamarin.Forms
- Microsoft Dynamics CRM 2016
- Microsoft Dynamics CRM Online
## Topics
- Xamarin/Android
- Xamarin.Forms
- Microsoft Dynamics CRM Web API
## Updated
- 10/18/2016
## Description

<h1>Introduction</h1>
<p>This sample shows how to connect a Xamarin Forms app to Dynamics CRM Online using the new Web API.</p>
<h1><span>Building the Sample</span></h1>
<p>Xamarin -&nbsp;https://www.xamarin.com/download-it?_bt=101035045148&amp;_bk=xamarin%20download&amp;_bm=e&amp;gclid=Cj0KEQjwg8i_BRCT9dHt5ZSGi90BEiQAItdjpA2aCRUPen55rmM6Sqnbp10aI7fwmxNZBX2AD1lYrmkaAtBf8P8HAQ</p>
<p>Newtonsoft JSON Library</p>
<p>ADAL Library</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>This sample shows how to use the new Dynamics CRM Web API to build out a Xamarin app. &nbsp;This sample works in Android and Universal Windows app. &nbsp;The app will display a list of Tasks from Dynamics CRM and allow for the ability to create a new Task
 using a subject and description. &nbsp;It also uses the Xamarin Master Page which adds a navigation menu and new pages can easily be added to it to display more information from Dynamics CRM.</p>
<p>In order to authenticate to Dynamics CRM, you need to create an application in Azure Active Directory to get a client id. &nbsp;The client id can then be used for authentication.</p>
<p>&nbsp;</p>
<p>The following class is used for Universal Windows specific authentication to get an access token&nbsp;to be used with the Dynamics CRM Web Api.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">    public class Service : IService
    {
        public async Task&lt;AuthenticationResult&gt; Authenticate(string authority, string resource, string clientId, Uri returnUri)
        {
            var authContext = new AuthenticationContext(authority);
            var platformParams = new PlatformParameters(PromptBehavior.RefreshSession, false);
            var authResult = await authContext.AcquireTokenAsync(resource, clientId, returnUri, platformParams);

            return authResult;
        }
    }</pre>
<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Service&nbsp;:&nbsp;IService&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;async&nbsp;Task&lt;AuthenticationResult&gt;&nbsp;Authenticate(<span class="cs__keyword">string</span>&nbsp;authority,&nbsp;<span class="cs__keyword">string</span>&nbsp;resource,&nbsp;<span class="cs__keyword">string</span>&nbsp;clientId,&nbsp;Uri&nbsp;returnUri)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;authContext&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;AuthenticationContext(authority);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;platformParams&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PlatformParameters(PromptBehavior.RefreshSession,&nbsp;<span class="cs__keyword">false</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;authResult&nbsp;=&nbsp;await&nbsp;authContext.AcquireTokenAsync(resource,&nbsp;clientId,&nbsp;returnUri,&nbsp;platformParams);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;authResult;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;The following class is used for Android specific authentication to get an access token to be used with the Dynamics CRM Web Api.</div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">    public class Service : IService
    {
        public async Task&lt;AuthenticationResult&gt; Authenticate(string authority, string resource, string clientId, Uri returnUri)
        {
            var authContext = new AuthenticationContext(authority);
            var platformParams = new PlatformParameters((Activity)Forms.Context);
            var authResult = await authContext.AcquireTokenAsync(resource, clientId, returnUri, platformParams);
            return authResult;
        }
    }</pre>
<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Service&nbsp;:&nbsp;IService&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;async&nbsp;Task&lt;AuthenticationResult&gt;&nbsp;Authenticate(<span class="cs__keyword">string</span>&nbsp;authority,&nbsp;<span class="cs__keyword">string</span>&nbsp;resource,&nbsp;<span class="cs__keyword">string</span>&nbsp;clientId,&nbsp;Uri&nbsp;returnUri)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;authContext&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;AuthenticationContext(authority);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;platformParams&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PlatformParameters((Activity)Forms.Context);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;authResult&nbsp;=&nbsp;await&nbsp;authContext.AcquireTokenAsync(resource,&nbsp;clientId,&nbsp;returnUri,&nbsp;platformParams);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;authResult;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;The following needs to be replaced with your Dynamics CRM org and the client id of your Azure application. &nbsp;Also be sure that the RedirectUri used below is the same one that is registered within your Azure Active Directory
 application.</div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static class Constants
{
     public static string Authority = &quot;https://login.windows.net/common&quot;;
     public static Uri RedirectUri = new Uri(&quot;https://org.crm.dynamics.com&quot;);
     public static string Resource = &quot;https://org.crm.dynamics.com&quot;;
     public static string ClientId = &quot;client-id&quot;;
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Constants&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Authority&nbsp;=&nbsp;<span class="cs__string">&quot;https://login.windows.net/common&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;Uri&nbsp;RedirectUri&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Uri(<span class="cs__string">&quot;https://org.crm.dynamics.com&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Resource&nbsp;=&nbsp;<span class="cs__string">&quot;https://org.crm.dynamics.com&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;ClientId&nbsp;=&nbsp;<span class="cs__string">&quot;client-id&quot;</span>;&nbsp;
}</pre>
</div>
</div>
</div>
