namespace tetris_cs
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Button1 = new System.Windows.Forms.Button();
            this.lblScore = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.game = new tetris_cs.game();
            this.shapePreview1 = new tetris_cs.ShapePreview();
            ((System.ComponentModel.ISupportInitialize)(this.game)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shapePreview1)).BeginInit();
            this.SuspendLayout();
            // 
            // Button1
            // 
            this.Button1.BackColor = System.Drawing.Color.Black;
            this.Button1.ForeColor = System.Drawing.Color.Silver;
            this.Button1.Location = new System.Drawing.Point(418, 523);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(75, 23);
            this.Button1.TabIndex = 7;
            this.Button1.Text = "New Game";
            this.Button1.UseVisualStyleBackColor = false;
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.ForeColor = System.Drawing.Color.Silver;
            this.lblScore.Location = new System.Drawing.Point(388, 334);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(84, 26);
            this.lblScore.TabIndex = 6;
            this.lblScore.Text = "000000";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Silver;
            this.Label1.Location = new System.Drawing.Point(366, 275);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(75, 26);
            this.Label1.TabIndex = 5;
            this.Label1.Text = "Score:";
            // 
            // game
            // 
            this.game.AllowUserToAddRows = false;
            this.game.AllowUserToDeleteRows = false;
            this.game.AllowUserToResizeColumns = false;
            this.game.AllowUserToResizeRows = false;
            this.game.BackgroundColor = System.Drawing.Color.Black;
            this.game.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.game.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.game.DefaultCellStyle = dataGridViewCellStyle1;
            this.game.GridColor = System.Drawing.Color.Black;
            this.game.Location = new System.Drawing.Point(62, 62);
            this.game.Name = "game";
            this.game.RowHeadersVisible = false;
            this.game.Size = new System.Drawing.Size(303, 453);
            this.game.TabIndex = 0;
            // 
            // shapePreview1
            // 
            this.shapePreview1.AllowUserToAddRows = false;
            this.shapePreview1.AllowUserToDeleteRows = false;
            this.shapePreview1.AllowUserToResizeColumns = false;
            this.shapePreview1.AllowUserToResizeRows = false;
            this.shapePreview1.BackgroundColor = System.Drawing.Color.Black;
            this.shapePreview1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.shapePreview1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.shapePreview1.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.shapePreview1.DefaultCellStyle = dataGridViewCellStyle2;
            this.shapePreview1.GridColor = System.Drawing.Color.Black;
            this.shapePreview1.Location = new System.Drawing.Point(383, 394);
            this.shapePreview1.Name = "ShapePreview1";
            this.shapePreview1.RowHeadersVisible = false;
            this.shapePreview1.Size = new System.Drawing.Size(91, 91);
            //this.ShapePreview1.TabIndex = 1;

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(551, 561);
            this.Controls.Add(this.shapePreview1);
            this.Controls.Add(this.game);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.Label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "tetris cs";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.game)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shapePreview1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.Label lblScore;
        internal System.Windows.Forms.Label Label1;
        private game game;
        private ShapePreview shapePreview1;
    }
}

