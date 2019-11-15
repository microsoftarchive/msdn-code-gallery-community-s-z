# Tracing and Caching Provider Wrappers for Entity Framework 4
## Requires
- Visual Studio 2010
## License
- MIT
## Technologies
- ADO.NET Entity Framework
- ADO.NET
- Entity Framework
## Topics
- Caching
- Entity Framework Provider Mappers
- EFProviderWrappers
- Tracing
## Updated
- 12/22/2014
## Description

<h1>This sample only applies to Entity Framework&nbsp;4 and 5</h1>
<p><em>This sample was originally developed by Jarek Kowalski (<a href="http://jkowalski.com">http://jkowalski.com</a>), who at the time was a member of the Entity Framework&nbsp;Team. He created it using the Entity Framework 4 APIs. It should however still
 work with EF5 since the&nbsp;EF5 core APIs that are part of the .NET Framework are compatible with EF4.</em></p>
<p><em>The&nbsp;sample&nbsp;cannot be made to work without modifications&nbsp;on Entity Framework 6&nbsp;since the latter implements its own core APIs separate from the .NET framework and contains other breaking changes. We are currently not actively developing
 this sample and therefore we have no plans to publish a new version compatible with EF6.</em></p>
<p><em><em>That said, </em>EF6 introduces&nbsp;a new feature called Interception which can help application and&nbsp;library developers achieve&nbsp;most of the same&nbsp;functionality without implementing a wrapping EF provider.
</em><em>For more information about Interception and other new features in Entity Framework 6,&nbsp;refer to&nbsp;the EF documentation at
<a href="http://msdn.com/EF"><span>http://msdn.com/EF</span></a>.</em></p>
<p><em>Information about Entity Framework 7 and its new APIs can be currently found in the EF7 open source repository at
<a href="https://github.com/aspnet/entityframework/"><span>https://github.com/aspnet/entityframework/</span></a>.
</em><span><br>
</span></p>
<h1>Introduction</h1>
<p>This sample shows how to extend Entity Framework in interesting ways by plugging into ADO.NET provider interface. The sample provides two extensions:</p>
<ul>
<li>
<div><strong>EFTracingProvider</strong>&nbsp;&ndash; which adds the ability to log all SQL commands that are executed (similar to LINQ to SQL&rsquo;s DataContext.Log</div>
</li><li>
<div><strong>EFCachingProvider</strong>&nbsp;&ndash; which adds transparent query results cache to EF</div>
</li></ul>
<p>The sample comes with implementation of distributed cache which uses&nbsp;<a href="http://blogs.msdn.com/velocity/archive/2009/04/08/announcing-velocity-ctp3.aspx">Velocity CTP 3</a>&nbsp;as well as an adapter for ASP.NET and simple in-memory cache implementation.</p>
<p><span>Because the sample is quite large and uses many advanced techniques, it&rsquo;s impossible to fully explain it all in one blog post. In this first post I&rsquo;ll briefly explain the idea of wrapper providers and describe the new the APIs exposed by
 EFTracingProvider and EFCachingProvider. In future posts I&rsquo;ll try to explain more technical detail details and provide advanced logging/caching tips.</span></p>
<h1>Provider Wrapers</h1>
<p>Entity Framework has a public provider model which makes it possible for provider writers to support 3<sup>rd</sup>-party databases, such as Oracle, MySQL, PostreSQL, Firebird. The provider model provides uniform way for EF to query the capabilities of the
 database and execute queries and updates using canonical query tree representation (as opposed to textual queries).</p>
<p>Whenever you issue a LINQ or Entity SQL query through an ObjectContext instance, the query passes through a series of layers (see the picture below). At high level we can say that all queries and updates from ObjectContext are translated and executed through
 EntityConnection, which in turns talks to server-specific data provider such as SqlClient or Sql Server CE client.</p>
<p>Provider interface used by Entity Framework is stackable, which means it&rsquo;s possible to write a provider which will wrap another provider and intercept communication between Entity Framework and the original provider.</p>
<p>The wrapper provider gets a chance do interesting things, such as:</p>
<ul>
<li>Examining query trees and commands before they are executed </li><li>Controlling connections, commands, transactions, data readers, etc. </li></ul>
<p><img title="image" src="http://blogs.msdn.com/blogfiles/jkowalski/WindowsLiveWriter/TracingandCachinginEntityFrameworkavaila_860F/image_3.png" border="0" alt="image" width="528" height="408"></p>
<p><strong>EFTracingProvider</strong>&nbsp;intercepts DbCommand.ExecuteReader(), ExecuteScalar() and ExecuteNonQuery() and sends details about the command (including command text and parameters) to configured outputs.</p>
<p><strong>EFCachingProvider</strong>&nbsp;is a bit more complex. It uses external caching implementation and caches results of all queries queries that are executed in DbCommand.ExecuteReader(). Whenever update is detected (either UPDATE, INSERT or DELETE)
 the provider invalidates affected cache entries by evicting all cached queries which were dependent on any of the updated tables.</p>
<h1>Using the sample code</h1>
<p>Here&rsquo;s a step-by-step guide to downloading and using the sample code in your project:</p>
<ol>
<li>Download the sample project from MSDN Code Gallery and built it. </li><li>Take&nbsp;<strong>EFCachingProvider.dll</strong>,&nbsp;<strong>EFTracingProvider.dll</strong>&nbsp;and&nbsp;<strong>EFProviderWrapperToolkit.dll</strong>&nbsp;and place them in a common directory for easy referencing.
</li><li>Add reference to those three assemblies in your application. </li><li>Register the providers &ndash; either:
<ol>
<li>Locally for your application (recommended) &ndash; put registration entries in App.config (see Provider Registration section below) and make sure that provider DLLs are in your application directory (adding reference and building should take care of that).
</li><li>Globally: GAC the providers and add required registration entries (see Provider Registration section below) to machine.config
</li></ol>
</li><li>Copy&nbsp;<strong>EFProviderWrapperDemo\ExtendedNorthwindEntities.cs</strong>&nbsp;from the sample and put it in your project &ndash; rename the class as appropriate &ndash; you will need to use this class instead of a regular strongly typed object context
 class. </li><li>Modify the base class by replacing NorthwindEntities with the name of your strongly typed object context class.
</li><li>Modify the default constructor by providing your own connection string. </li><li>(optional) You can also modify the second constructor by specifying which wrapper providers to use.
</li></ol>
<p>That&rsquo;s it.</p>
<h1>Caching and Tracing APIs</h1>
<p>By using&nbsp;<strong>ExtendedNorthwindEntities</strong>&nbsp;which was created in previous step, instead of&nbsp;<strong>NorthwindEntities</strong>&nbsp;you get access to new APIs which control caching and tracing:</p>
<pre class="csharpcode"><span class="kwrd">public</span> TextWriter Log { get; set; }</pre>
<p>Specifies the text writer where log output should be written - same as in LINQ to SQL</p>
<pre class="csharpcode"><span class="kwrd">public</span> ICache Cache { get; set; }</pre>
<p>Specifies which cache should be used for the context (typically a global one). The sample comes with 3 implementations of ICache interface which you can be used in your applications:</p>
<ul>
<li>AspNetCache &ndash; cache which uses ASP.NET caching mechanism </li><li>InMemoryCache &ndash; simple, in-memory cache with basic LRU expiration policy
</li><li>VelocityCache &ndash; implementation of caching which uses Microsoft Distributed Cache codename &quot;Velocity&quot; CTP3.
</li></ul>
<pre class="csharpcode"><span class="kwrd">public</span> CachingPolicy CachingPolicy { get; set; }</pre>
<p>Specifies caching policy. There are 3 policies included in the package:</p>
<ul>
<li>CachingPolicy.CacheAll &ndash; caches all queries regardless of their results size or affected tables
</li><li>CachingPolicy.NoCaching &ndash; disables caching </li><li>CustomCachingPolicy &ndash; includes user-configurable list of tables that should and should not be cached, as well as expiration times and result size limits.
</li></ul>
<p>It is also possible to write your own caching policy by creating a class which derives from CachingPolicy and overriding a bunch of methods.</p>
<p>For more advanced logging scenarios there are also 3 events, which provide access to raw DbCommand objects and some additional information:</p>
<pre class="csharpcode"><span class="kwrd">public</span> <span class="kwrd">event</span> EventHandler&lt;CommandExecutionEventArgs&gt; CommandExecuting
<span class="kwrd">public</span> <span class="kwrd">event</span> EventHandler&lt;CommandExecutionEventArgs&gt; CommandFinished
<span class="kwrd">public</span> <span class="kwrd">event</span> EventHandler&lt;CommandExecutionEventArgs&gt; CommandFailed</pre>
<p>The events are raised before and after each command is executed.</p>
<h1>Global configuration</h1>
<p>You can also configure logging defaults through static properties of EFTracingProviderConfiguration class and they will apply to all new contexts:</p>
<pre class="csharpcode"><span class="kwrd">public</span> <span class="kwrd">static</span> <span class="kwrd">bool</span> LogToConsole { get; set; }</pre>
<p>Specifies whether every SQL command should be logged to the console.</p>
<pre class="csharpcode"><span class="kwrd">public</span> <span class="kwrd">static</span> <span class="kwrd">string</span> LogToFile { get; set; }</pre>
<p>Specifies global log file.</p>
<pre class="csharpcode"><span class="kwrd">public</span> <span class="kwrd">static</span> Action&lt;CommandExecutionEventArgs&gt; LogAction { get; set; }</pre>
<p>Specifies global custom logging action &ndash; a delegate that will be invoked before and after each command is executed.</p>
<h1>Tracing Example</h1>
<p>In order to write all SQL commands to a file, you must create a text writer object to write to and assign it to context.Log:</p>
<p><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">&nbsp;</span></span></p>
<pre class="csharpcode"><span class="kwrd">using</span> (TextWriter logFile = File.CreateText(<span class="str">&quot;sqllogfile.txt&quot;</span>))
{
  <span class="kwrd">using</span> (var context = <span class="kwrd">new</span> ExtendedNorthwindEntities())
  {
    context.Log = logFile;&nbsp;&nbsp;&nbsp;&nbsp; <span class="rem">// ... </span>
  }
}</pre>
<p>&nbsp;</p>
<p>Logging to the console is even easier:</p>
<pre class="csharpcode"><span class="kwrd">using</span> (var context = <span class="kwrd">new</span> ExtendedNorthwindEntities())
{
  context.Log = Console.Out;&nbsp;&nbsp; <span class="rem">// ... </span>
}</pre>
<p>&nbsp;</p>
<p>More advanced logging can be achieved by hooking up Command*events:</p>
<p><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">&nbsp;</span></span></p>
<pre class="csharpcode"><span class="kwrd">using</span> (var context = <span class="kwrd">new</span> ExtendedNorthwindEntities())
{
  context.CommandExecuting &#43;= (sender, e) =&gt;
  {
   Console.WriteLine(<span class="str">&quot;Command is executing: {0}&quot;</span>, e.ToTraceString());
  };
  context.CommandFinished &#43;= (sender, e) =&gt;
  {
    Console.WriteLine(<span class="str">&quot;Command has finished: {0}&quot;</span>, e.ToTraceString());
  };&nbsp;&nbsp; <span class="rem">// ... </span>
}</pre>
<p>&nbsp;</p>
<p>To enable tracing globally for all connections (to both console and a log file):</p>
<pre class="csharpcode">EFTracingProviderConfiguration.LogToConsole = <span class="kwrd">true</span>;
EFTracingProviderConfiguration.LogToFile = <span class="str">&quot;MyLogFile.txt&quot;</span><br></pre>
<h1>Caching Example</h1>
<p>In order to use caching using InMemoryCache implementation, you must create global instances of your cache and caching policy objects:</p>
<pre class="csharpcode">ICache cache = <span class="kwrd">new</span> InMemoryCache(); 
CachingPolicy cachingPolicy = CachingPolicy.CacheAll;</pre>
<p>In order to use caching with Velocity CTP3, you must create DataCache object and pass it to VelocityCache constructor.</p>
<pre class="csharpcode"><span class="kwrd">private</span> <span class="kwrd">static</span> ICache CreateVelocityCache(<span class="kwrd">bool</span> useLocalCache)
{
  DataCacheServerEndpoint endpoint = <span class="kwrd">new</span> DataCacheServerEndpoint(<span class="str">&quot;localhost&quot;</span>, 22233, <span class="str">&quot;DistributedCacheService&quot;</span>);
  DataCacheFactory fac = <span class="kwrd">new</span> DataCacheFactory(<span class="kwrd">new</span> DataCacheServerEndpoint[] { endpoint }, useLocalCache, useLocalCache);

  <span class="kwrd">return</span> <span class="kwrd">new</span> VelocityCache(fac.GetCache(<span class="str">&quot;Velocity&quot;</span>));
}</pre>
<p>Now in order to use either of the caches we need to set up Cache and CachingPolicy properties on the context:</p>
<pre class="csharpcode"><span class="kwrd">using</span> (var context = <span class="kwrd">new</span> ExtendedNorthwindEntities())
{
  <span class="rem">// set up caching</span>
  context.Cache = cache;
  context.CachingPolicy = cachingPolicy;&nbsp;&nbsp; <span class="rem">// ... </span>
}</pre>
<h1>Configuring Providers</h1>
<h2>Provider Registration</h2>
<p>Before a provider can work with Entity Framework it must be registered, either in machine.config file or in application configuration file. Configuration for each provider specifies the factory class and gives it three names, two of which are human-readable
 name and one - provider invariant name is used to refer to the provider in the connection string and SSDL.</p>
<p>Configuration for the providers included in the sample looks like this:</p>
<pre class="csharpcode"><span class="kwrd">&lt;</span><span class="html"><a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/system.data.aspx" target="_blank" title="Auto generated link to system.data">system.data</a></span><span class="kwrd">&gt;</span>
  <span class="kwrd">&lt;</span><span class="html">DbProviderFactories</span><span class="kwrd">&gt;</span>
    <span class="kwrd">&lt;</span><span class="html">add</span> <span class="attr">name</span><span class="kwrd">=&quot;EF Caching Data Provider&quot;</span>
         <span class="attr">invariant</span><span class="kwrd">=&quot;EFCachingProvider&quot;</span>
         <span class="attr">description</span><span class="kwrd">=&quot;Caching Provider Wrapper&quot;</span>
         <span class="attr">type</span><span class="kwrd">=&quot;EFCachingProvider.EFCachingProviderFactory, EFCachingProvider, Version=1.0.0.0, Culture=neutral, PublicKeyToken=def642f226e0e59b&quot;</span> <span class="kwrd">/&gt;</span>
    <span class="kwrd">&lt;</span><span class="html">add</span> <span class="attr">name</span><span class="kwrd">=&quot;EF Tracing Data Provider&quot;</span>
         <span class="attr">invariant</span><span class="kwrd">=&quot;EFTracingProvider&quot;</span>
         <span class="attr">description</span><span class="kwrd">=&quot;Tracing Provider Wrapper&quot;</span>
         <span class="attr">type</span><span class="kwrd">=&quot;EFTracingProvider.EFTracingProviderFactory, EFTracingProvider, Version=1.0.0.0, Culture=neutral, PublicKeyToken=def642f226e0e59b&quot;</span> <span class="kwrd">/&gt;</span>
    <span class="kwrd">&lt;</span><span class="html">add</span> <span class="attr">name</span><span class="kwrd">=&quot;EF Generic Provider Wrapper&quot;</span>
         <span class="attr">invariant</span><span class="kwrd">=&quot;EFProviderWrapper&quot;</span>
         <span class="attr">description</span><span class="kwrd">=&quot;Generic Provider Wrapper&quot;</span>
         <span class="attr">type</span><span class="kwrd">=&quot;EFProviderWrapperToolkit.EFProviderWrapperFactory, EFProviderWrapperToolkit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=def642f226e0e59b&quot;</span> <span class="kwrd">/&gt;</span>
  <span class="kwrd">&lt;/</span><span class="html">DbProviderFactories</span><span class="kwrd">&gt;</span>
<span class="kwrd">&lt;/</span><span class="html"><a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/system.data.aspx" target="_blank" title="Auto generated link to system.data">system.data</a></span><span class="kwrd">&gt;</span></pre>
<p>&nbsp;</p>
<p>This XML fragment can be copied/pasted into any project which needs to use EF provider wrappers or put in the machine.config to be shared by all applications.</p>
<h2>Injecting into provider chain</h2>
<p>In order to inject the provider into the provider chain, you have to modify SSDL files for your project as well as the connection string. There are two ways to do so: automated (which requires application code changes) or manual which can be done externally
 just by changing configuration file and SSDL file.</p>
<p>In order to create an EntityConnection with injected wrapped providers, you can use the provided helper method:</p>
<pre class="csharpcode">connection = EntityConnectionWrapperUtils.CreateEntityConnectionWithWrappers(
  connectionString, <span class="str">&quot;EFTracingProvider&quot;</span>, <span class="str">&quot;EFCachingProvider&quot;</span>)</pre>
<p>You can then pass&nbsp;<strong>connection</strong>&nbsp;to ObjectContext constructor or use the connection to run ESQL queries as usual.</p>
<p><a title="alternativeinjection" name="alternativeinjection"></a></p>
<h2>Alternative injection method</h2>
<p>If you cannot change the application code, you have to make the modifications manually, which involves changing SSDL file and the connection string. Let&rsquo;s take a quick look to see what SSDL and connection string look like today: The provider name is
 specified in the Provider attribute of the &lt;Schema/&gt; element:</p>
<pre class="csharpcode"><span class="kwrd">&lt;</span><span class="html">Schema</span> <span class="attr">Namespace</span><span class="kwrd">=&quot;NorthwindEFModel.Store&quot;</span>
  <span class="attr">Alias</span><span class="kwrd">=&quot;Self&quot;</span>
  <span class="attr">Provider</span><span class="kwrd">=&quot;<span style="text-decoration:underline"><strong><span style="font-size:small"><a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Data.SqlClient.aspx" target="_blank" title="Auto generated link to System.Data.SqlClient">System.Data.SqlClient</a></span></strong></span>&quot;</span>
  <span class="attr">ProviderManifestToken</span><span class="kwrd">=&quot;<strong><span style="text-decoration:underline"><span style="font-size:small">2005</span></span></strong>&quot;</span>
  <span class="attr">xmlns</span><span class="kwrd">=&quot;http://schemas.microsoft.com/ado/2006/04/edm/ssdl&quot;</span><span class="kwrd">&gt;</span></pre>
<p>Provider invariant name is also be specified in the connection string:</p>
<pre class="csharpcode"><span class="kwrd">&lt;</span><span class="html">connectionStrings</span><span class="kwrd">&gt;</span>
  <span class="kwrd">&lt;</span><span class="html">add</span> <span class="attr">name</span><span class="kwrd">=&quot;NorthwindEntities&quot;</span>
       <span class="attr">connectionString</span><span class="kwrd">=&quot;metadata=NorthwindEFModel.csdl | NorthwindEFModel.msl | NorthwindEFModel.ssdl;
                         provider=<strong><span style="text-decoration:underline"><span style="font-size:small"><a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Data.SqlClient.aspx" target="_blank" title="Auto generated link to System.Data.SqlClient">System.Data.SqlClient</a></span></span></strong>; 
                         provider connection string=&amp;quot;Data Source=.\sqlexpress;
Initial Catalog=NorthwindEF;Integrated Security=True;MultipleActiveResultSets=True&amp;quot;&quot;</span>
       <span class="attr">providerName</span><span class="kwrd">=&quot;System.Data.EntityClient&quot;</span> <span class="kwrd">/&gt;</span>
<span class="kwrd">&lt;/</span><span class="html">connectionStrings</span><span class="kwrd">&gt;</span></pre>
<p>In order to inject our own provider we need to override those to point to our provider. In SSDL, we put the name of the new provider in the Provider attribute and concatenate the previous provider with its provider manifest token in the ProviderManifestToken
 field, like this:</p>
<pre class="csharpcode"><span class="kwrd">&lt;?</span><span class="html">xml</span> <span class="attr">version</span><span class="kwrd">=&quot;1.0&quot;</span> <span class="attr">encoding</span><span class="kwrd">=&quot;utf-8&quot;</span>?<span class="kwrd">&gt;</span>
<span class="kwrd">&lt;</span><span class="html">Schema</span> <span class="attr">Namespace</span><span class="kwrd">=&quot;NorthwindEFModel.Store&quot;</span>
  <span class="attr">Alias</span><span class="kwrd">=&quot;Self&quot;</span>
  <span class="attr">Provider</span><span class="kwrd">=&quot;<strong><span style="font-size:small"><span style="text-decoration:underline">EFCachingProvider</span></span></strong>&quot;</span>
  <span class="attr">ProviderManifestToken</span><span class="kwrd">=&quot;<strong><span style="text-decoration:underline"><span style="font-size:small"><a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Data.SqlClient.aspx" target="_blank" title="Auto generated link to System.Data.SqlClient">System.Data.SqlClient</a>;2005</span></span></strong>&quot;</span>
  <span class="attr">xmlns</span><span class="kwrd">=&quot;http://schemas.microsoft.com/ado/2006/04/edm/ssdl&quot;</span><span class="kwrd">&gt;</span></pre>
<p>Modifying connection string is a bit different &ndash; we need to put the pointer to the new *.ssdl, change provider name and add new keyword to provider connection string:</p>
<pre class="csharpcode"><span class="kwrd">&lt;</span><span class="html">connectionStrings</span><span class="kwrd">&gt;</span>
  <span class="kwrd">&lt;</span><span class="html">add</span> <span class="attr">name</span><span class="kwrd">=&quot;NorthwindEntities&quot;</span>
       <span class="attr">connectionString</span><span class="kwrd">=&quot;metadata=NorthwindEFModel.csdl | NorthwindEFModel.msl | <strong><span style="text-decoration:underline"><span style="font-size:small">NorthwindEFModel.Modified.ssdl</span></span></strong>;
                         provider=<strong><span style="text-decoration:underline"><span style="font-size:small">EFCachingProvider</span></span></strong>; 
                         provider connection string=&amp;quot;<span style="text-decoration:underline"><span style="font-size:small"><strong>wrappedProvider=<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Data.SqlClient.aspx" target="_blank" title="Auto generated link to System.Data.SqlClient">System.Data.SqlClient</a>;</strong></span></span>Data Source=.\sqlexpress;<br>Initial Catalog=NorthwindEF;Integrated Security=True;MultipleActiveResultSets=True&amp;quot;&quot;</span>
       <span class="attr">providerName</span><span class="kwrd">=&quot;System.Data.EntityClient&quot;</span> <span class="kwrd">/&gt;</span>
<span class="kwrd">&lt;/</span><span class="html">connectionStrings</span><span class="kwrd">&gt;</span></pre>
<h2>Specifying tracing configuration in the configuration file</h2>
<p>It is also possible to specify tracing configuration in App.config file. The following parameters are available:</p>
<pre class="csharpcode"><span class="kwrd">&lt;</span><span class="html">appSettings</span><span class="kwrd">&gt;</span>
  <span class="rem">&lt;!-- write log messages to the console. --&gt;</span>
  <span class="kwrd">&lt;</span><span class="html">add</span> <span class="attr">key</span><span class="kwrd">=&quot;EFTracingProvider.logToConsole&quot;</span> <span class="attr">value</span><span class="kwrd">=&quot;true&quot;</span> <span class="kwrd">/&gt;</span>
    
  <span class="rem">&lt;!-- append log messages to the specified file --&gt;</span>
  <span class="kwrd">&lt;</span><span class="html">add</span> <span class="attr">key</span><span class="kwrd">=&quot;EFTracingProvider.logToFile&quot;</span> <span class="attr">value</span><span class="kwrd">=&quot;sqllog.txt&quot;</span> <span class="kwrd">/&gt;</span>
<span class="kwrd">&lt;/</span><span class="html">appSettings</span><span class="kwrd">&gt;</span></pre>
<h1>Limitations and Disclaimers</h1>
<p>The providers have not been extensively tested beyond what&rsquo;s included in the sample code, so you should use them at your own risk.</p>
<p>As with any other sample, Microsoft is not offering any kind of support for it.<strong><br>
</strong></p>
