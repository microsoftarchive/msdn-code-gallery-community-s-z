# Workflow Studio for WF 4.5
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- Windows Workflow 4.5
- .NET 4.5
## Topics
- Workflow Designer Hosting
## Updated
- 11/07/2012
## Description

<h1>Introduction</h1>
<p>Rehosting the WF designer in an application outside of Visual Studio is nothing new and since WF4, nothing particularly difficult. In fact the WF product team has gone out of its way to make rehosting the designer as easy an experience as possible and they&rsquo;ve
 done a great job. The <a href="http://msdn.microsoft.com/en-us/library/dd483375.aspx">
WCF and WF Samples for .NET Framework 4</a> provides code samples for rehosting the designer with its corresponding toolbox and properties grid. The samples also cover handling validation errors, executing workflows and providing some level of debugging through
 workflow tracking &ndash; most of what you need to write your own rehosted designer.</p>
<div>
<p>But to get a useable app you&rsquo;re going to have to write some boiler plate code to stitch all these concepts together. You&rsquo;ll need code to open, save and execute workflows. You&rsquo;ll need to manage window layout, display workflow output and
 handle runtime exceptions. And wouldn't it be nice to support working with multiple workflows at the same time all in a windowing environment that supports docking and pinning?</p>
</div>
<div>
<p>Enter <span style="font-style:italic">Workflow Studio</span><span> </span>&ndash; a simple, generic application that allows you to design and execute multiple XAML based workflows in a windowed environment akin with Visual Studio. Use it to design and test
 your workflows in environments where Visual Studio is not the right tool. You can even use it as a simple hosting environment. I&rsquo;ve developed Workflow Studio as an application you can use out of the box, or you can use it as the basis for your own specialised
 implementation.</p>
<h1>Workflow Studio for WF 4.5</h1>
</div>
<p>.NET 4.5 has introduced some great new features to improve the usability of the Workflow designer. If you&rsquo;re rehosting the designer outside of Visual Studio then you can take advantage of most of these features very easily which is what I have done
 with Workflow Studio. If you&rsquo;ve read my <a href="http://blogs.msdn.com/b/mcsuksoldev/archive/2012/03/26/workflow-foundation-wf4-rehosting-the-workflow-designer.aspx">
previous post</a>&nbsp;you&rsquo;ll know that Workflow Studio is a rehosted WF designer implementation that allows you to execute and debug workflows in a windowing environment that supports docking and pinning (courtesy of
<a href="http://avalondock.codeplex.com/">AvalonDock</a>).</p>
<p><span>Workflow </span><span>Studio for WF 4.5 is a minor update to the original Workflow Studio for WF 4 and the blog post that supports this sample can be found
<a title="here" href="http://blogs.msdn.com/b/mcsuksoldev/archive/2012/11/07/workflow-foundation-wf-4-5-designer-improvements.aspx">
here</a>. You can download the original version of Workflow Studio for WF 4 <a title="here" href="http://code.msdn.microsoft.com/Workflow-Studio-df1d7dc0">
here</a>.</span></p>
