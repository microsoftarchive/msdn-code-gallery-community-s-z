using System.Linq;
using System.Web.Mvc;

using System.Collections.Specialized;

namespace  MvcMusicStore.Models
{
    public class WorkFlowContextModelBinder : IModelBinder
    {
     
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            NameValueCollection request = controllerContext.RequestContext.HttpContext.Request.Params;
            
            var context = (WorkFlowContext)bindingContext.Model;
           
            foreach (var item in request.AllKeys)
            {
                context.Request.AddItem(item, request[item]);
          }
            context.User = controllerContext.RequestContext.HttpContext.User;
            context.ViewData = new ViewDataDictionary();
            return context;
        }
    }
}
