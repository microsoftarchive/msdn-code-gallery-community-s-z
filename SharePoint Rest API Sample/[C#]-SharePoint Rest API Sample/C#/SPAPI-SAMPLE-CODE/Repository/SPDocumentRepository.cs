using SPAPI_SAMPLE_CODE.Objects;
using System.Globalization;
using System.Web.Script.Serialization;

namespace SPAPI_SAMPLE_CODE.Repository {
    public class SPDocumentRepository {

        public string ClientId {
            get;
            set;
        }

        public string ClientSecret {
            get;
            set;
        }

        public SPDocumentRepository(string clientId, string clientSecret) {
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        public string GetDocument(string siteUrl, string list, string Id) {
            
            string retVal = string.Empty;
            string url = string.Format(CultureInfo.InvariantCulture, "{0}/_api/web/lists/getByTitle('{1}')/items?$select=EncodedAbsUrl&$filter=Id eq {2}", siteUrl, list, Id);

            SPAPIHandler handler = new SPAPIHandler(ClientId, ClientSecret);

            
                retVal = handler.Get(url);
   

            return retVal;
        }

        public string PostDocument(string siteUrl, string list, Document document) {
            string retVal = string.Empty;

            string url = string.Format(CultureInfo.InvariantCulture, "{0}/_api/web/lists/getByTitle('{1}')/RootFolder/Files/Add(url='{2}', overwrite=true)", siteUrl, list, document.FileName);
            SPAPIHandler handler = new SPAPIHandler(ClientId, ClientSecret);
            retVal = handler.PostDocument(url, document.DocumentByteArray);

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            dynamic item = serializer.Deserialize<object>(retVal);
            string relativeUrl = item["d"]["ServerRelativeUrl"];

            UpdateDocument(siteUrl, relativeUrl, document);

            return retVal;
        }

        public string UpdateDocument(string siteUrl, string relativeUrl, Document document) {
            string retVal = string.Empty;
            
            string url = string.Format(CultureInfo.InvariantCulture, "{0}/_api/web/GetFileByServerRelativeUrl('{1}')/ListItemAllFields", siteUrl, relativeUrl);
            SPAPIHandler handler = new SPAPIHandler(ClientId, ClientSecret);

                retVal = handler.Merge(url, document);

            return retVal;
        }
    }
}
