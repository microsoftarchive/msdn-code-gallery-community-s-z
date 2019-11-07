// Stephen Toub

using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Microsoft.Pcp.Pfx.InteractiveFractal
{
    public partial class MainForm : Form
    {
        public MainForm() { InitializeComponent(); }

        /// <summary>Describes the bounds of the fractal to render.</summary>
        MandelbrotPosition _mandelbrotWindow = MandelbrotPosition.Default;
        /// <summary>The last known size of the main window.</summary>
        private Size _lastWindowSize = Size.Empty;
        /// <summary>The last known position of the mouse.</summary>
        private Point _lastMousePosition;
        /// <summary>The most recent cancellation source to cancel the last task.</summary>
        private CancellationTokenSource _lastCancellation;
        /// <summary>The last time the image was updated.</summary>
        private DateTime _lastUpdateTime = DateTime.MinValue;
        /// <summary>Whether the left mouse button is currently pressed on the picture box.</summary>
        private bool _leftMouseDown = false;
        /// <summary>
        /// The format string to use for the main form's title; {0} should be set to the number of
        /// pixels per second rendered.
        /// </summary>
        private const string _formTitle = "Interactive Fractal ({0}x) - PPMS: {1} - Time: {2}";
        /// <summary>Whether to use parallel rendering.</summary>
        private bool _parallelRendering = false;

        void mandelbrotPb_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Center the image on the selected location
            _mandelbrotWindow.CenterX += ((e.X - (mandelbrotPb.Width / 2.0)) / mandelbrotPb.Width) * _mandelbrotWindow.Width;
            _mandelbrotWindow.CenterY += ((e.Y - (mandelbrotPb.Height / 2.0)) / mandelbrotPb.Height) * _mandelbrotWindow.Height;

            // If the left mouse button was used, zoom in by a factor of 2; if the right mouse button, zoom
            // out by a factor of 2
            double factor = e.Button == MouseButtons.Left ? .5 : 2;
            _mandelbrotWindow.Width *= factor;
            _mandelbrotWindow.Height *= factor;
            
            // Update the image
            UpdateImageAsync();
        }

        void mandelbrotPb_VisibleChanged(object sender, EventArgs e)
        {
            // When the picture box becomes visible, render it
            if (mandelbrotPb.Visible)
            {
                _lastWindowSize = Size;
                UpdateImageAsync();
            }
        }

        void mandelbrotPb_Resize(object sender, EventArgs e)
        {
            // If the window has been resized
            if (Size != _lastWindowSize)
            {
                // Scale the mandelbrot image by the same factor so that its visual size doesn't change
                if (_lastWindowSize.Width != 0)
                {
                    double xFactor = Size.Width / (double)_lastWindowSize.Width;
                    _mandelbrotWindow.Width *= xFactor;
                }

                if (_lastWindowSize.Height != 0)
                {
                    double yFactor = Size.Height / (double)_lastWindowSize.Height;
                    _mandelbrotWindow.Height *= yFactor;
                }

                // Record the new window size
                _lastWindowSize = Size;

                // Update the image
                UpdateImageAsync();
            }
        }

        void mandelbrotPb_MouseMove(object sender, MouseEventArgs e)
        {
            // Determine how far the mouse has moved.  If it moved at all...
            Point delta = new Point(e.X - _lastMousePosition.X, e.Y - _lastMousePosition.Y);
            if (delta != Point.Empty)
            {
                // And if the left mouse button is down...
                if (_leftMouseDown)
                {
                    // Determine how much the mouse moved in fractal coordinates
                    double fractalMoveX = delta.X * _mandelbrotWindow.Width / mandelbrotPb.Width;
                    double fractalMoveY = delta.Y * _mandelbrotWindow.Height / mandelbrotPb.Height;

                    // Shift the fractal window accordingly
                    _mandelbrotWindow.CenterX -= fractalMoveX;
                    _mandelbrotWindow.CenterY -= fractalMoveY;
 
                    // And update the image
                    UpdateImageAsync();
                }
                // Record the new mouse position
                _lastMousePosition = e.Location;
            }
        }

        void mandelbrotPb_MouseDown(object sender, MouseEventArgs e)
        {
            // Record that mouse button is being pressed
            if (e.Button == MouseButtons.Left)
            {
                _lastMousePosition = e.Location;
                _leftMouseDown = true;
            }
        }

        void mandelbrotPb_MouseUp(object sender, MouseEventArgs e)
        {
            // Record that the mouse button is being released
            if (e.Button == MouseButtons.Left)
            {
                _lastMousePosition = e.Location;
                _leftMouseDown = false;
            }
        }

        private void UpdateImageAsync()
        {
            // If there's currently an active task, cancel it!  We don't care about it anymore.
            if (_lastCancellation != null) _lastCancellation.Cancel();

            // Get the current size of the picture box
            Size renderSize = mandelbrotPb.Size;

            // Keep track of the time this request was made.  If multiple requests are executing,
            // we want to only render the most recent one available rather than overwriting a more
            // recent image with an older one.
            DateTime timeOfRequest = DateTime.UtcNow;

            // Start a task to asynchronously render the fractal, and store the task
            // so we can cancel it later as necessary
            _lastCancellation = new CancellationTokenSource();
            var token = _lastCancellation.Token;
            Task.Factory.StartNew(() =>
            {
                // For diagnostic reasons, time how long the rendering takes
                Stopwatch sw = Stopwatch.StartNew();

                // Render the fractal
                Bitmap bmp = MandelbrotGenerator.Create(_mandelbrotWindow, renderSize.Width, renderSize.Height, token, _parallelRendering);
                if (bmp != null)
                {
                    sw.Stop();
                    double ppms = (renderSize.Width * renderSize.Height) / (double)sw.ElapsedMilliseconds;

                    // Update the fractal image asynchronously on the UI thread
                    Image old = null;
                    BeginInvoke((MethodInvoker)delegate
                    {
                        // If this image is the most recent, store it into the picture box
                        // making sure to free the resources for the one currently in use.
                        // And update the form's title to reflect the rendering time.
                        if (timeOfRequest > _lastUpdateTime)
                        {
                            old = mandelbrotPb.Image;
                            mandelbrotPb.Image = bmp;
                            _lastUpdateTime = timeOfRequest;
                            this.Text = string.Format(_formTitle, _parallelRendering ? Environment.ProcessorCount : 1, ppms.ToString("F2"), sw.ElapsedMilliseconds.ToString());
                        }
                        // If the image isn't the most recent, just get rid of it
                        else bmp.Dispose();
                    });
                    if (old != null) old.Dispose();
                }
            }, token);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.R)
            {
                _mandelbrotWindow = MandelbrotPosition.Default;

                using (MainForm tempForm = new MainForm())
                {
                    double xFactor = Size.Width / (double)tempForm.Width, yFactor = Size.Height / (double)tempForm.Height;
                    _mandelbrotWindow.Width *= xFactor;
                    _mandelbrotWindow.Height *= yFactor;
                }

                UpdateImageAsync();
            }
            else if (e.KeyCode == Keys.S)
            {
                _parallelRendering = false;
                UpdateImageAsync();
            }
            else if (e.KeyCode == Keys.P)
            {
                _parallelRendering = true;
                UpdateImageAsync();
            }
        }
    }
}


