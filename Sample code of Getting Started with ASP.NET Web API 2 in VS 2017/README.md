# Sample code of Getting Started with ASP.NET Web API 2 in VS 2017
## Requires
- Visual Studio 2017
## License
- MIT
## Technologies
- ASP.NET
- ASP.NET Web API
## Topics
- ASP.NET
## Updated
- 07/24/2017
## Description

<h1>Sample code of Getting Started with ASP.NET Web API 2</h1>
<p><span style="font-size:small">Excerpt from the tutorial:&nbsp;HTTP is not just for serving up web pages. It is also a powerful platform for building APIs that expose services and data. HTTP is simple, flexible, and ubiquitous. Almost any platform that you
 can think of has an HTTP library, so HTTP services can reach a broad range of clients, including browsers, mobile devices, and traditional desktop applications.</span></p>
<p><span style="font-size:small">&nbsp;</span><span style="font-size:small">ASP.NET Web API is a framework for building web APIs on top of the .NET Framework. In this tutorial, you will use ASP.NET Web API to create a web API that returns a list of products.
 The front-end web page uses jQuery to display the results.</span></p>
<h2><span style="font-size:small">&nbsp;</span><br>
<span style="font-size:small">Requirements</span></h2>
<p><span style="font-size:small">This tutorial uses Visual Studio 2017 update 2 (or it is also called 2017.2 release).
</span></p>
<p><span style="font-size:small">Previous version of this tutorial uses Visual Studio 2013, and it is available in this link:&nbsp;https://code.msdn.microsoft.com/ASP-NET-Web-API-Tutorial-8d2588b1</span></p>
<h2><span style="font-size:small">Create a Web API Project</span></h2>
<p><span style="font-size:small">Start Visual Studio and select New Project from the strong&gt;Start page. Or, from the File menu, select strong&gt;New and then Project.</span><br>
<span style="font-size:small">In the Templates pane, select Installed Templates and expand the Visual C# node. Under Visual C#, select Web. In the list of project templates, select ASP.NET Web Application. Name the project &quot;ProductsApp&quot; and click OK.</span><br>
<span style="font-size:small">In the New ASP.NET Project dialog, select the Empty template. Under &quot;Add folders and core references for&quot;, check Web API. Click OK.</span></p>
<h2><span style="font-size:small">Adding a Model</span></h2>
<p><span style="font-size:small">A model is an object that represents the data in your application ASP.NET Web API can automatically serialize your model to JSON, XML, or some other format, and then write the serialized data into the body of the HTTP response
 message. As long as a client can read the serialization format, it can deserialize the object. Most clients can parse either XML or JSON. Moreover, the client can indicate which format it wants by setting the Accept header in the HTTP request message.</span></p>
<p><span style="font-size:small">Let's start by creating a simple model that represents a product.</span><br>
<span style="font-size:small">If Solution Explorer is not already visible, click the View menu and select Solution Explorer. In Solution Explorer, right-click the Models folder. From the context menu, select AddClass.</span></p>
<p><span style="font-size:small"></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Product&nbsp;
&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;Id&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Name&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Category&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">decimal</span>&nbsp;Price&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
</span>
<p></p>
