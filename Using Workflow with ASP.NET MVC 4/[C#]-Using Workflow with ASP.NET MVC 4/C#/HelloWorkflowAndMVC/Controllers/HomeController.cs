namespace HelloWorkflowAndMVC.Controllers
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        #region Public Methods and Operators

        public ActionResult About()
        {
            return this.View();
        }

        public ActionResult Index()
        {
            this.ViewBag.Message = "Welcome to Workflow and ASP.NET MVC!";

            return this.View();
        }

        #endregion
    }
}