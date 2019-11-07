# VSTO - Generate tables and charts by using an Excel add-in
## Requires
- Visual Studio 2013
## License
- MS-LPL
## Technologies
- VSTO
- Excel 2013
- Visual Studio 2013
- Office Development
- add
- custom task panes
## Topics
- Excel
- VSTO
- Excel Automation
- Office Addin
## Updated
- 04/29/2014
## Description

<h1>
<div class="endscriptcode">Introduction</div>
</h1>
<p>Excel Add-ins typically have no knowledge of what a worksheet contains. A typical add-in solution uses information that users select in custom UI's or in worksheet cells to perform some sort of service for the user that is not built into Excel.</p>
<p>The add-in featured in this sample serves folks who plan their retirement by using worksheets. The add-in assumes users will have a list of stock or mutual fund symbols somewhere in their worksheet. Users select a symbol, and then, from a custom task pane,&nbsp;
 generate a new worksheet that contains a table of historical stock prices and a chart that shows the performance of that stock over a period of time.</p>
<p>Here's a few things that you'll learn:</p>
<ul>
<li>How to create a custom task pane that interacts with a worksheet. </li><li>How to get data from a service and consume that data in your solution. </li><li>How to generate a new worksheet, a list object (table), and a chart that shows data from the service
</li><li>How to enable users to change the appearance and content of a list object and chart by using controls a custom task pane.
</li><li>How to remove the list object, chart, and worksheet when users choose a control in the custom task pane.
</li></ul>
<p>&nbsp;</p>
<h1>Requirements</h1>
<p>To run this sample, you'll need Visual Studio 2013, and Excel 2013 or Excel 2010. For more information about what you need to develop Office solutions in general, see
<a href="http://msdn.microsoft.com/library/bb398242">Configuring a Computer to Develop Office Solutions</a>.</p>
<h1>Building the Sample</h1>
<p><strong>To generate a sheet, table, and chart of data:</strong></p>
<ol>
<li>Press F5. </li><li>In Excel, create a new worksheet. </li><li>A custom task pane appears to the side of the worksheet. </li><li>Type a stock symbol such as &quot;MSFT&quot; into a cell. </li><li>Select another blank cell in the worksheet and then select the cell that contains the symbol that you just added.
</li><li>In the task pane, choose a start date, and then, select the <strong>Show price history for selected symbol
</strong>checkbox. </li></ol>
<p style="padding-left:30px">A new worksheet opens and a table of historical prices appear alongside a chart.</p>
<p><strong>To modify the contents and appearance of the table and chart by using controls in the task pane:</strong></p>
<ol>
<li>In the task pane, choose any of the table headings (for example: high or close) to show and hide that column in the table.
</li><li>Change the color theme of the table by choosing any of the radio color radio buttons.
</li><li>Change which column of data that the chart shows, the style of the chart or the color of the chart by using any of the combo boxes near the bottom of the task pane.
</li></ol>
<p><strong>To remove the table, chart, and sheet</strong></p>
<ul>
<li>Clear the Show price history for selected symbol checkbox to delete the sheet and the controls on it.
</li></ul>
<p>&nbsp;</p>
<h1>More Information</h1>
<p>For more information on Visual Studio Tools for Office (VSTO): <a href="http://msdn.microsoft.com/en-us/vsto/default.aspx" target="_blank">
http://msdn.microsoft.com/en-us/vsto/default.aspx</a>.</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<h1><em>&nbsp;</em></h1>
