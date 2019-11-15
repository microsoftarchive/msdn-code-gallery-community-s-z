# WPF Printing Overview
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- WPF
- XAML
## Topics
- viewport3D
- Printing
- InkCanvas
- DrawingVisual
- DrawingContext
- RenderTargetBitmap
- PrintDialog
- PrintVisual
- FlowDocumentReader
- FlowDocument
- DocumentPaginator
- XpsDocument
- FixedDocument
- FixedPage
- FileStream
- BinaryWriter
- VisualBrush
- JpegBitmapEncoder
- BitmapFrame
- PrintDocument
## Updated
- 09/19/2012
## Description

<h1>Introduction</h1>
<div>This sample shows five aspects of printing, in relation to WPF.</div>
<div>&nbsp;</div>
<h1><span>Building the Sample</span></h1>
<div>Just download, unblock, unzip, open &amp; run!</div>
<div>&nbsp;</div>
<h2><span style="font-size:20px">Description</span></h2>
<div><strong>&nbsp;</strong></div>
<div><strong>This sample accompanies a TechNet Wiki article that explains the five examples in much more depth:</strong></div>
<div></div>
<div><strong><a href="http://social.technet.microsoft.com/wiki/contents/articles/13025.wpf-printing-overview.aspx">http://social.technet.microsoft.com/wiki/contents/articles/13025.wpf-printing-overview.aspx</a></strong></div>
<div></div>
<div></div>
<div></div>
<h3>1. Using DrawingContext</h3>
<div>DrawingContext allows you to build up the print page, like a canvas. This method allows you to build up the page in code with many methods, like&nbsp;adding shapes, images and text.</div>
<div>&nbsp;
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;DrawingVisual&nbsp;dv&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DrawingVisual();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;dc&nbsp;=&nbsp;dv.RenderOpen();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;rect&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Rect(<span class="cs__keyword">new</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Windows.Point.aspx" target="_blank" title="Auto generated link to System.Windows.Point">System.Windows.Point</a>(<span class="cs__number">20</span>,&nbsp;<span class="cs__number">20</span>),&nbsp;<span class="cs__keyword">new</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Windows.Size.aspx" target="_blank" title="Auto generated link to System.Windows.Size">System.Windows.Size</a>(<span class="cs__number">350</span>,&nbsp;<span class="cs__number">240</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;dc.DrawRoundedRectangle(<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Windows.Media.Brushes.Yellow.aspx" target="_blank" title="Auto generated link to System.Windows.Media.Brushes.Yellow">System.Windows.Media.Brushes.Yellow</a>,&nbsp;<span class="cs__keyword">new</span>&nbsp;Pen(Brushes.Purple,&nbsp;<span class="cs__number">2</span>),&nbsp;rect,&nbsp;<span class="cs__number">20</span>,&nbsp;<span class="cs__number">20</span>);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<h3>2. Printing WPF Controls</h3>
<div>WPF is specially good at printing, bacause you can print the rendered WPF controls, exactly as they are.&nbsp;You can also save to file or apply the image to another surface (technique sometimes used in reflections)</div>
<div></div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">&nbsp;&nbsp;&nbsp;&nbsp;PrintDialog&nbsp;dialog&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;PrintDialog();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(dialog.ShowDialog()&nbsp;!=&nbsp;true)&nbsp;<span class="js__statement">return</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;printGrid.Measure(<span class="js__operator">new</span>&nbsp;Size(dialog.PrintableAreaWidth,&nbsp;dialog.PrintableAreaHeight));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;printGrid.Arrange(<span class="js__operator">new</span>&nbsp;Rect(<span class="js__operator">new</span>&nbsp;Point(<span class="js__num">50</span>,&nbsp;<span class="js__num">50</span>),&nbsp;printGrid.DesiredSize));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;dialog.PrintVisual(printGrid,&nbsp;<span class="js__string">&quot;A&nbsp;WPF&nbsp;printing&quot;</span>);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<h3>3. Printing Flow Documents</h3>
<div>Flow documents are a great way to display formatted content and easy to print. The FlowDocumentReader is a rich user control, and printing pages can be controlled with the DocumentPaginator.</div>
<div></div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">&nbsp;&nbsp;&nbsp;&nbsp;PrintDialog&nbsp;printDialog&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;PrintDialog();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(printDialog.ShowDialog()&nbsp;==&nbsp;true)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;printDialog.PrintDocument(((IDocumentPaginatorSource)flowDocument).DocumentPaginator,&nbsp;<span class="js__string">&quot;This&nbsp;is&nbsp;a&nbsp;Flow&nbsp;Document&quot;</span>);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<h3>4. Making and Printing XPS Documents</h3>
<div>XPS is a popular printing format, and is easy to make out of WPF controls. This example shows how to use the XpsDocumentWriter to build the file.</div>
<div></div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;FixedDocument&nbsp;doc&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;FixedDocument();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;PageContent&nbsp;pageContent&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PageContent();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;((<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Windows.Markup.IAddChild.aspx" target="_blank" title="Auto generated link to System.Windows.Markup.IAddChild">System.Windows.Markup.IAddChild</a>)pageContent).AddChild(page);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;doc.Pages.Add(pageContent);&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;XpsDocument&nbsp;xpsd&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;XpsDocument(filename,&nbsp;FileAccess.Write);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;XpsDocument.CreateXpsDocumentWriter(xpsd).Write(doc);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;xpsd.Close();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;PrintDialog&nbsp;printDialog&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PrintDialog();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(printDialog.ShowDialog()&nbsp;==&nbsp;<span class="cs__keyword">true</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;printDialog.PrintQueue.AddJob(<span class="cs__string">&quot;MyInkCanvas&nbsp;print&nbsp;job&quot;</span>,&nbsp;filename,&nbsp;<span class="cs__keyword">true</span>);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<h3>5. Capturing and Saving Video Stills</h3>
<div>This example shows how you can &quot;scrub&quot; through a video and pull out frames to file and printer. A slider bar is joined to the MediaElement to allow scene selection.</div>
<div>&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;screenshot&nbsp;=&nbsp;GetScreenShot(player,&nbsp;<span class="cs__number">1</span>,&nbsp;<span class="cs__number">90</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;FileStream&nbsp;fileStream&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;FileStream(filename,&nbsp;FileMode.Create,&nbsp;FileAccess.ReadWrite);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;BinaryWriter&nbsp;binaryWriter&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;BinaryWriter(fileStream);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;binaryWriter.Write(screenshot);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;binaryWriter.Close();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;PrintDocument&nbsp;pd&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PrintDocument();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;pd.PrintPage&nbsp;&#43;=&nbsp;(<span class="cs__keyword">object</span>&nbsp;printSender,&nbsp;PrintPageEventArgs&nbsp;printE)&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;img&nbsp;=&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Drawing.Image.FromFile.aspx" target="_blank" title="Auto generated link to System.Drawing.Image.FromFile">System.Drawing.Image.FromFile</a>(filename);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;printE.Graphics.DrawImageUnscaled(img,&nbsp;<span class="cs__keyword">new</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Drawing.Point.aspx" target="_blank" title="Auto generated link to System.Drawing.Point">System.Drawing.Point</a>(<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;PrintDialog&nbsp;dialog&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PrintDialog();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;dialog.ShowDialog();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;pd.Print();&nbsp;</pre>
</div>
</div>
</div>
<h2>6. Landscape Printing</h2>
<div></div>
<div>This example shows how to print in Landscape, and how the choice of control and it's parent container affect what is printed.</div>
<div></div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">private&nbsp;<span class="js__operator">void</span>&nbsp;Button_Click2(object&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;PrintDialog&nbsp;printDialog&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;PrintDialog();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;printDialog.PrintTicket.PageOrientation&nbsp;=&nbsp;PageOrientation.Landscape;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;printDialog.PrintVisual(printBlock,&nbsp;<span class="js__string">&quot;Landscape&nbsp;working&nbsp;TextBox&nbsp;print&quot;</span>);&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
In this example, there are two printing buttons. the first prints the parent grid, which prints the buttons, scrollviewer and it's contents. This shows as a cut off print. The second example prints the TextBlock itself, which is inside a ScrollViewer, so is
 not actually constrained at all.</div>
<div><br>
<br>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li>MainWindow - Using DrawingContext </li><li>Window1 - Printing WPF Controls </li><li>Window2 - Printing Flow Documents </li><li>Window3 - XPS (make &amp; print) </li><li>Window4 - Saving &amp; Printing Video Stills </li><li>Window5 - Landscape Printing </li></ul>
<h1><em>&nbsp;</em>&nbsp;</h1>
<p><span style="font-size:small"><strong>Don't forget to read:</strong></span></p>
<p><span style="font-size:small"><strong><a href="http://social.technet.microsoft.com/wiki/contents/articles/13025.wpf-printing-overview.aspx">http://social.technet.microsoft.com/wiki/contents/articles/13025.wpf-printing-overview.aspx</a></strong></span></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><img src="http://213.163.64.28/aniThanks1.gif" alt="" style="margin-right:auto; margin-left:auto; display:block"></p>
