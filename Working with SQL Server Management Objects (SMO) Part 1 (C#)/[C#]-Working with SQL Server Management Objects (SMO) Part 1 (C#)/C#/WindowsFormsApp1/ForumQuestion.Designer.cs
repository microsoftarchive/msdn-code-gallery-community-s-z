namespace WindowsFormsApp1
{
    partial class ForumQuestion
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
            this.cboDatabaseNames = new System.Windows.Forms.ComboBox();
            this.lstTableNames = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // cboDatabaseNames
            // 
            this.cboDatabaseNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDatabaseNames.FormattingEnabled = true;
            this.cboDatabaseNames.Location = new System.Drawing.Point(16, 19);
            this.cboDatabaseNames.Name = "cboDatabaseNames";
            this.cboDatabaseNames.Size = new System.Drawing.Size(193, 21);
            this.cboDatabaseNames.TabIndex = 0;
            // 
            // lstTableNames
            // 
            this.lstTableNames.FormattingEnabled = true;
            this.lstTableNames.Location = new System.Drawing.Point(16, 46);
            this.lstTableNames.Name = "lstTableNames";
            this.lstTableNames.Size = new System.Drawing.Size(193, 173);
            this.lstTableNames.TabIndex = 2;
            // 
            // ForumQuestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 262);
            this.Controls.Add(this.lstTableNames);
            this.Controls.Add(this.cboDatabaseNames);
            this.Name = "ForumQuestion";
            this.Text = "ForumQuestion";
            this.Load += new System.EventHandler(this.ForumQuestion_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboDatabaseNames;
        private System.Windows.Forms.ListBox lstTableNames;
    }
}