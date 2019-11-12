namespace ShanuSPCCpCPK_Demo
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtusl = new System.Windows.Forms.TextBox();
            this.txtData = new System.Windows.Forms.TextBox();
            this.txtLSL = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRealTime = new System.Windows.Forms.Button();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.Label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.shanuCPCPKChart = new ShanuCPCPKChart.ShanuCPCPKChart();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.txtWaterMark = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.Panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnRealTime);
            this.panel1.Controls.Add(this.Panel4);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1313, 208);
            this.panel1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtWaterMark);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtusl);
            this.groupBox1.Controls.Add(this.txtData);
            this.groupBox1.Controls.Add(this.txtLSL);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(8, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(176, 160);
            this.groupBox1.TabIndex = 128;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "USL/LSL Setting";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.SteelBlue;
            this.label4.Location = new System.Drawing.Point(0, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 37);
            this.label4.TabIndex = 118;
            this.label4.Text = "Cpk Limit";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.SteelBlue;
            this.label3.Location = new System.Drawing.Point(4, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 22);
            this.label3.TabIndex = 117;
            this.label3.Text = "LSL";
            // 
            // txtusl
            // 
            this.txtusl.BackColor = System.Drawing.Color.White;
            this.txtusl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtusl.Location = new System.Drawing.Point(88, 64);
            this.txtusl.MaxLength = 6;
            this.txtusl.Name = "txtusl";
            this.txtusl.Size = new System.Drawing.Size(80, 21);
            this.txtusl.TabIndex = 116;
            this.txtusl.Text = "2.27";
            // 
            // txtData
            // 
            this.txtData.BackColor = System.Drawing.Color.White;
            this.txtData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtData.Location = new System.Drawing.Point(88, 128);
            this.txtData.MaxLength = 6;
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(84, 21);
            this.txtData.TabIndex = 115;
            this.txtData.Text = "1.33";
            // 
            // txtLSL
            // 
            this.txtLSL.BackColor = System.Drawing.Color.White;
            this.txtLSL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLSL.Location = new System.Drawing.Point(88, 94);
            this.txtLSL.MaxLength = 6;
            this.txtLSL.Name = "txtLSL";
            this.txtLSL.Size = new System.Drawing.Size(80, 21);
            this.txtLSL.TabIndex = 114;
            this.txtLSL.Text = "1.26";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(5, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "USL";
            // 
            // btnRealTime
            // 
            this.btnRealTime.BackColor = System.Drawing.Color.AliceBlue;
            this.btnRealTime.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRealTime.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnRealTime.Location = new System.Drawing.Point(192, 112);
            this.btnRealTime.Name = "btnRealTime";
            this.btnRealTime.Size = new System.Drawing.Size(200, 80);
            this.btnRealTime.TabIndex = 127;
            this.btnRealTime.Text = "Real Time Data ON";
            this.btnRealTime.UseVisualStyleBackColor = false;
            this.btnRealTime.Click += new System.EventHandler(this.btnRealTime_Click);
            // 
            // Panel4
            // 
            this.Panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Panel4.BackgroundImage")));
            this.Panel4.Controls.Add(this.Label1);
            this.Panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel4.Location = new System.Drawing.Point(0, 0);
            this.Panel4.Name = "Panel4";
            this.Panel4.Size = new System.Drawing.Size(1313, 29);
            this.Panel4.TabIndex = 126;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Yellow;
            this.Label1.Location = new System.Drawing.Point(416, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(291, 24);
            this.Label1.TabIndex = 47;
            this.Label1.Text = "Shanu - SPC Cp / Cpk CHART";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(400, 32);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(880, 160);
            this.dataGridView1.TabIndex = 125;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.AliceBlue;
            this.button1.Font = new System.Drawing.Font("굴림", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.ForeColor = System.Drawing.Color.DarkGreen;
            this.button1.Location = new System.Drawing.Point(192, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 80);
            this.button1.TabIndex = 124;
            this.button1.Text = "Manual Data";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // shanuCPCPKChart
            // 
            this.shanuCPCPKChart.CokPpkValue = 1.33D;
            this.shanuCPCPKChart.Location = new System.Drawing.Point(48, 216);
            this.shanuCPCPKChart.LSL = 0D;
            this.shanuCPCPKChart.Name = "shanuCPCPKChart";
            this.shanuCPCPKChart.Size = new System.Drawing.Size(1135, 560);
            this.shanuCPCPKChart.TabIndex = 3;
            this.shanuCPCPKChart.USL = 0D;
            // 
            // timer1
            // 
            this.timer1.Interval = 900;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtWaterMark
            // 
            this.txtWaterMark.Location = new System.Drawing.Point(8, 24);
            this.txtWaterMark.Multiline = true;
            this.txtWaterMark.Name = "txtWaterMark";
            this.txtWaterMark.Size = new System.Drawing.Size(160, 21);
            this.txtWaterMark.TabIndex = 119;
            this.txtWaterMark.Text = "Shanu SPC Chart";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1313, 810);
            this.Controls.Add(this.shanuCPCPKChart);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Shanu SPC Cp,Cpk Chart Control";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Panel4.ResumeLayout(false);
            this.Panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtusl;
        internal System.Windows.Forms.TextBox txtData;
        internal System.Windows.Forms.TextBox txtLSL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRealTime;
        internal System.Windows.Forms.Panel Panel4;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private ShanuCPCPKChart.ShanuCPCPKChart shanuCPCPKChart;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.TextBox txtWaterMark;
    }
}

