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
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private TaskScheduler _uiScheduler;
        private int _width, _height;
        private Bitmap _image;
        private Rectangle _rect;
        private bool _parallel;
        private Stopwatch _sw;
        private CancellationTokenSource _cancellation;

        private void MainForm_Load(object sender, EventArgs e)
        {
            _uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
        }

        private void btnRender_Click(object sender, EventArgs e)
        {
            if (_cancellation == null)
            {
                btnRender.Text = "Cancel";
                rbLINQ.Enabled = false;
                rbPLINQ.Enabled = false;

                _width = _height = Math.Min(pbImage.Width, pbImage.Height);
                _image = new Bitmap(_width, _height, PixelFormat.Format32bppRgb);
                _rect = new Rectangle(0, 0, _width, _height);

                Image oldBmp = pbImage.Image;
                pbImage.Image = _image;
                if (oldBmp != null) oldBmp.Dispose();

                _parallel = rbPLINQ.Checked;
                _cancellation = new CancellationTokenSource();
                _sw = Stopwatch.StartNew();

                var background = Task.Factory.StartNew(BackgroundRender, _cancellation.Token, _cancellation.Token);
                background.ContinueWith(_ =>
                {
                    lbTimeToComplete.Text = _sw.Elapsed.ToString();
                    btnRender.Enabled = true;
                    btnRender.Text = "Render";
                    rbLINQ.Enabled = true;
                    rbPLINQ.Enabled = true;
                    _cancellation = null;
                }, _uiScheduler);
            }
            else
            {
                btnRender.Enabled = false;
                _cancellation.Cancel();
            }
        }

        private void BackgroundRender(object state)
        {
            var cancellationToken = (CancellationToken)state;
            RayTracer rayTracer = new RayTracer(_width, _height, (rgb) =>
            {
                Task.Factory.StartNew(() =>
                {
                    var bmpData = _image.LockBits(_rect, ImageLockMode.WriteOnly, _image.PixelFormat);
                    Marshal.Copy(rgb, 0, bmpData.Scan0, rgb.Length);
                    _image.UnlockBits(bmpData);
                    pbImage.Refresh();
                }, CancellationToken.None, TaskCreationOptions.AttachedToParent, _uiScheduler);
            });

            if (_parallel) rayTracer.RenderParallel(rayTracer.DefaultScene, cancellationToken);
            else rayTracer.RenderSequential(rayTracer.DefaultScene, cancellationToken);
        }
    }
}
