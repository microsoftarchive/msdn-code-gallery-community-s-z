# WPF  Interop Excel  xls/xlsx  to DataSet
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- Excel
- WPF
- xls/xlsx
- Interop Excel
## Topics
- WPF
- Interop Excel
## Updated
- 01/14/2017
## Description

<h1>Introduction</h1>
<p><em>The example shows how to import Excel file to DataSet (all sheets).&nbsp;</em></p>
<p><em><strong>Excel</strong> creates XLS and XLSX files. These files are hard to read in C# programs. It is handled with the <a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/Microsoft.Office.Interop.Excel.aspx" target="_blank" title="Auto generated link to Microsoft.Office.Interop.Excel">Microsoft.Office.Interop.Excel</a> assembly.</em></p>
<p><em><strong>Interop.</strong> You must include a namespace to use Excel in your C# program.&nbsp;<br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>No special requirements.</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>Bring project. Build, run, select the file (xls, xlsx)... The file will be transferred to DataSet.&nbsp;</em></p>
<p><em>Application using DataGrid from &quot;WindowsFormsIntegration&quot;.</em></p>
<p><em>&nbsp;</em><span style="font-size:x-small">Ambiguous reference between data table (<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/Microsoft.Office.Interop.Excel.aspx" target="_blank" title="Auto generated link to Microsoft.Office.Interop.Excel">Microsoft.Office.Interop.Excel</a> vs. <a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Data.aspx" target="_blank" title="Auto generated link to System.Data">System.Data</a>)&nbsp;</span></p>
<pre class="commentable-title"><span style="font-size:x-small">-&nbsp;Just fully qualify the class as you desire:&nbsp;Instead of using DataTable, use:&nbsp;&nbsp; &nbsp; <a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Data.DataTable.aspx" target="_blank" title="Auto generated link to System.Data.DataTable">System.Data.DataTable</a><br> or &nbsp; <a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/Microsoft.Office.Interop.Excel.DataTable.aspx" target="_blank" title="Auto generated link to Microsoft.Office.Interop.Excel.DataTable">Microsoft.Office.Interop.Excel.DataTable</a></span></pre>
<p>&nbsp;</p>
<p><em><br>
</em></p>
<h1 class="title"><span style="font-size:small"><a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/Microsoft.Office.Interop.Excel.aspx" target="_blank" title="Auto generated link to Microsoft.Office.Interop.Excel">Microsoft.Office.Interop.Excel</a> namespace&nbsp;</span></h1>
<h1 class="title"><span style="font-size:small">&nbsp;</span><span style="font-size:10px">https://msdn.microsoft.com/en-us/library/microsoft.office.interop.excel(v=office.15).aspx</span></h1>
<div class="scriptcode">
<div class="pluginEditHolder">
<div class="title"><span>XAML</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span><span class="hidden">csharp</span>


<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;Window</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;WPFExcelXML&quot;</span>&nbsp;x:<span class="xaml__attr_name">Class</span>=<span class="xaml__attr_value">&quot;WPF_Interop_Excel.MainWindow&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">xmlns</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">wf</span>=<span class="xaml__attr_value">&quot;clr-namespace:<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Windows.Forms.aspx" target="_blank" title="Auto generated link to System.Windows.Forms">System.Windows.Forms</a>;assembly=System.Windows.Forms&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">x</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">xf</span>&nbsp;=<span class="xaml__attr_value">&quot;WindowsFormsIntegration&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">Title</span>=<span class="xaml__attr_value">&quot;WPF&nbsp;Excel&nbsp;XML&quot;</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;350&quot;</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;600&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span>&nbsp;<span class="xaml__attr_name">Background</span>=<span class="xaml__attr_value">&quot;#FFF0F0F0&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;0,10,0,0&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Button</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;btnSelectFile&quot;</span>&nbsp;<span class="xaml__attr_name">Content</span>=<span class="xaml__attr_value">&quot;Select&nbsp;File&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;0,14,10,0&quot;</span>&nbsp;<span class="xaml__attr_name">VerticalAlignment</span>=<span class="xaml__attr_value">&quot;Top&quot;</span>&nbsp;<span class="xaml__attr_name">Click</span>=<span class="xaml__attr_value">&quot;btnSelectFile_Click&quot;</span>&nbsp;<span class="xaml__attr_name">HorizontalAlignment</span>=<span class="xaml__attr_value">&quot;Right&quot;</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;101&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;WindowsFormsHost</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;0,41,0,0&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;wf</span>:DataGrid&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;DG&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/WindowsFormsHost&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBox</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;txtBoxFileName&quot;</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;23&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;10,13,116,0&quot;</span>&nbsp;<span class="xaml__attr_name">TextWrapping</span>=<span class="xaml__attr_value">&quot;Wrap&quot;</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;Select&nbsp;File&nbsp;Name&quot;</span>&nbsp;<span class="xaml__attr_name">VerticalAlignment</span>=<span class="xaml__attr_value">&quot;Top&quot;</span>&nbsp;<span class="xaml__attr_name">IsEnabled</span>=<span class="xaml__attr_value">&quot;False&quot;</span>&nbsp;<span class="xaml__attr_name">IsReadOnlyCaretVisible</span>=<span class="xaml__attr_value">&quot;True&quot;</span>&nbsp;<span class="xaml__attr_name">Foreground</span>=<span class="xaml__attr_value">&quot;#FF060606&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Grid&gt;</span>&nbsp;
<span class="xaml__tag_end">&lt;/Window&gt;</span>&nbsp;
</pre>
</div>
</div>
</div>
<h1><strong><span style="font-size:x-small">Windows Form's DataGrid wraped inside WindowsFormsHost&nbsp; element. &nbsp;</span></strong></h1>
<p><strong><span style="font-size:x-small">https://msdn.microsoft.com/en-us/library/system.windows.forms.integration.windowsformshost(v=vs.110).aspx&nbsp;</span></strong></p>
<p>&nbsp;</p>
<p>https://msdn.microsoft.com/en-us/library/15s06t57(VS.80).aspx&nbsp;</p>
<p>For Microsoft Office applications that do not have projects in Visual Studio Tools for Office, you must add a reference to the appropriate application or component to your project manually. Adding references to the primary interop assembly if the assembly
 is installed in the global assembly cache. Office applications and components are accessible from the
<strong>COM</strong> tab of the <strong>Add Reference</strong> dialog box.</p>
<p>If the primary interop assembly is not installed in the global assembly cache, Visual Studio generates an interop assembly for the project that might not work fully in all cases. For more information, see
<span class="linkTerms"><a href="https://msdn.microsoft.com/en-us/library/6s0wczt9(v=vs.80).aspx">Troubleshooting in Office at Run Time</a></span>.</p>
<div class="alert">
<table width="100%">
<tbody>
<tr>
<th align="left"><img class="note cl_IC103139" src=":-clear.gif?v=635677640377841095" alt="Note">Note</th>
</tr>
<tr>
<td>
<p>Some assemblies are added to a project automatically when an assembly that references them is added. For example, references to the assemblies Office.dll and Microsoft.Vbe.Interop.dll are added automatically when you add a reference to the Word, Excel, Outlook,
 Microsoft Forms, or Graph assemblies.</p>
</td>
</tr>
</tbody>
</table>
</div>
<p>For more information about installing Office primary interop assemblies, see <span class="linkTerms">
<a href="https://msdn.microsoft.com/en-us/library/kh3965hw(v=vs.80).aspx">How to: Install Office Primary Interop Assemblies</a></span>. For more information about adding references, see
<span class="linkTerms"><a href="https://msdn.microsoft.com/en-us/library/7314433t(v=vs.80).aspx">How to: Add and Remove References in Visual Studio (C#, J#)</a></span>.</p>
