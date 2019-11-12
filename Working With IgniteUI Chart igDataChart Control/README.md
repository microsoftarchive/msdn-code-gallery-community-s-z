# Working With IgniteUI Chart igDataChart Control
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- SQL Server
- MVC
- Chart Control
- Ignite UI
## Topics
- Performance
- Visual Studio
- Chart Controls
- MVC
- Ignite UI
- Data Chart
## Updated
- 07/14/2016
## Description

<p><span style="font-size:small">In this post we will see how we can use an&nbsp;<a href="http://sibeeshpassion.com/category/products/" target="_blank">IgniteUI</a>&nbsp;chart control in our&nbsp;<a href="http://sibeeshpassion.com/category/mvc" target="_blank">MVC</a>&nbsp;application.
 If you are new IgniteUI controls I strongly recommend you to read my previous post related to IgniteUI grid here<a href="http://sibeeshpassion.com/working-with-igniteui-grid-control/" target="_blank">Working With IgniteUI Grid Control</a>. Here we are going
 to use the chart control available in the kit. We will create an MVC application in&nbsp;<a href="http://sibeeshpassion.com/category/visual-studio/" target="_blank">Visual Studio</a>. I hope you will like this.<br>
</span></p>
<p><span style="font-size:small">Background</span></p>
<p><span style="font-size:small">I have you have already gone though my previous article about IgniteUI grid control. You can consider that as an introduction to the control kit. Now as I mentioned, we will try to create a chart using the chart control. Is
 that fine?</span></p>
<p><span style="font-size:small">Prerequisites</span></p>
<p><span style="font-size:small">As I said in the introduction part, we are going to create an IgniteUI grid in MVC application, so you must have a visual studio installed in your machine.</span></p>
<li><span style="font-size:small">Visual Studio</span> </li><li><span style="font-size:small">SQL</span> </li><li><span style="font-size:small">IgniteUI control</span>
<p><span style="font-size:small">Table of Contents</span></p>
</li><li><span style="font-size:small">Download and install IgniteUI</span> </li><li><span style="font-size:small">Set up database</span> </li><li><span style="font-size:small">Creating models and entity</span> </li><li><span style="font-size:small">Configure MVC application</span> </li><li><span style="font-size:small">Creating IgniteUI Chart</span>
<p><span style="font-size:small">Download and install IgniteUI</span></p>
<p><span style="font-size:small">Please see my&nbsp;<a href="http://sibeeshpassion.com/working-with-igniteui-grid-control/" target="_blank">previous post</a>&nbsp;to see the steps to install the Ignite UI in your machine.</span></p>
<p><span style="font-size:small">Set up database</span></p>
<div>
<div class="syntaxhighlighter sql" id="highlighter_741772">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="mysql"><span class="sql__keyword">USE</span>&nbsp;[<span class="sql__keyword">master</span>]&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;&nbsp;
<span class="sql__mlcom">/******&nbsp;Object:&nbsp;&nbsp;Database&nbsp;[TrialsDB]&nbsp;&nbsp;&nbsp;&nbsp;Script&nbsp;Date:&nbsp;07/14/2016&nbsp;10:56:41&nbsp;AM&nbsp;******/</span>&nbsp;
<span class="sql__keyword">CREATE</span>&nbsp;<span class="sql__keyword">DATABASE</span>&nbsp;[<span class="sql__id">TrialsDB</span>]&nbsp;
&nbsp;<span class="sql__id">CONTAINMENT</span>&nbsp;=&nbsp;<span class="sql__keyword">NONE</span>&nbsp;
&nbsp;<span class="sql__keyword">ON</span>&nbsp;&nbsp;<span class="sql__keyword">PRIMARY</span>&nbsp;
(&nbsp;<span class="sql__keyword">NAME</span>&nbsp;=&nbsp;<span class="sql__id">N</span><span class="sql__string">'TrialsDB',&nbsp;FILENAME&nbsp;=&nbsp;N'C:\Program&nbsp;Files\Microsoft&nbsp;SQL&nbsp;Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\TrialsDB.mdf'</span>&nbsp;,&nbsp;<span class="sql__id">SIZE</span>&nbsp;=&nbsp;<span class="sql__id">3072KB</span>&nbsp;,&nbsp;<span class="sql__id">MAXSIZE</span>&nbsp;=&nbsp;<span class="sql__id">UNLIMITED</span>,&nbsp;<span class="sql__id">FILEGROWTH</span>&nbsp;=&nbsp;<span class="sql__id">1024KB</span>&nbsp;)&nbsp;
&nbsp;<span class="sql__id">LOG</span>&nbsp;<span class="sql__keyword">ON</span>&nbsp;
(&nbsp;<span class="sql__keyword">NAME</span>&nbsp;=&nbsp;<span class="sql__id">N</span><span class="sql__string">'TrialsDB_log',&nbsp;FILENAME&nbsp;=&nbsp;N'C:\Program&nbsp;Files\Microsoft&nbsp;SQL&nbsp;Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\TrialsDB_log.ldf'</span>&nbsp;,&nbsp;<span class="sql__id">SIZE</span>&nbsp;=&nbsp;<span class="sql__id">1024KB</span>&nbsp;,&nbsp;<span class="sql__id">MAXSIZE</span>&nbsp;=&nbsp;<span class="sql__id">2048GB</span>&nbsp;,&nbsp;<span class="sql__id">FILEGROWTH</span>&nbsp;=&nbsp;<span class="sql__number">10</span>%)&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;&nbsp;
<span class="sql__keyword">ALTER</span>&nbsp;<span class="sql__keyword">DATABASE</span>&nbsp;[<span class="sql__id">TrialsDB</span>]&nbsp;<span class="sql__keyword">SET</span>&nbsp;<span class="sql__id">COMPATIBILITY_LEVEL</span>&nbsp;=&nbsp;<span class="sql__number">110</span>&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;&nbsp;
<span class="sql__keyword">IF</span>&nbsp;(<span class="sql__number">1</span>&nbsp;=&nbsp;<span class="sql__id">FULLTEXTSERVICEPROPERTY</span>(<span class="sql__string">'IsFullTextInstalled'</span>))&nbsp;
<span class="sql__keyword">begin</span>&nbsp;
<span class="sql__id">EXEC</span>&nbsp;[<span class="sql__id">TrialsDB</span>].[<span class="sql__id">dbo</span>].[<span class="sql__id">sp_fulltext_database</span>]&nbsp;<span class="sql__keyword">@</span><span class="sql__variable">action</span>&nbsp;=&nbsp;<span class="sql__string">'enable'</span>&nbsp;
<span class="sql__keyword">end</span>&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;&nbsp;
<span class="sql__keyword">ALTER</span>&nbsp;<span class="sql__keyword">DATABASE</span>&nbsp;[<span class="sql__id">TrialsDB</span>]&nbsp;<span class="sql__keyword">SET</span>&nbsp;<span class="sql__id">ANSI_NULL_DEFAULT</span>&nbsp;<span class="sql__id">OFF</span>&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;&nbsp;
<span class="sql__keyword">ALTER</span>&nbsp;<span class="sql__keyword">DATABASE</span>&nbsp;[<span class="sql__id">TrialsDB</span>]&nbsp;<span class="sql__keyword">SET</span>&nbsp;<span class="sql__id">ANSI_NULLS</span>&nbsp;<span class="sql__id">OFF</span>&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;&nbsp;
<span class="sql__keyword">ALTER</span>&nbsp;<span class="sql__keyword">DATABASE</span>&nbsp;[<span class="sql__id">TrialsDB</span>]&nbsp;<span class="sql__keyword">SET</span>&nbsp;<span class="sql__id">ANSI_PADDING</span>&nbsp;<span class="sql__id">OFF</span>&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;&nbsp;
<span class="sql__keyword">ALTER</span>&nbsp;<span class="sql__keyword">DATABASE</span>&nbsp;[<span class="sql__id">TrialsDB</span>]&nbsp;<span class="sql__keyword">SET</span>&nbsp;<span class="sql__id">ANSI_WARNINGS</span>&nbsp;<span class="sql__id">OFF</span>&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;&nbsp;
<span class="sql__keyword">ALTER</span>&nbsp;<span class="sql__keyword">DATABASE</span>&nbsp;[<span class="sql__id">TrialsDB</span>]&nbsp;<span class="sql__keyword">SET</span>&nbsp;<span class="sql__id">ARITHABORT</span>&nbsp;<span class="sql__id">OFF</span>&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;&nbsp;
<span class="sql__keyword">ALTER</span>&nbsp;<span class="sql__keyword">DATABASE</span>&nbsp;[<span class="sql__id">TrialsDB</span>]&nbsp;<span class="sql__keyword">SET</span>&nbsp;<span class="sql__id">AUTO_CLOSE</span>&nbsp;<span class="sql__id">OFF</span>&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;&nbsp;
<span class="sql__keyword">ALTER</span>&nbsp;<span class="sql__keyword">DATABASE</span>&nbsp;[<span class="sql__id">TrialsDB</span>]&nbsp;<span class="sql__keyword">SET</span>&nbsp;<span class="sql__id">AUTO_CREATE_STATISTICS</span>&nbsp;<span class="sql__keyword">ON</span>&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;&nbsp;
<span class="sql__keyword">ALTER</span>&nbsp;<span class="sql__keyword">DATABASE</span>&nbsp;[<span class="sql__id">TrialsDB</span>]&nbsp;<span class="sql__keyword">SET</span>&nbsp;<span class="sql__id">AUTO_SHRINK</span>&nbsp;<span class="sql__id">OFF</span>&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;&nbsp;
<span class="sql__keyword">ALTER</span>&nbsp;<span class="sql__keyword">DATABASE</span>&nbsp;[<span class="sql__id">TrialsDB</span>]&nbsp;<span class="sql__keyword">SET</span>&nbsp;<span class="sql__id">AUTO_UPDATE_STATISTICS</span>&nbsp;<span class="sql__keyword">ON</span>&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;&nbsp;
<span class="sql__keyword">ALTER</span>&nbsp;<span class="sql__keyword">DATABASE</span>&nbsp;[<span class="sql__id">TrialsDB</span>]&nbsp;<span class="sql__keyword">SET</span>&nbsp;<span class="sql__id">CURSOR_CLOSE_ON_COMMIT</span>&nbsp;<span class="sql__id">OFF</span>&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;&nbsp;
<span class="sql__keyword">ALTER</span>&nbsp;<span class="sql__keyword">DATABASE</span>&nbsp;[<span class="sql__id">TrialsDB</span>]&nbsp;<span class="sql__keyword">SET</span>&nbsp;<span class="sql__id">CURSOR_DEFAULT</span>&nbsp;&nbsp;<span class="sql__keyword">GLOBAL</span>&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;&nbsp;
<span class="sql__keyword">ALTER</span>&nbsp;<span class="sql__keyword">DATABASE</span>&nbsp;[<span class="sql__id">TrialsDB</span>]&nbsp;<span class="sql__keyword">SET</span>&nbsp;<span class="sql__id">CONCAT_NULL_YIELDS_NULL</span>&nbsp;<span class="sql__id">OFF</span>&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;&nbsp;
<span class="sql__keyword">ALTER</span>&nbsp;<span class="sql__keyword">DATABASE</span>&nbsp;[<span class="sql__id">TrialsDB</span>]&nbsp;<span class="sql__keyword">SET</span>&nbsp;<span class="sql__id">NUMERIC_ROUNDABORT</span>&nbsp;<span class="sql__id">OFF</span>&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;&nbsp;
<span class="sql__keyword">ALTER</span>&nbsp;<span class="sql__keyword">DATABASE</span>&nbsp;[<span class="sql__id">TrialsDB</span>]&nbsp;<span class="sql__keyword">SET</span>&nbsp;<span class="sql__id">QUOTED_IDENTIFIER</span>&nbsp;<span class="sql__id">OFF</span>&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;&nbsp;
<span class="sql__keyword">ALTER</span>&nbsp;<span class="sql__keyword">DATABASE</span>&nbsp;[<span class="sql__id">TrialsDB</span>]&nbsp;<span class="sql__keyword">SET</span>&nbsp;<span class="sql__id">RECURSIVE_TRIGGERS</span>&nbsp;<span class="sql__id">OFF</span>&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;&nbsp;
<span class="sql__keyword">ALTER</span>&nbsp;<span class="sql__keyword">DATABASE</span>&nbsp;[<span class="sql__id">TrialsDB</span>]&nbsp;<span class="sql__keyword">SET</span>&nbsp;&nbsp;<span class="sql__id">DISABLE_BROKER</span>&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;&nbsp;
<span class="sql__keyword">ALTER</span>&nbsp;<span class="sql__keyword">DATABASE</span>&nbsp;[<span class="sql__id">TrialsDB</span>]&nbsp;<span class="sql__keyword">SET</span>&nbsp;<span class="sql__id">AUTO_UPDATE_STATISTICS_ASYNC</span>&nbsp;<span class="sql__id">OFF</span>&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;&nbsp;
<span class="sql__keyword">ALTER</span>&nbsp;<span class="sql__keyword">DATABASE</span>&nbsp;[<span class="sql__id">TrialsDB</span>]&nbsp;<span class="sql__keyword">SET</span>&nbsp;<span class="sql__id">DATE_CORRELATION_OPTIMIZATION</span>&nbsp;<span class="sql__id">OFF</span>&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;&nbsp;
<span class="sql__keyword">ALTER</span>&nbsp;<span class="sql__keyword">DATABASE</span>&nbsp;[<span class="sql__id">TrialsDB</span>]&nbsp;<span class="sql__keyword">SET</span>&nbsp;<span class="sql__id">TRUSTWORTHY</span>&nbsp;<span class="sql__id">OFF</span>&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;&nbsp;
<span class="sql__keyword">ALTER</span>&nbsp;<span class="sql__keyword">DATABASE</span>&nbsp;[<span class="sql__id">TrialsDB</span>]&nbsp;<span class="sql__keyword">SET</span>&nbsp;<span class="sql__id">ALLOW_SNAPSHOT_ISOLATION</span>&nbsp;<span class="sql__id">OFF</span>&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;&nbsp;
<span class="sql__keyword">ALTER</span>&nbsp;<span class="sql__keyword">DATABASE</span>&nbsp;[<span class="sql__id">TrialsDB</span>]&nbsp;<span class="sql__keyword">SET</span>&nbsp;<span class="sql__id">PARAMETERIZATION</span>&nbsp;<span class="sql__keyword">SIMPLE</span>&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;&nbsp;
<span class="sql__keyword">ALTER</span>&nbsp;<span class="sql__keyword">DATABASE</span>&nbsp;[<span class="sql__id">TrialsDB</span>]&nbsp;<span class="sql__keyword">SET</span>&nbsp;<span class="sql__id">READ_COMMITTED_SNAPSHOT</span>&nbsp;<span class="sql__id">OFF</span>&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;&nbsp;
<span class="sql__keyword">ALTER</span>&nbsp;<span class="sql__keyword">DATABASE</span>&nbsp;[<span class="sql__id">TrialsDB</span>]&nbsp;<span class="sql__keyword">SET</span>&nbsp;<span class="sql__id">HONOR_BROKER_PRIORITY</span>&nbsp;<span class="sql__id">OFF</span>&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;&nbsp;
<span class="sql__keyword">ALTER</span>&nbsp;<span class="sql__keyword">DATABASE</span>&nbsp;[<span class="sql__id">TrialsDB</span>]&nbsp;<span class="sql__keyword">SET</span>&nbsp;<span class="sql__id">RECOVERY</span>&nbsp;<span class="sql__keyword">FULL</span>&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;&nbsp;
<span class="sql__keyword">ALTER</span>&nbsp;<span class="sql__keyword">DATABASE</span>&nbsp;[<span class="sql__id">TrialsDB</span>]&nbsp;<span class="sql__keyword">SET</span>&nbsp;&nbsp;<span class="sql__id">MULTI_USER</span>&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;&nbsp;
<span class="sql__keyword">ALTER</span>&nbsp;<span class="sql__keyword">DATABASE</span>&nbsp;[<span class="sql__id">TrialsDB</span>]&nbsp;<span class="sql__keyword">SET</span>&nbsp;<span class="sql__id">PAGE_VERIFY</span>&nbsp;<span class="sql__keyword">CHECKSUM</span>&nbsp;&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;&nbsp;
<span class="sql__keyword">ALTER</span>&nbsp;<span class="sql__keyword">DATABASE</span>&nbsp;[<span class="sql__id">TrialsDB</span>]&nbsp;<span class="sql__keyword">SET</span>&nbsp;<span class="sql__id">DB_CHAINING</span>&nbsp;<span class="sql__id">OFF</span>&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;&nbsp;
<span class="sql__keyword">ALTER</span>&nbsp;<span class="sql__keyword">DATABASE</span>&nbsp;[<span class="sql__id">TrialsDB</span>]&nbsp;<span class="sql__keyword">SET</span>&nbsp;<span class="sql__id">FILESTREAM</span>(&nbsp;<span class="sql__id">NON_TRANSACTED_ACCESS</span>&nbsp;=&nbsp;<span class="sql__id">OFF</span>&nbsp;)&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;&nbsp;
<span class="sql__keyword">ALTER</span>&nbsp;<span class="sql__keyword">DATABASE</span>&nbsp;[<span class="sql__id">TrialsDB</span>]&nbsp;<span class="sql__keyword">SET</span>&nbsp;<span class="sql__id">TARGET_RECOVERY_TIME</span>&nbsp;=&nbsp;<span class="sql__number">0</span>&nbsp;<span class="sql__id">SECONDS</span>&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;&nbsp;
<span class="sql__keyword">ALTER</span>&nbsp;<span class="sql__keyword">DATABASE</span>&nbsp;[<span class="sql__id">TrialsDB</span>]&nbsp;<span class="sql__keyword">SET</span>&nbsp;&nbsp;<span class="sql__id">READ_WRITE</span>&nbsp;
<span class="sql__id">GO</span></pre>
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
<p><span style="font-size:small">Create table with data</span></p>
<div>
<div class="syntaxhighlighter sql" id="highlighter_382667">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="js">USE&nbsp;[TrialsDB]&nbsp;
GO&nbsp;
/******&nbsp;Object:&nbsp;&nbsp;Table&nbsp;[dbo].[Product]&nbsp;&nbsp;&nbsp;&nbsp;Script&nbsp;Date:&nbsp;<span class="js__num">5</span>/<span class="js__num">12</span><span class="js__reg_exp">/2016&nbsp;10:54:48&nbsp;AM&nbsp;******/</span>&nbsp;
SET&nbsp;ANSI_NULLS&nbsp;ON&nbsp;
GO&nbsp;
SET&nbsp;QUOTED_IDENTIFIER&nbsp;ON&nbsp;
GO&nbsp;
CREATE&nbsp;TABLE&nbsp;[dbo].[Product](&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[ProductID]&nbsp;[int]&nbsp;NOT&nbsp;NULL,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[Name]&nbsp;[nvarchar](max)&nbsp;NOT&nbsp;NULL,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[ProductNumber]&nbsp;[nvarchar](<span class="js__num">25</span>)&nbsp;NOT&nbsp;NULL,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[MakeFlag]&nbsp;[bit]&nbsp;NOT&nbsp;NULL,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[FinishedGoodsFlag]&nbsp;[bit]&nbsp;NOT&nbsp;NULL,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[Color]&nbsp;[nvarchar](<span class="js__num">15</span>)&nbsp;NULL,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[SafetyStockLevel]&nbsp;[smallint]&nbsp;NOT&nbsp;NULL,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[ReorderPoint]&nbsp;[smallint]&nbsp;NOT&nbsp;NULL,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[StandardCost]&nbsp;[money]&nbsp;NOT&nbsp;NULL,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[ListPrice]&nbsp;[money]&nbsp;NOT&nbsp;NULL,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[Size]&nbsp;[nvarchar](<span class="js__num">5</span>)&nbsp;NULL,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[SizeUnitMeasureCode]&nbsp;[nchar](<span class="js__num">3</span>)&nbsp;NULL,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[WeightUnitMeasureCode]&nbsp;[nchar](<span class="js__num">3</span>)&nbsp;NULL,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[Weight]&nbsp;[decimal](<span class="js__num">8</span>,&nbsp;<span class="js__num">2</span>)&nbsp;NULL,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[DaysToManufacture]&nbsp;[int]&nbsp;NOT&nbsp;NULL,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[ProductLine]&nbsp;[nchar](<span class="js__num">2</span>)&nbsp;NULL,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[Class]&nbsp;[nchar](<span class="js__num">2</span>)&nbsp;NULL,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[Style]&nbsp;[nchar](<span class="js__num">2</span>)&nbsp;NULL,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[ProductSubcategoryID]&nbsp;[int]&nbsp;NULL,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[ProductModelID]&nbsp;[int]&nbsp;NULL,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[SellStartDate]&nbsp;[datetime]&nbsp;NOT&nbsp;NULL,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[SellEndDate]&nbsp;[datetime]&nbsp;NULL,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[DiscontinuedDate]&nbsp;[datetime]&nbsp;NULL,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[rowguid]&nbsp;[uniqueidentifier]&nbsp;ROWGUIDCOL&nbsp;&nbsp;NOT&nbsp;NULL,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[ModifiedDate]&nbsp;[datetime]&nbsp;NOT&nbsp;NULL&nbsp;
)&nbsp;ON&nbsp;[PRIMARY]&nbsp;TEXTIMAGE_ON&nbsp;[PRIMARY]&nbsp;
GO&nbsp;
INSERT&nbsp;[dbo].[Product]&nbsp;([ProductID],&nbsp;[Name],&nbsp;[ProductNumber],&nbsp;[MakeFlag],&nbsp;[FinishedGoodsFlag],&nbsp;[Color],&nbsp;[SafetyStockLevel],&nbsp;[ReorderPoint],&nbsp;[StandardCost],&nbsp;[ListPrice],&nbsp;[Size],&nbsp;[SizeUnitMeasureCode],&nbsp;[WeightUnitMeasureCode],&nbsp;[Weight],&nbsp;[DaysToManufacture],&nbsp;[ProductLine],&nbsp;[Class],&nbsp;[Style],&nbsp;[ProductSubcategoryID],&nbsp;[ProductModelID],&nbsp;[SellStartDate],&nbsp;[SellEndDate],&nbsp;[DiscontinuedDate],&nbsp;[rowguid],&nbsp;[ModifiedDate])&nbsp;VALUES&nbsp;(<span class="js__num">1</span>,&nbsp;N<span class="js__string">'Adjustable&nbsp;Race'</span>,&nbsp;N<span class="js__string">'AR-5381'</span>,&nbsp;<span class="js__num">0</span>,&nbsp;<span class="js__num">0</span>,&nbsp;NULL,&nbsp;<span class="js__num">1000</span>,&nbsp;<span class="js__num">750</span>,&nbsp;<span class="js__num">0.0000</span>,&nbsp;<span class="js__num">0.0000</span>,&nbsp;NULL,&nbsp;NULL,&nbsp;NULL,&nbsp;NULL,&nbsp;<span class="js__num">0</span>,&nbsp;NULL,&nbsp;NULL,&nbsp;NULL,&nbsp;NULL,&nbsp;NULL,&nbsp;CAST(0x0000921E00000000&nbsp;AS&nbsp;DateTime),&nbsp;NULL,&nbsp;NULL,&nbsp;N<span class="js__string">'694215b7-08f7-4c0d-acb1-d734ba44c0c8'</span>,&nbsp;CAST(0x00009A5C00A53CF8&nbsp;AS&nbsp;DateTime))&nbsp;
INSERT&nbsp;[dbo].[Product]&nbsp;([ProductID],&nbsp;[Name],&nbsp;[ProductNumber],&nbsp;[MakeFlag],&nbsp;[FinishedGoodsFlag],&nbsp;[Color],&nbsp;[SafetyStockLevel],&nbsp;[ReorderPoint],&nbsp;[StandardCost],&nbsp;[ListPrice],&nbsp;[Size],&nbsp;[SizeUnitMeasureCode],&nbsp;[WeightUnitMeasureCode],&nbsp;[Weight],&nbsp;[DaysToManufacture],&nbsp;[ProductLine],&nbsp;[Class],&nbsp;[Style],&nbsp;[ProductSubcategoryID],&nbsp;[ProductModelID],&nbsp;[SellStartDate],&nbsp;[SellEndDate],&nbsp;[DiscontinuedDate],&nbsp;[rowguid],&nbsp;[ModifiedDate])&nbsp;VALUES&nbsp;(<span class="js__num">2</span>,&nbsp;N<span class="js__string">'Bearing&nbsp;Ball'</span>,&nbsp;N<span class="js__string">'BA-8327'</span>,&nbsp;<span class="js__num">0</span>,&nbsp;<span class="js__num">0</span>,&nbsp;NULL,&nbsp;<span class="js__num">1000</span>,&nbsp;<span class="js__num">750</span>,&nbsp;<span class="js__num">0.0000</span>,&nbsp;<span class="js__num">0.0000</span>,&nbsp;NULL,&nbsp;NULL,&nbsp;NULL,&nbsp;NULL,&nbsp;<span class="js__num">0</span>,&nbsp;NULL,&nbsp;NULL,&nbsp;NULL,&nbsp;NULL,&nbsp;NULL,&nbsp;CAST(0x0000921E00000000&nbsp;AS&nbsp;DateTime),&nbsp;NULL,&nbsp;NULL,&nbsp;N<span class="js__string">'58ae3c20-4f3a-4749-a7d4-d568806cc537'</span>,&nbsp;CAST(0x00009A5C00A53CF8&nbsp;AS&nbsp;DateTime))&nbsp;
INSERT&nbsp;[dbo].[Product]&nbsp;([ProductID],&nbsp;[Name],&nbsp;[ProductNumber],&nbsp;[MakeFlag],&nbsp;[FinishedGoodsFlag],&nbsp;[Color],&nbsp;[SafetyStockLevel],&nbsp;[ReorderPoint],&nbsp;[StandardCost],&nbsp;[ListPrice],&nbsp;[Size],&nbsp;[SizeUnitMeasureCode],&nbsp;[WeightUnitMeasureCode],&nbsp;[Weight],&nbsp;[DaysToManufacture],&nbsp;[ProductLine],&nbsp;[Class],&nbsp;[Style],&nbsp;[ProductSubcategoryID],&nbsp;[ProductModelID],&nbsp;[SellStartDate],&nbsp;[SellEndDate],&nbsp;[DiscontinuedDate],&nbsp;[rowguid],&nbsp;[ModifiedDate])&nbsp;VALUES&nbsp;(<span class="js__num">3</span>,&nbsp;N<span class="js__string">'BB&nbsp;Ball&nbsp;Bearing'</span>,&nbsp;N<span class="js__string">'BE-2349'</span>,&nbsp;<span class="js__num">1</span>,&nbsp;<span class="js__num">0</span>,&nbsp;NULL,&nbsp;<span class="js__num">800</span>,&nbsp;<span class="js__num">600</span>,&nbsp;<span class="js__num">0.0000</span>,&nbsp;<span class="js__num">0.0000</span>,&nbsp;NULL,&nbsp;NULL,&nbsp;NULL,&nbsp;NULL,&nbsp;<span class="js__num">1</span>,&nbsp;NULL,&nbsp;NULL,&nbsp;NULL,&nbsp;NULL,&nbsp;NULL,&nbsp;CAST(0x0000921E00000000&nbsp;AS&nbsp;DateTime),&nbsp;NULL,&nbsp;NULL,&nbsp;N<span class="js__string">'9c21aed2-5bfa-4f18-bcb8-f11638dc2e4e'</span>,&nbsp;CAST(0x00009A5C00A53CF8&nbsp;AS&nbsp;DateTime))&nbsp;
INSERT&nbsp;[dbo].[Product]&nbsp;([ProductID],&nbsp;[Name],&nbsp;[ProductNumber],&nbsp;[MakeFlag],&nbsp;[FinishedGoodsFlag],&nbsp;[Color],&nbsp;[SafetyStockLevel],&nbsp;[ReorderPoint],&nbsp;[StandardCost],&nbsp;[ListPrice],&nbsp;[Size],&nbsp;[SizeUnitMeasureCode],&nbsp;[WeightUnitMeasureCode],&nbsp;[Weight],&nbsp;[DaysToManufacture],&nbsp;[ProductLine],&nbsp;[Class],&nbsp;[Style],&nbsp;[ProductSubcategoryID],&nbsp;[ProductModelID],&nbsp;[SellStartDate],&nbsp;[SellEndDate],&nbsp;[DiscontinuedDate],&nbsp;[rowguid],&nbsp;[ModifiedDate])&nbsp;VALUES&nbsp;(<span class="js__num">4</span>,&nbsp;N<span class="js__string">'Headset&nbsp;Ball&nbsp;Bearings'</span>,&nbsp;N<span class="js__string">'BE-2908'</span>,&nbsp;<span class="js__num">0</span>,&nbsp;<span class="js__num">0</span>,&nbsp;NULL,&nbsp;<span class="js__num">800</span>,&nbsp;<span class="js__num">600</span>,&nbsp;<span class="js__num">0.0000</span>,&nbsp;<span class="js__num">0.0000</span>,&nbsp;NULL,&nbsp;NULL,&nbsp;NULL,&nbsp;NULL,&nbsp;<span class="js__num">0</span>,&nbsp;NULL,&nbsp;NULL,&nbsp;NULL,&nbsp;NULL,&nbsp;NULL,&nbsp;CAST(0x0000921E00000000&nbsp;AS&nbsp;DateTime),&nbsp;NULL,&nbsp;NULL,&nbsp;N<span class="js__string">'ecfed6cb-51ff-49b5-b06c-7d8ac834db8b'</span>,&nbsp;CAST(0x00009A5C00A53CF8&nbsp;AS&nbsp;DateTime))&nbsp;
INSERT&nbsp;[dbo].[Product]&nbsp;([ProductID],&nbsp;[Name],&nbsp;[ProductNumber],&nbsp;[MakeFlag],&nbsp;[FinishedGoodsFlag],&nbsp;[Color],&nbsp;[SafetyStockLevel],&nbsp;[ReorderPoint],&nbsp;[StandardCost],&nbsp;[ListPrice],&nbsp;[Size],&nbsp;[SizeUnitMeasureCode],&nbsp;[WeightUnitMeasureCode],&nbsp;[Weight],&nbsp;[DaysToManufacture],&nbsp;[ProductLine],&nbsp;[Class],&nbsp;[Style],&nbsp;[ProductSubcategoryID],&nbsp;[ProductModelID],&nbsp;[SellStartDate],&nbsp;[SellEndDate],&nbsp;[DiscontinuedDate],&nbsp;[rowguid],&nbsp;[ModifiedDate])&nbsp;VALUES&nbsp;(<span class="js__num">316</span>,&nbsp;N<span class="js__string">'Blade'</span>,&nbsp;N<span class="js__string">'BL-2036'</span>,&nbsp;<span class="js__num">1</span>,&nbsp;<span class="js__num">0</span>,&nbsp;NULL,&nbsp;<span class="js__num">800</span>,&nbsp;<span class="js__num">600</span>,&nbsp;<span class="js__num">0.0000</span>,&nbsp;<span class="js__num">0.0000</span>,&nbsp;NULL,&nbsp;NULL,&nbsp;NULL,&nbsp;NULL,&nbsp;<span class="js__num">1</span>,&nbsp;NULL,&nbsp;NULL,&nbsp;NULL,&nbsp;NULL,&nbsp;NULL,&nbsp;CAST(0x0000921E00000000&nbsp;AS&nbsp;DateTime),&nbsp;NULL,&nbsp;NULL,&nbsp;N<span class="js__string">'e73e9750-603b-4131-89f5-3dd15ed5ff80'</span>,&nbsp;CAST(0x00009A5C00A53CF8&nbsp;AS&nbsp;DateTime))&nbsp;
INSERT&nbsp;[dbo].[Product]&nbsp;([ProductID],&nbsp;[Name],&nbsp;[ProductNumber],&nbsp;[MakeFlag],&nbsp;[FinishedGoodsFlag],&nbsp;[Color],&nbsp;[SafetyStockLevel],&nbsp;[ReorderPoint],&nbsp;[StandardCost],&nbsp;[ListPrice],&nbsp;[Size],&nbsp;[SizeUnitMeasureCode],&nbsp;[WeightUnitMeasureCode],&nbsp;[Weight],&nbsp;[DaysToManufacture],&nbsp;[ProductLine],&nbsp;[Class],&nbsp;[Style],&nbsp;[ProductSubcategoryID],&nbsp;[ProductModelID],&nbsp;[SellStartDate],&nbsp;[SellEndDate],&nbsp;[DiscontinuedDate],&nbsp;[rowguid],&nbsp;[ModifiedDate])&nbsp;VALUES&nbsp;(<span class="js__num">317</span>,&nbsp;N<span class="js__string">'LL&nbsp;Crankarm'</span>,&nbsp;N<span class="js__string">'CA-5965'</span>,&nbsp;<span class="js__num">0</span>,&nbsp;<span class="js__num">0</span>,&nbsp;N<span class="js__string">'Black'</span>,&nbsp;<span class="js__num">500</span>,&nbsp;<span class="js__num">375</span>,&nbsp;<span class="js__num">0.0000</span>,&nbsp;<span class="js__num">0.0000</span>,&nbsp;NULL,&nbsp;NULL,&nbsp;NULL,&nbsp;NULL,&nbsp;<span class="js__num">0</span>,&nbsp;NULL,&nbsp;N<span class="js__string">'L&nbsp;'</span>,&nbsp;NULL,&nbsp;NULL,&nbsp;NULL,&nbsp;CAST(0x0000921E00000000&nbsp;AS&nbsp;DateTime),&nbsp;NULL,&nbsp;NULL,&nbsp;N<span class="js__string">'3c9d10b7-a6b2-4774-9963-c19dcee72fea'</span>,&nbsp;CAST(0x00009A5C00A53CF8&nbsp;AS&nbsp;DateTime))&nbsp;
INSERT&nbsp;[dbo].[Product]&nbsp;([ProductID],&nbsp;[Name],&nbsp;[ProductNumber],&nbsp;[MakeFlag],&nbsp;[FinishedGoodsFlag],&nbsp;[Color],&nbsp;[SafetyStockLevel],&nbsp;[ReorderPoint],&nbsp;[StandardCost],&nbsp;[ListPrice],&nbsp;[Size],&nbsp;[SizeUnitMeasureCode],&nbsp;[WeightUnitMeasureCode],&nbsp;[Weight],&nbsp;[DaysToManufacture],&nbsp;[ProductLine],&nbsp;[Class],&nbsp;[Style],&nbsp;[ProductSubcategoryID],&nbsp;[ProductModelID],&nbsp;[SellStartDate],&nbsp;[SellEndDate],&nbsp;[DiscontinuedDate],&nbsp;[rowguid],&nbsp;[ModifiedDate])&nbsp;VALUES&nbsp;(<span class="js__num">318</span>,&nbsp;N<span class="js__string">'ML&nbsp;Crankarm'</span>,&nbsp;N<span class="js__string">'CA-6738'</span>,&nbsp;<span class="js__num">0</span>,&nbsp;<span class="js__num">0</span>,&nbsp;N<span class="js__string">'Black'</span>,&nbsp;<span class="js__num">500</span>,&nbsp;<span class="js__num">375</span>,&nbsp;<span class="js__num">0.0000</span>,&nbsp;<span class="js__num">0.0000</span>,&nbsp;NULL,&nbsp;NULL,&nbsp;NULL,&nbsp;NULL,&nbsp;<span class="js__num">0</span>,&nbsp;NULL,&nbsp;N<span class="js__string">'M&nbsp;'</span>,&nbsp;NULL,&nbsp;NULL,&nbsp;NULL,&nbsp;CAST(0x0000921E00000000&nbsp;AS&nbsp;DateTime),&nbsp;NULL,&nbsp;NULL,&nbsp;N<span class="js__string">'eabb9a92-fa07-4eab-8955-f0517b4a4ca7'</span>,&nbsp;CAST(0x00009A5C00A53CF8&nbsp;AS&nbsp;DateTime))</pre>
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
<p><span style="font-size:small">Creating models and entity</span></p>
<p><span style="font-size:small">If you don&rsquo;t know how to create an entity in your solution, please read that&nbsp;<a href="http://sibeeshpassion.com/web-api-with-angular-js/" target="_blank">here</a>. I have mentioned the steps to be followed in that
 article. Once you have created the entity, you are good to go.</span></p>
<p><span style="font-size:small">Here I am assuming that you have created an entity and got a model class as preceding.</span></p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_595589">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//------------------------------------------------------------------------------</span>&nbsp;
<span class="cs__com">//&nbsp;&lt;auto-generated&gt;</span>&nbsp;
<span class="cs__com">//&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;This&nbsp;code&nbsp;was&nbsp;generated&nbsp;from&nbsp;a&nbsp;template.</span>&nbsp;
<span class="cs__com">//</span>&nbsp;
<span class="cs__com">//&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Manual&nbsp;changes&nbsp;to&nbsp;this&nbsp;file&nbsp;may&nbsp;cause&nbsp;unexpected&nbsp;behavior&nbsp;in&nbsp;your&nbsp;application.</span>&nbsp;
<span class="cs__com">//&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Manual&nbsp;changes&nbsp;to&nbsp;this&nbsp;file&nbsp;will&nbsp;be&nbsp;overwritten&nbsp;if&nbsp;the&nbsp;code&nbsp;is&nbsp;regenerated.</span>&nbsp;
<span class="cs__com">//&nbsp;&lt;/auto-generated&gt;</span>&nbsp;
<span class="cs__com">//------------------------------------------------------------------------------</span>&nbsp;
&nbsp;&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;IgniteUI.Models&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;System;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;Product&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;ProductID&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Name&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;ProductNumber&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;MakeFlag&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;FinishedGoodsFlag&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Color&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">short</span>&nbsp;SafetyStockLevel&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">short</span>&nbsp;ReorderPoint&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">decimal</span>&nbsp;StandardCost&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">decimal</span>&nbsp;ListPrice&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Size&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;SizeUnitMeasureCode&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;WeightUnitMeasureCode&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Nullable&lt;<span class="cs__keyword">decimal</span>&gt;&nbsp;Weight&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;DaysToManufacture&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;ProductLine&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Class&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Style&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Nullable&lt;<span class="cs__keyword">int</span>&gt;&nbsp;ProductSubcategoryID&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Nullable&lt;<span class="cs__keyword">int</span>&gt;&nbsp;ProductModelID&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;System.DateTime&nbsp;SellStartDate&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Nullable&lt;System.DateTime&gt;&nbsp;SellEndDate&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Nullable&lt;System.DateTime&gt;&nbsp;DiscontinuedDate&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;System.Guid&nbsp;rowguid&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;System.DateTime&nbsp;ModifiedDate&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
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
<p><span style="font-size:small">Configure MVC application</span></p>
<p><span style="font-size:small">As you have finished your installing, we can create a MVC application now. Open your&nbsp;<a href="http://sibeeshpassion.com/category/visual-studio/" target="_blank">Visual Studio</a>&nbsp;and click on new project. Name your
 project, here I am going to name my project as IgniteUIGrid. Select MVC template and click OK.</span></p>
<p><span style="font-size:small">Click on the reference and add DLL reference of IgiteUI from C:\Program Files (x86)\Infragistics\2016.1\Ignite UI\MVC\MVC6\Bin\dnx451 or from which ever the folder you installed IgniteUI.</span></p>
<div class="wp-caption x_x_alignnone" id="attachment_11800"></div>
<p><span style="font-size:small">Create controller and actions</span></p>
<p><span style="font-size:small">Now create a controller as follows.</span></p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_467414">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Web.Mvc.aspx" target="_blank" title="Auto generated link to System.Web.Mvc">System.Web.Mvc</a>;&nbsp;
&nbsp;&nbsp;
namespace&nbsp;IgniteUI.Controllers&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;ChartController&nbsp;:&nbsp;Controller&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;IgniteUI.Models.TrialsDBEntities&nbsp;db&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;IgniteUI.Models.TrialsDBEntities();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;ActionResult&nbsp;Index()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;View();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
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
<p><span style="font-size:small">Now we will create a JsonResult action for fetching the products from database.</span></p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_835428">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">[HttpGet]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;JsonResult&nbsp;Getproducts()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;model&nbsp;=&nbsp;db.Products.AsQueryable().GroupBy(g&nbsp;=&gt;&nbsp;g.Name,&nbsp;g&nbsp;=&gt;&nbsp;g.ReorderPoint,&nbsp;(key,&nbsp;g)&nbsp;=&gt;&nbsp;<span class="js__operator">new</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name&nbsp;=&nbsp;key,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ReorderPoint&nbsp;=&nbsp;g.Take(<span class="js__num">1</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>).Take(<span class="js__num">10</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;Json(model,&nbsp;JsonRequestBehavior.AllowGet);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
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
<p><span style="font-size:small">Here I am just grouping the items together and taking the first value for Y axis. And as you know we will we setting &lsquo;Name&rsquo; as X axis value in chart.</span></p>
<p><span style="font-size:small">Now shall we create a view?</span></p>
<p><span style="font-size:small">Create view</span></p>
<div>
<div class="syntaxhighlighter xml" id="highlighter_797871">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">@using&nbsp;Infragistics.Web.Mvc;&nbsp;
@using&nbsp;IgniteUI.Models;&nbsp;
@model&nbsp;IQueryable&lt;IgniteUI.Models.Product&gt;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><span style="font-size:small">Creating IgniteUI Chart</span></p>
<p><span style="font-size:small">So our view is ready, now we will create an element where we can render our chart.</span></p>
<div>
<div class="syntaxhighlighter xml" id="highlighter_453495">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;div&nbsp;style=<span class="js__string">&quot;width:&nbsp;100%;&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;id=<span class="js__string">&quot;chart&quot;</span>&gt;&lt;/div&gt;&nbsp;
&lt;/div&gt;</pre>
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
<p><span style="font-size:small">What is next? Yes you are right. We need an ajax call.</span></p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_810376">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">&lt;script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$.ajax(<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;type:&nbsp;<span class="js__string">'GET'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;url:&nbsp;<span class="js__string">'http://localhost:39044/chart/Getproducts'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;beforeSend:&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;success:&nbsp;<span class="js__operator">function</span>&nbsp;(data)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GenerateChart(data);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;error:&nbsp;<span class="js__operator">function</span>&nbsp;(e)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;console.log(<span class="js__string">'Error&nbsp;occured:&nbsp;'</span>&nbsp;&#43;&nbsp;e.message);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&lt;/script&gt;</pre>
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
<p><span style="font-size:small">Here&nbsp;<em>GenerateChart</em>&nbsp;is where we actually build our chart.</span></p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_943147">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__operator">function</span>&nbsp;GenerateChart(chartData)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#chart&quot;</span>).igDataChart(<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;width:&nbsp;<span class="js__string">&quot;100%&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;height:&nbsp;<span class="js__string">&quot;500px&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;title:&nbsp;<span class="js__string">&quot;Product&nbsp;vs&nbsp;Reorder&nbsp;Point&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;subtitle:&nbsp;<span class="js__string">&quot;Final&nbsp;products&nbsp;and&nbsp;reorder&nbsp;Point&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dataSource:&nbsp;chartData,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;axes:&nbsp;[&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;name:&nbsp;<span class="js__string">&quot;NameAxis&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;type:&nbsp;<span class="js__string">&quot;categoryX&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;title:&nbsp;<span class="js__string">&quot;Product&nbsp;Name&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;label:&nbsp;<span class="js__string">&quot;Name&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;name:&nbsp;<span class="js__string">&quot;YAxisReorderPoint&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;type:&nbsp;<span class="js__string">&quot;numericY&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;minimumValue:&nbsp;<span class="js__num">0</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;title:&nbsp;<span class="js__string">&quot;Reorder&nbsp;Point&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;],&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;series:&nbsp;[&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;name:&nbsp;<span class="js__string">&quot;NameReorderPoint&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;type:&nbsp;<span class="js__string">&quot;column&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isHighlightingEnabled:&nbsp;true,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isTransitionInEnabled:&nbsp;true,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xAxis:&nbsp;<span class="js__string">&quot;NameAxis&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;yAxis:&nbsp;<span class="js__string">&quot;YAxisReorderPoint&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;valueMemberPath:&nbsp;<span class="js__string">&quot;ReorderPoint&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<div>
<div class="syntaxhighlighter xml" id="highlighter_593403"><span style="font-size:small">Now please run your application and go to the&nbsp;</span><em style="font-size:small">http://localhost:39044/Chart</em><span style="font-size:small">, there you can
 see a chart with the data you have given.</span></div>
</div>
<div class="wp-caption x_x_alignnone" id="attachment_11825"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/07/Ignite_UI_Chart_Control.png"><img class="size-large x_x_wp-image-11825" src="-ignite_ui_chart_control-1024x446.png" alt="Ignite_UI_Chart_Control" width="634" height="276"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">Ignite_UI_Chart_Control</span></p>
</div>
<p><span style="font-size:small">Sounds good? I hope you have got some knowledge about the Ignite UI chart control. That&rsquo;s all for today. See you soon with other Ignite UI controls.</span></p>
</li>