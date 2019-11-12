using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace CR_With_MVC.Controllers
{
    public class GenericReportViewerController : Controller
    {
        //
        // GET: /GenericReportViewer/

        public ActionResult Index()
        {
            return View();
        }

        
        public void ShowGenericRpt()
        {
            try
            {
                bool isValid = true;

                string strReportName = System.Web.HttpContext.Current.Session["ReportName"].ToString();    // Setting ReportName
                string strFromDate = System.Web.HttpContext.Current.Session["rptFromDate"].ToString();     // Setting FromDate 
                string strToDate = System.Web.HttpContext.Current.Session["rptToDate"].ToString();         // Setting ToDate    
                var rptSource = System.Web.HttpContext.Current.Session["rptSource"];

                if (string.IsNullOrEmpty(strReportName))
                {
                    isValid = false;
                }

                if (isValid)
                {
                    ReportDocument rd = new ReportDocument();
                    string strRptPath = System.Web.HttpContext.Current.Server.MapPath("~/") + "Rpts//" + strReportName;
                    rd.Load(strRptPath);
                    if (rptSource != null && rptSource.GetType().ToString() != "System.String")
                        rd.SetDataSource(rptSource);
                    if (!string.IsNullOrEmpty(strFromDate))
                        rd.SetParameterValue("fromDate", strFromDate);
                    if (!string.IsNullOrEmpty(strToDate))
                        rd.SetParameterValue("toDate", strFromDate);
                    rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "crReport");

                    
                    // Clear all sessions value
                    Session["ReportName"] = null;
                    Session["rptFromDate"] = null;
                    Session["rptToDate"] = null;
                    Session["rptSource"] = null;
                }
                else
                {
                    Response.Write("<H2>Nothing Found; No Report name found</H2>");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
    }
}
