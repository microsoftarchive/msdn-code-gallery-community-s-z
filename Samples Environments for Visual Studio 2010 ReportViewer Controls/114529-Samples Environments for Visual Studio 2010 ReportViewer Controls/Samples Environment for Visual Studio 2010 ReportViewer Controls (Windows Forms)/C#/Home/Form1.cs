//-----------------------------------------------------------------------
// <copyright company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Home
{
    public partial class Form1 : Form
    {
        private string root;

        public Form1()
        {
            InitializeComponent();
            root = Environment.CurrentDirectory;
            richTextBox1.LoadFile("content.rtf");
        }

        private void ButtonCustomAssembly_Click(object sender, EventArgs e)
        {
            Process proc = null;
            try
            {
                proc = new Process();
                proc.StartInfo.WorkingDirectory = String.Format(@"{0}\..\..\..\CustomAssembly\bin\debug", root);
                proc.StartInfo.FileName = "CustomAssembly.exe";
                proc.Start();
                proc.WaitForExit();
            }
            finally 
            {
                if (proc != null)
                    proc.Dispose();
            }
        }

        private void ButtonCustomCredentials_Click(object sender, EventArgs e)
        {
            Process proc = null;
            try
            {
                proc = new Process();
                proc.StartInfo.WorkingDirectory = String.Format(@"{0}\..\..\..\CustomCredentials\bin\debug", root);
                proc.StartInfo.FileName = "CustomCredentials.exe";
                proc.Start();
                proc.WaitForExit();
            }
            finally 
            {
                if (proc != null)
                    proc.Dispose();
            }
        }

        private void ButtonCustomToolbar_Click(object sender, EventArgs e)
        {
            Process proc = null;
            try
            {
                proc = new Process();
                proc.StartInfo.WorkingDirectory = String.Format(@"{0}\..\..\..\CustomToolBar\bin\debug", root);
                proc.StartInfo.FileName = "CustomToolBar.exe";
                proc.Start();
                proc.WaitForExit();
            }
            finally 
            {
                if (proc != null)
                    proc.Dispose();
            }
        }

        private void ButtonCustomToolstripRenderer_Click(object sender, EventArgs e)
        {
            Process proc = null;
            try
            {
                proc = new Process();
                proc.StartInfo.WorkingDirectory = String.Format(@"{0}\..\..\..\CustomToolstripRenderer\bin\debug", root);
                proc.StartInfo.FileName = "CustomToolstripRenderer.exe";
                proc.Start();
                proc.WaitForExit();
            }
            finally 
            {
                if (proc != null)
                    proc.Dispose();
            }
        }

        private void ButtonPrintingReportNoViewer_Click(object sender, EventArgs e)
        {
            Process proc = null;
            try
            {
                proc = new Process();
                proc.StartInfo.WorkingDirectory = String.Format(@"{0}\..\..\..\PrintingReportNoViewer\bin\debug", root);
                proc.StartInfo.FileName = "PrintingReportNoViewer.exe";
                proc.Start();
                proc.WaitForExit();
            }
            finally 
            {
                if (proc != null)
                    proc.Dispose();
            }
        }

        private void ButtonRefreshData_Click(object sender, EventArgs e)
        {
            Process proc = null;
            try
            {
                proc = new Process();
                proc.StartInfo.WorkingDirectory = String.Format(@"{0}\..\..\..\RefreshData\bin\debug", root);
                proc.StartInfo.FileName = "RefreshData.exe";
                proc.Start();
                proc.WaitForExit();
            }
            finally 
            {
                if (proc != null)
                    proc.Dispose();
            }
        }

        private void ButtonReportFromStream_Click(object sender, EventArgs e)
        {
            Process proc = null;
            try
            {
                proc = new Process();
                proc.StartInfo.WorkingDirectory = String.Format(@"{0}\..\..\..\ReportFromStream\bin\debug", root);
                proc.StartInfo.FileName = "ReportFromStream.exe";
                proc.Start();
                proc.WaitForExit();
            }
            finally 
            {
                if (proc != null)
                    proc.Dispose();
            }
        }

        private void ButtonSupplyingData_Click(object sender, EventArgs e)
        {
            Process proc = null;
            try
            {
                proc = new Process();
                proc.StartInfo.WorkingDirectory = String.Format(@"{0}\..\..\..\SupplyingData\bin\debug", root);
                proc.StartInfo.FileName = "SupplyingData.exe";
                proc.Start();
                proc.WaitForExit();
            }
            finally 
            {
                if (proc != null)
                    proc.Dispose();
            }
        }

        private void ButtonSupplyingParameters_Click(object sender, EventArgs e)
        {
            Process proc = null;
            try
            {
                proc = new Process();
                proc.StartInfo.WorkingDirectory = String.Format(@"{0}\..\..\..\SupplyingParameters\bin\debug", root);
                proc.StartInfo.FileName = "SupplyingParameters.exe";
                proc.Start();
                proc.WaitForExit();
            }
            finally
            {
                if (proc != null)
                    proc.Dispose();
            }
        }
    }
}
