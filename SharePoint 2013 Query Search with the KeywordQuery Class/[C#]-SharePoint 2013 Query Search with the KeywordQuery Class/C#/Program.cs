using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Microsoft.SharePoint;
using Microsoft.Office.Server.Search.Query;

namespace SearchConsoleApplication1
{
	class Program
	{
		static void Main(string[] args)
		{
			using (SPSite siteCollection = new SPSite("http://sp2010/sites/test"))
			{
				KeywordQuery keywordQuery = new KeywordQuery(siteCollection);
				keywordQuery.QueryText = "SharePoint";
				keywordQuery.SortList.Add("Author", SortDirection.Ascending);
				keywordQuery.SortList.Add("Size", SortDirection.Descending);

				SearchExecutor searchExecutor = new SearchExecutor();
				ResultTableCollection resultTableCollection = searchExecutor.ExecuteQuery(keywordQuery);
				var resultTables = resultTableCollection.Filter("TableType", KnownTableTypes.RelevantResults);

				var resultTable = resultTables.FirstOrDefault();

				DataTable dataTable = resultTable.Table;
			}
		}
	}
}
