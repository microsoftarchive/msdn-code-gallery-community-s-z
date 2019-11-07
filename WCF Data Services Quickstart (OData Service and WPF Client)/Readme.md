# WCF Data Services Quickstart (OData Service and WPF Client)
## Requires
- Visual Studio 2008
## License
- Apache License, Version 2.0
## Technologies
- ADO.NET Entity Framework
- ASP.NET
- WPF
- WCF Data Services
- OData
## Topics
- ADO.NET Entity Framework
- Data Access
- WCF Data Services
- OData
- WPF Data Binding
## Updated
- 06/30/2011
## Description

<h1>Introduction</h1>
<div class="introduction">
<p>This sample contains the Visual Studio projects that are created when you complete the
<a href="http://msdn.microsoft.com/en-us/library/cc668796.aspx">WCF Data Services quickstart</a>. This quickstart helps you become familiar with the Open Data Protocol (OData) and WCF Data Services through a series of tasks that support the topics in
<span><a href="http://msdn.microsoft.com/en-us/library/cc668810.aspx"><span style="color:#1364c4">Getting Started with WCF Data Services</span></a></span>.</p>
</div>
<div>
<div class="LW_CollapsibleArea_TitleDiv">
<h1><img class="cl_CollapsibleArea_expanding LW_CollapsibleArea_Img" src="-030c41d9079671d09a62d8e2c1db6973.gif" alt=""><span class="LW_CollapsibleArea_Title">What You Will Learn</span></h1>
</div>
<div class="sectionblock" id="2bdc72c8-e9bf-4841-95bb-027776bc0a19_c"><a id="sectionToggle0"></a>
<p><a href="http://msdn.microsoft.com/en-us/library/cc668796(v=VS.100).aspx">This quickstart</a>&nbsp;shows how to create and access a data service to expose data from the Northwind sample database. In later topics, you will create a Windows Presentation Foundation
 (WPF) client application that accesses the data service by using client libraries.</p>
</div>
</div>
<div>
<div class="LW_CollapsibleArea_TitleDiv">
<h1><span class="LW_CollapsibleArea_Title">Prerequisites</span></h1>
</div>
<a id="sectionToggle1"></a>
<p class="sectionblock">To use&nbsp;WCF Data Services to create a data service, you must install the following components:</p>
<div class="sectionblock">
<ul>
<li>
<p>WCF&nbsp;Data Services and the <span><a href="http://msdn.microsoft.com/en-us/library/bb399572.aspx"><span style="color:#1364c4">ADO.NET Entity Framework</span></a></span>. Both are installed when you install the .NET Framework version 3.5 Service Pack 1
 (SP1) or later versions (WCF Data Services was previously called ADO.NET Data Services).</p>
</li></ul>
</div>
<p style="padding-left:60px">Note: To complete the final task of this quickstart, you must install an update to the .NET Framework version 3.5 Service Pack 1. You can download and install the update from the
<a href="http://go.microsoft.com/fwlink/?LinkId=158125"><span style="color:#1364c4">Microsoft Download Center</span></a>.
<strong>This download is not required when you are using .NET Framework 4 with Visual Studio 2010.</strong></p>
<ul>
<li>
<p>The Entity Data Model tools. These tools are included in Visual Studio 2008 Service Pack 1 (SP1) or a later version.</p>
</li><li>
<p>An instance of Microsoft SQL Server. This includes SQL Server Express.</p>
</li><li>
<p>The Northwind sample database. To download this sample database, see the download page,
<a href="http://go.microsoft.com/fwlink/?linkid=24758"><span style="color:#1364c4">Sample Databases for SQL Server</span></a>.&nbsp;</p>
</li></ul>
</div>
<div>
<div class="LW_CollapsibleArea_TitleDiv">
<h1><span class="LW_CollapsibleArea_Title">WCF&nbsp;Data Services Quickstart Tasks</span></h1>
<p><span class="LW_CollapsibleArea_Title">The following quickstart tasks, when completed, create the Northwind sample data service and client projects.</span></p>
<p><span class="LW_CollapsibleArea_Title">&nbsp;</span></p>
</div>
<a id="sectionToggle2"></a>
<div class="sectionblock">
<dl class="authored"><dt><a href="http://msdn.microsoft.com/en-us/library/dd728275.aspx"><span style="color:#1364c4">Creating the Data Service</span></a>
</dt><dd>
<p>Define the ASP.NET application, define the data model, create the data service, and enable access to resources.</p>
</dd><dt><span><a href="http://msdn.microsoft.com/en-us/library/dd728279.aspx"><span style="color:#1364c4">Accessing the Service from a Web Browser (WCF Data Services Quickstart)</span></a>
</span></dt><dd>
<p>Start the service from Visual Studio and access the service by submitting HTTP GET requests through a Web browser to the exposed resources.</p>
</dd><dt><span><a href="http://msdn.microsoft.com/en-us/library/dd728278.aspx"><span style="color:#1364c4">Creating the .NET Framework Client Application (WCF Data Services Quickstart)</span></a>
</span></dt><dd>
<p>Create a WPF client application to access the data service, bind data to Windows controls, change data in the bound controls, and then send the changes back to the data service.</p>
</dd></dl>
</div>
</div>
<h1>More Information</h1>
<ul>
<li><a href="http://msdn.microsoft.com/en-us/library/cc668796.aspx"><span style="font-family:Calibri; font-size:11pt">WCF Data Services Quickstart (MSDN Library)</span></a>
</li><li><a href="http://msdn.microsoft.com/en-us/library/dd673932.aspx"><span style="font-family:Calibri; font-size:11pt">Entity Framework Provider (MSDN Library)</span></a>
</li><li><a href="http://msdn.microsoft.com/en-us/library/ee358710.aspx"><span style="font-family:Calibri; font-size:11pt">Configuring the Data Service (MSDN Library)</span></a>
</li><li><a href="http://msdn.microsoft.com/en-us/library/dd728286.aspx"><span style="font-family:Calibri; font-size:11pt">Getting Started: Exposing Your Data as a Service (MSDN Library)</span></a>
</li></ul>
