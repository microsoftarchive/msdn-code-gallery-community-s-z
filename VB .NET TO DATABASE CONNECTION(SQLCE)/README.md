# VB .NET TO DATABASE CONNECTION(SQLCE)
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- Visual Studio 2010
## Topics
- Visual Studio 2008
- Visual Studio 2010
- Visual Studio 2012
## Updated
- 01/07/2014
## Description

<p><span style="font-size:2em">Introduction</span></p>
<p><em>Creating Database connection via Local Database using VB .NET</em></p>
<h1>Description</h1>
<p><em>For Beginners, you use this sample as you references, you could do a lot of techniques using this code snippets.</em></p>
<h1 class="title">SqlCeConnection Class</h1>
<div class="lw_vs">
<div id="curversion"><strong>Visual Studio 2010</strong></div>
<div id="versionclick">
<div class="cl_lw_vs_seperator" id="vsseperator"></div>
<div>
<div><a id="vsLink">Other Versions</a></div>
<div class="cl_vs_arrow clip10x10"></div>
</div>
</div>
<div class="cl_lw_vs_seperator" id="ratingCounterSeperator"></div>
<div id="ratingCounter"><span id="rcA" class="ratingText">This topic has not yet been rated&nbsp;<span id="rateThisPrefix">-&nbsp;</span><a id="rateThisTopic" title="Rate this topic" href="http://msdn.microsoft.com/en-us/library/system.data.sqlserverce.sqlceconnection(v=vs.100).aspx#feedback">Rate
 this topic</a></span></div>
</div>
<div></div>
<div id="mainSection">
<div id="mainBody">
<div>
<div class="summary">
<p>Represents an open connection to a SQL Server Compact&nbsp;data source.</p>
</div>
</div>
<div>
<div class="LW_CollapsibleArea_TitleDiv"><a class="LW_CollapsibleArea_TitleAhref" title="Click to collapse. Double-click to collapse all."><span class="cl_CollapsibleArea_expanding LW_CollapsibleArea_Img">&nbsp;</span><span class="LW_CollapsibleArea_Title">Inheritance
 Hierarchy</span></a>
<div class="LW_CollapsibleArea_HrDiv">
<hr class="LW_CollapsibleArea_Hr">
</div>
</div>
<div class="sectionblock"><a id="familyToggle"></a><a href="http://msdn.microsoft.com/en-us/library/system.object(v=vs.100).aspx">System<span>.</span>Object</a>&nbsp;<br>
&nbsp;&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.marshalbyrefobject(v=vs.100).aspx">System<span>.</span>MarshalByRefObject</a><br>
&nbsp;&nbsp;&nbsp;&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.componentmodel.component(v=vs.100).aspx"><a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.ComponentModel.aspx" target="_blank" title="Auto generated link to System.ComponentModel">System.ComponentModel</a><span>.</span>Component</a><br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.data.common.dbconnection(v=vs.100).aspx"><a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Data.Common.aspx" target="_blank" title="Auto generated link to System.Data.Common">System.Data.Common</a><span>.</span>DbConnection</a><br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="selflink"><a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Data.SqlServerCe.aspx" target="_blank" title="Auto generated link to System.Data.SqlServerCe">System.Data.SqlServerCe</a><span>.</span>SqlCeConnection</span></div>
</div>
<p>&nbsp;</p>
<strong>Namespace:</strong>&nbsp;&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.data.sqlserverce(v=vs.100).aspx">System.Data.SqlServerCe</a><br>
<strong>Assembly:</strong>&nbsp;&nbsp;System.Data.SqlServerCe&nbsp;(in System.Data.SqlServerCe.dll)
<div>
<div class="LW_CollapsibleArea_TitleDiv"><a class="LW_CollapsibleArea_TitleAhref" title="Click to collapse. Double-click to collapse all."><span class="cl_CollapsibleArea_expanding LW_CollapsibleArea_Img">&nbsp;</span><span class="LW_CollapsibleArea_Title">Syntax</span></a>
<div class="LW_CollapsibleArea_HrDiv">
<hr class="LW_CollapsibleArea_Hr">
</div>
</div>
<div class="sectionblock"><a id="syntaxToggle"></a>
<div class="codeSnippetContainer" id="code-snippet-1">
<div class="codeSnippetContainerTabs">
<div class="codeSnippetContainerTab" dir="ltr"><a href="http://msdn.microsoft.com/en-us/library/system.data.sqlserverce.sqlceconnection(v=vs.100).aspx?cs-save-lang=1&cs-lang=csharp#code-snippet-1">C#</a></div>
<div class="codeSnippetContainerTab" dir="ltr"><a href="http://msdn.microsoft.com/en-us/library/system.data.sqlserverce.sqlceconnection(v=vs.100).aspx?cs-save-lang=1&cs-lang=cpp#code-snippet-1">C&#43;&#43;</a></div>
<div class="codeSnippetContainerTab" dir="ltr"><a href="http://msdn.microsoft.com/en-us/library/system.data.sqlserverce.sqlceconnection(v=vs.100).aspx?cs-save-lang=1&cs-lang=fsharp#code-snippet-1">F#</a></div>
<div class="codeSnippetContainerTab" dir="ltr"><a href="http://msdn.microsoft.com/en-us/library/system.data.sqlserverce.sqlceconnection(v=vs.100).aspx?cs-save-lang=1&cs-lang=jscript#code-snippet-1">JScript</a></div>
<div class="codeSnippetContainerTabActive" dir="ltr"><a>VB</a></div>
</div>
<div class="codeSnippetContainerCodeContainer">
<div class="codeSnippetToolBar">
<div class="codeSnippetToolBarText"></div>
</div>
<div class="codeSnippetContainerCode" dir="ltr" id="CodeSnippetContainerCode_2de89ff5-810c-40dd-89da-2923f4c8e00c">
<div>
<pre><span>'Declaration</span>
<span>Public</span> <span>NotInheritable</span> <span>Class</span> SqlCeConnection _
	<span>Inherits</span> DbConnection
<span>'Usage</span>
<span>Dim</span> instance <span>As</span> SqlCeConnection
</pre>
</div>
</div>
</div>
</div>
</div>
</div>
<p>The&nbsp;<span class="selflink">SqlCeConnection</span>&nbsp;type exposes the following members.</p>
<div>
<div class="LW_CollapsibleArea_TitleDiv"><a class="LW_CollapsibleArea_TitleAhref" title="Click to collapse. Double-click to collapse all."><span class="cl_CollapsibleArea_expanding LW_CollapsibleArea_Img">&nbsp;</span><span class="LW_CollapsibleArea_Title">Constructors</span></a>
<div class="LW_CollapsibleArea_HrDiv">
<hr class="LW_CollapsibleArea_Hr">
</div>
</div>
<div class="sectionblock"><a id="constructorTableToggle"></a>
<div class="libraryMemberFilter">
<div class="filterContainer">Show:&nbsp;&lt;label&gt;&lt;input class=&quot;libraryFilterInherited&quot; checked=&quot;checked&quot; type=&quot;checkbox&quot; value=&quot;Inherit&quot; /&gt;Inherited&nbsp;&lt;/label&gt;&lt;label&gt;&lt;input class=&quot;libraryFilterProtected&quot; checked=&quot;checked&quot; type=&quot;checkbox&quot; value=&quot;Protected&quot;
 /&gt;Protected&lt;/label&gt;</div>
</div>
<table id="memberList" class="members">
<tbody>
<tr>
<th class="iconColumn">&nbsp;</th>
<th class="nameColumn">Name</th>
<th class="descriptionColumn">Description</th>
</tr>
<tr>
<td><img id="pubmethod" class="cl_IC91302" title="Public method" src="-clear.gif" alt="Public method"></td>
<td><a href="http://msdn.microsoft.com/en-us/library/xbbx6s9c(v=vs.100).aspx">SqlCeConnection<span>&nbsp;</span></a></td>
<td>Initializes a new instance of the&nbsp;<span class="selflink">SqlCeConnection</span>&nbsp;class.</td>
</tr>
<tr>
<td><img id="pubmethod" class="cl_IC91302" title="Public method" src="-clear.gif" alt="Public method"></td>
<td><a href="http://msdn.microsoft.com/en-us/library/s1ydzx6b(v=vs.100).aspx">SqlCeConnection(String)</a></td>
<td>Initializes a new instance of the&nbsp;<span class="selflink">SqlCeConnection</span>&nbsp;class with the specified connection string.</td>
</tr>
</tbody>
</table>
<a href="http://msdn.microsoft.com/en-us/library/system.data.sqlserverce.sqlceconnection(v=vs.100).aspx#mainBody">Top</a></div>
</div>
<div>
<div class="LW_CollapsibleArea_TitleDiv"><a class="LW_CollapsibleArea_TitleAhref" title="Click to collapse. Double-click to collapse all."><span class="cl_CollapsibleArea_expanding LW_CollapsibleArea_Img">&nbsp;</span><span class="LW_CollapsibleArea_Title">Properties</span></a>
<div class="LW_CollapsibleArea_HrDiv">
<hr class="LW_CollapsibleArea_Hr">
</div>
</div>
<div class="sectionblock"><a id="propertyTableToggle"></a>
<div class="libraryMemberFilter">
<div class="filterContainer">Show:&nbsp;&lt;label&gt;&lt;input class=&quot;libraryFilterInherited&quot; checked=&quot;checked&quot; type=&quot;checkbox&quot; value=&quot;Inherit&quot; /&gt;Inherited&nbsp;&lt;/label&gt;&lt;label&gt;&lt;input class=&quot;libraryFilterProtected&quot; checked=&quot;checked&quot; type=&quot;checkbox&quot; value=&quot;Protected&quot;
 /&gt;Protected&lt;/label&gt;</div>
</div>
<table id="memberList1" class="members">
<tbody>
<tr>
<th class="iconColumn">&nbsp;</th>
<th class="nameColumn">Name</th>
<th class="descriptionColumn">Description</th>
</tr>
<tr>
<td><img id="protproperty" class="cl_IC100399" title="Protected property" src="-clear.gif" alt="Protected property"></td>
<td><a href="http://msdn.microsoft.com/en-us/library/system.componentmodel.component.canraiseevents(v=vs.100).aspx">CanRaiseEvents</a></td>
<td>(inherited from&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.componentmodel.component(v=vs.100).aspx">Component</a>)</td>
</tr>
<tr>
<td><img id="pubproperty" class="cl_IC74937" title="Public property" src="-clear.gif" alt="Public property"></td>
<td><a href="http://msdn.microsoft.com/en-us/library/system.data.sqlserverce.sqlceconnection.connectionstring(v=vs.100).aspx">ConnectionString</a></td>
<td>Gets or sets the string used to open a database.&nbsp;(Overrides<a href="http://msdn.microsoft.com/en-us/library/system.data.common.dbconnection.connectionstring(v=vs.100).aspx">DbConnection<span>.</span>ConnectionString</a>.)</td>
</tr>
<tr>
<td><img id="pubproperty" class="cl_IC74937" title="Public property" src="-clear.gif" alt="Public property"></td>
<td><a href="http://msdn.microsoft.com/en-us/library/system.data.sqlserverce.sqlceconnection.connectiontimeout(v=vs.100).aspx">ConnectionTimeout</a></td>
<td>Gets the time to wait while trying to establish a connection before terminating the attempt and generating an error.&nbsp;(Overrides<a href="http://msdn.microsoft.com/en-us/library/system.data.common.dbconnection.connectiontimeout(v=vs.100).aspx">DbConnection<span>.</span>ConnectionTimeout</a>.)</td>
</tr>
<tr>
<td><img id="pubproperty" class="cl_IC74937" title="Public property" src="-clear.gif" alt="Public property"></td>
<td><a href="http://msdn.microsoft.com/en-us/library/system.componentmodel.component.container(v=vs.100).aspx">Container</a></td>
<td>(inherited from&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.componentmodel.component(v=vs.100).aspx">Component</a>)</td>
</tr>
<tr>
<td><img id="pubproperty" class="cl_IC74937" title="Public property" src="-clear.gif" alt="Public property"></td>
<td><a href="http://msdn.microsoft.com/en-us/library/system.data.sqlserverce.sqlceconnection.database(v=vs.100).aspx">Database</a></td>
<td>Gets the name of the current database or the database to be used when a connection is open.&nbsp;(Overrides&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.data.common.dbconnection.database(v=vs.100).aspx">DbConnection<span>.</span>Database</a>.)</td>
</tr>
<tr>
<td><img id="pubproperty" class="cl_IC74937" title="Public property" src="-clear.gif" alt="Public property"></td>
<td><a href="http://msdn.microsoft.com/en-us/library/system.data.sqlserverce.sqlceconnection.databaseidentifier(v=vs.100).aspx">DatabaseIdentifier</a></td>
<td>Gets the unique identifier of the current database while synchronizing.</td>
</tr>
<tr>
<td><img id="pubproperty" class="cl_IC74937" title="Public property" src="-clear.gif" alt="Public property"></td>
<td><a href="http://msdn.microsoft.com/en-us/library/system.data.sqlserverce.sqlceconnection.datasource(v=vs.100).aspx">DataSource</a></td>
<td>Gets the file name of the data source.&nbsp;(Overrides&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.data.common.dbconnection.datasource(v=vs.100).aspx">DbConnection<span>.</span>DataSource</a>.)</td>
</tr>
<tr>
<td><img id="protproperty" class="cl_IC100399" title="Protected property" src="-clear.gif" alt="Protected property"></td>
<td><a href="http://msdn.microsoft.com/en-us/library/system.data.common.dbconnection.dbproviderfactory(v=vs.100).aspx">DbProviderFactory</a></td>
<td>(inherited from&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.data.common.dbconnection(v=vs.100).aspx">DbConnection</a>)</td>
</tr>
<tr>
<td><img id="protproperty" class="cl_IC100399" title="Protected property" src="-clear.gif" alt="Protected property"></td>
<td><a href="http://msdn.microsoft.com/en-us/library/system.componentmodel.component.designmode(v=vs.100).aspx">DesignMode</a></td>
<td>(inherited from&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.componentmodel.component(v=vs.100).aspx">Component</a>)</td>
</tr>
<tr>
<td><img id="protproperty" class="cl_IC100399" title="Protected property" src="-clear.gif" alt="Protected property"></td>
<td><a href="http://msdn.microsoft.com/en-us/library/system.componentmodel.component.events(v=vs.100).aspx">Events</a></td>
<td>(inherited from&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.componentmodel.component(v=vs.100).aspx">Component</a>)</td>
</tr>
<tr>
<td><img id="pubproperty" class="cl_IC74937" title="Public property" src="-clear.gif" alt="Public property"></td>
<td><a href="http://msdn.microsoft.com/en-us/library/system.data.sqlserverce.sqlceconnection.serverversion(v=vs.100).aspx">ServerVersion</a></td>
<td>Returns the database version number as a string.&nbsp;(Overrides<a href="http://msdn.microsoft.com/en-us/library/system.data.common.dbconnection.serverversion(v=vs.100).aspx">DbConnection<span>.</span>ServerVersion</a>.)</td>
</tr>
<tr>
<td><img id="pubproperty" class="cl_IC74937" title="Public property" src="-clear.gif" alt="Public property"></td>
<td><a href="http://msdn.microsoft.com/en-us/library/system.componentmodel.component.site(v=vs.100).aspx">Site</a></td>
<td>(inherited from&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.componentmodel.component(v=vs.100).aspx">Component</a>)</td>
</tr>
<tr>
<td><img id="pubproperty" class="cl_IC74937" title="Public property" src="-clear.gif" alt="Public property"></td>
<td><a href="http://msdn.microsoft.com/en-us/library/system.data.sqlserverce.sqlceconnection.state(v=vs.100).aspx">State</a></td>
<td>Gets the current state of the connection.&nbsp;(Overrides&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.data.common.dbconnection.state(v=vs.100).aspx">DbConnection<span>.</span>State</a>.)</td>
</tr>
</tbody>
</table>
<a href="http://msdn.microsoft.com/en-us/library/system.data.sqlserverce.sqlceconnection(v=vs.100).aspx#mainBody">Top</a></div>
</div>
<div>
<div class="LW_CollapsibleArea_TitleDiv"><a class="LW_CollapsibleArea_TitleAhref" title="Click to collapse. Double-click to collapse all."><span class="cl_CollapsibleArea_expanding LW_CollapsibleArea_Img">&nbsp;</span><span class="LW_CollapsibleArea_Title">Methods</span></a>
<div class="LW_CollapsibleArea_HrDiv">
<hr class="LW_CollapsibleArea_Hr">
</div>
</div>
<div class="sectionblock"><a id="methodTableToggle"></a>
<div class="libraryMemberFilter">
<div class="filterContainer">Show:&nbsp;&lt;label&gt;&lt;input class=&quot;libraryFilterInherited&quot; checked=&quot;checked&quot; type=&quot;checkbox&quot; value=&quot;Inherit&quot; /&gt;Inherited&nbsp;&lt;/label&gt;&lt;label&gt;&lt;input class=&quot;libraryFilterProtected&quot; checked=&quot;checked&quot; type=&quot;checkbox&quot; value=&quot;Protected&quot;
 /&gt;Protected&lt;/label&gt;</div>
</div>
<table id="memberList2" class="members">
<tbody>
<tr>
<th class="iconColumn">&nbsp;</th>
<th class="nameColumn">Name</th>
<th class="descriptionColumn">Description</th>
</tr>
<tr>
<td><img id="protmethod" class="cl_IC155188" title="Protected method" src="-clear.gif" alt="Protected method"></td>
<td><a href="http://msdn.microsoft.com/en-us/library/system.data.common.dbconnection.begindbtransaction(v=vs.100).aspx">BeginDbTransaction</a></td>
<td>(inherited from&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.data.common.dbconnection(v=vs.100).aspx">DbConnection</a>)</td>
</tr>
<tr>
<td><img id="pubmethod" class="cl_IC91302" title="Public method" src="-clear.gif" alt="Public method"></td>
<td><a href="http://msdn.microsoft.com/en-us/library/csz1c3h7(v=vs.100).aspx">BeginTransaction<span>&nbsp;</span></a></td>
<td>Begins a database transaction.</td>
</tr>
<tr>
<td><img id="pubmethod" class="cl_IC91302" title="Public method" src="-clear.gif" alt="Public method"></td>
<td><a href="http://msdn.microsoft.com/en-us/library/3xywy9w8(v=vs.100).aspx">BeginTransaction(IsolationLevel)</a></td>
<td>Begins a database transaction with the current&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.data.isolationlevel(v=vs.100).aspx">IsolationLevel</a>&nbsp;value.</td>
</tr>
<tr>
<td><img id="pubmethod" class="cl_IC91302" title="Public method" src="-clear.gif" alt="Public method"></td>
<td><a href="http://msdn.microsoft.com/en-us/library/system.data.sqlserverce.sqlceconnection.changedatabase(v=vs.100).aspx">ChangeDatabase</a></td>
<td>Changes the current database for an open&nbsp;<span class="selflink">SqlCeConnection</span>.(Overrides&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.data.common.dbconnection.changedatabase(v=vs.100).aspx">DbConnection<span>.</span>ChangeDatabase(String)</a>.)</td>
</tr>
<tr>
<td><img id="pubmethod" class="cl_IC91302" title="Public method" src="-clear.gif" alt="Public method"></td>
<td><a href="http://msdn.microsoft.com/en-us/library/system.data.sqlserverce.sqlceconnection.close(v=vs.100).aspx">Close</a></td>
<td>Closes the connection to the data source. This is the preferred method of closing any open connection.&nbsp;(Overrides<a href="http://msdn.microsoft.com/en-us/library/system.data.common.dbconnection.close(v=vs.100).aspx">DbConnection<span>.</span>Close<span>&nbsp;</span></a>.)</td>
</tr>
<tr>
<td><img id="pubmethod" class="cl_IC91302" title="Public method" src="-clear.gif" alt="Public method"></td>
<td><a href="http://msdn.microsoft.com/en-us/library/system.data.sqlserverce.sqlceconnection.createcommand(v=vs.100).aspx">CreateCommand</a></td>
<td>Creates and returns a&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.data.sqlserverce.sqlcecommand(v=vs.100).aspx">SqlCeCommand</a>&nbsp;object associated with the<span class="selflink">SqlCeConnection</span>.</td>
</tr>
<tr>
<td><img id="protmethod" class="cl_IC155188" title="Protected method" src="-clear.gif" alt="Protected method"></td>
<td><a href="http://msdn.microsoft.com/en-us/library/system.data.common.dbconnection.createdbcommand(v=vs.100).aspx">CreateDbCommand</a></td>
<td>(inherited from&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.data.common.dbconnection(v=vs.100).aspx">DbConnection</a>)</td>
</tr>
<tr>
<td><img id="pubmethod" class="cl_IC91302" title="Public method" src="-clear.gif" alt="Public method"></td>
<td><a href="http://msdn.microsoft.com/en-us/library/system.marshalbyrefobject.createobjref(v=vs.100).aspx">CreateObjRef</a></td>
<td>(inherited from&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.marshalbyrefobject(v=vs.100).aspx">MarshalByRefObject</a>)</td>
</tr>
<tr>
<td><img id="pubmethod" class="cl_IC91302" title="Public method" src="-clear.gif" alt="Public method"></td>
<td><a href="http://msdn.microsoft.com/en-us/library/bb300654(v=vs.100).aspx">Dispose</a></td>
<td>Releases all resources used by the current instance of the<span class="selflink">SqlCeConnection</span>&nbsp;class.</td>
</tr>
<tr>
<td><img id="protmethod" class="cl_IC155188" title="Protected method" src="-clear.gif" alt="Protected method"></td>
<td><a href="http://msdn.microsoft.com/en-us/library/d9yzd5cx(v=vs.100).aspx">Dispose(Boolean)</a></td>
<td>(inherited from&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.componentmodel.component(v=vs.100).aspx">Component</a>)</td>
</tr>
<tr>
<td><img id="pubmethod" class="cl_IC91302" title="Public method" src="-clear.gif" alt="Public method"></td>
<td><a href="http://msdn.microsoft.com/en-us/library/system.data.common.dbconnection.enlisttransaction(v=vs.100).aspx">EnlistTransaction(Transaction)</a></td>
<td>(inherited from&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.data.common.dbconnection(v=vs.100).aspx">DbConnection</a>)</td>
</tr>
<tr>
<td><img id="pubmethod" class="cl_IC91302" title="Public method" src="-clear.gif" alt="Public method"></td>
<td><a href="http://msdn.microsoft.com/en-us/library/bb896161(v=vs.100).aspx">EnlistTransaction(Transaction)</a></td>
<td>Enlists in the specified&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.transactions.transaction(v=vs.100).aspx">Transaction</a>.</td>
</tr>
<tr>
<td><img id="pubmethod" class="cl_IC91302" title="Public method" src="-clear.gif" alt="Public method"></td>
<td><a href="http://msdn.microsoft.com/en-us/library/bsc2ak47(v=vs.100).aspx">Equals</a></td>
<td>(inherited from&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.object(v=vs.100).aspx">Object</a>)</td>
</tr>
<tr>
<td><img id="protmethod" class="cl_IC155188" title="Protected method" src="-clear.gif" alt="Protected method"></td>
<td><a href="http://msdn.microsoft.com/en-us/library/az5741fh(v=vs.100).aspx">Finalize</a></td>
<td>(inherited from&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.componentmodel.component(v=vs.100).aspx">Component</a>)</td>
</tr>
<tr>
<td><img id="pubmethod" class="cl_IC91302" title="Public method" src="-clear.gif" alt="Public method"></td>
<td><a href="http://msdn.microsoft.com/en-us/library/system.data.sqlserverce.sqlceconnection.getdatabaseinfo(v=vs.100).aspx">GetDatabaseInfo</a></td>
<td>Returns a set of Key Value pairs with information about locale, encryption mode, and case-sensitivity setting of the connected database.</td>
</tr>
<tr>
<td><img id="pubmethod" class="cl_IC91302" title="Public method" src="-clear.gif" alt="Public method"></td>
<td><a href="http://msdn.microsoft.com/en-us/library/system.object.gethashcode(v=vs.100).aspx">GetHashCode</a></td>
<td>(inherited from&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.object(v=vs.100).aspx">Object</a>)</td>
</tr>
<tr>
<td><img id="pubmethod" class="cl_IC91302" title="Public method" src="-clear.gif" alt="Public method"></td>
<td><a href="http://msdn.microsoft.com/en-us/library/system.marshalbyrefobject.getlifetimeservice(v=vs.100).aspx">GetLifetimeService</a></td>
<td>(inherited from&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.marshalbyrefobject(v=vs.100).aspx">MarshalByRefObject</a>)</td>
</tr>
<tr>
<td><img id="pubmethod" class="cl_IC91302" title="Public method" src="-clear.gif" alt="Public method"></td>
<td><a href="http://msdn.microsoft.com/en-us/library/ff802050(v=vs.100).aspx">GetSchema</a></td>
<td>Returns schema information for the data source of this<span class="selflink">SqlCeConnection</span>.&nbsp;(Overrides&nbsp;<a href="http://msdn.microsoft.com/en-us/library/s98te64s(v=vs.100).aspx">DbConnection<span>.</span>GetSchema</a>.)</td>
</tr>
<tr>
<td><img id="pubmethod" class="cl_IC91302" title="Public method" src="-clear.gif" alt="Public method"></td>
<td><a href="http://msdn.microsoft.com/en-us/library/ff801934(v=vs.100).aspx">GetSchema(String)</a></td>
<td>Returns schema information for the data source of this<span class="selflink">SqlCeConnection</span>&nbsp;using the specified string for the schema name.(Overrides&nbsp;<a href="http://msdn.microsoft.com/en-us/library/22936zd1(v=vs.100).aspx">DbConnection<span>.</span>GetSchema(String)</a>.)</td>
</tr>
<tr>
<td><img id="pubmethod" class="cl_IC91302" title="Public method" src="-clear.gif" alt="Public method"></td>
<td><a href="http://msdn.microsoft.com/en-us/library/ff802169(v=vs.100).aspx">GetSchema(String,&nbsp;String<span>()</span>)</a></td>
<td>Returns schema information for the data source of this<span class="selflink">SqlCeConnection</span>&nbsp;using the specified string for the schema name and the specified string array for the restriction values.&nbsp;(Overrides<a href="http://msdn.microsoft.com/en-us/library/y53he2tz(v=vs.100).aspx">DbConnection<span>.</span>GetSchema(String,&nbsp;String<span>()</span>)</a>.)</td>
</tr>
<tr>
<td><img id="protmethod" class="cl_IC155188" title="Protected method" src="-clear.gif" alt="Protected method"></td>
<td><a href="http://msdn.microsoft.com/en-us/library/system.componentmodel.component.getservice(v=vs.100).aspx">GetService</a></td>
<td>(inherited from&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.componentmodel.component(v=vs.100).aspx">Component</a>)</td>
</tr>
<tr>
<td><img id="pubmethod" class="cl_IC91302" title="Public method" src="-clear.gif" alt="Public method"></td>
<td><a href="http://msdn.microsoft.com/en-us/library/system.object.gettype(v=vs.100).aspx">GetType</a></td>
<td>(inherited from&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.object(v=vs.100).aspx">Object</a>)</td>
</tr>
<tr>
<td><img id="pubmethod" class="cl_IC91302" title="Public method" src="-clear.gif" alt="Public method"></td>
<td><a href="http://msdn.microsoft.com/en-us/library/system.marshalbyrefobject.initializelifetimeservice(v=vs.100).aspx">InitializeLifetimeService</a></td>
<td>(inherited from&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.marshalbyrefobject(v=vs.100).aspx">MarshalByRefObject</a>)</td>
</tr>
<tr>
<td><img id="protmethod" class="cl_IC155188" title="Protected method" src="-clear.gif" alt="Protected method"></td>
<td><a href="http://msdn.microsoft.com/en-us/library/system.object.memberwiseclone(v=vs.100).aspx">MemberwiseClone</a></td>
<td>(inherited from&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.object(v=vs.100).aspx">Object</a>)</td>
</tr>
<tr>
<td><img id="protmethod" class="cl_IC155188" title="Protected method" src="-clear.gif" alt="Protected method"></td>
<td><a href="http://msdn.microsoft.com/en-us/library/ms131262(v=vs.100).aspx">MemberwiseClone(Boolean)</a></td>
<td>(inherited from&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.marshalbyrefobject(v=vs.100).aspx">MarshalByRefObject</a>)</td>
</tr>
<tr>
<td><img id="protmethod" class="cl_IC155188" title="Protected method" src="-clear.gif" alt="Protected method"></td>
<td><a href="http://msdn.microsoft.com/en-us/library/system.data.common.dbconnection.onstatechange(v=vs.100).aspx">OnStateChange</a></td>
<td>(inherited from&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.data.common.dbconnection(v=vs.100).aspx">DbConnection</a>)</td>
</tr>
<tr>
<td><img id="pubmethod" class="cl_IC91302" title="Public method" src="-clear.gif" alt="Public method"></td>
<td><a href="http://msdn.microsoft.com/en-us/library/system.data.sqlserverce.sqlceconnection.open(v=vs.100).aspx">Open</a></td>
<td>Opens a database connection with the property settings specified by the&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.data.sqlserverce.sqlceconnection.connectionstring(v=vs.100).aspx">ConnectionString</a>.&nbsp;(Overrides&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.data.common.dbconnection.open(v=vs.100).aspx">DbConnection<span>.</span>Open</a>.)</td>
</tr>
<tr>
<td><img id="pubmethod" class="cl_IC91302" title="Public method" src="-clear.gif" alt="Public method"></td>
<td><a href="http://msdn.microsoft.com/en-us/library/z819d1t5(v=vs.100).aspx">ToString</a></td>
<td>(inherited from&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.componentmodel.component(v=vs.100).aspx">Component</a>)</td>
</tr>
</tbody>
</table>
<a href="http://msdn.microsoft.com/en-us/library/system.data.sqlserverce.sqlceconnection(v=vs.100).aspx#mainBody">Top</a></div>
</div>
<div>
<div class="LW_CollapsibleArea_TitleDiv"><a class="LW_CollapsibleArea_TitleAhref" title="Click to collapse. Double-click to collapse all."><span class="LW_CollapsibleArea_Title">Events</span></a>
<div class="LW_CollapsibleArea_HrDiv">
<hr class="LW_CollapsibleArea_Hr">
</div>
</div>
<div class="sectionblock"><a id="eventTableToggle"></a>
<div class="libraryMemberFilter">
<div class="filterContainer">Show:&nbsp;&lt;label&gt;&lt;input class=&quot;libraryFilterInherited&quot; checked=&quot;checked&quot; type=&quot;checkbox&quot; value=&quot;Inherit&quot; /&gt;Inherited&nbsp;&lt;/label&gt;&lt;label&gt;&lt;input class=&quot;libraryFilterProtected&quot; checked=&quot;checked&quot; type=&quot;checkbox&quot; value=&quot;Protected&quot;
 /&gt;Protected&lt;/label&gt;</div>
</div>
<table id="memberList3" class="members">
<tbody>
<tr>
<th class="iconColumn">&nbsp;</th>
<th class="nameColumn">Name</th>
<th class="descriptionColumn">Description</th>
</tr>
<tr>
<td><img id="pubevent" class="cl_IC90369" title="Public event" src="-clear.gif" alt="Public event"></td>
<td><a href="http://msdn.microsoft.com/en-us/library/system.componentmodel.component.disposed(v=vs.100).aspx">Disposed</a></td>
<td>(inherited from&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.componentmodel.component(v=vs.100).aspx">Component</a>)</td>
</tr>
<tr>
<td><img id="pubevent" class="cl_IC90369" title="Public event" src="-clear.gif" alt="Public event"></td>
<td><a href="http://msdn.microsoft.com/en-us/library/system.data.sqlserverce.sqlceconnection.flushfailure(v=vs.100).aspx">FlushFailure</a></td>
<td>Occurs when the background flush fails.</td>
</tr>
<tr>
<td><img id="pubevent" class="cl_IC90369" title="Public event" src="-clear.gif" alt="Public event"></td>
<td><a href="http://msdn.microsoft.com/en-us/library/system.data.sqlserverce.sqlceconnection.infomessage(v=vs.100).aspx">InfoMessage</a></td>
<td>Occurs when the .NET Compact Framework Data Provider for SQL Server sends a warning or an informational message.</td>
</tr>
<tr>
<td><img id="pubevent" class="cl_IC90369" title="Public event" src="-clear.gif" alt="Public event"></td>
<td><a href="http://msdn.microsoft.com/en-us/library/system.data.sqlserverce.sqlceconnection.statechange(v=vs.100).aspx">StateChange</a></td>
<td>Occurs when the state of the connection changes.&nbsp;(Overrides<a href="http://msdn.microsoft.com/en-us/library/system.data.common.dbconnection.statechange(v=vs.100).aspx">DbConnection<span>.</span>StateChange</a>.)</td>
</tr>
</tbody>
</table>
<a href="http://msdn.microsoft.com/en-us/library/system.data.sqlserverce.sqlceconnection(v=vs.100).aspx#mainBody">Top</a></div>
</div>
<div>
<div class="LW_CollapsibleArea_TitleDiv"><a class="LW_CollapsibleArea_TitleAhref" title="Click to collapse. Double-click to collapse all."><span class="LW_CollapsibleArea_Title">Explicit&nbsp;Interface&nbsp;Implementations</span></a>
<div class="LW_CollapsibleArea_HrDiv">
<hr class="LW_CollapsibleArea_Hr">
</div>
</div>
<div class="sectionblock"><a id="ExplicitInterfaceImplementationTableToggle"></a>
<div class="libraryMemberFilter">
<div class="filterContainer">Show:&nbsp;&lt;label&gt;&lt;input class=&quot;libraryFilterInherited&quot; checked=&quot;checked&quot; type=&quot;checkbox&quot; value=&quot;Inherit&quot; /&gt;Inherited&nbsp;&lt;/label&gt;&lt;label&gt;&lt;input class=&quot;libraryFilterProtected&quot; checked=&quot;checked&quot; type=&quot;checkbox&quot; value=&quot;Protected&quot;
 /&gt;Protected&lt;/label&gt;</div>
</div>
<table id="memberList4" class="members">
<tbody>
<tr>
<th class="iconColumn">&nbsp;</th>
<th class="nameColumn">Name</th>
<th class="descriptionColumn">Description</th>
</tr>
<tr>
<td><img id="pubinterface" class="cl_IC141795" title="Explicit interface implemetation" src="-clear.gif" alt="Explicit interface implemetation"><img id="privmethod" class="cl_IC6709" title="Private method" src="-clear.gif" alt="Private method"></td>
<td><span class="unresolvedLink">IDbConnection<span>.</span>BeginTransaction</span></td>
<td>(inherited from&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.data.common.dbconnection(v=vs.100).aspx">DbConnection</a>)</td>
</tr>
<tr>
<td><img id="pubinterface" class="cl_IC141795" title="Explicit interface implemetation" src="-clear.gif" alt="Explicit interface implemetation"><img id="privmethod" class="cl_IC6709" title="Private method" src="-clear.gif" alt="Private method"></td>
<td><span class="unresolvedLink">IDbConnection<span>.</span>BeginTransaction(IsolationLevel)</span></td>
<td>(inherited from&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.data.common.dbconnection(v=vs.100).aspx">DbConnection</a>)</td>
</tr>
<tr>
<td><img id="pubinterface" class="cl_IC141795" title="Explicit interface implemetation" src="-clear.gif" alt="Explicit interface implemetation"><img id="privmethod" class="cl_IC6709" title="Private method" src="-clear.gif" alt="Private method"></td>
<td><span class="unresolvedLink">IDbConnection<span>.</span>CreateCommand</span></td>
<td>(inherited from&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.data.common.dbconnection(v=vs.100).aspx">DbConnection</a>)</td>
</tr>
</tbody>
</table>
<a href="http://msdn.microsoft.com/en-us/library/system.data.sqlserverce.sqlceconnection(v=vs.100).aspx#mainBody">Top</a></div>
</div>
<div>
<div class="LW_CollapsibleArea_TitleDiv"><a class="LW_CollapsibleArea_TitleAhref" title="Click to collapse. Double-click to collapse all."><span class="LW_CollapsibleArea_Title">Remarks</span></a>
<div class="LW_CollapsibleArea_HrDiv">
<hr class="LW_CollapsibleArea_Hr">
</div>
</div>
<div class="sectionblock"><a id="remarksToggle"></a>
<p>A&nbsp;<span class="selflink">SqlCeConnection</span>&nbsp;object represents a unique connection to a data source. When you create an instance of<span class="selflink">SqlCeConnection</span>, all properties are set to their initial values. For a list
 of these values, see the&nbsp;<span class="selflink">SqlCeConnection</span>constructor.</p>
<p>If the&nbsp;<span class="selflink">SqlCeConnection</span>&nbsp;goes out of scope, it is not closed. You must explicitly close the connection by calling&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.data.sqlserverce.sqlceconnection.close(v=vs.100).aspx">Close</a>&nbsp;or<a href="http://msdn.microsoft.com/en-us/library/system.data.sqlserverce.sqlceconnection.dispose(v=vs.100).aspx">Dispose</a>.</p>
<p>SQL Server Compact&nbsp;supports multiple simultaneous connections as well as multiple commands that share the same connection. This means that you can have multiple instances of&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.data.sqlserverce.sqlcedatareader(v=vs.100).aspx">SqlCeDataReader</a>&nbsp;open
 on the same connection. This behavior differs from that of&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.data.sqlclient(v=vs.100).aspx">System.Data.SqlClient</a>.</p>
<p>If a fatal&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.data.sqlserverce.sqlceexception(v=vs.100).aspx">SqlCeException</a>&nbsp;is generated by the method executing a&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.data.sqlserverce.sqlcecommand(v=vs.100).aspx">SqlCeCommand</a>,
 the&nbsp;<span class="selflink">SqlCeConnection</span>&nbsp;may be closed. You can reopen the connection and continue.</p>
</div>
</div>
<div>
<div class="LW_CollapsibleArea_TitleDiv"><a class="LW_CollapsibleArea_TitleAhref" title="Click to collapse. Double-click to collapse all."><span class="LW_CollapsibleArea_Title">Examples</span></a>
<div class="LW_CollapsibleArea_HrDiv">
<hr class="LW_CollapsibleArea_Hr">
</div>
</div>
<div class="sectionblock"><a id="exampleToggle"></a>
<p>The following example creates a&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.data.sqlserverce.sqlcecommand(v=vs.100).aspx">SqlCeCommand</a>&nbsp;and a&nbsp;<span class="selflink">SqlCeConnection</span>. The&nbsp;<span class="selflink">SqlCeConnection</span>&nbsp;is
 opened and set as the<a href="http://msdn.microsoft.com/en-us/library/system.data.sqlserverce.sqlcecommand.connection(v=vs.100).aspx">Connection</a>&nbsp;for the&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.data.sqlserverce.sqlcecommand(v=vs.100).aspx">SqlCeCommand</a>.
 The example then calls&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.data.sqlserverce.sqlcecommand.executenonquery(v=vs.100).aspx">ExecuteNonQuery</a>&nbsp;and closes the connection.</p>
<div id="snippetGroup">
<div class="codeSnippetContainer" id="code-snippet-2">
<div class="codeSnippetContainerTabs">
<div class="codeSnippetContainerTab" dir="ltr"><a href="http://msdn.microsoft.com/en-us/library/system.data.sqlserverce.sqlceconnection(v=vs.100).aspx?cs-save-lang=1&cs-lang=csharp#code-snippet-2">C#</a></div>
<div class="codeSnippetContainerTabActive" dir="ltr"><a>VB</a></div>
</div>
<div class="codeSnippetContainerCodeContainer">
<div class="codeSnippetToolBar">
<div class="codeSnippetToolBarText"></div>
</div>
<div class="codeSnippetContainerCode" dir="ltr" id="CodeSnippetContainerCode_ef3ba1eb-2399-4470-9102-70b51f7a4e99">
<div>
<pre><span>Dim</span> conn <span>As</span> SqlCeConnection = <span>Nothing</span>

<span>Try</span>
    conn = <span>New</span> SqlCeConnection(<span>&quot;Data Source = MyDatabase.sdf; Password ='&lt;pwd&gt;'&quot;</span>)
    conn.Open()

    <span>Dim</span> cmd <span>As</span> SqlCeCommand = conn.CreateCommand()
    cmd.CommandText = <span>&quot;INSERT INTO Customers ([Customer ID], [Company Name]) Values('NWIND', 'Northwind Traders')&quot;</span>

    cmd.ExecuteNonQuery()
<span>Finally</span>
    conn.Close()
<span>End</span> <span>Try</span>


</pre>
</div>
</div>
</div>
</div>
</div>
</div>
</div>
<div>
<div class="LW_CollapsibleArea_TitleDiv"><a class="LW_CollapsibleArea_TitleAhref" title="Click to collapse. Double-click to collapse all."><span class="LW_CollapsibleArea_Title">Thread Safety</span></a>
<div class="LW_CollapsibleArea_HrDiv">
<hr class="LW_CollapsibleArea_Hr">
</div>
</div>
<div class="sectionblock"><a id="threadSafetyToggle"></a>Any public static (Shared in Microsoft Visual Basic) members of this type are thread safe. Any instance members are not guaranteed to be thread safe.</div>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Option</span>&nbsp;Explicit&nbsp;<span class="visualBasic__keyword">On</span>&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Data.SqlServerCe&nbsp;
&nbsp;
<span class="visualBasic__keyword">Module</span>&nbsp;Module1&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;Conn&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;SqlCeConnection(<span class="visualBasic__string">&quot;Data&nbsp;Source=&quot;</span>&nbsp;&amp;&nbsp;AppPath()&nbsp;&amp;&nbsp;<span class="visualBasic__string">&quot;\Database1.sdf&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;sqlCeCmd&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;SqlCeCommand&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;sqlCeda&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;SqlCeDataAdapter&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;sqlCeds&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;DataSet&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;sqlCedr&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;SqlCeDataReader&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;AppPath()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;System.AppDomain.CurrentDomain.BaseDirectory&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;ConnectTable(<span class="visualBasic__keyword">ByVal</span>&nbsp;strSql&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;strTableName&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;dataGrid&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;DataGridView)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sqlCeds.Clear()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sqlCeCmd&nbsp;=&nbsp;Conn.CreateCommand&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sqlCeCmd.CommandText&nbsp;=&nbsp;strSql&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sqlCeCmd.Connection&nbsp;=&nbsp;Conn&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Conn.Open()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sqlCeda&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;SqlCeDataAdapter(sqlCeCmd)&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sqlCeda.Fill(sqlCeds,&nbsp;strTableName)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dataGrid.DataSource&nbsp;=&nbsp;sqlCeds&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dataGrid.DataMember&nbsp;=&nbsp;strTableName&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Conn.Close()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Module</span></pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>source code file name #1 - summary for this source code file.</em> </li></ul>
