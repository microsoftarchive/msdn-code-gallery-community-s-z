//-----------------------------------------------------------------------
// <copyright company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Data;
using Microsoft.Reporting.WebForms;

namespace SupplyingData
{
    public partial class Default : System.Web.UI.Page
    {
        private DataTable orderDetailsData;

        private DataTable LoadOrdersData()
        {
            DataTable table = null;
            DataSet dataSet = null;

            try
            {
                // Load data from XML file
                dataSet = new DataSet();
                dataSet.ReadXml(Server.MapPath(@"OrderData.xml"));
                table = dataSet.Tables[0];
            }
            finally
            {
                if (dataSet != null)
                    dataSet.Dispose();
            }

            return table;
        }

        private DataTable LoadOrderDetailsData()
        {
            DataTable table = null;
            DataSet dataSet = null;

            try
            {
                // Load data from XML file
                dataSet = new DataSet();
                dataSet.ReadXml(Server.MapPath(@"OrderDetailData.xml"));
                table = dataSet.Tables[0];
            }
            finally 
            {
                if (dataSet != null)
                    dataSet.Dispose();
            }

            return table;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set the processing mode
                ReportViewer1.ProcessingMode = ProcessingMode.Local;

                // Set the report definition
                ReportViewer1.LocalReport.ReportPath = Server.MapPath(@"OrdersWithSubreport.rdlc");

                // Supply a DataTable corresponding to each report dataset
                // The dataset name must match the name defined in the RDLC report
                ReportViewer1.LocalReport.DataSources.Add(
                    new ReportDataSource(ReportViewer1.LocalReport.GetDataSourceNames()[0], LoadOrdersData()));

                // Add a handler for the SubreportProcessing event
                ReportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);
            }

            // Add a handler for the Drillthrough event
            ReportViewer1.Drillthrough += new DrillthroughEventHandler(ReportViewer1_Drillthrough);

            // Note where the two events are being hooked up. The SubreportProcessing event needs to be raised in the same postback
            // when the main report is processed, but the Drillthrough event needs to be raised on the postback caused by a drillthrough
            // action. Therefore, we need to hook up SubreportProcessing when the page is first requested and in DropDownList1_SelectedIndexChanged
            // for when OrdersWithSubreport.rdlc is selected.
        }

        private void ReportViewer1_Drillthrough(object sender, DrillthroughEventArgs e)
        {
            if (this.orderDetailsData == null)
                this.orderDetailsData = LoadOrderDetailsData();

            // Supply a DataTable corresponding to each drillthrough report dataset
            // The dataset name must match the name defined in the drillthrough report
            LocalReport report = ((LocalReport)e.Report);
            report.DataSources.Add(new ReportDataSource(report.GetDataSourceNames()[0], this.orderDetailsData));
        }

        private void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            if (this.orderDetailsData == null)
            {
                this.orderDetailsData = LoadOrderDetailsData();
            }

            // Supply a DataTable corresponding to each subreport dataset
            // The dataset name must match the name defined in the subreport
            e.DataSources.Add(new ReportDataSource(e.DataSourceNames[0], this.orderDetailsData));
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Reset the viewer in case we're switching from a drillthrough report (not at the root of the drillthrough hierarchy). 
            // You can also get back to the root by repeatedly calling ReportViewer.PerformBack(). However, ReportViewer.Reset() will
            // reset all other settings as well, so we can work with a clean ReportViewer object.
            ReportViewer1.Reset();

            // Set the processing mode
            ReportViewer1.ProcessingMode = ProcessingMode.Local;

            // Set the report definition
            ReportViewer1.LocalReport.ReportPath = Server.MapPath(String.Format("{0}.rdlc", DropDownList1.SelectedValue));

            // Supply a DataTable corresponding to each report dataset
            // The dataset name must match the name defined in the RDLC report. Both OrdersWithSubreport.rdlc and OrdersWithDrillthrough.rdlc
            // use the same name for their their datasets, so just add it to DataSources.
            ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource(ReportViewer1.LocalReport.GetDataSourceNames()[0], LoadOrdersData()));

            // Hook up the event handlers again, since the ReportViewer1.Reset() method removes event handlers.
            ReportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);
        }
    }
}