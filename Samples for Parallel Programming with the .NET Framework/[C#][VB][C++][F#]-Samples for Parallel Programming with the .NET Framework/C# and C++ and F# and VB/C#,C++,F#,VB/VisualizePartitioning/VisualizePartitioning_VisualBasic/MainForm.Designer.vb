Namespace VisualizePartitioning
    Partial Public Class MainForm
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

#Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.pbPartitionedImage = New PictureBox()
            Me.btnVisualize = New Button()
            Me.lvPartitioningMethods = New ListView()
            Me.lvWorkloads = New ListView()
            Me.label1 = New Label()
            Me.label2 = New Label()
            Me.lblTime = New Label()
            Me.tbWorkFactor = New TrackBar()
            Me.label3 = New Label()
            Me.rbParallelFor = New RadioButton()
            Me.rbParallelForEach = New RadioButton()
            Me.rbPLINQ = New RadioButton()
            Me.groupBox1 = New GroupBox()
            Me.label4 = New Label()
            Me.tbCores = New TrackBar()
            Me.toolTip1 = New ToolTip(Me.components)
            CType(Me.pbPartitionedImage, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.tbWorkFactor, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.groupBox1.SuspendLayout()
            CType(Me.tbCores, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' pbPartitionedImage
            ' 
            Me.pbPartitionedImage.Anchor = (CType((((AnchorStyles.Top Or AnchorStyles.Bottom) Or AnchorStyles.Left) Or AnchorStyles.Right), AnchorStyles))
            Me.pbPartitionedImage.BackColor = Color.Black
            Me.pbPartitionedImage.BorderStyle = BorderStyle.Fixed3D
            Me.pbPartitionedImage.Location = New Point(12, 12)
            Me.pbPartitionedImage.Name = "pbPartitionedImage"
            Me.pbPartitionedImage.Size = New Size(539, 522)
            Me.pbPartitionedImage.SizeMode = PictureBoxSizeMode.StretchImage
            Me.pbPartitionedImage.TabIndex = 0
            Me.pbPartitionedImage.TabStop = False
            ' 
            ' btnVisualize
            ' 
            Me.btnVisualize.Anchor = (CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles))
            Me.btnVisualize.Location = New Point(557, 490)
            Me.btnVisualize.Name = "btnVisualize"
            Me.btnVisualize.Size = New Size(75, 23)
            Me.btnVisualize.TabIndex = 1
            Me.btnVisualize.Text = "Visualize"
            Me.btnVisualize.UseVisualStyleBackColor = True
            ' Me.btnVisualize.Click += New System.EventHandler(AddressOf Me.btnVisualize_Click)
            ' 
            ' lvPartitioningMethods
            ' 
            Me.lvPartitioningMethods.Activation = ItemActivation.OneClick
            Me.lvPartitioningMethods.Alignment = ListViewAlignment.Default
            Me.lvPartitioningMethods.Anchor = (CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles))
            Me.lvPartitioningMethods.AutoArrange = False
            Me.lvPartitioningMethods.Enabled = False
            Me.lvPartitioningMethods.FullRowSelect = True
            Me.lvPartitioningMethods.GridLines = True
            Me.lvPartitioningMethods.HeaderStyle = ColumnHeaderStyle.None
            Me.lvPartitioningMethods.Location = New Point(559, 127)
            Me.lvPartitioningMethods.MultiSelect = False
            Me.lvPartitioningMethods.Name = "lvPartitioningMethods"
            Me.lvPartitioningMethods.ShowGroups = False
            Me.lvPartitioningMethods.Size = New Size(126, 150)
            Me.lvPartitioningMethods.TabIndex = 2
            Me.lvPartitioningMethods.UseCompatibleStateImageBehavior = False
            Me.lvPartitioningMethods.View = View.List
            ' 
            ' lvWorkloads
            ' 
            Me.lvWorkloads.Activation = ItemActivation.OneClick
            Me.lvWorkloads.Alignment = ListViewAlignment.Default
            Me.lvWorkloads.Anchor = (CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles))
            Me.lvWorkloads.AutoArrange = False
            Me.lvWorkloads.FullRowSelect = True
            Me.lvWorkloads.GridLines = True
            Me.lvWorkloads.HeaderStyle = ColumnHeaderStyle.None
            Me.lvWorkloads.HideSelection = False
            Me.lvWorkloads.Location = New Point(559, 296)
            Me.lvWorkloads.MultiSelect = False
            Me.lvWorkloads.Name = "lvWorkloads"
            Me.lvWorkloads.ShowGroups = False
            Me.lvWorkloads.Size = New Size(126, 77)
            Me.lvWorkloads.TabIndex = 3
            Me.lvWorkloads.UseCompatibleStateImageBehavior = False
            Me.lvWorkloads.View = View.List
            ' 
            ' label1
            ' 
            Me.label1.Anchor = (CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles))
            Me.label1.AutoSize = True
            Me.label1.Location = New Point(556, 280)
            Me.label1.Name = "label1"
            Me.label1.Size = New Size(53, 13)
            Me.label1.TabIndex = 4
            Me.label1.Text = "Workload"
            ' 
            ' label2
            ' 
            Me.label2.Anchor = (CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles))
            Me.label2.AutoSize = True
            Me.label2.Location = New Point(557, 111)
            Me.label2.Name = "label2"
            Me.label2.Size = New Size(59, 13)
            Me.label2.TabIndex = 5
            Me.label2.Text = "Partitioning"
            ' 
            ' lblTime
            ' 
            Me.lblTime.Anchor = (CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles))
            Me.lblTime.AutoSize = True
            Me.lblTime.Location = New Point(556, 516)
            Me.lblTime.Name = "lblTime"
            Me.lblTime.Size = New Size(36, 13)
            Me.lblTime.TabIndex = 6
            Me.lblTime.Text = "Time: "
            ' 
            ' tbWorkFactor
            ' 
            Me.tbWorkFactor.Anchor = (CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles))
            Me.tbWorkFactor.LargeChange = 1
            Me.tbWorkFactor.Location = New Point(558, 408)
            Me.tbWorkFactor.Maximum = 1000
            Me.tbWorkFactor.Minimum = 1
            Me.tbWorkFactor.Name = "tbWorkFactor"
            Me.tbWorkFactor.Size = New Size(123, 45)
            Me.tbWorkFactor.TabIndex = 7
            Me.tbWorkFactor.TickFrequency = 100
            Me.tbWorkFactor.TickStyle = TickStyle.None
            Me.tbWorkFactor.Value = 1
            ' Me.tbWorkFactor.ValueChanged += New System.EventHandler(Me.tbWorkFactor_ValueChanged)
            ' 
            ' label3
            ' 
            Me.label3.Anchor = (CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles))
            Me.label3.AutoSize = True
            Me.label3.Location = New Point(557, 385)
            Me.label3.Name = "label3"
            Me.label3.Size = New Size(66, 13)
            Me.label3.TabIndex = 8
            Me.label3.Text = "Work Factor"
            ' 
            ' rbParallelFor
            ' 
            Me.rbParallelFor.AutoSize = True
            Me.rbParallelFor.Checked = True
            Me.rbParallelFor.Location = New Point(7, 18)
            Me.rbParallelFor.Name = "rbParallelFor"
            Me.rbParallelFor.Size = New Size(77, 17)
            Me.rbParallelFor.TabIndex = 9
            Me.rbParallelFor.TabStop = True
            Me.rbParallelFor.Text = "Parallel.For"
            Me.rbParallelFor.UseVisualStyleBackColor = True
            ' Me.rbParallelFor.CheckedChanged += New System.EventHandler(Me.rbAPI_CheckedChanged)
            ' 
            ' rbParallelForEach
            ' 
            Me.rbParallelForEach.AutoSize = True
            Me.rbParallelForEach.Location = New Point(6, 41)
            Me.rbParallelForEach.Name = "rbParallelForEach"
            Me.rbParallelForEach.Size = New Size(102, 17)
            Me.rbParallelForEach.TabIndex = 10
            Me.rbParallelForEach.TabStop = True
            Me.rbParallelForEach.Text = "Parallel.ForEach"
            Me.rbParallelForEach.UseVisualStyleBackColor = True
            ' Me.rbParallelForEach.CheckedChanged += New System.EventHandler(Me.rbAPI_CheckedChanged)
            ' 
            ' rbPLINQ
            ' 
            Me.rbPLINQ.AutoSize = True
            Me.rbPLINQ.Location = New Point(6, 64)
            Me.rbPLINQ.Name = "rbPLINQ"
            Me.rbPLINQ.Size = New Size(57, 17)
            Me.rbPLINQ.TabIndex = 11
            Me.rbPLINQ.TabStop = True
            Me.rbPLINQ.Text = "PLINQ"
            Me.rbPLINQ.UseVisualStyleBackColor = True
            ' Me.rbPLINQ.CheckedChanged += New System.EventHandler(Me.rbAPI_CheckedChanged)
            ' 
            ' groupBox1
            ' 
            Me.groupBox1.Anchor = (CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles))
            Me.groupBox1.Controls.Add(Me.rbParallelForEach)
            Me.groupBox1.Controls.Add(Me.rbPLINQ)
            Me.groupBox1.Controls.Add(Me.rbParallelFor)
            Me.groupBox1.Location = New Point(557, 12)
            Me.groupBox1.Name = "groupBox1"
            Me.groupBox1.Size = New Size(130, 91)
            Me.groupBox1.TabIndex = 12
            Me.groupBox1.TabStop = False
            Me.groupBox1.Text = "API"
            ' 
            ' label4
            ' 
            Me.label4.Anchor = (CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles))
            Me.label4.AutoSize = True
            Me.label4.Location = New Point(556, 436)
            Me.label4.Name = "label4"
            Me.label4.Size = New Size(34, 13)
            Me.label4.TabIndex = 14
            Me.label4.Text = "Cores"
            ' 
            ' tbCores
            ' 
            Me.tbCores.Anchor = (CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles))
            Me.tbCores.LargeChange = 1
            Me.tbCores.Location = New Point(557, 459)
            Me.tbCores.Maximum = 100
            Me.tbCores.Minimum = 0
            Me.tbCores.Name = "tbCores"
            Me.tbCores.Size = New Size(123, 45)
            Me.tbCores.TabIndex = 13
            Me.tbCores.TickStyle = TickStyle.None
            Me.tbCores.Value = 0
            ' Me.tbCores.ValueChanged += New System.EventHandler(Me.tbCores_ValueChanged)
            ' 
            ' MainForm
            ' 
            Me.AutoScaleDimensions = New SizeF(6.0F, 13.0F)
            Me.AutoScaleMode = AutoScaleMode.Font
            Me.ClientSize = New Size(695, 547)
            Me.Controls.Add(Me.btnVisualize)
            Me.Controls.Add(Me.label4)
            Me.Controls.Add(Me.tbCores)
            Me.Controls.Add(Me.groupBox1)
            Me.Controls.Add(Me.label3)
            Me.Controls.Add(Me.tbWorkFactor)
            Me.Controls.Add(Me.lblTime)
            Me.Controls.Add(Me.label2)
            Me.Controls.Add(Me.label1)
            Me.Controls.Add(Me.lvWorkloads)
            Me.Controls.Add(Me.lvPartitioningMethods)
            Me.Controls.Add(Me.pbPartitionedImage)
            Me.Name = "MainForm"
            Me.Text = "Visualize Partitioning"
            CType(Me.pbPartitionedImage, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.tbWorkFactor, System.ComponentModel.ISupportInitialize).EndInit()
            Me.groupBox1.ResumeLayout(False)
            Me.groupBox1.PerformLayout()
            CType(Me.tbCores, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

#End Region

        Private pbPartitionedImage As PictureBox
        Private WithEvents btnVisualize As Button
        Private lvPartitioningMethods As ListView
        Private lvWorkloads As ListView
        Private label1 As Label
        Private label2 As Label
        Private lblTime As Label
        Private WithEvents tbWorkFactor As TrackBar
        Private label3 As Label
        Private WithEvents rbParallelFor As RadioButton
        Private WithEvents rbParallelForEach As RadioButton
        Private WithEvents rbPLINQ As RadioButton
        Private groupBox1 As GroupBox
        Private label4 As Label
        Private WithEvents tbCores As TrackBar
        Private toolTip1 As ToolTip
    End Class
End Namespace

