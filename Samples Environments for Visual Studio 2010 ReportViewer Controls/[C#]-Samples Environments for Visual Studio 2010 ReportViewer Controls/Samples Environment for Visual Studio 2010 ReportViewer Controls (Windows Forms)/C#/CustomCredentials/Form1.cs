//-----------------------------------------------------------------------
// <copyright company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Configuration;
using System.Net;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace CustomCredentials
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ReportViewer1.ProcessingMode = ProcessingMode.Remote;

            // Get report path from configuration file.
            ReportViewer1.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportServerUrl"]);
            ReportViewer1.ServerReport.ReportPath = String.Format("{0}/{1}{2}",
                ConfigurationManager.AppSettings["SampleReportsPath"],                                           // folder or site path
                "Employee Sales Summary 2008",                                                                   // report name
                (ConfigurationManager.AppSettings["ReportServerMode"] == "SharePoint" ? ".rdl" : String.Empty)); // extension, depending on the report server mode
                                                                                                                 // (for information on the report path format, 
                                                                                                                 // see http://msdn.microsoft.com/en-us/library/ms252075.aspx)

            // Create a custom credential and read the user information from the App.config file.  
            NetworkCredential mycredential = new NetworkCredential(
                ConfigurationManager.AppSettings["MyReportViewerUser"],
                ConfigurationManager.AppSettings["MyReportViewerPassword"],
                ConfigurationManager.AppSettings["MyReportViewerDomain"]);
            if (string.IsNullOrEmpty(mycredential.UserName))
                throw new FormatException("Missing user name from App.config file");
            if (string.IsNullOrEmpty(mycredential.Password))
                throw new FormatException("Missing password from App.config file");
            if (string.IsNullOrEmpty(mycredential.Domain))
                throw new FormatException("Missing domain name from App.config file");

            // Add the custom credential
            ReportViewer1.ServerReport.ReportServerCredentials.NetworkCredentials = mycredential;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ReportViewer1.RefreshReport();
        }
    }
}