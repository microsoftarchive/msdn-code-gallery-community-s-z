//-----------------------------------------------------------------------
// <copyright company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Configuration;
using Microsoft.Reporting.WebForms;

namespace PopupDrillthrough
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
                    "Employee Sales Summary 2008",                                                                   // report name
                    (ConfigurationManager.AppSettings["ReportServerMode"] == "SharePoint" ? ".rdl" : String.Empty)); // extension, depending on the report server mode
                                                                                                                     // (for information on the report path format, 
                                                                                                                     // see http://msdn.microsoft.com/en-us/library/ms252075.aspx)
            }

            ReportViewer1.Drillthrough += new DrillthroughEventHandler(ReportViewer1_Drillthrough);
        }

        private void ReportViewer1_Drillthrough(object sender, Microsoft.Reporting.WebForms.DrillthroughEventArgs e)
        {
            // When a Drillthrough event occurs, cancel it and assign the drillthrough report's URL and path
            // to the viewer in the popup panel, then display the popup panel.
            e.Cancel = true;

            ReportViewerDrillthrough.ServerReport.ReportServerUrl = ((ServerReport)e.Report).ReportServerUrl;
            ReportViewerDrillthrough.ServerReport.ReportPath = ((ServerReport)e.Report).ReportPath;
            ModalPopupExtender_Drillthrough.Show();
        }
    }
}