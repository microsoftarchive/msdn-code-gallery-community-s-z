namespace WindowsApplication_cs
{
    partial class CustomerForm
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
            this.Label6 = new System.Windows.Forms.Label();
            this.txtZipCode = new System.Windows.Forms.TextBox();
            this.Button2 = new System.Windows.Forms.Button();
            this.cmdAccept = new System.Windows.Forms.Button();
            this.cboStates = new System.Windows.Forms.ComboBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(33, 199);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(49, 13);
            this.Label6.TabIndex = 27;
            this.Label6.Text = "Zip code";
            // 
            // txtZipCode
            // 
            this.txtZipCode.Location = new System.Drawing.Point(106, 195);
            this.txtZipCode.Name = "txtZipCode";
            this.txtZipCode.Size = new System.Drawing.Size(100, 20);
            this.txtZipCode.TabIndex = 26;
            // 
            // Button2
            // 
            this.Button2.Location = new System.Drawing.Point(230, 244);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(87, 43);
            this.Button2.TabIndex = 25;
            this.Button2.Text = "Cancel";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // cmdAccept
            // 
            this.cmdAccept.Location = new System.Drawing.Point(13, 244);
            this.cmdAccept.Name = "cmdAccept";
            this.cmdAccept.Size = new System.Drawing.Size(87, 43);
            this.cmdAccept.TabIndex = 24;
            this.cmdAccept.Text = "Accept";
            this.cmdAccept.UseVisualStyleBackColor = true;
            this.cmdAccept.Click += new System.EventHandler(this.cmdAccept_Click);
            // 
            // cboStates
            // 
            this.cboStates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStates.FormattingEnabled = true;
            this.cboStates.Location = new System.Drawing.Point(106, 156);
            this.cboStates.Name = "cboStates";
            this.cboStates.Size = new System.Drawing.Size(197, 21);
            this.cboStates.TabIndex = 23;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(50, 162);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(32, 13);
            this.Label5.TabIndex = 22;
            this.Label5.Text = "State";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(106, 122);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(197, 20);
            this.txtCity.TabIndex = 21;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(58, 125);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(24, 13);
            this.Label4.TabIndex = 20;
            this.Label4.Text = "City";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(106, 86);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(197, 20);
            this.txtAddress.TabIndex = 19;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(47, 93);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(35, 13);
            this.Label3.TabIndex = 18;
            this.Label3.Text = "Street";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(106, 49);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(197, 20);
            this.txtLastName.TabIndex = 17;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(26, 52);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(56, 13);
            this.Label2.TabIndex = 16;
            this.Label2.Text = "Last name";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(106, 12);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(197, 20);
            this.txtFirstName.TabIndex = 15;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(27, 15);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(55, 13);
            this.Label1.TabIndex = 14;
            this.Label1.Text = "First name";
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 299);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.txtZipCode);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.cmdAccept);
            this.Controls.Add(this.cboStates);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.Label1);
            this.Name = "CustomerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CustomerForm";
            this.Load += new System.EventHandler(this.CustomerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label6;
        public System.Windows.Forms.TextBox txtZipCode;
        internal System.Windows.Forms.Button Button2;
        internal System.Windows.Forms.Button cmdAccept;
        public System.Windows.Forms.ComboBox cboStates;
        internal System.Windows.Forms.Label Label5;
        public System.Windows.Forms.TextBox txtCity;
        internal System.Windows.Forms.Label Label4;
        public System.Windows.Forms.TextBox txtAddress;
        internal System.Windows.Forms.Label Label3;
        public System.Windows.Forms.TextBox txtLastName;
        internal System.Windows.Forms.Label Label2;
        public System.Windows.Forms.TextBox txtFirstName;
        internal System.Windows.Forms.Label Label1;
    }
}