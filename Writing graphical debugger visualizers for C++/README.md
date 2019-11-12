# Writing graphical debugger visualizers for C++
## Requires
- Visual Studio 2012
## License
- MS-LPL
## Technologies
- Visual Studio 2012
## Topics
- Debugger Extensibility
## Updated
- 02/07/2013
## Description

<h1>Introduction</h1>
<p style="text-align:justify">Visual Studio 2012 introduces support for graphical debugger visualizer plugins for native types. These visualizers allow developers to view a variable or an object in a custom user interface that is appropriate for the data type.
 They complement the existing visualizers that have been used in Visual Studio debugger (e.g. built-in text, HTML, XML visualizers and the visualizers for .NET objects).</p>
<p style="text-align:justify">This sample project demonstrates how to create a simple native visualizer for std::vector&lt;int&gt; objects. The visualizer is packaged in a VSIX that can be easily deployed to a user&rsquo;s machine.&nbsp;</p>
<h1><span>Building the Sample</span></h1>
<p style="text-align:justify">You need to have Visual Studio 2012 SDK in order to open and build the project in this sample. You can download it from
<a href="http://www.microsoft.com/en-us/download/details.aspx?id=30668">http://www.microsoft.com/en-us/download/details.aspx?id=30668</a>.</p>
<h1><span style="font-size:20px; font-weight:bold">Description</span></h1>
<p>The following sections briefly explain the steps involved in creating a graphical debugger visualizer:</p>
<h4>1.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Create a VSPackage to host the visualizer service</h4>
<p style="text-align:justify">The visualizer code must be contained in a package which will be loaded by the debugger when needed. You can create your visualizer project based on the &ldquo;Visual Studio Package&rdquo; template to help with this. Note that
 you can implement this VSPackage in different programming languages (this sample uses C#). You can just pick the language of your choice in Visual Studio Package Wizard when you are creating the project.</p>
<h4>2.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Declare the service to be consumed by the debugger</h4>
<p style="text-align:justify">The created package must proffer a service to be consumed by the debugger. The relevant code that defines the service in the sample is in VectorVisualizerPackage.cs and shown below. The important point to note below is the GUID
 for the IVectorVisualizerService which will be used in the next step.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
<span class="cs__com">///&nbsp;Vector&nbsp;visualizer&nbsp;service&nbsp;exposed&nbsp;by&nbsp;the&nbsp;package</span>&nbsp;
<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
[Guid(<span class="cs__string">&quot;5452AFEA-3DF6-46BB-9177-C0B08F318025&quot;</span>)]&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">interface</span>&nbsp;IVectorVisualizerService&nbsp;{&nbsp;}&nbsp;
&nbsp;
[PackageRegistration(UseManagedResourcesOnly&nbsp;=&nbsp;<span class="cs__keyword">true</span>)]&nbsp;
[ProvideService(<span class="cs__keyword">typeof</span>(IVectorVisualizerService),&nbsp;ServiceName&nbsp;=&nbsp;<span class="cs__string">&quot;VectorVisualizerService&quot;</span>)]&nbsp;
[InstalledProductRegistration(<span class="cs__string">&quot;Vector&nbsp;Visualizer&nbsp;Sample&quot;</span>,&nbsp;<span class="cs__string">&quot;Vector&nbsp;Visualizer&nbsp;Sample&quot;</span>,&nbsp;<span class="cs__string">&quot;1.0&quot;</span>)]&nbsp;
[Guid(<span class="cs__string">&quot;C37A4CFC-670F-454A-B40E-AC08578ABABD&quot;</span>)]&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">sealed</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;VectorVisualizerPackage&nbsp;:&nbsp;Package&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Initialization&nbsp;of&nbsp;the&nbsp;package;&nbsp;register&nbsp;vector&nbsp;visualizer&nbsp;service</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Initialize()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">base</span>.Initialize();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IServiceContainer&nbsp;serviceContainer&nbsp;=&nbsp;(IServiceContainer)<span class="cs__keyword">this</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(serviceContainer&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;serviceContainer.AddService(<span class="cs__keyword">typeof</span>(IVectorVisualizerService),&nbsp;<span class="cs__keyword">new</span>&nbsp;VectorVisualizerService(),&nbsp;<span class="cs__keyword">true</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<h4>3.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Define the visualizer and its applicable types in the natvis file</h4>
<p style="text-align:justify">In order to register the visualizer with the debugger and to declare the types it can handle, a natvis file must be used (please see
<a href="http://code.msdn.microsoft.com/Writing-type-visualizers-2eae77a2">http://code.msdn.microsoft.com/Writing-type-visualizers-2eae77a2</a> for more information on natvis files). The debugger reads the entries in this file to match types viewed in the debugger
 with the registered visualizers. The following shows the natvis file used by the sample. Note that the guid of the service declared in the previous step is used here:</p>
<h1>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>

<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;?xml</span><span class="xml__attr_name">version</span>=<span class="xml__attr_value">&quot;1.0&quot;</span><span class="xml__attr_name">encoding</span>=<span class="xml__attr_value">&quot;utf-8&quot;</span><span class="xml__tag_start">?&gt;</span><span class="xml__tag_start">&lt;AutoVisualizer</span><span class="xml__attr_name">xmlns</span>=<span class="xml__attr_value">&quot;http://schemas.microsoft.com/vstudio/debugger/natvis/2010&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span><span class="xml__tag_start">&lt;UIVisualizer</span><span class="xml__attr_name">ServiceId</span>=<span class="xml__attr_value">&quot;{5452AFEA-3DF6-46BB-9177-C0B08F318025}&quot;</span><span class="xml__attr_name">Id</span>=<span class="xml__attr_value">&quot;1&quot;</span><span class="xml__attr_name">MenuName</span>=<span class="xml__attr_value">&quot;Vector&nbsp;Visualizer&quot;</span><span class="xml__tag_start">/&gt;</span><span class="xml__tag_start">&lt;Type</span><span class="xml__attr_name">Name</span>=<span class="xml__attr_value">&quot;std::vector&amp;lt;int,*&amp;gt;&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span><span class="xml__tag_start">&lt;UIVisualizer</span><span class="xml__attr_name">ServiceId</span>=<span class="xml__attr_value">&quot;{5452AFEA-3DF6-46BB-9177-C0B08F318025}&quot;</span><span class="xml__attr_name">Id</span>=<span class="xml__attr_value">&quot;1&quot;</span><span class="xml__tag_start">/&gt;</span><span class="xml__tag_end">&lt;/Type&gt;</span><span class="xml__tag_end">&lt;/AutoVisualizer&gt;</span></pre>
</div>
</div>
</div>
</h1>
<p style="text-align:justify">A <strong>UIVisualizer</strong> is identified by a <strong>
ServiceId</strong> - <strong>Id</strong> pair. <strong>ServiceId</strong> is the GUID of the service exposed by the visualizer package, Id is a unique identifier that can be used to differentiate visualizers if a service provides more than one visualizer.
<strong>MenuName</strong> attribute is what the users see as the name of the visualizer when they open the dropdown next to the magnifying glass icon in a debugger variable window.</p>
<p style="text-align:justify">Each type defined in the natvis file must explicitly list the visualizers that can display them. The debugger reads the visualizer references in the type entries to match types with the registered visualizers.</p>
<p style="text-align:justify">For VSIX deployment, a NativeVisualizer asset needs to be added to the project. This file should also be included in the extension manifest and the VSIX (i.e. set 'Build Action' to 'Content' and 'Include in VSIX' attribute to true).
 The following shows the related section in source.extension.vsixmanifest:</p>
<h1>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>

<div class="preview">
<pre class="js">&lt;?xml&nbsp;version=<span class="js__string">&quot;1.0&quot;</span>&nbsp;encoding=<span class="js__string">&quot;utf-8&quot;</span>?&gt;&nbsp;
&lt;PackageManifest&nbsp;Version=<span class="js__string">&quot;2.0.0&quot;</span>&nbsp;xmlns=<span class="js__string">&quot;http://schemas.microsoft.com/developer/vsx-schema/2011&quot;</span>&nbsp;xmlns:d=<span class="js__string">&quot;http://schemas.microsoft.com/developer/vsx-schema-design/2011&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;.&nbsp;
&nbsp;&nbsp;.&nbsp;
&nbsp;&nbsp;.&nbsp;
&nbsp;&nbsp;&lt;Assets&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Asset&nbsp;Type=<span class="js__string">&quot;NativeVisualizer&quot;</span>&nbsp;Path=<span class="js__string">&quot;VectorVisualizer.xml&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Asset&nbsp;Type=<span class="js__string">&quot;Microsoft.VisualStudio.VsPackage&quot;</span>&nbsp;d:Source=<span class="js__string">&quot;Project&quot;</span>&nbsp;d:ProjectName=<span class="js__string">&quot;%CurrentProject%&quot;</span>&nbsp;Path=<span class="js__string">&quot;|%CurrentProject%;PkgdefProjectOutputGroup|&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&lt;/Assets&gt;&nbsp;
&lt;/PackageManifest&gt;&nbsp;
</pre>
</div>
</div>
</div>
</h1>
<h4>4. &nbsp; &nbsp; &nbsp;Implement the visualizer service</h4>
<p style="text-align:justify">The service object exposed by the package must implement IVsCppDebugUIVisualizer interface (defined in Microsoft.VisualStudio.Debugger.Interop.11.0) which will be called by the debugger when the user requests visualization on an
 object. This interface has one DisplayValue method that is implemented in VectorVisualizerService.cs:</p>
<h1>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">///&nbsp;&lt;summary&gt;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;Plots&nbsp;the&nbsp;given&nbsp;vector&nbsp;contents&nbsp;in&nbsp;a&nbsp;modal&nbsp;window</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;/summary&gt;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;param&nbsp;name=&quot;ownerHwnd&quot;&gt;Parent&nbsp;window&nbsp;hwnd&lt;/param&gt;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;param&nbsp;name=&quot;visualizerId&quot;&gt;The&nbsp;visualizer&nbsp;id&nbsp;to&nbsp;use&lt;/param&gt;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;param&nbsp;name=&quot;debugProperty&quot;&gt;DebugProperty&nbsp;for&nbsp;a&nbsp;vector&nbsp;object&lt;/param&gt;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;returns&gt;An&nbsp;HRESULT&lt;/returns&gt;</span>&nbsp;
public&nbsp;int&nbsp;DisplayValue(uint&nbsp;ownerHwnd,&nbsp;uint&nbsp;visualizerId,&nbsp;IDebugProperty3&nbsp;debugProperty)&nbsp;
</pre>
</div>
</div>
</div>
</h1>
<p style="text-align:justify">The method is passed an <a href="http://msdn.microsoft.com/en-us/library/bb147018(v=vs.110).aspx">
IDebugProperty3</a> reference which represents the variable being visualized in the debugger variable windows.&nbsp; Using this interface you can get the property values, enumerate children properties shown in the debugger windows to help visualize the variable.
 For instance, the sample visualizer uses IDebugProperty3 methods to get the values of _Myfirst and _Mylast fields of the vector type. After that it uses IDebugMemoryContext2, IDebugMemoryBytes2 interface methods to read the debuggee memory pointed to by the
 _Myfirst field that contains the elements in the vector. Lastly, it display the values read using a chart control.</p>
<h4>5. &nbsp; &nbsp; &nbsp;Test the visualizer</h4>
<p style="text-align:justify">After you&rsquo;ve built the project, you can test it in the experimental instance of Visual Studio. Using the simple code snippet below, put a breakpoint on the return statement, and start debugging in the experimental instance.
 Launch the visualizer on myVector variable, and</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre class="cplusplus"><span class="cpp__keyword">void</span>&nbsp;main()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;std::vector&lt;<span class="cpp__datatype">int</span>&gt;&nbsp;myVector;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">for</span>&nbsp;(<span class="cpp__datatype">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;<span class="cpp__number">100</span>;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;myVector.push_back(&nbsp;((i&nbsp;-&nbsp;<span class="cpp__number">50</span>)&nbsp;*&nbsp;(i&nbsp;-&nbsp;<span class="cpp__number">50</span>)));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>;&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<p>you should see the following chart that plots the values contained in the myVector variable:</p>
<p><img id="64457" src="64457-untitled.png" alt="" width="613" height="376"></p>
