'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: ResourceHelper.vb
'
'  Description: Strongly-typed access to resources.
' 
'--------------------------------------------------------------------------
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Reflection
Imports System.Resources


Namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku
    ''' <summary>Provides strongly-typed resource access to the rest of the application.</summary>
    Friend NotInheritable Class ResourceHelper
        ''' <summary>The name of the resource file containing the string resources for this application.</summary>
        Private Const _stringsResourceFileName = "Strings"
       
        ''' <summary>The resource manager used to load all resources.</summary>
        Private Shared _manager As ResourceManager
        ''' <summary>This assembly.</summary>
        Private Shared _resourceAssembly As System.Reflection.Assembly

        ''' <summary>Image displayed as the shadow for a standard button.</summary>
        Private Shared _buttonShadow As Bitmap
        ''' <summary>Image displayed when a button is in the checked state.</summary>
        Private Shared _buttonCheckedImage As Bitmap
        ''' <summary>Image displayed when a button is in the unchecked state.</summary>
        Private Shared _buttonUncheckedImage As Bitmap
        ''' <summary>Image displayed when a button is in the highlighted state.</summary>
        Private Shared _buttonHighlightedImage As Bitmap

        ''' <summary>Icon for the new puzzle button.</summary>
        Private Shared _newPuzzleImage As Bitmap
        ''' <summary>Icon for the options button.</summary>
        Private Shared _optionsImage As Bitmap
        ''' <summary>Icon for the undo button.</summary>
        Private Shared _undoImage As Bitmap

        ''' <summary>The board image containing each cell.</summary>
        Private Shared _boardImage As Bitmap
        ''' <summary>The backdrop image for the board.</summary>
        Private Shared _boardBackgroundImage As Bitmap

        ''' <summary>Active cell image for the upper-left corner cell.</summary>
        Private Shared _cellActiveUpperLeft As Bitmap
        ''' <summary>Active cell image for the upper-right corner cell.</summary>
        Private Shared _cellActiveUpperRight As Bitmap
        ''' <summary>Active cell image for the lower-left corner cell.</summary>
        Private Shared _cellActiveLowerLeft As Bitmap
        ''' <summary>Active cell image for the lower-right corner cell.</summary>
        Private Shared _cellActiveLowerRight As Bitmap
        ''' <summary>Active cell image for any square cell.</summary>
        Private Shared _cellActiveSquare As Bitmap

        ''' <summary>Hint cell image for the upper-left corner cell.</summary>
        Private Shared _cellHintUpperLeft As Bitmap
        ''' <summary>Hint cell image for the upper-right corner cell.</summary>
        Private Shared _cellHintUpperRight As Bitmap
        ''' <summary>Hint cell image for the lower-left corner cell.</summary>
        Private Shared _cellHintLowerLeft As Bitmap
        ''' <summary>Hint cell image for the lower-right corner cell.</summary>
        Private Shared _cellHintLowerRight As Bitmap
        ''' <summary>Hint cell image for any square cell.</summary>
        Private Shared _cellHintSquare As Bitmap

        ''' <summary>Image used as the background for the new puzzle "dialog".</summary>
        Private Shared _newPuzzleBackground As Bitmap
        ''' <summary>The checked state image for a button on the new puzzle screen.</summary>
        Private Shared _newPuzzleItemChecked As Bitmap
        ''' <summary>The unchecked state image for a button on the new puzzle screen.</summary>
        Private Shared _newPuzzleItemUnchecked As Bitmap
        ''' <summary>The highlighted state image for a button on the new puzzle screen.</summary>
        Private Shared _newPuzzleItemHighlighted As Bitmap

        ''' <summary>The string used as the display title for the application.</summary>
        Private Shared _displayTitle As String
        ''' <summary>The string used as the display title for the application when a difficulty level has been set.</summary>
        Private Shared _displayTitleWithDifficultyLevel As String
        ''' <summary>Easy difficulty level description.</summary>
        Private Shared _easyDifficultyLevel As String
        ''' <summary>Medium difficulty level description.</summary>
        Private Shared _mediumDifficultyLevel As String
        ''' <summary>Hard difficulty level description.</summary>
        Private Shared _hardDifficultyLevel As String
        ''' <summary>Very hard difficulty level description.</summary>
        Private Shared _veryHardDifficultyLevel As String
        ''' <summary>The string used to size the width of a single character.</summary>
        Private Shared _fontSizingString As String
        ''' <summary>The string displayed to the user when they solve the puzzle.</summary>
        Private Shared _puzzleSolvedCongratulations As String
        ''' <summary>The string displayed to a user when they're about to lose a puzzle.</summary>
        Private Shared _aboutToLosePuzzle As String

        ''' <summary>Initializes all resources.</summary>
        Private Sub New()
        End Sub
        Shared Sub New()
            ' Create the resource manager
            _resourceAssembly = GetType(ResourceHelper).Assembly
            _manager = New ResourceManager(_stringsResourceFileName, _resourceAssembly)

            ' Retrieve the string resources
            _displayTitle = _manager.GetString("DisplayTitle")
            _displayTitleWithDifficultyLevel = _manager.GetString("DisplayTitleWithDifficultyLevel")
            _easyDifficultyLevel = _manager.GetString("EasyDifficultyLevel")
            _mediumDifficultyLevel = _manager.GetString("MediumDifficultyLevel")
            _hardDifficultyLevel = _manager.GetString("HardDifficultyLevel")
            _veryHardDifficultyLevel = _manager.GetString("VeryHardDifficultyLevel")
            _fontSizingString = _manager.GetString("FontSizingString")
            _puzzleSolvedCongratulations = _manager.GetString("PuzzleSolvedCongratulations")
            _aboutToLosePuzzle = _manager.GetString("AboutToLosePuzzle")

            ' Load the image resources that are compiled into the assembly manifest
            _boardBackgroundImage = GetResourceImageWithAlphaBlending("BoardBackground.png")
            _boardImage = GetResourceImageWithAlphaBlending("Board.png")

            ' Get the active and hint cell images
            _cellActiveSquare = GetResourceImageWithAlphaBlending("CellActiveSquare.png")
            _cellActiveUpperLeft = GetResourceImageWithAlphaBlending("CellActiveUpperLeft.png")
            _cellActiveUpperRight = GetResourceImageWithAlphaBlending("CellActiveUpperRight.png")
            _cellActiveLowerLeft = GetResourceImageWithAlphaBlending("CellActiveLowerLeft.png")
            _cellActiveLowerRight = GetResourceImageWithAlphaBlending("CellActiveLowerRight.png")
            _cellHintSquare = GetResourceImageWithAlphaBlending("CellHintSquare.png")
            _cellHintUpperLeft = GetResourceImageWithAlphaBlending("CellHintUpperLeft.png")
            _cellHintUpperRight = GetResourceImageWithAlphaBlending("CellHintUpperRight.png")
            _cellHintLowerLeft = GetResourceImageWithAlphaBlending("CellHintLowerLeft.png")
            _cellHintLowerRight = GetResourceImageWithAlphaBlending("CellHintLowerRight.png")

            ' Get the form button images 
            _buttonShadow = GetResourceImageWithAlphaBlending("ButtonShadow.png")
            _buttonCheckedImage = GetResourceImageWithAlphaBlending("ButtonChecked.png")
            _buttonUncheckedImage = GetResourceImageWithAlphaBlending("ButtonUnchecked.png")
            _buttonHighlightedImage = GetResourceImageWithAlphaBlending("ButtonHighlighted.png")
            _optionsImage = GetResourceImageWithAlphaBlending("Options.png")
            _undoImage = GetResourceImageWithAlphaBlending("Undo.png")
            _newPuzzleImage = GetResourceImageWithAlphaBlending("New.png")

            ' Get new puzzle dialog images
            _newPuzzleBackground = GetResourceImageWithAlphaBlending("NewPuzzleBackground.png")
            _newPuzzleItemChecked = GetResourceImageWithAlphaBlending("NewPuzzleItemChecked.png")
            _newPuzzleItemUnchecked = GetResourceImageWithAlphaBlending("NewPuzzleItemUnchecked.png")
            _newPuzzleItemHighlighted = GetResourceImageWithAlphaBlending("NewPuzzleItemHighlighted.png")
        End Sub

        ''' <summary>Gets the board image containing each cell.</summary>
        Public Shared ReadOnly Property BoardImage() As Bitmap
            Get
                Return _boardImage
            End Get
        End Property
        ''' <summary>Gets the background image for the whole app.</summary>
        Public Shared ReadOnly Property BoardBackgroundImage() As Bitmap
            Get
                Return _boardBackgroundImage
            End Get
        End Property

        ''' <summary>Gets the image displayed as the shadow for a standard button.</summary>
        Public Shared ReadOnly Property ButtonShadow() As Bitmap
            Get
                Return _buttonShadow
            End Get
        End Property
        ''' <summary>Gets the image displayed when a button is in the checked state.</summary>
        Public Shared ReadOnly Property ButtonCheckedImage() As Bitmap
            Get
                Return _buttonCheckedImage
            End Get
        End Property
        ''' <summary>Gets the image displayed when a button is in the unchecked state.</summary>
        Public Shared ReadOnly Property ButtonUncheckedImage() As Bitmap
            Get
                Return _buttonUncheckedImage
            End Get
        End Property
        ''' <summary>Gets the image displayed when a button is in the highlighted state.</summary>
        Public Shared ReadOnly Property ButtonHighlightedImage() As Bitmap
            Get
                Return _buttonHighlightedImage
            End Get
        End Property

        ''' <summary>Gets the active cell image for any square cell.</summary>
        Public Shared ReadOnly Property CellActiveSquare() As Bitmap
            Get
                Return _cellActiveSquare
            End Get
        End Property
        ''' <summary>Gets the active cell image for the upper-left corner cell.</summary>
        Public Shared ReadOnly Property CellActiveUpperLeft() As Bitmap
            Get
                Return _cellActiveUpperLeft
            End Get
        End Property
        ''' <summary>Gets the active cell image for the upper-right corner cell.</summary>
        Public Shared ReadOnly Property CellActiveUpperRight() As Bitmap
            Get
                Return _cellActiveUpperRight
            End Get
        End Property
        ''' <summary>Gets the active cell image for the lower-left corner cell.</summary>
        Public Shared ReadOnly Property CellActiveLowerLeft() As Bitmap
            Get
                Return _cellActiveLowerLeft
            End Get
        End Property
        ''' <summary>Gets the active cell image for the lower-right corner cell.</summary>
        Public Shared ReadOnly Property CellActiveLowerRight() As Bitmap
            Get
                Return _cellActiveLowerRight
            End Get
        End Property
        ''' <summary>Gets the hint cell image for any square cell.</summary>
        Public Shared ReadOnly Property CellHintSquare() As Bitmap
            Get
                Return _cellHintSquare
            End Get
        End Property
        ''' <summary>Gets the hint cell image for the upper-left corner cell.</summary>
        Public Shared ReadOnly Property CellHintUpperLeft() As Bitmap
            Get
                Return _cellHintUpperLeft
            End Get
        End Property
        ''' <summary>Gets the hint cell image for the upper-right corner cell.</summary>
        Public Shared ReadOnly Property CellHintUpperRight() As Bitmap
            Get
                Return _cellHintUpperRight
            End Get
        End Property
        ''' <summary>Gets the hint cell image for the lower-left corner cell.</summary>
        Public Shared ReadOnly Property CellHintLowerLeft() As Bitmap
            Get
                Return _cellHintLowerLeft
            End Get
        End Property
        ''' <summary>Gets the hint cell image for the lower-right corner cell.</summary>
        Public Shared ReadOnly Property CellHintLowerRight() As Bitmap
            Get
                Return _cellHintLowerRight
            End Get
        End Property

        ''' <summary>Gets the icon for the options button.</summary>
        Public Shared ReadOnly Property OptionsImage() As Bitmap
            Get
                Return _optionsImage
            End Get
        End Property
        ''' <summary>Gets the icon for the undo button.</summary>
        Public Shared ReadOnly Property UndoImage() As Bitmap
            Get
                Return _undoImage
            End Get
        End Property
        ''' <summary>Gets the icon for the new game button.</summary>
        Public Shared ReadOnly Property NewImage() As Bitmap
            Get
                Return _newPuzzleImage
            End Get
        End Property

        ''' <summary>Gets the image used as the background for the new puzzle "dialog".</summary>
        Public Shared ReadOnly Property NewPuzzleBackground() As Bitmap
            Get
                Return _newPuzzleBackground
            End Get
        End Property
        ''' <summary>Gets the checked state image for a button on the new puzzle screen.</summary>
        Public Shared ReadOnly Property NewPuzzleItemChecked() As Bitmap
            Get
                Return _newPuzzleItemChecked
            End Get
        End Property
        ''' <summary>Gets the unchecked state image for a button on the new puzzle screen.</summary>
        Public Shared ReadOnly Property NewPuzzleItemUnchecked() As Bitmap
            Get
                Return _newPuzzleItemUnchecked
            End Get
        End Property
        ''' <summary>Gets the highlighted state image for a button on the new puzzle screen.</summary>
        Public Shared ReadOnly Property NewPuzzleItemHighlighted() As Bitmap
            Get
                Return _newPuzzleItemHighlighted
            End Get
        End Property

        ''' <summary>Gets the string used as the display title for the application.</summary>
        Public Shared ReadOnly Property DisplayTitle() As String
            Get
                Return _displayTitle
            End Get
        End Property
        ''' <summary>Gets the string used as the display title for the application when a difficulty level is set.</summary>
        Public Shared ReadOnly Property DisplayTitleWithDifficultyLevel() As String
            Get
                Return _displayTitleWithDifficultyLevel
            End Get
        End Property
        ''' <summary>Easy difficulty level description.</summary>
        Public Shared ReadOnly Property EasyDifficultyLevel() As String
            Get
                Return _easyDifficultyLevel
            End Get
        End Property
        ''' <summary>Medium difficulty level description.</summary>
        Public Shared ReadOnly Property MediumDifficultyLevel() As String
            Get
                Return _mediumDifficultyLevel
            End Get
        End Property
        ''' <summary>Hard difficulty level description.</summary>
        Public Shared ReadOnly Property HardDifficultyLevel() As String
            Get
                Return _hardDifficultyLevel
            End Get
        End Property
        ''' <summary>Very hard difficulty level description.</summary>
        Public Shared ReadOnly Property VeryHardDifficultyLevel() As String
            Get
                Return _veryHardDifficultyLevel
            End Get
        End Property
        ''' <summary>Gets the string used to size the width of a single character.</summary>
        Public Shared ReadOnly Property FontSizingString() As String
            Get
                Return _fontSizingString
            End Get
        End Property
        ''' <summary>Gets the string displayed to the user when they solve the puzzle.</summary>
        Public Shared ReadOnly Property PuzzleSolvedCongratulations() As String
            Get
                Return _puzzleSolvedCongratulations
            End Get
        End Property
        ''' <summary>Gets the string displayed to a user when they're about to lose a puzzle.</summary>
        Public Shared ReadOnly Property AboutToLosePuzzle() As String
            Get
                Return _aboutToLosePuzzle
            End Get
        End Property

        ''' <summary>Gets an image from assembly manifest, adding premultiplied alpha.</summary>
        ''' <param name="resourceName">The name of the resource.</param>
        ''' <returns>The image.</returns>
        Friend Shared Function GetResourceImageWithAlphaBlending(ByVal resourceName As String) As Bitmap
            Using bmp = GetResourceImage(resourceName)
                Return PremultiplyAlpha(bmp)
            End Using
        End Function

        ''' <summary>Gets an image from the current skin or from the assembly manifest.</summary>
        ''' <param name="resourceName">The name of the resource.</param>
        ''' <returns>The image.</returns>
        Friend Shared Function GetResourceImage(ByVal resourceName As String) As Bitmap
            Return New Bitmap(_resourceAssembly.GetManifestResourceStream(resourceName))
        End Function

        ''' <summary>Creates a new bitmap with a premultiplied alpha layer.</summary>
        ''' <param name="bmp">The Bitmap.</param>
        ''' <returns>The new Bitmap.</returns>
        Friend Shared Function PremultiplyAlpha(ByVal bmp As Bitmap) As Bitmap
            Dim width = bmp.Width, height = bmp.Height
            Dim renderBmp As New Bitmap(width, height, PixelFormat.Format32bppPArgb)
            Using g = Graphics.FromImage(renderBmp)
                g.DrawImage(bmp, 0, 0, width, height)
            End Using
            Return renderBmp
        End Function
    End Class
End Namespace