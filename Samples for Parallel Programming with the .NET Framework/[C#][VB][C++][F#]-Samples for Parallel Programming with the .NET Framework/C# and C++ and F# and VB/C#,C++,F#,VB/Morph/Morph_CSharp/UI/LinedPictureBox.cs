//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: LinedPictureBox.cs
//
//--------------------------------------------------------------------------

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ParallelMorph
{
	/// <summary>PictureBox that also displays morphing lines.</summary>
	public class LinedPictureBox : PictureBox
	{
		/// <summary>The pen to use for drawing normal morph lines.</summary>
		private Pen _linePen;
		/// <summary>The pen to use for drawing selected morph lines.</summary>
		private Pen _selectedLinePen;

		/// <summary>Initialize the picture box.</summary>
		public LinedPictureBox()
		{
			// Create the normal line pen
			_linePen = new Pen(Brushes.Red, 1);
			_linePen.CustomEndCap = new AdjustableArrowCap(2, 2, true);

			// Create the selected line pen
			_selectedLinePen = new Pen(Brushes.Yellow, 1);
			_selectedLinePen.CustomEndCap = new AdjustableArrowCap(2, 2, true);
		}

		/// <summary>Gets or sets the morph line pairs to be drawn.</summary>
        public LinePairCollection LinePairs { get; set; }
		/// <summary>Gets or sets the number of the morph image held by this box.</summary>
		public int ImageNumber { get; set; }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _linePen.Dispose();
                _selectedLinePen.Dispose();
            }
            base.Dispose(disposing);
        }

		/// <summary>Renders the picture box.</summary>
		/// <param name="e">The paint events.</param>
		protected override void OnPaint(PaintEventArgs e)
		{
			// Render the base picture box (including the morph image)
			base.OnPaint (e);

			// If there are morph lines, render them.
			if (LinePairs != null && Image != null)
			{
				Graphics g = e.Graphics;
                foreach (var pair in LinePairs)
				{
                    Line line = pair.Item(ImageNumber);
					if (line != null)
					{
						g.DrawLine(
							pair == LinePairs.Selected ? _selectedLinePen : _linePen,
                            TranslateControlToImage(line[0]), 
                            TranslateControlToImage(line[1]));
					}
				}
			}
		}

        /// <summary>Translates a point from control space to image space.</summary>
        /// <param name="point">The location to convert.</param>
        /// <returns>The converted location.</returns>
        public PointF TranslateControlToImage(PointF point)
        {
            if (Image == null) throw new InvalidOperationException();
            Rectangle targetRectangle = ImageRectangleFromSizeMode();
            PointF scale = new PointF(targetRectangle.Width / (float)Image.Width, targetRectangle.Height / (float)Image.Height);
            return new PointF(point.X * scale.X + targetRectangle.Left, point.Y * scale.Y + targetRectangle.Top);
        }

        /// <summary>Translates a point from image space to control space.</summary>
        /// <param name="point">The location to convert.</param>
        /// <returns>The converted location.</returns>
        public PointF TranslateImageToControl(PointF point)
        {
            if (Image == null) throw new InvalidOperationException();
            Rectangle targetRectangle = ImageRectangleFromSizeMode();
            PointF scale = new PointF(targetRectangle.Width / (float)Image.Width, targetRectangle.Height / (float)Image.Height);
            return new PointF((point.X - targetRectangle.Left) / scale.X, (point.Y - targetRectangle.Top) / scale.Y);
        }

        public static Rectangle DeflateRect(Rectangle rect, Padding padding)
        {
            rect.X += padding.Left;
            rect.Y += padding.Top;
            rect.Width -= padding.Horizontal;
            rect.Height -= padding.Vertical;
            return rect;
        }

        public Rectangle ImageRectangleFromSizeMode()
        {
            Rectangle rectangle = DeflateRect(base.ClientRectangle, base.Padding);
            if (this.Image != null)
            {
                switch (this.SizeMode)
                {
                    case PictureBoxSizeMode.Normal:
                    case PictureBoxSizeMode.AutoSize:
                        rectangle.Size = this.Image.Size;
                        return rectangle;

                    case PictureBoxSizeMode.StretchImage:
                        return rectangle;

                    case PictureBoxSizeMode.CenterImage:
                        rectangle.X += (rectangle.Width - this.Image.Width) / 2;
                        rectangle.Y += (rectangle.Height - this.Image.Height) / 2;
                        rectangle.Size = this.Image.Size;
                        return rectangle;

                    case PictureBoxSizeMode.Zoom:
                        Size size = this.Image.Size;
                        float num = Math.Min((float)(((float)base.ClientRectangle.Width) / ((float)size.Width)), (float)(((float)base.ClientRectangle.Height) / ((float)size.Height)));
                        rectangle.Width = (int)(size.Width * num);
                        rectangle.Height = (int)(size.Height * num);
                        rectangle.X = (base.ClientRectangle.Width - rectangle.Width) / 2;
                        rectangle.Y = (base.ClientRectangle.Height - rectangle.Height) / 2;
                        return rectangle;
                }
            }
            return rectangle;
        }
	}
}