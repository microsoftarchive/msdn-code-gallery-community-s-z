using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CR_With_MVC.Models;

namespace CR_With_MVC.Controllers
{
    public class FromMvcController : Controller
    {
        //
        // GET: /FromMvc/

        public ActionResult Index()
        {
            return View();
        }

        //Used for showing simple report
        public void ShowSimple()
        {
            
            using (ReportClass rptH = new ReportClass())
            {

                rptH.FileName = Server.MapPath("~/") + "//Rpts//simple.rpt";
                rptH.Load();
                rptH.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "crReport");
            }
        }


        /// <summary>
        /// Generating Report Data
        /// </summary>
        /// <returns></returns>
        private List<Student> GetStudents()
        {
            return new List<Student>() { 
            new Student(){StudentID=1,StudentName="Hasibul"},
            new Student(){StudentID=2,StudentName="Tst"}
            };
        }

        


        /// <summary>
        /// This is used for showing Generic Report(with data and report parameter) in a same window
        /// </summary>
        /// <param name="txtFromDate">This will be passed to Report for showing from Date</param>
        /// <param name="txtToDate">This will be passed to Report for showing to Date</param>
        /// <returns></returns>
        public ActionResult ShowGeneric(string txtFromDate, string txtToDate)
        {

            this.HttpContext.Session["ReportName"] = "generic.rpt";
            this.HttpContext.Session["rptFromDate"] = txtFromDate;
            this.HttpContext.Session["rptToDate"] = txtToDate;
            this.HttpContext.Session["rptSource"] = GetStudents();


            return RedirectToAction("ShowGenericRpt", "GenericReportViewer");
        }




       /// <summary>
       /// This is used for preprocess report data and next generic report called from java script block
       /// </summary>
       /// <param name="FromDate"></param>
       /// <param name="ToDate"></param>
        [HttpPost]
        public void ShowGenericRptInNewWin(string FromDate, string ToDate) 
        {
            this.HttpContext.Session["ReportName"] = "generic.rpt";
            this.HttpContext.Session["rptFromDate"] = FromDate;
            this.HttpContext.Session["rptToDate"] = ToDate;
            this.HttpContext.Session["rptSource"] = GetStudents();

        }

        
    }


   
}
