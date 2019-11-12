# Set row height and column width for all cells in an Excel sheet using automation
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- Microsoft Office Excel
- Interop Excel
## Topics
- Excel Automation
- Excel ranges
## Updated
- 02/03/2016
## Description

<h1>Description</h1>
<p><span style="font-size:small">Many times developers are lost in how to write code in Microsoft Excel using Excel automation, they will search the web and find half-baked solutions, usually not complete ones ready to try out. This sample comes from a question
 asked on Stack Overflow asking how to set row height and column width for each cell in a worksheet. The code presented shows how to set the row height and column width for each cell unlike most examples out there which show how to do this for a range of cells,
 not the entire worksheet.</span></p>
<p><span style="font-size:small; background-color:#ffff99">Code is in VS2013 but should work fine with VS2010, VS2012 and VS2015</span><br>
<br>
<span style="font-size:small">The code to do so is extremely simple once you have a fair understanding of working with Excel automation but if a developer does not have experience then all the search on the web will be for not.</span><br>
<br>
<span style="font-size:small">The path is to create the proper objects where none of the objects make more than one call to a base object e.g. create the application then create a workbooks object followed by creating a workbook object and access the worksheets
 via the workbook is correct as we only make one call on each from any of the objects instead of app.workbooks.workbook.worksheets which in the end the objects may very well not be released and hang in memory.</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">Base code to set width and height</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>


<div class="preview">
<pre class="vb">xlCells&nbsp;=&nbsp;xlWorkSheet.Cells&nbsp;
<span class="visualBasic__keyword">Dim</span>&nbsp;EntireRow&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Excel.Range&nbsp;=&nbsp;xlCells.EntireRow&nbsp;
EntireRow.RowHeight&nbsp;=&nbsp;RowHeight&nbsp;
EntireRow.ColumnWidth&nbsp;=&nbsp;ColumnHeight</pre>
</div>
</div>
</div>
<p><span style="font-size:small">The base code shown above is part of a class method which has 100 lines of code, rather than show the code here please brows through the code online.</span></p>
<p><span style="font-size:small">All code except for one part is done both in C# and VB.NET, what I did not do a C# part is for creating a new Excel file and with a converter is simple to do.</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">To try out setting width and heigh, build the solution and run either demo_vb or demo_cs. Set the width and height via NumericUpDown controls and press the button. If all goes as expected a message box appears indicating the
 process is done or an error message indicating the file or sheet were not found. If successful open the Excel file and examine the changes.</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">Code to call the method to set width/height</span></p>
<p><span style="font-size:small">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>


<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;Form1&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;fileName&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory,&nbsp;<span class="visualBasic__string">&quot;Demo.xlsx&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;Form1_Load(sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;<span class="visualBasic__keyword">MyBase</span>.Load&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;demoCreate&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;CreateExcel(fileName)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;demoCreate.CreateFileIfMissing()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;setRowColumnButton.Enabled&nbsp;=&nbsp;IO.File.Exists(fileName)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;setRowColumnButton_Click(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;setRowColumnButton.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;Ops&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Operations&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.FileName&nbsp;=&nbsp;fileName,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.SheetName&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Sheet1&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.RowHeight&nbsp;=&nbsp;<span class="visualBasic__keyword">CInt</span>(NumericUpDownRowHeight.Value),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.ColumnHeight&nbsp;=&nbsp;<span class="visualBasic__keyword">CInt</span>(NumericUpDownColumn.Value)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;result&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;OperationReasons&nbsp;=&nbsp;Ops.SetRowHeightColumnWidth()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;result&nbsp;=&nbsp;OperationReasons.Success&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="visualBasic__string">&quot;Finished&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ElseIf</span>&nbsp;result&nbsp;=&nbsp;OperationReasons.FileNameFound&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="visualBasic__string">&quot;Failed&nbsp;to&nbsp;locate&nbsp;file&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ElseIf</span>&nbsp;result&nbsp;=&nbsp;OperationReasons.SheetNotFound&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="visualBasic__string">&quot;Failed&nbsp;to&nbsp;locate&nbsp;sheet&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><img id="148080" src="148080-aaaaa.jpg" alt="" width="252" height="168"></p>
<p>&nbsp;</p>
<h1><span style="font-size:large">Notes</span></h1>
<p><span style="font-size:small">The code is presented in windows forms but is not limited to form projects.</span></p>
