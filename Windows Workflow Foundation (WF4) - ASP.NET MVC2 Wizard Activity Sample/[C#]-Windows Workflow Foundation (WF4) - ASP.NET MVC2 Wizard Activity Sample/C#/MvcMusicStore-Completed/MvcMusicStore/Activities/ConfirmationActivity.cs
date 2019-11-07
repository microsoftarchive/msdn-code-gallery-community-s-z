using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using MvcMusicStore.Models;

namespace MvcMusicStore.Activities
{

    public sealed class ConfirmationActivity : CodeActivity
    {
       
        public InOutArgument<WorkFlowContext> WFContext { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {

            var wfcontext = context.GetValue(this.WFContext);
            wfcontext.ViewName = "Confirmation";
            
            wfcontext.ViewData.Model = new Order();
            context.SetValue(WFContext, wfcontext);
        }
    }
}
