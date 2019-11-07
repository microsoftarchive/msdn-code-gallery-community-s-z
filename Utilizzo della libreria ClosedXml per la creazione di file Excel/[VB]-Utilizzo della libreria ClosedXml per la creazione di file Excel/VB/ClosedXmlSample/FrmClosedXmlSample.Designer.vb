<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmClosedXmlSample
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnReport = New System.Windows.Forms.Button()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.cbxFind = New System.Windows.Forms.ComboBox()
        Me.dgvUserData = New System.Windows.Forms.DataGridView()
        Me.txtNationality = New System.Windows.Forms.TextBox()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.txtTelephoneNumber = New System.Windows.Forms.TextBox()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.txtSurname = New System.Windows.Forms.TextBox()
        Me.lnationality = New System.Windows.Forms.Label()
        Me.lblCity = New System.Windows.Forms.Label()
        Me.lblUserTelephoneNumber = New System.Windows.Forms.Label()
        Me.lblUserAddress = New System.Windows.Forms.Label()
        Me.lblUserSurName = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.btnEsci = New System.Windows.Forms.Button()
        Me.btnModifica = New System.Windows.Forms.Button()
        Me.btnElimina = New System.Windows.Forms.Button()
        Me.btnNuovo = New System.Windows.Forms.Button()
        Me.UserDataSet = New ClosedXmlSample.UserDataSet()
        Me.USERDATABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.USERDATATableAdapter = New ClosedXmlSample.UserDataSetTableAdapters.USERDATATableAdapter()
        Me.TableAdapterManager = New ClosedXmlSample.UserDataSetTableAdapters.TableAdapterManager()
        CType(Me.dgvUserData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UserDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.USERDATABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnReport
        '
        Me.btnReport.Location = New System.Drawing.Point(284, 12)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(88, 23)
        Me.btnReport.TabIndex = 17
        Me.btnReport.Text = "Report"
        Me.btnReport.UseVisualStyleBackColor = True
        '
        'btnFind
        '
        Me.btnFind.Location = New System.Drawing.Point(512, 188)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(75, 23)
        Me.btnFind.TabIndex = 32
        Me.btnFind.Text = "Find"
        Me.btnFind.UseVisualStyleBackColor = True
        '
        'cbxFind
        '
        Me.cbxFind.FormattingEnabled = True
        Me.cbxFind.Items.AddRange(New Object() {"NAME", "SURNAME", "ADDRESS", "TELEPHONENUMBER", "CITY", "NATIONALITY"})
        Me.cbxFind.Location = New System.Drawing.Point(350, 190)
        Me.cbxFind.Name = "cbxFind"
        Me.cbxFind.Size = New System.Drawing.Size(148, 21)
        Me.cbxFind.TabIndex = 30
        '
        'dgvUserData
        '
        Me.dgvUserData.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgvUserData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvUserData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvUserData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUserData.Location = New System.Drawing.Point(15, 285)
        Me.dgvUserData.Name = "dgvUserData"
        Me.dgvUserData.Size = New System.Drawing.Size(659, 365)
        Me.dgvUserData.TabIndex = 33
        '
        'txtNationality
        '
        Me.txtNationality.Location = New System.Drawing.Point(113, 191)
        Me.txtNationality.Name = "txtNationality"
        Me.txtNationality.Size = New System.Drawing.Size(100, 20)
        Me.txtNationality.TabIndex = 29
        '
        'txtCity
        '
        Me.txtCity.Location = New System.Drawing.Point(113, 165)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(192, 20)
        Me.txtCity.TabIndex = 27
        '
        'txtTelephoneNumber
        '
        Me.txtTelephoneNumber.Location = New System.Drawing.Point(113, 139)
        Me.txtTelephoneNumber.Name = "txtTelephoneNumber"
        Me.txtTelephoneNumber.Size = New System.Drawing.Size(100, 20)
        Me.txtTelephoneNumber.TabIndex = 25
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(113, 113)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(192, 20)
        Me.txtAddress.TabIndex = 23
        '
        'txtSurname
        '
        Me.txtSurname.Location = New System.Drawing.Point(113, 87)
        Me.txtSurname.Name = "txtSurname"
        Me.txtSurname.Size = New System.Drawing.Size(100, 20)
        Me.txtSurname.TabIndex = 22
        '
        'lnationality
        '
        Me.lnationality.AutoSize = True
        Me.lnationality.Location = New System.Drawing.Point(12, 194)
        Me.lnationality.Name = "lnationality"
        Me.lnationality.Size = New System.Drawing.Size(56, 13)
        Me.lnationality.TabIndex = 31
        Me.lnationality.Text = "Nationality"
        '
        'lblCity
        '
        Me.lblCity.AutoSize = True
        Me.lblCity.Location = New System.Drawing.Point(12, 168)
        Me.lblCity.Name = "lblCity"
        Me.lblCity.Size = New System.Drawing.Size(24, 13)
        Me.lblCity.TabIndex = 28
        Me.lblCity.Text = "City"
        '
        'lblUserTelephoneNumber
        '
        Me.lblUserTelephoneNumber.AutoSize = True
        Me.lblUserTelephoneNumber.Location = New System.Drawing.Point(11, 142)
        Me.lblUserTelephoneNumber.Name = "lblUserTelephoneNumber"
        Me.lblUserTelephoneNumber.Size = New System.Drawing.Size(96, 13)
        Me.lblUserTelephoneNumber.TabIndex = 26
        Me.lblUserTelephoneNumber.Text = "Telephone number"
        '
        'lblUserAddress
        '
        Me.lblUserAddress.AutoSize = True
        Me.lblUserAddress.Location = New System.Drawing.Point(11, 116)
        Me.lblUserAddress.Name = "lblUserAddress"
        Me.lblUserAddress.Size = New System.Drawing.Size(45, 13)
        Me.lblUserAddress.TabIndex = 24
        Me.lblUserAddress.Text = "Address"
        '
        'lblUserSurName
        '
        Me.lblUserSurName.AutoSize = True
        Me.lblUserSurName.Location = New System.Drawing.Point(11, 90)
        Me.lblUserSurName.Name = "lblUserSurName"
        Me.lblUserSurName.Size = New System.Drawing.Size(49, 13)
        Me.lblUserSurName.TabIndex = 21
        Me.lblUserSurName.Text = "Surname"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(113, 61)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(100, 20)
        Me.txtName.TabIndex = 20
        '
        'lblUserName
        '
        Me.lblUserName.AutoSize = True
        Me.lblUserName.Location = New System.Drawing.Point(11, 64)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(35, 13)
        Me.lblUserName.TabIndex = 19
        Me.lblUserName.Text = "Name"
        '
        'btnEsci
        '
        Me.btnEsci.Location = New System.Drawing.Point(512, 12)
        Me.btnEsci.Name = "btnEsci"
        Me.btnEsci.Size = New System.Drawing.Size(75, 23)
        Me.btnEsci.TabIndex = 18
        Me.btnEsci.Text = "Exit"
        Me.btnEsci.UseVisualStyleBackColor = True
        '
        'btnModifica
        '
        Me.btnModifica.Location = New System.Drawing.Point(174, 12)
        Me.btnModifica.Name = "btnModifica"
        Me.btnModifica.Size = New System.Drawing.Size(75, 23)
        Me.btnModifica.TabIndex = 16
        Me.btnModifica.Text = "Update"
        Me.btnModifica.UseVisualStyleBackColor = True
        '
        'btnElimina
        '
        Me.btnElimina.Location = New System.Drawing.Point(93, 12)
        Me.btnElimina.Name = "btnElimina"
        Me.btnElimina.Size = New System.Drawing.Size(75, 23)
        Me.btnElimina.TabIndex = 15
        Me.btnElimina.Text = "Delete"
        Me.btnElimina.UseVisualStyleBackColor = True
        '
        'btnNuovo
        '
        Me.btnNuovo.Location = New System.Drawing.Point(12, 12)
        Me.btnNuovo.Name = "btnNuovo"
        Me.btnNuovo.Size = New System.Drawing.Size(75, 23)
        Me.btnNuovo.TabIndex = 14
        Me.btnNuovo.Text = "New"
        Me.btnNuovo.UseVisualStyleBackColor = True
        '
        'UserDataSet
        '
        Me.UserDataSet.DataSetName = "UserDataSet"
        Me.UserDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'USERDATABindingSource
        '
        Me.USERDATABindingSource.DataMember = "USERDATA"
        Me.USERDATABindingSource.DataSource = Me.UserDataSet
        '
        'USERDATATableAdapter
        '
        Me.USERDATATableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.UpdateOrder = ClosedXmlSample.UserDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.USERDATATableAdapter = Me.USERDATATableAdapter
        '
        'FrmClosedXmlSample
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(715, 670)
        Me.Controls.Add(Me.btnReport)
        Me.Controls.Add(Me.btnFind)
        Me.Controls.Add(Me.cbxFind)
        Me.Controls.Add(Me.dgvUserData)
        Me.Controls.Add(Me.txtNationality)
        Me.Controls.Add(Me.txtCity)
        Me.Controls.Add(Me.txtTelephoneNumber)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.txtSurname)
        Me.Controls.Add(Me.lnationality)
        Me.Controls.Add(Me.lblCity)
        Me.Controls.Add(Me.lblUserTelephoneNumber)
        Me.Controls.Add(Me.lblUserAddress)
        Me.Controls.Add(Me.lblUserSurName)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.lblUserName)
        Me.Controls.Add(Me.btnEsci)
        Me.Controls.Add(Me.btnModifica)
        Me.Controls.Add(Me.btnElimina)
        Me.Controls.Add(Me.btnNuovo)
        Me.Name = "FrmClosedXmlSample"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CLOSED XML SAMPLE"
        CType(Me.dgvUserData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UserDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.USERDATABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents btnReport As System.Windows.Forms.Button
    Private WithEvents btnFind As System.Windows.Forms.Button
    Private WithEvents cbxFind As System.Windows.Forms.ComboBox
    Private WithEvents dgvUserData As System.Windows.Forms.DataGridView
    Private WithEvents txtNationality As System.Windows.Forms.TextBox
    Private WithEvents txtCity As System.Windows.Forms.TextBox
    Private WithEvents txtTelephoneNumber As System.Windows.Forms.TextBox
    Private WithEvents txtAddress As System.Windows.Forms.TextBox
    Private WithEvents txtSurname As System.Windows.Forms.TextBox
    Private WithEvents lnationality As System.Windows.Forms.Label
    Private WithEvents lblCity As System.Windows.Forms.Label
    Private WithEvents lblUserTelephoneNumber As System.Windows.Forms.Label
    Private WithEvents lblUserAddress As System.Windows.Forms.Label
    Private WithEvents lblUserSurName As System.Windows.Forms.Label
    Private WithEvents txtName As System.Windows.Forms.TextBox
    Private WithEvents lblUserName As System.Windows.Forms.Label
    Private WithEvents btnEsci As System.Windows.Forms.Button
    Private WithEvents btnModifica As System.Windows.Forms.Button
    Private WithEvents btnElimina As System.Windows.Forms.Button
    Private WithEvents btnNuovo As System.Windows.Forms.Button
    Friend WithEvents UserDataSet As ClosedXmlSample.UserDataSet
    Friend WithEvents USERDATABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents USERDATATableAdapter As ClosedXmlSample.UserDataSetTableAdapters.USERDATATableAdapter
    Friend WithEvents TableAdapterManager As ClosedXmlSample.UserDataSetTableAdapters.TableAdapterManager
End Class
