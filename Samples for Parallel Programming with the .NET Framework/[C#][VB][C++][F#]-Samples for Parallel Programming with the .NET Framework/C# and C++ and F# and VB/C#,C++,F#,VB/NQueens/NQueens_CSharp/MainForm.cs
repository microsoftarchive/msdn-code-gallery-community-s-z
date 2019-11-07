//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: MainForm.cs
//
//--------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples;

namespace NQueens_CSharp
{
    public partial class MainForm : Form
    {
        const int NUM_QUEENS = 22;
        private TaskScheduler _uiScheduler;
        private DataPoint _serial;
        private DataPoint _parallel;
        private double _max = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            SetupPoints();
        }

        private void SetupPoints()
        {
            _serial = chart1.Series[0].Points[chart1.Series[0].Points.AddXY("Serial", 0.0)];
            _parallel = chart1.Series[0].Points[chart1.Series[0].Points.AddXY("Parallel", 0.0)];
            chart1.ChartAreas[0].AxisY.Minimum = 0.0;
            chart1.ChartAreas[0].AxisY.Maximum = 10.0;
            ClearPointValues();
            Invalidate();
        }

        private void ClearPointValues()
        {
            foreach (var point in new[] { _serial, _parallel })
            {
                point.SetValueY(0);
                point.ToolTip = "";
                point.Label = "";
                point.Font = new System.Drawing.Font(point.Font, System.Drawing.FontStyle.Bold);
            }
            chart1.Invalidate();
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            int numQueens = 0;
            if (!Int32.TryParse(cbNumQueens.Text, out numQueens)) return;

            btnSolve.Enabled = false;
            progressBar1.Visible = true;

            ClearPointValues();
            _max = 0;

            Task.Factory.StartNew(() =>
            {
                TimeSpan elapsed;

                elapsed = Time(() => NQueensSolver.Sequential(numQueens));
                SetPoint(_serial, elapsed.TotalSeconds);

                elapsed = Time(() => NQueensSolver.Parallel(numQueens));
                SetPoint(_parallel, elapsed.TotalSeconds);

            }, TaskCreationOptions.AttachedToParent).ContinueWith(t =>
            {
                progressBar1.Visible = false;
                btnSolve.Enabled = true;
                if (t.IsFaulted) MessageBox.Show(t.Exception.ToString());
            }, CancellationToken.None, TaskContinuationOptions.AttachedToParent, _uiScheduler);
        }

        private void SetPoint(DataPoint point, double seconds)
        {
            Task.Factory.StartNew(() =>
            {
                if (seconds > _max)
                {
                    _max = seconds;
                    chart1.ChartAreas[0].AxisY.Maximum = _max * 1.1;
                }
                point.SetValueY(seconds);
                point.ToolTip = seconds.ToString("F3");
                point.Label = string.Format("{0:F3} secs  ({1:F2}x)", seconds, (_max / seconds));
                chart1.Invalidate();
            }, CancellationToken.None, TaskCreationOptions.AttachedToParent, _uiScheduler);
        }

        static TimeSpan Time(Action action)
        {
            var sw = Stopwatch.StartNew();
            action();
            return sw.Elapsed;
        }
    }
}