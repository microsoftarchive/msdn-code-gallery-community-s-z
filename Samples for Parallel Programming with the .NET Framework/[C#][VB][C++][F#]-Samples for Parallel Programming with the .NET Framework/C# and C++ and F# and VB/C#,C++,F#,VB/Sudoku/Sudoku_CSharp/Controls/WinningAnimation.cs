//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: WinningAnimation.cs
//
//  Description: A controls that displays an animation when a puzzle is solved.
// 
//--------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Utilities;

namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls
{
	/// <summary>End of game animation for the Puzzle Grid.</summary>
	internal class WinningAnimation : Control
	{
		/// <summary>Used for randomness in the animation.</summary>
		Random _rand;
		/// <summary>List of sprites to be rendered.</summary>
		List<ImageSprite> _sprites;
		/// <summary>Animation timer.</summary>
		Timer _timer;
		/// <summary>Used for centering text in the window.</summary>
		StringFormat _sf;
		/// <summary>PuzzleGrid in which we're contained.</summary>
		PuzzleGrid _grid;

		/// <summary>Initializes the animation.</summary>
		/// <param name="grid">The grid in which this animation should be displayed.</param>
		public WinningAnimation(PuzzleGrid grid) : base(grid, string.Empty)
		{
			_rand = new Random();
			_grid = grid;
			SetStyle(
				ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw | 
				ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
			BackColor = Color.Transparent;
			Visible = false;
		}

		/// <summary>An image to render underneath the sprites.</summary>
		private Bitmap _underImage;

		protected override void OnResize(EventArgs e)
		{
			base.OnResize (e);
			
			// NOTE: This Bitmap and Region work is done to workaround
			// the performance issues causes by using BackColor = Color.Transparent,
			// which would allow the exact functionality we want, but which is very
			// slow when the window is big or maximized.
			int width = Width, height = Height;
			if (width > 0 && height > 0)
			{
				// Update the boundaries of the control so we only draw within our own area
				int arcSize = (int)(width / 14.5);
				if (Region != null) 
				{
					Region.Dispose();
					Region = null;
				}
				using(GraphicsPath path = GraphicsHelpers.CreateRoundedRectangle(width, height, arcSize))
				{
					Region = new Region(path);
				}

				// Update the background underlying image to be rendered under
				// the sprites
				if (_underImage != null) _underImage.Dispose();
				_underImage = new Bitmap(width, height, PixelFormat.Format32bppPArgb);
				using(Graphics g = Graphics.FromImage(_underImage))
				{
					_grid.DrawToGraphics(g, _grid.ClientRectangle);
					using(SolidBrush b = new SolidBrush(Color.FromArgb(128, Color.SlateGray)))
					{
						g.FillRectangle(b, ClientRectangle);
					}
				} 
			}
		}
 
		/// <summary>Raises the VisibleChanged event and sets whether the animation is running based on the visibility.</summary>
		protected override void OnVisibleChanged(EventArgs e)
		{
			base.OnVisibleChanged (e);
			AnimationEnabled = Visible;
		}

		/// <summary>Gets or sets whether the animation is enabled.</summary>
		private bool AnimationEnabled
		{
			get { return _timer != null; }
			set
			{
				if (value)
				{
					// Reset any state from last time around
					if (_timer != null) Cleanup();
					OnResize(EventArgs.Empty);

					// Sets up string formatting so that the congratulations text is centered
					BackColor = Color.Black;
					_sf = new StringFormat();
					_sf.Alignment = StringAlignment.Center;
					_sf.LineAlignment = StringAlignment.Center;

					// Create the list to store the sprites
					_sprites = new List<ImageSprite>(_grid.State.GridSize*_grid.State.GridSize);

					// Setup the animation timer
					_timer = new Timer();
					_timer.Interval = 1000/24; // 24 fps
					_timer.Tick += new EventHandler(UpdateSpritesOnTimerTick);

					// Initialize all of the sprites
					using(Bitmap bmp = new Bitmap(_grid.ClientRectangle.Width, _grid.ClientRectangle.Height))
					{
						// Take a snapshot of the underlying puzzle grid
						using(Graphics g = Graphics.FromImage(bmp))
						{
							_grid.DrawToGraphics(g, _grid.ClientRectangle);
						}

						// Setup each individual sprite based on pulling out a section
						// of the underlying grid snapshot
						for(int i=0; i<_grid.State.GridSize; i++)
						{
							for(int j=0; j<_grid.State.GridSize; j++)
							{
								RectangleF cellRect = PuzzleGrid.GetCellRectangle(_grid.BoardRectangle, new Point(i,j));
								Bitmap smallImage = new Bitmap((int)cellRect.Width, (int)cellRect.Height, PixelFormat.Format32bppPArgb);
								using(Graphics g = Graphics.FromImage(smallImage))
								{
									g.DrawImage(bmp, 0, 0, cellRect, GraphicsUnit.Pixel);
								}
								ImageSprite s = new ImageSprite(smallImage);

								// Each sprite is setup with random velocity and angular velocity.
								// It's position is set to overlap with the underlying puzzle grid.
								const int maxSpeed = 10;
								
								// Set the location to the same location as on the grid
								Point loc = Point.Truncate(cellRect.Location);
								s.Location = PointToClient(_grid.PointToScreen(loc));
							
								// Set a random linear velocity
								do
								{
									s.Velocity=new Size(_rand.Next(maxSpeed*2)-maxSpeed, _rand.Next(maxSpeed*2)-maxSpeed);
								} 
								while(
									s.Velocity.Width >= -2 && s.Velocity.Width <= 2 &&
									s.Velocity.Height >= -2 && s.Velocity.Height <= 2);
								
								// Set a random angular velocity
								do
								{
									s.AngularVelocity=(float)_rand.Next(maxSpeed*2) - maxSpeed;
								} 
								while(s.AngularVelocity == 0);
								s.RotateAroundCenter = (_rand.Next(2) == 0);

								// Set a random flip speed (really angular velocity but around a different axis)
								do
								{
									s.FlipSpeed = _rand.Next(maxSpeed*2)-(maxSpeed);
								}
								while(s.FlipSpeed == 0);
								
								// Add the completed sprite to the list
								_sprites.Add(s);
							}
						}
					}

					_timer.Start();
				}
				else Cleanup();
			}
		}

		/// <summary>Cleans up resources.</summary>
		private void Cleanup()
		{
			if (_timer != null)
			{
				_timer.Stop();
				_timer.Dispose();
				_timer = null;
			}
			if (_underImage != null)
			{
				_underImage.Dispose();
				_underImage = null;
			}
			if (_sf != null)
			{
				_sf.Dispose();
				_sf = null;
			}
			if (_sprites != null)
			{
				foreach(IDisposable disposable in _sprites) disposable.Dispose();
				_sprites = null;
			}
		}

		/// <summary>Releases the unmanaged resources used by the Control and optionally releases the managed resources.</summary>
		/// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
		protected override void Dispose( bool disposing )
		{
			if (disposing) Cleanup();
			base.Dispose(disposing);
		}

		/// <summary>Raises the Paint event.</summary>
		/// <param name="pe">A PaintEventArgs that contains the event data.</param>
		protected override void OnPaint(PaintEventArgs pe)
		{
			// Do base painting
			base.OnPaint(pe);

			// Draw the base underlying image
			if (_underImage != null) pe.Graphics.DrawImage(_underImage, 0, 0);

			// Render all of the sprites
			if (_sprites != null && _sprites.Count > 0)
			{
				for(int i=_sprites.Count-1; i>=0; --i)
				{
					ImageSprite s = _sprites[i];
					s.Paint(pe.Graphics);
				}
			}

			// Show the congratulatory text
			string text = ResourceHelper.PuzzleSolvedCongratulations;
			if (_sf != null && text != null && text.Length > 0)
			{
				float emSize = GraphicsHelpers.GetMaximumEMSize(text,
					pe.Graphics, Font.FontFamily, Font.Style, ClientRectangle.Width, ClientRectangle.Height);
				using(Font f = new Font(Font.FontFamily, emSize))
				{
					pe.Graphics.DrawString(text, f, Brushes.Black, new RectangleF(2, 2, ClientRectangle.Width, ClientRectangle.Height), _sf);
					pe.Graphics.DrawString(text, f, Brushes.Gray, new RectangleF(-1, -1, ClientRectangle.Width, ClientRectangle.Height), _sf);
					pe.Graphics.DrawString(text, f, Brushes.Yellow, new RectangleF(0, 0, ClientRectangle.Width, ClientRectangle.Height), _sf);
				}
			}
		}

		/// <summary>Updates the position and orientation of all sprites on each timer tick.</summary>
		/// <param name="sender">The timer.</param>
		/// <param name="e">Event args.</param>
		private void UpdateSpritesOnTimerTick(object sender, EventArgs e)
		{
			if (_timer != null)
			{
				if (_sprites != null)
				{
					// Update each sprite
					for(int i=_sprites.Count-1; i>=0; --i)
					{
						// Update the sprite
						ImageSprite s = _sprites[i];
						s.Update();

						// If it's left the visible range, remove it from the list so we don't
						// need to deal with it any more
						Rectangle bounds = ClientRectangle;
						if (s.Location.X > bounds.Right + s.Image.Width || s.Location.X < -s.Image.Width ||
							s.Location.Y > bounds.Bottom + s.Image.Width || s.Location.Y < -s.Image.Width) 
						{
							_sprites.RemoveAt(i);
							s.Dispose();
						}
					}
				
					// If there are no sprites left, stop the timer; we're done.
					if (_sprites.Count == 0) _timer.Stop(); // stop but don't delete, as _timer is used as a marker

					// Refresh the window
					Invalidate();
				}
			}
		}

		/// <summary>Represents an image sprite to be displayed as part of the animation.</summary>
		internal class ImageSprite : IDisposable
		{
			/// <summary>The location of the sprite.</summary>
			Point _location;
			/// <summary>The rotational angle of the sprite.</summary>
			float _angle;
			/// <summary>The current flipped position of the sprite (angular velocity around a different axis).</summary>
			float _flipPosition;

			/// <summary>The linear velocity of the sprite.</summary>
			Size _velocity;
			/// <summary>The angular velocity of the sprite.</summary>
			float _angularVelocity;
			/// <summary>The speed at which the sprite flips over itself.</summary>
			float _flipSpeed;
			/// <summary>Whether to rotate around the center or corner.</summary>
			bool _rotateAroundCenter;

			/// <summary>The image that is the sprite.</summary>
			private Bitmap _bmp;

			/// <summary>Initializes the sprite.</summary>
			/// <param name="bmp">The sprite's image.</param>
			public ImageSprite(Bitmap bmp)
			{
				if (bmp == null) throw new ArgumentNullException("bmp");
				_bmp = bmp;
			}

			/// <summary>Releases resources used by the sprite.</summary>
			public void Dispose()
			{
				if (_bmp != null)
				{
					_bmp.Dispose();
					_bmp = null;
				}
			}

			/// <summary>Gets the image that is the sprite.</summary>
			public Bitmap Image { get { return _bmp; } }
			/// <summary>Gets or sets the location of the sprite.</summary>
			public Point Location { get { return _location; } set { _location=value; } }
			/// <summary>Gets or sets the flip speed of the sprite.</summary>
			public float FlipSpeed { get { return _flipSpeed; } set { _flipSpeed=value; } }
			/// <summary>Gets or sets the linear velocity of the sprite.</summary>
			public Size Velocity { get { return _velocity; } set { _velocity = value; } }
			/// <summary>Gets or sets the angular velocity of the sprite.</summary>
			public float AngularVelocity { get { return _angularVelocity; } set { _angularVelocity=value; } }
			/// <summary>Sets whether to rotate around the center versus around a corner.</summary>
			public bool RotateAroundCenter { set { _rotateAroundCenter = value; } }

			/// <summary>Renders the sprite.</summary>
			/// <param name="graphics">The graphics object onto which the sprite should be rendered.</param>
			public void Paint(Graphics graphics)
			{
				// Rotate and translate the graphics object appropriately
				using(Matrix mx = new Matrix())
				{
					GraphicsState gs = graphics.Save();
					if (_rotateAroundCenter) mx.Translate(-_bmp.Width/2, -_bmp.Height/2, MatrixOrder.Append); // to rotate around the center rather than corner
					mx.Rotate(_angle, MatrixOrder.Append);
					if (_rotateAroundCenter) mx.Translate(_bmp.Width/2, _bmp.Height/2, MatrixOrder.Append); // to rotate around the center rather than corner
					mx.Translate(_location.X, _location.Y, MatrixOrder.Append);
					graphics.Transform = mx;

					// Draw the image
					float flipMult = ((float)Math.Cos(_flipPosition*Math.PI/180.0));
					if (flipMult > 0.001 || flipMult < -0.001) // avoids an OOM exception from GDI+
					{
						graphics.DrawImage(_bmp, 
							new RectangleF(0, 1-Math.Abs(flipMult), _bmp.Width, _bmp.Height*flipMult), 
							new RectangleF(0, 0, _bmp.Width, _bmp.Height), 
							GraphicsUnit.Pixel);
					}
			
					// Restore the graphics object
					graphics.Restore(gs);
				}
			}

			/// <summary>Updates the position and orientation of the sprite.</summary>
			public void Update()
			{
				// Update the location based on the lineary velocity
				_location = new Point(_location.X + _velocity.Width, _location.Y + _velocity.Height);
				
				// Update the flipped position based on the flip speed
				_flipPosition += _flipSpeed;
				if (_flipPosition >= 360) _flipPosition -= 360;
				else if (_flipPosition < 0) _flipPosition += 360;

				// Update the rotational angle based on the rotational velocity
				_angle += _angularVelocity;
				if (_angle >= 360) _angle -= 360;
				else if (_angle < 0) _angle += 360;
			}
		}
	}
}