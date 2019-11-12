using SPAPI_SAMPLE_CODE.Objects;
using SPAPI_SAMPLE_CODE.Repository;
using System.Collections.Generic;

namespace SPAPI_SAMPLE {
    class Program {
        static void Main(string[] args) {

            string clientId = "[ClientId]";
            string clientSecret = "[ClientSecret]";
            string siteUrl = "[siteurl]";
            string list = "[List name]";
            string query = "[Query]";
            string id = "[Document Id]";

            //Getting items from a list with a caml query
            SPItemsRepository itemRepo = new SPItemsRepository(clientId, clientSecret);
            string result = itemRepo.GetItems(siteUrl, list, query);

            //Getting a document by its item id
            SPDocumentRepository docRepo = new SPDocumentRepository(clientId, clientSecret);
            string docResult = docRepo.GetDocument(siteUrl, list, id.ToString());

            Dictionary<string, string> metaData = new Dictionary<string, string>();
            metaData.Add("[InternalName]", "[Value]");

            Document document = new Document() {
                FileName = "[FileName]",
                MetaData = metaData,           
                DocumentByteArray = "[DocumentByteArray]"
            };
            //Uploading a document with Metadata
            string uploadResult = docRepo.PostDocument(siteUrl, list, document);

        }
    }
}
