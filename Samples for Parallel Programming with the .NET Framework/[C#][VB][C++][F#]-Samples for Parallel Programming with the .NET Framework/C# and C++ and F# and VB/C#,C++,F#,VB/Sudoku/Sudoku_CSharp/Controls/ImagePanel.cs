//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: ImagePanel.cs
//
//  Description: A panel used to render a double-buffered image.
// 
//--------------------------------------------------------------------------

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls
{
	/// <summary>Double-buffered panel that displays a stretched image.</summary>
	internal class ImagePanel : NoFlickerPanel
	{
		/// <summary>Initializes the panel.</summary>
		public ImagePanel(){}

		/// <summary>The image to be rendered.</summary>
		private Image _img;

		/// <summary>Gets or sets the image to be rendered.</summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public Image Image { get { return _img; } set { _img = value; } }

		/// <summary>Paints the image.</summary>
		/// <param name="e">Paint event args.</param>
		protected override void OnPaint(PaintEventArgs e)
		{
			if (_img != null) 
			{
				e.Graphics.DrawImage(_img, 0, 0, Width, Height);
			}
			base.OnPaint(e);
		}
	}
}