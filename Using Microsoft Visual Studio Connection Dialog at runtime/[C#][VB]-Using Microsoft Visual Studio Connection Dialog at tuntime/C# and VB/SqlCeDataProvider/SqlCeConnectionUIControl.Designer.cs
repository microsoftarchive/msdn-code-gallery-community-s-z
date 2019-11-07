namespace Microsoft.Data.ConnectionUI
{
	partial class SqlCeConnectionUIControl
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SqlCeConnectionUIControl));
			this.dataSourceGroupBox = new System.Windows.Forms.GroupBox();
			this.activeSyncRadioButton = new System.Windows.Forms.RadioButton();
			this.myComputerRadioButton = new System.Windows.Forms.RadioButton();
			this.propertiesGroupBox = new System.Windows.Forms.GroupBox();
			this.savePasswordCheckBox = new System.Windows.Forms.CheckBox();
			this.databaseButtonsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.browseButton = new System.Windows.Forms.Button();
			this.createButton = new System.Windows.Forms.Button();
			this.passwordTextBox = new System.Windows.Forms.TextBox();
			this.databaseTextBox = new System.Windows.Forms.TextBox();
			this.passwordLabel = new System.Windows.Forms.Label();
			this.databaseLabel = new System.Windows.Forms.Label();
			this.dataSourceGroupBox.SuspendLayout();
			this.propertiesGroupBox.SuspendLayout();
			this.databaseButtonsTableLayoutPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// dataSourceGroupBox
			// 
			resources.ApplyResources(this.dataSourceGroupBox, "dataSourceGroupBox");
			this.dataSourceGroupBox.Controls.Add(this.activeSyncRadioButton);
			this.dataSourceGroupBox.Controls.Add(this.myComputerRadioButton);
			this.dataSourceGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.dataSourceGroupBox.Name = "dataSourceGroupBox";
			this.dataSourceGroupBox.TabStop = false;
			// 
			// activeSyncRadioButton
			// 
			resources.ApplyResources(this.activeSyncRadioButton, "activeSyncRadioButton");
			this.activeSyncRadioButton.Name = "activeSyncRadioButton";
			this.activeSyncRadioButton.TabStop = true;
			this.activeSyncRadioButton.UseVisualStyleBackColor = true;
			this.activeSyncRadioButton.CheckedChanged += new System.EventHandler(this.activeSyncRadioButton_CheckedChanged);
			// 
			// myComputerRadioButton
			// 
			resources.ApplyResources(this.myComputerRadioButton, "myComputerRadioButton");
			this.myComputerRadioButton.Name = "myComputerRadioButton";
			this.myComputerRadioButton.TabStop = true;
			this.myComputerRadioButton.UseVisualStyleBackColor = true;
			this.myComputerRadioButton.CheckedChanged += new System.EventHandler(this.myComputerRadioButton_CheckedChanged);
			// 
			// propertiesGroupBox
			// 
			resources.ApplyResources(this.propertiesGroupBox, "propertiesGroupBox");
			this.propertiesGroupBox.Controls.Add(this.savePasswordCheckBox);
			this.propertiesGroupBox.Controls.Add(this.databaseButtonsTableLayoutPanel);
			this.propertiesGroupBox.Controls.Add(this.passwordTextBox);
			this.propertiesGroupBox.Controls.Add(this.databaseTextBox);
			this.propertiesGroupBox.Controls.Add(this.passwordLabel);
			this.propertiesGroupBox.Controls.Add(this.databaseLabel);
			this.propertiesGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.propertiesGroupBox.Name = "propertiesGroupBox";
			this.propertiesGroupBox.TabStop = false;
			// 
			// savePasswordCheckBox
			// 
			resources.ApplyResources(this.savePasswordCheckBox, "savePasswordCheckBox");
			this.savePasswordCheckBox.Name = "savePasswordCheckBox";
			this.savePasswordCheckBox.UseVisualStyleBackColor = true;
			this.savePasswordCheckBox.CheckedChanged += new System.EventHandler(this.savePasswordCheckBox_CheckedChanged);
			// 
			// databaseButtonsTableLayoutPanel
			// 
			resources.ApplyResources(this.databaseButtonsTableLayoutPanel, "databaseButtonsTableLayoutPanel");
			this.databaseButtonsTableLayoutPanel.Controls.Add(this.browseButton, 1, 0);
			this.databaseButtonsTableLayoutPanel.Controls.Add(this.createButton, 0, 0);
			this.databaseButtonsTableLayoutPanel.Name = "databaseButtonsTableLayoutPanel";
			// 
			// browseButton
			// 
			resources.ApplyResources(this.browseButton, "browseButton");
			this.browseButton.MinimumSize = new System.Drawing.Size(75, 23);
			this.browseButton.Name = "browseButton";
			this.browseButton.UseVisualStyleBackColor = true;
			this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
			// 
			// createButton
			// 
			resources.ApplyResources(this.createButton, "createButton");
			this.createButton.MinimumSize = new System.Drawing.Size(75, 23);
			this.createButton.Name = "createButton";
			this.createButton.UseVisualStyleBackColor = true;
			// 
			// passwordTextBox
			// 
			resources.ApplyResources(this.passwordTextBox, "passwordTextBox");
			this.passwordTextBox.Name = "passwordTextBox";
			this.passwordTextBox.UseSystemPasswordChar = true;
			this.passwordTextBox.TextChanged += new System.EventHandler(this.passwordTextBox_TextChanged);
			// 
			// databaseTextBox
			// 
			resources.ApplyResources(this.databaseTextBox, "databaseTextBox");
			this.databaseTextBox.Name = "databaseTextBox";
			this.databaseTextBox.Leave += new System.EventHandler(this.TrimControlText);
			this.databaseTextBox.TextChanged += new System.EventHandler(this.databaseTextBox_TextChanged);
			// 
			// passwordLabel
			// 
			resources.ApplyResources(this.passwordLabel, "passwordLabel");
			this.passwordLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.passwordLabel.Name = "passwordLabel";
			// 
			// databaseLabel
			// 
			resources.ApplyResources(this.databaseLabel, "databaseLabel");
			this.databaseLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.databaseLabel.Name = "databaseLabel";
			// 
			// SqlCeConnectionUIControl
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.propertiesGroupBox);
			this.Controls.Add(this.dataSourceGroupBox);
			this.MinimumSize = new System.Drawing.Size(300, 247);
			this.Name = "SqlCeConnectionUIControl";
			this.dataSourceGroupBox.ResumeLayout(false);
			this.dataSourceGroupBox.PerformLayout();
			this.propertiesGroupBox.ResumeLayout(false);
			this.propertiesGroupBox.PerformLayout();
			this.databaseButtonsTableLayoutPanel.ResumeLayout(false);
			this.databaseButtonsTableLayoutPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox dataSourceGroupBox;
		private System.Windows.Forms.RadioButton myComputerRadioButton;
		private System.Windows.Forms.RadioButton activeSyncRadioButton;
		private System.Windows.Forms.GroupBox propertiesGroupBox;
		private System.Windows.Forms.Label databaseLabel;
		private System.Windows.Forms.Label passwordLabel;
		private System.Windows.Forms.TextBox databaseTextBox;
		private System.Windows.Forms.TextBox passwordTextBox;
		private System.Windows.Forms.TableLayoutPanel databaseButtonsTableLayoutPanel;
		private System.Windows.Forms.Button browseButton;
		private System.Windows.Forms.Button createButton;
		private System.Windows.Forms.CheckBox savePasswordCheckBox;
	}
}
