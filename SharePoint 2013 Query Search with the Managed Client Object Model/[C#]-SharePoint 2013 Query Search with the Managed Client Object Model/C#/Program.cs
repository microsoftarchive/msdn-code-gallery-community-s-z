using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.Search;
using Microsoft.SharePoint.Client.Search.Query;

namespace SearchClientObjectModelTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ClientContext clientContext = new ClientContext("http://sp2010"))
            {
                KeywordQuery keywordQuery = new KeywordQuery(clientContext);
                keywordQuery.QueryText = "SharePoint";

                SearchExecutor searchExecutor = new SearchExecutor(clientContext);

                ClientResult<ResultTableCollection> results = searchExecutor.ExecuteQuery(keywordQuery);
                clientContext.ExecuteQuery();

                foreach (var resultRow in results.Value[0].ResultRows)
                {
                    Console.WriteLine("{0}: {1} ({2})", resultRow["Title"], resultRow["Path"], resultRow["Write"]);
                }

                Console.ReadLine();
            }
        }
    }
}
