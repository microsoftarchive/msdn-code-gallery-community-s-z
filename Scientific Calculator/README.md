# Scientific Calculator
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- Visual Basic .NET
- Visual basic
- VB.Net
- Visual C#
## Topics
- C#
- Calculator
- Calculator Application
- VB.Net
- C# calculator
- Advanced Calculator
- Scientific Calculator
- Visual Basic Calculator
## Updated
- 04/03/2019
## Description

<h1><strong>Preface</strong></h1>
<p>In this chapter we want to write Scientific Calculator program .</p>
<p>_______________________________________________________________________________________________</p>
<h1><strong>Process</strong></h1>
<p><strong>&nbsp;</strong><span style="font-size:small">The following steps show how to write a advanced Calculator:</span></p>
<p>1. First, Click <strong><span style="font-size:x-small">New Project</span></strong> in
<span style="font-size:x-small"><strong>Start Page</strong></span> Or On <strong>
<span style="font-size:x-small">File </span></strong>Menu .</p>
<p>2. In <strong>New Project</strong> Dialog , Click <strong>Windows</strong> On Left Pane And
<strong>Windows Forms Application</strong> On Middle Pane .</p>
<p>3. Change forms layout to this Mode :</p>
<p>&nbsp;<img id="163864" src="163864-calc.jpg" alt="" width="369" height="325"></p>
<p>_______________________________________________________________________________________________</p>
<p>4. Now Declare This Public Variables :</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp"><span class="cs__keyword">decimal</span>&nbsp;num1;&nbsp;
<span class="cs__keyword">decimal</span>&nbsp;num2;&nbsp;
<span class="cs__keyword">string</span>&nbsp;operation;&nbsp;<br></pre>
</div>
</div>
</div>
<p>5. Then Add This Method for Number Buttons :</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;input(<span class="cs__keyword">string</span>&nbsp;a)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(textBox1.Text&nbsp;==&nbsp;<span class="cs__string">&quot;0&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBox1.Text&nbsp;=&nbsp;a;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBox1.Text&nbsp;&#43;=&nbsp;a;&nbsp;
}</pre>
</div>
</div>
</div>
<p>6. Add This Code In Number Buttons(Click Event) :</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp">input(<span class="cs__string">&quot;(Number&nbsp;Of&nbsp;Button)&quot;</span>);<br></pre>
</div>
</div>
</div>
<p>7. Now Add This Code For Operation Buttons(&#43;, -, /, *, ^ And Mod(%)) :</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp">num1&nbsp;=&nbsp;<span class="cs__keyword">decimal</span>.Parse(textBox1.Text);&nbsp;
operation&nbsp;=&nbsp;<span class="cs__string">&quot;(Operation&nbsp;For&nbsp;Example&nbsp;&quot;</span>&#43;<span class="cs__string">&quot;)&quot;</span>;&nbsp;
textBox1.Text&nbsp;=&nbsp;<span class="cs__string">&quot;0&quot;</span>;<br></pre>
</div>
</div>
</div>
<p>8.Then Add&nbsp; This Code For Calculation Button(=) :</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>


<div class="preview">
<pre class="vb">num2&nbsp;=&nbsp;<span class="visualBasic__keyword">Decimal</span>.Parse(textBox1.Text)&nbsp;
<span class="visualBasic__com">'''''''''''''''''''''''''''''''''''</span>&nbsp;
<span class="visualBasic__keyword">Select</span>&nbsp;<span class="visualBasic__keyword">Case</span>&nbsp;operation&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Case</span>&nbsp;<span class="visualBasic__string">&quot;&#43;&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBox1.Text&nbsp;=&nbsp;(num1&nbsp;&#43;&nbsp;num2).ToString()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Exit</span>&nbsp;<span class="visualBasic__keyword">Select</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Case</span>&nbsp;<span class="visualBasic__string">&quot;-&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBox1.Text&nbsp;=&nbsp;(num1&nbsp;-&nbsp;num2).ToString()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Exit</span>&nbsp;<span class="visualBasic__keyword">Select</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Case</span>&nbsp;<span class="visualBasic__string">&quot;*&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBox1.Text&nbsp;=&nbsp;(num1&nbsp;*&nbsp;num2).ToString()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Exit</span>&nbsp;<span class="visualBasic__keyword">Select</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Case</span>&nbsp;<span class="visualBasic__string">&quot;/&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBox1.Text&nbsp;=&nbsp;(num1&nbsp;/&nbsp;num2).ToString()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Exit</span>&nbsp;<span class="visualBasic__keyword">Select</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Case</span>&nbsp;<span class="visualBasic__string">&quot;^&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBox1.Text&nbsp;=&nbsp;(<span class="visualBasic__keyword">Integer</span>.Parse(num1.ToString())&nbsp;<span class="visualBasic__keyword">Xor</span>&nbsp;<span class="visualBasic__keyword">Integer</span>.Parse(num2.ToString())).ToString()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Exit</span>&nbsp;<span class="visualBasic__keyword">Select</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Case</span>&nbsp;<span class="visualBasic__string">&quot;%&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBox1.Text&nbsp;=&nbsp;(num1&nbsp;<span class="visualBasic__keyword">Mod</span>&nbsp;num2).ToString()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Exit</span>&nbsp;<span class="visualBasic__keyword">Select</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Select</span></pre>
</div>
</div>
</div>
<p>9. Now Add This Code For Cosine Button :</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp">textBox1.Text&nbsp;=&nbsp;(Math.Cos(<span class="cs__keyword">double</span>.Parse(textBox1.Text))).ToString();<br></pre>
</div>
</div>
</div>
<p>10. Then Add This Code For Sinus Button :</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp">textBox1.Text&nbsp;=&nbsp;(Math.Sin(<span class="cs__keyword">double</span>.Parse(textBox1.Text))).ToString();<br></pre>
</div>
</div>
</div>
<p>11. Now Add This Code For Tangent Button :</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp">textBox1.Text&nbsp;=&nbsp;(Math.Tan(<span class="cs__keyword">double</span>.Parse(textBox1.Text))).ToString();<br></pre>
</div>
</div>
</div>
<p>12. Then Add This Code For Logarithm Button :</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp">textBox1.Text&nbsp;=&nbsp;(Math.Log(<span class="cs__keyword">double</span>.Parse(textBox1.Text))).ToString();<br></pre>
</div>
</div>
</div>
<p>13. Now Add This Code For Factorial Button :</p>
<p><strong>&nbsp;</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp"><span class="cs__keyword">long</span>&nbsp;f&nbsp;=&nbsp;<span class="cs__number">1</span>;&nbsp;
<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">long</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">1</span>;&nbsp;i&nbsp;&lt;=&nbsp;<span class="cs__keyword">long</span>.Parse(textBox1.Text);&nbsp;i&#43;&#43;)&nbsp;{&nbsp;f&nbsp;=&nbsp;f&nbsp;*&nbsp;i;&nbsp;}&nbsp;
textBox1.Text&nbsp;=&nbsp;f.ToString();</pre>
</div>
</div>
</div>
<p>14. Then Add This Code For Radical Button :</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp">textBox1.Text&nbsp;=&nbsp;(Math.Sqrt(<span class="cs__keyword">double</span>.Parse(textBox1.Text))).ToString();<br></pre>
</div>
</div>
</div>
<p><strong><span style="font-size:large">good luck &nbsp;!</span></strong></p>
<p>_______________________________________________________________________________________________</p>
<ul>
</ul>
<h1>More Information</h1>
<p><em>My Email-Address is aryanmesgari@outlook.com</em></p>
