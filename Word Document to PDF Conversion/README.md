# Word Document to PDF Conversion.
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- C#
- Windows Forms
- WPF
- Microsoft Office Word
## Topics
- COM Interop
- .NET 4.5
## Updated
- 01/09/2014
## Description

<h1>Introduction</h1>
<p><em>In .NET no direct support for Word Document to PDF Document Conversion.</em></p>
<p><em>This sample of application explain how to Convert Document File such as .doc,.docx to PDF Documents. It is very easy to use and understand.<br>
</em></p>
<h1><span>Screen</span></h1>
<p><span><img id="106861" src="http://i1.code.msdn.s-msft.com/windowsdesktop/word-file-to-pdf-conversion-261fd865/image/file/106861/1/doc2pdf.gif" alt="" width="794" height="513"><br>
</span></p>
<h1><span>Building the Sample</span></h1>
<p><em>Add the following reference Assembly.</em></p>
<p><em>1) <a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/system.windows.forms.aspx" target="_blank" title="Auto generated link to system.windows.forms">system.windows.forms</a></em></p>
<p><em>2)<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/Microsoft.Office.Interop.Word.aspx" target="_blank" title="Auto generated link to Microsoft.Office.Interop.Word">Microsoft.Office.Interop.Word</a></em></p>
<p><em><img id="106817" src="106817-word%20reference.png" alt="" width="798" height="550"><br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>This Sample of application converts the .doc/.docx file to PDF document using WPF and C#. You can integrate into your application as per your requirement. With the help of this sample you can convert office file such as excel, presentation file into
 pdf in the same way.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
</em></p>
<p>&nbsp;Word2PDF Converter will convert any WORD document to a PDF file extension. If you have a .doc or a .docx file and you need it to be converted to a .PDF file, this program will do it simply and completely free. When you convert word to PDF free you
 will notice everything from images, text, columns, and anything else is included in the finished PDF file.</p>
<p><em>&nbsp;It is easy to use and easy to integrate in your application.&nbsp;&nbsp;&nbsp;&nbsp;</em></p>
<p><em><strong>Design Process:</strong><br>
</em></p>
<p><em>If you want to build this application Take one TextBox to display Source File Path Name and One Button to open the File DialogueBox. Take another TextBox to Display the Distination Path. One Button to convert the Button. Make sure that to add reference
 assembly&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
</em></p>
<p>Include the name space.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>


<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Imports</span>&nbsp;System.Windows&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;Microsoft.Office.Interop.Word&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Windows.Forms.aspx" target="_blank" title="Auto generated link to System.Windows.Forms">System.Windows.Forms</a></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>


<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;wordDocument()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Microsoft.Office.Interop.Word.Document&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;m_wordDocument&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_wordDocument&nbsp;=&nbsp;Value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
<span class="visualBasic__keyword">Private</span>&nbsp;m_wordDocument&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/Microsoft.Office.Interop.Word.Document.aspx" target="_blank" title="Auto generated link to Microsoft.Office.Interop.Word.Document">Microsoft.Office.Interop.Word.Document</a></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Write the following code on Browse Button Click Event.</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>


<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;btnBrowse_Click(sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;RoutedEventArgs)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;dlg&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/Microsoft.Win32.OpenFileDialog.aspx" target="_blank" title="Auto generated link to Microsoft.Win32.OpenFileDialog">Microsoft.Win32.OpenFileDialog</a>()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Set&nbsp;filter&nbsp;for&nbsp;file&nbsp;extension&nbsp;and&nbsp;default&nbsp;file&nbsp;extension</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;dlg.DefaultExt&nbsp;=&nbsp;<span class="visualBasic__string">&quot;.doc&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;dlg.Filter&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Word&nbsp;documents&nbsp;(.doc)|*.docx;*.doc&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Display&nbsp;OpenFileDialog&nbsp;by&nbsp;calling&nbsp;ShowDialog&nbsp;method</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;result&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Nullable(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>)&nbsp;=&nbsp;dlg.ShowDialog()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Get&nbsp;the&nbsp;selected&nbsp;file&nbsp;name&nbsp;and&nbsp;display&nbsp;in&nbsp;a&nbsp;TextBox</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;result&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Open&nbsp;document</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;filename&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;dlg.FileName&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FileNameTextBox.Text&nbsp;=&nbsp;filename&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Write the following code on convert button click event.</div>
</div>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>


<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;btnConvert_Click(sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;RoutedEventArgs)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;appWord&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/Microsoft.Office.Interop.Word.Application.aspx" target="_blank" title="Auto generated link to Microsoft.Office.Interop.Word.Application">Microsoft.Office.Interop.Word.Application</a>()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;wordDocument&nbsp;=&nbsp;appWord.Documents.Open(FileNameTextBox.Text)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;sfd&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;SaveFileDialog()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;sfd.Filter&nbsp;=&nbsp;<span class="visualBasic__string">&quot;PDF&nbsp;Documents|*.pdf&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;sfd.ShowDialog()&nbsp;=&nbsp;System.Windows.Forms.DialogResult.OK&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;ext&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.IO.Path.GetExtension.aspx" target="_blank" title="Auto generated link to System.IO.Path.GetExtension">System.IO.Path.GetExtension</a>(sfd.FileName)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Select</span>&nbsp;<span class="visualBasic__keyword">Case</span>&nbsp;ext&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Case</span>&nbsp;<span class="visualBasic__string">&quot;.pdf&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;wordDocument.ExportAsFixedFormat(sfd.FileName,&nbsp;WdExportFormat.wdExportFormatPDF)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Exit</span>&nbsp;<span class="visualBasic__keyword">Select</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Select</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pdfFileName.Text&nbsp;=&nbsp;sfd.FileName&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Windows.Forms.MessageBox.Show.aspx" target="_blank" title="Auto generated link to System.Windows.Forms.MessageBox.Show">System.Windows.Forms.MessageBox.Show</a>(<span class="visualBasic__string">&quot;File&nbsp;Converted&nbsp;Successfully..&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Catch</span>&nbsp;ex&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Exception&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Windows.Forms.MessageBox.Show.aspx" target="_blank" title="Auto generated link to System.Windows.Forms.MessageBox.Show">System.Windows.Forms.MessageBox.Show</a>(ex.Message)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Diagnostics.Process.Start.aspx" target="_blank" title="Auto generated link to System.Diagnostics.Process.Start">System.Diagnostics.Process.Start</a>(sfd.FileName)&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span></pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><a id="106818" href="/windowsdesktop/site/view/file/106818/1/DOC2PDF.zip">DOC2PDF.zip</a>
</li></ul>
<h1>More Information</h1>
<p><em>For more information on X, see ...?</em></p>
