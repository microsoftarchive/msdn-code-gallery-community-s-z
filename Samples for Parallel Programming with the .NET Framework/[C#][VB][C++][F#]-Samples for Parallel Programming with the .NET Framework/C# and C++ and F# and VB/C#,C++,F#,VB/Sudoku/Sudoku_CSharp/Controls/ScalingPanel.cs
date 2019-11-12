//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: ScalingPanel.cs
//
//  Description: A panel that maintains the relative size and position of its children.
// 
//--------------------------------------------------------------------------

using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls
{
	/// <summary>Resizes contained controls based on maintaining original aspect ratios.</summary>
	internal class ScalingPanel : NoFlickerPanel
	{
		/// <summary>Initializes the panel.</summary>
		public ScalingPanel(){}

		/// <summary>The initial bounds of the panel.</summary>
		private Rectangle _initialBounds;

		/// <summary>Table of controls and their respective original bounds.</summary>
        private Dictionary<Control, Rectangle> _controlBounds;

		/// <summary>Whether the panel has been initialized.</summary>
		private bool _initialized;

		/// <summary>Initializes the panel based on the current controls in it.</summary>
		public void ConfigureByContainedControls()
		{
			_initialBounds = Bounds;
			_controlBounds = new Dictionary<Control,Rectangle>();
			foreach(Control c in this.Controls)
			{
				_controlBounds.Add(c, c.Bounds);
			}
			_initialized = true;
		}

		/// <summary>Rescales all contained controls.</summary>
		/// <param name="levent">Event arguments.</param>
		protected override void OnLayout(LayoutEventArgs levent)
		{
			if (_initialized && Width > 0 && Height > 0 && levent.AffectedControl == this)
			{
				// Maintain original aspect ratio
				int newWidth = Width;
				int tmp = (int)(_initialBounds.Width / (double)_initialBounds.Height * Height);
				if (tmp < newWidth) newWidth = tmp;

				int newHeight = Height;
				tmp = (int)(_initialBounds.Height / (double)_initialBounds.Width * newWidth);
				if (tmp < newHeight) newHeight = tmp;

				// Keep track of max and min boundaries
				int minX=int.MaxValue, minY=int.MaxValue, maxX=-1, maxY=-1;

				// Move and resize all controls
				foreach(Control c in this.Controls)
				{
					Rectangle rect = (Rectangle)_controlBounds[c];

					// Determine initial best guess at size
					int x = (int)(rect.X / (double)_initialBounds.Width * newWidth);
					int y = (int)(rect.Y / (double)_initialBounds.Height * newHeight);
					int width = (int)(rect.Width / (double)_initialBounds.Width * newWidth);
					int height = (int)(rect.Height / (double)_initialBounds.Height * newHeight);

					// Set the new bounds
					Rectangle newBounds = new Rectangle(x, y, width, height);
					if (newBounds != c.Bounds) c.Bounds = newBounds;

					// Keep track of max and min boundaries
					if (c.Left < minX) minX = c.Left;
					if (c.Top < minY) minY = c.Top;
					if (c.Right  > maxX) maxX = c.Right;
					if (c.Bottom > maxY) maxY = c.Bottom;
				}

				// Center all controls
				int moveX = (Width - (maxX - minX + 1)) / 2;
				int moveY = (Height - (maxY - minY + 1)) / 2;

				if (moveX > 0 || moveY > 0)
				{
					foreach(Control c in this.Controls) 
					{
						c.Location = c.Location + new Size(moveX - minX, moveY - minY);
					}
				}
			}

			// Do base layout
			base.OnLayout (levent);
		}
	}
}