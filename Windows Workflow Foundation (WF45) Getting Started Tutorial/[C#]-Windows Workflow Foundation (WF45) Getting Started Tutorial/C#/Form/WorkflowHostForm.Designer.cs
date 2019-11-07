namespace NumberGuessWorkflowHost
{
    partial class WorkflowHostForm
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
            this.NewGame = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.NumberRange = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.WorkflowType = new System.Windows.Forms.ComboBox();
            this.WorkflowVersion = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.InstanceId = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Guess = new System.Windows.Forms.TextBox();
            this.EnterGuess = new System.Windows.Forms.Button();
            this.QuitGame = new System.Windows.Forms.Button();
            this.WorkflowStatus = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // NewGame
            // 
            this.NewGame.Location = new System.Drawing.Point(13, 13);
            this.NewGame.Name = "NewGame";
            this.NewGame.Size = new System.Drawing.Size(75, 23);
            this.NewGame.TabIndex = 0;
            this.NewGame.Text = "New Game";
            this.NewGame.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Guess a number from 1 to";
            // 
            // NumberRange
            // 
            this.NumberRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NumberRange.FormattingEnabled = true;
            this.NumberRange.Items.AddRange(new object[] {
            "10",
            "100",
            "1000"});
            this.NumberRange.Location = new System.Drawing.Point(228, 12);
            this.NumberRange.Name = "NumberRange";
            this.NumberRange.Size = new System.Drawing.Size(143, 21);
            this.NumberRange.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Workflow type";
            // 
            // WorkflowType
            // 
            this.WorkflowType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WorkflowType.FormattingEnabled = true;
            this.WorkflowType.Items.AddRange(new object[] {
            "StateMachineNumberGuessWorkflow",
            "FlowchartNumberGuessWorkflow",
            "SequentialNumberGuessWorkflow"});
            this.WorkflowType.Location = new System.Drawing.Point(94, 40);
            this.WorkflowType.Name = "WorkflowType";
            this.WorkflowType.Size = new System.Drawing.Size(277, 21);
            this.WorkflowType.TabIndex = 4;
            // 
            // WorkflowVersion
            // 
            this.WorkflowVersion.AutoSize = true;
            this.WorkflowVersion.Location = new System.Drawing.Point(13, 362);
            this.WorkflowVersion.Name = "WorkflowVersion";
            this.WorkflowVersion.Size = new System.Drawing.Size(89, 13);
            this.WorkflowVersion.TabIndex = 5;
            this.WorkflowVersion.Text = "Workflow version";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.WorkflowStatus);
            this.groupBox1.Controls.Add(this.QuitGame);
            this.groupBox1.Controls.Add(this.EnterGuess);
            this.groupBox1.Controls.Add(this.Guess);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.InstanceId);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(13, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(358, 287);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Game";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Workflow Instance Id";
            // 
            // InstanceId
            // 
            this.InstanceId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.InstanceId.FormattingEnabled = true;
            this.InstanceId.Location = new System.Drawing.Point(121, 17);
            this.InstanceId.Name = "InstanceId";
            this.InstanceId.Size = new System.Drawing.Size(227, 21);
            this.InstanceId.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Guess";
            // 
            // Guess
            // 
            this.Guess.Location = new System.Drawing.Point(50, 44);
            this.Guess.Name = "Guess";
            this.Guess.Size = new System.Drawing.Size(65, 20);
            this.Guess.TabIndex = 3;
            // 
            // EnterGuess
            // 
            this.EnterGuess.Location = new System.Drawing.Point(121, 42);
            this.EnterGuess.Name = "EnterGuess";
            this.EnterGuess.Size = new System.Drawing.Size(75, 23);
            this.EnterGuess.TabIndex = 4;
            this.EnterGuess.Text = "Enter Guess";
            this.EnterGuess.UseVisualStyleBackColor = true;
            // 
            // QuitGame
            // 
            this.QuitGame.Location = new System.Drawing.Point(274, 42);
            this.QuitGame.Name = "QuitGame";
            this.QuitGame.Size = new System.Drawing.Size(75, 23);
            this.QuitGame.TabIndex = 5;
            this.QuitGame.Text = "Quit";
            this.QuitGame.UseVisualStyleBackColor = true;
            // 
            // WorkflowStatus
            // 
            this.WorkflowStatus.Location = new System.Drawing.Point(10, 73);
            this.WorkflowStatus.Multiline = true;
            this.WorkflowStatus.Name = "WorkflowStatus";
            this.WorkflowStatus.ReadOnly = true;
            this.WorkflowStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.WorkflowStatus.Size = new System.Drawing.Size(338, 208);
            this.WorkflowStatus.TabIndex = 6;
            // 
            // WorkflowHostForm
            // 
            this.AcceptButton = this.EnterGuess;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 382);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.WorkflowVersion);
            this.Controls.Add(this.WorkflowType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NumberRange);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NewGame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "WorkflowHostForm";
            this.Text = "WorkflowHostForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button NewGame;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox NumberRange;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox WorkflowType;
        private System.Windows.Forms.Label WorkflowVersion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox WorkflowStatus;
        private System.Windows.Forms.Button QuitGame;
        private System.Windows.Forms.Button EnterGuess;
        private System.Windows.Forms.TextBox Guess;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox InstanceId;
        private System.Windows.Forms.Label label3;
    }
}