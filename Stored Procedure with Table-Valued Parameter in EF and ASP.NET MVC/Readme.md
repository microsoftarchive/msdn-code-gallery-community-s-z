# Stored Procedure with Table-Valued Parameter in EF and ASP.NET MVC
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- C#
- SQL Server
- ASP.NET
- .NET Framework
- Entity Framework
## Topics
- Data Access
- Entity Framework
- Stored Procedures
## Updated
- 03/03/2013
## Description

<h1>Introduction</h1>
<p><em>This sample shows how to call stored procedure with table-value parameter while using Entity Framework. Something like this might be needed for example when user can add multiple rows at once to insert to database like in small ASP.NET MVC site included
 in sample.<br>
</em></p>
<h1><span>Building the Sample</span></h1>
<ul>
<li><em>Extract the files</em> </li><li><em>Create database from database.sql script included in sample.</em> </li><li>Modify connection string. Sample by default uses the local SQL Express. </li><li>Build with Visual Studio 2012 and ASP.NET MVC 3. </li></ul>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>This sample solves the problem of calling stored procedure with table-value parameter when using Entity Framework by creating few extension methods that makes calling procedure easier. It demonstrates usage of procedure in case where used can create
 multiple contacts with ASP.NET MVC site and then insert them all at once with stored procedure.</em></p>
<p>This all is build around using few extension methods. First one shown below is the one that converts object instances to DataTable to make it simplier to create value for the table valued parameter.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">/// &lt;summary&gt;
/// Creates data table from source data.
/// &lt;/summary&gt;
public static DataTable ToDataTable&lt;T&gt;(this IEnumerable&lt;T&gt; source)
{
    DataTable table = new DataTable();

    //// get properties of T
    var binding = BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty;
    var options = PropertyReflectionOptions.IgnoreEnumerable | PropertyReflectionOptions.IgnoreIndexer;

    var properties = ReflectionExtensions.GetProperties&lt;T&gt;(binding, options).ToList();

    //// create table schema based on properties
    foreach (var property in properties)
    {
        table.Columns.Add(property.Name, property.PropertyType);
    }

    //// create table data from T instances
    object[] values = new object[properties.Count];

    foreach (T item in source)
    {
        for (int i = 0; i &lt; properties.Count; i&#43;&#43;)
        {
            values[i] = properties[i].GetValue(item, null);
        }

        table.Rows.Add(values);
    }

    return table;
}</pre>
<div class="preview">
<pre class="js"><span class="js__sl_comment">///&nbsp;&lt;summary&gt;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;Creates&nbsp;data&nbsp;table&nbsp;from&nbsp;source&nbsp;data.</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;/summary&gt;</span>&nbsp;
public&nbsp;static&nbsp;DataTable&nbsp;ToDataTable&lt;T&gt;(<span class="js__operator">this</span>&nbsp;IEnumerable&lt;T&gt;&nbsp;source)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;DataTable&nbsp;table&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;DataTable();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">////&nbsp;get&nbsp;properties&nbsp;of&nbsp;T</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;binding&nbsp;=&nbsp;BindingFlags.Public&nbsp;|&nbsp;BindingFlags.Instance&nbsp;|&nbsp;BindingFlags.GetProperty;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;options&nbsp;=&nbsp;PropertyReflectionOptions.IgnoreEnumerable&nbsp;|&nbsp;PropertyReflectionOptions.IgnoreIndexer;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;properties&nbsp;=&nbsp;ReflectionExtensions.GetProperties&lt;T&gt;(binding,&nbsp;options).ToList();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">////&nbsp;create&nbsp;table&nbsp;schema&nbsp;based&nbsp;on&nbsp;properties</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;foreach&nbsp;(<span class="js__statement">var</span>&nbsp;property&nbsp;<span class="js__operator">in</span>&nbsp;properties)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;table.Columns.Add(property.Name,&nbsp;property.PropertyType);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">////&nbsp;create&nbsp;table&nbsp;data&nbsp;from&nbsp;T&nbsp;instances</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;object[]&nbsp;values&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;object[properties.Count];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;foreach&nbsp;(T&nbsp;item&nbsp;<span class="js__operator">in</span>&nbsp;source)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(int&nbsp;i&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;i&nbsp;&lt;&nbsp;properties.Count;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;values[i]&nbsp;=&nbsp;properties[i].GetValue(item,&nbsp;null);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;table.Rows.Add(values);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;table;&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>The second one is the one that actually uses the DataTable created above and calls the provided stored procedure using DbContext. So it extends DbContext to call stored procedure with table value the one in the sample is the overload that calls procedure
 with only single one table value parameter shown below.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">/// &lt;summary&gt;
/// Execute stored procedure with single table value parameter.
/// &lt;/summary&gt;
/// &lt;typeparam name=&quot;T&quot;&gt;Type of object to store.&lt;/typeparam&gt;
/// &lt;param name=&quot;context&quot;&gt;DbContext instance.&lt;/param&gt;
/// &lt;param name=&quot;data&quot;&gt;Data to store&lt;/param&gt;
/// &lt;param name=&quot;procedureName&quot;&gt;Procedure name&lt;/param&gt;
/// &lt;param name=&quot;paramName&quot;&gt;Parameter name&lt;/param&gt;
/// &lt;param name=&quot;typeName&quot;&gt;User table type name&lt;/param&gt;
public static void ExecuteTableValueProcedure&lt;T&gt;(this DbContext context, IEnumerable&lt;T&gt; data, string procedureName, string paramName, string typeName)
{
    //// convert source data to DataTable
    DataTable table = data.ToDataTable();

    //// create parameter
    SqlParameter parameter = new SqlParameter(paramName, table);
    parameter.SqlDbType = SqlDbType.Structured;
    parameter.TypeName = typeName;

    //// execute sp sql
    string sql = String.Format(&quot;EXEC {0} {1};&quot;, procedureName, paramName);

    //// execute sql
    context.Database.ExecuteSqlCommand(sql, parameter);
}</pre>
<div class="preview">
<pre class="js"><span class="js__sl_comment">///&nbsp;&lt;summary&gt;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;Execute&nbsp;stored&nbsp;procedure&nbsp;with&nbsp;single&nbsp;table&nbsp;value&nbsp;parameter.</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;/summary&gt;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;typeparam&nbsp;name=&quot;T&quot;&gt;Type&nbsp;of&nbsp;object&nbsp;to&nbsp;store.&lt;/typeparam&gt;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;param&nbsp;name=&quot;context&quot;&gt;DbContext&nbsp;instance.&lt;/param&gt;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;param&nbsp;name=&quot;data&quot;&gt;Data&nbsp;to&nbsp;store&lt;/param&gt;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;param&nbsp;name=&quot;procedureName&quot;&gt;Procedure&nbsp;name&lt;/param&gt;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;param&nbsp;name=&quot;paramName&quot;&gt;Parameter&nbsp;name&lt;/param&gt;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;param&nbsp;name=&quot;typeName&quot;&gt;User&nbsp;table&nbsp;type&nbsp;name&lt;/param&gt;</span>&nbsp;
public&nbsp;static&nbsp;<span class="js__operator">void</span>&nbsp;ExecuteTableValueProcedure&lt;T&gt;(<span class="js__operator">this</span>&nbsp;DbContext&nbsp;context,&nbsp;IEnumerable&lt;T&gt;&nbsp;data,&nbsp;string&nbsp;procedureName,&nbsp;string&nbsp;paramName,&nbsp;string&nbsp;typeName)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">////&nbsp;convert&nbsp;source&nbsp;data&nbsp;to&nbsp;DataTable</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;DataTable&nbsp;table&nbsp;=&nbsp;data.ToDataTable();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">////&nbsp;create&nbsp;parameter</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SqlParameter&nbsp;parameter&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;SqlParameter(paramName,&nbsp;table);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;parameter.SqlDbType&nbsp;=&nbsp;SqlDbType.Structured;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;parameter.TypeName&nbsp;=&nbsp;typeName;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">////&nbsp;execute&nbsp;sp&nbsp;sql</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;sql&nbsp;=&nbsp;<span class="js__object">String</span>.Format(<span class="js__string">&quot;EXEC&nbsp;{0}&nbsp;{1};&quot;</span>,&nbsp;procedureName,&nbsp;paramName);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">////&nbsp;execute&nbsp;sql</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;context.Database.ExecuteSqlCommand(sql,&nbsp;parameter);&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>The sample ASP.NET MVC uses the one above in its action to insert user created contact in database.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public class HomeController : Controller
{
    //
    // GET: /Home/

    public ActionResult Index()
    {
        return View(new ContactModel[0]);
    }

    [HttpPost]
    public ActionResult Index(ContactModel[] contacts)
    {
        //// create unique ids
        foreach (var contact in contacts)
        {
            contact.ContactID = Guid.NewGuid();
        }

        //// save using procedure with table value parameter
        using (var context = new ContactingContext())
        {
            context.ExecuteTableValueProcedure&lt;ContactModel&gt;(contacts, &quot;InsertContacts&quot;, &quot;@contacts&quot;, &quot;ContactStruct&quot;);
        }

        TempData[&quot;saved&quot;] = &quot;Contacts saved.&quot;;

        return View(contacts);
    }
}</pre>
<div class="preview">
<pre class="js">public&nbsp;class&nbsp;HomeController&nbsp;:&nbsp;Controller&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;GET:&nbsp;/Home/</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;ActionResult&nbsp;Index()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;View(<span class="js__operator">new</span>&nbsp;ContactModel[<span class="js__num">0</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[HttpPost]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;ActionResult&nbsp;Index(ContactModel[]&nbsp;contacts)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">////&nbsp;create&nbsp;unique&nbsp;ids</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;foreach&nbsp;(<span class="js__statement">var</span>&nbsp;contact&nbsp;<span class="js__operator">in</span>&nbsp;contacts)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;contact.ContactID&nbsp;=&nbsp;Guid.NewGuid();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">////&nbsp;save&nbsp;using&nbsp;procedure&nbsp;with&nbsp;table&nbsp;value&nbsp;parameter</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;using&nbsp;(<span class="js__statement">var</span>&nbsp;context&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;ContactingContext())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;context.ExecuteTableValueProcedure&lt;ContactModel&gt;(contacts,&nbsp;<span class="js__string">&quot;InsertContacts&quot;</span>,&nbsp;<span class="js__string">&quot;@contacts&quot;</span>,&nbsp;<span class="js__string">&quot;ContactStruct&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TempData[<span class="js__string">&quot;saved&quot;</span>]&nbsp;=&nbsp;<span class="js__string">&quot;Contacts&nbsp;saved.&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;View(contacts);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">Included very simple ASP.NET MVC site demonstrates one possible use case where something like this would be needed.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><img id="76980" src="76980-ui.jpg" alt="" width="682" height="468"></div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>DataTableExtensions.cs - to create DataTable from object instances<br>
</em></li><li><em><em>DbContextExtensions.cs - to call procedure with table-value parameter with DbContext.</em></em>
</li><li><em>ReflectionExtensions.cs - to get properties of object instance.</em> </li><li><em>HomeController.cs - ASP.NET MVC controller to demonstrate usage.</em> </li></ul>
