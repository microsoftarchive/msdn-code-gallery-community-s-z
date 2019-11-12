using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using MvcMusicStore.Models;

namespace MvcMusicStore.Activities
{

    public sealed class ShippingMethodActivity : CodeActivity
    {
    
        public InOutArgument<WorkFlowContext> WFContext { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            
            var wfcontext = context.GetValue(this.WFContext);
            wfcontext.ViewName = "ShippingMethod";
            List<ShippingMethod> shippingmethods = new List<ShippingMethod>{
           new  ShippingMethod{Name="Standard",Description="Standard Shipping (5 -8 days)"},
           new  ShippingMethod{Name="TwoDay",Description="Two-Day Shipping"},
           new  ShippingMethod{Name="OneDay",Description="One-Day Shipping"}};
            wfcontext.ViewData.Model = shippingmethods;
            context.SetValue(WFContext, wfcontext);
        }
    }
}
