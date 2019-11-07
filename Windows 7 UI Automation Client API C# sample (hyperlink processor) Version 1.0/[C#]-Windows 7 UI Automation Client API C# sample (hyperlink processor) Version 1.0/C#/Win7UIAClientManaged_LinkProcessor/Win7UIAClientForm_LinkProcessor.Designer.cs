namespace Win7UIAClientManaged
{
    partial class Win7UIAClientForm_LinkProcessor
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
            this.listViewLinks = new System.Windows.Forms.ListView();
            this.columnHeaderLinkName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelLinkCount = new System.Windows.Forms.Label();
            this.checkBoxUseCaching = new System.Windows.Forms.CheckBox();
            this.checkBoxSearchLinkChildren = new System.Windows.Forms.CheckBox();
            this.checkboxAlwaysOnTop = new System.Windows.Forms.CheckBox();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonInvoke = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonAddEventHandler = new System.Windows.Forms.Button();
            this.labelLinkCountValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listViewLinks
            // 
            this.listViewLinks.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewLinks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderLinkName});
            this.listViewLinks.Location = new System.Drawing.Point(13, 13);
            this.listViewLinks.Name = "listViewLinks";
            this.listViewLinks.Size = new System.Drawing.Size(352, 206);
            this.listViewLinks.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewLinks.TabIndex = 0;
            this.listViewLinks.UseCompatibleStateImageBehavior = false;
            this.listViewLinks.View = System.Windows.Forms.View.Details;
            this.listViewLinks.SelectedIndexChanged += new System.EventHandler(this.listViewLinks_SelectedIndexChanged);
            // 
            // columnHeaderLinkName
            // 
            this.columnHeaderLinkName.Text = "Hyperlink name";
            this.columnHeaderLinkName.Width = 260;
            // 
            // labelLinkCount
            // 
            this.labelLinkCount.AutoSize = true;
            this.labelLinkCount.Location = new System.Drawing.Point(13, 230);
            this.labelLinkCount.Name = "labelLinkCount";
            this.labelLinkCount.Size = new System.Drawing.Size(144, 13);
            this.labelLinkCount.TabIndex = 1;
            this.labelLinkCount.Text = "Numbers of hyperlinks found:";
            // 
            // checkBoxUseCaching
            // 
            this.checkBoxUseCaching.AutoSize = true;
            this.checkBoxUseCaching.Location = new System.Drawing.Point(16, 255);
            this.checkBoxUseCaching.Name = "checkBoxUseCaching";
            this.checkBoxUseCaching.Size = new System.Drawing.Size(110, 17);
            this.checkBoxUseCaching.TabIndex = 3;
            this.checkBoxUseCaching.Text = "&Use UIA caching.";
            this.checkBoxUseCaching.UseVisualStyleBackColor = true;
            this.checkBoxUseCaching.CheckedChanged += new System.EventHandler(this.checkBoxUseCaching_CheckedChanged);
            // 
            // checkBoxSearchLinkChildren
            // 
            this.checkBoxSearchLinkChildren.AutoSize = true;
            this.checkBoxSearchLinkChildren.Location = new System.Drawing.Point(16, 279);
            this.checkBoxSearchLinkChildren.Name = "checkBoxSearchLinkChildren";
            this.checkBoxSearchLinkChildren.Size = new System.Drawing.Size(192, 17);
            this.checkBoxSearchLinkChildren.TabIndex = 4;
            this.checkBoxSearchLinkChildren.Text = "&Search hyperlink children for name.";
            this.checkBoxSearchLinkChildren.UseVisualStyleBackColor = true;
            // 
            // checkboxAlwaysOnTop
            // 
            this.checkboxAlwaysOnTop.AutoSize = true;
            this.checkboxAlwaysOnTop.Location = new System.Drawing.Point(275, 255);
            this.checkboxAlwaysOnTop.Name = "checkboxAlwaysOnTop";
            this.checkboxAlwaysOnTop.Size = new System.Drawing.Size(95, 17);
            this.checkboxAlwaysOnTop.TabIndex = 5;
            this.checkboxAlwaysOnTop.Text = "Always on &top.";
            this.checkboxAlwaysOnTop.UseVisualStyleBackColor = true;
            this.checkboxAlwaysOnTop.CheckedChanged += new System.EventHandler(this.checkboxAlwaysOnTop_CheckedChanged);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(16, 314);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(60, 23);
            this.buttonRefresh.TabIndex = 6;
            this.buttonRefresh.Text = "&Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonInvoke
            // 
            this.buttonInvoke.Location = new System.Drawing.Point(82, 314);
            this.buttonInvoke.Name = "buttonInvoke";
            this.buttonInvoke.Size = new System.Drawing.Size(60, 23);
            this.buttonInvoke.TabIndex = 7;
            this.buttonInvoke.Text = "&Invoke";
            this.buttonInvoke.UseVisualStyleBackColor = true;
            this.buttonInvoke.Click += new System.EventHandler(this.buttonInvoke_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(305, 314);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(60, 23);
            this.buttonClose.TabIndex = 9;
            this.buttonClose.Text = "&Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonAddEventHandler
            // 
            this.buttonAddEventHandler.Location = new System.Drawing.Point(148, 314);
            this.buttonAddEventHandler.Name = "buttonAddEventHandler";
            this.buttonAddEventHandler.Size = new System.Drawing.Size(110, 23);
            this.buttonAddEventHandler.TabIndex = 8;
            this.buttonAddEventHandler.Text = "&Add Event Handler";
            this.buttonAddEventHandler.UseVisualStyleBackColor = true;
            this.buttonAddEventHandler.Click += new System.EventHandler(this.buttonAddEventHandler_Click);
            // 
            // labelLinkCountValue
            // 
            this.labelLinkCountValue.AutoSize = true;
            this.labelLinkCountValue.Location = new System.Drawing.Point(154, 230);
            this.labelLinkCountValue.Name = "labelLinkCountValue";
            this.labelLinkCountValue.Size = new System.Drawing.Size(13, 13);
            this.labelLinkCountValue.TabIndex = 2;
            this.labelLinkCountValue.Text = "0";
            // 
            // Win7UIAClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 349);
            this.Controls.Add(this.labelLinkCountValue);
            this.Controls.Add(this.buttonAddEventHandler);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonInvoke);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.checkboxAlwaysOnTop);
            this.Controls.Add(this.checkBoxSearchLinkChildren);
            this.Controls.Add(this.checkBoxUseCaching);
            this.Controls.Add(this.labelLinkCount);
            this.Controls.Add(this.listViewLinks);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Win7UIAClientForm";
            this.Text = "Windows 7 UIA Client (Managed) - Link Processor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewLinks;
        private System.Windows.Forms.Label labelLinkCount;
        private System.Windows.Forms.CheckBox checkBoxUseCaching;
        private System.Windows.Forms.CheckBox checkBoxSearchLinkChildren;
        private System.Windows.Forms.CheckBox checkboxAlwaysOnTop;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonInvoke;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonAddEventHandler;
        private System.Windows.Forms.ColumnHeader columnHeaderLinkName;
        private System.Windows.Forms.Label labelLinkCountValue;
    }
}

