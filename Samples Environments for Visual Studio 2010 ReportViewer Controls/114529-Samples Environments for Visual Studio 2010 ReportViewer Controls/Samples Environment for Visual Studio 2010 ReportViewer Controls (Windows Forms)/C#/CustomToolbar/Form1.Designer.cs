//-----------------------------------------------------------------------
// <copyright company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace CustomToolBar
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
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ButtonFirstPage = new System.Windows.Forms.ToolStripButton();
            this.ButtonPrevPage = new System.Windows.Forms.ToolStripButton();
            this.TextBoxPageNum = new System.Windows.Forms.ToolStripTextBox();
            this.LabelTotalPages = new System.Windows.Forms.ToolStripLabel();
            this.ButtonNextPage = new System.Windows.Forms.ToolStripButton();
            this.ButtonLastPage = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ButtonBack = new System.Windows.Forms.ToolStripButton();
            this.ButtonStop = new System.Windows.Forms.ToolStripButton();
            this.ButtonRefresh = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ButtonPrint = new System.Windows.Forms.ToolStripButton();
            this.ButtonPreview = new System.Windows.Forms.ToolStripButton();
            this.ButtonSetup = new System.Windows.Forms.ToolStripButton();
            this.DropDownExport = new System.Windows.Forms.ToolStripDropDownButton();
            this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.DropDownZoom = new System.Windows.Forms.ToolStripComboBox();
            this.TextBoxFind = new System.Windows.Forms.ToolStripTextBox();
            this.ButtonFind = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.ButtonNext = new System.Windows.Forms.ToolStripButton();
            this.ReportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ButtonFirstPage,
            this.ButtonPrevPage,
            this.TextBoxPageNum,
            this.LabelTotalPages,
            this.ButtonNextPage,
            this.ButtonLastPage,
            this.ToolStripSeparator1,
            this.ButtonBack,
            this.ButtonStop,
            this.ButtonRefresh,
            this.ToolStripSeparator2,
            this.ButtonPrint,
            this.ButtonPreview,
            this.ButtonSetup,
            this.DropDownExport,
            this.ToolStripSeparator3,
            this.DropDownZoom,
            this.TextBoxFind,
            this.ButtonFind,
            this.ToolStripSeparator4,
            this.ButtonNext});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 437);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(607, 25);
            this.ToolStrip1.TabIndex = 0;
            // 
            // ButtonFirstPage
            // 
            this.ButtonFirstPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonFirstPage.Enabled = false;
            this.ButtonFirstPage.Image = global::CustomToolBar.Properties.Resources.ButtonFirstPage;
            this.ButtonFirstPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonFirstPage.Name = "ButtonFirstPage";
            this.ButtonFirstPage.Size = new System.Drawing.Size(23, 22);
            this.ButtonFirstPage.Text = "toolStripButton1";
            this.ButtonFirstPage.ToolTipText = "CustomToolBar: click to go to the first page.";
            this.ButtonFirstPage.Click += new System.EventHandler(this.ButtonFirstPage_Click);
            // 
            // ButtonPrevPage
            // 
            this.ButtonPrevPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonPrevPage.Enabled = false;
            this.ButtonPrevPage.Image = global::CustomToolBar.Properties.Resources.ButtonPrevPage;
            this.ButtonPrevPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonPrevPage.Name = "ButtonPrevPage";
            this.ButtonPrevPage.Size = new System.Drawing.Size(23, 22);
            this.ButtonPrevPage.Text = "toolStripButton2";
            this.ButtonPrevPage.ToolTipText = "CustomToolBar: click to to go to the previous page.";
            this.ButtonPrevPage.Click += new System.EventHandler(this.ButtonPrevPage_Click);
            // 
            // TextBoxPageNum
            // 
            this.TextBoxPageNum.Enabled = false;
            this.TextBoxPageNum.Name = "TextBoxPageNum";
            this.TextBoxPageNum.Size = new System.Drawing.Size(50, 25);
            this.TextBoxPageNum.ToolTipText = "CustomToolBar: input the page number you want.";
            this.TextBoxPageNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxPageNum_KeyPress);
            // 
            // LabelTotalPages
            // 
            this.LabelTotalPages.Name = "LabelTotalPages";
            this.LabelTotalPages.Size = new System.Drawing.Size(21, 22);
            this.LabelTotalPages.Text = "of ";
            // 
            // ButtonNextPage
            // 
            this.ButtonNextPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonNextPage.Enabled = false;
            this.ButtonNextPage.Image = global::CustomToolBar.Properties.Resources.ButtonNextPage;
            this.ButtonNextPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonNextPage.Name = "ButtonNextPage";
            this.ButtonNextPage.Size = new System.Drawing.Size(23, 22);
            this.ButtonNextPage.Text = "toolStripButton3";
            this.ButtonNextPage.ToolTipText = "CustomToolBar: click to go to the next page.";
            this.ButtonNextPage.Click += new System.EventHandler(this.ButtonNextPage_Click);
            // 
            // ButtonLastPage
            // 
            this.ButtonLastPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonLastPage.Enabled = false;
            this.ButtonLastPage.Image = global::CustomToolBar.Properties.Resources.ButtonLastPage;
            this.ButtonLastPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonLastPage.Name = "ButtonLastPage";
            this.ButtonLastPage.Size = new System.Drawing.Size(23, 22);
            this.ButtonLastPage.Text = "toolStripButton4";
            this.ButtonLastPage.ToolTipText = "CustomToolBar: click to go to the last page.";
            this.ButtonLastPage.Click += new System.EventHandler(this.ButtonLastPage_Click);
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // ButtonBack
            // 
            this.ButtonBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonBack.Enabled = false;
            this.ButtonBack.Image = global::CustomToolBar.Properties.Resources.ButtonBack;
            this.ButtonBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonBack.Name = "ButtonBack";
            this.ButtonBack.Size = new System.Drawing.Size(23, 22);
            this.ButtonBack.Text = "toolStripButton1";
            this.ButtonBack.ToolTipText = "CustomToolBar: click to go to the parent report.";
            this.ButtonBack.Click += new System.EventHandler(this.ButtonBack_Click);
            // 
            // ButtonStop
            // 
            this.ButtonStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonStop.Enabled = false;
            this.ButtonStop.Image = global::CustomToolBar.Properties.Resources.ButtonStop;
            this.ButtonStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonStop.Name = "ButtonStop";
            this.ButtonStop.Size = new System.Drawing.Size(23, 22);
            this.ButtonStop.Text = "toolStripButton2";
            this.ButtonStop.ToolTipText = "CustomToolBar: click to stop the current operation.";
            this.ButtonStop.Click += new System.EventHandler(this.ButtonStop_Click);
            // 
            // ButtonRefresh
            // 
            this.ButtonRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonRefresh.Enabled = false;
            this.ButtonRefresh.Image = global::CustomToolBar.Properties.Resources.ButtonRefresh;
            this.ButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonRefresh.Name = "ButtonRefresh";
            this.ButtonRefresh.Size = new System.Drawing.Size(23, 22);
            this.ButtonRefresh.Text = "toolStripButton3";
            this.ButtonRefresh.ToolTipText = "CustomToolBar: click to refresh the current report.";
            this.ButtonRefresh.Click += new System.EventHandler(this.ButtonRefresh_Click);
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // ButtonPrint
            // 
            this.ButtonPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonPrint.Enabled = false;
            this.ButtonPrint.Image = global::CustomToolBar.Properties.Resources.ButtonPrint;
            this.ButtonPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonPrint.Name = "ButtonPrint";
            this.ButtonPrint.Size = new System.Drawing.Size(23, 22);
            this.ButtonPrint.Text = "toolStripButton4";
            this.ButtonPrint.ToolTipText = "CustomToolBar: click to print the report.";
            this.ButtonPrint.Click += new System.EventHandler(this.ButtonPrint_Click);
            // 
            // ButtonPreview
            // 
            this.ButtonPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonPreview.Enabled = false;
            this.ButtonPreview.Image = global::CustomToolBar.Properties.Resources.ButtonPreview;
            this.ButtonPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonPreview.Name = "ButtonPreview";
            this.ButtonPreview.Size = new System.Drawing.Size(23, 22);
            this.ButtonPreview.Text = "toolStripButton5";
            this.ButtonPreview.ToolTipText = "CustomToolBar: click to preview the print layout.";
            this.ButtonPreview.Click += new System.EventHandler(this.ButtonPreview_Click);
            // 
            // ButtonSetup
            // 
            this.ButtonSetup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonSetup.Enabled = false;
            this.ButtonSetup.Image = global::CustomToolBar.Properties.Resources.ButtonSetup;
            this.ButtonSetup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonSetup.Name = "ButtonSetup";
            this.ButtonSetup.Size = new System.Drawing.Size(23, 22);
            this.ButtonSetup.Text = "toolStripButton6";
            this.ButtonSetup.ToolTipText = "CustomToolBar: click to setup the page properties.";
            this.ButtonSetup.Click += new System.EventHandler(this.ButtonSetup_Click);
            // 
            // DropDownExport
            // 
            this.DropDownExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DropDownExport.Enabled = false;
            this.DropDownExport.Image = global::CustomToolBar.Properties.Resources.DropDownExport;
            this.DropDownExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DropDownExport.Name = "DropDownExport";
            this.DropDownExport.Size = new System.Drawing.Size(29, 22);
            this.DropDownExport.Text = "toolStripDropDownButton1";
            this.DropDownExport.ToolTipText = "CustomToolBar: click to export the report.";
            this.DropDownExport.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.DropDownExport_DropDownItemClicked);
            // 
            // ToolStripSeparator3
            // 
            this.ToolStripSeparator3.Name = "ToolStripSeparator3";
            this.ToolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // DropDownZoom
            // 
            this.DropDownZoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DropDownZoom.Items.AddRange(new object[] {
            "Page Width",
            "Whole Page",
            "500%",
            "200%",
            "150%",
            "100%",
            "75%",
            "50%",
            "25%"});
            this.DropDownZoom.Name = "DropDownZoom";
            this.DropDownZoom.Size = new System.Drawing.Size(85, 25);
            this.DropDownZoom.ToolTipText = "CustomToolBar: Select a zoom level";
            this.DropDownZoom.SelectedIndexChanged += new System.EventHandler(this.DropDownZoom_SelectedIndexChanged);
            // 
            // TextBoxFind
            // 
            this.TextBoxFind.Name = "TextBoxFind";
            this.TextBoxFind.Size = new System.Drawing.Size(50, 25);
            this.TextBoxFind.ToolTipText = "CustomToolBar: input the string to search for.";
            this.TextBoxFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxFind_KeyDown);
            this.TextBoxFind.TextChanged += new System.EventHandler(this.TextBoxFind_TextChanged);
            // 
            // ButtonFind
            // 
            this.ButtonFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ButtonFind.Enabled = false;
            this.ButtonFind.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ButtonFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonFind.Name = "ButtonFind";
            this.ButtonFind.Size = new System.Drawing.Size(34, 22);
            this.ButtonFind.Text = "Find";
            this.ButtonFind.Click += new System.EventHandler(this.ButtonFind_Click);
            // 
            // ToolStripSeparator4
            // 
            this.ToolStripSeparator4.Name = "ToolStripSeparator4";
            this.ToolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // ButtonNext
            // 
            this.ButtonNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ButtonNext.Enabled = false;
            this.ButtonNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ButtonNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonNext.Name = "ButtonNext";
            this.ButtonNext.Size = new System.Drawing.Size(35, 22);
            this.ButtonNext.Text = "Next";
            this.ButtonNext.ToolTipText = "CustomToolBar: click to search for the next hit.";
            this.ButtonNext.Click += new System.EventHandler(this.ButtonNext_Click);
            // 
            // ReportViewer1
            // 
            this.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.ReportViewer1.Name = "ReportViewer1";
            this.ReportViewer1.ShowToolBar = false;
            this.ReportViewer1.Size = new System.Drawing.Size(607, 437);
            this.ReportViewer1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 462);
            this.Controls.Add(this.ReportViewer1);
            this.Controls.Add(this.ToolStrip1);
            this.Name = "Form1";
            this.Text = "CustomToolBar";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ToolStrip1;
        private System.Windows.Forms.ToolStripButton ButtonFirstPage;
        private System.Windows.Forms.ToolStripButton ButtonPrevPage;
        private System.Windows.Forms.ToolStripTextBox TextBoxPageNum;
        private System.Windows.Forms.ToolStripButton ButtonNextPage;
        private System.Windows.Forms.ToolStripButton ButtonLastPage;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        private Microsoft.Reporting.WinForms.ReportViewer ReportViewer1;
        private System.Windows.Forms.ToolStripLabel LabelTotalPages;
        private System.Windows.Forms.ToolStripButton ButtonBack;
        private System.Windows.Forms.ToolStripButton ButtonStop;
        private System.Windows.Forms.ToolStripButton ButtonRefresh;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
        private System.Windows.Forms.ToolStripButton ButtonPrint;
        private System.Windows.Forms.ToolStripButton ButtonPreview;
        private System.Windows.Forms.ToolStripButton ButtonSetup;
        private System.Windows.Forms.ToolStripDropDownButton DropDownExport;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator3;
        private System.Windows.Forms.ToolStripComboBox DropDownZoom;
        private System.Windows.Forms.ToolStripTextBox TextBoxFind;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator4;
        private System.Windows.Forms.ToolStripButton ButtonFind;
        private System.Windows.Forms.ToolStripButton ButtonNext;
    }
}

