<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEmail
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
        Me.txtFrom = New System.Windows.Forms.TextBox()
        Me.txtCc = New System.Windows.Forms.TextBox()
        Me.txtTo = New System.Windows.Forms.TextBox()
        Me.txtBody = New System.Windows.Forms.TextBox()
        Me.btnCc = New System.Windows.Forms.Button()
        Me.btnTo = New System.Windows.Forms.Button()
        Me.txtOggetto = New System.Windows.Forms.TextBox()
        Me.lblOggetto = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.lblServerPosta = New System.Windows.Forms.Label()
        Me.cbxServerPosta = New System.Windows.Forms.ComboBox()
        Me.btnInvia = New System.Windows.Forms.Button()
        Me.cbxTo = New System.Windows.Forms.ComboBox()
        Me.cbxCc = New System.Windows.Forms.ComboBox()
        Me.btnEsci = New System.Windows.Forms.Button()
        Me.lblFrom = New System.Windows.Forms.Label()
        Me.btnAllega = New System.Windows.Forms.Button()
        Me.txtAllegati = New System.Windows.Forms.TextBox()
        Me.btnAggiungi = New System.Windows.Forms.Button()
        Me.btnEliminaContatti = New System.Windows.Forms.Button()
        Me.ofd = New System.Windows.Forms.OpenFileDialog()
        Me.SuspendLayout()
        '
        'txtFrom
        '
        Me.txtFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFrom.Location = New System.Drawing.Point(151, 73)
        Me.txtFrom.Name = "txtFrom"
        Me.txtFrom.Size = New System.Drawing.Size(172, 20)
        Me.txtFrom.TabIndex = 1
        '
        'txtCc
        '
        Me.txtCc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCc.Location = New System.Drawing.Point(455, 102)
        Me.txtCc.Name = "txtCc"
        Me.txtCc.Size = New System.Drawing.Size(1137, 20)
        Me.txtCc.TabIndex = 6
        '
        'txtTo
        '
        Me.txtTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTo.Location = New System.Drawing.Point(455, 131)
        Me.txtTo.Name = "txtTo"
        Me.txtTo.Size = New System.Drawing.Size(1137, 20)
        Me.txtTo.TabIndex = 9
        '
        'txtBody
        '
        Me.txtBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBody.Location = New System.Drawing.Point(15, 273)
        Me.txtBody.Multiline = True
        Me.txtBody.Name = "txtBody"
        Me.txtBody.Size = New System.Drawing.Size(1577, 597)
        Me.txtBody.TabIndex = 15
        '
        'btnCc
        '
        Me.btnCc.Location = New System.Drawing.Point(12, 100)
        Me.btnCc.Name = "btnCc"
        Me.btnCc.Size = New System.Drawing.Size(75, 23)
        Me.btnCc.TabIndex = 4
        Me.btnCc.Text = "Cc"
        Me.btnCc.UseVisualStyleBackColor = True
        '
        'btnTo
        '
        Me.btnTo.Location = New System.Drawing.Point(12, 129)
        Me.btnTo.Name = "btnTo"
        Me.btnTo.Size = New System.Drawing.Size(75, 23)
        Me.btnTo.TabIndex = 7
        Me.btnTo.Text = "To"
        Me.btnTo.UseVisualStyleBackColor = True
        '
        'txtOggetto
        '
        Me.txtOggetto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOggetto.Location = New System.Drawing.Point(455, 171)
        Me.txtOggetto.Name = "txtOggetto"
        Me.txtOggetto.Size = New System.Drawing.Size(476, 20)
        Me.txtOggetto.TabIndex = 12
        '
        'lblOggetto
        '
        Me.lblOggetto.AutoSize = True
        Me.lblOggetto.Location = New System.Drawing.Point(396, 173)
        Me.lblOggetto.Name = "lblOggetto"
        Me.lblOggetto.Size = New System.Drawing.Size(45, 13)
        Me.lblOggetto.TabIndex = 9
        Me.lblOggetto.Text = "Oggetto"
        '
        'txtPassword
        '
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPassword.Location = New System.Drawing.Point(455, 73)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(78, 20)
        Me.txtPassword.TabIndex = 2
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(396, 76)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(53, 13)
        Me.lblPassword.TabIndex = 11
        Me.lblPassword.Text = "Password"
        '
        'lblServerPosta
        '
        Me.lblServerPosta.AutoSize = True
        Me.lblServerPosta.Location = New System.Drawing.Point(586, 76)
        Me.lblServerPosta.Name = "lblServerPosta"
        Me.lblServerPosta.Size = New System.Drawing.Size(79, 13)
        Me.lblServerPosta.TabIndex = 12
        Me.lblServerPosta.Text = "Server di Posta"
        '
        'cbxServerPosta
        '
        Me.cbxServerPosta.FormattingEnabled = True
        Me.cbxServerPosta.Items.AddRange(New Object() {"hotmail"})
        Me.cbxServerPosta.Location = New System.Drawing.Point(686, 73)
        Me.cbxServerPosta.Name = "cbxServerPosta"
        Me.cbxServerPosta.Size = New System.Drawing.Size(185, 21)
        Me.cbxServerPosta.TabIndex = 3
        '
        'btnInvia
        '
        Me.btnInvia.Location = New System.Drawing.Point(374, 203)
        Me.btnInvia.Name = "btnInvia"
        Me.btnInvia.Size = New System.Drawing.Size(75, 23)
        Me.btnInvia.TabIndex = 14
        Me.btnInvia.Text = "Invia"
        Me.btnInvia.UseVisualStyleBackColor = True
        '
        'cbxTo
        '
        Me.cbxTo.FormattingEnabled = True
        Me.cbxTo.Location = New System.Drawing.Point(151, 131)
        Me.cbxTo.Name = "cbxTo"
        Me.cbxTo.Size = New System.Drawing.Size(172, 21)
        Me.cbxTo.TabIndex = 8
        '
        'cbxCc
        '
        Me.cbxCc.FormattingEnabled = True
        Me.cbxCc.Location = New System.Drawing.Point(151, 102)
        Me.cbxCc.Name = "cbxCc"
        Me.cbxCc.Size = New System.Drawing.Size(172, 21)
        Me.cbxCc.TabIndex = 5
        '
        'btnEsci
        '
        Me.btnEsci.Location = New System.Drawing.Point(12, 12)
        Me.btnEsci.Name = "btnEsci"
        Me.btnEsci.Size = New System.Drawing.Size(75, 23)
        Me.btnEsci.TabIndex = 14
        Me.btnEsci.Text = "Esci"
        Me.btnEsci.UseVisualStyleBackColor = True
        '
        'lblFrom
        '
        Me.lblFrom.AutoSize = True
        Me.lblFrom.Location = New System.Drawing.Point(33, 76)
        Me.lblFrom.Name = "lblFrom"
        Me.lblFrom.Size = New System.Drawing.Size(30, 13)
        Me.lblFrom.TabIndex = 15
        Me.lblFrom.Text = "From"
        '
        'btnAllega
        '
        Me.btnAllega.Location = New System.Drawing.Point(293, 203)
        Me.btnAllega.Name = "btnAllega"
        Me.btnAllega.Size = New System.Drawing.Size(75, 23)
        Me.btnAllega.TabIndex = 13
        Me.btnAllega.Text = "Allega"
        Me.btnAllega.UseVisualStyleBackColor = True
        '
        'txtAllegati
        '
        Me.txtAllegati.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAllegati.Location = New System.Drawing.Point(455, 206)
        Me.txtAllegati.Name = "txtAllegati"
        Me.txtAllegati.Size = New System.Drawing.Size(476, 20)
        Me.txtAllegati.TabIndex = 17
        '
        'btnAggiungi
        '
        Me.btnAggiungi.Location = New System.Drawing.Point(12, 158)
        Me.btnAggiungi.Name = "btnAggiungi"
        Me.btnAggiungi.Size = New System.Drawing.Size(75, 52)
        Me.btnAggiungi.TabIndex = 10
        Me.btnAggiungi.Text = "Aggiungi ai contatti"
        Me.btnAggiungi.UseVisualStyleBackColor = True
        '
        'btnEliminaContatti
        '
        Me.btnEliminaContatti.Location = New System.Drawing.Point(12, 216)
        Me.btnEliminaContatti.Name = "btnEliminaContatti"
        Me.btnEliminaContatti.Size = New System.Drawing.Size(75, 52)
        Me.btnEliminaContatti.TabIndex = 11
        Me.btnEliminaContatti.Text = "Enimina Contatti"
        Me.btnEliminaContatti.UseVisualStyleBackColor = True
        '
        'ofd
        '
        Me.ofd.Multiselect = True
        '
        'FrmEmail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(1604, 882)
        Me.Controls.Add(Me.btnEliminaContatti)
        Me.Controls.Add(Me.btnAggiungi)
        Me.Controls.Add(Me.txtAllegati)
        Me.Controls.Add(Me.btnAllega)
        Me.Controls.Add(Me.lblFrom)
        Me.Controls.Add(Me.btnEsci)
        Me.Controls.Add(Me.cbxCc)
        Me.Controls.Add(Me.cbxTo)
        Me.Controls.Add(Me.btnInvia)
        Me.Controls.Add(Me.cbxServerPosta)
        Me.Controls.Add(Me.lblServerPosta)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.lblOggetto)
        Me.Controls.Add(Me.txtOggetto)
        Me.Controls.Add(Me.btnTo)
        Me.Controls.Add(Me.btnCc)
        Me.Controls.Add(Me.txtBody)
        Me.Controls.Add(Me.txtTo)
        Me.Controls.Add(Me.txtCc)
        Me.Controls.Add(Me.txtFrom)
        Me.Name = "FrmEmail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EMAIL SAMPLE"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtFrom As System.Windows.Forms.TextBox
    Friend WithEvents txtCc As System.Windows.Forms.TextBox
    Friend WithEvents txtTo As System.Windows.Forms.TextBox
    Friend WithEvents txtBody As System.Windows.Forms.TextBox
    Friend WithEvents btnCc As System.Windows.Forms.Button
    Friend WithEvents btnTo As System.Windows.Forms.Button
    Friend WithEvents txtOggetto As System.Windows.Forms.TextBox
    Friend WithEvents lblOggetto As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents lblServerPosta As System.Windows.Forms.Label
    Friend WithEvents cbxServerPosta As System.Windows.Forms.ComboBox
    Friend WithEvents btnInvia As System.Windows.Forms.Button
    Friend WithEvents cbxTo As System.Windows.Forms.ComboBox
    Friend WithEvents cbxCc As System.Windows.Forms.ComboBox
    Friend WithEvents btnEsci As System.Windows.Forms.Button
    Friend WithEvents lblFrom As System.Windows.Forms.Label
    Friend WithEvents btnAllega As System.Windows.Forms.Button
    Friend WithEvents txtAllegati As System.Windows.Forms.TextBox
    Friend WithEvents btnAggiungi As System.Windows.Forms.Button
    Friend WithEvents btnEliminaContatti As System.Windows.Forms.Button
    Friend WithEvents ofd As System.Windows.Forms.OpenFileDialog

End Class
