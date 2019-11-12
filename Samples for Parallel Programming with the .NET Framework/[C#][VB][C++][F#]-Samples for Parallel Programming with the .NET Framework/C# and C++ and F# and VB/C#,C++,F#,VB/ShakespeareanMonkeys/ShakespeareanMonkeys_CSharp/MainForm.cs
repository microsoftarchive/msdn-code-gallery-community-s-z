//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: MainForm.cs
//
//--------------------------------------------------------------------------

using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShakespeareanMonkeys
{
    public partial class MainForm : Form
    {
        private static string _targetText =
            "To be or not to be, that is the question;" + Environment.NewLine +
            "Whether 'tis nobler in the mind to suffer" + Environment.NewLine +
            "The slings and arrows of outrageous fortune," + Environment.NewLine +
            "Or to take arms against a sea of troubles," + Environment.NewLine +
            "And by opposing, end them.";
        private TaskFactory _uiTasks;

        public MainForm()
        {
            InitializeComponent();

            txtTarget.Text = _targetText;
            _uiTasks = new TaskFactory(TaskScheduler.FromCurrentSynchronizationContext());
        }

        private int _currentIteration;
        private CancellationTokenSource _cancellation;

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (_cancellation == null)
            {
                _cancellation = new CancellationTokenSource();
                GeneticAlgorithmSettings settings = new GeneticAlgorithmSettings { PopulationSize = Int32.Parse(txtMonkeysPerGeneration.Text) };

                txtBestMatch.BackColor = SystemColors.Window;
                lblGenerations.BackColor = SystemColors.Control;
                lblGenPerSec.Text = lblGenerations.Text = "-";
                lblElapsedTime.Text = "0";
                btnRun.Text = "Cancel";
                chkParallel.Visible = false;

                _startTime = _lastTime = DateTimeOffset.Now;
                timerElapsedTime.Start();

                // Run the work in the background
                _cancellation = new CancellationTokenSource();
                var token = _cancellation.Token;
                bool runParallel = chkParallel.Checked;
                Task.Factory.StartNew(() =>
                {
                    // Create the new genetic algorithm
                    var ga = new TextMatchGeneticAlgorithm(runParallel, _targetText, settings);
                    TextMatchGenome? bestGenome = null;

                    // Iterate until a solution is found or until cancellation is requested
                    for (_currentIteration = 1; ; _currentIteration++)
                    {
                        token.ThrowIfCancellationRequested();

                        // Move to the next generation
                        ga.MoveNext();

                        // If we've found the best solution thus far, update the UI
                        if (bestGenome == null ||
                            ga.CurrentBest.Fitness < bestGenome.Value.Fitness)
                        {
                            bestGenome = ga.CurrentBest;
                            _uiTasks.StartNew(() => txtBestMatch.Text = bestGenome.Value.Text);

                            // If we've found the solution, bail.
                            if (bestGenome.Value.Text == _targetText) break;
                        }
                    }

                    // When the task completes, update the UI
                }, token).ContinueWith(t =>
                {
                    timerElapsedTime.Stop();
                    chkParallel.Visible = true;
                    btnRun.Text = "Start";
                    _cancellation = null;

                    switch (t.Status)
                    {
                        case TaskStatus.Faulted:
                            MessageBox.Show(this, t.Exception.ToString(), "Error");
                            break;
                        case TaskStatus.RanToCompletion:
                            txtBestMatch.BackColor = Color.LightGreen;
                            lblGenerations.BackColor = Color.LemonChiffon;
                            break;
                    }
                }, _uiTasks.Scheduler);
            }
            else _cancellation.Cancel();
        }

        private DateTimeOffset _startTime = DateTimeOffset.MinValue;
        private DateTimeOffset _lastTime = DateTimeOffset.MinValue;

        private void timerElapsedTime_Tick(object sender, EventArgs e)
        {
            var now = DateTimeOffset.Now;
            var elapsed = (int)(now - _startTime).TotalSeconds;
            
            lblElapsedTime.Text = elapsed.ToString();
            lblGenerations.Text = _currentIteration.ToString();

            if (elapsed > 2)
            {
                var diffSeconds = (now - _lastTime).TotalSeconds;
                if (diffSeconds > 0)
                {
                    lblGenPerSec.Text = ((int)(_currentIteration / diffSeconds)).ToString();
                }
            }
        }
    }
}
