# Startup Page In ASP.NET Core
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- HTML
- Visual Studio 2015
- ASP.NET Core
## Topics
- C#
- HTML
- Visual Studio 2015
- ASP.NET Core
## Updated
- 08/16/2017
## Description

<h2><a name="Introduction"></a>Introduction</h2>
<p><br>
We all are familiar with the configuration of the default startup page in the previous versions of AP.NET but it's slightly different in ASP.NET Core Applications. In this blog, we explain how to configure the default startup page in ASP.NET Core 1.0.
<br>
<br>
</p>
<h2><a name="Default_Startup_Page_Configuration"></a>Default Startup Page Configuration</h2>
<p><br>
In this way, we can implement the default startup page In ASP.NET Core 1.0.</p>
<ul>
<li>Default Configuration </li><li>Customized Configuration </li></ul>
<h3><a name="Default_Configuration"></a>Default Configuration</h3>
<p><br>
We can use UseDefaultFiles() extension method in ASP.NET Core 1.0. UseDefaultFiles() will only search for the files given in &quot;wwwroot&quot;. If any of the files are detected first in &quot;wwwroot&quot; the files are run as default in the client browser.</p>
<ul>
<li>default.html </li><li>default.htm </li><li>index.html </li><li>index.htm </li></ul>
<p>UseDefaultFiles must be called before UseStaticFiles or any other method (app.Run, app.Use) to serve the default file in the client-side browser. As you state UseStaticFiles() method after UseDefaultFiles(), it will run UseStaticFiles() method as a default
 and automatically terminates the other files which come after UseStaticFiles() method.
<br>
<br>
</p>
<h3><a name="Customized_Configuration"></a>Customized Configuration</h3>
<p><br>
In this case, we are calling other customized pages as default startup pages in ASP.NET Core 1.0. Thus, we can use DefaultFilesOptions in ASP.NET Core 1.0. If you want to run other files as default, check the code given below in Startup.cs.<br>
<br>
</p>
<h4><a name="Code"></a>Code</h4>
<p>&nbsp;</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">DefaultFilesOptions DefaultFile =
</code><code style="color:#006699; font-weight:bold">new</code> <code style="color:#000000">
DefaultFilesOptions();</code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">DefaultFile.DefaultFileNames.Clear();</code></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">DefaultFile.DefaultFileNames.Add(</code><code style="color:blue">&quot;Welcome.html&quot;</code><code style="color:#000000">);</code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">app.UseDefaultFiles(DefaultFile);</code></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">app.UseStaticFiles();</code></span></div>
</div>
<p>&nbsp;</p>
<h2><a name="Reference"></a>Reference</h2>
<ul>
<li><a rel="noopener" href="https://social.technet.microsoft.com/wiki/contents/articles/36490.asp-net-core-1-0-project-layout.aspx">Asp.Net Core Article
</a></li><li><a rel="noopener" href="https://docs.microsoft.com/en-us/aspnet/core/">Microsoft Docs</a>
</li></ul>
<h2><a name="Summary"></a>Summary</h2>
<p><br>
We learned how to configure the default startup page In ASP.NET Core 1.0. Hope, this article is useful for all ASP.NET Core 1.0 beginners.</p>
