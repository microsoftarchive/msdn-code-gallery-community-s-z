using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using MvcMusicStore.Models;

namespace MvcMusicStore.Activities
{

    public sealed class PaymentOptionsActivity : CodeActivity
    {
        public InOutArgument<WorkFlowContext> WFContext { get; set; }


        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {

            var wfcontext = context.GetValue(this.WFContext);
            wfcontext.ViewName = "PaymentOptions";
            List<PaymentOption> shippingmethods = new List<PaymentOption>{
           new  PaymentOption{Name="CreditCard",Description="Credit Card"},
           new  PaymentOption{Name="GoogleCheckOut",Description="Google Checkout"},
           new  PaymentOption{Name="PayPal",Description="PayPal"}};
            wfcontext.ViewData.Model = shippingmethods;
            context.SetValue(WFContext, wfcontext);
        }
    }
}
