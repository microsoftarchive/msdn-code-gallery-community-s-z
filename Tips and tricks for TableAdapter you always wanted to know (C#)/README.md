# Tips and tricks for TableAdapter you always wanted to know (C#)
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- SQL Server
- DataSet
- TableAdapter
## Topics
- Data Binding
- Data Access
- DataGridView
- Master/Detail
- TableAdapter
- data relations
## Updated
- 12/10/2017
## Description

<h1>Introduction</h1>
<p><span style="font-size:small">This code sample deals with TableAdapters and DataSets.&nbsp; If you never worked with them before here is an overview from Microsoft.</span></p>
<p><span style="font-size:small">TableAdapters are designer-generated components that connect to a database, run queries or stored procedures, and fill their DataTable with the returned data. TableAdapters also send updated data from your application back to
 the database. You can run as many queries as you want on a TableAdapter as long as they return data that conforms to the schema of the table with which the TableAdapter is associated. The following diagram shows how TableAdapters interact with databases and
 other objects in memory.</span></p>
<p><span style="font-size:small">Using generated components as per above is simply one way to communicate with databases. Other methods include manage data providers and Entity Framework.</span></p>
<p><span style="font-size:small">Many novice developers seem to prefer using TableAdapters I believe because they appear to be less work than using managed data providers or Entity Framework (also, a developer may be using Microsoft Access database which Entity
 Framework does not support). At first glance they are great, you use Visual Studio data wizards to generate components and then drag data objects to a form which in turn places controls onto the form which are data bound to these controls such as DataGridView
 and/or TextBox, ComboBox controls and so forth. But as we get more complex they can be harder to work with if the developer never learns fully about this way of working with data. So let&rsquo;s dig in to a few things that I want to focus on.</span></p>
<p>&nbsp;</p>
<h1><span>Building the Sample</span></h1>
<p><span style="font-size:small">Before running the sample, you need to add the database to your SQL-Server instance, I've included the script under the DataScripts folder.&nbsp; In app.config, change the connection string property, Data Source from KARENS-PC
 to the name of your SQL-Server or to SQLEXPRESS.</span></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><span style="font-size:small">One of the first things is after you drag items from the Data Source window onto a form you notice there is a BindingNavigator which have buttons for add/edit/delete operations. Check out
<a href="https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/bindingnavigator-control-overview-windows-forms">
BindingNavigator overview</a> (include an image).</span></p>
<p><span style="font-size:small">Once the form is showing at runtime, you&rsquo;ve selected a record in a DataGridView which is setup to work with a BindingNavigator you press the delete button what happens is the current record is removed but not saved back
 to the database until you press the save button next to the delete button. Suppose the user pressed the delete by mistake, the only recourse is to close the app as there are no un-dues.</span></p>
<p><span style="font-size:small">A better way to handle a delete operation is to override the default action. This is done by selecting the BindingNavigator, select properties, find Items, select DeleteItem, there is a dropdown, select none.</span></p>
<p><span style="font-size:small"><img id="183472" src="183472-1.jpg" alt="" width="473" height="176"></span></p>
<p><span style="font-size:small">Next, double click the delete button in the BindingNavigator to create an event. Added code to ask the user to confirm the removal. Below is code from the included project.</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">private&nbsp;<span class="js__operator">void</span>&nbsp;bindingNavigatorDeleteItem_Click(object&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(KarenDialogs.Question(<span class="js__string">&quot;Do&nbsp;you&nbsp;really&nbsp;want&nbsp;to&nbsp;remove&nbsp;the&nbsp;current&nbsp;customer?&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;customersBindingSource.RemoveCurrent();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">It looks like this (you could also place the company name in the dialog) and note the default button is &quot;No&quot;.</span></div>
<div class="endscriptcode"><span style="font-size:small"><br>
</span></div>
<div class="endscriptcode"><span style="font-size:small"><img id="183473" src="183473-2.jpg" alt="" width="448" height="352"></span></div>
<div class="endscriptcode"><span style="font-size:small; color:#ffffff">.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:small">In the included code sample (which is a master-details sample) I do the same with the save button, override it and add my own code to save both master and details data.</span></div>
<div class="endscriptcode"><span style="font-size:small">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;customersBindingNavigatorSaveItem_Click_1(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(KarenDialogs.Question(<span class="cs__string">&quot;Save&nbsp;changes&nbsp;back&nbsp;to&nbsp;database?&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Validate();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.customersBindingSource.EndEdit();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__mlcom">/*&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;Manually&nbsp;added&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.ordersBindingSource.EndEdit();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.tableAdapterManager.UpdateAll(<span class="cs__keyword">this</span>.northWindDataSet);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">Then added a label, TextBox and button to the BindingNavigator to show we can add functionality (the hardest part is finding an proper image for the button).&nbsp;</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">Here is a super simple filter which I'm sure you can write a better one :-) I kept it simple so it would be easy to follow.</div>
<div class="endscriptcode"><span style="color:#ffffff">.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><img id="183474" src="183474-3.jpg" alt="" width="525" height="143"></div>
<br>
</span></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;searchByCompanyName_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!<span class="cs__keyword">string</span>.IsNullOrWhiteSpace(companyNameSearchToolStripTextBox1.Text))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;customersBindingSource.Filter&nbsp;=&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$<span class="cs__string">&quot;CompanyName&nbsp;LIKE&nbsp;'{companyNameSearchToolStripTextBox1.Text.Replace(&quot;</span><span class="cs__string">'&quot;,&quot;'</span><span class="cs__string">'&quot;)}%'</span>&quot;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;customersBindingSource.Filter&nbsp;=&nbsp;<span class="cs__string">&quot;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="background-color:#ffff00">Before going any farther with thoughts on improving how we code with TableAdapters/BindingSource/DataSet</span>...</div>
<div class="endscriptcode"></div>
<h1 class="endscriptcode">How to create a master detail</h1>
<div class="endscriptcode">
<ol>
<li><span style="font-size:small">Add your master and detail tables via the data source window (<a href="https://msdn.microsoft.com/en-us/library/tzedkwye.aspx">the following</a> explains doing one table, repeat for the second table)</span>
</li><li><span style="font-size:small">Drag tables to the form, the master first which will create a BindingNavigator while the details will not, we really can add our own if needed and wire it up. I would first place a splitter control on the form and drag the
 tables into the splitter (as done in the attached code sample).</span> </li><li><span style="font-size:small">In the following code sample which is taken from the code sample, the TableAdapter.Fill lines were generated when dropping the tables on the form while the lines below I added. They setup the relationship between the master
 and detail tables. Note, you should first set the relations in the database using SQL command or in SQL-Server Management Studio.</span>
</li></ol>
</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js"><span class="js__operator">this</span>.ordersTableAdapter.Fill(<span class="js__operator">this</span>.northWindDataSet.Orders);&nbsp;
<span class="js__operator">this</span>.customersTableAdapter.Fill(<span class="js__operator">this</span>.northWindDataSet.Customers);&nbsp;
&nbsp;
<span class="js__ml_comment">/*&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;Manually&nbsp;added,&nbsp;next&nbsp;two&nbsp;lines&nbsp;so&nbsp;we&nbsp;have&nbsp;the&nbsp;master&nbsp;and&nbsp;details&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;working&nbsp;together.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
<span class="js__operator">this</span>.ordersBindingSource.DataSource&nbsp;=&nbsp;customersBindingSource;&nbsp;
ordersBindingSource.DataMember&nbsp;=&nbsp;northWindDataSet.Relations[<span class="js__num">0</span>].RelationName;</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">After the above we have details DataGridView showing data for the current row in the master DataGridView.</span>&nbsp;</div>
<div class="endscriptcode"><span style="color:#ffffff">.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:small">Since the column headers in both DataGridView controls are taken from generated code you should change the HeaderText for each column in the DataGridView properties or as I did (and here I had decent
 field names) split up names e.g. FirstName column turns into First Name.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js"><span class="js__ml_comment">/*&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;Split&nbsp;Header&nbsp;text&nbsp;by&nbsp;upper-case&nbsp;characters&nbsp;in&nbsp;the&nbsp;master&nbsp;DataGridView&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
foreach&nbsp;(DataGridViewColumn&nbsp;col&nbsp;<span class="js__operator">in</span>&nbsp;customersDataGridView.Columns)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;col.HeaderText&nbsp;=&nbsp;System.Text&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.RegularExpressions&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Regex.Replace(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;col.HeaderText,&nbsp;<span class="js__string">&quot;([a-z])([A-Z])&quot;</span>,&nbsp;<span class="js__string">&quot;$1&nbsp;$2&quot;</span>);&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">The same was done for the details DataGridView.</span>&nbsp;</div>
<div class="endscriptcode"></div>
<h1 class="endscriptcode">Get current row data</h1>
<div class="endscriptcode"><span style="font-size:small">We can get to the current row via casting the BindingSource.Current to a DataRowView then access the Row (DataRow) property then finally Field&lt;T&gt;.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js"><span class="js__statement">if</span>&nbsp;(customersBindingSource.Current&nbsp;!=&nbsp;null)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;row&nbsp;=&nbsp;((DataRowView)customersBindingSource.Current).Row;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(row.Field&lt;string&gt;(<span class="js__string">&quot;CompanyName&quot;</span>));&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<h1 class="endscriptcode">Changing row data</h1>
<div class="endscriptcode"><span style="font-size:small">By default we can edit in place in the DataGridView but suppose the database was poorly designed (and this database is). For example, here one field is ContactTitle. There is no reference table so if
 the user typed in shop owner and that is not valid you have to either validate it or how valid selections in a DataGridViewComboBox column (I have samples for this,
<a href="https://code.msdn.microsoft.com/Working-with-data-in-a-e24664d9">here is one</a>)&nbsp;or perhaps a modal window can be used to provide validation. Rather than show the code you can see it in the attached sample, here is a screenshot.</span></div>
<div class="endscriptcode"><span style="font-size:small"><br>
</span></div>
<div class="endscriptcode"><span style="font-size:small"><img id="183476" src="183476-4.jpg" alt="" width="460" height="247"></span></div>
<div class="endscriptcode"><span style="font-size:small"><br>
</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:small">Note that I used a strong typed class that was generated by the data wizard to pass data to the modal form.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:small"><img id="183477" src="183477-5.jpg" alt="" width="460" height="49"></span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:small">The standard documentation show locating a entity (in this case a customer) via</span></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">northWindDataSet&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.Customers&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.FindByCustomerIdentifier(x)</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">Where x in this case is the primary key to locate. In most cases you will not have that identifier but instead will need to get it from the current row in a DataGridView. The best way to get at the
 current row is through the BindingSource component e.g.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:small">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js"><span class="js__statement">var</span>&nbsp;id&nbsp;=&nbsp;((DataRowView)customersBindingSource.Current)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.Row.Field&lt;int&gt;(<span class="js__string">&quot;CustomerIdentifier&quot;</span>);</pre>
</div>
</div>
</div>
</span>
<div class="endscriptcode"></div>
</div>
<div class="endscriptcode"><span style="font-size:small">From here (using the above code) we can get at a strong typed class instance, CustomerRow.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">NorthWindDataSet.CustomersRow&nbsp;cust&nbsp;=&nbsp;northWindDataSet&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.Customers.FirstOrDefault(c&nbsp;=&gt;&nbsp;c.CustomerIdentifier&nbsp;==&nbsp;id);</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">A good example of the last two code snippets in use is in the key down event in the code sample.</span>&nbsp;</div>
</div>
</div>
<div class="endscriptcode"><span style="color:#ffffff">.</span></div>
<div class="endscriptcode"><span style="font-size:small"><br>
</span></div>
<div class="endscriptcode"><span style="font-size:small">In the image below you can see what was generated (which includes CustomersRow)</span></div>
<div class="endscriptcode"><span style="font-size:small; color:#ffffff">.</span></div>
<div class="endscriptcode"><span style="font-size:small"><img id="183478" src="183478-6.jpg" alt="" width="537" height="630"><br>
</span></div>
</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:small"><br>
</span></div>
<h1 class="endscriptcode">Using images rather than text</h1>
<p><span style="font-size:small"><em>First off the following was added after the initial publishing, seemed this would be a benefit to include</em></span>.</p>
<p><span style="font-size:small">Suppose there is limited space to display information where a image can convey a meaning that takes up less space than text e.g. in the following screenshot the image signifies customer standing where gold (well perhaps yellow)
 signifies a very good customer, silver is a platinum customer and blue is a regular customer.</span></p>
<p><span style="font-size:small"><img id="183499" src="183499-11.jpg" alt="" width="249" height="428"></span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">How I managed the above, added a reference table.</span></p>
<p><span style="font-size:small"><img id="183500" src="183500-12.jpg" alt="" width="257" height="554"></span></p>
<p><span style="font-size:small">Created three records to CustomerType, set text (thinking the data could be used in other places besides a DataGridView) then added the images via SQL.</span></p>
<p><span style="font-size:x-small">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="mysql"><span class="sql__keyword">UPDATE</span>&nbsp;&nbsp;<span class="sql__id">CustomerType</span>&nbsp;
<span class="sql__keyword">SET</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">StandingImage</span>&nbsp;=&nbsp;(&nbsp;<span class="sql__keyword">SELECT</span>&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">FROM</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">OPENROWSET</span>(<span class="sql__id">BULK</span>&nbsp;<span class="sql__id">N</span><span class="sql__string">'C:\Circles\circle_Gold.jpg'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">SINGLE_BLOB</span>)&nbsp;<span class="sql__id">CategoryImage</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;)&nbsp;
<span class="sql__keyword">WHERE</span>&nbsp;&nbsp;&nbsp;<span class="sql__id">id</span>&nbsp;=&nbsp;<span class="sql__number">1</span>;&nbsp;
<span class="sql__keyword">UPDATE</span>&nbsp;&nbsp;<span class="sql__id">CustomerType</span>&nbsp;
<span class="sql__keyword">SET</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">StandingImage</span>&nbsp;=&nbsp;(&nbsp;<span class="sql__keyword">SELECT</span>&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">FROM</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">OPENROWSET</span>(<span class="sql__id">BULK</span>&nbsp;<span class="sql__id">N</span><span class="sql__string">'C:\Circles\circle_grey.jpg'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">SINGLE_BLOB</span>)&nbsp;<span class="sql__id">CategoryImage</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;)&nbsp;
<span class="sql__keyword">WHERE</span>&nbsp;&nbsp;&nbsp;<span class="sql__id">id</span>&nbsp;=&nbsp;<span class="sql__number">2</span>;&nbsp;
<span class="sql__keyword">UPDATE</span>&nbsp;&nbsp;<span class="sql__id">CustomerType</span>&nbsp;
<span class="sql__keyword">SET</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">StandingImage</span>&nbsp;=&nbsp;(&nbsp;<span class="sql__keyword">SELECT</span>&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">FROM</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">OPENROWSET</span>(<span class="sql__id">BULK</span>&nbsp;<span class="sql__id">N</span><span class="sql__string">'C:\Circles\circle_blue.jpg'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">SINGLE_BLOB</span>)&nbsp;<span class="sql__id">CategoryImage</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;)&nbsp;
<span class="sql__keyword">WHERE</span>&nbsp;&nbsp;&nbsp;<span class="sql__id">id</span>&nbsp;=&nbsp;<span class="sql__number">3</span>;</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">In SQL Server Management Studio created a query that would be used in the code sample.</span></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="mysql"><span class="sql__keyword">SELECT</span>&nbsp;&nbsp;<span class="sql__id">Customers</span>.<span class="sql__id">CustomerIdentifier</span>&nbsp;,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">Customers</span>.<span class="sql__id">CompanyName</span>&nbsp;,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">Customers</span>.<span class="sql__id">ContactName</span>&nbsp;,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">Customers</span>.<span class="sql__id">ContactTitle</span>&nbsp;,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">Address</span>]&nbsp;,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">Customers</span>.<span class="sql__id">City</span>&nbsp;,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">CustomerType</span>.<span class="sql__id">StandingImage</span>&nbsp;
<span class="sql__keyword">FROM</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">Customers</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">INNER</span>&nbsp;<span class="sql__keyword">JOIN</span>&nbsp;<span class="sql__id">CustomerType</span>&nbsp;<span class="sql__keyword">ON</span>&nbsp;<span class="sql__id">Customers</span>.<span class="sql__id">Standing</span>&nbsp;=&nbsp;<span class="sql__id">CustomerType</span>.<span class="sql__id">id</span>;</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">Validated the above query then in the .xsd designer file in our project added a new TableAdapter&nbsp;</span></div>
&nbsp;</div>
<img id="183501" src="183501-13.jpg" alt="" width="474" height="491">
<p>&nbsp;</p>
<p><span style="font-size:x-small"><br>
</span></p>
<p><span style="font-size:small">Added another form to our project, dragged CustomerWithStanding onto the form. From here I setup the HeaderText for the DataGridView in the designer unlike how the first form's DataGridView was done via code.</span></p>
<p><span style="font-size:small"><img id="183502" src="183502-14.jpg" alt="" width="229" height="168"></span></p>
<p><span style="font-size:small">Now as it stands, the image is selectable so the following code is used to disallow the standings column from being selected.</span></p>
<p><span style="font-size:small">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;CustomerWithStandingDataGridView_SelectionChanged(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(customerWithStandingDataGridView.Columns[customerWithStandingDataGridView.CurrentCell.ColumnIndex].Name&nbsp;==&nbsp;<span class="cs__string">&quot;standingsImageColumn&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;customerWithStandingDataGridView.CurrentCell.Selected&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">Using a language extension method (located in DataGridViewExtensions class)&nbsp;&nbsp;</span></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">customerWithStandingDataGridView.ExpandColumns();</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">&nbsp;Since the SELECT used for the above uses a reference table save is not enabled but add, edit and remove are enabled. So I enabled save, added a click event and placed a MessageBox within indicating
 the fact there is no save, did this for the CRUD buttons also. If you wanted to perform a save you need to setup the update not based on the current SELECT as it does not a) contain the image we display b) as mentioned above we used a reference table. I will
 add another code sample later to show how to implement a save.</span></div>
<p>&nbsp;</p>
<h1 class="endscriptcode"><span style="font-size:medium">Dealing with errors</span></h1>
<div class="endscriptcode"><span style="font-size:small">You can check for errors via DataSet.HasErrors e.g.</span></div>
<div class="endscriptcode"><span style="font-size:small">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">///&nbsp;&lt;summary&gt;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;If&nbsp;you&nbsp;need&nbsp;to&nbsp;check&nbsp;for&nbsp;errors&nbsp;prior&nbsp;to&nbsp;saving.&nbsp;This&nbsp;method&nbsp;is</span>&nbsp;
<span class="js__sl_comment">///&nbsp;currently&nbsp;incomplete&nbsp;in&nbsp;that&nbsp;all&nbsp;it&nbsp;does&nbsp;is&nbsp;check&nbsp;for&nbsp;errors&nbsp;for</span>&nbsp;
<span class="js__sl_comment">///&nbsp;each&nbsp;row&nbsp;in&nbsp;the&nbsp;data&nbsp;set.&nbsp;Note&nbsp;the&nbsp;commented&nbsp;lines,&nbsp;they&nbsp;provide</span>&nbsp;
<span class="js__sl_comment">///&nbsp;access&nbsp;to&nbsp;the&nbsp;errors&nbsp;so&nbsp;you&nbsp;can&nbsp;decide&nbsp;how&nbsp;to&nbsp;handle&nbsp;them.</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;/summary&gt;</span>&nbsp;
private&nbsp;bool&nbsp;FindErrors()&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;int&nbsp;errorCount&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(northWindDataSet.HasErrors)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;foreach&nbsp;(DataTable&nbsp;table&nbsp;<span class="js__operator">in</span>&nbsp;northWindDataSet.Tables)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(table.HasErrors)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;foreach&nbsp;(DataRow&nbsp;row&nbsp;<span class="js__operator">in</span>&nbsp;table.Rows)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(row.HasErrors)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Process&nbsp;error&nbsp;here.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//row.RowError</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//row.GetColumnError</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//row.GetColumnsInError&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;errorCount&nbsp;&#43;=&nbsp;<span class="js__num">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
In the code sample above all that is done is to see if there are error yet it would be prudent to find out what the errors are via the properties available which are commented out. You could use an error provider component to set up error messages for instance
 so that the user can correct the errors. Rather than providing an exact way to deal with them as each developer will have their own idea on this I leave it to the reader to implement this.</span></div>
<div class="endscriptcode"><span style="font-size:small"><br>
</span></div>
</div>
<h1 class="endscriptcode"><span style="font-size:medium">Validating data in DataSets</span></h1>
<div class="endscriptcode"><span style="font-size:small">This is covered in the following
<a href="https://msdn.microsoft.com/en-us/library/kx9x2fsb.aspx?f=255&MSPPError=-2147217396">
MSDN documentation</a>. In the MSDN documentation there is mention of working with DataTable events, if you would like to explore these events then check out
<a href="https://code.msdn.microsoft.com/Get-changes-for-a-11413e32">my MSDN code sample</a> for DataTable events which shows how to (and this might seem easy at first) access deleted row information.</span></div>
<div class="endscriptcode"></div>
<h1 class="endscriptcode"><span style="font-size:medium">Next steps</span></h1>
<div class="endscriptcode"><span style="font-size:small">All of the above the code resides in the project and forms within the project. Next step is to learn how to separate your data layer from the presentation layer (the forms) which may include if you
 elect too is to create the data layer in another (class) project. For this go to the following
<a href="https://msdn.microsoft.com/en-us/library/bb384587.aspx">web page</a> which complete covers this.</span></div>
<div class="endscriptcode"></div>
<h1 class="endscriptcode"><span style="font-size:medium">What can go wrong?</span></h1>
<div class="endscriptcode"><span style="font-size:small">The most common thing I see on the forums is a developer decides to change the database schema e.g. add or remove columns in one or more tables. While doing so when they regenerate the strong type classes
 they get compile errors that can range from one or more items not recognized to forms not opening.</span></div>
<div class="endscriptcode"><span style="font-size:small; color:#ffffff">.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:small">To assist with this the best advise is prior to making any of the above changes is to fully backup the project. Backing up the project (and in some cases the solution) can be as simple as copying the
 entire project folder or using a source control application or service such as Microsoft Team Foundation server which for small teams is cheap compared to taking your chances without any backup or copying the project folder.</span></div>
<div class="endscriptcode"></div>
<h1 class="endscriptcode"><span style="font-size:medium">Other directions</span></h1>
<div class="endscriptcode"><span style="font-size:small">Using managed data providers. Here you code everything which at first may seem like a lot of work yet you are in complete control.</span></div>
<div class="endscriptcode"><span style="font-size:small; color:#ffffff">.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:small">Using Entity Framework, Entity Framework 6 allows you to create a database and table then create strong typed classes from these items. Accessing and changing data is a tad less than using a mangaged
 data provider and once you have worked with Entity Framework fro a while most developer will never go back to TableAdapters or managed data providers. What you should go next is move up to the latest version of Entity Framework which does not provide a visual
 canvas (as does Entity Framework 6) to work from yet after working with this you'll see the benefits to working with Entity Framework.</span></div>
<div class="endscriptcode"><span style="font-size:small; color:#ffffff">.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:small">If you have read this far I assume you are a desktop developer so take a look at my code sample for Entity Framework for Windows forms to get a handle on Entity Framework for desktop applications, see
 if this is for you or not.</span></div>
<div class="endscriptcode"><span style="font-size:small; color:#ffffff">.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:small"><a href="https://code.msdn.microsoft.com/Entity-Framework-in-764fa5ba?redir=0">Entity Framework in Windows forms</a>.</span></div>
<div class="endscriptcode"><span style="font-size:small">.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:small"><img id="183481" src="183481-10.jpg" alt="" width="600" height="377"><br>
</span></div>
<div class="endscriptcode"><span style="font-size:small"><br>
</span></div>
</div>
<div class="endscriptcode"><span style="font-size:x-small"><br>
</span></div>
</div>
<div class="endscriptcode"><span style="font-size:small"><br>
</span></div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><span style="font-size:small"><br>
</span></p>
<p><span style="font-size:small"><br>
</span></p>
<p><span style="font-size:small"><br>
</span></p>
<p><span style="font-size:small"><br>
</span></p>
