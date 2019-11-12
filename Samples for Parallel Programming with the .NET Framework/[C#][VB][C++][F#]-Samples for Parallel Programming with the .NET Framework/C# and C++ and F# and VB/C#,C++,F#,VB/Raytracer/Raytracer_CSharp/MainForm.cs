//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: MainForm.cs
//
//--------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Concurrent;

namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples
{
    public partial class MainForm : Form
    {
        public MainForm() { InitializeComponent(); }

        private bool _showThreads;
        private bool _parallel;
        private int _degreeOfParallelism = Environment.ProcessorCount;
        private CancellationTokenSource _cancellation;

        private int _width, _height;
        private Bitmap _bitmap;
        private Rectangle _rect;
        private ObjectPool<int[]> _freeBuffers;

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            // If we already have the rendering task created, then we're currently running.
            // In that case, stop the renderer.
            if (_cancellation != null)
            {
                btnStartStop.Enabled = false;
                _cancellation.Cancel();
            }
            else
            {
                // Set up the image in the picture box and start the rendering loop with a new rendering task
                ConfigureImage();
                _showThreads = chkShowThreads.Checked;
                _cancellation = new CancellationTokenSource();
                Task.Factory.StartNew(RenderLoop, 
                    _cancellation.Token, _cancellation.Token).
                    ContinueWith(delegate
                {
                    chkParallel.Enabled = true;
                    chkShowThreads.Enabled = chkParallel.Checked;
                    btnStartStop.Enabled = true;
                    btnStartStop.Text = "Start";
                    _cancellation = null;
                }, TaskScheduler.FromCurrentSynchronizationContext());
                
                chkShowThreads.Enabled = false;
                chkParallel.Enabled = false;
                btnStartStop.Text = "Stop";
            }
        }

        private void ConfigureImage()
        {
            // If we need to create a new bitmap, do so
            if (_bitmap == null || _bitmap.Width != pbRenderedImage.Width || _bitmap.Height != pbRenderedImage.Height)
            {
                // Dispose of the old one if one exists
                if (_bitmap != null)
                {
                    pbRenderedImage.Image = null;
                    _bitmap.Dispose();
                }

                // We always render a square even if the window isn't square
                _width = _height = Math.Min(pbRenderedImage.Width, pbRenderedImage.Height);

                // Create a new object pool for the rendering arrays
                _freeBuffers = new ObjectPool<int[]>(() => new int[_width * _height]);

                // Create a new Bitmap and set it into the picture box
                _bitmap = new Bitmap(_width, _height, PixelFormat.Format32bppRgb);
                _rect = new Rectangle(0, 0, _width, _height);
                pbRenderedImage.Image = _bitmap;
            }
        }

        private void RenderLoop(object boxedToken)
        {
            var cancellationToken = (CancellationToken)boxedToken;

            // Create a ray tracer, and create a reference to "sphere2" that we are going to bounce
            var rayTracer = new RayTracer(_width, _height);
            var scene = rayTracer.DefaultScene;
            var sphere2 = (Sphere)scene.Things[0]; // The first item is assumed to be our sphere
            var baseY = sphere2.Radius;
            sphere2.Center.Y = sphere2.Radius;

            // Timing determines how fast the ball bounces as well as diagnostics frames/second info
            var renderingTime = new Stopwatch();
            var totalTime = Stopwatch.StartNew();

            // Keep rendering until the rendering task has been canceled
            while (!cancellationToken.IsCancellationRequested)
            {
                // Get the next buffer
                var rgb = _freeBuffers.GetObject();

                // Determine the new position of the sphere based on the current time elapsed
                double dy2 = 0.8 * Math.Abs(Math.Sin(totalTime.ElapsedMilliseconds * Math.PI / 3000));
                sphere2.Center.Y = baseY + dy2;

                // Render the scene
                renderingTime.Reset();
                renderingTime.Start();
                    ParallelOptions options = new ParallelOptions { MaxDegreeOfParallelism = _degreeOfParallelism, CancellationToken = _cancellation.Token };
                    if (!_parallel) rayTracer.RenderSequential(scene, rgb);
                    else if (_showThreads) rayTracer.RenderParallelShowingThreads(scene, rgb, options);
                    else rayTracer.RenderParallel(scene, rgb, options);
                renderingTime.Stop();

                // Update the bitmap in the UI thread
                //var framesPerSecond = (++frame * 1000.0 / renderingTime.ElapsedMilliseconds);
                var framesPerSecond = (1000.0 / renderingTime.ElapsedMilliseconds);
                BeginInvoke((Action)delegate
                {
                    // Copy the pixel array into the bitmap
                    var bmpData = _bitmap.LockBits(_rect, ImageLockMode.WriteOnly, _bitmap.PixelFormat);
                    Marshal.Copy(rgb, 0, bmpData.Scan0, rgb.Length);
                    _bitmap.UnlockBits(bmpData);
                    _freeBuffers.PutObject(rgb);

                    // Refresh the UI
                    pbRenderedImage.Invalidate();
                    Text = "Ray Tracer - FPS: " + framesPerSecond.ToString("F1");
                });
            }
        }

        private void chkParallel_CheckedChanged(object sender, EventArgs e)
        {
            _parallel = 
                lblNumProcs.Enabled = 
                tbNumProcs.Enabled = 
                chkShowThreads.Enabled = 
                chkParallel.Checked;
        }

        private void tbNumProcs_ValueChanged(object sender, EventArgs e)
        {
            lblNumProcs.Text = tbNumProcs.Value.ToString();
            _degreeOfParallelism = tbNumProcs.Value;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            tbNumProcs.Minimum = 1;
            tbNumProcs.Maximum = Environment.ProcessorCount;
            tbNumProcs.Value = tbNumProcs.Maximum;
            lblNumProcs.Text = tbNumProcs.Value.ToString();
        }
    }
}