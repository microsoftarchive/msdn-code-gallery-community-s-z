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

namespace Strassens
{
    public partial class MainForm : Form
    {
        private TaskScheduler _uiScheduler;
        private DataPoint _naive;
        private DataPoint _naiveParallel;
        private DataPoint _strassens;
        private DataPoint _strassensParallel;
        private double _max = 0;
        private CancellationTokenSource _cancellation;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            SetupPoints();
        }

        private void SetupPoints()
        {
            _naive = chart1.Series[0].Points[chart1.Series[0].Points.AddXY("Naive", 0.0)];
            _naiveParallel = chart1.Series[0].Points[chart1.Series[0].Points.AddXY("Naive Parallel", 0.0)];
            _strassens = chart1.Series[0].Points[chart1.Series[0].Points.AddXY("Strassen's", 0.0)];
            _strassensParallel = chart1.Series[0].Points[chart1.Series[0].Points.AddXY("Strassen's Parallel", 0.0)];
            chart1.ChartAreas[0].AxisY.Minimum = 0.0;
            chart1.ChartAreas[0].AxisY.Maximum = 10.0;
            ClearPointValues();
            Invalidate();
        }

        private void ClearPointValues()
        {
            foreach (var point in new[] { _naive, _naiveParallel, _strassens, _strassensParallel })
            {
                point.SetValueY(0);
                point.ToolTip = "";
                point.Label = "";
                point.Font = new System.Drawing.Font(point.Font, System.Drawing.FontStyle.Bold);
            }
            chart1.Invalidate();
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            if (_cancellation == null)
            {
                btnCompute.Text = "Cancel";

                int matrixSize = 0;
                if (!Int32.TryParse(cbMatrixSize.Text, out matrixSize)) return;
                progressBar1.Visible = true;

                ClearPointValues();
                _max = 0;

                _cancellation = new CancellationTokenSource();
                var token = _cancellation.Token;
                Task.Factory.StartNew(() =>
                {
                    using (Matrix matA = new Matrix(matrixSize))
                    using (Matrix matB = new Matrix(matrixSize))
                    using (Matrix matC = new Matrix(matrixSize))
                    {
                        TimeSpan elapsed;

                        elapsed = Time(() => Matrix.Multiply(token, matA, matB, matC));
                        SetPoint(_naive, elapsed.TotalSeconds);

                        elapsed = Time(() => Matrix.MultiplyParallel(token, matA, matB, matC));
                        SetPoint(_naiveParallel, elapsed.TotalSeconds);

                        elapsed = Time(() => Matrix.MultiplyStrassens(token, matA, matB, matC));
                        SetPoint(_strassens, elapsed.TotalSeconds);

                        elapsed = Time(() => Matrix.MultiplyStrassensParallel(token, matA, matB, matC));
                        SetPoint(_strassensParallel, elapsed.TotalSeconds);
                    }
                }, token).ContinueWith(t =>
                {
                    _cancellation = null;
                    btnCompute.Text = "Compute";
                    progressBar1.Visible = false;
                    if (t.IsFaulted) MessageBox.Show(t.Exception.ToString());
                }, _uiScheduler);
            }
            else _cancellation.Cancel();
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
                point.ToolTip = seconds.ToString("F2");
                point.Label = string.Format("{0:F2} secs  ({1:F2}x)", seconds, (_max / seconds));
                chart1.Invalidate();
            }, CancellationToken.None, TaskCreationOptions.None, _uiScheduler);
        }

        static TimeSpan Time(Action action)
        {
            var sw = Stopwatch.StartNew();
            action();
            return sw.Elapsed;
        }
    }
}
