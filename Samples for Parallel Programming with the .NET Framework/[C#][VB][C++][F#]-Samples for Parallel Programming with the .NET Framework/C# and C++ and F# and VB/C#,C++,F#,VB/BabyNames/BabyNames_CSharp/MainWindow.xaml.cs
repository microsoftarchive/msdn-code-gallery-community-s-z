//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: MainWindow.xaml.cs
//
//--------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Threading;

namespace BabyNames
{
    /// <summary>Baby Names</summary>
    public partial class Window1 : Window
    {
        private const int YEAR_START = 1960, YEAR_END = 2005;
        private const int Y_SCALE_MAX = 1000;
        private const int RUN_MULTIPLIER = 10;
        private const string DATA_TO_USE_FORMAT = "Data To Use: {0} records";
        private const string PROCESSORS_TO_USE_FORMAT = "Processors To Use: {0}";

        private QueryData _userQuery = new QueryData();
        private List<BabyInfo> _babies = new List<BabyInfo>();
        private ParallelQuery<BabyInfo> _parallelQuery;
        private IEnumerable<BabyInfo> _sequentialQuery;
        private long _lastSeqRun = 0, _lastParRun = 0;
        private DispatcherTimer _sizeChangedTimer;
        private TaskFactory _uiTasks;

        public Window1()
        {
            // Initialize controls
            InitializeComponent();
            
            // Setup a timer for the slider control so that we don't load for every single tick change
            _sizeChangedTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(.5) };
            _sizeChangedTimer.Tick += (sender, e) =>
            {
                ((DispatcherTimer)sender).Stop();
                LoadAsync((int)slNumRecords.Value);
            };
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Create a UI task factory
            _uiTasks = new TaskFactory(TaskScheduler.FromCurrentSynchronizationContext());

            // Set up the processors slider
            slProcessorsToUse.Minimum = 1;
            slProcessorsToUse.Maximum = slProcessorsToUse.Value = Environment.ProcessorCount;

            // Setup the label controls for the sliders
            lblProcessorsToUse.Content = string.Format(PROCESSORS_TO_USE_FORMAT, (int)slProcessorsToUse.Value);
            lblSize.Content = string.Format(DATA_TO_USE_FORMAT, (int)slNumRecords.Value);

            // Load the data for the app
            LoadAsync((int)slNumRecords.Value);
        }

        private void btnRunLinq_Click(object sender, RoutedEventArgs e)
        {
            // Run sequentially
            RunQuery(() => _sequentialQuery.ToList(), graphLinq, lblLinqTime);
        }

        private void btnRunPlinq_Click(object sender, RoutedEventArgs e)
        {
            // Run in parallel
            RunQuery(() => _parallelQuery.ToList(), graphPlinq, lblPlinqTime);
        }

        internal class QueryData { public string Name, State; }

        private void RunQuery(Func<List<BabyInfo>> query, Graph targetGraph, Label targetLabel)
        {
            // Get query info values from the text box.
            _userQuery.Name = txtQueryName.Text.Trim();
            _userQuery.State = txtQueryState.Text.Trim();
            if (_userQuery.Name.Length == 0 || _userQuery.State.Length == 0) return;
            
            // Disable UI interaction
            lblSpeedup.Visibility = Visibility.Hidden;
            targetLabel.Visibility = Visibility.Hidden;
            targetGraph.Visibility = Visibility.Hidden;
            ConfigureUiControls(false);

            // Do query asynchronously
            Task.Factory.StartNew(delegate
            {
                // Execute and time the query:
                List<BabyInfo> results = null;
                var sw = Stopwatch.StartNew();
                for (int i = 0; i < RUN_MULTIPLIER; i++) results = query();
                sw.Stop();

                // Update the UI
                _uiTasks.StartNew(()=>
                {
                    // Update the run time
                    if (targetLabel == lblLinqTime) _lastSeqRun = sw.ElapsedTicks;
                    else _lastParRun = sw.ElapsedTicks;

                    // Update the graph
                    targetGraph.Configure(results);
                    targetGraph.Visibility = Visibility.Visible;
                    targetGraph.InvalidateVisual();

                    // Display the execution time
                    targetLabel.Content = string.Format("{0:F2} seconds", (sw.ElapsedMilliseconds / 1000.0));
                    targetLabel.Visibility = Visibility.Visible;

                    // Show any speedup
                    if (_lastSeqRun != 0 && _lastParRun != 0)
                    {
                        lblSpeedup.Content = string.Format("{0:F2}x speedup", ((float)_lastSeqRun) / _lastParRun);
                        lblSpeedup.Visibility = Visibility.Visible;
                    }

                    // Allow the user to interact again
                    ConfigureUiControls(true);
                });
            });
        }

        private void LoadAsync(int numRecords)
        {
            // Loading new data, so hide and reset old timings
            lblLinqTime.Visibility = lblPlinqTime.Visibility = lblSpeedup.Visibility = Visibility.Hidden;
            _lastSeqRun = _lastParRun = 0;

            // Clear the screen
            graphLinq.Visibility = graphPlinq.Visibility = Visibility.Hidden;
            ConfigureUiControls(false);

            // Load all of the names asynchronously; when done, update the UI
            Task.Factory.StartNew(delegate
            {
                _babies = DataLoader.GenerateRandom(numRecords, YEAR_START, YEAR_END);
                _uiTasks.StartNew(()=>
                {
                    InitializeQueries();
                    ConfigureUiControls(true);
                });
            });
        }

        private void ConfigureUiControls(bool allowUserInteraction)
        {
            // Controls that the user can interact with
            txtQueryName.IsEnabled = txtQueryState.IsEnabled = btnRunLinq.IsEnabled = btnRunPlinq.IsEnabled =
                slProcessorsToUse.IsEnabled = slNumRecords.IsEnabled = allowUserInteraction;
        }


        private void slSize_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Handle data size slider updates
            if (slNumRecords.IsVisible)
            {
                lblSize.Content = string.Format(DATA_TO_USE_FORMAT, (int)slNumRecords.Value);
                _sizeChangedTimer.Stop();
                _sizeChangedTimer.Start();
            }
        }

        private void slProcessorsToUse_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Handle processors to use updates
            if (slProcessorsToUse.IsVisible)
            {
                lblProcessorsToUse.Content = string.Format(PROCESSORS_TO_USE_FORMAT, (int)slProcessorsToUse.Value);
                InitializeQueries();
            }
        }
    }
}
