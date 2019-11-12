namespace SHANUExcelAddIn
{
    partial class ShanuExcelADDIn
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShanuExcelADDIn));
            this.txtActiveCellText = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.btnAddText = new System.Windows.Forms.Button();
            this.btnAddImage = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtActiveCellText
            // 
            this.txtActiveCellText.Location = new System.Drawing.Point(8, 40);
            this.txtActiveCellText.Name = "txtActiveCellText";
            this.txtActiveCellText.Size = new System.Drawing.Size(136, 21);
            this.txtActiveCellText.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightYellow;
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtItemName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(8, 160);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(136, 128);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Load DB Data";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.OliveDrab;
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(8, 73);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(120, 40);
            this.btnSearch.TabIndex = 256;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Item Name";
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(16, 40);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(100, 26);
            this.txtItemName.TabIndex = 0;
            // 
            // btnAddText
            // 
            this.btnAddText.BackColor = System.Drawing.Color.OliveDrab;
            this.btnAddText.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddText.BackgroundImage")));
            this.btnAddText.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddText.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddText.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.btnAddText.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btnAddText.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddText.Location = new System.Drawing.Point(7, 66);
            this.btnAddText.Name = "btnAddText";
            this.btnAddText.Size = new System.Drawing.Size(136, 40);
            this.btnAddText.TabIndex = 257;
            this.btnAddText.Text = "Add Text";
            this.btnAddText.UseVisualStyleBackColor = false;
            this.btnAddText.Click += new System.EventHandler(this.btnAddText_Click);
            // 
            // btnAddImage
            // 
            this.btnAddImage.BackColor = System.Drawing.Color.OliveDrab;
            this.btnAddImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddImage.BackgroundImage")));
            this.btnAddImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddImage.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnAddImage.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btnAddImage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddImage.Location = new System.Drawing.Point(8, 112);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(136, 40);
            this.btnAddImage.TabIndex = 258;
            this.btnAddImage.Text = "Add Image";
            this.btnAddImage.UseVisualStyleBackColor = false;
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("HY태백B", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.DarkGreen;
            this.label2.Location = new System.Drawing.Point(10, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 32);
            this.label2.TabIndex = 259;
            this.label2.Text = "SHANU";
            // 
            // ShanuExcelADDIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(172)))), ((int)(((byte)(91)))));
            this.Controls.Add(this.btnAddImage);
            this.Controls.Add(this.btnAddText);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtActiveCellText);
            this.Controls.Add(this.label2);
            this.Name = "ShanuExcelADDIn";
            this.Size = new System.Drawing.Size(150, 308);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtActiveCellText;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAddText;
        private System.Windows.Forms.Button btnAddImage;
        private System.Windows.Forms.Label label2;
    }
}
