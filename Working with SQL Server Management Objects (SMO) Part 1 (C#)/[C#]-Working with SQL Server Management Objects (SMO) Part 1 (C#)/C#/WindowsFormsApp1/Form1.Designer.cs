namespace WindowsFormsApp1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.lstDatabaseNames = new System.Windows.Forms.ListBox();
            this.lstTableNames = new System.Windows.Forms.ListBox();
            this.lstColumnNames = new System.Windows.Forms.ListBox();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.cmdSpecialLoader = new System.Windows.Forms.Button();
            this.cmdGetForeignDetails = new System.Windows.Forms.Button();
            this.cmdColumnDetails = new System.Windows.Forms.Button();
            this.cmdLoadColumnNamesForSelectedTable = new System.Windows.Forms.Button();
            this.cmdLoadTableNamesForSelectedDatabaseName = new System.Windows.Forms.Button();
            this.cmdLoadDatabaseNames = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(1005, 398);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lstDatabaseNames
            // 
            this.lstDatabaseNames.FormattingEnabled = true;
            this.lstDatabaseNames.Location = new System.Drawing.Point(9, 15);
            this.lstDatabaseNames.Name = "lstDatabaseNames";
            this.lstDatabaseNames.Size = new System.Drawing.Size(218, 316);
            this.lstDatabaseNames.TabIndex = 0;
            // 
            // lstTableNames
            // 
            this.lstTableNames.FormattingEnabled = true;
            this.lstTableNames.Location = new System.Drawing.Point(240, 15);
            this.lstTableNames.Name = "lstTableNames";
            this.lstTableNames.Size = new System.Drawing.Size(232, 316);
            this.lstTableNames.TabIndex = 1;
            // 
            // lstColumnNames
            // 
            this.lstColumnNames.FormattingEnabled = true;
            this.lstColumnNames.Location = new System.Drawing.Point(478, 15);
            this.lstColumnNames.Name = "lstColumnNames";
            this.lstColumnNames.Size = new System.Drawing.Size(230, 316);
            this.lstColumnNames.TabIndex = 2;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Location = new System.Drawing.Point(714, 15);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(366, 312);
            this.propertyGrid1.TabIndex = 10;
            this.propertyGrid1.ToolbarVisible = false;
            // 
            // cmdSpecialLoader
            // 
            this.cmdSpecialLoader.Image = global::WindowsFormsApp1.Properties.Resources.View_16x;
            this.cmdSpecialLoader.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSpecialLoader.Location = new System.Drawing.Point(9, 371);
            this.cmdSpecialLoader.Name = "cmdSpecialLoader";
            this.cmdSpecialLoader.Size = new System.Drawing.Size(218, 23);
            this.cmdSpecialLoader.TabIndex = 4;
            this.cmdSpecialLoader.Text = "Karen\'s loader";
            this.cmdSpecialLoader.UseVisualStyleBackColor = true;
            this.cmdSpecialLoader.Click += new System.EventHandler(this.cmdSpecialLoader_Click);
            // 
            // cmdGetForeignDetails
            // 
            this.cmdGetForeignDetails.Image = global::WindowsFormsApp1.Properties.Resources.SQLLibrary_16x;
            this.cmdGetForeignDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdGetForeignDetails.Location = new System.Drawing.Point(240, 371);
            this.cmdGetForeignDetails.Name = "cmdGetForeignDetails";
            this.cmdGetForeignDetails.Size = new System.Drawing.Size(232, 23);
            this.cmdGetForeignDetails.TabIndex = 6;
            this.cmdGetForeignDetails.Text = "Get foreign key details";
            this.cmdGetForeignDetails.UseVisualStyleBackColor = true;
            this.cmdGetForeignDetails.Click += new System.EventHandler(this.cmdGetForeignDetails_Click);
            // 
            // cmdColumnDetails
            // 
            this.cmdColumnDetails.Image = global::WindowsFormsApp1.Properties.Resources.ColumnDetail_16x;
            this.cmdColumnDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdColumnDetails.Location = new System.Drawing.Point(714, 342);
            this.cmdColumnDetails.Name = "cmdColumnDetails";
            this.cmdColumnDetails.Size = new System.Drawing.Size(232, 23);
            this.cmdColumnDetails.TabIndex = 7;
            this.cmdColumnDetails.Text = "Get column details";
            this.cmdColumnDetails.UseVisualStyleBackColor = true;
            this.cmdColumnDetails.Click += new System.EventHandler(this.cmdColumnDetails_Click);
            // 
            // cmdLoadColumnNamesForSelectedTable
            // 
            this.cmdLoadColumnNamesForSelectedTable.Image = global::WindowsFormsApp1.Properties.Resources.SQLField_16x;
            this.cmdLoadColumnNamesForSelectedTable.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdLoadColumnNamesForSelectedTable.Location = new System.Drawing.Point(476, 342);
            this.cmdLoadColumnNamesForSelectedTable.Name = "cmdLoadColumnNamesForSelectedTable";
            this.cmdLoadColumnNamesForSelectedTable.Size = new System.Drawing.Size(232, 23);
            this.cmdLoadColumnNamesForSelectedTable.TabIndex = 8;
            this.cmdLoadColumnNamesForSelectedTable.Text = "Load column names for selected table";
            this.cmdLoadColumnNamesForSelectedTable.UseVisualStyleBackColor = true;
            this.cmdLoadColumnNamesForSelectedTable.Click += new System.EventHandler(this.cmdLoadColumnNamesForSelectedTable_Click);
            // 
            // cmdLoadTableNamesForSelectedDatabaseName
            // 
            this.cmdLoadTableNamesForSelectedDatabaseName.Image = global::WindowsFormsApp1.Properties.Resources.SQLSecurityPolicyTableSlider_16x;
            this.cmdLoadTableNamesForSelectedDatabaseName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdLoadTableNamesForSelectedDatabaseName.Location = new System.Drawing.Point(240, 342);
            this.cmdLoadTableNamesForSelectedDatabaseName.Name = "cmdLoadTableNamesForSelectedDatabaseName";
            this.cmdLoadTableNamesForSelectedDatabaseName.Size = new System.Drawing.Size(232, 23);
            this.cmdLoadTableNamesForSelectedDatabaseName.TabIndex = 5;
            this.cmdLoadTableNamesForSelectedDatabaseName.Text = "Load table names for selected database";
            this.cmdLoadTableNamesForSelectedDatabaseName.UseVisualStyleBackColor = true;
            this.cmdLoadTableNamesForSelectedDatabaseName.Click += new System.EventHandler(this.cmdLoadTableNamesForSelectedDatabaseName_Click);
            // 
            // cmdLoadDatabaseNames
            // 
            this.cmdLoadDatabaseNames.Image = global::WindowsFormsApp1.Properties.Resources.SQLDatabase_16x;
            this.cmdLoadDatabaseNames.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdLoadDatabaseNames.Location = new System.Drawing.Point(9, 342);
            this.cmdLoadDatabaseNames.Name = "cmdLoadDatabaseNames";
            this.cmdLoadDatabaseNames.Size = new System.Drawing.Size(218, 23);
            this.cmdLoadDatabaseNames.TabIndex = 3;
            this.cmdLoadDatabaseNames.Text = "Load database names from server";
            this.cmdLoadDatabaseNames.UseVisualStyleBackColor = true;
            this.cmdLoadDatabaseNames.Click += new System.EventHandler(this.cmdLoadDatabaseNames_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 432);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.cmdSpecialLoader);
            this.Controls.Add(this.cmdGetForeignDetails);
            this.Controls.Add(this.cmdColumnDetails);
            this.Controls.Add(this.cmdLoadColumnNamesForSelectedTable);
            this.Controls.Add(this.lstColumnNames);
            this.Controls.Add(this.cmdLoadTableNamesForSelectedDatabaseName);
            this.Controls.Add(this.lstTableNames);
            this.Controls.Add(this.cmdLoadDatabaseNames);
            this.Controls.Add(this.lstDatabaseNames);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Code sample [smo]";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox lstDatabaseNames;
        private System.Windows.Forms.Button cmdLoadDatabaseNames;
        private System.Windows.Forms.ListBox lstTableNames;
        private System.Windows.Forms.Button cmdLoadTableNamesForSelectedDatabaseName;
        private System.Windows.Forms.ListBox lstColumnNames;
        private System.Windows.Forms.Button cmdLoadColumnNamesForSelectedTable;
        private System.Windows.Forms.Button cmdColumnDetails;
        private System.Windows.Forms.Button cmdGetForeignDetails;
        private System.Windows.Forms.Button cmdSpecialLoader;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
    }
}

