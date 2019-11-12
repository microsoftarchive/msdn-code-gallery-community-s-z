# WPF: Exporting Data from a DataGrid Control
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- WPF
- XAML
## Topics
- DataGrid
- Reflection
- threading
- CSV
## Updated
- 10/01/2013
## Description

<h1>Introduction</h1>
<p>This project provides an example of how you can export tabular data from a DataGrid control&nbsp;in WPF to a physical&nbsp;.csv (Comma Separated Values) file. The sample code is explained in more detail in the following wiki article:
<a href="http://social.technet.microsoft.com/wiki/contents/articles/19990.wpf-export-data-from-a-datagrid-control.aspx">
WPF: Export data from a DataGrid control</a></p>
<h1><span>Building the Sample</span></h1>
<p>You should be able to build the sample code in Visual Studio by just open the solution file that is included&nbsp;in the .zip file and compile the project. You don't need to change any settings before you run the application.</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>The sample code includes a C# class library with a public extension method to the
<em><a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Windows.Controls.DataGrid.aspx" target="_blank" title="Auto generated link to System.Windows.Controls.DataGrid">System.Windows.Controls.DataGrid</a></em> class that uses reflection to get the property values of each object in the source collection of ItemsSource property of the DataGrid.</p>
<p>It also includes a custom class that derives from the built-in <em>DataGrid</em> class and adds an export option to its context menu.</p>
<p>You should be able to add additional export formats by adding classes that implements the
<em>IExporter</em> interface.</p>
<h1><span>Source Code Files</span></h1>
<p>The solution consists of two projects;&nbsp;a sample WPF application with a single window and a DataGrid that is bound to a collection of
<em>Products</em> objects, and&nbsp;a C# class library where the export functionality is implemented.</p>
<h1>More Information</h1>
<p><em>For more information and explanations&nbsp;about the solution, see the following wiki article:
<br>
<a href="http://social.technet.microsoft.com/wiki/contents/articles/19990.wpf-export-data-from-a-datagrid-control.aspx">WPF: Exporting Data from a DataGrid Control</a></em></p>
