# SQL Reporting Services Single Sign On Example
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- SQL Reporting Services
- SSRS
## Topics
- Security
- SQL Server
- Security Extension
## Updated
- 04/25/2011
## Description

<p>This is an example of building a custom security extension that supports SSO (single sign-on) for SQL Reporting Services 2008 / R2.&nbsp; The documentation accompanying the sample can be found here,
<a href="http://blogs.msdn.com/b/cliffgreen/archive/2011/03/29/reporting-services-single-sign-on-sso-authentication-part-1.aspx">
http://blogs.msdn.com/b/cliffgreen/archive/2011/03/29/reporting-services-single-sign-on-sso-authentication-part-1.aspx</a>.&nbsp; The example takes the forms based authentication sample from codeplex and makes modifcations to the UILogon.aspx page to extract
 header information from the request, validating the user and potentially other information.&nbsp; The ValidationManager class in the sample validates the header information and also valudates the user using a table in the database.&nbsp; Key parts of the solution
 are the UILogon.aspx page, the ValidationManager logic, a ReportingServicesProxy and the Authorization and Authentication extensions required by Reporting Services.</p>
<p>This example can be modified to fit other cases of single sign-on by injecting HTTP Modules that intercept the request and redirect to an authentication store where the user can sign in and be redirected back to reporting services.</p>
<p>Information for the forms based authentication sample can be found here, <a href="http://msftrsprodsamples.codeplex.com/releases/view/45918">
http://msftrsprodsamples.codeplex.com/releases/view/45918</a>.</p>
