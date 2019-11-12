# Using a .NET 4 Based DLL From a .NET 2 Based Application
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- Interop
- .NET Framework 4.0
## Topics
- Interop
- COM Interop
- .NET 4
- .NET 2
- In-process SxS
## Updated
- 05/30/2011
## Description

<h1>Introduction</h1>
<div><em>There are times when you ask yourself the question: How can you use a .NET 4 DLL from a .NET 2 application? and vice versa?</em></div>
<div>Personally I&rsquo;ve encountered two scenarios when I had to solve this problem:</div>
<ol>
<li>I had a 3rd-party control that would load only in a .NET 3.5 application, but I had to use it in a .NET 4 application.
</li><li>I wanted to write a plug-in for Windows Live Writer, which must use .NET 2.0, but I needed to use in my plug-in a .NET 4 DLL.
</li></ol>
<div>The official answer is you can&rsquo;t. Even with the <a href="http://msdn.microsoft.com/en-us/library/ee518876.aspx">
In-Process Side by Side execution</a> (SxS) feature, introduced in .NET 4.</div>
<div></div>
<div>The SxS feature was intended to be used when <a href="http://en.wikipedia.org/wiki/Component_Object_Model">
COM</a> is involved. <br>
For example, if you got an application that loads plugins, like outlook, and it loads 2 COM plugins, one is using .NET 4 and the other is using .NET 2.0 then it will load two versions of the CLR into the process using the new SxS feature.</div>
<div></div>
<div><strong><em>&nbsp;</em></strong></div>
<div><strong><em>So, what can we do if no COM is involved?</em></strong></div>
<div></div>
<div>Well, simply add <strong>COM</strong> to the mixture..</div>
<div></div>
<div>The idea is that you can expose the required classes from your DLL (which uses .NET Framework X) as COM classes (using
<a href="http://msdn.microsoft.com/en-us/library/aa645736(v=vs.71).aspx">COM Interop</a>), and then use those classes from your other DLL (which uses .NET Framework Y). Since you are crossing a COM interface, in-process SxS will kick in and work its magic.</div>
<div><span>&nbsp;</span></div>
<h1><span>&nbsp;</span></h1>
<h1><span>Building the Sample</span></h1>
<div><em>Simply compile and run the solution. It contains the following three projects:</em></div>
<ol>
<li><em>Net2Assembly - host application written with .NET 2</em> </li><li><em>Net4Assembly - DLL written with .NET 4</em> </li><li><em>Net4ToNet2Adapter - DLL which helps exposing the Net4Assembly to Net2Assembly</em>
</li></ol>
<h1><span style="font-size:medium"><em>Steps to work around the problem</em></span></h1>
<h2><em>Create a .NET 4 DLL</em></h2>
<div><em>Suppose we have a .NET 4 DLL which does some .NET 4 functionality. In the attached sample our .NET 4 class prints the CLR version, which should be 4. This DLL is compiled with .NET Framework 4.</em></div>
<div><em>
<h2 class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;Net4Assembly&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;MyClass&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;DoNet4Action()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;CLR&nbsp;version&nbsp;from&nbsp;DLL:&nbsp;{0}&quot;</span>,&nbsp;Environment.Version);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</h2>
<h2>Create a .NET 2 EXE</h2>
<div></div>
</em>
<div>Here we create a .NET 2 EXE which will eventually call the .NET 4 DLL, currently all it does is write it&rsquo;s own CLR version.</div>
</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;Net2Assembly&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Program&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;CLR&nbsp;version&nbsp;from&nbsp;EXE:&nbsp;{0}&quot;</span>,&nbsp;Environment.Version);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
<h2 class="endscriptcode">Create a .NET 4 to .NET 2 adapter</h2>
<div>Here we create a .NET 4 DLL that exposes the same functionality we need from our original .NET 4 DLL only it exposes it in a COM-friendly way. In this sample, it only needs to delegate the call to the original implementation, but in more advanced scenarios
 it should translate the parameters to something more COM friendly. In addition to changing the parameters the classes also implement interfaces (as required by COM) and are marked with
<strong><a href="http://msdn.microsoft.com/en-us/library/system.runtime.interopservices.comvisibleattribute.aspx">ComVisible</a>
</strong>and <strong><a href="http://msdn.microsoft.com/en-us/library/system.runtime.interopservices.guidattribute.aspx">Guid</a>
</strong>attributes to allow access using COM.</div>
<div>
<p>Here is our COM visible interface:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Runtime.InteropServices.aspx" target="_blank" title="Auto generated link to System.Runtime.InteropServices">System.Runtime.InteropServices</a>;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;Net4ToNet2Adapter&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[ComVisible(<span class="cs__keyword">true</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[Guid(<span class="cs__string">&quot;E36BBF07-591E-4959-97AE-D439CBA392FB&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">interface</span>&nbsp;IMyClassAdapter&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">void</span>&nbsp;DoNet4Action();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">And our COM visible class, which delegates its calls to the original class.</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Runtime.InteropServices.aspx" target="_blank" title="Auto generated link to System.Runtime.InteropServices">System.Runtime.InteropServices</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Net4Assembly;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;Net4ToNet2Adapter&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[ComVisible(<span class="cs__keyword">true</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[Guid(<span class="cs__string">&quot;A6574755-925A-4E41-A01B-B6A0EEF72DF0&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;MyClassAdapter&nbsp;:&nbsp;IMyClassAdapter&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;MyClass&nbsp;_myClass&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MyClass();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;DoNet4Action()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_myClass.DoNet4Action();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode"><span style="text-decoration:underline">Note</span>: we could have combined
<strong>Net4Assembly.MyClass </strong>and <strong>Net4ToNet2Adapter.MyClassAdapter</strong> into the same class but I wanted to keep the example general. In real life application you often can&rsquo;t change the original object and thus you are forced to create
 a wrapper.</div>
<div class="endscriptcode"></div>
<h2 class="endscriptcode">Add support to the adapter for registration-free COM activation&nbsp;</h2>
<p><span style="text-decoration:underline">Important note</span>: this part is not really necessary for the .NET 4 to .NET 2 interop to work. But without it you will need to start using he registry for registering your .NET COM components and most projects
 would rather to avoid it if possible. If this is not a problem just register your objects in the registry and move to the next step.</p>
<p>To add support for registration-free COM we need to create two application manifest files.</p>
<p>The first application manifest specifies dependent assemblies for the client executable. Note that since this manifest replaces the default .NET manifest I&rsquo;ve added some extra standard manifest stuff (trustinfo), but only the first part is really needed
 for the registration-free COM to work. To add it, add a file to the client project named
<strong>app.manifest </strong>(&ldquo;Add new item&rdquo; &ndash;&gt; &ldquo;Application Manifest&rdquo;) and change the project properties to use this file.</p>
<p>Following is the content of <strong>app.manifest </strong>for the <strong>Net2Aseembly.exe</strong> client in our example:&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>

<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;?xml</span>&nbsp;<span class="xml__attr_name">version</span>=<span class="xml__attr_value">&quot;1.0&quot;</span>&nbsp;<span class="xml__attr_name">encoding</span>=<span class="xml__attr_value">&quot;UTF-8&quot;</span>&nbsp;<span class="xml__attr_name">standalone</span>=<span class="xml__attr_value">&quot;yes&quot;</span><span class="xml__tag_start">?&gt;</span>&nbsp;
<span class="xml__tag_start">&lt;assembly</span>&nbsp;
&nbsp;&nbsp;<span class="xml__attr_name">xmlns</span>=<span class="xml__attr_value">&quot;urn:schemas-microsoft-com:asm.v1&quot;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__attr_name">manifestVersion</span>=<span class="xml__attr_value">&quot;1.0&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;<span class="xml__tag_start">&lt;assemblyIdentity</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__attr_name">type</span>&nbsp;=&nbsp;<span class="xml__attr_value">&quot;win32&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__attr_name">name</span>&nbsp;=&nbsp;<span class="xml__attr_value">&quot;Net2Assembly&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__attr_name">version</span>&nbsp;=&nbsp;<span class="xml__attr_value">&quot;1.0.0.0&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_start">&lt;dependency</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;dependentAssembly</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;assemblyIdentity</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__attr_name">type</span>=<span class="xml__attr_value">&quot;win32&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;Net4ToNet2Adapter&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__attr_name">version</span>=<span class="xml__attr_value">&quot;1.0.0.0&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/dependentAssembly&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_end">&lt;/dependency&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;<span class="xml__tag_start">&lt;trustInfo</span>&nbsp;<span class="xml__attr_name">xmlns</span>=<span class="xml__attr_value">&quot;urn:schemas-microsoft-com:asm.v2&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;security</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;requestedPrivileges</span>&nbsp;<span class="xml__attr_name">xmlns</span>=<span class="xml__attr_value">&quot;urn:schemas-microsoft-com:asm.v3&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__comment">&lt;!--&nbsp;UAC&nbsp;Manifest&nbsp;Options&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;If&nbsp;you&nbsp;want&nbsp;to&nbsp;change&nbsp;the&nbsp;Windows&nbsp;User&nbsp;Account&nbsp;Control&nbsp;level&nbsp;replace&nbsp;the&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;requestedExecutionLevel&nbsp;node&nbsp;with&nbsp;one&nbsp;of&nbsp;the&nbsp;following.&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;requestedExecutionLevel&nbsp;&nbsp;level=&quot;asInvoker&quot;&nbsp;uiAccess=&quot;false&quot;&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;requestedExecutionLevel&nbsp;&nbsp;level=&quot;requireAdministrator&quot;&nbsp;uiAccess=&quot;false&quot;&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;requestedExecutionLevel&nbsp;&nbsp;level=&quot;highestAvailable&quot;&nbsp;uiAccess=&quot;false&quot;&nbsp;/&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;If&nbsp;you&nbsp;want&nbsp;to&nbsp;utilize&nbsp;File&nbsp;and&nbsp;Registry&nbsp;Virtualization&nbsp;for&nbsp;backward&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;compatibility&nbsp;then&nbsp;delete&nbsp;the&nbsp;requestedExecutionLevel&nbsp;node.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;requestedExecutionLevel</span>&nbsp;<span class="xml__attr_name">level</span>=<span class="xml__attr_value">&quot;asInvoker&quot;</span>&nbsp;<span class="xml__attr_name">uiAccess</span>=<span class="xml__attr_value">&quot;false&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/requestedPrivileges&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/security&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_end">&lt;/trustInfo&gt;</span>&nbsp;
<span class="xml__tag_end">&lt;/assembly&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">The second application manifest, describes the COM components which are exposed in the assembly. It needs to be set as the application manifest which resides as a native Win32 resource inside the DLL.&nbsp;</div>
<div class="endscriptcode"><br>
Unfortunately, this can&rsquo;t be done as easily as the previous manifest. In <strong>
Visual Studio 2010</strong>, the relevant field in the project <br>
properties is disabled when the project is of type <strong>Class Library</strong>. So we must go to the
<strong>Net4ToNet2Adapter.csproj <br>
</strong>file and change it ourselves. The change is easy, just add the following lines in the relevant place:</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>

<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;PropertyGroup</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;<span class="xml__tag_start">&lt;ApplicationManifest</span><span class="xml__tag_start">&gt;</span>app.manifest<span class="xml__tag_end">&lt;/ApplicationManifest&gt;</span>&nbsp;
<span class="xml__tag_end">&lt;/PropertyGroup&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">Following is the content of <strong>app.manifest</strong> for the
<strong>Net4ToNet2Adapter.dll</strong> in our example:</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>

<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;?xml</span>&nbsp;<span class="xml__attr_name">version</span>=<span class="xml__attr_value">&quot;1.0&quot;</span>&nbsp;<span class="xml__attr_name">encoding</span>=<span class="xml__attr_value">&quot;UTF-8&quot;</span>&nbsp;<span class="xml__attr_name">standalone</span>=<span class="xml__attr_value">&quot;yes&quot;</span><span class="xml__tag_start">?&gt;</span>&nbsp;
<span class="xml__tag_start">&lt;assembly</span>&nbsp;<span class="xml__attr_name">xmlns</span>=<span class="xml__attr_value">&quot;urn:schemas-microsoft-com:asm.v1&quot;</span>&nbsp;<span class="xml__attr_name">manifestVersion</span>=<span class="xml__attr_value">&quot;1.0&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;<span class="xml__tag_start">&lt;assemblyIdentity</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__attr_name">type</span>=<span class="xml__attr_value">&quot;win32&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;Net4ToNet2Adapter&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__attr_name">version</span>=<span class="xml__attr_value">&quot;1.0.0.0&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_start">&lt;clrClass</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__attr_name">clsid</span>=<span class="xml__attr_value">&quot;{A6574755-925A-4E41-A01B-B6A0EEF72DF0}&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__attr_name">progid</span>=<span class="xml__attr_value">&quot;Net4ToNet2Adapter.MyClassAdapter&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__attr_name">threadingModel</span>=<span class="xml__attr_value">&quot;Both&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;Net4ToNet2Adapter.MyClassAdapter&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__attr_name">runtimeVersion</span>=<span class="xml__attr_value">&quot;v4.0.30319&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
<span class="xml__tag_end">&lt;/assembly&gt;</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
</div>
<h2 class="endscriptcode">Use our .NET 4 DLL via COM</h2>
<div class="endscriptcode">Now all you need to do is create an instance of your .NET 4 class from your .NET 2 executable using COM:</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Net4ToNet2Adapter;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;Net2Assembly&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Program&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;CLR&nbsp;version&nbsp;from&nbsp;EXE:&nbsp;{0}&quot;</span>,&nbsp;Environment.Version);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Type&nbsp;myClassAdapterType&nbsp;=&nbsp;Type.GetTypeFromProgID(<span class="cs__string">&quot;Net4ToNet2Adapter.MyClassAdapter&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">object</span>&nbsp;myClassAdapterInstance&nbsp;=&nbsp;Activator.CreateInstance(myClassAdapterType);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IMyClassAdapter&nbsp;myClassAdapter&nbsp;=&nbsp;(IMyClassAdapter)myClassAdapterInstance;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;myClassAdapter.DoNet4Action();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="text-decoration:underline">Note</span>: Since the interface
<strong>IMyClassAdapter</strong> should be duplicated in the client, I&rsquo;ve added the source file
<strong>IMyClassAdapter.cs <br>
</strong>as a link to the client project.</div>
</div>
<div class="endscriptcode"></div>
<h2 class="endscriptcode">The result</h2>
<div class="endscriptcode">The result of running this simple console application is:</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><img src="22754-net4netresult.png" alt="" width="846" height="552"></div>
<p>&nbsp;</p>
</div>
<p>There you go, two CLR versions in the same process!</p>
<h1>More Information</h1>
<div><em>The relevant post on my blog: <a href="http://blogs.microsoft.co.il/blogs/arik">
http://blogs.microsoft.co.il/blogs/arik</a></em></div>
