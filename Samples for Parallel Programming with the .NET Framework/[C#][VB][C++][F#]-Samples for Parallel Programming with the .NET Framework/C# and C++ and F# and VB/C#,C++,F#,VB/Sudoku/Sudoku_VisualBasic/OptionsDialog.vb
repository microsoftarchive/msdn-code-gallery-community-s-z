'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: OptionsDialog.vb
'
'  Description: Dialog for user configuration options.
' 
'--------------------------------------------------------------------------


Namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku
	''' <summary>Presents configuration options to the user.</summary>
	Friend Class OptionsDialog
		Inherits Form
		Private groupBox1 As GroupBox
		Private WithEvents chkShowIncorrectCells As CheckBox
		Private chkHighlightEasyCell As CheckBox
		Private groupBox2 As GroupBox
		Private groupBox3 As GroupBox
		Private chkCreateWithSymmetry As CheckBox
		Private chkPromptOnDelete As CheckBox
		Private btnCancel As Button
		Private WithEvents btnOK As Button
		Private chkParallelPuzzleGeneration As CheckBox
		Private chkSpeculativeGeneration As CheckBox
		Private components As System.ComponentModel.Container = Nothing

		''' <summary>Initializes the OptionsDialog.</summary>
		Public Sub New()
			InitializeComponent()
		End Sub

		''' <summary>Cleans up.</summary>
		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If components IsNot Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(OptionsDialog))
			Me.groupBox1 = New GroupBox()
			Me.chkHighlightEasyCell = New CheckBox()
			Me.chkShowIncorrectCells = New CheckBox()
			Me.groupBox2 = New GroupBox()
			Me.chkParallelPuzzleGeneration = New CheckBox()
			Me.chkCreateWithSymmetry = New CheckBox()
			Me.groupBox3 = New GroupBox()
			Me.chkPromptOnDelete = New CheckBox()
			Me.btnCancel = New Button()
			Me.btnOK = New Button()
			Me.chkSpeculativeGeneration = New CheckBox()
			Me.groupBox1.SuspendLayout()
			Me.groupBox2.SuspendLayout()
			Me.groupBox3.SuspendLayout()
			Me.SuspendLayout()
			' 
			' groupBox1
			' 
			resources.ApplyResources(Me.groupBox1, "groupBox1")
			Me.groupBox1.Controls.Add(Me.chkHighlightEasyCell)
			Me.groupBox1.Controls.Add(Me.chkShowIncorrectCells)
			Me.groupBox1.FlatStyle = FlatStyle.System
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.TabStop = False
			' 
			' chkHighlightEasyCell
			' 
			Me.chkHighlightEasyCell.AccessibleRole = AccessibleRole.HotkeyField
			resources.ApplyResources(Me.chkHighlightEasyCell, "chkHighlightEasyCell")
			Me.chkHighlightEasyCell.Name = "chkHighlightEasyCell"
			' 
			' chkShowIncorrectCells
			' 
			resources.ApplyResources(Me.chkShowIncorrectCells, "chkShowIncorrectCells")
			Me.chkShowIncorrectCells.AccessibleRole = AccessibleRole.HotkeyField
			Me.chkShowIncorrectCells.Name = "chkShowIncorrectCells"
'			Me.chkShowIncorrectCells.CheckedChanged += New System.EventHandler(Me.chkShowIncorrectCells_CheckedChanged)
			' 
			' groupBox2
			' 
			resources.ApplyResources(Me.groupBox2, "groupBox2")
			Me.groupBox2.Controls.Add(Me.chkSpeculativeGeneration)
			Me.groupBox2.Controls.Add(Me.chkParallelPuzzleGeneration)
			Me.groupBox2.Controls.Add(Me.chkCreateWithSymmetry)
			Me.groupBox2.FlatStyle = FlatStyle.System
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.TabStop = False
			' 
			' chkParallelPuzzleGeneration
			' 
			Me.chkParallelPuzzleGeneration.AccessibleRole = AccessibleRole.HotkeyField
			resources.ApplyResources(Me.chkParallelPuzzleGeneration, "chkParallelPuzzleGeneration")
			Me.chkParallelPuzzleGeneration.Name = "chkParallelPuzzleGeneration"
			' 
			' chkCreateWithSymmetry
			' 
			Me.chkCreateWithSymmetry.AccessibleRole = AccessibleRole.HotkeyField
			resources.ApplyResources(Me.chkCreateWithSymmetry, "chkCreateWithSymmetry")
			Me.chkCreateWithSymmetry.Name = "chkCreateWithSymmetry"
			' 
			' groupBox3
			' 
			resources.ApplyResources(Me.groupBox3, "groupBox3")
			Me.groupBox3.Controls.Add(Me.chkPromptOnDelete)
			Me.groupBox3.FlatStyle = FlatStyle.System
			Me.groupBox3.Name = "groupBox3"
			Me.groupBox3.TabStop = False
			' 
			' chkPromptOnDelete
			' 
			Me.chkPromptOnDelete.AccessibleRole = AccessibleRole.HotkeyField
			resources.ApplyResources(Me.chkPromptOnDelete, "chkPromptOnDelete")
			Me.chkPromptOnDelete.Name = "chkPromptOnDelete"
			' 
			' btnCancel
			' 
			resources.ApplyResources(Me.btnCancel, "btnCancel")
			Me.btnCancel.DialogResult = DialogResult.Cancel
			Me.btnCancel.Name = "btnCancel"
			' 
			' btnOK
			' 
			resources.ApplyResources(Me.btnOK, "btnOK")
			Me.btnOK.DialogResult = DialogResult.OK
			Me.btnOK.Name = "btnOK"
'			Me.btnOK.Click += New System.EventHandler(Me.btnOK_Click)
			' 
			' chkSpeculativeGeneration
			' 
			Me.chkSpeculativeGeneration.AccessibleRole = AccessibleRole.HotkeyField
			resources.ApplyResources(Me.chkSpeculativeGeneration, "chkSpeculativeGeneration")
			Me.chkSpeculativeGeneration.Name = "chkSpeculativeGeneration"
			' 
			' OptionsDialog
			' 
			Me.AcceptButton = Me.btnOK
			resources.ApplyResources(Me, "$this")
			Me.CancelButton = Me.btnCancel
			Me.Controls.Add(Me.btnOK)
			Me.Controls.Add(Me.btnCancel)
			Me.Controls.Add(Me.groupBox3)
			Me.Controls.Add(Me.groupBox2)
			Me.Controls.Add(Me.groupBox1)
			Me.FormBorderStyle = FormBorderStyle.FixedDialog
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "OptionsDialog"
			Me.ShowInTaskbar = False
			Me.SizeGripStyle = SizeGripStyle.Hide
			Me.groupBox1.ResumeLayout(False)
			Me.groupBox2.ResumeLayout(False)
			Me.groupBox3.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		''' <summary>The configuration options for this dialog.</summary>
		Private _options As New ConfigurationOptions()

		''' <summary>Gets the configuration options.</summary>
		Public ReadOnly Property ConfiguredOptions() As ConfigurationOptions
			Get
				Return _options
			End Get
		End Property

		''' <summary>Sets up the form based on the current configuration options.</summary>
		Protected Overrides Sub OnVisibleChanged(ByVal e As EventArgs)
			If Visible Then
				chkHighlightEasyCell.Checked = _options.SuggestEasyCells
				chkShowIncorrectCells.Checked = _options.ShowIncorrectCells
				chkCreateWithSymmetry.Checked = _options.CreatePuzzlesWithSymmetry
				chkPromptOnDelete.Checked = _options.PromptOnPuzzleDelete
				chkParallelPuzzleGeneration.Checked = _options.ParallelPuzzleGeneration
				chkSpeculativeGeneration.Checked = _options.SpeculativePuzzleGeneration
				ConfiguredEnabledCheckboxes()

				btnOK.Select()
			End If
			MyBase.OnVisibleChanged (e)
		End Sub

		''' <summary>Sets up the configuration options based on the status of the form.</summary>
        Private Sub btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOK.Click
            With _options
                .SuggestEasyCells = chkHighlightEasyCell.Checked
                .ShowIncorrectCells = chkShowIncorrectCells.Checked
                .CreatePuzzlesWithSymmetry = chkCreateWithSymmetry.Checked
                .PromptOnPuzzleDelete = chkPromptOnDelete.Checked
                .ParallelPuzzleGeneration = chkParallelPuzzleGeneration.Checked
                .SpeculativePuzzleGeneration = chkSpeculativeGeneration.Checked
            End With
        End Sub

		''' <summary>Enables or disables the highlight easy cells option based on the show incorrect values option.</summary>
        Private Sub chkShowIncorrectCells_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkShowIncorrectCells.CheckedChanged
            ConfiguredEnabledCheckboxes()
        End Sub

        ''' <summary>Configures chkHighlightEasyCell based on whether chkShowIncorrectCells is checked.</summary>
        Private Sub ConfiguredEnabledCheckboxes()
            If chkShowIncorrectCells.Checked Then
                chkHighlightEasyCell.Enabled = True
            Else
                chkHighlightEasyCell.Enabled = False
                chkHighlightEasyCell.Checked = False
            End If
        End Sub
    End Class
End Namespace