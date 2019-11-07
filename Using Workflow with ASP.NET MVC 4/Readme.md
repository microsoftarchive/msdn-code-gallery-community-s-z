# Using Workflow with ASP.NET MVC 4
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- Windows Workflow
- WF
- WF4
- ASP.NET MVC 4
## Topics
- Workflow
- ASP.NET MVC
## Updated
- 04/11/2012
## Description

<h1>Introduction</h1>
<p>This sample demonstrates how you can invoke a Workflow from an MVC 4 controller and write to the ViewBag/ViewData from the workflow.<em><br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p>This sample requires</p>
<ul>
<li><a href="http://www.asp.net/mvc/mvc4">ASP.NET MVC 4</a>&nbsp; </li><li><a href="http://wf.codeplex.com/wikipage?title=Microsoft.Activities%20Overview&referringTitle=Documentation">Microsoft.Activities.Extensions</a> (included)
</li></ul>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>This simple &quot;Hello World&quot; workflow adds to the ViewBag a greeting property created from a workflow.&nbsp; In .NET 4 expressions in Workflow are always in Visual Basic.&nbsp; The MVC object ViewBag is a C# dynamic object which cannot be used from Visual Basic.&nbsp;
 Fortunately ASP.NET MVC also provides ViewData which is a dictionary that points to the same object.&nbsp; Reading/Writing to ViewData is the same as reading/writing to ViewBag.<em>&nbsp;</em></p>
<p><em><img src="41831-greeting.png" alt="" width="405" height="162"><br>
</em></p>
<p>The workflow is invoked using WorkflowInvoker which makes the call synchronous.&nbsp; You can also use WorkflowApplication but if you do you should inherit from AsyncController.
<em><br>
</em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public ActionResult Index()
{
    // Visual Basic does not support dynamic objects - use ViewData to access the ViewBag

    // Classic way of passing input arguments
    // var input = new Dictionary&lt;string, object&gt; { { &quot;ViewData&quot;, this.ViewData } };

    // More &quot;MVC&quot; like method using Microsoft.Activities.WorkflowArguments
    dynamic input = new WorkflowArguments();

    input.ViewData = this.ViewData;

    // Synchronously invoke the workflow
    // Short-running workflows only.
    WorkflowInvoker.Invoke(HelloMvcDefinition, input);

    // ViewBag contains the result set by the workflow
    // See Views / Hello / Index.cshtml for the related view
    return this.View();
}
</pre>
<div class="preview">
<pre id="codePreview" class="csharp"><span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;Index()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Visual&nbsp;Basic&nbsp;does&nbsp;not&nbsp;support&nbsp;dynamic&nbsp;objects&nbsp;-&nbsp;use&nbsp;ViewData&nbsp;to&nbsp;access&nbsp;the&nbsp;ViewBag</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Classic&nbsp;way&nbsp;of&nbsp;passing&nbsp;input&nbsp;arguments</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;var&nbsp;input&nbsp;=&nbsp;new&nbsp;Dictionary&lt;string,&nbsp;object&gt;&nbsp;{&nbsp;{&nbsp;&quot;ViewData&quot;,&nbsp;this.ViewData&nbsp;}&nbsp;};</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;More&nbsp;&quot;MVC&quot;&nbsp;like&nbsp;method&nbsp;using&nbsp;Microsoft.Activities.WorkflowArguments</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;dynamic&nbsp;input&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;WorkflowArguments();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;input.ViewData&nbsp;=&nbsp;<span class="cs__keyword">this</span>.ViewData;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Synchronously&nbsp;invoke&nbsp;the&nbsp;workflow</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Short-running&nbsp;workflows&nbsp;only.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;WorkflowInvoker.Invoke(HelloMvcDefinition,&nbsp;input);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;ViewBag&nbsp;contains&nbsp;the&nbsp;result&nbsp;set&nbsp;by&nbsp;the&nbsp;workflow</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;See&nbsp;Views&nbsp;/&nbsp;Hello&nbsp;/&nbsp;Index.cshtml&nbsp;for&nbsp;the&nbsp;related&nbsp;view</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">this</span>.View();&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<p>The Hello view simply accesses the greeting from the ViewBag.&nbsp; The controller has already invoked the workflow which has executed prior to displaying the view.</p>
<h1>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>
<pre class="hidden">@{
    ViewBag.Title = &quot;Hello&quot;;
}
&lt;h2&gt;
    Hello&lt;/h2&gt;
&lt;p&gt;
    Workflow said @ViewBag.Greeting
&lt;/p&gt;
</pre>
<div class="preview">
<pre id="codePreview" class="html">@{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ViewBag.Title&nbsp;=&nbsp;&quot;Hello&quot;;&nbsp;
}&nbsp;
<span class="html__tag_start">&lt;h2</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;Hello<span class="html__tag_end">&lt;/h2&gt;</span>&nbsp;
<span class="html__tag_start">&lt;p</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;Workflow&nbsp;said&nbsp;@ViewBag.Greeting&nbsp;
<span class="html__tag_end">&lt;/p&gt;</span>&nbsp;
</pre>
</div>
</div>
</div>
<span>Source Code Files</span></h1>
<p><span>This sample is the basic ASP.NET MVC 4&nbsp;template plus a couple of additional files<br>
</span></p>
<ul>
<li>Views / Hello / Index.cshtml - contains thew view </li><li>Controllers / HelloController.cs - contains the controller </li></ul>
<h1>More Information</h1>
<p>This sample is part of a larger project to explore the integration of Workflow with ASP.NET MVC.&nbsp; More information is available at
<a href="http://wfmvc.codeplex.com">http://wfmvc.codeplex.com</a></p>
