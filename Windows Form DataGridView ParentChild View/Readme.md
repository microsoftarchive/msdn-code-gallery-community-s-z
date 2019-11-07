# Windows Form DataGridView Parent/Child View
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- Windows Forms
- Microsoft Office Access
## Topics
- Data Binding
- ADO.NET
- DataSet
- DataGridView
## Updated
- 02/21/2013
## Description

<h1>Introduction</h1>
<p><em>This example demonstrates a Windows Forms equivalent to the Microsoft Access one-to-many form by binding a DataSet containing a DataRelation between 2 DataTables to a DataGridView resulting in Parent/Child views.<br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>This sample was built using Visual Studio 2010.<br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em><em><strong></strong></em><strong></strong></em>In Microsoft Access you can create a form that contains a subform (a one-to-many form) which is useful when working with relational data.&nbsp; For this sample we'll use the Customer Orders scenario giving
 the user a way to view both Customer and related Order data at the same time by creating a Parent/Child view on a Windows Form using DataGridViews.&nbsp; This is accomplished through the use of a DataRelation between two DataTable objects in a DataSet which
 are bound to DataGridViews.</p>
<p>Below is a code snippet from Form1.cs which creates the DataSet, DataTables, DataRelation, adds test data, and binds the data to DataGridViews.</p>
<p><em>The purpose of this sample is to fulfill a code sample request.&nbsp; I hope this helps.</em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormSubformEquivalent
{
    /// &lt;summary&gt;
    /// This class demonstrates the use of DataTables and DataRelations,
    /// creating Master/Child views to mimic a one-to-many form 
    /// (form/subform) in Microsoft Access.  This should be considered a 
    /// starting point.
    /// &lt;/summary&gt;
    public partial class Form1 : Form
    {
        private DataTable tblCustomer;
        private DataTable tblOrder;
        private DataSet tblDataSet;

        public Form1()
        {
            InitializeComponent();

            // Create Tables
            tblCustomer = new DataTable(&quot;tblCustomer&quot;);
            tblOrder = new DataTable(&quot;tblOrder&quot;);

            // Create DataSet
            tblDataSet = new DataSet();

            // Create Columns and Add to Tables
            tblCustomer.Columns.Add(&quot;ID&quot;, typeof(int));
            tblCustomer.Columns.Add(&quot;CustomerName&quot;, typeof(string));
            tblOrder.Columns.Add(&quot;ID&quot;, typeof(int));
            tblOrder.Columns.Add(&quot;Order&quot;, typeof(string));
            tblOrder.Columns.Add(&quot;CustomerID&quot;, typeof(int));

            // Add Test Data
            tblCustomer.Rows.Add(1, &quot;Jane Doe&quot;);
            tblCustomer.Rows.Add(2, &quot;John Smith&quot;);
            tblCustomer.Rows.Add(3, &quot;Richard Roe&quot;);
            tblOrder.Rows.Add(1, &quot;Order1.1&quot;, 1);
            tblOrder.Rows.Add(2, &quot;Order1.2&quot;, 1);
            tblOrder.Rows.Add(3, &quot;Order1.3&quot;, 1);
            tblOrder.Rows.Add(4, &quot;Order2.1&quot;, 2);
            tblOrder.Rows.Add(5, &quot;Order3.1&quot;, 3);
            tblOrder.Rows.Add(6, &quot;Order3.2&quot;, 3);
            
            // Add Tables to DataSet
            tblDataSet.Tables.Add(tblCustomer);
            tblDataSet.Tables.Add(tblOrder);

            // Create Relation
            tblDataSet.Relations.Add(&quot;CustOrderRelation&quot;,
                tblCustomer.Columns[&quot;ID&quot;], tblOrder.Columns[&quot;CustomerID&quot;]);

            BindingSource bsCustomer = new BindingSource();
            bsCustomer.DataSource = tblDataSet;
            bsCustomer.DataMember = &quot;tblCustomer&quot;;

            BindingSource bsOrder = new BindingSource();
            bsOrder.DataSource = bsCustomer;
            bsOrder.DataMember = &quot;CustOrderRelation&quot;;

            // Bind Data to DataGridViews
            dgvCustomer.DataSource = bsCustomer;
            dgvOrder.DataSource = bsOrder;
        }
    }
}
</pre>
<div class="preview">
<pre id="codePreview" class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Collections.Generic;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.ComponentModel;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Data;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Drawing;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Linq;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Text;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Windows.Forms;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;FormSubformEquivalent&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;This&nbsp;class&nbsp;demonstrates&nbsp;the&nbsp;use&nbsp;of&nbsp;DataTables&nbsp;and&nbsp;DataRelations,</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;creating&nbsp;Master/Child&nbsp;views&nbsp;to&nbsp;mimic&nbsp;a&nbsp;one-to-many&nbsp;form&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;(form/subform)&nbsp;in&nbsp;Microsoft&nbsp;Access.&nbsp;&nbsp;This&nbsp;should&nbsp;be&nbsp;considered&nbsp;a&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;starting&nbsp;point.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;Form1&nbsp;:&nbsp;Form&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;DataTable&nbsp;tblCustomer;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;DataTable&nbsp;tblOrder;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;DataSet&nbsp;tblDataSet;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Form1()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Create&nbsp;Tables</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tblCustomer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DataTable(<span class="cs__string">&quot;tblCustomer&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tblOrder&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DataTable(<span class="cs__string">&quot;tblOrder&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Create&nbsp;DataSet</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tblDataSet&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DataSet();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Create&nbsp;Columns&nbsp;and&nbsp;Add&nbsp;to&nbsp;Tables</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tblCustomer.Columns.Add(<span class="cs__string">&quot;ID&quot;</span>,&nbsp;<span class="cs__keyword">typeof</span>(<span class="cs__keyword">int</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tblCustomer.Columns.Add(<span class="cs__string">&quot;CustomerName&quot;</span>,&nbsp;<span class="cs__keyword">typeof</span>(<span class="cs__keyword">string</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tblOrder.Columns.Add(<span class="cs__string">&quot;ID&quot;</span>,&nbsp;<span class="cs__keyword">typeof</span>(<span class="cs__keyword">int</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tblOrder.Columns.Add(<span class="cs__string">&quot;Order&quot;</span>,&nbsp;<span class="cs__keyword">typeof</span>(<span class="cs__keyword">string</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tblOrder.Columns.Add(<span class="cs__string">&quot;CustomerID&quot;</span>,&nbsp;<span class="cs__keyword">typeof</span>(<span class="cs__keyword">int</span>));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Add&nbsp;Test&nbsp;Data</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tblCustomer.Rows.Add(<span class="cs__number">1</span>,&nbsp;<span class="cs__string">&quot;Jane&nbsp;Doe&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tblCustomer.Rows.Add(<span class="cs__number">2</span>,&nbsp;<span class="cs__string">&quot;John&nbsp;Smith&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tblCustomer.Rows.Add(<span class="cs__number">3</span>,&nbsp;<span class="cs__string">&quot;Richard&nbsp;Roe&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tblOrder.Rows.Add(<span class="cs__number">1</span>,&nbsp;<span class="cs__string">&quot;Order1.1&quot;</span>,&nbsp;<span class="cs__number">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tblOrder.Rows.Add(<span class="cs__number">2</span>,&nbsp;<span class="cs__string">&quot;Order1.2&quot;</span>,&nbsp;<span class="cs__number">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tblOrder.Rows.Add(<span class="cs__number">3</span>,&nbsp;<span class="cs__string">&quot;Order1.3&quot;</span>,&nbsp;<span class="cs__number">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tblOrder.Rows.Add(<span class="cs__number">4</span>,&nbsp;<span class="cs__string">&quot;Order2.1&quot;</span>,&nbsp;<span class="cs__number">2</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tblOrder.Rows.Add(<span class="cs__number">5</span>,&nbsp;<span class="cs__string">&quot;Order3.1&quot;</span>,&nbsp;<span class="cs__number">3</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tblOrder.Rows.Add(<span class="cs__number">6</span>,&nbsp;<span class="cs__string">&quot;Order3.2&quot;</span>,&nbsp;<span class="cs__number">3</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Add&nbsp;Tables&nbsp;to&nbsp;DataSet</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tblDataSet.Tables.Add(tblCustomer);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tblDataSet.Tables.Add(tblOrder);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Create&nbsp;Relation</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tblDataSet.Relations.Add(<span class="cs__string">&quot;CustOrderRelation&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tblCustomer.Columns[<span class="cs__string">&quot;ID&quot;</span>],&nbsp;tblOrder.Columns[<span class="cs__string">&quot;CustomerID&quot;</span>]);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BindingSource&nbsp;bsCustomer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;BindingSource();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bsCustomer.DataSource&nbsp;=&nbsp;tblDataSet;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bsCustomer.DataMember&nbsp;=&nbsp;<span class="cs__string">&quot;tblCustomer&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BindingSource&nbsp;bsOrder&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;BindingSource();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bsOrder.DataSource&nbsp;=&nbsp;bsCustomer;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bsOrder.DataMember&nbsp;=&nbsp;<span class="cs__string">&quot;CustOrderRelation&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Bind&nbsp;Data&nbsp;to&nbsp;DataGridViews</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvCustomer.DataSource&nbsp;=&nbsp;bsCustomer;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvOrder.DataSource&nbsp;=&nbsp;bsOrder;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<h1><img src="21209-parentchild1.png" alt="" width="681" height="270"></h1>
<p><img src="21210-parentchild2.png" alt="" width="682" height="270"></p>
<p><img src="21211-parentchild3.png" alt="" width="684" height="270"></p>
<h1>More Information</h1>
<p><a href="http://msdn.microsoft.com/en-us/library/system.data.dataset.aspx">DataSet Class</a><a></a></p>
<p><a href="http://msdn.microsoft.com/en-us/library/system.data.datatable.aspx">DataTable Class</a></p>
<p><a href="http://msdn.microsoft.com/en-us/library/system.data.datarelation.aspx">DataRelation Class</a></p>
<p><a href="http://msdn.microsoft.com/en-us/library/system.windows.forms.datagridview.aspx">DataGridView Class</a></p>
<p><span style="font-size:20px; font-weight:bold">About the Author</span></p>
<p><strong>Brandon Williams,</strong> <span style="color:#999999">MCITP, MCTS, MCC</span></p>
<p>I can be found on the <a title="MSDN Forums" href="http://social.msdn.microsoft.com/Forums/en-US/sqlreplication/threads/" target="_blank">
SQL Server Replication Forum</a> on MSDN.</p>
<p>I aslo have a <a title="Brandon Williams | SQLREPL" href="http://www.sqlrepl.com">
blog about SQL Server Replication</a>.</p>
