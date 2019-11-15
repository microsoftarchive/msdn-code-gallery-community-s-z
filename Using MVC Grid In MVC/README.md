# Using MVC Grid In MVC
## Requires
- Visual Studio 2012
## License
- MIT
## Technologies
- C#
- SQL Server
- ASP.NET MVC
- Visual Studio 2015
- MVC Grid
## Topics
- Performance
- Data
## Updated
- 07/10/2016
## Description

<p><span style="font-size:small">In this post we will see how we can develop a MVC grid in our&nbsp;<a href="http://sibeeshpassion.com/category/mvc/" target="_blank">MVC&nbsp;</a>application. There are so many grids are available in the industries, most of
 them are useful. Here we are going to use a grid called MVC grid, which uses bootstrap and&nbsp;<a href="http://sibeeshpassion.com/category/jQuery/" target="_blank">jQuery</a>. We will create some dynamic data using list first, once it is done, we will send
 this data to the MVC grid. Sounds good? I hope you will like this article.</span></p>
<p><strong><span style="font-size:small">Background</span></strong></p>
<p><span style="font-size:small">I have been working with the Grid controls for a long long time. So far I have worked with jQX Grid, jQ Grid, jQuery Datatables, Pivot tables, KO grid etc. It is always interesting to work with some controls. I always loved
 it. recently I worked with MVC grid. So I thought of sharing that experience with you all.</span></p>
<p><strong><span style="font-size:small">Create a MVC application</span></strong></p>
<p><span style="font-size:small">First, we will start with creating an MVC application. Open your visual studio, then click File-&gt;New-&gt;Project. Name your project.</span></p>
<p><strong><span style="font-size:small">Install MVC Grid</span></strong></p>
<p><span style="font-size:small">The next step we are going to do is, installing the MVC grid to our project. To install, please right click your solution and click on Manage NuGet packages.</span></p>
<div class="wp-caption x_alignnone" id="attachment_10982"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2015/11/Select_NuGet_Package.png"><img class="size-full x_wp-image-10982" src="http://sibeeshpassion.com/wp-content/uploads/2015/11/Select_NuGet_Package.png" alt="Select NuGet Package" width="459" height="673"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">Select NuGet Package</span></p>
</div>
<p><span style="font-size:small">Now you can see a new window, please search for MVC grid in the search box. And then click Install.</span></p>
<div class="wp-caption x_alignnone" id="attachment_10983"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2015/11/Install_MVC_Grid_To_Project-e1448285055873.png"><img class="size-full x_wp-image-10983" src="http://sibeeshpassion.com/wp-content/uploads/2015/11/Install_MVC_Grid_To_Project-e1448285055873.png" alt="Install_MVC_Grid_To_Project" width="650" height="433"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">Install_MVC_Grid_To_Project</span></p>
</div>
<p><span style="font-size:small">Once you installed, you can see there is a new reference file has been added(GridMVC), you can also notice that two views are created (_Grig.cshtml,_GridPager.cshtml) and one CSS file and some scripts. Now we will move to our
 next step.</span></p>
<p><strong><span style="font-size:small">Dependencies</span></strong></p>
<p><span style="font-size:small">As I said before, MVC grid uses bootstrap for design. So the next thing we need to is to install bootstrap in our project. For that, go to NuGet packages again and search for bootstrap.</span></p>
<div class="wp-caption x_alignnone" id="attachment_10984"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2015/11/Install_Bootstrap_To_Project-e1448285364634.png"><img class="size-full x_wp-image-10984" src="http://sibeeshpassion.com/wp-content/uploads/2015/11/Install_Bootstrap_To_Project-e1448285364634.png" alt="Install_Bootstrap_To_Project" width="650" height="433"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">Install_Bootstrap_To_Project</span></p>
</div>
<p><span style="font-size:small">You can see some new CSS files and scripts has been added to our project. So the set up has been done. Now what we need to do is to move on the coding part.</span></p>
<p><strong><span style="font-size:small">Create a controller</span></strong></p>
<p><span style="font-size:small">Now we can create a new controller, in my case I created a controller &lsquo;HomeController&rsquo;. In my controller I am going to call a model action which will return some dynamic data. See the code below.</span></p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_875112">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">public&nbsp;class&nbsp;HomeController&nbsp;:&nbsp;Controller&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;GET:&nbsp;/Home/</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;ActionResult&nbsp;Index()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Test&nbsp;t&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Test();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;myList=&nbsp;t.GetData();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;View(myList);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">As you can see I am creating an instance of my model Test, now we will create our model class. Shall we?</span></p>
<p><span style="font-size:small">Create Model</span></p>
<p><span style="font-size:small">I have create a model class with the name Test. Here I am creating some data dynamically using a for loop and assign those values to a list. Please see the codes below.</span></p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_203949">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">namespace&nbsp;AsyncActions.Models&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;Test&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;List&lt;Customer&gt;&nbsp;GetData()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;List&lt;Customer&gt;&nbsp;cst&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;List&lt;Customer&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(int&nbsp;i&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;i&nbsp;&lt;&nbsp;<span class="js__num">100</span>;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Customer&nbsp;c&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Customer();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.CustomerID&nbsp;=&nbsp;i;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.CustomerCode&nbsp;=&nbsp;<span class="js__string">&quot;CST&quot;</span>&nbsp;&#43;&nbsp;i;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cst.Add(c);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;cst;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">catch</span>&nbsp;(Exception)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">throw</span>&nbsp;<span class="js__operator">new</span>&nbsp;NotImplementedException();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;Customer&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;int&nbsp;CustomerID&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;CustomerCode&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">As you can see I am creating a list of type Customer. Is that fine? Now what is pending? Yes, a view.</span></p>
<p><span style="font-size:small">Create a strongly typed view</span></p>
<p><span style="font-size:small">Now we are going to create a strongly typed view.</span></p>
<div class="wp-caption x_alignnone" id="attachment_10985"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2015/11/Create_Strongly_Typed_View.png"><img class="size-full x_wp-image-10985" src="http://sibeeshpassion.com/wp-content/uploads/2015/11/Create_Strongly_Typed_View.png" alt="Create_Strongly_Typed_View" width="509" height="502"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">Create_Strongly_Typed_View</span></p>
</div>
<blockquote>
<p><span style="font-size:small">When you create a view as strongly typed view, your view header will be as follows. @model List</span></p>
</blockquote>
<p><span style="font-size:small">So our view is ready, now we can do some codes in our view to populate our grid. Are you ready? First thing is you need to include the needed references to our view, you can do this in the file called Layout.cshtml. Here I am
 going to add those references directly to the view.</span></p>
<div>
<div class="syntaxhighlighter xml" id="highlighter_225821">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;link&nbsp;href=<span class="js__string">&quot;~/Content/bootstrap-theme.css&quot;</span>&nbsp;rel=<span class="js__string">&quot;stylesheet&quot;</span>&nbsp;/&gt;&nbsp;
&lt;link&nbsp;href=<span class="js__string">&quot;~/Content/bootstrap.css&quot;</span>&nbsp;rel=<span class="js__string">&quot;stylesheet&quot;</span>&nbsp;/&gt;&nbsp;
&lt;script&nbsp;src=<span class="js__string">&quot;~/Scripts/jquery-2.1.3.min.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&lt;link&nbsp;href=<span class="js__string">&quot;~/Content/Gridmvc.css&quot;</span>&nbsp;rel=<span class="js__string">&quot;stylesheet&quot;</span>&nbsp;/&gt;&nbsp;
&lt;script&nbsp;src=<span class="js__string">&quot;~/Scripts/gridmvc.min.js&quot;</span>&gt;&lt;/script&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">Add the grid namespace</span></p>
<p><span style="font-size:small">You can add the grid namespace as follows.</span></p>
<div>
<div class="syntaxhighlighter xml" id="highlighter_807529">
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
<tr>
<td class="gutter">
<div class="line number1 index0 alt2"><br>
<br>
</div>
</td>
<td class="code"><br>
</td>
</tr>
</tbody>
</table>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">@using&nbsp;GridMvc.Html&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><span style="font-size:small">Next thing is to add grid implementation.</span></p>
<p><span style="font-size:small">MVC Grid Implementation</span></p>
<p><span style="font-size:small">To add a MVC grid as our requirement, you need to add the codes as below.</span></p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_609432">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">@Html.Grid(Model).Columns(columns&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;columns.Add(foo&nbsp;=&gt;&nbsp;foo.CustomerID).Titled(<span class="js__string">&quot;Customer&nbsp;ID&quot;</span>).SetWidth(<span class="js__num">50</span>).Sortable(true).Filterable(true);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;columns.Add(foo&nbsp;=&gt;&nbsp;foo.CustomerCode).Titled(<span class="js__string">&quot;Customer&nbsp;Code&quot;</span>).SetWidth(<span class="js__num">50</span>).Sortable(true).Filterable(true);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>).WithPaging(<span class="js__num">20</span>)</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">As you can see we are using the columns Customer.CustomerID and Customer.CustomerCode.</span></p>
<p><span style="font-size:small">Output</span></p>
<div class="wp-caption x_alignnone" id="attachment_10986"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2015/11/MVC_Grid_With_Dynamic_Data.png"><img class="size-large x_wp-image-10986" src="http://sibeeshpassion.com/wp-content/uploads/2015/11/MVC_Grid_With_Dynamic_Data-1024x518.png" alt="MVC_Grid_With_Dynamic_Data" width="634" height="321"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">MVC_Grid_With_Dynamic_Data</span></p>
</div>
<p><span style="font-size:small">Add more Grid features</span></p>
<p><span style="font-size:small"><em>To set the paging&nbsp;</em>we can use the option&nbsp;<em>WithPaging(20)</em>.</span><br>
<span style="font-size:small"><em>To add title</em>&nbsp;we can use&nbsp;<em>Titled</em>&nbsp;property.</span><br>
<span style="font-size:small"><em>To set width</em>&nbsp;we can use&nbsp;<em>SetWidth</em>&nbsp;property.</span><br>
<span style="font-size:small"><em>To set sort</em>&nbsp;we can use&nbsp;<em>Sortable</em>&nbsp;property.</span><br>
<span style="font-size:small"><em>To set filter</em>&nbsp;we can use&nbsp;<em>Filterable</em>&nbsp;property.</span></p>
<p><span style="font-size:small">You can always see the additional options&nbsp;<a href="https://gridmvc.codeplex.com/documentation" target="_blank">here&nbsp;</a>.</span></p>
<h1></h1>
