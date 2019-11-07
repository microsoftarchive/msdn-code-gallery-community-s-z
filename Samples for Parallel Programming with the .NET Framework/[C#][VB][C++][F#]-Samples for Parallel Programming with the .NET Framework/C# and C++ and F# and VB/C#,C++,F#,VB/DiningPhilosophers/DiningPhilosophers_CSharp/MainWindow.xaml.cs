//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: MainWindow.xaml.cs
//
//--------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Async;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DiningPhilosophers
{
    /// <summary>Application logic.</summary>
    public partial class MainWindow : Window
    {
        /// <summary>The number of philosophers to employ in the simulation.</summary>
        private const int NUM_PHILOSOPHERS = 5;
        /// <summary>The timescale to use for thinking and eating (any positive value; the larger, the linearly longer amount of time).</summary>
        private const int TIMESCALE = 200;
        /// <summary>The philosophers, represented as Ellipse WPF objects.</summary>
        private Ellipse[] _philosophers;
        /// <summary>A TaskFactory for running tasks on the UI.</summary>
        private TaskFactory _ui;

        /// <summary>Initializes the MainWindow.</summary>
        public MainWindow()
        {
            // Initialize the component's layout
            InitializeComponent();

            // Grab a TaskFactory for creating Tasks that run on the UI.
            _ui = new TaskFactory(TaskScheduler.FromCurrentSynchronizationContext());

            // Initialize the philosophers, and then run them.
            ConfigurePhilosophers();

            // Uncomment one of the following three lines
            RunWithSemaphoresSyncWithOrderedForks();  // 1. use synchronous semaphores, with ordered forks
            //RunWithSemaphoresSyncWithWaitAll();  // 2. use synchronous semaphores, with WaitAll
            //RunWithSemaphoresAsync(); // 3. use asynchronous semaphores
        }

        #region Colors
        /// <summary>A brush for rendering thinking philosophers.</summary>
        private Brush _think = Brushes.Yellow;
        /// <summary>A brush for rendering eating philosophers.</summary>
        private Brush _eat = Brushes.Green;
        /// <summary>A brush for rendering waiting philosophers.</summary>
        private Brush _wait = Brushes.Red;
        #endregion

        #region Helpers
        /// <summary>Initialize the philosophers.</summary>
        /// <param name="numPhilosophers">The number of philosophers to initialize.</param>
        private void ConfigurePhilosophers()
        {
            _philosophers = (from i in Enumerable.Range(0, NUM_PHILOSOPHERS) select new Ellipse { Height = 75, Width = 75, Fill = Brushes.Red, Stroke = Brushes.Black }).ToArray();
            foreach (var philosopher in _philosophers) circularPanel1.Children.Add(philosopher);
        }

        /// <summary>Gets the fork IDs of the forks for a particular philosopher.</summary>
        /// <param name="philosopherIndex">The index of the philosopher whose IDs are being retrieved.</param>
        /// <param name="numForks">The number of forks that exist.</param>
        /// <param name="left">The ID of the philosopher's left fork.</param>
        /// <param name="right">The ID of the philosopher's right fork.</param>
        /// <param name="sort">Whether to sort the forks, so that the left fork is always smaller than the right.</param>
        private void GetForkIds(int philosopherIndex, int numForks, out int left, out int right, bool sort)
        {
            // The forks for a philosopher are the ones at philosopherIndex and philosopherIndex+1, though
            // the latter can wrap around.  We need to ensure they're always acquired in the right order, to
            // prevent deadlock, so order them.
            left = philosopherIndex;
            right = (philosopherIndex + 1) % numForks;
            if (sort && left > right)
            {
                int tmp = left;
                left = right;
                right = tmp;
            }
        }
        #endregion

        #region Synchronous, Ordered
        /// <summary>Runs the philosophers utilizing one thread per philosopher.</summary>
        private void RunWithSemaphoresSyncWithOrderedForks()
        {
            var forks = (from i in Enumerable.Range(0, _philosophers.Length) select new SemaphoreSlim(1, 1)).ToArray();
            for (int i = 0; i < _philosophers.Length; i++)
            {
                int index = i;
                Task.Factory.StartNew(() => RunPhilosopherSyncWithOrderedForks(forks, index), TaskCreationOptions.LongRunning);
            }
        }

        /// <summary>Runs a philosopher synchronously.</summary>
        /// <param name="forks">The forks, represented as semaphores.</param>
        /// <param name="index">The philosopher's index number.</param>
        private void RunPhilosopherSyncWithOrderedForks(SemaphoreSlim[] forks, int index)
        {
            // Assign forks
            int fork1Id, fork2Id;
            GetForkIds(index, forks.Length, out fork1Id, out fork2Id, true);
            SemaphoreSlim fork1 = forks[fork1Id], fork2 = forks[fork2Id];

            // Think and Eat, repeatedly
            var rand = new Random(index);
            while (true)
            {
                // Think (Yellow)
                _ui.StartNew(() => _philosophers[index].Fill = _think).Wait();
                Thread.Sleep(rand.Next(10) * TIMESCALE);

                // Wait for forks (Red)
                fork1.Wait();
                _ui.StartNew(() => _philosophers[index].Fill = _wait).Wait();
                fork2.Wait();

                // Eat (Green)
                _ui.StartNew(() => _philosophers[index].Fill = _eat).Wait();
                Thread.Sleep(rand.Next(10) * TIMESCALE);

                // Done with forks
                fork1.Release();
                fork2.Release();
            }
        }
        #endregion

        #region Synchronous, WaitAll
        /// <summary>Runs the philosophers utilizing one thread per philosopher.</summary>
        private void RunWithSemaphoresSyncWithWaitAll()
        {
            var forks = (from i in Enumerable.Range(0, _philosophers.Length) select new Semaphore(1, 1)).ToArray();
            for (int i = 0; i < _philosophers.Length; i++)
            {
                int index = i;
                Task.Factory.StartNew(() => RunPhilosopherSyncWithWaitAll(forks, index), TaskCreationOptions.LongRunning);
            }
        }

        /// <summary>Runs a philosopher synchronously.</summary>
        /// <param name="forks">The forks, represented as semaphores.</param>
        /// <param name="index">The philosopher's index number.</param>
        private void RunPhilosopherSyncWithWaitAll(Semaphore[] forks, int index)
        {
            // Assign forks
            int fork1Id, fork2Id;
            GetForkIds(index, forks.Length, out fork1Id, out fork2Id, false);
            Semaphore fork1 = forks[fork1Id], fork2 = forks[fork2Id];

            // Think and Eat, repeatedly
            var rand = new Random(index);
            while (true)
            {
                // Think (Yellow)
                _ui.StartNew(() => _philosophers[index].Fill = _think).Wait();
                Thread.Sleep(rand.Next(10) * TIMESCALE);

                // Wait for forks (Red)
                _ui.StartNew(() => _philosophers[index].Fill = _wait).Wait();
                WaitHandle.WaitAll(new[] { fork1, fork2 });

                // Eat (Green)
                _ui.StartNew(() => _philosophers[index].Fill = _eat).Wait();
                Thread.Sleep(rand.Next(10) * TIMESCALE);

                // Done with forks
                fork1.Release();
                fork2.Release();
            }
        }
        #endregion

        #region Asynchronous
        /// <summary>Runs the philosophers using asynchronous processing techniques to avoid one thread per philosopher.</summary>
        private void RunWithSemaphoresAsync()
        {
            var forks = (from i in Enumerable.Range(0, _philosophers.Length) select new AsyncSemaphore(1, 1)).ToArray();
            for (int i = 0; i < _philosophers.Length; i++)
            {
                Task.Factory.Iterate(RunPhilosopherAsync(forks, i));
            }
        }

        /// <summary>Runs a philosopher asynchronously.</summary>
        /// <param name="forks">The forks, represented as semaphores.</param>
        /// <param name="index">The philosopher's index number.</param>
        /// <returns>An enumerable of tasks representing a philosopher's execution.</returns>
        private IEnumerable<Task> RunPhilosopherAsync(AsyncSemaphore[] forks, int index)
        {
            // Assign forks
            int fork1Id, fork2Id;
            GetForkIds(index, forks.Length, out fork1Id, out fork2Id, true);
            AsyncSemaphore fork1 = forks[fork1Id], fork2 = forks[fork2Id];

            // Think and Eat, repeatedly
            var rand = new Random(index);
            while (true)
            {
                // Think (Yellow)
                yield return _ui.StartNew(() => _philosophers[index].Fill = _think);
                yield return Task.Factory.StartNewDelayed(rand.Next(10) * TIMESCALE, () => { });

                // Wait for forks (Red)
                yield return fork1.WaitAsync();
                yield return _ui.StartNew(() => _philosophers[index].Fill = _wait);
                yield return fork2.WaitAsync();

                // Eat (Green)
                yield return _ui.StartNew(() => _philosophers[index].Fill = _eat);
                yield return Task.Factory.StartNewDelayed(rand.Next(10) * TIMESCALE, () => { });

                // Done with forks
                fork1.Release();
                fork2.Release();
            }
        }
        #endregion
    }
}