'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: MainForm.vb
'
'  Description: The main form window for Sudoku.
' 
'--------------------------------------------------------------------------
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Globalization
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Security
Imports System.Windows.Forms
Imports Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls
Imports Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Utilities


Namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku
	''' <summary>The main form of the Sudoku application.</summary>
	Friend NotInheritable Class MainForm
		Inherits Form
		#Region "Windows Form Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
            Dim resources = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
            Me.mainTooltips = New System.Windows.Forms.ToolTip()
            Me.backgroundPanel = New Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.ImagePanel()
            Me.pnlSavedOrNewPuzzle = New Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.ImagePanel()
            Me.lblPlaySavedGame = New System.Windows.Forms.Label()
            Me.lblDeleteSavedGameWarning = New System.Windows.Forms.Label()
            Me.lblNewGameSavedDeleted = New System.Windows.Forms.Label()
            Me.tsbLoadPreviousGame = New Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.TextStatefulButton()
            Me.tsbBeginner2 = New Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.TextStatefulButton()
            Me.tsbIntermediate2 = New Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.TextStatefulButton()
            Me.tsbAdvanced2 = New Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.TextStatefulButton()
            Me.tsbExpert2 = New Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.TextStatefulButton()
            Me.pnlNewPuzzle = New Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.ImagePanel()
            Me.lblDifficultyLevel = New System.Windows.Forms.Label()
            Me.tsbBeginner = New Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.TextStatefulButton()
            Me.tsbIntermediate = New Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.TextStatefulButton()
            Me.tsbAdvanced = New Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.TextStatefulButton()
            Me.tsbExpert = New Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.TextStatefulButton()
            Me.pnlGrid = New Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.NoFlickerPanel()
            Me.thePuzzleGrid = New Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.PuzzleGrid()
            Me.pnlControls = New Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.ScalingPanel()
            Me.optionsButton = New Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.TextStatefulButton()
            Me.newGameButton = New Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.TextStatefulButton()
            Me.undoButton = New Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.TextStatefulButton()
            Me.marqueeBar = New System.Windows.Forms.ProgressBar()
            Me.backgroundPanel.SuspendLayout()
            Me.pnlSavedOrNewPuzzle.SuspendLayout()
            Me.pnlNewPuzzle.SuspendLayout()
            Me.pnlGrid.SuspendLayout()
            Me.pnlControls.SuspendLayout()
            Me.SuspendLayout()
            '
            'mainTooltips
            '
            Me.mainTooltips.AutoPopDelay = 5000
            Me.mainTooltips.InitialDelay = 1000
            Me.mainTooltips.ReshowDelay = 100
            '
            'backgroundPanel
            '
            Me.backgroundPanel.BackColor = System.Drawing.Color.Black
            Me.backgroundPanel.Controls.Add(Me.pnlSavedOrNewPuzzle)
            Me.backgroundPanel.Controls.Add(Me.pnlNewPuzzle)
            Me.backgroundPanel.Controls.Add(Me.pnlGrid)
            Me.backgroundPanel.Controls.Add(Me.pnlControls)
            Me.backgroundPanel.Controls.Add(Me.marqueeBar)
            resources.ApplyResources(Me.backgroundPanel, "backgroundPanel")
            Me.backgroundPanel.ForeColor = System.Drawing.Color.Black
            Me.backgroundPanel.Name = "backgroundPanel"
            '
            'pnlSavedOrNewPuzzle
            '
            Me.pnlSavedOrNewPuzzle.BackColor = System.Drawing.Color.Transparent
            Me.pnlSavedOrNewPuzzle.Controls.Add(Me.lblPlaySavedGame)
            Me.pnlSavedOrNewPuzzle.Controls.Add(Me.lblDeleteSavedGameWarning)
            Me.pnlSavedOrNewPuzzle.Controls.Add(Me.lblNewGameSavedDeleted)
            Me.pnlSavedOrNewPuzzle.Controls.Add(Me.tsbLoadPreviousGame)
            Me.pnlSavedOrNewPuzzle.Controls.Add(Me.tsbBeginner2)
            Me.pnlSavedOrNewPuzzle.Controls.Add(Me.tsbIntermediate2)
            Me.pnlSavedOrNewPuzzle.Controls.Add(Me.tsbAdvanced2)
            Me.pnlSavedOrNewPuzzle.Controls.Add(Me.tsbExpert2)
            resources.ApplyResources(Me.pnlSavedOrNewPuzzle, "pnlSavedOrNewPuzzle")
            Me.pnlSavedOrNewPuzzle.ForeColor = System.Drawing.Color.Red
            Me.pnlSavedOrNewPuzzle.Name = "pnlSavedOrNewPuzzle"
            '
            'lblPlaySavedGame
            '
            resources.ApplyResources(Me.lblPlaySavedGame, "lblPlaySavedGame")
            Me.lblPlaySavedGame.ForeColor = System.Drawing.Color.White
            Me.lblPlaySavedGame.Name = "lblPlaySavedGame"
            '
            'lblDeleteSavedGameWarning
            '
            resources.ApplyResources(Me.lblDeleteSavedGameWarning, "lblDeleteSavedGameWarning")
            Me.lblDeleteSavedGameWarning.ForeColor = System.Drawing.Color.White
            Me.lblDeleteSavedGameWarning.Name = "lblDeleteSavedGameWarning"
            '
            'lblNewGameSavedDeleted
            '
            resources.ApplyResources(Me.lblNewGameSavedDeleted, "lblNewGameSavedDeleted")
            Me.lblNewGameSavedDeleted.ForeColor = System.Drawing.Color.White
            Me.lblNewGameSavedDeleted.Name = "lblNewGameSavedDeleted"
            '
            'tsbLoadPreviousGame
            '
            Me.tsbLoadPreviousGame.AdjustTextPlacementWhenChecked = False
            Me.tsbLoadPreviousGame.AllowChecking = False
            Me.tsbLoadPreviousGame.AllowNonprogrammaticUnchecking = False
            Me.tsbLoadPreviousGame.AutosizeFont = False
            Me.tsbLoadPreviousGame.BackColor = System.Drawing.Color.Gray
            Me.tsbLoadPreviousGame.Checked = False
            Me.tsbLoadPreviousGame.Focusable = True
            resources.ApplyResources(Me.tsbLoadPreviousGame, "tsbLoadPreviousGame")
            Me.tsbLoadPreviousGame.ForeColor = System.Drawing.Color.White
            Me.tsbLoadPreviousGame.Name = "tsbLoadPreviousGame"
            Me.mainTooltips.SetToolTip(Me.tsbLoadPreviousGame, resources.GetString("tsbLoadPreviousGame.ToolTip"))
            '
            'tsbBeginner2
            '
            Me.tsbBeginner2.AdjustTextPlacementWhenChecked = False
            Me.tsbBeginner2.AllowChecking = False
            Me.tsbBeginner2.AllowNonprogrammaticUnchecking = False
            Me.tsbBeginner2.AutosizeFont = False
            Me.tsbBeginner2.BackColor = System.Drawing.Color.Gray
            Me.tsbBeginner2.Checked = False
            Me.tsbBeginner2.Focusable = True
            resources.ApplyResources(Me.tsbBeginner2, "tsbBeginner2")
            Me.tsbBeginner2.ForeColor = System.Drawing.Color.White
            Me.tsbBeginner2.Name = "tsbBeginner2"
            Me.mainTooltips.SetToolTip(Me.tsbBeginner2, resources.GetString("tsbBeginner2.ToolTip"))
            '
            'tsbIntermediate2
            '
            Me.tsbIntermediate2.AdjustTextPlacementWhenChecked = False
            Me.tsbIntermediate2.AllowChecking = False
            Me.tsbIntermediate2.AllowNonprogrammaticUnchecking = False
            Me.tsbIntermediate2.AutosizeFont = False
            Me.tsbIntermediate2.BackColor = System.Drawing.Color.Gray
            Me.tsbIntermediate2.Checked = False
            Me.tsbIntermediate2.Focusable = True
            resources.ApplyResources(Me.tsbIntermediate2, "tsbIntermediate2")
            Me.tsbIntermediate2.ForeColor = System.Drawing.Color.White
            Me.tsbIntermediate2.Name = "tsbIntermediate2"
            Me.mainTooltips.SetToolTip(Me.tsbIntermediate2, resources.GetString("tsbIntermediate2.ToolTip"))
            '
            'tsbAdvanced2
            '
            Me.tsbAdvanced2.AdjustTextPlacementWhenChecked = False
            Me.tsbAdvanced2.AllowChecking = False
            Me.tsbAdvanced2.AllowNonprogrammaticUnchecking = False
            Me.tsbAdvanced2.AutosizeFont = False
            Me.tsbAdvanced2.BackColor = System.Drawing.Color.Gray
            Me.tsbAdvanced2.Checked = False
            Me.tsbAdvanced2.Focusable = True
            resources.ApplyResources(Me.tsbAdvanced2, "tsbAdvanced2")
            Me.tsbAdvanced2.ForeColor = System.Drawing.Color.White
            Me.tsbAdvanced2.Name = "tsbAdvanced2"
            Me.mainTooltips.SetToolTip(Me.tsbAdvanced2, resources.GetString("tsbAdvanced2.ToolTip"))
            '
            'tsbExpert2
            '
            Me.tsbExpert2.AdjustTextPlacementWhenChecked = False
            Me.tsbExpert2.AllowChecking = False
            Me.tsbExpert2.AllowNonprogrammaticUnchecking = False
            Me.tsbExpert2.AutosizeFont = False
            Me.tsbExpert2.BackColor = System.Drawing.Color.Gray
            Me.tsbExpert2.Checked = False
            Me.tsbExpert2.Focusable = True
            Me.tsbExpert2.ForeColor = System.Drawing.Color.White
            resources.ApplyResources(Me.tsbExpert2, "tsbExpert2")
            Me.tsbExpert2.Name = "tsbExpert2"
            Me.mainTooltips.SetToolTip(Me.tsbExpert2, resources.GetString("tsbExpert2.ToolTip"))
            '
            'pnlNewPuzzle
            '
            Me.pnlNewPuzzle.BackColor = System.Drawing.Color.Transparent
            Me.pnlNewPuzzle.Controls.Add(Me.lblDifficultyLevel)
            Me.pnlNewPuzzle.Controls.Add(Me.tsbBeginner)
            Me.pnlNewPuzzle.Controls.Add(Me.tsbIntermediate)
            Me.pnlNewPuzzle.Controls.Add(Me.tsbAdvanced)
            Me.pnlNewPuzzle.Controls.Add(Me.tsbExpert)
            resources.ApplyResources(Me.pnlNewPuzzle, "pnlNewPuzzle")
            Me.pnlNewPuzzle.ForeColor = System.Drawing.Color.Red
            Me.pnlNewPuzzle.Name = "pnlNewPuzzle"
            '
            'lblDifficultyLevel
            '
            resources.ApplyResources(Me.lblDifficultyLevel, "lblDifficultyLevel")
            Me.lblDifficultyLevel.ForeColor = System.Drawing.Color.White
            Me.lblDifficultyLevel.Name = "lblDifficultyLevel"
            '
            'tsbBeginner
            '
            Me.tsbBeginner.AdjustTextPlacementWhenChecked = False
            Me.tsbBeginner.AllowChecking = False
            Me.tsbBeginner.AllowNonprogrammaticUnchecking = False
            resources.ApplyResources(Me.tsbBeginner, "tsbBeginner")
            Me.tsbBeginner.AutosizeFont = False
            Me.tsbBeginner.BackColor = System.Drawing.Color.Gray
            Me.tsbBeginner.Checked = False
            Me.tsbBeginner.Focusable = True
            Me.tsbBeginner.ForeColor = System.Drawing.Color.White
            Me.tsbBeginner.Name = "tsbBeginner"
            Me.mainTooltips.SetToolTip(Me.tsbBeginner, resources.GetString("tsbBeginner.ToolTip"))
            '
            'tsbIntermediate
            '
            Me.tsbIntermediate.AdjustTextPlacementWhenChecked = False
            Me.tsbIntermediate.AllowChecking = False
            Me.tsbIntermediate.AllowNonprogrammaticUnchecking = False
            resources.ApplyResources(Me.tsbIntermediate, "tsbIntermediate")
            Me.tsbIntermediate.AutosizeFont = False
            Me.tsbIntermediate.BackColor = System.Drawing.Color.Gray
            Me.tsbIntermediate.Checked = False
            Me.tsbIntermediate.Focusable = True
            Me.tsbIntermediate.ForeColor = System.Drawing.Color.White
            Me.tsbIntermediate.Name = "tsbIntermediate"
            Me.mainTooltips.SetToolTip(Me.tsbIntermediate, resources.GetString("tsbIntermediate.ToolTip"))
            '
            'tsbAdvanced
            '
            Me.tsbAdvanced.AdjustTextPlacementWhenChecked = False
            Me.tsbAdvanced.AllowChecking = False
            Me.tsbAdvanced.AllowNonprogrammaticUnchecking = False
            Me.tsbAdvanced.AutosizeFont = False
            Me.tsbAdvanced.BackColor = System.Drawing.Color.Gray
            Me.tsbAdvanced.Checked = False
            Me.tsbAdvanced.Focusable = True
            resources.ApplyResources(Me.tsbAdvanced, "tsbAdvanced")
            Me.tsbAdvanced.ForeColor = System.Drawing.Color.White
            Me.tsbAdvanced.Name = "tsbAdvanced"
            Me.mainTooltips.SetToolTip(Me.tsbAdvanced, resources.GetString("tsbAdvanced.ToolTip"))
            '
            'tsbExpert
            '
            Me.tsbExpert.AdjustTextPlacementWhenChecked = False
            Me.tsbExpert.AllowChecking = False
            Me.tsbExpert.AllowNonprogrammaticUnchecking = False
            Me.tsbExpert.AutosizeFont = False
            Me.tsbExpert.BackColor = System.Drawing.Color.Gray
            Me.tsbExpert.Checked = False
            Me.tsbExpert.Focusable = True
            Me.tsbExpert.ForeColor = System.Drawing.Color.White
            resources.ApplyResources(Me.tsbExpert, "tsbExpert")
            Me.tsbExpert.Name = "tsbExpert"
            Me.mainTooltips.SetToolTip(Me.tsbExpert, resources.GetString("tsbExpert.ToolTip"))
            '
            'pnlGrid
            '
            Me.pnlGrid.BackColor = System.Drawing.Color.Black
            Me.pnlGrid.Controls.Add(Me.thePuzzleGrid)
            resources.ApplyResources(Me.pnlGrid, "pnlGrid")
            Me.pnlGrid.Name = "pnlGrid"
            '
            'thePuzzleGrid
            '
            Me.thePuzzleGrid.AllowDrop = True
            Me.thePuzzleGrid.BackColor = System.Drawing.Color.Transparent
            resources.ApplyResources(Me.thePuzzleGrid, "thePuzzleGrid")
            Me.thePuzzleGrid.ForeColor = System.Drawing.Color.Black
            Me.thePuzzleGrid.Name = "thePuzzleGrid"
            Me.thePuzzleGrid.PossibleNumbersDifficultyLevel = Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.PuzzleDifficulty.Easy
            Me.thePuzzleGrid.ShowIncorrectNumbers = True
            Me.thePuzzleGrid.ShowSuggestedCells = False
            '
            'pnlControls
            '
            Me.pnlControls.BackColor = System.Drawing.Color.Black
            Me.pnlControls.Controls.Add(Me.optionsButton)
            Me.pnlControls.Controls.Add(Me.newGameButton)
            Me.pnlControls.Controls.Add(Me.undoButton)
            resources.ApplyResources(Me.pnlControls, "pnlControls")
            Me.pnlControls.Name = "pnlControls"
            '
            'optionsButton
            '
            Me.optionsButton.AdjustTextPlacementWhenChecked = True
            Me.optionsButton.AllowChecking = False
            Me.optionsButton.AllowNonprogrammaticUnchecking = False
            resources.ApplyResources(Me.optionsButton, "optionsButton")
            Me.optionsButton.AutosizeFont = True
            Me.optionsButton.BackColor = System.Drawing.Color.LightSteelBlue
            Me.optionsButton.Checked = False
            Me.optionsButton.Focusable = False
            Me.optionsButton.ForeColor = System.Drawing.Color.White
            Me.optionsButton.Name = "optionsButton"
            Me.mainTooltips.SetToolTip(Me.optionsButton, resources.GetString("optionsButton.ToolTip"))
            '
            'newGameButton
            '
            Me.newGameButton.AdjustTextPlacementWhenChecked = True
            Me.newGameButton.AllowChecking = False
            Me.newGameButton.AllowNonprogrammaticUnchecking = False
            resources.ApplyResources(Me.newGameButton, "newGameButton")
            Me.newGameButton.AutosizeFont = True
            Me.newGameButton.BackColor = System.Drawing.Color.LightSteelBlue
            Me.newGameButton.Checked = False
            Me.newGameButton.Focusable = False
            Me.newGameButton.ForeColor = System.Drawing.Color.White
            Me.newGameButton.Name = "newGameButton"
            Me.mainTooltips.SetToolTip(Me.newGameButton, resources.GetString("newGameButton.ToolTip"))
            '
            'undoButton
            '
            Me.undoButton.AdjustTextPlacementWhenChecked = True
            Me.undoButton.AllowChecking = False
            Me.undoButton.AllowNonprogrammaticUnchecking = False
            resources.ApplyResources(Me.undoButton, "undoButton")
            Me.undoButton.AutosizeFont = True
            Me.undoButton.BackColor = System.Drawing.Color.LightSteelBlue
            Me.undoButton.Checked = False
            Me.undoButton.Focusable = False
            Me.undoButton.ForeColor = System.Drawing.Color.White
            Me.undoButton.Name = "undoButton"
            Me.mainTooltips.SetToolTip(Me.undoButton, resources.GetString("undoButton.ToolTip"))
            '
            'marqueeBar
            '
            Me.marqueeBar.ForeColor = System.Drawing.Color.Green
            resources.ApplyResources(Me.marqueeBar, "marqueeBar")
            Me.marqueeBar.Name = "marqueeBar"
            Me.marqueeBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee
            '
            'MainForm
            '
            resources.ApplyResources(Me, "$this")
            Me.BackColor = System.Drawing.Color.Black
            Me.Controls.Add(Me.backgroundPanel)
            Me.KeyPreview = True
            Me.Name = "MainForm"
            Me.backgroundPanel.ResumeLayout(False)
            Me.pnlSavedOrNewPuzzle.ResumeLayout(False)
            Me.pnlNewPuzzle.ResumeLayout(False)
            Me.pnlGrid.ResumeLayout(False)
            Me.pnlControls.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
		Private WithEvents undoButton As Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.TextStatefulButton
		Private mainTooltips As ToolTip
		Private thePuzzleGrid As Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.PuzzleGrid
		Private pnlControls As Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.ScalingPanel
		Private pnlGrid As Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.NoFlickerPanel
		Private pnlNewPuzzle As Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.ImagePanel
		Private WithEvents tsbIntermediate As Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.TextStatefulButton
		Private WithEvents tsbBeginner As Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.TextStatefulButton
		Private WithEvents tsbAdvanced As Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.TextStatefulButton
		Private WithEvents tsbExpert As Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.TextStatefulButton
		Private lblDifficultyLevel As Label
		Private pnlSavedOrNewPuzzle As Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.ImagePanel
		Private lblNewGameSavedDeleted As Label
		Private WithEvents tsbBeginner2 As Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.TextStatefulButton
		Private WithEvents tsbIntermediate2 As Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.TextStatefulButton
		Private WithEvents tsbAdvanced2 As Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.TextStatefulButton
		Private WithEvents tsbExpert2 As Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.TextStatefulButton
		Private WithEvents tsbLoadPreviousGame As Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.TextStatefulButton
		Private lblPlaySavedGame As Label
		Private lblDeleteSavedGameWarning As Label

		''' <summary>Required designer variable.</summary>
        Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>Clean up any resources being used.</summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub
		#End Region

		#Region "Member Variables"
		Private backgroundPanel As Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.ImagePanel
		Private marqueeBar As ProgressBar
		Private WithEvents newGameButton As Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.TextStatefulButton
		Private WithEvents optionsButton As Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.TextStatefulButton

		''' <summary>The last user-selected puzzle difficulty.</summary>
		Private _puzzleDifficulty As PuzzleDifficulty
		''' <summary>The options dialog for the whole run.</summary>
		Private _optionsDialog As OptionsDialog
		''' <summary>The winning animation control.</summary>
		Private _winningAnimation As WinningAnimation
		''' <summary>A list of the control buttons, like pen and eraser.</summary>
		Private _controlButtons As List(Of TextStatefulButton)
		''' <summary>Path to the saved game state file, based in Application Data.</summary>
        Private Const SAVED_STATE_USER_PATH = "\Microsoft\Sudoku\1.0\SavedGame.bin"
		''' <summary>Path to the saved settings file, based in Application Data.</summary>
        Private Const SAVED_SETTINGS_USER_PATH = "\Microsoft\Sudoku\1.0\SavedSettings.bin"
		#End Region

		#Region "Startup and Shutdown"
		''' <summary>Initializes the MainForm.</summary>
		''' <remarks>Initialization work for MainForm is split between the constructor and the Load event handler.</remarks>
		Public Sub New()
			' Initialize all of the controls
			InitializeComponent()
            pnlControls.ConfigureByContainedControls()
            Text = ResourceHelper.DisplayTitle

			' Initialize font sizes for new/save screens
            Dim newSaveLabels() = {lblDeleteSavedGameWarning, lblDifficultyLevel, lblNewGameSavedDeleted, lblPlaySavedGame}
            For Each lbl In newSaveLabels
                Dim emSize As Single
                Using g = lbl.CreateGraphics()
                    emSize = GraphicsHelpers.GetMaximumEMSize(lbl.Text, g, lbl.Font.FontFamily, lbl.Font.Style, lbl.Width, lbl.Height)
                End Using
                lbl.Font = New Font(lbl.Font.Name, emSize, lbl.Font.Style)
            Next lbl

			' Setup the dialogs used in the game
			_optionsDialog = New OptionsDialog()

			' Setup the winning animation control
			_winningAnimation = New WinningAnimation(thePuzzleGrid)
			thePuzzleGrid.Controls.Add(_winningAnimation)
			_winningAnimation.Dock = DockStyle.Fill
			_winningAnimation.BringToFront()

			' Handle changes to the state of the puzzle
			AddHandler thePuzzleGrid.StateChanged, AddressOf HandleStateChanged

			' Initialize the control/number button lists
            _controlButtons = New List(Of TextStatefulButton)()
            With _controlButtons
                .Add(newGameButton)
                .Add(optionsButton)
                .Add(undoButton)
            End With


            ' Configure the control and number buttons
            SetupTextStatefulButtonImages(_controlButtons)

            ' Setup all of the main control and background images
            optionsButton.OverlayImage = ResourceHelper.OptionsImage
            newGameButton.OverlayImage = ResourceHelper.NewImage
            undoButton.OverlayImage = ResourceHelper.UndoImage

            pnlGrid.BackColor = Color.Black
            pnlControls.BackColor = Color.Black

            ' Configure the new/saved puzzle screen
            pnlNewPuzzle.BackColor = Color.Transparent
            pnlSavedOrNewPuzzle.BackColor = Color.Transparent
            pnlNewPuzzle.Image = ResourceHelper.NewPuzzleBackground
            pnlSavedOrNewPuzzle.Image = ResourceHelper.NewPuzzleBackground
            For Each tsb As TextStatefulButton In New Object() {tsbBeginner, tsbIntermediate, tsbAdvanced, tsbExpert, tsbBeginner2,
                                                                tsbIntermediate2, tsbAdvanced2, tsbExpert2, tsbLoadPreviousGame}
                With tsb
                    .BackColor = Color.Transparent
                    .CheckedImage = ResourceHelper.NewPuzzleItemChecked
                    .UncheckedImage = ResourceHelper.NewPuzzleItemUnchecked
                    .HighlightedImage = ResourceHelper.NewPuzzleItemHighlighted
                End With
            Next tsb

            ' Load the settings for this user
            Dim windowSettingsLoaded As Boolean
            LoadSettings(windowSettingsLoaded)
            If Not windowSettingsLoaded Then
                Dim screen = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea
                Location = New Point(CType((screen.Width - Width) / 2, Integer), CType((screen.Height - Height) / 2, Integer))
                WindowState = FormWindowState.Maximized
            End If
        End Sub

		''' <summary>Set up the glass surface.</summary>
		''' <param name="e">Event args</param>
		Protected Overrides Sub OnLoad(ByVal e As EventArgs)
			MyBase.OnLoad(e)

            Dim glassUsed = False
			Try
				' If composition in the desktop window manager is enabled, look pretty with glass
				If NativeMethods.DwmIsCompositionEnabled() Then
					Dim margins As New NativeMethods.MARGINS()
					margins.Top = -1
					NativeMethods.DwmExtendFrameIntoClientArea(Me.Handle, margins)
					NativeMethods.DwmExtendFrameIntoClientArea(backgroundPanel.Handle, margins)
					NativeMethods.DwmExtendFrameIntoClientArea(pnlControls.Handle, margins)
					NativeMethods.DwmExtendFrameIntoClientArea(pnlGrid.Handle, margins)
				End If
				glassUsed = True
			Catch e1 As DllNotFoundException
			End Try
			If Not glassUsed Then
				BackColor = Color.DarkGreen
				backgroundPanel.BackColor = Color.DarkGreen
				pnlControls.BackColor = Color.DarkGreen
				pnlGrid.BackColor = Color.DarkGreen
			End If
		End Sub

		''' <summary>Sets up all StatefulButton controls in the specified panel.</summary>
		''' <param name="buttons">The controls to set up.</param>
		Private Shared Sub SetupTextStatefulButtonImages(ByVal buttons As IList)
            For Each c In buttons
                Dim sb = TryCast(c, TextStatefulButton)
                If sb IsNot Nothing Then

                    With sb
                        .ShadowImage = ResourceHelper.ButtonShadow
                        .CheckedImage = ResourceHelper.ButtonCheckedImage
                        .UncheckedImage = ResourceHelper.ButtonUncheckedImage
                        .HighlightedImage = ResourceHelper.ButtonHighlightedImage
                        .BackColor = Color.Transparent
                    End With
                End If
            Next c
		End Sub

		''' <summary>Initializes the MainForm when it's loaded.</summary>
		''' <param name="sender">The MainForm.</param>
		''' <param name="e">The event arguments.</param>
		Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			' Display the new puzzle dialog after startup.
			ShowNewPuzzleScreen()
		End Sub

		''' <summary>Hides the grid and controls, resets the form title, etc.</summary>
		Private Sub ResetFormForNewPuzzleScreen()
			Text = ResourceHelper.DisplayTitle
			_winningAnimation.Visible = False
			pnlGrid.Visible = False
			pnlControls.Visible = False
		End Sub

		''' <summary>Shows the new puzzle selection screen.</summary>
		Private Sub ShowNewPuzzleScreen()
			' Hides the grid and controls, resets the form title, etc.
			ResetFormForNewPuzzleScreen()

			' Try to open an existing state file.  If it can be opened and deserialized,
			' then show the saved or new puzzle dialog; otherwise, just show the new dialog.
            Dim showSavedOption = OpenStateFile(True)
			If showSavedOption Then
				pnlSavedOrNewPuzzle.Visible = True
				pnlSavedOrNewPuzzle.Focus()
				tsbLoadPreviousGame.Select()
			Else
				thePuzzleGrid.State = Nothing ' prevents erroneous save if new screen is closed
				pnlNewPuzzle.Visible = True
				pnlNewPuzzle.Focus()
                Select Case _puzzleDifficulty
                    
					Case PuzzleDifficulty.Medium
                        tsbIntermediate.Select()

                    Case PuzzleDifficulty.Hard
                        tsbAdvanced.Select()

                    Case PuzzleDifficulty.VeryHard
                        tsbExpert.Select()

                    Case Else
                        tsbBeginner.Select()

                End Select
			End If
		End Sub

		''' <summary>Handles interaction from the new/saved puzzle splash screens.</summary>
        Private Sub HandleNewPuzzleSelection(ByVal sender As Object, ByVal e As EventArgs) Handles tsbLoadPreviousGame.Click,
            tsbBeginner2.Click, tsbIntermediate2.Click, tsbAdvanced2.Click, tsbExpert2.Click, tsbBeginner.Click, tsbIntermediate.Click,
            tsbAdvanced.Click, tsbExpert.Click
            ' If one of the level buttons was clicked, create a new puzzle of that level
            If sender Is tsbExpert OrElse sender Is tsbAdvanced OrElse sender Is tsbIntermediate OrElse
                sender Is tsbBeginner OrElse sender Is tsbExpert2 OrElse sender Is tsbAdvanced2 OrElse
                sender Is tsbIntermediate2 OrElse sender Is tsbBeginner2 Then
                DisableBoardToSetupPuzzle()
                DeleteStateFile()

                ' Choose the level
                If sender Is tsbExpert OrElse sender Is tsbExpert2 Then
                    _puzzleDifficulty = PuzzleDifficulty.VeryHard
                ElseIf sender Is tsbAdvanced OrElse sender Is tsbAdvanced2 Then
                    _puzzleDifficulty = PuzzleDifficulty.Hard
                ElseIf sender Is tsbIntermediate OrElse sender Is tsbIntermediate2 Then
                    _puzzleDifficulty = PuzzleDifficulty.Medium
                ElseIf sender Is tsbBeginner OrElse sender Is tsbBeginner2 Then
                    _puzzleDifficulty = PuzzleDifficulty.Easy
                End If

                ' Create the generation options for the puzzle based on the user's difficulty choice and on their settings
                Dim options = GeneratorOptions.Create(_puzzleDifficulty)

                With options
                    .EnsureSymmetry = _optionsDialog.ConfiguredOptions.CreatePuzzlesWithSymmetry
                    .ParallelGeneration = _optionsDialog.ConfiguredOptions.ParallelPuzzleGeneration
                    .SpeculativeGeneration = _optionsDialog.ConfiguredOptions.SpeculativePuzzleGeneration
                End With

                ' Start creating the new puzzle
                Dim startNewPuzzle As New GenerateNewPuzzleHandler(AddressOf thePuzzleGrid.GenerateNewPuzzle)
                startNewPuzzle.BeginInvoke(options, New AsyncCallback(AddressOf ResetBoardAfterNewPuzzle), startNewPuzzle)
                ' Otherwise, the load button was clicked, so load the previous game
            ElseIf sender Is tsbLoadPreviousGame Then
                If OpenStateFile(False) Then
                    ResetBoardAfterNewPuzzle(Nothing)
                End If
            End If
        End Sub

        ''' <summary>Disables controls on the board while a puzzle is being loaded.</summary>
        Private Sub DisableBoardToSetupPuzzle()
            ' Make sure the screen doesn't flash too much.  To do that, put a *minimum*
            ' amount of wait time into effect
            _startNewPuzzleTime = Date.UtcNow

            ' Disable the board
            pnlNewPuzzle.Visible = False
            pnlSavedOrNewPuzzle.Visible = False
            _winningAnimation.Visible = False
            thePuzzleGrid.Visible = False
            pnlGrid.Visible = False
            pnlControls.Visible = False

            ' Enable the progress bar
            marqueeBar.Visible = True
        End Sub

        ''' <summary>Enables asynchronous creation of puzzles.</summary>
        Private Delegate Sub GenerateNewPuzzleHandler(ByVal options As GeneratorOptions)

        ''' <summary>Used to time how long it takes to generate a new puzzle.</summary>
        Private _startNewPuzzleTime As Date

        ''' <summary>Finishes setting up the board after a new puzzle is created.</summary>
        ''' <param name="result">Can be null if puzzle was generated synchronously.</param>
        Private Sub ResetBoardAfterNewPuzzle(ByVal result As IAsyncResult)
            ' Make sure we're running on the UI thread
            If InvokeRequired Then
                Invoke(New AsyncCallback(AddressOf ResetBoardAfterNewPuzzle), New Object() {result})
                Return
            End If

            ' Finish the call to GenerateNewPuzzle
            Try
                If result IsNot Nothing AndAlso TypeOf result.AsyncState Is GenerateNewPuzzleHandler Then
                    CType(result.AsyncState, GenerateNewPuzzleHandler).EndInvoke(result)
                End If
            Finally
                ' Disable the progress bar
                marqueeBar.Visible = False

                ' Enable the board
                SuspendLayout()
                For Each c In _controlButtons
                    c.Visible = True
                Next c
                ResumeLayout()

                pnlNewPuzzle.Visible = False
                pnlSavedOrNewPuzzle.Visible = False
                pnlGrid.Visible = True
                pnlControls.Visible = True

                backgroundPanel.Enabled = True
                thePuzzleGrid.Visible = True
                thePuzzleGrid.Enabled = True
                OnResize(EventArgs.Empty)
                thePuzzleGrid.Focus()

                ' Set the title to include the difficulty level
                Dim titleText = ResourceHelper.DisplayTitleWithDifficultyLevel
                Dim diffText = Nothing
                Select Case thePuzzleGrid.State.Difficulty
                    Case PuzzleDifficulty.Easy
                        diffText = ResourceHelper.EasyDifficultyLevel
                    Case PuzzleDifficulty.Medium
                        diffText = ResourceHelper.MediumDifficultyLevel
                    Case PuzzleDifficulty.Hard
                        diffText = ResourceHelper.HardDifficultyLevel
                    Case PuzzleDifficulty.VeryHard
                        diffText = ResourceHelper.VeryHardDifficultyLevel
                    Case Else
                        titleText = ResourceHelper.DisplayTitle
                End Select
                Text = If((diffText IsNot Nothing), String.Format(CultureInfo.CurrentCulture, titleText, diffText), titleText)
            End Try
        End Sub

        ''' <summary>Handles cleanup when the MainForm is closed.</summary>
        ''' <param name="sender">The MainForm.</param>
        ''' <param name="e">The event args.</param>
        Private Sub MainForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
            ' If the puzzle grid is visible (meaning we're not on the open/save/thinking screens),
            ' delete the existing state file and save a new one in its place.  Deletion is necessary
            ' before saving in case SaveStateFile determines that the current puzzle doesn't need to be saved
            ' because it hasn't been modified from the original.
            If thePuzzleGrid.Visible Then
                DeleteStateFile()
                SaveStateFile()
            End If

            ' Save the options/settings
            SaveSettings()
        End Sub

        ''' <summary>Focus the PuzzleGrid on activation.</summary>
        ''' <param name="e">The event arguments.</param>
        Protected Overrides Sub OnActivated(ByVal e As EventArgs)
            ' Make sure that when the main form is activated, the puzzle grid
            ' is given focus.  Without this, keyboard interaction with the puzzle
            ' grid can break down.
            MyBase.OnActivated(e)
            thePuzzleGrid.Focus()
        End Sub

        ''' <summary>Warns the user that by creating a new puzzle they'll lose their current puzzle.</summary>
        ''' <returns>true if the user wants to delete the current puzzle; false, otherwise.</returns>
        ''' <remarks>Won't warn the user if they don't want to be warned or if nothing has changed in the current puzzle.</remarks>
        Private Function WarningForUnsolvedPuzzleOnNew() As Boolean
            If _optionsDialog.ConfiguredOptions.PromptOnPuzzleDelete Then
                If thePuzzleGrid.PuzzleHasBeenModified Then
                    ' Get the status of the puzzle.  If it's not solved, ask the user if they'd like
                    ' to save it.
                    Dim result = MessageBox.Show(ResourceHelper.AboutToLosePuzzle, ResourceHelper.DisplayTitle,
                                MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
                                GetMessageBoxOptions(Me))

                    Return result = DialogResult.Yes
                End If
            End If
            Return True
        End Function

        ''' <summary>Responds to resizing of the main form.</summary>
        ''' <param name="e">The event arguments</param>
        Protected Overrides Sub OnResize(ByVal e As EventArgs)
            ' Do the base resizing
            MyBase.OnResize(e)

            ' Put the new puzzle panel in the middle
            pnlNewPuzzle.Location = New Point(CType((backgroundPanel.Location.X + (backgroundPanel.Width - pnlNewPuzzle.Width) / 2),
                            Integer), CType((backgroundPanel.Location.Y + (backgroundPanel.Height - pnlNewPuzzle.Height) / 2), Integer))
            pnlSavedOrNewPuzzle.Location = New Point(CType((backgroundPanel.Location.X + (backgroundPanel.Width -
                            pnlSavedOrNewPuzzle.Width) / 2), Integer), CType((backgroundPanel.Location.Y +
                            (backgroundPanel.Height - pnlSavedOrNewPuzzle.Height) / 2), Integer))

            ' Make sure that when we resize the form that the puzzle grid
            ' stays in the center and square, as big as it can be while not exceeding its parent's bounds
            Dim width = pnlGrid.Width
            Dim height = pnlGrid.Height
            Dim margin = 25
            Dim gridSize = If(width > height, New Size(height - margin, height - margin), New Size(width - margin, width - margin))
            thePuzzleGrid.Bounds = New Rectangle(New Point(CType(((width - gridSize.Width) / 2), Integer),
                                    CType(((height - gridSize.Height) / 2), Integer)), gridSize)

            ' Make sure that no matter how the form resizes that the
            ' marquee progress bar ends up in the center of the form.
            marqueeBar.Location = New Point(CType((backgroundPanel.Location.X + (backgroundPanel.Width - marqueeBar.Width) / 2), Integer),
                        CType((backgroundPanel.Location.Y + (backgroundPanel.Height - marqueeBar.Height) / 2), Integer))
        End Sub

        ''' <summary>Responds to layout changes on the main form.</summary>
        ''' <param name="levent"></param>
        Protected Overrides Sub OnLayout(ByVal levent As LayoutEventArgs)
            ' Ensure relative widths of panels
            pnlControls.Width = Width \ 6

            ' Do base layout.
            MyBase.OnLayout(levent)
        End Sub

        ''' <summary>Gets the message box options to use given the current state of the form.</summary>
        ''' <param name="parent">The parent of the message box to be displayed.</param>
        ''' <returns>The MessageBoxOptions to be used with MessageBox.Show.</returns>
        Friend Shared Function GetMessageBoxOptions(ByVal parent As Control) As MessageBoxOptions
            Return If((parent IsNot Nothing AndAlso parent.RightToLeft = RightToLeft.Yes), MessageBoxOptions.RightAlign Or
                      MessageBoxOptions.RtlReading, New MessageBoxOptions())
        End Function

        ''' <summary>Responds when any changes are made to the current puzzle's state (or when a new puzzle is made current).</summary>
        ''' <param name="sender">The PuzzleGrid or PuzzleState.</param>
        ''' <param name="e">The event arguments.</param>
        Private Sub HandleStateChanged(ByVal sender As Object, ByVal e As EventArgs)
            ' If the puzzle is solved...
            If thePuzzleGrid.State.Status = PuzzleStatus.Solved Then
                ' Disable the grid (can't interact with a solved puzzle)
                SuspendLayout()
                thePuzzleGrid.Enabled = False
                undoButton.Enabled = False
                ResumeLayout()

                ' Delete any state file that may have resulted from a power-save
                DeleteStateFile()

                ' Show the winning animation
                Refresh()
                _winningAnimation.Visible = True
                ' Otherwise, if the puzzle is not solved, make sure the grid is enabled
            Else
                _winningAnimation.Visible = False

                SuspendLayout()
                thePuzzleGrid.Enabled = True
                undoButton.Enabled = thePuzzleGrid.UndoStates.Count > 0
                ResumeLayout()
            End If
        End Sub

        ''' <summary>Handle Windows messages</summary>
        ''' <param name="m">The Windows message.</param>
        Protected Overrides Sub WndProc(ByRef m As Message)
            ' Delegate to the base implementation
            MyBase.WndProc(m)

            ' The WM_POWERBROADCAST message is broadcast to an application to notify it of power-management events.
            Const WM_POWERBROADCAST = &H218
            ' The WM_DISPLAYCHANGE message is sent to all windows when the display resolution has changed.
            Const WM_DISPLAYCHANGE = &H7E
            ' The PBT_APMSUSPEND event is broadcast immediately before the computer enters a suspended state.
            Const PBT_APMSUSPEND = &H4
            ' The PBT_APMSUSPEND event is broadcast immediately before the computer enters a standby state.
            Const PBT_APMSTANDBY = &H5
            ' The PBT_APMBATTERYLOW event is broadcast to notify applications that battery power is low.
            Const PBT_APMBATTERYLOW = &H9

            Select Case m.Msg
                ' Save the puzzle when something power-related happens, just in case
                Case WM_POWERBROADCAST
                    Select Case CInt(Fix(m.WParam))
                        Case PBT_APMBATTERYLOW, PBT_APMSTANDBY, PBT_APMSUSPEND
                            SaveStateFile()
                    End Select

                    ' Make sure everything is within the correct boundaries
                Case WM_DISPLAYCHANGE
                    ' Make sure dialogs are within screen boundaries
                    Dim screenRect = Screen.GetWorkingArea(Me)
                    Dim f = Me
                    Dim bounds = GetRestoreBounds(f)
                    If Not screenRect.Contains(bounds) Then
                        f.Location = New Point(CType(((screenRect.Width - bounds.Width) / 2), Integer),
                                               CType(((screenRect.Height - bounds.Height) / 2), Integer))
                    End If
            End Select
        End Sub
#End Region

#Region "Loading and Saving Puzzles and Settings"
        ''' <summary>Loads a saved state from the specified stream.</summary>
        ''' <param name="s">The stream from which to load the state.</param>
        ''' <param name="testOnly">true if the state shouldn't be loaded into the grid, but only tested to see if it can be parsed.</param>
        Private Sub LoadStateFileToGrid(ByVal s As Stream, ByVal testOnly As Boolean)
            ' Deserialize from the state file
            Dim formatter As New BinaryFormatter()
            formatter.Deserialize(s) ' Version v = (Version)
            Dim state = CType(formatter.Deserialize(s), PuzzleState)
            Dim originalState = CType(formatter.Deserialize(s), PuzzleState)
            Dim undoStates As Stack(Of PuzzleState) = CType(formatter.Deserialize(s), Stack(Of PuzzleState))

            ' Restore state and original state, undo states.  Note that LoadStateFileToGrid
            ' can be called simply to test whether the state file can be deserialized, so
            ' don't restore the puzzle if it was just a test.
            If Not testOnly Then
                thePuzzleGrid.RestorePuzzle(state, originalState, undoStates)
            End If
        End Sub

        ''' <summary>Stores the current state to the specified stream.</summary>
        ''' <param name="s">The stream to which the current state should be written.</param>
        Private Sub StoreStateFileFromGrid(ByVal s As Stream)
            ' Serialize:
            ' 1. The main version number
            ' 2. The current state of the board
            ' 3. The original board
            ' 4. The undo states
            Dim formatter As New BinaryFormatter()
            With formatter
                .Serialize(s, System.Reflection.Assembly.GetEntryAssembly().GetName().Version)
                .Serialize(s, thePuzzleGrid.State)
                .Serialize(s, thePuzzleGrid.OriginalState)
                .Serialize(s, thePuzzleGrid.UndoStates)
            End With
        End Sub

        ''' <summary>Opens a state file containing a saved game.</summary>
        ''' <param name="testOnly">true if the state shouldn't be loaded into the grid, but only tested to see if it can be parsed.</param>
        ''' <returns>true if the file was successfully parsed; false, otherwise.</returns>
        Private Function OpenStateFile(ByVal testOnly As Boolean) As Boolean
            Try
                Using s = File.OpenRead(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & SAVED_STATE_USER_PATH)
                    LoadStateFileToGrid(s, testOnly)
                    Return True
                End Using
            Catch e1 As ArgumentException
            Catch e2 As IOException
            Catch e3 As SecurityException
            Catch e4 As SerializationException
            Catch e5 As InvalidOperationException
            Catch e6 As UnauthorizedAccessException
            End Try
            Return False
        End Function

        ''' <summary>Deletes a saved game state file, if one exists.</summary>
        Private Shared Sub DeleteStateFile()
            Try
                Dim path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & SAVED_STATE_USER_PATH
                File.Delete(path)
            Catch e1 As ArgumentException
            Catch e2 As IOException
            Catch e3 As SecurityException
            Catch e4 As UnauthorizedAccessException
            End Try
        End Sub

        ''' <summary>Saves the current puzzle state.</summary>
        ''' <returns>true if a state was saved; false, otherwise.</returns>
        Friend Function SaveStateFile() As Boolean
            If thePuzzleGrid.PuzzleHasBeenModified Then
                ' Make sure we're not weirdly serializing an empty board
                Dim state = thePuzzleGrid.State
                Dim anyCellSet = False
                For Each cell? As Byte In state
                    If cell.HasValue Then
                        anyCellSet = True
                        Exit For
                    End If
                Next cell

                ' If any cells have values, go ahead and write out the state file
                If anyCellSet Then
                    Dim path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & SAVED_STATE_USER_PATH
                    Try
                        Dim parentDir = Directory.GetParent(path)
                        If Not parentDir.Exists Then
                            parentDir.Create()
                        End If
                    Catch e1 As ArgumentException
                    Catch e2 As IOException
                    Catch e3 As SecurityException
                    Catch e4 As UnauthorizedAccessException
                    End Try

                    Try
                        Using s = File.OpenWrite(path)
                            StoreStateFileFromGrid(s)
                            Return True
                        End Using
                    Catch e5 As ArgumentException
                    Catch e6 As IOException
                    Catch e7 As SerializationException
                    Catch e8 As UnauthorizedAccessException
                    End Try
                End If
            End If
            Return False
        End Function

        ''' <summary>Loads the user's settings from their settings store.</summary>
        Private Sub LoadSettings(<System.Runtime.InteropServices.Out()> ByRef windowSettingsLoaded As Boolean)
            ' Initialize out values
            windowSettingsLoaded = False

            ' Set defaults
            Dim options = _optionsDialog.ConfiguredOptions
            thePuzzleGrid.ShowIncorrectNumbers = options.ShowIncorrectCells
            thePuzzleGrid.ShowSuggestedCells = options.SuggestEasyCells

            ' Get the path to where settings are stored
            Dim formatter As New BinaryFormatter()
            Dim path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & SAVED_SETTINGS_USER_PATH
            Try
                Dim parentDir = Directory.GetParent(path)
                If Not parentDir.Exists Then
                    parentDir.Create()
                End If
            Catch e1 As ArgumentException
            Catch e2 As IOException
            Catch e3 As SecurityException
            Catch e4 As UnauthorizedAccessException
            End Try

            Try
                ' Open the settings file and read in all options
                Using s = File.OpenRead(path)
                    options = CType(formatter.Deserialize(s), ConfigurationOptions)
                    Dim diff = CType(formatter.Deserialize(s), PuzzleDifficulty)
                    Dim windowBounds = CType(formatter.Deserialize(s), Rectangle)
                    Dim maximized = CBool(formatter.Deserialize(s))

                    With _optionsDialog
                        .ConfiguredOptions.CreatePuzzlesWithSymmetry = options.CreatePuzzlesWithSymmetry
                        .ConfiguredOptions.PromptOnPuzzleDelete = options.PromptOnPuzzleDelete
                        .ConfiguredOptions.ShowIncorrectCells = options.ShowIncorrectCells
                        .ConfiguredOptions.SuggestEasyCells = options.SuggestEasyCells
                        .ConfiguredOptions.ParallelPuzzleGeneration = options.ParallelPuzzleGeneration
                        .ConfiguredOptions.SpeculativePuzzleGeneration = options.SpeculativePuzzleGeneration
                    End With

                    thePuzzleGrid.ShowIncorrectNumbers = options.ShowIncorrectCells
                    thePuzzleGrid.ShowSuggestedCells = options.SuggestEasyCells

                    Select Case diff
                        Case PuzzleDifficulty.Easy, PuzzleDifficulty.Medium, PuzzleDifficulty.Hard, PuzzleDifficulty.VeryHard
                            _puzzleDifficulty = diff
                        Case Else
                            _puzzleDifficulty = PuzzleDifficulty.Easy
                    End Select

                    If maximized Then
                        WindowState = FormWindowState.Maximized
                    End If
                    If Screen.PrimaryScreen.WorkingArea.Contains(windowBounds) Then
                        Bounds = windowBounds
                    Else

                        Dim screen = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea
                        Location = New Point(CType(((screen.Width - Width) / 2), Integer), CType(((screen.Height - Height) / 2), Integer))
                    End If
                    windowSettingsLoaded = True
                End Using
            Catch e5 As ArgumentException
            Catch e6 As IOException
            Catch e7 As InvalidCastException
            Catch e8 As SerializationException
            End Try
        End Sub

        ''' <summary>Gets the bounds of the form when it's at its normal (non-maximized and non-minimized) size.</summary>
        ''' <param name="c">The form for which we need the normal bounds.</param>
        ''' <returns>The restored bounds of the control.</returns>
        Private Function GetRestoreBounds(ByVal f As Form) As Rectangle
            ' Get the normal window bounds
            Dim placement As New NativeMethods.WINDOWPLACEMENT()
            placement.length = Marshal.SizeOf(GetType(NativeMethods.WINDOWPLACEMENT))
            NativeMethods.GetWindowPlacement(New HandleRef(Me, f.Handle), placement)
            Return New Rectangle(placement.rcNormalPosition_left, placement.rcNormalPosition_top, placement.rcNormalPosition_right -
                          placement.rcNormalPosition_left + 1, placement.rcNormalPosition_bottom - placement.rcNormalPosition_top + 1)
        End Function

        ''' <summary>Saves the user's settings to their settings store.</summary>
        Private Sub SaveSettings()
            Dim formatter As New BinaryFormatter()
            Dim path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & SAVED_SETTINGS_USER_PATH

            ' Make sure settings directory has been created
            Try
                Dim parentDir = Directory.GetParent(path)
                If Not parentDir.Exists Then
                    parentDir.Create()
                End If
            Catch e1 As ArgumentException
            Catch e2 As IOException
            Catch e3 As SecurityException
            Catch e4 As UnauthorizedAccessException
            End Try

            Try
                ' Get configuration options and new puzzle difficulty
                Dim options = _optionsDialog.ConfiguredOptions
                Dim difficulty = _puzzleDifficulty

                ' Get the normal window bounds
                Dim windowBounds = GetRestoreBounds(Me)

                ' Allow restoration to a maximized state
                Dim maximized = (WindowState = FormWindowState.Maximized)

                ' Save everything out to the settings file
                Using s = File.OpenWrite(path)
                    With formatter
                        .Serialize(s, options)
                        .Serialize(s, difficulty)
                        .Serialize(s, windowBounds)
                        .Serialize(s, maximized)
                    End With
                End Using
            Catch e5 As ArgumentException
            Catch e6 As InvalidCastException
            Catch e7 As IOException
            Catch e8 As SerializationException
            End Try
        End Sub
#End Region

#Region "Keyboard Handling"
        ''' <summary>Handle key down events to account for full-screen and non-square modes.</summary>
        ''' <param name="e">The event arguments.</param>
        Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)
            ' ctrl-Z == Undo
            If (e.KeyCode = Keys.Z AndAlso ((Control.ModifierKeys And Keys.Control) = Keys.Control)) AndAlso _
              thePuzzleGrid.Visible AndAlso thePuzzleGrid.UndoStates.Count > 0 AndAlso thePuzzleGrid.State.Status <>
              PuzzleStatus.Solved Then
                thePuzzleGrid.Undo()
                ' ctrl-C == Copy the puzzle to the clipboard
            ElseIf (e.KeyCode = Keys.C AndAlso ((Control.ModifierKeys And Keys.Control) = Keys.Control)) AndAlso
                thePuzzleGrid.Visible Then
                Clipboard.SetText(thePuzzleGrid.State.ToString(), TextDataFormat.Text)
                ' F2 = New puzzle
            ElseIf e.KeyCode = Keys.F2 AndAlso newGameButton.Visible AndAlso newGameButton.Enabled Then
                newGameButton_Click(Me, New MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0))
                ' ctrl+F5 = Clear puzzle
            ElseIf (e.Control AndAlso e.KeyCode = Keys.F5) AndAlso newGameButton.Visible AndAlso newGameButton.Enabled Then
                With thePuzzleGrid
                    .State = Nothing
                    .ClearUndoCheckpoints()
                    .ClearOriginalPuzzleCheckpoint()
                End With
                DeleteStateFile()
                ' ctrl-O = options
            ElseIf e.KeyCode = Keys.O AndAlso ((Control.ModifierKeys And Keys.Control) = Keys.Control) AndAlso
                optionsButton.Visible AndAlso optionsButton.Enabled Then
                optionsButton_Click(Me, New MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0))
                ' otherwise, pass it along
            Else
                MyBase.OnKeyDown(e)
            End If
        End Sub
#End Region

#Region "Button Handling"
        ''' <summary>Exits when the exit button is clicked.</summary>
        Private Sub exitButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            Close()
        End Sub

        ''' <summary>Opens the options dialog.</summary>
        Private Sub optionsButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles optionsButton.Click
            If _optionsDialog.ShowDialog(Me) = DialogResult.OK Then
                SaveSettings()
                Dim options = _optionsDialog.ConfiguredOptions
                thePuzzleGrid.ShowSuggestedCells = options.SuggestEasyCells
                thePuzzleGrid.ShowIncorrectNumbers = options.ShowIncorrectCells
            End If
        End Sub

        ''' <summary>Starts a new game.</summary>
        Private Sub newGameButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles newGameButton.Click
            If WarningForUnsolvedPuzzleOnNew() Then
                ' Hide the puzzle grid, reset the title bar, etc.
                ResetFormForNewPuzzleScreen()

                ' Delete current and saved puzzle
                With thePuzzleGrid
                    .State = Nothing
                    .ClearUndoCheckpoints()
                    .ClearOriginalPuzzleCheckpoint()
                End With
                DeleteStateFile()

                ' Now, prompt the user to create a new puzzle
                ShowNewPuzzleScreen()
            End If
        End Sub

        ''' <summary>Undo for the previous action.</summary>
        Private Sub undoButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles undoButton.Click
            thePuzzleGrid.Undo()
        End Sub
#End Region

    End Class
End Namespace