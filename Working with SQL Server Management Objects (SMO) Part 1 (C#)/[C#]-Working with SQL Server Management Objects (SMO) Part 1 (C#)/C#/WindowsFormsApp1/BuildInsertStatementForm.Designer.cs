namespace WindowsFormsApp1
{
    partial class BuildInsertStatementForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdCopyToClipboard = new System.Windows.Forms.Button();
            this.chkWrapColumnsWithBrackets = new System.Windows.Forms.CheckBox();
            this.cmdCreateInsertStatement = new System.Windows.Forms.Button();
            this.lstTableNames = new System.Windows.Forms.ListBox();
            this.cboDatabaseNames = new System.Windows.Forms.ComboBox();
            this.clbColumnNames = new System.Windows.Forms.CheckedListBox();
            this.cmdSelect = new System.Windows.Forms.Button();
            this.chkToggleColumnsChecked = new System.Windows.Forms.CheckBox();
            this.txtSqlStatement = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmdCopyToClipboard);
            this.panel1.Controls.Add(this.chkWrapColumnsWithBrackets);
            this.panel1.Controls.Add(this.cmdCreateInsertStatement);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 276);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(521, 98);
            this.panel1.TabIndex = 0;
            // 
            // cmdCopyToClipboard
            // 
            this.cmdCopyToClipboard.Location = new System.Drawing.Point(12, 68);
            this.cmdCopyToClipboard.Name = "cmdCopyToClipboard";
            this.cmdCopyToClipboard.Size = new System.Drawing.Size(166, 23);
            this.cmdCopyToClipboard.TabIndex = 2;
            this.cmdCopyToClipboard.Text = "Copy to clipboard";
            this.cmdCopyToClipboard.UseVisualStyleBackColor = true;
            this.cmdCopyToClipboard.Click += new System.EventHandler(this.cmdCopyToClipboard_Click);
            // 
            // chkWrapColumnsWithBrackets
            // 
            this.chkWrapColumnsWithBrackets.AutoSize = true;
            this.chkWrapColumnsWithBrackets.Location = new System.Drawing.Point(12, 45);
            this.chkWrapColumnsWithBrackets.Name = "chkWrapColumnsWithBrackets";
            this.chkWrapColumnsWithBrackets.Size = new System.Drawing.Size(175, 17);
            this.chkWrapColumnsWithBrackets.TabIndex = 1;
            this.chkWrapColumnsWithBrackets.Text = "Wrap columns with [FieldName]";
            this.chkWrapColumnsWithBrackets.UseVisualStyleBackColor = true;
            // 
            // cmdCreateInsertStatement
            // 
            this.cmdCreateInsertStatement.Location = new System.Drawing.Point(12, 12);
            this.cmdCreateInsertStatement.Name = "cmdCreateInsertStatement";
            this.cmdCreateInsertStatement.Size = new System.Drawing.Size(166, 23);
            this.cmdCreateInsertStatement.TabIndex = 0;
            this.cmdCreateInsertStatement.Text = "Create INSERT statement";
            this.cmdCreateInsertStatement.UseVisualStyleBackColor = true;
            this.cmdCreateInsertStatement.Click += new System.EventHandler(this.cmdCreateInsertStatement_Click);
            // 
            // lstTableNames
            // 
            this.lstTableNames.FormattingEnabled = true;
            this.lstTableNames.Location = new System.Drawing.Point(12, 39);
            this.lstTableNames.Name = "lstTableNames";
            this.lstTableNames.Size = new System.Drawing.Size(227, 173);
            this.lstTableNames.TabIndex = 3;
            // 
            // cboDatabaseNames
            // 
            this.cboDatabaseNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDatabaseNames.FormattingEnabled = true;
            this.cboDatabaseNames.Location = new System.Drawing.Point(12, 12);
            this.cboDatabaseNames.Name = "cboDatabaseNames";
            this.cboDatabaseNames.Size = new System.Drawing.Size(227, 21);
            this.cboDatabaseNames.TabIndex = 0;
            // 
            // clbColumnNames
            // 
            this.clbColumnNames.FormattingEnabled = true;
            this.clbColumnNames.Location = new System.Drawing.Point(245, 39);
            this.clbColumnNames.Name = "clbColumnNames";
            this.clbColumnNames.Size = new System.Drawing.Size(261, 169);
            this.clbColumnNames.TabIndex = 4;
            // 
            // cmdSelect
            // 
            this.cmdSelect.Location = new System.Drawing.Point(245, 12);
            this.cmdSelect.Name = "cmdSelect";
            this.cmdSelect.Size = new System.Drawing.Size(125, 23);
            this.cmdSelect.TabIndex = 1;
            this.cmdSelect.Text = "Select";
            this.cmdSelect.UseVisualStyleBackColor = true;
            this.cmdSelect.Click += new System.EventHandler(this.cmdSelect_Click);
            // 
            // chkToggleColumnsChecked
            // 
            this.chkToggleColumnsChecked.AutoSize = true;
            this.chkToggleColumnsChecked.Location = new System.Drawing.Point(376, 14);
            this.chkToggleColumnsChecked.Name = "chkToggleColumnsChecked";
            this.chkToggleColumnsChecked.Size = new System.Drawing.Size(37, 17);
            this.chkToggleColumnsChecked.TabIndex = 2;
            this.chkToggleColumnsChecked.Text = "All";
            this.chkToggleColumnsChecked.UseVisualStyleBackColor = true;
            // 
            // txtSqlStatement
            // 
            this.txtSqlStatement.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtSqlStatement.Location = new System.Drawing.Point(0, 224);
            this.txtSqlStatement.Multiline = true;
            this.txtSqlStatement.Name = "txtSqlStatement";
            this.txtSqlStatement.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSqlStatement.Size = new System.Drawing.Size(521, 52);
            this.txtSqlStatement.TabIndex = 5;
            // 
            // BuildInsertStatementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 374);
            this.Controls.Add(this.txtSqlStatement);
            this.Controls.Add(this.chkToggleColumnsChecked);
            this.Controls.Add(this.cmdSelect);
            this.Controls.Add(this.clbColumnNames);
            this.Controls.Add(this.lstTableNames);
            this.Controls.Add(this.cboDatabaseNames);
            this.Controls.Add(this.panel1);
            this.Name = "BuildInsertStatementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Build Insert Statement";
            this.Load += new System.EventHandler(this.BuildInsertStatementForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox lstTableNames;
        private System.Windows.Forms.ComboBox cboDatabaseNames;
        private System.Windows.Forms.CheckedListBox clbColumnNames;
        private System.Windows.Forms.Button cmdCreateInsertStatement;
        private System.Windows.Forms.Button cmdSelect;
        private System.Windows.Forms.CheckBox chkToggleColumnsChecked;
        private System.Windows.Forms.CheckBox chkWrapColumnsWithBrackets;
        private System.Windows.Forms.TextBox txtSqlStatement;
        private System.Windows.Forms.Button cmdCopyToClipboard;
    }
}