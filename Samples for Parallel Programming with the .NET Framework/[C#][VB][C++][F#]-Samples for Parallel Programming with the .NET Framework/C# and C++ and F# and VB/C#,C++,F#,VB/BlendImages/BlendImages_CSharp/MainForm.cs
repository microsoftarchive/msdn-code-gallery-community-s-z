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
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Drawing;

namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples
{
    public partial class MainForm : Form
    {
        private TimeSpan? _lastSequentialTime, _lastParallelTime;

        public MainForm() { InitializeComponent(); }

        private void pbInput_DoubleClick(object sender, EventArgs e)
        {
            // Get the PictureBox that caused this event
            PictureBox pb = sender as PictureBox;
            if (pb == null) return;

            // Open a dialog to let the user select an image
            using (var ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Store the new image into the PictureBox
                    Image newImage = new Bitmap(ofd.FileName);
                    Image oldImage = pb.Image;
                    pb.Image = newImage;
                    if (oldImage != null) oldImage.Dispose();
                }
            }

            // Make sure the btns are enabled if they should be
            _lastSequentialTime = _lastParallelTime = null;
            btnSequential.Enabled = btnParallel.Enabled = (pbInput1.Image != null && pbInput2.Image != null);
        }

        private void pbOutput_DoubleClick(object sender, EventArgs e)
        {
            if (pbOutput.Image != null)
            {
                // Open a dialog to let the user select an output path
                using (var sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Bitmap Images|*.bmp";
                    if (sfd.ShowDialog(this) == DialogResult.OK)
                    {
                        // Save the image as a bitmap to the selected location
                        pbOutput.Image.Save(sfd.FileName, ImageFormat.Bmp);
                    }
                }
            }
        }

        private void btnBlendImages_Click(object sender, EventArgs e)
        {
            // Determine whether to run sequentially or in parallel based on the
            // button click that got us here
            bool isParallel = sender == btnParallel;

            // Get the images
            Bitmap bmp1 = (Bitmap)pbInput1.Image;
            Bitmap bmp2 = (Bitmap)pbInput2.Image;
            if (bmp1 == null || bmp2 == null) return;

            // Clear the output image
            Image oldOutput = pbOutput.Image;
            pbOutput.Image = null;
            if (oldOutput != null) oldOutput.Dispose();

            // Resize the second image's size to match that of the first
            if (bmp1.Size != bmp2.Size)
            {
                Bitmap newBmp2 = new Bitmap(bmp1.Width, bmp1.Height);
                using (var g = Graphics.FromImage(newBmp2)) g.DrawImage(bmp2, 0, 0, newBmp2.Width, newBmp2.Height);
                pbInput2.Image = newBmp2;
                bmp2.Dispose();
                bmp2 = newBmp2;
            }

            // Disable the form to prevent user interaction while merging
            EnableOrDisableFormControls(false);
            lblSpeedup.Text = string.Empty;
            lblTime.Text = string.Empty;

            // Do the work in the background
            var uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            Task.Factory.StartNew(delegate
            {
                // Blend the images (and time the operation)
                TimeSpan time;
                Bitmap output = BlendImages(bmp1, bmp2, .5, isParallel, out time);

                // Update our stats
                if (isParallel) _lastParallelTime = time;
                else _lastSequentialTime = time;
                string speedup = (_lastSequentialTime != null && _lastParallelTime != null) ?
                    string.Format("Speedup: {0:F2}", _lastSequentialTime.Value.TotalSeconds / _lastParallelTime.Value.TotalSeconds) + "x" :
                    string.Empty;

                // Pass results to the UI
                return new { output, time, speedup };
            }).ContinueWith(t =>
            {
                EnableOrDisableFormControls(true);
                pbOutput.Image = t.Result.output;
                lblTime.Text = "Time: " + t.Result.time.ToString();
                lblSpeedup.Text = t.Result.speedup;
                lblSpeedup.Location = new Point(splitContainer1.Right - lblSpeedup.Width, lblSpeedup.Location.Y);
            }, uiScheduler);
        }

        internal unsafe static Bitmap BlendImages(Bitmap start, Bitmap end, double blend, bool parallel, out TimeSpan time)
        {
            // Validate parameters
            if (start.Width != end.Width || start.Height != end.Height) 
                throw new ArgumentException("The sizes of images do not match.");
            if (blend < 0 || blend > 1) 
                throw new ArgumentOutOfRangeException("blend", blend, "Must be in the range [0.0,1.1].");

            // Create the output image
            int width = start.Width, height = start.Height;
            Bitmap output = new Bitmap(width, height);
            var sw = new Stopwatch();

            // Blend the input images into the output
            using (FastBitmap fastOut = new FastBitmap(output))
            using (FastBitmap fastStart = new FastBitmap(start))
            using (FastBitmap fastEnd = new FastBitmap(end))
            {
                if (parallel)
                {
                    // Blend the images in parallel
                    sw.Restart();
                    Parallel.For(0, height, j =>
                    {
                        PixelData* outPixel = fastOut.GetInitialPixelForRow(j);
                        PixelData* startPixel = fastStart.GetInitialPixelForRow(j);
                        PixelData* endPixel = fastEnd.GetInitialPixelForRow(j);

                        for (int i = 0; i < width; i++)
                        {
                            // Blend the input pixels into the output pixel
                            outPixel->R = (byte)((startPixel->R * blend) + .5 + (endPixel->R * (1 - blend))); // .5 for rounding
                            outPixel->G = (byte)((startPixel->G * blend) + .5 + (endPixel->G * (1 - blend)));
                            outPixel->B = (byte)((startPixel->B * blend) + .5 + (endPixel->B * (1 - blend)));

                            outPixel++;
                            startPixel++;
                            endPixel++;
                        }
                    });
                    sw.Stop();
                }
                else
                {
                    // Blend the images sequentially
                    sw.Restart();
                    for(int j=0; j<height; j++)
                    {
                        PixelData* outPixel = fastOut.GetInitialPixelForRow(j);
                        PixelData* startPixel = fastStart.GetInitialPixelForRow(j);
                        PixelData* endPixel = fastEnd.GetInitialPixelForRow(j);

                        for (int i = 0; i < width; i++)
                        {
                            // Blend the input pixels into the output pixel
                            outPixel->R = (byte)((startPixel->R * blend) + .5 + (endPixel->R * (1 - blend))); // .5 for rounding
                            outPixel->G = (byte)((startPixel->G * blend) + .5 + (endPixel->G * (1 - blend)));
                            outPixel->B = (byte)((startPixel->B * blend) + .5 + (endPixel->B * (1 - blend)));

                            outPixel++;
                            startPixel++;
                            endPixel++;
                        }
                    }
                    sw.Stop();
                }
            }

            // Return the new image
            time = sw.Elapsed;
            return output;
        }

        private void EnableOrDisableFormControls(bool enable)
        {
            btnParallel.Enabled = enable;
            btnSequential.Enabled = enable;
            splitContainer1.Enabled = enable;
        }
    }
}