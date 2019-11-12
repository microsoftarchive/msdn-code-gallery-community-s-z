namespace ClosedXmlSample
{
    partial class FrmClosedXmlSample
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Liberare le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnNuovo = new System.Windows.Forms.Button();
            this.btnElimina = new System.Windows.Forms.Button();
            this.btnModifica = new System.Windows.Forms.Button();
            this.btnEsci = new System.Windows.Forms.Button();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblUserSurName = new System.Windows.Forms.Label();
            this.lblUserAddress = new System.Windows.Forms.Label();
            this.lblUserTelephoneNumber = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.lnationality = new System.Windows.Forms.Label();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtTelephoneNumber = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtNationality = new System.Windows.Forms.TextBox();
            this.dgvUserData = new System.Windows.Forms.DataGridView();
            this.cbxFind = new System.Windows.Forms.ComboBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.userDataSet = new ClosedXmlSample.UserDataSet();
            this.uSERDATABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uSERDATATableAdapter = new ClosedXmlSample.UserDataSetTableAdapters.USERDATATableAdapter();
            this.tableAdapterManager = new ClosedXmlSample.UserDataSetTableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSERDATABindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNuovo
            // 
            this.btnNuovo.Location = new System.Drawing.Point(10, 12);
            this.btnNuovo.Name = "btnNuovo";
            this.btnNuovo.Size = new System.Drawing.Size(75, 23);
            this.btnNuovo.TabIndex = 0;
            this.btnNuovo.Text = "New";
            this.btnNuovo.UseVisualStyleBackColor = true;
            this.btnNuovo.Click += new System.EventHandler(this.BtnNewClick);
            // 
            // btnElimina
            // 
            this.btnElimina.Location = new System.Drawing.Point(91, 12);
            this.btnElimina.Name = "btnElimina";
            this.btnElimina.Size = new System.Drawing.Size(75, 23);
            this.btnElimina.TabIndex = 1;
            this.btnElimina.Text = "Delete";
            this.btnElimina.UseVisualStyleBackColor = true;
            this.btnElimina.Click += new System.EventHandler(this.BtnDeleteClick);
            // 
            // btnModifica
            // 
            this.btnModifica.Location = new System.Drawing.Point(172, 12);
            this.btnModifica.Name = "btnModifica";
            this.btnModifica.Size = new System.Drawing.Size(75, 23);
            this.btnModifica.TabIndex = 2;
            this.btnModifica.Text = "Update";
            this.btnModifica.UseVisualStyleBackColor = true;
            this.btnModifica.Click += new System.EventHandler(this.BtnUpdateClick);
            // 
            // btnEsci
            // 
            this.btnEsci.Location = new System.Drawing.Point(510, 12);
            this.btnEsci.Name = "btnEsci";
            this.btnEsci.Size = new System.Drawing.Size(75, 23);
            this.btnEsci.TabIndex = 4;
            this.btnEsci.Text = "Exit";
            this.btnEsci.UseVisualStyleBackColor = true;
            this.btnEsci.Click += new System.EventHandler(this.BtnExitClick);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(9, 64);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(35, 13);
            this.lblUserName.TabIndex = 4;
            this.lblUserName.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(111, 61);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 5;
            // 
            // lblUserSurName
            // 
            this.lblUserSurName.AutoSize = true;
            this.lblUserSurName.Location = new System.Drawing.Point(9, 90);
            this.lblUserSurName.Name = "lblUserSurName";
            this.lblUserSurName.Size = new System.Drawing.Size(49, 13);
            this.lblUserSurName.TabIndex = 6;
            this.lblUserSurName.Text = "Surname";
            // 
            // lblUserAddress
            // 
            this.lblUserAddress.AutoSize = true;
            this.lblUserAddress.Location = new System.Drawing.Point(9, 116);
            this.lblUserAddress.Name = "lblUserAddress";
            this.lblUserAddress.Size = new System.Drawing.Size(45, 13);
            this.lblUserAddress.TabIndex = 7;
            this.lblUserAddress.Text = "Address";
            // 
            // lblUserTelephoneNumber
            // 
            this.lblUserTelephoneNumber.AutoSize = true;
            this.lblUserTelephoneNumber.Location = new System.Drawing.Point(9, 142);
            this.lblUserTelephoneNumber.Name = "lblUserTelephoneNumber";
            this.lblUserTelephoneNumber.Size = new System.Drawing.Size(96, 13);
            this.lblUserTelephoneNumber.TabIndex = 8;
            this.lblUserTelephoneNumber.Text = "Telephone number";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(10, 168);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(24, 13);
            this.lblCity.TabIndex = 10;
            this.lblCity.Text = "City";
            // 
            // lnationality
            // 
            this.lnationality.AutoSize = true;
            this.lnationality.Location = new System.Drawing.Point(10, 194);
            this.lnationality.Name = "lnationality";
            this.lnationality.Size = new System.Drawing.Size(56, 13);
            this.lnationality.TabIndex = 11;
            this.lnationality.Text = "Nationality";
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(111, 87);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(100, 20);
            this.txtSurname.TabIndex = 6;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(111, 113);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(192, 20);
            this.txtAddress.TabIndex = 7;
            // 
            // txtTelephoneNumber
            // 
            this.txtTelephoneNumber.Location = new System.Drawing.Point(111, 139);
            this.txtTelephoneNumber.Name = "txtTelephoneNumber";
            this.txtTelephoneNumber.Size = new System.Drawing.Size(100, 20);
            this.txtTelephoneNumber.TabIndex = 8;
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(111, 165);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(192, 20);
            this.txtCity.TabIndex = 9;
            // 
            // txtNationality
            // 
            this.txtNationality.Location = new System.Drawing.Point(111, 191);
            this.txtNationality.Name = "txtNationality";
            this.txtNationality.Size = new System.Drawing.Size(100, 20);
            this.txtNationality.TabIndex = 10;
            // 
            // dgvUserData
            // 
            this.dgvUserData.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvUserData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUserData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUserData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserData.Location = new System.Drawing.Point(13, 285);
            this.dgvUserData.Name = "dgvUserData";
            this.dgvUserData.Size = new System.Drawing.Size(659, 365);
            this.dgvUserData.TabIndex = 13;
            this.dgvUserData.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvUserDataRowHeaderMouseClick);
            // 
            // cbxFind
            // 
            this.cbxFind.FormattingEnabled = true;
            this.cbxFind.Items.AddRange(new object[] {
            "NAME",
            "SURNAME",
            "ADDRESS",
            "TELEPHONENUMBER",
            "CITY",
            "NATIONALITY"});
            this.cbxFind.Location = new System.Drawing.Point(348, 190);
            this.cbxFind.Name = "cbxFind";
            this.cbxFind.Size = new System.Drawing.Size(148, 21);
            this.cbxFind.TabIndex = 11;
            this.cbxFind.SelectedIndexChanged += new System.EventHandler(this.CbxFindSelectedIndexChanged);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(510, 188);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 12;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.BtnFindClick);
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(282, 12);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(88, 23);
            this.btnReport.TabIndex = 3;
            this.btnReport.Text = "Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.BtnReportClick);
            // 
            // userDataSet
            // 
            this.userDataSet.DataSetName = "UserDataSet";
            this.userDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // uSERDATABindingSource
            // 
            this.uSERDATABindingSource.DataMember = "USERDATA";
            this.uSERDATABindingSource.DataSource = this.userDataSet;
            // 
            // uSERDATATableAdapter
            // 
            this.uSERDATATableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.UpdateOrder = ClosedXmlSample.UserDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.USERDATATableAdapter = this.uSERDATATableAdapter;
            // 
            // FrmClosedXmlSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(692, 670);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.cbxFind);
            this.Controls.Add(this.dgvUserData);
            this.Controls.Add(this.txtNationality);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.txtTelephoneNumber);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.lnationality);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.lblUserTelephoneNumber);
            this.Controls.Add(this.lblUserAddress);
            this.Controls.Add(this.lblUserSurName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.btnEsci);
            this.Controls.Add(this.btnModifica);
            this.Controls.Add(this.btnElimina);
            this.Controls.Add(this.btnNuovo);
            this.Name = "FrmClosedXmlSample";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CLOSED XML SAMPLE";
            this.Load += new System.EventHandler(this.FrmClosedXmlSampleLoad);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSERDATABindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNuovo;
        private System.Windows.Forms.Button btnElimina;
        private System.Windows.Forms.Button btnModifica;
        private System.Windows.Forms.Button btnEsci;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblUserSurName;
        private System.Windows.Forms.Label lblUserAddress;
        private System.Windows.Forms.Label lblUserTelephoneNumber;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lnationality;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtTelephoneNumber;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtNationality;
        private System.Windows.Forms.DataGridView dgvUserData;
        private System.Windows.Forms.ComboBox cbxFind;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnReport;
        private UserDataSet userDataSet;
        private System.Windows.Forms.BindingSource uSERDATABindingSource;
        private UserDataSetTableAdapters.USERDATATableAdapter uSERDATATableAdapter;
        private UserDataSetTableAdapters.TableAdapterManager tableAdapterManager;
    }
}

