//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: MainForm.cs
//
//--------------------------------------------------------------------------

using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>Used to cancel the current game.</summary>
        private CancellationTokenSource _cancellation;
        /// <summary>The current game.</summary>
        private GameBoard _game;

        private void chkParallel_CheckedChanged(object sender, EventArgs e)
        {
            if (_game != null) _game.RunParallel = chkParallel.Checked;
        }

        /// <summary>Run a game.</summary>
        private void btnRun_Click(object sender, EventArgs e)
        {
            // If no game is currently running, run one
            if (_cancellation == null)
            {
                // Clear the current image, get the size of the board to use, initialize cancellation,
                // and prepare the form for game running.
                pictureBox1.Image = null;
                int width = pictureBox1.Width, height = pictureBox1.Height;
                _cancellation = new CancellationTokenSource();
                var token = _cancellation.Token;
                lblDensity.Visible = false;
                tbDensity.Visible = false;
                btnRun.Text = "Stop";
                double initialDensity = tbDensity.Value / 1000.0;

                // Initialize the object pool and the game board
                var pool = new ObjectPool<Bitmap>(() => new Bitmap(width, height));
                _game = new GameBoard(width, height, initialDensity, pool) { RunParallel = chkParallel.Checked };

                // Run the game on a background thread
                Task.Factory.StartNew(() =>
                {
                    // Run until cancellation is requested
                    var sw = new Stopwatch();
                    while (!token.IsCancellationRequested)
                    {
                        // Move to the next board, timing how long it takes
                        sw.Restart();
                        Bitmap bmp = _game.MoveNext();
                        var framesPerSecond = 1 / sw.Elapsed.TotalSeconds;

                        // Update the UI with the new board image
                        BeginInvoke((Action)(() =>
                        {
                            lblFramesPerSecond.Text = String.Format("Frames / Sec: {0:F2}", framesPerSecond);
                            var old = (Bitmap)pictureBox1.Image;
                            pictureBox1.Image = bmp;
                            if (old != null) pool.PutObject(old);
                        }));
                    }
                    
                    // When the game is done, reset the board.
                }, token).ContinueWith(_ =>
                {
                    _cancellation = null;
                    btnRun.Text = "Start";
                    lblDensity.Visible = true;
                    tbDensity.Visible = true;
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }

                // If a game is currently running, cancel it
            else _cancellation.Cancel();
        }
    }
}
