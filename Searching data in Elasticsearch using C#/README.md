# Searching data in Elasticsearch using C#
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- C#
- JSON
- ES
- Elasticsearch
## Topics
- C#
- JSON
- ES
- Elasticsearch
## Updated
- 06/01/2016
## Description

<p><span style="font-size:small">To help beginners I decided to write the article with step by step approach using Elasticsearch with C#, since it is a NOSQL, distributed full text database. Which means that this database is document based instead of using
 tables or schema, we use documents&hellip; lots and lots of documents. I have written this article specially focusing on newcomers and anyone new wants to learn or thinking of using ES in their .NET program. This sample illustrates a way to let user search
 data from Elasticsearch from their app.</span></p>
<h1><span>&nbsp;</span><br>
<span>Work In Progress.</span></h1>
<h2><span>Overview:</span></h2>
<p><span style="font-size:small">This article covers 3 major aspects</span></p>
<ul>
<li>
<p><span style="font-size:small">What is Elasticseach?<br>
</span></p>
</li><li>
<p><span style="font-size:small">Getting started with ES in Visual Studio<br>
</span></p>
</li><li>
<p><span style="font-size:small">Perform some search operation using C#</span></p>
</li></ul>
<h2 id="markdown-header-what-is-elasticsearch"><span>What is Elasticsearch?</span></h2>
<p><span style="font-size:small"><a rel="nofollow" href="http://www.elasticsearch.org/">http://www.elasticsearch.org/</a></span></p>
<p><span style="font-size:small">ElasticSearch is a distributed RESTful search engine built for the cloud. Features include:</span></p>
<ul>
<li><span style="font-size:small">Distributed and Highly Available Search Engine.
</span>
<ul>
<li><span style="font-size:small">Each index is fully sharded with a configurable number of shards.</span>
</li><li><span style="font-size:small">Each shard can have one or more replicas.</span>
</li><li><span style="font-size:small">Read / Search operations performed on either one of the replica shard.</span>
</li></ul>
</li><li><span style="font-size:small">Multi Tenant with Multi Types. </span>
<ul>
<li><span style="font-size:small">Support for more than one index.</span> </li><li><span style="font-size:small">Support for more than one type per index.</span>
</li><li><span style="font-size:small">Index level configuration (number of shards, index storage, &hellip;).</span>
</li></ul>
</li><li><span style="font-size:small">Various set of APIs </span>
<ul>
<li><span style="font-size:small">HTTP RESTful API</span> </li><li><span style="font-size:small">Native Java API.</span> </li><li><span style="font-size:small">All APIs perform automatic node operation rerouting.</span>
</li></ul>
</li><li><span style="font-size:small">Document oriented </span>
<ul>
<li><span style="font-size:small">No need for upfront schema definition.</span> </li><li><span style="font-size:small">Schema can be defined per type for customization of the indexing process.</span>
</li></ul>
</li><li><span style="font-size:small">Reliable, Asynchronous Write Behind for long term persistency.</span>
</li><li><span style="font-size:small">(Near) Real Time Search.</span> </li><li><span style="font-size:small">Built on top of Lucene </span>
<ul>
<li><span style="font-size:small">Each shard is a fully functional Lucene index</span>
</li><li><span style="font-size:small">All the power of Lucene easily exposed through simple configuration / plugins.</span>
</li></ul>
</li><li><span style="font-size:small">Per operation consistency </span>
<ul>
<li><span style="font-size:small">Single document level operations are atomic, consistent, isolated and durable.</span>
</li></ul>
</li><li><span style="font-size:small">Open Source under Apache 2 License.</span> </li></ul>
<h2 id="markdown-header-installing-elasticsearch">Installing Elasticsearch</h2>
<h3 id="markdown-header-installing-elastic-search-on-a-windows-server">Installing Elastic Search on a Windows server</h3>
<ul>
<li>
<p><span style="font-size:small">Pre-requisites:</span></p>
<ul>
<li>
<p><span style="font-size:small">Java Runtime Environment (JRE)<a rel="nofollow" href="http://www.oracle.com/technetwork/java/javase/downloads/index.html">http://www.oracle.com/technetwork/java/javase/downloads/index.html</a></span></p>
</li><li>
<p><span style="font-size:small">After installing JRE, do yourself a favor and set the JAVA___HOME environment variable</span></p>
<ul>
<li>
<p><span style="font-size:small">My Computer -&gt; Properties -&gt; Advanced tab -&gt; Environment variables button</span></p>
</li><li>
<p><span style="font-size:small">Under System Variables, click Add New</span></p>
</li><li>
<p><span style="font-size:small">Name: JAVA___HOME</span></p>
</li><li>
<p><span style="font-size:small">Path: c:\progra~1\Java\jre7</span></p>
</li><li>
<p><span style="font-size:small">Assumes Java JRE is installed at c:\program files\Java\jre[X]</span></p>
</li></ul>
</li></ul>
</li><li>
<p><span style="font-size:small">You can download the Elasticsearch runtime from the Elasticsearch website and follow the standard installation instructions (it's really quite simple)</span></p>
</li><li>
<p><span style="font-size:small">OR, if you'd like the Elasticsearch engine to run as a Windows service, you can download an installer from here:&nbsp;<a rel="nofollow" href="http://ruilopes.com/elasticsearch-setup/">http://ruilopes.com/elasticsearch-setup/</a></span></p>
<ul>
<li>
<p><span style="font-size:small">Basically the installer just unzips the Elasticsearch package, then creates a Windows service wrapping the engine</span></p>
</li><li>
<p><span style="font-size:small">Install to [DRIVE]:\Elasticsearch (avoid installing to the Program Files directory to help avoid UAC issues)</span></p>
</li><li>
<p><span style="font-size:small">An Elasticsearch service will be created, but you may need to start the service manually (Administrative tools -&gt; Services) and set it to startup automatically</span></p>
</li></ul>
</li><li>
<p><span style="font-size:small">Confirm Elasticsearch is running by browsing to:&nbsp;<a rel="nofollow" href="http://localhost:9200/_cluster/health">http://localhost:9200/_cluster/health</a></span></p>
<ul>
<li>
<p><span style="font-size:small">If you receive a JSON response with a property named &quot;status&quot; that has a value of &quot;green&quot; or &quot;yellow&quot;, all systems are go.</span></p>
</li><li>
<p><span style="font-size:small">By default, Elasticsearch listens on port 9200.</span></p>
</li></ul>
</li></ul>
<h2 id="markdown-header-install-a-web-based-management-tool-for-elastic-search">
Install a web-based management tool for Elastic Search</h2>
<ul>
<li><span style="font-size:small">I like the Kibana for cluster/node/index monitoring -&nbsp;<a rel="nofollow" href="https://www.elastic.co/products/kibana">https://www.elastic.co/products/kibana</a></span>
</li><li><span style="font-size:small">I also like the Sense plugin for Google Chrome for testing queries -<a rel="nofollow" href="https://chrome.google.com/webstore/detail/sense/doinijnbnggojdlcjifpdckfokbbfpbo">https://chrome.google.com/webstore/detail/sense/doinijnbnggojdlcjifpdckfokbbfpbo</a></span>
</li><li><span style="font-size:small">Another great client elasticsearch-head also good for monitoring cluster -<a rel="nofollow" href="https://mobz.github.io/elasticsearch-head/">https://mobz.github.io/elasticsearch-head/</a></span>
</li><li><span style="font-size:small">Several other options/tools available here:&nbsp;<a rel="nofollow" href="http://www.elasticsearch.org/guide/clients/">http://www.elasticsearch.org/guide/clients/</a>
</span>
<ul>
<li><span style="font-size:small">Scroll to the &quot;Health and Performance Monitoring&quot; and &quot;Front Ends&quot; sections</span>
</li></ul>
</li></ul>
<h2 id="markdown-header-elasticsearch-with-csharp"><span>ElasticSearch-with-Csharp</span></h2>
<p><span style="font-size:small">ElasticSearch with C#</span></p>
<p><span style="font-size:small">Example project for using Elasticsearch with C#. This is a autosearch feature demonstration in Elasticsearch using C#.NET. User cansearch any name by typing its first character. Example for searching user &quot;Abby&quot; jusy type A
 and it will list all the name that has A in it.</span></p>
<h2 id="markdown-header-getting-started"><span>Getting Started</span></h2>
<p><span style="font-size:small">Download NEST package using the below command and then run the program. You can learn more about Elasticsearch.NET &amp; NEST&nbsp;<a href="https://github.com/elastic/elasticsearch-net">here</a>.</span></p>
<div class="codehilite">
<pre><span style="font-size:small"><span class="n">PM</span><span class="o">&gt;</span> <span class="n">Install</span><span class="o">-</span><span class="n">Package</span> <span class="n">NEST</span></span>
</pre>
</div>
<h2 id="markdown-header-sample-data"><span>Sample Data</span></h2>
<p><span style="font-size:small">You could use the attached data in the project folder and do a bulk insert into ES or you can use your own data. If you use you own data please change the index name in the Form1.cs code to your index name and type to your type
 name. Also you need to update the getter and setter.</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">Sample code will be look like as follows</span></p>
<p><span style="font-size:small">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;Nest;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Windows.Forms.aspx" target="_blank" title="Auto generated link to System.Windows.Forms">System.Windows.Forms</a>;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;ESsearchTest&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;Form1&nbsp;:&nbsp;Form&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ConnectionSettings&nbsp;connectionSettings;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ElasticClient&nbsp;elasticClient;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Form1()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Form1_Load(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Establishing&nbsp;connection&nbsp;with&nbsp;ES</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;connectionSettings&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ConnectionSettings(<span class="cs__keyword">new</span>&nbsp;Uri(<span class="cs__string">&quot;http://localhost:9200/&quot;</span>));&nbsp;<span class="cs__com">//local&nbsp;PC&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;elasticClient&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ElasticClient(connectionSettings);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Get&nbsp;suggestion&nbsp;under&nbsp;search&nbsp;textbox</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;tbxName_TextChanged(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Search&nbsp;query&nbsp;to&nbsp;retrieve&nbsp;info</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;response&nbsp;=&nbsp;elasticClient.Search&lt;disney&gt;(s&nbsp;=&gt;&nbsp;s&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Index(<span class="cs__string">&quot;disney&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Type(<span class="cs__string">&quot;character&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Query(q&nbsp;=&gt;&nbsp;q.QueryString(qs&nbsp;=&gt;&nbsp;qs.Query(tbxName.Text&nbsp;&#43;&nbsp;<span class="cs__string">&quot;*&quot;</span>))));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AutoCompleteStringCollection&nbsp;collection&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;AutoCompleteStringCollection();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(var&nbsp;hit&nbsp;<span class="cs__keyword">in</span>&nbsp;response.Hits)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;collection.Add(hit.Source.name);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tbxName.AutoCompleteSource&nbsp;=&nbsp;AutoCompleteSource.CustomSource;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tbxName.AutoCompleteMode&nbsp;=&nbsp;AutoCompleteMode.Suggest;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tbxName.AutoCompleteCustomSource&nbsp;=&nbsp;collection;&nbsp;
&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(tbxName.Text&nbsp;==&nbsp;<span class="cs__string">&quot;&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rtxSearchResult.Clear();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;tbxName_KeyPress(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;KeyPressEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(e.KeyChar&nbsp;==&nbsp;<span class="cs__string">'\b'</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rtxSearchResult.Clear();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<h2><span>Technicalities:</span></h2>
<p><span style="font-size:small">The application retrieves all names from Elasticsearch. That means that if a name didn't create in the index that information will not show.</span></p>
<p><span style="font-size:small"><strong>Note</strong></span></p>
<div>
<ul>
<li>
<p><span style="font-size:small">For more about query DSL please see this page&nbsp;<a href="https://www.elastic.co/guide/en/elasticsearch/reference/current/query-dsl.html" target="_blank">Query DSL</a></span></p>
</li><li>
<p><span style="font-size:small">More about Elasticsearch visit&nbsp;<a href="https://www.elastic.co/" target="_blank">website</a></span></p>
</li></ul>
</div>
