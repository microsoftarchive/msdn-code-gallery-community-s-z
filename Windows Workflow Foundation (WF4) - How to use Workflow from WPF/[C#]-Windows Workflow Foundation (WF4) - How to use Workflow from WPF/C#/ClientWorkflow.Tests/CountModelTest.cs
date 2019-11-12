namespace ClientWorkflow.Tests
{
    using System;
    using System.Threading;

    using ClientWorkflow.Model;

    using Microsoft.Activities.UnitTesting.Tracking;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CountModelTest
    {
        #region Constants and Fields

        private const int TestTimeout = 1000;

        #endregion

        #region Properties

        ///<summary>
        ///  Gets or sets the test context which provides
        ///  information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        #endregion

        #region Public Methods

        [TestMethod]
        public void ShouldCancelCountAsync()
        {
            const int expected = 10;
            var countUpdated = new AutoResetEvent(false);
            var countCanceled = new AutoResetEvent(false);
            var tracking = new MemoryTrackingParticipant();
            var target = CountModelFactory.CreateModel(tracking);

            target.CountUpdated = i =>
                {
                    if (i == 5)
                    {
                        countUpdated.Set();
                    }
                };

            target.CountCanceled = () => countCanceled.Set();

            try
            {
                target.StartCounting(expected);

                // Wait for the first update
                Assert.IsTrue(countUpdated.WaitOne(TestTimeout));
                target.BeginCancelCounting(target.EndCancelCounting, null);

                // Wait for the cancel
                Assert.IsTrue(countCanceled.WaitOne(TestTimeout));
            }
            finally
            {
                tracking.Trace();
            }
        }

        [TestMethod]
        public void ShouldCancelCountAt5()
        {
            const int expected = 10;
            var countUpdated = new AutoResetEvent(false);
            var countCanceled = new AutoResetEvent(false);
            var tracking = new MemoryTrackingParticipant();
            var target = CountModelFactory.CreateModel(tracking);

            target.CountUpdated = i =>
                {
                    if (i == 5)
                    {
                        countUpdated.Set();
                    }
                };

            target.CountCanceled = () => countCanceled.Set();

            try
            {
                target.StartCounting(expected);

                // Wait for the first update
                Assert.IsTrue(countUpdated.WaitOne(TestTimeout));
                target.CancelCounting();

                // Wait for the cancel
                Assert.IsTrue(countCanceled.WaitOne(TestTimeout));
            }
            finally
            {
                tracking.Trace();
            }
        }

        [TestMethod]
        public void ShouldCountTo10()
        {
            var actual = -1;
            const int expected = 10;
            var tracking = new MemoryTrackingParticipant();
            var target = CountModelFactory.CreateModel(tracking);

            var countCompleted = new AutoResetEvent(false);

            target.CountCompleted = () => countCompleted.Set();
            target.CountUpdated = i => actual = i;

            try
            {
                target.StartCounting(expected);
                Assert.IsTrue(countCompleted.WaitOne(TestTimeout));
                Assert.AreEqual(expected, actual);
            }
            finally
            {
                tracking.Trace();
            }
        }

        [TestMethod]
        public void ShouldRaiseCompleteEvent()
        {
            var tracking = new MemoryTrackingParticipant();
            var target = CountModelFactory.CreateModel(tracking);
            var countCompleted = new AutoResetEvent(false);

            target.CountCompleted = () => countCompleted.Set();

            try
            {
                target.StartCounting(1);
                Assert.IsTrue(countCompleted.WaitOne(TestTimeout));
            }
            finally
            {
                tracking.Trace();
            }
        }

        [TestMethod]
        public void ShouldRaiseCountUpdateEvent()
        {
            var tracking = new MemoryTrackingParticipant();
            var target = CountModelFactory.CreateModel(tracking);
            var updateEventRaised = false;
            var countCompleted = new AutoResetEvent(false);

            target.CountUpdated = i => updateEventRaised = true;
            target.CountCompleted = () => countCompleted.Set();

            try
            {
                target.StartCounting(1);
                Assert.IsTrue(countCompleted.WaitOne(TestTimeout));
                Assert.IsTrue(updateEventRaised);
            }
            finally
            {
                tracking.Trace();
            }
        }

        [TestMethod]
        public void ShouldRaiseStartEvent()
        {
            var tracking = new MemoryTrackingParticipant();
            var target = CountModelFactory.CreateModel(tracking);
            var startEventRaised = false;
            var countCompleted = new AutoResetEvent(false);

            target.CountStarted = () => startEventRaised = true;
            target.CountCompleted = () => countCompleted.Set();
            try
            {
                target.StartCounting(1);
                Assert.IsTrue(countCompleted.WaitOne(TestTimeout));

                Assert.IsTrue(startEventRaised);
            }
            finally
            {
                tracking.Trace();
            }
        }

        [TestMethod]
        public void ShouldUseDelayWhenCounting()
        {
            const int expected = 5;
            var countCompleted = new AutoResetEvent(false);
            var tracking = new MemoryTrackingParticipant();

            var target = CountModelFactory.CreateModel(tracking);
            target.CountCompleted = () => countCompleted.Set();

            try
            {
                var start = DateTime.Now;
                target.StartCounting(expected, 10);
                Assert.IsTrue(countCompleted.WaitOne(TestTimeout));

                var stop = DateTime.Now;

                // Should be at least 50msecs
                Assert.IsTrue(stop.Subtract(start).Milliseconds >= 50);
            }
            finally
            {
                tracking.Trace();
            }
        }

        [TestMethod]
        public void WhenCountIsCanceledNoCompleteEventShouldBeRaised()
        {
            var countUpdated = new AutoResetEvent(false);
            var countCanceled = new AutoResetEvent(false);

            const int expected = 10;
            var tracking = new MemoryTrackingParticipant();
            var target = CountModelFactory.CreateModel(tracking);

            // Trigger the sync event on the first count
            target.CountUpdated = i => countUpdated.Set();

            target.CountCanceled = () => countCanceled.Set();
            target.CountCompleted = () => countCanceled.Set();

            try
            {
                target.StartCounting(expected);

                // Wait for the first update
                Assert.IsTrue(countUpdated.WaitOne(TestTimeout));
                target.CancelCounting();

                // Wait for the cancel
                Assert.IsTrue(countCanceled.WaitOne(TestTimeout));
            }
            finally
            {
                tracking.Trace();
            }
        }

        #endregion
    }
}