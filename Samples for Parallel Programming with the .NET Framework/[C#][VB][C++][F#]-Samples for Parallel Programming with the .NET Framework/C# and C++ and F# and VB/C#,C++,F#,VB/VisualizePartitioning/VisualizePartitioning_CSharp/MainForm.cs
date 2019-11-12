//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: MainForm.cs
//
//--------------------------------------------------------------------------

using System;
using System.Collections.Concurrent;
using System.Collections.Concurrent.Partitioners;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Drawing;

namespace VisualizePartitioning
{
    public partial class MainForm : Form
    {
        /// <summary>Name and identifier for turning on stripe partitioning with PLINQ.</summary>
        const string PartitioningStripe = "Stripe";
        /// <summary>Name and identifier for turning on hash partitioning with PLINQ.</summary>
        const string PartitioningHash = "Hash";

        /// <summary>Color palette to use when rendering threads.</summary>
        private Color[] _colors;
        /// <summary>A multiplicative factor of how much work to do for each rendered line.</summary>
        private int _workFactor;

        /// <summary>Provides a source of seeds for thread-local random instances.</summary>
        private static Random _randomnessSeed = new Random();
        /// <summary>A thread-safe source of randomness for all threads that need random values.</summary>
        private static ThreadLocal<Random> _localRandom = new ThreadLocal<Random>(delegate { lock (_randomnessSeed) return new Random(_randomnessSeed.Next()); });

        public MainForm()
        {
            InitializeComponent();

            // Configure the workloads and the color palette.  The partitioning methods initialization will be done
            // when the radio button is changed to Parallel.ForEach or PLINQ.  The color palette will be
            // initialized when the cores trackbar changes value.
            InitializeWorkloads();

            // Configure number of cores
            tbCores.Minimum = 1;
            tbCores.Maximum = Environment.ProcessorCount * 2;
            tbCores.Value = Environment.ProcessorCount;
        }

        /// <summary>Initializes the color palette to use when rendering threads.</summary>
        private void InitializeColorPalette()
        {
            Random random = new Random(8); // Change seed value to change the palette used
            _colors = (from i in Enumerable.Range(0, tbCores.Value)
                       select Color.FromArgb(random.Next(128) + 127, random.Next(128) + 127, random.Next(128) + 127)).ToArray();
        }

        /// <summary>Initializes the workloads list view.</summary>
        private void InitializeWorkloads()
        {
            lvWorkloads.Items.Clear();
            var workloads = new List<Tuple<string, Func<int, int, int>>>();

            // NOTE: To add a new workload, simply add a new entry below with a name and corresponding function
            workloads.Add(Tuple.Create<string, Func<int, int, int>>("Constant", (size, current) => 1000 * _workFactor));
            workloads.Add(Tuple.Create<string, Func<int, int, int>>("Increasing Linear", (size, current) => 200 * current * _workFactor));
            workloads.Add(Tuple.Create<string, Func<int, int, int>>("Decreasing Linear", (size, current) => 200 * (size - current) * _workFactor));
            workloads.Add(Tuple.Create<string, Func<int, int, int>>("Random", (size, current) => _localRandom.Value.Next(100, 10000) * _workFactor));
            
            foreach (var workload in workloads) lvWorkloads.Items.Add(new ListViewItem(workload.Item1) { Tag = workload });
            lvWorkloads.Items[0].Selected = true;
        }

        /// <summary>Initializes the partitioning methods list view.</summary>
        private void InitializePartitioningMethods()
        {
            lvPartitioningMethods.Items.Clear();
            bool usingPLINQ = rbPLINQ.Checked;
            var partitioningMethods = new List<Tuple<string, Func<int[], Partitioner<int>>>>();

            // Static partitioning using the Partitioner.Create overload requires static partitioner support,
            // which Parallel.ForEach does not provide.
            if (usingPLINQ)
            {
                partitioningMethods.Add(Tuple.Create<string, Func<int[], Partitioner<int>>>(
                    "Static", e => Partitioner.Create(e, false)));
            }

            // Add a bunch of partitioning approaches that work with both PLINQ and Parallel.ForEach
            partitioningMethods.Add(Tuple.Create<string, Func<int[], Partitioner<int>>>(
                "Load Balance", e => Partitioner.Create(e, true)));
            partitioningMethods.Add(Tuple.Create<string, Func<int[], Partitioner<int>>>(
                "Dynamic(1)", e => ChunkPartitioner.Create(e, 1)));
            partitioningMethods.Add(Tuple.Create<string, Func<int[], Partitioner<int>>>(
                "Dynamic(16)", e => ChunkPartitioner.Create(e, 16)));
            partitioningMethods.Add(Tuple.Create<string, Func<int[], Partitioner<int>>>(
                "Guided", e => ChunkPartitioner.Create(e, prev =>
                {
                    if (prev <= 0) return e.Length <= 1 ? 1 : e.Length / (Environment.ProcessorCount * 3);
                    var next = prev / 2;
                    return next <= 0 ? prev : next;
                })));
            partitioningMethods.Add(Tuple.Create<string, Func<int[], Partitioner<int>>>(
                "Grow Exponential", e => ChunkPartitioner.Create(e, prev => prev <= 0 ? 1 : prev * 2)));
            partitioningMethods.Add(Tuple.Create<string, Func<int[], Partitioner<int>>>(
                "Random", e => ChunkPartitioner.Create(e, prev => _localRandom.Value.Next(e.Length))));

            // Special-case some PLINQ-only hashing
            if (usingPLINQ)
            {
                // The actual enabling of these partitioning schemes is done later, as they can't 
                // be encoded in a partitioner but rather are based on what operators are used in the PLINQ query.
                partitioningMethods.Add(Tuple.Create<string, Func<int[], Partitioner<int>>>(
                    PartitioningStripe, e => Partitioner.Create(e)));
                partitioningMethods.Add(Tuple.Create<string, Func<int[], Partitioner<int>>>(
                    PartitioningHash, e => Partitioner.Create(e)));
            }

            // Dump the partitioners into the list view
            foreach (var method in partitioningMethods) lvPartitioningMethods.Items.Add(new ListViewItem(method.Item1) { Tag = method });
            lvPartitioningMethods.Items[0].Selected = true;
        }

        /// <summary>Visualize the partitioning.</summary>
        private void btnVisualize_Click(object sender, EventArgs e)
        {
            int numProcs = tbCores.Value;
            int width = pbPartitionedImage.Width, height = pbPartitionedImage.Height;
            bool useParallelFor = rbParallelFor.Checked, useParallelForEach = rbParallelForEach.Checked;
            _workFactor = tbWorkFactor.Value;

            // If we're using Parallel.ForEach or PLINQ, ensure a partitioning scheme was selected and use it
            Tuple<string, Func<int[], Partitioner<int>>> selectedMethod = null;
            if (!useParallelFor)
            {
                if (lvPartitioningMethods.SelectedIndices.Count == 0) return;
                else selectedMethod = (Tuple<string, Func<int[], Partitioner<int>>>)lvPartitioningMethods.SelectedItems[0].Tag;
            }

            // Make sure a workload was selected and use it
            if (lvWorkloads.SelectedItems.Count == 0) return;
            var selectedWorkload = (Tuple<string, Func<int, int, int>>)lvWorkloads.SelectedItems[0].Tag;

            // Create a new Bitmap to store the rendered output
            var bmp = new Bitmap(width, height);

            // Disable the start button and kick off the background work
            btnVisualize.Enabled = false;
            Task.Factory.StartNew(() =>
            {
                int nextId = -1; // assign each thread a unique id
                var threadId = new ThreadLocal<int>(() => Interlocked.Increment(ref nextId));

                using (FastBitmap fastBmp = new FastBitmap(bmp)) // get faster access to the Bitmap's contents
                {
                    var sw = Stopwatch.StartNew(); // time the operation
                    if (useParallelFor)
                    {
                        Parallel.For(0, height, new ParallelOptions { MaxDegreeOfParallelism = numProcs }, i =>
                        {
                            int id = threadId.Value;
                            DoWork(selectedWorkload.Item2(height, i));
                            for (int j = 0; j < width; j++) fastBmp.SetColor(j, i, _colors[id % _colors.Length]);
                        });
                    }
                    else
                    {
                        // Create the partitioner to be used
                        var partitioner = selectedMethod.Item2(Enumerable.Range(0, height).ToArray());

                        if (useParallelForEach)
                        {
                            // Run the work with Parallel.ForEach
                            Parallel.ForEach(partitioner, new ParallelOptions { MaxDegreeOfParallelism = numProcs }, i =>
                            {
                                int id = threadId.Value;
                                DoWork(selectedWorkload.Item2(height, i));
                                for (int j = 0; j < width; j++) fastBmp.SetColor(j, i, _colors[id % _colors.Length]);
                            });
                        }
                        else // PLINQ
                        {
                            // Run the work with PLINQ.  If a special partitioning method was selected, use relevant query operators
                            // to get PLINQ to use that partitioning approach.
                            var source = partitioner.AsParallel().WithDegreeOfParallelism(numProcs);
                            if (selectedMethod.Item1 == PartitioningStripe) source = source.TakeWhile(elem => true);
                            else if (selectedMethod.Item1 == PartitioningHash) source = source.Join(Enumerable.Range(0, height).AsParallel(), i => i, i => i, (i, ignore) => i);
                            source.ForAll(i =>
                            {
                                int id = threadId.Value;
                                DoWork(selectedWorkload.Item2(height, i));
                                for (int j = 0; j < width; j++) fastBmp.SetColor(j, i, _colors[id % _colors.Length]);
                            });
                        }
                    }

                    // Return the total time from the task
                    return sw.Elapsed;
                }

                // When the work completes, run the following on the UI thread
            }).ContinueWith(t =>
            {
                // Dispose of the old image (if there was one) and display the new one
                var old = pbPartitionedImage.Image;
                pbPartitionedImage.Image = bmp;
                if (old != null) old.Dispose();

                // Re-enable controls on the form and display the elapsed time
                btnVisualize.Enabled = true;
                lblTime.Text = "Time: " + t.Result.ToString();
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        /// <summary>Does an amount of work relative to the amount requested.</summary>
        /// <param name="workAmount">The amount of work to perform.</param>
        [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
        private static int DoWork(int workAmount)
        {
            int value = 1;
            for (int i = 0; i < workAmount; i++) value *= workAmount;
            return value;
        }

        /// <summary>Update relevant portions of the form when the API radio buttons are checked.</summary>
        /// <param name="sender">The radio button.</param>
        /// <param name="e">The event args.</param>
        private void rbAPI_CheckedChanged(object sender, EventArgs e)
        {
            lvPartitioningMethods.Enabled = !rbParallelFor.Checked;
            lvPartitioningMethods.HideSelection = !lvPartitioningMethods.Enabled;

            // Recreate partitioning methods every time a radio button is checked,
            // as which API is selected determines which partitioning methods are available
            InitializePartitioningMethods();
        }

        private void tbCores_ValueChanged(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(tbCores, tbCores.Value.ToString());
            InitializeColorPalette();
            int worker, io;
            ThreadPool.GetMinThreads(out worker, out io);
            ThreadPool.SetMinThreads(tbCores.Value, io);
        }

        private void tbWorkFactor_ValueChanged(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(tbWorkFactor, tbWorkFactor.Value.ToString());
        }
    }
}