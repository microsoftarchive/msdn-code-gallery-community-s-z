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
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParallelMorph
{
    /// <summary>Main application form.</summary>
    public partial class MainForm : Form
    {
        private UiSettings _morphSettings = new UiSettings();
        private LinePairCollection _lines;
        private int _currentLineImageNumber = 0;
        private int _currentLineEnd = 0;
        private bool _lineCreationInProcess = false;
        private TaskFactory _uiThread;
        private ComputeMorph _morpher;
        private CancellationTokenSource _currentCancellationSource;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Create a Task factory to use for targetting the UI thread
            _uiThread = new TaskFactory(TaskScheduler.FromCurrentSynchronizationContext());

            // Initialize the picture boxes
            _lines = new LinePairCollection();
            ConfigurePictureBoxes(_lines, null, null);

            // Set up the parallel menu item to reflect the number of cores
            parallelProcessingModeToolStripMenuItem.Text += " (" + Environment.ProcessorCount + "x)";
        }

        private void ConfigurePictureBoxes(LinePairCollection lines, Image startImage, Image endImage)
        {
            // The lines collection stores the line pairs.  Configure the start image to selec the 0th line from each pair.
            pbStartImage.LinePairs = _lines;
            pbStartImage.ImageNumber = 0;
            pbStartImage.Image = startImage;

            // ... and configure the start image to selec the 0th line from each pair.
            pbEndImage.LinePairs = _lines;
            pbEndImage.ImageNumber = 1;
            pbEndImage.Image = endImage;

            if (autoSizeToolStripMenuItem.Checked)
            {
                pbStartImage.Dock = DockStyle.None;
                pbStartImage.SizeMode = PictureBoxSizeMode.AutoSize;
                pbEndImage.Dock = DockStyle.None;
                pbEndImage.SizeMode = PictureBoxSizeMode.AutoSize;
            }
            else if (zoomToolStripMenuItem.Checked)
            {
                pbStartImage.Dock = DockStyle.Fill;
                pbStartImage.SizeMode = PictureBoxSizeMode.Zoom;
                pbEndImage.Dock = DockStyle.Fill;
                pbEndImage.SizeMode = PictureBoxSizeMode.Zoom;
            }

            btnMorph.Enabled = pbStartImage.Image != null && pbEndImage.Image != null;

            pbStartImage.Refresh();
            pbEndImage.Refresh();
        }

        private string SelectOutputPath(OutputMode mode)
        {
            switch (mode)
            {
                case OutputMode.Movie:
                    // Get target movie path
                    var sfd = new SaveFileDialog() { Filter = "AVI Files (*.avi)|*.avi" };
                    if (sfd.ShowDialog(this) == DialogResult.OK) return sfd.FileName;
                    else return null;

                case OutputMode.ImageSequence:
                    // Get target directory path
                    var fbd = new FolderBrowserDialog();
                    if (fbd.ShowDialog(this) == DialogResult.OK) return fbd.SelectedPath;
                    else return null;

                default:
                    throw new InvalidOperationException();
            }
        }

        private void PrepareUIDataForMorph(
            out UiSettings settings, out LinePairCollection lines,
            out Bitmap newStartImage, out Bitmap newEndImage)
        {
            // Grab UI data
            settings = Utilities.DeepClone(_morphSettings);
            lines = Utilities.DeepClone(_lines);

            // Get the original iamges
            var origStartImage = (Bitmap)pbStartImage.Image;
            var origEndImage = (Bitmap)pbEndImage.Image;

            // Get a scale factor from the UI
            float startImageScaleFactor = int.Parse(outputSizeToolStripTextBox.Text) / 100f;

            // Create the starting and ending images.  The starting image is scaled by the UI setting,
            // and the ending image is created to match the starting image's size.
            newStartImage = Utilities.CreateNewBitmapFrom(origStartImage, startImageScaleFactor);
            newEndImage = Utilities.CreateNewBitmapFrom(origEndImage, newStartImage.Width, newStartImage.Height);

            // Get a scale factor by comparing the new and old ending images
            var endImageScaleFactor = new PointF(
                newEndImage.Width / (float)origEndImage.Width,
                newEndImage.Height / (float)origEndImage.Height);

            // Create new line pairings to cope with the scaling
            var newlineList =
                (from pair in _lines
                 select Tuple.Create(
                     new Line(
                     new PointF(pair.Item1.Item1.X * startImageScaleFactor, pair.Item1.Item1.Y * startImageScaleFactor),
                     new PointF(pair.Item1.Item2.X * startImageScaleFactor, pair.Item1.Item2.Y * startImageScaleFactor)),
                     new Line(
                     new PointF(pair.Item2.Item1.X * endImageScaleFactor.X, pair.Item2.Item1.Y * endImageScaleFactor.Y),
                     new PointF(pair.Item2.Item2.X * endImageScaleFactor.X, pair.Item2.Item2.Y * endImageScaleFactor.Y)))).ToList();
            lines = new LinePairCollection(newlineList);
        }

        private void btnMorph_Click(object sender, EventArgs e)
        {
            if (pbStartImage.Image == null || pbEndImage.Image == null) return;

            // Get the parallel mode, the output mode, and query the user for the output path
            bool useParallelism = parallelProcessingModeToolStripMenuItem.Checked;
            OutputMode outputMode = aviOutputToolStripMenuItem.Checked ? OutputMode.Movie : OutputMode.ImageSequence;
            string outputPath = SelectOutputPath(outputMode);
            if (outputPath == null) return;

            // Grab UI data
            UiSettings settings;
            LinePairCollection lines;
            Bitmap startImage, endImage;
            PrepareUIDataForMorph(out settings, out lines, out startImage, out endImage);

            // Setup UI for run
            this.Text = "Parallel Morph - Running...";
            pbMorphStatus.Visible = true;
            splitContainer1.Visible = false;
            menuStrip1.Enabled = false;
            btnCancel.Visible = true;
            btnCancel.Enabled = true;
            btnMorph.Enabled = false;
            pbInProgressMorph.Visible = true;
            _currentCancellationSource = new CancellationTokenSource();
            var cancellationToken = _currentCancellationSource.Token;

            // Time how long the operation takes
            Stopwatch startTime = Stopwatch.StartNew();

            // Create the morpher and launch the algorithm to run asynchronously
            _morpher = new ComputeMorph(settings, useParallelism, cancellationToken);
            _morpher.ProgressChanged += (ps, pe) => _uiThread.StartNew(() => pbMorphStatus.Value = pe.ProgressPercentage);
            Task.Factory.StartNew(() =>
            {
                // Create an output writer based on whether we're writing to image files or to a movie file
                using (var tempImageWriter = outputMode == OutputMode.Movie ?
                    (IImageWriter)new AviImageWriter(outputPath, settings.FramesPerSecond, startImage.Width, startImage.Height) :
                    (IImageWriter)new JpgImageWriter(outputPath, "MorphFrame"))
                {
                    // Also display every frame to the UI
                    var imageWriter = new PassthroughImageWriter(tempImageWriter, bmp =>
                    {
                        var clonedBmp = Utilities.CreateNewBitmapFrom(bmp);
                        _uiThread.StartNew(() =>
                        {
                            Image oldImage = pbInProgressMorph.Image;
                            pbInProgressMorph.Image = clonedBmp;
                            if (oldImage != null) oldImage.Dispose();
                        });
                    });

                    // Run the morph synchronously
                    _morpher.Render(imageWriter, lines, startImage, endImage);
                }

                // When the morph completes, update the UI...
            }, cancellationToken).ContinueWith(t =>
            {
                _morpher = null;
                btnMorph.Enabled = true;
                btnCancel.Visible = false;
                pbMorphStatus.Visible = false;
                splitContainer1.Visible = true;
                menuStrip1.Enabled = true;
                pbInProgressMorph.Visible = false;
                if (pbInProgressMorph.Image != null)
                {
                    Image oldImage = pbInProgressMorph.Image;
                    pbInProgressMorph.Image = null;
                    oldImage.Dispose();
                }

                this.Text = "Parallel Morph - " + t.Status + " - " + startTime.Elapsed.ToString();
                if (t.IsFaulted) MessageBox.Show(this, t.Exception.ToString(), "Morph Error");
            }, _uiThread.Scheduler);
        }


        private void frmMainForm_KeyDown(object sender, KeyEventArgs e)
        {
            // The arrow keys allow cycling through each of the line pairs, and d/delete/back also
            // support deleting line pairs.
            switch (e.KeyCode)
            {
                case Keys.Right: _lines.SelectNext(); break;
                case Keys.Left: _lines.SelectPrev(); break;
                case Keys.Up: _lines.SelectFirst(); break;
                case Keys.Down: _lines.SelectLast(); break;
                case Keys.Back:
                case Keys.Delete:
                case Keys.D:
                    if (_lines.Selected != null) _lines.Remove(_lines.Selected);
                    break;
            }
            pbStartImage.Refresh();
            pbEndImage.Refresh();
        }

        private void SetFoundPairAtPoint(int imageNum, PointF location)
        {
            const int radius = 6;
            int end;

            // First check if the selected one fits, and keep it if it does
            if (_lines.Selected != null &&
                LineHitByPoint(_lines.Selected.Item(imageNum), location, radius, out end))
            {
                _currentLineImageNumber = imageNum;
                _currentLineEnd = end;
                return;
            }

            // If the selected one doesn't fit reset the selected pair and try to find one that fits.
            _lines.Selected = null;
            foreach (var pair in _lines)
            {
                Line line = pair.Item(imageNum);
                if (LineHitByPoint(line, location, radius, out end))
                {
                    _currentLineImageNumber = imageNum;
                    _currentLineEnd = end;
                    _lines.Selected = pair;
                    return;
                }
            }
        }

        private bool LineHitByPoint(Line line, PointF location, int radius, out int end)
        {
            end = -1;
            for (int i = 0; i < 2; i++)
            {
                PointF p = line[i];

                int x = (int)(p.X - radius);
                if (x < 0) x = 0;
                int y = (int)(p.Y - radius);
                if (y < 0) y = 0;

                if (new RectangleF(x, y, radius * 2, radius * 2).Contains(location))
                {
                    end = i;
                    return true;
                }
            }
            return false;
        }

        private void HandleMouseDown(MouseEventArgs e, LinedPictureBox pb)
        {
            if (pbStartImage.Image != null && pbEndImage.Image != null)
            {
                PointF point = pb.TranslateImageToControl((PointF)e.Location);
                if (e.Button == MouseButtons.Left)
                {
                    SetFoundPairAtPoint(pb.ImageNumber, point);
                }
                else
                {
                    _lines.Add(Tuple.Create(
                        new Line(point, point),
                        new Line(point, point)));
                    _currentLineImageNumber = pb.ImageNumber;
                    _currentLineEnd = 1;
                    _lineCreationInProcess = true;
                }
                pbStartImage.Refresh();
                pbEndImage.Refresh();
            }
        }

        private void HandleMouseUp(MouseEventArgs e, LinedPictureBox pb)
        {
            if (pbStartImage.Image != null && pbEndImage.Image != null)
            {
                if (_lineCreationInProcess)
                {
                    // If we're creating a new line and if the line is too small, delete it.
                    if (_lines.Selected != null)
                    {
                        var line = _lines.Selected.Item(_currentLineImageNumber);
                        if (line.Item1.Equals(line.Item2))
                        {
                            _lines.Remove(_lines.Selected);
                        }
                    }
                }
                _lineCreationInProcess = false;
                pbStartImage.Refresh();
                pbEndImage.Refresh();
            }
        }

        private void HandleMouseMove(MouseEventArgs e, LinedPictureBox pb)
        {
            if (pbStartImage.Image != null && pbEndImage.Image != null)
            {
                if (_lines.Selected != null &&
                    (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right))
                {
                    _lines.Selected.Item(_currentLineImageNumber)[_currentLineEnd] = pb.TranslateImageToControl((PointF)e.Location);
                    if (_lineCreationInProcess)
                    {
                        // if we're creating the line, shape both the start and end line the same
                        _lines.Selected.Item(_currentLineImageNumber ^ 1)[_currentLineEnd] =
                            _lines.Selected.Item(_currentLineImageNumber)[_currentLineEnd];
                    }
                }
                pbStartImage.Refresh();
                pbEndImage.Refresh();
            }
        }

        private void pbAnyImage_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            HandleMouseDown(e, (LinedPictureBox)sender);
        }

        private void pbAnyImage_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            HandleMouseMove(e, (LinedPictureBox)sender);
        }

        private void pbAnyImage_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            HandleMouseUp(e, (LinedPictureBox)sender);
        }

        private void autoSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pbStartImage.SizeMode = PictureBoxSizeMode.AutoSize;
            pbStartImage.Dock = DockStyle.None;
            pbEndImage.SizeMode = PictureBoxSizeMode.AutoSize;
            pbEndImage.Dock = DockStyle.None;
            autoSizeToolStripMenuItem.Checked = true;
            zoomToolStripMenuItem.Checked = false;
        }

        private void zoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pbStartImage.SizeMode = PictureBoxSizeMode.Zoom;
            pbStartImage.Dock = DockStyle.Fill;
            pbEndImage.SizeMode = PictureBoxSizeMode.Zoom;
            pbEndImage.Dock = DockStyle.Fill;
            autoSizeToolStripMenuItem.Checked = false;
            zoomToolStripMenuItem.Checked = true;
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (EditSettings es = new EditSettings())
            {
                es.Settings = _morphSettings;
                es.ShowDialog(this);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "Parallel Morph";
            _lines = new LinePairCollection();
            ConfigurePictureBoxes(_lines, null, null);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _lines.Selected = null;
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Morph Files (*.morph)|*.morph|All Files (*.*)|*.*";
                if (ofd.ShowDialog(this) == DialogResult.OK)
                {
                    var formatter = new BinaryFormatter();
                    using (Stream fileStream = ofd.OpenFile())
                    {
                        SavedSettings ss = (SavedSettings)formatter.Deserialize(fileStream);
                        _lines = ss.Lines;
                        _morphSettings = ss.Settings;
                        ConfigurePictureBoxes(_lines, ss.FirstImage, ss.SecondImage);
                    }
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _lines.Selected = null;
            SavedSettings ss = new SavedSettings
            {
                FirstImage = pbStartImage.Image,
                SecondImage = pbEndImage.Image,
                Lines = _lines,
                Settings = _morphSettings
            };
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Morph Files (*.morph)|*.morph|All Files (*.*)|*.*";
                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    var formatter = new BinaryFormatter();
                    using (Stream fileStream = sfd.OpenFile())
                    {
                        formatter.Serialize(fileStream, ss);
                    }
                }
            }
        }

        private void LoadPictureBoxImage(object sender, EventArgs e)
        {
            _lines.Selected = null;
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files (*.jpg)|*.jpg|All Files (*.*)|*.*";
                if (ofd.ShowDialog(this) == DialogResult.OK)
                {
                    ((PictureBox)sender).Image = new Bitmap(ofd.FileName);
                }
            }
            if (pbStartImage.Image != null && pbEndImage.Image != null) btnMorph.Enabled = true;
        }

        private void splitContainer1_Panel1_DoubleClick(object sender, EventArgs e)
        {
            LoadPictureBoxImage(pbStartImage, e);
        }

        private void splitContainer1_Panel2_DoubleClick(object sender, EventArgs e)
        {
            LoadPictureBoxImage(pbEndImage, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_currentCancellationSource != null) _currentCancellationSource.Cancel();
            btnCancel.Enabled = false;
        }

        private void parallelModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in new ToolStripMenuItem[] { sequentialProcessingModeToolStripMenuItem, parallelProcessingModeToolStripMenuItem })
            {
                item.Checked = item == sender;
            }
        }

        private void outputModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in new ToolStripMenuItem[] { aviOutputToolStripMenuItem, imagesOutputToolStripMenuItem })
            {
                item.Checked = item == sender;
            }
        }

        private void morphInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var image = pbStartImage.Image;
            MessageBox.Show(this, 
                string.Format("Lines: {1}{0}Width: {2}{0}Height: {3}{0}",
                    Environment.NewLine,
                    _lines.Count, 
                    image != null ? image.Width : 0,
                    image != null ? image.Height : 0),
                "Morph Information");
        }
    }
}