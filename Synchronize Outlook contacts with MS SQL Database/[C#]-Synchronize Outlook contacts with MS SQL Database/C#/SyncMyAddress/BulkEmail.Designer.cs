namespace SyncMyAddress
{
    [System.ComponentModel.ToolboxItemAttribute(false)]
    partial class BulkEmail : Microsoft.Office.Tools.Outlook.FormRegionControl
    {
        public BulkEmail(Microsoft.Office.Interop.Outlook.FormRegion formRegion)
            : base(formRegion)
        {
            this.InitializeComponent();
        }

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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SendEmails = new System.Windows.Forms.Button();
            this.ContactsDataGridView = new System.Windows.Forms.DataGridView();
            this.CompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmailAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ContactsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // SendEmails
            // 
            this.SendEmails.Location = new System.Drawing.Point(152, 253);
            this.SendEmails.Name = "SendEmails";
            this.SendEmails.Size = new System.Drawing.Size(133, 29);
            this.SendEmails.TabIndex = 4;
            this.SendEmails.Text = "Send Emails";
            this.SendEmails.UseVisualStyleBackColor = true;
            this.SendEmails.Click += new System.EventHandler(this.SendEmails_Click);
            // 
            // ContactsDataGridView
            // 
            this.ContactsDataGridView.AllowUserToAddRows = false;
            this.ContactsDataGridView.AllowUserToDeleteRows = false;
            this.ContactsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CompanyName,
            this.EmailAddress});
            this.ContactsDataGridView.Location = new System.Drawing.Point(3, 3);
            this.ContactsDataGridView.Name = "ContactsDataGridView";
            this.ContactsDataGridView.RowHeadersVisible = false;
            this.ContactsDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ContactsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ContactsDataGridView.Size = new System.Drawing.Size(501, 244);
            this.ContactsDataGridView.TabIndex = 3;
            // 
            // CompanyName
            // 
            this.CompanyName.DataPropertyName = "CompanyName";
            this.CompanyName.HeaderText = "Company Name";
            this.CompanyName.Name = "CompanyName";
            // 
            // EmailAddress
            // 
            this.EmailAddress.DataPropertyName = "EmailAddress";
            this.EmailAddress.HeaderText = "Email Address";
            this.EmailAddress.Name = "EmailAddress";
            // 
            // BulkEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SendEmails);
            this.Controls.Add(this.ContactsDataGridView);
            this.Name = "BulkEmail";
            this.Size = new System.Drawing.Size(509, 287);
            this.FormRegionClosed += new System.EventHandler(this.BulkEmail_FormRegionClosed);
            this.FormRegionShowing += new System.EventHandler(this.BulkEmail_FormRegionShowing);
            ((System.ComponentModel.ISupportInitialize)(this.ContactsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        #region Form Region Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private static void InitializeManifest(Microsoft.Office.Tools.Outlook.FormRegionManifest manifest)
        {
            manifest.FormRegionName = "BulkEmail";
            manifest.ShowReadingPane = false;

        }

        #endregion

        internal System.Windows.Forms.Button SendEmails;
        internal System.Windows.Forms.DataGridView ContactsDataGridView;
        internal System.Windows.Forms.DataGridViewTextBoxColumn CompanyName;
        internal System.Windows.Forms.DataGridViewTextBoxColumn EmailAddress;


        public partial class BulkEmailFactory : Microsoft.Office.Tools.Outlook.IFormRegionFactory
        {
            public event System.EventHandler<Microsoft.Office.Tools.Outlook.FormRegionInitializingEventArgs> FormRegionInitializing;

            private Microsoft.Office.Tools.Outlook.FormRegionManifest _Manifest;

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public BulkEmailFactory()
            {
                this._Manifest = new Microsoft.Office.Tools.Outlook.FormRegionManifest();
                BulkEmail.InitializeManifest(this._Manifest);
                this.FormRegionInitializing += new System.EventHandler<Microsoft.Office.Tools.Outlook.FormRegionInitializingEventArgs>(this.BulkEmailFactory_FormRegionInitializing);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public Microsoft.Office.Tools.Outlook.FormRegionManifest Manifest
            {
                get
                {
                    return this._Manifest;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            Microsoft.Office.Tools.Outlook.IFormRegion Microsoft.Office.Tools.Outlook.IFormRegionFactory.CreateFormRegion(Microsoft.Office.Interop.Outlook.FormRegion formRegion)
            {
                BulkEmail form = new BulkEmail(formRegion);
                form.Factory = this;
                return form;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            byte[] Microsoft.Office.Tools.Outlook.IFormRegionFactory.GetFormRegionStorage(object outlookItem, Microsoft.Office.Interop.Outlook.OlFormRegionMode formRegionMode, Microsoft.Office.Interop.Outlook.OlFormRegionSize formRegionSize)
            {
                throw new System.NotSupportedException();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            bool Microsoft.Office.Tools.Outlook.IFormRegionFactory.IsDisplayedForItem(object outlookItem, Microsoft.Office.Interop.Outlook.OlFormRegionMode formRegionMode, Microsoft.Office.Interop.Outlook.OlFormRegionSize formRegionSize)
            {
                if (this.FormRegionInitializing != null)
                {
                    Microsoft.Office.Tools.Outlook.FormRegionInitializingEventArgs cancelArgs = new Microsoft.Office.Tools.Outlook.FormRegionInitializingEventArgs(outlookItem, formRegionMode, formRegionSize, false);
                    this.FormRegionInitializing(this, cancelArgs);
                    return !cancelArgs.Cancel;
                }
                else
                {
                    return true;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            string Microsoft.Office.Tools.Outlook.IFormRegionFactory.Kind
            {
                get
                {
                    return Microsoft.Office.Tools.Outlook.FormRegionKindConstants.WindowsForms;
                }
            }
        }
    }

    partial class WindowFormRegionCollection
    {
        internal BulkEmail BulkEmail
        {
            get
            {
                return this.FindFirst<BulkEmail>();
            }
        }
    }
}
