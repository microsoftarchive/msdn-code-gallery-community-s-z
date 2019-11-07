# Streaming Photo OData Service Sample
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET
- LINQ
- WPF
- WCF Data Services
- OData
- Entity Framework
## Topics
- Data Binding
- Data Access
- WCF Data Services
- OData
- EDM
- Streaming
## Updated
- 10/18/2011
## Description

<div id="mainBody">
<div class="saveHistory" id="allHistory"></div>
<p>The Open Data Protocol (OData) enables you to define data feeds that also make binary large object (BLOB) data, such as photos, videos, and documents, available to client applications that consume OData feeds. This sample is intended to demonstrate how to
 use the <a href="mhtml:file://C:\Users\glenga\AppData\Local\Temp\Temp1_PhotoService.zip\Readme.mht!x-usc:http://msdn.microsoft.com/en-us/library/system.data.services.providers.idataservicestreamprovider" target="_blank">
IDataServiceStreamProvider</a> interface in WCF Data Services to implement an OData service that uses a streaming provider to store and retrieve image files, along with information about each photo. For more information about the scenario and design decisions
 made in implementing this application, see the <a href="mhtml:file://C:\Users\glenga\AppData\Local\Temp\Temp1_PhotoService.zip\Readme.mht!x-usc:http://go.microsoft.com/fwlink/?LinkId=198989" target="_blank">
Data Services Streaming Provider Series: Implementing a Streaming Provider (Part 1)</a>.</p>
<p>This sample streaming data service supports the following blog posts in the data services streaming provider series:</p>
<table>
<tbody>
<tr>
<th>&nbsp;</th>
<th style="text-align:left">&nbsp;</th>
</tr>
<tr>
<td>&nbsp;</td>
<td><a class="externalLink" href="http://go.microsoft.com/fwlink/?LinkId=198989">Part 1: Implementing a Streaming Provider</a></td>
</tr>
<tr>
<td>&nbsp;</td>
<td><a class="externalLink" href="http://blogs.msdn.com/b/astoriateam/archive/2010/09/08/data-services-streaming-provider-series-part-2-accessing-a-media-resource-stream-from-the-client.aspx">Part 2: Accessing a Media Resource Stream from the Client</a></td>
</tr>
</tbody>
</table>
<div>
<h2 class="heading"><span>Prerequisites</span></h2>
<div class="section" id="sectionSection0">
<p>Before running this sample, make sure that the following software is installed:</p>
<ul>
<li class="unordered">Visual Studio 2010, including SQL Server Express (if SQL Server is not already installed).
</li><li class="unordered">Internet Information Services (IIS) on the local computer.
</li></ul>
</div>
</div>
<div>
<h2 class="heading"><span>Building the Sample</span></h2>
<div class="section" id="sectionSection1">
<p>Use the following procedure to build the sample.</p>
<div class="alert">
<table cellspacing="0" cellpadding="0" width="100%">
<tbody>
<tr>
<th align="left">Note: </th>
</tr>
<tr>
<td>Because the ASP.NET Development Server does not support a chunked HTTP Transfer-Encoding, you must instead use IIS to host the ASP.NET Web application that implements this streaming data service. For more information, see the
<a href="http://msdn.microsoft.com/en-us/library/ee960144.aspx" target="_blank">Streaming Provider</a> topic.</td>
</tr>
</tbody>
</table>
<p>&nbsp;<span><strong>To configure IIS</strong></span></p>
</div>
<div>
<div class="subSection">
<ol class="ordered">
<li>
<p>Unzip the sample files on the local computer.</p>
</li><li>
<p>On the <strong>Start</strong> menu, right-click <strong>Visual Studio 2010</strong> and select
<strong>Run as administrator</strong>.</p>
<div class="alert">
<table cellspacing="0" cellpadding="0" width="100%">
<tbody>
<tr>
<th align="left">Note: </th>
</tr>
<tr>
<td>Visual Studio must run with administrator privileges to be able to make changes to virtual directories and ASP.NET.</td>
</tr>
</tbody>
</table>
<p>&nbsp;</p>
</div>
</li><li>
<p>In Visual Studio, open the PhotoService.sln solution file in the root directory of the sample.</p>
</li><li>
<p>In the Solution Explorer window, expand the solution, right-click the PhotoService project, and click
<strong>Properties</strong>.</p>
</li><li>
<p>In the PhotoService properties page, click the <strong>Web</strong> tab, and then under
<strong>Servers</strong> click <strong>Create Virtual Directory</strong>.</p>
<p>This creates the <code>\PhotoService</code> virtual directory in the default Web site with the project directory as the physical directory.</p>
</li><li>
<p>Navigate to the <code>\PhotoService</code> physical directory and make sure that the user under which IIS runs (usually NETWORK SERVICE) has at least modify permissions on the directory.</p>
</li><li>
<p>(Optional) From the command prompt with administrator privileges, execute one of the following commands (depending on the operating system):</p>
<ul>
<li class="unordered">32-bit systems:<br>
<div class="code"><span>
<table cellspacing="0" cellpadding="0" width="100%">
<tbody>
<tr>
<th>&nbsp;</th>
<th><span class="copyCode">&nbsp;</span></th>
</tr>
<tr>
<td colspan="2">
<pre>&quot;%windir%\Microsoft.NET\Framework\v3.0\Windows Communication Foundation\ServiceModelReg.exe&quot; -i</pre>
</td>
</tr>
</tbody>
</table>
</span></div>
</li><li class="unordered">64-bit systems:<br>
<div class="code"><span>
<table cellspacing="0" cellpadding="0" width="100%">
<tbody>
<tr>
<th>&nbsp;</th>
<th><span class="copyCode">&nbsp;</span></th>
</tr>
<tr>
<td colspan="2">
<pre>&quot;%windir%\Microsoft.NET\Framework64\v3.0\Windows Communication Foundation\ServiceModelReg.exe&quot; -i</pre>
</td>
</tr>
</tbody>
</table>
</span></div>
</li></ul>
<p>This makes sure that Windows Communication Foundation (WCF) is registered on the computer.</p>
</li><li>
<p>(Optional) From the command prompt with administrator privileges, execute one of the following commands (depending on the operating system):</p>
<ul>
<li class="unordered">32-bit systems:<br>
<div class="code"><span>
<table cellspacing="0" cellpadding="0" width="100%">
<tbody>
<tr>
<th>&nbsp;</th>
<th>&nbsp;</th>
</tr>
<tr>
<td colspan="2">
<pre>&quot;%windir%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis.exe&quot; -i -enable</pre>
</td>
</tr>
</tbody>
</table>
</span></div>
</li><li class="unordered">64-bit systems:<br>
<div class="code"><span>
<table cellspacing="0" cellpadding="0" width="100%">
<tbody>
<tr>
<th>&nbsp;</th>
<th>&nbsp;</th>
</tr>
<tr>
<td colspan="2">
<pre>&quot;%windir%\Microsoft.NET\Framework64\v4.0.30319\aspnet_regiis.exe&quot; -i -enable</pre>
</td>
</tr>
</tbody>
</table>
</span></div>
</li></ul>
<p>This makes sure that IIS runs correctly after WCF has been installed on the computer. You might have to also restart IIS.</p>
</li><li>
<p>When the ASP.NET application runs on IIS7, you must also perform the following steps:</p>
<ol class="ordered">
<li>Open IIS Manager and navigate to the PhotoService application under <strong>Default Web Site</strong>.
</li><li>In <strong>Features View</strong>, double-click <strong>Authentication</strong>.
</li><li>On the <strong>Authentication</strong> page, select <strong>Anonymous Authentication</strong>.
</li><li>In the <strong>Actions</strong> pane, click <strong>Edit</strong> to set the security principal under which anonymous users will connect to the site.
</li><li>In the <strong>Edit Anonymous Authentication Credentials</strong> dialog box, select
<strong>Application pool identity</strong>. </li></ol>
<div class="alert">
<table cellspacing="0" cellpadding="0" width="100%">
<tbody>
<tr>
<th align="left">Note: </th>
</tr>
<tr>
<td>When you use the Network Service account, you grant anonymous users all the internal network access associated with that account.</td>
</tr>
</tbody>
</table>
<p>&nbsp;</p>
</div>
</li></ol>
</div>
</div>
<div>
<h4 class="subHeading"><span><strong>To create the PhotoStorage database</strong></span></h4>
<div class="subSection">
<ol class="ordered">
<li>
<p>In Visual Studio, open the <strong>PhotoData.edmx.sql</strong> file in the PhotoService project.</p>
</li><li>
<p>From the <strong>Data</strong> menu, expand <strong>Transact-SQL Editor</strong> and
<strong>Connection</strong> and click <strong>Connect</strong>.</p>
<p>This displays the Connect to Database Engine dialog box.</p>
</li><li>
<p>Type <strong>localhost\SQLExpress</strong> or select another local instance of SQL Server, and then click
<strong>Connect</strong>.</p>
</li><li>
<p>From the <strong>Data</strong> menu, expand <strong>Transact-SQL Editor</strong> and
<strong>Connection</strong> and click <strong>Execute SQL</strong>.</p>
<p>This creates the PhotoStorage database. It also creates a login for the Network Service and grants this login access to the new PhotoStorage database, which gives the IIS process access to the data.</p>
</li></ol>
</div>
</div>
<div>
<h4 class="subHeading"><span><strong>To build the sample</strong></span></h4>
<div class="subSection">
<ol class="ordered">
<li>
<p>Make sure that the connection string stored in the web.config file in the <code>
\PhotoService</code> subdirectory is valid for the database instance being used.</p>
</li><li>
<p>Build the solution.</p>
</li></ol>
</div>
</div>
</div>
</div>
<div>
<h2 class="heading"><span>Running the Sample</span></h2>
<div class="section" id="sectionSection2">
<p>Use the following procedures to run the sample.</p>
<div>
<h4 class="subHeading"><span><strong>To test the data service</strong></span></h4>
<div class="subSection">
<ol class="ordered">
<li>
<p>On the local computer, open the following URI in a Web browser:</p>
<div class="code"><span>
<table cellspacing="0" cellpadding="0" width="100%">
<tbody>
<tr>
<th>&nbsp;</th>
<th>&nbsp;</th>
</tr>
<tr>
<td colspan="2">
<pre><a href="http://localhost/PhotoService/PhotoData.svc">http://localhost/PhotoService/PhotoData.svc</a><br></pre>
</td>
</tr>
</tbody>
</table>
</span></div>
<div class="alert">
<table cellspacing="0" cellpadding="0" width="100%">
<tbody>
<tr>
<th align="left">Note: </th>
</tr>
<tr>
<td>You may need to disable feed viewing in your browser. For more information, see
<a href="http://msdnstage.redmond.corp.microsoft.com/en-us/library/dd728279.aspx" target="_blank">
Accessing the Service from a Web Browser (ADO.NET Data Services Quickstart)</a>.</td>
</tr>
</tbody>
</table>
<p>Verify that the data service returns the <code>PhotoData</code> entity set definition.</p>
</div>
</li><li>
<p>On the local computer, open the following URI in a Web browser:</p>
<div class="code"><span>
<table cellspacing="0" cellpadding="0" width="100%">
<tbody>
<tr>
<th>&nbsp;</th>
<th>&nbsp;</th>
</tr>
<tr>
<td colspan="2">
<pre>http://localhost/PhotoService/PhotoData.svc/$metadata</pre>
</td>
</tr>
</tbody>
</table>
</span></div>
<p>Notice that the <strong>HasStream</strong> attribute is applied to the <strong>
EntitySet</strong> element that defines the <strong>PhotoInfo</strong> entity.</p>
</li><li>
<p>On the local computer, open the following URI in a Web browser:</p>
<div class="code"><span>
<table cellspacing="0" cellpadding="0" width="100%">
<tbody>
<tr>
<th>&nbsp;</th>
<th>&nbsp;</th>
</tr>
<tr>
<td colspan="2">
<pre>http://localhost/PhotoService/PhotoData.svc/PhotoInfo(1)</pre>
</td>
</tr>
</tbody>
</table>
</span></div>
<p>This returns the <strong>PhotoInfo</strong> entity that has a key value of 1.</p>
</li><li>
<p>On the local computer, open the following URI in a Web browser:</p>
<div class="code"><span>
<table cellspacing="0" cellpadding="0" width="100%">
<tbody>
<tr>
<th>&nbsp;</th>
<th>&nbsp;</th>
</tr>
<tr>
<td colspan="2">
<pre>http://localhost/PhotoService/PhotoData.svc/PhotoInfo(1)/$value</pre>
</td>
</tr>
</tbody>
</table>
</span></div>
<p>This returns the image file as a data stream for the entity with the specified key. The image is displayed in the Web browser.</p>
</li></ol>
</div>
</div>
<div>
<h4 class="subHeading"><span><strong>To run the client application</strong></span></h4>
<div class="subSection">
<ol class="ordered">
<li>
<p>Make sure that <strong>PhotoStreamingClient</strong> is the startup project, and then press F5.</p>
<p><strong>PhotoInfo</strong> data is requested from the data service and loaded into a
<a href="http://msdn.microsoft.com/en-us/library/ee474331.aspx" target="_blank">DataServiceCollection&lt;T&gt;</a>, which is bound to the combo box. The image file associated with the selected entity is obtained as a stream from the data service.</p>
<div class="alert">
<table cellspacing="0" cellpadding="0" width="100%">
<tbody>
<tr>
<th align="left">Note: </th>
</tr>
<tr>
<td>The data service is configured to limit uploaded images to 500 KB.</td>
</tr>
</tbody>
</table>
<p>&nbsp;</p>
</div>
</li><li>
<p>Click <strong>Photo Details</strong>.</p>
<p>This displays data from the <strong>PhotoInfo</strong> entity for the selected image.</p>
</li><li>
<p>Select another photo to display a different image file.</p>
<div class="alert">
<table cellspacing="0" cellpadding="0" width="100%">
<tbody>
<tr>
<th align="left">Note: </th>
</tr>
<tr>
<td>Images are not cached. Each selection results in a request to the data service.</td>
</tr>
</tbody>
</table>
<p>&nbsp;</p>
</div>
</li><li>
<p>Click <strong>Add Photo</strong>, in the displayed dialog select an image to upload to the data service, and then click
<strong>Open</strong>.</p>
<div class="alert">
<table cellspacing="0" cellpadding="0" width="100%">
<tbody>
<tr>
<th align="left">Note: </th>
</tr>
<tr>
<td>The data service is configured to limit uploaded images to 500 KB.</td>
</tr>
</tbody>
</table>
<p>&nbsp;</p>
</div>
</li><li>
<p>In the <strong>Select a new photo to upload...</strong> dialog box, enter information about the selected photo and then click
<strong>Save and Close</strong>.</p>
<p>This sends a POST request to the data service that contains the image file as a stream. A subsequent MERGE request sends the rest of the data from the newly created
<strong>PhotoInfo</strong> object.</p>
</li><li>
<p>Click <strong>Refresh Images</strong> to reload <strong>PhotoInfo</strong> data from the data service.</p>
</li></ol>
</div>
</div>
</div>
</div>
</div>
