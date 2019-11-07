//-----------------------------------------------------------------------
// <copyright company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace SupplyingData
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private DataTable ordersData;
        private DataTable orderDetailsData;

        /// <summary>
        /// Returns a DataTable with the data for both OrdersWithSubreport.rdlc and OrdersWithDrillthrough.rdlc
        /// </summary>
        private DataTable LoadOrdersData()
        {
            DataSet dataSet = null;

            try
            {
                if (ordersData == null)
                {
                    // Load data from XML file
                    dataSet = new DataSet();
                    dataSet.ReadXml(@"..\..\OrderData.xml");
                    ordersData = dataSet.Tables[0];
                }

                return ordersData;
            }
            finally 
            {
                if (dataSet != null)
                    dataSet.Dispose();
            }
        }

        /// <summary>
        /// Returns a DataTable with the data for both OrderDetails.rdlc
        /// </summary>
        private DataTable LoadOrderDetailsData()
        {
            DataSet dataSet = null;
            try
            {
                if (orderDetailsData == null)
                {
                    // Load data from XML file
                    dataSet = new DataSet();
                    dataSet.ReadXml(@"..\..\OrderDetailData.xml");
                    orderDetailsData = dataSet.Tables[0];
                }

                return orderDetailsData;
            }
            finally 
            {
                if (dataSet != null)
                    dataSet.Dispose();
            }
        }

        /// <summary>
        /// Handles the Form1.Load event. Initialize the viewer here.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = @"..\..\OrdersWithSubreport.rdlc";

            // Supply a DataTable corresponding to each report dataset
            // The dataset name must match the name defined in the RDLC report
            ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource(ReportViewer1.LocalReport.GetDataSourceNames()[0], LoadOrdersData()));

            // Run the report
            ReportViewer1.RefreshReport();

            // Add a handler for the SubreportProcessing event
            ReportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);

            ComboBoxChooseReport.SelectedIndexChanged += new EventHandler(ComboBoxChooseReport_SelectedIndexChanged);
        }

        /// <summary>
        /// Handles the ToolstripComboBox.SelectedIndexChanged event. In this handler, the viewer is reset, then the report path
        /// and respective viewer event are set, and the report is refreshed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxChooseReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReportViewer1.Reset();
            ReportViewer1.LocalReport.DataSources.Clear();

            if (ComboBoxChooseReport.Text == "Report with Subreport")
            {
                ReportViewer1.LocalReport.ReportPath = @"..\..\OrdersWithSubreport.rdlc";
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource(ReportViewer1.LocalReport.GetDataSourceNames()[0], LoadOrdersData()));

                // Hook up the event handlers again, since the ReportViewer1.Reset() method removes event handlers.
                ReportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);
            }
            else 
            {
                ReportViewer1.LocalReport.ReportPath = @"..\..\OrdersWithDrillthrough.rdlc";
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource(ReportViewer1.LocalReport.GetDataSourceNames()[0], LoadOrdersData()));

                // Hook up the event handlers again, since the ReportViewer1.Reset() method removes event handlers.
                ReportViewer1.Drillthrough += new DrillthroughEventHandler(ReportViewer1_Drillthrough);
            }

            ReportViewer1.RefreshReport();
        }

        /// <summary>
        /// Handles the ReportViewer.Drillthrough event. Add the data for the drillthrough report here.
        /// </summary>
        private void ReportViewer1_Drillthrough(object sender, DrillthroughEventArgs e)
        {
            LocalReport report = (LocalReport)e.Report;
            // Supply a DataTable corresponding to each drillthrough report dataset
            // The dataset name must match the name defined in the drillthrough report
            report.DataSources.Add(new ReportDataSource(report.GetDataSourceNames()[0], LoadOrderDetailsData()));
        }

        /// <summary>
        /// Handles the LocalReport.SubreportProcessing event. Add the data for the subreport here.
        /// </summary>
        private void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            // Supply a DataTable corresponding to each subreport dataset
            // The dataset name must match the name defined in the subreport
            e.DataSources.Add(new ReportDataSource(e.DataSourceNames[0], LoadOrderDetailsData()));
        }
    }
}
