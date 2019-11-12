using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RestfulService
{
    // NOTE: If you change the class name "IRestServiceImpl" here, you must also update the reference to "IRestServiceImpl" in Web.config.
    public class RestServiceImpl : IRestServiceImpl
    {

        #region IRestServiceImpl Members

        public string XMLData(string id)
        {
            return "your Product is " + id;
        }

        #endregion

        #region IRestServiceImpl Members


        public string JsonData(string id)
        {
            return "your Product is " + id;
        }

        #endregion
    }
}
