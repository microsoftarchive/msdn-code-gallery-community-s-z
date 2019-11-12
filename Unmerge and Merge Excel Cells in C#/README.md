# Unmerge and Merge Excel Cells in C#
## Requires
- Visual Studio 2013
## License
- MS-LPL
## Technologies
- C#
## Topics
- Unmerge and Merge Excel Cells in C#
## Updated
- 04/21/2017
## Description

<h1>&nbsp;</h1>
<h1><span style="font-size:medium">Introduction</span></h1>
<p><span style="font-size:small">Unmerging and <a title="Easily Merge Excel Cells with C#, VB.NET" href="https://www.e-iceblue.com/Tutorials/Spire.XLS/Spire.XLS-Program-Guide/How-to-Merge-Cells-in-Excel.html">
merging Excel cells</a> are indispensable for handling Excel worksheet. This sample aims at introducing the solution to unmerge and merge Excel cells in c# through several lines of codes.</span></p>
<p><span style="font-size:small">At first, we need to complete the preparatory work before unmerging and merging Excel cells in C#:</span></p>
<ul>
<li><span style="font-size:small"><a title="Download the Spire.XLS" href="https://www.e-iceblue.com/Download/download-excel-for-net-now.html">Download the Free Spire.XLS</a> for .NET and install it on your system.
</span></li><li><span style="font-size:small">Create a console application. </span></li><li><span style="font-size:small">Right click on your project and select Add Reference, and then click the Browse tab to find out the folder in which you just installed Free Spire.XLS. Usually it will be in the C:\Program Files\e-iceblue\Spire.XLS-FE\. Now
 go to the Bin folder and reference Spire.XLS.dll from the folder that corresponds to the version of your .NET Framework (you can choose .NET2.0, .NET3.5, .NET4.0 and .NET4.0 ClientProfile).
</span></li></ul>
<p><br>
<span style="font-size:medium"><strong>Using the codes (unmerge)</strong></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;Spire.Xls;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Text.aspx" target="_blank" title="Auto generated link to System.Text">System.Text</a>;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;unmerge_the_cells&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Program&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Workbook&nbsp;book&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Workbook();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;book.LoadFromFile(@<span class="cs__string">&quot;C:\Users\Administrator\Desktop\unmerge.xlsx&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Worksheet&nbsp;sheet&nbsp;=&nbsp;book.Worksheets[<span class="cs__number">0</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sheet.Range[<span class="cs__string">&quot;A2&quot;</span>].UnMerge();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;book.SaveToFile(<span class="cs__string">&quot;consequence.xlsx&quot;</span>,&nbsp;ExcelVersion.Version2010);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<p><span style="color:#ff6600; font-size:small"><strong>The original <strong>effect screenshot</strong>:</strong></span></p>
<p><img id="172441" src="172441-%e5%8e%9f%e5%9b%be.png" alt="" width="622" height="370"></p>
<p>&nbsp;</p>
<p><span style="color:#ff6600; font-size:small"><strong>The generated effect screenshot:</strong></span></p>
<p><img id="172442" src="172442-%e6%95%88%e6%9e%9c%e5%9b%be.png" alt="" width="630" height="369"></p>
<p><span style="font-size:medium"><strong>&nbsp;</strong>&nbsp;</span></p>
<p><span style="font-size:medium"><strong>Using the codes (merge)</strong></span></p>
<h1>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;Spire.Xls;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Text.aspx" target="_blank" title="Auto generated link to System.Text">System.Text</a>;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;merge_the_Excel_cells&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Program&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Workbook&nbsp;workbook&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Workbook();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;workbook.LoadFromFile(@<span class="cs__string">&quot;C:\Users\Administrator\Desktop\merge.xlsx&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;workbook.Worksheets[<span class="cs__number">0</span>].Range[<span class="cs__string">&quot;A2:C3&quot;</span>].Merge();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;workbook.SaveToFile(<span class="cs__string">&quot;result.xlsx&quot;</span>);&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="color:#ff6600; font-size:small"><strong>&nbsp;</strong></span></div>
<div class="endscriptcode"><span style="color:#ff6600; font-size:small"><strong><span style="color:#ff6600; font-size:small"><strong>The original
<strong>effect screenshot</strong>:</strong></span></strong></span></div>
<div class="endscriptcode"><span style="color:#ff6600; font-size:small"><strong>&nbsp;</strong></span></div>
</h1>
<h1><img id="172443" src="172443-merge%e5%8e%9f%e5%9b%be.png" alt=""></h1>
<h1><span style="color:#ff6600; font-size:small"><strong>&nbsp;</strong></span></h1>
<h1><span style="color:#ff6600; font-size:small"><strong><span style="color:#ff6600; font-size:small"><strong><span style="color:#ff6600; font-size:small"><strong><span style="color:#ff6600; font-size:small"><strong>The generated effect screenshot:</strong></span></strong></span></strong></span></strong></span></h1>
<h1><span style="color:#ff6600; font-size:small"><strong><span style="color:#ff6600; font-size:small"><strong>&nbsp;</strong></span></strong></span></h1>
<h1>&nbsp;<img id="172445" src="172445-merge%e6%95%88%e6%9e%9c%e5%9b%be.png" alt=""></h1>
<h1><span style="font-size:small">&nbsp;</span></h1>
<h1><span style="font-size:medium">More Information</span></h1>
<p><span style="font-size:small"><a href="https://www.e-iceblue.com/Introduce/free-xls-component.html#.WPcPuHaS3IV">Free Spire.XLS for .NET</a> is a professional and reliable Excel component for commercial and personal use. It enables developers to create,
 manage and manipulate Excel files on .NET applications. Meanwhile, it supports both the old Excel 97-2003 format (.xls) and the new Excel 2007, Excel 2010 and Excel 2013 (.xlsx, .xlsm).</span></p>
<p><span style="font-size:medium"><strong>Main Features:</strong></span></p>
<ul>
<li><span style="font-size:small">No Microsoft Office Automation </span></li><li><span style="font-size:small">High quality conversion (Excel to XML, Excel to Text, Excel to PDF, Excel to Image)
</span></li><li><span style="font-size:small">Create charts, auto filters and Pivot Tables </span>
</li><li><span style="font-size:small">Implement Data Sorting and Data Validations </span>
</li><li><span style="font-size:small">Encrypt/Decrypt files </span></li><li><span style="font-size:small">Calculate complex Excel formula </span></li><li><span style="font-size:small">Print Excel documents </span></li><li><span style="font-size:small">Totally Free </span></li></ul>
<p><span style="font-size:medium"><strong>Related Links:</strong></span></p>
<p><span style="font-size:small">Website: <a title="www.e-iceblue.com" href="http://www.e-iceblue.com/">
www.e-iceblue.com</a></span></p>
<p><span style="font-size:small">Download: <a href="https://www.e-iceblue.com/Download/download-excel-for-net-free.html">
https://www.e-iceblue.com/Download/download-excel-for-net-free.html</a></span></p>
<p><span style="font-size:small">Forum:&nbsp; <a href="http://www.e-iceblue.com/forum/viewforum.php?f=4">
Spire.XLS forum</a></span></p>
