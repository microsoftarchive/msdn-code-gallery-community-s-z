//-----------------------------------------------------------------------
// <copyright company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Configuration;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace CustomToolBar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Note: You can set the processing mode, report server URL, and report path directly in the form designer, but here
            //       we set it maually instead in order to use global values.

            // Set to remote processing mode
            ReportViewer1.ProcessingMode = ProcessingMode.Remote;

            // Get report path from configuration file
            ReportViewer1.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportServerUrl"], UriKind.Absolute);
            ReportViewer1.ServerReport.ReportPath = String.Format("{0}/{1}{2}",
                ConfigurationManager.AppSettings["SampleReportsPath"],                                           // folder or site path
                "Employee Sales Summary 2008",                                                                   // report name
                (ConfigurationManager.AppSettings["ReportServerMode"] == "SharePoint" ? ".rdl" : String.Empty)); // extension, depending on the report server mode
                                                                                                                 // (for information on the report path format, 
                                                                                                                 // see http://msdn.microsoft.com/en-us/library/ms252075.aspx)

            ReportViewer1.StatusChanged += new EventHandler<EventArgs>(ReportViewer1_StatusChanged);
            ReportViewer1.Drillthrough += new DrillthroughEventHandler(ReportViewer1_Drillthrough);
            ReportViewer1.ZoomChange += new ZoomChangedEventHandler(ReportViewer1_ZoomChange);
        }

        private void ReportViewer1_ZoomChange(object sender, ZoomChangeEventArgs e)
        {
            switch (e.ZoomMode)
            {
                case ZoomMode.FullPage:
                    DropDownZoom.Text = "Whole Page";
                    break;
                case ZoomMode.PageWidth:
                    DropDownZoom.Text = "Page Width";
                    break;
                case ZoomMode.Percent:
                    DropDownZoom.Text = String.Format("{0}%", e.ZoomPercent.ToString());
                    break;
            }
        }

        private void ReportViewer1_Drillthrough(object sender, DrillthroughEventArgs e)
        {
            SetToolbarItems();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ReportViewer1.RefreshReport();
            SetToolbarItems();
        }

        private void SetToolbarItems()
        {
            ToolStripMenuItem item = null;
            try
            {
                DropDownExport.DropDownItems.Clear();
                RenderingExtension[] extensions = ReportViewer1.ServerReport.ListRenderingExtensions();
                foreach (RenderingExtension ext in extensions)
                {
                    // Only show the visible renderers in the drop down list.
                    if (ext.Visible)
                    {
                        item = new ToolStripMenuItem(ext.LocalizedName);
                        item.Name = ext.Name;
                        DropDownExport.DropDownItems.Add(item);
                    }
                }
            }
            finally
            {
                if (item != null)
                    item.Dispose();
            }

            switch (ReportViewer1.ZoomMode)
            {
                case ZoomMode.FullPage:
                    DropDownZoom.Text = "Whole Page";
                    break;
                case ZoomMode.PageWidth:
                    DropDownZoom.Text = "Page Width";
                    break;
                case ZoomMode.Percent:
                    DropDownZoom.Text = String.Format("{0}%", ReportViewer1.ZoomCalculated.ToString());
                    break;
            }
        }

        // This is where the appearance of most of the toolbar items are set
        private void ReportViewer1_StatusChanged(object sender, EventArgs e)
        {
            ReportViewerStatus status = ReportViewer1.CurrentStatus;

            this.SuspendLayout();

            // Set page navigation items
            if (status.CanNavigatePages)
            {
                ButtonFirstPage.Enabled = (ReportViewer1.CurrentPage > 1);
                ButtonPrevPage.Enabled = (ReportViewer1.CurrentPage > 1);

                TextBoxPageNum.Enabled = true;
                TextBoxPageNum.Text = ReportViewer1.CurrentPage.ToString();
                PageCountMode mode;
                int total = ReportViewer1.GetTotalPages(out mode);
                LabelTotalPages.Text = String.Format("of {0}{1}", total, (mode == PageCountMode.Estimate ? "?" : String.Empty));

                ButtonNextPage.Enabled = (ReportViewer1.CurrentPage < total);
                ButtonLastPage.Enabled = (ReportViewer1.CurrentPage < total);
            }
            else
            {
                ButtonFirstPage.Enabled = false;
                ButtonPrevPage.Enabled = false;
                TextBoxPageNum.Enabled = false;
                TextBoxPageNum.Text = String.Empty;
                ButtonNextPage.Enabled = false;
                ButtonLastPage.Enabled = false;
            }

            // Set Back, Stop, and Refresh buttons
            ButtonBack.Enabled = status.CanNavigateBack;
            ButtonStop.Enabled = status.InCancelableOperation;
            ButtonRefresh.Enabled = status.CanRefreshData;

            // Set Print, Print Preview, Page Setup, and Export buttons
            ButtonPrint.Enabled = status.CanPrint;
            ButtonPreview.Enabled = status.CanChangeDisplayModes;
            ButtonPreview.Checked = ReportViewer1.DisplayMode == DisplayMode.PrintLayout;
            ButtonSetup.Enabled = status.CanNavigatePages;
            DropDownExport.Enabled = status.CanExport;

            // Set zoom and search items
            DropDownZoom.Enabled = status.CanChangeZoom;
            TextBoxFind.Enabled = status.CanSearch;
            ButtonFind.Enabled = (status.CanSearch && TextBoxFind.Text.Length > 0) ? true : false;
            ButtonNext.Enabled = status.CanContinueSearch;

            this.ResumeLayout();
        }

        private void ButtonFirstPage_Click(object sender, EventArgs e)
        {
            ReportViewer1.CurrentPage = 1;
        }

        private void ButtonLastPage_Click(object sender, EventArgs e)
        {
            PageCountMode mode;
            int total = ReportViewer1.GetTotalPages(out mode);
            if (mode == PageCountMode.Estimate)
                ReportViewer1.CurrentPage = ReportViewer.MaximumPageCount;
            else ReportViewer1.CurrentPage = total;
        }

        private void ButtonPrevPage_Click(object sender, EventArgs e)
        {
            ReportViewer1.CurrentPage--;
        }

        private void ButtonNextPage_Click(object sender, EventArgs e)
        {
            ReportViewer1.CurrentPage++;
        }

        private void TextBoxPageNum_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            // Only allow number keys and the ENTER key to be used in this textbox.
            if (e.KeyChar == '\r')
            {
                try 
                { 
                    ReportViewer1.CurrentPage = Int32.Parse(TextBoxPageNum.Text); 
                }
                catch (ArgumentOutOfRangeException)
                {
                    ReportViewer1.CurrentPage = 1;
                }
            }
            else if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            ReportViewer1.PerformBack();
            SetToolbarItems();
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            ReportViewer1.CancelRendering(-1);
        }

        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            LabelTotalPages.Text = "of";
            ReportViewer1.RefreshReport();
        }

        private void ButtonPrint_Click(object sender, EventArgs e)
        {
            ReportViewer1.PrintDialog();
        }

        private void ButtonPreview_Click(object sender, EventArgs e)
        {
            ReportViewer1.SetDisplayMode(ButtonPreview.Checked ? DisplayMode.Normal : DisplayMode.PrintLayout);
        }

        private void ButtonSetup_Click(object sender, EventArgs e)
        {
            ReportViewer1.PageSetupDialog();
        }

        private void DropDownExport_DropDownItemClicked(object sender, System.Windows.Forms.ToolStripItemClickedEventArgs e)
        {
            foreach (RenderingExtension ext in ReportViewer1.ServerReport.ListRenderingExtensions())
            {
                if (ext.LocalizedName == e.ClickedItem.Text)
                {
                    ReportViewer1.ExportDialog(ext);
                    break;
                }
            }
        }

        private void DropDownZoom_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (DropDownZoom.Text == "Page Width")
                ReportViewer1.ZoomMode = ZoomMode.PageWidth;
            else if (DropDownZoom.Text == "Whole Page")
                ReportViewer1.ZoomMode = ZoomMode.FullPage;
            else
            {
                ReportViewer1.ZoomMode = ZoomMode.Percent;
                ReportViewer1.ZoomPercent = Int32.Parse(DropDownZoom.Text.TrimEnd('%'));
            }
        }

        private void TextBoxFind_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyValue == '\r' && TextBoxFind.Text.Length > 0)
                if (ReportViewer1.Find(TextBoxFind.Text, ReportViewer1.CurrentPage) == 0)
                {
                    MessageBox.Show("No results were found.", "CustomToolBar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    TextBoxFind.Text = String.Empty;
                }
        }

        private void TextBoxFind_TextChanged(object sender, System.EventArgs e)
        {
            ButtonFind.Enabled = (TextBoxFind.Text.Length > 0);
        }

        private void ButtonFind_Click(object sender, EventArgs e)
        {
            if (ReportViewer1.Find(TextBoxFind.Text, ReportViewer1.CurrentPage) == 0)
            {
                MessageBox.Show("No results were found.", "CustomToolBar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                TextBoxFind.Text = String.Empty;
            }
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            if (ReportViewer1.FindNext() == 0)
            {
                MessageBox.Show("Reached the end of the report.", "CustomToolBar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                TextBoxFind.Text = String.Empty;
            }
        }
    }
}
