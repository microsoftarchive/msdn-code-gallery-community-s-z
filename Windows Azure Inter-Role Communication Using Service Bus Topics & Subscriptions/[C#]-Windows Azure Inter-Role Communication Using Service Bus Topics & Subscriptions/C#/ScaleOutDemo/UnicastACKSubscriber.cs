//=======================================================================================
// Microsoft Windows Azure Customer Advisory Team (CAT) Best Practices Series
//
// This sample is supplemental to the technical guidance published on the community
// blog at http://windowsazurecat.com/. 
//
//=======================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
// EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
// MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=======================================================================================
namespace ScaleOutDemo
{
    #region Using references
    using System;
    using System.Linq;
    using System.Threading;
    using System.Configuration;
    using System.Text.RegularExpressions;
    using System.Data.Services.Client;

    using Microsoft.WindowsAzure;
    using Microsoft.WindowsAzure.StorageClient;

    using Microsoft.AzureCAT.Samples.InterRoleCommunication;
    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Contracts.Data;
    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Framework.Instrumentation;

    using ScaleOutDemo.Contracts.Data;
    using Microsoft.WindowsAzure.ServiceRuntime;
    #endregion

    public class UnicastACKSubscriber : InterRoleCommunicationEventSubscriberBase<DemoPayload>
    {
        private readonly IInterRoleCommunicationExtension interRoleCommunicator;
        private readonly CloudTableClient tableClient;
        private readonly string tableName;
        private int ackCount, maxAckCount;

        public UnicastACKSubscriber(IInterRoleCommunicationExtension communicator, CloudTableClient tableClient, string tableName)
        {
            this.tableClient = tableClient;
            this.tableName = tableName;
            this.interRoleCommunicator = communicator;
        }

        /// <summary>
        /// Receives a notification when a new inter-role communication event occurs.
        /// </summary>
        public override void OnNext(DemoPayload msg)
        {
            msg.AckReceivedTickCount = HighResolutionTimer.CurrentTickCount;
            msg.AckReceivedTime = DateTime.UtcNow;
            msg.MulticastResponseTime = Convert.ToInt64((msg.ReceiveTime - msg.PublishTime).TotalMilliseconds);
            msg.UnicastResponseTime = Convert.ToInt64((msg.AckReceivedTime - msg.ReceiveTime).TotalMilliseconds);
            msg.TotalResponseTime = Convert.ToInt64((msg.AckReceivedTime - msg.PublishTime).TotalMilliseconds);

            // Store the msg in Azure Table Storage
            TestResultTableEntity result = new TestResultTableEntity()
            {
                IterationID = msg.IterationID,
                MsgId = msg.MsgId,
                FromInstanceID = msg.FromInstanceID,
                ReceiveTime = msg.ReceiveTime,
                ReceiveTickCount = msg.ReceiveTickCount,
                PublishTime = msg.PublishTime,
                PublishTickCount = msg.PublishTickCount,
                MulticastResponseTime = msg.MulticastResponseTime,
                AckReceivedTime = msg.AckReceivedTime,
                AckReceivedTickCount = msg.AckReceivedTickCount,
                UnicastResponseTime = msg.UnicastResponseTime,
                TotalResponseTime = msg.TotalResponseTime,
                NumReceivers = msg.NumReceivers,
                ToInstanceID = msg.ToInstanceID
            };

            using (TraceManager.WorkerRoleComponent.TraceScope("Update results table for Message ID", msg.MsgId))
            {
                var resultTable = new TestResultEntityTableContext(this.tableClient.BaseUri.ToString(), tableClient.Credentials);
                resultTable.TableName = this.tableName;

                try
                {
                    resultTable.AddResults(result);
                }
                catch (DataServiceRequestException ex)
                {
                    if (ex.IsEntityAlreadyExists())
                    {
                        resultTable.UpdateResults(result);
                    }
                }
            }
            
            if (Interlocked.Increment(ref this.ackCount) == this.maxAckCount)
            {
                ResetAckCounter();
                GenerateTestRunStats(msg.IterationID);
            }

            TraceManager.WorkerRoleComponent.TraceInfo("#### Received and processed {0} ACKs from test clients ####", this.ackCount);
        }

        /// <summary>
        /// Gets notified that the provider has successfully finished sending notifications to all observers.
        /// </summary>
        public override void OnCompleted()
        {
            // Doesn't have to do anything upon completion.
        }

        /// <summary>
        /// Gets notified that the provider has experienced an error condition.
        /// </summary>
        public override void OnError(Exception ex)
        {
            // Report on the error through common logging/tracing infrastructure.
            TraceManager.WorkerRoleComponent.TraceError(ex);
        }

        public void SetExpectedAckCount(int ackCount)
        {
            TraceManager.WorkerRoleComponent.TraceInfo("#### Expecting {0} ACKs to complete the test ####", ackCount);
            this.maxAckCount = ackCount;
        }

        public void ResetAckCounter()
        {
            this.ackCount = 0;
        }

        /// <summary>
        /// Filter the Results Table and generate stats for a particular test RUN
        /// </summary>
        /// <param name="testRunID"></param>
        /// <returns></returns>
        private void GenerateTestRunStats(Guid testRunID)
        {
            DateTime testRunFinished = DateTime.UtcNow;
            long minUnicastLatency = 0, maxUnicastLatency = 0, minMulticastLatency = 0, maxMulticastLatency = 0;
            double avgUnicastLatency = 0, avgMulticastLatency = 0;

            using (TraceManager.WorkerRoleComponent.TraceScope("Generating stats for test run: ", testRunID))
            {
                var resultTable = new TestResultEntityTableContext(this.tableClient.BaseUri.ToString(), this.tableClient.Credentials);
                resultTable.TableName = this.tableName;

                var testRunTable = new TestRunEntityTableContext(this.tableClient.BaseUri.ToString(), this.tableClient.Credentials);
                testRunTable.TableName = ConfigurationManager.AppSettings[CommonConsts.ConfigSettingTestRunsTableName];

                try
                {
                    var testResults = from r in resultTable.DemoTestResults
                                      where r.PartitionKey == testRunID.ToString("N")
                                      select r;

                    if (testResults != null)
                    {
                        var tr = testResults.ToList();

                        if (tr != null && tr.Count > 0)
                        {
                            minUnicastLatency = tr.Min(f => f.UnicastResponseTime);
                            maxUnicastLatency = tr.Max(f => f.UnicastResponseTime);
                            avgUnicastLatency = tr.Average(f => f.UnicastResponseTime);

                            minMulticastLatency = tr.Min(f => f.MulticastResponseTime);
                            maxMulticastLatency = tr.Max(f => f.MulticastResponseTime);
                            avgMulticastLatency = tr.Average(f => f.MulticastResponseTime);
                        }
                    }

                    var testRun = (from r in testRunTable.GetTestRuns()
                                   where r.PartitionKey == testRunID.ToString("N")
                                   select r).FirstOrDefault();

                    if (testRun != null)
                    {
                        testRun.EndDateTime = testRunFinished;
                        testRun.AvgAckLatency = avgUnicastLatency;
                        testRun.AvgReqLatency = avgMulticastLatency;
                        
                        // Number of published messages (N1)
                        // Number of subscribers (S)
                        // Number of messages recevied by each subscriber (N2) 
                        // Number of ACKs published by each subscriber (N3) 
                        // Number of ACKs receieved by publisher (N4) 
                        // Formula for throughput (msg/sec) calculation: (N1 + (N2 * S) + (N3 * S) + (N4 * S)) / Duration (seconds)
                        testRun.Throughput = Convert.ToDouble(testRun.MessageCount + (testRun.MessageCount * testRun.InstanceCount) * 3) / (testRun.EndDateTime - testRun.StartDateTime).TotalSeconds;

                        // Update test run stats in the Windows Azure table.
                        testRunTable.UpdateTestRun(testRun);

                        TestRunFinishEvent finishEvent = new TestRunFinishEvent()
                        {
                            TestRunID = testRunID,
                            Duration = (testRun.EndDateTime - testRun.StartDateTime),
                            Throughput = testRun.Throughput,
                            MinUnicastLatency = minUnicastLatency,
                            AvgUnicastLatency = avgUnicastLatency,
                            MaxUnicastLatency = maxUnicastLatency,
                            MinMulticastLatency = minMulticastLatency,
                            AvgMulticastLatency = avgMulticastLatency,
                            MaxMulticastLatency = maxMulticastLatency
                        };

                        // Determine the role which will receive the TestRunFinishEvent event.
                        var targetRole = RoleEnvironment.Roles.Where(r => { return r.Value != RoleEnvironment.CurrentRoleInstance.Role; }).Select(i => i.Value).FirstOrDefault();

                        if (targetRole != null)
                        {
                            TraceManager.WorkerRoleComponent.TraceInfo("Sending TestRunFinishEvent for test run {0} to role {1}", testRunID, targetRole.Name);

                            // Send the TestRunFinishEvent instance back to the web role for visualization.
                            this.interRoleCommunicator.Publish(new InterRoleCommunicationEvent(finishEvent, roleName: targetRole.Name));
                        }
                    }
                }
                catch (Exception ex)
                {
                    TraceManager.WorkerRoleComponent.TraceError(ex);
                }
            }
        }
    }
}
