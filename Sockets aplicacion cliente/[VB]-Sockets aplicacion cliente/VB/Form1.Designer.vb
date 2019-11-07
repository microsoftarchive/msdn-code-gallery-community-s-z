<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.conectar = New System.Windows.Forms.CheckBox
        Me.conversacion = New System.Windows.Forms.TextBox
        Me.usuarios = New System.Windows.Forms.TextBox
        Me.txtenviar = New System.Windows.Forms.TextBox
        Me.btnenviar = New System.Windows.Forms.Button
        Me.secuencia_lecturas = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'conectar
        '
        Me.conectar.AutoSize = True
        Me.conectar.Location = New System.Drawing.Point(21, 12)
        Me.conectar.Name = "conectar"
        Me.conectar.Size = New System.Drawing.Size(91, 17)
        Me.conectar.TabIndex = 0
        Me.conectar.Text = "CONECTAR?"
        Me.conectar.UseVisualStyleBackColor = True
        '
        'conversacion
        '
        Me.conversacion.Location = New System.Drawing.Point(21, 35)
        Me.conversacion.Multiline = True
        Me.conversacion.Name = "conversacion"
        Me.conversacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.conversacion.Size = New System.Drawing.Size(225, 163)
        Me.conversacion.TabIndex = 1
        '
        'usuarios
        '
        Me.usuarios.Location = New System.Drawing.Point(252, 35)
        Me.usuarios.Multiline = True
        Me.usuarios.Name = "usuarios"
        Me.usuarios.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.usuarios.Size = New System.Drawing.Size(133, 163)
        Me.usuarios.TabIndex = 2
        '
        'txtenviar
        '
        Me.txtenviar.Location = New System.Drawing.Point(21, 214)
        Me.txtenviar.Multiline = True
        Me.txtenviar.Name = "txtenviar"
        Me.txtenviar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtenviar.Size = New System.Drawing.Size(266, 59)
        Me.txtenviar.TabIndex = 3
        '
        'btnenviar
        '
        Me.btnenviar.Location = New System.Drawing.Point(303, 214)
        Me.btnenviar.Name = "btnenviar"
        Me.btnenviar.Size = New System.Drawing.Size(82, 59)
        Me.btnenviar.TabIndex = 4
        Me.btnenviar.Text = "ENVIAR"
        Me.btnenviar.UseVisualStyleBackColor = True
        '
        'secuencia_lecturas
        '
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(395, 285)
        Me.Controls.Add(Me.btnenviar)
        Me.Controls.Add(Me.txtenviar)
        Me.Controls.Add(Me.usuarios)
        Me.Controls.Add(Me.conversacion)
        Me.Controls.Add(Me.conectar)
        Me.Name = "Form1"
        Me.Text = "TCPCLIENTE"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents conectar As System.Windows.Forms.CheckBox
    Friend WithEvents conversacion As System.Windows.Forms.TextBox
    Friend WithEvents usuarios As System.Windows.Forms.TextBox
    Friend WithEvents txtenviar As System.Windows.Forms.TextBox
    Friend WithEvents btnenviar As System.Windows.Forms.Button
    Friend WithEvents secuencia_lecturas As System.Windows.Forms.Timer

End Class
