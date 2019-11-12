//-----------------------------------------------------------------------
// <copyright company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace ReportFromStream
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ReportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Note: A FileStream is used here for demonstration simplicity, but you can also generate the RDLC stream dynamically using System.Xml.
            FileStream report = null;
            FileStream subreport = null;
            DataSet dataSet = null;

            try
            {
                // Load the report from a stream. 
                report = new FileStream(@"..\..\OrdersWithSubreport.rdlc", FileMode.Open, FileAccess.Read);
                ReportViewer1.LocalReport.LoadReportDefinition(report);
                //// Load all the subreports contained in the report using LoadSubReportDefinition. The name of the subreport must match the one defined
                //// in the main report stream (in the <Subreport>\<ReportName> XML element)
                subreport = new FileStream(@"..\..\OrderDetails.rdlc", FileMode.Open, FileAccess.Read);
                ReportViewer1.LocalReport.LoadSubreportDefinition("OrderDetails", subreport);

                // Supply a DataTable corresponding to each report dataset. The dataset name must match the name defined in the main report stream
                // (in the Name attribute of the <DataSets>\<DataSet> element.
                dataSet = new DataSet();
                dataSet.ReadXml(@"..\..\OrderData.xml");
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource(ReportViewer1.LocalReport.GetDataSourceNames()[0], dataSet.Tables[0]));

                this.ReportViewer1.RefreshReport();
            }
            finally 
            {
                if (report != null)
                    report.Dispose();
                if (subreport != null)
                    subreport.Dispose();
                if (dataSet != null)
                    dataSet.Dispose();
            }
        }

        /// <summary>
        /// Handles the LocalReport.SubreportProcessing event. Add the data for the subreport here.
        /// </summary>
        private void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            DataSet dataSet = null;

            try
            {
                // Load data from XML file
                dataSet = new DataSet();
                dataSet.ReadXml(@"..\..\OrderDetailData.xml");

                // Supply a DataTable corresponding to each report dataset. The dataset name must match the name defined in the main report stream
                // (in the Name attribute of the <DataSets>\<DataSet> element.
                e.DataSources.Add(new ReportDataSource(e.DataSourceNames[0], dataSet.Tables[0]));
            }
            finally
            {
                if (dataSet != null)
                    dataSet.Dispose();
            }
        }
    }
}
