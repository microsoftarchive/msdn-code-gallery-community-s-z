//-----------------------------------------------------------------------
// <copyright company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace RefreshData
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.Table1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.StudentGrades = new RefreshData.StudentGradesDataSet();
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ReportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SplitContainer2 = new System.Windows.Forms.SplitContainer();
            this.RichTextBox1 = new System.Windows.Forms.RichTextBox();
            this.DataGridViewStudentGrades = new System.Windows.Forms.DataGridView();
            this.Table1TableAdapter = new RefreshData.StudentGradesDataSetTableAdapters.Table1TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Table1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StudentGrades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).BeginInit();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer2)).BeginInit();
            this.SplitContainer2.Panel1.SuspendLayout();
            this.SplitContainer2.Panel2.SuspendLayout();
            this.SplitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewStudentGrades)).BeginInit();
            this.SuspendLayout();
            // 
            // Table1BindingSource
            // 
            this.Table1BindingSource.DataMember = "Table1";
            this.Table1BindingSource.DataSource = this.StudentGrades;
            // 
            // StudentGrades
            // 
            this.StudentGrades.DataSetName = "StudentGrades";
            this.StudentGrades.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SplitContainer1
            // 
            this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer1.Name = "SplitContainer1";
            // 
            // SplitContainer1.Panel1
            // 
            this.SplitContainer1.Panel1.Controls.Add(this.ReportViewer1);
            // 
            // SplitContainer1.Panel2
            // 
            this.SplitContainer1.Panel2.Controls.Add(this.SplitContainer2);
            this.SplitContainer1.Size = new System.Drawing.Size(820, 370);
            this.SplitContainer1.SplitterDistance = 374;
            this.SplitContainer1.TabIndex = 0;
            // 
            // ReportViewer1
            // 
            this.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.Table1BindingSource;
            this.ReportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.ReportViewer1.LocalReport.ReportEmbeddedResource = "RefreshData.Report1.rdlc";
            this.ReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.ReportViewer1.Name = "ReportViewer1";
            this.ReportViewer1.Size = new System.Drawing.Size(374, 370);
            this.ReportViewer1.TabIndex = 0;
            // 
            // SplitContainer2
            // 
            this.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer2.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer2.Name = "SplitContainer2";
            this.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer2.Panel1
            // 
            this.SplitContainer2.Panel1.BackColor = System.Drawing.SystemColors.Window;
            this.SplitContainer2.Panel1.Controls.Add(this.RichTextBox1);
            // 
            // SplitContainer2.Panel2
            // 
            this.SplitContainer2.Panel2.Controls.Add(this.DataGridViewStudentGrades);
            this.SplitContainer2.Size = new System.Drawing.Size(442, 370);
            this.SplitContainer2.SplitterDistance = 63;
            this.SplitContainer2.TabIndex = 1;
            // 
            // RichTextBox1
            // 
            this.RichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RichTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichTextBox1.Location = new System.Drawing.Point(0, 0);
            this.RichTextBox1.Name = "RichTextBox1";
            this.RichTextBox1.Size = new System.Drawing.Size(442, 63);
            this.RichTextBox1.TabIndex = 0;
            this.RichTextBox1.Text = "Add a new record to the DataGridView control below, then click the Refresh button" +
                " in the ReportViewer control to see the new data displayed in the report.";
            // 
            // DataGridViewStudentGrades
            // 
            this.DataGridViewStudentGrades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridViewStudentGrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewStudentGrades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridViewStudentGrades.Location = new System.Drawing.Point(0, 0);
            this.DataGridViewStudentGrades.Name = "DataGridViewStudentGrades";
            this.DataGridViewStudentGrades.Size = new System.Drawing.Size(442, 303);
            this.DataGridViewStudentGrades.TabIndex = 0;
            // 
            // Table1TableAdapter
            // 
            this.Table1TableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 370);
            this.Controls.Add(this.SplitContainer1);
            this.Name = "Form1";
            this.Text = "RefreshData";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Table1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StudentGrades)).EndInit();
            this.SplitContainer1.Panel1.ResumeLayout(false);
            this.SplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).EndInit();
            this.SplitContainer1.ResumeLayout(false);
            this.SplitContainer2.Panel1.ResumeLayout(false);
            this.SplitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer2)).EndInit();
            this.SplitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewStudentGrades)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer SplitContainer1;
        private Microsoft.Reporting.WinForms.ReportViewer ReportViewer1;
        private System.Windows.Forms.SplitContainer SplitContainer2;
        private System.Windows.Forms.RichTextBox RichTextBox1;
        private System.Windows.Forms.BindingSource Table1BindingSource;
        private StudentGradesDataSet StudentGrades;
        private StudentGradesDataSetTableAdapters.Table1TableAdapter Table1TableAdapter;
        private System.Windows.Forms.DataGridView DataGridViewStudentGrades;
    }
}

