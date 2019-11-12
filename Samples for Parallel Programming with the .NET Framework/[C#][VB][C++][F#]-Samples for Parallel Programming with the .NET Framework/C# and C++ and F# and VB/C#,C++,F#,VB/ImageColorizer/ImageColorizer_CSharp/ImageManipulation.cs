//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: ImageManipulation.cs
//
//--------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Drawing;

namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples
{
    /// <summary>Class for manipulating the colors in images.</summary>
    internal class ImageManipulation
    {
        /// <summary>Event that notifies of progress changes in image operations.</summary>
        public event ProgressChangedEventHandler ProgressChanged;

        /// <summary>Implements a b&w + hue-based transformation for an image.</summary>
        /// <param name="original">The original image.</param>
        /// <param name="selectedPixels">The location in the original image of the selected pixels for hue
        /// comparison.</param>
        /// <param name="epsilon">Allowed hue variation from selected pixels.</param>
        /// <param name="paths">GraphicPath instances demarcating regions containing possible pixels to be
        /// left in color.</param>
        /// <param name="parallel">Whether to run in parallel.</param>
        /// <returns>The new Bitmap.</returns>
        public Bitmap Colorize(Bitmap original, List<Point> selectedPixels, int epsilon, List<GraphicsPath> paths, bool parallel)
        {
            // Create a new bitmap with the same size as the original
            int width = original.Width, height = original.Height;
            Bitmap colorizedImage = new Bitmap(width, height);

            // Optimization: For every GraphicsPath, get a bounding rectangle.  This allows for quickly
            // ruling out pixels that are definitely not containing within the selected region.
            Rectangle [] pathsBounds = null;
            if (paths != null && paths.Count > 0) 
            {
                pathsBounds = new Rectangle[paths.Count];
                for(int i=0; i<pathsBounds.Length; i++)
                {
                    pathsBounds[i] = Rectangle.Ceiling(paths[i].GetBounds());
                }
            }

            // Optimization: Hit-testing against GraphicPaths is relatively slow.  Hit testing
            // against rectangles is very fast.  As such, appromixate the area of the GraphicsPath
            // with rectangles which can be hit tested against instead of the paths.  Not quite
            // as accurate, but much faster.
            List<RectangleF[]> compositions = null;
            if (paths != null && paths.Count > 0)
            {
                compositions = new List<RectangleF[]>(paths.Count);
                using (Matrix m = new Matrix())
                {
                    for(int i=0; i<paths.Count; i++)
                    {
                        using (Region r = new Region(paths[i])) compositions.Add(r.GetRegionScans(m));
                    }
                }
            }

            // Use FastBitmap instances to provide unsafe/faster access to the pixels
            // in the original and in the new images
            using (FastBitmap fastColorizedImage = new FastBitmap(colorizedImage))
            using (FastBitmap fastOriginalImage = new FastBitmap(original))
            {
                // Extract the selected hues from the selected pixels
                List<float> selectedHues = new List<float>(selectedPixels.Count);
                foreach (Point p in selectedPixels)
                {
                    selectedHues.Add(fastOriginalImage.GetColor(p.X, p.Y).GetHue());
                }

                // For progress update purposes, figure out how many pixels there
                // are in total, and how many constitute 1% so that we can raise
                // events after every additional 1% has been completed.
                long totalPixels = height * width;
                long pixelsPerProgressUpdate = totalPixels / 100;
                if (pixelsPerProgressUpdate == 0) pixelsPerProgressUpdate = 1;
                long pixelsProcessed = 0;

                // Pixels close to the selected hue but not close enough may be
                // left partially desaturated.  The saturation window determines
                // what pixels fall into that range.
                const int maxSaturationWindow = 10;
                int saturationWindow = Math.Min(maxSaturationWindow, epsilon);

                // Separated out the body of the loop just to make it easier
                // to switch between sequential and parallel for demo purposes
                Action<int> processRow = y =>
                {
                    for (int x = 0; x < width; x++)
                    {
                        // Get the color/hue of th epixel
                        Color c = fastOriginalImage.GetColor(x, y);
                        float pixelHue = c.GetHue();

                        // Use hit-testing to determine if the pixel is in the selected region.
                        bool pixelInSelectedRegion = false;

                        // First, if there are no paths, by definition it is in the selected
                        // region, since the whole image is then selected
                        if (paths == null || paths.Count == 0) pixelInSelectedRegion = true;
                        else
                        {
                            // For each path, first see if the pixel is within the bounding
                            // rectangle; if it's not, it's not in the selected region.
                            Point p = new Point(x, y);
                            for (int i = 0; i < pathsBounds.Length && !pixelInSelectedRegion; i++)
                            {
                                if (pathsBounds[i].Contains(p))
                                {
                                    // The pixel is within a bounding rectangle, so now
                                    // see if it's within the composition rectangles
                                    // approximating the region.
                                    foreach (RectangleF bound in compositions[i])
                                    {
                                        if (bound.Contains(x, y))
                                        {
                                            // If it is, it's in the region.
                                            pixelInSelectedRegion = true;
                                            break;
                                        }
                                    }
                                }
                            }
                        }

                        // Now that we know whether a pixel is in the region,
                        // we can figure out what to do with it.  If the pixel
                        // is not in the selected region, it needs to be converted
                        // to grayscale.
                        bool useGrayscale = true;
                        if (pixelInSelectedRegion)
                        {
                            // If it is in the selected region, get the color hue's distance 
                            // from each target hue.  If that distance is less than the user-selected
                            // hue variation limit, leave it in color.  If it's greater than the
                            // variation limit, but within the saturation window of the limit,
                            // desaturate it proportionally to the distance from the limit.
                            foreach (float selectedHue in selectedHues)
                            {
                                // A hue wheel is 360 degrees. If you pick two points on a wheel, there
                                // will be two distances between them, depending on which way you go around
                                // the wheel from one to the other (unless they're exactly opposite from
                                // each other on the wheel, the two distances will be different).  We always
                                // want to do our work based on the smaller of the two distances (e.g. a hue
                                // with the value 359 is very, very close to a hue with the value 1).  So,
                                // we take the absolute value of the difference between the two hues.  If that
                                // distance is 180 degrees, then both distances are the same, so it doesn't
                                // matter which we go with. If that difference is less than 180 degrees, 
                                // we know this must be the smaller of the two distances, since the sum of the 
                                // two distances must add up to 360.  If, however, it's larger than 180, it's the
                                // longer distance, so to get the shorter one, we have to subtract it from 360.
                                float distance = Math.Abs(pixelHue - selectedHue);
                                if (distance > 180) distance = 360 - distance;

                                if (distance <= epsilon)
                                {
                                    useGrayscale = false;
                                    break;
                                }
                                else if ((distance - epsilon) / saturationWindow < 1.0f)
                                {
                                    useGrayscale = false;
                                    c = ColorFromHsb(
                                        pixelHue,
                                        c.GetSaturation() * (1.0f - ((distance - epsilon) / maxSaturationWindow)),
                                        c.GetBrightness());
                                    break;
                                }
                            }
                        }

                        // Set the pixel color into the new image
                        if (useGrayscale) c = ToGrayscale(c);
                        fastColorizedImage.SetColor(x, y, c);
                    }

                    // Notify any listeners of our progress, if enough progress has been made
                    Interlocked.Add(ref pixelsProcessed, width);
                    OnProgressChanged((int)(100 * pixelsProcessed / (double)totalPixels));
                };

                // Copy over every single pixel, and possibly transform it in the process
                if (parallel)
                {
                    Parallel.For(0, height, processRow);
                }
                else
                {
                    for (int y = 0; y < height; y++) processRow(y);
                }
            }

            // We're done creating the image.  Return it.
            return colorizedImage;
        }

        /// <summary>Notifies any ProgressChanged subscribers of a progress update.</summary>
        /// <param name="progressPercentage">The progress percentage.</param>
        private void OnProgressChanged(int progressPercentage)
        {
            if (ProgressChanged != null)
            {
                ProgressChanged(this, new ProgressChangedEventArgs(progressPercentage, null));
            }
        }

        /// <summary>Converts a color to grayscale.</summary>
        /// <param name="c">The color to convert.</param>
        /// <returns>The grayscale color.</returns>
        private static Color ToGrayscale(Color c)
        {
            int luminance = (int)(0.299 * c.R + 0.587 * c.G + 0.114 * c.B);
            return Color.FromArgb(luminance, luminance, luminance);
        }

        /// <summary>HSB to RGB color conversion.</summary>
        /// <param name="h">The color's hue.</param>
        /// <param name="s">The color's saturation.</param>
        /// <param name="b">The color's brightness.</param>
        /// <returns>The RGB color for the supplied HSB values.</returns>
        /// <remarks>
        /// Based on Chris Jackson's conversion routine from:
        /// http://blogs.msdn.com/cjacks/archive/2006/04/12/575476.aspx
        /// </remarks>
        private static Color ColorFromHsb(float h, float s, float b)
        {
            if (0f > h || 360f < h) throw new ArgumentOutOfRangeException("h");
            if (0f > s || 1f < s) throw new ArgumentOutOfRangeException("s");
            if (0f > b || 1f < b) throw new ArgumentOutOfRangeException("b");

            if (0 == s) return Color.FromArgb((int)(b * 255), (int)(b * 255), (int)(b * 255));

            float fMax, fMid, fMin;
            int iSextant, iMax, iMid, iMin;

            if (0.5 < b)
            {
                fMax = b - (b * s) + s;
                fMin = b + (b * s) - s;
            }
            else
            {
                fMax = b + (b * s);
                fMin = b - (b * s);
            }

            iSextant = (int)(h / 60f);
            if (300f <= h)
            {
                h -= 360f;
            }
            h /= 60f;
            h -= 2f * (float)Math.Floor(((iSextant + 1f) % 6f) / 2f);
            if (0 == iSextant % 2)
            {
                fMid = h * (fMax - fMin) + fMin;
            }
            else
            {
                fMid = fMin - h * (fMax - fMin);
            }

            iMax = (int)(fMax * 255);
            iMid = (int)(fMid * 255);
            iMin = (int)(fMin * 255);

            switch (iSextant)
            {
                case 1:
                    return Color.FromArgb(iMid, iMax, iMin);
                case 2:
                    return Color.FromArgb(iMin, iMax, iMid);
                case 3:
                    return Color.FromArgb(iMin, iMid, iMax);
                case 4:
                    return Color.FromArgb(iMid, iMin, iMax);
                case 5:
                    return Color.FromArgb(iMax, iMin, iMid);
                default:
                    return Color.FromArgb(iMax, iMid, iMin);
            }
        }
    }
}