# Visual Basic Print text to Printer
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- Windows General
## Topics
- Printing
## Updated
- 02/25/2013
## Description

<h1>Introduction</h1>
<p><em>This sample uses the systems default printer to Print Text. The PrintDocument class has been used&nbsp;for this purpose so&nbsp;external reference of any library is not required.</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>The sample uses the following libraries,</em></p>
<p><em><a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.IO.aspx" target="_blank" title="Auto generated link to System.IO">System.IO</a><br>
<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Drawing.aspx" target="_blank" title="Auto generated link to System.Drawing">System.Drawing</a><br>
<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Drawing.Printing.aspx" target="_blank" title="Auto generated link to System.Drawing.Printing">System.Drawing.Printing</a></em></p>
<p><em>So no building configuration or reference addition is required</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>The sample contains a simple windows form with RictTexBox &amp; Button Controls.</em></p>
<p><em>It uses PrintDocument, Font Classes for printing text to the printer.</em></p>
<p><em>This sample mainly concentrates on printing a plain text to the systems default printer.</em></p>
<p><em>The text typed in the RichTextBox can be printed by clicking Print Button.</em></p>
<p><em>PrintDocument class is used in the sample for printing the text. </em></p>
<p><em>PrintDocumnt performs printing by calling the system's default printer. </em>
</p>
<p><em>PrintDocument Page Print Event handler takes care of the printing operation.<br>
In this sample, based on the no of lines in the RichTextBox, the no of pages<br>
to be printed has been calculted using the selected Font size.</em></p>
<p>&nbsp;<img id="76426" src="76426-print.png" alt="" width="488" height="277"></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Dim</span>&nbsp;printDoc&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;PrintDocument()&nbsp;
printDoc.Print()&nbsp;
&nbsp;
&nbsp;
<span class="visualBasic__keyword">While</span>&nbsp;curLineCount&nbsp;&lt;&nbsp;linesPerPage&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;(RichTextBox1.Lines.Length&nbsp;-&nbsp;<span class="visualBasic__number">1</span>)&nbsp;&lt;&nbsp;totalLineCount&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;line&nbsp;=&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Exit</span>&nbsp;<span class="visualBasic__keyword">While</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;line&nbsp;=&nbsp;RichTextBox1.Lines(totalLineCount)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;yPos&nbsp;=&nbsp;topMargin&nbsp;&#43;&nbsp;curLineCount&nbsp;*&nbsp;printFont.GetHeight(e.Graphics)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawString(line,&nbsp;printFont,&nbsp;Brushes.Black,&nbsp;leftMargin,&nbsp;yPos,&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;StringFormat())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;curLineCount&nbsp;&#43;=&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;totalLineCount&nbsp;&#43;=&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">While</span></pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>Form1&nbsp;- Text Print Sample</em> </li></ul>
<h1>More Information</h1>
<p><em>For more information on PrintDocument, see </em></p>
<p><em><a href="http://msdn.microsoft.com/en-us/library/system.drawing.printing.printdocument.aspx?cs-save-lang=1&cs-lang=vb">http://msdn.microsoft.com/en-us/library/system.drawing.printing.printdocument.aspx?cs-save-lang=1&amp;cs-lang=vb</a></em></p>
