using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Workflow.Client;
using Microsoft.Workflow.Samples.Common;

namespace GetProductsWorkflowClient
{
    class Program
    {
        static string workflowName = "GetProductsWorkflow";
        // !!!!!!
        // YOU MUST SET THE baseAddress PROPERTY BELOW TO A FULLY QUALIFIED NAME OF YOUR WORKFLOW MANAGER ENDPOINT
        static string baseAddress = "https://<Base address>:12290/";
        
        static void Main(string[] args)
        {
            // The following code allows a client to use a non-fully qualified name and resolves https issues such as:
            // System.Net.WebException: The underlying connection was closed: Could not establish trust 
            // relationship for the SSL/TLS secure channel
            // NOT for production, only for limited local development. 
            //System.Net.ServicePointManager.ServerCertificateValidationCallback += delegate (object sender,
            //    System.Security.Cryptography.X509Certificates.X509Certificate certificate,
            //    System.Security.Cryptography.X509Certificates.X509Chain chain,
            //    System.Net.Security.SslPolicyErrors sslPolicyErrors)
            //{
            //    return true;
            //};

            Console.Write("Setting up scope...");
            WorkflowManagementClient client = WorkflowUtils.CreateForSample(baseAddress, "WFMgrGettingStarted");
            WorkflowUtils.PrintDone();

            Console.Write("Publishing GetProducts activity...");
            client.PublishActivity("GetProducts", @"..\..\..\GetProductsActivities\GetProducts.xaml");
            WorkflowUtils.PrintDone();

            Console.Write("Publishing Workflow...");
            client.PublishWorkflow(workflowName, @"..\..\..\GetProductsActivities\GetProductsWorkflow.xaml");
            WorkflowUtils.PrintDone();

            Console.Write("Enter a search keyword: ");
            string SearchKeyword = Console.ReadLine();

            Console.Write("Starting workflow instance...");
            WorkflowStartParameters startParameters = new WorkflowStartParameters();
            startParameters.Content.Add("SearchKeyword", SearchKeyword);
            string instanceId = client.Workflows.Start(workflowName, startParameters);
            WorkflowUtils.PrintDone();

            Console.WriteLine("\nPolling UserStatus...\n");
            string finalUserStatus = client.WaitForWorkflowCompletion(workflowName, instanceId);
            WorkflowUtils.Print("Completed with status: " + finalUserStatus, ConsoleColor.Green);

            Console.WriteLine("Press any key to clean up scope.");
            Console.ReadKey();

            client.CleanUp();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
