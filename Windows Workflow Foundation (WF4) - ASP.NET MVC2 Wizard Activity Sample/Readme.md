# Windows Workflow Foundation (WF4) - ASP.NET MVC2 Wizard Activity Sample
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- Workflow
- Windows Workflow Foundation
- WF4
## Topics
- Workflow
- ASP.NET MVC
## Updated
- 05/11/2011
## Description

<h1>Introduction</h1>
<p>This sample code demonstrates how you can use Windows Workflow Foundation along with custom activities to build a Wizard Style UI with ASP.NET MVC.</p>
<p>The code was created by the Microsoft Product Quality Team to support wizard based troubleshooters for Microsoft products.&nbsp; For more information see
<a href="http://channel9.msdn.com/Shows/Endpoint/endpointtv-WF4-in-the-Real-World-Microsoft-Support-ASPNET-MVC-Wizard-Framework">
endpoint.tv - WF4 in the Real World - Microsoft Support ASP.NET MVC Wizard Framework</a></p>
<h1><span>Building the Sample</span></h1>
<p>The solution consists of the Wizard Activities, Designers and a modified version of the MVC Music Store sample application which uses a workflow to process the checkout.</p>
<p>Build the solution and run the MVC Music Store to see it in action</p>
<h1>Navigation Problem</h1>
<p>How to get users from one screen to another in a pre-determined sequence based on user inputs and business rules.</p>
<p>Enable screens to be added or removed or rearranged without having to re-code or re-compile a solution.</p>
<p>User can perform following actions</p>
<p><strong>Next :</strong> Show the next screen</p>
<p><strong>Back : </strong>Show the previous screen</p>
<p><strong>GoTo : </strong>Jump to any previous visited screen.</p>
<p><strong>Example</strong>: E-Commerce checkout workflow</p>
<p>Wizard activity pack has been developed to solve this navigation problem using WF4.0.</p>
<h1>Basic Architecture</h1>
<p>The Wizard activity pack has following components:</p>
<p>Custom Activities: There are 3 custom activities (WizardContainer, Wizard and Step) all derived from Native Activity .</p>
<p>Workflow Input/Output: There is a class and enum (&ldquo;CustomBookmark&rdquo; and &ldquo;Command&rdquo;), these are used to pass input/output<br>
parameters of wizard container activity.</p>
<p>Helper Classes: There are 2 helper classes (ExtentionMethods and Conatants) internally used by custom activities.</p>
<p>&nbsp;</p>
