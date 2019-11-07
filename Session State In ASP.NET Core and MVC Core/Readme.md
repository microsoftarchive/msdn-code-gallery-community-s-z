# Session State In ASP.NET Core and MVC Core
## Requires
- Visual Studio 2017
## License
- MIT
## Technologies
- C#
- ASP.NET Core
- ASP.NET Core MVC
- ASP.NET Core 1.1
- Visual Studio 2017
## Topics
- C#
- ASP.NET Core
- ASP.NET Core MVC
- ASP.NET Core 1.1
- Visual Studio 2017
## Updated
- 06/11/2017
## Description

<h1>Introduction</h1>
<p><em>In this article, we will explain how to create a <em>&quot;Session State in ASP.NET Core and MVC Core&quot;.</em></em></p>
<h1>Session State</h1>
<p><span>In Session State, we can use to save and store user data while the user browses your web app. We already know that in previous versions of ASP.NET, we could store session as key value pair like this&nbsp;</span><em>&quot;Session[&quot;Name&quot;] = &quot;Rajeesh Menoth&quot;&quot;</em><span>&nbsp;and
 implement it in an easy way. But in the latest version of ASP.NET or ASP.NET Core, we need to do a few configurations for accessing and enabling Session State in the application. The main purpose of session is maintaining user data in memory because of HTTP
 is a stateless protocol.</span></p>
<p><span>Before reading this article, you must read the articles given below for ASP.NET Core knowledge.</span></p>
<ul>
<li><a title="ASP.NET CORE 1.0: Getting Started" href="https://social.technet.microsoft.com/wiki/contents/articles/36451.asp-net-core-1-0-getting-started.aspx" target="_blank">ASP.NET CORE 1.0: Getting Started</a>
</li><li><a title="ASP.NET Core 1.0: Project Layout" href="https://social.technet.microsoft.com/wiki/contents/articles/36490.asp-net-core-1-0-project-layout.aspx" target="_blank">ASP.NET Core 1.0: Project Layout</a>
</li><li><a title="ASP.NET Core 1.0: Middleware And Static files (Part 1)" href="https://social.technet.microsoft.com/wiki/contents/articles/36629.asp-net-core-1-0-middleware-and-static-files-part-1.aspx" target="_blank">ASP.NET Core 1.0: Middleware And Static files
 (Part 1)</a> </li><li><a title="Middleware And Staticfiles In ASP.NET Core 1.0 - Part Two" href="https://social.technet.microsoft.com/wiki/contents/articles/36727.middleware-and-staticfiles-in-asp-net-core-1-0-part-two.aspx" target="_blank">Middleware And Staticfiles In ASP.NET
 Core 1.0 - Part Two</a> </li></ul>
<h1>Code</h1>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace SessionInCore.Controllers
{
    public class HomeController : Controller
    {
        const string SessionKeyName = &quot;_Name&quot;;
        const string SessionKeyAge = &quot;_Age&quot;;
        const string SessionKeyDate = &quot;_Date&quot;;

        public IActionResult Index()
        {
            HttpContext.Session.SetString(SessionKeyName, &quot;Rajeesh Menoth&quot;);
            HttpContext.Session.SetInt32(SessionKeyAge, 28);
            // Requires you add the Set extension method mentioned in the SessionExtensions static class.
            HttpContext.Session.Set&lt;DateTime&gt;(SessionKeyDate, DateTime.Now);

            return View();
        }

        public IActionResult About()
        {
            ViewBag.Name = HttpContext.Session.GetString(SessionKeyName);
            ViewBag.Age = HttpContext.Session.GetInt32(SessionKeyAge);
            ViewBag.Date = HttpContext.Session.Get&lt;DateTime&gt;(SessionKeyDate);

            ViewData[&quot;Message&quot;] = &quot;Session State In Asp.Net Core 1.1&quot;;

            return View();
        }

        public IActionResult Contact()
        {
            ViewData[&quot;Message&quot;] = &quot;My Contact Details&quot;;

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
        
    }

    public static class SessionExtensions
    {
        public static void Set&lt;T&gt;(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T Get&lt;T&gt;(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) :
                                  JsonConvert.DeserializeObject&lt;T&gt;(value);
        }
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Microsoft.AspNetCore.Mvc;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Microsoft.AspNetCore.Http;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Newtonsoft.Json;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;SessionInCore.Controllers&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;HomeController&nbsp;:&nbsp;Controller&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;SessionKeyName&nbsp;=&nbsp;<span class="cs__string">&quot;_Name&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;SessionKeyAge&nbsp;=&nbsp;<span class="cs__string">&quot;_Age&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;SessionKeyDate&nbsp;=&nbsp;<span class="cs__string">&quot;_Date&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;IActionResult&nbsp;Index()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpContext.Session.SetString(SessionKeyName,&nbsp;<span class="cs__string">&quot;Rajeesh&nbsp;Menoth&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpContext.Session.SetInt32(SessionKeyAge,&nbsp;<span class="cs__number">28</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Requires&nbsp;you&nbsp;add&nbsp;the&nbsp;Set&nbsp;extension&nbsp;method&nbsp;mentioned&nbsp;in&nbsp;the&nbsp;SessionExtensions&nbsp;static&nbsp;class.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpContext.Session.Set&lt;DateTime&gt;(SessionKeyDate,&nbsp;DateTime.Now);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;IActionResult&nbsp;About()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ViewBag.Name&nbsp;=&nbsp;HttpContext.Session.GetString(SessionKeyName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ViewBag.Age&nbsp;=&nbsp;HttpContext.Session.GetInt32(SessionKeyAge);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ViewBag.Date&nbsp;=&nbsp;HttpContext.Session.Get&lt;DateTime&gt;(SessionKeyDate);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ViewData[<span class="cs__string">&quot;Message&quot;</span>]&nbsp;=&nbsp;<span class="cs__string">&quot;Session&nbsp;State&nbsp;In&nbsp;Asp.Net&nbsp;Core&nbsp;1.1&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;IActionResult&nbsp;Contact()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ViewData[<span class="cs__string">&quot;Message&quot;</span>]&nbsp;=&nbsp;<span class="cs__string">&quot;My&nbsp;Contact&nbsp;Details&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;IActionResult&nbsp;Error()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;SessionExtensions&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Set&lt;T&gt;(<span class="cs__keyword">this</span>&nbsp;ISession&nbsp;session,&nbsp;<span class="cs__keyword">string</span>&nbsp;key,&nbsp;T&nbsp;<span class="cs__keyword">value</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;session.SetString(key,&nbsp;JsonConvert.SerializeObject(<span class="cs__keyword">value</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;T&nbsp;Get&lt;T&gt;(<span class="cs__keyword">this</span>&nbsp;ISession&nbsp;session,&nbsp;<span class="cs__keyword">string</span>&nbsp;key)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;<span class="cs__keyword">value</span>&nbsp;=&nbsp;session.GetString(key);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">value</span>&nbsp;==&nbsp;<span class="cs__keyword">null</span>&nbsp;?&nbsp;<span class="cs__keyword">default</span>(T)&nbsp;:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;JsonConvert.DeserializeObject&lt;T&gt;(<span class="cs__keyword">value</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<p><span>The following code contains the Key name as &quot;SessionKeyName&quot; &amp; Value name as &quot;Rajeesh Menoth&quot;. So we can set the Session String &quot;Key&quot; and &quot;Value&quot; in SetString(&quot;Key&quot;,&quot;Value&quot;).</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">const string SessionKeyName = &quot;_Name&quot;;
HttpContext.Session.SetString(SessionKeyName, &quot;Rajeesh Menoth&quot;);</pre>
<div class="preview">
<pre class="js"><span class="js__statement">const</span>&nbsp;string&nbsp;SessionKeyName&nbsp;=&nbsp;<span class="js__string">&quot;_Name&quot;</span>;&nbsp;
HttpContext.Session.SetString(SessionKeyName,&nbsp;<span class="js__string">&quot;Rajeesh&nbsp;Menoth&quot;</span>);</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span>The following code contains a similar Session code as an older version of ASP.NET.</span></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">Session[&quot;Name&quot;] = &quot;Rajeesh Menoth&quot;;</pre>
<div class="preview">
<pre class="js">Session[<span class="js__string">&quot;Name&quot;</span>]&nbsp;=&nbsp;<span class="js__string">&quot;Rajeesh&nbsp;Menoth&quot;</span>;</pre>
</div>
</div>
</div>
</div>
<p><span>We can Assign and Get the Session string value using &quot;GetString(Name)&quot; Method in a simple way.</span></p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">ViewBag.Name = HttpContext.Session.GetString(SessionKeyName);</pre>
<div class="preview">
<pre class="js">ViewBag.Name&nbsp;=&nbsp;HttpContext.Session.GetString(SessionKeyName);</pre>
</div>
</div>
</div>
<p></p>
<h1>Output</h1>
<p><img id="174277" src="174277-sessionstateexample.jpg" alt="" width="944" height="380"></p>
<h1>Conclusion</h1>
<p><span>We learned how to create Session State In ASP.NET Core and MVC Core. I hope you liked this article. Please share your valuable suggestions and feedback.</span></p>
