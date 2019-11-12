# SAML 2  Shibboleth Example for ASP.NET
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- ASP.NET
- ASP.NET MVC
- ASP.NET MVC 4
- saml
## Topics
- saml
- Shibboleth
## Updated
- 05/26/2014
## Description

<h1>Introduction</h1>
<p>This example demonstrates how to create a SAML 2 Shibboleth application for ASP.NET.</p>
<h1><span>Building the Sample</span></h1>
<p>In order to build the sample project, you need the commercial <a href="http://www.componentpro.com/saml.net/" target="_blank">
Ultimate SAML</a> library which can be downloaded at <a href="http://www.componentpro.com/download/?name=UltimateSaml">
Ultimate SAML Download Page</a>.<em><br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>These applications may also be used to demonstrate interoperability with Shibboleth. Shibboleth (<a href="http://shibboleth.internet2.edu">http://shibboleth.internet2.edu</a>) is an open source SSO software package using Java and C&#43;&#43; technologies. Installation
 and configuration of the Shibboleth software is beyond the scope of this document and is not required for this demonstration.</p>
<p>The package contains two example project:</p>
<h2>Identity Provider Web Application</h2>
<p>This sample is configured to run at port 1423 (you can easily change the port number in the project property page). The identity provider web application, in conjunction with Service Provider web application,&nbsp;demonstrates SP initiated single sign-on.</p>
<h2>Service&nbsp;Provider Web Application</h2>
<p>This sample is configured to run at port 1424 (you can easily change the port number in the project property page). The&nbsp;service provider web application, in conjunction with&nbsp;Identity Provider&nbsp;web application, demonstrates SP initiated single
 sign-on.&nbsp;You can directly login to the local system by&nbsp;entering credentials (suser/password) and clicking on the Login button (login to SP without Single Sign-On) or&nbsp;follow the&nbsp;steps below to run the application with Single Sign-On (In
 this scenario, the user is attempting to access a protected resource on the service provider and, rather than performing a local login at the service provider, SSO is initiated with a local login occurring at the identity provider and the asserted identity,
 passed to the service provider in a SAML assertion, is used to perform an automatic login at the service provider)</p>
<p>&nbsp;</p>
<p>The following code snippet demonstrates how to load a SAML response from ASP.NET's Response object, load a certificate, get Assertion object, and decrypt the encrypted attributes:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">XmlDocument&nbsp;xmlDocument&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;XmlDocument();&nbsp;
xmlDocument.PreserveWhitespace&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
xmlDocument.Load(samlResponseXml);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;Load&nbsp;the&nbsp;SAML&nbsp;response&nbsp;from&nbsp;the&nbsp;XML&nbsp;document.</span>&nbsp;
Response&nbsp;samlResponse&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Response(xmlDocument.DocumentElement);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;Load&nbsp;the&nbsp;private&nbsp;key&nbsp;file.</span>&nbsp;
X509Certificate2&nbsp;certificate&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;X509Certificate2(privateCertificateFile,&nbsp;<span class="cs__string">&quot;password&quot;</span>);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;Access&nbsp;the&nbsp;first&nbsp;assertion&nbsp;object.</span>&nbsp;
Assertion&nbsp;assertion&nbsp;=&nbsp;(Assertion)samlResponse.Assertions[<span class="cs__number">0</span>];&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;Loop&nbsp;through&nbsp;the&nbsp;encrypted&nbsp;attributes&nbsp;list.&nbsp;</span>&nbsp;
<span class="cs__keyword">foreach</span>&nbsp;(EncryptedAttribute&nbsp;encryptedAttribute&nbsp;<span class="cs__keyword">in</span>&nbsp;assertion.AttributeStatements[<span class="cs__number">0</span>].EncryptedAttributes)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Get&nbsp;the&nbsp;encrypted&nbsp;key.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;EncryptedKey&nbsp;encryptedKey&nbsp;=&nbsp;encryptedAttribute.GetEncryptedKeyObjects()[<span class="cs__number">0</span>];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Decrypt&nbsp;the&nbsp;encrypted&nbsp;attribute.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ComponentPro.Saml2.Attribute&nbsp;decryptedAttribute&nbsp;=&nbsp;encryptedAttribute.Decrypt(certificate.PrivateKey,&nbsp;encryptedKey,&nbsp;<span class="cs__keyword">null</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;...</span>&nbsp;
}</pre>
</div>
</div>
</div>
<h1>More Information</h1>
<p>For more information on saml examples, please see our official blog for our component at:
<a href="http://samlcomponent.net/">http://samlcomponent.net/</a></p>
