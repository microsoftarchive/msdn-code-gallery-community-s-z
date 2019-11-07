using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data.Common;
using System.Data;

namespace HowToSsrsRdlcReport.Rdls
{
    public partial class Report : System.Web.UI.Page
    {

        string strCustomerID = @"SELECT ""CustomerID"", ""CompanyName"", ""ContactName"", ""ContactTitle"" FROM  `Customers` ";
        string strCustomerAddress = @"SELECT ""Address"", ""City"", ""Region"", ""PostalCode"", ""Country"", ""Phone"", ""Fax"" FROM  `Customers` ";
        string strOrderID = @"SELECT ""OrderID"", ""CustomerID"", ""EmployeeID"", Date(""OrderDate"") AS ""OrderDate"",Date(""RequiredDate"") AS ""RequiredDate"" , DATE(""ShippedDate"") AS ""ShippedDate"", ""ShipVia"", ""Freight"", ""ShipName"", ""ShipAddress"", ""ShipCity"", ""ShipRegion"", ""ShipPostalCode"", ""ShipCountry"" FROM `Orders`  ";
        string strError = "";

        string strConnection = "Data Source=" + AppDomain.CurrentDomain.BaseDirectory.ToString() + "Northwind.sl3";

        DataCommon dc;
        DbCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (InitDataBase())
                {
                    LoadReport();
                }
                else
                {

                }
            }
            else
            {

            }
        }

        protected void LoadReport()
        {
            InitDataBase();

            cmd.CommandText = strCustomerID;
            DataTable dtCustomer = dc.GetDataSet(cmd, CommandType.Text, null).Tables[0];

            Microsoft.Reporting.WebForms.Warning warnings = null;
            string[] streamIds = null;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;

            // ActivityCodeDescriptions.rdlc
            string reportPath = AppDomain.CurrentDomain.BaseDirectory.ToString() + @"Rdls\ReportCustomers.rdlc";

            //Create MS Report object
            rv.Reset();
            rv.LocalReport.ReportPath = reportPath;
            rv.ProcessingMode = ProcessingMode.Local;
            rv.LocalReport.SetBasePermissionsForSandboxAppDomain(new System.Security.PermissionSet(System.Security.Permissions.PermissionState.Unrestricted));

            rv.LocalReport.DataSources.Clear();   // MUST CLEAR DATA 

            rv.LocalReport.DataSources.Add(new ReportDataSource("dtCustomer", dtCustomer));

            var param = new List<ReportParameter>();
            param.Add(new ReportParameter("pNameReport", "Customer Report"));
            rv.LocalReport.SetParameters(param);

            rv.AsyncRendering = true;
            rv.DataBind();

            //Process subreport(s) which you include in main report ..
            rv.LocalReport.SubreportProcessing += SubreportProcessingEventHandler;

            rv.LocalReport.Refresh();
            rv.Visible = true;
        }

        //Process subreport(s) which you include in main report (from ToolBox)
        public void SubreportProcessingEventHandler(object sender, SubreportProcessingEventArgs e)
        {
            ReportParameterInfoCollection infoParam = e.Parameters;
            string strCaseId = infoParam[0].Values[0].ToString();

            switch (e.ReportPath)
            {
                case "subreport1":
                    ;
                    break;

                case "ReportCustomersAddress":
                    cmd.CommandText = strCustomerAddress + @" where ""CustomerID"" = '" + strCaseId + "'";
                    var dtCustomersAddress = dc.GetDataSet(cmd, CommandType.Text, null).Tables[0];
                    e.DataSources.Add(new ReportDataSource("dtCustomersAddress", dtCustomersAddress));
                    break;
                case "subreport3":
                    ;
                    break;
                default:
                    break;
            }
        }

        protected bool InitDataBase()
        {
            try
            {
                dc = new DataCommon();
                dc.connectionString = strConnection;
                dc.providerName = "System.Data.SQLite";
                cmd = dc.commandDB("");
                return true;
            }
            catch
            {
                return false;
            }
        }

        protected void Alert(string message)
        {
            var sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");

            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }

        protected void btnMainReport_Click(object sender, EventArgs e)
        {
            LoadReport();
        }

        protected void rv_Drillthrough(object sender, DrillthroughEventArgs e)
        {
            switch (e.ReportPath)
            {
                case "subreport1":
                    ;
                    break;

                case "ReportOrder":
                    LocalReport report = (LocalReport)e.Report;
                    IList<ReportParameter> list = report.OriginalParametersToDrillthrough;
                    string strCaseId = list[0].Values[0].ToString();
                    InitDataBase();
                    cmd.CommandText = strOrderID + @" where ""CustomerID"" = '" + strCaseId + "'";
                    DataTable dtOrders = dc.GetDataSet(cmd, CommandType.Text, null).Tables[0];
                    report.DataSources.Add(new ReportDataSource("dtOrders", dtOrders));
                    break;

                case "subreport3":
                    ;
                    break;
                default:
                    break;
            }
        }
    }
}