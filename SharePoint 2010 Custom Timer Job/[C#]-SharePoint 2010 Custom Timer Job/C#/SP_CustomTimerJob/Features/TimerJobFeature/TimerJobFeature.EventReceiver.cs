using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Security;
using Microsoft.SharePoint.Administration;

namespace DotnetFinder.Features.Feature1
{
    [Guid("dfeeb3f4-3c70-4dcb-b09a-11ca8c9ad898")]
    public class Feature1EventReceiver : SPFeatureReceiver
    {
        const string List_JOB_NAME = "ListLogger";
        // Uncomment the method below to handle the event raised after a feature has been activated.

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            SPSite site = properties.Feature.Parent as SPSite;

            // make sure the job isn't already registered

            foreach (SPJobDefinition job in site.WebApplication.JobDefinitions)
            {

                if (job.Name == List_JOB_NAME)

                    job.Delete();

            }

            // install the job

            ListTimerJob listLoggerJob = new ListTimerJob(List_JOB_NAME, site.WebApplication);

            SPMinuteSchedule schedule = new SPMinuteSchedule();

            schedule.BeginSecond = 0;

            schedule.EndSecond = 59;

            schedule.Interval = 5;

            listLoggerJob.Schedule = schedule;

            listLoggerJob.Update();

        }

        // Uncomment the method below to handle the event raised before a feature is deactivated.

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            SPSite site = properties.Feature.Parent as SPSite;

            // delete the job

            foreach (SPJobDefinition job in site.WebApplication.JobDefinitions)
            {

                if (job.Name == List_JOB_NAME)

                    job.Delete();

            }

        }

    }
}