# Samples for Solid Edge
## Requires
- Visual Studio 2012
## License
- MS-LPL
## Technologies
- COM
- Windows General
## Topics
- COM
- COM Interop
## Updated
- 05/13/2013
## Description

<h1>Introduction</h1>
<p><em>Samples for Solid Edge is a CodePlex project whose goal is to provide high quality examples of automating Solid Edge using .NET technologies. Having the samples hosted in MSDN in addition to CodePlex allows developers to quickly and easily get the samples
 installed and running. The samples provided range from automating Solid Edge from an external application to creating an integrated addin.</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>The main solution contains numerous projects stored in folders named by their purpose. After successfully building the solution, simply set the startup project and begin debugging the samples.</em></p>
<h1><span style="font-size:20px; font-weight:bold">Description</span></h1>
<p><em>Solid Edge's API is a COM based API. Automating Solid Edge using .NET technologies can be difficult due to various COM Interop scenarios. The projects in this solution offer high quality solutions to common automation needs.</em></p>
<p><em>The following is a small example of a console application automating Solid Edge using Visual Basic.</em></p>
<p><em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Imports</span>&nbsp;System.Text&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Runtime.InteropServices&nbsp;
&nbsp;
<span class="visualBasic__keyword">Namespace</span>&nbsp;SolidEdge.Automation&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;Console&nbsp;application&nbsp;demonstrating&nbsp;basic&nbsp;Solid&nbsp;Edge&nbsp;automation.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Friend</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;Program&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;STAThread&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Shared</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;Main(<span class="visualBasic__keyword">ByVal</span>&nbsp;args()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;application&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;SolidEdgeFramework.Application&nbsp;=&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;documents&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;SolidEdgeFramework.Documents&nbsp;=&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;document&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;SolidEdgeFramework.SolidEdgeDocument&nbsp;=&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="visualBasic__string">&quot;Registering&nbsp;OleMessageFilter.&quot;</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Register&nbsp;with&nbsp;OLE&nbsp;to&nbsp;handle&nbsp;concurrency&nbsp;issues&nbsp;on&nbsp;the&nbsp;current&nbsp;thread.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OleMessageFilter.Register()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="visualBasic__string">&quot;Connecting&nbsp;to&nbsp;Solid&nbsp;Edge.&quot;</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Connect&nbsp;to&nbsp;or&nbsp;start&nbsp;Solid&nbsp;Edge.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;application&nbsp;=&nbsp;SolidEdgeUtils.Connect(<span class="visualBasic__keyword">True</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Ensure&nbsp;Solid&nbsp;Edge&nbsp;GUI&nbsp;is&nbsp;visible.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;application.Visible&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Bring&nbsp;Solid&nbsp;Edge&nbsp;to&nbsp;the&nbsp;foreground.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;application.Activate()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Get&nbsp;a&nbsp;reference&nbsp;to&nbsp;the&nbsp;documents&nbsp;collection.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;documents&nbsp;=&nbsp;application.Documents&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="visualBasic__string">&quot;Creating&nbsp;a&nbsp;new&nbsp;part&nbsp;document.&nbsp;&nbsp;No&nbsp;template&nbsp;specified.&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document&nbsp;=&nbsp;<span class="visualBasic__keyword">CType</span>(documents.Add(<span class="visualBasic__string">&quot;SolidEdge.PartDocument&quot;</span>),&nbsp;SolidEdgeFramework.SolidEdgeDocument)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Catch</span>&nbsp;ex&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Exception.aspx" target="_blank" title="Auto generated link to System.Exception">System.Exception</a><span class="visualBasic__preproc">&nbsp;
#If&nbsp;DEBUG&nbsp;Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Diagnostics.Debugger.Break.aspx" target="_blank" title="Auto generated link to System.Diagnostics.Debugger.Break">System.Diagnostics.Debugger.Break</a>()<span class="visualBasic__preproc">&nbsp;
#End&nbsp;If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(ex.Message)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Namespace</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
</em>
<p></p>
<h1>More Information</h1>
<p><em>The project is hosted at&nbsp;<a title="http://solidedgesamples.codeplex.com" href="http://solidedgesamples.codeplex.com" target="_blank">http://solidedgesamples.codeplex.com</a>. The solution references
<a title="Interop.SolidEdge.dll" href="http://nuget.org/packages/Interop.SolidEdge" target="_blank">
Interop.SolidEdge.dll</a> which is hosted at&nbsp;<a title="http://solidedgeinterop.codeplex.com" href="http://solidedgeinterop.codeplex.com" target="_blank">http://solidedgeinterop.codeplex.com</a>&nbsp;and is also available on NuGet at&nbsp;<a title="http://nuget.org/packages/Interop.SolidEdge" href="http://nuget.org/packages/Interop.SolidEdge" target="_blank">http://nuget.org/packages/Interop.SolidEdge</a>.</em></p>
<p><em>You can learn more about Solid Edge at&nbsp;<a title="www.solidedge.com" href="http://www.solidedge.com" target="_blank">www.solidedge.com</a>.</em></p>
