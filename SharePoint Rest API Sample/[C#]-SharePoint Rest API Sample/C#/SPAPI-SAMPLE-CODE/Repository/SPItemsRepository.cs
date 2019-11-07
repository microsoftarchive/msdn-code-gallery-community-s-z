using System.Globalization;

namespace SPAPI_SAMPLE_CODE.Repository {
    public class SPItemsRepository {

        private static string camlJson = "{ \"query\" : {\"__metadata\": { \"type\": \"SP.CamlQuery\" }, \"ViewXml\": \"{0}\" } }";

        public string ClientId {
            get;
            set;
        }

        public string ClientSecret {
            get;
            set;
        }

        public SPItemsRepository(string clientId, string clientSecret) {
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        public string GetItems(string siteUrl, string list, string camlQuery) {
            string retVal = string.Empty;

            string data = camlJson.Replace("{0}", camlQuery);
            camlQuery = "(query=@v1)?@v1={\"ViewXml\":\"{2}\"}".Replace("{2}", camlQuery);
            string url =string.Format(CultureInfo.InvariantCulture, "{0}/_api/web/lists/GetByTitle('{1}')/GetItems{2}", siteUrl, list, camlQuery);

            SPAPIHandler handler = new SPAPIHandler(ClientId, ClientSecret);
            retVal = handler.Post(url);

            return retVal;
        }
    }
}
