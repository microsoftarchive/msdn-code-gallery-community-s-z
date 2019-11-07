# Xamarin.Android: Download a file with DialogProgressBar
## Requires
- Visual Studio 2015
## License
- MS-LPL
## Technologies
- C#
- Silverlight
- ASP.NET
- Win32
- .NET
- Windows Forms
- WPF
- Microsoft Azure
- XAML
- Windows SDK
- .NET Framework
- .NET Framework 4.0
- Windows General
- Windows Phone
- C# Language
- Windows Runtime
- Visual C#
- Windows Phone 8
- Windows Store app
- Windows Phone 8.1
## Topics
- Controls
- Graphics
- C#
- Data Binding
- Security
- Azure
- User Interface
- Windows Forms
- WPF
- Microsoft Azure
- Data Access
- XAML
- Windows Phone
- How to
- Numerical Computing
- C# Language Features
- Windows web services
- Windows Store app
- data and storage
- universal app
## Updated
- 06/03/2016
## Description

<h1 class="title">WebClient Class</h1>
<div class="lw_vs">
<div id="curversion"></div>
</div>
<div id="mainSection">
<div id="mainBody">
<div>
<div class="summary">
<p>Provides common methods for sending data to and receiving data from a resource identified by a URI.</p>
</div>
</div>
<p>&nbsp;</p>
<div>
<h2 class="LW_CollapsibleArea_TitleDiv"><a class="LW_CollapsibleArea_TitleAhref"><span class="LW_CollapsibleArea_Title">Remarks</span></a>
<div class="LW_CollapsibleArea_Anchor_Div" id="Anchor_1"><a class="LW_CollapsibleArea_Anchor_Img" title="Right-click to copy and share the link for this section" href="https://msdn.microsoft.com/en-us/library/system.net.webclient(v=vs.90).aspx#Anchor_1"></a></div>
<div class="LW_CollapsibleArea_HrDiv"></div>
</h2>
<div class="sectionblock"><a id="remarksToggle"></a>
<p>The&nbsp;<span class="selflink">WebClient</span>&nbsp;class provides common methods for sending data to or receiving data from any local, intranet, or Internet resource identified by a URI.</p>
<p>The&nbsp;<span class="selflink">WebClient</span>&nbsp;class uses the&nbsp;<a href="https://msdn.microsoft.com/en-us/library/system.net.webrequest(v=vs.90).aspx">WebRequest</a>&nbsp;class to provide access to resources.&nbsp;<span class="selflink">WebClient</span>&nbsp;instances
 can access data with any&nbsp;<a href="https://msdn.microsoft.com/en-us/library/system.net.webrequest(v=vs.90).aspx">WebRequest</a>descendant registered with the&nbsp;<a href="https://msdn.microsoft.com/en-us/library/system.net.webrequest.registerprefix(v=vs.90).aspx">WebRequest<span>.</span>RegisterPrefix</a>&nbsp;method.</p>
<div class="alert">
<div class="contentTableWrapper"></div>
</div>
<div class="caption"></div>
<div class="tableSection">
<div class="contentTableWrapper">
<table>
<tbody>
<tr>
<th>
<p>Method</p>
</th>
<th>
<p>Description</p>
</th>
</tr>
<tr>
<td>
<p><a href="https://msdn.microsoft.com/en-us/library/system.net.webclient.openwrite(v=vs.90).aspx">OpenWrite</a></p>
</td>
<td>
<p>Retrieves a&nbsp;<a href="https://msdn.microsoft.com/en-us/library/system.io.stream(v=vs.90).aspx">Stream</a>&nbsp;used to send data to the resource.</p>
</td>
</tr>
<tr>
<td>
<p><a href="https://msdn.microsoft.com/en-us/library/system.net.webclient.openwriteasync(v=vs.90).aspx">OpenWriteAsync</a></p>
</td>
<td>
<p>Retrieves a&nbsp;<a href="https://msdn.microsoft.com/en-us/library/system.io.stream(v=vs.90).aspx">Stream</a>&nbsp;used to send data to the resource, without blocking the calling thread.</p>
</td>
</tr>
<tr>
<td>
<p><a href="https://msdn.microsoft.com/en-us/library/system.net.webclient.uploaddata(v=vs.90).aspx">UploadData</a></p>
</td>
<td>
<p>Sends a byte array to the resource and returns a&nbsp;<a href="https://msdn.microsoft.com/en-us/library/system.byte(v=vs.90).aspx">Byte</a>&nbsp;array containing any response.</p>
</td>
</tr>
<tr>
<td>
<p><a href="https://msdn.microsoft.com/en-us/library/system.net.webclient.uploaddataasync(v=vs.90).aspx">UploadDataAsync</a></p>
</td>
<td>
<p>Sends a&nbsp;<a href="https://msdn.microsoft.com/en-us/library/system.byte(v=vs.90).aspx">Byte</a>&nbsp;array to the resource, without blocking the calling thread.</p>
</td>
</tr>
<tr>
<td>
<p><a href="https://msdn.microsoft.com/en-us/library/system.net.webclient.uploadfile(v=vs.90).aspx">UploadFile</a></p>
</td>
<td>
<p>Sends a local file to the resource and returns a&nbsp;<a href="https://msdn.microsoft.com/en-us/library/system.byte(v=vs.90).aspx">Byte</a>&nbsp;array containing any response.</p>
</td>
</tr>
<tr>
<td>
<p><a href="https://msdn.microsoft.com/en-us/library/system.net.webclient.uploadfileasync(v=vs.90).aspx">UploadFileAsync</a></p>
</td>
<td>
<p>Sends a local file to the resource, without blocking the calling thread.</p>
</td>
</tr>
<tr>
<td>
<p><a href="https://msdn.microsoft.com/en-us/library/system.net.webclient.uploadvalues(v=vs.90).aspx">UploadValues</a></p>
</td>
<td>
<p>Sends a&nbsp;<a href="https://msdn.microsoft.com/en-us/library/system.collections.specialized.namevaluecollection(v=vs.90).aspx">NameValueCollection</a>&nbsp;to the resource and returns a&nbsp;<a href="https://msdn.microsoft.com/en-us/library/system.byte(v=vs.90).aspx">Byte</a>&nbsp;array
 containing any response.</p>
</td>
</tr>
<tr>
<td>
<p><a href="https://msdn.microsoft.com/en-us/library/system.net.webclient.uploadvaluesasync(v=vs.90).aspx">UploadValuesAsync</a></p>
</td>
<td>
<p>Sends a&nbsp;<a href="https://msdn.microsoft.com/en-us/library/system.collections.specialized.namevaluecollection(v=vs.90).aspx">NameValueCollection</a>&nbsp;to the resource and returns a&nbsp;<a href="https://msdn.microsoft.com/en-us/library/system.byte(v=vs.90).aspx">Byte</a>&nbsp;array
 containing any response, without blocking the calling thread.</p>
</td>
</tr>
<tr>
<td>
<p><a href="https://msdn.microsoft.com/en-us/library/system.net.webclient.uploadstring(v=vs.90).aspx">UploadString</a></p>
</td>
<td>
<p>Sends a&nbsp;<a href="https://msdn.microsoft.com/en-us/library/system.string(v=vs.90).aspx">String</a>&nbsp;to the resource, without blocking the calling thread.</p>
</td>
</tr>
<tr>
<td>
<p><a href="https://msdn.microsoft.com/en-us/library/system.net.webclient.uploadstringasync(v=vs.90).aspx">UploadStringAsync</a></p>
</td>
<td>
<p>Sends a&nbsp;<a href="https://msdn.microsoft.com/en-us/library/system.string(v=vs.90).aspx">String</a>&nbsp;to the resource, without blocking the calling thread.</p>
</td>
</tr>
</tbody>
</table>
</div>
</div>
<p>The following table describes&nbsp;<span class="selflink">WebClient</span>&nbsp;methods for downloading data from a resource.</p>
<div class="caption"></div>
<div class="tableSection">
<div class="contentTableWrapper">
<table>
<tbody>
<tr>
<th>
<p>Method</p>
</th>
<th>
<p>Description</p>
</th>
</tr>
<tr>
<td>
<p><a href="https://msdn.microsoft.com/en-us/library/system.net.webclient.openread(v=vs.90).aspx">OpenRead</a></p>
</td>
<td>
<p>Returns the data from a resource as a&nbsp;<a href="https://msdn.microsoft.com/en-us/library/system.io.stream(v=vs.90).aspx">Stream</a>.</p>
</td>
</tr>
<tr>
<td>
<p><a href="https://msdn.microsoft.com/en-us/library/system.net.webclient.openreadasync(v=vs.90).aspx">OpenReadAsync</a></p>
</td>
<td>
<p>Returns the data from a resource, without blocking the calling thread.</p>
</td>
</tr>
<tr>
<td>
<p><a href="https://msdn.microsoft.com/en-us/library/system.net.webclient.downloaddata(v=vs.90).aspx">DownloadData</a></p>
</td>
<td>
<p>Downloads data from a resource and returns a&nbsp;<a href="https://msdn.microsoft.com/en-us/library/system.byte(v=vs.90).aspx">Byte</a>&nbsp;array.</p>
</td>
</tr>
<tr>
<td>
<p><a href="https://msdn.microsoft.com/en-us/library/system.net.webclient.downloaddataasync(v=vs.90).aspx">DownloadDataAsync</a></p>
</td>
<td>
<p>Downloads data from a resource and returns a&nbsp;<a href="https://msdn.microsoft.com/en-us/library/system.byte(v=vs.90).aspx">Byte</a>&nbsp;array, without blocking the calling thread.</p>
</td>
</tr>
<tr>
<td>
<p><a href="https://msdn.microsoft.com/en-us/library/system.net.webclient.downloadfile(v=vs.90).aspx">DownloadFile</a></p>
</td>
<td>
<p>Downloads data from a resource to a local file.</p>
</td>
</tr>
<tr>
<td>
<p><a href="https://msdn.microsoft.com/en-us/library/system.net.webclient.downloadfileasync(v=vs.90).aspx">DownloadFileAsync</a></p>
</td>
<td>
<p>Downloads data from a resource to a local file, without blocking the calling thread.</p>
</td>
</tr>
<tr>
<td>
<p><a href="https://msdn.microsoft.com/en-us/library/system.net.webclient.downloadstring(v=vs.90).aspx">DownloadString</a></p>
</td>
<td>
<p>Downloads a&nbsp;<a href="https://msdn.microsoft.com/en-us/library/system.string(v=vs.90).aspx">String</a>&nbsp;from a resource and returns a&nbsp;<a href="https://msdn.microsoft.com/en-us/library/system.string(v=vs.90).aspx">String</a>.</p>
</td>
</tr>
<tr>
<td>
<p><a href="https://msdn.microsoft.com/en-us/library/system.net.webclient.downloadstringasync(v=vs.90).aspx">DownloadStringAsync</a></p>
</td>
<td>
<p>Downloads a&nbsp;<a href="https://msdn.microsoft.com/en-us/library/system.string(v=vs.90).aspx">String</a>&nbsp;from a resource, without blocking the calling thread.</p>
</td>
</tr>
</tbody>
</table>
</div>
</div>
<p>You can use the&nbsp;<a href="https://msdn.microsoft.com/en-us/library/system.net.webclient.cancelasync(v=vs.90).aspx">CancelAsync</a>&nbsp;method to cancel asynchronous operations that have not completed.</p>
<p>A&nbsp;<span class="selflink">WebClient</span>&nbsp;instance does not send optional HTTP headers by default. If your request requires an optional header, you must add the header to the<a href="https://msdn.microsoft.com/en-us/library/system.net.webclient.headers(v=vs.90).aspx">Headers</a>&nbsp;collection.
 For example, to retain queries in the response, you must add a user-agent header. Also, servers may return 500 (Internal Server Error) if the user agent header is missing.</p>
</div>
</div>
</div>
</div>
<ul>
<li></li></ul>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">Add a new using statemnets to your code:
using Java.IO;
using System.IO;
using System.Net;
Create a WebClient object:

var webClient=new WebClient();
Create the Url for the files to download:

var url=new Uri(&quot;http://8morning.com/demo/wp-content/uploads/2016/04/hoc-photoshop.jpg This link is external to TechNet Wiki. It will open in a new window. &quot;);
Create the array for contains length of a file.
byte[] bytes=null;
</pre>
<div class="preview">
<pre class="csharp">Add&nbsp;a&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">using</span>&nbsp;statemnets&nbsp;to&nbsp;your&nbsp;code:&nbsp;
<span class="cs__keyword">using</span>&nbsp;Java.IO;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.IO;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Net;&nbsp;
Create&nbsp;a&nbsp;WebClient&nbsp;<span class="cs__keyword">object</span>:&nbsp;
&nbsp;
var&nbsp;webClient=<span class="cs__keyword">new</span>&nbsp;WebClient();&nbsp;
Create&nbsp;the&nbsp;Url&nbsp;<span class="cs__keyword">for</span>&nbsp;the&nbsp;files&nbsp;to&nbsp;download:&nbsp;
&nbsp;
var&nbsp;url=<span class="cs__keyword">new</span>&nbsp;Uri(<span class="cs__string">&quot;http://8morning.com/demo/wp-content/uploads/2016/04/hoc-photoshop.jpg&nbsp;This&nbsp;link&nbsp;is&nbsp;external&nbsp;to&nbsp;TechNet&nbsp;Wiki.&nbsp;It&nbsp;will&nbsp;open&nbsp;in&nbsp;a&nbsp;new&nbsp;window.&nbsp;&quot;</span>);&nbsp;
Create&nbsp;the&nbsp;array&nbsp;<span class="cs__keyword">for</span>&nbsp;contains&nbsp;length&nbsp;of&nbsp;a&nbsp;file.&nbsp;
<span class="cs__keyword">byte</span>[]&nbsp;bytes=<span class="cs__keyword">null</span>;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
