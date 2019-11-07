//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: EditSettings.cs
//
//--------------------------------------------------------------------------

using System.Windows.Forms;

namespace ParallelMorph
{
	/// <summary>Used to edit morph settings.</summary>
	public class EditSettings : Form
	{
		private System.Windows.Forms.PropertyGrid pgSettings;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public EditSettings()
		{
			InitializeComponent();
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.pgSettings = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // pgSettings
            // 
            this.pgSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgSettings.LineColor = System.Drawing.SystemColors.ScrollBar;
            this.pgSettings.Location = new System.Drawing.Point(0, 0);
            this.pgSettings.Name = "pgSettings";
            this.pgSettings.Size = new System.Drawing.Size(300, 237);
            this.pgSettings.TabIndex = 0;
            this.pgSettings.ToolbarVisible = false;
            // 
            // EditSettings
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(300, 237);
            this.Controls.Add(this.pgSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "EditSettings";
            this.Opacity = 0.97D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Settings";
            this.ResumeLayout(false);

		}
		#endregion

		// ==========================================================================================
		// ==========================================================================================
		// ==========================================================================================

		/// <summary>Gets or sets the settings being edited.</summary>
		public UiSettings Settings
		{
			get { return (UiSettings)pgSettings.SelectedObject; }
			set { pgSettings.SelectedObject = value; }
		}
	}
}
