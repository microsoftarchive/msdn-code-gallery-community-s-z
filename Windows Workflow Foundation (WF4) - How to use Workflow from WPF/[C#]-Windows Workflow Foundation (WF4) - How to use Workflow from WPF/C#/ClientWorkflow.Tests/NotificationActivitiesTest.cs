namespace ClientWorkflow.Tests
{
    using System.Activities;

    using ClientWorkflow.Model;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class NotificationActivitiesTest
    {
        #region Properties

        ///<summary>
        ///  Gets or sets the test context which provides
        ///  information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        #endregion

        #region Public Methods

        [TestMethod]
        public void NotifyCanceledShouldNotify()
        {
            var model = CountModelFactory.CreateModel();
            var cancelNotified = false;
            model.CountCanceled = () => cancelNotified = true;
            var invoker = new WorkflowInvoker(new NotifyCountCanceled());
            invoker.Extensions.Add(model);

            invoker.Invoke();

            Assert.IsTrue(cancelNotified);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void NotifyCanceledShouldThrowOnNoExtension()
        {
            WorkflowInvoker.Invoke(new NotifyCountCanceled());
        }

        [TestMethod]
        public void NotifyCanceledWithNoDelegateShouldDoNothing()
        {
            var model = CountModelFactory.CreateModel();
            var invoker = new WorkflowInvoker(new NotifyCountCanceled());
            invoker.Extensions.Add(model);

            invoker.Invoke();
            // No exception is success
        }

        [TestMethod]
        public void NotifyCompletedShouldNotify()
        {
            var model = CountModelFactory.CreateModel();
            var completeNotified = false;
            model.CountCompleted = () => completeNotified = true;
            var invoker = new WorkflowInvoker(new NotifyCountCompleted());
            invoker.Extensions.Add(model);

            invoker.Invoke();

            Assert.IsTrue(completeNotified);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void NotifyCompletedShouldThrowOnNoExtension()
        {
            WorkflowInvoker.Invoke(new NotifyCountCompleted());
        }

        [TestMethod]
        public void NotifyCompletedWithNoDelegateShouldDoNothing()
        {
            var model = CountModelFactory.CreateModel();
            var invoker = new WorkflowInvoker(new NotifyCountCompleted());
            invoker.Extensions.Add(model);

            invoker.Invoke();
            // No exception is success
        }

        [TestMethod]
        public void NotifyStartedShouldNotify()
        {
            var model = CountModelFactory.CreateModel();
            var startNotified = false;
            model.CountStarted = () => startNotified = true;
            var invoker = new WorkflowInvoker(new NotifyCountStarted());
            invoker.Extensions.Add(model);

            invoker.Invoke();

            Assert.IsTrue(startNotified);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void NotifyStartedShouldThrowOnNoExtension()
        {
            WorkflowInvoker.Invoke(new NotifyCountStarted());
        }

        [TestMethod]
        public void NotifyStartedWithNoDelegateShouldDoNothing()
        {
            var model = CountModelFactory.CreateModel();
            var invoker = new WorkflowInvoker(new NotifyCountStarted());
            invoker.Extensions.Add(model);

            invoker.Invoke();
            // No exception is success
        }

        [TestMethod]
        public void NotifyUpdatedShouldNotify()
        {
            var model = CountModelFactory.CreateModel();
            var updateNotified = false;
            var actual = 0;
            const int expected = 32;

            // The delegate will be invoked with the count
            model.CountUpdated = i =>
                {
                    updateNotified = true;
                    actual = i;
                };

            var invoker = new WorkflowInvoker(
                new NotifyCountUpdated
                    {
                        CurrentCount = expected
                    });
            invoker.Extensions.Add(model);

            invoker.Invoke();

            Assert.IsTrue(updateNotified);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void NotifyUpdatedShouldThrowOnNoExtension()
        {
            WorkflowInvoker.Invoke(new NotifyCountUpdated());
        }

        [TestMethod]
        public void NotifyUpdatedWithNoDelegateShouldDoNothing()
        {
            var model = CountModelFactory.CreateModel();
            var invoker = new WorkflowInvoker(new NotifyCountUpdated());
            invoker.Extensions.Add(model);

            invoker.Invoke();
            // No exception is success
        }

        #endregion
    }
}