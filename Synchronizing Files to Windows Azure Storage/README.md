# Synchronizing Files to Windows Azure Storage
## Requires
- Visual Studio 2010
## License
- Custom
## Technologies
- Microsoft Azure
- Microsoft Sync Framework 2.0
## Topics
- Microsoft Azure
- synchronize files with Azure Blob Storage
## Updated
- 05/13/2011
## Description

<div class="WikiContent">
<div class="wikidoc">At PDC09 we talked quite a bit about how to synchronize data to the cloud. Most of this revolved around synchronizing structured data to and from SQL Azure. If you are interested in that, check out our Developer Quick Start at
<a class="externalLink" href="http://www.microsoft.com/windowsazure/developers/sqlazure/datasync/">
http://www.microsoft.com/windowsazure/developers/sqlazure/datasync/<span class="externalLinkIcon">&nbsp;</span></a>, which includes a link to download Microsoft Sync Framework Power Pack for SQL Azure November CTP.
<br>
<br>
For this sample, however, we augmented that information to answer another question that we are frequently asked and were asked a number of times at PDC, &ldquo;How can I synchronize things like files with Azure Blob Storage?&rdquo; The answer at this point
 is that you&rsquo;ll have to build a provider. The good news is that it&rsquo;s not too hard. We built one here that we will describe as part of this sample.</div>
<div class="wikidoc"></div>
<div class="wikidoc">
<p>So how does it work?&nbsp; The sample itself consists of three major portions: the actual provider, some wrapper code on Azure Blob Storage, and a simple console application to run it.&nbsp; I&rsquo;ll talk in a bit more depth about both the provider and
 the Azure Blob Storage integration.&nbsp; On the client side the sample uses Sync Framework&rsquo;s file synchronization provider.&nbsp; The file synchronization provider solves a lot of the hard problems for synchronizing files, including moves, renames,
 etc., so it is a great way to get this up and going quickly.</p>
<p>The azure provider is implemented as a FullEnumerationSimpleSyncProvider, using the
<a href="http://msdn.microsoft.com/en-us/library/dd937763%28SQL.105%29.aspx">simple provider</a> components of Sync Framework.&nbsp; Simple providers are a way to create Sync Framework providers for data stores that do not have built-in synchronization support.</p>
<p>The provider itself derives from the <a href="http://msdn.microsoft.com/en-us/library/microsoft.synchronization.simpleproviders.fullenumerationsimplesyncprovider%28SQL.105%29.aspx">
FullEnumerationSimpleSyncProvider</a> class, which is used for stores that don&rsquo;t support any form of change detection whatsoever.&nbsp; It&rsquo;s extremely useful because this is actually the category that most off-the-shelf stores fall into (another
 great example of this type of store is the FAT file system).&nbsp; Sync Framework also contains the notion of an
<a href="http://msdn.microsoft.com/en-us/library/microsoft.synchronization.simpleproviders.anchorenumerationsimplesyncprovider%28SQL.105%29.aspx">
AnchorEnumerationSimpleSyncProvider</a> for stores that have the ability to enumerate changes based on some type of anchor (timestamp, tick count, opaque blob of goo, whatever).&nbsp; But for now I&rsquo;m going to focus on full enumeration as that is what
 is required for Azure Blob Storage at this point.</p>
<p>The basic idea behind a full enumeration synchronization provider is that you need to tell Sync Framework some basic information about the items you'll be synchronizing, how to identify them and how to detect a version change, and then give Sync Framework
 the ability to enumerate through the items looking for changes.&nbsp; To tell Sync Framework about the items, override the MetadataSchema property of the FullEnumerationSimpleSyncProvider class.&nbsp; When you build the metadata schema you&rsquo;ll specify
 a set of custom fields to track, and an IdentityRule.&nbsp; Together these things make up the set of data required to track and identify changes for objects in the store.&nbsp; For the Azure Blob synchronization provider this property looks like this:</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;ItemMetadataSchema&nbsp;MetadataSchema&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CustomFieldDefinition[]&nbsp;customFields&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;CustomFieldDefinition[<span class="cs__number">2</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;customFields[<span class="cs__number">0</span>]&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;CustomFieldDefinition(ItemFields.CUSTOM_FIELD_NAME,&nbsp;<span class="cs__keyword">typeof</span>(<span class="cs__keyword">string</span>),&nbsp;AzureBlobStore.MaxFileNameLength);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;customFields[<span class="cs__number">1</span>]&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;CustomFieldDefinition(ItemFields.CUSTOM_FIELD_TIMESTAMP,&nbsp;<span class="cs__keyword">typeof</span>(<span class="cs__keyword">ulong</span>));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IdentityRule[]&nbsp;identityRule&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;IdentityRule[<span class="cs__number">1</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;identityRule[<span class="cs__number">0</span>]&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;IdentityRule(<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">uint</span>[]&nbsp;{&nbsp;ItemFields.CUSTOM_FIELD_NAME&nbsp;});&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;ItemMetadataSchema(customFields,&nbsp;identityRule);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>Next, in order to let Sync Framework detect changes you need to override the EnumerateItems method.&nbsp; In your EnumerateItems implementation you&rsquo;ll create a List of ItemFieldDictionary objects to tell Sync Framework about all of the metadata properties
 you have specified in your MetadataSchema.&nbsp; Sync Framework uses this information to track the state of objects in the store, looking for adds, updates, and deletes and then produces the proper synchronization metadata for those changes so that they can
 be synchronized with any Sync Framework provider.&nbsp; The implementation for EnumerateItems in this sample looks like this:</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp"><span class="cs__com">//&nbsp;Enumerate&nbsp;all&nbsp;items&nbsp;in&nbsp;the&nbsp;store</span>&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;EnumerateItems(FullEnumerationContext&nbsp;context)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;List&lt;ItemFieldDictionary&gt;&nbsp;items&nbsp;=&nbsp;DataStore.ListBlobs();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;context.ReportItems(items);&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>There is obviously some hidden detail here because I&rsquo;ve put some of the work in the store wrapper that I mentioned previously.&nbsp; I&rsquo;ll talk more about the store wrapper in a moment but I&rsquo;ll include its ListBlobs method here since it
 is relevant.</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="js">internal&nbsp;List&lt;ItemFieldDictionary&gt;&nbsp;ListBlobs()&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;List&lt;ItemFieldDictionary&gt;&nbsp;items&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;List&lt;ItemFieldDictionary&gt;();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;BlobRequestOptions&nbsp;opts&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;BlobRequestOptions();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;opts.UseFlatBlobListing&nbsp;=&nbsp;true;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;opts.BlobListingDetails&nbsp;=&nbsp;BlobListingDetails.Metadata;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;foreach&nbsp;(IListBlobItem&nbsp;o&nbsp;<span class="js__operator">in</span>&nbsp;Container.ListBlobs(opts))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CloudBlob&nbsp;blob&nbsp;=&nbsp;Container.GetBlobReference(o.Uri.ToString());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ItemFieldDictionary&nbsp;dict&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;ItemFieldDictionary();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dict.Add(<span class="js__operator">new</span>&nbsp;ItemField(ItemFields.CUSTOM_FIELD_NAME,&nbsp;<span class="js__operator">typeof</span>(string),&nbsp;o.Uri.ToString()));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dict.Add(<span class="js__operator">new</span>&nbsp;ItemField(ItemFields.CUSTOM_FIELD_TIMESTAMP,&nbsp;<span class="js__operator">typeof</span>(ulong),&nbsp;(ulong)blob.Properties.LastModifiedUtc.ToBinary()));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;items.Add(dict);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__statement">return</span>&nbsp;items;&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>What this ListBlobs implementation does is simply walk through all of the blobs in the container (container is an Azure Blob Storage concept; in this sample I treat it like a root directory).&nbsp; Then, for each blob get out the information that was specified
 for the MetadataSchema and build a list of that information to give back to Sync Framework.</p>
<p>The last crucial bit for the providers is to give Sync Framework a way to add, update, or delete items from the store.&nbsp; To do this, override
<a href="http://msdn.microsoft.com/en-us/library/microsoft.synchronization.simpleproviders.simplesyncprovider.insertitem%28SQL.105%29.aspx">
InsertItem</a>, <a href="http://msdn.microsoft.com/en-us/library/microsoft.synchronization.simpleproviders.simplesyncprovider.updateitem%28SQL.105%29.aspx">
UpdateItem</a>, and <a href="http://msdn.microsoft.com/en-us/library/microsoft.synchronization.simpleproviders.simplesyncprovider.deleteitem%28SQL.105%29.aspx">
DeleteItem</a> respectively.&nbsp; I won&rsquo;t include the source for those methods here for brevity but you can check them out in the sample.</p>
<p>There are a couple of other things that are needed for the synchronization provider but those are mostly bookkeeping and I&rsquo;ll let you look at the sample to get the details.</p>
<p>At this point, I want to talk briefly about the store wrapper class.&nbsp; The store wrapper class utilizes objects in the <a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/Microsoft.WindowsAzure.StorageClient.aspx" target="_blank" title="Auto generated link to Microsoft.WindowsAzure.StorageClient">Microsoft.WindowsAzure.StorageClient</a> namespace.&nbsp; To get that you&rsquo;ll need to download
<a href="http://www.microsoft.com/downloads/details.aspx?FamilyID=6967ff37-813e-47c7-b987-889124b43abd&displaylang=en">
Windows Azure Tools for Microsoft Visual Studio</a>.&nbsp; I&rsquo;m not going to go into too much detail about the store wrapper itself.&nbsp; It has most of the methods you&rsquo;d expect, such as the ListBlobs method seen above, and the corresponding methods
 for adds, updates, and deletes.&nbsp; I do want to talk a little bit about one important detail with the store and that is
<em>optimistic concurrency</em>.&nbsp; Optimistic concurrency is the thing that will allow multiple synchronization clients to work with the store at the same time without overwriting each other unwittingly and corrupting data.&nbsp; The Sync Framework simple
 providers are designed to work well with stores that support optimistic concurrency so that they can provide correct synchronization.</p>
<div class="wikidoc">The great news is that Windows Azure Blob Storage supports optimistic concurrency well.&nbsp; If you are using the StorageClient API, it does this by using a BlobRequestOptions object.&nbsp; You can see an example of how this works in
 the DeleteFile method of the store wrapper:</div>
<div class="wikidoc"></div>
<div class="wikidoc">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp"><span class="cs__keyword">internal</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;DeleteFile(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;name,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;DateTime&nbsp;expectedLastModified&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CloudBlob&nbsp;blob&nbsp;=&nbsp;Container.GetBlobReference(name);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;blob.FetchAttributes();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(StorageClientException&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Someone&nbsp;may&nbsp;have&nbsp;deleted&nbsp;the&nbsp;blob&nbsp;in&nbsp;the&nbsp;meantime</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(e.ErrorCode&nbsp;==&nbsp;StorageErrorCode.BlobNotFound)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;ApplicationException(<span class="cs__string">&quot;Concurrency&nbsp;Violation&quot;</span>,&nbsp;e);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;BlobProperties&nbsp;blobProperties&nbsp;=&nbsp;blob.Properties;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;...&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;BlobRequestOptions&nbsp;opts&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;BlobRequestOptions();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;opts.AccessCondition&nbsp;=&nbsp;AccessCondition.IfNotModifiedSince(expectedLastModified);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;blob.Delete(opts);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>(&nbsp;StorageClientException&nbsp;e&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Someone&nbsp;must&nbsp;have&nbsp;modified&nbsp;the&nbsp;file&nbsp;in&nbsp;the&nbsp;meantime</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(e.ErrorCode&nbsp;==&nbsp;StorageErrorCode.BlobNotFound&nbsp;||&nbsp;e.ErrorCode&nbsp;==&nbsp;StorageErrorCode.ConditionFailed)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;ApplicationException(<span class="cs__string">&quot;Concurrency&nbsp;Violation&quot;</span>,&nbsp;e);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>Note that by specifying the AccessCondition property of the BlobRequestOptions object, the code tells Azure Blob Storage not to touch the file if the file has been modified since the last time we looked at it.&nbsp; If the file has been touched, the CloudBlog
 object from the StorageClient library throws StorageClientException.&nbsp; For a couple of specific errors, the store wrapper converts that into ApplicationException to let other parts of the code know that they should treat this as a temporary error and temporarily
 skip it from the perspective of synchronization.&nbsp; That code is in the DeteleItem method of the provider and looks like this:</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre id="codePreview" class="js"><span class="js__statement">try</span><span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;DataStore.DeleteFile(name,&nbsp;expectedLastUpdate);&nbsp;
<span class="js__brace">}</span><span class="js__statement">catch</span>&nbsp;(ApplicationException&nbsp;e)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;recoverableErrorReportingContext.RecordRecoverableErrorForChange(<span class="js__operator">new</span>&nbsp;RecoverableErrorData(e));&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>What this does is cause Sync Framework to temporarily exclude that particular item from synchronization. The item will be picked up again later.</p>
Now, to run this sample you&rsquo;ll need to download the <a href="http://www.microsoft.com/downloads/details.aspx?FamilyID=89adbb1e-53ff-41b5-ba17-8e43a2e66254&displaylang=en">
Microsoft Sync Framework v2 SDK</a> as well as the <a href="http://www.microsoft.com/downloads/details.aspx?FamilyID=6967ff37-813e-47c7-b987-889124b43abd&displaylang=en">
Windows Azure Tools for Microsoft Visual Studio</a>.&nbsp; The sample synchronizes to a Windows Azure Blob Storage project so you&rsquo;ll need to make sure that you have an account and project set up.&nbsp; To get started on that, go to
<a href="http://www.microsoft.com/windowsazure/">http://www.microsoft.com/windowsazure/</a>.&nbsp; Finally, when running the sample you&rsquo;ll need to modify the app.config file for the sample and specify the AccountName and AccountSharedKey properties for
 the storage project that you created.&nbsp; When you actually run it from the command line, the application expects to be given a container name (this is an Azure Blob Storage concept mentioned previously) and a local path.&nbsp; It will synchronize everything
 from the local path, including subdirectories, up to the container specified.</div>
<p>So that&rsquo;s basically it.&nbsp; Please give this a try, check out the code, and let us know what you think by sending mail to
<a href="mailto:syncfdbk@microsoft.com?subject=Azure%20Blob%20Provider%20feedback">
syncfdbk@microsoft.com</a>.&nbsp; If you do this with photos you can easily view them in your web browser by going to https://&lt;accountName&gt;.blobs.core.windows.net/&lt;containerName&gt;/&lt;fileName&gt;.jpg.</p>
<p>One final note that is worth covering: A great question to ask here is, &ldquo;Why not just use Live Mesh to synchronize the files?&rdquo;&nbsp; The answer to that is that if Live Mesh fits your scenario and requirements, then you absolutely should use it.&nbsp;
 Live Mesh, part of the Windows Live Platform, is a great product and will allow you to synchronize files between any set of PCs and mobile devices.&nbsp; It is perfect for a lot of synchronization scenarios involving files.&nbsp; Most of the customers that
 have asked us about how to accomplish this with Sync Framework need something special.&nbsp; For instance, they are creating an end-to-end application and want explicit control over everything (instead of leaving that up to the end user) including where the
 files are synchronized, etc.&nbsp; Other examples are customers who specifically want the files in Azure Blob Storage so that they can use them with their Azure Web Application.&nbsp; The bottom line is that if Live Mesh meets your needs, then great.&nbsp;
 If not, Sync Framework is a perfect alternative for meeting the synchronization needs of your application.</p>
So there it is.&nbsp; This is a simple example of how to synchronize files with Azure Blob Storage.&nbsp; You can take this a lot further by for instance hosting in a Windows Azure Web Role and storing the item metadata directly in the file metadata.&nbsp;
 But using the method described above is fast to get up and running and performs well for a number of scenarios.&nbsp; Let us know if you have any questions or comments.</div>
<div class="wikidoc"><br>
To get started you will need:</div>
<div class="wikidoc"></div>
<div class="wikidoc">
<ul>
<li>Microsoft Sync Framework 2.0 or higher <a class="externalLink" href="http://www.microsoft.com/downloads/details.aspx?FamilyID=89adbb1e-53ff-41b5-ba17-8e43a2e66254&displaylang=en">
http://www.microsoft.com/downloads/details.aspx?FamilyID=89adbb1e-53ff-41b5-ba17-8e43a2e66254&amp;displaylang=en<span class="externalLinkIcon">&nbsp;</span></a>
</li><li>Windows Azure Tools for Microsoft Visual Studio <a class="externalLink" href="http://www.microsoft.com/downloads/details.aspx?FamilyID=5664019e-6860-4c33-9843-4eb40b297ab6&DisplayLang=en&nbsp;">
http://www.microsoft.com/downloads/details.aspx?FamilyID=5664019e-6860-4c33-9843-4eb40b297ab6&amp;DisplayLang=en<span class="externalLinkIcon">&nbsp;</span></a>
</li></ul>
</div>
<div class="WikiContent">
<p><strong>Note:</strong> If you use Visual Studio 2010 to compile these samples, you will first need to remove references to the Sync Framework assemblies and then re-add the assembly references to the projects. Otherwise, you will see &quot;type or namespace name
 could not be found&quot; compilation errors.</p>
<hr>
<p><img src="19002-msf_logo.jpg" alt="" width="639" height="56"></p>
</div>
</div>
<div></div>
<div class="DescriptionAndFileUpload" id="DescriptionAndFileUploadDiv">
<div id="ctl00_ctl00_Content_TabContentPanel_Content_FileUpdatePanel">
<div class="FileUpload ClearLeft"></div>
</div>
</div>
