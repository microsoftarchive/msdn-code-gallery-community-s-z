# Working with API help page controller action description in Web API
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- SQL Server
- XML
- ASP.NET Web API
- Web API
- Entity Framework 6
- Visual Studio 2015
## Topics
- documentation
- XML Documentation
- Visual Studio 2015
## Updated
- 05/12/2016
## Description

<p><span style="font-size:small">In this article we are going to see how we can enable the API descriptions for the better understanding of how our API controller works and what exactly it is supposed to do. It is recommended that to give the summary and parameter
 lists and a bit introduction to the service whenever you write any API services. Here I am going to use create a&nbsp;<a href="http://sibeeshpassion.com/category/web-api" target="_blank">Web API</a>&nbsp;in&nbsp;<a href="http://sibeeshpassion.com/category/tools/visual-studio/" target="_blank">Visual
 Studio</a>&nbsp;2015. I hope you will like this.</span></p>
<p><strong><span style="font-size:small">Download the source code</span></strong></p>
<p><span style="font-size:small">You can always download the source code here:&nbsp;<a href="http://sibeeshpassion.com/Download/ControllerActionDescriptions.zip" target="_blank">API Help Page Documentation</a></span></p>
<p><strong><span style="font-size:small">Background</span></strong></p>
<p><span style="font-size:small">Few months back I have hosted one of my API application to&nbsp;<a href="http://sibeeshpassion.com/category/azure" target="_blank">Azure</a>. I thought of implementing the document summary for the services(controllers actions)
 now. And I did, now any one can understand what exactly my service will do by going to the help page of the API application. I will show you a demo of the same. Here we will create a Web API with entity framework. Lets us start then.</span></p>
<p><span style="font-size:small">Setting up database</span></p>
<p><span style="font-size:small">Here I am going to create a database which I created for my demo purposes, you can always create this database by running the queries mentioned here.</span></p>
<p><strong><span style="font-size:small">Create database</span></strong></p>
<div>
<div class="syntaxhighlighter sql" id="highlighter_882996">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="js">USE&nbsp;[master]&nbsp;
GO&nbsp;
&nbsp;&nbsp;
/******&nbsp;Object:&nbsp;&nbsp;Database&nbsp;[TrialsDB]&nbsp;&nbsp;&nbsp;&nbsp;Script&nbsp;Date:&nbsp;<span class="js__num">5</span>/<span class="js__num">12</span><span class="js__reg_exp">/2016&nbsp;10:56:41&nbsp;AM&nbsp;******/</span>&nbsp;
CREATE&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;
&nbsp;CONTAINMENT&nbsp;=&nbsp;NONE&nbsp;
&nbsp;ON&nbsp;&nbsp;PRIMARY&nbsp;
(&nbsp;NAME&nbsp;=&nbsp;N<span class="js__string">'TrialsDB'</span>,&nbsp;FILENAME&nbsp;=&nbsp;N<span class="js__string">'C:\Program&nbsp;Files\Microsoft&nbsp;SQL&nbsp;Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\TrialsDB.mdf'</span>&nbsp;,&nbsp;SIZE&nbsp;=&nbsp;3072KB&nbsp;,&nbsp;MAXSIZE&nbsp;=&nbsp;UNLIMITED,&nbsp;FILEGROWTH&nbsp;=&nbsp;1024KB&nbsp;)&nbsp;
&nbsp;LOG&nbsp;ON&nbsp;
(&nbsp;NAME&nbsp;=&nbsp;N<span class="js__string">'TrialsDB_log'</span>,&nbsp;FILENAME&nbsp;=&nbsp;N<span class="js__string">'C:\Program&nbsp;Files\Microsoft&nbsp;SQL&nbsp;Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\TrialsDB_log.ldf'</span>&nbsp;,&nbsp;SIZE&nbsp;=&nbsp;1024KB&nbsp;,&nbsp;MAXSIZE&nbsp;=&nbsp;2048GB&nbsp;,&nbsp;FILEGROWTH&nbsp;=&nbsp;<span class="js__num">10</span>%)&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;COMPATIBILITY_LEVEL&nbsp;=&nbsp;<span class="js__num">110</span>&nbsp;
GO&nbsp;
&nbsp;&nbsp;
IF&nbsp;(<span class="js__num">1</span>&nbsp;=&nbsp;FULLTEXTSERVICEPROPERTY(<span class="js__string">'IsFullTextInstalled'</span>))&nbsp;
begin&nbsp;
EXEC&nbsp;[TrialsDB].[dbo].[sp_fulltext_database]&nbsp;@action&nbsp;=&nbsp;<span class="js__string">'enable'</span>&nbsp;
end&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;ANSI_NULL_DEFAULT&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;ANSI_NULLS&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;ANSI_PADDING&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;ANSI_WARNINGS&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;ARITHABORT&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;AUTO_CLOSE&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;AUTO_CREATE_STATISTICS&nbsp;ON&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;AUTO_SHRINK&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;AUTO_UPDATE_STATISTICS&nbsp;ON&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;CURSOR_CLOSE_ON_COMMIT&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;CURSOR_DEFAULT&nbsp;&nbsp;GLOBAL&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;CONCAT_NULL_YIELDS_NULL&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;NUMERIC_ROUNDABORT&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;QUOTED_IDENTIFIER&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;RECURSIVE_TRIGGERS&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;&nbsp;DISABLE_BROKER&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;AUTO_UPDATE_STATISTICS_ASYNC&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;DATE_CORRELATION_OPTIMIZATION&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;TRUSTWORTHY&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;ALLOW_SNAPSHOT_ISOLATION&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;PARAMETERIZATION&nbsp;SIMPLE&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;READ_COMMITTED_SNAPSHOT&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;HONOR_BROKER_PRIORITY&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;RECOVERY&nbsp;FULL&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;&nbsp;MULTI_USER&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;PAGE_VERIFY&nbsp;CHECKSUM&nbsp;&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;DB_CHAINING&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;FILESTREAM(&nbsp;NON_TRANSACTED_ACCESS&nbsp;=&nbsp;OFF&nbsp;)&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;TARGET_RECOVERY_TIME&nbsp;=&nbsp;<span class="js__num">0</span>&nbsp;SECONDS&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;&nbsp;READ_WRITE&nbsp;
GO</pre>
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
<p><strong><span style="font-size:small">Create table with data</span></strong></p>
<div>
<div class="syntaxhighlighter sql" id="highlighter_632029">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="mysql"><span class="sql__keyword">USE</span>&nbsp;[<span class="sql__id">TrialsDB</span>]&nbsp;
<span class="sql__id">GO</span>&nbsp;
<span class="sql__mlcom">/******&nbsp;Object:&nbsp;&nbsp;Table&nbsp;[dbo].[Product]&nbsp;&nbsp;&nbsp;&nbsp;Script&nbsp;Date:&nbsp;5/12/2016&nbsp;10:54:48&nbsp;AM&nbsp;******/</span>&nbsp;
<span class="sql__keyword">SET</span>&nbsp;<span class="sql__id">ANSI_NULLS</span>&nbsp;<span class="sql__keyword">ON</span>&nbsp;
<span class="sql__id">GO</span>&nbsp;
<span class="sql__keyword">SET</span>&nbsp;<span class="sql__id">QUOTED_IDENTIFIER</span>&nbsp;<span class="sql__keyword">ON</span>&nbsp;
<span class="sql__id">GO</span>&nbsp;
<span class="sql__keyword">CREATE</span>&nbsp;<span class="sql__keyword">TABLE</span>&nbsp;[<span class="sql__id">dbo</span>].[<span class="sql__id">Product</span>](&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">ProductID</span>]&nbsp;[<span class="sql__keyword">int</span>]&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__keyword">Name</span>]&nbsp;[<span class="sql__keyword">nvarchar</span>](<span class="sql__id">max</span>)&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">ProductNumber</span>]&nbsp;[<span class="sql__keyword">nvarchar</span>](<span class="sql__number">25</span>)&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">MakeFlag</span>]&nbsp;[<span class="sql__keyword">bit</span>]&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">FinishedGoodsFlag</span>]&nbsp;[<span class="sql__keyword">bit</span>]&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">Color</span>]&nbsp;[<span class="sql__keyword">nvarchar</span>](<span class="sql__number">15</span>)&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">SafetyStockLevel</span>]&nbsp;[<span class="sql__keyword">smallint</span>]&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">ReorderPoint</span>]&nbsp;[<span class="sql__keyword">smallint</span>]&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">StandardCost</span>]&nbsp;[<span class="sql__id">money</span>]&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">ListPrice</span>]&nbsp;[<span class="sql__id">money</span>]&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">Size</span>]&nbsp;[<span class="sql__keyword">nvarchar</span>](<span class="sql__number">5</span>)&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">SizeUnitMeasureCode</span>]&nbsp;[<span class="sql__keyword">nchar</span>](<span class="sql__number">3</span>)&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">WeightUnitMeasureCode</span>]&nbsp;[<span class="sql__keyword">nchar</span>](<span class="sql__number">3</span>)&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">Weight</span>]&nbsp;[<span class="sql__keyword">decimal</span>](<span class="sql__number">8</span>,&nbsp;<span class="sql__number">2</span>)&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">DaysToManufacture</span>]&nbsp;[<span class="sql__keyword">int</span>]&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">ProductLine</span>]&nbsp;[<span class="sql__keyword">nchar</span>](<span class="sql__number">2</span>)&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">Class</span>]&nbsp;[<span class="sql__keyword">nchar</span>](<span class="sql__number">2</span>)&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">Style</span>]&nbsp;[<span class="sql__keyword">nchar</span>](<span class="sql__number">2</span>)&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">ProductSubcategoryID</span>]&nbsp;[<span class="sql__keyword">int</span>]&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">ProductModelID</span>]&nbsp;[<span class="sql__keyword">int</span>]&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">SellStartDate</span>]&nbsp;[<span class="sql__keyword">datetime</span>]&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">SellEndDate</span>]&nbsp;[<span class="sql__keyword">datetime</span>]&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">DiscontinuedDate</span>]&nbsp;[<span class="sql__keyword">datetime</span>]&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">rowguid</span>]&nbsp;[<span class="sql__id">uniqueidentifier</span>]&nbsp;<span class="sql__id">ROWGUIDCOL</span>&nbsp;&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">ModifiedDate</span>]&nbsp;[<span class="sql__keyword">datetime</span>]&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>&nbsp;
)&nbsp;<span class="sql__keyword">ON</span>&nbsp;[<span class="sql__keyword">PRIMARY</span>]&nbsp;<span class="sql__id">TEXTIMAGE_ON</span>&nbsp;[<span class="sql__keyword">PRIMARY</span>]&nbsp;
<span class="sql__id">GO</span>&nbsp;
<span class="sql__keyword">INSERT</span>&nbsp;[<span class="sql__id">dbo</span>].[<span class="sql__id">Product</span>]&nbsp;([<span class="sql__id">ProductID</span>],&nbsp;[<span class="sql__keyword">Name</span>],&nbsp;[<span class="sql__id">ProductNumber</span>],&nbsp;[<span class="sql__id">MakeFlag</span>],&nbsp;[<span class="sql__id">FinishedGoodsFlag</span>],&nbsp;[<span class="sql__id">Color</span>],&nbsp;[<span class="sql__id">SafetyStockLevel</span>],&nbsp;[<span class="sql__id">ReorderPoint</span>],&nbsp;[<span class="sql__id">StandardCost</span>],&nbsp;[<span class="sql__id">ListPrice</span>],&nbsp;[<span class="sql__id">Size</span>],&nbsp;[<span class="sql__id">SizeUnitMeasureCode</span>],&nbsp;[<span class="sql__id">WeightUnitMeasureCode</span>],&nbsp;[<span class="sql__id">Weight</span>],&nbsp;[<span class="sql__id">DaysToManufacture</span>],&nbsp;[<span class="sql__id">ProductLine</span>],&nbsp;[<span class="sql__id">Class</span>],&nbsp;[<span class="sql__id">Style</span>],&nbsp;[<span class="sql__id">ProductSubcategoryID</span>],&nbsp;[<span class="sql__id">ProductModelID</span>],&nbsp;[<span class="sql__id">SellStartDate</span>],&nbsp;[<span class="sql__id">SellEndDate</span>],&nbsp;[<span class="sql__id">DiscontinuedDate</span>],&nbsp;[<span class="sql__id">rowguid</span>],&nbsp;[<span class="sql__id">ModifiedDate</span>])&nbsp;<span class="sql__keyword">VALUES</span>&nbsp;(<span class="sql__number">1</span>,&nbsp;<span class="sql__id">N</span><span class="sql__string">'Adjustable&nbsp;Race'</span>,&nbsp;<span class="sql__id">N</span><span class="sql__string">'AR-5381'</span>,&nbsp;<span class="sql__number">0</span>,&nbsp;<span class="sql__number">0</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__number">1000</span>,&nbsp;<span class="sql__number">750</span>,&nbsp;<span class="sql__number">0.0000</span>,&nbsp;<span class="sql__number">0.0000</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__number">0</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__function">CAST</span>(<span class="sql__hexnum">0x0000921E00000000</span>&nbsp;<span class="sql__keyword">AS</span>&nbsp;<span class="sql__keyword">DateTime</span>),&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__id">N</span><span class="sql__string">'694215b7-08f7-4c0d-acb1-d734ba44c0c8'</span>,&nbsp;<span class="sql__function">CAST</span>(<span class="sql__hexnum">0x00009A5C00A53CF8</span>&nbsp;<span class="sql__keyword">AS</span>&nbsp;<span class="sql__keyword">DateTime</span>))&nbsp;
<span class="sql__keyword">INSERT</span>&nbsp;[<span class="sql__id">dbo</span>].[<span class="sql__id">Product</span>]&nbsp;([<span class="sql__id">ProductID</span>],&nbsp;[<span class="sql__keyword">Name</span>],&nbsp;[<span class="sql__id">ProductNumber</span>],&nbsp;[<span class="sql__id">MakeFlag</span>],&nbsp;[<span class="sql__id">FinishedGoodsFlag</span>],&nbsp;[<span class="sql__id">Color</span>],&nbsp;[<span class="sql__id">SafetyStockLevel</span>],&nbsp;[<span class="sql__id">ReorderPoint</span>],&nbsp;[<span class="sql__id">StandardCost</span>],&nbsp;[<span class="sql__id">ListPrice</span>],&nbsp;[<span class="sql__id">Size</span>],&nbsp;[<span class="sql__id">SizeUnitMeasureCode</span>],&nbsp;[<span class="sql__id">WeightUnitMeasureCode</span>],&nbsp;[<span class="sql__id">Weight</span>],&nbsp;[<span class="sql__id">DaysToManufacture</span>],&nbsp;[<span class="sql__id">ProductLine</span>],&nbsp;[<span class="sql__id">Class</span>],&nbsp;[<span class="sql__id">Style</span>],&nbsp;[<span class="sql__id">ProductSubcategoryID</span>],&nbsp;[<span class="sql__id">ProductModelID</span>],&nbsp;[<span class="sql__id">SellStartDate</span>],&nbsp;[<span class="sql__id">SellEndDate</span>],&nbsp;[<span class="sql__id">DiscontinuedDate</span>],&nbsp;[<span class="sql__id">rowguid</span>],&nbsp;[<span class="sql__id">ModifiedDate</span>])&nbsp;<span class="sql__keyword">VALUES</span>&nbsp;(<span class="sql__number">2</span>,&nbsp;<span class="sql__id">N</span><span class="sql__string">'Bearing&nbsp;Ball'</span>,&nbsp;<span class="sql__id">N</span><span class="sql__string">'BA-8327'</span>,&nbsp;<span class="sql__number">0</span>,&nbsp;<span class="sql__number">0</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__number">1000</span>,&nbsp;<span class="sql__number">750</span>,&nbsp;<span class="sql__number">0.0000</span>,&nbsp;<span class="sql__number">0.0000</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__number">0</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__function">CAST</span>(<span class="sql__hexnum">0x0000921E00000000</span>&nbsp;<span class="sql__keyword">AS</span>&nbsp;<span class="sql__keyword">DateTime</span>),&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__id">N</span><span class="sql__string">'58ae3c20-4f3a-4749-a7d4-d568806cc537'</span>,&nbsp;<span class="sql__function">CAST</span>(<span class="sql__hexnum">0x00009A5C00A53CF8</span>&nbsp;<span class="sql__keyword">AS</span>&nbsp;<span class="sql__keyword">DateTime</span>))&nbsp;
<span class="sql__keyword">INSERT</span>&nbsp;[<span class="sql__id">dbo</span>].[<span class="sql__id">Product</span>]&nbsp;([<span class="sql__id">ProductID</span>],&nbsp;[<span class="sql__keyword">Name</span>],&nbsp;[<span class="sql__id">ProductNumber</span>],&nbsp;[<span class="sql__id">MakeFlag</span>],&nbsp;[<span class="sql__id">FinishedGoodsFlag</span>],&nbsp;[<span class="sql__id">Color</span>],&nbsp;[<span class="sql__id">SafetyStockLevel</span>],&nbsp;[<span class="sql__id">ReorderPoint</span>],&nbsp;[<span class="sql__id">StandardCost</span>],&nbsp;[<span class="sql__id">ListPrice</span>],&nbsp;[<span class="sql__id">Size</span>],&nbsp;[<span class="sql__id">SizeUnitMeasureCode</span>],&nbsp;[<span class="sql__id">WeightUnitMeasureCode</span>],&nbsp;[<span class="sql__id">Weight</span>],&nbsp;[<span class="sql__id">DaysToManufacture</span>],&nbsp;[<span class="sql__id">ProductLine</span>],&nbsp;[<span class="sql__id">Class</span>],&nbsp;[<span class="sql__id">Style</span>],&nbsp;[<span class="sql__id">ProductSubcategoryID</span>],&nbsp;[<span class="sql__id">ProductModelID</span>],&nbsp;[<span class="sql__id">SellStartDate</span>],&nbsp;[<span class="sql__id">SellEndDate</span>],&nbsp;[<span class="sql__id">DiscontinuedDate</span>],&nbsp;[<span class="sql__id">rowguid</span>],&nbsp;[<span class="sql__id">ModifiedDate</span>])&nbsp;<span class="sql__keyword">VALUES</span>&nbsp;(<span class="sql__number">3</span>,&nbsp;<span class="sql__id">N</span><span class="sql__string">'BB&nbsp;Ball&nbsp;Bearing'</span>,&nbsp;<span class="sql__id">N</span><span class="sql__string">'BE-2349'</span>,&nbsp;<span class="sql__number">1</span>,&nbsp;<span class="sql__number">0</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__number">800</span>,&nbsp;<span class="sql__number">600</span>,&nbsp;<span class="sql__number">0.0000</span>,&nbsp;<span class="sql__number">0.0000</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__number">1</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__function">CAST</span>(<span class="sql__hexnum">0x0000921E00000000</span>&nbsp;<span class="sql__keyword">AS</span>&nbsp;<span class="sql__keyword">DateTime</span>),&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__id">N</span><span class="sql__string">'9c21aed2-5bfa-4f18-bcb8-f11638dc2e4e'</span>,&nbsp;<span class="sql__function">CAST</span>(<span class="sql__hexnum">0x00009A5C00A53CF8</span>&nbsp;<span class="sql__keyword">AS</span>&nbsp;<span class="sql__keyword">DateTime</span>))&nbsp;
<span class="sql__keyword">INSERT</span>&nbsp;[<span class="sql__id">dbo</span>].[<span class="sql__id">Product</span>]&nbsp;([<span class="sql__id">ProductID</span>],&nbsp;[<span class="sql__keyword">Name</span>],&nbsp;[<span class="sql__id">ProductNumber</span>],&nbsp;[<span class="sql__id">MakeFlag</span>],&nbsp;[<span class="sql__id">FinishedGoodsFlag</span>],&nbsp;[<span class="sql__id">Color</span>],&nbsp;[<span class="sql__id">SafetyStockLevel</span>],&nbsp;[<span class="sql__id">ReorderPoint</span>],&nbsp;[<span class="sql__id">StandardCost</span>],&nbsp;[<span class="sql__id">ListPrice</span>],&nbsp;[<span class="sql__id">Size</span>],&nbsp;[<span class="sql__id">SizeUnitMeasureCode</span>],&nbsp;[<span class="sql__id">WeightUnitMeasureCode</span>],&nbsp;[<span class="sql__id">Weight</span>],&nbsp;[<span class="sql__id">DaysToManufacture</span>],&nbsp;[<span class="sql__id">ProductLine</span>],&nbsp;[<span class="sql__id">Class</span>],&nbsp;[<span class="sql__id">Style</span>],&nbsp;[<span class="sql__id">ProductSubcategoryID</span>],&nbsp;[<span class="sql__id">ProductModelID</span>],&nbsp;[<span class="sql__id">SellStartDate</span>],&nbsp;[<span class="sql__id">SellEndDate</span>],&nbsp;[<span class="sql__id">DiscontinuedDate</span>],&nbsp;[<span class="sql__id">rowguid</span>],&nbsp;[<span class="sql__id">ModifiedDate</span>])&nbsp;<span class="sql__keyword">VALUES</span>&nbsp;(<span class="sql__number">4</span>,&nbsp;<span class="sql__id">N</span><span class="sql__string">'Headset&nbsp;Ball&nbsp;Bearings'</span>,&nbsp;<span class="sql__id">N</span><span class="sql__string">'BE-2908'</span>,&nbsp;<span class="sql__number">0</span>,&nbsp;<span class="sql__number">0</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__number">800</span>,&nbsp;<span class="sql__number">600</span>,&nbsp;<span class="sql__number">0.0000</span>,&nbsp;<span class="sql__number">0.0000</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__number">0</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__function">CAST</span>(<span class="sql__hexnum">0x0000921E00000000</span>&nbsp;<span class="sql__keyword">AS</span>&nbsp;<span class="sql__keyword">DateTime</span>),&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__id">N</span><span class="sql__string">'ecfed6cb-51ff-49b5-b06c-7d8ac834db8b'</span>,&nbsp;<span class="sql__function">CAST</span>(<span class="sql__hexnum">0x00009A5C00A53CF8</span>&nbsp;<span class="sql__keyword">AS</span>&nbsp;<span class="sql__keyword">DateTime</span>))&nbsp;
<span class="sql__keyword">INSERT</span>&nbsp;[<span class="sql__id">dbo</span>].[<span class="sql__id">Product</span>]&nbsp;([<span class="sql__id">ProductID</span>],&nbsp;[<span class="sql__keyword">Name</span>],&nbsp;[<span class="sql__id">ProductNumber</span>],&nbsp;[<span class="sql__id">MakeFlag</span>],&nbsp;[<span class="sql__id">FinishedGoodsFlag</span>],&nbsp;[<span class="sql__id">Color</span>],&nbsp;[<span class="sql__id">SafetyStockLevel</span>],&nbsp;[<span class="sql__id">ReorderPoint</span>],&nbsp;[<span class="sql__id">StandardCost</span>],&nbsp;[<span class="sql__id">ListPrice</span>],&nbsp;[<span class="sql__id">Size</span>],&nbsp;[<span class="sql__id">SizeUnitMeasureCode</span>],&nbsp;[<span class="sql__id">WeightUnitMeasureCode</span>],&nbsp;[<span class="sql__id">Weight</span>],&nbsp;[<span class="sql__id">DaysToManufacture</span>],&nbsp;[<span class="sql__id">ProductLine</span>],&nbsp;[<span class="sql__id">Class</span>],&nbsp;[<span class="sql__id">Style</span>],&nbsp;[<span class="sql__id">ProductSubcategoryID</span>],&nbsp;[<span class="sql__id">ProductModelID</span>],&nbsp;[<span class="sql__id">SellStartDate</span>],&nbsp;[<span class="sql__id">SellEndDate</span>],&nbsp;[<span class="sql__id">DiscontinuedDate</span>],&nbsp;[<span class="sql__id">rowguid</span>],&nbsp;[<span class="sql__id">ModifiedDate</span>])&nbsp;<span class="sql__keyword">VALUES</span>&nbsp;(<span class="sql__number">316</span>,&nbsp;<span class="sql__id">N</span><span class="sql__string">'Blade'</span>,&nbsp;<span class="sql__id">N</span><span class="sql__string">'BL-2036'</span>,&nbsp;<span class="sql__number">1</span>,&nbsp;<span class="sql__number">0</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__number">800</span>,&nbsp;<span class="sql__number">600</span>,&nbsp;<span class="sql__number">0.0000</span>,&nbsp;<span class="sql__number">0.0000</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__number">1</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__function">CAST</span>(<span class="sql__hexnum">0x0000921E00000000</span>&nbsp;<span class="sql__keyword">AS</span>&nbsp;<span class="sql__keyword">DateTime</span>),&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__id">N</span><span class="sql__string">'e73e9750-603b-4131-89f5-3dd15ed5ff80'</span>,&nbsp;<span class="sql__function">CAST</span>(<span class="sql__hexnum">0x00009A5C00A53CF8</span>&nbsp;<span class="sql__keyword">AS</span>&nbsp;<span class="sql__keyword">DateTime</span>))&nbsp;
<span class="sql__keyword">INSERT</span>&nbsp;[<span class="sql__id">dbo</span>].[<span class="sql__id">Product</span>]&nbsp;([<span class="sql__id">ProductID</span>],&nbsp;[<span class="sql__keyword">Name</span>],&nbsp;[<span class="sql__id">ProductNumber</span>],&nbsp;[<span class="sql__id">MakeFlag</span>],&nbsp;[<span class="sql__id">FinishedGoodsFlag</span>],&nbsp;[<span class="sql__id">Color</span>],&nbsp;[<span class="sql__id">SafetyStockLevel</span>],&nbsp;[<span class="sql__id">ReorderPoint</span>],&nbsp;[<span class="sql__id">StandardCost</span>],&nbsp;[<span class="sql__id">ListPrice</span>],&nbsp;[<span class="sql__id">Size</span>],&nbsp;[<span class="sql__id">SizeUnitMeasureCode</span>],&nbsp;[<span class="sql__id">WeightUnitMeasureCode</span>],&nbsp;[<span class="sql__id">Weight</span>],&nbsp;[<span class="sql__id">DaysToManufacture</span>],&nbsp;[<span class="sql__id">ProductLine</span>],&nbsp;[<span class="sql__id">Class</span>],&nbsp;[<span class="sql__id">Style</span>],&nbsp;[<span class="sql__id">ProductSubcategoryID</span>],&nbsp;[<span class="sql__id">ProductModelID</span>],&nbsp;[<span class="sql__id">SellStartDate</span>],&nbsp;[<span class="sql__id">SellEndDate</span>],&nbsp;[<span class="sql__id">DiscontinuedDate</span>],&nbsp;[<span class="sql__id">rowguid</span>],&nbsp;[<span class="sql__id">ModifiedDate</span>])&nbsp;<span class="sql__keyword">VALUES</span>&nbsp;(<span class="sql__number">317</span>,&nbsp;<span class="sql__id">N</span><span class="sql__string">'LL&nbsp;Crankarm'</span>,&nbsp;<span class="sql__id">N</span><span class="sql__string">'CA-5965'</span>,&nbsp;<span class="sql__number">0</span>,&nbsp;<span class="sql__number">0</span>,&nbsp;<span class="sql__id">N</span><span class="sql__string">'Black'</span>,&nbsp;<span class="sql__number">500</span>,&nbsp;<span class="sql__number">375</span>,&nbsp;<span class="sql__number">0.0000</span>,&nbsp;<span class="sql__number">0.0000</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__number">0</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__id">N</span><span class="sql__string">'L&nbsp;'</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__function">CAST</span>(<span class="sql__hexnum">0x0000921E00000000</span>&nbsp;<span class="sql__keyword">AS</span>&nbsp;<span class="sql__keyword">DateTime</span>),&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__id">N</span><span class="sql__string">'3c9d10b7-a6b2-4774-9963-c19dcee72fea'</span>,&nbsp;<span class="sql__function">CAST</span>(<span class="sql__hexnum">0x00009A5C00A53CF8</span>&nbsp;<span class="sql__keyword">AS</span>&nbsp;<span class="sql__keyword">DateTime</span>))&nbsp;
<span class="sql__keyword">INSERT</span>&nbsp;[<span class="sql__id">dbo</span>].[<span class="sql__id">Product</span>]&nbsp;([<span class="sql__id">ProductID</span>],&nbsp;[<span class="sql__keyword">Name</span>],&nbsp;[<span class="sql__id">ProductNumber</span>],&nbsp;[<span class="sql__id">MakeFlag</span>],&nbsp;[<span class="sql__id">FinishedGoodsFlag</span>],&nbsp;[<span class="sql__id">Color</span>],&nbsp;[<span class="sql__id">SafetyStockLevel</span>],&nbsp;[<span class="sql__id">ReorderPoint</span>],&nbsp;[<span class="sql__id">StandardCost</span>],&nbsp;[<span class="sql__id">ListPrice</span>],&nbsp;[<span class="sql__id">Size</span>],&nbsp;[<span class="sql__id">SizeUnitMeasureCode</span>],&nbsp;[<span class="sql__id">WeightUnitMeasureCode</span>],&nbsp;[<span class="sql__id">Weight</span>],&nbsp;[<span class="sql__id">DaysToManufacture</span>],&nbsp;[<span class="sql__id">ProductLine</span>],&nbsp;[<span class="sql__id">Class</span>],&nbsp;[<span class="sql__id">Style</span>],&nbsp;[<span class="sql__id">ProductSubcategoryID</span>],&nbsp;[<span class="sql__id">ProductModelID</span>],&nbsp;[<span class="sql__id">SellStartDate</span>],&nbsp;[<span class="sql__id">SellEndDate</span>],&nbsp;[<span class="sql__id">DiscontinuedDate</span>],&nbsp;[<span class="sql__id">rowguid</span>],&nbsp;[<span class="sql__id">ModifiedDate</span>])&nbsp;<span class="sql__keyword">VALUES</span>&nbsp;(<span class="sql__number">318</span>,&nbsp;<span class="sql__id">N</span><span class="sql__string">'ML&nbsp;Crankarm'</span>,&nbsp;<span class="sql__id">N</span><span class="sql__string">'CA-6738'</span>,&nbsp;<span class="sql__number">0</span>,&nbsp;<span class="sql__number">0</span>,&nbsp;<span class="sql__id">N</span><span class="sql__string">'Black'</span>,&nbsp;<span class="sql__number">500</span>,&nbsp;<span class="sql__number">375</span>,&nbsp;<span class="sql__number">0.0000</span>,&nbsp;<span class="sql__number">0.0000</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__number">0</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__id">N</span><span class="sql__string">'M&nbsp;'</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__function">CAST</span>(<span class="sql__hexnum">0x0000921E00000000</span>&nbsp;<span class="sql__keyword">AS</span>&nbsp;<span class="sql__keyword">DateTime</span>),&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__value">NULL</span>,&nbsp;<span class="sql__id">N</span><span class="sql__string">'eabb9a92-fa07-4eab-8955-f0517b4a4ca7'</span>,&nbsp;<span class="sql__function">CAST</span>(<span class="sql__hexnum">0x00009A5C00A53CF8</span>&nbsp;<span class="sql__keyword">AS</span>&nbsp;<span class="sql__keyword">DateTime</span>))</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><span style="font-size:small">Our database is ready, now create a Web API application in visual studio and then entity with the above mentioned database.</span></p>
<div class="wp-caption x_alignnone" id="attachment_11556"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/05/Creating-Entity-e1463031313825.png"><img class="size-large x_wp-image-11556" src="-creating-entity-1024x542.png" alt="Creating Entity" width="634" height="336"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">Creating Entity</span></p>
</div>
<p><span style="font-size:small">If you don&rsquo;t know how to create an entity in your solution, please read that&nbsp;<a href="http://sibeeshpassion.com/web-api-with-angular-js/" target="_blank">here</a>. I have mentioned the steps to be followed in that
 article. Once you have created the entity, you are good to go and create a API controller with the entity created. If you do so, The CRUD actions will be created automatically for you. You may need to edit those actions according to your needs.</span></p>
<div class="wp-caption x_alignnone" id="attachment_11557"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/05/Web-API-2-Controller-with-actions-using-Entity-Framework-e1463031653319.png"><img class="size-full x_wp-image-11557" src="-web-api-2-controller-with-actions-using-entity-framework-e1463031653319.png" alt="Web API 2 Controller with actions, using Entity Framework" width="650" height="457"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">Web API 2 Controller with actions, using Entity Framework</span></p>
</div>
<p><span style="font-size:small">Select the Model Class, DBContext then name your controller and click OK. I hope a controller with the CRUD actions like preceding has been generated for you.</span></p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_309465">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">public&nbsp;class&nbsp;ProductsController&nbsp;:&nbsp;ApiController&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;TrialsDBEntities&nbsp;db&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;TrialsDBEntities();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;GET:&nbsp;api/Products</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;IQueryable&lt;Product&gt;&nbsp;GetProducts()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;db.Products;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;GET:&nbsp;api/Products/5</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[ResponseType(<span class="js__operator">typeof</span>(Product))]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;IHttpActionResult&nbsp;GetProduct(int&nbsp;id)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Product&nbsp;product&nbsp;=&nbsp;db.Products.Find(id);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(product&nbsp;==&nbsp;null)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;NotFound();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;Ok(product);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;PUT:&nbsp;api/Products/5</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[ResponseType(<span class="js__operator">typeof</span>(<span class="js__operator">void</span>))]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;IHttpActionResult&nbsp;PutProduct(int&nbsp;id,&nbsp;Product&nbsp;product)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(!ModelState.IsValid)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;BadRequest(ModelState);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(id&nbsp;!=&nbsp;product.ProductID)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;BadRequest();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;db.Entry(product).State&nbsp;=&nbsp;EntityState.Modified;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;db.SaveChanges();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">catch</span>&nbsp;(DbUpdateConcurrencyException)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(!ProductExists(id))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;NotFound();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">throw</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;StatusCode(HttpStatusCode.NoContent);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;POST:&nbsp;api/Products</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[ResponseType(<span class="js__operator">typeof</span>(Product))]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;IHttpActionResult&nbsp;PostProduct(Product&nbsp;product)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(!ModelState.IsValid)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;BadRequest(ModelState);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;db.Products.Add(product);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;db.SaveChanges();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">catch</span>&nbsp;(DbUpdateException)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(ProductExists(product.ProductID))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;Conflict();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">throw</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;CreatedAtRoute(<span class="js__string">&quot;DefaultApi&quot;</span>,&nbsp;<span class="js__operator">new</span>&nbsp;<span class="js__brace">{</span>&nbsp;id&nbsp;=&nbsp;product.ProductID&nbsp;<span class="js__brace">}</span>,&nbsp;product);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;DELETE:&nbsp;api/Products/5</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[ResponseType(<span class="js__operator">typeof</span>(Product))]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;IHttpActionResult&nbsp;DeleteProduct(int&nbsp;id)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Product&nbsp;product&nbsp;=&nbsp;db.Products.Find(id);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(product&nbsp;==&nbsp;null)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;NotFound();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;db.Products.Remove(product);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;db.SaveChanges();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;Ok(product);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;protected&nbsp;override&nbsp;<span class="js__operator">void</span>&nbsp;Dispose(bool&nbsp;disposing)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(disposing)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;db.Dispose();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;base.Dispose(disposing);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;bool&nbsp;ProductExists(int&nbsp;id)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;db.Products.Count(e&nbsp;=&gt;&nbsp;e.ProductID&nbsp;==&nbsp;id)&nbsp;&gt;&nbsp;<span class="js__num">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
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
<p><span style="font-size:small">Now please run your application and go to the help page. You can see the API help page as follows.</span></p>
<div class="wp-caption x_alignnone" id="attachment_11558"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/05/API-Help-Page-e1463032044742.png"><img class="size-full x_wp-image-11558" src="-api-help-page-e1463032044742.png" alt="API Help Page" width="650" height="524"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">API Help Page</span></p>
</div>
<p><span style="font-size:small">As you can see &lsquo;No documentation available.&rsquo; under description of all the service actions. No worries we will try to add some summary to the actions now. So we will change the code as follows.</span></p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_910995">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">#region&nbsp;GetProducts&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;Get&nbsp;all&nbsp;the&nbsp;products&nbsp;available</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;GET:&nbsp;api/Products</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;IQueryable&lt;Product&gt;&nbsp;GetProducts()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;db.Products;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#endregion&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#region&nbsp;GetProductWithParameter&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;Get&nbsp;a&nbsp;single&nbsp;product</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;GET:&nbsp;api/Products/5</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;param&nbsp;name=&quot;id&quot;&gt;&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[ResponseType(<span class="js__operator">typeof</span>(Product))]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;IHttpActionResult&nbsp;GetProduct(int&nbsp;id)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Product&nbsp;product&nbsp;=&nbsp;db.Products.Find(id);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(product&nbsp;==&nbsp;null)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;NotFound();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;Ok(product);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#endregion</pre>
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
<p><span style="font-size:small">Now run your application and see the help page. Still the same result? Hmm, here comes the things we need to do. I will explain that.</span></p>
<li><span style="font-size:small">Go to Areas\HelpPage\App_Start and click on the file&nbsp;<em>HelpPageConfig.cs</em>.</span>
</li><li><span style="font-size:small">Uncomment the following line from the static function Register.</span><span style="font-size:small">&nbsp;
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">config.SetDocumentationProvider(<span class="js__operator">new</span>&nbsp;XmlDocumentationProvider(HttpContext.Current.Server.MapPath(<span class="js__string">&quot;App_Data/XmlDocument.xml&quot;</span>)));</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</span>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_158603"><br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
</li><li><span style="font-size:small">Right click on your project and go to properties, then click on Build</span>
</li><li><span style="font-size:small">Go to Output section and click on XML documentation file and then type<em>~/App_Data/XmlDocument.xml</em>&nbsp;in the given text box.</span>
</li><li><span style="font-size:small">Save and build your project.</span>
<p><span style="font-size:small">This will create a XML document with the name&nbsp;<em>XmlDocument.xml</em>&nbsp;in App_Data folder. Once it is generated, the summary you have described in your API controller will be listed there. Initially the file will be
 in excluded state, you may need to include the same to your project when you deploy your API application. For that please follows the below steps.</span></p>
</li><li><span style="font-size:small">Click on show all files.</span> </li><li><span style="font-size:small">Click on Refresh.</span> </li><li><span style="font-size:small">Go to App_Data folder and find XmlDocument.xml.</span>
</li><li><span style="font-size:small">Right click the file and click Include In Project.</span>
<p><span style="font-size:small">That&rsquo;s all. Run your application and see the Help page again. Hope you get the page as follows.</span></p>
<div class="wp-caption x_alignnone" id="attachment_11559"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/05/API-Help-Page-With-Descriptions-e1463033550891.png"><img class="size-full x_wp-image-11559" src="-api-help-page-with-descriptions-e1463033550891.png" alt="API Help Page With Descriptions" width="650" height="361"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">API Help Page With Descriptions</span></p>
</div>
<p><span style="font-size:small">Have a happy coding!.</span></p>
</li>