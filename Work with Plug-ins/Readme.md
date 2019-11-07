# Work with Plug-ins
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- Microsoft Dynamics CRM
- Dynamics 365 Customer Engagement
## Topics
- Microsoft Dynamics CRM SDK
## Updated
- 09/17/2018
## Description

<h1>Work with plug-ins</h1>
<p>A plug-in is custom business logic (code) that you can integrate with Microsoft Dynamics 365 (online &amp; on-premises) to modify or augment the standard behavior of the platform. Another way to think about plug-ins is that they are handlers for events fired
 by Microsoft Dynamics 365. You can subscribe, or register, a plug-in to a known set of events to have your code run when the event occurs.<strong>&nbsp;</strong><em>&nbsp;</em></p>
<p>Plug-ins are custom classes that implement the <a href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.iplugin?view=dynamics-general-ce-9">
IPlugin</a> interface. You can write a plug-in in any .NET Framework 4.5.2 CLR-compliant language such as Microsoft Visual C# and Microsoft Visual Basic .NET. To be able to compile plug-in code, you must add Microsoft.Xrm.Sdk.dll and Microsoft.Crm.Sdk.Proxy.dll
 assembly references to your project.</p>
<p>The <strong>plug-in.sln</strong> file contains the following code samples.</p>
<h2><span>Sample: Create a basic plug-in</span></h2>
<p>The sample demonstrates how to write a basic plug-in that can access the Microsoft Dynamics 365 organization Web service.</p>
<p>The plug-in creates a task activity after a new account is created. The activity reminds the user to follow-up with the new account customer one week after the account was created.</p>
<h3 id="requirements">Requirements</h3>
<p class="lf-text-block x_x_x_x_x_x_x_x_x_lf-block">Register this plug-in for an account entity, on the Create message, and in asynchronous mode. Alternately, you can register the plug-in on a post-event in the sandbox.</p>
<p class="lf-text-block x_x_x_x_x_x_x_x_x_lf-block">Click to see&nbsp;<a href="https://code.msdn.microsoft.com/Sample-Create-a-basic-plug-64d86ade/sourcecode?fileId=182866&pathId=2098651455">FollowupPlugin.cs</a><strong>&nbsp;</strong><em>&nbsp;</em> sample
 file.<strong>&nbsp;</strong><em>&nbsp;</em></p>
<p>More information:&nbsp;<a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/sample-create-basic-plugin">Sample: Create a basic plug-in</a> and
<a class="selected" tabindex="0" href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/write-plugin">
Write a plug-in</a> <strong>&nbsp;</strong><em>&nbsp;</em></p>
<h2><span>Sample: Web access from a sandboxed plug-in</span></h2>
<p>The sample Demonstrates how to code a plug-in that has Web (network) access and be registered in the sandbox.</p>
<p>Click to see&nbsp;<a href="https://code.msdn.microsoft.com/Sample-Create-a-basic-plug-64d86ade/sourcecode?fileId=182866&pathId=981980527">WebClientPlugin.cs</a><strong>&nbsp;</strong><em>&nbsp;</em> sample file.</p>
<h3 id="requirements">Requirements</h3>
<p class="lf-text-block x_x_x_x_x_x_x_x_x_lf-block">Register the compiled plug-in to run in the sandbox on the Dynamics 365 server.
<strong></strong><em></em></p>
<p>More information: <a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/sample-web-access-sandboxed-plugin">
Sample: Web access from a sandboxed plug-in</a></p>
<h2>Sample: Advanced plug-in&nbsp;</h2>
<p>A plug-in that updates the description field with values from the unsecure and secure constructor parameters. You can register this plug-in on the Update message, contact entity, pre-Operation and synchronous mode.</p>
<p>Click to see <a href="https://code.msdn.microsoft.com/Sample-Create-a-basic-plug-64d86ade/sourcecode?fileId=182866&pathId=925933620">
AdvancedPlugin.cs</a> sample file.<strong></strong><em></em></p>
<p>More information: <a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/debug-plugin#logging-and-tracing">
Logging and Tracing</a></p>
<h2>Sample: SharedVariables plug-in</h2>
<p>A plug-in that sends data to another plug-in through the SharedVariables<span class="hljs-comment"> property of
<a href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.ipluginexecutioncontext">
IPluginExecutionContext</a>.</span></p>
<p><span class="hljs-comment">Click to see <a href="https://code.msdn.microsoft.com/Sample-Create-a-basic-plug-64d86ade/sourcecode?fileId=182866&pathId=770776645">
SharedVariablesPlugin.cs</a> sample file.<strong></strong><em></em><br>
</span></p>
<p><span class="hljs-comment">More information: <a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/pass-data-between-plug-ins">
Pass data between plug-ins</a>&nbsp;</span></p>
<p><span class="hljs-comment"><a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/pass-data-between-plug-ins"></a><br>
</span></p>
