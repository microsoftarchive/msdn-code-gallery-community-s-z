# Using the .NET Process Class
## Requires
- Visual Studio 2010
## License
- Custom
## Technologies
- Windows Forms
- .NET Framework 4.0
## Topics
- Command Line Arguments
- Generics
- Process Events
- Modules
- StringBuilder
## Updated
- 06/07/2011
## Description

<h1>Introduction</h1>
<p><span id="ctl00_ctl00_Content_TabContentPanel_Content_wikiSourceLabel">The Process class is used to perform a variety of tasks such as commandline processing and listing information about currently running processes.</span></p>
<h1><span>Building the Sample</span></h1>
<p>Press F5</p>
<h1>Description</h1>
<p>The Process class is used to perform the following tasks:</p>
<ul>
<li>
<p>Run an application with and without command-line arguments by using the Start method.</p>
</li><li>
<p>List all the running applications by using the GetProcesses method.</p>
</li><li>
<p>List the loaded modules by using the Modules property.</p>
</li><li>
<p>Retrieve information about the running application by using the GetCurrentProcess method.</p>
</li></ul>
<p>The sample also demonstrates some programming techniques with the StringBuilder and generic List<span class="cs">&lt;</span><span class="vb">(Of
</span><span class="cpp">&lt;</span><span class="nu">(</span>T<span class="cs">&gt;</span><span class="vb">)</span><span class="cpp">&gt;</span><span class="nu">)</span> classes.</p>
<h1>Screenshot</h1>
<p><img src="23127-screenshot.png" alt="" width="489" height="319"></p>
<h1>Sample Code<em></em></h1>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre id="codePreview" class="vb">&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;CurrentProcessInfo_Click(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.EventArgs.aspx" target="_blank" title="Auto generated link to System.EventArgs">System.EventArgs</a>)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;btnCurrentProcessInfo.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Shows&nbsp;how&nbsp;to&nbsp;retrieve&nbsp;information&nbsp;about&nbsp;the&nbsp;current&nbsp;Process.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;curProc&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Process&nbsp;=&nbsp;Process.GetCurrentProcess()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;description&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;<span class="visualBasic__string">&quot;The&nbsp;total&nbsp;working&nbsp;set&nbsp;of&nbsp;the&nbsp;current&nbsp;process&nbsp;is:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;curProc.WorkingSet64.ToString()&nbsp;&#43;&nbsp;vbCrLf&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;description&nbsp;&#43;=&nbsp;<span class="visualBasic__string">&quot;The&nbsp;minimum&nbsp;working&nbsp;set&nbsp;of&nbsp;the&nbsp;current&nbsp;process&nbsp;is:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;curProc.MinWorkingSet.ToString()&nbsp;&#43;&nbsp;vbCrLf&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;description&nbsp;&#43;=&nbsp;<span class="visualBasic__string">&quot;The&nbsp;max&nbsp;working&nbsp;set&nbsp;of&nbsp;the&nbsp;current&nbsp;process&nbsp;is:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;curProc.MaxWorkingSet.ToString()&nbsp;&#43;&nbsp;vbCrLf&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;description&nbsp;&#43;=&nbsp;<span class="visualBasic__string">&quot;The&nbsp;start&nbsp;time&nbsp;of&nbsp;the&nbsp;current&nbsp;process&nbsp;is:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;curProc.StartTime.ToLongTimeString()&nbsp;&#43;&nbsp;vbCrLf&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;description&nbsp;&#43;=&nbsp;<span class="visualBasic__string">&quot;The&nbsp;processor&nbsp;time&nbsp;used&nbsp;by&nbsp;the&nbsp;current&nbsp;process&nbsp;is:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;curProc.TotalProcessorTime.ToString()&nbsp;&#43;&nbsp;vbCrLf&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DisplayText.Text&nbsp;=&nbsp;description&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span></pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><a class="browseFile" href="sourcecode?fileId=23125&pathId=1853820986">MainForm.Designer.vb</a>
</li><li><a class="browseFile" href="sourcecode?fileId=23125&pathId=520100027">MainForm.vb</a>
</li><li><a class="browseFile" href="sourcecode?fileId=23125&pathId=734643353">ModulesDisplay.Designer.vb</a>
</li><li><a class="browseFile" href="sourcecode?fileId=23125&pathId=1060836758">ModulesDisplay.vb</a>
</li><li><a class="browseFile" href="sourcecode?fileId=23125&pathId=1770018561">TaskManager.Designer.vb</a>
</li><li><a class="browseFile" href="sourcecode?fileId=23125&pathId=397761980">TaskManager.vb</a>
</li></ul>
<h1>More Information</h1>
<p>For more information on the Process Class: <a href="http://msdn.microsoft.com/en-us/library/system.diagnostics.process.aspx" target="_blank">
http://msdn.microsoft.com/en-us/library/system.diagnostics.process.aspx</a></p>
