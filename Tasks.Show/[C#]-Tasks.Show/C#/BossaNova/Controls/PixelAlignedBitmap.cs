using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Tasks.Show.Controls
{
    class PixelAlignedImage : UIElement
    {
		#region Fields 

        private Point _pixelOffset;
        private EventHandler _sourceDownloaded;
        private EventHandler<ExceptionEventArgs> _sourceFailed;
        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register(
            "Source",
            typeof(BitmapSource),
            typeof(PixelAlignedImage),
            new FrameworkPropertyMetadata(
                null,
                FrameworkPropertyMetadataOptions.AffectsRender |
                FrameworkPropertyMetadataOptions.AffectsMeasure,
                new PropertyChangedCallback(PixelAlignedImage.OnSourceChanged)));

		#endregion Fields 

		#region Constructors 

        public PixelAlignedImage()
        {
            _sourceDownloaded = new EventHandler(OnSourceDownloaded);
            _sourceFailed = new EventHandler<ExceptionEventArgs>(OnSourceFailed);

            LayoutUpdated += new EventHandler(OnLayoutUpdated);
        }

		#endregion Constructors 

		#region Properties 

        public BitmapSource Source
        {
            get
            {
                return (BitmapSource)GetValue(SourceProperty);
            }
            set
            {
                SetValue(SourceProperty, value);
            }
        }

		#endregion Properties 

		#region Events 

        public event EventHandler<ExceptionEventArgs> BitmapFailed;

		#endregion Events 

		#region Protected Methods 

        // Return our measure size to be the size needed to display the bitmap pixels.
        protected override Size MeasureCore(Size availableSize)
        {
            return new Size(Source.PixelWidth, Source.PixelHeight);
            //Size measureSize = new Size();

            //BitmapSource bitmapSource = Source;
            //if (bitmapSource != null)
            //{
            //    PresentationSource ps = PresentationSource.FromVisual(this);
            //    if (ps != null)
            //    {
            //        Matrix fromDevice = ps.CompositionTarget.TransformFromDevice;

            //        Vector pixelSize = new Vector(bitmapSource.PixelWidth, bitmapSource.PixelHeight);
            //        Vector measureSizeV = fromDevice.Transform(pixelSize);
            //        measureSize = new Size(measureSizeV.X, measureSizeV.Y);
            //    }
            //}

            //return measureSize;
        }

        protected override void OnRender(DrawingContext dc)
        {
            BitmapSource bitmapSource = this.Source;
            if (bitmapSource != null)
            {
                _pixelOffset = GetPixelOffset();

                // Render the bitmap offset by the needed amount to align to pixels.
                dc.DrawImage(bitmapSource, new Rect(_pixelOffset, DesiredSize));
            }
        }

		#endregion Protected Methods 

		#region Private Methods 

        private Point ApplyVisualTransform(Point point, Visual v, bool inverse)
        {
            bool success = true;
            return TryApplyVisualTransform(point, v, inverse, true, out success);
        }

        private bool AreClose(Point point1, Point point2)
        {
            return AreClose(point1.X, point2.X) && AreClose(point1.Y, point2.Y);
        }

        private bool AreClose(double value1, double value2)
        {
            if (value1 == value2)
            {
                return true;
            }
            double delta = value1 - value2;
            return ((delta < 1.53E-06) && (delta > -1.53E-06));
        }

        private Point GetPixelOffset()
        {
            Point pixelOffset = new Point();

            PresentationSource ps = PresentationSource.FromVisual(this);
            if (ps != null)
            {
                Visual rootVisual = ps.RootVisual;

                // Transform (0,0) from this element up to pixels.
                pixelOffset = this.TransformToAncestor(rootVisual).Transform(pixelOffset);
                pixelOffset = ApplyVisualTransform(pixelOffset, rootVisual, false);
                pixelOffset = ps.CompositionTarget.TransformToDevice.Transform(pixelOffset);

                // Round the origin to the nearest whole pixel.
                pixelOffset.X = Math.Round(pixelOffset.X);
                pixelOffset.Y = Math.Round(pixelOffset.Y);

                // Transform the whole-pixel back to this element.
                pixelOffset = ps.CompositionTarget.TransformFromDevice.Transform(pixelOffset);
                pixelOffset = ApplyVisualTransform(pixelOffset, rootVisual, true);
                pixelOffset = rootVisual.TransformToDescendant(this).Transform(pixelOffset);
            }

            return pixelOffset;
        }

        // Gets the matrix that will convert a point from "above" the
        // coordinate space of a visual into the the coordinate space
        // "below" the visual.
        private Matrix GetVisualTransform(Visual v)
        {
            if (v != null)
            {
                Matrix m = Matrix.Identity;

                Transform transform = VisualTreeHelper.GetTransform(v);
                if (transform != null)
                {
                    Matrix cm = transform.Value;
                    m = Matrix.Multiply(m, cm);
                }

                Vector offset = VisualTreeHelper.GetOffset(v);
                m.Translate(offset.X, offset.Y);

                return m;
            }

            return Matrix.Identity;
        }

        private void OnLayoutUpdated(object sender, EventArgs e)
        {
            // This event just means that layout happened somewhere.  However, this is
            // what we need since layout anywhere could affect our pixel positioning.
            Point pixelOffset = GetPixelOffset();
            if (!AreClose(pixelOffset, _pixelOffset))
            {
                InvalidateVisual();
            }
        }

        private static void OnSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PixelAlignedImage bitmap = (PixelAlignedImage)d;

            BitmapSource oldValue = (BitmapSource)e.OldValue;
            BitmapSource newValue = (BitmapSource)e.NewValue;

            if (((oldValue != null) && (bitmap._sourceDownloaded != null)) && (!oldValue.IsFrozen && (oldValue is BitmapSource)))
            {
                ((BitmapSource)oldValue).DownloadCompleted -= bitmap._sourceDownloaded;
                ((BitmapSource)oldValue).DownloadFailed -= bitmap._sourceFailed;
                ((BitmapSource)newValue).DecodeFailed -= bitmap._sourceFailed; // 3.5
            }
            if (((newValue != null) && (newValue is BitmapSource)) && !newValue.IsFrozen)
            {
                ((BitmapSource)newValue).DownloadCompleted += bitmap._sourceDownloaded;
                ((BitmapSource)newValue).DownloadFailed += bitmap._sourceFailed;
                ((BitmapSource)newValue).DecodeFailed += bitmap._sourceFailed; // 3.5
            }
        }

        private void OnSourceDownloaded(object sender, EventArgs e)
        {
            InvalidateMeasure();
            InvalidateVisual();
        }

        private void OnSourceFailed(object sender, ExceptionEventArgs e)
        {
            Source = null; // setting a local value seems scetchy...

            BitmapFailed(this, e);
        }

        private Point TryApplyVisualTransform(Point point, Visual v, bool inverse, bool throwOnError, out bool success)
        {
            success = true;
            if (v != null)
            {
                Matrix visualTransform = GetVisualTransform(v);
                if (inverse)
                {
                    if (!throwOnError && !visualTransform.HasInverse)
                    {
                        success = false;
                        return new Point(0, 0);
                    }
                    visualTransform.Invert();
                }
                point = visualTransform.Transform(point);
            }
            return point;
        }

		#endregion Private Methods 
    }
}
