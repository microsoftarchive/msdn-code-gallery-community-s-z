//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: NoFlickerPanel.cs
//
//  Description: A double-buffering and redraw-on-resizing panel.
// 
//--------------------------------------------------------------------------

using System.Drawing;
using System.Windows.Forms;

namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls
{
	/// <summary>A derived panel that uses double buffering to prevent flicker.</summary>
	[ToolboxBitmap(typeof(Panel))]
	internal class NoFlickerPanel : Panel
	{
		/// <summary>Initializes the panel.</summary>
		public NoFlickerPanel()
		{
			SetStyle(
				ControlStyles.DoubleBuffer | 
				ControlStyles.AllPaintingInWmPaint | 
				ControlStyles.UserPaint | 
				ControlStyles.ResizeRedraw | 
				ControlStyles.SupportsTransparentBackColor, true);
		}
	}
}