# Uploading large files using ASP.NET Web API and Azure Blob Storage
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET
- Windows Azure Storage
- ASP.NET Web API
## Topics
- Azure Blob Storage
- ASP.NET Web API
## Updated
- 05/19/2013
## Description

<p>When you create a Web API service that needs to store large amount of unstructured data (pictures, videos, documents, etc.), one of the options you can consider is to use Windows Azure Blob Storage. It provides a fairly straightforward way of storing unstructured
 data in the cloud. This sample illustrates how to create a simple file service using ASP.NET Web API backed by Azure Blob Storage. See this
<a href="http://blogs.msdn.com/b/yaohuang1/archive/2012/07/02/asp-net-web-api-and-azure-blob-storage.aspx">
blog</a> for more&nbsp;information about the sample.</p>
<h1>Setup</h1>
<p>1. Download and install <a href="http://www.asp.net/web-api">ASP.NET Web API</a>.</p>
<p>2. Download and install <a href="https://www.windowsazure.com/en-us/develop/net/">
Azure SDK for .NET</a>.</p>
<p><strong>Update 05/19/13: The sample was built using Azure SDK that was released in June 2012, If you're installing a newer version, simply remove and re-add the following assemblies&nbsp;in the AzureBlobsFileUploadSample.csproj:</strong></p>
<ul>
<li><strong>Microsoft.WindowsAzure.Configuration</strong> </li><li><strong>Microsoft.WindowsAzure.StorageClient</strong> </li></ul>
<p>3. Enable NuGet Package Restore. (Inside VS, go to Tools -&gt; Options... -&gt; Package Manager -&gt; check &quot;Allow NuGet to download missing packages during build&quot; option)</p>
<h1>Running the sample</h1>
<p>First you need to start the Azure Storage Emulator. You can do it by going to the &ldquo;Server Explorer&rdquo;. Under the &ldquo;Windows Azure Storage&rdquo;, just right click and Refresh the &ldquo;(Development)&rdquo; node. It will start the Azure Storage
 Emulator.</p>
<p><a href="http://blogs.msdn.com/cfs-file.ashx/__key/communityserver-blogs-components-weblogfiles/00-00-01-52-84-metablogapi/0121.image_5F00_00FEF111.png"><img title="image" src="-5315.image_5f00_thumb_5f00_0ed1370c.png" border="0" alt="image" width="244" height="181" style="display:inline"></a></p>
<p>Once the <strong>Azure</strong> <strong>storage</strong> <strong>emulator</strong> and the
<strong>Web API service</strong> are up and running, you can start uploading files. Here I used
<a href="http://www.fiddler2.com/fiddler2/">fiddler</a> to do that.</p>
<p><a href="http://blogs.msdn.com/cfs-file.ashx/__key/communityserver-blogs-components-weblogfiles/00-00-01-52-84-metablogapi/6076.image_5F00_07B1FA94.png"><img title="image" src="-2275.image_5f00_thumb_5f00_6796edd6.png" border="0" alt="image" width="391" height="300" style="display:inline"></a></p>
<p>After the upload is complete, we can issue a GET request to the FilesController to get a list of files that have been uploaded. From the result below we can see there&rsquo;s one file uploaded so far. And the file can be downloaded at Location:
<a href="http://127.0.0.1:10000/devstoreaccount1/webapicontainer/samplePresentation.pptx">
http://127.0.0.1:10000/devstoreaccount1/webapicontainer/samplePresentation.pptx</a>.</p>
<p><a href="http://blogs.msdn.com/cfs-file.ashx/__key/communityserver-blogs-components-weblogfiles/00-00-01-52-84-metablogapi/1780.image_5F00_328A5EA6.png"><img title="image" src="-1602.image_5f00_thumb_5f00_405ca4a1.png" border="0" alt="image" width="391" height="98" style="display:inline"></a></p>
<p>Alternatively we can look through the Server Explorer to see that the file has in fact been upload to the blob storage.</p>
<p><a href="http://blogs.msdn.com/cfs-file.ashx/__key/communityserver-blogs-components-weblogfiles/00-00-01-52-84-metablogapi/1373.image_5F00_4E2EEA9C.png"><img title="image" src="-2843.image_5f00_thumb_5f00_19225b6c.png" border="0" alt="image" width="309" height="160" style="display:inline"></a></p>
<h1>Switching to a real Azure Blob Storage</h1>
<p>When everything is ready to be deployed, you can simply update the connection string in Web.config to use the real Azure Storage account. Here is an example of what the connection string would look like:</p>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;appSettings&gt;
    &lt;add key=&quot;CloudStorageConnectionString&quot; value=&quot;DefaultEndpointsProtocol=http;AccountName=[your account name];AccountKey=[your account key]&quot;/&gt;
&lt;/appSettings&gt;</pre>
<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;appSettings</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;add</span>&nbsp;<span class="xml__attr_name">key</span>=<span class="xml__attr_value">&quot;CloudStorageConnectionString&quot;</span>&nbsp;<span class="xml__attr_name">value</span>=<span class="xml__attr_value">&quot;DefaultEndpointsProtocol=http;AccountName=[your&nbsp;account&nbsp;name];AccountKey=[your&nbsp;account&nbsp;key]&quot;</span><span class="xml__tag_start">/&gt;</span>&nbsp;
<span class="xml__tag_end">&lt;/appSettings&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">The DefaultEndpointsProtocol=http will tell the CloudBlobClient to use the default http endpoint which is:
<a href="http://[AccountName].blob.core.windows.net/">http://[AccountName].blob.core.windows.net/</a> for the blobs.</div>
</div>
<p>The AccountName is simply the name of the storage account.</p>
<p>The AccountKey can be obtained from the Azure portal &ndash; just browse to the Storage section and click on &ldquo;MANAGE KEYS&rdquo;.</p>
<h1>Increasing the maxRequestLength and maxAllowedContentLength</h1>
<p>If you&rsquo;re uploading large files, you'll need to increasing the maxRequestLength setting in ASP.NET which is kept at 4MB by default. The following setting in Web.config should do the trick to increase it to 2GB.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;system.web&gt;
    &lt;httpRuntime maxRequestLength=&quot;2097152&quot;/&gt;
&lt;/system.web&gt;</pre>
<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;system</span>.web<span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;httpRuntime</span>&nbsp;<span class="xml__attr_name">maxRequestLength</span>=<span class="xml__attr_value">&quot;2097152&quot;</span><span class="xml__tag_start">/&gt;</span>&nbsp;
&lt;/system.web&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;If you&rsquo;re on IIS, you'll also need to increase the maxAllowedContentLength.&nbsp;Note that maxAllowedContentLength is in bytes whereas maxRequestLength is in kilobytes.</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;system.webServer&gt;
      &lt;security&gt;
          &lt;requestFiltering&gt;
             &lt;requestLimits maxAllowedContentLength=&quot;2147483648&quot; /&gt;
          &lt;/requestFiltering&gt;
      &lt;/security&gt;
&lt;/system.webServer&gt;</pre>
<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;system</span>.webServer<span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;security</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;requestFiltering</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;requestLimits</span>&nbsp;<span class="xml__attr_name">maxAllowedContentLength</span>=<span class="xml__attr_value">&quot;2147483648&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/requestFiltering&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/security&gt;</span>&nbsp;
&lt;/system.webServer&gt;</pre>
</div>
</div>
</div>
