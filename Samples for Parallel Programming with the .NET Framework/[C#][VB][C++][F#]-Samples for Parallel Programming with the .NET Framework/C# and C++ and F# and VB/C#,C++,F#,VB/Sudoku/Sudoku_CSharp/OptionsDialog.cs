//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: OptionsDialog.cs
//
//  Description: Dialog for user configuration options.
// 
//--------------------------------------------------------------------------

using System;

namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku
{
	/// <summary>Presents configuration options to the user.</summary>
	internal class OptionsDialog : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox chkShowIncorrectCells;
		private System.Windows.Forms.CheckBox chkHighlightEasyCell;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.CheckBox chkCreateWithSymmetry;
		private System.Windows.Forms.CheckBox chkPromptOnDelete;
		private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox chkParallelPuzzleGeneration;
        private System.Windows.Forms.CheckBox chkSpeculativeGeneration;
		private System.ComponentModel.Container components = null;

		/// <summary>Initializes the OptionsDialog.</summary>
		public OptionsDialog()
		{
			InitializeComponent();
		}

		/// <summary>Cleans up.</summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsDialog));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkHighlightEasyCell = new System.Windows.Forms.CheckBox();
            this.chkShowIncorrectCells = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkParallelPuzzleGeneration = new System.Windows.Forms.CheckBox();
            this.chkCreateWithSymmetry = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkPromptOnDelete = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.chkSpeculativeGeneration = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.chkHighlightEasyCell);
            this.groupBox1.Controls.Add(this.chkShowIncorrectCells);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // chkHighlightEasyCell
            // 
            this.chkHighlightEasyCell.AccessibleRole = System.Windows.Forms.AccessibleRole.HotkeyField;
            resources.ApplyResources(this.chkHighlightEasyCell, "chkHighlightEasyCell");
            this.chkHighlightEasyCell.Name = "chkHighlightEasyCell";
            // 
            // chkShowIncorrectCells
            // 
            resources.ApplyResources(this.chkShowIncorrectCells, "chkShowIncorrectCells");
            this.chkShowIncorrectCells.AccessibleRole = System.Windows.Forms.AccessibleRole.HotkeyField;
            this.chkShowIncorrectCells.Name = "chkShowIncorrectCells";
            this.chkShowIncorrectCells.CheckedChanged += new System.EventHandler(this.chkShowIncorrectCells_CheckedChanged);
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.chkSpeculativeGeneration);
            this.groupBox2.Controls.Add(this.chkParallelPuzzleGeneration);
            this.groupBox2.Controls.Add(this.chkCreateWithSymmetry);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // chkParallelPuzzleGeneration
            // 
            this.chkParallelPuzzleGeneration.AccessibleRole = System.Windows.Forms.AccessibleRole.HotkeyField;
            resources.ApplyResources(this.chkParallelPuzzleGeneration, "chkParallelPuzzleGeneration");
            this.chkParallelPuzzleGeneration.Name = "chkParallelPuzzleGeneration";
            // 
            // chkCreateWithSymmetry
            // 
            this.chkCreateWithSymmetry.AccessibleRole = System.Windows.Forms.AccessibleRole.HotkeyField;
            resources.ApplyResources(this.chkCreateWithSymmetry, "chkCreateWithSymmetry");
            this.chkCreateWithSymmetry.Name = "chkCreateWithSymmetry";
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Controls.Add(this.chkPromptOnDelete);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // chkPromptOnDelete
            // 
            this.chkPromptOnDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.HotkeyField;
            resources.ApplyResources(this.chkPromptOnDelete, "chkPromptOnDelete");
            this.chkPromptOnDelete.Name = "chkPromptOnDelete";
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Name = "btnOK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // chkSpeculativeGeneration
            // 
            this.chkSpeculativeGeneration.AccessibleRole = System.Windows.Forms.AccessibleRole.HotkeyField;
            resources.ApplyResources(this.chkSpeculativeGeneration, "chkSpeculativeGeneration");
            this.chkSpeculativeGeneration.Name = "chkSpeculativeGeneration";
            // 
            // OptionsDialog
            // 
            this.AcceptButton = this.btnOK;
            resources.ApplyResources(this, "$this");
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsDialog";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>The configuration options for this dialog.</summary>
		private ConfigurationOptions _options = new ConfigurationOptions();

		/// <summary>Gets the configuration options.</summary>
		public ConfigurationOptions ConfiguredOptions { get { return _options; } }

		/// <summary>Sets up the form based on the current configuration options.</summary>
		protected override void OnVisibleChanged(EventArgs e)
		{
			if (Visible)
			{
				chkHighlightEasyCell.Checked = _options.SuggestEasyCells;
				chkShowIncorrectCells.Checked = _options.ShowIncorrectCells;
				chkCreateWithSymmetry.Checked = _options.CreatePuzzlesWithSymmetry;
				chkPromptOnDelete.Checked = _options.PromptOnPuzzleDelete;
                chkParallelPuzzleGeneration.Checked = _options.ParallelPuzzleGeneration;
                chkSpeculativeGeneration.Checked = _options.SpeculativePuzzleGeneration;
				ConfiguredEnabledCheckboxes();

				btnOK.Select();
			}
			base.OnVisibleChanged (e);
		}

		/// <summary>Sets up the configuration options based on the status of the form.</summary>
		private void btnOK_Click(object sender, System.EventArgs e)
		{
			_options.SuggestEasyCells = chkHighlightEasyCell.Checked;
			_options.ShowIncorrectCells = chkShowIncorrectCells.Checked;
			_options.CreatePuzzlesWithSymmetry = chkCreateWithSymmetry.Checked;
			_options.PromptOnPuzzleDelete = chkPromptOnDelete.Checked;
            _options.ParallelPuzzleGeneration = chkParallelPuzzleGeneration.Checked;
            _options.SpeculativePuzzleGeneration = chkSpeculativeGeneration.Checked;
		}

		/// <summary>Enables or disables the highlight easy cells option based on the show incorrect values option.</summary>
		private void chkShowIncorrectCells_CheckedChanged(object sender, System.EventArgs e)
		{
			ConfiguredEnabledCheckboxes();
		}

		/// <summary>Configures chkHighlightEasyCell based on whether chkShowIncorrectCells is checked.</summary>
		private void ConfiguredEnabledCheckboxes()
		{
			if (chkShowIncorrectCells.Checked)
			{
				chkHighlightEasyCell.Enabled = true;
			}
			else
			{
				chkHighlightEasyCell.Enabled = false;
				chkHighlightEasyCell.Checked = false;
			}
		}
	}
}