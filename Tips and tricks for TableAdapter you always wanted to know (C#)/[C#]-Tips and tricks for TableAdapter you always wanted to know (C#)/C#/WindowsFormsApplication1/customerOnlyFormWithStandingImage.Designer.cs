namespace WindowsFormsApplication1
{
    partial class customerOnlyFormWithStandingImage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(customerOnlyFormWithStandingImage));
            this.northWindDataSet = new WindowsFormsApplication1.NorthWindDataSet();
            this.customerWithStandingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.customerWithStandingTableAdapter = new WindowsFormsApplication1.NorthWindDataSetTableAdapters.CustomerWithStandingTableAdapter();
            this.tableAdapterManager = new WindowsFormsApplication1.NorthWindDataSetTableAdapters.TableAdapterManager();
            this.customerWithStandingBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.customerWithStandingBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.customerWithStandingDataGridView = new System.Windows.Forms.DataGridView();
            this.standingsImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.northWindDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerWithStandingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerWithStandingBindingNavigator)).BeginInit();
            this.customerWithStandingBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerWithStandingDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // northWindDataSet
            // 
            this.northWindDataSet.DataSetName = "NorthWindDataSet";
            this.northWindDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // customerWithStandingBindingSource
            // 
            this.customerWithStandingBindingSource.DataMember = "CustomerWithStanding";
            this.customerWithStandingBindingSource.DataSource = this.northWindDataSet;
            // 
            // customerWithStandingTableAdapter
            // 
            this.customerWithStandingTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.CustomersTableAdapter = null;
            this.tableAdapterManager.CustomerTypeTableAdapter = null;
            this.tableAdapterManager.OrdersTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = WindowsFormsApplication1.NorthWindDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // customerWithStandingBindingNavigator
            // 
            this.customerWithStandingBindingNavigator.AddNewItem = null;
            this.customerWithStandingBindingNavigator.BindingSource = this.customerWithStandingBindingSource;
            this.customerWithStandingBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.customerWithStandingBindingNavigator.DeleteItem = null;
            this.customerWithStandingBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.customerWithStandingBindingNavigatorSaveItem});
            this.customerWithStandingBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.customerWithStandingBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.customerWithStandingBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.customerWithStandingBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.customerWithStandingBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.customerWithStandingBindingNavigator.Name = "customerWithStandingBindingNavigator";
            this.customerWithStandingBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.customerWithStandingBindingNavigator.Size = new System.Drawing.Size(866, 25);
            this.customerWithStandingBindingNavigator.TabIndex = 0;
            this.customerWithStandingBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // customerWithStandingBindingNavigatorSaveItem
            // 
            this.customerWithStandingBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.customerWithStandingBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("customerWithStandingBindingNavigatorSaveItem.Image")));
            this.customerWithStandingBindingNavigatorSaveItem.Name = "customerWithStandingBindingNavigatorSaveItem";
            this.customerWithStandingBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.customerWithStandingBindingNavigatorSaveItem.Text = "Save Data";
            this.customerWithStandingBindingNavigatorSaveItem.Click += new System.EventHandler(this.customerWithStandingBindingNavigatorSaveItem_Click);
            // 
            // customerWithStandingDataGridView
            // 
            this.customerWithStandingDataGridView.AllowUserToAddRows = false;
            this.customerWithStandingDataGridView.AutoGenerateColumns = false;
            this.customerWithStandingDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerWithStandingDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.standingsImageColumn,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.customerWithStandingDataGridView.DataSource = this.customerWithStandingBindingSource;
            this.customerWithStandingDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customerWithStandingDataGridView.Location = new System.Drawing.Point(0, 25);
            this.customerWithStandingDataGridView.Name = "customerWithStandingDataGridView";
            this.customerWithStandingDataGridView.Size = new System.Drawing.Size(866, 333);
            this.customerWithStandingDataGridView.TabIndex = 1;
            // 
            // standingsImageColumn
            // 
            this.standingsImageColumn.DataPropertyName = "StandingImage";
            this.standingsImageColumn.Description = "Customer standing/ranking";
            this.standingsImageColumn.HeaderText = "";
            this.standingsImageColumn.Name = "standingsImageColumn";
            this.standingsImageColumn.ToolTipText = "Standings";
            this.standingsImageColumn.Width = 25;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CustomerIdentifier";
            this.dataGridViewTextBoxColumn1.HeaderText = "CustomerIdentifier";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "CompanyName";
            this.dataGridViewTextBoxColumn2.HeaderText = "Company";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ContactName";
            this.dataGridViewTextBoxColumn3.HeaderText = "Contact";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "ContactTitle";
            this.dataGridViewTextBoxColumn4.HeaderText = "Title";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Address";
            this.dataGridViewTextBoxColumn5.HeaderText = "Street";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "City";
            this.dataGridViewTextBoxColumn6.HeaderText = "City";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // customerOnlyFormWithStandingImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 358);
            this.Controls.Add(this.customerWithStandingDataGridView);
            this.Controls.Add(this.customerWithStandingBindingNavigator);
            this.Name = "customerOnlyFormWithStandingImage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sample (image from ref table unselectable - save/add/edit/delete disabled)";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.northWindDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerWithStandingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerWithStandingBindingNavigator)).EndInit();
            this.customerWithStandingBindingNavigator.ResumeLayout(false);
            this.customerWithStandingBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerWithStandingDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NorthWindDataSet northWindDataSet;
        private System.Windows.Forms.BindingSource customerWithStandingBindingSource;
        private NorthWindDataSetTableAdapters.CustomerWithStandingTableAdapter customerWithStandingTableAdapter;
        private NorthWindDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator customerWithStandingBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton customerWithStandingBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView customerWithStandingDataGridView;
        private System.Windows.Forms.DataGridViewImageColumn standingsImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }
}