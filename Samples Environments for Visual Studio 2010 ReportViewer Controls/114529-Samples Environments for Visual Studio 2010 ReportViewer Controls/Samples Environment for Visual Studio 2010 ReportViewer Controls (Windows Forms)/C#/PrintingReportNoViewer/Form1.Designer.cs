//-----------------------------------------------------------------------
// <copyright company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace PrintingReportNoViewer
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
            this.ButtonPrintLocal = new System.Windows.Forms.Button();
            this.ButtonPrintServer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonPrintLocal
            // 
            this.ButtonPrintLocal.Location = new System.Drawing.Point(36, 31);
            this.ButtonPrintLocal.Name = "ButtonPrintLocal";
            this.ButtonPrintLocal.Size = new System.Drawing.Size(105, 23);
            this.ButtonPrintLocal.TabIndex = 0;
            this.ButtonPrintLocal.Text = "Print Local Report";
            this.ButtonPrintLocal.UseVisualStyleBackColor = true;
            this.ButtonPrintLocal.Click += new System.EventHandler(this.ButtonPrintLocal_Click);
            // 
            // ButtonPrintServer
            // 
            this.ButtonPrintServer.Location = new System.Drawing.Point(36, 60);
            this.ButtonPrintServer.Name = "ButtonPrintServer";
            this.ButtonPrintServer.Size = new System.Drawing.Size(105, 23);
            this.ButtonPrintServer.TabIndex = 1;
            this.ButtonPrintServer.Text = "Print Server Report";
            this.ButtonPrintServer.UseVisualStyleBackColor = true;
            this.ButtonPrintServer.Click += new System.EventHandler(this.ButtonPrintServer_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(185, 119);
            this.Controls.Add(this.ButtonPrintServer);
            this.Controls.Add(this.ButtonPrintLocal);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "PrintingReportNoViewer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonPrintLocal;
        private System.Windows.Forms.Button ButtonPrintServer;
    }
}

