//-----------------------------------------------------------------------
// <copyright company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Configuration;
using System.Drawing;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

namespace CustomSkin
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ReportViewer1.ProcessingMode = ProcessingMode.Remote;

                // Get report path from configuration file
                ReportViewer1.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportServerUrl"]);
                ReportViewer1.ServerReport.ReportPath = String.Format("{0}/{1}{2}",
                    ConfigurationManager.AppSettings["SampleReportsPath"],                                           // folder or site path
                    "Product Catalog 2008",                                                                          // report name
                    (ConfigurationManager.AppSettings["ReportServerMode"] == "SharePoint" ? ".rdl" : String.Empty)); // extension, depending on the report server mode
                                                                                                                     // (for information on the report path format, 
                                                                                                                     // see http://msdn.microsoft.com/en-us/library/ms252075.aspx)

                FillDropDownLists();

                // Initialize the controls to the ReportViewer control's default skin settings.
                DropDownBackColor.SelectedValue = ReportViewer1.BackColor.Name;
                DropDownBorderColor.SelectedValue = ReportViewer1.BorderColor.Name;
                DropDownBorderStyle.SelectedValue = System.Enum.GetName(typeof(BorderStyle), ReportViewer1.BorderStyle);
                TextBoxBorderWidth.Text = ReportViewer1.BorderWidth.ToString();
                DropDownFont.SelectedValue = ReportViewer1.Font.Name;
                TextBoxSize.Text = ReportViewer1.Font.Size.ToString();
                CheckBoxBold.Checked = ReportViewer1.Font.Bold;
                CheckBoxItalic.Checked = ReportViewer1.Font.Italic;
                CheckBoxOverLine.Checked = ReportViewer1.Font.Overline;
                CheckBoxStrikeout.Checked = ReportViewer1.Font.Strikeout;
                CheckBoxUnderline.Checked = ReportViewer1.Font.Underline;
                DropDownInternalBorderColor.SelectedValue = ReportViewer1.InternalBorderColor.Name;
                DropDownInternalBorderStyle.SelectedValue = System.Enum.GetName(typeof(BorderStyle), ReportViewer1.InternalBorderStyle);
                TextBoxInternalBorderWidth.Text = ReportViewer1.InternalBorderWidth.ToString();
                DropDownListActiveColor.SelectedValue = ReportViewer1.LinkActiveColor.Name;
                DropDownListActiveHoverColor.SelectedValue = ReportViewer1.LinkActiveHoverColor.Name;
                DropDownListDisabledColor.SelectedValue = ReportViewer1.LinkDisabledColor.Name;
                DropDownSplitterBackColor.SelectedValue = ReportViewer1.SplitterBackColor.Name;
                DropDownWaitMessageFont.SelectedValue = ReportViewer1.WaitMessageFont.Name;
                TextBoxWaitMessageSize.Text = ReportViewer1.WaitMessageFont.Size.ToString();
                CheckBoxWaitMessageBold.Checked = ReportViewer1.WaitMessageFont.Bold;
                CheckBoxWaitMessageItalic.Checked = ReportViewer1.WaitMessageFont.Italic;
                CheckBoxWaitMessageOverLine.Checked = ReportViewer1.WaitMessageFont.Overline;
                CheckBoxWaitMessageStrikeout.Checked = ReportViewer1.WaitMessageFont.Strikeout;
                CheckBoxWaitMessageUnderline.Checked = ReportViewer1.WaitMessageFont.Underline;
            }
        }

        /// <summary>
        /// Fill the drop down lists with the available colors, border styles, and fonts
        /// </summary>
        private void FillDropDownLists()
        {
            string[] colors = typeof(KnownColor).GetEnumNames();
            foreach (string color in colors)
            {
                DropDownBackColor.Items.Add(color);
                DropDownBorderColor.Items.Add(color);
                DropDownInternalBorderColor.Items.Add(color);
                DropDownListActiveColor.Items.Add(color);
                DropDownListActiveHoverColor.Items.Add(color);
                DropDownListDisabledColor.Items.Add(color);
                DropDownSplitterBackColor.Items.Add(color);
            }

            string[] borderStyles = typeof(BorderStyle).GetEnumNames();
            foreach (string style in borderStyles)
            {
                DropDownBorderStyle.Items.Add(style);
                DropDownInternalBorderStyle.Items.Add(style);
            }

            FontFamily[] fonts = FontFamily.Families;
            foreach (FontFamily font in fonts)
            {
                DropDownFont.Items.Add(font.Name);
                DropDownWaitMessageFont.Items.Add(font.Name);
            }
        }

        protected void DropDownBackColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReportViewer1.BackColor = Color.FromName(DropDownBackColor.SelectedValue);
        }

        protected void DropDownBorderColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReportViewer1.BorderColor = Color.FromName(DropDownBorderColor.SelectedValue);
        }

        protected void DropDownBorderStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReportViewer1.BorderStyle = (BorderStyle)System.Enum.Parse(typeof(BorderStyle), DropDownBorderStyle.SelectedValue, true);
        }

        protected void TextBoxBorderWidth_TextChanged(object sender, EventArgs e)
        {
            ReportViewer1.BorderWidth = new Unit(TextBoxBorderWidth.Text);
        }

        protected void DropDownFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReportViewer1.Font.Name = DropDownFont.SelectedValue;
        }

        protected void TextBoxSize_TextChanged(object sender, EventArgs e)
        {
            ReportViewer1.Font.Size = new FontUnit(TextBoxSize.Text);
        }

        protected void CheckBoxBold_CheckedChanged(object sender, EventArgs e)
        {
            ReportViewer1.Font.Bold = CheckBoxBold.Checked;
        }

        protected void CheckBoxItalic_CheckedChanged(object sender, EventArgs e)
        {
            ReportViewer1.Font.Italic = CheckBoxItalic.Checked;
        }

        protected void CheckBoxOverLine_CheckedChanged(object sender, EventArgs e)
        {
            ReportViewer1.Font.Overline = CheckBoxOverLine.Checked;
        }

        protected void CheckBoxStrikeout_CheckedChanged(object sender, EventArgs e)
        {
            ReportViewer1.Font.Strikeout = CheckBoxStrikeout.Checked;
        }

        protected void CheckBoxUnderline_CheckedChanged(object sender, EventArgs e)
        {
            ReportViewer1.Font.Underline = CheckBoxUnderline.Checked;
        }

        protected void DropDownInternalBorderColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReportViewer1.InternalBorderColor = Color.FromName(DropDownInternalBorderColor.SelectedValue);
        }

        protected void DropDownInternalBorderStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReportViewer1.InternalBorderStyle = (BorderStyle)System.Enum.Parse(typeof(BorderStyle), DropDownInternalBorderStyle.SelectedValue, true);
        }

        protected void TextBoxInternalBorderWidth_TextChanged(object sender, EventArgs e)
        {
            ReportViewer1.InternalBorderWidth = new Unit(TextBoxInternalBorderWidth.Text);
        }

        protected void DropDownListActiveColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReportViewer1.LinkActiveColor = Color.FromName(DropDownListActiveColor.SelectedValue);
        }

        protected void DropDownListActiveHoverColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReportViewer1.LinkActiveHoverColor = Color.FromName(DropDownListActiveHoverColor.SelectedValue);
        }

        protected void DropDownListDisabledColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReportViewer1.LinkDisabledColor = Color.FromName(DropDownListDisabledColor.SelectedValue);
        }

        protected void DropDownSplitterBackColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReportViewer1.SplitterBackColor = Color.FromName(DropDownSplitterBackColor.SelectedValue);
        }

        protected void DropDownWaitMessageFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReportViewer1.WaitMessageFont.Name = DropDownWaitMessageFont.SelectedValue;
        }

        protected void TextBoxWaitMessageSize_TextChanged(object sender, EventArgs e)
        {
            ReportViewer1.WaitMessageFont.Size = new FontUnit(TextBoxWaitMessageSize.Text);
        }

        protected void CheckBoxWaitMessageBold_CheckedChanged(object sender, EventArgs e)
        {
            ReportViewer1.WaitMessageFont.Bold = CheckBoxWaitMessageBold.Checked;
        }

        protected void CheckBoxWaitMessageItalic_CheckedChanged(object sender, EventArgs e)
        {
            ReportViewer1.WaitMessageFont.Italic = CheckBoxWaitMessageItalic.Checked;
        }

        protected void CheckBoxWaitMessageOverLine_CheckedChanged(object sender, EventArgs e)
        {
            ReportViewer1.WaitMessageFont.Overline = CheckBoxWaitMessageOverLine.Checked;
        }

        protected void CheckBoxWaitMessageStrikeout_CheckedChanged(object sender, EventArgs e)
        {
            ReportViewer1.WaitMessageFont.Strikeout = CheckBoxWaitMessageStrikeout.Checked;
        }

        protected void CheckBoxWaitMessageUnderline_CheckedChanged(object sender, EventArgs e)
        {
            ReportViewer1.WaitMessageFont.Underline = CheckBoxWaitMessageUnderline.Checked;
        }
    }
}