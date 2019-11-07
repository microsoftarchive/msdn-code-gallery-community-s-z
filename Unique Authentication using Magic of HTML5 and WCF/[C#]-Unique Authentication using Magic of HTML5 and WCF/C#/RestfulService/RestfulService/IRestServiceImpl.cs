using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RestfulService
{
    // NOTE: If you change the interface name "IIRestServiceImpl" here, you must also update the reference to "IIRestServiceImpl" in Web.config.
    [ServiceContract]
    public interface IRestServiceImpl
    {
        [OperationContract]
        [WebInvoke(Method="GET",
            ResponseFormat=WebMessageFormat.Xml,
            BodyStyle=WebMessageBodyStyle.Wrapped,
            UriTemplate="xml/{id}")]
        string XMLData(string id);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "json/{id}")]
        string JsonData(string id);
    }
}
