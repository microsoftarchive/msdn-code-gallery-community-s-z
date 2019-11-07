# VB.Net Printing Example
## Requires
- Visual Studio 2008
## License
- Apache License, Version 2.0
## Technologies
- GDI+
- System.Drawing.Printing
## Topics
- Printing
## Updated
- 11/11/2016
## Description

<p><span style="font-size:small">For improved printing encapsulated in an extended DGV, see:</span></p>
<p><span style="font-size:small">&nbsp;</span><a href="https://code.msdn.microsoft.com/ExtendedDataGridView-5fa651f7" style="font-size:small">https://code.msdn.microsoft.com/ExtendedDataGridView-5fa651f7</a></p>
<p>&nbsp;</p>
<p><span style="font-size:small">Here's an example i wrote to answer a Code Gallery request.</span></p>
<p>&nbsp;</p>
<p><img src="59864-13-06-2012%2022.30.12.jpg" alt="" width="572" height="490"></p>
<p>&nbsp;</p>
<p><span style="font-size:small">The example shows how to print text &#43; a multiple page DataGridView using a PrintDocument Component &#43; GDI&#43;. It also shows how to preview your printing in a
<span class="selflink">System.Windows.Forms.PrintPreviewDialog</span>.</span></p>
<p><span style="font-size:small">This is designed &#43; written dynamically, i.e. it's not a one time code, it's versatile &#43; can be used for any multi (printed) page DataGridView. Try resizing the Columns or Rows &#43; you'll see what I mean.</span></p>
<p><span style="font-size:small">The majority of the code in this example is for calculating printed page ranges for printing the DataGridView. The actual printing is very simple, as it uses standard GDI&#43; techniques in the PrintDocument1_PrintPage event (<span class="selflink">System.Drawing.Printing.PrintDocument</span>).</span></p>
<p><span style="font-size:small">The Graphics Device Interface (GDI) is a Microsoft Windows application programming interface and core operating system component responsible for representing graphical objects and transmitting them to output devices such as
 monitors and printers.</span><br>
&nbsp;<br>
<span style="font-size:small">GDI is responsible for tasks such as drawing lines and curves, rendering fonts and handling palettes. VB.Net printing is far simpler &#43; faster than pre VB.Net versions of Visual Basic.</span></p>
<p><span style="font-size:small">If you find this example useful or helpful, please take the time to rate it, or if you have any questions, ask in the Questions &#43; Answers part of this page. Thanks.</span></p>
