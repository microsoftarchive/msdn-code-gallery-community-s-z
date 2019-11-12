<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.MasterBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.MasterBindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.MasterBindingNavigatorDeleteCustomer = New System.Windows.Forms.ToolStripButton()
        Me.MasterBindingNavigatorEditCustomer = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.OrderDetailsDataGridView = New System.Windows.Forms.DataGridView()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.MasterDataGridView = New System.Windows.Forms.DataGridView()
        Me.DetailsDataGridView = New System.Windows.Forms.DataGridView()
        Me.OrderIdColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomerIdColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrderDateColumn = New DataGridViewCalendarLibrary.CalendarColumn()
        Me.InvoiceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UpdateButtonColumn = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.DetailBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem1 = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem1 = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem1 = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem1 = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem1 = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem1 = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.DetailsBindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.DetailsBindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
        CType(Me.MasterBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MasterBindingNavigator.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.OrderDetailsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.MasterDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DetailsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DetailBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DetailBindingNavigator.SuspendLayout()
        Me.SuspendLayout()
        '
        'MasterBindingNavigator
        '
        Me.MasterBindingNavigator.AddNewItem = Nothing
        Me.MasterBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.MasterBindingNavigator.DeleteItem = Nothing
        Me.MasterBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.MasterBindingNavigatorAddNewItem, Me.MasterBindingNavigatorDeleteCustomer, Me.MasterBindingNavigatorEditCustomer})
        Me.MasterBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.MasterBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.MasterBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.MasterBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.MasterBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.MasterBindingNavigator.Name = "MasterBindingNavigator"
        Me.MasterBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.MasterBindingNavigator.Size = New System.Drawing.Size(622, 25)
        Me.MasterBindingNavigator.TabIndex = 0
        Me.MasterBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 22)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'MasterBindingNavigatorAddNewItem
        '
        Me.MasterBindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.MasterBindingNavigatorAddNewItem.Image = CType(resources.GetObject("MasterBindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.MasterBindingNavigatorAddNewItem.Name = "MasterBindingNavigatorAddNewItem"
        Me.MasterBindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.MasterBindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.MasterBindingNavigatorAddNewItem.Text = "Add new"
        '
        'MasterBindingNavigatorDeleteCustomer
        '
        Me.MasterBindingNavigatorDeleteCustomer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.MasterBindingNavigatorDeleteCustomer.Image = CType(resources.GetObject("MasterBindingNavigatorDeleteCustomer.Image"), System.Drawing.Image)
        Me.MasterBindingNavigatorDeleteCustomer.Name = "MasterBindingNavigatorDeleteCustomer"
        Me.MasterBindingNavigatorDeleteCustomer.RightToLeftAutoMirrorImage = True
        Me.MasterBindingNavigatorDeleteCustomer.Size = New System.Drawing.Size(23, 22)
        Me.MasterBindingNavigatorDeleteCustomer.Text = "Delete"
        '
        'MasterBindingNavigatorEditCustomer
        '
        Me.MasterBindingNavigatorEditCustomer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.MasterBindingNavigatorEditCustomer.Image = CType(resources.GetObject("MasterBindingNavigatorEditCustomer.Image"), System.Drawing.Image)
        Me.MasterBindingNavigatorEditCustomer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.MasterBindingNavigatorEditCustomer.Name = "MasterBindingNavigatorEditCustomer"
        Me.MasterBindingNavigatorEditCustomer.Size = New System.Drawing.Size(23, 22)
        Me.MasterBindingNavigatorEditCustomer.Text = "ToolStripButton1"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.OrderDetailsDataGridView)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 437)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(622, 117)
        Me.Panel1.TabIndex = 2
        '
        'OrderDetailsDataGridView
        '
        Me.OrderDetailsDataGridView.AllowUserToAddRows = False
        Me.OrderDetailsDataGridView.AllowUserToDeleteRows = False
        Me.OrderDetailsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.OrderDetailsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OrderDetailsDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.OrderDetailsDataGridView.Name = "OrderDetailsDataGridView"
        Me.OrderDetailsDataGridView.ReadOnly = True
        Me.OrderDetailsDataGridView.RowHeadersVisible = False
        Me.OrderDetailsDataGridView.Size = New System.Drawing.Size(622, 117)
        Me.OrderDetailsDataGridView.TabIndex = 0
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.MasterDataGridView)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DetailsDataGridView)
        Me.SplitContainer1.Panel2.Controls.Add(Me.DetailBindingNavigator)
        Me.SplitContainer1.Size = New System.Drawing.Size(622, 412)
        Me.SplitContainer1.SplitterDistance = 204
        Me.SplitContainer1.TabIndex = 1
        '
        'MasterDataGridView
        '
        Me.MasterDataGridView.AllowUserToAddRows = False
        Me.MasterDataGridView.AllowUserToDeleteRows = False
        Me.MasterDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.MasterDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MasterDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.MasterDataGridView.Name = "MasterDataGridView"
        Me.MasterDataGridView.ReadOnly = True
        Me.MasterDataGridView.Size = New System.Drawing.Size(622, 204)
        Me.MasterDataGridView.TabIndex = 0
        '
        'DetailsDataGridView
        '
        Me.DetailsDataGridView.AllowUserToAddRows = False
        Me.DetailsDataGridView.AllowUserToDeleteRows = False
        Me.DetailsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DetailsDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OrderIdColumn, Me.CustomerIdColumn, Me.OrderDateColumn, Me.InvoiceColumn, Me.UpdateButtonColumn})
        Me.DetailsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DetailsDataGridView.Location = New System.Drawing.Point(0, 25)
        Me.DetailsDataGridView.Name = "DetailsDataGridView"
        Me.DetailsDataGridView.Size = New System.Drawing.Size(622, 179)
        Me.DetailsDataGridView.TabIndex = 0
        '
        'OrderIdColumn
        '
        Me.OrderIdColumn.DataPropertyName = "id"
        Me.OrderIdColumn.HeaderText = "Id"
        Me.OrderIdColumn.Name = "OrderIdColumn"
        Me.OrderIdColumn.ReadOnly = True
        '
        'CustomerIdColumn
        '
        Me.CustomerIdColumn.DataPropertyName = "customerid"
        Me.CustomerIdColumn.HeaderText = "Customer"
        Me.CustomerIdColumn.Name = "CustomerIdColumn"
        Me.CustomerIdColumn.ReadOnly = True
        '
        'OrderDateColumn
        '
        Me.OrderDateColumn.DataPropertyName = "orderdate"
        Me.OrderDateColumn.DateFormat = ""
        DataGridViewCellStyle3.Format = "d"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.OrderDateColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.OrderDateColumn.HeaderText = "Order date"
        Me.OrderDateColumn.Name = "OrderDateColumn"
        Me.OrderDateColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.OrderDateColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'InvoiceColumn
        '
        Me.InvoiceColumn.DataPropertyName = "invoice"
        Me.InvoiceColumn.HeaderText = "Invoice"
        Me.InvoiceColumn.Name = "InvoiceColumn"
        Me.InvoiceColumn.ReadOnly = True
        '
        'UpdateButtonColumn
        '
        Me.UpdateButtonColumn.HeaderText = ""
        Me.UpdateButtonColumn.Name = "UpdateButtonColumn"
        Me.UpdateButtonColumn.Text = "Update"
        '
        'DetailBindingNavigator
        '
        Me.DetailBindingNavigator.AddNewItem = Nothing
        Me.DetailBindingNavigator.CountItem = Me.BindingNavigatorCountItem1
        Me.DetailBindingNavigator.DeleteItem = Nothing
        Me.DetailBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem1, Me.BindingNavigatorMovePreviousItem1, Me.BindingNavigatorSeparator3, Me.BindingNavigatorPositionItem1, Me.BindingNavigatorCountItem1, Me.BindingNavigatorSeparator4, Me.BindingNavigatorMoveNextItem1, Me.BindingNavigatorMoveLastItem1, Me.BindingNavigatorSeparator5, Me.DetailsBindingNavigatorAddNewItem, Me.DetailsBindingNavigatorDeleteItem})
        Me.DetailBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.DetailBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem1
        Me.DetailBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem1
        Me.DetailBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem1
        Me.DetailBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem1
        Me.DetailBindingNavigator.Name = "DetailBindingNavigator"
        Me.DetailBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem1
        Me.DetailBindingNavigator.Size = New System.Drawing.Size(622, 25)
        Me.DetailBindingNavigator.TabIndex = 1
        Me.DetailBindingNavigator.Text = "BindingNavigator2"
        '
        'BindingNavigatorCountItem1
        '
        Me.BindingNavigatorCountItem1.Name = "BindingNavigatorCountItem1"
        Me.BindingNavigatorCountItem1.Size = New System.Drawing.Size(35, 22)
        Me.BindingNavigatorCountItem1.Text = "of {0}"
        Me.BindingNavigatorCountItem1.ToolTipText = "Total number of items"
        '
        'BindingNavigatorMoveFirstItem1
        '
        Me.BindingNavigatorMoveFirstItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem1.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem1.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem1.Name = "BindingNavigatorMoveFirstItem1"
        Me.BindingNavigatorMoveFirstItem1.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem1.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem1.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem1
        '
        Me.BindingNavigatorMovePreviousItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem1.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem1.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem1.Name = "BindingNavigatorMovePreviousItem1"
        Me.BindingNavigatorMovePreviousItem1.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem1.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem1.Text = "Move previous"
        '
        'BindingNavigatorSeparator3
        '
        Me.BindingNavigatorSeparator3.Name = "BindingNavigatorSeparator3"
        Me.BindingNavigatorSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem1
        '
        Me.BindingNavigatorPositionItem1.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem1.AutoSize = False
        Me.BindingNavigatorPositionItem1.Name = "BindingNavigatorPositionItem1"
        Me.BindingNavigatorPositionItem1.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem1.Text = "0"
        Me.BindingNavigatorPositionItem1.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator4
        '
        Me.BindingNavigatorSeparator4.Name = "BindingNavigatorSeparator4"
        Me.BindingNavigatorSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem1
        '
        Me.BindingNavigatorMoveNextItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem1.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem1.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem1.Name = "BindingNavigatorMoveNextItem1"
        Me.BindingNavigatorMoveNextItem1.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem1.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem1.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem1
        '
        Me.BindingNavigatorMoveLastItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem1.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem1.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem1.Name = "BindingNavigatorMoveLastItem1"
        Me.BindingNavigatorMoveLastItem1.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem1.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem1.Text = "Move last"
        '
        'BindingNavigatorSeparator5
        '
        Me.BindingNavigatorSeparator5.Name = "BindingNavigatorSeparator5"
        Me.BindingNavigatorSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'DetailsBindingNavigatorAddNewItem
        '
        Me.DetailsBindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.DetailsBindingNavigatorAddNewItem.Image = CType(resources.GetObject("DetailsBindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.DetailsBindingNavigatorAddNewItem.Name = "DetailsBindingNavigatorAddNewItem"
        Me.DetailsBindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.DetailsBindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.DetailsBindingNavigatorAddNewItem.Text = "Add new"
        '
        'DetailsBindingNavigatorDeleteItem
        '
        Me.DetailsBindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.DetailsBindingNavigatorDeleteItem.Image = CType(resources.GetObject("DetailsBindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.DetailsBindingNavigatorDeleteItem.Name = "DetailsBindingNavigatorDeleteItem"
        Me.DetailsBindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.DetailsBindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.DetailsBindingNavigatorDeleteItem.Text = "Delete"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(622, 554)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MasterBindingNavigator)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Master details simple example for add new detail row"
        CType(Me.MasterBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MasterBindingNavigator.ResumeLayout(False)
        Me.MasterBindingNavigator.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.OrderDetailsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.MasterDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DetailsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DetailBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DetailBindingNavigator.ResumeLayout(False)
        Me.DetailBindingNavigator.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MasterBindingNavigator As BindingNavigator
    Friend WithEvents MasterBindingNavigatorAddNewItem As ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As ToolStripLabel
    Friend WithEvents MasterBindingNavigatorDeleteCustomer As ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As ToolStripSeparator
    Friend WithEvents Panel1 As Panel
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents MasterDataGridView As DataGridView
    Friend WithEvents DetailsDataGridView As DataGridView
    Friend WithEvents OrderIdColumn As DataGridViewTextBoxColumn
    Friend WithEvents CustomerIdColumn As DataGridViewTextBoxColumn
    Friend WithEvents OrderDateColumn As DataGridViewCalendarLibrary.CalendarColumn
    Friend WithEvents InvoiceColumn As DataGridViewTextBoxColumn
    Friend WithEvents UpdateButtonColumn As DataGridViewButtonColumn
    Friend WithEvents DetailBindingNavigator As BindingNavigator
    Friend WithEvents BindingNavigatorCountItem1 As ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem1 As ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem1 As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator3 As ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem1 As ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator4 As ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem1 As ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem1 As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator5 As ToolStripSeparator
    Friend WithEvents DetailsBindingNavigatorAddNewItem As ToolStripButton
    Friend WithEvents DetailsBindingNavigatorDeleteItem As ToolStripButton
    Friend WithEvents MasterBindingNavigatorEditCustomer As ToolStripButton
    Friend WithEvents OrderDetailsDataGridView As DataGridView
End Class
