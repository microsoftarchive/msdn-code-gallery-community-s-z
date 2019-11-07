# Working With Test Client In Asp Net Web API Help Page
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- SQL Server
- ASP.NET Web API
- Web API
- Visual Studio 2015
## Topics
- Performance
- Visual Studio
- Web API
## Updated
- 05/29/2016
## Description

<p><span style="font-size:small">In this article we are going to see how we test our API with the help of a package called&nbsp;<em>WebApiTestClient</em>. As you all know, if you create a sample API project you will get a folder HelpPage in Areas. This is for
 adding the XML description to each controller and actions we use in our API. If you document it well, any one can understand your API, so that you don&rsquo;t need to explain what your API will do and what would be the output. If you are new to HelpPage implementation
 in API, please see here:&nbsp;<a href="http://sibeeshpassion.com/working-with-api-help-page-controller-action-description-in-web-api/" target="_blank">API help page controller action description in Web API</a>. Here I am going to create a&nbsp;<a href="http://sibeeshpassion.com/category/web-api" target="_blank">Web
 API</a>&nbsp;with the help page descriptions in<a href="http://sibeeshpassion.com/category/tools/visual-studio/" target="_blank">Visual Studio</a>&nbsp;2015. And once after the project is ready I will install the&nbsp;<em>WebApiTestClient&nbsp;</em>package
 to my solution. I hope you will like this.</span></p>
<blockquote>
<p><span style="font-size:small">Please be noted that this package is not officially released by Microsoft. This is a prototype created by<a href="https://social.msdn.microsoft.com/profile/Yao&#43;-&#43;MSFT" target="_blank">Yao &ndash; MSFT</a></span></p>
</blockquote>
<p><strong><span style="font-size:small">Background</span></strong></p>
<p><span style="font-size:small">For the past few months, I had been working with API projects. Recently I was asked to create an application to test the API I created so that the testing team can test the API easily. Yes I agree that we have tools like Fiddler
 and Post Man for the same. Still we thought to create our own. As I started my development, I came to know about the package&nbsp;<em>WebApiTestClient</em>&nbsp;which does what we wanted. Finally we decided to stop developing the application and used this
 wonderful package. Here I am going to show you how can we use this.</span></p>
<p><strong><span style="font-size:small">Prerequisites</span></strong></p>
<li><span style="font-size:small">Visual Studio With Web API Installed</span>
<p><span style="font-size:small">Things we are going to do</span></p>
<p><span style="font-size:small">The following are the tasks we are going to do.</span></p>
</li><li><span style="font-size:small">Setting up database</span> </li><li><span style="font-size:small">Creating an Entity Framework</span> </li><li><span style="font-size:small">Creating API controller with the Model Created</span>
</li><li><span style="font-size:small">Installing&nbsp;<em>WebApiTestClient</em></span>
</li><li><span style="font-size:small">Configuring&nbsp;<em>WebApiTestClient</em></span>
</li><li><span style="font-size:small">Testing&nbsp;<em>WebApiTestClient</em></span>
<p><strong><span style="font-size:small">Setting up database</span></strong></p>
<p><span style="font-size:small">Here I am going to create a database which I created for my demo purposes, you can always create this database by running the queries mentioned here.</span></p>
<p><strong><span style="font-size:small">Create database</span></strong></p>
<div>
<div class="syntaxhighlighter sql" id="highlighter_367168">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>
<pre class="hidden">USE [master]
GO
 
/****** Object:  Database [TrialsDB]    Script Date: 5/12/2016 10:56:41 AM ******/
CREATE DATABASE [TrialsDB]
 CONTAINMENT = NONE
 ON  PRIMARY
( NAME = N'TrialsDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\TrialsDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON
( NAME = N'TrialsDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\TrialsDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
 
ALTER DATABASE [TrialsDB] SET COMPATIBILITY_LEVEL = 110
GO
 
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TrialsDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
 
ALTER DATABASE [TrialsDB] SET ANSI_NULL_DEFAULT OFF
GO
 
ALTER DATABASE [TrialsDB] SET ANSI_NULLS OFF
GO
 
ALTER DATABASE [TrialsDB] SET ANSI_PADDING OFF
GO
 
ALTER DATABASE [TrialsDB] SET ANSI_WARNINGS OFF
GO
 
ALTER DATABASE [TrialsDB] SET ARITHABORT OFF
GO
 
ALTER DATABASE [TrialsDB] SET AUTO_CLOSE OFF
GO
 
ALTER DATABASE [TrialsDB] SET AUTO_CREATE_STATISTICS ON
GO
 
ALTER DATABASE [TrialsDB] SET AUTO_SHRINK OFF
GO
 
ALTER DATABASE [TrialsDB] SET AUTO_UPDATE_STATISTICS ON
GO
 
ALTER DATABASE [TrialsDB] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
 
ALTER DATABASE [TrialsDB] SET CURSOR_DEFAULT  GLOBAL
GO
 
ALTER DATABASE [TrialsDB] SET CONCAT_NULL_YIELDS_NULL OFF
GO
 
ALTER DATABASE [TrialsDB] SET NUMERIC_ROUNDABORT OFF
GO
 
ALTER DATABASE [TrialsDB] SET QUOTED_IDENTIFIER OFF
GO
 
ALTER DATABASE [TrialsDB] SET RECURSIVE_TRIGGERS OFF
GO
 
ALTER DATABASE [TrialsDB] SET  DISABLE_BROKER
GO
 
ALTER DATABASE [TrialsDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
 
ALTER DATABASE [TrialsDB] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
 
ALTER DATABASE [TrialsDB] SET TRUSTWORTHY OFF
GO
 
ALTER DATABASE [TrialsDB] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
 
ALTER DATABASE [TrialsDB] SET PARAMETERIZATION SIMPLE
GO
 
ALTER DATABASE [TrialsDB] SET READ_COMMITTED_SNAPSHOT OFF
GO
 
ALTER DATABASE [TrialsDB] SET HONOR_BROKER_PRIORITY OFF
GO
 
ALTER DATABASE [TrialsDB] SET RECOVERY FULL
GO
 
ALTER DATABASE [TrialsDB] SET  MULTI_USER
GO
 
ALTER DATABASE [TrialsDB] SET PAGE_VERIFY CHECKSUM 
GO
 
ALTER DATABASE [TrialsDB] SET DB_CHAINING OFF
GO
 
ALTER DATABASE [TrialsDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF )
GO
 
ALTER DATABASE [TrialsDB] SET TARGET_RECOVERY_TIME = 0 SECONDS
GO
 
ALTER DATABASE [TrialsDB] SET  READ_WRITE
GO</pre>
<div class="preview">
<pre class="mysql"><span class="sql__keyword">USE</span>&nbsp;[<span class="sql__keyword">master</span>]&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;&nbsp;
<span class="sql__mlcom">/******&nbsp;Object:&nbsp;&nbsp;Database&nbsp;[TrialsDB]&nbsp;&nbsp;&nbsp;&nbsp;Script&nbsp;Date:&nbsp;5/12/2016&nbsp;10:56:41&nbsp;AM&nbsp;******/</span>&nbsp;
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
<p><strong><span style="font-size:small">Create table with data</span></strong></p>
<div>
<div class="syntaxhighlighter sql" id="highlighter_43679">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>
<pre class="hidden">USE [TrialsDB]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 5/12/2016 10:54:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
    [ProductID] [int] NOT NULL,
    [Name] [nvarchar](max) NOT NULL,
    [ProductNumber] [nvarchar](25) NOT NULL,
    [MakeFlag] [bit] NOT NULL,
    [FinishedGoodsFlag] [bit] NOT NULL,
    [Color] [nvarchar](15) NULL,
    [SafetyStockLevel] [smallint] NOT NULL,
    [ReorderPoint] [smallint] NOT NULL,
    [StandardCost] [money] NOT NULL,
    [ListPrice] [money] NOT NULL,
    [Size] [nvarchar](5) NULL,
    [SizeUnitMeasureCode] [nchar](3) NULL,
    [WeightUnitMeasureCode] [nchar](3) NULL,
    [Weight] [decimal](8, 2) NULL,
    [DaysToManufacture] [int] NOT NULL,
    [ProductLine] [nchar](2) NULL,
    [Class] [nchar](2) NULL,
    [Style] [nchar](2) NULL,
    [ProductSubcategoryID] [int] NULL,
    [ProductModelID] [int] NULL,
    [SellStartDate] [datetime] NOT NULL,
    [SellEndDate] [datetime] NULL,
    [DiscontinuedDate] [datetime] NULL,
    [rowguid] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
    [ModifiedDate] [datetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Product] ([ProductID], [Name], [ProductNumber], [MakeFlag], [FinishedGoodsFlag], [Color], [SafetyStockLevel], [ReorderPoint], [StandardCost], [ListPrice], [Size], [SizeUnitMeasureCode], [WeightUnitMeasureCode], [Weight], [DaysToManufacture], [ProductLine], [Class], [Style], [ProductSubcategoryID], [ProductModelID], [SellStartDate], [SellEndDate], [DiscontinuedDate], [rowguid], [ModifiedDate]) VALUES (1, N'Adjustable Race', N'AR-5381', 0, 0, NULL, 1000, 750, 0.0000, 0.0000, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, CAST(0x0000921E00000000 AS DateTime), NULL, NULL, N'694215b7-08f7-4c0d-acb1-d734ba44c0c8', CAST(0x00009A5C00A53CF8 AS DateTime))
INSERT [dbo].[Product] ([ProductID], [Name], [ProductNumber], [MakeFlag], [FinishedGoodsFlag], [Color], [SafetyStockLevel], [ReorderPoint], [StandardCost], [ListPrice], [Size], [SizeUnitMeasureCode], [WeightUnitMeasureCode], [Weight], [DaysToManufacture], [ProductLine], [Class], [Style], [ProductSubcategoryID], [ProductModelID], [SellStartDate], [SellEndDate], [DiscontinuedDate], [rowguid], [ModifiedDate]) VALUES (2, N'Bearing Ball', N'BA-8327', 0, 0, NULL, 1000, 750, 0.0000, 0.0000, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, CAST(0x0000921E00000000 AS DateTime), NULL, NULL, N'58ae3c20-4f3a-4749-a7d4-d568806cc537', CAST(0x00009A5C00A53CF8 AS DateTime))
INSERT [dbo].[Product] ([ProductID], [Name], [ProductNumber], [MakeFlag], [FinishedGoodsFlag], [Color], [SafetyStockLevel], [ReorderPoint], [StandardCost], [ListPrice], [Size], [SizeUnitMeasureCode], [WeightUnitMeasureCode], [Weight], [DaysToManufacture], [ProductLine], [Class], [Style], [ProductSubcategoryID], [ProductModelID], [SellStartDate], [SellEndDate], [DiscontinuedDate], [rowguid], [ModifiedDate]) VALUES (3, N'BB Ball Bearing', N'BE-2349', 1, 0, NULL, 800, 600, 0.0000, 0.0000, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, CAST(0x0000921E00000000 AS DateTime), NULL, NULL, N'9c21aed2-5bfa-4f18-bcb8-f11638dc2e4e', CAST(0x00009A5C00A53CF8 AS DateTime))
INSERT [dbo].[Product] ([ProductID], [Name], [ProductNumber], [MakeFlag], [FinishedGoodsFlag], [Color], [SafetyStockLevel], [ReorderPoint], [StandardCost], [ListPrice], [Size], [SizeUnitMeasureCode], [WeightUnitMeasureCode], [Weight], [DaysToManufacture], [ProductLine], [Class], [Style], [ProductSubcategoryID], [ProductModelID], [SellStartDate], [SellEndDate], [DiscontinuedDate], [rowguid], [ModifiedDate]) VALUES (4, N'Headset Ball Bearings', N'BE-2908', 0, 0, NULL, 800, 600, 0.0000, 0.0000, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, CAST(0x0000921E00000000 AS DateTime), NULL, NULL, N'ecfed6cb-51ff-49b5-b06c-7d8ac834db8b', CAST(0x00009A5C00A53CF8 AS DateTime))
INSERT [dbo].[Product] ([ProductID], [Name], [ProductNumber], [MakeFlag], [FinishedGoodsFlag], [Color], [SafetyStockLevel], [ReorderPoint], [StandardCost], [ListPrice], [Size], [SizeUnitMeasureCode], [WeightUnitMeasureCode], [Weight], [DaysToManufacture], [ProductLine], [Class], [Style], [ProductSubcategoryID], [ProductModelID], [SellStartDate], [SellEndDate], [DiscontinuedDate], [rowguid], [ModifiedDate]) VALUES (316, N'Blade', N'BL-2036', 1, 0, NULL, 800, 600, 0.0000, 0.0000, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, CAST(0x0000921E00000000 AS DateTime), NULL, NULL, N'e73e9750-603b-4131-89f5-3dd15ed5ff80', CAST(0x00009A5C00A53CF8 AS DateTime))
INSERT [dbo].[Product] ([ProductID], [Name], [ProductNumber], [MakeFlag], [FinishedGoodsFlag], [Color], [SafetyStockLevel], [ReorderPoint], [StandardCost], [ListPrice], [Size], [SizeUnitMeasureCode], [WeightUnitMeasureCode], [Weight], [DaysToManufacture], [ProductLine], [Class], [Style], [ProductSubcategoryID], [ProductModelID], [SellStartDate], [SellEndDate], [DiscontinuedDate], [rowguid], [ModifiedDate]) VALUES (317, N'LL Crankarm', N'CA-5965', 0, 0, N'Black', 500, 375, 0.0000, 0.0000, NULL, NULL, NULL, NULL, 0, NULL, N'L ', NULL, NULL, NULL, CAST(0x0000921E00000000 AS DateTime), NULL, NULL, N'3c9d10b7-a6b2-4774-9963-c19dcee72fea', CAST(0x00009A5C00A53CF8 AS DateTime))
INSERT [dbo].[Product] ([ProductID], [Name], [ProductNumber], [MakeFlag], [FinishedGoodsFlag], [Color], [SafetyStockLevel], [ReorderPoint], [StandardCost], [ListPrice], [Size], [SizeUnitMeasureCode], [WeightUnitMeasureCode], [Weight], [DaysToManufacture], [ProductLine], [Class], [Style], [ProductSubcategoryID], [ProductModelID], [SellStartDate], [SellEndDate], [DiscontinuedDate], [rowguid], [ModifiedDate]) VALUES (318, N'ML Crankarm', N'CA-6738', 0, 0, N'Black', 500, 375, 0.0000, 0.0000, NULL, NULL, NULL, NULL, 0, NULL, N'M ', NULL, NULL, NULL, CAST(0x0000921E00000000 AS DateTime), NULL, NULL, N'eabb9a92-fa07-4eab-8955-f0517b4a4ca7', CAST(0x00009A5C00A53CF8 AS DateTime))</pre>
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
</div>
</div>
<p><span style="font-size:small">Our database is ready, now create a Web API application in visual studio and then entity with the above mentioned database.</span></p>
<div class="wp-caption x_alignnone" id="attachment_11556"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/05/Creating-Entity-e1463031313825.png"><img class="size-large x_wp-image-11556" src="-creating-entity-1024x542.png" alt="Creating Entity" width="634" height="336"></a>
</span>
<p class="wp-caption-text"><strong><span style="font-size:small">Creating Entity</span></strong></p>
</div>
<p><span style="font-size:small">If you don&rsquo;t know how to create an entity in your solution, please read that&nbsp;<a href="http://sibeeshpassion.com/web-api-with-angular-js/" target="_blank">here</a>. I have mentioned the steps to be followed in that
 article. Once you have created the entity, you are good to go and create a API controller with the entity created. If you do so, The CRUD actions will be created automatically for you. You may need to edit those actions according to your needs.</span></p>
<div class="wp-caption x_alignnone" id="attachment_11557"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/05/Web-API-2-Controller-with-actions-using-Entity-Framework-e1463031653319.png"><img class="size-full x_wp-image-11557" src="-web-api-2-controller-with-actions-using-entity-framework-e1463031653319.png" alt="Web API 2 Controller with actions, using Entity Framework" width="650" height="457"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">Web API 2 Controller with actions, using Entity Framework</span></p>
</div>
<p><span style="font-size:small">Select the Model Class, DBContext then name your controller and click OK. I hope a controller with the CRUD actions. Now we can modify that as follows.</span></p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_952001">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ControllerActionDescriptions.Models;
 
namespace ControllerActionDescriptions.Controllers
{
    public class ProductsController : ApiController
    {
        private TrialsDBEntities db = new TrialsDBEntities();
        #region GetProducts
        /// &lt;summary&gt;
        /// Get all the products available
        /// GET: api/Products
        /// &lt;/summary&gt;
        public IQueryable&lt;Product&gt; GetProducts()
        {
            return db.Products;
        }
        #endregion
 
        #region GetProductWithParameter
        /// &lt;summary&gt;
        /// Get a single product by id
        /// GET: api/Products/5
        /// &lt;param name=&quot;id&quot;&gt;&lt;/param&gt;
        /// &lt;/summary&gt;
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
 
            return Ok(product);
        }
        #endregion
 // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
 
            if (id != product.ProductID)
            {
                return BadRequest();
            }
 
            db.Entry(product).State = EntityState.Modified;
 
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
 
            return StatusCode(HttpStatusCode.NoContent);
        }
 
        // POST: api/Products
        [ResponseType(typeof(Product))]
        public IHttpActionResult PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
 
            db.Products.Add(product);
 
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ProductExists(product.ProductID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
 
            return CreatedAtRoute(&quot;DefaultApi&quot;, new { id = product.ProductID }, product);
        }
 
        // DELETE: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
 
            db.Products.Remove(product);
            db.SaveChanges();
 
            return Ok(product);
        }
 
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
 
        private bool ProductExists(int id)
        {
            return db.Products.Count(e =&gt; e.ProductID == id) &gt; 0;
        }
    }
}</pre>
<div class="preview">
<pre class="js">using&nbsp;System;&nbsp;
using&nbsp;System.Collections.Generic;&nbsp;
using&nbsp;System.Data;&nbsp;
using&nbsp;System.Data.Entity;&nbsp;
using&nbsp;System.Data.Entity.Infrastructure;&nbsp;
using&nbsp;System.Linq;&nbsp;
using&nbsp;System.Net;&nbsp;
using&nbsp;System.Net.Http;&nbsp;
using&nbsp;System.Web.Http;&nbsp;
using&nbsp;System.Web.Http.Description;&nbsp;
using&nbsp;ControllerActionDescriptions.Models;&nbsp;
&nbsp;&nbsp;
namespace&nbsp;ControllerActionDescriptions.Controllers&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;ProductsController&nbsp;:&nbsp;ApiController&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;TrialsDBEntities&nbsp;db&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;TrialsDBEntities();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#region&nbsp;GetProducts&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;Get&nbsp;all&nbsp;the&nbsp;products&nbsp;available</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;GET:&nbsp;api/Products</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;IQueryable&lt;Product&gt;&nbsp;GetProducts()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;db.Products;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#endregion&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#region&nbsp;GetProductWithParameter&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;Get&nbsp;a&nbsp;single&nbsp;product&nbsp;by&nbsp;id</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;GET:&nbsp;api/Products/5</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;param&nbsp;name=&quot;id&quot;&gt;&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[ResponseType(<span class="js__operator">typeof</span>(Product))]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;IHttpActionResult&nbsp;GetProduct(int&nbsp;id)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Product&nbsp;product&nbsp;=&nbsp;db.Products.Find(id);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(product&nbsp;==&nbsp;null)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;NotFound();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;Ok(product);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#endregion&nbsp;
&nbsp;//&nbsp;PUT:&nbsp;api/Products/<span class="js__num">5</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[ResponseType(<span class="js__operator">typeof</span>(<span class="js__operator">void</span>))]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;IHttpActionResult&nbsp;PutProduct(int&nbsp;id,&nbsp;Product&nbsp;product)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(!ModelState.IsValid)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;BadRequest(ModelState);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(id&nbsp;!=&nbsp;product.ProductID)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;BadRequest();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;db.Entry(product).State&nbsp;=&nbsp;EntityState.Modified;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;db.SaveChanges();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">catch</span>&nbsp;(DbUpdateConcurrencyException)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(!ProductExists(id))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;NotFound();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">throw</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;StatusCode(HttpStatusCode.NoContent);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;POST:&nbsp;api/Products</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[ResponseType(<span class="js__operator">typeof</span>(Product))]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;IHttpActionResult&nbsp;PostProduct(Product&nbsp;product)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(!ModelState.IsValid)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;BadRequest(ModelState);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;db.Products.Add(product);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;db.SaveChanges();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">catch</span>&nbsp;(DbUpdateException)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(ProductExists(product.ProductID))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;Conflict();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">throw</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;CreatedAtRoute(<span class="js__string">&quot;DefaultApi&quot;</span>,&nbsp;<span class="js__operator">new</span>&nbsp;<span class="js__brace">{</span>&nbsp;id&nbsp;=&nbsp;product.ProductID&nbsp;<span class="js__brace">}</span>,&nbsp;product);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;DELETE:&nbsp;api/Products/5</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[ResponseType(<span class="js__operator">typeof</span>(Product))]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;IHttpActionResult&nbsp;DeleteProduct(int&nbsp;id)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Product&nbsp;product&nbsp;=&nbsp;db.Products.Find(id);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(product&nbsp;==&nbsp;null)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;NotFound();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;db.Products.Remove(product);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;db.SaveChanges();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;Ok(product);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;protected&nbsp;override&nbsp;<span class="js__operator">void</span>&nbsp;Dispose(bool&nbsp;disposing)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(disposing)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;db.Dispose();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;base.Dispose(disposing);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;bool&nbsp;ProductExists(int&nbsp;id)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;db.Products.Count(e&nbsp;=&gt;&nbsp;e.ProductID&nbsp;==&nbsp;id)&nbsp;&gt;&nbsp;<span class="js__num">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><strong><span style="font-size:small">Installing WebApiTestClient</span></strong></p>
<p><span style="font-size:small">To install the package, please go to your Package Manage Console from NuGet Package Manager and run the following command.</span></p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_132314">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Bash/shell</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">bash</span>
<pre class="hidden">Install-Package WebApiTestClient
</pre>
<div class="preview">
<pre class="js">Install-Package&nbsp;WebApiTestClient&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><span style="font-size:small">You can always get the details about the package&nbsp;<a href="https://www.nuget.org/packages/WebApiTestClient" target="_blank">here</a>.</span></p>
<p><span style="font-size:small">Once you install the package, you can see some files are added to your Script and Area folder as preceding.</span></p>
<div class="wp-caption x_alignnone" id="attachment_11655"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/05/Script-and-Area-Folder.png"><img class="size-full x_wp-image-11655" src="-script-and-area-folder.png" alt="Script and Area Folder" width="281" height="780"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">Script and Area Folder</span></p>
</div>
<p><strong><span style="font-size:small">Configuring WebApiTestClient</span></strong></p>
<p><span style="font-size:small">To configure the WebApiTestClient, please go to the folder Areas-&gt;Views-&gt;Help and then click on Api.cshtml</span></p>
<div class="wp-caption x_alignnone" id="attachment_11656"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/05/Api-Cshtml.png"><img class="size-full x_wp-image-11656" src="-api-cshtml.png" alt="Api Cshtml" width="262" height="232"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">Api Cshtml</span></p>
</div>
<p><span style="font-size:small">This is the view shown when you click on each API in your help page. Now add the preceding code block to that view.</span></p>
<p><span style="font-size:small"></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>
<pre class="hidden">@Html.DisplayForModel(&quot;TestClientDialogs&quot;)
@section Scripts
{
&lt;link href=&quot;~/Areas/HelpPage/HelpPage.css&quot; rel=&quot;stylesheet&quot; type=&quot;text/css&quot; /&gt;
    @Html.DisplayForModel(&quot;TestClientReferences&quot;)
}</pre>
<div class="preview">
<pre class="js">@Html.DisplayForModel(<span class="js__string">&quot;TestClientDialogs&quot;</span>)&nbsp;
@section&nbsp;Scripts&nbsp;
<span class="js__brace">{</span>&nbsp;
&lt;link&nbsp;href=<span class="js__string">&quot;~/Areas/HelpPage/HelpPage.css&quot;</span>&nbsp;rel=<span class="js__string">&quot;stylesheet&quot;</span>&nbsp;type=<span class="js__string">&quot;text/css&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;@Html.DisplayForModel(<span class="js__string">&quot;TestClientReferences&quot;</span>)&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
</span>
<p></p>
<div>
<div class="syntaxhighlighter xml" id="highlighter_26380"><br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<div class="wp-caption x_alignnone" id="attachment_11657"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/05/Code-Block-e1464327127249.png"><img class="size-full x_wp-image-11657" src="-code-block-e1464327127249.png" alt="Code Block" width="650" height="503"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">Code Block</span></p>
</div>
<p><strong><span style="font-size:small">Testing WebApiTestClient</span></strong></p>
<p><span style="font-size:small">Now run your API application and go to the help page for any controller action, you can see a button called Test API on the bottom. If you click on that you will get a pop where you can test your API action.</span></p>
<div class="wp-caption x_alignnone" id="attachment_11658"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/05/Test-API-Client-Output-e1464327451839.png"><img class="size-large x_wp-image-11658" src="-test-api-client-output-1024x451.png" alt="Test API Client Output" width="634" height="279"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">Test API Client Output</span></p>
</div>
<p><span style="font-size:small">Now if you send your request by clicking the send button, you will get an output as follows.</span></p>
<div class="wp-caption x_alignnone" id="attachment_11659"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/05/Test-API-Client-Output-With-Response-e1464327640682.png"><img class="size-full x_wp-image-11659" src="-test-api-client-output-with-response-e1464327640682.png" alt="Test API Client Output With Response" width="650" height="484"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">Test API Client Output With Response</span></p>
</div>
<p><span style="font-size:small">You can always give id parameter as follows.</span></p>
<div class="wp-caption x_alignnone" id="attachment_11660"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/05/Test-Client-With-Parameters-e1464327873548.png"><img class="size-full x_wp-image-11660" src="-test-client-with-parameters-e1464327873548.png" alt="Test Client With Parameters" width="650" height="302"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">Test Client With Parameters</span></p>
</div>
<p><span style="font-size:small">You can also give content-length and content-type in your post request as follows.</span></p>
<div class="wp-caption x_alignnone" id="attachment_11661"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/05/Test-Client-With-Post-e1464328070355.png"><img class="size-full x_wp-image-11661" src="-test-client-with-post-e1464328070355.png" alt="Test Client With Post" width="650" height="468"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">Test Client With Post</span></p>
</div>
<div class="wp-caption x_alignnone" id="attachment_11662"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/05/Test-Client-With-PUT-Request-e1464328191663.png"><img class="size-full x_wp-image-11662" src="-test-client-with-put-request-e1464328191663.png" alt="Test Client With PUT Request" width="650" height="542"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">Test Client With PUT Request</span></p>
</div>
<p><span style="font-size:small">References</span></p>
</li><li><span style="font-size:small"><a href="https://blogs.msdn.microsoft.com/yaohuang1/2012/12/02/adding-a-simple-test-client-to-asp-net-web-api-help-page/" target="_blank">Sample Test Client</a></span>
</li><li><span style="font-size:small"><a href="https://www.nuget.org/packages/WebApiTestClient" target="_blank">WebApiTestClient</a></span>
<p><span style="font-size:small">Author has already posted the source code in GitHub, please check&nbsp;<a href="https://github.com/yaohuang/WebApiTestClient" target="_blank">here</a>.</span></p>
<p><span style="font-size:small">Have a happy coding!.</span></p>
<h1></h1>
</li>