using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;

using ScaleOutDemo.Contracts.Data;

namespace ScaleOutDemo.WebUI
{
    public partial class Results : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AzureTableDataSource.TypeName = typeof(TestRunEntityTableContext).FullName;
            this.AzureTableDataSource.DataObjectTypeName = typeof(TestRunTableEntity).FullName;
            this.AzureTableDataSource.SelectMethod = "GetTestRuns";
            this.AzureTableDataSource.ObjectCreating += (s, p) => 
            {
                var storageAccountName = ConfigurationManager.AppSettings[CommonConsts.ConfigSettingStorageAccount];
                var storageAccountKey = ConfigurationManager.AppSettings[CommonConsts.ConfigSettingStorageAccountKey];
                var testRunsTableName = ConfigurationManager.AppSettings[CommonConsts.ConfigSettingTestRunsTableName];
                var creds = new StorageCredentialsAccountAndKey(storageAccountName, storageAccountKey);
                var storageAccount = new CloudStorageAccount(creds, true);
                var tableClient = storageAccount.CreateCloudTableClient();

                var testRunTable = new TestRunEntityTableContext(tableClient.BaseUri.ToString(), tableClient.Credentials);
                testRunTable.TableName = testRunsTableName;

                p.ObjectInstance = testRunTable;
            };

            this.AzureTableDataSource.Select();
            this.AzureTableDataSource.DataBind();
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
        }
    }
}