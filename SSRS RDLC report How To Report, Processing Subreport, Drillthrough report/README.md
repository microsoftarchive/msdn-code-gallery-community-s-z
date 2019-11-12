# SSRS RDLC report How To: Report, Processing Subreport, Drillthrough report.
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- SSRS
- RDLC
- System.Data.Common
- SQLiteFactory
- DbProviderFactories
- Processing Subreport
- Drillthrough report
## Topics
- System.Data.Common
- SQLiteFactory
- Processing Subreport
- Drillthrough report
- SSRS RDLC
## Updated
- 01/14/2017
## Description

<h1>Introduction</h1>
<p><span style="background-color:#ffff00"><strong>Working template (you will not find here detail instruction how to build rdlc file).</strong></span></p>
<p>SSRS RDLC reports How To: Report, Processing Subreport, Drillthrough report.</p>
<p>How to<strong> open rdlc</strong> report with - report viewer.</p>
<p>How to manage <strong>multiple </strong>subreports (see code)</p>
<p>How to <strong>processing subrepor</strong>t.</p>
<p>How to drill<strong> through report</strong>.&nbsp;&nbsp;</p>
<p>How&nbsp;to&nbsp;manage <strong>multiple </strong><strong>drillthrough report</strong>&nbsp; (see code)</p>
<p>How to&nbsp;<strong><a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Data.Common.aspx" target="_blank" title="Auto generated link to System.Data.Common">System.Data.Common</a></strong></p>
<p>Completely working web application - please see&nbsp;<strong>More Information</strong><strong>&nbsp;</strong>on the bottom<strong>&nbsp;(In order to use the SQLiteFactory and have the SQLite data provider enumerated in the DbProviderFactories methods)</strong></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>RDLC - design view&nbsp;</p>
<p><img id="166769" src="166769-mainrdlcreport.png" alt="" width="700" height="270"></p>
<p><strong>Report on web page</strong></p>
<p><img id="166770" src="166770-reportitself.png" alt="" width="700" height="370"></p>
<p>&nbsp;</p>
<p><strong>Drillthrough repor</strong></p>
<p>&nbsp;</p>
<p><img id="166771" src="166771-drill.png" alt="" width="350" height="270"></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">Imports&nbsp;Microsoft.Reporting.WebForms&nbsp;
Imports&nbsp;System.Data.Common&nbsp;
&nbsp;
Public&nbsp;Class&nbsp;Report&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Inherits&nbsp;System.Web.UI.Page&nbsp;
&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Private&nbsp;Const&nbsp;strCustomerID&nbsp;As&nbsp;String&nbsp;=&nbsp;<span class="cs__string">&quot;SELECT&nbsp;&quot;</span><span class="cs__string">&quot;CustomerID&quot;</span><span class="cs__string">&quot;,&nbsp;&quot;</span><span class="cs__string">&quot;CompanyName&quot;</span><span class="cs__string">&quot;,&nbsp;&quot;</span><span class="cs__string">&quot;ContactName&quot;</span><span class="cs__string">&quot;,&nbsp;&quot;</span><span class="cs__string">&quot;ContactTitle&quot;</span><span class="cs__string">&quot;&nbsp;FROM&nbsp;&nbsp;`Customers`&nbsp;&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Private&nbsp;Const&nbsp;strCustomerAddress&nbsp;As&nbsp;String&nbsp;=&nbsp;<span class="cs__string">&quot;SELECT&nbsp;&quot;</span><span class="cs__string">&quot;Address&quot;</span><span class="cs__string">&quot;,&nbsp;&quot;</span><span class="cs__string">&quot;City&quot;</span><span class="cs__string">&quot;,&nbsp;&quot;</span><span class="cs__string">&quot;Region&quot;</span><span class="cs__string">&quot;,&nbsp;&quot;</span><span class="cs__string">&quot;PostalCode&quot;</span><span class="cs__string">&quot;,&nbsp;&quot;</span><span class="cs__string">&quot;Country&quot;</span><span class="cs__string">&quot;,&nbsp;&quot;</span><span class="cs__string">&quot;Phone&quot;</span><span class="cs__string">&quot;,&nbsp;&quot;</span><span class="cs__string">&quot;Fax&quot;</span><span class="cs__string">&quot;&nbsp;FROM&nbsp;&nbsp;`Customers`&nbsp;&quot;</span>&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Private&nbsp;Const&nbsp;strOrderID&nbsp;As&nbsp;String&nbsp;=&nbsp;<span class="cs__string">&quot;SELECT&nbsp;&quot;</span><span class="cs__string">&quot;OrderID&quot;</span><span class="cs__string">&quot;,&nbsp;&quot;</span><span class="cs__string">&quot;CustomerID&quot;</span><span class="cs__string">&quot;,&nbsp;&quot;</span><span class="cs__string">&quot;EmployeeID&quot;</span><span class="cs__string">&quot;,&nbsp;Date(&quot;</span><span class="cs__string">&quot;OrderDate&quot;</span><span class="cs__string">&quot;)&nbsp;AS&nbsp;&quot;</span><span class="cs__string">&quot;OrderDate&quot;</span><span class="cs__string">&quot;,Date(&quot;</span><span class="cs__string">&quot;RequiredDate&quot;</span><span class="cs__string">&quot;)&nbsp;AS&nbsp;&quot;</span><span class="cs__string">&quot;RequiredDate&quot;</span><span class="cs__string">&quot;&nbsp;,&nbsp;DATE(&quot;</span><span class="cs__string">&quot;ShippedDate&quot;</span><span class="cs__string">&quot;)&nbsp;AS&nbsp;&quot;</span><span class="cs__string">&quot;ShippedDate&quot;</span><span class="cs__string">&quot;,&nbsp;&quot;</span><span class="cs__string">&quot;ShipVia&quot;</span><span class="cs__string">&quot;,&nbsp;&quot;</span><span class="cs__string">&quot;Freight&quot;</span><span class="cs__string">&quot;,&nbsp;&quot;</span><span class="cs__string">&quot;ShipName&quot;</span><span class="cs__string">&quot;,&nbsp;&quot;</span><span class="cs__string">&quot;ShipAddress&quot;</span><span class="cs__string">&quot;,&nbsp;&quot;</span><span class="cs__string">&quot;ShipCity&quot;</span><span class="cs__string">&quot;,&nbsp;&quot;</span><span class="cs__string">&quot;ShipRegion&quot;</span><span class="cs__string">&quot;,&nbsp;&quot;</span><span class="cs__string">&quot;ShipPostalCode&quot;</span><span class="cs__string">&quot;,&nbsp;&quot;</span><span class="cs__string">&quot;ShipCountry&quot;</span><span class="cs__string">&quot;&nbsp;FROM&nbsp;`Orders`&nbsp;&nbsp;&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Private&nbsp;strConnection&nbsp;=&nbsp;<span class="cs__string">&quot;Data&nbsp;Source=&quot;</span>&nbsp;&#43;&nbsp;AppDomain.CurrentDomain.BaseDirectory.ToString()&nbsp;&#43;&nbsp;<span class="cs__string">&quot;Northwind.sl3&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Private&nbsp;strError&nbsp;As&nbsp;String&nbsp;=&nbsp;<span class="cs__string">&quot;&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Private&nbsp;dc&nbsp;As&nbsp;New&nbsp;DataCommon&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Private&nbsp;cmd&nbsp;As&nbsp;DbCommand&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Protected&nbsp;Sub&nbsp;Page_Load(ByVal&nbsp;sender&nbsp;As&nbsp;Object,&nbsp;ByVal&nbsp;e&nbsp;As&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.EventArgs.aspx" target="_blank" title="Auto generated link to System.EventArgs">System.EventArgs</a>)&nbsp;Handles&nbsp;Me.Load&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;If&nbsp;Not&nbsp;Page.IsPostBack&nbsp;Then&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;If&nbsp;InitDataBase()&nbsp;Then&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LoadReport()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Else&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Alert(<span class="cs__string">&quot;Data&nbsp;Base&nbsp;does&nbsp;not&nbsp;Exist.&nbsp;\nPlease&nbsp;verify&nbsp;Name/location!&nbsp;\nOr&nbsp;install&nbsp;SQLite&nbsp;provider!&nbsp;&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;If&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;If&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Sub&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;'Private&nbsp;Const&nbsp;strMaster&nbsp;=&nbsp;<span class="cs__string">&quot;SELECT&nbsp;*&nbsp;FROM&nbsp;sqlite_master&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;'For&nbsp;Debug&nbsp;purpose&nbsp;added&nbsp;SHEMA&nbsp;-&nbsp;please&nbsp;make&nbsp;sure&nbsp;that&nbsp;you&nbsp;use&nbsp;existed&nbsp;database&nbsp;....&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;'Dim&nbsp;dtMaster&nbsp;As&nbsp;DataTable&nbsp;=&nbsp;db.FindDataSet(New&nbsp;StringBuilder(strMaster),&nbsp;strConnection).Tables(<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Protected&nbsp;Function&nbsp;InitDataBase()&nbsp;As&nbsp;Boolean&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Try&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dc&nbsp;=&nbsp;New&nbsp;DataCommon&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dc.connectionString&nbsp;=&nbsp;strConnection&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cmd&nbsp;=&nbsp;dc.commandDB&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Return&nbsp;True&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Catch&nbsp;ex&nbsp;As&nbsp;Exception&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Return&nbsp;False&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Try&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Function&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;'How&nbsp;To&nbsp;Report&nbsp;itself&nbsp;-&nbsp;http:<span class="cs__com">//rohit-developer.blogspot.com/2015/02/sub-report-in-rdlc-report-viewer.html</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;'http:<span class="cs__com">//stackoverflow.com/questions/456982/microsoft-reporting-setting-subreport-parameters-in-code</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;'https:<span class="cs__com">//blogs.msdn.microsoft.com/sqlforum/2011/01/02/walkthrough-add-a-subreport-in-local-report-in-reportviewer/</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;'How&nbsp;to&nbsp;Run&nbsp;Subreport&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;'https:<span class="cs__com">//msdn.microsoft.com/en-us/library/microsoft.reporting.webforms.localreport.subreportprocessing.aspx?cs-save-lang=1&amp;cs-lang=vb#code-snippet-1</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Private&nbsp;Sub&nbsp;LoadReport()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitDataBase()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cmd.CommandText&nbsp;=&nbsp;strCustomerID&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;dtCustomer&nbsp;As&nbsp;DataTable&nbsp;=&nbsp;dc.GetDataSet(cmd).Tables(<span class="cs__number">0</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;warnings&nbsp;As&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/Microsoft.Reporting.WebForms.Warning.aspx" target="_blank" title="Auto generated link to Microsoft.Reporting.WebForms.Warning">Microsoft.Reporting.WebForms.Warning</a>()&nbsp;=&nbsp;Nothing&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;streamIds&nbsp;As&nbsp;String()&nbsp;=&nbsp;Nothing&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;mimeType&nbsp;As&nbsp;String&nbsp;=&nbsp;String.Empty&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;encoding&nbsp;As&nbsp;String&nbsp;=&nbsp;String.Empty&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;extension&nbsp;As&nbsp;String&nbsp;=&nbsp;String.Empty&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'&nbsp;ActivityCodeDescriptions.rdlc&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;reportPath&nbsp;As&nbsp;String&nbsp;=&nbsp;AppDomain.CurrentDomain.BaseDirectory.ToString()&nbsp;&#43;&nbsp;<span class="cs__string">&quot;Rdls\ReportCustomers.rdlc&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'<span class="cs__com">//Create&nbsp;MS&nbsp;Report&nbsp;object</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rv.Reset()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rv.LocalReport.ReportPath&nbsp;=&nbsp;reportPath&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rv.ProcessingMode&nbsp;=&nbsp;ProcessingMode.Local&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rv.LocalReport.SetBasePermissionsForSandboxAppDomain(New&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Security.PermissionSet.aspx" target="_blank" title="Auto generated link to System.Security.PermissionSet">System.Security.PermissionSet</a>(System.Security.Permissions.PermissionState.Unrestricted))&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rv.LocalReport.DataSources.Clear()&nbsp;&nbsp;&nbsp;'&nbsp;MUST&nbsp;CLEAR&nbsp;DATA&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rv.LocalReport.DataSources.Add(New&nbsp;ReportDataSource(<span class="cs__string">&quot;dtCustomer&quot;</span>,&nbsp;dtCustomer))&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;param&nbsp;As&nbsp;List(Of&nbsp;ReportParameter)&nbsp;=&nbsp;New&nbsp;List(Of&nbsp;ReportParameter)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;param.Add(New&nbsp;ReportParameter(<span class="cs__string">&quot;pNameReport&quot;</span>,&nbsp;<span class="cs__string">&quot;Customer&nbsp;Report&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rv.LocalReport.SetParameters(param)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rv.AsyncRendering&nbsp;=&nbsp;True&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rv.DataBind()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'Process&nbsp;subreport(s)&nbsp;which&nbsp;you&nbsp;include&nbsp;<span class="cs__keyword">in</span>&nbsp;main&nbsp;report&nbsp;(from&nbsp;ToolBox)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AddHandler&nbsp;rv.LocalReport.SubreportProcessing,&nbsp;AddressOf&nbsp;SubreportProcessingEventHandler&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rv.LocalReport.Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rv.Visible&nbsp;=&nbsp;True&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Sub&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;'Process&nbsp;subreport(s)&nbsp;which&nbsp;you&nbsp;include&nbsp;<span class="cs__keyword">in</span>&nbsp;main&nbsp;report&nbsp;(from&nbsp;ToolBox)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Public&nbsp;Sub&nbsp;SubreportProcessingEventHandler(ByVal&nbsp;sender&nbsp;As&nbsp;Object,&nbsp;ByVal&nbsp;e&nbsp;As&nbsp;SubreportProcessingEventArgs)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;infoParam&nbsp;As&nbsp;ReportParameterInfoCollection&nbsp;=&nbsp;e.Parameters()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;strCaseId&nbsp;As&nbsp;String&nbsp;=&nbsp;infoParam.First.Values(<span class="cs__number">0</span>).ToString()&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Select&nbsp;Case&nbsp;e.ReportPath&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Case&nbsp;<span class="cs__string">&quot;subreport1&quot;</span>&nbsp;&nbsp;&nbsp;&nbsp;'&nbsp;&nbsp;just&nbsp;example&nbsp;-&nbsp;how&nbsp;to&nbsp;manage&nbsp;multiply&nbsp;subreports&nbsp;...&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Case&nbsp;<span class="cs__string">&quot;ReportCustomersAddress&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cmd.CommandText&nbsp;=&nbsp;strCustomerAddress&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;where&nbsp;&quot;</span><span class="cs__string">&quot;CustomerID&quot;</span><span class="cs__string">&quot;&nbsp;=&nbsp;'&quot;</span>&nbsp;&#43;&nbsp;strCaseId&nbsp;&#43;&nbsp;<span class="cs__string">&quot;'&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;dtCustomersAddress&nbsp;As&nbsp;DataTable&nbsp;=&nbsp;dc.GetDataSet(cmd).Tables(<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.DataSources.Add(New&nbsp;ReportDataSource(<span class="cs__string">&quot;dtCustomersAddress&quot;</span>,&nbsp;dtCustomersAddress))&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Case&nbsp;<span class="cs__string">&quot;subreport3&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Select&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Sub&nbsp;
&nbsp;
&nbsp;
&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Protected&nbsp;Sub&nbsp;Alert(ByVal&nbsp;message&nbsp;As&nbsp;String)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;sb&nbsp;As&nbsp;New&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Text.StringBuilder.aspx" target="_blank" title="Auto generated link to System.Text.StringBuilder">System.Text.StringBuilder</a>()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sb.Append(<span class="cs__string">&quot;&lt;script&nbsp;type&nbsp;=&nbsp;'text/javascript'&gt;&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sb.Append(<span class="cs__string">&quot;window.onload=function(){&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sb.Append(<span class="cs__string">&quot;alert('&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sb.Append(message)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sb.Append(<span class="cs__string">&quot;')};&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sb.Append(<span class="cs__string">&quot;&lt;/script&gt;&quot;</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ClientScript.RegisterClientScriptBlock(Me.GetType(),&nbsp;<span class="cs__string">&quot;alert&quot;</span>,&nbsp;sb.ToString())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Sub&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;'https:<span class="cs__com">//msdn.microsoft.com/en-us/library/dn154769.aspx</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Protected&nbsp;Sub&nbsp;rv_Drillthrough(sender&nbsp;As&nbsp;Object,&nbsp;e&nbsp;As&nbsp;DrillthroughEventArgs)&nbsp;Handles&nbsp;rv.Drillthrough&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'Get&nbsp;the&nbsp;instance&nbsp;of&nbsp;the&nbsp;Target&nbsp;report.&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Select&nbsp;Case&nbsp;e.ReportPath&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Case&nbsp;<span class="cs__string">&quot;subreport1&quot;</span>&nbsp;&nbsp;&nbsp;&nbsp;'&nbsp;&nbsp;just&nbsp;example&nbsp;-&nbsp;how&nbsp;to&nbsp;manage&nbsp;multiply&nbsp;subreports&nbsp;...&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Case&nbsp;<span class="cs__string">&quot;ReportOrder&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;report&nbsp;As&nbsp;LocalReport&nbsp;=&nbsp;e.Report&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;list&nbsp;As&nbsp;IList(Of&nbsp;ReportParameter)&nbsp;=&nbsp;report.OriginalParametersToDrillthrough&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;strCaseId&nbsp;As&nbsp;String&nbsp;=&nbsp;list.Item(<span class="cs__number">0</span>).Values(<span class="cs__number">0</span>).ToString&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitDataBase()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cmd.CommandText&nbsp;=&nbsp;strOrderID&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;where&nbsp;&quot;</span><span class="cs__string">&quot;CustomerID&quot;</span><span class="cs__string">&quot;&nbsp;=&nbsp;'&quot;</span>&nbsp;&#43;&nbsp;strCaseId&nbsp;&#43;&nbsp;<span class="cs__string">&quot;'&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;dtOrders&nbsp;As&nbsp;DataTable&nbsp;=&nbsp;dc.GetDataSet(cmd).Tables(<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;report.DataSources.Add(New&nbsp;ReportDataSource(<span class="cs__string">&quot;dtOrders&quot;</span>,&nbsp;dtOrders))&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Case&nbsp;<span class="cs__string">&quot;subreport3&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Select&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Sub&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Protected&nbsp;Sub&nbsp;btnMainReport_Click(sender&nbsp;As&nbsp;Object,&nbsp;e&nbsp;As&nbsp;EventArgs)&nbsp;Handles&nbsp;btnMainReport.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LoadReport()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Sub&nbsp;
End&nbsp;Class</pre>
</div>
</div>
</div>
<ul>
</ul>
<h1>More Information</h1>
<p>This example uses SQLite database &ldquo;Northwind.sl3&rdquo;</p>
<p>So for work this sample please install on your PC SQLite provider <a href="https://system.data.sqlite.org/index.html/doc/trunk/www/downloads.wiki">
https://system.data.sqlite.org/index.html/doc/trunk/www/downloads.wiki</a></p>
<p>(Use setup file it install System.Data.SQLite to assembly)</p>
<p>I recommend install x86 and x64 version &ndash; just choose right Net Framework for you.</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>In order to use the SQLiteFactory and have the SQLite data provider enumerated in the DbProviderFactories methods, you must add the following segment into your application's app.config file:</p>
<p>&lt;configuration&gt;</p>
<p>&nbsp;&nbsp;&nbsp; &lt;system.data&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;DbProviderFactories&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;remove invariant=&quot;System.Data.SQLite&quot; /&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;add name=&quot;SQLite Data Provider&quot; invariant=&quot;System.Data.SQLite&quot; description=&quot;.NET Framework Data Provider for SQLite&quot;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; type=&quot;System.Data.SQLite.SQLiteFactory, System.Data.SQLite, Version=1.0.104.0, Culture=neutral, PublicKeyToken=db937bc2d44ff139&quot; /&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/DbProviderFactories&gt;</p>
<p>&nbsp;&nbsp;&nbsp; &lt;/system.data&gt;</p>
<p>&lt;/configuration&gt;</p>
<p>See the help documentation for further details on implementing both version-specific (GAC enabled) and version independent DBProviderFactories support.&nbsp;</p>
<div class="mcePaste" id="_mcePaste" style="left:-10000px; top:0px; width:1px; height:1px; overflow:hidden">
</div>
