# SSASProxy Custom HTTP Security Sample
## Requires
- Visual Studio 2012
## License
- MS-LPL
## Technologies
- Excel 2010
- SQL server analysis services
- Excel 2013
## Topics
- HTTP Handler
- Business Intelligence
## Updated
- 09/30/2015
## Description

<h1>Introduction</h1>
<p><em>This sample shows how to put a HTTP Handler in front of the Analysis Services Data Pump, which is the HTTP interface for Analysis Services.&nbsp; This HTTP Handler should be deployed in an IIS application that supports HTTP Anonymous authentication.&nbsp;
</em></p>
<h1><span>Building the Sample</span></h1>
<p>The code is delivered as a Visual Studio 2012 project is configured to deploy to the local IIS web server.&nbsp; You'll need to run Visual Studio as Administrator to allow it to configure and deploy to IIS.&nbsp; The code also assumes that the SSAS Data
 Pump is deployed at <a href="http://localhost/ssas/msmdpump.dll">http://localhost/ssas/msmdpump.dll</a>.&nbsp; You should test connectivity to the data pump from Excel before trying to run through the SSAS Proxy.</p>
<p><span style="color:#a31515; font-family:Consolas; font-size:medium">&nbsp;</span><span style="font-size:20px; font-weight:bold">&nbsp;</span>&nbsp;</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>The HTTP interface for Analysis Services supports Windows Integrated Authenticaion (NTLM or Kerberos) and HTTP Basic Authentication.&nbsp; And the authenticated user is then impersonated for connection to Analysis Services.&nbsp; This works well for
 the normal case of domain-based users connecting to SSAS cubes from Excel.&nbsp; But for scenarios where the end user is not a member of a trusted domain, or the Analysis Services box is on a remote server and the client can't use Kerberos (ie where the client
 can't communicate with the Domain Controller), the data pump can be hard to deploy.&nbsp; So this sample is intended to be useful in that scenario, and also serve as a starting point for other custom authentication scenarios with Analysis Services.</em></p>
<p><em>The SSAS Proxy has a custom implementation of HTTP Basic authentication to validate user credentials against a custom identity store.&nbsp; The authenticated user identity is then passed to SSAS in the CustomData field of the XMLA BeginSession request
 so it can be used by a cube to implement custom security.&nbsp; Note that since this uses HTTP Basic authentication, the user's password is sent in plain text to the web server, and so you should alwas use HTTPS to protect the traffic in a production deployment.</em></p>
<p>&nbsp;</p>
<h1>More Information</h1>
<p><strong>CustomData (MDX)</strong></p>
<p><a href="http://msdn.microsoft.com/en-us/library/ms145582.aspx">http://msdn.microsoft.com/en-us/library/ms145582.aspx</a></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><strong>Clients (Analysis Services - Multidimensional Data)</strong></p>
<p><a href="http://msdn.microsoft.com/en-us/library/ms174518.aspx">http://msdn.microsoft.com/en-us/library/ms174518.aspx</a></p>
<p>&nbsp;</p>
<p><strong><em>Configure HTTP Access to Analysis Services on Internet Information Services (IIS) 7.0</em></strong></p>
<p><em><a href="http://msdn.microsoft.com/en-us/library/gg492140(v=sql.110).aspx">http://msdn.microsoft.com/en-us/library/gg492140(v=sql.110).aspx</a></em></p>
