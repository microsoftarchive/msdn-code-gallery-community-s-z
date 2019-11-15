# Search Data From Database and Filter in Datagridview
## Requires
- Visual Studio 2012
## License
- MS-LPL
## Technologies
- SQL
- DataGridView
- Visual Studio 2012
## Topics
- C#
- SQL
- Search
- Visual Studio 2012
- Filter data
## Updated
- 02/10/2015
## Description

<p><strong>Introduction</strong></p>
<p>Today in this article I will show you how to search record in the database and then filter it in to the datagridview.</p>
<p><strong>What problem does the sample solve?</strong></p>
<p>Ans: This sample problem will solve a basic problem. The problem is that we need to search a record/data about something from a database on a GUI in a fast and easy way. So this is the solution this sample uses DataGridView to solve this problem.</p>
<p><strong>How does this sample solve the problem?</strong></p>
<p>How this sample code helps the user ?? So In this sample code users enters a query related to its requirment(according to database) in the text box and then record or data will fetch from the database and &nbsp;filter in the datagridview if it is exist in
 the database. It is &nbsp;same like google search bar.A user can use this code and make a search functionality in his application very easily.</p>
<ul>
</ul>
<p><strong>Diagram:</strong></p>
<p><strong><img id="133651" src="https://i1.code.msdn.s-msft.com/search-data-from-database-f2cb5d53/image/file/133651/1/database.jpg" alt="" width="650" height="382"><br>
</strong></p>
<p><strong>Variables:</strong></p>
<p>In this program we will use these variables.</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SqlConnection sqlconnection;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SqlCommand sqlcommand;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string ConnectionString = @&quot;Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Ehtesham Mehmood\Documents\Database1.mdf;Integrated Security=True;Connect Timeout=30&quot;;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string Query;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; DataSet dataset;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; DataTable datatable;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SqlDataAdapter sqladapter;</p>
<p><strong>Complete Program:</strong></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><strong>C#</strong></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">using&nbsp;System;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.ComponentModel.aspx" target="_blank" title="Auto generated link to System.ComponentModel">System.ComponentModel</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Data.aspx" target="_blank" title="Auto generated link to System.Data">System.Data</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Drawing.aspx" target="_blank" title="Auto generated link to System.Drawing">System.Drawing</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Text.aspx" target="_blank" title="Auto generated link to System.Text">System.Text</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Threading.Tasks.aspx" target="_blank" title="Auto generated link to System.Threading.Tasks">System.Threading.Tasks</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Windows.Forms.aspx" target="_blank" title="Auto generated link to System.Windows.Forms">System.Windows.Forms</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Data.SqlClient.aspx" target="_blank" title="Auto generated link to System.Data.SqlClient">System.Data.SqlClient</a>;&nbsp;
&nbsp;
namespace&nbsp;FilterValuesDataGridviewThrougTextBox&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;partial&nbsp;class&nbsp;Form1&nbsp;:&nbsp;Form&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;Form1()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__sl_comment">//global&nbsp;variables</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SqlConnection&nbsp;sqlconnection;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SqlCommand&nbsp;sqlcommand;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;ConnectionString&nbsp;=&nbsp;@<span class="js__string">&quot;Data&nbsp;Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Ehtesham&nbsp;Mehmood\Documents\Database1.mdf;Integrated&nbsp;Security=True;Connect&nbsp;Timeout=30&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;Query;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataSet&nbsp;dataset;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataTable&nbsp;datatable;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SqlDataAdapter&nbsp;sqladapter;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;
<span class="js__sl_comment">//This&nbsp;is&nbsp;the&nbsp;form&nbsp;load&nbsp;event</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;<span class="js__operator">void</span>&nbsp;Form1_Load(object&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//form&nbsp;load&nbsp;event&nbsp;here&nbsp;data&nbsp;will&nbsp;show&nbsp;in&nbsp;the&nbsp;data&nbsp;gridview</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sqlconnection=<span class="js__operator">new</span>&nbsp;SqlConnection(ConnectionString);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Query&nbsp;=&nbsp;<span class="js__string">&quot;select&nbsp;*&nbsp;from&nbsp;Student&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sqlcommand=<span class="js__operator">new</span>&nbsp;SqlCommand(Query,sqlconnection);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sqladapter=<span class="js__operator">new</span>&nbsp;SqlDataAdapter();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;datatable&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;DataTable();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sqladapter.SelectCommand=sqlcommand;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sqladapter.Fill(datatable);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dataGridView1.DataSource&nbsp;=&nbsp;datatable;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;
<span class="js__sl_comment">//This&nbsp;is&nbsp;the&nbsp;textchanged&nbsp;event&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;<span class="js__operator">void</span>&nbsp;textBox1_TextChanged(object&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//textchanged&nbsp;event&nbsp;of&nbsp;texbox&nbsp;when&nbsp;user&nbsp;enter&nbsp;a&nbsp;word&nbsp;in&nbsp;the&nbsp;textbox&nbsp;then&nbsp;through&nbsp;this&nbsp;dataview&nbsp;object&nbsp;string&nbsp;format&nbsp;it&nbsp;will&nbsp;filter&nbsp;and&nbsp;attached&nbsp;the&nbsp;filter&nbsp;result&nbsp;in&nbsp;to&nbsp;the&nbsp;datagridview</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataView&nbsp;DV&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;DataView(datatable);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DV.RowFilter&nbsp;=&nbsp;string.Format(<span class="js__string">&quot;Name&nbsp;LIKE&nbsp;'%{0}%'&quot;</span>,&nbsp;textBox1.Text);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dataGridView1.DataSource&nbsp;=&nbsp;DV;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
