# Upload File to Windows Azure Blob Storage using Windows Azure Mobile Services
## Requires
- Visual Studio 2013
## License
- MS-LPL
## Technologies
- Microsoft Azure
- Windows RT
- Windows Azure Mobile Services
- Windows Store app
## Topics
- Microsoft Azure
- Data Access
- Image
- Files
- Storage
- Windows Azure Mobile Services
## Updated
- 01/05/2014
## Description

<div class="content">
<h1 id="My_Pictures_Sample">My Pictures Sample -&nbsp;Upload File to Windows Azure Blob Storage using Windows Azure Mobile Services</h1>
<h3 id="Introduction">Introduction</h3>
<p>This demonstrates how to store your files such as images, videos, documents or any binary data off device in the cloud using
<strong>Windows Azure Blob Storage</strong>.&nbsp; It will walk you through how to generate a
<em>Shared Access Signature</em> using <strong>Windows Azure Mobile Services</strong> and then show how to upload that Blob using the
<em>Windows Azure Storage Client Library</em>. In this example we focus on capturing and uploading images, using the same approach you can upload any binary data to Windows Azure Blob Storage.</p>
<h3 id="Prerequisites">Prerequisites</h3>
<ul>
<li>Visual Studio 2012 Express for Windows 8.1 </li><li>and a Windows Azure account - get the&nbsp;<a title="Windows Azure Free" href="http://www.windowsazure.com/en-us/pricing/free-trial/?WT.mc_id=AA0EDCEAF" target="_blank">Windows Azure Free Trial</a>
</li></ul>
<h3 id="Building_the_Sample">Building the Sample</h3>
<p>Follow these steps to set up the sample.</p>
<ol>
<li>
<p>Create a new <strong>Storage Account</strong> from the Windows Azure Management Portal.</p>
<p>To do this, follow the instructions in <a href="http://www.windowsazure.com/en-us/manage/services/storage/how-to-create-a-storage-account/">
How To Create a Storage Account</a>.</p>
<p>Get the <strong>Storage Account Keys</strong>. Browse to your storage account dashboard and click
<strong>Manage Access Keys</strong> on the bottom bar.</p>
<p><img id="106556" title="Manage Keys Button" src="106556-manage-keys-button.png" alt="Manage Keys Button" width="200" height="60"></p>
<p>Copy the <strong>Storage Account Name</strong> and <strong>Primary Access Key</strong> values.</p>
<p><img id="106557" title="Storage Access Keys" src="106557-storage-access-keys.png" alt="Storage Access Keys" width="551" height="457"></p>
</li><li>
<p>Create a new <strong>Mobile Service</strong> from the Windows Azure Management Portal.</p>
<p>To do this, log in to the <a href="https://manage.windowsazure.com">Windows Azure Management Portal</a>, navigate to Mobile Services and click
<strong>New</strong>.</p>
<p><img id="106558" src="106558-new-button.png" alt="New Button" width="133" height="57"></p>
<p>Expand <strong>Compute | Mobile Service</strong>, then click <strong>Create</strong>.</p>
<p>In the <strong>Create a Mobile Service</strong> page, type a subdomain name for the new mobile service in the
<strong>URL</strong> textbox (e.g: <em>mypicturesservice</em>) and wait for name verification. Once name verification completes, select
<em>Create a new SQL Database</em> in the <strong>Database</strong> dropdown list and click the right arrow button to go to the next page.</p>
<p><img id="106559" src="106559-create-new-mobile-service.png" alt="Create new Mobile Service" width="680" height="450"></p>
<p>This displays the <strong>Specify database settings</strong> page.</p>
<blockquote>
<p><strong>Note:</strong> As part of this sample, you create a new SQL database instance and server. You can reuse this new database and administer it as you would with any other SQL database instance. If you already have a database in the same region as the
 new mobile service, you can instead choose <em>Use existing Database</em> and then select that database. The use of a database in a different region is not recommended because of additional bandwidth costs and higher latencies.</p>
</blockquote>
<p>In <strong>Name</strong>, type the name of the new database. In <strong>Server Login Name</strong>, specify the administrator login name for the new SQL database server, type and confirm the password, and click the check button to complete the process.</p>
<p><img id="106560" src="106560-new-mobile-service-step-2.png" alt="New Mobile Service step 2" width="680" height="450"></p>
<p>You have now created a new mobile service that can be used by your mobile apps.</p>
</li><li>
<p>Import your Windows Azure subscription to Visual Studio.</p>
<blockquote>
<p><strong>Note:</strong> If you already imported the subscription to Visual Studio you can skip this step.</p>
</blockquote>
<p>In <strong>Server Explorer</strong>, right click on the <strong>Windows Azure</strong> node and select
<strong>Import Subscriptions...</strong>.</p>
<p><img id="106561" title="Import Subscription Menu" src="106561-import-subscription-menu.png" alt="Import Subscription Menu" width="383" height="262"></p>
<p>Click on <strong>Download subscription file</strong>, log in to your windows Azure account (if required) and click Save when your browser requests to save the file.</p>
<p><img id="106562" title="Download Subscription File" src="106562-import-subscription-download.png" alt="Download Subscription File" width="550" height="206"></p>
<blockquote>
<p><strong>Note:</strong> The login window is displayed in the browser, which may be behind your Visual Studio window. Remember to make a note of where you saved the downloaded .publishsettings file.</p>
</blockquote>
<p>Click <strong>Browse</strong>, navigate to the location where you saved the .publishsettings file, select the file, then click
<strong>Open</strong> and then <strong>Import</strong>. Visual Studio imports the data needed to connect to your Windows Azure subscription.</p>
<p><img id="106563" title="Import Subscription" src="106563-import-subscription-import.png" alt="Import Subscription" width="550" height="206"></p>
<blockquote>
<p><strong>Security Note:</strong> After importing the publish settings, consider deleting the downloaded .publishsettings file as it contains information that can be used by others to access your account. Secure the file if you plan to keep it for use in other
 connected app projects.</p>
</blockquote>
</li><li>
<p>Create a table named <strong>Album</strong>.</p>
<p>Go to Visual Studio. Open Server Explorer, expand <strong>Mobile Services</strong> under
<strong>Windows Azure</strong>, right-click your mobile service and select <strong>
Create Table...</strong>.</p>
<p><img id="106564" title="Create a new Table" src="106564-creating-a-new-table.png" alt="Create a new Table" width="447" height="218"></p>
<p>Create a new table named <strong>Album</strong> and set the permissions for Insert, Update, Delete, and Read to
<strong>&quot;Anybody with the application key&quot;</strong>.</p>
<p><img id="106567" src="106567-create-album-table.png" alt="" width="500" height="484"></p>
</li><li>
<p>Repeat the previous operation and create a table named <strong>Picture</strong>. Set permissions for Insert, Update, Delete, and Read to
<strong>&quot;Anybody with the application key&quot;</strong>.</p>
<p><img id="106566" title="Create Picture Table" src="106566-create-picture-table.png" alt="Create Picture Table" width="500" height="484"></p>
</li><li>
<p>Expand the <strong>Picture</strong> table you just created. Then right-click the
<strong>insert.js</strong> script file and select <strong>Edit script</strong>.</p>
<p><img id="106568" src="106568-edit-insert-menu-option.png" alt="edit-insert-menu-option" width="406" height="286"></p>
<p>The script opens in an editor window. Here you can insert a JavaScript function that is going to be invoked whenever someone performs an insert (the item to be inserted is passed as a parameter).</p>
<p>Update the content of the file with the code below in order to obtain the Shared Access Signature (SAS) for the pictures you will upload later. Replace the
<strong>storage account name</strong> and <strong>key</strong> placeholders with your
<strong>Windows Azure Storage Account</strong> credentials.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__statement">var</span>&nbsp;azure&nbsp;=&nbsp;require(<span class="js__string">'azure'</span>);&nbsp;
<span class="js__statement">var</span>&nbsp;qs&nbsp;=&nbsp;require(<span class="js__string">'querystring'</span>);&nbsp;
&nbsp;
<span class="js__operator">function</span>&nbsp;insert(item,&nbsp;user,&nbsp;request)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;accountName&nbsp;=&nbsp;<span class="js__string">'&lt;replace&nbsp;with&nbsp;your&nbsp;storage&nbsp;account&nbsp;name&gt;'</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;accountKey&nbsp;=&nbsp;<span class="js__string">'&lt;replace&nbsp;with&nbsp;your&nbsp;storage&nbsp;account&nbsp;key&gt;'</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;host&nbsp;=&nbsp;accountName&nbsp;&#43;&nbsp;<span class="js__string">'.blob.core.windows.net'</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;containerName&nbsp;=&nbsp;<span class="js__string">'mypictures-'</span>&nbsp;&#43;&nbsp;item.albumid.toLowerCase();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;pictureRelativePath&nbsp;=&nbsp;<span class="js__string">'/'</span>&nbsp;&#43;&nbsp;containerName&nbsp;&#43;&nbsp;<span class="js__string">'/'</span>&nbsp;&#43;&nbsp;item.fileName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;pictureThumbnailRelativePath&nbsp;=&nbsp;<span class="js__string">'/'</span>&nbsp;&#43;&nbsp;containerName&nbsp;&#43;&nbsp;<span class="js__string">'/'</span>&nbsp;&#43;&nbsp;item.thumbnailFileName;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Create&nbsp;the&nbsp;container&nbsp;if&nbsp;it&nbsp;does&nbsp;not&nbsp;exist</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Use&nbsp;public&nbsp;read&nbsp;access&nbsp;for&nbsp;the&nbsp;blobs,&nbsp;and&nbsp;the&nbsp;SAS&nbsp;to&nbsp;upload&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;blobService&nbsp;=&nbsp;azure.createBlobService(accountName,&nbsp;accountKey,&nbsp;host);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;blobService.createContainerIfNotExists(containerName,&nbsp;<span class="js__brace">{</span>&nbsp;publicAccessLevel:&nbsp;<span class="js__string">'blob'</span>&nbsp;<span class="js__brace">}</span>,&nbsp;<span class="js__operator">function</span>&nbsp;(error)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(!error)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Container&nbsp;exists&nbsp;now&nbsp;define&nbsp;a&nbsp;policy&nbsp;for&nbsp;write&nbsp;access</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;that&nbsp;starts&nbsp;immediately&nbsp;and&nbsp;expires&nbsp;in&nbsp;5&nbsp;mins</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;sharedAccessPolicy&nbsp;=&nbsp;createAccessPolicy();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Create&nbsp;the&nbsp;blobs&nbsp;urls&nbsp;with&nbsp;the&nbsp;SAS</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;item.imageurl&nbsp;=&nbsp;createResourceURLWithSAS(accountName,&nbsp;accountKey,&nbsp;pictureRelativePath,&nbsp;sharedAccessPolicy,&nbsp;host);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;item.thumbnailurl&nbsp;=&nbsp;createResourceURLWithSAS(accountName,&nbsp;accountKey,&nbsp;pictureThumbnailRelativePath,&nbsp;sharedAccessPolicy,&nbsp;host);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;console.error(error);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;request.execute();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
<span class="js__operator">function</span>&nbsp;createResourceURLWithSAS(accountName,&nbsp;accountKey,&nbsp;blobRelativePath,&nbsp;sharedAccessPolicy,&nbsp;host)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Generate&nbsp;the&nbsp;SAS&nbsp;for&nbsp;your&nbsp;BLOB</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;sasQueryString&nbsp;=&nbsp;getSAS(accountName,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;accountKey,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;blobRelativePath,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;azure.Constants.BlobConstants.ResourceTypes.BLOB,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sharedAccessPolicy);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Full&nbsp;path&nbsp;for&nbsp;resource&nbsp;with&nbsp;SAS</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;<span class="js__string">'https://'</span>&nbsp;&#43;&nbsp;host&nbsp;&#43;&nbsp;blobRelativePath&nbsp;&#43;&nbsp;<span class="js__string">'?'</span>&nbsp;&#43;&nbsp;sasQueryString;&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
<span class="js__operator">function</span>&nbsp;createAccessPolicy()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AccessPolicy:&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Permissions:&nbsp;azure.Constants.BlobConstants.SharedAccessPermissions.WRITE,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Start:&nbsp;use&nbsp;for&nbsp;start&nbsp;time&nbsp;in&nbsp;future,&nbsp;beware&nbsp;of&nbsp;server&nbsp;time&nbsp;skew&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Expiry:&nbsp;formatDate(<span class="js__operator">new</span>&nbsp;<span class="js__object">Date</span>(<span class="js__operator">new</span>&nbsp;<span class="js__object">Date</span>().getTime()&nbsp;&#43;&nbsp;<span class="js__num">5</span>&nbsp;*&nbsp;<span class="js__num">60</span>&nbsp;*&nbsp;<span class="js__num">1000</span>))&nbsp;<span class="js__sl_comment">//&nbsp;5&nbsp;minutes&nbsp;from&nbsp;now</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
<span class="js__operator">function</span>&nbsp;getSAS(accountName,&nbsp;accountKey,&nbsp;path,&nbsp;resourceType,&nbsp;sharedAccessPolicy)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;qs.encode(<span class="js__operator">new</span>&nbsp;azure.SharedAccessSignature(accountName,&nbsp;accountKey)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.generateSignedQueryString(path,&nbsp;<span class="js__brace">{</span><span class="js__brace">}</span>,&nbsp;resourceType,&nbsp;sharedAccessPolicy));&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
<span class="js__operator">function</span>&nbsp;formatDate(date)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;raw&nbsp;=&nbsp;date.toJSON();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Blob&nbsp;service&nbsp;does&nbsp;not&nbsp;like&nbsp;milliseconds&nbsp;on&nbsp;the&nbsp;end&nbsp;of&nbsp;the&nbsp;time&nbsp;so&nbsp;strip</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;raw.substr(<span class="js__num">0</span>,&nbsp;raw.lastIndexOf(<span class="js__string">'.'</span>))&nbsp;&#43;&nbsp;<span class="js__string">'Z'</span>;&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<p>When you save changes to the insert.js file, a new version of the script is uploaded to your mobile service.</p>
</li><li>
<p>Connect the Windows 8 app to Mobile Services.</p>
<p>Get the <strong>Mobile Service URL</strong> and <strong>Mobile Service Key</strong> values. Browse to your Mobile Service dashboard, copy the service URL and click
<strong>Manage Keys</strong> on the bottom bar.</p>
<p><img id="106569" title="Mobile Service URL" src="106569-mobile-service-settings-dashboard.png" alt="Mobile Service URL" width="945" height="616"></p>
<p>Now copy the <strong>Application Key</strong> value.</p>
<p><img id="106570" title="Mobile Service Access Key" src="106570-mobile-service-settings-keys.png" alt="Mobile Service Access Key" width="500" height="349"></p>
<p>In Visual Studio, open the <strong>Windows Store</strong> app provided in this sample, open the
<strong>App.xaml.cs</strong> file in the solution and replace the placeholders <strong>
{mobile-service-url}</strong> and <strong>{mobile-service-key}</strong> with the values obtained in the previous steps.</p>
&lt;!-- mark:2-3 --&gt;
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;MobileServiceClient&nbsp;mobileService&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MobileServiceClient(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;https://{mobile-service-name}.azure-mobile.net/&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;{mobile-service-application-key}&quot;</span>);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</li><li>
<p>Use the Windows Azure Storage Client Library to upload blobs.</p>
<p>In Visual Studio, install the <a href="http://www.nuget.org/packages/WindowsAzure.Storage-Preview">
WindowsAzure.Storage-Preview</a> NuGet package in the project using the Package Manage Console directly within Visual Studio</p>
&lt;!-- mark:1 --&gt;
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>PowerShell</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">powershell</span>

<div class="preview">
<pre class="js">Install-Package&nbsp;WindowsAzure.Storage-Preview&nbsp;-Pre</pre>
</div>
</div>
</div>
<p>Right-click the <strong>DataModel</strong> folder and select <strong>Add | Class...</strong>. In the Add New Item dialog box, change the name of the class file to
<strong>BlobStorageHelper.cs</strong> and click <strong>Add</strong>. Replace the contents of the class file with the code below.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js"><span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;using&nbsp;System;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;using&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.IO.aspx" target="_blank" title="Auto generated link to System.IO">System.IO</a>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;using&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Threading.Tasks.aspx" target="_blank" title="Auto generated link to System.Threading.Tasks">System.Threading.Tasks</a>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;using&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/Microsoft.WindowsAzure.Storage.Auth.aspx" target="_blank" title="Auto generated link to Microsoft.WindowsAzure.Storage.Auth">Microsoft.WindowsAzure.Storage.Auth</a>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;using&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/Microsoft.WindowsAzure.Storage.Blob.aspx" target="_blank" title="Auto generated link to Microsoft.WindowsAzure.Storage.Blob">Microsoft.WindowsAzure.Storage.Blob</a>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;BlobStorageHelper&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;static&nbsp;async&nbsp;Task&nbsp;UploadBlob(Stream&nbsp;fileStream,&nbsp;string&nbsp;fileName,&nbsp;string&nbsp;blobUrl,&nbsp;string&nbsp;containerName)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;fileStream.Position&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;sasUri&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Uri(blobUrl);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">////&nbsp;Our&nbsp;credential&nbsp;for&nbsp;the&nbsp;upload&nbsp;is&nbsp;our&nbsp;SAS&nbsp;token</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StorageCredentials&nbsp;cred&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;StorageCredentials(sasUri.Query.Substring(<span class="js__num">1</span>));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CloudBlobContainer&nbsp;container&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;CloudBlobContainer(<span class="js__operator">new</span>&nbsp;Uri(string.Format(<span class="js__string">&quot;https://{0}/{1}&quot;</span>,&nbsp;sasUri.Host,&nbsp;containerName)),&nbsp;cred);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CloudBlockBlob&nbsp;blobFromSASCredential&nbsp;=&nbsp;container.GetBlockBlobReference(fileName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;blobFromSASCredential.UploadFromStreamAsync(fileStream.AsInputStream());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<blockquote>
<p><strong>Note:</strong> This helper method will be called to upload the picture and the picture's thumbnail directly to blob storage using SAS and the Storage Client library for Windows 8.</p>
</blockquote>
<p>Open the <strong>AlbumDataSource.cs</strong> file in the <strong>DataModel</strong> folder, and locate the
<em>//// TODO</em> line inside the <strong>UploadPicture</strong> method. Replace that line with the following code to upload the picture to blob storage using SAS.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">public&nbsp;static&nbsp;async&nbsp;Task&nbsp;UploadPicture(UploadViewModel&nbsp;uploadForm)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;...&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;containerName&nbsp;=&nbsp;string.Format(<span class="js__string">&quot;mypictures-{0}&quot;</span>,&nbsp;pictureItem.AlbumId).ToLowerInvariant();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">////&nbsp;Upload&nbsp;picture&nbsp;directly&nbsp;to&nbsp;blob&nbsp;storage&nbsp;using&nbsp;SAS&nbsp;and&nbsp;the&nbsp;Storage&nbsp;Client&nbsp;library&nbsp;for&nbsp;Windows&nbsp;8</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">////&nbsp;Get&nbsp;a&nbsp;stream&nbsp;of&nbsp;the&nbsp;image&nbsp;just&nbsp;taken</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;using&nbsp;(<span class="js__statement">var</span>&nbsp;fileStream&nbsp;=&nbsp;await&nbsp;uploadForm.PictureFile.OpenStreamForReadAsync())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;BlobStorageHelper.UploadBlob(fileStream,&nbsp;pictureItem.FileName,&nbsp;pictureItem.ImageUrl,&nbsp;containerName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">////&nbsp;Thumbnail&nbsp;upload</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;using&nbsp;(<span class="js__statement">var</span>&nbsp;fileStream&nbsp;=&nbsp;uploadForm.PictureThumbnail.AsStreamForRead())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;BlobStorageHelper.UploadBlob(fileStream,&nbsp;pictureItem.ThumbnailFileName,&nbsp;pictureItem.ThumbnailUrl,&nbsp;containerName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">////&nbsp;Update&nbsp;the&nbsp;picture&nbsp;Table&nbsp;to&nbsp;remove&nbsp;the&nbsp;SAS&nbsp;from&nbsp;the&nbsp;URL</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;pictureItem.ThumbnailUrl&nbsp;=&nbsp;pictureItem.ThumbnailUrl.Substring(<span class="js__num">0</span>,&nbsp;pictureItem.ThumbnailUrl.IndexOf(<span class="js__string">'?'</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;pictureItem.ImageUrl&nbsp;=&nbsp;pictureItem.ImageUrl.Substring(<span class="js__num">0</span>,&nbsp;pictureItem.ImageUrl.IndexOf(<span class="js__string">'?'</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;pictureTable.UpdateAsync(pictureItem);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;...&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<pre><code class="C#">
</code></pre>
</li></ol>
<h3 id="Running_the_Sample">Running the Sample</h3>
<ol>
<li>
<p>In Visual Studio, press <strong>F5</strong> to launch the application.</p>
<blockquote>
<p><strong>Note:</strong> If this is the first time you run the app, you may get an error message saying that the build restored the NuGet packages. If that is the case, run the app one more time to include those packages in the build (for more information,
 see <a href="http://go.microsoft.com/fwlink/?LinkID=317568">http://go.microsoft.com/fwlink/?LinkID=317568</a>).</p>
</blockquote>
</li><li>
<p>In the main page, swipe the bottom edge of the screen (or right-click with the mouse) to make app bars appear and click or tap
<strong>Upload</strong>.</p>
<p><img id="106571" title="Upload Button" src="106571-mypictures-upload-button.png" alt="Upload Button" width="122" height="92"></p>
</li><li>
<p>In the upload page, select an image and provide the required information. Then, click or tap the
<strong>Upload picture</strong> button.</p>
<p><img id="106573" title="Upload Page" src="106573-mypictures-upload-page.png" alt="Upload Page" width="1077" height="374"></p>
</li><li>
<p>The new uploaded picture is shown in the main page.</p>
<p><img id="106574" title="Main Page" src="106574-mypictures-main-page.png" alt="Main Page" width="391" height="411"></p>
</li><li>
<p>Switch to the Windows Azure Management Portal, and select the storage account created for this sample.</p>
</li><li>
<p>In the <strong>Containers</strong> tab, select the container and browse to the URL of the uploaded blob.</p>
<p><img id="106575" title="Uploaded Blob" src="106575-mypictures-blob.png" alt="Uploaded Blob" width="1024" height="784"></p>
</li></ol>
</div>
<p>Want to see More Windows Store app samples using Windows Azure Mobile Services - check out the
<a href="http://code.msdn.microsoft.com/windowsapps/site/search?f%5B0%5D.Type=Technology&f%5B0%5D.Value=Windows%20Azure%20Mobile%20Services&f%5B0%5D.Text=Windows%20Azure%20Mobile%20Services" target="_blank">
full listing</a>. If you cant find a specific&nbsp;Windows Azure Mobile Services&nbsp;scenaro in the
<a href="http://code.msdn.microsoft.com/windowsapps/site/search?f%5B0%5D.Type=Technology&f%5B0%5D.Value=Windows%20Azure%20Mobile%20Services&f%5B0%5D.Text=Windows%20Azure%20Mobile%20Services" target="_blank">
full listing</a> please&nbsp;feel free to reach out on Twitter&nbsp;via&nbsp;<a href="http://www.twitter.com/cloudnick" target="_blank">@cloudnick</a></p>
