using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Management;
using Microsoft.WindowsAzure.Scheduler;
using Microsoft.WindowsAzure.Scheduler.Models;
using Microsoft.WindowsAzure.Management.Scheduler;
using Microsoft.WindowsAzure.Common.Internals;
using Microsoft.WindowsAzure.Management.Scheduler.Models;

namespace AzureScheduler
{
    class Schedular
    {
        // retrieve the windows azure managment certificate from current user
        public Schedular()
        {
            var store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadWrite);
            var certificate = store.Certificates.Find(X509FindType.FindByThumbprint, "<ThumbPrint>", false)[0];
            store.Close();
            //
            // create management credencials and cloud service management client
            var credentials = new CertificateCloudCredentials("8cb918af-59d0-4b24-893c-15661d048f16", certificate);
            var cloudServiceMgmCli = new CloudServiceManagementClient(credentials);

            // create cloud service
            var cloudServiceCreateParameters = new CloudServiceCreateParameters()
            {
                Description = "schedulerdemo1",
                Email = "microsoft.com",
                GeoRegion = "Southeast Asia",
                Label = "schedulerdemo1"
            };
            var cloudService = cloudServiceMgmCli.CloudServices.Create("schedulerdemo1", cloudServiceCreateParameters);
            // create job collection
            var schedulerMgmCli = new SchedulerManagementClient(credentials);
            var jobCollectionIntrinsicSettings = new JobCollectionIntrinsicSettings()
            {
                Plan = JobCollectionPlan.Free,
                Quota = new JobCollectionQuota()
                {
                    MaxJobCount = 5,
                    MaxJobOccurrence = 1,
                    MaxRecurrence = new JobCollectionMaxRecurrence()
                     {
                         Frequency = JobCollectionRecurrenceFrequency.Hour,
                         Interval = 1
                     }
                }
            };
            var jobCollectionCreateParameters = new JobCollectionCreateParameters()
            {
                IntrinsicSettings = jobCollectionIntrinsicSettings,
                Label = "jc1"
            };
            var jobCollectionCreateResponse = schedulerMgmCli.JobCollections.Create("schedulerdemo1", "jc1", jobCollectionCreateParameters);

            var schedulerClient = new SchedulerClient("schedulerdemo1", "jc1", credentials);
            var jobAction = new JobAction()
            {
                Type = JobActionType.Http,
                Request = new JobHttpRequest()
                {
                    Uri = new Uri("http://blog.shaunxu.me"),
                    Method = "GET"
                }
            };
            var jobRecurrence = new JobRecurrence()
            {
                Frequency = JobRecurrenceFrequency.Hour,
                Interval = 1
            };
            var jobCreateOrUpdateParameters = new JobCreateOrUpdateParameters()
            {
                Action = jobAction,
                Recurrence = jobRecurrence
            };
            var jobCreateResponse = schedulerClient.Jobs.CreateOrUpdate("poll_blog", jobCreateOrUpdateParameters);

            var jobGetHistoryParameters = new JobGetHistoryParameters()
                 {
                     Skip = 0,
                     Top = 100
                 };
            var history = schedulerClient.Jobs.GetHistory("poll_blog", jobGetHistoryParameters);
            foreach (var action in history)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", action.Status, action.Message, action.RetryCount, action.RepeatCount, action.Timestamp);
            }

        }
    }
}