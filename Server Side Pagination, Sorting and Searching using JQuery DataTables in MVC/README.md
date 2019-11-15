# Server Side Pagination, Sorting and Searching using JQuery DataTables in MVC
## Requires
- Visual Studio 2015
## License
- Apache License, Version 2.0
## Technologies
- SQL Server
- ASP.NET MVC
- Entity Framework
- JQuery DataTables
## Topics
- C#
- ASP.NET MVC
- Entity Framework
- ASP.NET MVC 5
- JQuery DataTables
## Updated
- 02/10/2017
## Description

<h1>Introduction</h1>
<p><em><span>This article explains how we can implement the server side pagination, searching and sorting in a grid using jquery datatables &nbsp;which is of course a better approach in the long run or for the applications where datasets are too big.</span></em></p>
<h1><span>Building the Sample</span></h1>
<p><em>There is file named <strong>dbscript.txt,</strong> you would need to create database with reqired tables and some data in the tables using the script which can be found in the solution, and after that you will need to modify the connection string of
 the database in the <strong>web.config</strong> which will be used by Entity Framework to query records :</em></p>
<p><em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&lt;add&nbsp;name=<span class="cs__string">&quot;DefaultConnection&quot;</span>&nbsp;connectionString=<span class="cs__string">&quot;Data&nbsp;Source=(localdb)\MSSQLLocalDB;Initial&nbsp;Catalog=TrialAssignment-Joseph;Integrated&nbsp;Security=True;MultipleActiveResultSets=true&quot;</span>&nbsp;providerName=<span class="cs__string">&quot;System.Data.SqlClient&quot;</span>&nbsp;/&gt;&nbsp;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
</em>
<p></p>
<p><em><br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>First of all we will install&nbsp;<a href="https://www.nuget.org/packages/datatables.mvc5/">datatables.mvc5</a>&nbsp;, Go to&nbsp;<strong>Tools &gt;&gt; NuGet Package Manager &gt;&gt; Manage Nuget Packages for Solution</strong>&nbsp;and click it, and search
 for <strong>datatables.mvc5</strong>&nbsp;package and install it :</p>
<p><img src="https://2.bp.blogspot.com/-YY5HPOhZkZM/V6pEWQWJPBI/AAAAAAAADU4/60GJhWO3uHgRnssdad818BzVd2kR9o2gwCLcB/s1600/datatables.mvc5.png" alt=""></p>
<p>&nbsp;</p>
<p>Create a html table that would be used for populating the records in the view :</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="html"><span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;row&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;col-md-12&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;panel&nbsp;panel-primary&nbsp;list-panel&quot;</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;list-panel&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;panel-heading&nbsp;list-panel-heading&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;h1</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;panel-title&nbsp;list-panel-title&quot;</span><span class="html__tag_start">&gt;</span>Assets<span class="html__tag_end">&lt;/h1&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;panel-body&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;table</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;assets-data-table&quot;</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;table&nbsp;table-striped&nbsp;table-bordered&quot;</span>&nbsp;<span class="html__attr_name">style</span>=<span class="html__attr_value">&quot;width:100%;&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/table&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
<span class="html__tag_end">&lt;/div&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>Next, initilaize the datatables with the needed properties on the html table created above :</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">@section&nbsp;Scripts&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&lt;script&nbsp;type=<span class="js__string">&quot;text/javascript&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;assetListVM;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;assetListVM&nbsp;=&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt:&nbsp;null,&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;init:&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt&nbsp;=&nbsp;$(<span class="js__string">'#assets-data-table'</span>).DataTable(<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;serverSide&quot;</span>:&nbsp;true,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;processing&quot;</span>:&nbsp;true,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;ajax&quot;</span>:&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;url&quot;</span>:&nbsp;<span class="js__string">&quot;@Url.Action(&quot;</span>Get<span class="js__string">&quot;,&quot;</span>Asset<span class="js__string">&quot;)&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;columns&quot;</span>:&nbsp;[&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__string">&quot;title&quot;</span>:&nbsp;<span class="js__string">&quot;Bar&nbsp;Code&quot;</span>,&nbsp;<span class="js__string">&quot;data&quot;</span>:&nbsp;<span class="js__string">&quot;BarCode&quot;</span>,&nbsp;<span class="js__string">&quot;searchable&quot;</span>:&nbsp;true&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__string">&quot;title&quot;</span>:&nbsp;<span class="js__string">&quot;Manufacturer&quot;</span>,&nbsp;<span class="js__string">&quot;data&quot;</span>:&nbsp;<span class="js__string">&quot;Manufacturer&quot;</span>,&nbsp;<span class="js__string">&quot;searchable&quot;</span>:&nbsp;true&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__string">&quot;title&quot;</span>:&nbsp;<span class="js__string">&quot;Model&quot;</span>,&nbsp;<span class="js__string">&quot;data&quot;</span>:&nbsp;<span class="js__string">&quot;ModelNumber&quot;</span>,&nbsp;<span class="js__string">&quot;searchable&quot;</span>:&nbsp;true&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__string">&quot;title&quot;</span>:&nbsp;<span class="js__string">&quot;Building&quot;</span>,&nbsp;<span class="js__string">&quot;data&quot;</span>:&nbsp;<span class="js__string">&quot;Building&quot;</span>,&nbsp;<span class="js__string">&quot;searchable&quot;</span>:&nbsp;true&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__string">&quot;title&quot;</span>:&nbsp;<span class="js__string">&quot;Room&nbsp;No&quot;</span>,&nbsp;<span class="js__string">&quot;data&quot;</span>:&nbsp;<span class="js__string">&quot;RoomNo&quot;</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__string">&quot;title&quot;</span>:&nbsp;<span class="js__string">&quot;Quantity&quot;</span>,&nbsp;<span class="js__string">&quot;data&quot;</span>:&nbsp;<span class="js__string">&quot;Quantity&quot;</span>&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;],&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;lengthMenu&quot;</span>:&nbsp;[[<span class="js__num">10</span>,&nbsp;<span class="js__num">25</span>,&nbsp;<span class="js__num">50</span>,&nbsp;<span class="js__num">100</span>],&nbsp;[<span class="js__num">10</span>,&nbsp;<span class="js__num">25</span>,&nbsp;<span class="js__num">50</span>,&nbsp;<span class="js__num">100</span>]],&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span class="js__sl_comment">//&nbsp;initialize&nbsp;the&nbsp;datatables</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;assetListVM.init();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;
&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p><span>We also need reference the&nbsp;</span><strong>System.Linq.Dynamic</strong><span>&nbsp;namespace as we will be using the methods provided for dynamic linq in our action, for that go to Nuget Package Manager once again and search for&nbsp;</span><strong>System.Linq.Dynamic</strong><span>&nbsp;package
 and install it in your project.</span></p>
<p>&nbsp;</p>
<p><img src="https://3.bp.blogspot.com/--R7svGG0SIY/V6pEw5uofvI/AAAAAAAADVA/eBFRcH2gc-s91aQKSe6vdfvzJ_pwpmBKwCLcB/s1600/linq.dynamic%2Bnuget.png" alt=""></p>
<p>&nbsp;</p>
<p><span>Finally we will write the controller action part where the datatable parameters will be posted and using those we will be performing search, ordering and paging :</span></p>
<p><em>You can include <em><strong>code snippets,&nbsp;</strong></em><strong>images</strong>,
<strong>videos</strong>. &nbsp;&nbsp;</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;Get([ModelBinder(<span class="cs__keyword">typeof</span>(DataTablesBinder))]&nbsp;IDataTablesRequest&nbsp;requestModel)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;IQueryable&lt;asset&gt;&nbsp;query&nbsp;=&nbsp;DbContext.Assets;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;totalCount&nbsp;=&nbsp;query.Count();<span class="cs__preproc">&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#region&nbsp;Filtering</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span class="cs__com">//&nbsp;Apply&nbsp;filters&nbsp;for&nbsp;searching</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(requestModel.Search.Value&nbsp;!=&nbsp;<span class="cs__keyword">string</span>.Empty)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;<span class="cs__keyword">value</span>&nbsp;=&nbsp;requestModel.Search.Value.Trim();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;query&nbsp;=&nbsp;query.Where(p&nbsp;=&gt;&nbsp;p.Barcode.Contains(<span class="cs__keyword">value</span>)&nbsp;||&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;p.Manufacturer.Contains(<span class="cs__keyword">value</span>)&nbsp;||&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;p.ModelNumber.Contains(<span class="cs__keyword">value</span>)&nbsp;||&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;p.Building.Contains(<span class="cs__keyword">value</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;filteredCount&nbsp;=&nbsp;query.Count();<span class="cs__preproc">&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#endregion&nbsp;Filtering</span><span class="cs__preproc">&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#region&nbsp;Sorting</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span class="cs__com">//&nbsp;Sorting</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;sortedColumns&nbsp;=&nbsp;requestModel.Columns.GetSortedColumns();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;orderByString&nbsp;=&nbsp;String.Empty;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(var&nbsp;column&nbsp;<span class="cs__keyword">in</span>&nbsp;sortedColumns)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;orderByString&nbsp;&#43;=&nbsp;orderByString&nbsp;!=&nbsp;String.Empty&nbsp;?&nbsp;<span class="cs__string">&quot;,&quot;</span>&nbsp;:&nbsp;<span class="cs__string">&quot;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;orderByString&nbsp;&#43;=&nbsp;(column.Data)&nbsp;&#43;&nbsp;(column.SortDirection&nbsp;==&nbsp;Column.OrderDirection.Ascendant&nbsp;?&nbsp;<span class="cs__string">&quot;&nbsp;asc&quot;</span>&nbsp;:&nbsp;<span class="cs__string">&quot;&nbsp;desc&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;query&nbsp;=&nbsp;query.OrderBy(orderByString&nbsp;==&nbsp;<span class="cs__keyword">string</span>.Empty&nbsp;?&nbsp;<span class="cs__string">&quot;BarCode&nbsp;asc&quot;</span>&nbsp;:&nbsp;orderByString);<span class="cs__preproc">&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#endregion&nbsp;Sorting</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span class="cs__com">//&nbsp;Paging</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;query&nbsp;=&nbsp;query.Skip(requestModel.Start).Take(requestModel.Length);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;data&nbsp;=&nbsp;query.Select(asset&nbsp;=&gt;&nbsp;<span class="cs__keyword">new</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AssetID&nbsp;=&nbsp;asset.AssetID,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BarCode&nbsp;=&nbsp;asset.Barcode,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Manufacturer&nbsp;=&nbsp;asset.Manufacturer,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ModelNumber&nbsp;=&nbsp;asset.ModelNumber,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Building&nbsp;=&nbsp;asset.Building,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RoomNo&nbsp;=&nbsp;asset.RoomNo,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Quantity&nbsp;=&nbsp;asset.Quantity&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}).ToList();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;Json(<span class="cs__keyword">new</span>&nbsp;DataTablesResponse(requestModel.Draw,&nbsp;data,&nbsp;filteredCount,&nbsp;totalCount),&nbsp;JsonRequestBehavior.AllowGet);&nbsp;
}</pre>
</div>
</div>
</div>
