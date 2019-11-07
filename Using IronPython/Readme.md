# Using IronPython
## Requires
- Visual Studio 2010
## License
- Custom
## Technologies
- C#
- Visual Basic .NET
- IronPython
## Topics
- Windows Forms
- IronPython
## Updated
- 06/20/2011
## Description

<h1>Introduction</h1>
<p>This example shows how to integrate Visual Basic 2010 and IronPython using Visual Basic's Late-Binding capabilities and the Dynamic Language Runtime (<em>New in .NET 4</em>).</p>
<h1><span>Building the Sample</span></h1>
<p>To run the sample, you will need to install <a class="externalLink" href="http://ironpython.codeplex.com/releases/view/36280">
IronPython 2.6.1</a>, which is a available as a separate download. It may also work with more recent versions of IronPython.</p>
<p>After installing IronPython you may need to update this sample by replacing the following assembly references:</p>
<ul>
<li><strong>IronPython</strong> </li><li><strong>IronPython.Modules</strong> </li><li><strong>Microsoft.Dynamic</strong> </li><li><strong>Microsoft.Scripting</strong> </li></ul>
<p>To do so:</p>
<ol>
<li>Open the <strong>Project Properties</strong> and navigate to the <strong>References</strong> tab.
</li><li>Remove the assemblies listed above. </li><li>On the <strong>References</strong> tab Choose <strong>Add Reference</strong>.
</li><li>Browse to the directory where you installed IronPython.<br>
<em>By default, IronPython is installed under &quot;C:\Program Files\IronPython 2.6 for .NET 4.0&quot; on 32-bit systems and &quot;C:\Program Files (x86)\IronPython 2.6 for .NET 4.0&quot; on 64-bit systems.</em>
</li><li>Select and add new references to the assemblies listed above. </li></ol>
<p>After you have updated the project references, the program should compile and run without error.</p>
<h1>Sample Code</h1>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">        Sub Main(ByVal args() As String)
            Console.WriteLine(&quot;Loading helloworld.py...&quot;)

            Dim py As ScriptRuntime = Python.CreateRuntime()

            'Late-Binding only works on objects typed as Object
            Dim helloworld As Object = py.UseFile(&quot;helloworld.py&quot;)

            Console.WriteLine(&quot;helloworld.py loaded!&quot;)

            For i = 0 To 999
                Console.WriteLine(helloworld.welcome(&quot;Employee #{0}&quot;), i)
            Next i

            Console.ReadLine()
        End Sub</pre>
<div class="preview">
<pre id="codePreview" class="vb">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;Main(<span class="visualBasic__keyword">ByVal</span>&nbsp;args()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="visualBasic__string">&quot;Loading&nbsp;helloworld.py...&quot;</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;py&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ScriptRuntime&nbsp;=&nbsp;Python.CreateRuntime()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Late-Binding&nbsp;only&nbsp;works&nbsp;on&nbsp;objects&nbsp;typed&nbsp;as&nbsp;Object</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;helloworld&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>&nbsp;=&nbsp;py.UseFile(<span class="visualBasic__string">&quot;helloworld.py&quot;</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="visualBasic__string">&quot;helloworld.py&nbsp;loaded!&quot;</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;i&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;<span class="visualBasic__keyword">To</span>&nbsp;<span class="visualBasic__number">999</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(helloworld.welcome(<span class="visualBasic__string">&quot;Employee&nbsp;#{0}&quot;</span>),&nbsp;i)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;i&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadLine()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span></pre>
</div>
</div>
</div>
<h1>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(&quot;Loading helloworld.py...&quot;);

            ScriptRuntime py = Python.CreateRuntime();
            //Dynamic feature only works on objects typed as 'dynamic'
            dynamic helloworld = py.UseFile(&quot;helloworld.py&quot;);

            Console.WriteLine(&quot;helloworld.py loaded!&quot;);

            for (int i = 0; i &lt; 1000; i&#43;&#43;)
            {
                Console.WriteLine(helloworld.welcome(&quot;Employee #{0}&quot;), i);
            }
            
            Console.ReadLine();
        }
    }</pre>
<div class="preview">
<pre id="codePreview" class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Program&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Loading&nbsp;helloworld.py...&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ScriptRuntime&nbsp;py&nbsp;=&nbsp;Python.CreateRuntime();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Dynamic&nbsp;feature&nbsp;only&nbsp;works&nbsp;on&nbsp;objects&nbsp;typed&nbsp;as&nbsp;'dynamic'</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dynamic&nbsp;helloworld&nbsp;=&nbsp;py.UseFile(<span class="cs__string">&quot;helloworld.py&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;helloworld.py&nbsp;loaded!&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;<span class="cs__number">1000</span>;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(helloworld.welcome(<span class="cs__string">&quot;Employee&nbsp;#{0}&quot;</span>),&nbsp;i);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<span>Source Code Files</span></h1>
<ul>
<li>C#
<ul>
<li><a class="browseFile" href="sourcecode?fileId=23636&pathId=1768582591">Program.cs</a>
</li><li><a class="browseFile" href="sourcecode?fileId=23636&pathId=79127500">helloworld.py</a>
</li></ul>
</li><li>VB
<ul>
<li><a class="browseFile" href="sourcecode?fileId=22801&pathId=35343865">Module1.vb</a>
</li><li><a class="browseFile" href="sourcecode?fileId=22801&pathId=79127500">helloworld.py</a>
</li></ul>
</li></ul>
