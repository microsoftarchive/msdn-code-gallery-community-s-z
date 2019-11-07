using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;

namespace JQueryAutoCompleteCS.WebService
{
    /// <summary>
    /// Summary description for AutoCompleteWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class AutoCompleteWebService : System.Web.Services.WebService
    {

        /// <summary>
        /// Gets the random strings.
        /// </summary>
        /// <param name="Value">The value.</param>
        /// <returns>GetRandomStringsResult)</returns>
        /// <author>Luca Congiu (25/05/2013)</author>
        /// <includesource>yes</includesource>
        [WebMethod()]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<GetRandomStringsResult> GetRandomStrings(string Value)
        {
            List<GetRandomStringsResult> result = new List<GetRandomStringsResult>();
            //Generate Random Strings
            for (int i = 97; i <= 122; i++)
            {
                result.Add(new GetRandomStringsResult(Value + Convert.ToChar(i), i.ToString()));
            }

            return result;

        }
    }

    /// <summary>
    /// Result Class for json
    /// </summary>
    /// <author>LCO (25/05/2013)</author>
    /// <includesource>yes</includesource>
    public class GetRandomStringsResult
    {

        public GetRandomStringsResult()
        {
        }
        public GetRandomStringsResult(string Name, string Value)
        {
            this.Name = Name;
            this.Value = Value;
        }
        public string Name { get; set; }
        public string Value { get; set; }


    }
}
