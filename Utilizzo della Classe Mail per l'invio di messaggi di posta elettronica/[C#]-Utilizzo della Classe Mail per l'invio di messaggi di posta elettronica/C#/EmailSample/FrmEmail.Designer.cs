namespace EmailSample
{
    partial class FrmEmail
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
            this.btnEliminaContatti = new System.Windows.Forms.Button();
            this.btnAggiungi = new System.Windows.Forms.Button();
            this.txtAllegati = new System.Windows.Forms.TextBox();
            this.btnAllega = new System.Windows.Forms.Button();
            this.lblFrom = new System.Windows.Forms.Label();
            this.btnEsci = new System.Windows.Forms.Button();
            this.cbxCc = new System.Windows.Forms.ComboBox();
            this.cbxTo = new System.Windows.Forms.ComboBox();
            this.btnInvia = new System.Windows.Forms.Button();
            this.cbxServerPosta = new System.Windows.Forms.ComboBox();
            this.lblServerPosta = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblOggetto = new System.Windows.Forms.Label();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.txtOggetto = new System.Windows.Forms.TextBox();
            this.btnTo = new System.Windows.Forms.Button();
            this.btnCc = new System.Windows.Forms.Button();
            this.txtBody = new System.Windows.Forms.TextBox();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.txtCc = new System.Windows.Forms.TextBox();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnEliminaContatti
            // 
            this.btnEliminaContatti.Location = new System.Drawing.Point(12, 216);
            this.btnEliminaContatti.Name = "btnEliminaContatti";
            this.btnEliminaContatti.Size = new System.Drawing.Size(75, 52);
            this.btnEliminaContatti.TabIndex = 29;
            this.btnEliminaContatti.Text = "Enimina Contatti";
            this.btnEliminaContatti.UseVisualStyleBackColor = true;
            this.btnEliminaContatti.Click += new System.EventHandler(this.btnEliminaContatti_Click);
            // 
            // btnAggiungi
            // 
            this.btnAggiungi.Location = new System.Drawing.Point(12, 158);
            this.btnAggiungi.Name = "btnAggiungi";
            this.btnAggiungi.Size = new System.Drawing.Size(75, 52);
            this.btnAggiungi.TabIndex = 28;
            this.btnAggiungi.Text = "Aggiungi ai contatti";
            this.btnAggiungi.UseVisualStyleBackColor = true;
            this.btnAggiungi.Click += new System.EventHandler(this.btnAggiungi_Click);
            // 
            // txtAllegati
            // 
            this.txtAllegati.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAllegati.Location = new System.Drawing.Point(455, 206);
            this.txtAllegati.Name = "txtAllegati";
            this.txtAllegati.Size = new System.Drawing.Size(476, 20);
            this.txtAllegati.TabIndex = 38;
            // 
            // btnAllega
            // 
            this.btnAllega.Location = new System.Drawing.Point(293, 203);
            this.btnAllega.Name = "btnAllega";
            this.btnAllega.Size = new System.Drawing.Size(75, 23);
            this.btnAllega.TabIndex = 33;
            this.btnAllega.Text = "Allega";
            this.btnAllega.UseVisualStyleBackColor = true;
            this.btnAllega.Click += new System.EventHandler(this.btnAllega_Click);
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(33, 76);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(30, 13);
            this.lblFrom.TabIndex = 37;
            this.lblFrom.Text = "From";
            // 
            // btnEsci
            // 
            this.btnEsci.Location = new System.Drawing.Point(12, 12);
            this.btnEsci.Name = "btnEsci";
            this.btnEsci.Size = new System.Drawing.Size(75, 23);
            this.btnEsci.TabIndex = 34;
            this.btnEsci.Text = "Esci";
            this.btnEsci.UseVisualStyleBackColor = true;
            this.btnEsci.Click += new System.EventHandler(this.btnEsci_Click);
            // 
            // cbxCc
            // 
            this.cbxCc.FormattingEnabled = true;
            this.cbxCc.Location = new System.Drawing.Point(151, 102);
            this.cbxCc.Name = "cbxCc";
            this.cbxCc.Size = new System.Drawing.Size(172, 21);
            this.cbxCc.TabIndex = 22;
            this.cbxCc.SelectedIndexChanged += new System.EventHandler(this.cbxCc_SelectedIndexChanged);
            // 
            // cbxTo
            // 
            this.cbxTo.FormattingEnabled = true;
            this.cbxTo.Location = new System.Drawing.Point(151, 131);
            this.cbxTo.Name = "cbxTo";
            this.cbxTo.Size = new System.Drawing.Size(172, 21);
            this.cbxTo.TabIndex = 25;
            this.cbxTo.SelectedIndexChanged += new System.EventHandler(this.cbxTo_SelectedIndexChanged);
            // 
            // btnInvia
            // 
            this.btnInvia.Location = new System.Drawing.Point(374, 203);
            this.btnInvia.Name = "btnInvia";
            this.btnInvia.Size = new System.Drawing.Size(75, 23);
            this.btnInvia.TabIndex = 35;
            this.btnInvia.Text = "Invia";
            this.btnInvia.UseVisualStyleBackColor = true;
            this.btnInvia.Click += new System.EventHandler(this.btnInvia_Click);
            // 
            // cbxServerPosta
            // 
            this.cbxServerPosta.FormattingEnabled = true;
            this.cbxServerPosta.Items.AddRange(new object[] {
            "hotmail"});
            this.cbxServerPosta.Location = new System.Drawing.Point(686, 73);
            this.cbxServerPosta.Name = "cbxServerPosta";
            this.cbxServerPosta.Size = new System.Drawing.Size(185, 21);
            this.cbxServerPosta.TabIndex = 20;
            // 
            // lblServerPosta
            // 
            this.lblServerPosta.AutoSize = true;
            this.lblServerPosta.Location = new System.Drawing.Point(586, 76);
            this.lblServerPosta.Name = "lblServerPosta";
            this.lblServerPosta.Size = new System.Drawing.Size(79, 13);
            this.lblServerPosta.TabIndex = 31;
            this.lblServerPosta.Text = "Server di Posta";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(396, 76);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 30;
            this.lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Location = new System.Drawing.Point(455, 73);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(78, 20);
            this.txtPassword.TabIndex = 19;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblOggetto
            // 
            this.lblOggetto.AutoSize = true;
            this.lblOggetto.Location = new System.Drawing.Point(396, 173);
            this.lblOggetto.Name = "lblOggetto";
            this.lblOggetto.Size = new System.Drawing.Size(45, 13);
            this.lblOggetto.TabIndex = 26;
            this.lblOggetto.Text = "Oggetto";
            // 
            // ofd
            // 
            this.ofd.Multiselect = true;
            // 
            // txtOggetto
            // 
            this.txtOggetto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOggetto.Location = new System.Drawing.Point(455, 171);
            this.txtOggetto.Name = "txtOggetto";
            this.txtOggetto.Size = new System.Drawing.Size(476, 20);
            this.txtOggetto.TabIndex = 32;
            // 
            // btnTo
            // 
            this.btnTo.Location = new System.Drawing.Point(12, 129);
            this.btnTo.Name = "btnTo";
            this.btnTo.Size = new System.Drawing.Size(75, 23);
            this.btnTo.TabIndex = 24;
            this.btnTo.Text = "To";
            this.btnTo.UseVisualStyleBackColor = true;
            this.btnTo.Click += new System.EventHandler(this.btnTo_Click);
            // 
            // btnCc
            // 
            this.btnCc.Location = new System.Drawing.Point(12, 100);
            this.btnCc.Name = "btnCc";
            this.btnCc.Size = new System.Drawing.Size(75, 23);
            this.btnCc.TabIndex = 21;
            this.btnCc.Text = "Cc";
            this.btnCc.UseVisualStyleBackColor = true;
            this.btnCc.Click += new System.EventHandler(this.btnCc_Click);
            // 
            // txtBody
            // 
            this.txtBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBody.Location = new System.Drawing.Point(15, 273);
            this.txtBody.Multiline = true;
            this.txtBody.Name = "txtBody";
            this.txtBody.Size = new System.Drawing.Size(1577, 597);
            this.txtBody.TabIndex = 36;
            // 
            // txtTo
            // 
            this.txtTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTo.Location = new System.Drawing.Point(455, 131);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(1137, 20);
            this.txtTo.TabIndex = 27;
            // 
            // txtCc
            // 
            this.txtCc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCc.Location = new System.Drawing.Point(455, 102);
            this.txtCc.Name = "txtCc";
            this.txtCc.Size = new System.Drawing.Size(1137, 20);
            this.txtCc.TabIndex = 23;
            // 
            // txtFrom
            // 
            this.txtFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFrom.Location = new System.Drawing.Point(151, 73);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(172, 20);
            this.txtFrom.TabIndex = 18;
            // 
            // FrmEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1604, 882);
            this.Controls.Add(this.btnEliminaContatti);
            this.Controls.Add(this.btnAggiungi);
            this.Controls.Add(this.txtAllegati);
            this.Controls.Add(this.btnAllega);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.btnEsci);
            this.Controls.Add(this.cbxCc);
            this.Controls.Add(this.cbxTo);
            this.Controls.Add(this.btnInvia);
            this.Controls.Add(this.cbxServerPosta);
            this.Controls.Add(this.lblServerPosta);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblOggetto);
            this.Controls.Add(this.txtOggetto);
            this.Controls.Add(this.btnTo);
            this.Controls.Add(this.btnCc);
            this.Controls.Add(this.txtBody);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.txtCc);
            this.Controls.Add(this.txtFrom);
            this.Name = "FrmEmail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EMAIL SAMPLE";
            this.Load += new System.EventHandler(this.FrmEmail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnEliminaContatti;
        internal System.Windows.Forms.Button btnAggiungi;
        internal System.Windows.Forms.TextBox txtAllegati;
        internal System.Windows.Forms.Button btnAllega;
        internal System.Windows.Forms.Label lblFrom;
        internal System.Windows.Forms.Button btnEsci;
        internal System.Windows.Forms.ComboBox cbxCc;
        internal System.Windows.Forms.ComboBox cbxTo;
        internal System.Windows.Forms.Button btnInvia;
        internal System.Windows.Forms.ComboBox cbxServerPosta;
        internal System.Windows.Forms.Label lblServerPosta;
        internal System.Windows.Forms.Label lblPassword;
        internal System.Windows.Forms.TextBox txtPassword;
        internal System.Windows.Forms.Label lblOggetto;
        internal System.Windows.Forms.OpenFileDialog ofd;
        internal System.Windows.Forms.TextBox txtOggetto;
        internal System.Windows.Forms.Button btnTo;
        internal System.Windows.Forms.Button btnCc;
        internal System.Windows.Forms.TextBox txtBody;
        internal System.Windows.Forms.TextBox txtTo;
        internal System.Windows.Forms.TextBox txtCc;
        internal System.Windows.Forms.TextBox txtFrom;
    }
}

