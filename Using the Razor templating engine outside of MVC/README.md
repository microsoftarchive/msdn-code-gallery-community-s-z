# Using the Razor templating engine outside of MVC
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- Razor
## Topics
- Template Transformations outside of MVC
- Dynamic Assembly Generation
## Updated
- 04/10/2011
## Description

<p>I have begun working on a feature that will Create Visual Studio VSIX files of the fly. The VSIX file format is essentially a zipped up payload and a VSIX Manifest file which provides metadats to describe the payload. This manifest file is an XML file that
 includes such details as Name, version, Author, etc.</p>
<p>I really did not want to use traditional XML file generation techniches using an XMLDocument or XDocument to buildup the XML content. I had heard about how the Razor Templating engine in MVC3 can be used outside of MVC and this seemed like an attractively
 simple method to produce these manifest files. I would ideally need to supply a fairly simple template for producing the vsix manifest xml. Then I would have a Model class that would encapsulate the actual metadata similar to a View Model passed to an MVC
 View.</p>
<p>This sample is largely a product &nbsp;of two blog posts:</p>
<p><a href="http://vibrantcode.com/blog/month/november-2010">http://vibrantcode.com/blog/month/november-2010</a></p>
<p><a href="http://www.fidelitydesign.net/?p=208">http://www.fidelitydesign.net/?p=208</a></p>
<p>I wanted to be able to build a somewhat generic templating library for rendering Razor templates against a Model class. There are a couple of open source projects that appear to do this quite nicely:</p>
<p><a href="http://razorengine.codeplex.com/">http://razorengine.codeplex.com/</a></p>
<p><a title="http://www.west-wind.com:8080/svn/articles/trunk/RazorHosting/" href="http://www.west-wind.com:8080/svn/articles/trunk/RazorHosting/">http://www.west-wind.com:8080/svn/articles/trunk/RazorHosting/</a></p>
<p>However, both of these projects seemed rather large for what I wanted to accomplish. I just wanted very simple templating and I really just wanted to depend on a few small classes to do it.</p>
<p>This sample provides a very small C# code sample that will allow you to create a Razor view in the form of a normal string and compile it against a model class which will supply data to your template.</p>
<p>Before explaining the underlying classes, I'll highlight the template and model classes that you will write.</p>
<p>Here is an example template. Its just a string:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;SampleTemplateStrings&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Sample1&nbsp;=&nbsp;@&quot;&nbsp;
&lt;html&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;I&nbsp;hope&nbsp;that&nbsp;you&nbsp;enjoy&nbsp;the&nbsp;rendering&nbsp;of&nbsp;@Model.Prop1&nbsp;just&nbsp;<span class="cs__keyword">as</span>&nbsp;much&nbsp;<span class="cs__keyword">as</span>&nbsp;the&nbsp;rendering&nbsp;of&nbsp;@Model.Prop2&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;For&nbsp;your&nbsp;pleasure&nbsp;I&nbsp;am&nbsp;including&nbsp;these&nbsp;extra&nbsp;parameter&nbsp;strings:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;@<span class="cs__keyword">foreach</span>(var&nbsp;p&nbsp;<span class="cs__keyword">in</span>&nbsp;@Model.Prop3)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;span&gt;I&nbsp;present&nbsp;<span class="cs__keyword">this</span>&nbsp;param3&nbsp;<span class="cs__keyword">value</span>:&nbsp;@p&lt;/span&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&lt;/html&gt;&nbsp;
&quot;;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<p class="endscriptcode">&nbsp;This Template simply provides a Razor View. You will notice that the view, references a @Model and accesses properties off of that model to render customized content. You will need to define a class that will represent the model
 data. Here is the code for the sample model thatwe use:</p>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;SampleModel&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Prop1&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Prop2&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;IList&lt;<span class="cs__keyword">string</span>&gt;&nbsp;Prop3&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<p class="endscriptcode">The actual code that facilitates the template compile and rendering is the RazorTemplateGenerator. You must register your template strings and models with this class. Once all templates have been registered, you need to tell the RazorTemplateGenerator
 to compile the templates. After the templates are successfuly compiled, you may call the generator to Generate template output providing a instantiated model. Below you can see how the sample console app does this:</p>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IRazorTemplateGenerator&nbsp;generator&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;RazorTemplateGenerator();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;generator.RegisterTemplate&lt;SampleModel&gt;(SampleTemplateStrings.Sample1);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;generator.CompileTemplates();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;output&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;generator.GenerateOutput(<span class="cs__keyword">new</span>&nbsp;SampleModel()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{Prop1&nbsp;=&nbsp;<span class="cs__string">&quot;p1&quot;</span>,&nbsp;Prop2&nbsp;=&nbsp;<span class="cs__string">&quot;p2&quot;</span>,&nbsp;Prop3&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;<span class="cs__keyword">string</span>&gt;&nbsp;{<span class="cs__string">&quot;pe1&quot;</span>,&nbsp;<span class="cs__string">&quot;pe2&quot;</span>,&nbsp;<span class="cs__string">&quot;pe3&quot;</span>}});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Console.Out.WriteLine(output);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Console.In.ReadLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<p class="endscriptcode">Ideally the registration and compile calls would live in your app start code and only execute once. I created an interface IRazorTemplateGenerator to make testing easier. The CompileTemplates call iterates through all templates and
 compiles them into a single assembly. You would not want to generate a new assembly on every usage. You may adopt a singleton pattern here or use your IOC of choice to ensure that the RazorTemplateGenerator has a single instance in your app. My team uses StructureMap
 and instead of newing up a fresh RazorTemplateGenerator, we call GetInstance&lt;IRazorTemplateGenerator&gt;() to get the singleton instance.</p>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<p class="endscriptcode">Here is the RazorTemplateGenerator code:</p>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;RazorTemplateGenerator&nbsp;:&nbsp;IRazorTemplateGenerator&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">readonly</span>&nbsp;Dictionary&lt;<span class="cs__keyword">string</span>,&nbsp;RazorTemplateEntry&gt;&nbsp;templateItems&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Dictionary&lt;<span class="cs__keyword">string</span>,&nbsp;RazorTemplateEntry&gt;();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;Assembly&nbsp;compiledTemplateAssembly;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;RegisterTemplate&lt;TModel&gt;(<span class="cs__keyword">string</span>&nbsp;templateString)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RegisterTemplate&lt;TModel&gt;(GetTemplateNameFromModel(<span class="cs__keyword">typeof</span>(TModel)),&nbsp;templateString);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;RegisterTemplate&lt;TModel&gt;(<span class="cs__keyword">string</span>&nbsp;templateName,&nbsp;<span class="cs__keyword">string</span>&nbsp;templateString)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(compiledTemplateAssembly&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;InvalidOperationException(<span class="cs__string">&quot;May&nbsp;not&nbsp;register&nbsp;new&nbsp;templates&nbsp;after&nbsp;compiling.&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(templateName&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;ArgumentNullException(<span class="cs__string">&quot;templateName&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(templateString&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;ArgumentNullException(<span class="cs__string">&quot;templateString&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;templateItems[TranslateKey(<span class="cs__keyword">typeof</span>(TModel),&nbsp;templateName)]&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;RazorTemplateEntry()&nbsp;{&nbsp;ModelType&nbsp;=&nbsp;<span class="cs__keyword">typeof</span>(TModel),&nbsp;TemplateString&nbsp;=&nbsp;templateString,&nbsp;TemplateName&nbsp;=&nbsp;<span class="cs__string">&quot;Rzr&quot;</span>&nbsp;&#43;&nbsp;Guid.NewGuid().ToString(<span class="cs__string">&quot;N&quot;</span>)&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;CompileTemplates()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;compiledTemplateAssembly&nbsp;=&nbsp;Compiler.Compile(templateItems.Values);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;GenerateOutput&lt;TModel&gt;(TModel&nbsp;model)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;GenerateOutput(model,&nbsp;GetTemplateNameFromModel(<span class="cs__keyword">typeof</span>(TModel)));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;GenerateOutput&lt;TModel&gt;(TModel&nbsp;model,&nbsp;<span class="cs__keyword">string</span>&nbsp;templateName)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(compiledTemplateAssembly&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;InvalidOperationException(<span class="cs__string">&quot;Templates&nbsp;have&nbsp;not&nbsp;been&nbsp;compiled.&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(templateName&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;ArgumentNullException(<span class="cs__string">&quot;templateName&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RazorTemplateEntry&nbsp;entry&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;entry&nbsp;=&nbsp;templateItems[TranslateKey(<span class="cs__keyword">typeof</span>(TModel),&nbsp;templateName)];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(KeyNotFoundException)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;ArgumentOutOfRangeException(<span class="cs__string">&quot;No&nbsp;template&nbsp;has&nbsp;been&nbsp;registered&nbsp;under&nbsp;this&nbsp;model&nbsp;or&nbsp;name.&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;template&nbsp;=&nbsp;(RazorTemplateBase&lt;TModel&gt;)compiledTemplateAssembly.CreateInstance(<span class="cs__string">&quot;RazorTemplateingSample.&quot;</span>&nbsp;&#43;&nbsp;entry.TemplateName&nbsp;&#43;&nbsp;<span class="cs__string">&quot;Template&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;template.Model&nbsp;=&nbsp;model;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;template.Execute();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;output&nbsp;=&nbsp;template.Buffer.ToString();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;template.Buffer.Clear();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;output;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;GetTemplateNameFromModel(Type&nbsp;model)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">string</span>.Format(<span class="cs__string">&quot;RZR::{0}&quot;</span>,&nbsp;model.Name);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;TranslateKey(Type&nbsp;model,&nbsp;<span class="cs__keyword">string</span>&nbsp;templateName)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">string</span>.Format(<span class="cs__string">&quot;{0}::{1}&quot;</span>,&nbsp;model.Name,&nbsp;templateName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="endscriptcode">You can see that this class also supports named templates. If you dont need more than one template string to render a single model type. The call to GenerateOutput will suffice, but if you need to use more than one template string
 for a single model type, you will need to use the overload which takes templateName parameter.</p>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<p class="endscriptcode">There is a Compiler class which does the actual transformatin of the razor string to C# code and then compiles that into an assembly. I will not include that code here but you can find it in the source.&nbsp;</p>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<p class="endscriptcode">One key class used in the compilation and rendering of the templates is the abstract RazorTemplateBase&lt;T&gt; class. This is the class that the final compiled class will derrive from. Razor uses a convention thatrequires this class
 to include a Execute mothod which performs the template merge with the model. Here is the class:</p>
<div class="endscriptcode"></div>
<p class="endscriptcode"></p>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">abstract</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;RazorTemplateBase&lt;T&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;T&nbsp;Model&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;StringBuilder&nbsp;Buffer&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;RazorTemplateBase()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Buffer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StringBuilder();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">abstract</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Execute();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">virtual</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Write(<span class="cs__keyword">object</span>&nbsp;<span class="cs__keyword">value</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WriteLiteral(<span class="cs__keyword">value</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">virtual</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;WriteLiteral(<span class="cs__keyword">object</span>&nbsp;<span class="cs__keyword">value</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Buffer.Append(<span class="cs__keyword">value</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<p class="endscriptcode">T is the modelClass and the two methods Write and WriteLiteral is what outputs the string. Write is for writing dynamic content like @Model.Param and WriteLiteral outputs plain text in the view like &quot;&lt;p&gt;my literal output&lt;/p&gt;&quot;.
 Here we essentially treat both the same, but another environment like MVC may do HTML encoding on the Write method.</p>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
</div>
I hope you find this sample useful in understanding how the Razor templating engine works and how to leverage it outside of the MVC runtime environment. To provide additional clarity, I have provided an XUnit Fact class which can run tests against this API.
 Use a product like TestDriven.net to run these tests.
<p></p>
</div>
