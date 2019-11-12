namespace MvcWebApp.BaseSystem
{
    using System.Threading;
    using System.Web.Mvc;

    [Authorize]
    public class BaseController : Controller
    {
        protected string LayoutLink
        {
            get
            {
                var link = "~/Views/Shared/_Layout.cshtml";

                if (Request.Browser.IsMobileDevice)
                {
                    link = "~/Views/Shared/_Layout.Mobile.cshtml";
                }

                if (User == null) return link;

                if (User.Identity.IsAuthenticated)
                {
                    link = "~/Views/Shared/_AdminLayout.cshtml";
                }
                
                return link;
            }
        }

        protected object CurrentUser
        {
            get { return Thread.CurrentPrincipal.Identity; }
        }

        protected override ViewResult View(IView view, object model)
        {
            ViewBag.Layout = LayoutLink;
            return base.View(view, model);
        }

        protected override ViewResult View(string viewName, string masterName, object model)
        {
            ViewBag.Layout = LayoutLink;
            return base.View(viewName, masterName, model);
        }
    }
}