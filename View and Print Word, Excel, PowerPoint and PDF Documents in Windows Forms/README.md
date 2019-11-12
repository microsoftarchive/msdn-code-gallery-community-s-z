# View and Print Word, Excel, PowerPoint and PDF Documents in Windows Forms
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- Windows Forms，.NET
## Topics
- View Office documents and PDF Files in WinForm
## Updated
- 09/20/2016
## Description

<h1>Introduction</h1>
<p>Developers may want to view and print documents like Word, Excel, PowerPoint and PDF all in one application. This sample explains how to view and print Word, Excel, PowerPoint and PDF Documents in Windows Forms applications via a powerful component Spire.OfficeViewer.</p>
<p>Spire.OfficeViewer is a .NET library which&nbsp;mainly focus on how to display Microsoft Office and PDF&nbsp;documents. It enables developers to directly view and print these documents in their Windows Forms&nbsp;applications. In addtion, as&nbsp;an&nbsp;independent&nbsp;library,
 it&nbsp;<strong>doesn't need&nbsp;users to install&nbsp;Microsoft Office,&nbsp;Adobe Reader or any other 3rd party software/library on system</strong>.</p>
<p><strong>File Formats&nbsp;<strong>Supported&nbsp;</strong></strong></p>
<p>Spire.OfficeViewer supports&nbsp;<strong>DOC, DOCX, DOT, XLS, XLSX, XLSB, ODS, PPT, PPTX, PPS, PPSX
</strong>and <strong>PDF</strong>&nbsp;file formats.</p>
<p>&nbsp;</p>
<h1><strong>Main features in this sample</strong></h1>
<ul>
<li>Load office documents and PDF from file and view </li><li>Save as PDF and XPS file formats </li><li>Switch to target page </li><li>Fit page, Fit width, Fit height </li><li>Page down/up </li><li>Zoom in/out </li><li>Hand tool </li><li>Print </li></ul>
<p>&nbsp;</p>
<h1><strong>Preparations</strong></h1>
<p><strong>Add Controls to Toolbox</strong></p>
<ul>
<li>Right-click on Toolbox panel, click 'Add Tab' to add a new tab </li><li>Right-click the new tab and select 'Choose Items...' </li><li>Choose '.NET Framework Components' tab </li><li>Click 'Browse...' button </li><li>Choose 'Spire.OfficeViewer.Forms.dll' in open file dialog </li><li>Click 'OK', then the controls will be successfully added to Toolbox </li><li>Drag OfficeViewer control into Form. </li></ul>
<p>Just like following:</p>
<p><em><img id="159919" src="159919-add%20toolbox.gif" alt="">&nbsp; &nbsp;</em></p>
<p>It also allows developers to design custom buttons by just dragging <strong>DocumentViewer</strong>&nbsp;control&nbsp;instead of OfficeViewer into Form.</p>
<p>&nbsp;</p>
<h1>Using the Code</h1>
<p>Developers can use code as well as click the folder button to load documents.</p>
<p>Use below code to load a pdf document:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Windows.Forms.aspx" target="_blank" title="Auto generated link to System.Windows.Forms">System.Windows.Forms</a>;&nbsp;&nbsp;
&nbsp;&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;View_and_Print_Office_and_PDF_Documents&nbsp;&nbsp;
{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;Form1&nbsp;:&nbsp;Form&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Form1()&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.officeViewer1.LoadFromFile(@<span class="cs__string">&quot;E:\Program&nbsp;Files\Test.pdf&quot;</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
}&nbsp;&nbsp;
</pre>
</div>
</div>
</div>
<p><strong>Screenshot After running the code</strong></p>
<h1><img id="159925" src="159925-result.gif" alt=""></h1>
<p>&nbsp;</p>
<h1><strong>Download</strong></h1>
<p>Download <a href="http://www.e-iceblue.com/Download/download-spire-office-viewer-net.html ">
Spire.OfficeViewer</a>.</p>
<p>&nbsp;</p>
<p><strong>More Information</strong></p>
<p><strong>Related Links:</strong></p>
<p>Website:&nbsp;<a href="http://www.e-iceblue.com/">http://www.e-iceblue.com/</a></p>
<p>Product Home:&nbsp;<a href="http://www.e-iceblue.com/Introduce/word-for-net-introduce.html">http://www.e-iceblue.com/Introduce/spire-office-viewer-net.html</a></p>
<p>Forum:&nbsp;<a href="http://www.e-iceblue.com/forum/">http://www.e-iceblue.com/forum/</a></p>
