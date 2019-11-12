//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: Window1.xaml.cs
//
//--------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Timers;
using System.Threading;
using System.Threading.Tasks;


namespace Reversi
{

    /// <summary>
    /// Interaction logic for Window1.xaml
    /// 
    /// The board is oriented such that the top left hand corner is cell 0,0 and the bottom right hand corner
    /// is cell 7,7
    /// </summary>
    public partial class Window1 : Window
    {
        private const double S_CYLINDER_HEIGHT = 3.0;
        private const double S_CYLINDER_WIDTH = 5.0;
        private readonly Color S_DARK_COLOR = Color.FromRgb(30, 30, 30);
        private readonly Color S_LIGHT_COLOR = Colors.White;

        private ReversiGame m_game;
        private MinimaxSpot[,] m_GUIboard;
        private Task m_aiUITask;
        private CancellationTokenSource m_aiUICts;
        private TaskScheduler m_UIScheduler;
        private bool m_isGameOver, m_isAIMoving, m_isAIParallel, m_isAuto;
        private Duration m_progBarDuration;
        private DoubleAnimation m_progBarAnim;

        private bool m_useAnimation;

        public Window1()
        {
            InitializeComponent();
            m_gamePieces = new Dictionary<Point, Cylinder>();
            m_ghostPieces = new Dictionary<Cylinder, Point>();

            // some animation/UI initialization
            NameScope.SetNameScope(mainViewport, new NameScope());

            ui_dopSlider.Minimum = 1.0;
            ui_dopSlider.Maximum = Environment.ProcessorCount * 2;
            ui_dopSlider.Value = Environment.ProcessorCount;
            ui_depthSlider.Minimum = 8.0;
            ui_depthSlider.Maximum = 24.0;
            ui_depthSlider.Value = 18.0;
            ui_timeoutSlider.Minimum = 1.0;
            ui_timeoutSlider.Maximum = 60.0;
            ui_timeoutSlider.Value = 8.0;
            m_useAnimation = true;

            // Set the UI scheduler
            m_UIScheduler = TaskScheduler.FromCurrentSynchronizationContext();

            // Initialize the game
            m_game = new ReversiGame(8, 8);
            m_isGameOver = false;
            m_isAIMoving = false;
            m_isAIParallel = true;
            m_isAuto = false;

            // Initialize the GUI's board
            m_GUIboard = new MinimaxSpot[8, 8];
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    m_GUIboard[i, j] = MinimaxSpot.Empty;
            UpdateBoard();
        }

        private void GoAI()
        {
            if (m_isGameOver)
                return;

            m_isAIMoving = true;

            m_progBarAnim = new DoubleAnimation(0.0, 100.0, m_progBarDuration);
            if (m_isAIParallel)
            {
                ui_parProgBar.Visibility = Visibility.Visible;
                ui_parProgBar.BeginAnimation(ProgressBar.ValueProperty, m_progBarAnim, HandoffBehavior.SnapshotAndReplace);
            }
            else
            {
                ui_seqProgBar.Visibility = Visibility.Visible;
                ui_seqProgBar.BeginAnimation(ProgressBar.ValueProperty, m_progBarAnim, HandoffBehavior.SnapshotAndReplace);
            }

            m_aiUICts = new CancellationTokenSource();
            m_aiUITask = Task.Factory.StartNew(() =>
            {
                return m_game.GetAIMove(m_isAIParallel);

            }, m_aiUICts.Token, TaskCreationOptions.None, TaskScheduler.Default)
            .ContinueWith(completedTask =>
            {
                MinimaxMove aiMove = completedTask.Result;
                if (aiMove.Row != -1)
                    m_game.MakeMove(aiMove.Row, aiMove.Col);
                else
                    m_game.PassMove();

                string s;
                if (m_isAIParallel)
                {
                    s = String.Format("{0:N}", m_game.MovesConsidered);
                    s = s.Substring(0, s.Length - 3);
                    ui_parLabel.Content = s;
                    ui_parProgBar.Visibility = Visibility.Hidden;
                }
                else
                {
                    s = String.Format("{0:N}", m_game.MovesConsidered);
                    s = s.Substring(0, s.Length - 3);
                    ui_seqLabel.Content = s;
                    ui_seqProgBar.Visibility = Visibility.Hidden;
                }

                UpdateBoard();
                m_isAIMoving = false;

                if (m_isAuto)
                {
                    m_isAIParallel = !m_isAIParallel;
                    GoAI();
                }
            }, m_aiUICts.Token, TaskContinuationOptions.None, m_UIScheduler);
        }

        private bool UpdateBoard()
        {
            if (m_isGameOver)
                return false;

            MinimaxSpot[,] game = m_game.Board;
            MinimaxSpot[,] gui = m_GUIboard;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (gui[i, j] == MinimaxSpot.Empty && game[i, j] != MinimaxSpot.Empty)
                    {
                        AddPiece(i, j, game[i, j] == MinimaxSpot.Light ? true : false);
                    }
                    else if ((gui[i, j] == MinimaxSpot.Light && game[i, j] == MinimaxSpot.Dark) ||
                        (gui[i, j] == MinimaxSpot.Dark && game[i, j] == MinimaxSpot.Light))
                    {
                        FlipPiece(i, j);
                    }
                }
            }

            // Remove old ghost pieces.
            foreach (var c in m_ghostPieces)
            {
                mainViewport.Children.Remove(c.Key);
            }
            m_ghostPieces.Clear();

            // Generate new ghost pieces.
            IEnumerable<MinimaxMove> moves = m_game.GetValidMoves();
            foreach (var m in moves)
            {
                ShowGhost(m.Row, m.Col, m_game.IsLightMove);
            }

            ReversiGameResult gs = m_game.GetGameResult();
            if (gs.GameState == ReversiGameState.LightWon)
            {
                m_isGameOver = true;
                MessageBox.Show(String.Format("Light Won! {0}-{1}", gs.NumLightPieces, gs.NumDarkPieces), "GAME OVER");
                return false;
            }
            if (gs.GameState == ReversiGameState.DarkWon)
            {
                m_isGameOver = true;
                MessageBox.Show(String.Format("Dark Won! {0}-{1}", gs.NumLightPieces, gs.NumDarkPieces), "GAME OVER");
                return false;
            }
            if (gs.GameState == ReversiGameState.Draw)
            {
                m_isGameOver = true;
                MessageBox.Show(String.Format("Draw! {0}-{1}", gs.NumLightPieces, gs.NumDarkPieces), "GAME OVER");
                return false;
            }
            return true;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            var cameraPos = mainCamera.Position;
            if (e.Key == Key.Up)
                cameraPos.Z += 1;
            if (e.Key == Key.Down)
                cameraPos.Z -= 1;
            if (e.Key == Key.T)
                mainCamera.FieldOfView += 10;
            if (e.Key == Key.G)
                mainCamera.FieldOfView -= 10;
            if (e.Key == Key.D)
            {
                m_game.Dump("");
                MessageBox.Show("Dumped.");
            }

            mainCamera.Position = cameraPos;
        }

        #region IReversiView Members

        /// <summary>
        /// Collection of pieces on the board.
        /// </summary>
        private Dictionary<Point, Cylinder> m_gamePieces;
        private Dictionary<Cylinder, Point> m_ghostPieces;

        public void AddPiece(int row, int col, bool isPlayerLight)
        {
            if (m_useAnimation)
                AddPieceAnimated(row, col, isPlayerLight);
            else
                AddPieceUnanimated(row, col, isPlayerLight);
        }

        const int CYLINDER_RESOLUTION = 50;

        /// <summary>
        /// Places a piece on the gameboard by visually "dropping the piece."
        /// </summary>
        /// <param name="row">The row of the piece to place.</param>
        /// <param name="col">The column of the piece to place.</param>
        /// <param name="isBlack">If true, the piece color is black; otherwise, it's white.</param>
        public void AddPieceAnimated(int row, int col, bool isPlayerLight)
        {
            // Update the GUI board
            m_GUIboard[row, col] = isPlayerLight ? MinimaxSpot.Light : MinimaxSpot.Dark;

            // Hack to match danny's orientation
            row = 7 - row;

            // create the piece and place it above the destination square
            var newPiece = new Cylinder(S_CYLINDER_WIDTH, S_CYLINDER_HEIGHT, CYLINDER_RESOLUTION, isPlayerLight
                ? new DiffuseMaterial(new SolidColorBrush(S_LIGHT_COLOR))
                : new DiffuseMaterial(new SolidColorBrush(S_DARK_COLOR)));
            double centerX, centerY;
            GetViewCoordinates(col, row, out centerX, out centerY);
            newPiece.MoveTo(new Point3D(centerX, centerY, 20.0));
            mainViewport.Children.Add(newPiece);

            // animate it's descent
            var animationStoryboard = new Storyboard();

            var translateTransform = new TranslateTransform3D(
                centerX, centerY, 20.0);
            var moveDownAnimation = new DoubleAnimation(0, new Duration(TimeSpan.FromMilliseconds(500)));
            mainViewport.RegisterName("GamePieceDrop", translateTransform);
            Storyboard.SetTargetName(moveDownAnimation, "GamePieceDrop");
            Storyboard.SetTargetProperty(moveDownAnimation, new PropertyPath(TranslateTransform3D.OffsetZProperty));
            animationStoryboard.Children.Add(moveDownAnimation);
            newPiece.Transform = translateTransform;

            animationStoryboard.Begin(mainViewport);

            mainViewport.UnregisterName("GamePieceDrop");

            m_gamePieces[new Point(row, col)] = newPiece;
        }

        /// <summary>
        /// Adds a piece to the game board without animation.  This method is called when the board is
        /// initialized.
        /// </summary>
        /// <param name="col">The column of the piece to add.</param>
        /// <param name="row">The row of the piece to add.</param>
        /// <param name="isBlack">If true, the piece color is black; otherwise, it's white.</param>
        public void AddPieceUnanimated(int row, int col, bool isPlayerLight)
        {
            // Update the GUI board
            m_GUIboard[row, col] = isPlayerLight ? MinimaxSpot.Light : MinimaxSpot.Dark;

            // Hack to match danny's orientation
            row = 7 - row;

            // create the piece and place it above the destination square
            var newPiece = new Cylinder(S_CYLINDER_WIDTH, S_CYLINDER_HEIGHT, CYLINDER_RESOLUTION, isPlayerLight
                ? new DiffuseMaterial(new SolidColorBrush(S_LIGHT_COLOR))
                : new DiffuseMaterial(new SolidColorBrush(S_DARK_COLOR)));
            MovePiece(newPiece, col, row);
            m_gamePieces[new Point(row, col)] = newPiece;
            mainViewport.Children.Add(newPiece);
        }

        public void FlipPiece( int row, int col )
        {
            if (m_useAnimation)
                FlipPieceAnimated(row, col);
            else
                FlipPieceUnanimated(row, col);
        }

        public void FlipPieceUnanimated(int row, int col)
        {
            // Update the GUI board
            m_GUIboard[row, col] = m_GUIboard[row, col] == MinimaxSpot.Light ? MinimaxSpot.Dark : MinimaxSpot.Light;

            // Hack to match danny's orientation
            row = 7 - row;

            // get the piece's world coordinates
            double centerX, centerY;
            GetViewCoordinates(col, row, out centerX, out centerY);
            var gamePiece = m_gamePieces[new Point(row, col)];

            // get the diffuse material
            var diffMaterialBrush = (gamePiece.Material as DiffuseMaterial).Brush as SolidColorBrush;
            diffMaterialBrush.Color = diffMaterialBrush.Color.Equals(S_LIGHT_COLOR) ? S_DARK_COLOR : S_LIGHT_COLOR;
        }

        /// <summary>
        /// "Flips" the game piece by lifting it, rotating it, and fading it's color from black to white, or vice versa.
        /// </summary>
        /// <param name="col">The column of the piece to flip.</param>
        /// <param name="row">The row of the piece to flip.</param>
        public void FlipPieceAnimated(int row, int col)
        {
            // Update the GUI board
            m_GUIboard[row, col] = m_GUIboard[row, col] == MinimaxSpot.Light ? MinimaxSpot.Dark : MinimaxSpot.Light;

            // Hack to match danny's orientation
            row = 7 - row;

            // get the piece's world coordinates
            double centerX, centerY;
            GetViewCoordinates(col, row, out centerX, out centerY);
            var gamePiece = m_gamePieces[new Point(row, col)];

            // define an animation storyboard and a transform group
            var animationsStoryboard = new Storyboard();
            var transformGroup = new Transform3DGroup();

            // setup the lift animation
            var translateTransform = new TranslateTransform3D(
                centerX, centerY, S_CYLINDER_HEIGHT / 2.0);
            var moveUpAnimation = new DoubleAnimation(10, new Duration(TimeSpan.FromMilliseconds(500)));
            moveUpAnimation.AutoReverse = true;
            mainViewport.RegisterName("GamePieceMoveUp", translateTransform);
            Storyboard.SetTargetName(moveUpAnimation, "GamePieceMoveUp");
            Storyboard.SetTargetProperty(moveUpAnimation, new PropertyPath(TranslateTransform3D.OffsetZProperty));
            animationsStoryboard.Children.Add(moveUpAnimation);


            // setup the rotate animation
            var axisAngleRotation = new AxisAngleRotation3D(new Vector3D(0, 1, 0), 0);
            var rotateTransform = new RotateTransform3D(axisAngleRotation, new Point3D(-0, 0, S_CYLINDER_HEIGHT / 2.0));
            rotateTransform.Rotation = axisAngleRotation;
            var flipOverAnimation = new DoubleAnimation(0, 180, new Duration(TimeSpan.FromMilliseconds(1000)));
            mainViewport.RegisterName("GamePieceFlipOver", axisAngleRotation);
            Storyboard.SetTargetName(flipOverAnimation, "GamePieceFlipOver");
            Storyboard.SetTargetProperty(flipOverAnimation, new PropertyPath(AxisAngleRotation3D.AngleProperty));
            animationsStoryboard.Children.Add(flipOverAnimation);

            // setup the recolor animation
            // get the diffuse material
            var diffMaterialBrush = (gamePiece.Material as DiffuseMaterial).Brush as SolidColorBrush;
            var changeColorAnimation = new ColorAnimation();
            changeColorAnimation.To = diffMaterialBrush.Color.Equals(S_LIGHT_COLOR) ? S_DARK_COLOR : S_LIGHT_COLOR;
            changeColorAnimation.Duration = TimeSpan.FromMilliseconds(1000);
            mainViewport.RegisterName("GamePieceChangeColor", diffMaterialBrush);
            Storyboard.SetTargetName(changeColorAnimation, "GamePieceChangeColor");
            Storyboard.SetTargetProperty(changeColorAnimation, new PropertyPath(SolidColorBrush.ColorProperty));
            animationsStoryboard.Children.Add(changeColorAnimation);

            // start the animation
            // note the transforms are applied in this specific order so that the piece ends up in the right location
            transformGroup.Children.Add(rotateTransform);
            transformGroup.Children.Add(translateTransform);
            gamePiece.Transform = transformGroup;
            animationsStoryboard.Begin(mainViewport);

            // unregister all animations so they can be performed again
            mainViewport.UnregisterName("GamePieceMoveUp");
            mainViewport.UnregisterName("GamePieceFlipOver");
            mainViewport.UnregisterName("GamePieceChangeColor");
        }

        public void ShowGhost(int row, int col, bool isPlayerLight)
        {
            // Hack to match danny's orientation
            row = 7 - row;

            // create the piece and place it above the destination square
            var newPiece = new Cylinder(S_CYLINDER_WIDTH, S_CYLINDER_HEIGHT, CYLINDER_RESOLUTION, isPlayerLight
                ? new DiffuseMaterial(new SolidColorBrush(S_LIGHT_COLOR))
                : new DiffuseMaterial(new SolidColorBrush(S_DARK_COLOR)));
            double centerX, centerY;
            GetViewCoordinates(col, row, out centerX, out centerY);
            // make the piece transparent
            var pieceColor = (newPiece.Material as DiffuseMaterial).Color;
            pieceColor.A = 70;
            (newPiece.Material as DiffuseMaterial).Color = pieceColor;
            newPiece.MoveTo(new Point3D(centerX, centerY, 0.0));
            mainViewport.Children.Add(newPiece);

            m_ghostPieces.Add(newPiece, new Point(col, row));
        }

        #endregion

        #region View Helper Functions

        // moves a cylinder piece to a place on the gameboard
        private void MovePiece(Cylinder piece, int col, int row)
        {
            double centerX;
            double centerY;
            GetViewCoordinates(col, row, out centerX, out centerY);
            piece.MoveTo(new Point3D(centerX, centerY, S_CYLINDER_HEIGHT / 2.0));
        }

        private static void GetViewCoordinates(int col, int row, out double centerX, out double centerY)
        {
            // width of cell * number of row/col - center point of first col/row
            centerY = -(row * 10.0 - 35.0);
            centerX = col * 10.0 - 35.0;
        }
        #endregion

        private void mainViewport_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (m_isGameOver)
            {
                MessageBox.Show("Game is over.", "GAME OVER");
                return;
            }

            if (m_isAIMoving)
            {
                MessageBox.Show("AI is moving.  Wait for your opponent.", "INVALID");
                return;
            }

            Point ghostPos;
            var res = GetGhostPiecePosition(e.GetPosition(mainViewport), out ghostPos);
            if (res)
            {
                m_game.SetMinimaxKnobs((int)ui_depthSlider.Value, TimeSpan.FromSeconds((int)ui_timeoutSlider.Value), (int)ui_dopSlider.Value);
                m_progBarDuration = new Duration(m_game.TimeLimit);
                int row = 7 - (int)ghostPos.Y;
                int col = (int)ghostPos.X;
                if (m_game.MakeMove(row, col))
                {
                    if (UpdateBoard())
                        GoAI();
                }
                else
                {
                    MessageBox.Show("Can't move there. Shouldn't be seeing this message.", "ERROR");
                }
            }
            else
            {
                MessageBox.Show("You chose to pass.", "USER MOVE");
                m_game.PassMove();
                if (UpdateBoard())
                    GoAI();
            }
        }

        private bool GetGhostPiecePosition(Point mousePosition, out Point ghostPosition)
        {
            ghostPosition = new Point();
            var hitTestResult = VisualTreeHelper.HitTest(mainViewport, mousePosition);
            if (hitTestResult.VisualHit is Cylinder)
            {
                var cylinder = hitTestResult.VisualHit as Cylinder;
                if (!m_ghostPieces.ContainsKey(cylinder)) return false;
                ghostPosition = m_ghostPieces[cylinder];
                return true;
            }
            else
            {

                return false;
            }
        }


        private void ui_startStopButton_Click(object sender, RoutedEventArgs e)
        {
            if (!m_isAuto)
            {
                ui_dopSlider.IsEnabled = false;
                ui_depthSlider.IsEnabled = false;
                ui_timeoutSlider.IsEnabled = false;

                ui_startStopButton.Content = "Stop Sequential vs. Parallel";

                m_game.SetMinimaxKnobs((int)ui_depthSlider.Value, TimeSpan.FromSeconds((int)ui_timeoutSlider.Value), (int)ui_dopSlider.Value);
                m_progBarDuration = new Duration(m_game.TimeLimit);
                m_isAuto = true;
                m_isAIParallel = false;

                ui_seqPlayerLabel.Content = "Sequential Player";
                GoAI();
            }
            else
            {
                m_game.Cancel();
                m_aiUICts.Cancel();
                ui_seqProgBar.Visibility = Visibility.Hidden;
                ui_parProgBar.Visibility = Visibility.Hidden;

                ui_dopSlider.IsEnabled = true;
                ui_depthSlider.IsEnabled = true;
                ui_timeoutSlider.IsEnabled = true;

                ui_startStopButton.Content = "Start Sequential vs. Parallel";

                m_isAuto = false;
                m_isAIMoving = false;
                m_isAIParallel = true;

                ui_seqPlayerLabel.Content = "You";
            }
            ui_settings.Focus(); // stop the button from blinking due to it having focus
        }

        private void Animation_Toggled(object sender, RoutedEventArgs e)
        {
            m_useAnimation = !m_useAnimation;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // add piece icons to the player badges
            seqPlayerViewport.Children.Add( new Cylinder(S_CYLINDER_WIDTH, S_CYLINDER_HEIGHT, CYLINDER_RESOLUTION, new DiffuseMaterial(new SolidColorBrush(S_DARK_COLOR))));
            parPlayerViewport.Children.Add(new Cylinder(S_CYLINDER_WIDTH, S_CYLINDER_HEIGHT, CYLINDER_RESOLUTION, new DiffuseMaterial(new SolidColorBrush(S_LIGHT_COLOR))));
        }
    }
}
