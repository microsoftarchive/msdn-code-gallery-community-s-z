//-----------------------------------------------------------------------
// <copyright company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Configuration;

namespace AjaxControls
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Get report path from configuration file
                Uri serverurl = new Uri(ConfigurationManager.AppSettings["ReportServerUrl"]);
                string reportsfolder = ConfigurationManager.AppSettings["SampleReportsPath"];                                           // folder or site path
                string fileextension = (ConfigurationManager.AppSettings["ReportServerMode"] == "SharePoint" ? ".rdl" : String.Empty);  // extension, depending on the report server mode
                                                                                                                                        // (for information on the report path format, 
                                                                                                                                        // see http://msdn.microsoft.com/en-us/library/ms252075.aspx)

                ReportViewer1.ServerReport.ReportServerUrl = serverurl;
                ReportViewer1.ServerReport.ReportPath = String.Format("{0}/Company Sales 2008{1}", reportsfolder, fileextension);
                ReportViewer2.ServerReport.ReportServerUrl = serverurl;
                ReportViewer2.ServerReport.ReportPath = String.Format("{0}/Employee Sales Summary 2008{1}", reportsfolder, fileextension);
                ReportViewer3.ServerReport.ReportServerUrl = serverurl;
                ReportViewer3.ServerReport.ReportPath = String.Format("{0}/Product Catalog 2008{1}", reportsfolder, fileextension);
                ReportViewer4.ServerReport.ReportServerUrl = serverurl;
                ReportViewer4.ServerReport.ReportPath = String.Format("{0}/Sales Trend 2008{1}", reportsfolder, fileextension);
                ReportViewer5.ServerReport.ReportServerUrl = serverurl;
                ReportViewer5.ServerReport.ReportPath = String.Format("{0}/Territory Sales Drilldown 2008{1}", reportsfolder, fileextension);
            }
        }
    }
}