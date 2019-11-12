<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class CustomersOrdersControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.selectCustomerLabel = New System.Windows.Forms.Label
        Me.divider1 = New System.Windows.Forms.Panel
        Me.selectCustomer = New System.Windows.Forms.ComboBox
        Me.phoneNumberLabel = New System.Windows.Forms.Label
        Me.phoneNumber = New System.Windows.Forms.Label
        Me.contactNameLabel = New System.Windows.Forms.Label
        Me.contactName = New System.Windows.Forms.Label
        Me.faxNumber = New System.Windows.Forms.Label
        Me.faxNumberLabel = New System.Windows.Forms.Label
        Me.unfulfilledOrdersLabel = New System.Windows.Forms.Label
        Me.divider2 = New System.Windows.Forms.Panel
        Me.unfulfilledOrders = New System.Windows.Forms.ListBox
        Me.SuspendLayout()
        '
        'selectCustomerLabel
        '
        Me.selectCustomerLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.selectCustomerLabel.Location = New System.Drawing.Point(4, 34)
        Me.selectCustomerLabel.Name = "selectCustomerLabel"
        Me.selectCustomerLabel.Size = New System.Drawing.Size(143, 23)
        Me.selectCustomerLabel.TabIndex = 0
        Me.selectCustomerLabel.Text = "Select a Customer"
        '
        'divider1
        '
        Me.divider1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.divider1.Location = New System.Drawing.Point(4, 53)
        Me.divider1.Name = "divider1"
        Me.divider1.Size = New System.Drawing.Size(142, 2)
        Me.divider1.TabIndex = 1
        '
        'selectCustomer
        '
        Me.selectCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.selectCustomer.FormattingEnabled = True
        Me.selectCustomer.Location = New System.Drawing.Point(4, 61)
        Me.selectCustomer.Name = "selectCustomer"
        Me.selectCustomer.Size = New System.Drawing.Size(143, 21)
        Me.selectCustomer.TabIndex = 4
        '
        'phoneNumberLabel
        '
        Me.phoneNumberLabel.AutoSize = True
        Me.phoneNumberLabel.Location = New System.Drawing.Point(3, 143)
        Me.phoneNumberLabel.Name = "phoneNumberLabel"
        Me.phoneNumberLabel.Size = New System.Drawing.Size(78, 13)
        Me.phoneNumberLabel.TabIndex = 13
        Me.phoneNumberLabel.Text = "Phone Number"
        '
        'phoneNumber
        '
        Me.phoneNumber.AutoSize = True
        Me.phoneNumber.Location = New System.Drawing.Point(3, 163)
        Me.phoneNumber.Name = "phoneNumber"
        Me.phoneNumber.Size = New System.Drawing.Size(74, 13)
        Me.phoneNumber.TabIndex = 14
        Me.phoneNumber.Text = "phoneNumber"
        '
        'contactNameLabel
        '
        Me.contactNameLabel.AutoSize = True
        Me.contactNameLabel.Location = New System.Drawing.Point(3, 85)
        Me.contactNameLabel.Name = "contactNameLabel"
        Me.contactNameLabel.Size = New System.Drawing.Size(75, 13)
        Me.contactNameLabel.TabIndex = 11
        Me.contactNameLabel.Text = "Contact Name"
        '
        'contactName
        '
        Me.contactName.AutoSize = True
        Me.contactName.Location = New System.Drawing.Point(3, 106)
        Me.contactName.Name = "contactName"
        Me.contactName.Size = New System.Drawing.Size(78, 13)
        Me.contactName.TabIndex = 12
        Me.contactName.Text = "customerName"
        '
        'faxNumber
        '
        Me.faxNumber.AutoSize = True
        Me.faxNumber.Location = New System.Drawing.Point(3, 222)
        Me.faxNumber.Name = "faxNumber"
        Me.faxNumber.Size = New System.Drawing.Size(58, 13)
        Me.faxNumber.TabIndex = 16
        Me.faxNumber.Text = "faxNumber"
        '
        'faxNumberLabel
        '
        Me.faxNumberLabel.AutoSize = True
        Me.faxNumberLabel.Location = New System.Drawing.Point(3, 201)
        Me.faxNumberLabel.Name = "faxNumberLabel"
        Me.faxNumberLabel.Size = New System.Drawing.Size(64, 13)
        Me.faxNumberLabel.TabIndex = 15
        Me.faxNumberLabel.Text = "Fax Number"
        '
        'unfulfilledOrdersLabel
        '
        Me.unfulfilledOrdersLabel.Location = New System.Drawing.Point(3, 257)
        Me.unfulfilledOrdersLabel.Name = "unfulfilledOrdersLabel"
        Me.unfulfilledOrdersLabel.Size = New System.Drawing.Size(100, 23)
        Me.unfulfilledOrdersLabel.TabIndex = 10
        Me.unfulfilledOrdersLabel.Text = "Unfulfilled Orders"
        '
        'divider2
        '
        Me.divider2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.divider2.Location = New System.Drawing.Point(5, 276)
        Me.divider2.Name = "divider2"
        Me.divider2.Size = New System.Drawing.Size(141, 2)
        Me.divider2.TabIndex = 17
        '
        'unfulfilledOrders
        '
        Me.unfulfilledOrders.FormattingEnabled = True
        Me.unfulfilledOrders.Location = New System.Drawing.Point(4, 284)
        Me.unfulfilledOrders.Name = "unfulfilledOrders"
        Me.unfulfilledOrders.Size = New System.Drawing.Size(143, 186)
        Me.unfulfilledOrders.TabIndex = 18
        '
        'CustomersOrdersControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.unfulfilledOrders)
        Me.Controls.Add(Me.divider2)
        Me.Controls.Add(Me.phoneNumberLabel)
        Me.Controls.Add(Me.phoneNumber)
        Me.Controls.Add(Me.contactNameLabel)
        Me.Controls.Add(Me.contactName)
        Me.Controls.Add(Me.faxNumber)
        Me.Controls.Add(Me.faxNumberLabel)
        Me.Controls.Add(Me.unfulfilledOrdersLabel)
        Me.Controls.Add(Me.selectCustomer)
        Me.Controls.Add(Me.divider1)
        Me.Controls.Add(Me.selectCustomerLabel)
        Me.Name = "CustomersOrdersControl"
        Me.Size = New System.Drawing.Size(150, 515)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents selectCustomerLabel As System.Windows.Forms.Label
    Friend WithEvents divider1 As System.Windows.Forms.Panel
    Friend WithEvents selectCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents phoneNumberLabel As System.Windows.Forms.Label
    Friend WithEvents phoneNumber As System.Windows.Forms.Label
    Friend WithEvents contactNameLabel As System.Windows.Forms.Label
    Friend WithEvents contactName As System.Windows.Forms.Label
    Friend WithEvents faxNumber As System.Windows.Forms.Label
    Friend WithEvents faxNumberLabel As System.Windows.Forms.Label
    Friend WithEvents unfulfilledOrdersLabel As System.Windows.Forms.Label
    Friend WithEvents divider2 As System.Windows.Forms.Panel
    Friend WithEvents unfulfilledOrders As System.Windows.Forms.ListBox

End Class
