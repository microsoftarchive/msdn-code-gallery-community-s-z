# Upload document to SharePoint Library with .NET CSOM
## Requires
- Visual Studio 2017
## License
- MIT
## Technologies
- Console Application
- Office 365
- Sharepoint Online
- SharePoint 2013
- CSOM
- SharePoint 2016
- SharePoint Add-ins
- SharePoint 2019
## Topics
- SharePoint client object model (CSOM)
## Updated
- 07/27/2018
## Description

<div class="post-title">
<h1>Upload document to SharePoint Library with .NET CSOM</h1>
</div>
<div>
<p><span style="font-size:small">Example project is a simple Console Application created in Visual Studio 2017. This application can be able to work with most of existing SharePoint versions:</span></p>
<ul>
<li><span style="font-size:small">SharePoint 2013</span> </li><li><span style="font-size:small">SharePoint 2016</span> </li><li><span style="font-size:small">SharePoint 2019</span> </li><li><span style="font-size:small">SharePoint Online</span> </li></ul>
<h1>Nuget Pacakges</h1>
<p><span style="font-size:small">This sample uses&nbsp;<a href="https://www.nuget.org/packages/Microsoft.SharePointOnline.CSOM" target="_blank">Microsoft.SharePointOnline.CSOM</a>&nbsp;nuget-package which contains SharePoint Client Side Object Model libraries.</span></p>
<p><span style="font-size:small">After downloading the sample run &quot;Restore NuGet Packages&quot; command:</span></p>
<p><span style="font-size:small"><img id="205637" src="205637-restore-packages.png" alt="" width="549" height="676"><br>
</span></p>
<h1>Credentials</h1>
<p><span style="font-size:small">Credentials used in the sample hard coded in the Program.cs file. Open the file and type in a relevant informatioin:</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">// SharePoint Site URL
var siteUrl = &quot;https://sharepointsiteurl&quot;;
// Login
var userLogin = &quot;userLogin@domain&quot;;
// Password
var userPassword = &quot;P@ssw0rd&quot;;
// Document Library Name
var docLib = &quot;Documents&quot;;</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;SharePoint&nbsp;Site&nbsp;URL</span>&nbsp;
var&nbsp;siteUrl&nbsp;=&nbsp;<span class="cs__string">&quot;https://sharepointsiteurl&quot;</span>;&nbsp;
<span class="cs__com">//&nbsp;Login</span>&nbsp;
var&nbsp;userLogin&nbsp;=&nbsp;<span class="cs__string">&quot;userLogin@domain&quot;</span>;&nbsp;
<span class="cs__com">//&nbsp;Password</span>&nbsp;
var&nbsp;userPassword&nbsp;=&nbsp;<span class="cs__string">&quot;P@ssw0rd&quot;</span>;&nbsp;
<span class="cs__com">//&nbsp;Document&nbsp;Library&nbsp;Name</span>&nbsp;
var&nbsp;docLib&nbsp;=&nbsp;<span class="cs__string">&quot;Documents&quot;</span>;</pre>
</div>
</div>
</div>
<h1 class="endscriptcode">Application</h1>
<div class="endscriptcode"><span style="font-size:small">The sample application contains three operations:</span></div>
<div class="endscriptcode">
<ol>
<li><span style="font-size:small">Uploading a document via sending&nbsp;FileCreationInformation object with content;</span>
</li><li><span style="font-size:small">Uploading a document via&nbsp;SaveBinaryDirect method of File class</span>
</li><li><span style="font-size:small">Uploading chunked document</span> </li></ol>
</div>
<p>&nbsp;</p>
<h2>The Document</h2>
<p><span style="font-size:small">The application does not use any existing file. It generates a text file which contains 100 lines of the same pangram:</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span style="font-size:small">C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">var fileBytes = new byte[] { };

using (var ms = new MemoryStream())
{
    using (TextWriter tw = new StreamWriter(ms, Encoding.UTF8))
    {
        for (var i = 0; i &lt; 100; i&#43;&#43;)
        {
            tw.WriteLine(@&quot;The quick brown fox jumps over the lazy dog&quot;);
        }
        fileBytes = ms.ToArray();
    }
}</pre>
<div class="preview">
<pre class="csharp">var&nbsp;fileBytes&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;{&nbsp;};&nbsp;
&nbsp;
<span class="cs__keyword">using</span>&nbsp;(var&nbsp;ms&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MemoryStream())&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(TextWriter&nbsp;tw&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StreamWriter(ms,&nbsp;Encoding.UTF8))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(var&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;<span class="cs__number">100</span>;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tw.WriteLine(@<span class="cs__string">&quot;The&nbsp;quick&nbsp;brown&nbsp;fox&nbsp;jumps&nbsp;over&nbsp;the&nbsp;lazy&nbsp;dog&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;fileBytes&nbsp;=&nbsp;ms.ToArray();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<p>&nbsp;</p>
<p>&nbsp;</p>
<h1>More information</h1>
<p><span style="font-size:small">More information about document uploading with SharePoint CSOM and does this sample work you can find in my blog:</span><br>
<span style="font-size:small"><a href="http://blog.vitalyzhukov.ru/en/csom-upload-document">http://blog.vitalyzhukov.ru/en/csom-upload-document</a></span></p>
<p>&nbsp;</p>
</div>
