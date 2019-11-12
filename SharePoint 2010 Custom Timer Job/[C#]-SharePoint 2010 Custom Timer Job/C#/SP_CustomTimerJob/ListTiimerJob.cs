using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

namespace DotnetFinder
{
    class ListTimerJob : SPJobDefinition
    {
        public ListTimerJob()

            : base()
        {

        }

        public ListTimerJob(string jobName, SPService service, SPServer server, SPJobLockType targetType)

            : base(jobName, service, server, targetType)
        {

        }

        public ListTimerJob(string jobName, SPWebApplication webApplication)

            : base(jobName, webApplication, null, SPJobLockType.ContentDatabase)
        {

            this.Title = "List Timer Job";

        }

        public override void Execute(Guid contentDbId)
        {

            // get a reference to the current site collection's content database

            SPWebApplication webApplication = this.Parent as SPWebApplication;

            SPContentDatabase contentDb = webApplication.ContentDatabases[contentDbId];

            // get a reference to the "ListTimerJob" list in the RootWeb of the first site collection in the content database

            SPList Listjob = contentDb.Sites[0].RootWeb.Lists["ListTimerJob"];

            // create a new list Item, set the Title to the current day/time, and update the item

            SPListItem newList = Listjob.Items.Add();

            newList["Title"] = DateTime.Now.ToString();

            newList.Update();

        }
    }
}