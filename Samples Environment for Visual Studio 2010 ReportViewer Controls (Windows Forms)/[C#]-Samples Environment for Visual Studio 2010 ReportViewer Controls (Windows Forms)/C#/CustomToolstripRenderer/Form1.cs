//-----------------------------------------------------------------------
// <copyright company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Configuration;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace CustomToolStripRenderer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Note: You can set the processing mode, report server URL, and report path directly in the form designer, but here
            //       we set it maually instead in order to use global values.

            // Set to remote processing mode
            ReportViewer1.ProcessingMode = ProcessingMode.Remote;

            // Get report path from configuration file
            ReportViewer1.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportServerUrl"], UriKind.Absolute);
            ReportViewer1.ServerReport.ReportPath = String.Format("{0}/{1}{2}",
                ConfigurationManager.AppSettings["SampleReportsPath"],                                           // folder or site path
                "Product Catalog 2008",                                                                          // report name
                (ConfigurationManager.AppSettings["ReportServerMode"] == "SharePoint" ? ".rdl" : String.Empty)); // extension, depending on the report server mode
                                                                                                                 // (for information on the report path format, 
                                                                                                                 // see http://msdn.microsoft.com/en-us/library/ms252075.aspx)
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ReportViewer1.RefreshReport();
        }

        private void RadioProfessionalSkin_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioProfessionalSkin.Checked)
                //// Use the professional toolstrip renderer
                ReportViewer1.ToolStripRenderer = new ToolStripProfessionalRenderer();
        }

        private void RadioSystemSkin_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioSystemSkin.Checked)
                //// Use the system toolstrip renderer
                ReportViewer1.ToolStripRenderer = new ToolStripSystemRenderer();
        }

        private void RadioCustomSkin_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioCustomSkin.Checked)
                //// Use the sample SDKRenderer renderer
                ReportViewer1.ToolStripRenderer = new SdkRenderer();
        }
    }
}
