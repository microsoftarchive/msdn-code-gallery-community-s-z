# Set Excel Font Style in C#
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- C#
- Silverlight
- WPF
- c# control
## Topics
- Excel Automation
- Set Excel font
- Excel font style
## Updated
- 11/09/2014
## Description

<h1>Introduction</h1>
<p><span style="font-size:small">In order to show a good-looking Excel file or emphasize one part of Excel, different font styles for cells, which include characters, are needed. This sample aims to provide a C# solution to set Excel font style using free Spire.XLS.<br>
</span></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p style="text-align:justify"><span style="font-size:20px"><span style="font-size:small"><strong>Tools we need:</strong><br>
</span></span></p>
<p style="text-align:justify"><span style="font-size:20px"><span style="font-size:small">- Free Spire.XLS (This dll is available in the package attached.)<br>
- Visual Studio</span></span></p>
<p style="text-align:justify"><span style="font-size:20px"><span style="font-size:small"><strong>Prepare the environment</strong><br>
</span></span></p>
<p style="text-align:justify"><span style="font-size:20px"><span style="font-size:small"><span style="font-size:20px"><span style="font-size:small">This solution is based on a free .NET Excel component - free Spire.XLS, download the package and unzip it, you&rsquo;ll
 get dll file and sample demo at the same time. Create or open a .NET class application in Visual Studio 2005 or above versions, add Spire.Xls.dll as a reference to your .NET project assemblies, set &ldquo;Target framework&rdquo; to &ldquo;.NET Framework 4&rdquo;.</span></span></span></span></p>
<p style="text-align:justify"><span style="font-size:20px"><span style="font-size:small"><span style="font-size:20px"><span style="font-size:small"><strong>Namespaces to be used</strong></span></span></span></span></p>
<p style="text-align:justify"><span style="font-size:20px"><span style="font-size:small"><span style="font-size:20px"><span style="font-size:small">using Spire.Xls;<br>
using <a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Drawing.aspx" target="_blank" title="Auto generated link to System.Drawing">System.Drawing</a>;</span></span></span></span></p>
<p style="text-align:justify"><span style="font-size:20px"><span style="font-size:small"><span style="font-size:20px"><span style="font-size:small"><strong>Code Snippet</strong></span></span></span></span></p>
<p style="text-align:justify"><span style="font-size:20px"><span style="font-size:small"><span style="font-size:20px"><span style="font-size:small"><strong>&nbsp;</strong></span></span></span></span></p>
<p><strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Create&nbsp;Workbook&nbsp;and&nbsp;Worksheet</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Workbook&nbsp;workbook&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Workbook();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Worksheet&nbsp;sheet&nbsp;=&nbsp;workbook.Worksheets[<span class="js__num">0</span>];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Set&nbsp;Font&nbsp;Type&nbsp;as&nbsp;Calibri</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sheet.Range[<span class="js__string">&quot;B1&quot;</span>].Text&nbsp;=&nbsp;<span class="js__string">&quot;Calibri&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sheet.Range[<span class="js__string">&quot;B1&quot;</span>].Style.Font.FontName&nbsp;=&nbsp;<span class="js__string">&quot;Calibri&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Set&nbsp;Font&nbsp;Size&nbsp;as&nbsp;22</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sheet.Range[<span class="js__string">&quot;B2&quot;</span>].Text&nbsp;=&nbsp;<span class="js__string">&quot;Large&nbsp;size&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sheet.Range[<span class="js__string">&quot;B2&quot;</span>].Style.Font.Size&nbsp;=&nbsp;<span class="js__num">22</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Set&nbsp;Font&nbsp;as&nbsp;Bold</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sheet.Range[<span class="js__string">&quot;B3&quot;</span>].Text&nbsp;=&nbsp;<span class="js__string">&quot;Bold&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sheet.Range[<span class="js__string">&quot;B3&quot;</span>].Style.Font.IsBold&nbsp;=&nbsp;true;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Set&nbsp;Font&nbsp;as&nbsp;Italic</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sheet.Range[<span class="js__string">&quot;B4&quot;</span>].Text&nbsp;=&nbsp;<span class="js__string">&quot;Italic&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sheet.Range[<span class="js__string">&quot;B4&quot;</span>].Style.Font.IsItalic&nbsp;=&nbsp;true;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Set&nbsp;Font&nbsp;as&nbsp;Superscript</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sheet.Range[<span class="js__string">&quot;B5&quot;</span>].Text&nbsp;=&nbsp;<span class="js__string">&quot;Superscript&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sheet.Range[<span class="js__string">&quot;B5&quot;</span>].Style.Font.IsSuperscript&nbsp;=&nbsp;true;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Set&nbsp;Font&nbsp;as&nbsp;Colored</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sheet.Range[<span class="js__string">&quot;B6&quot;</span>].Text&nbsp;=&nbsp;<span class="js__string">&quot;Colored&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sheet.Range[<span class="js__string">&quot;B6&quot;</span>].Style.Font.Color&nbsp;=&nbsp;Color.FromArgb(<span class="js__num">255</span>,&nbsp;<span class="js__num">125</span>,&nbsp;<span class="js__num">125</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Set&nbsp;Font&nbsp;as&nbsp;Underlined</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sheet.Range[<span class="js__string">&quot;B7&quot;</span>].Text&nbsp;=&nbsp;<span class="js__string">&quot;Underline&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sheet.Range[<span class="js__string">&quot;B7&quot;</span>].Style.Font.Underline&nbsp;=&nbsp;FontUnderlineType.Single;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Save&nbsp;File</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;workbook.SaveToFile(<span class="js__string">&quot;FontStyle.xls&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Launch&nbsp;File</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Diagnostics.Process.Start.aspx" target="_blank" title="Auto generated link to System.Diagnostics.Process.Start">System.Diagnostics.Process.Start</a>(<span class="js__string">&quot;FontStyle.xls&quot;</span>);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Output</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><img id="128488" src="128488-1.png" alt="" width="385" height="198"></div>
<br>
</strong>
<p></p>
<p>&nbsp;</p>
<h1 style="text-align:left">More Information</h1>
<p style="text-align:justify"><span style="font-size:small">Free Spire.XLS for .NET is a Community Edition of the Spire.XLS for .NET, which is a totally free Excel component for commercial and personal use. As a standalone C#/VB.NET component, Free Spire.XLS
 for .NET enables developers to create, manage and manipulate Excel files on any .NET applications.</span></p>
<p style="text-align:justify">&nbsp;</p>
<p><strong><span style="font-size:small">Related Links:</span></strong></p>
<p><span style="font-size:small">Website: <a href="http://www.e-iceblue.com">www.e-iceblue.com</a></span><br>
<span style="font-size:small">Product Home: <a href="http://www.e-iceblue.com/Introduce/free-xls-component.html">
Free Spire.XLS for .NET</a></span><br>
<span style="font-size:small">Download: <a href="http://www.e-iceblue.com/Download/download-excel-for-net-now.html">
Spire.XLS for. NET</a></span><br>
<span style="font-size:small">Forum: <a href="http://www.e-iceblue.com/forum/viewforum.php?f=4">
Spire.XLS forum</a></span></p>
