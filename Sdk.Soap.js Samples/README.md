# Sdk.Soap.js Samples
## Requires
- Visual Studio 2012
## License
- MS-LPL
## Technologies
- CRM Online
- Javascript
- Microsoft CRM SDK
- Microsoft Dynamics CRM 2013
## Topics
- CRM Extensibility
- Microsoft Dynamics CRM SDK
- SOAP Web Service
- Use Microsoft CRM SOAP web service with JavaScript
## Updated
- 12/13/2014
## Description

<ul>
<li><a href="#intro">Introduction</a> </li><li><a href="#solution">Sdk.Soap.js Samples solution</a> </li><li><a href="#organization">Organization of files</a> </li><li><a href="#helpers">SampleHelperMethods.js</a> </li><li><a href="#asyncearly">AsyncEarlyBindingCRUD.js</a> </li><li><a href="#asynclate">AsyncLateBindingCRUD.js</a> </li><li><a href="#jquery">jQuerySample.js</a> </li><li><a href="#q">QSample.js</a> </li><li><a href="#metadata">RetrieveMetadataChangesSample.js</a> </li><li><a href="#fetch">Sdk.Query.FetchExpressionSample.js</a> </li><li><a href="#query">Sdk.Query.QueryExpressionSample.js</a> </li><li><a href="#sync">SyncSample.js</a> </li></ul>
<div>
<h1 id="intro">Introduction</h1>
<p>This project contains samples using the <a href="http://code.msdn.microsoft.com/SdkSoapjs-9b51b99a" target="_blank">
Sdk.Soap.js </a>library. Refer to that project for documentation about using the Sdk.Soap.js library.</p>
<p>This project describes the samples as well as recommended coding practices when using this library in Microsoft Dynamics CRM web resources.</p>
</div>
<div>
<h1 id="solution">Sdk.Soap.js Samples solution</h1>
<p>Included in this project is a Microsoft Dynamics CRM managed solution made using the files in this project. To verify that the samples work and to observe the intended behavior, install the
<strong><a title="SdkSoapjsSamples_managed.zip" href="http://download.microsoft.com/download/6/E/6/6E693FD1-1F03-453C-B2BC-43AE7D7C6D53/SdkSoapjsSamples_managed.zip">SdkSoapjsSamples_managed.zip</a>
</strong>solution by uploading it to your Microsoft Dynamics CRM 2013 organization.
<a href="http://technet.microsoft.com/en-us/library/dn531198(v=crm.6).aspx#BKMK_ImportSolutions">
Find out how to import solutions</a>.</p>
<p>After you install the solution, go to the solution configuration page to view the
<strong>Launcher.html</strong> page included in this project. Use the links in that page to view the sample pages.</p>
<p>Each sample includes one or two buttons to execute the code in the sample.</p>
<p>Each of the samples is an HTML web resource that is linked to other files in the sample using relative paths.</p>
<p><strong>Note</strong>:The <strong>sample_/SdkSoap/samples/QSample.html</strong> doesn&rsquo;t function because the
<strong>q.min.js</strong> libraries referenced by the files isn&rsquo;t included with this sample project or in the sample solution. To verify that the sample works you would need to create a JavaScript web resource named
<strong>sample_\SdkSoap\q.min.js</strong> containing the Q library. <a href="http://documentup.com/kriskowal/q/">
Find out more about the Q library</a>.</p>
</div>
<div>
<h1 id="organization">Organization of files</h1>
<p>The organization of files in this sample isn&rsquo;t intended to represent any best practice except for the way that the vsdoc and minimized libraries are separated.</p>
<p>The reason for this separation is that you&rsquo;ll probably develop the functionality for your web resources in a manner that they can be uploaded rather than creating them manually. If you&rsquo;re doing substantial web resource development, you&rsquo;ll
 probably want to automate the creation of web resources. The Microsoft Dynamics CRM 2013 SDK contains a
<a href="http://msdn.microsoft.com/en-us/library/gg328133(v=crm.6).aspx">sample web resource utility</a> that does this. Other solutions available from third parties provide similar functionality.</p>
<p>Since the <strong>vsdoc</strong> files are included in the solution only to provide design-time IntelliSense support, you don&rsquo;t want to create web resources using these files. This project separates the vsdoc files by placing them all in the
<strong>vsdoc</strong> folder while the files intended to be web resources are all under the
<strong>samples_ </strong>folder.</p>
<img id="113721" src="113721-samplefiles.png" alt="" width="266" height="446"><br>
<p>The <strong>sample_</strong> folder represents the solution publisher&rsquo;s customization prefix that is prepended to the name of any web resources created in the context of a solution where the solution publisher&rsquo;s customization prefix is &ldquo;sample&rdquo;.
 When uploading files as web resources, you can import all the files in this folder using the path from this folder as the web resource name. This way all the web resources in the project will have unique names and the relative paths used to link them will
 continue to work.</p>
<p>Beneath the <strong>samples_</strong> folder, the <strong>SdkSoap</strong> folder provides a unique name to differentiate any other web resources from this publisher that might include different versions of the same file. Within
<strong>SdkSoap</strong> are the <strong>entities</strong>, <strong>messages</strong> and
<strong>samples</strong> folders as well as the minimized <strong>jquery_1.9.1.min.js</strong>, and
<strong>Sdk.Soap.min.js</strong> files and the <strong>Launcher.html</strong> page that serves as the configuration page for the Sdk.Soap.js Samples solution.</p>
<p>Note that the default name for the minimized <strong>jquery_1.9.1.min.js</strong> file was changed to replace the hyphen with an underscore character. A hyphen is not allowed in a name for a web resource.</p>
<h2>Entity files</h2>
<p>In both the <strong>SdkSoap</strong> and <strong>vsdoc</strong> folders, the <strong>
entities</strong> folder contains files that were generated using the<a href="http://code.msdn.microsoft.com/SdkSoapjs-Entity-Class-14ca830f"> Sdk.Soap.js Entity Class Generator</a> project to support the early-bound development style. See the
<a href="http://code.msdn.microsoft.com/SdkSoapjs-9b51b99a">Sdk.Soap.js</a> project for more information about early and late binding styles and
<strong>Sdk.Soap.js Entity Class Generator </strong>for more information about how to generate these files.</p>
<img id="113722" src="113722-entityfiles.png" alt="" width="264" height="579"><br>
<p>In both folders you&rsquo;ll find classes for the Account, Opportunity, and Task entities. In
<strong>vsdoc\entities</strong>, the <strong>*.vsdoc.js</strong> files for these entities provide the larger files that contain descriptions for all the attributes in the entity. These files can be relatively large.
<strong>Sdk.Account.vsdoc.js</strong> is 167kb. Although the files are fully functional, you don&rsquo;t want to use them in solutions.</p>
<p>Within <strong>SdkSoap\entities</strong> the files are structured differently so that you can choose which attributes you want to include in your code. By default, all the attributes and relationship references are commented out; you must uncomment any of
 the attributes or relationships you want to use. These files are relatively smaller because they don&rsquo;t include the comments to support IntelliSense.
<strong>Sdk.Account.js</strong> is just 15kb. But these files could be even smaller. If you minimize the
<strong>Sdk.Account.js</strong> file used in this sample it would be only 3kb.</p>
<h2>Message Files</h2>
<p>This project uses the <strong>Retrieve</strong>, <strong>RetrieveMetadataChanges</strong>, and
<strong>SetState</strong> messages. The libraries to support these messages are in
<strong>SdkSoap\messages</strong> and <strong>vsdoc\messages</strong> folder. These message files were originally taken from the
<strong>Sdk.Soap.js</strong> project but they have been changed.</p>
<img id="113723" src="113723-messagefiles.png" alt="" width="342" height="576"><br>
<p>The files in the <strong>vsdoc\messages</strong> folder have been renamed to include
<strong>*.vsdoc.js</strong> so that it&rsquo;s easier to distinguish them as the files to support design-time IntelliSense.</p>
<p>Those files in the <strong>SdkSoap\messages</strong> folder have been minimized and renamed to include
<strong>*.min.js</strong> so that it&rsquo;s easier to distinguish them as the minimized files.</p>
<p>You should minimize the message files you use in your solutions. As you can see, there is a substantial change in file size, especially for larger files:</p>
<table>
<thead>
<tr>
<th>Message library</th>
<th>Original size</th>
<th>Minimized size</th>
</tr>
</thead>
<tbody>
<tr>
<td>Sdk.Retrieve.js</td>
<td>8 KB</td>
<td>4 KB</td>
</tr>
<tr>
<td>Sdk.RetrieveMetadataChanges.js</td>
<td>129 KB</td>
<td>58 KB</td>
</tr>
<tr>
<td>Sdk.SetState.js</td>
<td>5 KB</td>
<td>3 KB</td>
</tr>
</tbody>
</table>
<h2>Sample files</h2>
<p>The <strong>SdkSoap\samples </strong>folder contains the samples included in this project. There are 11 samples with 8 HTML pages to launch them. Each HTML page contains the necessary references and one or two buttons to execute the sample code. For each
 HTML page there is a corresponding &ldquo;code-behind&rdquo; *.js page containing the functions that run in the sample.</p>
<img id="113724" src="113724-samplefolderexpanded.png" alt="" width="380" height="743"><br>
<p>Several of the samples include the same operations but use different styles to achieve the same result. This was done to highlight some of the differences introduced within the following matrix of namespace and development styles.</p>
<table>
<thead>
<tr>
<td>&nbsp;</td>
<th>Early-bound</th>
<th>Late-bound</th>
</tr>
</thead>
<tbody>
<tr>
<td><strong>Sdk.Async</strong></td>
<td>AsyncEarlyBindingCRUD.js :<br>
earlyBindingCRUDSample</td>
<td>AsyncLateBindingCRUD.js :<br>
lateBindingCRUDSample</td>
</tr>
<tr>
<td><strong>Sdk.jQ</strong></td>
<td>jQuerySample.js :<br>
earlyBindingCRUDSample</td>
<td>jQuerySample.js :<br>
lateBindingCRUDSample</td>
</tr>
<tr>
<td><strong>Sdk.Q</strong></td>
<td>QSample.js :<br>
earlyBindingCRUDSample</td>
<td>QSample.js :<br>
lateBindingCRUDSample</td>
</tr>
<tr>
<td><strong>Sdk.Sync</strong></td>
<td>SyncSample.js :<br>
earlyBindingCRUDSample</td>
<td>SyncSample.js :<br>
lateBindingCRUDSample</td>
</tr>
</tbody>
</table>
<p>The two query samples also execute the same operations, but one uses <strong>Sdk.Query.FetchExpression
</strong>and the other uses <strong>Sdk.Query.QueryExpression</strong>. This simply highlights the different development styles afforded by each class.</p>
<p>Each of the samples use a common set of shared functions included in <strong>SampleHelperMethods.js</strong> and styles defined in
<strong>SampleStyles.css</strong>.</p>
</div>
<div>
<h1 id="helpers">SampleHelperMethods.js</h1>
<p>Before looking at the code in each sample it may be valuable to review the functions included in SampleHelperMethods.js. Some of these functions represent helpers that may be re-used or revised for use in your code.</p>
<h2 id="initializeEntity">initializeEntity function</h2>
<p>This simple function is a recommended best practice when using the late-binding style.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__operator">function</span>&nbsp;initializeEntity(entity,&nbsp;columns)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;<span class="js__sl_comment">///&lt;summary&gt;</span>&nbsp;
&nbsp;<span class="js__sl_comment">///&nbsp;Initializes&nbsp;an&nbsp;Sdk.Entity&nbsp;with&nbsp;attributes&nbsp;defined&nbsp;in&nbsp;a</span>&nbsp;
&nbsp;<span class="js__sl_comment">///&nbsp;dictionary&nbsp;object.</span>&nbsp;
&nbsp;<span class="js__sl_comment">///&lt;/summary&gt;</span>&nbsp;
&nbsp;<span class="js__sl_comment">///&lt;param&nbsp;name=&quot;entity&quot;&nbsp;type=&quot;Sdk.Entity&quot;&nbsp;optional='false'&gt;</span>&nbsp;
&nbsp;<span class="js__sl_comment">///&nbsp;An&nbsp;Sdk.Entity</span>&nbsp;
&nbsp;<span class="js__sl_comment">///&lt;/param&gt;</span>&nbsp;
&nbsp;<span class="js__sl_comment">///&lt;param&nbsp;name=&quot;columns&quot;&nbsp;type=&quot;Object&quot;&nbsp;optional='false'&gt;</span>&nbsp;
&nbsp;<span class="js__sl_comment">///&nbsp;A&nbsp;dictionary&nbsp;object&nbsp;containing&nbsp;the&nbsp;names&nbsp;of&nbsp;each&nbsp;attribute</span>&nbsp;
&nbsp;<span class="js__sl_comment">///&nbsp;and&nbsp;the&nbsp;type.</span>&nbsp;
&nbsp;<span class="js__sl_comment">///&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(<span class="js__statement">var</span>&nbsp;i&nbsp;<span class="js__operator">in</span>&nbsp;columns)&nbsp;
&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;entity.addAttribute(<span class="js__operator">new</span>&nbsp;columns[i](i));&nbsp;
&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>&nbsp;</pre>
</div>
</div>
</div>
<p>Without entity class files to provide IntelliSense, you need to define the type of attribute when you add it to the
<strong>Sdk.Entity</strong>. This function, combined with a dictionary of attributes and types allows you to use the simpler
<strong>setValue</strong> method for the attributes that are already added.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//This&nbsp;dictionary&nbsp;of&nbsp;columns&nbsp;is&nbsp;used&nbsp;by&nbsp;</span>&nbsp;
&nbsp;<span class="js__sl_comment">//&nbsp;the&nbsp;initializeEntity&nbsp;and&nbsp;getColumnSet&nbsp;functions</span>&nbsp;
&nbsp;<span class="js__sl_comment">//&nbsp;with&nbsp;the&nbsp;&ldquo;late-binding&rdquo;&nbsp;style.</span>&nbsp;
&nbsp;<span class="js__statement">var</span>&nbsp;accountColumns&nbsp;=&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;accountcategorycode&quot;</span>:&nbsp;Sdk.OptionSet,&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;accountid&quot;</span>:&nbsp;Sdk.Guid,&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;accountnumber&quot;</span>:&nbsp;Sdk.<span class="js__object">String</span>,&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;address1_addressid&quot;</span>:&nbsp;Sdk.Guid,&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;address1_city&quot;</span>:&nbsp;Sdk.<span class="js__object">String</span>,&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;address1_latitude&quot;</span>:&nbsp;Sdk.Double,&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;address1_longitude&quot;</span>:&nbsp;Sdk.Double,&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;createdby&quot;</span>:&nbsp;Sdk.Lookup,&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;createdon&quot;</span>:&nbsp;Sdk.DateTime,&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;creditlimit&quot;</span>:&nbsp;Sdk.Money,&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;creditonhold&quot;</span>:&nbsp;Sdk.<span class="js__object">Boolean</span>,&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;description&quot;</span>:&nbsp;Sdk.<span class="js__object">String</span>,&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;donotbulkemail&quot;</span>:&nbsp;Sdk.<span class="js__object">Boolean</span>,&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;exchangerate&quot;</span>:&nbsp;Sdk.Decimal,&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;industrycode&quot;</span>:&nbsp;Sdk.OptionSet,&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;name&quot;</span>:&nbsp;Sdk.<span class="js__object">String</span>,&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;numberofemployees&quot;</span>:&nbsp;Sdk.Int,&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;ownerid&quot;</span>:&nbsp;Sdk.Lookup,&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;owninguser&quot;</span>:&nbsp;Sdk.Lookup,&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;revenue&quot;</span>:&nbsp;Sdk.Money,&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;sharesoutstanding&quot;</span>:&nbsp;Sdk.Int,&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;statecode&quot;</span>:&nbsp;Sdk.OptionSet,&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;statuscode&quot;</span>:&nbsp;Sdk.OptionSet,&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;versionnumber&quot;</span>:&nbsp;Sdk.Long&nbsp;
&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;
&nbsp;<span class="js__statement">var</span>&nbsp;account&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Sdk.Entity(<span class="js__string">&quot;account&quot;</span>);&nbsp;
&nbsp;<span class="js__sl_comment">//When&nbsp;using&nbsp;&ldquo;late-binding,&rdquo;&nbsp;a&nbsp;helper&nbsp;function&nbsp;like&nbsp;initializeEntity&nbsp;helps&nbsp;simplify&nbsp;syntax&nbsp;to&nbsp;set&nbsp;values.</span>&nbsp;
&nbsp;<span class="js__sl_comment">//You&rsquo;ll&nbsp;want&nbsp;to&nbsp;use&nbsp;this&nbsp;every&nbsp;time&nbsp;you&nbsp;retrieve&nbsp;a&nbsp;record,&nbsp;too.</span>&nbsp;
&nbsp;initializeEntity(account,&nbsp;accountColumns);&nbsp;
&nbsp;account.setValue(<span class="js__string">&quot;name&quot;</span>,&nbsp;<span class="js__string">&quot;Sample&nbsp;Account&nbsp;001&quot;</span>);&nbsp;
&nbsp;account.setValue(<span class="js__string">&quot;creditonhold&quot;</span>,&nbsp;false);&nbsp;
&nbsp;account.setValue(<span class="js__string">&quot;address1_latitude&quot;</span>,&nbsp;<span class="js__num">47.638197</span>);&nbsp;
&nbsp;account.setValue(<span class="js__string">&quot;address1_longitude&quot;</span>,&nbsp;-<span class="js__num">122.131378</span>);&nbsp;
&nbsp;account.setValue(<span class="js__string">&quot;numberofemployees&quot;</span>,&nbsp;<span class="js__num">100000</span>);&nbsp;
&nbsp;account.setValue(<span class="js__string">&quot;description&quot;</span>,&nbsp;<span class="js__string">&quot;This&nbsp;is&nbsp;a&nbsp;description.&quot;</span>);&nbsp;
&nbsp;account.setValue(<span class="js__string">&quot;creditlimit&quot;</span>,&nbsp;<span class="js__num">2000000.00</span>);&nbsp;
&nbsp;account.setValue(<span class="js__string">&quot;accountcategorycode&quot;</span>,&nbsp;<span class="js__num">1</span>);&nbsp;<span class="js__sl_comment">//Preferred&nbsp;Customer</span>&nbsp;
&nbsp;
&nbsp;<span class="js__sl_comment">//Without&nbsp;initializeEntity:</span>&nbsp;
&nbsp;account.addAttribute(<span class="js__operator">new</span>&nbsp;Sdk.<span class="js__object">String</span>(<span class="js__string">&quot;name&quot;</span>,&nbsp;name));&nbsp;
&nbsp;account.addAttribute(<span class="js__operator">new</span>&nbsp;Sdk.<span class="js__object">Boolean</span>(<span class="js__string">&quot;creditonhold&quot;</span>,&nbsp;false));&nbsp;
&nbsp;account.addAttribute(<span class="js__operator">new</span>&nbsp;Sdk.Double(<span class="js__string">&quot;address1_latitude&quot;</span>,&nbsp;<span class="js__num">47.638197</span>));&nbsp;
&nbsp;account.addAttribute(<span class="js__operator">new</span>&nbsp;Sdk.Double(<span class="js__string">&quot;address1_longitude&quot;</span>,&nbsp;-<span class="js__num">122.131378</span>));&nbsp;
&nbsp;account.addAttribute(<span class="js__operator">new</span>&nbsp;Sdk.Int(<span class="js__string">&quot;numberofemployees&quot;</span>,&nbsp;<span class="js__num">100000</span>));&nbsp;
&nbsp;account.addAttribute(<span class="js__operator">new</span>&nbsp;Sdk.<span class="js__object">String</span>(<span class="js__string">&quot;description&quot;</span>,&nbsp;<span class="js__string">&quot;This&nbsp;is&nbsp;a&nbsp;description.&quot;</span>));&nbsp;
&nbsp;account.addAttribute(<span class="js__operator">new</span>&nbsp;Sdk.Money(<span class="js__string">&quot;creditlimit&quot;</span>,&nbsp;<span class="js__num">2000000</span>));&nbsp;
&nbsp;account.addAttribute(<span class="js__operator">new</span>&nbsp;Sdk.OptionSet(<span class="js__string">&quot;accountcategorycode&quot;</span>,&nbsp;<span class="js__num">1</span>));&nbsp;<span class="js__sl_comment">//Preferred&nbsp;Customer</span>&nbsp;</pre>
</div>
</div>
</div>
<p><strong>Sdk.Entity.addAttribute</strong> must be used if the attribute hasn&rsquo;t previously been added to the entity. The
<strong>addAttribute</strong> method requires that the first parameter be one of the classes that inherit from
<strong>Sdk.AttributeBase</strong> and each of these classes require a string representing the attribute name as the first constructor parameter. The second constructor parameter to set the value is optional.</p>
<p>You can use <strong>addAttribute</strong> on an entity that already has the attribute added. If the attribute you add doesn&rsquo;t have a value set, the value of the attribute already in the entity won&rsquo;t be overwritten.</p>
<h2 id="getColumnSet">getColumnSet function</h2>
<p>This function uses the same dictionary of entity columns used by the <a href="#initializeEntity">
initializeEntity function</a> to generate an Sdk.ColumnSet object needed for queries.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__operator">function</span>&nbsp;getColumnSet(entityColumns)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;<span class="js__sl_comment">///&lt;summary&gt;</span>&nbsp;
&nbsp;<span class="js__sl_comment">///&nbsp;Initializes&nbsp;an&nbsp;Sdk.ColumnSet</span>&nbsp;
&nbsp;<span class="js__sl_comment">///&nbsp;dictionary&nbsp;object.</span>&nbsp;
&nbsp;<span class="js__sl_comment">///&lt;/summary&gt;</span>&nbsp;
&nbsp;<span class="js__sl_comment">///&lt;param&nbsp;name=&quot;entityColumns&quot;&nbsp;type=&quot;Object&quot;&nbsp;optional='false'&gt;</span>&nbsp;
&nbsp;<span class="js__sl_comment">///&nbsp;A&nbsp;dictionary&nbsp;object&nbsp;containing&nbsp;the&nbsp;names&nbsp;of&nbsp;each&nbsp;attribute</span>&nbsp;
&nbsp;<span class="js__sl_comment">///&nbsp;and&nbsp;the&nbsp;type.</span>&nbsp;
&nbsp;<span class="js__sl_comment">///&lt;/param&gt;</span>&nbsp;
&nbsp;<span class="js__statement">var</span>&nbsp;attributeNames&nbsp;=&nbsp;[];&nbsp;
&nbsp;<span class="js__statement">for</span>&nbsp;(<span class="js__statement">var</span>&nbsp;i&nbsp;<span class="js__operator">in</span>&nbsp;entityColumns)&nbsp;
&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;attributeNames.push(i);&nbsp;
&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;<span class="js__sl_comment">//Sdk.ColumnSet&nbsp;accepts&nbsp;an&nbsp;array&nbsp;of&nbsp;strings&nbsp;as&nbsp;the&nbsp;parameter.</span>&nbsp;
&nbsp;<span class="js__statement">return</span>&nbsp;<span class="js__operator">new</span>&nbsp;Sdk.ColumnSet(attributeNames);&nbsp;
<span class="js__brace">}</span>&nbsp;</pre>
</div>
</div>
</div>
<p>Together, <strong>initializeEntity</strong> and <strong>getColumnSet</strong> can be used to define a limited set of attributes to use for an entity when using the late-binding style.</p>
<h2 id="showEntityAttributeValues">showEntityAttributeValues function</h2>
<p>This function uses the <a href="#writetopage">writeToPage</a> function to render a table showing the values of a record in the sample. This function shows how to access formatted values in an entity using the
<strong>entity.getFormattedValues </strong>method.</p>
<h3>C# Equivalent Code:</h3>
<p>The following code is the C# equivalent.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ShowEntityAttributeValues(Entity&nbsp;entity)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;====================================&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(var&nbsp;a&nbsp;<span class="cs__keyword">in</span>&nbsp;entity.Attributes)&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;String&nbsp;name&nbsp;=&nbsp;a.Key;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Object&nbsp;<span class="cs__keyword">value</span>&nbsp;=&nbsp;a.Value;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;String&nbsp;formattedValue&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Boolean&nbsp;IsFormattedValue&nbsp;=&nbsp;entity.FormattedValues.TryGetValue(name,&nbsp;<span class="cs__keyword">out</span>&nbsp;formattedValue);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">value</span>&nbsp;<span class="cs__keyword">is</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/Microsoft.Xrm.Sdk.EntityReference.aspx" target="_blank" title="Auto generated link to Microsoft.Xrm.Sdk.EntityReference">Microsoft.Xrm.Sdk.EntityReference</a>)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">value</span>&nbsp;=&nbsp;((EntityReference)<span class="cs__keyword">value</span>).Name;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;{0}&nbsp;:&nbsp;{1}&quot;</span>,&nbsp;name,&nbsp;(IsFormattedValue)?&nbsp;formattedValue&nbsp;:&nbsp;(<span class="cs__keyword">value</span>&nbsp;==&nbsp;<span class="cs__keyword">null</span>)?&nbsp;<span class="cs__string">&quot;null&quot;</span>:&nbsp;<span class="cs__keyword">value</span>);&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;====================================&quot;</span>);&nbsp;
&nbsp;&nbsp;}&nbsp;</pre>
</div>
</div>
</div>
<h2 id="errorhandler">ErrorHandler class</h2>
<p>When defining an error handler for asynchronous requests you must set a function to the
<strong>errorCallback</strong> parameter exposed for each operation. This function represents a simple class that stores a context string that will be prepended to the error message returned from the platform.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__operator">function</span>&nbsp;ErrorHandler(errorContext)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;<span class="js__sl_comment">///&lt;summary&gt;</span>&nbsp;
&nbsp;<span class="js__sl_comment">///&nbsp;A&nbsp;class&nbsp;that&nbsp;stores&nbsp;an&nbsp;error&nbsp;context&nbsp;string&nbsp;and&nbsp;provides&nbsp;a&nbsp;function&nbsp;</span>&nbsp;
&nbsp;<span class="js__sl_comment">///&nbsp;to&nbsp;call&nbsp;in&nbsp;an&nbsp;asynchronous&nbsp;event&nbsp;handler.</span>&nbsp;
&nbsp;<span class="js__sl_comment">///&lt;/summary&gt;</span>&nbsp;
&nbsp;<span class="js__sl_comment">///&lt;param&nbsp;name=&quot;errorContext&quot;&nbsp;type=&quot;String&quot;&nbsp;optional='false'&gt;</span>&nbsp;
&nbsp;<span class="js__sl_comment">///&nbsp;A&nbsp;string&nbsp;that&nbsp;provides&nbsp;some&nbsp;context&nbsp;for&nbsp;where&nbsp;the&nbsp;error&nbsp;occurred.</span>&nbsp;
&nbsp;<span class="js__sl_comment">///&lt;/param&gt;</span>&nbsp;
&nbsp;<span class="js__statement">var</span>&nbsp;_ec&nbsp;=&nbsp;errorContext;&nbsp;
&nbsp;<span class="js__operator">this</span>.getError&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;(error)&nbsp;
&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;writeToPage(_ec&nbsp;&#43;&nbsp;<span class="js__string">&quot;&nbsp;Error:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;error.message);&nbsp;
&nbsp;<span class="js__brace">}</span>;&nbsp;
<span class="js__brace">}</span>&nbsp;</pre>
</div>
</div>
</div>
<p>Be sure to use the new keyword when setting the <strong>errorCallback</strong> function, and don&rsquo;t actually call the function, as shown here.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">Sdk.Async.create(&nbsp;
&nbsp;account,&nbsp;
&nbsp;<span class="js__operator">function</span>&nbsp;(id)&nbsp;
&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;<span class="js__sl_comment">//successCallback</span>&nbsp;
&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;<span class="js__operator">new</span>&nbsp;ErrorHandler(<span class="js__string">&quot;create&nbsp;account&quot;</span>).getError);&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<p>If there is an error that occurs for this operation, the error message will include the description provided as the
<strong>errorContext</strong> parameter. This particular error handler uses the <a href="#writetopage">
writeToPage function</a> to make the error visible.</p>
<h2 id="jqerrorhandler">jQErrorHandler class</h2>
<p>When using the methods in the Sdk.jQ namespace, the <a href="#errorhandler">
ErrorHandler class</a> doesn&rsquo;t work as expected. The returned error doesn&rsquo;t stop the chain unless a jQuery.Deferred.promise is returned. In addition to using the
<a href="#writetopage">writeToPage function</a>, this error handler also returns a
<strong>jQuery.Deferred.promise</strong>. Otherwise, it is the same as the <strong>
ErrorHandler</strong> class.</p>
<h2 id="writetopage">writeToPage function</h2>
<p>This utility function simply appends a new list element or a DOM object (such as a table) to the sample page.</p>
</div>
<div>
<h1 id="asyncearly">AsyncEarlyBindingCRUD.js</h1>
<p>This sample uses the methods in the <strong>Sdk.Async </strong>namespace to perform the following actions in an early-bound style using the function
<strong>earlyBindingCRUDSample</strong>.</p>
<h2 id="csharpearlybinding">C# Equivalent Early Binding CRUD Code:</h2>
<p>The following code is the C# equivalent.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;earlyBindingCRUDSample()&nbsp;
&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//Capture&nbsp;the&nbsp;ID&nbsp;of&nbsp;created&nbsp;records&nbsp;to&nbsp;clean&nbsp;up&nbsp;afterwards&nbsp;by&nbsp;deleting&nbsp;them.</span>&nbsp;
&nbsp;&nbsp;&nbsp;Guid&nbsp;CreatedAccountId;&nbsp;
&nbsp;&nbsp;&nbsp;Guid&nbsp;CreatedOpportunityId;&nbsp;
&nbsp;&nbsp;&nbsp;Guid&nbsp;CreatedTaskId;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;Account&nbsp;account&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Account();&nbsp;
&nbsp;&nbsp;&nbsp;account.Name&nbsp;=&nbsp;<span class="cs__string">&quot;Sample&nbsp;Account&nbsp;001&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;account.CreditOnHold&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;account.Address1_Latitude&nbsp;=&nbsp;<span class="cs__number">47.638197</span>;&nbsp;
&nbsp;&nbsp;&nbsp;account.Address1_Longitude&nbsp;=&nbsp;-<span class="cs__number">122.131378</span>;&nbsp;
&nbsp;&nbsp;&nbsp;account.Description&nbsp;=&nbsp;<span class="cs__string">&quot;This&nbsp;is&nbsp;a&nbsp;description.&nbsp;\n&nbsp;It&nbsp;has&nbsp;several&nbsp;lines.&nbsp;\n&nbsp;This&nbsp;is&nbsp;the&nbsp;third&nbsp;line.&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;account.CreditLimit&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Money(<span class="cs__keyword">new</span>&nbsp;Decimal(<span class="cs__number">200000.00</span>));&nbsp;
&nbsp;&nbsp;&nbsp;account.AccountCategoryCode&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;OptionSetValue(<span class="cs__number">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//Create&nbsp;the&nbsp;account.</span>&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//Capture&nbsp;the&nbsp;ID&nbsp;of&nbsp;created&nbsp;records&nbsp;to&nbsp;clean&nbsp;up&nbsp;afterwards&nbsp;by&nbsp;deleting&nbsp;them.</span>&nbsp;
&nbsp;&nbsp;&nbsp;CreatedAccountId&nbsp;=&nbsp;_serviceProxy.Create(account);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//Define&nbsp;the&nbsp;account&nbsp;columns&nbsp;to&nbsp;work&nbsp;with&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;when&nbsp;retrieving&nbsp;columns&nbsp;for&nbsp;this&nbsp;sample.</span>&nbsp;
&nbsp;&nbsp;&nbsp;ColumnSet&nbsp;accountColumnSet&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ColumnSet(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">string</span>[]{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;accountcategorycode&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;accountid&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;accountnumber&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;address1_addressid&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;address1_city&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;address1_latitude&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;address1_longitude&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;createdby&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;createdon&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;creditlimit&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;creditonhold&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;description&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;donotbulkemail&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;exchangerate&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;industrycode&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;name&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;numberofemployees&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;ownerid&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;owninguser&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;revenue&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;sharesoutstanding&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;statecode&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;statuscode&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;versionnumber&quot;</span>}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//Retrieve&nbsp;the&nbsp;created&nbsp;account.</span>&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//Retrieve&nbsp;returns&nbsp;an&nbsp;Entity&nbsp;object&nbsp;so&nbsp;you&nbsp;have&nbsp;to&nbsp;cast&nbsp;it&nbsp;into&nbsp;an&nbsp;Account.</span>&nbsp;
&nbsp;&nbsp;&nbsp;account&nbsp;=&nbsp;(Account)_serviceProxy.Retrieve(<span class="cs__string">&quot;account&quot;</span>,&nbsp;CreatedAccountId,&nbsp;accountColumnSet);&nbsp;
&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Retrieved&nbsp;account&nbsp;named:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;account.Name);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;account.SharesOutstanding&nbsp;=&nbsp;<span class="cs__number">200</span>;&nbsp;
&nbsp;&nbsp;&nbsp;account.Revenue&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Money(<span class="cs__keyword">new</span>&nbsp;Decimal(<span class="cs__number">3000000.00</span>));&nbsp;
&nbsp;&nbsp;&nbsp;account.IndustryCode&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;OptionSetValue(<span class="cs__number">6</span>);&nbsp;<span class="cs__com">//Business&nbsp;Services</span>&nbsp;
&nbsp;&nbsp;&nbsp;account.AccountNumber&nbsp;=&nbsp;<span class="cs__string">&quot;ABC123&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;_serviceProxy.Update(account);&nbsp;
&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Updated&nbsp;account&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//Call&nbsp;retrieve&nbsp;again&nbsp;to&nbsp;refresh&nbsp;formatted&nbsp;values:</span>&nbsp;
&nbsp;&nbsp;&nbsp;account&nbsp;=&nbsp;(Account)_serviceProxy.Retrieve(<span class="cs__string">&quot;account&quot;</span>,&nbsp;account.Id,&nbsp;accountColumnSet);&nbsp;
&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Retrieved&nbsp;account&nbsp;after&nbsp;updating&nbsp;to&nbsp;get&nbsp;any&nbsp;new&nbsp;formatted&nbsp;values&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;These&nbsp;are&nbsp;the&nbsp;current&nbsp;values&nbsp;for&nbsp;the&nbsp;account:&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;ShowEntityAttributeValues(account);&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//Create&nbsp;Opportunity&nbsp;with&nbsp;Task:</span>&nbsp;
&nbsp;&nbsp;&nbsp;Opportunity&nbsp;opportunity&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Opportunity();&nbsp;
&nbsp;&nbsp;&nbsp;opportunity.Name&nbsp;=&nbsp;<span class="cs__string">&quot;Sample&nbsp;Opportunity&nbsp;001&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;opportunity.CustomerId&nbsp;=&nbsp;account.ToEntityReference();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;Task&nbsp;task&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Task();&nbsp;
&nbsp;&nbsp;&nbsp;task.Subject&nbsp;=&nbsp;<span class="cs__string">&quot;Sample&nbsp;Task&nbsp;001&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;DateTime&nbsp;dueDate&nbsp;=&nbsp;DateTime.Now;&nbsp;
&nbsp;&nbsp;&nbsp;dueDate&nbsp;=&nbsp;dueDate.AddDays(<span class="cs__number">10</span>);&nbsp;
&nbsp;&nbsp;&nbsp;task.ScheduledEnd&nbsp;=&nbsp;dueDate;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//Adding&nbsp;the&nbsp;task&nbsp;to&nbsp;the&nbsp;related&nbsp;Opportunity_Tasks&nbsp;before&nbsp;create</span>&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;will&nbsp;associate&nbsp;the&nbsp;task&nbsp;with&nbsp;the&nbsp;opportunity&nbsp;when&nbsp;they&nbsp;are&nbsp;both&nbsp;created.</span>&nbsp;
&nbsp;&nbsp;&nbsp;EntityCollection&nbsp;relatedTasks&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;EntityCollection();&nbsp;
&nbsp;&nbsp;&nbsp;relatedTasks.Entities.Add(task);&nbsp;
&nbsp;&nbsp;&nbsp;opportunity.RelatedEntities.Add(&nbsp;<span class="cs__keyword">new</span>&nbsp;Relationship(<span class="cs__string">&quot;Opportunity_Tasks&quot;</span>),&nbsp;relatedTasks);&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//Create&nbsp;the&nbsp;opportunity&nbsp;with&nbsp;related&nbsp;task:</span>&nbsp;
&nbsp;&nbsp;&nbsp;CreatedOpportunityId&nbsp;=&nbsp;_serviceProxy.Create(opportunity);&nbsp;<span class="cs__com">//cache&nbsp;for&nbsp;deletion&nbsp;later.</span>&nbsp;
&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Created&nbsp;new&nbsp;Opportunity&nbsp;with&nbsp;id:&quot;</span>&nbsp;&#43;&nbsp;CreatedOpportunityId);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Use&nbsp;QueryByAttribute&nbsp;to&nbsp;retrieve&nbsp;tasks&nbsp;associated&nbsp;with&nbsp;the&nbsp;opportunity.</span>&nbsp;
&nbsp;&nbsp;&nbsp;QueryByAttribute&nbsp;retrieveTaskQuery&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;QueryByAttribute(<span class="cs__string">&quot;task&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;retrieveTaskQuery.ColumnSet&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ColumnSet(<span class="cs__keyword">new</span>&nbsp;String[]&nbsp;{&nbsp;<span class="cs__string">&quot;subject&quot;</span>,&nbsp;<span class="cs__string">&quot;scheduledend&quot;</span>,&nbsp;<span class="cs__string">&quot;regardingobjectid&quot;</span>&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;retrieveTaskQuery.AddAttributeValue(<span class="cs__string">&quot;regardingobjectid&quot;</span>,&nbsp;CreatedOpportunityId);&nbsp;
&nbsp;&nbsp;&nbsp;EntityCollection&nbsp;taskCollection&nbsp;=&nbsp;_serviceProxy.RetrieveMultiple(retrieveTaskQuery);&nbsp;
&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Retrieved&nbsp;&quot;</span>&nbsp;&#43;&nbsp;taskCollection.Entities.Count&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;task&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;These&nbsp;are&nbsp;the&nbsp;properties&nbsp;of&nbsp;the&nbsp;task&nbsp;retrieved:&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;task&nbsp;=&nbsp;(Task)taskCollection.Entities[<span class="cs__number">0</span>];&nbsp;
&nbsp;&nbsp;&nbsp;CreatedTaskId&nbsp;=&nbsp;task.Id;&nbsp;<span class="cs__com">//cache&nbsp;for&nbsp;deletion&nbsp;later</span>&nbsp;
&nbsp;&nbsp;&nbsp;ShowEntityAttributeValues(task);&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//Set&nbsp;the&nbsp;task&nbsp;as&nbsp;completed&nbsp;using&nbsp;SetStateRequest.</span>&nbsp;
&nbsp;&nbsp;&nbsp;SetStateRequest&nbsp;setStateRequest&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SetStateRequest()&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;EntityMoniker&nbsp;=&nbsp;task.ToEntityReference(),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;State&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;OptionSetValue(<span class="cs__number">1</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Status&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;OptionSetValue(<span class="cs__number">5</span>)&nbsp;
&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;_serviceProxy.Execute(setStateRequest);&nbsp;
&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Task&nbsp;set&nbsp;to&nbsp;Completed.&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//Delete&nbsp;created&nbsp;records:</span>&nbsp;
&nbsp;&nbsp;&nbsp;_serviceProxy.Delete(<span class="cs__string">&quot;task&quot;</span>,&nbsp;CreatedTaskId);&nbsp;
&nbsp;&nbsp;&nbsp;_serviceProxy.Delete(<span class="cs__string">&quot;opportunity&quot;</span>,&nbsp;CreatedOpportunityId);&nbsp;
&nbsp;&nbsp;&nbsp;_serviceProxy.Delete(<span class="cs__string">&quot;account&quot;</span>,&nbsp;CreatedAccountId);&nbsp;
&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Ending&nbsp;sample&nbsp;by&nbsp;deleting&nbsp;account.&quot;</span>);&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;}&nbsp;</pre>
</div>
</div>
</div>
</div>
<div>
<h1 id="asynclate">AsyncLateBindingCRUD.js</h1>
<p>This sample uses the methods in the <strong>Sdk.Async </strong>namespace to perform the following actions in a late-bound style using the function
<strong>lateBindingCRUDSample</strong>.</p>
<h2 id="csharplatebinding">C# Equivalent Late Binding CRUD Code:</h2>
<p>The following code is the C# equivalent.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;lateBindingCRUDSample()&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//Capture&nbsp;the&nbsp;ID&nbsp;of&nbsp;created&nbsp;records&nbsp;to&nbsp;clean&nbsp;up&nbsp;afterwards&nbsp;by&nbsp;deleting&nbsp;them.</span>&nbsp;
&nbsp;&nbsp;&nbsp;Guid&nbsp;CreatedAccountId;&nbsp;
&nbsp;&nbsp;&nbsp;Guid&nbsp;CreatedOpportunityId;&nbsp;
&nbsp;&nbsp;&nbsp;Guid&nbsp;CreatedTaskId;&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;Entity&nbsp;account&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Entity(<span class="cs__string">&quot;account&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;account[<span class="cs__string">&quot;name&quot;</span>]&nbsp;=&nbsp;<span class="cs__string">&quot;Sample&nbsp;Account&nbsp;001&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;account[<span class="cs__string">&quot;creditonhold&quot;</span>]&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;account[<span class="cs__string">&quot;address1_latitude&quot;</span>]&nbsp;=&nbsp;<span class="cs__number">47.638197</span>;&nbsp;
&nbsp;&nbsp;&nbsp;account[<span class="cs__string">&quot;address1_longitude&quot;</span>]&nbsp;=&nbsp;-<span class="cs__number">122.131378</span>;&nbsp;
&nbsp;&nbsp;&nbsp;account[<span class="cs__string">&quot;description&quot;</span>]&nbsp;=&nbsp;<span class="cs__string">&quot;This&nbsp;is&nbsp;a&nbsp;description.&nbsp;\n&nbsp;It&nbsp;has&nbsp;several&nbsp;lines.&nbsp;\n&nbsp;This&nbsp;is&nbsp;the&nbsp;third&nbsp;line.&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;account[<span class="cs__string">&quot;creditlimit&quot;</span>]&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Money(<span class="cs__keyword">new</span>&nbsp;Decimal(<span class="cs__number">200000.00</span>));&nbsp;
&nbsp;&nbsp;&nbsp;account[<span class="cs__string">&quot;accountcategorycode&quot;</span>]&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;OptionSetValue(<span class="cs__number">1</span>);&nbsp;<span class="cs__com">//Preferred&nbsp;Customer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//Create&nbsp;the&nbsp;account.</span>&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//Capture&nbsp;the&nbsp;ID&nbsp;of&nbsp;created&nbsp;records&nbsp;to&nbsp;clean&nbsp;up&nbsp;afterwards&nbsp;by&nbsp;deleting&nbsp;them.</span>&nbsp;
&nbsp;&nbsp;&nbsp;CreatedAccountId&nbsp;=&nbsp;_serviceProxy.Create(account);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//Define&nbsp;the&nbsp;account&nbsp;columns&nbsp;to&nbsp;work&nbsp;with&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;when&nbsp;retrieving&nbsp;columns&nbsp;for&nbsp;this&nbsp;sample.</span>&nbsp;
&nbsp;&nbsp;&nbsp;ColumnSet&nbsp;accountColumnSet&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ColumnSet(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">string</span>[]{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;accountcategorycode&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;accountid&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;accountnumber&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;address1_addressid&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;address1_city&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;address1_latitude&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;address1_longitude&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;createdby&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;createdon&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;creditlimit&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;creditonhold&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;description&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;donotbulkemail&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;exchangerate&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;industrycode&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;name&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;numberofemployees&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;ownerid&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;owninguser&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;revenue&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;sharesoutstanding&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;statecode&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;statuscode&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;versionnumber&quot;</span>}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//Retrieve&nbsp;the&nbsp;created&nbsp;account.</span>&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//Retrieve&nbsp;returns&nbsp;an&nbsp;Entity&nbsp;object&nbsp;so&nbsp;you&nbsp;have&nbsp;to&nbsp;cast&nbsp;it&nbsp;into&nbsp;an&nbsp;Account.</span>&nbsp;
&nbsp;&nbsp;&nbsp;account&nbsp;=&nbsp;_serviceProxy.Retrieve(<span class="cs__string">&quot;account&quot;</span>,&nbsp;CreatedAccountId,&nbsp;accountColumnSet);&nbsp;
&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Retrieved&nbsp;account&nbsp;named:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;account[<span class="cs__string">&quot;name&quot;</span>]);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;account[<span class="cs__string">&quot;sharesoutstanding&quot;</span>]&nbsp;=&nbsp;<span class="cs__number">200</span>;&nbsp;
&nbsp;&nbsp;&nbsp;account[<span class="cs__string">&quot;revenue&quot;</span>]&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Money(<span class="cs__keyword">new</span>&nbsp;Decimal(<span class="cs__number">3000000.00</span>));&nbsp;
&nbsp;&nbsp;&nbsp;account[<span class="cs__string">&quot;industrycode&quot;</span>]&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;OptionSetValue(<span class="cs__number">6</span>);&nbsp;<span class="cs__com">//Business&nbsp;Services</span>&nbsp;
&nbsp;&nbsp;&nbsp;account[<span class="cs__string">&quot;accountnumber&quot;</span>]&nbsp;=&nbsp;<span class="cs__string">&quot;ABC123&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;_serviceProxy.Update(account);&nbsp;
&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Updated&nbsp;account&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//Call&nbsp;retrieve&nbsp;again&nbsp;to&nbsp;refresh&nbsp;formatted&nbsp;values:</span>&nbsp;
&nbsp;&nbsp;&nbsp;account&nbsp;=&nbsp;_serviceProxy.Retrieve(<span class="cs__string">&quot;account&quot;</span>,&nbsp;account.Id,&nbsp;accountColumnSet);&nbsp;
&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Retrieved&nbsp;account&nbsp;after&nbsp;updating&nbsp;to&nbsp;get&nbsp;any&nbsp;new&nbsp;formatted&nbsp;values&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;These&nbsp;are&nbsp;the&nbsp;current&nbsp;values&nbsp;for&nbsp;the&nbsp;account:&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;ShowEntityAttributeValues(account);&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//Create&nbsp;Opportunity&nbsp;with&nbsp;Task:</span>&nbsp;
&nbsp;&nbsp;&nbsp;Entity&nbsp;opportunity&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Entity(<span class="cs__string">&quot;opportunity&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;opportunity[<span class="cs__string">&quot;name&quot;</span>]&nbsp;=&nbsp;<span class="cs__string">&quot;Sample&nbsp;Opportunity&nbsp;001&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;opportunity[<span class="cs__string">&quot;customerid&quot;</span>]&nbsp;=&nbsp;account.ToEntityReference();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;Entity&nbsp;task&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Entity(<span class="cs__string">&quot;task&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;task[<span class="cs__string">&quot;subject&quot;</span>]&nbsp;=&nbsp;<span class="cs__string">&quot;Sample&nbsp;Task&nbsp;001&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;DateTime&nbsp;dueDate&nbsp;=&nbsp;DateTime.Now;&nbsp;
&nbsp;&nbsp;&nbsp;dueDate&nbsp;=&nbsp;dueDate.AddDays(<span class="cs__number">10</span>);&nbsp;
&nbsp;&nbsp;&nbsp;task[<span class="cs__string">&quot;scheduledend&quot;</span>]&nbsp;=&nbsp;dueDate;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//Adding&nbsp;the&nbsp;task&nbsp;to&nbsp;the&nbsp;related&nbsp;Opportunity_Tasks&nbsp;before&nbsp;create</span>&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;will&nbsp;associate&nbsp;the&nbsp;task&nbsp;with&nbsp;the&nbsp;opportunity&nbsp;when&nbsp;they&nbsp;are&nbsp;both&nbsp;created.</span>&nbsp;
&nbsp;&nbsp;&nbsp;EntityCollection&nbsp;relatedTasks&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;EntityCollection();&nbsp;
&nbsp;&nbsp;&nbsp;relatedTasks.Entities.Add(task);&nbsp;
&nbsp;&nbsp;&nbsp;opportunity.RelatedEntities.Add(<span class="cs__keyword">new</span>&nbsp;Relationship(<span class="cs__string">&quot;Opportunity_Tasks&quot;</span>),&nbsp;relatedTasks);&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//Create&nbsp;the&nbsp;opportunity&nbsp;with&nbsp;related&nbsp;task:</span>&nbsp;
&nbsp;&nbsp;&nbsp;CreatedOpportunityId&nbsp;=&nbsp;_serviceProxy.Create(opportunity);&nbsp;<span class="cs__com">//cache&nbsp;for&nbsp;deletion&nbsp;later.</span>&nbsp;
&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Created&nbsp;new&nbsp;Opportunity&nbsp;with&nbsp;id:&quot;</span>&nbsp;&#43;&nbsp;CreatedOpportunityId);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Use&nbsp;QueryByAttribute&nbsp;to&nbsp;retrieve&nbsp;tasks&nbsp;associated&nbsp;with&nbsp;the&nbsp;opportunity.</span>&nbsp;
&nbsp;&nbsp;&nbsp;QueryByAttribute&nbsp;retrieveTaskQuery&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;QueryByAttribute(<span class="cs__string">&quot;task&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;retrieveTaskQuery.ColumnSet&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ColumnSet(<span class="cs__keyword">new</span>&nbsp;String[]&nbsp;{&nbsp;<span class="cs__string">&quot;subject&quot;</span>,&nbsp;<span class="cs__string">&quot;scheduledend&quot;</span>,&nbsp;<span class="cs__string">&quot;regardingobjectid&quot;</span>&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;retrieveTaskQuery.AddAttributeValue(<span class="cs__string">&quot;regardingobjectid&quot;</span>,&nbsp;CreatedOpportunityId);&nbsp;
&nbsp;&nbsp;&nbsp;EntityCollection&nbsp;taskCollection&nbsp;=&nbsp;_serviceProxy.RetrieveMultiple(retrieveTaskQuery);&nbsp;
&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Retrieved&nbsp;&quot;</span>&nbsp;&#43;&nbsp;taskCollection.Entities.Count&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;task&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;These&nbsp;are&nbsp;the&nbsp;properties&nbsp;of&nbsp;the&nbsp;task&nbsp;retrieved:&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;task&nbsp;=&nbsp;taskCollection.Entities[<span class="cs__number">0</span>];&nbsp;
&nbsp;&nbsp;&nbsp;CreatedTaskId&nbsp;=&nbsp;task.Id;&nbsp;<span class="cs__com">//cache&nbsp;for&nbsp;deletion&nbsp;later</span>&nbsp;
&nbsp;&nbsp;&nbsp;ShowEntityAttributeValues(task);&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//Set&nbsp;the&nbsp;task&nbsp;as&nbsp;completed&nbsp;using&nbsp;SetStateRequest.</span>&nbsp;
&nbsp;&nbsp;&nbsp;SetStateRequest&nbsp;setStateRequest&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SetStateRequest()&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;EntityMoniker&nbsp;=&nbsp;task.ToEntityReference(),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;State&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;OptionSetValue(<span class="cs__number">1</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Status&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;OptionSetValue(<span class="cs__number">5</span>)&nbsp;
&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;_serviceProxy.Execute(setStateRequest);&nbsp;
&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Task&nbsp;set&nbsp;to&nbsp;Completed.&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//Delete&nbsp;created&nbsp;records:</span>&nbsp;
&nbsp;&nbsp;&nbsp;_serviceProxy.Delete(<span class="cs__string">&quot;task&quot;</span>,&nbsp;CreatedTaskId);&nbsp;
&nbsp;&nbsp;&nbsp;_serviceProxy.Delete(<span class="cs__string">&quot;opportunity&quot;</span>,&nbsp;CreatedOpportunityId);&nbsp;
&nbsp;&nbsp;&nbsp;_serviceProxy.Delete(<span class="cs__string">&quot;account&quot;</span>,&nbsp;CreatedAccountId);&nbsp;
&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Ending&nbsp;sample&nbsp;by&nbsp;deleting&nbsp;account.&quot;</span>);&nbsp;
&nbsp;&nbsp;}&nbsp;</pre>
</div>
</div>
</div>
</div>
<div>
<h1 id="jquery">jQuerySample.js</h1>
<p>This sample contains two functions, <strong>earlyBindingCRUDSample</strong> and
<strong>lateBindingCRUDSample</strong>, which perform exactly the same operations describe in AsyncEarlyBindingCRUD.js and AsyncLateBindingCRUD.js respectively, except using the methods in the Sdk.jQ namespace. These methods use jQuery.Deferred objects, which
 are an implementation of promises. This enables a different style of using asynchronous requests.</p>
<p>Note: There are two important differences in this sample:</p>
<ol>
<li>This sample uses Sdk.jQ.setJQueryVariable($) to explicitly set $ as the jQuery variable.
</li><li>This sample uses the jQErrorHandler class rather than the ErrorHandler class due to the difference in behavior noted with jQuery.
</li></ol>
<p>For C# equivalent code, see:</p>
<ul>
<li><a href="#csharpearlybinding">C# Equivalent Early Binding CRUD Code</a> </li><li><a href="#csharplatebinding">C# Equivalent Late Binding CRUD Code</a> </li></ul>
</div>
<div>
<h1 id="q">QSample.js</h1>
<p>This sample contains two functions, earlyBindingCRUDSample and lateBindingCRUDSample, which perform exactly the same operations describe in
<a href="#asyncearly">AsyncEarlyBindingCRUD.js</a> and <a href="#asynclate">AsyncLateBindingCRUD.js</a> respectively, except using the methods in the
<strong>Sdk.Q</strong> namespace. These methods use the <a href="http://wiki.commonjs.org/wiki/Promises/A" target="_blank">
Promises/A</a> proposal for promises.</p>
<p><strong>Note</strong>: This project doesn&rsquo;t include the <a href="https://github.com/kriskowal/q">
Q.js library</a>. To run this sample, you need to create a JavaScript web resource named
<strong>sample_/SdkSoap/samples/q.min.js</strong> containing the content of that library.</p>
<p>For C# equivalent code, see:</p>
<ul>
<li><a href="#csharpearlybinding">C# Equivalent Early Binding CRUD Code</a> </li><li><a href="#csharplatebinding">C# Equivalent Late Binding CRUD Code</a> </li></ul>
</div>
<div>
<h1 id="metadata">RetrieveMetadataChangesSample.js</h1>
<p>This sample shows the use of the objects in the <strong>Sdk.Mdq</strong> namespace to construct a query using the
<strong>Sdk.RetrieveMetadataChangesRequest</strong> and <strong>Sdk.RetrieveMetadataChangesResponse
</strong>classes found in the <strong>Sdk.RetrieveMetadataChanges.js</strong> library.</p>
<p>The <strong>Sdk.RetrieveMetadataChanges.js </strong>library is one of two message files that contain the definitions of objects that are only used for that message. The other is
<strong>Sdk.Search.js</strong>.</p>
<p>The objects defined in this message library implement the objects found in the
<a href="http://msdn.microsoft.com/en-us/library/microsoft.xrm.sdk.metadata.query(v=crm.6).aspx" target="_blank">
<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/Microsoft.Xrm.Sdk.Metadata.Query.aspx" target="_blank" title="Auto generated link to Microsoft.Xrm.Sdk.Metadata.Query">Microsoft.Xrm.Sdk.Metadata.Query</a> Namespace</a> and documented in the CRM SDK topic
<a href="http://msdn.microsoft.com/en-us/library/jj863599(v=crm.6).aspx" target="_blank">
Retrieve and detect changes to metadata.</a> An earlier JavaScript implementation for this message with Microsoft Dynamics CRM 2011 was described in the technical article:
<a href="http://msdn.microsoft.com/en-us/library/jj919080.aspx" target="_blank">Query Metadata Using JavaScript</a>. While the implementation details are different (including the namespace used) the core use cases are the same.</p>
<p>Although this sample does not demonstrate it, this message also supports tracking changes to metadata so that only differences from a previous query are returned.</p>
<h2>C# Equivalent Retrieve Metadata Changes Code</h2>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;retrieveMetadataChangesSample()&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//Set&nbsp;entity&nbsp;filter&nbsp;to&nbsp;return&nbsp;only&nbsp;the&nbsp;account&nbsp;entity.</span>&nbsp;
&nbsp;&nbsp;&nbsp;MetadataFilterExpression&nbsp;entityFilter&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MetadataFilterExpression(LogicalOperator.And);&nbsp;
&nbsp;&nbsp;&nbsp;entityFilter.Conditions.Add(<span class="cs__keyword">new</span>&nbsp;MetadataConditionExpression(<span class="cs__string">&quot;SchemaName&quot;</span>,&nbsp;MetadataConditionOperator.Equals,&nbsp;<span class="cs__string">&quot;Account&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//Set&nbsp;entity&nbsp;properties&nbsp;to&nbsp;only&nbsp;return&nbsp;attributes&nbsp;and&nbsp;the&nbsp;PrimaryIdAttribute.</span>&nbsp;
&nbsp;&nbsp;&nbsp;MetadataPropertiesExpression&nbsp;entityProperties&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MetadataPropertiesExpression(<span class="cs__keyword">new</span>&nbsp;String[]&nbsp;{&nbsp;<span class="cs__string">&quot;Attributes&quot;</span>,&nbsp;<span class="cs__string">&quot;PrimaryIdAttribute&quot;</span>&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//Set&nbsp;attribute&nbsp;filter&nbsp;to&nbsp;not&nbsp;include&nbsp;virtual&nbsp;attributes.</span>&nbsp;
&nbsp;&nbsp;&nbsp;MetadataFilterExpression&nbsp;attributeFilter&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MetadataFilterExpression(LogicalOperator.And);&nbsp;
&nbsp;&nbsp;&nbsp;attributeFilter.Conditions.Add(<span class="cs__keyword">new</span>&nbsp;MetadataConditionExpression(<span class="cs__string">&quot;AttributeType&quot;</span>,&nbsp;MetadataConditionOperator.NotEquals,&nbsp;AttributeTypeCode.Virtual));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//Set&nbsp;attribute&nbsp;properties&nbsp;to&nbsp;only&nbsp;include&nbsp;the&nbsp;attribute&nbsp;type&nbsp;and&nbsp;schema&nbsp;name.</span>&nbsp;
&nbsp;&nbsp;&nbsp;MetadataPropertiesExpression&nbsp;attributeProperties&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MetadataPropertiesExpression(<span class="cs__keyword">new</span>&nbsp;String[]{<span class="cs__string">&quot;AttributeType&quot;</span>,<span class="cs__string">&quot;SchemaName&quot;</span>});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//Instantiate&nbsp;the&nbsp;entity&nbsp;query.</span>&nbsp;
&nbsp;&nbsp;&nbsp;EntityQueryExpression&nbsp;query&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;EntityQueryExpression(){&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Criteria&nbsp;=&nbsp;entityFilter,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Properties&nbsp;=&nbsp;entityProperties,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AttributeQuery&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;AttributeQueryExpression(){&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Criteria&nbsp;=&nbsp;attributeFilter,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Properties&nbsp;=&nbsp;attributeProperties&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//Execute&nbsp;the&nbsp;request.</span>&nbsp;
&nbsp;&nbsp;&nbsp;RetrieveMetadataChangesResponse&nbsp;response&nbsp;=&nbsp;(RetrieveMetadataChangesResponse)_serviceProxy.Execute(<span class="cs__keyword">new</span>&nbsp;RetrieveMetadataChangesRequest(){&nbsp;Query&nbsp;=&nbsp;query});&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;List&lt;AttributeMetadata&gt;&nbsp;attributeList&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;AttributeMetadata&gt;();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(AttributeMetadata&nbsp;att&nbsp;<span class="cs__keyword">in</span>&nbsp;response.EntityMetadata[<span class="cs__number">0</span>].Attributes)&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;attributeList.Add(att);&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//Sort&nbsp;the&nbsp;attributes.</span>&nbsp;
&nbsp;&nbsp;&nbsp;attributeList.Sort((x,&nbsp;y)&nbsp;=&gt;&nbsp;String.Compare(x.SchemaName,&nbsp;y.SchemaName));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//Display&nbsp;the&nbsp;attributes.</span>&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(AttributeMetadata&nbsp;att&nbsp;<span class="cs__keyword">in</span>&nbsp;attributeList)&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;{0}&nbsp;:&nbsp;{1}&quot;</span>,&nbsp;att.SchemaName,att.AttributeType);&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;}&nbsp;</pre>
</div>
</div>
</div>
<div>
<h1 id="fetch">Sdk.Query.FetchExpressionSample.js</h1>
<p>The <strong>fetchExpressionSample</strong> function in this sample performs the following actions:</p>
<ol>
<li>Creates an account with three related tasks </li><li>Uses <strong>Sdk.Query.FetchExpression</strong> with <strong>Sdk.jQ.retrieveMultiple</strong> to retrieve the account and related tasks
</li><li>Uses <strong>Sdk.Query.FetchExpression </strong>to include a related entities query to also return related tasks as part of an
<strong>Sdk.RetrieveRequest</strong> that retrieves the account. </li></ol>
<h2>C# Equivalent Code:</h2>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;fetchExpressionSample()&nbsp;
&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;Guid&nbsp;CreatedAccountId;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//Create&nbsp;an&nbsp;account&nbsp;with&nbsp;three&nbsp;associated&nbsp;tasks&nbsp;in&nbsp;the&nbsp;late-bound&nbsp;style.</span>&nbsp;
&nbsp;&nbsp;&nbsp;Entity&nbsp;account&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Entity(<span class="cs__string">&quot;account&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;account[<span class="cs__string">&quot;name&quot;</span>]&nbsp;=&nbsp;<span class="cs__string">&quot;Sample&nbsp;Account&nbsp;001&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;account[<span class="cs__string">&quot;creditonhold&quot;</span>]&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;account[<span class="cs__string">&quot;address1_latitude&quot;</span>]&nbsp;=&nbsp;<span class="cs__number">47.638197</span>;&nbsp;
&nbsp;&nbsp;&nbsp;account[<span class="cs__string">&quot;address1_longitude&quot;</span>]&nbsp;=&nbsp;-<span class="cs__number">122.131378</span>;&nbsp;
&nbsp;&nbsp;&nbsp;account[<span class="cs__string">&quot;description&quot;</span>]&nbsp;=&nbsp;<span class="cs__string">&quot;This&nbsp;is&nbsp;a&nbsp;description.&nbsp;\n&nbsp;It&nbsp;has&nbsp;several&nbsp;lines.&nbsp;\n&nbsp;This&nbsp;is&nbsp;the&nbsp;third&nbsp;line.&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;account[<span class="cs__string">&quot;creditlimit&quot;</span>]&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Money(<span class="cs__keyword">new</span>&nbsp;Decimal(<span class="cs__number">200000.00</span>));&nbsp;
&nbsp;&nbsp;&nbsp;account[<span class="cs__string">&quot;accountcategorycode&quot;</span>]&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;OptionSetValue(<span class="cs__number">1</span>);&nbsp;<span class="cs__com">//Preferred&nbsp;Customer</span>&nbsp;
&nbsp;&nbsp;&nbsp;account[<span class="cs__string">&quot;sharesoutstanding&quot;</span>]&nbsp;=&nbsp;<span class="cs__number">200</span>;&nbsp;
&nbsp;&nbsp;&nbsp;account[<span class="cs__string">&quot;revenue&quot;</span>]&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Money(<span class="cs__keyword">new</span>&nbsp;Decimal(<span class="cs__number">3000000.00</span>));&nbsp;
&nbsp;&nbsp;&nbsp;account[<span class="cs__string">&quot;industrycode&quot;</span>]&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;OptionSetValue(<span class="cs__number">6</span>);&nbsp;<span class="cs__com">//Business&nbsp;Services</span>&nbsp;
&nbsp;&nbsp;&nbsp;account[<span class="cs__string">&quot;accountnumber&quot;</span>]&nbsp;=&nbsp;<span class="cs__string">&quot;ABC123&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;account[<span class="cs__string">&quot;address1_city&quot;</span>]&nbsp;=&nbsp;<span class="cs__string">&quot;Redmond&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;EntityCollection&nbsp;relatedTasks&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;EntityCollection();&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;Entity&nbsp;task1&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Entity(<span class="cs__string">&quot;task&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;task1[<span class="cs__string">&quot;subject&quot;</span>]&nbsp;=&nbsp;<span class="cs__string">&quot;Task&nbsp;1&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;task1[<span class="cs__string">&quot;prioritycode&quot;</span>]&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;OptionSetValue(<span class="cs__number">0</span>);&nbsp;<span class="cs__com">//Low</span>&nbsp;
&nbsp;&nbsp;&nbsp;relatedTasks.Entities.Add(task1);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;Entity&nbsp;task2&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Entity(<span class="cs__string">&quot;task&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;task2[<span class="cs__string">&quot;subject&quot;</span>]&nbsp;=&nbsp;<span class="cs__string">&quot;Task&nbsp;2&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;task2[<span class="cs__string">&quot;prioritycode&quot;</span>]&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;OptionSetValue(<span class="cs__number">1</span>);&nbsp;<span class="cs__com">//Normal</span>&nbsp;
&nbsp;&nbsp;&nbsp;relatedTasks.Entities.Add(task2);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;Entity&nbsp;task3&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Entity(<span class="cs__string">&quot;task&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;task3[<span class="cs__string">&quot;subject&quot;</span>]&nbsp;=&nbsp;<span class="cs__string">&quot;Task&nbsp;3&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;task3[<span class="cs__string">&quot;prioritycode&quot;</span>]&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;OptionSetValue(<span class="cs__number">2</span>);&nbsp;<span class="cs__com">//High</span>&nbsp;
&nbsp;&nbsp;&nbsp;relatedTasks.Entities.Add(task3);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;account.RelatedEntities.Add(<span class="cs__keyword">new</span>&nbsp;Relationship(<span class="cs__string">&quot;Account_Tasks&quot;</span>),&nbsp;relatedTasks);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;CreatedAccountId&nbsp;=&nbsp;_serviceProxy.Create(account);&nbsp;
&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Created&nbsp;account&nbsp;with&nbsp;id:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;CreatedAccountId&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;and&nbsp;three&nbsp;associated&nbsp;tasks.&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//Compose&nbsp;the&nbsp;FetchXML&nbsp;to&nbsp;return&nbsp;task&nbsp;data&nbsp;linked&nbsp;from&nbsp;the&nbsp;account</span>&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;based&nbsp;on&nbsp;the&nbsp;task&nbsp;regardingobjectid&nbsp;value&nbsp;linking&nbsp;to&nbsp;the&nbsp;accountid.</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;String&nbsp;taskFetchXml&nbsp;=&nbsp;@&quot;&lt;fetch&nbsp;version=<span class="cs__string">'1.0'</span>&nbsp;output-format=<span class="cs__string">'xml-platform'</span>&nbsp;mapping=<span class="cs__string">'logical'</span>&nbsp;distinct=<span class="cs__string">'false'</span>&gt;&nbsp;
&nbsp;&nbsp;&lt;entity&nbsp;name=<span class="cs__string">'task'</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;attribute&nbsp;name=<span class="cs__string">'subject'</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;attribute&nbsp;name=<span class="cs__string">'prioritycode'</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;attribute&nbsp;name=<span class="cs__string">'activityid'</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;attribute&nbsp;name=<span class="cs__string">'createdon'</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;filter&nbsp;type=<span class="cs__string">'and'</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;condition&nbsp;attribute=<span class="cs__string">'regardingobjectid'</span>&nbsp;<span class="cs__keyword">operator</span>=<span class="cs__string">'eq'</span>&nbsp;uitype=<span class="cs__string">'account'</span>&nbsp;<span class="cs__keyword">value</span>=<span class="cs__string">'{&quot;&nbsp;&#43;&nbsp;CreatedAccountId&nbsp;&#43;&nbsp;@&quot;}'</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/filter&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;link-entity&nbsp;name=<span class="cs__string">'account'</span>&nbsp;from=<span class="cs__string">'accountid'</span>&nbsp;to=<span class="cs__string">'regardingobjectid'</span>&nbsp;visible=<span class="cs__string">'false'</span>&nbsp;link-type=<span class="cs__string">'outer'</span>&nbsp;alias=<span class="cs__string">'acct'</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;attribute&nbsp;name=<span class="cs__string">'name'</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;attribute&nbsp;name=<span class="cs__string">'createdon'</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;attribute&nbsp;name=<span class="cs__string">'accountcategorycode'</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/link-entity&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&lt;/entity&gt;&nbsp;
&nbsp;&lt;/fetch&gt;&quot;;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Use&nbsp;a&nbsp;FetchExpression&nbsp;with&nbsp;RetrieveMultiple&nbsp;to&nbsp;return&nbsp;the&nbsp;three&nbsp;tasks.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;FetchExpression&nbsp;taskQuery&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;FetchExpression(taskFetchXml);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;EntityCollection&nbsp;taskCollection&nbsp;=&nbsp;_serviceProxy.RetrieveMultiple(taskQuery);&nbsp;
&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;These&nbsp;are&nbsp;the&nbsp;tasks&nbsp;retrieved&nbsp;using&nbsp;RetrieveMultiple&nbsp;with&nbsp;a&nbsp;FetchExpression:&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//Use&nbsp;ShowEntityCollectionValues1&nbsp;to&nbsp;display&nbsp;the&nbsp;results&nbsp;of&nbsp;the&nbsp;EntityCollection&nbsp;returned.</span>&nbsp;
&nbsp;&nbsp;&nbsp;ShowEntityCollectionValues1(taskCollection);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//Retrieve&nbsp;related&nbsp;records&nbsp;with&nbsp;RetrieveRequest.</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;String&nbsp;relatedTasksFetchXml&nbsp;=&nbsp;@&quot;&lt;fetch&nbsp;version=<span class="cs__string">'1.0'</span>&nbsp;output-format=<span class="cs__string">'xml-platform'</span>&nbsp;mapping=<span class="cs__string">'logical'</span>&nbsp;distinct=<span class="cs__string">'false'</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;entity&nbsp;name=<span class="cs__string">'task'</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;attribute&nbsp;name=<span class="cs__string">'subject'</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;attribute&nbsp;name=<span class="cs__string">'prioritycode'</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;attribute&nbsp;name=<span class="cs__string">'activityid'</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;attribute&nbsp;name=<span class="cs__string">'createdon'</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/entity&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/fetch&gt;&quot;;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Instantiate&nbsp;a&nbsp;FetchExpression&nbsp;with&nbsp;FetchXml&nbsp;that&nbsp;defines&nbsp;attributes&nbsp;for&nbsp;the&nbsp;task&nbsp;entity.</span>&nbsp;
&nbsp;&nbsp;&nbsp;FetchExpression&nbsp;relatedTasksQuery&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;FetchExpression(relatedTasksFetchXml);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//Instantiates&nbsp;a&nbsp;RelationshipQueryCollection&nbsp;for&nbsp;the&nbsp;Account_Tasks&nbsp;relationship&nbsp;and&nbsp;the&nbsp;FetchExpression.</span>&nbsp;
&nbsp;&nbsp;&nbsp;KeyValuePair&lt;Relationship,&nbsp;QueryBase&gt;&nbsp;rtq&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;KeyValuePair&lt;Relationship,&nbsp;QueryBase&gt;(<span class="cs__keyword">new</span>&nbsp;Relationship(<span class="cs__string">&quot;Account_Tasks&quot;</span>),&nbsp;relatedTasksQuery);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;RelationshipQueryCollection&nbsp;rqc&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;RelationshipQueryCollection();&nbsp;
&nbsp;&nbsp;&nbsp;rqc.Add(rtq);&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;&nbsp;&nbsp;&nbsp;Instantiates&nbsp;a&nbsp;new&nbsp;RetrieveRequest&nbsp;with&nbsp;a&nbsp;reference&nbsp;to&nbsp;the&nbsp;created&nbsp;account&nbsp;as&nbsp;the&nbsp;target&nbsp;parameter,&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;a&nbsp;ColumnSet&nbsp;specifying&nbsp;that&nbsp;the&nbsp;name&nbsp;of&nbsp;the&nbsp;account&nbsp;should&nbsp;be&nbsp;returned&nbsp;as&nbsp;the&nbsp;columnSet&nbsp;parameter,&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;and&nbsp;the&nbsp;RelationshipQueryCollection&nbsp;as&nbsp;the&nbsp;RelatedEntitiesQuery&nbsp;parameter.</span>&nbsp;
&nbsp;&nbsp;&nbsp;RetrieveRequest&nbsp;req&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;RetrieveRequest()&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Target&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;EntityReference(<span class="cs__string">&quot;account&quot;</span>,&nbsp;CreatedAccountId),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ColumnSet&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ColumnSet(<span class="cs__string">&quot;name&quot;</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;RelatedEntitiesQuery&nbsp;=&nbsp;rqc&nbsp;
&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//Retrieve&nbsp;the&nbsp;account</span>&nbsp;
&nbsp;&nbsp;&nbsp;RetrieveResponse&nbsp;resp&nbsp;=&nbsp;(RetrieveResponse)_serviceProxy.Execute(req);&nbsp;
&nbsp;&nbsp;&nbsp;Entity&nbsp;RetrievedAccount&nbsp;=&nbsp;resp.Entity;&nbsp;
&nbsp;&nbsp;&nbsp;EntityCollection&nbsp;RetrievedTaskCollection;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//The&nbsp;tasks&nbsp;returned&nbsp;with&nbsp;the&nbsp;account&nbsp;retrieved&nbsp;are&nbsp;set&nbsp;to&nbsp;the&nbsp;RetrievedTaskCollection&nbsp;using:&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;RetrievedAccount.RelatedEntities.TryGetValue(<span class="cs__keyword">new</span>&nbsp;Relationship(<span class="cs__string">&quot;Account_Tasks&quot;</span>),&nbsp;<span class="cs__keyword">out</span>&nbsp;RetrievedTaskCollection);&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//Use&nbsp;ShowEntityCollectionValues2&nbsp;to&nbsp;display&nbsp;the&nbsp;values&nbsp;returned.</span>&nbsp;
&nbsp;&nbsp;&nbsp;ShowEntityCollectionValues2(RetrievedTaskCollection);&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//Deletes&nbsp;the&nbsp;account&nbsp;created&nbsp;and&nbsp;therefore&nbsp;also&nbsp;the&nbsp;related&nbsp;tasks.</span>&nbsp;
&nbsp;&nbsp;&nbsp;_serviceProxy.Delete(<span class="cs__string">&quot;account&quot;</span>,&nbsp;CreatedAccountId);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ShowEntityCollectionValues1(EntityCollection&nbsp;ec)&nbsp;
&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//For&nbsp;best&nbsp;results&nbsp;set&nbsp;the&nbsp;width&nbsp;of&nbsp;your&nbsp;Console&nbsp;window&nbsp;to&nbsp;150&nbsp;or&nbsp;higher.</span>&nbsp;
&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;====================================&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;String&nbsp;formatString&nbsp;=&nbsp;<span class="cs__string">&quot;{0,-8}{1,-13}{2,-37}{3,-20}{4,-17}{5,-20}{6,-20}&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;Console.WriteLine(formatString,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;subject&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;prioritycode&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;activityid&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;createdon&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;acct.name&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;acct.createdon&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;acct.accountcategorycode&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(Entity&nbsp;e&nbsp;<span class="cs__keyword">in</span>&nbsp;ec.Entities)&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;String&nbsp;subject&nbsp;=&nbsp;(String)e[<span class="cs__string">&quot;subject&quot;</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;String&nbsp;priorityCode&nbsp;=&nbsp;((OptionSetValue)e[<span class="cs__string">&quot;prioritycode&quot;</span>]).Value.ToString();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;e.FormattedValues.TryGetValue(<span class="cs__string">&quot;prioritycode&quot;</span>,&nbsp;<span class="cs__keyword">out</span>&nbsp;priorityCode);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;String&nbsp;activityId&nbsp;=&nbsp;((Guid)e[<span class="cs__string">&quot;activityid&quot;</span>]).ToString();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;String&nbsp;createdOn&nbsp;=&nbsp;((DateTime)e[<span class="cs__string">&quot;createdon&quot;</span>]).ToShortDateString();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;e.FormattedValues.TryGetValue(<span class="cs__string">&quot;createdon&quot;</span>,&nbsp;<span class="cs__keyword">out</span>&nbsp;createdOn);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;String&nbsp;accountName&nbsp;=&nbsp;(String)((AliasedValue)e[<span class="cs__string">&quot;acct.name&quot;</span>]).Value;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;String&nbsp;accountCreatedOn&nbsp;=&nbsp;((DateTime)((AliasedValue)e[<span class="cs__string">&quot;acct.createdon&quot;</span>]).Value).ToShortDateString();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;e.FormattedValues.TryGetValue(<span class="cs__string">&quot;acct.createdon&quot;</span>,&nbsp;<span class="cs__keyword">out</span>&nbsp;accountCreatedOn);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;String&nbsp;accountCategorycode&nbsp;=&nbsp;((AliasedValue)e[<span class="cs__string">&quot;acct.accountcategorycode&quot;</span>]).Value.ToString();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;e.FormattedValues.TryGetValue(<span class="cs__string">&quot;acct.accountcategorycode&quot;</span>,&nbsp;<span class="cs__keyword">out</span>&nbsp;accountCategorycode);&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(formatString,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;subject,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;priorityCode,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;activityId,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;createdOn,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;accountName,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;accountCreatedOn,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;accountCategorycode&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;====================================&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ShowEntityCollectionValues2(EntityCollection&nbsp;ec)&nbsp;
&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//For&nbsp;best&nbsp;results&nbsp;set&nbsp;the&nbsp;width&nbsp;of&nbsp;your&nbsp;Console&nbsp;window&nbsp;to&nbsp;150&nbsp;or&nbsp;higher.</span>&nbsp;
&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;====================================&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;String&nbsp;formatString&nbsp;=&nbsp;<span class="cs__string">&quot;{0,-8}{1,-13}{2,-37}{3,-20}&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;Console.WriteLine(formatString,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;subject&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;prioritycode&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;activityid&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;createdon&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(Entity&nbsp;e&nbsp;<span class="cs__keyword">in</span>&nbsp;ec.Entities)&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;String&nbsp;subject&nbsp;=&nbsp;(String)e[<span class="cs__string">&quot;subject&quot;</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;String&nbsp;priorityCode&nbsp;=&nbsp;((OptionSetValue)e[<span class="cs__string">&quot;prioritycode&quot;</span>]).Value.ToString();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;e.FormattedValues.TryGetValue(<span class="cs__string">&quot;prioritycode&quot;</span>,&nbsp;<span class="cs__keyword">out</span>&nbsp;priorityCode);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;String&nbsp;activityId&nbsp;=&nbsp;((Guid)e[<span class="cs__string">&quot;activityid&quot;</span>]).ToString();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;String&nbsp;createdOn&nbsp;=&nbsp;((DateTime)e[<span class="cs__string">&quot;createdon&quot;</span>]).ToShortDateString();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;e.FormattedValues.TryGetValue(<span class="cs__string">&quot;createdon&quot;</span>,&nbsp;<span class="cs__keyword">out</span>&nbsp;createdOn);&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(formatString,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;subject,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;priorityCode,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;activityId,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;createdOn&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;====================================&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;}&nbsp;</pre>
</div>
</div>
</div>
</div>
<div>
<h1 id="query">Sdk.Query.QueryExpressionSample.js</h1>
<p>The queryExpressionSample function in this sample performs the following actions:</p>
<ol>
<li>Creates an account with three related tasks </li><li>Uses <strong>Sdk.Query.QueryExpression</strong> with <strong>Sdk.jQ.retrieveMultiple
</strong>to retrieve the account and related tasks </li><li>Uses <strong>Sdk.Query.QueryExpression </strong>to include a related entities query to also return related tasks as part of an
<strong>Sdk.RetrieveRequest </strong>that retrieves the account. </li></ol>
<h2>C# Equivalent Code:</h2>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;queryExpressionSample()&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;Guid&nbsp;CreatedAccountId;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//Create&nbsp;an&nbsp;account&nbsp;with&nbsp;three&nbsp;associated&nbsp;tasks&nbsp;in&nbsp;the&nbsp;late-bound&nbsp;style.</span>&nbsp;
&nbsp;&nbsp;&nbsp;Entity&nbsp;account&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Entity(<span class="cs__string">&quot;account&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;account[<span class="cs__string">&quot;name&quot;</span>]&nbsp;=&nbsp;<span class="cs__string">&quot;Sample&nbsp;Account&nbsp;001&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;account[<span class="cs__string">&quot;creditonhold&quot;</span>]&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;account[<span class="cs__string">&quot;address1_latitude&quot;</span>]&nbsp;=&nbsp;<span class="cs__number">47.638197</span>;&nbsp;
&nbsp;&nbsp;&nbsp;account[<span class="cs__string">&quot;address1_longitude&quot;</span>]&nbsp;=&nbsp;-<span class="cs__number">122.131378</span>;&nbsp;
&nbsp;&nbsp;&nbsp;account[<span class="cs__string">&quot;description&quot;</span>]&nbsp;=&nbsp;<span class="cs__string">&quot;This&nbsp;is&nbsp;a&nbsp;description.&nbsp;\n&nbsp;It&nbsp;has&nbsp;several&nbsp;lines.&nbsp;\n&nbsp;This&nbsp;is&nbsp;the&nbsp;third&nbsp;line.&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;account[<span class="cs__string">&quot;creditlimit&quot;</span>]&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Money(<span class="cs__keyword">new</span>&nbsp;Decimal(<span class="cs__number">200000.00</span>));&nbsp;
&nbsp;&nbsp;&nbsp;account[<span class="cs__string">&quot;accountcategorycode&quot;</span>]&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;OptionSetValue(<span class="cs__number">1</span>);&nbsp;<span class="cs__com">//Preferred&nbsp;Customer</span>&nbsp;
&nbsp;&nbsp;&nbsp;account[<span class="cs__string">&quot;sharesoutstanding&quot;</span>]&nbsp;=&nbsp;<span class="cs__number">200</span>;&nbsp;
&nbsp;&nbsp;&nbsp;account[<span class="cs__string">&quot;revenue&quot;</span>]&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Money(<span class="cs__keyword">new</span>&nbsp;Decimal(<span class="cs__number">3000000.00</span>));&nbsp;
&nbsp;&nbsp;&nbsp;account[<span class="cs__string">&quot;industrycode&quot;</span>]&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;OptionSetValue(<span class="cs__number">6</span>);&nbsp;<span class="cs__com">//Business&nbsp;Services</span>&nbsp;
&nbsp;&nbsp;&nbsp;account[<span class="cs__string">&quot;accountnumber&quot;</span>]&nbsp;=&nbsp;<span class="cs__string">&quot;ABC123&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;account[<span class="cs__string">&quot;address1_city&quot;</span>]&nbsp;=&nbsp;<span class="cs__string">&quot;Redmond&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;EntityCollection&nbsp;relatedTasks&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;EntityCollection();&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;Entity&nbsp;task1&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Entity(<span class="cs__string">&quot;task&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;task1[<span class="cs__string">&quot;subject&quot;</span>]&nbsp;=&nbsp;<span class="cs__string">&quot;Task&nbsp;1&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;task1[<span class="cs__string">&quot;prioritycode&quot;</span>]&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;OptionSetValue(<span class="cs__number">0</span>);&nbsp;<span class="cs__com">//Low</span>&nbsp;
&nbsp;&nbsp;&nbsp;relatedTasks.Entities.Add(task1);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;Entity&nbsp;task2&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Entity(<span class="cs__string">&quot;task&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;task2[<span class="cs__string">&quot;subject&quot;</span>]&nbsp;=&nbsp;<span class="cs__string">&quot;Task&nbsp;2&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;task2[<span class="cs__string">&quot;prioritycode&quot;</span>]&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;OptionSetValue(<span class="cs__number">1</span>);&nbsp;<span class="cs__com">//Normal</span>&nbsp;
&nbsp;&nbsp;&nbsp;relatedTasks.Entities.Add(task2);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;Entity&nbsp;task3&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Entity(<span class="cs__string">&quot;task&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;task3[<span class="cs__string">&quot;subject&quot;</span>]&nbsp;=&nbsp;<span class="cs__string">&quot;Task&nbsp;3&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;task3[<span class="cs__string">&quot;prioritycode&quot;</span>]&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;OptionSetValue(<span class="cs__number">2</span>);&nbsp;<span class="cs__com">//High</span>&nbsp;
&nbsp;&nbsp;&nbsp;relatedTasks.Entities.Add(task3);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;account.RelatedEntities.Add(<span class="cs__keyword">new</span>&nbsp;Relationship(<span class="cs__string">&quot;Account_Tasks&quot;</span>),&nbsp;relatedTasks);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;CreatedAccountId&nbsp;=&nbsp;_serviceProxy.Create(account);&nbsp;
&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Created&nbsp;account&nbsp;with&nbsp;id:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;CreatedAccountId&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;and&nbsp;three&nbsp;associated&nbsp;tasks.&quot;</span>);&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;QueryExpression&nbsp;taskQuery&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;QueryExpression(<span class="cs__string">&quot;task&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;taskQuery.ColumnSet.AddColumn(<span class="cs__string">&quot;subject&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;taskQuery.ColumnSet.AddColumn(<span class="cs__string">&quot;prioritycode&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;taskQuery.ColumnSet.AddColumn(<span class="cs__string">&quot;activityid&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;taskQuery.ColumnSet.AddColumn(<span class="cs__string">&quot;createdon&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;taskQuery.Criteria.AddCondition(<span class="cs__keyword">new</span>&nbsp;ConditionExpression(<span class="cs__string">&quot;task&quot;</span>,&nbsp;<span class="cs__string">&quot;regardingobjectid&quot;</span>,&nbsp;ConditionOperator.Equal,&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">object</span>[]&nbsp;{&nbsp;CreatedAccountId&nbsp;}));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;LinkEntity&nbsp;linkToAccount&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;LinkEntity(<span class="cs__string">&quot;task&quot;</span>,<span class="cs__string">&quot;account&quot;</span>,<span class="cs__string">&quot;regardingobjectid&quot;</span>,&nbsp;<span class="cs__string">&quot;accountid&quot;</span>,&nbsp;JoinOperator.Inner);&nbsp;
&nbsp;&nbsp;&nbsp;linkToAccount.EntityAlias&nbsp;=&nbsp;<span class="cs__string">&quot;acct&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;linkToAccount.Columns.AddColumns(<span class="cs__keyword">new</span>&nbsp;String[]&nbsp;{&nbsp;<span class="cs__string">&quot;name&quot;</span>,&nbsp;<span class="cs__string">&quot;createdon&quot;</span>,&nbsp;<span class="cs__string">&quot;accountcategorycode&quot;</span>&nbsp;});&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;taskQuery.LinkEntities.Add(linkToAccount);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;EntityCollection&nbsp;taskCollection&nbsp;=&nbsp;_serviceProxy.RetrieveMultiple(taskQuery);&nbsp;
&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;These&nbsp;are&nbsp;the&nbsp;tasks&nbsp;retrieved&nbsp;using&nbsp;RetrieveMultiple&nbsp;with&nbsp;a&nbsp;QueryExpression:&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//Use&nbsp;ShowEntityCollectionValues1&nbsp;to&nbsp;display&nbsp;the&nbsp;results&nbsp;of&nbsp;the&nbsp;EntityCollection&nbsp;returned.</span>&nbsp;
&nbsp;&nbsp;&nbsp;ShowEntityCollectionValues1(taskCollection);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//Retrieve&nbsp;related&nbsp;records&nbsp;with&nbsp;RetrieveRequest.</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;QueryExpression&nbsp;relatedTasksQuery&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;QueryExpression(<span class="cs__string">&quot;task&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;relatedTasksQuery.ColumnSet.AddColumn(<span class="cs__string">&quot;subject&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;relatedTasksQuery.ColumnSet.AddColumn(<span class="cs__string">&quot;prioritycode&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;relatedTasksQuery.ColumnSet.AddColumn(<span class="cs__string">&quot;activityid&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;relatedTasksQuery.ColumnSet.AddColumn(<span class="cs__string">&quot;createdon&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//Instantiates&nbsp;an&nbsp;RelationshipQueryCollection&nbsp;for&nbsp;the&nbsp;Account_Tasks&nbsp;relationship&nbsp;and&nbsp;the&nbsp;FetchExpression.</span>&nbsp;
&nbsp;&nbsp;&nbsp;KeyValuePair&lt;Relationship,&nbsp;QueryBase&gt;&nbsp;rtq&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;KeyValuePair&lt;Relationship,&nbsp;QueryBase&gt;(<span class="cs__keyword">new</span>&nbsp;Relationship(<span class="cs__string">&quot;Account_Tasks&quot;</span>),&nbsp;relatedTasksQuery);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;RelationshipQueryCollection&nbsp;rqc&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;RelationshipQueryCollection();&nbsp;
&nbsp;&nbsp;&nbsp;rqc.Add(rtq);&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//Instantiates&nbsp;a&nbsp;new&nbsp;RetrieveRequest&nbsp;with&nbsp;a&nbsp;reference&nbsp;to&nbsp;the&nbsp;created&nbsp;account&nbsp;as&nbsp;the&nbsp;target&nbsp;parameter,&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;a&nbsp;ColumnSet&nbsp;specifying&nbsp;that&nbsp;the&nbsp;name&nbsp;of&nbsp;the&nbsp;account&nbsp;should&nbsp;be&nbsp;returned&nbsp;as&nbsp;the&nbsp;ColumnSet&nbsp;parameter,&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;and&nbsp;the&nbsp;RelationshipQueryCollection&nbsp;as&nbsp;the&nbsp;RelatedEntitiesQuery&nbsp;parameter.</span>&nbsp;
&nbsp;&nbsp;&nbsp;RetrieveRequest&nbsp;req&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;RetrieveRequest()&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Target&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;EntityReference(<span class="cs__string">&quot;account&quot;</span>,&nbsp;CreatedAccountId),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ColumnSet&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ColumnSet(<span class="cs__string">&quot;name&quot;</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;RelatedEntitiesQuery&nbsp;=&nbsp;rqc&nbsp;
&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//Retrieve&nbsp;the&nbsp;account</span>&nbsp;
&nbsp;&nbsp;&nbsp;RetrieveResponse&nbsp;resp&nbsp;=&nbsp;(RetrieveResponse)_serviceProxy.Execute(req);&nbsp;
&nbsp;&nbsp;&nbsp;Entity&nbsp;RetrievedAccount&nbsp;=&nbsp;resp.Entity;&nbsp;
&nbsp;&nbsp;&nbsp;EntityCollection&nbsp;RetrievedTaskCollection;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//The&nbsp;tasks&nbsp;returned&nbsp;with&nbsp;the&nbsp;account&nbsp;retrieved&nbsp;are&nbsp;set&nbsp;to&nbsp;the&nbsp;RetrievedTaskCollection&nbsp;using:&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;RetrievedAccount.RelatedEntities.TryGetValue(<span class="cs__keyword">new</span>&nbsp;Relationship(<span class="cs__string">&quot;Account_Tasks&quot;</span>),&nbsp;<span class="cs__keyword">out</span>&nbsp;RetrievedTaskCollection);&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//Use&nbsp;ShowEntityCollectionValues2&nbsp;to&nbsp;display&nbsp;the&nbsp;values&nbsp;returned.</span>&nbsp;
&nbsp;&nbsp;&nbsp;ShowEntityCollectionValues2(RetrievedTaskCollection);&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//Deletes&nbsp;the&nbsp;account&nbsp;created&nbsp;and&nbsp;therefore&nbsp;also&nbsp;the&nbsp;related&nbsp;tasks.</span>&nbsp;
&nbsp;&nbsp;&nbsp;_serviceProxy.Delete(<span class="cs__string">&quot;account&quot;</span>,&nbsp;CreatedAccountId);&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;}&nbsp;</pre>
</div>
</div>
</div>
</div>
</div>
<div>
<h1 id="sync">SyncSample.js</h1>
<p>This sample contains two functions, <strong>earlyBindingCRUDSample</strong> and
<strong>lateBindingCRUDSample</strong>, which perform exactly the same operations describe in
<a href="#asyncearly">AsyncEarlyBindingCRUD.js </a>and <a href="#asynclate">AsyncLateBindingCRUD.js</a> respectively, except using the methods in the
<strong>Sdk.Sync</strong> namespace.</p>
<p><strong>Note</strong>: Synchronous requests are strongly discouraged because they block the single thread of the browser until the response returns. Under ideal conditions, when operations occur quickly and Internet speeds are fast you may not see any difference.
 Under other conditions, a synchronous request can cause the browser to stop responding.</p>
<p>Compare the UI button&rsquo;s behavior of this sample to the other samples. You&rsquo;ll see that the button does not complete the
<strong>mouseup</strong> event until the page is updated.</p>
<p>For C# equivalent code, see:</p>
<ul>
<li><a href="#csharpearlybinding">C# Equivalent Early Binding CRUD Code</a> </li><li><a href="#csharplatebinding">C# Equivalent Late Binding CRUD Code</a> </li></ul>
</div>
