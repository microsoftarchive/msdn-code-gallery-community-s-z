//-----------------------------------------------------------------------
// <copyright company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace SupplyingData
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
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ComboBoxChooseReport = new System.Windows.Forms.ToolStripComboBox();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.ToolStrip1.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ReportViewer1
            // 
            this.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportViewer1.DocumentMapWidth = 48;
            this.ReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.ReportViewer1.Name = "ReportViewer1";
            this.ReportViewer1.Size = new System.Drawing.Size(484, 437);
            this.ReportViewer1.TabIndex = 2;
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ComboBoxChooseReport});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(484, 25);
            this.ToolStrip1.TabIndex = 3;
            this.ToolStrip1.Text = "toolStrip1";
            // 
            // ComboBoxChooseReport
            // 
            this.ComboBoxChooseReport.Items.AddRange(new object[] {
            "Report with Subreport",
            "Report with Drillthrough"});
            this.ComboBoxChooseReport.Name = "ComboBoxChooseReport";
            this.ComboBoxChooseReport.Size = new System.Drawing.Size(150, 25);
            this.ComboBoxChooseReport.Text = "Report with Subreport";
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.ReportViewer1);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(0, 25);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(484, 437);
            this.Panel1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 462);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.ToolStrip1);
            this.Name = "Form1";
            this.Text = "SupplyingData";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.Panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer ReportViewer1;
        private System.Windows.Forms.ToolStrip ToolStrip1;
        private System.Windows.Forms.ToolStripComboBox ComboBoxChooseReport;
        private System.Windows.Forms.Panel Panel1;
    }
}

