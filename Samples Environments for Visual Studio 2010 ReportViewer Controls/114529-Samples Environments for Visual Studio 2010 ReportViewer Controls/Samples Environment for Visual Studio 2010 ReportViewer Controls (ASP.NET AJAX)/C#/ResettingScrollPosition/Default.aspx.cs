//-----------------------------------------------------------------------
// <copyright company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Configuration;
using Microsoft.Reporting.WebForms;

namespace ResettingScrollPosition
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ReportViewer1.ProcessingMode = ProcessingMode.Remote;

                // Get report path from configuration file
                ReportViewer1.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportServerUrl"]);
                ReportViewer1.ServerReport.ReportPath = String.Format("{0}/{1}{2}",
                    ConfigurationManager.AppSettings["SampleReportsPath"],                                           // folder or site path
                    "Product Catalog 2008",                                                                          // report name
                    (ConfigurationManager.AppSettings["ReportServerMode"] == "SharePoint" ? ".rdl" : String.Empty)); // extension, depending on the report server mode
                                                                                                                     // (for information on the report path format, 
                                                                                                                     // see http://msdn.microsoft.com/en-us/library/ms252075.aspx)
            }
        }
    }
}