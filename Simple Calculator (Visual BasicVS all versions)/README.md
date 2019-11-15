# Simple Calculator (Visual Basic/VS all versions)
## Requires
- Visual Studio 2017
## License
- MIT
## Technologies
- Windows Forms
## Topics
- Calculator Application
## Updated
- 09/13/2017
## Description

<h2>Simple Calculator</h2>
<p>Visual Studio all version</p>
<p>Visual Basic 2008 and later versions</p>
<h2><img id="179342" src="https://i1.code.msdn.s-msft.com/calculator-simple-visual-75d5c33c/image/file/179342/1/screenshot_12.png" alt="" width="399" height="496"></h2>
<h3>Basit bir hesap makinesi</h3>
<p>Toplama işlemi,</p>
<p>&Ccedil;ıkarma işlemi,</p>
<p>B&ouml;lme işlemi,</p>
<p>&Ccedil;arpma işlemi</p>
<p>yapabilmektedir. K&ouml;k alma vs. yoktur.</p>
<p>Klavye kullanımı yoktur.</p>
<p>&nbsp;</p>
<h3>Visual Basic</h3>
<p>&nbsp;</p>
<p>.sln dosyası Visual Studio 2010/12/13/15/17 s&uuml;r&uuml;mlerinde ve,</p>
<p>Visual Basic 2008 ve daha &uuml;st versiyonlarında a&ccedil;ılabilir.</p>
<p>&nbsp;</p>
<p>Visual Studio all version</p>
<p>Visual Basic 2008 and later versions</p>
<h2>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">D&uuml;zenle</span>|<span class="pluginRemoveHolderLink">Kaldır</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Public</span><span class="visualBasic__keyword">Class</span>&nbsp;HesapMakinesi&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;Firstnum&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">Decimal</span><span class="visualBasic__keyword">Dim</span>&nbsp;secondnum&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">Decimal</span><span class="visualBasic__keyword">Dim</span>&nbsp;Operations&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">Integer</span><span class="visualBasic__keyword">Dim</span>&nbsp;Operator_selctor&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">Boolean</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span><span class="visualBasic__keyword">Private</span><span class="visualBasic__keyword">Sub</span>&nbsp;HesapMakinesi_Load(sender&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span><span class="visualBasic__keyword">MyBase</span>.Load&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Sub</span><span class="visualBasic__keyword">Private</span><span class="visualBasic__keyword">Sub</span>&nbsp;Button4_Click(sender&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;Button4.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;Operator_selctor&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span><span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;secondnum&nbsp;=&nbsp;TextBox1.Text&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;Operations&nbsp;=&nbsp;<span class="visualBasic__number">1</span><span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TextBox1.Text&nbsp;=&nbsp;Firstnum&nbsp;&#43;&nbsp;secondnum&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ElseIf</span>&nbsp;Operations&nbsp;=&nbsp;<span class="visualBasic__number">2</span><span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TextBox1.Text&nbsp;=&nbsp;Firstnum&nbsp;-&nbsp;secondnum&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ElseIf</span>&nbsp;Operations&nbsp;=&nbsp;<span class="visualBasic__number">3</span><span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TextBox1.Text&nbsp;=&nbsp;Firstnum&nbsp;*&nbsp;secondnum&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span><span class="visualBasic__keyword">If</span>&nbsp;secondnum&nbsp;=&nbsp;<span class="visualBasic__number">0</span><span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TextBox1.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Hata!&nbsp;L&uuml;tfen&nbsp;işleminizi&nbsp;kontrol&nbsp;edin.&quot;</span><span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TextBox1.Text&nbsp;=&nbsp;Firstnum&nbsp;/&nbsp;secondnum&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">If</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Operator_selctor&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">If</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Sub</span><span class="visualBasic__keyword">Private</span><span class="visualBasic__keyword">Sub</span>&nbsp;Button15_Click(sender&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;Button15.Click&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;TextBox1.Text&nbsp;&lt;&gt;&nbsp;<span class="visualBasic__string">&quot;0&quot;</span><span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TextBox1.Text&nbsp;&#43;=&nbsp;<span class="visualBasic__string">&quot;1&quot;</span><span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TextBox1.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;1&quot;</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">If</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Sub</span><span class="visualBasic__keyword">Private</span><span class="visualBasic__keyword">Sub</span>&nbsp;Button10_Click(sender&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;Button10.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;TextBox1.Text&nbsp;&lt;&gt;&nbsp;<span class="visualBasic__string">&quot;0&quot;</span><span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TextBox1.Text&nbsp;&#43;=&nbsp;<span class="visualBasic__string">&quot;2&quot;</span><span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TextBox1.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;2&quot;</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">If</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Sub</span><span class="visualBasic__keyword">Private</span><span class="visualBasic__keyword">Sub</span>&nbsp;Button6_Click(sender&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;Button6.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;TextBox1.Text&nbsp;&lt;&gt;&nbsp;<span class="visualBasic__string">&quot;0&quot;</span><span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TextBox1.Text&nbsp;&#43;=&nbsp;<span class="visualBasic__string">&quot;3&quot;</span><span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TextBox1.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;3&quot;</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">If</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Sub</span><span class="visualBasic__keyword">Private</span><span class="visualBasic__keyword">Sub</span>&nbsp;Button16_Click(sender&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;Button16.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;TextBox1.Text&nbsp;&lt;&gt;&nbsp;<span class="visualBasic__string">&quot;0&quot;</span><span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TextBox1.Text&nbsp;&#43;=&nbsp;<span class="visualBasic__string">&quot;4&quot;</span><span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TextBox1.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;4&quot;</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">If</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Sub</span><span class="visualBasic__keyword">Private</span><span class="visualBasic__keyword">Sub</span>&nbsp;Button13_Click(sender&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;Button13.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;TextBox1.Text&nbsp;&lt;&gt;&nbsp;<span class="visualBasic__string">&quot;0&quot;</span><span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TextBox1.Text&nbsp;&#43;=&nbsp;<span class="visualBasic__string">&quot;5&quot;</span><span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TextBox1.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;5&quot;</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">If</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Sub</span><span class="visualBasic__keyword">Private</span><span class="visualBasic__keyword">Sub</span>&nbsp;Button2_Click(sender&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;Button2.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;TextBox1.Text&nbsp;&lt;&gt;&nbsp;<span class="visualBasic__string">&quot;0&quot;</span><span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TextBox1.Text&nbsp;&#43;=&nbsp;<span class="visualBasic__string">&quot;6&quot;</span><span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TextBox1.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;6&quot;</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">If</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Sub</span><span class="visualBasic__keyword">Private</span><span class="visualBasic__keyword">Sub</span>&nbsp;Button1_Click(sender&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;Button1.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;TextBox1.Text&nbsp;&lt;&gt;&nbsp;<span class="visualBasic__string">&quot;0&quot;</span><span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TextBox1.Text&nbsp;&#43;=&nbsp;<span class="visualBasic__string">&quot;7&quot;</span><span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TextBox1.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;7&quot;</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">If</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Sub</span><span class="visualBasic__keyword">Private</span><span class="visualBasic__keyword">Sub</span>&nbsp;Button17_Click(sender&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;Button17.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;TextBox1.Text&nbsp;&lt;&gt;&nbsp;<span class="visualBasic__string">&quot;0&quot;</span><span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TextBox1.Text&nbsp;&#43;=&nbsp;<span class="visualBasic__string">&quot;8&quot;</span><span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TextBox1.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;8&quot;</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">If</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Sub</span><span class="visualBasic__keyword">Private</span><span class="visualBasic__keyword">Sub</span>&nbsp;Button12_Click(sender&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;Button12.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;TextBox1.Text&nbsp;&lt;&gt;&nbsp;<span class="visualBasic__string">&quot;0&quot;</span><span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TextBox1.Text&nbsp;&#43;=&nbsp;<span class="visualBasic__string">&quot;9&quot;</span><span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TextBox1.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;9&quot;</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">If</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Sub</span><span class="visualBasic__keyword">Private</span><span class="visualBasic__keyword">Sub</span>&nbsp;Button14_Click(sender&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;Button14.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;TextBox1.Text&nbsp;&lt;&gt;&nbsp;<span class="visualBasic__string">&quot;0&quot;</span><span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TextBox1.Text&nbsp;&#43;=&nbsp;<span class="visualBasic__string">&quot;0&quot;</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">If</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Sub</span><span class="visualBasic__keyword">Private</span><span class="visualBasic__keyword">Sub</span>&nbsp;Button8_Click(sender&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;Button8.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TextBox1.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;0&quot;</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Sub</span><span class="visualBasic__keyword">Private</span><span class="visualBasic__keyword">Sub</span>&nbsp;Button3_Click(sender&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;Button3.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span><span class="visualBasic__keyword">Not</span>&nbsp;(TextBox1.Text.Contains(<span class="visualBasic__string">&quot;.&quot;</span>))&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TextBox1.Text&nbsp;&#43;=&nbsp;<span class="visualBasic__string">&quot;,&quot;</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">If</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Sub</span><span class="visualBasic__keyword">Private</span><span class="visualBasic__keyword">Sub</span>&nbsp;Button5_Click(sender&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;Button5.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Firstnum&nbsp;=&nbsp;TextBox1.Text&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TextBox1.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Operator_selctor&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Operations&nbsp;=&nbsp;<span class="visualBasic__number">1</span><span class="visualBasic__com">'&nbsp;=&nbsp;&#43;</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Sub</span><span class="visualBasic__keyword">Private</span><span class="visualBasic__keyword">Sub</span>&nbsp;Button9_Click(sender&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;Button9.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Firstnum&nbsp;=&nbsp;TextBox1.Text&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TextBox1.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Operator_selctor&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Operations&nbsp;=&nbsp;<span class="visualBasic__number">2</span><span class="visualBasic__com">'&nbsp;-&nbsp;-</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Sub</span><span class="visualBasic__keyword">Private</span><span class="visualBasic__keyword">Sub</span>&nbsp;Button11_Click(sender&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;Button11.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Firstnum&nbsp;=&nbsp;TextBox1.Text&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TextBox1.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Operator_selctor&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Operations&nbsp;=&nbsp;<span class="visualBasic__number">3</span><span class="visualBasic__com">'=x</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Sub</span><span class="visualBasic__keyword">Private</span><span class="visualBasic__keyword">Sub</span>&nbsp;Button7_Click(sender&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;Button7.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Firstnum&nbsp;=&nbsp;TextBox1.Text&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TextBox1.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Operator_selctor&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Operations&nbsp;=&nbsp;<span class="visualBasic__number">4</span><span class="visualBasic__com">'&nbsp;/</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Sub</span><span class="visualBasic__keyword">Private</span><span class="visualBasic__keyword">Sub</span>&nbsp;TextBox1_TextChanged(sender&nbsp;<span class="visualBasic__keyword">As</span><span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;TextBox1.TextChanged&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Sub</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Class</span></pre>
</div>
</div>
</div>
</h2>
<p>&nbsp;</p>
<h2>Windows Default Calculator&nbsp;</h2>
<p>https://en.wikipedia.org/wiki/Windows_Calculator</p>
<h2><span id="History" class="mw-headline">History</span><span class="mw-editsection"><span class="mw-editsection-bracket">[</span><a title="Edit section: History" href="https://en.wikipedia.org/w/index.php?title=Windows_Calculator&action=edit&section=1">edit</a><span class="mw-editsection-bracket">]</span></span></h2>
<p>A simple arithmetic calculator was first included with Windows 1.0.<sup id="cite_ref-1" class="reference"><a href="https://en.wikipedia.org/wiki/Windows_Calculator#cite_note-1">[1]</a></sup></p>
<p>In&nbsp;<a title="Windows 3.0" href="https://en.wikipedia.org/wiki/Windows_3.0">Windows 3.0</a>, a scientific mode was added, which included&nbsp;<a class="mw-redirect" title="Exponent" href="https://en.wikipedia.org/wiki/Exponent">exponents</a>&nbsp;and&nbsp;<a class="mw-redirect" title="Root (math)" href="https://en.wikipedia.org/wiki/Root_(math)">roots</a>,&nbsp;<a title="Logarithm" href="https://en.wikipedia.org/wiki/Logarithm">logarithms</a>,&nbsp;<a title="Factorial" href="https://en.wikipedia.org/wiki/Factorial">factorial</a>-based
 functions,&nbsp;<a title="Trigonometry" href="https://en.wikipedia.org/wiki/Trigonometry">trigonometry</a>(supports&nbsp;<a title="Radian" href="https://en.wikipedia.org/wiki/Radian">radian</a>,&nbsp;<a title="Degree (angle)" href="https://en.wikipedia.org/wiki/Degree_(angle)">degree</a>&nbsp;and&nbsp;<a class="mw-redirect" title="Gradians" href="https://en.wikipedia.org/wiki/Gradians">gradians</a>&nbsp;angles),
 base conversions (2, 8, 10, 16), logic operations,&nbsp;<a class="mw-redirect" title="Statistical" href="https://en.wikipedia.org/wiki/Statistical">statistical</a>&nbsp;functions such as single variable statistics and linear regression.</p>
<p>In&nbsp;<a title="Windows 98" href="https://en.wikipedia.org/wiki/Windows_98">Windows 98</a>&nbsp;and later, it uses an&nbsp;<a title="Arbitrary-precision arithmetic" href="https://en.wikipedia.org/wiki/Arbitrary-precision_arithmetic">arbitrary-precision
 arithmetic</a>&nbsp;library, replacing the standard&nbsp;<a class="mw-redirect" title="IEEE" href="https://en.wikipedia.org/wiki/IEEE">IEEE</a>&nbsp;<a class="mw-redirect" title="Floating point" href="https://en.wikipedia.org/wiki/Floating_point">floating
 point</a>&nbsp;library.<sup id="cite_ref-2" class="reference"><a href="https://en.wikipedia.org/wiki/Windows_Calculator#cite_note-2">[2]</a></sup>&nbsp;It offers&nbsp;<a class="mw-redirect" title="Bignum" href="https://en.wikipedia.org/wiki/Bignum">bignum</a>&nbsp;precision
 for basic operations (addition, subtraction, multiplication, division) and 32 digits of precision (128 bits internally actual precision, 38.5 digits, which can be verified by calculating a square root on the calc and a more precise product, or doing the same
 calculation two different ways) for advanced operations (<a title="Square root" href="https://en.wikipedia.org/wiki/Square_root">square root</a>,&nbsp;<a title="Transcendental function" href="https://en.wikipedia.org/wiki/Transcendental_function">transcendental
 functions</a>). The largest value that can be represented on the Windows Calculator is currently&nbsp;<span class="nowrap">&lt;10<sup>10,000</sup></span>&nbsp;and the smallest is&nbsp;<span class="nowrap">10<sup>&minus;9,999</sup></span>. (Also&nbsp;!
 calculates factorial function not just factorial so one can get 4.7! ).</p>
<p>In&nbsp;<a title="Windows 2000" href="https://en.wikipedia.org/wiki/Windows_2000">Windows 2000</a>,&nbsp;<a class="mw-redirect" title="Digit grouping" href="https://en.wikipedia.org/wiki/Digit_grouping">digit grouping</a>&nbsp;is added. Degree and base
 settings are added to menu bar.</p>
<div class="thumb tright">
<div class="thumbinner"><a class="image" href="https://en.wikipedia.org/wiki/File:Calculator_Vista_Scientific.png"><img class="thumbimage" src="https://upload.wikimedia.org/wikipedia/en/thumb/2/24/Calculator_Vista_Scientific.png/220px-Calculator_Vista_Scientific.png" alt="" width="220" height="148"></a>
<div class="thumbcaption">
<div class="magnify"><a class="internal" title="Enlarge" href="https://en.wikipedia.org/wiki/File:Calculator_Vista_Scientific.png"></a></div>
Scientific mode in&nbsp;<a title="Windows Vista" href="https://en.wikipedia.org/wiki/Windows_Vista">Windows Vista</a></div>
</div>
</div>
<div class="thumb tright">
<div class="thumbinner"><a class="image" href="https://en.wikipedia.org/wiki/File:Windows_7_Calculator.png"><img class="thumbimage" src="https://upload.wikimedia.org/wikipedia/en/thumb/a/ae/Windows_7_Calculator.png/150px-Windows_7_Calculator.png" alt="" width="150" height="204"></a>
<div class="thumbcaption">
<div class="magnify"><a class="internal" title="Enlarge" href="https://en.wikipedia.org/wiki/File:Windows_7_Calculator.png"></a></div>
<a title="Windows 7" href="https://en.wikipedia.org/wiki/Windows_7">Windows 7</a>&nbsp;Calculator</div>
</div>
</div>
<h3><span id="Windows_7" class="mw-headline">Windows 7</span><span class="mw-editsection"><span class="mw-editsection-bracket">[</span><a title="Edit section: Windows 7" href="https://en.wikipedia.org/w/index.php?title=Windows_Calculator&action=edit&section=2">edit</a><span class="mw-editsection-bracket">]</span></span></h3>
<p>In&nbsp;<a title="Windows 7" href="https://en.wikipedia.org/wiki/Windows_7">Windows 7</a>, separate programmer, statistics, unit conversion, date calculation and worksheets modes were added. Tooltips were removed. Furthermore, Calculator's interface was
 revamped for the first time since its introduction. The base conversion functions were moved to the programmer mode and statistics functions were moved to the statistics mode. Switching between modes does not preserve the current number, clearing it to 0.</p>
<p>In every mode except programmer mode, one can see the history of calculations. The app was redesigned to accommodate&nbsp;<a title="Multi-touch" href="https://en.wikipedia.org/wiki/Multi-touch">multi-touch</a>. Standard mode behaves as a simple checkbook
 calculator; entering the sequence 6 * 4 &#43; 12 / 4 - 4 * 5 gives the answer 25. In scientific mode,&nbsp;<a title="Order of operations" href="https://en.wikipedia.org/wiki/Order_of_operations">order of operations</a>&nbsp;is followed while doing calculations
 (multiplication and division are done before addition and subtraction), which means 6 * 4 &#43; 12 / 4 - 4 * 5 = 7.</p>
<p>In programmer mode, inputting a number in decimal has a lower and upper limit, depending on the data type, and must always be an integer. Data type of number in decimal mode is signed n-bit<sup id="cite_ref-3" class="reference"><a href="https://en.wikipedia.org/wiki/Windows_Calculator#cite_note-3">[3]</a></sup>&nbsp;integer
 when converting from number in hexadecimal, octal, or binary mode.</p>
<table class="wikitable">
<tbody>
<tr>
<th>Data type</th>
<th>Size of data type (bits)</th>
<th>Lower limit</th>
<th>Upper limit</th>
</tr>
<tr>
<td>Byte</td>
<td>8</td>
<td>-128</td>
<td>127</td>
</tr>
<tr>
<td>Word</td>
<td>16</td>
<td>-32,768</td>
<td>32,767</td>
</tr>
<tr>
<td>Dword</td>
<td>32</td>
<td>-2,147,483,648</td>
<td>2,147,483,647</td>
</tr>
<tr>
<td>Qword</td>
<td>64</td>
<td>-9,223,372,036,854,775,808</td>
<td>9,223,372,036,854,775,807</td>
</tr>
</tbody>
</table>
<div class="thumb tright">
<div class="thumbinner"><a class="image" href="https://en.wikipedia.org/wiki/File:Windows_8.1_Calculator.png"><img class="thumbimage" src="https://upload.wikimedia.org/wikipedia/commons/thumb/c/c6/Windows_8.1_Calculator.png/220px-Windows_8.1_Calculator.png" alt="" width="220" height="172"></a>
<div class="thumbcaption">
<div class="magnify"><a class="internal" title="Enlarge" href="https://en.wikipedia.org/wiki/File:Windows_8.1_Calculator.png"></a></div>
<a title="Windows 8.1" href="https://en.wikipedia.org/wiki/Windows_8.1">Windows 8.1</a>'s additional Metro-style calculator in standard mode</div>
</div>
</div>
<p>On the right of the main Calculator, one can add a panel with date calculation, unit conversion and worksheets. Worksheets allow one to calculate a result of a chosen field based on the values of other fields. Pre-defined templates include calculating a
 car's fuel economy (mpg and L/100&nbsp;km),<sup id="cite_ref-4" class="reference"><a href="https://en.wikipedia.org/wiki/Windows_Calculator#cite_note-4">[4]</a></sup>&nbsp;a vehicle lease, and a mortgage. In pre-beta versions of Windows 7, Calculator also
 provided a Wages template.</p>
<h3><span id="Windows_8.1" class="mw-headline">Windows 8.1</span><span class="mw-editsection"><span class="mw-editsection-bracket">[</span><a title="Edit section: Windows 8.1" href="https://en.wikipedia.org/w/index.php?title=Windows_Calculator&action=edit&section=3">edit</a><span class="mw-editsection-bracket">]</span></span></h3>
<p>While the traditional Calculator is still included with&nbsp;<a title="Windows 8.1" href="https://en.wikipedia.org/wiki/Windows_8.1">Windows 8.1</a>, a&nbsp;<a title="Metro (design language)" href="https://en.wikipedia.org/wiki/Metro_(design_language)">Metro-style</a>&nbsp;Calculator
 is also present, featuring a full-screen interface as well as normal, scientific, and conversion modes.<sup id="cite_ref-pt-81utility_5-0" class="reference"><a href="https://en.wikipedia.org/wiki/Windows_Calculator#cite_note-pt-81utility-5">[5]</a></sup></p>
<h3><span id="Windows_10" class="mw-headline">Windows 10</span><span class="mw-editsection"><span class="mw-editsection-bracket">[</span><a title="Edit section: Windows 10" href="https://en.wikipedia.org/w/index.php?title=Windows_Calculator&action=edit&section=4">edit</a><span class="mw-editsection-bracket">]</span></span></h3>
<p>The Calculator in&nbsp;<a title="Windows 10 editions" href="https://en.wikipedia.org/wiki/Windows_10_editions">non-LTSB editions</a>&nbsp;of&nbsp;<a title="Windows 10" href="https://en.wikipedia.org/wiki/Windows_10">Windows 10</a>&nbsp;is a&nbsp;<a title="Windows Store" href="https://en.wikipedia.org/wiki/Windows_Store">universal
 Windows app</a>. In contrast, Windows 10 LTSB (which does not include universal Windows apps) includes the traditional calculator, but which is now named&nbsp;<code class="mw-highlight" dir="ltr">win32calc.exe</code>. Both calculators provide the features
 of the traditional calculator included with Windows 7, such as a unit conversions for volume, length, weight, temperature, energy, area, speed, time, power, data, pressure and angle, and the history list which the user can clear.</p>
<p>Both the universal Windows app and LTSB's&nbsp;<code class="mw-highlight" dir="ltr">win32calc.exe</code>&nbsp;register themselves with the system as handlers of a '<code class="mw-highlight" dir="ltr">calculator:</code>' pseudo-protocol. This registration
 is similar to that performed by any other well-behaved application when it registers itself as a handler for a filetype (e.g.&nbsp;<code class="mw-highlight" dir="ltr">.jpg</code>) or protocol (e.g.&nbsp;<code class="mw-highlight" dir="ltr">http:</code>).</p>
<p>All Windows 10 editions (both LTSB and non-LTSB) continue to have a&nbsp;<code class="mw-highlight" dir="ltr">calc.exe</code>, which however is just a stub that launches (via ShellExecute) the handler that is associated with the '<code class="mw-highlight" dir="ltr">calculator:</code>'
 pseudo-protocol. As with any other protocol or filetype, when there are multiple handlers to choose from, users are free to choose which handler they prefer&mdash; either via the classic control panel ('Default programs' settings) or the immersive UI settings
 ('Default Apps' settings) or from the command prompt via&nbsp;<code class="mw-highlight" dir="ltr">OpenWith calculator:</code>.</p>
<h2><span id="Features" class="mw-headline">Features</span><span class="mw-editsection"><span class="mw-editsection-bracket">[</span><a title="Edit section: Features" href="https://en.wikipedia.org/w/index.php?title=Windows_Calculator&action=edit&section=5">edit</a><span class="mw-editsection-bracket">]</span></span></h2>
<p>By default, Calculator runs in standard mode, which resembles a four-function calculator. More advanced functions are available in scientific mode, including&nbsp;<a title="Logarithm" href="https://en.wikipedia.org/wiki/Logarithm">logarithms</a>,&nbsp;<a class="mw-redirect" title="Numerical base" href="https://en.wikipedia.org/wiki/Numerical_base">numerical
 base</a>&nbsp;conversions, some&nbsp;<a title="Logical connective" href="https://en.wikipedia.org/wiki/Logical_connective">logical operators</a>,&nbsp;<a title="Order of operations" href="https://en.wikipedia.org/wiki/Order_of_operations">operator precedence</a>,&nbsp;<a title="Radian" href="https://en.wikipedia.org/wiki/Radian">radian</a>,&nbsp;<a title="Degree (angle)" href="https://en.wikipedia.org/wiki/Degree_(angle)">degree</a>&nbsp;and&nbsp;<a class="mw-redirect" title="Gradians" href="https://en.wikipedia.org/wiki/Gradians">gradians</a>&nbsp;support
 as well as simple single-variable&nbsp;<a class="mw-redirect" title="Statistical" href="https://en.wikipedia.org/wiki/Statistical">statistical</a>&nbsp;functions. It does not provide support for user-defined functions,&nbsp;<a title="Complex number" href="https://en.wikipedia.org/wiki/Complex_number">complex
 numbers</a>, storage variables for intermediate results (other than the classic accumulator memory of pocket calculators), automated&nbsp;<a class="mw-redirect" title="Polar coordinates" href="https://en.wikipedia.org/wiki/Polar_coordinates">polar</a>-<a class="mw-redirect" title="Cartesian coordinates" href="https://en.wikipedia.org/wiki/Cartesian_coordinates">cartesian
 coordinates</a>&nbsp;conversion, or support for two-variables statistics.</p>
<p>Calculator supports&nbsp;<a title="Keyboard shortcut" href="https://en.wikipedia.org/wiki/Keyboard_shortcut">keyboard shortcuts</a>; all Calculator features have an associated keyboard shortcut.<sup id="cite_ref-6" class="reference"><a href="https://en.wikipedia.org/wiki/Windows_Calculator#cite_note-6">[6]</a></sup></p>
<p>Calculator in&nbsp;<a title="Hexadecimal" href="https://en.wikipedia.org/wiki/Hexadecimal">hexadecimal</a>&nbsp;mode cannot accept or display a hexadecimal number larger than 16 hex digits. The largest number it can handle is therefore 0xFFFFFFFFFFFFFFFF
 (decimal 18,446,744,073,709,551,615). Any calculations in hex mode which exceed this limit will display a result of zero, even if those calculations would succeed in other modes. In particular,&nbsp;<a title="Scientific notation" href="https://en.wikipedia.org/wiki/Scientific_notation">scientific
 notation</a>&nbsp;is not available in this mode.</p>
