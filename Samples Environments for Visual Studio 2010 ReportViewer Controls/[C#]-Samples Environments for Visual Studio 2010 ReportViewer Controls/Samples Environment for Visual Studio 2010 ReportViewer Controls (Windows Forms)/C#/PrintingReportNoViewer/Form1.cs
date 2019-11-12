//-----------------------------------------------------------------------
// <copyright company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace PrintingReportNoViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Prints a local report wihthout ReportViewer when the "Print Local Report" button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonPrintLocal_Click(object sender, EventArgs e)
        {
            LocalReport report = null;
            DataSet dataSet = null;
            ReportPrintDocument printdoc = null;

            try
            {
                // Create a LocalReport object directly
                report = new LocalReport();
                report.ReportPath = @"..\..\Report1.rdlc";

                // Add report data sources
                dataSet = new DataSet();
                dataSet.ReadXml(@"..\..\data.xml");
                report.DataSources.Add(new ReportDataSource(report.GetDataSourceNames()[0], dataSet.Tables[0]));

                // Print the report using the ReportPrintDocument class (see ReportPrintDocument.cs)
                printdoc = new ReportPrintDocument(report);
                printdoc.Print();
            }
            finally 
            {
                if (report != null)
                    report.Dispose();
                if (dataSet != null)
                    dataSet.Dispose();
                if (printdoc != null)
                    printdoc.Dispose();
            }
        }

        /// <summary>
        /// Prints a server report wihthout ReportViewer when the "Print Server Report" button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonPrintServer_Click(object sender, EventArgs e)
        {
            // Create a ServerReport object directly
            ServerReport report = new ServerReport();

            // Get report path from configuration file
            report.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportServerUrl"], UriKind.Absolute);
            report.ReportPath = String.Format("{0}/{1}{2}",
                ConfigurationManager.AppSettings["SampleReportsPath"],                                           // folder or site path
                "Product Catalog 2008",                                                                          // report name
                (ConfigurationManager.AppSettings["ReportServerMode"] == "SharePoint" ? ".rdl" : String.Empty)); // extension, depending on the report server mode
                                                                                                                 // (for information on the report path format, 
                                                                                                                 // see http://msdn.microsoft.com/en-us/library/ms252075.aspx)

            ReportPrintDocument printdoc = null;
            try
            {
                // Print the report using the ReportPrintDocument class (see ReportPrintDocument.cs)
                printdoc = new ReportPrintDocument(report);
                printdoc.Print();
            }
            finally 
            {
                if (printdoc != null)
                    printdoc.Dispose();
            }
        }
    }
}
