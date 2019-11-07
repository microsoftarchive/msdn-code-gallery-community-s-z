//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: GraphicsHelpers.cs
//
//  Description: Graphics utility class.
// 
//--------------------------------------------------------------------------

using System.Drawing;
using System.Drawing.Drawing2D;

namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Utilities
{
	/// <summary>Graphics utility class.</summary>
	internal static class GraphicsHelpers
	{
		/// <summary>Creates a GraphicsPath that represents a rounded rectangle.</summary>
		/// <param name="width">The width of the rectangle.</param>
		/// <param name="height">The height of the rectangle.</param>
		/// <param name="diameter">The diameter of the rounded corners.</param>
		/// <returns>The rounded rectangle path.</returns>
		public static GraphicsPath CreateRoundedRectangle(
			int width, int height, int diameter)
		{
			GraphicsPath path = new GraphicsPath();
			
			Rectangle upperLeft = new Rectangle(0, 0, diameter, diameter);
			Rectangle upperRight = new Rectangle(width - diameter, 0, diameter, diameter);
			Rectangle lowerRight = new Rectangle(width - diameter, height - diameter, diameter, diameter);
			Rectangle lowerLeft = new Rectangle(0, height - diameter, diameter, diameter);

			path.StartFigure();
			path.AddArc(upperLeft, 180, 90);
			path.AddArc(upperRight, 270, 90);
			path.AddArc(lowerRight, 0, 90);
			path.AddArc(lowerLeft, 90, 90);
			path.CloseFigure();

			return path;
		}
		
		/// <summary>Determines the maximum font em size to be used within a particular width and height area.</summary>
		/// <param name="text">The text for which we need to know the maximum size.</param>
		/// <param name="graphics">The graphics to use to analyze font size.</param>
		/// <param name="fontFamily">The FontFamily to size.</param>
		/// <param name="fontStyle">The FontStyle to size.</param>
		/// <param name="width">The width of the area to contain the drawn character.</param>
		/// <param name="height">The height of the area to contain the drawn character.</param>
		/// <returns></returns>
		public static float GetMaximumEMSize(string text,
			Graphics graphics, FontFamily fontFamily, FontStyle fontStyle, float width, float height)
		{
			// Binary search for the best size with at most MAX_ERROR error
			const float MAX_ERROR = .25f;
			float curMin = 1.0f, curMax = width;
			float emSize = ((curMax - curMin) / 2f) + curMin;
			while(curMax - curMin > MAX_ERROR && curMin >= 1)
			{
				using (Font f = new Font(fontFamily, emSize, fontStyle))
				{
					SizeF size = graphics.MeasureString(text, f);
					bool textFits = size.Width < width && size.Height < height;
					if (textFits && emSize > curMin) curMin = emSize;
					else if (!textFits && emSize < curMax) curMax = emSize;
				}
				emSize = ((curMax - curMin) / 2f) + curMin;
			}
			return curMin; // curMin is the size last known to fit completely, so we use that
		}
	}
}