namespace MSDN.Html.Client
{
    partial class EditorTestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            this.bToolbar = new System.Windows.Forms.Button();
            this.bEditHTML = new System.Windows.Forms.Button();
            this.bBackground = new System.Windows.Forms.Button();
            this.bForeground = new System.Windows.Forms.Button();
            this.bViewHtml = new System.Windows.Forms.Button();
            this.bStyle = new System.Windows.Forms.Button();
            this.readonlyCheck = new System.Windows.Forms.CheckBox();
            this.bOverWrite = new System.Windows.Forms.Button();
            this.bOpenHtml = new System.Windows.Forms.Button();
            this.bSaveHtml = new System.Windows.Forms.Button();
            this.listHeadings = new System.Windows.Forms.ComboBox();
            this.bHeading = new System.Windows.Forms.Button();
            this.bInsertHtml = new System.Windows.Forms.Button();
            this.bImage = new System.Windows.Forms.Button();
            this.bBasrHref = new System.Windows.Forms.Button();
            this.bPaste = new System.Windows.Forms.Button();
            this.bFormatted = new System.Windows.Forms.Button();
            this.bNormal = new System.Windows.Forms.Button();
            this.bScript = new System.Windows.Forms.Button();
            this.bMicrosoft = new System.Windows.Forms.Button();
            this.bLoadFile = new System.Windows.Forms.Button();
            this.bUrl = new System.Windows.Forms.Button();
            this.htmlEditorControl = new MSDN.Html.Editor.HtmlEditorControl();
            this.SuspendLayout();
            // 
            // bToolbar
            // 
            this.bToolbar.Location = new System.Drawing.Point(8, 64);
            this.bToolbar.Name = "bToolbar";
            this.bToolbar.Size = new System.Drawing.Size(75, 23);
            this.bToolbar.TabIndex = 2;
            this.bToolbar.Text = "Tool Bar";
            this.bToolbar.Click += new System.EventHandler(this.bToolbar_Click);
            // 
            // bEditHTML
            // 
            this.bEditHTML.Location = new System.Drawing.Point(8, 88);
            this.bEditHTML.Name = "bEditHTML";
            this.bEditHTML.Size = new System.Drawing.Size(75, 23);
            this.bEditHTML.TabIndex = 3;
            this.bEditHTML.Text = "Edit HTML";
            this.bEditHTML.Click += new System.EventHandler(this.bEditHTML_Click);
            // 
            // bBackground
            // 
            this.bBackground.Location = new System.Drawing.Point(8, 144);
            this.bBackground.Name = "bBackground";
            this.bBackground.Size = new System.Drawing.Size(75, 23);
            this.bBackground.TabIndex = 4;
            this.bBackground.Text = "Background";
            this.bBackground.Click += new System.EventHandler(this.bBackground_Click);
            // 
            // bForeground
            // 
            this.bForeground.Location = new System.Drawing.Point(8, 168);
            this.bForeground.Name = "bForeground";
            this.bForeground.Size = new System.Drawing.Size(75, 23);
            this.bForeground.TabIndex = 5;
            this.bForeground.Text = "Foreground";
            this.bForeground.Click += new System.EventHandler(this.bForeground_Click);
            // 
            // bViewHtml
            // 
            this.bViewHtml.Location = new System.Drawing.Point(8, 112);
            this.bViewHtml.Name = "bViewHtml";
            this.bViewHtml.Size = new System.Drawing.Size(75, 23);
            this.bViewHtml.TabIndex = 7;
            this.bViewHtml.Text = "View Html";
            this.bViewHtml.Click += new System.EventHandler(this.bViewHtml_Click);
            // 
            // bStyle
            // 
            this.bStyle.Location = new System.Drawing.Point(8, 8);
            this.bStyle.Name = "bStyle";
            this.bStyle.Size = new System.Drawing.Size(75, 23);
            this.bStyle.TabIndex = 8;
            this.bStyle.Text = "StyleSheet";
            this.bStyle.Click += new System.EventHandler(this.bStyle_Click);
            // 
            // readonlyCheck
            // 
            this.readonlyCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.readonlyCheck.Location = new System.Drawing.Point(880, 536);
            this.readonlyCheck.Name = "readonlyCheck";
            this.readonlyCheck.Size = new System.Drawing.Size(104, 24);
            this.readonlyCheck.TabIndex = 9;
            this.readonlyCheck.Text = "Read Only";
            this.readonlyCheck.CheckedChanged += new System.EventHandler(this.readonlyCheck_CheckedChanged);
            // 
            // bOverWrite
            // 
            this.bOverWrite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bOverWrite.Location = new System.Drawing.Point(792, 536);
            this.bOverWrite.Name = "bOverWrite";
            this.bOverWrite.Size = new System.Drawing.Size(75, 23);
            this.bOverWrite.TabIndex = 10;
            this.bOverWrite.Text = "OverWrite";
            this.bOverWrite.Click += new System.EventHandler(this.bOverWrite_Click);
            // 
            // bOpenHtml
            // 
            this.bOpenHtml.Location = new System.Drawing.Point(8, 256);
            this.bOpenHtml.Name = "bOpenHtml";
            this.bOpenHtml.Size = new System.Drawing.Size(75, 23);
            this.bOpenHtml.TabIndex = 12;
            this.bOpenHtml.Text = "Open Html";
            this.bOpenHtml.Click += new System.EventHandler(this.bOpenHtml_Click);
            // 
            // bSaveHtml
            // 
            this.bSaveHtml.Location = new System.Drawing.Point(8, 280);
            this.bSaveHtml.Name = "bSaveHtml";
            this.bSaveHtml.Size = new System.Drawing.Size(75, 23);
            this.bSaveHtml.TabIndex = 13;
            this.bSaveHtml.Text = "Save Html";
            this.bSaveHtml.Click += new System.EventHandler(this.bSaveHtml_Click);
            // 
            // listHeadings
            // 
            this.listHeadings.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listHeadings.FormattingEnabled = true;
            this.listHeadings.Items.AddRange(new object[] {
            "H1",
            "H2",
            "H3",
            "H4",
            "H5"});
            this.listHeadings.Location = new System.Drawing.Point(8, 360);
            this.listHeadings.MaxDropDownItems = 5;
            this.listHeadings.Name = "listHeadings";
            this.listHeadings.Size = new System.Drawing.Size(72, 21);
            this.listHeadings.TabIndex = 14;
            // 
            // bHeading
            // 
            this.bHeading.Location = new System.Drawing.Point(8, 384);
            this.bHeading.Name = "bHeading";
            this.bHeading.Size = new System.Drawing.Size(75, 23);
            this.bHeading.TabIndex = 15;
            this.bHeading.Text = "Set Heading";
            this.bHeading.Click += new System.EventHandler(this.bHeading_Click);
            // 
            // bInsertHtml
            // 
            this.bInsertHtml.Location = new System.Drawing.Point(8, 304);
            this.bInsertHtml.Name = "bInsertHtml";
            this.bInsertHtml.Size = new System.Drawing.Size(75, 23);
            this.bInsertHtml.TabIndex = 16;
            this.bInsertHtml.Text = "Insert Html";
            this.bInsertHtml.Click += new System.EventHandler(this.bInsertHtml_Click);
            // 
            // bImage
            // 
            this.bImage.Location = new System.Drawing.Point(8, 192);
            this.bImage.Name = "bImage";
            this.bImage.Size = new System.Drawing.Size(75, 23);
            this.bImage.TabIndex = 17;
            this.bImage.Text = "Local Image";
            this.bImage.Click += new System.EventHandler(this.bImage_Click);
            // 
            // bBasrHref
            // 
            this.bBasrHref.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bBasrHref.Location = new System.Drawing.Point(712, 536);
            this.bBasrHref.Name = "bBasrHref";
            this.bBasrHref.Size = new System.Drawing.Size(75, 23);
            this.bBasrHref.TabIndex = 18;
            this.bBasrHref.Text = "Word Wrap";
            this.bBasrHref.Click += new System.EventHandler(this.bBasrHref_Click);
            // 
            // bPaste
            // 
            this.bPaste.Location = new System.Drawing.Point(8, 328);
            this.bPaste.Name = "bPaste";
            this.bPaste.Size = new System.Drawing.Size(75, 23);
            this.bPaste.TabIndex = 19;
            this.bPaste.Text = "Insert Text";
            this.bPaste.Click += new System.EventHandler(this.bPaste_Click);
            // 
            // bFormatted
            // 
            this.bFormatted.Location = new System.Drawing.Point(8, 408);
            this.bFormatted.Name = "bFormatted";
            this.bFormatted.Size = new System.Drawing.Size(75, 23);
            this.bFormatted.TabIndex = 20;
            this.bFormatted.Text = "Formatted";
            this.bFormatted.Click += new System.EventHandler(this.bFormatted_Click);
            // 
            // bNormal
            // 
            this.bNormal.Location = new System.Drawing.Point(8, 432);
            this.bNormal.Name = "bNormal";
            this.bNormal.Size = new System.Drawing.Size(75, 23);
            this.bNormal.TabIndex = 21;
            this.bNormal.Text = "Normal";
            this.bNormal.Click += new System.EventHandler(this.bNormal_Click);
            // 
            // bScript
            // 
            this.bScript.Location = new System.Drawing.Point(8, 32);
            this.bScript.Name = "bScript";
            this.bScript.Size = new System.Drawing.Size(75, 23);
            this.bScript.TabIndex = 22;
            this.bScript.Text = "ScriptBlock";
            this.bScript.Click += new System.EventHandler(this.bScript_Click);
            // 
            // bMicrosoft
            // 
            this.bMicrosoft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bMicrosoft.Location = new System.Drawing.Point(552, 536);
            this.bMicrosoft.Name = "bMicrosoft";
            this.bMicrosoft.Size = new System.Drawing.Size(75, 23);
            this.bMicrosoft.TabIndex = 25;
            this.bMicrosoft.Text = "Microsoft";
            this.bMicrosoft.Click += new System.EventHandler(this.bMicrosoft_Click);
            // 
            // bLoadFile
            // 
            this.bLoadFile.Location = new System.Drawing.Point(8, 216);
            this.bLoadFile.Name = "bLoadFile";
            this.bLoadFile.Size = new System.Drawing.Size(75, 23);
            this.bLoadFile.TabIndex = 27;
            this.bLoadFile.Text = "Local File";
            this.bLoadFile.Click += new System.EventHandler(this.bLoadFile_Click);
            // 
            // bUrl
            // 
            this.bUrl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bUrl.Location = new System.Drawing.Point(472, 536);
            this.bUrl.Name = "bUrl";
            this.bUrl.Size = new System.Drawing.Size(75, 23);
            this.bUrl.TabIndex = 28;
            this.bUrl.Text = "Enter Href";
            this.bUrl.Click += new System.EventHandler(this.bUrl_Click);
            // 
            // htmlEditorControl
            // 
            this.htmlEditorControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.htmlEditorControl.InnerText = "Carl Nolan";
            this.htmlEditorControl.Location = new System.Drawing.Point(96, 8);
            this.htmlEditorControl.Name = "htmlEditorControl";
            this.htmlEditorControl.Size = new System.Drawing.Size(875, 520);
            this.htmlEditorControl.TabIndex = 26;
            this.htmlEditorControl.HtmlNavigation += new MSDN.Html.Editor.HtmlNavigationEventHandler(this.htmlEditorControl_HtmlNavigation);
            // 
            // EditorTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 566);
            this.Controls.Add(this.bUrl);
            this.Controls.Add(this.bLoadFile);
            this.Controls.Add(this.htmlEditorControl);
            this.Controls.Add(this.bMicrosoft);
            this.Controls.Add(this.bScript);
            this.Controls.Add(this.bNormal);
            this.Controls.Add(this.bFormatted);
            this.Controls.Add(this.bPaste);
            this.Controls.Add(this.bImage);
            this.Controls.Add(this.bInsertHtml);
            this.Controls.Add(this.bHeading);
            this.Controls.Add(this.listHeadings);
            this.Controls.Add(this.bSaveHtml);
            this.Controls.Add(this.bOpenHtml);
            this.Controls.Add(this.readonlyCheck);
            this.Controls.Add(this.bStyle);
            this.Controls.Add(this.bViewHtml);
            this.Controls.Add(this.bForeground);
            this.Controls.Add(this.bBackground);
            this.Controls.Add(this.bEditHTML);
            this.Controls.Add(this.bToolbar);
            this.Controls.Add(this.bBasrHref);
            this.Controls.Add(this.bOverWrite);
            this.Name = "EditorTestForm";
            this.Text = "Html Editor";
            this.Load += new System.EventHandler(this.EditorTestForm_Load);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Button bToolbar;
        private System.Windows.Forms.Button bBackground;
        private System.Windows.Forms.Button bForeground;
        private System.Windows.Forms.Button bEditHTML;
        private System.Windows.Forms.Button bViewHtml;
        private System.Windows.Forms.Button bStyle;
        private System.Windows.Forms.CheckBox readonlyCheck;
        private System.Windows.Forms.Button bOverWrite;
        private System.Windows.Forms.Button bOpenHtml;
        private System.Windows.Forms.Button bSaveHtml;
        private System.Windows.Forms.ComboBox listHeadings;
        private System.Windows.Forms.Button bHeading;
        private System.Windows.Forms.Button bInsertHtml;
        private System.Windows.Forms.Button bImage;
        private System.Windows.Forms.Button bBasrHref;
        private System.Windows.Forms.Button bPaste;
        private System.Windows.Forms.Button bFormatted;
        private System.Windows.Forms.Button bNormal;
        private System.Windows.Forms.Button bScript;
        private System.Windows.Forms.Button bMicrosoft;
        private System.Windows.Forms.Button bLoadFile;
        private System.Windows.Forms.Button bUrl;
        private MSDN.Html.Editor.HtmlEditorControl htmlEditorControl;

    }
}

