//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: ComputeMorph.cs
//
//--------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Drawing;

namespace ParallelMorph
{
    /// <summary>Computes a morph between two images.</summary>
	public sealed class ComputeMorph
	{
        private ComputeMorphOptions _options;
		private int _curFrame = 0;
        private CancellationToken _cancellationToken;
        private bool _useParallelism;

        public ComputeMorph(ComputeMorphOptions options, bool useParallelism, CancellationToken cancellationToken)
        {
            if (options == null) throw new ArgumentNullException("options");
            _options = options;
            _useParallelism = useParallelism;
            _cancellationToken = cancellationToken;
        }

        public event ProgressChangedEventHandler ProgressChanged;

        private void UpdateProgressChanged()
        {
            ProgressChangedEventHandler handler = ProgressChanged;
            if (handler != null)
            {
                double progress = _curFrame * 100.0 / _options.NumberOfOutputFrames;
                handler(this, new ProgressChangedEventArgs((int)progress, null));
            }
        }

        public Bitmap RenderFrame(LinePairCollection lines, Bitmap startImage, Bitmap endImage, double percent)
        {
            using (FastBitmap fastStartImage = new FastBitmap(startImage))
            using (FastBitmap fastEndImage = new FastBitmap(endImage))
            {
                return RenderFrame(lines, fastStartImage, fastEndImage, percent);
            }
        }

        private Bitmap RenderFrame(LinePairCollection lines, FastBitmap startImage, FastBitmap endImage, double percent)
        {
            var forwardsAndBackwards = InterpolateLines(lines, percent);
            using (Bitmap forward = ComputePreimage( startImage,  forwardsAndBackwards.Item1))
            using (Bitmap backward = ComputePreimage( endImage, forwardsAndBackwards.Item2))
                return BlendImages(forward, backward, 1 - percent);
        }

		/// <summary>Create the morphed images and video.</summary>
        public void Render(IImageWriter imageWriter, LinePairCollection lines, Bitmap startImageBmp, Bitmap endImageBmp)
        {
            _curFrame = 0;
            double percentagePerFrame = 1.0 / (_options.NumberOfOutputFrames - 1);

            using (Bitmap clonedStart = Utilities.CreateNewBitmapFrom(startImageBmp))
            using (Bitmap clonedEnd = Utilities.CreateNewBitmapFrom(endImageBmp))
            {
                // Write out the starting picture
                imageWriter.AddFrame(clonedStart);
                _curFrame = 1;
                UpdateProgressChanged();

                using (FastBitmap startImage = new FastBitmap(startImageBmp))
                using (FastBitmap endImage = new FastBitmap(endImageBmp))
                {
                    for (int i = 1; i < _options.NumberOfOutputFrames - 1; i++)
                    {
                        _cancellationToken.ThrowIfCancellationRequested();
                        using (Bitmap frame = RenderFrame(lines, startImage, endImage, percentagePerFrame * i))
                        {
                            imageWriter.AddFrame(frame);
                        }
                        _curFrame++;
                        UpdateProgressChanged();
                    }
                }

                imageWriter.AddFrame(clonedEnd);
                _curFrame++;
                UpdateProgressChanged();
            }
        }

		/// <summary>Interpolates between the starting and ending morph lines.</summary>
		/// <param name="pairs">The morph lines to interpolate.</param>
		/// <param name="percent">The percent of the way through the morph.</param>
		/// <param name="interpolatedForwards">Resulting interpolated lines for the starting image.</param>
		/// <param name="interpolatedBackwards">Resulting interpolated lines for the ending image.</param>
		private Tuple<LinePairCollection,LinePairCollection> InterpolateLines(
			LinePairCollection pairs, double percent)
		{
            LinePairCollection interpolatedForwards = new LinePairCollection(), interpolatedBackwards = new LinePairCollection();
            foreach (Tuple<Line,Line> pair in pairs)
		    {
                // Source line is the same as the original; dest line is the interpolated line
				// Add the new pair to the forwards list and the inverse to the backwards list.
                var newPair = Tuple.Create(
                    new Line(pair.Item1.Item1, pair.Item1.Item2),
                    new Line(
                        AddPoints(pair.Item1.Item1, ScalePoint(SubPoints(pair.Item2.Item1, pair.Item1.Item1), percent)),
                        AddPoints(pair.Item1.Item2, ScalePoint(SubPoints(pair.Item2.Item2, pair.Item1.Item2), percent))
                    ));
                interpolatedForwards.Add(newPair);
                interpolatedBackwards.Add(Tuple.Create(
                    new Line(pair.Item2.Item1, pair.Item2.Item2),
                    new Line(newPair.Item2.Item1, newPair.Item2.Item2)));
			}
            return Tuple.Create(interpolatedForwards, interpolatedBackwards);
		}

		/// <summary>Add two points.</summary>
		/// <param name="p1">The first point.</param>
		/// <param name="p2">The second point.</param>
		/// <returns>p1 + p2</returns>
		private PointF AddPoints(PointF p1, PointF p2)
		{
			return new PointF(p1.X+p2.X, p1.Y+p2.Y);
		}

		/// <summary>Subtract two points.</summary>
		/// <param name="p1">The first point.</param>
		/// <param name="p2">The second point.</param>
		/// <returns>p1 - p2</returns>
		private PointF SubPoints(PointF p1, PointF p2)
		{
			return new PointF(p1.X-p2.X, p1.Y-p2.Y);
		}

		/// <summary>Scales a point/</summary>
		/// <param name="p">The point to be scaled.</param>
		/// <param name="scale">The scaled value.</param>
		/// <returns>p * scale.</returns>
		private PointF ScalePoint(PointF p, double scale)
		{
			return new PointF(p.X*(float)scale, p.Y*(float)scale);
		}

		/// <summary>Normalizes the point as a vector.</summary>
		/// <param name="p">The point.</param>
		/// <returns>sqrt(p.x^2 + p.y^2)</returns>
		private double NormalizePoint(PointF p)
		{
			return Math.Sqrt(p.X*p.X + p.Y*p.Y);
		}

		/// <summary>Computes the dot product of two points.</summary>
		/// <param name="p1">The first point.</param>
		/// <param name="p2">The second point.</param>
		/// <returns>p1 . p2</returns>
		private double DotProduct(PointF p1, PointF p2)
		{
			return p1.X*p2.X + p1.Y*p2.Y;
		}

		/// <summary>Mirros a point.</summary>
		/// <param name="p">The point.</param>
		/// <returns>The point flipped perpendicularlly.</returns>
		private PointF FlipPerpendicular(PointF p)
		{
			return new PointF(p.Y*-1, p.X);
		}

        /// <summary>Gets the X location of a point in the source image for a point X' in the target image.</summary>
        /// <param name="p">The point whose preimage location we need.</param>
        /// <param name="pairs">The morph line pairs used to translate the point.</param>
        /// <returns>The point in the original image.</returns>
        private PointF GetPreimageLocation(PointF p, LinePairCollection pairs)
        {
            if (pairs.Count == 0) return p;

            // Grab settings
            double constA = _options.ConstA;
            double constB = _options.ConstB;
            double constP = _options.ConstP;

            PointF dSum = PointF.Empty;
            double weightSum = 0;

            foreach (var pair in pairs)
            {
                PointF srcStart = pair.Item1.Item1, srcEnd = pair.Item1.Item2;
                PointF destStart = pair.Item2.Item1, destEnd = pair.Item2.Item2;
                if (srcStart == srcEnd || destStart == destEnd) continue;

                PointF PQ = SubPoints(destEnd, destStart);
                double length = NormalizePoint(PQ);
                PointF PpQp = SubPoints(srcEnd, srcStart);
                PointF PX = SubPoints(p, destStart);

                double u = DotProduct(PX, PQ) / (length * length);
                double v = DotProduct(PX, FlipPerpendicular(PQ)) / length;

                PointF Xp = AddPoints(
                   AddPoints(srcStart, ScalePoint(PpQp, u)),
                   ScalePoint(FlipPerpendicular(PpQp), v / NormalizePoint(PpQp)));

                // Compute shortest distance from X to the line segment PQ
                double dist;
                if (u < 0) dist = NormalizePoint(SubPoints(p, destStart));
                else if (u > 1) dist = NormalizePoint(SubPoints(p, destEnd));
                else dist = Math.Abs(v);

                double strength = Math.Pow(length, constP) / (constA + dist);
                double weight = (constB == 2.0) ? strength * strength : Math.Pow(strength, constB);
                dSum = AddPoints(dSum, ScalePoint(SubPoints(Xp, p), weight));
                weightSum += weight;
            }

            return AddPoints(p, ScalePoint(dSum, 1.0 / weightSum));
        }

		/// <summary>Generates the output image for a source image and a collection of morph lines.</summary>
		/// <param name="bmp">The input image.</param>
		/// <param name="pairs">The lines used to skew the image.</param>
		/// <returns>The computed image.</returns>
        private unsafe Bitmap ComputePreimage(FastBitmap bmp, LinePairCollection pairs)
        {
            int width = bmp.Size.Width, height = bmp.Size.Height;
            Bitmap output = new Bitmap(width, height);

            using (FastBitmap fastOut = new FastBitmap(output))
            {
                if (!_useParallelism)
                {
                    for (int j = 0; j < height; j++)
                    {
                        _cancellationToken.ThrowIfCancellationRequested();
                        for (int i = 0; i < width; i++)
                        {
                            PointF pf = GetPreimageLocation(new PointF(i, j), pairs);
                            Point p = ClampPoint(pf, new Size(width, height));
                            PixelData* inPixel = bmp[p.X, p.Y];
                            PixelData* outPixel = fastOut[i, j];
                            outPixel->R = inPixel->R;
                            outPixel->G = inPixel->G;
                            outPixel->B = inPixel->B;
                        }
                    }
                }
                else
                {
                    Parallel.For(0, height, new ParallelOptions { CancellationToken=_cancellationToken }, (j, loop) =>
                    {
                        for (int i = 0; i < width; i++)
                        {
                            PointF pf = GetPreimageLocation(new PointF(i, j), pairs);
                            Point p = ClampPoint(pf, new Size(width, height));
                            PixelData* inPixel = bmp[p.X, p.Y];
                            PixelData* outPixel = fastOut[i, j];
                            outPixel->R = inPixel->R;
                            outPixel->G = inPixel->G;
                            outPixel->B = inPixel->B;
                        }
                    });
                }
            }
            
            return output;
        }

		/// <summary>Ensures that a point is within a set boundary.</summary>
		/// <param name="p">The point to clamp.</param>
		/// <param name="s">The boundaries.</param>
		/// <returns>The clamped point.</returns>
		private Point ClampPoint(PointF p, Size s)
		{
            int x = (int)p.X, y = (int)p.Y;

			if (x < 0) x = 0;
			else if (x >= s.Width) x = s.Width-1;

			if (y < 0) y = 0;
			else if (y >= s.Height) y = s.Height-1;

            return new Point(x, y);
		}

		/// <summary>Blends two images.</summary>
		/// <param name="start">The first image.</param>
		/// <param name="end">The second image.</param>
		/// <param name="blend">The percentage of the alpha blend for the first image.</param>
		/// <returns>The blended image.</returns>
        private unsafe Bitmap BlendImages(Bitmap start, Bitmap end, double blend)
        {
            // Validate parameters
            if (start.Width != end.Width ||
                start.Height != end.Height) throw new ArgumentException("The sizes of images do not match.");
            if (blend < 0 || blend > 1) throw new ArgumentOutOfRangeException("blend", blend, "Must be in the range [0.0,1.1].");

            // Blend the images
            int width = start.Width, height = start.Height;
            Bitmap output = new Bitmap(width, height);
            using (FastBitmap fastOut = new FastBitmap(output))
            using (FastBitmap fastStart = new FastBitmap(start))
            using (FastBitmap fastEnd = new FastBitmap(end))
            {
                if (!_useParallelism)
                {
                    for (int i = 0; i < width; i++)
                    {
                        for (int j = 0; j < height; j++)
                        {
                            // Get the pixels for the starting, ending, and output images
                            PixelData* outPixel = fastOut[i, j];
                            PixelData* startPixel = fastStart[i, j];
                            PixelData* endPixel = fastEnd[i, j];

                            // Blend the input pixels into the output pixel
                            outPixel->R = (byte)((startPixel->R * blend) + .5 + (endPixel->R * (1 - blend))); // .5 for rounding
                            outPixel->G = (byte)((startPixel->G * blend) + .5 + (endPixel->G * (1 - blend)));
                            outPixel->B = (byte)((startPixel->B * blend) + .5 + (endPixel->B * (1 - blend)));
                        }
                    }
                }
                else
                {
                    Parallel.For(0, width, i =>
                    {
                        for (int j = 0; j < height; j++)
                        {
                            // Get the pixels for the starting, ending, and output images
                            PixelData* outPixel = fastOut[i, j];
                            PixelData* startPixel = fastStart[i, j];
                            PixelData* endPixel = fastEnd[i, j];

                            // Blend the input pixels into the output pixel
                            outPixel->R = (byte)((startPixel->R * blend) + .5 + (endPixel->R * (1 - blend))); // .5 for rounding
                            outPixel->G = (byte)((startPixel->G * blend) + .5 + (endPixel->G * (1 - blend)));
                            outPixel->B = (byte)((startPixel->B * blend) + .5 + (endPixel->B * (1 - blend)));
                        }
                    });
                }
            }
            return output;
        }
	}
}