//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: MainForm.cs
//
//--------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.Ink;

namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples
{
    /// <summary>Main form for the application.</summary>
    public partial class MainForm : Form
    {
        /// <summary>Initializes the main form.</summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>A list of all selected points from which colors will be extracted from the image.</summary>
        private List<Point> _selectedPixels = new List<Point>();
        /// <summary>The last hue epsilon selected by the user.</summary>
        private int _lastEpsilon = -1;
        /// <summary>The last size of the image picture box before a resize.</summary>
        private Size _lastPictureBoxSize = new Size(-1, -1);
        /// <summary>A list of GraphicsPaths currently translated from Strokes.</summary>
        private List<GraphicsPath> _paths;
        /// <summary>The image as originally loaded.</summary>
        private Bitmap _originalImage;
        /// <summary>The current image after all color transformations.</summary>
        private Bitmap _colorizedImage;
        /// <summary>The InkOverlay used for accepting strokes to be translated into GraphicsPaths.</summary>
        private InkOverlay _overlay;

        /// <summary>Loads the form.</summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Store the current size of the picture box.  When the picture box is
            // resized (due to the form being resized), we need to scale any ink
            // that may exist on the form so that it sizes in accordance with the picture box.
            _lastPictureBoxSize = pbImage.Size;
            pbImage.AllowDrop = true;

            // If the current platform supports ink, initialize the InkOverlay
            if (PlatformDetection.SupportsInk) InitializeInk();

            // Setup the help text for the toolstrip
            lblHuesSelected.Text = string.Format(Properties.Resources.HuesSelectedDisplay, _selectedPixels.Count);
            tbEpsilon.ToolTipText = string.Format(Properties.Resources.EpsilonDisplay,  tbEpsilon.Value);
        }

        OpenFileDialog _ofd;

        /// <summary>Shows an OpenFileDialog and loads the selected image into the app.</summary>
        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            // Show a dialog to select JPG files
            if (_ofd == null)
            {
                _ofd = new OpenFileDialog();
                _ofd.Filter = "Image files (*.jpg, *.bmp, *.png, *.gif)|*.jpg;*.bmp;*.png;*.gif";
                _ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            }
            if (_ofd.ShowDialog() == DialogResult.OK) LoadImage(_ofd.FileName);
        }

        private void LoadImage(string path)
        {
            try
            {
                _originalImage = new Bitmap(path);
                pbImage.Image = _originalImage;

                // Disable saving of the image.  We only allow saving once changes have been made.
                btnSaveImage.Enabled = false;

                // Change the cursor on the picture box to let the user know they
                // can click on the image to select a hue.
                pbImage.Cursor = System.Windows.Forms.Cursors.Hand;

                // If ink is available on the current machine, enable the button that
                // turns on the overlay, and clear any existing ink from previous images
                // that may have existed in the app
                if (PlatformDetection.SupportsInk)
                {
                    btnInk.Enabled = true;
                    ClearInk();
                }
            }
            catch (ArgumentException) { }
        }

        /// <summary>Recomputes the image based on the newly selected pixel.</summary>
        private void pbImage_MouseClick(object sender, MouseEventArgs e)
        {
            // Only run if an image has been loaded and if ink isn't being drawn
            if (_originalImage != null && !(btnInk.Enabled && btnInk.Checked))
            {
                // Get the point in the original image.  To get this we need
                // to scale the selected point based on how much the image
                // is being resized for display.
                Point p = new Point(
                    (int)(e.X * _originalImage.Width / (double)pbImage.Width),
                    (int)(e.Y * _originalImage.Height / (double)pbImage.Height));

                // Add the selected point to the list or make it the only
                // point in the list, based on whether the shift key is being held down
                if (Control.ModifierKeys != Keys.Shift) _selectedPixels.Clear();
                _selectedPixels.Add(p);

                // With our updated list of selected pixels in hand, update
                // the toolstrip help text
                lblHuesSelected.Text = string.Format(Properties.Resources.HuesSelectedDisplay, _selectedPixels.Count);

                // Start recomputing the image based on the new parameters
                StartColorizeImage();
            }
        }

        private void StartColorizeImage()
        {
            // Stop the timer if it's running, since the timer's purpose
            // is to cause this method to be called when the timer expires
            tmRefresh.Stop();
            _lastEpsilon = tbEpsilon.Value;

            // If we have an image and if a pixel has been selected
            // and if we're not currently recomputing the image...
            if (_originalImage != null && _selectedPixels.Count > 0 && !bwColorize.IsBusy)
            {
                // If there are any strokes, turn them into GraphicsPaths
                if (PlatformDetection.SupportsInk)
                {
                    if (_paths != null)
                    {
                        foreach (GraphicsPath path in _paths) path.Dispose();
                    }
                    _paths = InkToGraphicsPaths(true);
                }

                // Modify the UI for progress
                toolStripMain.Enabled = false;
                pbImage.Enabled = false;
                pbColorizing.Value = 0;
                pbColorizing.Visible = true;

                // Recompute the image!
                bwColorize.RunWorkerAsync();
            }
        }

        /// <summary>Colorizes the image on a background thread.</summary>
        private void bwColorize_DoWork(object sender, DoWorkEventArgs e)
        {
            // Create the colorizer instance.  Any progress updates
            // will in turn update the progress through the BackgroundWorker.
            ImageManipulation colorizer = new ImageManipulation();
            colorizer.ProgressChanged += delegate(object s, ProgressChangedEventArgs pcea)
            {
                bwColorize.ReportProgress(pcea.ProgressPercentage);
            };

            // Create a clone of the original image, so that we can lock its bits
            // while still allowing the UI to refresh and resize appropriately
            using(Bitmap workImage = _originalImage.Clone(
                new Rectangle(0, 0, _originalImage.Width, _originalImage.Height), PixelFormat.Format24bppRgb))
            {
                // Colorize the image and store the resulting Bitmap
                e.Result = colorizer.Colorize(workImage, _selectedPixels, _lastEpsilon, _paths, btnParallel.Checked);
            }
        }

        /// <summary>Configures the MainForm after colorization is complete.</summary>
        private void bwColorize_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Reenable the UI
            pbColorizing.Visible = false;
            toolStripMain.Enabled = true;
            pbImage.Enabled = true;
            btnLoadImage.Enabled = true;
            btnSaveImage.Enabled = true;
            tbEpsilon.Focus();

            // Rethrow any exceptions
            if (e.Error != null) throw new TargetInvocationException(e.Error);

            // Get the newly computed image
            if (_colorizedImage != null) _colorizedImage.Dispose();
            _colorizedImage = (Bitmap)e.Result;

            // Set the newly computed image into the PictureBox
            if (pbImage.Image != null && pbImage.Image != _originalImage)
            {
                pbImage.Image.Dispose();
            }
            pbImage.Image = _colorizedImage;
        }

        /// <summary>Update the progress bar when the BackgroundWorker progress changes.</summary>
        private void bwColorize_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage > pbColorizing.Value) pbColorizing.Value = e.ProgressPercentage;
        }

        /// <summary>Saves the colorized image to a file.</summary>
        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            if (_colorizedImage != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Image files (*.jpg, *.bmp, *.png, *.gif)|*.jpg;*.bmp;*.png;*.gif|All files (*.*)|*.*";
                sfd.DefaultExt = ".jpg";
                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    SaveImage(_colorizedImage, sfd.FileName, 100);
                }
            }
        }

        /// <summary>Saves an image to a specified path and with a specified quality, if appropriate to the format.</summary>
        /// <param name="bmp">The image to be saved.</param>
        /// <param name="path">The path where to save the image.</param>
        /// <param name="quality">The quality of the image to save.</param>
        private static void SaveImage(Bitmap bmp, string path, long quality)
        {
            // Validate parameters
            if (bmp == null) throw new ArgumentNullException("bmp");
            if (path == null) throw new ArgumentNullException("path");
            if (quality < 1 || quality > 100) throw new ArgumentOutOfRangeException("quality", quality, "Quality out of range.");

            // Save it to a file format based on the path's extension
            switch (Path.GetExtension(path).ToLowerInvariant())
            {
                default:
                case ".bmp": bmp.Save(path, ImageFormat.Bmp); break;
                case ".png": bmp.Save(path, ImageFormat.Png); break;
                case ".gif": bmp.Save(path, ImageFormat.Gif); break;
                case ".tif":
                case ".tiff": bmp.Save(path, ImageFormat.Tiff); break;
                case ".jpg":
                    ImageCodecInfo jpegCodec = Array.Find(ImageCodecInfo.GetImageEncoders(),
                        delegate(ImageCodecInfo ici) { return ici.MimeType == "image/jpeg"; });
                    using (EncoderParameters codecParams = new EncoderParameters(1))
                    using (EncoderParameter ratio = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality))
                    {
                        // Set the JPEG quality value and save the image
                        codecParams.Param[0] = ratio;
                        bmp.Save(path, jpegCodec, codecParams);
                    }
                    break;
            }
        }

        /// <summary>Starts the colorization process when the refresh timer expires.</summary>
        private void tmRefresh_Tick(object sender, EventArgs e)
        {
            StartColorizeImage();
        }

        /// <summary>Starts the refresh timer when the epsilon track bar changes value.</summary>
        private void tbEpsilon_ValueChanged(object sender, EventArgs e)
        {
            tbEpsilon.ToolTipText = string.Format(Properties.Resources.EpsilonDisplay, tbEpsilon.Value);
            StartRefreshTimer();
        }

        /// <summary>Starts/restarts the refresh timer.</summary>
        private void StartRefreshTimer()
        {
            if (_originalImage != null &&
                _selectedPixels.Count > 0 && _lastEpsilon >= 0 &&
                !bwColorize.IsBusy)
            {
                btnLoadImage.Enabled = false;
                tmRefresh.Stop();
                tmRefresh.Start();
            }
        }

        /// <summary>Resizes any ink in the picture box when it resizes.</summary>
        private void pbImage_Resize(object sender, EventArgs e)
        {
            if (_lastPictureBoxSize.Width > 0 && _lastPictureBoxSize.Height > 0 &&
                PlatformDetection.SupportsInk)
            {
                ScaleInk();
            }
            _lastPictureBoxSize = pbImage.Size;
        }

        /// <summary>Initializes the InkOverlay.</summary>
        [MethodImpl(MethodImplOptions.NoInlining)]
        private void InitializeInk()
        {
            _overlay = new InkOverlay(pbImage, true);
            _overlay.DefaultDrawingAttributes.Width = 1;
            _overlay.DefaultDrawingAttributes.Color = Color.Red;
            _overlay.DefaultDrawingAttributes.IgnorePressure = true;

            // When a stroke is received, we start a timer that, when expiring,
            // will cause the image to be redrawn.  This timer allows the user
            // to draw multiple strokes without the image having to be redrawn
            // after each.
            _overlay.Stroke += delegate { StartRefreshTimer(); };

            // We also don't want the image to be redrawn midstroke (which
            // could happen if the user drew a stroke, causing the timer
            // to start, and then took longer than a second to draw the
            // second stroke), so when new packets are received, the timer
            // is stopped; it'll be restarted by the above when the Stroke
            // is completed.
            _overlay.NewPackets += delegate { tmRefresh.Stop(); };
        }

        /// <summary>Clears all ink from the overlay.</summary>
        [MethodImpl(MethodImplOptions.NoInlining)]
        private void ClearInk() { _overlay.Ink.DeleteStrokes(); }

        /// <summary>Scales the ink in the overlay.</summary>
        [MethodImpl(MethodImplOptions.NoInlining)]
        private void ScaleInk()
        {
            if (pbImage.Size.Width > 0 && pbImage.Size.Height > 0 &&
                _lastPictureBoxSize.Width > 0 && _lastPictureBoxSize.Height > 0 &&
                _overlay != null)
            {
                _overlay.Ink.Strokes.Scale(
                    pbImage.Size.Width / (float)_lastPictureBoxSize.Width,
                    pbImage.Size.Height / (float)_lastPictureBoxSize.Height);
            }
        }

        /// <summary>Converts all Strokes in the overlay to GraphicsPaths.</summary>
        /// <param name="scalePath">Whether to scale the GraphicsPaths based on the current image rescaling.</param>
        /// <returns>The list of converted GraphicsPath instances.</returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        private List<GraphicsPath> InkToGraphicsPaths(bool scalePath)
        {
            Renderer renderer = _overlay.Renderer;
            Strokes strokes = _overlay.Ink.Strokes;

            float scaleX = _originalImage.Width / (float)pbImage.Width;
            float scaleY = _originalImage.Height / (float)pbImage.Height;

            if (strokes.Count > 0)
            {
                using (Graphics g = CreateGraphics())
                {
                    List<GraphicsPath> paths = new List<GraphicsPath>(strokes.Count);
                    foreach (Stroke stroke in strokes)
                    {
                        Point[] points = stroke.GetPoints();
                        if (points.Length >= 3)
                        {
                            for (int i = 0; i < points.Length; i++)
                            {
                                renderer.InkSpaceToPixel(g, ref points[i]);
                                if (scalePath)
                                {
                                    points[i] = new Point(
                                        (int)(scaleX * points[i].X),
                                        (int)(scaleY * points[i].Y));
                                }
                            }
                            GraphicsPath path = new GraphicsPath();
                            path.AddPolygon(points);
                            path.CloseFigure();
                            paths.Add(path);
                        }
                    }
                    return paths;
                }
            }
            return null;
        }

        /// <summary>Enables or disables the InkOverlay.</summary>
        private void btnInk_Click(object sender, EventArgs e)
        {
            _overlay.Enabled = !_overlay.Enabled;
            btnInk.Checked = _overlay.Enabled;
            btnEraser.Enabled = btnInk.Checked;
        }

        /// <summary>Switches back and forth between Ink and Delete editing modes on the overlay.</summary>
        private void btnEraser_Click(object sender, EventArgs e)
        {
            _overlay.EditingMode = (_overlay.EditingMode == InkOverlayEditingMode.Delete) ?
                InkOverlayEditingMode.Ink : InkOverlayEditingMode.Delete;
            btnEraser.Checked = _overlay.EditingMode == InkOverlayEditingMode.Delete;
        }

        /// <summary>Resets back to the original image.</summary>
        private void lblHuesSelected_Click(object sender, EventArgs e)
        {
            _selectedPixels.Clear();
            pbImage.Image = _originalImage;
            if (_colorizedImage != null)
            {
                _colorizedImage.Dispose();
                _colorizedImage = null;
            }

            lblHuesSelected.Text = string.Format(Properties.Resources.HuesSelectedDisplay, _selectedPixels.Count);
            lblHuesSelected.ToolTipText = null;
        }

        /// <summary>Sets up a drag & drop affect.</summary>
        private void pbImage_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) &&
                ((string[])e.Data.GetData(DataFormats.FileDrop)).Length == 1)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        /// <summary>Completes a drag & drop operation, loading the dropped image.</summary>
        private void pbImage_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) &&
                e.Effect == DragDropEffects.Copy)
            {
                string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (paths.Length == 1)
                {
                    LoadImage(paths[0]);
                }
            }
        }

        private void btnParallel_CheckedChanged(object sender, EventArgs e)
        {
            StartColorizeImage();
        }
    }
}