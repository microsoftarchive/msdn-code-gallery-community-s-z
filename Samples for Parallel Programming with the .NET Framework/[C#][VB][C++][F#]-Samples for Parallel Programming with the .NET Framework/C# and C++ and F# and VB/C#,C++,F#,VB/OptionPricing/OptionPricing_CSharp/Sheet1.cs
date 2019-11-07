//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: Sheet1.cs
//
//--------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

namespace OptionPricing
{
    public partial class Sheet1
    {
        #region VSTO Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            this.Startup += new System.EventHandler(this.Sheet1_Startup);

        }

        #endregion

        private Excel.Range rngUp, rngDown, rngInitial, rngExercise, rngInterest, rngPeriods, rngRuns, rngRemote;
        private CancellationTokenSource _cancellation;

        private void Sheet1_Startup(object sender, System.EventArgs e)
        {
            rngUp = this.Range["B2", missing];
            rngDown = this.Range["B3", missing];
            rngInterest = this.Range["B4", missing];
            rngInitial = this.Range["B5", missing];
            rngPeriods = this.Range["B6", missing];
            rngExercise = this.Range["B7", missing];
            rngRuns = this.Range["B8", missing];
            rngRemote = this.Range["B9", missing];
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            // Set up a cancellation source to use to cancel background work
            if (_cancellation != null)
            {
                _cancellation.Cancel();
                return;
            }
            _cancellation = new CancellationTokenSource();
            var cancellationToken = _cancellation.Token;

            // Get a TaskFactory for targeting the UI thread
            var ui = GetUiTaskFactory();

            // Get data from form
            double initial = (double)rngInitial.Value2;
            double exercise = (double)rngInitial.Value2;
            double up = (double)rngUp.Value2;
            double down = (double)rngDown.Value2;
            double interest = (double)rngInterest.Value2;
            int periods = Convert.ToInt32(rngPeriods.Value2);
            int runs = Convert.ToInt32(rngRuns.Value2);

            // Create aggregation data
            int count = 0;
            double sumPrice = 0.0;
            double sumSquarePrice = 0.0;
            double min = double.MaxValue;
            double max = double.MinValue;
            double stdDev = 0.0;
            double stdErr = 0.0;

            // Run for a number of iterations
            string[] columns = { "D", "E", "F", "G", "H", "I", "J", "K", "L", "M" };
            int[] rows = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            bool runSequential = "No" == (string)rngRemote.Text;

            btnRun.Text = "Cancel";
            btnClear.Enabled = false;

            this.Range["C2", missing].Value2 = "Calculating...";
            IEnumerable<PricingResult> results;

            var cells = from column in columns
                        from row in rows
                        select new { column, row };

            Stopwatch timer = Stopwatch.StartNew();
            if (runSequential)
            {
                results = from cell in cells
                          let price = PriceAsianOptions(initial, exercise, up, down, interest, periods, runs)
                          select new PricingResult
                          {
                              Price = price,
                              Column = cell.column,
                              Row = cell.row
                          };
            }
            else
            {
                results = from cell in cells.AsParallel()
                              .AsOrdered()
                              .WithMergeOptions(ParallelMergeOptions.NotBuffered)
                              .WithCancellation(cancellationToken)
                          let price = PriceAsianOptions(initial, exercise, up, down, interest, periods, runs)
                          select new PricingResult
                          {
                              Price = price,
                              Column = cell.column,
                              Row = cell.row
                          };
            }

            Task.Factory.StartNew(() =>
            {
                foreach (var result in results)
                {
                    cancellationToken.ThrowIfCancellationRequested(); // for sequential implementation
                    UiUpdate(ui, () => this.Range[string.Format("{0}{1}", result.Column, result.Row), missing].Value2 = result.Price);
                    min = Math.Min(min, result.Price);
                    max = Math.Max(max, result.Price);
                    sumPrice += result.Price;
                    sumSquarePrice += result.Price * result.Price;
                    count++;
                    stdDev = Math.Sqrt(sumSquarePrice - sumPrice * sumPrice / count) / ((count == 1) ? 1 : count - 1);
                    stdErr = stdDev / Math.Sqrt(count);
                }
                timer.Stop();
            }, cancellationToken).ContinueWith(_ =>
            {
                UiUpdate(ui, () =>
                {
                    // Add summary data to form
                    this.Range["D13", missing].Value2 = sumPrice / count;
                    this.Range["D14", missing].Value2 = min;
                    this.Range["D15", missing].Value2 = max;
                    this.Range["D16", missing].Value2 = stdDev;
                    this.Range["D17", missing].Value2 = stdErr;
                    this.Range["D18", missing].Value2 = timer.Elapsed.TotalSeconds;
                    this.Range["C2", missing].ClearContents();

                    // Reset controls
                    btnRun.Text = "Run";
                    btnClear.Enabled = true;
                    _cancellation = null;
                });
            });
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.Range["D2", "M11"].ClearContents();
            this.Range["D13", "D18"].ClearContents();
        }

        private struct PricingResult
        {
            public double Price;
            public string Column;
            public int Row;
        }

        private static double PriceAsianOptions(double initial, double exercise, double up, double down, double interest, int periods, int runs)
        {
            double[] pricePath = new double[periods + 1];

            // Risk-neutral probabilities
            double piup = (interest - down) / (up - down);
            double pidown = 1 - piup;

            double temp = 0.0;

            Random rand = new Random(Thread.CurrentThread.ManagedThreadId ^ Environment.TickCount);
            double priceAverage = 0.0;
            double callPayOff = 0.0;

            for (int index = 0; index < runs; index++)
            {
                // Generate Path
                double sumPricePath = initial;

                for (int i = 1; i <= periods; i++)
                {
                    pricePath[0] = initial;
                    double rn = rand.NextDouble();

                    if (rn > pidown)
                    {
                        pricePath[i] = pricePath[i - 1] * up;
                    }
                    else
                    {
                        pricePath[i] = pricePath[i - 1] * down;
                    }
                    sumPricePath += pricePath[i];
                }

                priceAverage = sumPricePath / (periods + 1);
                callPayOff = Math.Max(priceAverage - exercise, 0);

                temp += callPayOff;
            }
            return (temp / Math.Pow(interest, periods)) / runs;
        }

        /// <summary>Gets a TaskFactory for targeting tasks to the UI thread.</summary>
        /// <returns>The created TaskFactory.</returns>
        private static TaskFactory GetUiTaskFactory()
        {
            var forceSyncContextInstall = new Control().Handle;
            return new TaskFactory(TaskScheduler.FromCurrentSynchronizationContext());
        }

        /// <summary>Make an update to the Excel spreadsheet from a background thread.</summary>
        /// <param name="uiScheduler">A TaskFactory associated with the UI thread.</param>
        /// <param name="body">The code to run on the UI thread.</param>
        private static void UiUpdate(TaskFactory ui, Action body)
        {
            // Invoke the code on the UI thread using the UI control's Invoke.
            // If the user is currently interacting with the spreadsheet,
            // resulting in a VBA_E_IGNORE error, try again after a brief
            // period of waiting.
            bool uiUpdated = false;
            while (!uiUpdated)
            {
                ui.StartNew(() =>
                {
                    try
                    {
                        body();
                        uiUpdated = true;
                    }
                    catch (COMException exc)
                    {
                        const int VBA_E_IGNORE = -2146777998;
                        if (exc.ErrorCode != VBA_E_IGNORE) throw;
                    }
                }).Wait();
                Thread.Sleep(50);
            }
        }
    }
}