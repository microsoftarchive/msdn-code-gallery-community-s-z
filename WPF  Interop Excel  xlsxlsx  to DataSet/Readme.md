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
<p><em><strong>Excel</strong> creates XLS and XLSX files. These files are hard to read in C# programs. It is handled with the Microsoft.Office.Interop.Excel assembly.</em></p>
<p><em><strong>Interop.</strong> You must include a namespace to use Excel in your C# program.&nbsp;<br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>No special requirements.</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>Bring project. Build, run, select the file (xls, xlsx)... The file will be transferred to DataSet.&nbsp;</em></p>
<p><em>Application using DataGrid from &quot;WindowsFormsIntegration&quot;.</em></p>
<p><em>&nbsp;</em><span style="font-size:x-small">Ambiguous reference between data table (Microsoft.Office.Interop.Excel vs. System.Data)&nbsp;</span></p>
<pre class="commentable-title"><span style="font-size:x-small">-&nbsp;Just fully qualify the class as you desire:&nbsp;Instead of using DataTable, use:&nbsp;&nbsp; &nbsp; System.Data.DataTable<br> or &nbsp; Microsoft.Office.Interop.Excel.DataTable</span></pre>
<p>&nbsp;</p>
<p><em><br>
</em></p>
<h1 class="title"><span style="font-size:small">Microsoft.Office.Interop.Excel namespace&nbsp;</span></h1>
<h1 class="title"><span style="font-size:small">&nbsp;</span><span style="font-size:10px">https://msdn.microsoft.com/en-us/library/microsoft.office.interop.excel(v=office.15).aspx</span></h1>
<div class="scriptcode">
<div class="pluginEditHolder">
<div class="title"><span>XAML</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span><span class="hidden">csharp</span>
<pre class="hidden">&lt;Window x:Name=&quot;WPFExcelXML&quot; x:Class=&quot;WPF_Interop_Excel.MainWindow&quot;
        xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;
        xmlns:wf=&quot;clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms&quot; 
        xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;
        xmlns:xf =&quot;WindowsFormsIntegration&quot;
        Title=&quot;WPF Excel XML&quot; Height=&quot;350&quot; Width=&quot;600&quot;&gt;
    &lt;Grid Background=&quot;#FFF0F0F0&quot; Margin=&quot;0,10,0,0&quot;&gt;
        &lt;Button x:Name=&quot;btnSelectFile&quot; Content=&quot;Select File&quot; Margin=&quot;0,14,10,0&quot; VerticalAlignment=&quot;Top&quot; Click=&quot;btnSelectFile_Click&quot; HorizontalAlignment=&quot;Right&quot; Width=&quot;101&quot;/&gt;

        &lt;WindowsFormsHost Margin=&quot;0,41,0,0&quot;&gt;
            &lt;wf:DataGrid x:Name=&quot;DG&quot; /&gt;
        &lt;/WindowsFormsHost&gt;
        &lt;TextBox x:Name=&quot;txtBoxFileName&quot; Height=&quot;23&quot; Margin=&quot;10,13,116,0&quot; TextWrapping=&quot;Wrap&quot; Text=&quot;Select File Name&quot; VerticalAlignment=&quot;Top&quot; IsEnabled=&quot;False&quot; IsReadOnlyCaretVisible=&quot;True&quot; Foreground=&quot;#FF060606&quot;/&gt;

    &lt;/Grid&gt;
&lt;/Window&gt;
</pre>
<pre class="hidden">using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using Microsoft.Office.Interop.Excel;

namespace WPF_Interop_Excel
{
    /// &lt;summary&gt;
    /// Interaction logic for MainWindow.xaml
    /// &lt;/summary&gt;
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private System.Data.DataSet excelDataSet;

        private void btnSelectFile_Click(object sender, RoutedEventArgs e)
        {
            // https://msdn.microsoft.com/en-us/library/microsoft.win32.filedialog.filter(v=vs.110).aspx

            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = &quot;&quot;; // Default file name
            dlg.DefaultExt = &quot;.xlsx&quot;; // Default file extension
            dlg.Filter = &quot;Excel documents (*.xlsx, *.xls)|*.xlsx;*.xls|All files (*.*)|*.*&quot;; // Filter files by extension 

            // Show open file dialog box
            Nullable&lt;bool&gt; result = dlg.ShowDialog();

            // Process open file dialog box results 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                txtBoxFileName.Text = filename;

                try { importExcelFile(filename); }
                catch (Exception ex) { ;}
            }
        }


        private DataSet importExcelFile(string fileName)
        {
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

            System.Data.DataSet ds = new System.Data.DataSet();
            Workbook wkBook = excelApp.Workbooks.Open(fileName, 0, true, 5, &quot;&quot;, &quot;&quot;, true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, &quot;\t&quot;, false, false, 0, true, 1, 0);

            ds.DataSetName = wkBook.Name;

            foreach (Worksheet ws in wkBook.Worksheets)
            {
                ds.Merge(importExcelSheet(ws));
                ds.AcceptChanges();
            }

            System.Windows.Forms.DataGridTableStyle tstyle = new System.Windows.Forms.DataGridTableStyle();
            tstyle.AllowSorting = true;
            tstyle.RowHeaderWidth = 0;

            DG.TableStyles.Add(tstyle);

            DG.NavigateBack();
            DG.NavigateBack();
            DG.DataSource = ds;

            excelApp.Quit();
            releaseObject(excelApp);
            releaseObject(wkBook);

            return ds;
        }


        private System.Data.DataTable importExcelSheet(Worksheet ws)
        {
            Range range = ws.UsedRange; ;

            string str = &quot;&quot;;
            int rCnt = 0;
            int cCnt = 0;

            System.Data.DataTable dt = new System.Data.DataTable();
            dt.TableName = ws.Name;

            //first excel row - column's name row...
            // column's name should not be empty ...
            try
            {
                for (cCnt = 1; cCnt &lt;= range.Columns.Count; cCnt&#43;&#43;)
                {
                    str = (string)(range.Cells[1, cCnt] as Range).Value2;
                    if (str != null) dt.Columns.Add(str,System.Type.GetType(&quot;System.String&quot;));
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf(&quot;belongs&quot;) != 0)
                {
                    MessageBox.Show(&quot; Duplicate Column Name in worksheet - [&quot; &#43; ws.Name &#43; &quot;]...&quot; &#43; Environment.NewLine &#43; &quot; Please fix/change column name - [&quot; &#43; str &#43; &quot;]&quot; &#43; Environment.NewLine &#43; &quot; and try again! &quot;, &quot;Column name MUST be unique! &quot;);
                }
                else
                {
                    MessageBox.Show(ex.Message, &quot;Error during reading Excel file! &quot;);               
                }
                return null;
            }

            // next - data

                for (rCnt = 2; rCnt &lt;= range.Rows.Count; rCnt&#43;&#43;)
                {
                    String strSum = &quot;&quot;;
                    DataRow dr = dt.NewRow();
                    for (cCnt = 1; cCnt &lt;= dt.Columns.Count; cCnt&#43;&#43;)
                    {
                        var x = (range.Cells[rCnt, cCnt] as Range).Value2;
                        if (x != null)
                        {
                            str = x.ToString();
                        }
                        else 
                        {
                            str = &quot;&quot;;
                        }

                        dr[cCnt - 1] = str;
                        strSum &#43;= str;  // Do not insert empty row ...
                    }
                    if (strSum.Trim() != &quot;&quot;) dt.Rows.Add(dr);
                }

            dt.AcceptChanges();
            releaseObject(ws);
            return dt;
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show(&quot;Unable to release the Object &quot; &#43; ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }



    }
}
</pre>
<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;Window</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;WPFExcelXML&quot;</span>&nbsp;x:<span class="xaml__attr_name">Class</span>=<span class="xaml__attr_value">&quot;WPF_Interop_Excel.MainWindow&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">xmlns</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">wf</span>=<span class="xaml__attr_value">&quot;clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms&quot;</span>&nbsp;&nbsp;
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
