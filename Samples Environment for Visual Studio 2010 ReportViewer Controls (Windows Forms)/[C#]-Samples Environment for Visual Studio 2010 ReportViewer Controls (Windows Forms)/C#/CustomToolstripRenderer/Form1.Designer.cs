//-----------------------------------------------------------------------
// <copyright company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace CustomToolStripRenderer
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
            this.ReportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.RadioSystemSkin = new System.Windows.Forms.RadioButton();
            this.RadioProfessionalSkin = new System.Windows.Forms.RadioButton();
            this.RadioCustomSkin = new System.Windows.Forms.RadioButton();
            this.RichTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // ReportViewer1
            // 
            this.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.ReportViewer1.Name = "ReportViewer1";
            this.ReportViewer1.Size = new System.Drawing.Size(637, 462);
            this.ReportViewer1.TabIndex = 0;
            // 
            // RadioSystemSkin
            // 
            this.RadioSystemSkin.AutoSize = true;
            this.RadioSystemSkin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioSystemSkin.Location = new System.Drawing.Point(653, 107);
            this.RadioSystemSkin.Name = "RadioSystemSkin";
            this.RadioSystemSkin.Size = new System.Drawing.Size(72, 21);
            this.RadioSystemSkin.TabIndex = 1;
            this.RadioSystemSkin.Text = "System";
            this.RadioSystemSkin.UseVisualStyleBackColor = true;
            this.RadioSystemSkin.CheckedChanged += new System.EventHandler(this.RadioSystemSkin_CheckedChanged);
            // 
            // RadioProfessionalSkin
            // 
            this.RadioProfessionalSkin.AutoSize = true;
            this.RadioProfessionalSkin.Checked = true;
            this.RadioProfessionalSkin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioProfessionalSkin.Location = new System.Drawing.Point(653, 131);
            this.RadioProfessionalSkin.Name = "RadioProfessionalSkin";
            this.RadioProfessionalSkin.Size = new System.Drawing.Size(104, 21);
            this.RadioProfessionalSkin.TabIndex = 2;
            this.RadioProfessionalSkin.TabStop = true;
            this.RadioProfessionalSkin.Text = "Professional";
            this.RadioProfessionalSkin.UseVisualStyleBackColor = true;
            this.RadioProfessionalSkin.CheckedChanged += new System.EventHandler(this.RadioProfessionalSkin_CheckedChanged);
            // 
            // RadioCustomSkin
            // 
            this.RadioCustomSkin.AutoSize = true;
            this.RadioCustomSkin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioCustomSkin.Location = new System.Drawing.Point(653, 155);
            this.RadioCustomSkin.Name = "RadioCustomSkin";
            this.RadioCustomSkin.Size = new System.Drawing.Size(73, 21);
            this.RadioCustomSkin.TabIndex = 3;
            this.RadioCustomSkin.Text = "Custom";
            this.RadioCustomSkin.UseVisualStyleBackColor = true;
            this.RadioCustomSkin.CheckedChanged += new System.EventHandler(this.RadioCustomSkin_CheckedChanged);
            // 
            // RichTextBox1
            // 
            this.RichTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RichTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichTextBox1.Location = new System.Drawing.Point(653, 35);
            this.RichTextBox1.Name = "RichTextBox1";
            this.RichTextBox1.Size = new System.Drawing.Size(146, 66);
            this.RichTextBox1.TabIndex = 5;
            this.RichTextBox1.Text = "Select one of the following renderers to apply a different skin to the toolbar.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 462);
            this.Controls.Add(this.RichTextBox1);
            this.Controls.Add(this.RadioCustomSkin);
            this.Controls.Add(this.RadioProfessionalSkin);
            this.Controls.Add(this.RadioSystemSkin);
            this.Controls.Add(this.ReportViewer1);
            this.Name = "Form1";
            this.Text = "CustomToolstripRenderer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer ReportViewer1;
        private System.Windows.Forms.RadioButton RadioSystemSkin;
        private System.Windows.Forms.RadioButton RadioProfessionalSkin;
        private System.Windows.Forms.RadioButton RadioCustomSkin;
        private System.Windows.Forms.RichTextBox RichTextBox1;
    }
}

