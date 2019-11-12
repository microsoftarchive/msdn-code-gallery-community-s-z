using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.WorkflowServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;

namespace CSOMWorkflow {

    class Program {
        static void Main(string[] args) {

            Console.WriteLine("Enter the Office 365 Login Name");
            string loginId = Console.ReadLine();
            string pwd = GetInput("Password", true);

            Console.WriteLine("Web Url:");
            string webUrl = Console.ReadLine();

            Console.WriteLine("List Name:");
            string listName = Console.ReadLine();

            Console.WriteLine("Workflow Name");
            string workflowName = Console.ReadLine();

            var passWord = new SecureString();
            foreach (char c in pwd.ToCharArray()) passWord.AppendChar(c);

            using (var ctx = new ClientContext(webUrl)) {
                ctx.Credentials = new SharePointOnlineCredentials(loginId, passWord);

                var workflowServicesManager = new WorkflowServicesManager(ctx, ctx.Web);
                var workflowInteropService = workflowServicesManager.GetWorkflowInteropService();
                var workflowSubscriptionService = workflowServicesManager.GetWorkflowSubscriptionService();
                var workflowDeploymentService = workflowServicesManager.GetWorkflowDeploymentService();
                var workflowInstanceService = workflowServicesManager.GetWorkflowInstanceService();

                var publishedWorkflowDefinitions = workflowDeploymentService.EnumerateDefinitions(true);
                ctx.Load(publishedWorkflowDefinitions);
                ctx.ExecuteQuery();

                var def = from defs in publishedWorkflowDefinitions
                          where defs.DisplayName == workflowName
                          select defs;

                WorkflowDefinition workflow = def.FirstOrDefault();

                if (workflow != null) {


                    // get all workflow associations
                    var workflowAssociations = workflowSubscriptionService.EnumerateSubscriptionsByDefinition(workflow.Id);
                    ctx.Load(workflowAssociations);
                    ctx.ExecuteQuery();

                    // find the first association
                    var firstWorkflowAssociation = workflowAssociations.First();

                    // start the workflow
                    var startParameters = new Dictionary<string, object>();

                    if (ctx.Web.ListExists(listName)) {
                        List list = ctx.Web.GetListByTitle(listName);

                        CamlQuery query = CamlQuery.CreateAllItemsQuery();
                        ListItemCollection items = list.GetItems(query);

                        // Retrieve all items in the ListItemCollection from List.GetItems(Query).
                        ctx.Load(items);
                        ctx.ExecuteQuery();
                        foreach (ListItem listItem in items) {
                            Console.WriteLine("Starting workflow for item: " + listItem.Id);
                            workflowInstanceService.StartWorkflowOnListItem(firstWorkflowAssociation, listItem.Id, startParameters);
                            ctx.ExecuteQuery();
                        }
                    }
                }
            }

            Console.WriteLine("Press any key to close....");
            Console.ReadKey();
        }

        private static string GetInput(string label, bool isPassword) {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("{0} : ", label);
            Console.ForegroundColor = ConsoleColor.Gray;

            string strPwd = "";

            for (ConsoleKeyInfo keyInfo = Console.ReadKey(true); keyInfo.Key != ConsoleKey.Enter; keyInfo = Console.ReadKey(true)) {
                if (keyInfo.Key == ConsoleKey.Backspace) {
                    if (strPwd.Length > 0) {
                        strPwd = strPwd.Remove(strPwd.Length - 1);
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        Console.Write(" ");
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    }
                } else if (keyInfo.Key != ConsoleKey.Enter) {
                    if (isPassword) {
                        Console.Write("*");
                    } else {
                        Console.Write(keyInfo.KeyChar);
                    }
                    strPwd += keyInfo.KeyChar;

                }

            }
            Console.WriteLine("");

            return strPwd;
        }
    }
}

