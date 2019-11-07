Namespace SolidEdge.AddIn.EdgeBar
	Partial Public Class SelectSetEdgeBarControl
		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Component Designer generated code"

		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.propertyGrid = New System.Windows.Forms.PropertyGrid()
			Me.comboBox = New System.Windows.Forms.ComboBox()
			Me.SuspendLayout()
			' 
			' propertyGrid
			' 
			Me.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill
			Me.propertyGrid.Location = New System.Drawing.Point(0, 21)
			Me.propertyGrid.Name = "propertyGrid"
			Me.propertyGrid.PropertySort = System.Windows.Forms.PropertySort.Alphabetical
			Me.propertyGrid.Size = New System.Drawing.Size(271, 313)
			Me.propertyGrid.TabIndex = 0
			Me.propertyGrid.ToolbarVisible = False
			' 
			' comboBox
			' 
			Me.comboBox.Dock = System.Windows.Forms.DockStyle.Top
			Me.comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.comboBox.FormattingEnabled = True
			Me.comboBox.Location = New System.Drawing.Point(0, 0)
			Me.comboBox.Name = "comboBox"
			Me.comboBox.Size = New System.Drawing.Size(271, 21)
			Me.comboBox.TabIndex = 1
'			Me.comboBox.SelectedIndexChanged += New System.EventHandler(Me.comboBox_SelectedIndexChanged)
			' 
			' SelectSetEdgeBarControl
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.BitmapID = 100
			Me.Controls.Add(Me.propertyGrid)
			Me.Controls.Add(Me.comboBox)
			Me.DoubleBuffered = True
			Me.Name = "SelectSetEdgeBarControl"
			Me.Size = New System.Drawing.Size(271, 334)
			Me.ToolTip = "SelectSet"
'			Me.Load += New System.EventHandler(Me.MyEdgeBarControl_Load)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private propertyGrid As System.Windows.Forms.PropertyGrid
		Private WithEvents comboBox As System.Windows.Forms.ComboBox
	End Class
End Namespace
