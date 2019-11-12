using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Linq;
namespace SharePoint2013.LabExamples.SPGridViewWP
{
    public partial class SPGridViewWPUserControl : UserControl
    {
       

        ObjectDataSource gridDS = null;
        /// <summary>
        /// n the Page_Load event we are declaring the GridView Object, its event and Datasource
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                const string DATASOURCEID = "gridDS";
                gridDS = new ObjectDataSource();
                gridDS.ID = DATASOURCEID;

                gridDS.SelectMethod = "SelectData";
                gridDS.TypeName = this.GetType().AssemblyQualifiedName;
                gridDS.ObjectCreating += new ObjectDataSourceObjectEventHandler(gridDS_ObjectCreating);

                this.Controls.Add(gridDS);
                BindDocuments();

            }
            catch (Exception ex)
            {
                SPDiagnosticsService diagnosticsService = SPDiagnosticsService.Local;
                SPDiagnosticsCategory cat = diagnosticsService.Areas["SharePoint Foundation"].Categories["Unknown"];
                diagnosticsService.WriteTrace(1, cat, TraceSeverity.Medium, ex.StackTrace, cat.Name, cat.Area.Name);
                SPUtility.TransferToErrorPage("Some Error occured, Please try after some time. <br/> If problem persists, contact your adminstrator");
            }

        }
        /// <summary>
        /// BindDocuments Method for Binding the objectDataSource to GridView
        /// </summary>
        private void BindDocuments()
        {
            gvICSSDocuments.AllowPaging = true;

            // Sorting
            gvICSSDocuments.AllowSorting = true;

            //allow Filtering
            gvICSSDocuments.FilterDataFields = "Year,Title,,Name";
            gvICSSDocuments.FilteredDataSourcePropertyName = "FilterExpression";
            gvICSSDocuments.FilteredDataSourcePropertyFormat = "{1} = '{0}'";
            gvICSSDocuments.Sorting += new GridViewSortEventHandler(gvDocuments_Sorting);
            gvICSSDocuments.PageIndexChanging += new GridViewPageEventHandler(gvDocuments_PageIndexChanging);
            //For Filtering
            gridDS.Filtering += new ObjectDataSourceFilteringEventHandler(gridDS_Filtering);
            gvICSSDocuments.AutoGenerateColumns = false;
            gvICSSDocuments.AllowFiltering = true;
            gvICSSDocuments.PagerTemplate = null;
            gvICSSDocuments.PageSize = 10;
            gvICSSDocuments.DataSourceID = gridDS.ID;        
            gvICSSDocuments.DataBind();
        }
        /// <summary>
        /// SelectData Method creates a DataTable from the data fetched from SharePoint List or Doc Library and returns the DataTable
        /// </summary>
        /// <returns></returns>
        public DataTable SelectData()
        {
            DataTable dataSource = new DataTable();
            try
            {
                SPSite site = SPContext.Current.Web.Site;
                SPWeb web = site.OpenWeb();
                SPList lstICSSDocuments = web.Lists["PhotoList"]; //create document library or List and add column year,Description,Url,Name, Title is inbuilt.
                SPQuery query = new SPQuery();
                IEnumerable<SPListItem> lstItemICSSDocuments = lstICSSDocuments.GetItems(query).OfType<SPListItem>();

                dataSource.Columns.Add("Year");
                dataSource.Columns.Add("Description");
                dataSource.Columns.Add("Name");
                dataSource.Columns.Add("Title");
                dataSource.Columns.Add("Url");

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    //SPGroup grpName = web.Groups["ICSSViewers"];
                    var committeeAndGroupDocumentswithURL = lstItemICSSDocuments.Select(x => new { Year = x["Year"], Description = x["Description"], Name = x["Name"], Title = x["Title"], Url = site.Url + "/" + x.Url });
                    foreach (var document in committeeAndGroupDocumentswithURL)
                    {
                        DataRow dr = dataSource.NewRow();
                        dr["Title"] = document.Title;
                        dr["Url"] = document.Url;
                        dr["Name"] = document.Name;
                        dr["Description"] = document.Description;
                        dr["Year"] = document.Year;
                        dataSource.Rows.Add(dr);
                    }

                });
                web.Dispose();
            }
            catch (Exception ex)
            {
                SPDiagnosticsService diagnosticsService = SPDiagnosticsService.Local;
                SPDiagnosticsCategory cat = diagnosticsService.Areas["SharePoint Foundation"].Categories["Unknown"];
                diagnosticsService.WriteTrace(1, cat, TraceSeverity.Medium, ex.StackTrace, cat.Name, cat.Area.Name);
                SPUtility.TransferToErrorPage("Some Error occured, Please try after some time. <br/> If problem persists, contact your adminstrator");
            }
            return dataSource;
        }
        /// <summary>
        /// The Sorting, Filtering, PageChanging etc are all handled similar to normal asp.net gridviews
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void gridDS_ObjectCreating(object sender, ObjectDataSourceEventArgs e)
        {
            e.ObjectInstance = this;
        }
        void gvDocuments_Sorting(object sender, GridViewSortEventArgs e)
        {
            string lastExpression = "";
            if (ViewState["SortExpression"] != null)
                lastExpression = ViewState["SortExpression"].ToString();

            string lastDirection = "asc";
            if (ViewState["SortDirection"] != null)
                lastDirection = ViewState["SortDirection"].ToString();

            string newDirection = string.Empty;
            if (e.SortExpression == lastExpression)
            {
                e.SortDirection = (lastDirection == "asc") ? System.Web.UI.WebControls.SortDirection.Descending : System.Web.UI.WebControls.SortDirection.Ascending;

            }

            newDirection = (e.SortDirection == System.Web.UI.WebControls.SortDirection.Descending) ? "desc" : "asc";
            ViewState["SortExpression"] = e.SortExpression;
            ViewState["SortDirection"] = newDirection;

            gvICSSDocuments.DataBind();
            //For Filter
            if (ViewState["FilterExpression"] != null)
            {
                gridDS.FilterExpression = (string)ViewState["FilterExpression"];
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
            ViewState["FilterExpression"] = ((ObjectDataSourceView)sender).FilterExpression;
        }
        protected sealed override void LoadViewState(object savedState)
        {
            base.LoadViewState(savedState);

            if (Context.Request.Form["__EVENTARGUMENT"] != null &&
                 Context.Request.Form["__EVENTARGUMENT"].EndsWith("__ClearFilter__"))
            {
                // Clear FilterExpression
                ViewState.Remove("FilterExpression");
            }
        }
    }
}
