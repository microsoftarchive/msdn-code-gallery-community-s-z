using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Configuration;

namespace WcfHttpCompressionEnabler
{
    public class HttpBehaviorExtensionElement : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get
            {
                return typeof(HttpRequestBehavior);
            }
        }

        protected override object CreateBehavior()
        {
            return new HttpRequestBehavior();
        }        
    }
    
}
