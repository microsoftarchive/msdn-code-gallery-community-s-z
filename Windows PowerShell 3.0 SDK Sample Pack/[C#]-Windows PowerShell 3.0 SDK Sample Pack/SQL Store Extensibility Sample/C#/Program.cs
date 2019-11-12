// <copyright file="AssemblyInfo.cs" company="Microsoft Corporation">
// Copyright (c) 2012 Microsoft Corporation. All rights reserved.
// </copyright>
// DISCLAIMER OF WARRANTY: The software is licensed “as-is.” You 
// bear the risk of using it. Microsoft gives no express warranties, 
// guarantees or conditions. You may have additional consumer rights 
// under your local laws which this agreement cannot change. To the extent 
// permitted under your local laws, Microsoft excludes the implied warranties 
// of merchantability, fitness for a particular purpose and non-infringement.

using System;
using System.Linq;
using System.Activities;
using System.Activities.Statements;
using Microsoft.PowerShell.Workflow;
using System.Collections.Generic;
using System.Threading;
using System.Management.Automation;
using System.IO;
using System.Data.SqlClient;

namespace SQLStoreExtensibilitySample
{

    class Program
    {
        static void Main(string[] args)
        {
            // Creat a variable for the workflow path.
            string workflowFileName = "SampleWorkflow.xaml";
            // Specify the database server name and instace before executing this command.
            string dbServer = "ServerName\\InstanceName";
            string database = "M3PExtendedStore";

            // Read the XAML into the variable
            string xaml = File.ReadAllText(workflowFileName);

            string conString = GetConnectionString(dbServer, database);

            // Create a runtime to host the application, passing the custom configuration provider.
            PSWorkflowRuntime runtime = new PSWorkflowRuntime(new SampleConfigurationProvider(conString));

            // Parameters to the workflow can be provided in this dictionary
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            // Create the job, providing the XAML definition.
            PSWorkflowJob job = runtime.JobManager.CreateJob(Guid.NewGuid(), xaml, "Get-CurrentProcess", "SampleWorkflow", parameters);

            // Subscribe to the state change event before starting the job.
            AutoResetEvent wfEvent = new AutoResetEvent(false);
            job.StateChanged += delegate(object sender, JobStateEventArgs e)
            {
                switch (e.JobStateInfo.State)
                {
                    case JobState.Failed:
                    case JobState.Completed:
                    case JobState.Suspended:
                        {
                            wfEvent.Set();
                        }
                        break;
                }
            };

            // Start the job
            job.StartJob();

            // Wait for the state changes event
            wfEvent.WaitOne();

            // Check whether the workflow is in the suspended state.
            if (job.JobStateInfo.State == JobState.Suspended)
            {
                Console.WriteLine("The job has suspended successfully.");
            }
            else
            {
                // If not, inform the user that the job was not suspended.
                Console.WriteLine("The job has not reached a desired state.");
                Console.ReadLine();
                return;
            }


            Console.WriteLine("Resuming the job.");
            // Resume
            job.ResumeJob();

            // Wait for the state changes event
            wfEvent.WaitOne();

            // The workfow should be completed
            if (job.JobStateInfo.State == JobState.Completed)
            {
                Console.WriteLine("The job has completed successfully.");
                Console.WriteLine("Total Process found: " + job.PSWorkflowInstance.Streams.OutputStream.Count);
            }
            else
                Console.WriteLine("The job has Failed.");

            Console.WriteLine("Press <Enter> to continue...");
            Console.ReadLine();
        }

        // This function is responsible for the creation of the SQL connection string.
        private static String GetConnectionString(string server, string database)
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = server,
                InitialCatalog = database,
                IntegratedSecurity = true,
                MultipleActiveResultSets = false // http://support.microsoft.com/kb/2019021
            };

            return connectionStringBuilder.ToString();
        }

    }
}
