# Using WMI with C#
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- WMI
- Windows Forms
- .NET Framework 4.0
## Topics
- Windows Management Instrumentation
## Updated
- 08/11/2011
## Description

<h1>Introduction</h1>
<p>This&nbsp;sample shows how to use&nbsp;Windows Management Instrumentation (WMI) with&nbsp;C#. This uses the System.Management assembly. It lists the services&nbsp;from a machine. It shows how to get a list of services on a named computer</p>
<h1><span>Building the Sample</span></h1>
<p>There are no special requirements to build this sample. It uses .NET 4.0</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>This sample&nbsp;demonstrates how to use WMI with C#.&nbsp;</p>
<p>The CreateNewManagementScope function shows how to create a new ManagementScope object which allows you to specify different credentials and options when making the connection to remote machines. The ConnectionOptions are not required for local connections</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private ManagementScope CreateNewManagementScope(string server)
        {
            string serverString = @&quot;\\&quot; &#43; server &#43; @&quot;\root\cimv2&quot;;

            ManagementScope scope = new ManagementScope(serverString);

            if (!chkUseCurrentUser.Checked)
            {
                ConnectionOptions options = new ConnectionOptions
                                  {
                                      Username = txtUsername.Text,
                                      Password = txtPassword.Text,
                                      Impersonation = ImpersonationLevel.Impersonate,
                                      Authentication = AuthenticationLevel.PacketPrivacy
                                  };
                scope.Options = options;
            }

            return scope;
        }</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;ManagementScope&nbsp;CreateNewManagementScope(<span class="cs__keyword">string</span>&nbsp;server)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;serverString&nbsp;=&nbsp;@<span class="cs__string">&quot;\\&quot;</span>&nbsp;&#43;&nbsp;server&nbsp;&#43;&nbsp;@<span class="cs__string">&quot;\root\cimv2&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ManagementScope&nbsp;scope&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ManagementScope(serverString);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!chkUseCurrentUser.Checked)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ConnectionOptions&nbsp;options&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ConnectionOptions&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Username&nbsp;=&nbsp;txtUsername.Text,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Password&nbsp;=&nbsp;txtPassword.Text,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Impersonation&nbsp;=&nbsp;ImpersonationLevel.Impersonate,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Authentication&nbsp;=&nbsp;AuthenticationLevel.PacketPrivacy&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;scope.Options&nbsp;=&nbsp;options;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;scope;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<p><span>The function GetServicesForComputer uses a WMI Select query run by the ManagementObjectSearcher with the ManagementScope to generate a list of ManagementObjects which are in this case Windows Services.</span></p>
<p><span>From there we use LINQ to generate a generic list of strings which are bound to the ListBox on the form</span></p>
<h1><span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden"> private void GetServicesForComputer(string computerName)
        {
            ManagementScope scope = CreateNewManagementScope(computerName);

            SelectQuery query = new SelectQuery(&quot;select * from Win32_Service&quot;);

            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query))
                {
                    ManagementObjectCollection services = searcher.Get();

                    List&lt;string&gt; serviceNames =
                        (from ManagementObject service in services select service[&quot;Caption&quot;].ToString()).ToList();

                    lstServices.DataSource = serviceNames;
                }
            }
            catch (Exception exception)
            {
                lstServices.DataSource = null;
                lstServices.Items.Clear();
                lblErrors.Text = exception.Message;
                Console.WriteLine(Resources.MainForm_GetServicesForServer_Error__ &#43; exception.Message);
            }
        }</pre>
<div class="preview">
<pre class="csharp">&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;GetServicesForComputer(<span class="cs__keyword">string</span>&nbsp;computerName)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ManagementScope&nbsp;scope&nbsp;=&nbsp;CreateNewManagementScope(computerName);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SelectQuery&nbsp;query&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SelectQuery(<span class="cs__string">&quot;select&nbsp;*&nbsp;from&nbsp;Win32_Service&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(ManagementObjectSearcher&nbsp;searcher&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ManagementObjectSearcher(scope,&nbsp;query))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ManagementObjectCollection&nbsp;services&nbsp;=&nbsp;searcher.Get();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;List&lt;<span class="cs__keyword">string</span>&gt;&nbsp;serviceNames&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(from&nbsp;ManagementObject&nbsp;service&nbsp;<span class="cs__keyword">in</span>&nbsp;services&nbsp;select&nbsp;service[<span class="cs__string">&quot;Caption&quot;</span>].ToString()).ToList();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lstServices.DataSource&nbsp;=&nbsp;serviceNames;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(Exception&nbsp;exception)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lstServices.DataSource&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lstServices.Items.Clear();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lblErrors.Text&nbsp;=&nbsp;exception.Message;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(Resources.MainForm_GetServicesForServer_Error__&nbsp;&#43;&nbsp;exception.Message);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</span>More Information</h1>
<p>For more information on the different objects used in this sample and the Windows Management namespace please check the following links</p>
<ul>
<li>System.Management namespace - <a href="http://msdn.microsoft.com/en-us/library/dwd0y33x.aspx">
http://msdn.microsoft.com/en-us/library/dwd0y33x.aspx</a> </li><li>ManagementScope - <a href="http://msdn.microsoft.com/en-us/library/system.management.managementscope.aspx">
http://msdn.microsoft.com/en-us/library/system.management.managementscope.aspx</a>
</li><li>ConnectionOptions - <a href="http://msdn.microsoft.com/en-us/library/system.management.connectionoptions.aspx">
http://msdn.microsoft.com/en-us/library/system.management.connectionoptions.aspx</a>
</li><li>ManagementObjectSearcher - <a href="http://msdn.microsoft.com/en-us/library/system.management.managementobjectsearcher.aspx">
http://msdn.microsoft.com/en-us/library/system.management.managementobjectsearcher.aspx</a>
</li><li>SelectQuery - <a href="http://msdn.microsoft.com/en-us/library/system.management.selectquery.aspx">
http://msdn.microsoft.com/en-us/library/system.management.selectquery.aspx</a> </li></ul>
