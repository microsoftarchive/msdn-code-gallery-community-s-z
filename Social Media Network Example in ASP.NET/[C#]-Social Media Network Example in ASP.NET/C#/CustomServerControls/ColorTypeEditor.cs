using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Web.UI.WebControls;
using System.Web.UI.Design.WebControls;
using System.Windows.Forms.Design;

namespace CustomServerControlsLibrary
{
	public class ColorTypeEditor : UITypeEditor
	{
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			// This editor appears when you click a drop-down arrow.
			return UITypeEditorEditStyle.DropDown;
		}

		public override object EditValue(ITypeDescriptorContext context, 
			IServiceProvider provider, object value)
		{
			IWindowsFormsEditorService srv = null;
				
			// Get the editor service from the provider,
			// which you need to perform the drop-down.
			if (provider != null)
				srv = (IWindowsFormsEditorService)
					provider.GetService(typeof(IWindowsFormsEditorService));
		
			if (srv != null)
			{
				// Create an instance of the custom Windows Forms
				// color-picking control.
				// Pass the current value of the color.
				ColorTypeEditorControl editor = 
					new ColorTypeEditorControl((System.Drawing.Color)value, 
					context.Instance as WebControl);

				// Show the control.
				srv.DropDownControl(editor);

				// Return the selected color information.
				return editor.SelectedColor;
			}
			else
			{
				// Return the current value.
				return value;
			}
		}

		
		public override bool GetPaintValueSupported(ITypeDescriptorContext context)
		{
			// This type editor will generate a color box thumbnail.
			return true;
		}

		
		public override void PaintValue(PaintValueEventArgs e)
		{
			WebControl control = e.Context.Instance as WebControl;

			// Fills the left rectangle with a color.
			e.Graphics.FillRegion(new SolidBrush(control.BackColor), new Region(e.Bounds));
		}

	}
}
