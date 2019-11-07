using System.Web.Mvc;

namespace AdminWeb.Areas.Lookup
{
    public class LookupAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Lookup";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Lookup_default",
                "Lookup/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
