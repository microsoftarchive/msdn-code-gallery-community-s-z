namespace HelloWorkflowAndMVC.Controllers
{
    using System.Activities;
    using System.Web.Mvc;

    using HelloWorkflowAndMVC.Workflows;

    using Microsoft.Activities;

    public class HelloController : Controller
    {
        //
        // GET: /Hello/

        // Declare the workflow this way for best performance

        #region Constants and Fields

        private static readonly HelloMVC HelloMvcDefinition = new HelloMVC();

        #endregion

        #region Public Methods and Operators

        public ActionResult Index()
        {
            // Visual Basic does not support dynamic objects - use ViewData to access the ViewBag

            // Classic way of passing input arguments
            // var input = new Dictionary<string, object> { { "ViewData", this.ViewData } };

            // More "MVC" like method using Microsoft.Activities.WorkflowArguments
            dynamic input = new WorkflowArguments();

            input.ViewData = this.ViewData;

            // Synchronously invoke the workflow
            // Short-running workflows only.
            WorkflowInvoker.Invoke(HelloMvcDefinition, input);

            // ViewBag contains the result set by the workflow
            // See Views / Hello / Index.cshtml for the related view
            return this.View();
        }

        #endregion
    }
}