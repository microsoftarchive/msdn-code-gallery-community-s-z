//-----------------------------------------------------------------------
// <copyright company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Home
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
            this.ButtonCustomAssembly = new System.Windows.Forms.Button();
            this.ButtonCustomCredentials = new System.Windows.Forms.Button();
            this.ButtonCustomToolbar = new System.Windows.Forms.Button();
            this.ButtonCustomToolStripRenderer = new System.Windows.Forms.Button();
            this.ButtonPrintingReportNoViewer = new System.Windows.Forms.Button();
            this.ButtonRefreshData = new System.Windows.Forms.Button();
            this.ButtonReportFromStream = new System.Windows.Forms.Button();
            this.ButtonSupplyingData = new System.Windows.Forms.Button();
            this.ButtonSupplyingParameters = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonCustomAssembly
            // 
            this.ButtonCustomAssembly.Location = new System.Drawing.Point(12, 454);
            this.ButtonCustomAssembly.Name = "ButtonCustomAssembly";
            this.ButtonCustomAssembly.Size = new System.Drawing.Size(141, 23);
            this.ButtonCustomAssembly.TabIndex = 0;
            this.ButtonCustomAssembly.Text = "CustomAssembly";
            this.toolTip1.SetToolTip(this.ButtonCustomAssembly, "Demonstrates how to use custom assemblies with your RDLC report.");
            this.ButtonCustomAssembly.UseVisualStyleBackColor = true;
            this.ButtonCustomAssembly.Click += new System.EventHandler(this.ButtonCustomAssembly_Click);
            // 
            // ButtonCustomCredentials
            // 
            this.ButtonCustomCredentials.Location = new System.Drawing.Point(159, 454);
            this.ButtonCustomCredentials.Name = "ButtonCustomCredentials";
            this.ButtonCustomCredentials.Size = new System.Drawing.Size(141, 23);
            this.ButtonCustomCredentials.TabIndex = 1;
            this.ButtonCustomCredentials.Text = "CustomCredentials";
            this.toolTip1.SetToolTip(this.ButtonCustomCredentials, "Demonstrates how to prevent the report server connection information from being s" +
                    "tored in the ASP.NET session. This sample requires the AdventureWorks 2008 Sampl" +
                    "e Reports.");
            this.ButtonCustomCredentials.UseVisualStyleBackColor = true;
            this.ButtonCustomCredentials.Click += new System.EventHandler(this.ButtonCustomCredentials_Click);
            // 
            // ButtonCustomToolbar
            // 
            this.ButtonCustomToolbar.Location = new System.Drawing.Point(306, 454);
            this.ButtonCustomToolbar.Name = "ButtonCustomToolbar";
            this.ButtonCustomToolbar.Size = new System.Drawing.Size(141, 23);
            this.ButtonCustomToolbar.TabIndex = 2;
            this.ButtonCustomToolbar.Text = "CustomToolbar";
            this.toolTip1.SetToolTip(this.ButtonCustomToolbar, "Demonstrates how to implement a custom toolbar for the ReportViewer control. This" +
                    " sample requires the AdventureWorks 2008 Sample Reports.");
            this.ButtonCustomToolbar.UseVisualStyleBackColor = true;
            this.ButtonCustomToolbar.Click += new System.EventHandler(this.ButtonCustomToolbar_Click);
            // 
            // ButtonCustomToolStripRenderer
            // 
            this.ButtonCustomToolStripRenderer.Location = new System.Drawing.Point(453, 454);
            this.ButtonCustomToolStripRenderer.Name = "ButtonCustomToolStripRenderer";
            this.ButtonCustomToolStripRenderer.Size = new System.Drawing.Size(141, 23);
            this.ButtonCustomToolStripRenderer.TabIndex = 3;
            this.ButtonCustomToolStripRenderer.Text = "CustomToolstripRenderer";
            this.toolTip1.SetToolTip(this.ButtonCustomToolStripRenderer, "Demonstrates how to change the skin of the ReportViewer control. This sample requ" +
                    "ires the AdventureWorks 2008 Sample Reports.");
            this.ButtonCustomToolStripRenderer.UseVisualStyleBackColor = true;
            this.ButtonCustomToolStripRenderer.Click += new System.EventHandler(this.ButtonCustomToolstripRenderer_Click);
            // 
            // ButtonPrintingReportNoViewer
            // 
            this.ButtonPrintingReportNoViewer.Location = new System.Drawing.Point(600, 454);
            this.ButtonPrintingReportNoViewer.Name = "ButtonPrintingReportNoViewer";
            this.ButtonPrintingReportNoViewer.Size = new System.Drawing.Size(141, 23);
            this.ButtonPrintingReportNoViewer.TabIndex = 4;
            this.ButtonPrintingReportNoViewer.Text = "PrintingReportNoViewer";
            this.toolTip1.SetToolTip(this.ButtonPrintingReportNoViewer, "Demonstrates how to print an RDLC report or a server report programmatically. To " +
                    "successfully print the server report requires the AdventureWorks 2008 Sample Rep" +
                    "orts.");
            this.ButtonPrintingReportNoViewer.UseVisualStyleBackColor = true;
            this.ButtonPrintingReportNoViewer.Click += new System.EventHandler(this.ButtonPrintingReportNoViewer_Click);
            // 
            // ButtonRefreshData
            // 
            this.ButtonRefreshData.Location = new System.Drawing.Point(12, 483);
            this.ButtonRefreshData.Name = "ButtonRefreshData";
            this.ButtonRefreshData.Size = new System.Drawing.Size(141, 23);
            this.ButtonRefreshData.TabIndex = 5;
            this.ButtonRefreshData.Text = "RefreshData";
            this.toolTip1.SetToolTip(this.ButtonRefreshData, "Demonstrates how to programmatically refresh the data for an RDLC report. ");
            this.ButtonRefreshData.UseVisualStyleBackColor = true;
            this.ButtonRefreshData.Click += new System.EventHandler(this.ButtonRefreshData_Click);
            // 
            // ButtonReportFromStream
            // 
            this.ButtonReportFromStream.Location = new System.Drawing.Point(159, 483);
            this.ButtonReportFromStream.Name = "ButtonReportFromStream";
            this.ButtonReportFromStream.Size = new System.Drawing.Size(141, 23);
            this.ButtonReportFromStream.TabIndex = 6;
            this.ButtonReportFromStream.Text = "ReportFromStream";
            this.toolTip1.SetToolTip(this.ButtonReportFromStream, "Demonstrates how to load an RDLC report from a stream.");
            this.ButtonReportFromStream.UseVisualStyleBackColor = true;
            this.ButtonReportFromStream.Click += new System.EventHandler(this.ButtonReportFromStream_Click);
            // 
            // ButtonSupplyingData
            // 
            this.ButtonSupplyingData.Location = new System.Drawing.Point(306, 483);
            this.ButtonSupplyingData.Name = "ButtonSupplyingData";
            this.ButtonSupplyingData.Size = new System.Drawing.Size(141, 23);
            this.ButtonSupplyingData.TabIndex = 7;
            this.ButtonSupplyingData.Text = "SupplyingData";
            this.toolTip1.SetToolTip(this.ButtonSupplyingData, "Demonstrates how to supply data to an RDLC report, as well as any subreport or dr" +
                    "illthrough report. It also demonstrates how to change the RDLC report at run tim" +
                    "e.");
            this.ButtonSupplyingData.UseVisualStyleBackColor = true;
            this.ButtonSupplyingData.Click += new System.EventHandler(this.ButtonSupplyingData_Click);
            // 
            // ButtonSupplyingParameters
            // 
            this.ButtonSupplyingParameters.Location = new System.Drawing.Point(453, 483);
            this.ButtonSupplyingParameters.Name = "ButtonSupplyingParameters";
            this.ButtonSupplyingParameters.Size = new System.Drawing.Size(141, 23);
            this.ButtonSupplyingParameters.TabIndex = 8;
            this.ButtonSupplyingParameters.Text = "SupplyingParameters";
            this.toolTip1.SetToolTip(this.ButtonSupplyingParameters, "Demonstrates how to supply parameters to a server report. This sample requires th" +
                    "e AdventureWorks 2008 Sample Reports.");
            this.ButtonSupplyingParameters.UseVisualStyleBackColor = true;
            this.ButtonSupplyingParameters.Click += new System.EventHandler(this.ButtonSupplyingParameters_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(753, 429);
            this.richTextBox1.TabIndex = 9;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 436);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(601, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Click the buttons below to run the samples. For more information on the samples, " +
                "hover over the buttons.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 515);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.ButtonSupplyingParameters);
            this.Controls.Add(this.ButtonSupplyingData);
            this.Controls.Add(this.ButtonReportFromStream);
            this.Controls.Add(this.ButtonRefreshData);
            this.Controls.Add(this.ButtonPrintingReportNoViewer);
            this.Controls.Add(this.ButtonCustomToolStripRenderer);
            this.Controls.Add(this.ButtonCustomToolbar);
            this.Controls.Add(this.ButtonCustomCredentials);
            this.Controls.Add(this.ButtonCustomAssembly);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "ReportViewer Samples Environment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonCustomAssembly;
        private System.Windows.Forms.Button ButtonCustomCredentials;
        private System.Windows.Forms.Button ButtonCustomToolbar;
        private System.Windows.Forms.Button ButtonCustomToolStripRenderer;
        private System.Windows.Forms.Button ButtonPrintingReportNoViewer;
        private System.Windows.Forms.Button ButtonRefreshData;
        private System.Windows.Forms.Button ButtonReportFromStream;
        private System.Windows.Forms.Button ButtonSupplyingData;
        private System.Windows.Forms.Button ButtonSupplyingParameters;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
    }
}

