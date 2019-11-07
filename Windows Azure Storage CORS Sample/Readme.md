# Windows Azure Storage CORS Sample
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- AJAX
- JSON
- Windows Azure Storage
- Jquery Ajax
- CORS
## Topics
- JSON
- Windows Azure Storage
- CORS for Windows Azure Storage
## Updated
- 01/31/2014
## Description

<h1>Introduction</h1>
<p>This is sample code demonstrates CORS usage for Windows Azure Storage. Please refer to the
<a title="Windows Azure Storage: Introducing CORS" href="http://blogs.msdn.com/b/windowsazurestorage/archive/2014/02/01/windows-azure-storage-introducing-cors.aspx" target="_blank">
following blog post</a> for more details.</p>
<p>&nbsp;</p>
<h1>Building the Sample</h1>
<p>Ensure that you have the latest version of <a href="http://docs.nuget.org/docs/start-here/installing-nuget" target="_blank">
NuGet Package Manager</a> installed in order to get access to the referenced libraries.</p>
<p>The sample by default is configured to use Windows Azure Storage Emulator which can be downloaded from
<a href="http://blogs.msdn.com/b/windowsazurestorage/archive/2014/01/27/windows-azure-storage-emulator-2-2-1-preview-release-with-support-for-2013-08-15-version.aspx">
here</a>. You can use your Windows Azure Storage account by configuring AzureCommon.StorageAccount as part of the AzureCommon.cs file.</p>
<p>&nbsp;</p>
<h1>Description</h1>
<p>We recently released CORS(Cross Origin Resource Sharing) for Windows Azure Storage. CORS is supported for Blob, Table and Queue services and can be enabled for each service through the Windows Azure Storage Client Library 3.0. The sample codes demoes this
 fucntionality. For more information please refer to the <a title="Windows Azure Storage: Introducing CORS" href="http://blogs.msdn.com/b/windowsazurestorage/archive/2014/02/01/windows-azure-storage-introducing-cors.aspx">
Windows Azure Storage blog post</a>.</p>
<p>&nbsp;</p>
<h1>Sample JavasScript Code for uploading a Blob to Windows Azure Storage</h1>
<p>This below sample is a code snippet that would allow you to upload a file directly from the Web Browser into Windows Azure Storage using JavaScript. The code below is a snippet from the UploadImage.cshtml file.</p>
<h1>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">        // Method uploads a blob to Azure Storage by using a Blob SAS URL.
        // The Web Browser will add the necessary CORS headers and issue a preflight request if needed.
        // blobSasUrl: Blob SAS URL already obtained through an Ajax call to own service
        // fileDataAsArrayBuffer: an ArrayBuffer (Byte Array) containing the raw data of the file to be uploaded
        function uploadImage(blobSasUrl, fileDataAsArrayBuffer) {
            var ajaxRequest = new XMLHttpRequest();
            // Once the image is successfully upload, we will call render Image that would show the uploaded image
            ajaxRequest.onreadystatechange = function() {return renderImage(ajaxRequest, blobSasUrl)};

            try {
                // Performing a PutBlob (BlockBlob) against storage
                ajaxRequest.open('PUT', blobSasUrl, true);
                ajaxRequest.setRequestHeader('Content-Type', 'image/jpeg');
                ajaxRequest.setRequestHeader('x-ms-blob-type', 'BlockBlob');
                ajaxRequest.send(fileDataAsArrayBuffer);
            }
            catch (e) {
                alert(&quot;can't upload the image to server.\n&quot; &#43; e.toString());
            }
        }
</pre>
<div class="preview">
<pre class="js">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Method&nbsp;uploads&nbsp;a&nbsp;blob&nbsp;to&nbsp;Azure&nbsp;Storage&nbsp;by&nbsp;using&nbsp;a&nbsp;Blob&nbsp;SAS&nbsp;URL.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;The&nbsp;Web&nbsp;Browser&nbsp;will&nbsp;add&nbsp;the&nbsp;necessary&nbsp;CORS&nbsp;headers&nbsp;and&nbsp;issue&nbsp;a&nbsp;preflight&nbsp;request&nbsp;if&nbsp;needed.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;blobSasUrl:&nbsp;Blob&nbsp;SAS&nbsp;URL&nbsp;already&nbsp;obtained&nbsp;through&nbsp;an&nbsp;Ajax&nbsp;call&nbsp;to&nbsp;own&nbsp;service</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;fileDataAsArrayBuffer:&nbsp;an&nbsp;ArrayBuffer&nbsp;(Byte&nbsp;Array)&nbsp;containing&nbsp;the&nbsp;raw&nbsp;data&nbsp;of&nbsp;the&nbsp;file&nbsp;to&nbsp;be&nbsp;uploaded</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;uploadImage(blobSasUrl,&nbsp;fileDataAsArrayBuffer)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;ajaxRequest&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;XMLHttpRequest();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Once&nbsp;the&nbsp;image&nbsp;is&nbsp;successfully&nbsp;upload,&nbsp;we&nbsp;will&nbsp;call&nbsp;render&nbsp;Image&nbsp;that&nbsp;would&nbsp;show&nbsp;the&nbsp;uploaded&nbsp;image</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ajaxRequest.onreadystatechange&nbsp;=&nbsp;<span class="js__operator">function</span>()&nbsp;<span class="js__brace">{</span><span class="js__statement">return</span>&nbsp;renderImage(ajaxRequest,&nbsp;blobSasUrl)<span class="js__brace">}</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">try</span>&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Performing&nbsp;a&nbsp;PutBlob&nbsp;(BlockBlob)&nbsp;against&nbsp;storage</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ajaxRequest.open(<span class="js__string">'PUT'</span>,&nbsp;blobSasUrl,&nbsp;true);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ajaxRequest.setRequestHeader(<span class="js__string">'Content-Type'</span>,&nbsp;<span class="js__string">'image/jpeg'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ajaxRequest.setRequestHeader(<span class="js__string">'x-ms-blob-type'</span>,&nbsp;<span class="js__string">'BlockBlob'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ajaxRequest.send(fileDataAsArrayBuffer);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">catch</span>&nbsp;(e)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="js__string">&quot;can't&nbsp;upload&nbsp;the&nbsp;image&nbsp;to&nbsp;server.\n&quot;</span>&nbsp;&#43;&nbsp;e.toString());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</h1>
<h1>Sample JQuery Code for accessing Windows Azure Table</h1>
<p>Please refer to the sample code provided in here for JQuery code for InsertEntity and QueryEntities code. A starting point would be the InsertTableEntities.cshtml and QueryTableEntities.cshtml files.</p>
