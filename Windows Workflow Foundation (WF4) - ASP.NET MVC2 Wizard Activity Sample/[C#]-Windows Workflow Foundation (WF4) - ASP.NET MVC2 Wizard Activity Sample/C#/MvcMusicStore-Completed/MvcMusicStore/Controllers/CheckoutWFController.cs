using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WizardActivityPack.Activities;
using MvcMusicStore.WorkflowHost;
using MvcMusicStore.Models;
using MvcMusicStore.Workflow;
namespace MvcMusicStore.Controllers
{
 [Authorize]
    public class CheckoutWFController : Controller
    {
        //
        // GET: /CheckoutWF/
        public WorkFlowContext workflowcontext;
        List<CustomBookmark> bookmarkhistory;
        public WizardHost host;
        public ActionResult Index(string Command,string Step)
        {

            host = new WizardHost(new Workflow1(), bookmarkhistory);

            Dictionary<string, object> input = new Dictionary<string, object>();
             IDictionary<string, object> output=new Dictionary<string,object>(); 
            input["Context"] = workflowcontext;
            switch (Command)
            {
                case "Start":
                    output=host.Start(input);
                    break;
                case "Next":
               output=host.Next(input);
                    break;
                case "Back":
               output=host.Back(input);
                    break;
                case "GoTo":
                    output = host.GoTo(input,Step);
                    break;
                default:
                    output = host.Start(input);
                    break;
            }
            bookmarkhistory = host.GetBookmarkHistory();
            workflowcontext = output["Context"] as WorkFlowContext;
            ViewData = workflowcontext.ViewData;
            ViewData["bookmarkhistory"] = bookmarkhistory;
            ViewData["currentbookmark"] = host.GetCurrentBookmark();
            ViewData["PartialViewName"] = workflowcontext.ViewName;
            return View();
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            //pupolate the model and context
            workflowcontext = (TempData["context"] ?? new WorkFlowContext()) as WorkFlowContext;

            TryUpdateModel(workflowcontext);
            


            bookmarkhistory = (TempData["bookmarkhistory"] ?? new List<CustomBookmark>()) as List<CustomBookmark>;

        }
        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {

            //save the context in tempdata
            TempData["context"] = workflowcontext;
            TempData["bookmarkhistory"] = bookmarkhistory;
        }
    }
}
