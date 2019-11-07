namespace RibbonControlsExcelWorkbook
{
    [System.ComponentModel.ToolboxItemAttribute(false)]
    partial class ActionsPaneControl1
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
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
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(22, 18);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(106, 13);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Toggle Actions Pane";
            // 
            // ActionsPaneControl1
            // 
            this.Controls.Add(this.Label1);
            this.Name = "ActionsPaneControl1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label1;
    }
}
