<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SimpleControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SimpleControl))
        Me._coffeePicture = New System.Windows.Forms.PictureBox
        Me._closeCoffeeList = New System.Windows.Forms.Button
        Me._coffeeGroup = New System.Windows.Forms.GroupBox
        Me._coffeeList = New System.Windows.Forms.ListBox
        CType(Me._coffeePicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._coffeeGroup.SuspendLayout()
        Me.SuspendLayout()
        '
        '_coffeePicture
        '
        Me._coffeePicture.Image = Global.UiManagerOutlookAddIn.My.Resources.Resources.espressoCup_tall
        resources.ApplyResources(Me._coffeePicture, "_coffeePicture")
        Me._coffeePicture.Name = "_coffeePicture"
        Me._coffeePicture.TabStop = False
        '
        '_closeCoffeeList
        '
        Me._closeCoffeeList.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me._closeCoffeeList, "_closeCoffeeList")
        Me._closeCoffeeList.Name = "_closeCoffeeList"
        Me._closeCoffeeList.UseVisualStyleBackColor = True
        '
        '_coffeeGroup
        '
        Me._coffeeGroup.Controls.Add(Me._closeCoffeeList)
        Me._coffeeGroup.Controls.Add(Me._coffeeList)
        Me._coffeeGroup.ForeColor = System.Drawing.SystemColors.ControlLightLight
        resources.ApplyResources(Me._coffeeGroup, "_coffeeGroup")
        Me._coffeeGroup.Name = "_coffeeGroup"
        Me._coffeeGroup.TabStop = False
        '
        '_coffeeList
        '
        resources.ApplyResources(Me._coffeeList, "_coffeeList")
        Me._coffeeList.FormattingEnabled = True
        Me._coffeeList.Name = "_coffeeList"
        '
        'SimpleControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlText
        Me.Controls.Add(Me._coffeePicture)
        Me.Controls.Add(Me._coffeeGroup)
        Me.Name = "SimpleControl"
        CType(Me._coffeePicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me._coffeeGroup.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents _coffeePicture As System.Windows.Forms.PictureBox
    Friend WithEvents _closeCoffeeList As System.Windows.Forms.Button
    Friend WithEvents _coffeeGroup As System.Windows.Forms.GroupBox
    Friend WithEvents _coffeeList As System.Windows.Forms.ListBox

End Class
