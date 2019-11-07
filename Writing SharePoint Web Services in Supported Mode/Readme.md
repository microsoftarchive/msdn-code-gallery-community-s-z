# Writing SharePoint Web Services in Supported Mode
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- SharePoint
- SharePoint 2010
## Topics
- SharePoint
- Web Services
## Updated
- 09/28/2013
## Description

<h1>Introduction</h1>
<p>There are so many examples of building custom web service for SharePoint. Unfortunatelly, the step includes modification of SharePoint built-in file (ISAPI\spdisco.aspx). This kind of modification is dangerous - especially when there is patch release by
 Microsoft; it will be overriden. Moreover, modifying SharePoint's&nbsp;built-in file leaving SharePoint farm in un-supported state.</p>
<h1><span>Building the Sample</span></h1>
<ol>
<li>Extract the package DemoCustomWS.zip </li><li>Double-click on the DemoCustomWS.sln </li><li>Build and deploy the package. </li></ol>
<p>This project requires Visual Studio 2010 and SharePoint 2010.</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>This solution offers different approach that basically avoid modifying spdisco.aspx. In order to do that there are couple things that we do:</p>
<ol>
<li>Create DemoWS.spdisco.aspx .<br>
Instead of registering our web service information in spdisco.aspx, we will list it in DemoWS.spdisco.aspx.
</li><li>Create&nbsp;custom HttpHandler to&nbsp;intercept request to _vti_bin/spdisco.aspx<br>
This HttpHandler will listen to _vti_bin/spdisco.aspx , process original spdisco.aspx and combine it with any *.spdisco.aspx. So in this case, it will return combination of spdisco.aspx and DemoWS.spdisco.aspx
</li><li>Create copy&nbsp;of spdisco.aspx into spdisco.disco.aspx<br>
This copy is important to avoid infinite-loop inside our HttpHandler. </li><li>Modify web.config to register HttpHandler<br>
To modify web.config, we will&nbsp;create webconfig.DemoWS.xml and&nbsp;install it in CONFIG folder&nbsp;of SharePoint hive.&nbsp;Then, we can&nbsp;run
<em>stsadm -o copyappbincontent </em>do merge it with&nbsp;web.config in any web application.&nbsp;
</li></ol>
<p>Following diagram shows how the solution works:</p>
<p>&nbsp;</p>
<p><img src="41840-blog%20sharepoint%20ws.png" alt="" width="688" height="233"></p>
<p><em>&nbsp;</em></p>
<p>The key of this solution is HttpHandler process which will intercepts all request to _vti_bin/spdisco.aspx and replacing with the new process. In the new process, the HttpHandler will combine spdisco.aspx and any other *.spdisco.aspx in the ISAPI folder.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public void ProcessRequest(HttpContext context)
        {
            StringWriter sw1 = new StringWriter();
            // Original - cop spdisco.aspx
            context.Server.Execute(&quot;spdisco.disco.aspx&quot;, sw1);
            XmlDocument spdiscoXml = new XmlDocument();
            spdiscoXml.LoadXml(sw1.ToString());

            var files = Directory.GetFiles(context.Server.MapPath(&quot;&quot;), &quot;*.spdisco.aspx&quot;);
            foreach (var file in files)
            {
                StringWriter sw2 = new StringWriter();
                context.Server.Execute(System.IO.Path.GetFileName(file), sw2);

                XmlDocument otherSPDiscoXml = new XmlDocument();
                otherSPDiscoXml.LoadXml(sw2.ToString());
                foreach (XmlNode importedNode in otherSPDiscoXml.DocumentElement.ChildNodes)
                {
                    spdiscoXml.DocumentElement.AppendChild(spdiscoXml.ImportNode(importedNode, true));
                }
            }

            context.Response.Write(String.Format(&quot;&lt;?xml version='1.0' encoding='utf-8' ?&gt; {0}&quot;, spdiscoXml.InnerXml));
        }</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ProcessRequest(HttpContext&nbsp;context)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StringWriter&nbsp;sw1&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StringWriter();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Original&nbsp;-&nbsp;cop&nbsp;spdisco.aspx</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;context.Server.Execute(<span class="cs__string">&quot;spdisco.disco.aspx&quot;</span>,&nbsp;sw1);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;XmlDocument&nbsp;spdiscoXml&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;XmlDocument();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;spdiscoXml.LoadXml(sw1.ToString());&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;files&nbsp;=&nbsp;Directory.GetFiles(context.Server.MapPath(<span class="cs__string">&quot;&quot;</span>),&nbsp;<span class="cs__string">&quot;*.spdisco.aspx&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(var&nbsp;file&nbsp;<span class="cs__keyword">in</span>&nbsp;files)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StringWriter&nbsp;sw2&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StringWriter();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;context.Server.Execute(System.IO.Path.GetFileName(file),&nbsp;sw2);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;XmlDocument&nbsp;otherSPDiscoXml&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;XmlDocument();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;otherSPDiscoXml.LoadXml(sw2.ToString());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(XmlNode&nbsp;importedNode&nbsp;<span class="cs__keyword">in</span>&nbsp;otherSPDiscoXml.DocumentElement.ChildNodes)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;spdiscoXml.DocumentElement.AppendChild(spdiscoXml.ImportNode(importedNode,&nbsp;<span class="cs__keyword">true</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;context.Response.Write(String.Format(<span class="cs__string">&quot;&lt;?xml&nbsp;version='1.0'&nbsp;encoding='utf-8'&nbsp;?&gt;&nbsp;{0}&quot;</span>,&nbsp;spdiscoXml.InnerXml));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<p>Next important things is to register HttpHandler to the web.config.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot; ?&gt; 
&lt;actions&gt; 
  &lt;add path=&quot;configuration&quot; id=&quot;{24E2107B-6288-4C54-912D-3D5CE7BEEDE0}&quot;&gt; 
    &lt;location path=&quot;_vti_bin/spdisco.aspx&quot;&gt; 
      &lt;system.webServer&gt; 
        &lt;handlers&gt; 
          &lt;add name=&quot;DemoWSHandler&quot; verb=&quot;*&quot; path=&quot;*_vti_bin/spdisco.aspx&quot; type=&quot;DemoWS.HttpHandler, DemoWS , Version=1.0.0.0, Culture=neutral, PublicKeyToken=293c0f6de57e7690&quot; /&gt; 
        &lt;/handlers&gt; 
      &lt;/system.webServer&gt; 
    &lt;/location&gt; 
  &lt;/add&gt; 
&lt;/actions&gt;</pre>
<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;?xml</span>&nbsp;<span class="xml__attr_name">version</span>=<span class="xml__attr_value">&quot;1.0&quot;</span>&nbsp;<span class="xml__attr_name">encoding</span>=<span class="xml__attr_value">&quot;utf-8&quot;</span>&nbsp;<span class="xml__tag_start">?&gt;</span>&nbsp;&nbsp;
<span class="xml__tag_start">&lt;actions</span><span class="xml__tag_start">&gt;&nbsp;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_start">&lt;add</span>&nbsp;<span class="xml__attr_name">path</span>=<span class="xml__attr_value">&quot;configuration&quot;</span>&nbsp;<span class="xml__attr_name">id</span>=<span class="xml__attr_value">&quot;{24E2107B-6288-4C54-912D-3D5CE7BEEDE0}&quot;</span><span class="xml__tag_start">&gt;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;location</span>&nbsp;<span class="xml__attr_name">path</span>=<span class="xml__attr_value">&quot;_vti_bin/spdisco.aspx&quot;</span><span class="xml__tag_start">&gt;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;system</span>.webServer<span class="xml__tag_start">&gt;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;handlers</span><span class="xml__tag_start">&gt;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;add</span>&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;DemoWSHandler&quot;</span>&nbsp;<span class="xml__attr_name">verb</span>=<span class="xml__attr_value">&quot;*&quot;</span>&nbsp;<span class="xml__attr_name">path</span>=<span class="xml__attr_value">&quot;*_vti_bin/spdisco.aspx&quot;</span>&nbsp;<span class="xml__attr_name">type</span>=<span class="xml__attr_value">&quot;DemoWS.HttpHandler,&nbsp;DemoWS&nbsp;,&nbsp;Version=1.0.0.0,&nbsp;Culture=neutral,&nbsp;PublicKeyToken=293c0f6de57e7690&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/handlers&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/system.webServer&gt;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/location&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;<span class="xml__tag_end">&lt;/add&gt;</span>&nbsp;&nbsp;
<span class="xml__tag_end">&lt;/actions&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;The config will be distributed to CONFIG folder in SharePoint hive and merged into web.config using
<em><strong>stsadm -o copyappbincontent </strong></em>command.</div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<h1>More Information</h1>
<p>1. Writing Custom Web Services for SharePoint Products and Technology (<a title="http://msdn.microsoft.com/en-us/library/dd583131(v=office.11).aspx" href="http://msdn.microsoft.com/en-us/library/dd583131(v=office.11).aspx">http://msdn.microsoft.com/en-us/library/dd583131(v=office.11).aspx</a>)<br>
2. SharePoint Architecture (<a title="http://msdn.microsoft.com/en-us/library/bb892189(v=office.12).aspx" href="http://msdn.microsoft.com/en-us/library/bb892189(v=office.12).aspx">http://msdn.microsoft.com/en-us/library/bb892189(v=office.12).aspx</a> )<br>
3. Architectural Overview of Windows SharePoint Services (<a title="http://msdn.microsoft.com/en-us/library/dd583133(v=office.11).aspx" href="http://msdn.microsoft.com/en-us/library/dd583133(v=office.11).aspx">http://msdn.microsoft.com/en-us/library/dd583133(v=office.11).aspx</a>)<br>
4. Modifying Built-In SharePoint Files (<a title="http://msdn.microsoft.com/en-us/library/bb803457(v=office.12).aspx" href="http://msdn.microsoft.com/en-us/library/bb803457(v=office.12).aspx">http://msdn.microsoft.com/en-us/library/bb803457(v=office.12).aspx</a>)<br>
5. My blog - Ideas for Free (<a href="http://blog.libinuko.com">http://blog.libinuko.com</a>)</p>
