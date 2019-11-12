# VB .NET OUTLOOK SEND EMAIL
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- Visual Studio 2010
## Topics
- Visual Studio 2008
- Visual Studio 2010
- Visual Studio 2012
## Updated
- 01/09/2014
## Description

<h1>Introduction</h1>
<p><em>VB .NET Sending Email via OUTLOOK, This sample conclude to Automate Email sending including Attachment</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>You could this program considering that having OUTLOOK, in behalf of that need to Import the Outlook Object</em></p>
<p><em><span>&nbsp;Add reference to&nbsp;</span><a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/Microsoft.Office.Interop.Outlook.aspx" target="_blank" title="Auto generated link to Microsoft.Office.Interop.Outlook">Microsoft.Office.Interop.Outlook</a><span>&nbsp;which can be done through,</span>Project Menu<span>,&nbsp;</span>Add Reference<br>
</em></p>
<p><em>'Imports <a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/Microsoft.Office.Interop.Outlook.aspx" target="_blank" title="Auto generated link to Microsoft.Office.Interop.Outlook">Microsoft.Office.Interop.Outlook</a>'</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><span>This article assumes that you are familiar with the following topics:</span></p>
<ul>
<li>Outlook Object Model (OOM) </li><li>Programming with Visual Basic .NET </li></ul>
<p><span>To use the Microsoft Outlook Object Library to create a contact in Microsoft Visual Basic .NET, follow these steps:</span></p>
<ol>
<li>Start Microsoft Visual Studio .NET. </li><li>On the&nbsp;<strong class="uiterm">File</strong>&nbsp;menu, point to&nbsp;<strong class="uiterm">New</strong>, and then click&nbsp;<strong class="uiterm">Project</strong>.
</li><li>Under&nbsp;<strong class="uiterm">Project Types</strong>, click&nbsp;<strong class="uiterm">Visual Basic Projects</strong>.
</li><li>Under&nbsp;<strong class="uiterm">Templates</strong>, click&nbsp;<strong class="uiterm">Console Application</strong>, and then click&nbsp;<strong class="uiterm">OK</strong>.&nbsp;<br>
<br>
By default, Module1.vb is created. </li><li>Add a reference to the Microsoft Outlook 10.0 Object Library. To do this, follow these steps:
<ol>
<li>On the&nbsp;<strong>Project</strong>&nbsp;menu, click&nbsp;<strong>Add Reference</strong>.
</li><li>On the&nbsp;<strong>COM</strong>&nbsp;tab, click&nbsp;<strong>Microsoft Outlook 14.0 Object Library</strong>, and then click&nbsp;<strong>Select</strong>.
</li><li>In the&nbsp;<strong>Add References</strong>&nbsp;dialog box, click&nbsp;<strong>OK</strong>&nbsp;to accept your selections. If you receive a prompt to generate wrappers for the libraries that you selected, click&nbsp;<strong>Yes</strong>
</li></ol>
</li></ol>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;setEmailSend(sSubject&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;sBody&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sTo&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;sCC&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sFilename&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;sDisplayname&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;oApp&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Interop.Outlook._Application&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;oApp&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Interop.Outlook.Application&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;oMsg&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Interop.Outlook._MailItem&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;oMsg&nbsp;=&nbsp;oApp.CreateItem(Interop.Outlook.OlItemType.olMailItem)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;oMsg.Subject&nbsp;=&nbsp;sSubject&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;oMsg.Body&nbsp;=&nbsp;sBody&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;oMsg.<span class="visualBasic__keyword">To</span>&nbsp;=&nbsp;sTo&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;oMsg.CC&nbsp;=&nbsp;sCC&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;strS&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;sFilename&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;strN&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;sDisplayname&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;sFilename&nbsp;&lt;&gt;&nbsp;<span class="visualBasic__string">&quot;&quot;</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;sBodyLen&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;Int(sBody.Length)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;oAttachs&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Interop.Outlook.Attachments&nbsp;=&nbsp;oMsg.Attachments&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;oAttach&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Interop.Outlook.Attachment&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;oAttach&nbsp;=&nbsp;oAttachs.Add(strS,&nbsp;,&nbsp;sBodyLen,&nbsp;strN)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;oMsg.Send()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="visualBasic__string">&quot;Email&nbsp;Send&quot;</span>,&nbsp;<span class="visualBasic__keyword">Me</span>.Text,&nbsp;MessageBoxButtons.OK,&nbsp;MessageBoxIcon.Exclamation)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span></pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>source code file name #1 - summary for this source code file.</em> </li></ul>
<h1>More Information</h1>
<p><em>For more information on X, see ...?</em></p>
