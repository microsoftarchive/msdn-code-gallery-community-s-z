# Unit Testing with ASP.NET Web API 2 using Visual Studio 2017
## Requires
- Visual Studio 2017
## License
- MIT
## Technologies
- C#
- ASP.NET
- Entity Framework
- ASP.NET Web Forms
## Topics
- Unit Testing
- ASP.NET Web API
## Updated
- 09/16/2017
## Description

<h1>Introduction</h1>
<p>This sample demonstrates how to create unit tests for your Web API 2 application. It shows how to create test objects for working with the Entity Framework, and how to add test methods that check the returned values from a controller method.</p>
<p>The sample is the sample code for this documentation:&nbsp;<a href="https://docs.microsoft.com/en-us/aspnet/web-api/overview/testing-and-debugging/unit-testing-with-aspnet-web-api" target="_blank">https://docs.microsoft.com/en-us/aspnet/web-api/overview/testing-and-debugging/unit-testing-with-aspnet-web-api</a></p>
<p>It is adapted for Visual Studio 2017, and it is compatible with Visual Studio 2015. Opening this project with previous version older than Visual Studio 2015 is not recommended.</p>
<p><strong>NOTE</strong>: The original documentation of ASP.NET Web API 2 was more targeted to support Visual Studio 2013. Therefore previous sample code was originally written to support Visual Studio 2013. This is the original sample code using Visual Studio
 2013:&nbsp;<a href="https://code.msdn.microsoft.com/Unit-Testing-with-ASPNET-e2867d4d">https://code.msdn.microsoft.com/Unit-Testing-with-ASPNET-e2867d4d</a>&nbsp;</p>
<p>&nbsp;</p>
<h1><span>Building the Sample</span></h1>
<p>You must restore the NuGet packages for the sample to work. This sample code uses Visual Studio 2017. In Visual Studio 2017, the Nuget tooling is Nuget v4.0. This nuget v4.0 tool by default connects to nuget feed v3.0 (or later). Starting with NuGet 4.0,
 by default the packages are restored when you open the solution. The package restore first build will take extra time or delay when opening the solution for the first time.</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>This sample includes code from two topics - Unit Testing ASP.NET Web API 2 and Mocking Entity Framework when Unit Testing ASP.NET Web API. It shows a simple data scenario through the SimpleProductController.cs file and the TestSimpleProductController.cs
 file.</p>
<p>Technology used:</p>
<ol>
<li>Entity Framework 6.1.3 </li><li>Web API 2 </li></ol>
<p>NOTE: Entity Framework 6.1.3 is used instead of the latest EF Core, because this sample is focusing on classic ASP.NET Web Forms. EF Core is best suited for ASP.NET Core application.</p>
<p>This is a sample EF DbContext<em>.in action: &nbsp;&nbsp;</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">    public class StoreAppContext : DbContext, IStoreAppContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public StoreAppContext() : base(&quot;name=StoreAppContext&quot;)
        {
        }

        public DbSet&lt;Product&gt; Products { get; set; }

        public void MarkAsModified(Product item)
        {
            Entry(item).State = EntityState.Modified;
        }
    }
</pre>
<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;StoreAppContext&nbsp;:&nbsp;DbContext,&nbsp;IStoreAppContext&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;You&nbsp;can&nbsp;add&nbsp;custom&nbsp;code&nbsp;to&nbsp;this&nbsp;file.&nbsp;Changes&nbsp;will&nbsp;not&nbsp;be&nbsp;overwritten.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;If&nbsp;you&nbsp;want&nbsp;Entity&nbsp;Framework&nbsp;to&nbsp;drop&nbsp;and&nbsp;regenerate&nbsp;your&nbsp;database</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;automatically&nbsp;whenever&nbsp;you&nbsp;change&nbsp;your&nbsp;model&nbsp;schema,&nbsp;please&nbsp;use&nbsp;data&nbsp;migrations.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;For&nbsp;more&nbsp;information&nbsp;refer&nbsp;to&nbsp;the&nbsp;documentation:</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;http://msdn.microsoft.com/en-us/data/jj591621.aspx</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;StoreAppContext()&nbsp;:&nbsp;<span class="cs__keyword">base</span>(<span class="cs__string">&quot;name=StoreAppContext&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;DbSet&lt;Product&gt;&nbsp;Products&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;MarkAsModified(Product&nbsp;item)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Entry(item).State&nbsp;=&nbsp;EntityState.Modified;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<p>The Product class is the class to hold the data:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
</pre>
<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Product&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;Id&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Name&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">decimal</span>&nbsp;Price&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;This is a sample unit test to test the returning result of a Web API method:</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">        [TestMethod]
        public void GetProduct_ShouldReturnCorrectProduct()
        {
            var testProducts = GetTestProducts();
            var controller = new SimpleProductController(testProducts);

            var result = controller.GetProduct(4) as OkNegotiatedContentResult&lt;Product&gt;;
            Assert.IsNotNull(result);
            Assert.AreEqual(testProducts[3].Name, result.Content.Name);
        }
</pre>
<div class="preview">
<pre class="js">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[TestMethod]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;<span class="js__operator">void</span>&nbsp;GetProduct_ShouldReturnCorrectProduct()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;testProducts&nbsp;=&nbsp;GetTestProducts();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;controller&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;SimpleProductController(testProducts);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;result&nbsp;=&nbsp;controller.GetProduct(<span class="js__num">4</span>)&nbsp;as&nbsp;OkNegotiatedContentResult&lt;Product&gt;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Assert.IsNotNull(result);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Assert.AreEqual(testProducts[<span class="js__num">3</span>].Name,&nbsp;result.Content.Name);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<p><em><em>.</em></em></p>
<h1>More Information</h1>
<p>For more information about starting introduction to ASP.NET Web API, please consult this documentation:&nbsp;<a href="https://docs.microsoft.com/en-us/aspnet/web-api/" target="_blank">https://docs.microsoft.com/en-us/aspnet/web-api/</a></p>
