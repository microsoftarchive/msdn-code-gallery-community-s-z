# Using Spire.XLS With Visual Studio
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- ASP.NET
- Visual Basic.NET
- Visual C#
- Visual Studio 2013
## Topics
- C#
- VB.Net
- Visual Studio
- XLS to HTML
## Updated
- 06/21/2016
## Description

<p><span style="font-size:small">Hi I hope you all are fine. Today we are going to see a new product&nbsp;<em>Spire.XLS</em>&nbsp;which helps us to create, manipulate, convert EXCEL file to other formats and many more. This product has been introduced by the
 company&nbsp;<a href="http://www.e-iceblue.com/" target="_blank">E-Iceblue</a>. I hope you have read my article of&nbsp;<em>Spire.Doc</em>. If you have not read it, I recommend you to read it here:&nbsp;<a href="http://sibeeshpassion.com/using-spire-doc-introduction/" target="_blank">Using
 Spire.Doc</a></span></p>
<p><strong><span style="font-size:small">Background</span></strong></p>
<p><span style="font-size:small">Always, managing excel files through code is a tough job for me. If you are also thinking the same, I strongly recommend this product Spire.XLX from E-Iceblue. It made the task easier than ever. In this article I will show you
 the demo for converting the Excel files to other formats. I hope you will like it.</span></p>
<p><strong><span style="font-size:small">Download the files</span></strong></p>
<p><span style="font-size:small">You can always the needed files from here:&nbsp;<a href="http://www.e-iceblue.com/Download/download-excel-for-net-now.html" target="_blank">Download Spire.XLS</a></span></p>
<p><strong><span style="font-size:small">Install Spire.XLS</span></strong></p>
<p><span style="font-size:small">I am using evaluation version with one month temporary license. There are free versions also available for spire.xls with some limitation. You can try that. Now click on the exe file after you extract the downloaded file. The
 installation will get started then.</span></p>
<p><span style="font-size:small"><img src="-installspirexls.png" alt="Using Spire XLS"></span></p>
<p><strong><span style="font-size:small">So Shall we start?</span></strong></p>
<p><span style="font-size:small">Once you Installed, you are ready to go. We will start with a &ldquo;Simple Windows Form &rdquo; Application. Before getting started, Please install Spire.XLs and Visual studio 2008 or above. I am using Visual Studio 2015 RC.&nbsp;</span></p>
<p><span style="font-size:small">Open your Visual Studio, click on New-&gt;Project-&gt;Select Visual C# (if you are good in C# or select Visual Basic) Project-&gt;Windows-&gt;Windows forms application-&gt;Name your project(I am naming it as Using SpireXLs)</span></p>
<p><span style="font-size:small"><img src="-usingspirexls1.png" alt="Using Spire XLS"></span></p>
<p><span style="font-size:small">Now create a group box and a button in your form and name them :). Later, click on the button.</span></p>
<p><span style="font-size:small"><img src="-usingspirexls2.png" alt="Using Spire XLS"></span></p>
<p><span style="font-size:small">Now right click on your project and click add reference, in the browse tab find out the folder in which you have installed spire xls. Usually it will be in the C:\Program Files\e-iceblue\Spire.Xls. Now just find your framework
 version from BIN folder and add Spire.xls.dll</span></p>
<p><span style="font-size:small"><img src="-usingspirexls3.png" alt="Using Spire XLS"></span></p>
<p><span style="font-size:small"><img src="-addingspirexlsreference.png" alt="Using Spire XLS"></span></p>
<p><span style="font-size:small">Now we have added reference too. So shall we start coding ?</span></p>
<p><strong><span style="font-size:small">Using the code</span></strong></p>
<p><span style="font-size:small">To start with coding you need to add the needed namespaces as follows.</span></p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_611224">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">using&nbsp;Spire.Xls;&nbsp;
using&nbsp;Spire.Pdf;&nbsp;
using&nbsp;Spire.Xls.Converter;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><span style="font-size:small">In the button click event you need to add the following lines codes.</span></p>
<p><strong><span style="font-size:small">C# Code</span></strong></p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_721107">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">private&nbsp;<span class="js__operator">void</span>&nbsp;button1_Click(object&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;load&nbsp;Excel&nbsp;file</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Workbook&nbsp;workbook&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Workbook();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;workbook.LoadFromFile(<span class="js__string">&quot;D:\\MyExcel.xlsx&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Set&nbsp;PDF&nbsp;template</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PdfDocument&nbsp;pdfDocument&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;PdfDocument();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pdfDocument.PageSettings.Orientation&nbsp;=&nbsp;PdfPageOrientation.Landscape;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pdfDocument.PageSettings.Width&nbsp;=&nbsp;<span class="js__num">970</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pdfDocument.PageSettings.Height&nbsp;=&nbsp;<span class="js__num">850</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Convert&nbsp;Excel&nbsp;to&nbsp;PDF&nbsp;using&nbsp;the&nbsp;template&nbsp;above</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PdfConverter&nbsp;pdfConverter&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;PdfConverter(workbook);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PdfConverterSettings&nbsp;settings&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;PdfConverterSettings();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;settings.TemplateDocument&nbsp;=&nbsp;pdfDocument;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pdfDocument&nbsp;=&nbsp;pdfConverter.Convert(settings);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Save&nbsp;and&nbsp;preview&nbsp;PDF</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pdfDocument.SaveToFile(<span class="js__string">&quot;MyPDF.pdf&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Diagnostics.Process.Start.aspx" target="_blank" title="Auto generated link to System.Diagnostics.Process.Start">System.Diagnostics.Process.Start</a>(<span class="js__string">&quot;MyPDF.pdf&quot;</span>);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><strong><span style="font-size:small">VB.NET Code</span></strong></p>
<div>
<div class="syntaxhighlighter vb" id="highlighter_678448">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="js">'load&nbsp;Excel&nbsp;file&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;workbook&nbsp;As&nbsp;New&nbsp;Workbook()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;workbook.LoadFromFile(<span class="js__string">&quot;D:\MyExcel.xlsx&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'&nbsp;Set&nbsp;PDF&nbsp;template&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;pdfDocument&nbsp;As&nbsp;New&nbsp;PdfDocument()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pdfDocument.PageSettings.Orientation&nbsp;=&nbsp;PdfPageOrientation.Landscape&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pdfDocument.PageSettings.Width&nbsp;=&nbsp;<span class="js__num">970</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pdfDocument.PageSettings.Height&nbsp;=&nbsp;<span class="js__num">850</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'Convert&nbsp;Excel&nbsp;to&nbsp;PDF&nbsp;using&nbsp;the&nbsp;template&nbsp;above&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;pdfConverter&nbsp;As&nbsp;New&nbsp;PdfConverter(workbook)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;settings&nbsp;As&nbsp;New&nbsp;PdfConverterSettings()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;settings.TemplateDocument&nbsp;=&nbsp;pdfDocument&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pdfDocument&nbsp;=&nbsp;pdfConverter.Convert(settings)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'&nbsp;Save&nbsp;and&nbsp;preview&nbsp;PDF&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pdfDocument.SaveToFile(<span class="js__string">&quot;MyPdf.pdf&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Diagnostics.Process.Start.aspx" target="_blank" title="Auto generated link to System.Diagnostics.Process.Start">System.Diagnostics.Process.Start</a>(<span class="js__string">&quot;MyPdf.pdf&quot;</span>)</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">In the above lines code, we are loading an excel file MyExcel.xlsx from my drive. The following is the content of our excel file.</span></p>
<p><span style="font-size:small"><img src="-spirexlssampleexcelfile.png" alt="Using Spire XLS"></span></p>
<p><span style="font-size:small">Now if you run your project and click our button, you will get a pdf file as follows.</span></p>
<p><span style="font-size:small"><img src="-spirexlspdfconvertoutput.png" alt="Using Spire XLS"></span></p>
<p><span style="font-size:small">Cool!. Very simple right? Now we will go to other conversions as well.</span></p>
<p><strong><span style="font-size:small">Excel to HTML</span></strong></p>
<p><span style="font-size:small">To convert our excel file to HTML, you need to create a button in our form and paste the following codes to the button click event.</span></p>
<p><strong><span style="font-size:small">C# Code</span></strong></p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_390967">
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
<tr>
<td class="gutter">
<div class="line number1 index0 alt2"></div>
</td>
<td class="code">
<div class="container"></div>
</td>
</tr>
</tbody>
</table>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">private&nbsp;<span class="js__operator">void</span>&nbsp;button2_Click(object&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//load&nbsp;Excel&nbsp;file</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Workbook&nbsp;workbook&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Workbook();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;workbook.LoadFromFile(<span class="js__string">&quot;D:\\MyExcel.xlsx&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//convert&nbsp;Excel&nbsp;to&nbsp;HTML</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Worksheet&nbsp;sheet&nbsp;=&nbsp;workbook.Worksheets[<span class="js__num">0</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sheet.SaveToHtml(<span class="js__string">&quot;MyHTML.html&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Preview&nbsp;HTML</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Diagnostics.Process.Start.aspx" target="_blank" title="Auto generated link to System.Diagnostics.Process.Start">System.Diagnostics.Process.Start</a>(<span class="js__string">&quot;MyHTML.html&quot;</span>);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><strong><span style="font-size:small">VB.NET Code</span></strong></p>
<div>
<div class="syntaxhighlighter vb" id="highlighter_681640">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="js">Private&nbsp;Shared&nbsp;Sub&nbsp;Main(args&nbsp;As&nbsp;<span class="js__object">String</span>())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'load&nbsp;Excel&nbsp;file&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;workbook&nbsp;As&nbsp;New&nbsp;Workbook()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;workbook.LoadFromFile(<span class="js__string">&quot;D:\\MyExcel.xlsx&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'convert&nbsp;Excel&nbsp;to&nbsp;HTML&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;sheet&nbsp;As&nbsp;Worksheet&nbsp;=&nbsp;workbook.Worksheets(<span class="js__num">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sheet.SaveToHtml(<span class="js__string">&quot;MyHTML.html&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'Preview&nbsp;HTML&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Diagnostics.Process.Start.aspx" target="_blank" title="Auto generated link to System.Diagnostics.Process.Start">System.Diagnostics.Process.Start</a>(<span class="js__string">&quot;MyHTML.html&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Sub</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">Now if you run the code, you can see an html file as follows.</span></p>
<p><span style="font-size:small"><img src="-spirexlsconverthtmlputput.png" alt="Using Spire XLS"></span></p>
<p><strong><span style="font-size:small">Excel To Image</span></strong></p>
<p><span style="font-size:small">To convert our excel file to image, you need to create a button in our form and paste the following codes to the button click event.</span></p>
<p><strong><span style="font-size:small">C# Code</span></strong></p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_978095">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">private&nbsp;<span class="js__operator">void</span>&nbsp;button3_Click(object&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Workbook&nbsp;workbook&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Workbook();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;workbook.LoadFromFile(<span class="js__string">&quot;D:\\MyExcel.xlsx&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Worksheet&nbsp;sheet&nbsp;=&nbsp;workbook.Worksheets[<span class="js__num">0</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sheet.SaveToImage(<span class="js__string">&quot;MyImage.jpg&quot;</span>);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><strong><span style="font-size:small">VB.NET Code</span></strong></p>
<div>
<div class="syntaxhighlighter vb" id="highlighter_191701">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="js">Shared&nbsp;Sub&nbsp;Main(ByVal&nbsp;args()&nbsp;As&nbsp;<span class="js__object">String</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;workbook&nbsp;As&nbsp;New&nbsp;Workbook()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;workbook.LoadFromFile(<span class="js__string">&quot;D:\\MyExcel.xlsx&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;sheet&nbsp;As&nbsp;Worksheet&nbsp;=&nbsp;workbook.Worksheets(<span class="js__num">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sheet.SaveToImage(<span class="js__string">&quot;MyImage.jpg&quot;</span>)&nbsp;
End&nbsp;Sub</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">Now if you run the code, you can see an Image as follows.</span></p>
<p><span style="font-size:small"><img src="-spirexlsconvertexceltoimagesoutput1.png" alt="Using Spire XLS"></span></p>
<p><span style="font-size:small"><img src="-spirexlsconvertexceltoimagesoutput2.png" alt="Using Spire XLS"></span></p>
<p><strong><span style="font-size:small">Excel to CSV</span></strong></p>
<p><span style="font-size:small">To convert our excel file to image, you need to create a button in our form and paste the following codes to the button click event.</span></p>
<p><strong><span style="font-size:small">C# Code</span></strong></p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_760501">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">private&nbsp;<span class="js__operator">void</span>&nbsp;button3_Click(object&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Workbook&nbsp;workbook&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Workbook();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;workbook.LoadFromFile(<span class="js__string">&quot;D:\\MyExcel.xlsx&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Worksheet&nbsp;sheet&nbsp;=&nbsp;workbook.Worksheets[<span class="js__num">0</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sheet.SaveToFile(<span class="js__string">&quot;MyCSV.csv&quot;</span>,&nbsp;<span class="js__string">&quot;,&quot;</span>,&nbsp;Encoding.UTF8);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><strong><span style="font-size:small">VB.NET Code</span></strong></p>
<div>
<div class="syntaxhighlighter vb" id="highlighter_264346">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="js">Shared&nbsp;Sub&nbsp;Main(ByVal&nbsp;args()&nbsp;As&nbsp;<span class="js__object">String</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;workbook&nbsp;As&nbsp;New&nbsp;Workbook()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;workbook.LoadFromFile(<span class="js__string">&quot;D:\\MyExcel.xlsx&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;sheet&nbsp;As&nbsp;Worksheet&nbsp;=&nbsp;workbook.Worksheets(<span class="js__num">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sheet.SaveToFile(<span class="js__string">&quot;MyCSV.csv&quot;</span>,&nbsp;<span class="js__string">&quot;,&quot;</span>,&nbsp;Encoding.UTF8)&nbsp;
&nbsp;&nbsp;
End&nbsp;Sub</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">Now if you run the code, you can see a CSV file as follows.</span></p>
<p><span style="font-size:small"><img src="-spirexlsconvertexceltocsvoutput.png" alt="Using Spire XLS"></span></p>
<p><span style="font-size:small"><em>Please be noted that, you can convert your excel to any other file format, there are plenty of options available. Please try that too. I have given only three options which I use always.</em></span></p>
<h1></h1>
