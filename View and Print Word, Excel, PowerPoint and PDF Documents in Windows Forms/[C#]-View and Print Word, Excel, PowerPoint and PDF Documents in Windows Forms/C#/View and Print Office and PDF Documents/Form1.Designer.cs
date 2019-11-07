namespace View_and_Print_Office_and_PDF_Documents
{
    partial class Form1
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
            this.officeViewer1 = new Spire.OfficeViewer.Forms.OfficeViewer();
            this.SuspendLayout();
            // 
            // officeViewer1
            // 
            this.officeViewer1.IsToolBarVisible = true;
            this.officeViewer1.Location = new System.Drawing.Point(12, 12);
            this.officeViewer1.Name = "officeViewer1";
            this.officeViewer1.Size = new System.Drawing.Size(777, 508);
            this.officeViewer1.TabIndex = 0;
            this.officeViewer1.Text = "officeViewer1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 532);
            this.Controls.Add(this.officeViewer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Spire.OfficeViewer.Forms.OfficeViewer officeViewer1;



    }
}

