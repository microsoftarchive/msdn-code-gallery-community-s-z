namespace ClientWorkflow.Tests
{
    using System.Threading;

    using ClientWorkflow.WPF;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    ///<summary>
    ///  This is a test class for CounterViewModelTest and is intended
    ///  to contain all CounterViewModelTest Unit Tests
    ///</summary>
    [TestClass]
    public class CounterViewModelTest
    {
        #region Properties

        ///<summary>
        ///  Gets or sets the test context which provides
        ///  information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        #endregion

        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //

        #region Public Methods

        ///<summary>
        ///  Verifies that the CancelCounting command is enabled/disabled as expected
        ///</summary>
        [TestMethod]
        public void CanCancelCountingTest()
        {
            var target = new CounterViewModel();
            var countStarted = new AutoResetEvent(false);
            var countCompleted = new AutoResetEvent(false);
            target.CountStarted += () => countStarted.Set();
            target.CountCompleted += () => countCompleted.Set();

            Assert.IsFalse(target.CanCancelCounting(), "Cancel command is not disabled");

            target.CountTo = 5;
            target.StartCounting();

            Assert.IsTrue(countStarted.WaitOne(1000));

            Assert.IsTrue(target.CanCancelCounting(), "Cancel command is not enabled");

            Assert.IsTrue(countCompleted.WaitOne(1000));

            Assert.IsFalse(target.CanCancelCounting(), "Cancel command is not disabled");
        }

        ///<summary>
        ///  Verifies that the StartCounting command is enabled/disabled as expected
        ///</summary>
        [TestMethod]
        public void CanStartCountingTest()
        {
            var target = new CounterViewModel();
            var countStarted = new AutoResetEvent(false);
            var countCompleted = new AutoResetEvent(false);
            target.CountStarted += () => countStarted.Set();
            target.CountCompleted += () => countCompleted.Set();

            Assert.IsTrue(target.CanStartCounting(), "Start command is not enabled");

            target.CountTo = 5;
            target.StartCounting();

            Assert.IsTrue(countStarted.WaitOne(1000));

            Assert.IsFalse(target.CanStartCounting(), "Start command is not disabled");

            Assert.IsTrue(countCompleted.WaitOne(1000));

            Assert.IsTrue(target.CanStartCounting(), "Start command is not enabled");
        }

        ///<summary>
        ///  A test for CancelCounting
        ///</summary>
        [TestMethod]
        public void CancelCountingCommandTest()
        {
            var target = new CounterViewModel();
            var countStarted = new AutoResetEvent(false);
            var countCanceled = new AutoResetEvent(false);
            target.CountStarted += () => countStarted.Set();
            target.CountCanceled += () => countCanceled.Set();

            target.CountTo = 5;
            target.StartCounting();

            Assert.IsTrue(countStarted.WaitOne(1000));

            target.CancelCommand.Execute(null);

            Assert.IsTrue(countCanceled.WaitOne(1000));
            Assert.AreNotEqual(target.CountTo, target.CurrentCount, "Count finished - did not cancel");
        }

        ///<summary>
        ///  A test for CancelCounting
        ///</summary>
        [TestMethod]
        public void CancelCountingTest()
        {
            var target = new CounterViewModel();
            var countStarted = new AutoResetEvent(false);
            var countCanceled = new AutoResetEvent(false);
            target.CountStarted += () => countStarted.Set();
            target.CountCanceled += () => countCanceled.Set();

            target.CountTo = 5;
            target.StartCounting();

            Assert.IsTrue(countStarted.WaitOne(1000));

            target.CancelCounting();

            Assert.IsTrue(countCanceled.WaitOne(1000));
            Assert.AreNotEqual(target.CountTo, target.CurrentCount, "Count finished - did not cancel");
        }

        ///<summary>
        ///  A test for CountTo
        ///</summary>
        [TestMethod]
        public void CountToTest()
        {
            var target = new CounterViewModel();
            var countCompleted = new AutoResetEvent(false);
            target.CountCompleted += () => countCompleted.Set();

            var propertyChangedNotified = false;
            target.PropertyChanged += (o, e) =>
                {
                    if (e.PropertyName == "CountTo")
                    {
                        propertyChangedNotified = true;
                    }
                };

            const int expected = 1;

            target.CountTo = expected;
            target.StartCounting();

            Assert.IsTrue(countCompleted.WaitOne(1000));

            // Verify the we did count to CountTo
            Assert.AreEqual(expected, target.CurrentCount);

            // Verify that the PropertyChanged event was fired
            Assert.IsTrue(propertyChangedNotified);
        }

        ///<summary>
        ///  A test for CurrentCount
        ///</summary>
        [TestMethod]
        public void CurrentCountTest()
        {
            var target = new CounterViewModel();
            var countCompleted = new AutoResetEvent(false);
            target.CountCompleted += () => countCompleted.Set();
            var actual = 0;
            var propertyChangedNotified = false;
            target.PropertyChanged += (o, e) =>
                {
                    if (e.PropertyName == "CurrentCount")
                    {
                        actual = ((CounterViewModel)o).CurrentCount;
                        propertyChangedNotified = true;
                    }
                };

            const int expected = 2;

            target.CountTo = expected;
            target.StartCounting();

            Assert.IsTrue(countCompleted.WaitOne(1000));

            // Verify CurrentCount did update
            Assert.AreEqual(expected, actual);

            // Verify that the PropertyChanged event was fired
            Assert.IsTrue(propertyChangedNotified);
        }

        ///<summary>
        ///  A test for IsCounting
        ///</summary>
        [TestMethod]
        public void IsCountingTest()
        {
            var target = new CounterViewModel();
            var countStarted = new AutoResetEvent(false);
            var countCompleted = new AutoResetEvent(false);
            target.CountStarted += () => countStarted.Set();
            target.CountCompleted += () => countCompleted.Set();
            var actual = new bool[2];
            var actualIndex = 0;
            var propertyChangedNotified = false;
            target.PropertyChanged += (o, e) =>
                {
                    if (e.PropertyName == "IsCounting")
                    {
                        actual[actualIndex] = ((CounterViewModel)o).IsCounting;
                        actualIndex++;
                        propertyChangedNotified = true;
                    }
                };

            const int expected = 1;

            target.CountTo = expected;
            target.StartCounting();

            Assert.IsTrue(countStarted.WaitOne(1000));
            // IsCounting will be updated twice, true at start, then false when done
            Assert.IsTrue(actual[0]);

            Assert.IsTrue(countCompleted.WaitOne(1000));
            Assert.IsFalse(actual[1]);

            // Verify that the PropertyChanged event was fired
            Assert.IsTrue(propertyChangedNotified);
        }

        ///<summary>
        ///  A test for StartCommand
        ///</summary>
        [TestMethod]
        public void StartCommandTest()
        {
            var target = new CounterViewModel();
            var countCompleted = new AutoResetEvent(false);
            target.CountCompleted += () => countCompleted.Set();

            target.CountTo = 5;
            target.StartCommand.Execute(null);

            Assert.IsTrue(countCompleted.WaitOne(1000));
            Assert.AreEqual(target.CountTo, target.CurrentCount, "Count did not complete");
        }

        ///<summary>
        ///  A test for StartCounting
        ///</summary>
        [TestMethod]
        public void StartCountingTest()
        {
            var target = new CounterViewModel();
            var countCompleted = new AutoResetEvent(false);
            target.CountCompleted += () => countCompleted.Set();

            target.CountTo = 5;
            target.StartCounting();

            Assert.IsTrue(countCompleted.WaitOne(1000));
            Assert.AreEqual(target.CountTo, target.CurrentCount, "Count did not complete");
        }

        ///<summary>
        ///  A test for Status
        ///</summary>
        [TestMethod]
        public void StatusTest()
        {
            var target = new CounterViewModel();
            var countStarted = new AutoResetEvent(false);
            var countCompleted = new AutoResetEvent(false);
            target.CountStarted += () => countStarted.Set();
            target.CountCompleted += () => countCompleted.Set();
            var expected = new[]
                {
                    "Count Started",
                    "Count is 1",
                    "Count Completed"
                };
            var actual = new string[3];
            var index = 0;
            var propertyChangedNotified = false;
            target.PropertyChanged += (o, e) =>
                {
                    if (e.PropertyName == "Status")
                    {
                        actual[index] = ((CounterViewModel)o).Status;
                        Assert.AreEqual(expected[index], actual[index]);
                        index++;
                        propertyChangedNotified = true;
                    }
                };

            Assert.AreEqual("Ready!", target.Status);

            target.CountTo = 1;
            target.StartCounting();

            Assert.IsTrue(countCompleted.WaitOne(1000));

            // Verify that the PropertyChanged event was fired
            Assert.IsTrue(propertyChangedNotified);
            Assert.AreEqual(3, index);
        }

        #endregion
    }
}