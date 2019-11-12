//-----------------------------------------------------------------------
// <copyright company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Configuration;
using Microsoft.Reporting.WebForms;

namespace SupplyingParameters
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // We need to add the parameters in an if(!IsPostBack) block because when AsyncRendering == true, the report is not processed
            // until the next asynchronous postback after the parameters are set. If we do not encapsulate the code in an is(!IsPostBack)
            // block, the application will be caught in an infinite loop of asynchronous postbacks.
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

                // Create ReportParameter objects with values, and set them to be invisible.
                ReportParameter year = new ReportParameter("ReportYear", "2003", false);
                ReportParameter month = new ReportParameter("ReportMonth", "7", false);
                ReportParameter id = new ReportParameter("EmployeeID", String.Empty, false);  // Will process this one more below
                ReportParameter description = new ReportParameter("ShowDescription", "false", false);

                // The ServerReport.GetParameters() method is useful for retrieving information about each report parameter
                // Here, retrieve a valid valud by specifying the label name.
                ReportParameterInfoCollection parameters = ReportViewer1.ServerReport.GetParameters();
                foreach (ValidValue value in parameters["EmployeeID"].ValidValues)
                {
                    if (value.Label == "David Campbell")
                    {
                        id.Values.Clear();
                        id.Values.Add(value.Value);
                        break;
                    }
                }

                // Set the parameters.
                ReportViewer1.ServerReport.SetParameters(new ReportParameter[] { year, month, id, description });
            }
        }
    }
}