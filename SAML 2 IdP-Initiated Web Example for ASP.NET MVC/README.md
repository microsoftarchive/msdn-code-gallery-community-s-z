# SAML 2 IdP-Initiated Web Example for ASP.NET MVC
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- C#
- ASP.NET
- VB.Net
- ASP.NET MVC 4
## Topics
- saml
## Updated
- 12/18/2014
## Description

<h1>Introduction</h1>
<p>This example demonstrates how to create a SAML 2 IDP-Initiated application for ASP.NET MVC. This example includes both ASP.NET MVC and ASP.NET MVC 4 solutions.</p>
<h1><span>Building the Sample</span></h1>
<p>In order to build the sample project, you need the commercial <a href="http://www.componentpro.com/saml.net/" target="_blank">
Ultimate SAML</a> library which can be downloaded at <a href="http://www.componentpro.com/download/?name=UltimateSaml">
Ultimate SAML Download Page</a>.</p>
<p>After opening the solution, you need to set startup for both projects.</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>These are two example projects: Identity Provider MVC and Service Provider MVC</p>
<p><em>&nbsp;</em></p>
<h2>Identity Provider MVC</h2>
<p>This sample is configured to run at port 1421 (you can easily change the port number in the project property page). Firstly, you need to login to the system with the username iuser and a password of password and then click on a link to access the service
 provider site.</p>
<h2>Service Provider MVC</h2>
<p>This sample is configured to run at port 1422 (you can easily change the port number in the project property page). The&nbsp;service provider web application, in conjunction with&nbsp;Identity Provider&nbsp;web application, demonstrates IdP initiated single
 sign-on. You can login to the local system with the user name&nbsp;<strong>suser</strong> and a password of
<strong>password</strong>.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">try</span>&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Extract&nbsp;the&nbsp;SP&nbsp;target&nbsp;url.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;targetUrl&nbsp;=&nbsp;Request.QueryString[<span class="cs__string">&quot;spUrl&quot;</span>];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Validate&nbsp;it.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">string</span>.IsNullOrEmpty(targetUrl))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Create&nbsp;a&nbsp;SAML&nbsp;response&nbsp;object.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ComponentPro.Saml2.Response&nbsp;samlResponse&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ComponentPro.Saml2.Response();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Assign&nbsp;the&nbsp;consumer&nbsp;service&nbsp;url.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;samlResponse.Destination&nbsp;=&nbsp;ConsumerServiceUrl;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Issuer&nbsp;issuer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Issuer(GetAbsoluteUrl(<span class="cs__string">&quot;~/&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;samlResponse.Issuer&nbsp;=&nbsp;issuer;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;samlResponse.Status&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Status(SamlPrimaryStatusCode.Success,&nbsp;<span class="cs__keyword">null</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Assertion&nbsp;samlAssertion&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Assertion();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;samlAssertion.Issuer&nbsp;=&nbsp;issuer;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Use&nbsp;the&nbsp;local&nbsp;user's&nbsp;local&nbsp;identity.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Subject&nbsp;subject&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Subject(<span class="cs__keyword">new</span>&nbsp;NameId(User.Identity.Name));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SubjectConfirmation&nbsp;subjectConfirmation&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SubjectConfirmation(SamlSubjectConfirmationMethod.Bearer);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SubjectConfirmationData&nbsp;subjectConfirmationData&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SubjectConfirmationData();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;subjectConfirmationData.Recipient&nbsp;=&nbsp;ConsumerServiceUrl;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;subjectConfirmation.SubjectConfirmationData&nbsp;=&nbsp;subjectConfirmationData;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;subject.SubjectConfirmations.Add(subjectConfirmation);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;samlAssertion.Subject&nbsp;=&nbsp;subject;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Create&nbsp;a&nbsp;new&nbsp;authentication&nbsp;statement.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;AuthnStatement&nbsp;authnStatement&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;AuthnStatement();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;authnStatement.AuthnContext&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;AuthnContext();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;authnStatement.AuthnContext.AuthnContextClassRef&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;AuthnContextClassRef(SamlAuthenticateContext.Password);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;samlAssertion.Statements.Add(authnStatement);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;If&nbsp;you&nbsp;need&nbsp;to&nbsp;add&nbsp;custom&nbsp;attributes,&nbsp;uncomment&nbsp;the&nbsp;following&nbsp;code</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;#region&nbsp;Custom&nbsp;Attributes</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;AttributeStatement&nbsp;attributeStatement&nbsp;=&nbsp;new&nbsp;AttributeStatement();</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;attributeStatement.Attributes.Add(new&nbsp;ComponentPro.Saml2.Attribute(&quot;email&quot;,&nbsp;SamlAttributeNameFormat.Basic,&nbsp;null,</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;&quot;john@test.com&quot;));</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;attributeStatement.Attributes.Add(new&nbsp;ComponentPro.Saml2.Attribute(&quot;FirstName&quot;,&nbsp;SamlAttributeNameFormat.Basic,&nbsp;null,</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;&quot;John&quot;));</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;attributeStatement.Attributes.Add(new&nbsp;ComponentPro.Saml2.Attribute(&quot;LastName&quot;,&nbsp;SamlAttributeNameFormat.Basic,&nbsp;null,</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;&quot;Smith&quot;));</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;//&nbsp;Insert&nbsp;a&nbsp;custom&nbsp;token&nbsp;key&nbsp;to&nbsp;the&nbsp;SAML&nbsp;response.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;attributeStatement.Attributes.Add(new&nbsp;ComponentPro.Saml2.Attribute(&quot;CustomTokenForVerification&quot;,&nbsp;SamlAttributeNameFormat.Basic,&nbsp;null,</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;&quot;YourEncryptedTokenHere&quot;));</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;samlAssertion.Statements.Add(attributeStatement);</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;#endregion</span>&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Define&nbsp;ENCRYPTEDSAML&nbsp;preprocessor&nbsp;flag&nbsp;if&nbsp;you&nbsp;wish&nbsp;to&nbsp;encrypt&nbsp;the&nbsp;SAML&nbsp;response.</span><span class="cs__preproc">&nbsp;
#if&nbsp;ENCRYPTEDSAML</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Load&nbsp;the&nbsp;certificate&nbsp;for&nbsp;the&nbsp;encryption.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Please&nbsp;make&nbsp;sure&nbsp;the&nbsp;file&nbsp;is&nbsp;in&nbsp;the&nbsp;root&nbsp;directory.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;X509Certificate2&nbsp;encryptingCert&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;X509Certificate2(Path.Combine(HttpRuntime.AppDomainAppPath,&nbsp;<span class="cs__string">&quot;EncryptionX509Certificate.cer&quot;</span>),&nbsp;<span class="cs__string">&quot;password&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Create&nbsp;an&nbsp;encrypted&nbsp;SAML&nbsp;assertion&nbsp;from&nbsp;the&nbsp;SAML&nbsp;assertion&nbsp;we&nbsp;have&nbsp;created.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;EncryptedAssertion&nbsp;encryptedSamlAssertion&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;EncryptedAssertion(samlAssertion,&nbsp;encryptingCert,&nbsp;<span class="cs__keyword">new</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Security.Cryptography.Xml.EncryptionMethod.aspx" target="_blank" title="Auto generated link to System.Security.Cryptography.Xml.EncryptionMethod">System.Security.Cryptography.Xml.EncryptionMethod</a>(SamlKeyAlgorithm.TripleDesCbc));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Add&nbsp;encrypted&nbsp;assertion&nbsp;to&nbsp;the&nbsp;SAML&nbsp;response&nbsp;object.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;samlResponse.Assertions.Add(encryptedSamlAssertion);<span class="cs__preproc">&nbsp;
#else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Add&nbsp;assertion&nbsp;to&nbsp;the&nbsp;SAML&nbsp;response&nbsp;object.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;samlResponse.Assertions.Add(samlAssertion);<span class="cs__preproc">&nbsp;
#endif</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Get&nbsp;the&nbsp;previously&nbsp;loaded&nbsp;certificate.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;X509Certificate2&nbsp;x509Certificate&nbsp;=&nbsp;(X509Certificate2)Application[Global.CertKeyName];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Sign&nbsp;the&nbsp;SAML&nbsp;response&nbsp;with&nbsp;the&nbsp;certificate.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;samlResponse.Sign(x509Certificate);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Send&nbsp;the&nbsp;SAML&nbsp;response&nbsp;to&nbsp;the&nbsp;service&nbsp;provider.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;samlResponse.SendPostBindingForm(Response.OutputStream,&nbsp;ConsumerServiceUrl,&nbsp;targetUrl);&nbsp;
}&nbsp;
&nbsp;
<span class="cs__keyword">catch</span>&nbsp;(Exception&nbsp;exception)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Trace.Write(<span class="cs__string">&quot;IdentityProvider&quot;</span>,&nbsp;<span class="cs__string">&quot;An&nbsp;Error&nbsp;occurred&quot;</span>,&nbsp;exception);&nbsp;
}</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<h1>More Information</h1>
<p><em>See <a href="http://www.componentpro.com/saml.net/">Ultimate SAML</a> home page and its example code
<a href="http://samlcomponent.net">http://samlcomponent.net/</a> for more information<em>.</em></em></p>
