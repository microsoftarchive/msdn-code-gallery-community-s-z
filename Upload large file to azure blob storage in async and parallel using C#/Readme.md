# Upload large file to azure blob storage in async and parallel using C#
## Requires
- Visual Studio 2013
## License
- MS-LPL
## Technologies
- C#
- Microsoft Azure
- Visual Studio 2013
## Topics
- Performance
## Updated
- 08/26/2014
## Description

<h1>Introduction</h1>
<p><span style="font-size:small"><em>Sample demonstrates how to upload large files to azure blob storage using C# in parallel and async way.
</em></span></p>
<h1><span>Building the Sample</span></h1>
<p><span style="line-height:115%; font-family:&quot;Comic Sans MS&quot;; font-size:small">I am using VS2013, Azure SDK 2.3 and Storage library as &ldquo;Windows Azure Storage 4.1.0&rdquo;<br>
launched on 23<sup>rd</sup> of Jun 2014.</span></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><span style="line-height:115%; font-family:&quot;Comic Sans MS&quot;; font-size:10pt">This sample&nbsp;explains the code by which you can UPLOAD MULTIPLE LARGE FILEs TO<br>
AZURE BLOB IN PARALLEL (PRECISELY BLOCK BLOB).&nbsp;</span>&nbsp;</p>
<address><span style="font-size:medium"><strong>Important - Full Description and approach&nbsp;is explained in detail and it is available on the link -<a href="http://sanganakauthority.blogspot.com/2014/07/upload-large-files-to-azure-block-blob.html">http://sanganakauthority.blogspot.com/2014/07/upload-large-files-to-azure-block-blob.html</a></strong></span></address>
<p><span style="font-size:small"><strong>&nbsp;</strong></span></p>
<p><span style="font-size:small"><strong>What I am doing and what I am not?</strong></span></p>
<ol>
<li><span style="font-size:small">Ask user to provide list large files and blob names to upload in one go in parallel.
</span></li><li><span style="font-size:small">The code will use TPL (Parallel.ForEach loop precisely) to perform simultaneous uploads of azure blobs.
</span></li><li><span style="font-size:small">Code will chop the large files into multiple blocks.
</span></li><li><span style="font-size:small">Every block of file is uploading in SYNC. I am not performing any ASYNC operation while uploading individual blocks to azure blob. (Precisely I will be using PutBlock and PutBlockList methods).
</span></li><li><span style="font-size:small">However, the UI project (In my case it is console application, also it can be either Worker Role) calls the method of upload blob in ASYNC way with the help of BeginInvoke and EndInvoke.
</span></li></ol>
<p><br>
<span style="font-size:small"><strong>Reference &ndash; 60% of this code is based on solution provided by codeplex on this post -
<a href="http://azurelargeblobupload.codeplex.com/SourceControl/latest#AzurePutBllockExample/">
http://azurelargeblobupload.codeplex.com/SourceControl/latest#AzurePutBllockExample/</a></strong></span><br>
<span style="font-size:small"><strong>It is a great solution to upload large files to azure blob storage. Just awesome!! I have changed so that, we can perform parallel uploads of large files.</strong></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public List&lt;BlobOperationStatus&gt; UploadBlockBlobsInParallel(List&lt;FileBlobNameMapper&gt; fileBlobNameMapperList, string containerName)
        {
            //create list of blob operation status 
            List&lt;BlobOperationStatus&gt; blobOperationStatusList = new List&lt;BlobOperationStatus&gt;();

            //upload every file from list to blob in parallel (multitasking)
            Parallel.ForEach(fileBlobNameMapperList, fileBlobNameMapper =&gt;
            {
                string blobName = fileBlobNameMapper.BlobName;

                //read file contents in byte array
                byte[] fileContent = File.ReadAllBytes(fileBlobNameMapper.FilePath);

                //call private method to actually perform upload of files to blob storage
                BlobOperationStatus blobStatus = UploadBlockBlobInternal(fileContent, containerName, blobName);

                //add the status of every blob upload operation to list.
                blobOperationStatusList.Add(blobStatus);
            });

            return blobOperationStatusList;
        }</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;List&lt;BlobOperationStatus&gt;&nbsp;UploadBlockBlobsInParallel(List&lt;FileBlobNameMapper&gt;&nbsp;fileBlobNameMapperList,&nbsp;<span class="cs__keyword">string</span>&nbsp;containerName)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//create&nbsp;list&nbsp;of&nbsp;blob&nbsp;operation&nbsp;status&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;List&lt;BlobOperationStatus&gt;&nbsp;blobOperationStatusList&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;BlobOperationStatus&gt;();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//upload&nbsp;every&nbsp;file&nbsp;from&nbsp;list&nbsp;to&nbsp;blob&nbsp;in&nbsp;parallel&nbsp;(multitasking)</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Parallel.ForEach(fileBlobNameMapperList,&nbsp;fileBlobNameMapper&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;blobName&nbsp;=&nbsp;fileBlobNameMapper.BlobName;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//read&nbsp;file&nbsp;contents&nbsp;in&nbsp;byte&nbsp;array</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;fileContent&nbsp;=&nbsp;File.ReadAllBytes(fileBlobNameMapper.FilePath);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//call&nbsp;private&nbsp;method&nbsp;to&nbsp;actually&nbsp;perform&nbsp;upload&nbsp;of&nbsp;files&nbsp;to&nbsp;blob&nbsp;storage</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BlobOperationStatus&nbsp;blobStatus&nbsp;=&nbsp;UploadBlockBlobInternal(fileContent,&nbsp;containerName,&nbsp;blobName);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//add&nbsp;the&nbsp;status&nbsp;of&nbsp;every&nbsp;blob&nbsp;upload&nbsp;operation&nbsp;to&nbsp;list.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;blobOperationStatusList.Add(blobStatus);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;blobOperationStatusList;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<h1><em><em>Enhancements - </em></em></h1>
<p><span style="font-size:small">If you are looking for REST api and SAS based blob upload sample then refer to the link -
<a href="http://sanganakauthority.blogspot.com/2014/08/using-sas-renew-sas-and-rest-api-to.html">
http://sanganakauthority.blogspot.com/2014/08/using-sas-renew-sas-and-rest-api-to.html</a></span></p>
<p>&nbsp;</p>
<h1>&nbsp;More Information</h1>
<p><span style="font-size:medium"><em><a href="http://sanganakauthority.blogspot.com/2014/07/upload-large-files-to-azure-block-blob.html">http://sanganakauthority.blogspot.com/2014/07/upload-large-files-to-azure-block-blob.html</a></em></span></p>
