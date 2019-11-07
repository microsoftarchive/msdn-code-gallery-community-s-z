//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: TextStatefulButton.cs
//
//  Description: Custom button used for all buttons in Sudoku.
// 
//--------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Utilities;

namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls
{
	/// <summary>A custom button rendered with multiple images and text.</summary>
	[ToolboxBitmap(typeof(Button))]
	internal sealed class TextStatefulButton : Control
	{
		/// <summary>Initializes the button.</summary>
		public TextStatefulButton()
		{
			SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer |
				ControlStyles.UserPaint | ControlStyles.ResizeRedraw |
				ControlStyles.SupportsTransparentBackColor | ControlStyles.CacheText, true);
			SetStyle(ControlStyles.StandardDoubleClick | ControlStyles.StandardClick, false);
			SetStyle(ControlStyles.Selectable, false);
			BackColor = Color.Transparent;

			_centeredFormat = new StringFormat(); //StringFormatFlags.FitBlackBox);
			_centeredFormat.LineAlignment = StringAlignment.Center;
			_centeredFormat.Alignment = StringAlignment.Center;
		}

		/// <summary>Image used as the shadow of the control.</summary>
		private Image _shadowImage;
		/// <summary>Image used to represent the pressed/checked state of the control.</summary>
		private Image _checkedImage;
		/// <summary>Image used to represent the unpressed/unchecked state of the control.</summary>
		private Image _uncheckedImage;
		/// <summary>Image used to represent the highlighted state of the control.</summary>
		private Image _highlightedImage;
		/// <summary>Image used to represent the icon/overlay for the control.</summary>
		private Image _overlayImage;

		/// <summary>Whether the control can be checked.</summary>
		private bool _allowChecking;
		/// <summary>Whether the control can be unchecked by a user.</summary>
		private bool _allowNonprogrammaticUnchecking;
		/// <summary>Whether the control is checked.</summary>
		private bool _checked;
		/// <summary>Whether the control is currently highlighted.</summary>
		private bool _highlighted;
		/// <summary>Whether the mouse is currently down.</summary>
		private bool _mouseDown;

		/// <summary>Used to center the text.</summary>
		private StringFormat _centeredFormat;
		/// <summary>The current font for rendering.</summary>
		private Font _font;
		/// <summary>Whether the font should autosize to fit within the button.</summary>
		private bool _autosizeFont = true;
		/// <summary>Whether the placement of text should be adjusted based on whether the button is checked.</summary>
		private bool _adjustTextPlacement = true;

		/// <summary>Sets the image used as the shadow of the control.</summary>
		public Image ShadowImage { set { _shadowImage = value; } }
		/// <summary>Sets the image used to represent the pressed/checked state of the control.</summary>
		public Image CheckedImage { set { _checkedImage = value; } }
		/// <summary>Sets the image used to represent the unpressed/unchecked state of the control.</summary>
		public Image UncheckedImage { set { _uncheckedImage = value; } }
		/// <summary>Sets the image used to represent the highlighted state of the control.</summary>
		public Image HighlightedImage { set { _highlightedImage = value; } }
		/// <summary>Sets the image used to represent the icon/overlay for the control.</summary>
		public Image OverlayImage { set { _overlayImage = value; } }

		/// <summary>Gets whether the control can be checked.</summary>
		public bool AllowChecking { get { return _allowChecking; } set { _allowChecking = value; } }
		/// <summary>Gets whether the control can be unchecked by a user.</summary>
		public bool AllowNonprogrammaticUnchecking {  get { return _allowNonprogrammaticUnchecking; } set { _allowNonprogrammaticUnchecking = value; } }

		/// <summary>Gets whether the control is currently highlighted.</summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		private bool Highlighted { get { return _highlighted; } }

		/// <summary>Gets wether the mouse is currently down.</summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		private bool MouseIsDown { get { return _mouseDown; } }

		/// <summary>Gets or sets whether the control is checked.</summary>
		public bool Checked 
		{ 
			get { return _allowChecking ? _checked : false; } 
			set 
			{
				if (_allowChecking && _checked != value)
				{
					CancelEventArgs e = new CancelEventArgs(false);
					OnBeforeCheckedChanged(e);
					if (!e.Cancel)
					{
						_checked = value; 
						Invalidate();
						OnCheckedChanged();
					}
				}
			}
		}

		/// <summary>Gets or sets whether the control is focusable.</summary>
		public bool Focusable 
		{ 
			get { return GetStyle(ControlStyles.Selectable); } 
			set { SetStyle(ControlStyles.Selectable, value); }
		}

		/// <summary>Gets or sets whether the control supports auto-font resize.</summary>
		public bool AutosizeFont { get { return _autosizeFont; } set { _autosizeFont = value; } }

		/// <summary>Gets or sets whether the font size should be adjusted based on whether the control is checked.</summary>
		public bool AdjustTextPlacementWhenChecked { get { return _adjustTextPlacement; } set { _adjustTextPlacement = value; } }

		/// <summary>Event raised before the control's checked state changes.</summary>
		public event CancelEventHandler BeforeCheckedChanged;
		/// <summary>Event raised after the control's checked state changes.</summary>
		public event EventHandler CheckedChanged;

		/// <summary>Cleans up.</summary>
		/// <param name="disposing">Whether this is the result of a call to IDisposable.Dispose.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (_centeredFormat != null)
				{
					_centeredFormat.Dispose();
					_centeredFormat = null;
				}
				if (_font != null)
				{
					_font.Dispose();
					_font = null;
				}
			}
			base.Dispose (disposing);
		}

		/// <summary>Handles the control's resize.</summary>
		protected override void OnResize(EventArgs e)
		{
			ClearFont();
			base.OnResize(e);
		}

		/// <summary>Handles the control's layout.</summary>
		protected override void OnLayout(LayoutEventArgs levent)
		{
			ClearFont();
			base.OnLayout (levent);
		}

		/// <summary>Handles the control's font change.</summary>
		protected override void OnFontChanged(EventArgs e)
		{
			ClearFont();
			base.OnFontChanged (e);
		}

		/// <summary>Handles the control's checked change.</summary>
		private void OnCheckedChanged()
		{
			ClearFont();
			EventHandler e = CheckedChanged;
			if (e != null) e(this, EventArgs.Empty);
		}

		/// <summary>Raises the BeforeCheckedChanged event.</summary>
		private void OnBeforeCheckedChanged(CancelEventArgs e)
		{
			CancelEventHandler handler = BeforeCheckedChanged;
			if (handler != null) handler(this, e);
		}

		/// <summary>Handles the mouse enter event.</summary>
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter (e);
			_highlighted = true;
			Invalidate();
		}

		/// <summary>Handles the mouse leave event.</summary>
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave (e);
			_highlighted = false;
			Invalidate();
		}

		/// <summary>Handles the mouse down event.</summary>
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown (e);
			if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
			{
				_highlighted = false;
				_mouseDown = true;
				if (_allowNonprogrammaticUnchecking || !Checked) Checked = !Checked;
				if (Focusable) Select();
				Invalidate();
			}
		}

		/// <summary>Handles the mouse up event.</summary>
		protected override void OnMouseUp(MouseEventArgs e)
		{
			if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
			{
				_mouseDown = false;
				if (!AllowChecking)
				{
					Point mousePosition = Control.MousePosition;
					if (ClientRectangle.Contains(PointToClient(mousePosition)))
					{
						_highlighted = true;
					}
				}
				Invalidate();
				if (ClientRectangle.Contains(PointToClient(MousePosition))) OnClick(e);
			}
			base.OnMouseUp (e);
		}

		/// <summary>Clears the currently cached font.</summary>
		private void ClearFont()
		{
			if (_font != null)
			{
				Font f = _font;
				_font = null;
				f.Dispose();
			}
		}

		/// <summary>Gets the font to use for rendering.</summary>
		/// <returns>The font to use for rendering.</returns>
		private Font GetFontForText()
		{
			if (!_autosizeFont) return base.Font;
			if (_font == null) 
			{
				Font baseFont = base.Font;
				if (Text == null || Text.Length == 0) return baseFont;
				using(Graphics g = CreateGraphics())
				{
					int width = Width * 9 / 10;
					int height = Height * 9 / 10;
					_font = new Font(baseFont.FontFamily, 
						GraphicsHelpers.GetMaximumEMSize(Text, g, baseFont.FontFamily, baseFont.Style, width, height), baseFont.Style);
				}
			}
			return _font;
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				OnClick(e);
			}
			else base.OnKeyDown (e);
		}

		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus (e);
			Invalidate();
		}

		protected override void OnLostFocus(EventArgs e)
		{
			base.OnLostFocus (e);
			Invalidate();
		}

		/// <summary>Paints the button.</summary>
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			// Setup the graphics object
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
			e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

			// Determine the image to be drawn based on the current state
			Image img = _uncheckedImage;
			if (Enabled && Visible)
			{
				if (Checked || _mouseDown) img =  _checkedImage;
				else if (_highlighted || this.Focused) img = _highlightedImage;
			}
			
			if (img != null)
			{
				using(ImageAttributes attrs = new ImageAttributes())
				{
					// If the control is disabled, use alpha blending
					ColorMatrix m = new ColorMatrix();
					m.Matrix33 = Enabled && Visible ? 1f : .5f;
					attrs.SetColorMatrix(m);

					int width = ClientRectangle.Width;
					int height = ClientRectangle.Height;

					// Draw the shadow if appropriate
					if (Enabled && Visible && !Checked && !MouseIsDown && _shadowImage != null)
					{
						e.Graphics.DrawImage(_shadowImage, new Rectangle(1, 1, width, height),
							0, 0, _shadowImage.Width, _shadowImage.Height, GraphicsUnit.Pixel, attrs);
					}
					width -= 2;
					height -= 2;

					// Draw the image
					e.Graphics.DrawImage(img, new Rectangle(0, 0, width, height),
						0, 0, img.Width, img.Height, GraphicsUnit.Pixel, attrs);

					// Draw the icon if appropriate
					if (_overlayImage != null)
					{
						Rectangle targetRect = new Rectangle(0, 0, width, height);
						targetRect.Inflate(-width/8, -height/8);
						if (Enabled && Visible && (Checked || _mouseDown))
						{
							targetRect.Offset((int)Math.Ceiling(ClientRectangle.Height/20f), (int)Math.Ceiling(ClientRectangle.Height/20f));
							targetRect.Inflate((int)Math.Ceiling(-ClientRectangle.Height/30f), (int)Math.Ceiling(-ClientRectangle.Height/30f));
						}
						e.Graphics.DrawImage(_overlayImage, targetRect,
							0, 0, _overlayImage.Width, _overlayImage.Height, GraphicsUnit.Pixel, attrs);
					}

					// If there's text to display
					if (Text != null && Text.Length > 0)
					{
						RectangleF bounds = new RectangleF(0, 0, width, height);
				
						// Update the bounds if necessary
						if (Enabled && Visible && AdjustTextPlacementWhenChecked && (Checked || MouseIsDown))
						{
							bounds.Inflate(-ClientRectangle.Height/6, -ClientRectangle.Height/6);
							bounds.Offset(ClientRectangle.Height/15, ClientRectangle.Height/15);
						}

						// Get the color to use for the text, alpha blended if the control is disabled
						Color c = ForeColor;
						if (!Enabled || !Visible) c = Color.FromArgb(128, c);

						// Draw it
						using(Brush b = new SolidBrush(c)) // Can cache this for improved performance
						{
							e.Graphics.DrawString(Text, GetFontForText(), b, bounds, _centeredFormat);
						}
					}
				}
			}
		}
	}
}