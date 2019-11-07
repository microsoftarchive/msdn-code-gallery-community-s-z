using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Web.UI.WebControls;

namespace CustomServerControlsLibrary
{
	/// <summary>
	/// A custom UI editor for colors.
	/// </summary>
	[ToolboxItem(false)]
	public class ColorTypeEditorControl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel pnlSample;
		private System.Windows.Forms.TrackBar trkRed;
		private System.Windows.Forms.TrackBar trkGreen;
		private System.Windows.Forms.TrackBar trkBlue;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TrackBar trkAlpha;
		private System.Windows.Forms.Label txtSample;
		private System.Windows.Forms.Button btnPicker;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;


		//Variable keeping the current color selection. It is initialized to black.
		private Color _color = Color.Black;
		private WebControl _component;

		/// <summary>
		/// Constructor of the user control.
		/// </summary>
		/// <param name="colorToEdit">The color which is going to be edited.</param>
		public ColorTypeEditorControl(Color colorToEdit, WebControl component)
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			_component = component;

			//Initialize controls.
			_color = colorToEdit;
			trkAlpha.Value = _color.A;
			trkBlue.Value = _color.B;
			trkGreen.Value = _color.G;
			trkRed.Value = _color.R;
			pnlSample.BackColor = _color;

			//Attach handlers to controls.
			trkAlpha.ValueChanged += new EventHandler(OnColorChanged);
			trkBlue.ValueChanged += new EventHandler(OnColorChanged);
			trkGreen.ValueChanged += new EventHandler(OnColorChanged);
			trkRed.ValueChanged += new EventHandler(OnColorChanged);
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.trkBlue = new System.Windows.Forms.TrackBar();
			this.trkAlpha = new System.Windows.Forms.TrackBar();
			this.trkGreen = new System.Windows.Forms.TrackBar();
			this.pnlSample = new System.Windows.Forms.Panel();
			this.txtSample = new System.Windows.Forms.Label();
			this.btnPicker = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.trkRed = new System.Windows.Forms.TrackBar();
			((System.ComponentModel.ISupportInitialize)(this.trkBlue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trkAlpha)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trkGreen)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trkRed)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Red:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 80);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 16);
			this.label2.TabIndex = 0;
			this.label2.Text = "Green:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 112);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 16);
			this.label3.TabIndex = 0;
			this.label3.Text = "Blue:";
			// 
			// trkBlue
			// 
			this.trkBlue.AutoSize = false;
			this.trkBlue.Location = new System.Drawing.Point(52, 108);
			this.trkBlue.Maximum = 255;
			this.trkBlue.Name = "trkBlue";
			this.trkBlue.Size = new System.Drawing.Size(144, 45);
			this.trkBlue.SmallChange = 10;
			this.trkBlue.TabIndex = 3;
			// 
			// trkAlpha
			// 
			this.trkAlpha.AutoSize = false;
			this.trkAlpha.Location = new System.Drawing.Point(52, 12);
			this.trkAlpha.Maximum = 255;
			this.trkAlpha.Name = "trkAlpha";
			this.trkAlpha.Size = new System.Drawing.Size(144, 45);
			this.trkAlpha.SmallChange = 10;
			this.trkAlpha.TabIndex = 3;
			// 
			// trkGreen
			// 
			this.trkGreen.AutoSize = false;
			this.trkGreen.Location = new System.Drawing.Point(52, 76);
			this.trkGreen.Maximum = 255;
			this.trkGreen.Name = "trkGreen";
			this.trkGreen.Size = new System.Drawing.Size(144, 45);
			this.trkGreen.SmallChange = 10;
			this.trkGreen.TabIndex = 3;
			// 
			// pnlSample
			// 
			this.pnlSample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlSample.Location = new System.Drawing.Point(8, 184);
			this.pnlSample.Name = "pnlSample";
			this.pnlSample.Size = new System.Drawing.Size(188, 16);
			this.pnlSample.TabIndex = 2;
			// 
			// txtSample
			// 
			this.txtSample.Location = new System.Drawing.Point(8, 164);
			this.txtSample.Name = "txtSample";
			this.txtSample.Size = new System.Drawing.Size(76, 16);
			this.txtSample.TabIndex = 1;
			this.txtSample.Text = "Sample Color:";
			// 
			// btnPicker
			// 
			this.btnPicker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPicker.Location = new System.Drawing.Point(148, 160);
			this.btnPicker.Name = "btnPicker";
			this.btnPicker.Size = new System.Drawing.Size(48, 20);
			this.btnPicker.TabIndex = 4;
			this.btnPicker.Text = "Picker";
			this.btnPicker.Click += new System.EventHandler(this.btnPicker_Click);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(40, 16);
			this.label5.TabIndex = 0;
			this.label5.Text = "Alpha:";
			// 
			// trkRed
			// 
			this.trkRed.AutoSize = false;
			this.trkRed.Location = new System.Drawing.Point(52, 44);
			this.trkRed.Maximum = 255;
			this.trkRed.Name = "trkRed";
			this.trkRed.Size = new System.Drawing.Size(144, 45);
			this.trkRed.SmallChange = 10;
			this.trkRed.TabIndex = 3;
			// 
			// ColorTypeEditorControl
			// 
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(153)), ((System.Byte)(153)), ((System.Byte)(255)));
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnPicker,
																		  this.txtSample,
																		  this.trkBlue,
																		  this.trkGreen,
																		  this.trkRed,
																		  this.pnlSample,
																		  this.label3,
																		  this.label2,
																		  this.label1,
																		  this.label5,
																		  this.trkAlpha});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Name = "ColorTypeEditorControl";
			this.Size = new System.Drawing.Size(204, 208);
			((System.ComponentModel.ISupportInitialize)(this.trkBlue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trkAlpha)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trkGreen)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trkRed)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void OnColorChanged(object sender, EventArgs e)
		{
			_color = Color.FromArgb(trkAlpha.Value, trkRed.Value, trkGreen.Value, trkBlue.Value);
			pnlSample.BackColor = _color;
			//_component.BackColor = _color;	//This won't work!
			//PropertyDescriptorCollection col = TypeDescriptor.GetProperties(_component);
			//col["BackColor"].SetValue(_component, _color);
			//Resumed version of the previous 2 lines
			TypeDescriptor.GetProperties(_component)["BackColor"].SetValue(_component, _color);
		}

		private void btnPicker_Click(object sender, System.EventArgs e)
		{
//			ColorDialog dlg = new ColorDialog();
//			dlg.Color = _color;
//			if (dlg.ShowDialog() == DialogResult.OK) _color = dlg.Color;
		
			TypeConverter tc = TypeDescriptor.GetConverter(_color);

			string res = System.Web.UI.Design.ColorBuilder.BuildColor(
				_component, this, tc.ConvertToString(_color));
			
			if (res != string.Empty && res != null)
				_color = (Color)tc.ConvertFromString(res);
		}

		internal Color SelectedColor
		{
			get { return _color; }
		}
	}
}