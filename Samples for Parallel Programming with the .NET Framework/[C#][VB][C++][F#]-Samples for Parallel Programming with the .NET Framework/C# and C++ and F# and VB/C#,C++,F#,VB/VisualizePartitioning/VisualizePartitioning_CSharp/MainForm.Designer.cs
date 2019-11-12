namespace VisualizePartitioning
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.pbPartitionedImage = new System.Windows.Forms.PictureBox();
            this.btnVisualize = new System.Windows.Forms.Button();
            this.lvPartitioningMethods = new System.Windows.Forms.ListView();
            this.lvWorkloads = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.tbWorkFactor = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.rbParallelFor = new System.Windows.Forms.RadioButton();
            this.rbParallelForEach = new System.Windows.Forms.RadioButton();
            this.rbPLINQ = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbCores = new System.Windows.Forms.TrackBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbPartitionedImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbWorkFactor)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbCores)).BeginInit();
            this.SuspendLayout();
            // 
            // pbPartitionedImage
            // 
            this.pbPartitionedImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbPartitionedImage.BackColor = System.Drawing.Color.Black;
            this.pbPartitionedImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbPartitionedImage.Location = new System.Drawing.Point(12, 12);
            this.pbPartitionedImage.Name = "pbPartitionedImage";
            this.pbPartitionedImage.Size = new System.Drawing.Size(539, 522);
            this.pbPartitionedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPartitionedImage.TabIndex = 0;
            this.pbPartitionedImage.TabStop = false;
            // 
            // btnVisualize
            // 
            this.btnVisualize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVisualize.Location = new System.Drawing.Point(557, 490);
            this.btnVisualize.Name = "btnVisualize";
            this.btnVisualize.Size = new System.Drawing.Size(75, 23);
            this.btnVisualize.TabIndex = 1;
            this.btnVisualize.Text = "Visualize";
            this.btnVisualize.UseVisualStyleBackColor = true;
            this.btnVisualize.Click += new System.EventHandler(this.btnVisualize_Click);
            // 
            // lvPartitioningMethods
            // 
            this.lvPartitioningMethods.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvPartitioningMethods.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lvPartitioningMethods.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lvPartitioningMethods.AutoArrange = false;
            this.lvPartitioningMethods.Enabled = false;
            this.lvPartitioningMethods.FullRowSelect = true;
            this.lvPartitioningMethods.GridLines = true;
            this.lvPartitioningMethods.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvPartitioningMethods.Location = new System.Drawing.Point(559, 127);
            this.lvPartitioningMethods.MultiSelect = false;
            this.lvPartitioningMethods.Name = "lvPartitioningMethods";
            this.lvPartitioningMethods.ShowGroups = false;
            this.lvPartitioningMethods.Size = new System.Drawing.Size(126, 150);
            this.lvPartitioningMethods.TabIndex = 2;
            this.lvPartitioningMethods.UseCompatibleStateImageBehavior = false;
            this.lvPartitioningMethods.View = System.Windows.Forms.View.List;
            // 
            // lvWorkloads
            // 
            this.lvWorkloads.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvWorkloads.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lvWorkloads.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lvWorkloads.AutoArrange = false;
            this.lvWorkloads.FullRowSelect = true;
            this.lvWorkloads.GridLines = true;
            this.lvWorkloads.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvWorkloads.HideSelection = false;
            this.lvWorkloads.Location = new System.Drawing.Point(559, 296);
            this.lvWorkloads.MultiSelect = false;
            this.lvWorkloads.Name = "lvWorkloads";
            this.lvWorkloads.ShowGroups = false;
            this.lvWorkloads.Size = new System.Drawing.Size(126, 77);
            this.lvWorkloads.TabIndex = 3;
            this.lvWorkloads.UseCompatibleStateImageBehavior = false;
            this.lvWorkloads.View = System.Windows.Forms.View.List;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(556, 280);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Workload";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(557, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Partitioning";
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(556, 516);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(36, 13);
            this.lblTime.TabIndex = 6;
            this.lblTime.Text = "Time: ";
            // 
            // tbWorkFactor
            // 
            this.tbWorkFactor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbWorkFactor.LargeChange = 1;
            this.tbWorkFactor.Location = new System.Drawing.Point(558, 408);
            this.tbWorkFactor.Maximum = 1000;
            this.tbWorkFactor.Minimum = 1;
            this.tbWorkFactor.Name = "tbWorkFactor";
            this.tbWorkFactor.Size = new System.Drawing.Size(123, 45);
            this.tbWorkFactor.TabIndex = 7;
            this.tbWorkFactor.TickFrequency = 100;
            this.tbWorkFactor.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbWorkFactor.Value = 1;
            this.tbWorkFactor.ValueChanged += new System.EventHandler(this.tbWorkFactor_ValueChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(557, 385);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Work Factor";
            // 
            // rbParallelFor
            // 
            this.rbParallelFor.AutoSize = true;
            this.rbParallelFor.Checked = true;
            this.rbParallelFor.Location = new System.Drawing.Point(7, 18);
            this.rbParallelFor.Name = "rbParallelFor";
            this.rbParallelFor.Size = new System.Drawing.Size(77, 17);
            this.rbParallelFor.TabIndex = 9;
            this.rbParallelFor.TabStop = true;
            this.rbParallelFor.Text = "Parallel.For";
            this.rbParallelFor.UseVisualStyleBackColor = true;
            this.rbParallelFor.CheckedChanged += new System.EventHandler(this.rbAPI_CheckedChanged);
            // 
            // rbParallelForEach
            // 
            this.rbParallelForEach.AutoSize = true;
            this.rbParallelForEach.Location = new System.Drawing.Point(6, 41);
            this.rbParallelForEach.Name = "rbParallelForEach";
            this.rbParallelForEach.Size = new System.Drawing.Size(102, 17);
            this.rbParallelForEach.TabIndex = 10;
            this.rbParallelForEach.TabStop = true;
            this.rbParallelForEach.Text = "Parallel.ForEach";
            this.rbParallelForEach.UseVisualStyleBackColor = true;
            this.rbParallelForEach.CheckedChanged += new System.EventHandler(this.rbAPI_CheckedChanged);
            // 
            // rbPLINQ
            // 
            this.rbPLINQ.AutoSize = true;
            this.rbPLINQ.Location = new System.Drawing.Point(6, 64);
            this.rbPLINQ.Name = "rbPLINQ";
            this.rbPLINQ.Size = new System.Drawing.Size(57, 17);
            this.rbPLINQ.TabIndex = 11;
            this.rbPLINQ.TabStop = true;
            this.rbPLINQ.Text = "PLINQ";
            this.rbPLINQ.UseVisualStyleBackColor = true;
            this.rbPLINQ.CheckedChanged += new System.EventHandler(this.rbAPI_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rbParallelForEach);
            this.groupBox1.Controls.Add(this.rbPLINQ);
            this.groupBox1.Controls.Add(this.rbParallelFor);
            this.groupBox1.Location = new System.Drawing.Point(557, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(130, 91);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "API";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(556, 436);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Cores";
            // 
            // tbCores
            // 
            this.tbCores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCores.LargeChange = 1;
            this.tbCores.Location = new System.Drawing.Point(557, 459);
            this.tbCores.Maximum = 100;
            this.tbCores.Minimum = 1;
            this.tbCores.Name = "tbCores";
            this.tbCores.Size = new System.Drawing.Size(123, 45);
            this.tbCores.TabIndex = 13;
            this.tbCores.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbCores.Value = 1;
            this.tbCores.ValueChanged += new System.EventHandler(this.tbCores_ValueChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 547);
            this.Controls.Add(this.btnVisualize);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbCores);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbWorkFactor);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvWorkloads);
            this.Controls.Add(this.lvPartitioningMethods);
            this.Controls.Add(this.pbPartitionedImage);
            this.Name = "MainForm";
            this.Text = "Visualize Partitioning";
            ((System.ComponentModel.ISupportInitialize)(this.pbPartitionedImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbWorkFactor)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbCores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPartitionedImage;
        private System.Windows.Forms.Button btnVisualize;
        private System.Windows.Forms.ListView lvPartitioningMethods;
        private System.Windows.Forms.ListView lvWorkloads;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.TrackBar tbWorkFactor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbParallelFor;
        private System.Windows.Forms.RadioButton rbParallelForEach;
        private System.Windows.Forms.RadioButton rbPLINQ;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar tbCores;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

