//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: ResourceHelper.cs
//
//  Description: Strongly-typed access to resources.
// 
//--------------------------------------------------------------------------

using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Resources;

namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku
{
	/// <summary>Provides strongly-typed resource access to the rest of the application.</summary>
	internal static class ResourceHelper
	{
		/// <summary>The name of the resource file containing the string resources for this application.</summary>
		private const string _stringsResourceFileName = "Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Strings";
		/// <summary>The resource manager used to load all resources.</summary>
		private static ResourceManager _manager;
		/// <summary>This assembly.</summary>
		private static Assembly _resourceAssembly;

		/// <summary>Image displayed as the shadow for a standard button.</summary>
		private static Bitmap _buttonShadow;
		/// <summary>Image displayed when a button is in the checked state.</summary>
		private static Bitmap _buttonCheckedImage;
		/// <summary>Image displayed when a button is in the unchecked state.</summary>
		private static Bitmap _buttonUncheckedImage;
		/// <summary>Image displayed when a button is in the highlighted state.</summary>
		private static Bitmap _buttonHighlightedImage;

		/// <summary>Icon for the new puzzle button.</summary>
		private static Bitmap _newPuzzleImage;
		/// <summary>Icon for the options button.</summary>
		private static Bitmap _optionsImage;
		/// <summary>Icon for the undo button.</summary>
		private static Bitmap _undoImage;

		/// <summary>The board image containing each cell.</summary>
		private static Bitmap _boardImage;
		/// <summary>The backdrop image for the board.</summary>
		private static Bitmap _boardBackgroundImage;

		/// <summary>Active cell image for the upper-left corner cell.</summary>
		private static Bitmap _cellActiveUpperLeft;
		/// <summary>Active cell image for the upper-right corner cell.</summary>
		private static Bitmap _cellActiveUpperRight;
		/// <summary>Active cell image for the lower-left corner cell.</summary>
		private static Bitmap _cellActiveLowerLeft;
		/// <summary>Active cell image for the lower-right corner cell.</summary>
		private static Bitmap _cellActiveLowerRight;
		/// <summary>Active cell image for any square cell.</summary>
		private static Bitmap _cellActiveSquare;

		/// <summary>Hint cell image for the upper-left corner cell.</summary>
		private static Bitmap _cellHintUpperLeft;
		/// <summary>Hint cell image for the upper-right corner cell.</summary>
		private static Bitmap _cellHintUpperRight;
		/// <summary>Hint cell image for the lower-left corner cell.</summary>
		private static Bitmap _cellHintLowerLeft;
		/// <summary>Hint cell image for the lower-right corner cell.</summary>
		private static Bitmap _cellHintLowerRight;
		/// <summary>Hint cell image for any square cell.</summary>
		private static Bitmap _cellHintSquare;

		/// <summary>Image used as the background for the new puzzle "dialog".</summary>
		private static Bitmap _newPuzzleBackground;
		/// <summary>The checked state image for a button on the new puzzle screen.</summary>
		private static Bitmap _newPuzzleItemChecked;
		/// <summary>The unchecked state image for a button on the new puzzle screen.</summary>
		private static Bitmap _newPuzzleItemUnchecked;
		/// <summary>The highlighted state image for a button on the new puzzle screen.</summary>
		private static Bitmap _newPuzzleItemHighlighted;

		/// <summary>The string used as the display title for the application.</summary>
		private static string _displayTitle;
		/// <summary>The string used as the display title for the application when a difficulty level has been set.</summary>
		private static string _displayTitleWithDifficultyLevel;
		/// <summary>Easy difficulty level description.</summary>
		private static string _easyDifficultyLevel;
		/// <summary>Medium difficulty level description.</summary>
		private static string _mediumDifficultyLevel;
		/// <summary>Hard difficulty level description.</summary>
        private static string _hardDifficultyLevel;
        /// <summary>Very hard difficulty level description.</summary>
        private static string _veryHardDifficultyLevel;
		/// <summary>The string used to size the width of a single character.</summary>
		private static string _fontSizingString;
		/// <summary>The string displayed to the user when they solve the puzzle.</summary>
		private static string _puzzleSolvedCongratulations;
		/// <summary>The string displayed to a user when they're about to lose a puzzle.</summary>
		private static string _aboutToLosePuzzle;

		/// <summary>Initializes all resources.</summary>
		static ResourceHelper()
		{
			// Create the resource manager
			_resourceAssembly = typeof(ResourceHelper).Assembly;
			_manager = new ResourceManager(_stringsResourceFileName, _resourceAssembly);

			// Retrieve the string resources
			_displayTitle = _manager.GetString("DisplayTitle");
			_displayTitleWithDifficultyLevel = _manager.GetString("DisplayTitleWithDifficultyLevel");
			_easyDifficultyLevel = _manager.GetString("EasyDifficultyLevel");
			_mediumDifficultyLevel = _manager.GetString("MediumDifficultyLevel");
            _hardDifficultyLevel = _manager.GetString("HardDifficultyLevel");
            _veryHardDifficultyLevel = _manager.GetString("VeryHardDifficultyLevel");
			_fontSizingString = _manager.GetString("FontSizingString");
			_puzzleSolvedCongratulations = _manager.GetString("PuzzleSolvedCongratulations");
			_aboutToLosePuzzle = _manager.GetString("AboutToLosePuzzle");

			// Load the image resources that are compiled into the assembly manifest
			_boardBackgroundImage = GetResourceImageWithAlphaBlending("Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Images.BoardBackground.png");
			_boardImage = GetResourceImageWithAlphaBlending("Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Images.Board.png");

			// Get the active and hint cell images
			_cellActiveSquare = GetResourceImageWithAlphaBlending("Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Images.CellActiveSquare.png");
			_cellActiveUpperLeft = GetResourceImageWithAlphaBlending("Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Images.CellActiveUpperLeft.png");
			_cellActiveUpperRight = GetResourceImageWithAlphaBlending("Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Images.CellActiveUpperRight.png");
			_cellActiveLowerLeft = GetResourceImageWithAlphaBlending("Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Images.CellActiveLowerLeft.png");
			_cellActiveLowerRight = GetResourceImageWithAlphaBlending("Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Images.CellActiveLowerRight.png");
			_cellHintSquare = GetResourceImageWithAlphaBlending("Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Images.CellHintSquare.png");
			_cellHintUpperLeft = GetResourceImageWithAlphaBlending("Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Images.CellHintUpperLeft.png");
			_cellHintUpperRight = GetResourceImageWithAlphaBlending("Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Images.CellHintUpperRight.png");
			_cellHintLowerLeft = GetResourceImageWithAlphaBlending("Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Images.CellHintLowerLeft.png");
			_cellHintLowerRight = GetResourceImageWithAlphaBlending("Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Images.CellHintLowerRight.png");

			// Get the form button images 
			_buttonShadow = GetResourceImageWithAlphaBlending("Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Images.ButtonShadow.png");
			_buttonCheckedImage = GetResourceImageWithAlphaBlending("Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Images.ButtonChecked.png");
			_buttonUncheckedImage = GetResourceImageWithAlphaBlending("Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Images.ButtonUnchecked.png");
			_buttonHighlightedImage = GetResourceImageWithAlphaBlending("Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Images.ButtonHighlighted.png");
			_optionsImage = GetResourceImageWithAlphaBlending("Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Images.Options.png");
			_undoImage = GetResourceImageWithAlphaBlending("Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Images.Undo.png");
			_newPuzzleImage = GetResourceImageWithAlphaBlending("Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Images.New.png");

			// Get new puzzle dialog images
			_newPuzzleBackground = GetResourceImageWithAlphaBlending("Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Images.NewPuzzleBackground.png");
			_newPuzzleItemChecked = GetResourceImageWithAlphaBlending("Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Images.NewPuzzleItemChecked.png");
			_newPuzzleItemUnchecked = GetResourceImageWithAlphaBlending("Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Images.NewPuzzleItemUnchecked.png");
			_newPuzzleItemHighlighted = GetResourceImageWithAlphaBlending("Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Images.NewPuzzleItemHighlighted.png");
		}

		/// <summary>Gets the board image containing each cell.</summary>
		public static Bitmap BoardImage { get { return _boardImage; } }
		/// <summary>Gets the background image for the whole app.</summary>
		public static Bitmap BoardBackgroundImage { get { return _boardBackgroundImage; } }

		/// <summary>Gets the image displayed as the shadow for a standard button.</summary>
		public static Bitmap ButtonShadow { get { return _buttonShadow; } }
		/// <summary>Gets the image displayed when a button is in the checked state.</summary>
		public static Bitmap ButtonCheckedImage { get { return _buttonCheckedImage; } }
		/// <summary>Gets the image displayed when a button is in the unchecked state.</summary>
		public static Bitmap ButtonUncheckedImage { get { return _buttonUncheckedImage; } }
		/// <summary>Gets the image displayed when a button is in the highlighted state.</summary>
		public static Bitmap ButtonHighlightedImage { get { return _buttonHighlightedImage; } }

		/// <summary>Gets the active cell image for any square cell.</summary>
		public static Bitmap CellActiveSquare { get { return _cellActiveSquare; } }
		/// <summary>Gets the active cell image for the upper-left corner cell.</summary>
		public static Bitmap CellActiveUpperLeft { get { return _cellActiveUpperLeft; } }
		/// <summary>Gets the active cell image for the upper-right corner cell.</summary>
		public static Bitmap CellActiveUpperRight { get { return _cellActiveUpperRight; } }
		/// <summary>Gets the active cell image for the lower-left corner cell.</summary>
		public static Bitmap CellActiveLowerLeft { get { return _cellActiveLowerLeft; } }
		/// <summary>Gets the active cell image for the lower-right corner cell.</summary>
		public static Bitmap CellActiveLowerRight { get { return _cellActiveLowerRight; } }
		/// <summary>Gets the hint cell image for any square cell.</summary>
		public static Bitmap CellHintSquare { get { return _cellHintSquare; } }
		/// <summary>Gets the hint cell image for the upper-left corner cell.</summary>
		public static Bitmap CellHintUpperLeft { get { return _cellHintUpperLeft; } }
		/// <summary>Gets the hint cell image for the upper-right corner cell.</summary>
		public static Bitmap CellHintUpperRight { get { return _cellHintUpperRight; } }
		/// <summary>Gets the hint cell image for the lower-left corner cell.</summary>
		public static Bitmap CellHintLowerLeft { get { return _cellHintLowerLeft; } }
		/// <summary>Gets the hint cell image for the lower-right corner cell.</summary>
		public static Bitmap CellHintLowerRight { get { return _cellHintLowerRight; } }
		
		/// <summary>Gets the icon for the options button.</summary>
		public static Bitmap OptionsImage { get { return _optionsImage; } }
		/// <summary>Gets the icon for the undo button.</summary>
		public static Bitmap UndoImage { get { return _undoImage; } }
		/// <summary>Gets the icon for the new game button.</summary>
		public static Bitmap NewImage { get { return _newPuzzleImage; } }

		/// <summary>Gets the image used as the background for the new puzzle "dialog".</summary>
		public static Bitmap NewPuzzleBackground { get { return _newPuzzleBackground; } }
		/// <summary>Gets the checked state image for a button on the new puzzle screen.</summary>
		public static Bitmap NewPuzzleItemChecked { get { return _newPuzzleItemChecked; } }
		/// <summary>Gets the unchecked state image for a button on the new puzzle screen.</summary>
		public static Bitmap NewPuzzleItemUnchecked { get { return _newPuzzleItemUnchecked; } }
		/// <summary>Gets the highlighted state image for a button on the new puzzle screen.</summary>
		public static Bitmap NewPuzzleItemHighlighted { get { return _newPuzzleItemHighlighted; } }

		/// <summary>Gets the string used as the display title for the application.</summary>
		public static string DisplayTitle { get { return _displayTitle; } }
		/// <summary>Gets the string used as the display title for the application when a difficulty level is set.</summary>
		public static string DisplayTitleWithDifficultyLevel { get { return _displayTitleWithDifficultyLevel; } }
		/// <summary>Easy difficulty level description.</summary>
		public static string EasyDifficultyLevel { get { return _easyDifficultyLevel; } }
		/// <summary>Medium difficulty level description.</summary>
		public static string MediumDifficultyLevel { get { return _mediumDifficultyLevel; } }
		/// <summary>Hard difficulty level description.</summary>
        public static string HardDifficultyLevel { get { return _hardDifficultyLevel; } }
        /// <summary>Very hard difficulty level description.</summary>
        public static string VeryHardDifficultyLevel { get { return _veryHardDifficultyLevel; } }
		/// <summary>Gets the string used to size the width of a single character.</summary>
		public static string FontSizingString { get { return _fontSizingString; } }
		/// <summary>Gets the string displayed to the user when they solve the puzzle.</summary>
		public static string PuzzleSolvedCongratulations { get { return _puzzleSolvedCongratulations; } }
		/// <summary>Gets the string displayed to a user when they're about to lose a puzzle.</summary>
		public static string AboutToLosePuzzle { get { return _aboutToLosePuzzle; } }

		/// <summary>Gets an image from assembly manifest, adding premultiplied alpha.</summary>
		/// <param name="resourceName">The name of the resource.</param>
		/// <returns>The image.</returns>
		internal static Bitmap GetResourceImageWithAlphaBlending(string resourceName)
		{
			using(Bitmap bmp = GetResourceImage(resourceName))
			{
				return PremultiplyAlpha(bmp);
			}
		}

		/// <summary>Gets an image from the current skin or from the assembly manifest.</summary>
		/// <param name="resourceName">The name of the resource.</param>
		/// <returns>The image.</returns>
		internal static Bitmap GetResourceImage(string resourceName)
		{
			return new Bitmap(_resourceAssembly.GetManifestResourceStream(resourceName)); 
		}

		/// <summary>Creates a new bitmap with a premultiplied alpha layer.</summary>
		/// <param name="bmp">The Bitmap.</param>
		/// <returns>The new Bitmap.</returns>
		internal static Bitmap PremultiplyAlpha(Bitmap bmp)
		{
			int width = bmp.Width, height = bmp.Height;
			Bitmap renderBmp = new Bitmap(width, height, PixelFormat.Format32bppPArgb);
			using(Graphics g = Graphics.FromImage(renderBmp))
			{
				g.DrawImage(bmp, 0, 0, width, height);
			}
			return renderBmp;
		}
	}
}