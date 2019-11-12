using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Configuration;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Microsoft.AzureCAT.Samples.InterRoleCommunication.Framework.Configuration;
using Microsoft.AzureCAT.Samples.InterRoleCommunication;
using Microsoft.AzureCAT.Samples.InterRoleCommunication.Contracts.Data;

namespace Microsoft.AzureCAT.Samples.InterRoleCommunication.Tests
{
    [TestClass]
    public class TopicBasedInterRoleCommunicationTests
    {
        private static ServiceBusEndpointInfo topicEndpoint;

        public TopicBasedInterRoleCommunicationTests()
        {
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            var serviceBusSettings = ConfigurationManager.GetSection(ServiceBusConfigurationSettings.SectionName) as ServiceBusConfigurationSettings;

            topicEndpoint = serviceBusSettings.Endpoints.Get(serviceBusSettings.DefaultEndpoint);
        }
        #endregion

        [TestMethod]
        public void TestSingleEvent()
        {
            using (InterRoleCommunicationExtension ircExtension = new InterRoleCommunicationExtension(topicEndpoint, new InterRoleCommunicationSettings() { EnableCarbonCopy = true }))
            {
                var subscriber1 = new EventCountingSubscriber();
                ircExtension.Subscribe(subscriber1);

                InterRoleCommunicationEvent ev = new InterRoleCommunicationEvent(new RoleGracefulRecycleEvent(typeof(TopicBasedInterRoleCommunicationTests).FullName));
                ircExtension.Publish(ev);

                Thread.Sleep(ircExtension.Settings.EventWaitTimeout.Add(TimeSpan.FromSeconds(5)));

                Assert.AreEqual<int>(1, subscriber1.OnNextCount);
            }
        }

        [TestMethod]
        public void TestSingleEventWithAsyncPublish()
        {
            using (InterRoleCommunicationExtension ircExtension = new InterRoleCommunicationExtension(topicEndpoint, new InterRoleCommunicationSettings() { EnableCarbonCopy = true, EnableAsyncPublish = true, EventWaitTimeout = TimeSpan.FromSeconds(3) }))
            {
                var subscriber1 = new EventCountingSubscriber();
                ircExtension.Subscribe(subscriber1);

                InterRoleCommunicationEvent ev = new InterRoleCommunicationEvent(new RoleGracefulRecycleEvent(typeof(TopicBasedInterRoleCommunicationTests).FullName));
                ircExtension.Publish(ev);

                while (subscriber1.OnNextCount == 0)
                {
                    Thread.Sleep(ircExtension.Settings.EventWaitTimeout.Add(TimeSpan.FromSeconds(5)));
                }

                Assert.AreEqual<int>(1, subscriber1.OnNextCount);
            }
        }

        [TestMethod]
        public void TestSingleEventWithNetworkFaultSimulation()
        {
            try
            {
                using (InterRoleCommunicationExtension ircExtension = new InterRoleCommunicationExtension(topicEndpoint, new InterRoleCommunicationSettings() { EnableCarbonCopy = true, EnableAsyncPublish = false, EventWaitTimeout = TimeSpan.FromSeconds(3) }))
                {
                    bool retryOccurred = false;

                    ircExtension.Settings.RetryPolicy.RetryOccurred += (currentRetryCount, ex, delay) =>
                    {
                        retryOccurred = true;
                        NetworkUtility.EnableNetworkAdapter();
                    };

                    var subscriber1 = new EventCountingSubscriber();
                    ircExtension.Subscribe(subscriber1);

                    NetworkUtility.DisableNetworkAdapter();

                    InterRoleCommunicationEvent ev = new InterRoleCommunicationEvent(new RoleGracefulRecycleEvent(typeof(TopicBasedInterRoleCommunicationTests).FullName));
                    ircExtension.Publish(ev);

                    while (subscriber1.OnNextCount == 0)
                    {
                        Thread.Sleep(ircExtension.Settings.EventWaitTimeout.Add(TimeSpan.FromSeconds(5)));
                    }

                    Assert.IsTrue(retryOccurred, "A retry condition does not seem to have occurred.");
                    Assert.AreEqual<int>(1, subscriber1.OnNextCount);
                }
            }
            finally
            {
                NetworkUtility.EnableNetworkAdapter();
            }
        }

        [TestMethod]
        public void TestSingleEventWithMultipleSubscribers()
        {
            using (InterRoleCommunicationExtension ircExtension = new InterRoleCommunicationExtension(topicEndpoint, new InterRoleCommunicationSettings() { EnableCarbonCopy = true }))
            {
                var subscriber1 = new EventCountingSubscriber();
                var subscriber2 = new EventCountingSubscriber();
                var subscriber3 = new EventCountingSubscriber();

                ircExtension.Subscribe(subscriber1);
                ircExtension.Subscribe(subscriber2);
                ircExtension.Subscribe(subscriber3);

                InterRoleCommunicationEvent ev = new InterRoleCommunicationEvent(new RoleGracefulRecycleEvent(typeof(TopicBasedInterRoleCommunicationTests).FullName));
                ircExtension.Publish(ev);

                Thread.Sleep(ircExtension.Settings.EventWaitTimeout.Add(TimeSpan.FromSeconds(5)));

                Assert.AreEqual<int>(1, subscriber1.OnNextCount);
                Assert.AreEqual<int>(1, subscriber2.OnNextCount);
                Assert.AreEqual<int>(1, subscriber3.OnNextCount);
            }
        }

        [TestMethod]
        public void TestSingleEventWithMultipleInstances()
        {
            using (InterRoleCommunicationExtension irc1 = new InterRoleCommunicationExtension(topicEndpoint, new InterRoleCommunicationSettings() { EnableCarbonCopy = true }))
            using (InterRoleCommunicationExtension irc2 = new InterRoleCommunicationExtension(topicEndpoint, new InterRoleCommunicationSettings() { EnableCarbonCopy = true }))
            using (InterRoleCommunicationExtension irc3 = new InterRoleCommunicationExtension(topicEndpoint, new InterRoleCommunicationSettings() { EnableCarbonCopy = true }))
            {
                var subscriber1 = new EventCountingSubscriber();

                irc1.Subscribe(subscriber1);
                irc2.Subscribe(subscriber1);
                irc3.Subscribe(subscriber1);

                InterRoleCommunicationEvent ev = new InterRoleCommunicationEvent(new RoleGracefulRecycleEvent(typeof(TopicBasedInterRoleCommunicationTests).FullName));

                irc1.Publish(ev);
                irc2.Publish(ev);
                irc3.Publish(ev);

                Thread.Sleep(irc3.Settings.EventWaitTimeout.Add(TimeSpan.FromSeconds(5)));

                Assert.AreEqual<int>(3 * 3, subscriber1.OnNextCount);
            }
        }

        [TestMethod]
        public void TestSingleEventWithMultipleInstancesNoCarbonCopy()
        {
            using (InterRoleCommunicationExtension irc1 = new InterRoleCommunicationExtension(topicEndpoint, new InterRoleCommunicationSettings() { EnableCarbonCopy = false }))
            using (InterRoleCommunicationExtension irc2 = new InterRoleCommunicationExtension(topicEndpoint, new InterRoleCommunicationSettings() { EnableCarbonCopy = false }))
            using (InterRoleCommunicationExtension irc3 = new InterRoleCommunicationExtension(topicEndpoint, new InterRoleCommunicationSettings() { EnableCarbonCopy = false }))
            {
                var subscriber1 = new EventCountingSubscriber();

                irc1.Subscribe(subscriber1);
                irc2.Subscribe(subscriber1);
                irc3.Subscribe(subscriber1);

                InterRoleCommunicationEvent ev = new InterRoleCommunicationEvent(new RoleGracefulRecycleEvent(typeof(TopicBasedInterRoleCommunicationTests).FullName));

                irc1.Publish(ev);
                irc2.Publish(ev);
                irc3.Publish(ev);

                Thread.Sleep(irc3.Settings.EventWaitTimeout.Add(TimeSpan.FromSeconds(5)));

                Assert.AreEqual<int>(3 * 2, subscriber1.OnNextCount);
            }
        }

        [TestMethod]
        public void TestSingleEventWithCompetingConsumers()
        {
            var ircSettings = new InterRoleCommunicationSettings() { UseCompetingConsumers = true, EventWaitTimeout = TimeSpan.FromSeconds(10) };

            using (InterRoleCommunicationExtension irc1 = new InterRoleCommunicationExtension(topicEndpoint, ircSettings))
            using (InterRoleCommunicationExtension irc2 = new InterRoleCommunicationExtension(topicEndpoint, ircSettings))
            using (InterRoleCommunicationExtension irc3 = new InterRoleCommunicationExtension(topicEndpoint, ircSettings))
            using (InterRoleCommunicationExtension irc4 = new InterRoleCommunicationExtension(topicEndpoint, ircSettings))
            {
                var subscriber1 = new EventCountingSubscriber();

                irc1.Subscribe(subscriber1);
                irc2.Subscribe(subscriber1);
                irc3.Subscribe(subscriber1);
                irc4.Subscribe(subscriber1);

                InterRoleCommunicationEvent ev = new InterRoleCommunicationEvent(new RoleGracefulRecycleEvent(typeof(TopicBasedInterRoleCommunicationTests).FullName));

                irc1.Publish(ev);
                irc1.Publish(ev);
                irc1.Publish(ev);

                Thread.Sleep(irc4.Settings.EventWaitTimeout.Add(TimeSpan.FromSeconds(5)));

                Assert.AreEqual<int>(3, subscriber1.OnNextCount);
            }
        }

        [TestMethod]
        public void TestMultipleEvents()
        {
            using (InterRoleCommunicationExtension ircExtension = new InterRoleCommunicationExtension(topicEndpoint, new InterRoleCommunicationSettings() { EnableCarbonCopy = true }))
            {
                var subscriber1 = new EventCountingSubscriber();
                ircExtension.Subscribe(subscriber1);

                int eventCount = 100;
                int waitAttemptCount = 0;

                for (int i = 0; i < eventCount; i++)
                {
                    ircExtension.Publish(new InterRoleCommunicationEvent(new RoleConfigurationSectionRefreshEvent(String.Format("Message #{0}", i))));
                }

                while (subscriber1.OnNextCount != eventCount)
                {
                    Thread.Sleep(ircExtension.Settings.EventWaitTimeout.Add(TimeSpan.FromSeconds(5)));
                    waitAttemptCount++;

                    if (waitAttemptCount > 10) break;
                }

                Assert.AreEqual<int>(eventCount, subscriber1.OnNextCount);
            }
        }

        private class EventCountingSubscriber : IObserver<InterRoleCommunicationEvent>
        {
            private int onCompletedCount;
            private int onErrorCount;
            private int onNextCount;

            public int OnCompletedCount { get { return this.onCompletedCount; } }
            public int OnErrorCount { get { return this.onErrorCount; } }
            public int OnNextCount { get { return this.onNextCount; } }

            public void OnCompleted()
            {
                Interlocked.Increment(ref this.onCompletedCount);
            }

            public void OnError(Exception error)
            {
                Interlocked.Increment(ref this.onErrorCount);
            }

            public void OnNext(InterRoleCommunicationEvent value)
            {
                Interlocked.Increment(ref this.onNextCount);
            }
        }
    }
}
