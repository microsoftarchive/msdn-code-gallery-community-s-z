# Working with Windows Management Instrumentation (WMI)
## Requires
- Visual Studio 2010
## License
- Custom
## Technologies
- Windows Forms
- .NET Framework 4.0
## Topics
- System Information
- Windows Management Instrumentation
- BIOS
## Updated
- 06/07/2011
## Description

<h1>Introduction</h1>
<p><span id="ctl00_ctl00_Content_TabContentPanel_Content_wikiSourceLabel">Demonstrates how to use objects in the System.Management namespace to access Windows Management Instrumentation (WMI) and to query system information such as operating system name,
 version, manufacturer, and computer name.</span></p>
<h1><span>Building the Sample</span></h1>
<p>Press F5</p>
<h1>Description<em></em></h1>
<p>The two tabbed pages of the TabControl demonstrate two types of WMI tasks:</p>
<ul>
<li>
<p><span class="ui">Queries</span>&nbsp;&nbsp;&nbsp;This one shows how to use the ManagementObjectSearcher object to query the following system information: Operating System Name, Version, Manufacturer, Computer name, and Windows Directory; Computer System
 Manufacturer, Model, System Type, and Total Physical Memory; Processor name; BIOS version; and Time zone. These queries are created by using the SelectQuery class.</p>
</li><li>
<p><span class="ui">Objects</span>&nbsp;&nbsp;&nbsp;This one shows how to enumerate through the top-level WMI classes and all their data management objects using the ManagementClass and EnumerationOptions classes.</p>
</li></ul>
<h1>Screenshot</h1>
<p><img src="23137-screenshot.png" alt="" width="610" height="392"></p>
<h1>Sample Code<em></em></h1>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">    ' This subroutine fills in the output text box with Operating System information
    ' from WMI
    Private Sub btnOperatingSytem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOperatingSytem.Click
        ' ManagementObjectSearcher retrieves a collection of WMI objects based on 
        ' the query.  In this case a string is used instead of a SelectQuery object.
        Dim search As New ManagementObjectSearcher(&quot;SELECT * FROM Win32_OperatingSystem&quot;)

        ' Display each entry for Win32_OperatingSystem
        Dim info As ManagementObject
        For Each info In search.Get()
            txtOutput.Text = &quot;Name: &quot; &amp; info(&quot;name&quot;).ToString() &amp; vbCrLf
            txtOutput.Text &amp;= &quot;Version: &quot; &amp; info(&quot;version&quot;).ToString() &amp; vbCrLf
            txtOutput.Text &amp;= &quot;Manufacturer: &quot; &amp; info(&quot;manufacturer&quot;).ToString() &amp; vbCrLf
            txtOutput.Text &amp;= &quot;Computer name: &quot; &amp; info(&quot;csname&quot;).ToString() &amp; vbCrLf
            txtOutput.Text &amp;= &quot;Windows Directory: &quot; &amp; _
                info(&quot;windowsdirectory&quot;).ToString() &amp; vbCrLf
        Next
    End Sub</pre>
<div class="preview">
<pre id="codePreview" class="vb">&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;This&nbsp;subroutine&nbsp;fills&nbsp;in&nbsp;the&nbsp;output&nbsp;text&nbsp;box&nbsp;with&nbsp;Operating&nbsp;System&nbsp;information</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;from&nbsp;WMI</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;btnOperatingSytem_Click(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;btnOperatingSytem.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;ManagementObjectSearcher&nbsp;retrieves&nbsp;a&nbsp;collection&nbsp;of&nbsp;WMI&nbsp;objects&nbsp;based&nbsp;on&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;the&nbsp;query.&nbsp;&nbsp;In&nbsp;this&nbsp;case&nbsp;a&nbsp;string&nbsp;is&nbsp;used&nbsp;instead&nbsp;of&nbsp;a&nbsp;SelectQuery&nbsp;object.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;search&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;ManagementObjectSearcher(<span class="visualBasic__string">&quot;SELECT&nbsp;*&nbsp;FROM&nbsp;Win32_OperatingSystem&quot;</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Display&nbsp;each&nbsp;entry&nbsp;for&nbsp;Win32_OperatingSystem</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;info&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ManagementObject&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;<span class="visualBasic__keyword">Each</span>&nbsp;info&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;search.<span class="visualBasic__keyword">Get</span>()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;txtOutput.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Name:&nbsp;&quot;</span>&nbsp;&amp;&nbsp;info(<span class="visualBasic__string">&quot;name&quot;</span>).ToString()&nbsp;&amp;&nbsp;vbCrLf&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;txtOutput.Text&nbsp;&amp;=&nbsp;<span class="visualBasic__string">&quot;Version:&nbsp;&quot;</span>&nbsp;&amp;&nbsp;info(<span class="visualBasic__string">&quot;version&quot;</span>).ToString()&nbsp;&amp;&nbsp;vbCrLf&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;txtOutput.Text&nbsp;&amp;=&nbsp;<span class="visualBasic__string">&quot;Manufacturer:&nbsp;&quot;</span>&nbsp;&amp;&nbsp;info(<span class="visualBasic__string">&quot;manufacturer&quot;</span>).ToString()&nbsp;&amp;&nbsp;vbCrLf&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;txtOutput.Text&nbsp;&amp;=&nbsp;<span class="visualBasic__string">&quot;Computer&nbsp;name:&nbsp;&quot;</span>&nbsp;&amp;&nbsp;info(<span class="visualBasic__string">&quot;csname&quot;</span>).ToString()&nbsp;&amp;&nbsp;vbCrLf&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;txtOutput.Text&nbsp;&amp;=&nbsp;<span class="visualBasic__string">&quot;Windows&nbsp;Directory:&nbsp;&quot;</span>&nbsp;&amp;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;info(<span class="visualBasic__string">&quot;windowsdirectory&quot;</span>).ToString()&nbsp;&amp;&nbsp;vbCrLf&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span></pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><a class="browseFile" href="sourcecode?fileId=23136&pathId=1459912393">MainForm.designer.vb</a>
</li><li><a class="browseFile" href="sourcecode?fileId=23136&pathId=164201288">MainForm.vb</a>
</li></ul>
<h1>More Information</h1>
<p>For more information on Windows Management Insturmentation: <a href="http://msdn.microsoft.com/en-us/library/aa394582%28VS.85%29.aspx" target="_blank">
http://msdn.microsoft.com/en-us/library/aa394582%28VS.85%29.aspx</a></p>
