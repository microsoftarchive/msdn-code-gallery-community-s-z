namespace winforCongitiveTexttoSpeech
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
			this.cboServiceName = new System.Windows.Forms.ComboBox();
			this.txtSpeak = new System.Windows.Forms.TextBox();
			this.btnSpeak = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.cboLocale = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtstatus = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// cboServiceName
			// 
			this.cboServiceName.FormattingEnabled = true;
			this.cboServiceName.Items.AddRange(new object[] {
            "Microsoft Server Speech Text to Speech Voice (en-US, ZiraRUS)",
            "Microsoft Server Speech Text to Speech Voice (ko-KR, HeamiRUS)",
            "Microsoft Server Speech Text to Speech Voice (ta-IN, Valluvar)"});
			this.cboServiceName.Location = new System.Drawing.Point(440, 12);
			this.cboServiceName.Name = "cboServiceName";
			this.cboServiceName.Size = new System.Drawing.Size(608, 20);
			this.cboServiceName.TabIndex = 7;
			this.cboServiceName.SelectedIndexChanged += new System.EventHandler(this.cboServiceName_SelectedIndexChanged);
			// 
			// txtSpeak
			// 
			this.txtSpeak.Font = new System.Drawing.Font("Gulim", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.txtSpeak.Location = new System.Drawing.Point(88, 49);
			this.txtSpeak.Multiline = true;
			this.txtSpeak.Name = "txtSpeak";
			this.txtSpeak.Size = new System.Drawing.Size(960, 257);
			this.txtSpeak.TabIndex = 5;
			this.txtSpeak.Text = "Welcome to Shanu Text to Speech world using Cognitive Service API";
			// 
			// btnSpeak
			// 
			this.btnSpeak.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.btnSpeak.Location = new System.Drawing.Point(644, 312);
			this.btnSpeak.Name = "btnSpeak";
			this.btnSpeak.Size = new System.Drawing.Size(404, 87);
			this.btnSpeak.TabIndex = 4;
			this.btnSpeak.Text = "Click me to Save the Speech and  Speak the Text";
			this.btnSpeak.UseVisualStyleBackColor = true;
			this.btnSpeak.Click += new System.EventHandler(this.btnSpeak_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label1.Location = new System.Drawing.Point(93, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(49, 12);
			this.label1.TabIndex = 8;
			this.label1.Text = "Locale";
			// 
			// cboLocale
			// 
			this.cboLocale.FormattingEnabled = true;
			this.cboLocale.Items.AddRange(new object[] {
            "en-US",
            "ko-KR",
            "ta-IN"});
			this.cboLocale.Location = new System.Drawing.Point(145, 12);
			this.cboLocale.Name = "cboLocale";
			this.cboLocale.Size = new System.Drawing.Size(121, 20);
			this.cboLocale.TabIndex = 9;
			this.cboLocale.SelectedIndexChanged += new System.EventHandler(this.cboLocale_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label3.Location = new System.Drawing.Point(279, 17);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(156, 12);
			this.label3.TabIndex = 11;
			this.label3.Text = "Service name mapping";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label4.Location = new System.Drawing.Point(8, 148);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(73, 12);
			this.label4.TabIndex = 12;
			this.label4.Text = "Enter Text";
			// 
			// txtstatus
			// 
			this.txtstatus.Location = new System.Drawing.Point(88, 313);
			this.txtstatus.Multiline = true;
			this.txtstatus.Name = "txtstatus";
			this.txtstatus.Size = new System.Drawing.Size(550, 87);
			this.txtstatus.TabIndex = 14;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label5.Location = new System.Drawing.Point(8, 350);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(46, 12);
			this.label5.TabIndex = 15;
			this.label5.Text = "Status";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(1060, 415);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtstatus);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cboLocale);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cboServiceName);
			this.Controls.Add(this.txtSpeak);
			this.Controls.Add(this.btnSpeak);
			this.Name = "Form1";
			this.Text = "Shanu Text to Speach using Conginitive Service API";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cboServiceName;
		private System.Windows.Forms.TextBox txtSpeak;
		private System.Windows.Forms.Button btnSpeak;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cboLocale;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtstatus;
		private System.Windows.Forms.Label label5;
	}
}

