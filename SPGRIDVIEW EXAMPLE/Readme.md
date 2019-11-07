# SPGRIDVIEW EXAMPLE
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- SharePoint 2010
## Topics
- SharePoint 2010
## Updated
- 10/30/2014
## Description

<p>Sharepoint has a built-in&nbsp;<code>gridview&nbsp;</code>control, i.e.&nbsp;<code>SPGridView&nbsp;</code>control. It has built-in support for sorting, filtering functionalities when used with an&nbsp;<code>ObjectDataSource</code>, and the look and feel
 is similar if&nbsp;<code>SPGridView&nbsp;</code>control is used. This is the major reason behind&nbsp;<code>SPGridView&nbsp;</code>usage over ASP.NET&nbsp;<code>GridView&nbsp;</code>control.</p>
<p>Below are the functionalities provided with this sample:</p>
<ul>
<li>Creating&nbsp;<code>SPGridview&nbsp;</code>webpart </li><li>Different models of Pagination </li><li>Sorting </li><li>Filtering </li></ul>
<p>&lt;table&gt;</p>
<p>&nbsp;&nbsp;&nbsp; &lt;tr&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;td&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;SharePoint:SPGridView ID=&quot;gvICSSDocuments&quot; runat=&quot;server&quot; AutoGenerateColumns=&quot;false&quot; Width=&quot;850px&quot;&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;RowStyle BackColor=&quot;#D0D8E8&quot; Height=&quot;30px&quot; HorizontalAlign=&quot;Left&quot; /&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;AlternatingRowStyle BackColor=&quot;#E9EDF4&quot; Height=&quot;30px&quot; HorizontalAlign=&quot;Left&quot; /&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;HeaderStyle HorizontalAlign=&quot;Left&quot; CssClass=&quot;ms-viewheadertr&quot; /&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Columns&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:TemplateField HeaderText=&quot;Year&quot; ControlStyle-Width=&quot;100px&quot; SortExpression=&quot;Year&quot; HeaderStyle-CssClass=&quot;ms-viewheadertr&quot;&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ItemTemplate&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:Label ID=&quot;lblCreated&quot; runat=&quot;server&quot; Text='&lt;%# Eval(&quot;Year&quot;) %&gt;'&gt;&lt;/asp:Label&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ItemTemplate&gt;</p>
<p>&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/asp:TemplateField&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:TemplateField HeaderText=&quot;Title&quot; ControlStyle-Width=&quot;250px&quot; SortExpression=&quot;Title&quot; HeaderStyle-CssClass=&quot;ms-viewheadertr&quot;&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ItemTemplate&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:Label ID=&quot;lblTitle&quot; runat=&quot;server&quot; Text='&lt;%# Eval(&quot;Title&quot;) %&gt;'&gt;&lt;/asp:Label&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/ItemTemplate&gt;</p>
<p>&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/asp:TemplateField&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:TemplateField HeaderText=&quot;Description&quot; ControlStyle-Width=&quot;300px&quot; HeaderStyle-HorizontalAlign=&quot;Left&quot; HeaderStyle-CssClass=&quot;ms-viewheadertr&quot;&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ItemTemplate&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:Label ID=&quot;lblDescription&quot; runat=&quot;server&quot; Text='&lt;%# Eval(&quot;Description&quot;) %&gt;'&gt;&lt;/asp:Label&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/ItemTemplate&gt;</p>
<p>&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/asp:TemplateField&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:TemplateField HeaderText=&quot;Attachment&quot; ControlStyle-Width=&quot;200px&quot; SortExpression=&quot;Name&quot; HeaderStyle-CssClass=&quot;ms-viewheadertr&quot;&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ItemTemplate&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:HyperLink ID=&quot;hlnkDocument&quot; runat=&quot;server&quot; Text='&lt;%# Eval(&quot;Name&quot;) %&gt;' NavigateUrl='&lt;%#
 Eval(&quot;Url&quot;) %&gt;'</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Target=&quot;_blank&quot;&gt;&lt;/asp:HyperLink&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/ItemTemplate&gt;</p>
<p>&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/asp:TemplateField&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/Columns&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;EmptyDataTemplate&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:Label ID=&quot;lblNoAccess&quot; Text=&quot;No documents available&quot; runat=&quot;server&quot; CssClass=&quot;emptyDataLabel&quot;&gt;&lt;/asp:Label&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/EmptyDataTemplate&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/SharePoint:SPGridView&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/td&gt;</p>
<p>&nbsp;&nbsp;&nbsp; &lt;/tr&gt;</p>
<p>&lt;/table&gt;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden"> ObjectDataSource gridDS = null;
        /// &lt;summary&gt;
        /// n the Page_Load event we are declaring the GridView Object, its event and Datasource
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
        /// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                const string DATASOURCEID = &quot;gridDS&quot;;
                gridDS = new ObjectDataSource();
                gridDS.ID = DATASOURCEID;

                gridDS.SelectMethod = &quot;SelectData&quot;;
                gridDS.TypeName = this.GetType().AssemblyQualifiedName;
                gridDS.ObjectCreating &#43;= new ObjectDataSourceObjectEventHandler(gridDS_ObjectCreating);

                this.Controls.Add(gridDS);
                BindDocuments();

            }
            catch (Exception ex)
            {
                SPDiagnosticsService diagnosticsService = SPDiagnosticsService.Local;
                SPDiagnosticsCategory cat = diagnosticsService.Areas[&quot;SharePoint Foundation&quot;].Categories[&quot;Unknown&quot;];
                diagnosticsService.WriteTrace(1, cat, TraceSeverity.Medium, ex.StackTrace, cat.Name, cat.Area.Name);
                SPUtility.TransferToErrorPage(&quot;Some Error occured, Please try after some time. &lt;br/&gt; If problem persists, contact your adminstrator&quot;);
            }

        }
        /// &lt;summary&gt;
        /// BindDocuments Method for Binding the objectDataSource to GridView
        /// &lt;/summary&gt;
        private void BindDocuments()
        {
            gvICSSDocuments.AllowPaging = true;

            // Sorting
            gvICSSDocuments.AllowSorting = true;

            //allow Filtering
            gvICSSDocuments.FilterDataFields = &quot;Year,Title,,Name&quot;;
            gvICSSDocuments.FilteredDataSourcePropertyName = &quot;FilterExpression&quot;;
            gvICSSDocuments.FilteredDataSourcePropertyFormat = &quot;{1} = '{0}'&quot;;
            gvICSSDocuments.Sorting &#43;= new GridViewSortEventHandler(gvDocuments_Sorting);
            gvICSSDocuments.PageIndexChanging &#43;= new GridViewPageEventHandler(gvDocuments_PageIndexChanging);
            //For Filtering
            gridDS.Filtering &#43;= new ObjectDataSourceFilteringEventHandler(gridDS_Filtering);
            gvICSSDocuments.AutoGenerateColumns = false;
            gvICSSDocuments.AllowFiltering = true;
            gvICSSDocuments.PagerTemplate = null;
            gvICSSDocuments.PageSize = 10;
            gvICSSDocuments.DataSourceID = gridDS.ID;        
            gvICSSDocuments.DataBind();
        }
        /// &lt;summary&gt;
        /// SelectData Method creates a DataTable from the data fetched from SharePoint List or Doc Library and returns the DataTable
        /// &lt;/summary&gt;
        /// &lt;returns&gt;&lt;/returns&gt;
        public DataTable SelectData()
        {
            DataTable dataSource = new DataTable();
            try
            {
                SPSite site = SPContext.Current.Web.Site;
                SPWeb web = site.OpenWeb();
                SPList lstICSSDocuments = web.Lists[&quot;PhotoList&quot;]; //create document library or List and add column year,Description,Url,Name, Title is inbuilt.
                SPQuery query = new SPQuery();
                IEnumerable&lt;SPListItem&gt; lstItemICSSDocuments = lstICSSDocuments.GetItems(query).OfType&lt;SPListItem&gt;();

                dataSource.Columns.Add(&quot;Year&quot;);
                dataSource.Columns.Add(&quot;Description&quot;);
                dataSource.Columns.Add(&quot;Name&quot;);
                dataSource.Columns.Add(&quot;Title&quot;);
                dataSource.Columns.Add(&quot;Url&quot;);

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    //SPGroup grpName = web.Groups[&quot;ICSSViewers&quot;];
                    var committeeAndGroupDocumentswithURL = lstItemICSSDocuments.Select(x =&gt; new { Year = x[&quot;Year&quot;], Description = x[&quot;Description&quot;], Name = x[&quot;Name&quot;], Title = x[&quot;Title&quot;], Url = site.Url &#43; &quot;/&quot; &#43; x.Url });
                    foreach (var document in committeeAndGroupDocumentswithURL)
                    {
                        DataRow dr = dataSource.NewRow();
                        dr[&quot;Title&quot;] = document.Title;
                        dr[&quot;Url&quot;] = document.Url;
                        dr[&quot;Name&quot;] = document.Name;
                        dr[&quot;Description&quot;] = document.Description;
                        dr[&quot;Year&quot;] = document.Year;
                        dataSource.Rows.Add(dr);
                    }

                });
                web.Dispose();
            }
            catch (Exception ex)
            {
                SPDiagnosticsService diagnosticsService = SPDiagnosticsService.Local;
                SPDiagnosticsCategory cat = diagnosticsService.Areas[&quot;SharePoint Foundation&quot;].Categories[&quot;Unknown&quot;];
                diagnosticsService.WriteTrace(1, cat, TraceSeverity.Medium, ex.StackTrace, cat.Name, cat.Area.Name);
                SPUtility.TransferToErrorPage(&quot;Some Error occured, Please try after some time. &lt;br/&gt; If problem persists, contact your adminstrator&quot;);
            }
            return dataSource;
        }
        /// &lt;summary&gt;
        /// The Sorting, Filtering, PageChanging etc are all handled similar to normal asp.net gridviews
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
        /// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
        void gridDS_ObjectCreating(object sender, ObjectDataSourceEventArgs e)
        {
            e.ObjectInstance = this;
        }
        void gvDocuments_Sorting(object sender, GridViewSortEventArgs e)
        {
            string lastExpression = &quot;&quot;;
            if (ViewState[&quot;SortExpression&quot;] != null)
                lastExpression = ViewState[&quot;SortExpression&quot;].ToString();

            string lastDirection = &quot;asc&quot;;
            if (ViewState[&quot;SortDirection&quot;] != null)
                lastDirection = ViewState[&quot;SortDirection&quot;].ToString();

            string newDirection = string.Empty;
            if (e.SortExpression == lastExpression)
            {
                e.SortDirection = (lastDirection == &quot;asc&quot;) ? System.Web.UI.WebControls.SortDirection.Descending : System.Web.UI.WebControls.SortDirection.Ascending;

            }

            newDirection = (e.SortDirection == System.Web.UI.WebControls.SortDirection.Descending) ? &quot;desc&quot; : &quot;asc&quot;;
            ViewState[&quot;SortExpression&quot;] = e.SortExpression;
            ViewState[&quot;SortDirection&quot;] = newDirection;

            gvICSSDocuments.DataBind();
            //For Filter
            if (ViewState[&quot;FilterExpression&quot;] != null)
            {
                gridDS.FilterExpression = (string)ViewState[&quot;FilterExpression&quot;];
            }

        }

        void gvDocuments_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvICSSDocuments.PageIndex = e.NewPageIndex;
            gvICSSDocuments.DataSourceID = gridDS.ID;
            gvICSSDocuments.DataBind();
        }
        //For Filtering
        private void gridDS_Filtering(object sender, ObjectDataSourceFilteringEventArgs e)
        {
            ViewState[&quot;FilterExpression&quot;] = ((ObjectDataSourceView)sender).FilterExpression;
        }
        protected sealed override void LoadViewState(object savedState)
        {
            base.LoadViewState(savedState);

            if (Context.Request.Form[&quot;__EVENTARGUMENT&quot;] != null &amp;&amp;
                 Context.Request.Form[&quot;__EVENTARGUMENT&quot;].EndsWith(&quot;__ClearFilter__&quot;))
            {
                // Clear FilterExpression
                ViewState.Remove(&quot;FilterExpression&quot;);
            }
        }</pre>
<div class="preview">
<pre class="js">&nbsp;ObjectDataSource&nbsp;gridDS&nbsp;=&nbsp;null;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;n&nbsp;the&nbsp;Page_Load&nbsp;event&nbsp;we&nbsp;are&nbsp;declaring&nbsp;the&nbsp;GridView&nbsp;Object,&nbsp;its&nbsp;event&nbsp;and&nbsp;Datasource</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;param&nbsp;name=&quot;sender&quot;&gt;&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;param&nbsp;name=&quot;e&quot;&gt;&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;protected&nbsp;<span class="js__operator">void</span>&nbsp;Page_Load(object&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">const</span>&nbsp;string&nbsp;DATASOURCEID&nbsp;=&nbsp;<span class="js__string">&quot;gridDS&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gridDS&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;ObjectDataSource();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gridDS.ID&nbsp;=&nbsp;DATASOURCEID;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gridDS.SelectMethod&nbsp;=&nbsp;<span class="js__string">&quot;SelectData&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gridDS.TypeName&nbsp;=&nbsp;<span class="js__operator">this</span>.GetType().AssemblyQualifiedName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gridDS.ObjectCreating&nbsp;&#43;=&nbsp;<span class="js__operator">new</span>&nbsp;ObjectDataSourceObjectEventHandler(gridDS_ObjectCreating);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.Controls.Add(gridDS);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BindDocuments();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">catch</span>&nbsp;(Exception&nbsp;ex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SPDiagnosticsService&nbsp;diagnosticsService&nbsp;=&nbsp;SPDiagnosticsService.Local;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SPDiagnosticsCategory&nbsp;cat&nbsp;=&nbsp;diagnosticsService.Areas[<span class="js__string">&quot;SharePoint&nbsp;Foundation&quot;</span>].Categories[<span class="js__string">&quot;Unknown&quot;</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;diagnosticsService.WriteTrace(<span class="js__num">1</span>,&nbsp;cat,&nbsp;TraceSeverity.Medium,&nbsp;ex.StackTrace,&nbsp;cat.Name,&nbsp;cat.Area.Name);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SPUtility.TransferToErrorPage(<span class="js__string">&quot;Some&nbsp;Error&nbsp;occured,&nbsp;Please&nbsp;try&nbsp;after&nbsp;some&nbsp;time.&nbsp;&lt;br/&gt;&nbsp;If&nbsp;problem&nbsp;persists,&nbsp;contact&nbsp;your&nbsp;adminstrator&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;BindDocuments&nbsp;Method&nbsp;for&nbsp;Binding&nbsp;the&nbsp;objectDataSource&nbsp;to&nbsp;GridView</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;<span class="js__operator">void</span>&nbsp;BindDocuments()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gvICSSDocuments.AllowPaging&nbsp;=&nbsp;true;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Sorting</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gvICSSDocuments.AllowSorting&nbsp;=&nbsp;true;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//allow&nbsp;Filtering</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gvICSSDocuments.FilterDataFields&nbsp;=&nbsp;<span class="js__string">&quot;Year,Title,,Name&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gvICSSDocuments.FilteredDataSourcePropertyName&nbsp;=&nbsp;<span class="js__string">&quot;FilterExpression&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gvICSSDocuments.FilteredDataSourcePropertyFormat&nbsp;=&nbsp;<span class="js__string">&quot;{1}&nbsp;=&nbsp;'{0}'&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gvICSSDocuments.Sorting&nbsp;&#43;=&nbsp;<span class="js__operator">new</span>&nbsp;GridViewSortEventHandler(gvDocuments_Sorting);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gvICSSDocuments.PageIndexChanging&nbsp;&#43;=&nbsp;<span class="js__operator">new</span>&nbsp;GridViewPageEventHandler(gvDocuments_PageIndexChanging);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//For&nbsp;Filtering</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gridDS.Filtering&nbsp;&#43;=&nbsp;<span class="js__operator">new</span>&nbsp;ObjectDataSourceFilteringEventHandler(gridDS_Filtering);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gvICSSDocuments.AutoGenerateColumns&nbsp;=&nbsp;false;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gvICSSDocuments.AllowFiltering&nbsp;=&nbsp;true;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gvICSSDocuments.PagerTemplate&nbsp;=&nbsp;null;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gvICSSDocuments.PageSize&nbsp;=&nbsp;<span class="js__num">10</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gvICSSDocuments.DataSourceID&nbsp;=&nbsp;gridDS.ID;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gvICSSDocuments.DataBind();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;SelectData&nbsp;Method&nbsp;creates&nbsp;a&nbsp;DataTable&nbsp;from&nbsp;the&nbsp;data&nbsp;fetched&nbsp;from&nbsp;SharePoint&nbsp;List&nbsp;or&nbsp;Doc&nbsp;Library&nbsp;and&nbsp;returns&nbsp;the&nbsp;DataTable</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;returns&gt;&lt;/returns&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;DataTable&nbsp;SelectData()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataTable&nbsp;dataSource&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;DataTable();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SPSite&nbsp;site&nbsp;=&nbsp;SPContext.Current.Web.Site;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SPWeb&nbsp;web&nbsp;=&nbsp;site.OpenWeb();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SPList&nbsp;lstICSSDocuments&nbsp;=&nbsp;web.Lists[<span class="js__string">&quot;PhotoList&quot;</span>];&nbsp;<span class="js__sl_comment">//create&nbsp;document&nbsp;library&nbsp;or&nbsp;List&nbsp;and&nbsp;add&nbsp;column&nbsp;year,Description,Url,Name,&nbsp;Title&nbsp;is&nbsp;inbuilt.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SPQuery&nbsp;query&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;SPQuery();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IEnumerable&lt;SPListItem&gt;&nbsp;lstItemICSSDocuments&nbsp;=&nbsp;lstICSSDocuments.GetItems(query).OfType&lt;SPListItem&gt;();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dataSource.Columns.Add(<span class="js__string">&quot;Year&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dataSource.Columns.Add(<span class="js__string">&quot;Description&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dataSource.Columns.Add(<span class="js__string">&quot;Name&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dataSource.Columns.Add(<span class="js__string">&quot;Title&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dataSource.Columns.Add(<span class="js__string">&quot;Url&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SPSecurity.RunWithElevatedPrivileges(delegate()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//SPGroup&nbsp;grpName&nbsp;=&nbsp;web.Groups[&quot;ICSSViewers&quot;];</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;committeeAndGroupDocumentswithURL&nbsp;=&nbsp;lstItemICSSDocuments.Select(x&nbsp;=&gt;&nbsp;<span class="js__operator">new</span>&nbsp;<span class="js__brace">{</span>&nbsp;Year&nbsp;=&nbsp;x[<span class="js__string">&quot;Year&quot;</span>],&nbsp;Description&nbsp;=&nbsp;x[<span class="js__string">&quot;Description&quot;</span>],&nbsp;Name&nbsp;=&nbsp;x[<span class="js__string">&quot;Name&quot;</span>],&nbsp;Title&nbsp;=&nbsp;x[<span class="js__string">&quot;Title&quot;</span>],&nbsp;Url&nbsp;=&nbsp;site.Url&nbsp;&#43;&nbsp;<span class="js__string">&quot;/&quot;</span>&nbsp;&#43;&nbsp;x.Url&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;foreach&nbsp;(<span class="js__statement">var</span>&nbsp;document&nbsp;<span class="js__operator">in</span>&nbsp;committeeAndGroupDocumentswithURL)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataRow&nbsp;dr&nbsp;=&nbsp;dataSource.NewRow();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dr[<span class="js__string">&quot;Title&quot;</span>]&nbsp;=&nbsp;document.Title;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dr[<span class="js__string">&quot;Url&quot;</span>]&nbsp;=&nbsp;document.Url;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dr[<span class="js__string">&quot;Name&quot;</span>]&nbsp;=&nbsp;document.Name;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dr[<span class="js__string">&quot;Description&quot;</span>]&nbsp;=&nbsp;document.Description;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dr[<span class="js__string">&quot;Year&quot;</span>]&nbsp;=&nbsp;document.Year;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dataSource.Rows.Add(dr);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;web.Dispose();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">catch</span>&nbsp;(Exception&nbsp;ex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SPDiagnosticsService&nbsp;diagnosticsService&nbsp;=&nbsp;SPDiagnosticsService.Local;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SPDiagnosticsCategory&nbsp;cat&nbsp;=&nbsp;diagnosticsService.Areas[<span class="js__string">&quot;SharePoint&nbsp;Foundation&quot;</span>].Categories[<span class="js__string">&quot;Unknown&quot;</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;diagnosticsService.WriteTrace(<span class="js__num">1</span>,&nbsp;cat,&nbsp;TraceSeverity.Medium,&nbsp;ex.StackTrace,&nbsp;cat.Name,&nbsp;cat.Area.Name);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SPUtility.TransferToErrorPage(<span class="js__string">&quot;Some&nbsp;Error&nbsp;occured,&nbsp;Please&nbsp;try&nbsp;after&nbsp;some&nbsp;time.&nbsp;&lt;br/&gt;&nbsp;If&nbsp;problem&nbsp;persists,&nbsp;contact&nbsp;your&nbsp;adminstrator&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;dataSource;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;The&nbsp;Sorting,&nbsp;Filtering,&nbsp;PageChanging&nbsp;etc&nbsp;are&nbsp;all&nbsp;handled&nbsp;similar&nbsp;to&nbsp;normal&nbsp;asp.net&nbsp;gridviews</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;param&nbsp;name=&quot;sender&quot;&gt;&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;param&nbsp;name=&quot;e&quot;&gt;&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">void</span>&nbsp;gridDS_ObjectCreating(object&nbsp;sender,&nbsp;ObjectDataSourceEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.ObjectInstance&nbsp;=&nbsp;<span class="js__operator">this</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">void</span>&nbsp;gvDocuments_Sorting(object&nbsp;sender,&nbsp;GridViewSortEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;lastExpression&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(ViewState[<span class="js__string">&quot;SortExpression&quot;</span>]&nbsp;!=&nbsp;null)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lastExpression&nbsp;=&nbsp;ViewState[<span class="js__string">&quot;SortExpression&quot;</span>].ToString();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;lastDirection&nbsp;=&nbsp;<span class="js__string">&quot;asc&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(ViewState[<span class="js__string">&quot;SortDirection&quot;</span>]&nbsp;!=&nbsp;null)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lastDirection&nbsp;=&nbsp;ViewState[<span class="js__string">&quot;SortDirection&quot;</span>].ToString();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;newDirection&nbsp;=&nbsp;string.Empty;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(e.SortExpression&nbsp;==&nbsp;lastExpression)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.SortDirection&nbsp;=&nbsp;(lastDirection&nbsp;==&nbsp;<span class="js__string">&quot;asc&quot;</span>)&nbsp;?&nbsp;System.Web.UI.WebControls.SortDirection.Descending&nbsp;:&nbsp;System.Web.UI.WebControls.SortDirection.Ascending;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newDirection&nbsp;=&nbsp;(e.SortDirection&nbsp;==&nbsp;System.Web.UI.WebControls.SortDirection.Descending)&nbsp;?&nbsp;<span class="js__string">&quot;desc&quot;</span>&nbsp;:&nbsp;<span class="js__string">&quot;asc&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ViewState[<span class="js__string">&quot;SortExpression&quot;</span>]&nbsp;=&nbsp;e.SortExpression;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ViewState[<span class="js__string">&quot;SortDirection&quot;</span>]&nbsp;=&nbsp;newDirection;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gvICSSDocuments.DataBind();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//For&nbsp;Filter</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(ViewState[<span class="js__string">&quot;FilterExpression&quot;</span>]&nbsp;!=&nbsp;null)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gridDS.FilterExpression&nbsp;=&nbsp;(string)ViewState[<span class="js__string">&quot;FilterExpression&quot;</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">void</span>&nbsp;gvDocuments_PageIndexChanging(object&nbsp;sender,&nbsp;GridViewPageEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gvICSSDocuments.PageIndex&nbsp;=&nbsp;e.NewPageIndex;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gvICSSDocuments.DataSourceID&nbsp;=&nbsp;gridDS.ID;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gvICSSDocuments.DataBind();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//For&nbsp;Filtering</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;<span class="js__operator">void</span>&nbsp;gridDS_Filtering(object&nbsp;sender,&nbsp;ObjectDataSourceFilteringEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ViewState[<span class="js__string">&quot;FilterExpression&quot;</span>]&nbsp;=&nbsp;((ObjectDataSourceView)sender).FilterExpression;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;protected&nbsp;sealed&nbsp;override&nbsp;<span class="js__operator">void</span>&nbsp;LoadViewState(object&nbsp;savedState)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;base.LoadViewState(savedState);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(Context.Request.Form[<span class="js__string">&quot;__EVENTARGUMENT&quot;</span>]&nbsp;!=&nbsp;null&nbsp;&amp;&amp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Context.Request.Form[<span class="js__string">&quot;__EVENTARGUMENT&quot;</span>].EndsWith(<span class="js__string">&quot;__ClearFilter__&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Clear&nbsp;FilterExpression</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ViewState.Remove(<span class="js__string">&quot;FilterExpression&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
