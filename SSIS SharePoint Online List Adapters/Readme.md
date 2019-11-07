# SSIS SharePoint Online List Adapters
## Requires
- Visual Studio 2012
## License
- MIT
## Technologies
- SQL Server 2012
- SSIS 2012
- SharePoint Server 2013
## Topics
- SsisDataflowTask
## Updated
- 02/18/2015
## Description

<p>&nbsp;</p>
<h1>Introduction</h1>
<p><em><span>This sample demonstrates how to get data into and out of SharePoint Online lists by using custom source and destination adapters.</span></em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><span>Use this sample to learn more about:</span></p>
<ul>
<li>Validation: Validation for this component actively goes against the SharePoint Site to verify the properties are valid.
</li><li>Values from Expressions: This component supports external variables, which can be expressions, and can be attached to the source component to customize the query. Similar to the CommandText for the other Sql Components
</li><li>Supports x86/x64 systems using SQL 2005 / SQL 2008 / SQL 2012 using WiX Installer
</li><li>Linq: The Component has been written using Linq and shows how elements such as the metadata and columns can be combined for data retrieval..
</li><li>Custom properties: The component keeps its configuration in custom properties on itself, inputs, and input columns.
</li><li>Connection Manager to store a username / password </li></ul>
<p>&nbsp;</p>
<p>&nbsp;</p>
<ul>
</ul>
<h1>More Information</h1>
<p><em>The sample has two installers for SQL2012 x86-x64. Also source code is included.</em></p>
<p>&nbsp;</p>
<h4>Q: What version of Windows Installer is needed to install the adapters?</h4>
<ul>
<li>You need Windows Installer 4.5 - http://www.microsoft.com/download/en/details.aspx?displaylang=en&amp;id=8483
</li></ul>
<h4>Q: The SharePoint Adapters do not show up in my toolbox after installation</h4>
<ul>
<li>This can happen when the components are installed near the SQL engine, but not on the drive with the actual SSIS components. Here is the workaround:
<ol>
<li>Open Business Intelligence Development Studio, open a package, and then click Choose Toolbox Items on the Tools menu.
</li><li>In the Choose Toolbox Items dialog box, click the SSIS Data Flow Items tab, and then check SharePoint Destination and SharePoint Source and click OK.
</li><li>Or, using the above steps, look at the other components in the toolbox to get an idea where the other components are installed at - and then reinstall the SharePoint components using the corrected path.
</li></ol>
</li><li>The SharePoint source and destination components should now appear in the toolbox for the data flow task. You can add the source and destination components to the data flow of the package.
</li></ul>
<p><em><br>
</em></p>
