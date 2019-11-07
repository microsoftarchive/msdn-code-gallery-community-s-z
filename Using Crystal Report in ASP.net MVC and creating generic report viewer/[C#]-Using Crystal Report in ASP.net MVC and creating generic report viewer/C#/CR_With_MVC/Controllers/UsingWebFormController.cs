using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CR_With_MVC.Models;

namespace CR_With_MVC.Controllers
{
    public class UsingWebFormController : Controller
    {
        //
        // GET: /UsingAspNet/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void ShowSimple() 
        {
            Response.Redirect("~/AspNetForms/aspnetsimple.aspx");
        }

        private List<Student> GetStudents() 
        {
            return new List<Student>() { 
            new Student(){StudentID=1,StudentName="Hasibul"},
            new Student(){StudentID=2,StudentName="Tst"}
            };
        }


        // Show report with data
        //public void ShowGenericReport(string strFromDate, string strToDate) 
        
        [HttpPost]
        public void ShowGenericReport(string txtFromDate, string txtToDate) 
        {
            // Setting session for generating report
            this.HttpContext.Session["ReportName"] = "generic.rpt";
            this.HttpContext.Session["rptFromDate"] = txtFromDate;
            this.HttpContext.Session["rptToDate"] = txtToDate;
            this.HttpContext.Session["rptSource"] = GetStudents();
            // Redirecting generic report viewer page from action
            Response.Redirect("~/AspNetForms/aspnetgeneric.aspx");

        }

        [HttpPost]
        public void ShowGenericReportInNewWin(string FromDate, string ToDate)
        {
            this.HttpContext.Session["ReportName"] = "generic.rpt";
            this.HttpContext.Session["rptFromDate"] = FromDate;
            this.HttpContext.Session["rptToDate"] = ToDate;
            this.HttpContext.Session["rptSource"] = GetStudents();
        }


    }
}
