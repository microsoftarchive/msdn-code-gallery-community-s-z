//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: MainForm.cs
//
//  Description: The main form window for Sudoku.
// 
//--------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;
using System.Windows.Forms;
using Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls;
using Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Utilities;

namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku
{
    /// <summary>The main form of the Sudoku application.</summary>
    internal sealed class MainForm : Form
    {
        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainTooltips = new System.Windows.Forms.ToolTip(this.components);
            this.tsbLoadPreviousGame = new Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.TextStatefulButton();
            this.tsbBeginner2 = new Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.TextStatefulButton();
            this.tsbIntermediate2 = new Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.TextStatefulButton();
            this.tsbAdvanced2 = new Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.TextStatefulButton();
            this.tsbExpert2 = new Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.TextStatefulButton();
            this.tsbBeginner = new Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.TextStatefulButton();
            this.tsbIntermediate = new Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.TextStatefulButton();
            this.tsbAdvanced = new Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.TextStatefulButton();
            this.tsbExpert = new Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.TextStatefulButton();
            this.optionsButton = new Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.TextStatefulButton();
            this.newGameButton = new Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.TextStatefulButton();
            this.undoButton = new Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.TextStatefulButton();
            this.backgroundPanel = new Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.ImagePanel();
            this.pnlSavedOrNewPuzzle = new Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.ImagePanel();
            this.lblPlaySavedGame = new System.Windows.Forms.Label();
            this.lblDeleteSavedGameWarning = new System.Windows.Forms.Label();
            this.lblNewGameSavedDeleted = new System.Windows.Forms.Label();
            this.pnlNewPuzzle = new Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.ImagePanel();
            this.lblDifficultyLevel = new System.Windows.Forms.Label();
            this.pnlGrid = new Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.NoFlickerPanel();
            this.thePuzzleGrid = new Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.PuzzleGrid();
            this.pnlControls = new Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.ScalingPanel();
            this.marqueeBar = new System.Windows.Forms.ProgressBar();
            this.backgroundPanel.SuspendLayout();
            this.pnlSavedOrNewPuzzle.SuspendLayout();
            this.pnlNewPuzzle.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            this.pnlControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTooltips
            // 
            this.mainTooltips.AutoPopDelay = 5000;
            this.mainTooltips.InitialDelay = 1000;
            this.mainTooltips.ReshowDelay = 100;
            // 
            // tsbLoadPreviousGame
            // 
            this.tsbLoadPreviousGame.AdjustTextPlacementWhenChecked = false;
            this.tsbLoadPreviousGame.AllowChecking = false;
            this.tsbLoadPreviousGame.AllowNonprogrammaticUnchecking = false;
            this.tsbLoadPreviousGame.AutosizeFont = false;
            this.tsbLoadPreviousGame.BackColor = System.Drawing.Color.Gray;
            this.tsbLoadPreviousGame.Checked = false;
            this.tsbLoadPreviousGame.Focusable = true;
            resources.ApplyResources(this.tsbLoadPreviousGame, "tsbLoadPreviousGame");
            this.tsbLoadPreviousGame.ForeColor = System.Drawing.Color.White;
            this.tsbLoadPreviousGame.Name = "tsbLoadPreviousGame";
            this.mainTooltips.SetToolTip(this.tsbLoadPreviousGame, resources.GetString("tsbLoadPreviousGame.ToolTip"));
            this.tsbLoadPreviousGame.Click += new System.EventHandler(this.HandleNewPuzzleSelection);
            // 
            // tsbBeginner2
            // 
            this.tsbBeginner2.AdjustTextPlacementWhenChecked = false;
            this.tsbBeginner2.AllowChecking = false;
            this.tsbBeginner2.AllowNonprogrammaticUnchecking = false;
            this.tsbBeginner2.AutosizeFont = false;
            this.tsbBeginner2.BackColor = System.Drawing.Color.Gray;
            this.tsbBeginner2.Checked = false;
            this.tsbBeginner2.Focusable = true;
            resources.ApplyResources(this.tsbBeginner2, "tsbBeginner2");
            this.tsbBeginner2.ForeColor = System.Drawing.Color.White;
            this.tsbBeginner2.Name = "tsbBeginner2";
            this.mainTooltips.SetToolTip(this.tsbBeginner2, resources.GetString("tsbBeginner2.ToolTip"));
            this.tsbBeginner2.Click += new System.EventHandler(this.HandleNewPuzzleSelection);
            // 
            // tsbIntermediate2
            // 
            this.tsbIntermediate2.AdjustTextPlacementWhenChecked = false;
            this.tsbIntermediate2.AllowChecking = false;
            this.tsbIntermediate2.AllowNonprogrammaticUnchecking = false;
            this.tsbIntermediate2.AutosizeFont = false;
            this.tsbIntermediate2.BackColor = System.Drawing.Color.Gray;
            this.tsbIntermediate2.Checked = false;
            this.tsbIntermediate2.Focusable = true;
            resources.ApplyResources(this.tsbIntermediate2, "tsbIntermediate2");
            this.tsbIntermediate2.ForeColor = System.Drawing.Color.White;
            this.tsbIntermediate2.Name = "tsbIntermediate2";
            this.mainTooltips.SetToolTip(this.tsbIntermediate2, resources.GetString("tsbIntermediate2.ToolTip"));
            this.tsbIntermediate2.Click += new System.EventHandler(this.HandleNewPuzzleSelection);
            // 
            // tsbAdvanced2
            // 
            this.tsbAdvanced2.AdjustTextPlacementWhenChecked = false;
            this.tsbAdvanced2.AllowChecking = false;
            this.tsbAdvanced2.AllowNonprogrammaticUnchecking = false;
            this.tsbAdvanced2.AutosizeFont = false;
            this.tsbAdvanced2.BackColor = System.Drawing.Color.Gray;
            this.tsbAdvanced2.Checked = false;
            this.tsbAdvanced2.Focusable = true;
            resources.ApplyResources(this.tsbAdvanced2, "tsbAdvanced2");
            this.tsbAdvanced2.ForeColor = System.Drawing.Color.White;
            this.tsbAdvanced2.Name = "tsbAdvanced2";
            this.mainTooltips.SetToolTip(this.tsbAdvanced2, resources.GetString("tsbAdvanced2.ToolTip"));
            this.tsbAdvanced2.Click += new System.EventHandler(this.HandleNewPuzzleSelection);
            // 
            // tsbExpert2
            // 
            this.tsbExpert2.AdjustTextPlacementWhenChecked = false;
            this.tsbExpert2.AllowChecking = false;
            this.tsbExpert2.AllowNonprogrammaticUnchecking = false;
            this.tsbExpert2.AutosizeFont = false;
            this.tsbExpert2.BackColor = System.Drawing.Color.Gray;
            this.tsbExpert2.Checked = false;
            this.tsbExpert2.Focusable = true;
            this.tsbExpert2.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.tsbExpert2, "tsbExpert2");
            this.tsbExpert2.Name = "tsbExpert2";
            this.mainTooltips.SetToolTip(this.tsbExpert2, resources.GetString("tsbExpert2.ToolTip"));
            this.tsbExpert2.Click += new System.EventHandler(this.HandleNewPuzzleSelection);
            // 
            // tsbBeginner
            // 
            this.tsbBeginner.AdjustTextPlacementWhenChecked = false;
            this.tsbBeginner.AllowChecking = false;
            this.tsbBeginner.AllowNonprogrammaticUnchecking = false;
            resources.ApplyResources(this.tsbBeginner, "tsbBeginner");
            this.tsbBeginner.AutosizeFont = false;
            this.tsbBeginner.BackColor = System.Drawing.Color.Gray;
            this.tsbBeginner.Checked = false;
            this.tsbBeginner.Focusable = true;
            this.tsbBeginner.ForeColor = System.Drawing.Color.White;
            this.tsbBeginner.Name = "tsbBeginner";
            this.mainTooltips.SetToolTip(this.tsbBeginner, resources.GetString("tsbBeginner.ToolTip"));
            this.tsbBeginner.Click += new System.EventHandler(this.HandleNewPuzzleSelection);
            // 
            // tsbIntermediate
            // 
            this.tsbIntermediate.AdjustTextPlacementWhenChecked = false;
            this.tsbIntermediate.AllowChecking = false;
            this.tsbIntermediate.AllowNonprogrammaticUnchecking = false;
            resources.ApplyResources(this.tsbIntermediate, "tsbIntermediate");
            this.tsbIntermediate.AutosizeFont = false;
            this.tsbIntermediate.BackColor = System.Drawing.Color.Gray;
            this.tsbIntermediate.Checked = false;
            this.tsbIntermediate.Focusable = true;
            this.tsbIntermediate.ForeColor = System.Drawing.Color.White;
            this.tsbIntermediate.Name = "tsbIntermediate";
            this.mainTooltips.SetToolTip(this.tsbIntermediate, resources.GetString("tsbIntermediate.ToolTip"));
            this.tsbIntermediate.Click += new System.EventHandler(this.HandleNewPuzzleSelection);
            // 
            // tsbAdvanced
            // 
            this.tsbAdvanced.AdjustTextPlacementWhenChecked = false;
            this.tsbAdvanced.AllowChecking = false;
            this.tsbAdvanced.AllowNonprogrammaticUnchecking = false;
            this.tsbAdvanced.AutosizeFont = false;
            this.tsbAdvanced.BackColor = System.Drawing.Color.Gray;
            this.tsbAdvanced.Checked = false;
            this.tsbAdvanced.Focusable = true;
            resources.ApplyResources(this.tsbAdvanced, "tsbAdvanced");
            this.tsbAdvanced.ForeColor = System.Drawing.Color.White;
            this.tsbAdvanced.Name = "tsbAdvanced";
            this.mainTooltips.SetToolTip(this.tsbAdvanced, resources.GetString("tsbAdvanced.ToolTip"));
            this.tsbAdvanced.Click += new System.EventHandler(this.HandleNewPuzzleSelection);
            // 
            // tsbExpert
            // 
            this.tsbExpert.AdjustTextPlacementWhenChecked = false;
            this.tsbExpert.AllowChecking = false;
            this.tsbExpert.AllowNonprogrammaticUnchecking = false;
            this.tsbExpert.AutosizeFont = false;
            this.tsbExpert.BackColor = System.Drawing.Color.Gray;
            this.tsbExpert.Checked = false;
            this.tsbExpert.Focusable = true;
            this.tsbExpert.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.tsbExpert, "tsbExpert");
            this.tsbExpert.Name = "tsbExpert";
            this.mainTooltips.SetToolTip(this.tsbExpert, resources.GetString("tsbExpert.ToolTip"));
            this.tsbExpert.Click += new System.EventHandler(this.HandleNewPuzzleSelection);
            // 
            // optionsButton
            // 
            this.optionsButton.AdjustTextPlacementWhenChecked = true;
            this.optionsButton.AllowChecking = false;
            this.optionsButton.AllowNonprogrammaticUnchecking = false;
            resources.ApplyResources(this.optionsButton, "optionsButton");
            this.optionsButton.AutosizeFont = true;
            this.optionsButton.BackColor = System.Drawing.Color.LightSteelBlue;
            this.optionsButton.Checked = false;
            this.optionsButton.Focusable = false;
            this.optionsButton.ForeColor = System.Drawing.Color.White;
            this.optionsButton.Name = "optionsButton";
            this.mainTooltips.SetToolTip(this.optionsButton, resources.GetString("optionsButton.ToolTip"));
            this.optionsButton.Click += new System.EventHandler(this.optionsButton_Click);
            // 
            // newGameButton
            // 
            this.newGameButton.AdjustTextPlacementWhenChecked = true;
            this.newGameButton.AllowChecking = false;
            this.newGameButton.AllowNonprogrammaticUnchecking = false;
            resources.ApplyResources(this.newGameButton, "newGameButton");
            this.newGameButton.AutosizeFont = true;
            this.newGameButton.BackColor = System.Drawing.Color.LightSteelBlue;
            this.newGameButton.Checked = false;
            this.newGameButton.Focusable = false;
            this.newGameButton.ForeColor = System.Drawing.Color.White;
            this.newGameButton.Name = "newGameButton";
            this.mainTooltips.SetToolTip(this.newGameButton, resources.GetString("newGameButton.ToolTip"));
            this.newGameButton.Click += new System.EventHandler(this.newGameButton_Click);
            // 
            // undoButton
            // 
            this.undoButton.AdjustTextPlacementWhenChecked = true;
            this.undoButton.AllowChecking = false;
            this.undoButton.AllowNonprogrammaticUnchecking = false;
            resources.ApplyResources(this.undoButton, "undoButton");
            this.undoButton.AutosizeFont = true;
            this.undoButton.BackColor = System.Drawing.Color.LightSteelBlue;
            this.undoButton.Checked = false;
            this.undoButton.Focusable = false;
            this.undoButton.ForeColor = System.Drawing.Color.White;
            this.undoButton.Name = "undoButton";
            this.mainTooltips.SetToolTip(this.undoButton, resources.GetString("undoButton.ToolTip"));
            this.undoButton.Click += new System.EventHandler(this.undoButton_Click);
            // 
            // backgroundPanel
            // 
            this.backgroundPanel.BackColor = System.Drawing.Color.Black;
            this.backgroundPanel.Controls.Add(this.pnlSavedOrNewPuzzle);
            this.backgroundPanel.Controls.Add(this.pnlNewPuzzle);
            this.backgroundPanel.Controls.Add(this.pnlGrid);
            this.backgroundPanel.Controls.Add(this.pnlControls);
            this.backgroundPanel.Controls.Add(this.marqueeBar);
            resources.ApplyResources(this.backgroundPanel, "backgroundPanel");
            this.backgroundPanel.ForeColor = System.Drawing.Color.Black;
            this.backgroundPanel.Name = "backgroundPanel";
            // 
            // pnlSavedOrNewPuzzle
            // 
            this.pnlSavedOrNewPuzzle.BackColor = System.Drawing.Color.Transparent;
            this.pnlSavedOrNewPuzzle.Controls.Add(this.lblPlaySavedGame);
            this.pnlSavedOrNewPuzzle.Controls.Add(this.lblDeleteSavedGameWarning);
            this.pnlSavedOrNewPuzzle.Controls.Add(this.lblNewGameSavedDeleted);
            this.pnlSavedOrNewPuzzle.Controls.Add(this.tsbLoadPreviousGame);
            this.pnlSavedOrNewPuzzle.Controls.Add(this.tsbBeginner2);
            this.pnlSavedOrNewPuzzle.Controls.Add(this.tsbIntermediate2);
            this.pnlSavedOrNewPuzzle.Controls.Add(this.tsbAdvanced2);
            this.pnlSavedOrNewPuzzle.Controls.Add(this.tsbExpert2);
            resources.ApplyResources(this.pnlSavedOrNewPuzzle, "pnlSavedOrNewPuzzle");
            this.pnlSavedOrNewPuzzle.ForeColor = System.Drawing.Color.Red;
            this.pnlSavedOrNewPuzzle.Name = "pnlSavedOrNewPuzzle";
            // 
            // lblPlaySavedGame
            // 
            resources.ApplyResources(this.lblPlaySavedGame, "lblPlaySavedGame");
            this.lblPlaySavedGame.ForeColor = System.Drawing.Color.White;
            this.lblPlaySavedGame.Name = "lblPlaySavedGame";
            // 
            // lblDeleteSavedGameWarning
            // 
            resources.ApplyResources(this.lblDeleteSavedGameWarning, "lblDeleteSavedGameWarning");
            this.lblDeleteSavedGameWarning.ForeColor = System.Drawing.Color.White;
            this.lblDeleteSavedGameWarning.Name = "lblDeleteSavedGameWarning";
            // 
            // lblNewGameSavedDeleted
            // 
            resources.ApplyResources(this.lblNewGameSavedDeleted, "lblNewGameSavedDeleted");
            this.lblNewGameSavedDeleted.ForeColor = System.Drawing.Color.White;
            this.lblNewGameSavedDeleted.Name = "lblNewGameSavedDeleted";
            // 
            // pnlNewPuzzle
            // 
            this.pnlNewPuzzle.BackColor = System.Drawing.Color.Transparent;
            this.pnlNewPuzzle.Controls.Add(this.lblDifficultyLevel);
            this.pnlNewPuzzle.Controls.Add(this.tsbBeginner);
            this.pnlNewPuzzle.Controls.Add(this.tsbIntermediate);
            this.pnlNewPuzzle.Controls.Add(this.tsbAdvanced);
            this.pnlNewPuzzle.Controls.Add(this.tsbExpert);
            resources.ApplyResources(this.pnlNewPuzzle, "pnlNewPuzzle");
            this.pnlNewPuzzle.ForeColor = System.Drawing.Color.Red;
            this.pnlNewPuzzle.Name = "pnlNewPuzzle";
            // 
            // lblDifficultyLevel
            // 
            resources.ApplyResources(this.lblDifficultyLevel, "lblDifficultyLevel");
            this.lblDifficultyLevel.ForeColor = System.Drawing.Color.White;
            this.lblDifficultyLevel.Name = "lblDifficultyLevel";
            // 
            // pnlGrid
            // 
            this.pnlGrid.BackColor = System.Drawing.Color.Black;
            this.pnlGrid.Controls.Add(this.thePuzzleGrid);
            resources.ApplyResources(this.pnlGrid, "pnlGrid");
            this.pnlGrid.Name = "pnlGrid";
            // 
            // thePuzzleGrid
            // 
            this.thePuzzleGrid.AllowDrop = true;
            this.thePuzzleGrid.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.thePuzzleGrid, "thePuzzleGrid");
            this.thePuzzleGrid.ForeColor = System.Drawing.Color.Black;
            this.thePuzzleGrid.Name = "thePuzzleGrid";
            this.thePuzzleGrid.PossibleNumbersDifficultyLevel = Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.PuzzleDifficulty.Easy;
            this.thePuzzleGrid.ShowIncorrectNumbers = true;
            this.thePuzzleGrid.ShowSuggestedCells = false;
            // 
            // pnlControls
            // 
            this.pnlControls.BackColor = System.Drawing.Color.Black;
            this.pnlControls.Controls.Add(this.optionsButton);
            this.pnlControls.Controls.Add(this.newGameButton);
            this.pnlControls.Controls.Add(this.undoButton);
            resources.ApplyResources(this.pnlControls, "pnlControls");
            this.pnlControls.Name = "pnlControls";
            // 
            // marqueeBar
            // 
            this.marqueeBar.ForeColor = System.Drawing.Color.Green;
            resources.ApplyResources(this.marqueeBar, "marqueeBar");
            this.marqueeBar.Name = "marqueeBar";
            this.marqueeBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.backgroundPanel);
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
            this.backgroundPanel.ResumeLayout(false);
            this.pnlSavedOrNewPuzzle.ResumeLayout(false);
            this.pnlNewPuzzle.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            this.pnlControls.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        private Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.TextStatefulButton undoButton;
        private System.Windows.Forms.ToolTip mainTooltips;
        private Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.PuzzleGrid thePuzzleGrid;
        private Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.ScalingPanel pnlControls;
        private Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.NoFlickerPanel pnlGrid;
        private Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.ImagePanel pnlNewPuzzle;
        private Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.TextStatefulButton tsbIntermediate;
        private Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.TextStatefulButton tsbBeginner;
        private Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.TextStatefulButton tsbAdvanced;
        private Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.TextStatefulButton tsbExpert;
        private System.Windows.Forms.Label lblDifficultyLevel;
        private Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.ImagePanel pnlSavedOrNewPuzzle;
        private System.Windows.Forms.Label lblNewGameSavedDeleted;
        private Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.TextStatefulButton tsbBeginner2;
        private Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.TextStatefulButton tsbIntermediate2;
        private Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.TextStatefulButton tsbAdvanced2;
        private Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.TextStatefulButton tsbExpert2;
        private Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.TextStatefulButton tsbLoadPreviousGame;
        private System.Windows.Forms.Label lblPlaySavedGame;
        private System.Windows.Forms.Label lblDeleteSavedGameWarning;

        /// <summary>Required designer variable.</summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>Clean up any resources being used.</summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }
        #endregion

        #region Member Variables
        private Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.ImagePanel backgroundPanel;
        private System.Windows.Forms.ProgressBar marqueeBar;
        private Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.TextStatefulButton newGameButton;
        private Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls.TextStatefulButton optionsButton;

        /// <summary>The last user-selected puzzle difficulty.</summary>
        private PuzzleDifficulty _puzzleDifficulty;
        /// <summary>The options dialog for the whole run.</summary>
        private OptionsDialog _optionsDialog;
        /// <summary>The winning animation control.</summary>
        private WinningAnimation _winningAnimation;
        /// <summary>A list of the control buttons, like pen and eraser.</summary>
        private List<TextStatefulButton> _controlButtons;
        /// <summary>Path to the saved game state file, based in Application Data.</summary>
        const string SAVED_STATE_USER_PATH = @"\Microsoft\Sudoku\1.0\SavedGame.bin";
        /// <summary>Path to the saved settings file, based in Application Data.</summary>
        const string SAVED_SETTINGS_USER_PATH = @"\Microsoft\Sudoku\1.0\SavedSettings.bin";
        #endregion

        #region Startup and Shutdown
        /// <summary>Initializes the MainForm.</summary>
        /// <remarks>Initialization work for MainForm is split between the constructor and the Load event handler.</remarks>
        public MainForm()
        {
            // Initialize all of the controls
            InitializeComponent();
            pnlControls.ConfigureByContainedControls();
            Text = ResourceHelper.DisplayTitle;

            // Initialize font sizes for new/save screens
            Label[] newSaveLabels = new Label[] { lblDeleteSavedGameWarning, lblDifficultyLevel, lblNewGameSavedDeleted, lblPlaySavedGame };
            foreach (Label lbl in newSaveLabels)
            {
                float emSize;
                using (Graphics g = lbl.CreateGraphics())
                {
                    emSize = GraphicsHelpers.GetMaximumEMSize(lbl.Text, g, lbl.Font.FontFamily, lbl.Font.Style, lbl.Width, lbl.Height);
                }
                lbl.Font = new Font(lbl.Font.Name, emSize, lbl.Font.Style);
            }

            // Setup the dialogs used in the game
            _optionsDialog = new OptionsDialog();

            // Setup the winning animation control
            _winningAnimation = new WinningAnimation(thePuzzleGrid);
            thePuzzleGrid.Controls.Add(_winningAnimation);
            _winningAnimation.Dock = DockStyle.Fill;
            _winningAnimation.BringToFront();

            // Handle changes to the state of the puzzle
            thePuzzleGrid.StateChanged += new EventHandler(HandleStateChanged);

            // Initialize the control/number button lists
            _controlButtons = new List<TextStatefulButton>();
            _controlButtons.Add(newGameButton);
            _controlButtons.Add(optionsButton);
            _controlButtons.Add(undoButton);

            // Configure the control and number buttons
            SetupTextStatefulButtonImages(_controlButtons);

            // Setup all of the main control and background images
            optionsButton.OverlayImage = ResourceHelper.OptionsImage;
            newGameButton.OverlayImage = ResourceHelper.NewImage;
            undoButton.OverlayImage = ResourceHelper.UndoImage;

            pnlGrid.BackColor = Color.Black;
            pnlControls.BackColor = Color.Black;

            // Configure the new/saved puzzle screen
            pnlNewPuzzle.BackColor = Color.Transparent;
            pnlSavedOrNewPuzzle.BackColor = Color.Transparent;
            pnlNewPuzzle.Image = ResourceHelper.NewPuzzleBackground;
            pnlSavedOrNewPuzzle.Image = ResourceHelper.NewPuzzleBackground;
            foreach (TextStatefulButton tsb in
                new object[]{tsbBeginner, tsbIntermediate, tsbAdvanced, tsbExpert, 
                    tsbBeginner2, tsbIntermediate2, tsbAdvanced2, tsbExpert2, tsbLoadPreviousGame})
            {
                tsb.BackColor = Color.Transparent;
                tsb.CheckedImage = ResourceHelper.NewPuzzleItemChecked;
                tsb.UncheckedImage = ResourceHelper.NewPuzzleItemUnchecked;
                tsb.HighlightedImage = ResourceHelper.NewPuzzleItemHighlighted;
            }

            // Load the settings for this user
            bool windowSettingsLoaded;
            LoadSettings(out windowSettingsLoaded);
            if (!windowSettingsLoaded)
            {
                Rectangle screen = Screen.PrimaryScreen.WorkingArea;
                Location = new Point((screen.Width - Width) / 2, (screen.Height - Height) / 2);
                WindowState = FormWindowState.Maximized;
            }
        }

        /// <summary>Set up the glass surface.</summary>
        /// <param name="e">Event args</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            bool glassUsed = false;
            try
            {
                // If composition in the desktop window manager is enabled, look pretty with glass
                if (NativeMethods.DwmIsCompositionEnabled())
                {
                    NativeMethods.MARGINS margins = new NativeMethods.MARGINS();
                    margins.Top = -1;
                    NativeMethods.DwmExtendFrameIntoClientArea(this.Handle, ref margins);
                    NativeMethods.DwmExtendFrameIntoClientArea(backgroundPanel.Handle, ref margins);
                    NativeMethods.DwmExtendFrameIntoClientArea(pnlControls.Handle, ref margins);
                    NativeMethods.DwmExtendFrameIntoClientArea(pnlGrid.Handle, ref margins);
                }
                glassUsed = true;
            }
            catch (DllNotFoundException) { }
            if (!glassUsed)
            {
                BackColor = Color.DarkGreen;
                backgroundPanel.BackColor = Color.DarkGreen;
                pnlControls.BackColor = Color.DarkGreen;
                pnlGrid.BackColor = Color.DarkGreen;
            }
        }

        /// <summary>Sets up all StatefulButton controls in the specified panel.</summary>
        /// <param name="buttons">The controls to set up.</param>
        private static void SetupTextStatefulButtonImages(IList buttons)
        {
            foreach (Control c in buttons)
            {
                TextStatefulButton sb = c as TextStatefulButton;
                if (sb != null)
                {
                    sb.ShadowImage = ResourceHelper.ButtonShadow;
                    sb.CheckedImage = ResourceHelper.ButtonCheckedImage;
                    sb.UncheckedImage = ResourceHelper.ButtonUncheckedImage;
                    sb.HighlightedImage = ResourceHelper.ButtonHighlightedImage;
                    sb.BackColor = Color.Transparent;
                }
            }
        }

        /// <summary>Initializes the MainForm when it's loaded.</summary>
        /// <param name="sender">The MainForm.</param>
        /// <param name="e">The event arguments.</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Display the new puzzle dialog after startup.
            ShowNewPuzzleScreen();
        }

        /// <summary>Hides the grid and controls, resets the form title, etc.</summary>
        private void ResetFormForNewPuzzleScreen()
        {
            Text = ResourceHelper.DisplayTitle;
            _winningAnimation.Visible = false;
            pnlGrid.Visible = false;
            pnlControls.Visible = false;
        }

        /// <summary>Shows the new puzzle selection screen.</summary>
        private void ShowNewPuzzleScreen()
        {
            // Hides the grid and controls, resets the form title, etc.
            ResetFormForNewPuzzleScreen();

            // Try to open an existing state file.  If it can be opened and deserialized,
            // then show the saved or new puzzle dialog; otherwise, just show the new dialog.
            bool showSavedOption = OpenStateFile(true);
            if (showSavedOption)
            {
                pnlSavedOrNewPuzzle.Visible = true;
                pnlSavedOrNewPuzzle.Focus();
                tsbLoadPreviousGame.Select();
            }
            else
            {
                thePuzzleGrid.State = null; // prevents erroneous save if new screen is closed
                pnlNewPuzzle.Visible = true;
                pnlNewPuzzle.Focus();
                switch (_puzzleDifficulty)
                {
                    default:
                    case PuzzleDifficulty.Easy:
                        tsbBeginner.Select();
                        break;
                    case PuzzleDifficulty.Medium:
                        tsbIntermediate.Select();
                        break;
                    case PuzzleDifficulty.Hard:
                        tsbAdvanced.Select();
                        break;
                    case PuzzleDifficulty.VeryHard:
                        tsbExpert.Select();
                        break;
                }
            }
        }

        /// <summary>Handles interaction from the new/saved puzzle splash screens.</summary>
        private void HandleNewPuzzleSelection(object sender, EventArgs e)
        {
            // If one of the level buttons was clicked, create a new puzzle of that level
            if (sender == tsbExpert || sender == tsbAdvanced || sender == tsbIntermediate || sender == tsbBeginner ||
                sender == tsbExpert2 || sender == tsbAdvanced2 || sender == tsbIntermediate2 || sender == tsbBeginner2)
            {
                DisableBoardToSetupPuzzle();
                DeleteStateFile();

                // Choose the level
                if (sender == tsbExpert || sender == tsbExpert2) _puzzleDifficulty = PuzzleDifficulty.VeryHard;
                else if (sender == tsbAdvanced || sender == tsbAdvanced2) _puzzleDifficulty = PuzzleDifficulty.Hard;
                else if (sender == tsbIntermediate || sender == tsbIntermediate2) _puzzleDifficulty = PuzzleDifficulty.Medium;
                else if (sender == tsbBeginner || sender == tsbBeginner2) _puzzleDifficulty = PuzzleDifficulty.Easy;

                // Create the generation options for the puzzle based on the user's difficulty choice and on their settings
                GeneratorOptions options = GeneratorOptions.Create(_puzzleDifficulty);
                options.EnsureSymmetry = _optionsDialog.ConfiguredOptions.CreatePuzzlesWithSymmetry;
                options.ParallelGeneration = _optionsDialog.ConfiguredOptions.ParallelPuzzleGeneration;
                options.SpeculativeGeneration = _optionsDialog.ConfiguredOptions.SpeculativePuzzleGeneration;

                // Start creating the new puzzle
                GenerateNewPuzzleHandler startNewPuzzle = new GenerateNewPuzzleHandler(thePuzzleGrid.GenerateNewPuzzle);
                startNewPuzzle.BeginInvoke(options, new AsyncCallback(ResetBoardAfterNewPuzzle), startNewPuzzle);
            }
            // Otherwise, the load button was clicked, so load the previous game
            else if (sender == tsbLoadPreviousGame)
            {
                if (OpenStateFile(false))
                {
                    ResetBoardAfterNewPuzzle(null);
                }
            }
        }

        /// <summary>Disables controls on the board while a puzzle is being loaded.</summary>
        private void DisableBoardToSetupPuzzle()
        {
            // Make sure the screen doesn't flash too much.  To do that, put a *minimum*
            // amount of wait time into effect
            _startNewPuzzleTime = DateTime.UtcNow;

            // Disable the board
            pnlNewPuzzle.Visible = false;
            pnlSavedOrNewPuzzle.Visible = false;
            _winningAnimation.Visible = false;
            thePuzzleGrid.Visible = false;
            pnlGrid.Visible = false;
            pnlControls.Visible = false;

            // Enable the progress bar
            marqueeBar.Visible = true;
        }

        /// <summary>Enables asynchronous creation of puzzles.</summary>
        private delegate void GenerateNewPuzzleHandler(GeneratorOptions options);

        /// <summary>Used to time how long it takes to generate a new puzzle.</summary>
        private DateTime _startNewPuzzleTime;

        /// <summary>Finishes setting up the board after a new puzzle is created.</summary>
        /// <param name="result">Can be null if puzzle was generated synchronously.</param>
        private void ResetBoardAfterNewPuzzle(IAsyncResult result)
        {
            // Make sure we're running on the UI thread
            if (InvokeRequired)
            {
                Invoke(new AsyncCallback(ResetBoardAfterNewPuzzle), new object[] { result });
                return;
            }

            // Finish the call to GenerateNewPuzzle
            try
            {
                if (result != null && result.AsyncState is GenerateNewPuzzleHandler) ((GenerateNewPuzzleHandler)result.AsyncState).EndInvoke(result);
            }
            finally
            {
                // Disable the progress bar
                marqueeBar.Visible = false;

                // Enable the board
                SuspendLayout();
                foreach (Control c in _controlButtons) c.Visible = true;
                ResumeLayout();

                pnlNewPuzzle.Visible = false;
                pnlSavedOrNewPuzzle.Visible = false;
                pnlGrid.Visible = true;
                pnlControls.Visible = true;

                backgroundPanel.Enabled = true;
                thePuzzleGrid.Visible = true;
                thePuzzleGrid.Enabled = true;
                OnResize(EventArgs.Empty);
                thePuzzleGrid.Focus();

                // Set the title to include the difficulty level
                string titleText = ResourceHelper.DisplayTitleWithDifficultyLevel;
                string diffText = null;
                switch (thePuzzleGrid.State.Difficulty)
                {
                    case PuzzleDifficulty.Easy: diffText = ResourceHelper.EasyDifficultyLevel; break;
                    case PuzzleDifficulty.Medium: diffText = ResourceHelper.MediumDifficultyLevel; break;
                    case PuzzleDifficulty.Hard: diffText = ResourceHelper.HardDifficultyLevel; break;
                    case PuzzleDifficulty.VeryHard: diffText = ResourceHelper.VeryHardDifficultyLevel; break;
                    default: titleText = ResourceHelper.DisplayTitle; break;
                }
                Text = (diffText != null) ?
                    string.Format(CultureInfo.CurrentCulture, titleText, diffText) :
                    titleText;
            }
        }

        /// <summary>Handles cleanup when the MainForm is closed.</summary>
        /// <param name="sender">The MainForm.</param>
        /// <param name="e">The event args.</param>
        private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // If the puzzle grid is visible (meaning we're not on the open/save/thinking screens),
            // delete the existing state file and save a new one in its place.  Deletion is necessary
            // before saving in case SaveStateFile determines that the current puzzle doesn't need to be saved
            // because it hasn't been modified from the original.
            if (thePuzzleGrid.Visible)
            {
                DeleteStateFile();
                SaveStateFile();
            }

            // Save the options/settings
            SaveSettings();
        }

        /// <summary>Focus the PuzzleGrid on activation.</summary>
        /// <param name="e">The event arguments.</param>
        protected override void OnActivated(EventArgs e)
        {
            // Make sure that when the main form is activated, the puzzle grid
            // is given focus.  Without this, keyboard interaction with the puzzle
            // grid can break down.
            base.OnActivated(e);
            thePuzzleGrid.Focus();
        }

        /// <summary>Warns the user that by creating a new puzzle they'll lose their current puzzle.</summary>
        /// <returns>true if the user wants to delete the current puzzle; false, otherwise.</returns>
        /// <remarks>Won't warn the user if they don't want to be warned or if nothing has changed in the current puzzle.</remarks>
        private bool WarningForUnsolvedPuzzleOnNew()
        {
            if (_optionsDialog.ConfiguredOptions.PromptOnPuzzleDelete)
            {
                if (thePuzzleGrid.PuzzleHasBeenModified)
                {
                    // Get the status of the puzzle.  If it's not solved, ask the user if they'd like
                    // to save it.
                    DialogResult result = MessageBox.Show(ResourceHelper.AboutToLosePuzzle,
                        ResourceHelper.DisplayTitle, MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, GetMessageBoxOptions(this));
                    return result == DialogResult.Yes;
                }
            }
            return true;
        }

        /// <summary>Responds to resizing of the main form.</summary>
        /// <param name="e">The event arguments</param>
        protected override void OnResize(EventArgs e)
        {
            // Do the base resizing
            base.OnResize(e);

            // Put the new puzzle panel in the middle
            pnlNewPuzzle.Location = new Point(
                backgroundPanel.Location.X + (backgroundPanel.Width - pnlNewPuzzle.Width) / 2,
                backgroundPanel.Location.Y + (backgroundPanel.Height - pnlNewPuzzle.Height) / 2);
            pnlSavedOrNewPuzzle.Location = new Point(
                backgroundPanel.Location.X + (backgroundPanel.Width - pnlSavedOrNewPuzzle.Width) / 2,
                backgroundPanel.Location.Y + (backgroundPanel.Height - pnlSavedOrNewPuzzle.Height) / 2);

            // Make sure that when we resize the form that the puzzle grid
            // stays in the center and square, as big as it can be while not exceeding its parent's bounds
            int width = pnlGrid.Width;
            int height = pnlGrid.Height;
            int margin = 25;
            Size gridSize = width > height ? new Size(height - margin, height - margin) : new Size(width - margin, width - margin);
            thePuzzleGrid.Bounds = new Rectangle(
                new Point((width - gridSize.Width) / 2, (height - gridSize.Height) / 2),
                gridSize);

            // Make sure that no matter how the form resizes that the
            // marquee progress bar ends up in the center of the form.
            marqueeBar.Location = new Point(
                backgroundPanel.Location.X + (backgroundPanel.Width - marqueeBar.Width) / 2,
                backgroundPanel.Location.Y + (backgroundPanel.Height - marqueeBar.Height) / 2);
        }

        /// <summary>Responds to layout changes on the main form.</summary>
        /// <param name="levent"></param>
        protected override void OnLayout(LayoutEventArgs levent)
        {
            // Ensure relative widths of panels
            pnlControls.Width = Width / 6;

            // Do base layout.
            base.OnLayout(levent);
        }

        /// <summary>Gets the message box options to use given the current state of the form.</summary>
        /// <param name="parent">The parent of the message box to be displayed.</param>
        /// <returns>The MessageBoxOptions to be used with MessageBox.Show.</returns>
        internal static MessageBoxOptions GetMessageBoxOptions(Control parent)
        {
            return (parent != null && parent.RightToLeft == RightToLeft.Yes) ?
                MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading :
                new MessageBoxOptions();
        }

        /// <summary>Responds when any changes are made to the current puzzle's state (or when a new puzzle is made current).</summary>
        /// <param name="sender">The PuzzleGrid or PuzzleState.</param>
        /// <param name="e">The event arguments.</param>
        private void HandleStateChanged(object sender, EventArgs e)
        {
            // If the puzzle is solved...
            if (thePuzzleGrid.State.Status == PuzzleStatus.Solved)
            {
                // Disable the grid (can't interact with a solved puzzle)
                SuspendLayout();
                thePuzzleGrid.Enabled = false;
                undoButton.Enabled = false;
                ResumeLayout();

                // Delete any state file that may have resulted from a power-save
                DeleteStateFile();

                // Show the winning animation
                Refresh();
                _winningAnimation.Visible = true;
            }
            // Otherwise, if the puzzle is not solved, make sure the grid is enabled
            else
            {
                _winningAnimation.Visible = false;

                SuspendLayout();
                thePuzzleGrid.Enabled = true;
                undoButton.Enabled = thePuzzleGrid.UndoStates.Count > 0;
                ResumeLayout();
            }
        }

        /// <summary>Handle Windows messages</summary>
        /// <param name="m">The Windows message.</param>
        protected override void WndProc(ref Message m)
        {
            // Delegate to the base implementation
            base.WndProc(ref m);

            // The WM_POWERBROADCAST message is broadcast to an application to notify it of power-management events.
            const int WM_POWERBROADCAST = 0x218;
            // The WM_DISPLAYCHANGE message is sent to all windows when the display resolution has changed.
            const int WM_DISPLAYCHANGE = 0x007E;
            // The PBT_APMSUSPEND event is broadcast immediately before the computer enters a suspended state.
            const int PBT_APMSUSPEND = 0x0004;
            // The PBT_APMSUSPEND event is broadcast immediately before the computer enters a standby state.
            const int PBT_APMSTANDBY = 0x0005;
            // The PBT_APMBATTERYLOW event is broadcast to notify applications that battery power is low.
            const int PBT_APMBATTERYLOW = 0x0009;

            switch (m.Msg)
            {
                // Save the puzzle when something power-related happens, just in case
                case WM_POWERBROADCAST:
                    switch ((int)m.WParam)
                    {
                        case PBT_APMBATTERYLOW:
                        case PBT_APMSTANDBY:
                        case PBT_APMSUSPEND:
                            SaveStateFile();
                            break;
                    }
                    break;

                // Make sure everything is within the correct boundaries
                case WM_DISPLAYCHANGE:
                    // Make sure dialogs are within screen boundaries
                    Rectangle screenRect = Screen.GetWorkingArea(this);
                    Form f = this;
                    Rectangle bounds = GetRestoreBounds(f);
                    if (!screenRect.Contains(bounds))
                    {
                        f.Location = new Point(
                            (screenRect.Width - bounds.Width) / 2,
                            (screenRect.Height - bounds.Height) / 2);
                    }
                    break;
            }
        }
        #endregion

        #region Loading and Saving Puzzles and Settings
        /// <summary>Loads a saved state from the specified stream.</summary>
        /// <param name="s">The stream from which to load the state.</param>
        /// <param name="testOnly">true if the state shouldn't be loaded into the grid, but only tested to see if it can be parsed.</param>
        private void LoadStateFileToGrid(Stream s, bool testOnly)
        {
            // Deserialize from the state file
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Deserialize(s); // Version v = (Version)
            PuzzleState state = (PuzzleState)formatter.Deserialize(s);
            PuzzleState originalState = (PuzzleState)formatter.Deserialize(s);
            Stack<PuzzleState> undoStates = (Stack<PuzzleState>)formatter.Deserialize(s);

            // Restore state and original state, undo states.  Note that LoadStateFileToGrid
            // can be called simply to test whether the state file can be deserialized, so
            // don't restore the puzzle if it was just a test.
            if (!testOnly)
            {
                thePuzzleGrid.RestorePuzzle(state, originalState, undoStates);
            }
        }

        /// <summary>Stores the current state to the specified stream.</summary>
        /// <param name="s">The stream to which the current state should be written.</param>
        private void StoreStateFileFromGrid(Stream s)
        {
            // Serialize:
            // 1. The main version number
            // 2. The current state of the board
            // 3. The original board
            // 4. The undo states
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(s, System.Reflection.Assembly.GetEntryAssembly().GetName().Version);
            formatter.Serialize(s, thePuzzleGrid.State);
            formatter.Serialize(s, thePuzzleGrid.OriginalState);
            formatter.Serialize(s, thePuzzleGrid.UndoStates);
        }

        /// <summary>Opens a state file containing a saved game.</summary>
        /// <param name="testOnly">true if the state shouldn't be loaded into the grid, but only tested to see if it can be parsed.</param>
        /// <returns>true if the file was successfully parsed; false, otherwise.</returns>
        private bool OpenStateFile(bool testOnly)
        {
            try
            {
                using (Stream s = File.OpenRead(
                          Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + SAVED_STATE_USER_PATH))
                {
                    LoadStateFileToGrid(s, testOnly);
                    return true;
                }
            }
            catch (ArgumentException) { }
            catch (IOException) { }
            catch (SecurityException) { }
            catch (SerializationException) { }
            catch (InvalidOperationException) { }
            catch (UnauthorizedAccessException) { }
            return false;
        }

        /// <summary>Deletes a saved game state file, if one exists.</summary>
        private static void DeleteStateFile()
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + SAVED_STATE_USER_PATH;
                File.Delete(path);
            }
            catch (ArgumentException) { }
            catch (IOException) { }
            catch (SecurityException) { }
            catch (UnauthorizedAccessException) { }
        }

        /// <summary>Saves the current puzzle state.</summary>
        /// <returns>true if a state was saved; false, otherwise.</returns>
        internal bool SaveStateFile()
        {
            if (thePuzzleGrid.PuzzleHasBeenModified)
            {
                // Make sure we're not weirdly serializing an empty board
                PuzzleState state = thePuzzleGrid.State;
                bool anyCellSet = false;
                foreach (byte? cell in state)
                {
                    if (cell.HasValue)
                    {
                        anyCellSet = true;
                        break;
                    }
                }

                // If any cells have values, go ahead and write out the state file
                if (anyCellSet)
                {
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + SAVED_STATE_USER_PATH;
                    try
                    {
                        DirectoryInfo parentDir = Directory.GetParent(path);
                        if (!parentDir.Exists) parentDir.Create();
                    }
                    catch (ArgumentException) { }
                    catch (IOException) { }
                    catch (SecurityException) { }
                    catch (UnauthorizedAccessException) { }

                    try
                    {
                        using (Stream s = File.OpenWrite(path))
                        {
                            StoreStateFileFromGrid(s);
                            return true;
                        }
                    }
                    catch (ArgumentException) { }
                    catch (IOException) { }
                    catch (SerializationException) { }
                    catch (UnauthorizedAccessException) { }
                }
            }
            return false;
        }

        /// <summary>Loads the user's settings from their settings store.</summary>
        private void LoadSettings(out bool windowSettingsLoaded)
        {
            // Initialize out values
            windowSettingsLoaded = false;

            // Set defaults
            ConfigurationOptions options = _optionsDialog.ConfiguredOptions;
            thePuzzleGrid.ShowIncorrectNumbers = options.ShowIncorrectCells;
            thePuzzleGrid.ShowSuggestedCells = options.SuggestEasyCells;

            // Get the path to where settings are stored
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + SAVED_SETTINGS_USER_PATH;
            try
            {
                DirectoryInfo parentDir = Directory.GetParent(path);
                if (!parentDir.Exists) parentDir.Create();
            }
            catch (ArgumentException) { }
            catch (IOException) { }
            catch (SecurityException) { }
            catch (UnauthorizedAccessException) { }

            try
            {
                // Open the settings file and read in all options
                using (Stream s = File.OpenRead(path))
                {
                    options = (ConfigurationOptions)formatter.Deserialize(s);
                    PuzzleDifficulty diff = (PuzzleDifficulty)formatter.Deserialize(s);
                    Rectangle windowBounds = (Rectangle)formatter.Deserialize(s);
                    bool maximized = (bool)formatter.Deserialize(s);

                    _optionsDialog.ConfiguredOptions.CreatePuzzlesWithSymmetry = options.CreatePuzzlesWithSymmetry;
                    _optionsDialog.ConfiguredOptions.PromptOnPuzzleDelete = options.PromptOnPuzzleDelete;
                    _optionsDialog.ConfiguredOptions.ShowIncorrectCells = options.ShowIncorrectCells;
                    _optionsDialog.ConfiguredOptions.SuggestEasyCells = options.SuggestEasyCells;
                    _optionsDialog.ConfiguredOptions.ParallelPuzzleGeneration = options.ParallelPuzzleGeneration;
                    _optionsDialog.ConfiguredOptions.SpeculativePuzzleGeneration = options.SpeculativePuzzleGeneration;

                    thePuzzleGrid.ShowIncorrectNumbers = options.ShowIncorrectCells;
                    thePuzzleGrid.ShowSuggestedCells = options.SuggestEasyCells;

                    switch (diff)
                    {
                        case PuzzleDifficulty.Easy:
                        case PuzzleDifficulty.Medium:
                        case PuzzleDifficulty.Hard:
                        case PuzzleDifficulty.VeryHard:
                            _puzzleDifficulty = diff;
                            break;
                        default:
                            _puzzleDifficulty = PuzzleDifficulty.Easy;
                            break;
                    }

                    if (maximized) WindowState = FormWindowState.Maximized;
                    if (Screen.PrimaryScreen.WorkingArea.Contains(windowBounds))
                    {
                        Bounds = windowBounds;
                    }
                    else
                    {
                        Rectangle screen = Screen.PrimaryScreen.WorkingArea;
                        Location = new Point((screen.Width - Width) / 2, (screen.Height - Height) / 2);
                    }
                    windowSettingsLoaded = true;
                }
            }
            catch (ArgumentException) { }
            catch (IOException) { }
            catch (InvalidCastException) { }
            catch (SerializationException) { }
        }

        /// <summary>Gets the bounds of the form when it's at its normal (non-maximized and non-minimized) size.</summary>
        /// <param name="c">The form for which we need the normal bounds.</param>
        /// <returns>The restored bounds of the control.</returns>
        private Rectangle GetRestoreBounds(Form f)
        {
            // Get the normal window bounds
            NativeMethods.WINDOWPLACEMENT placement = new NativeMethods.WINDOWPLACEMENT();
            placement.length = Marshal.SizeOf(typeof(NativeMethods.WINDOWPLACEMENT));
            NativeMethods.GetWindowPlacement(new HandleRef(this, f.Handle), ref placement);
            return new Rectangle(
                placement.rcNormalPosition_left, placement.rcNormalPosition_top,
                placement.rcNormalPosition_right - placement.rcNormalPosition_left + 1,
                placement.rcNormalPosition_bottom - placement.rcNormalPosition_top + 1);
        }

        /// <summary>Saves the user's settings to their settings store.</summary>
        private void SaveSettings()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + SAVED_SETTINGS_USER_PATH;

            // Make sure settings directory has been created
            try
            {
                DirectoryInfo parentDir = Directory.GetParent(path);
                if (!parentDir.Exists) parentDir.Create();
            }
            catch (ArgumentException) { }
            catch (IOException) { }
            catch (SecurityException) { }
            catch (UnauthorizedAccessException) { }

            try
            {
                // Get configuration options and new puzzle difficulty
                ConfigurationOptions options = _optionsDialog.ConfiguredOptions;
                PuzzleDifficulty difficulty = _puzzleDifficulty;

                // Get the normal window bounds
                Rectangle windowBounds = GetRestoreBounds(this);

                // Allow restoration to a maximized state
                bool maximized = (WindowState == FormWindowState.Maximized);

                // Save everything out to the settings file
                using (Stream s = File.OpenWrite(path))
                {
                    formatter.Serialize(s, options);
                    formatter.Serialize(s, difficulty);
                    formatter.Serialize(s, windowBounds);
                    formatter.Serialize(s, maximized);
                }
            }
            catch (ArgumentException) { }
            catch (InvalidCastException) { }
            catch (IOException) { }
            catch (SerializationException) { }
        }
        #endregion

        #region Keyboard Handling
        /// <summary>Handle key down events to account for full-screen and non-square modes.</summary>
        /// <param name="e">The event arguments.</param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            // ctrl-Z == Undo
            if ((e.KeyCode == Keys.Z && ((Control.ModifierKeys & Keys.Control) == Keys.Control)) &&
                thePuzzleGrid.Visible &&
                thePuzzleGrid.UndoStates.Count > 0 &&
                thePuzzleGrid.State.Status != PuzzleStatus.Solved)
            {
                thePuzzleGrid.Undo();
            }
            // ctrl-C == Copy the puzzle to the clipboard
            else if ((e.KeyCode == Keys.C && ((Control.ModifierKeys & Keys.Control) == Keys.Control)) &&
                thePuzzleGrid.Visible)
            {
                Clipboard.SetText(thePuzzleGrid.State.ToString(), TextDataFormat.Text);
            }
            // F2 = New puzzle
            else if (e.KeyCode == Keys.F2 && newGameButton.Visible && newGameButton.Enabled)
            {
                newGameButton_Click(this, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
            }
            // ctrl+F5 = Clear puzzle
            else if ((e.Control && e.KeyCode == Keys.F5) && newGameButton.Visible && newGameButton.Enabled)
            {
                thePuzzleGrid.State = null;
                thePuzzleGrid.ClearUndoCheckpoints();
                thePuzzleGrid.ClearOriginalPuzzleCheckpoint();
                DeleteStateFile();
            }
            // ctrl-O = options
            else if (e.KeyCode == Keys.O && ((Control.ModifierKeys & Keys.Control) == Keys.Control) &&
                optionsButton.Visible && optionsButton.Enabled)
            {
                optionsButton_Click(this, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
            }
            // otherwise, pass it along
            else base.OnKeyDown(e);
        }
        #endregion

        #region Button Handling
        /// <summary>Exits when the exit button is clicked.</summary>
        private void exitButton_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        /// <summary>Opens the options dialog.</summary>
        private void optionsButton_Click(object sender, System.EventArgs e)
        {
            if (_optionsDialog.ShowDialog(this) == DialogResult.OK)
            {
                SaveSettings();
                ConfigurationOptions options = _optionsDialog.ConfiguredOptions;
                thePuzzleGrid.ShowSuggestedCells = options.SuggestEasyCells;
                thePuzzleGrid.ShowIncorrectNumbers = options.ShowIncorrectCells;
            }
        }

        /// <summary>Starts a new game.</summary>
        private void newGameButton_Click(object sender, EventArgs e)
        {
            if (WarningForUnsolvedPuzzleOnNew())
            {
                // Hide the puzzle grid, reset the title bar, etc.
                ResetFormForNewPuzzleScreen();

                // Delete current and saved puzzle
                thePuzzleGrid.State = null;
                thePuzzleGrid.ClearUndoCheckpoints();
                thePuzzleGrid.ClearOriginalPuzzleCheckpoint();
                DeleteStateFile();

                // Now, prompt the user to create a new puzzle
                ShowNewPuzzleScreen();
            }
        }

        /// <summary>Undo for the previous action.</summary>
        private void undoButton_Click(object sender, EventArgs e)
        {
            thePuzzleGrid.Undo();
        }
        #endregion
    }
}