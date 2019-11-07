//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: MainWindow.xaml.cs
//
//--------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace AntisocialRobots
{
    /// <summary>Interaction logic for MainWindow.xaml</summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The width and height of the "room" (which is square) in "robot coordinates".  In
        /// other words, this many robots can sit side by side against one wall.
        /// </summary>
        const int ROOM_SIZE = 200;

        /// <summary>
        /// A map of the "room": item [x,y] (in "robot coordinates"; see RoomPoint) is the
        /// Robot that is at that spot in the room, or null if that spot is empty.
        /// </summary>
        Robot[,] _roomCells;

        /// <summary>The list of all robots.</summary>
        List<Robot> _robots;

        /// <summary>
        /// The color of the next robot to be created.  To cycle the colors, we use this
        /// algorithm: one of R, G, and B is zero; the other two cycle from 240 down to 10 and 10
        /// up to 240.
        /// </summary>
        Color _nextColor = Color.FromRgb(240, 10, 0);

        /// <summary>
        /// Calculates frames per second, by measuring the time required to display FramesPerSample
        /// frames.
        /// </summary>
        Stopwatch _framesPerSecondStopwatch = new Stopwatch();

        /// <summary>The current frame number, starting from frame zero.</summary>
        int _frameIndex;

        /// <summary>The number of frames included in one frames per second measurement.</summary>
        const int FramesPerSample = 10;

        /// <summary>Initializes an instance of this class.</summary>
        public MainWindow()
        {
            InitializeComponent();

            // Initializes robot state
            Action clearState = () =>
            {
                _roomCells = new Robot[ROOM_SIZE, ROOM_SIZE];
                _robots = new List<Robot>();
                Room.Children.Clear();
            };
            clearState();

            // When F5 is pressed, reset state
            KeyDown += (_, e) => { if (e.Key == Key.F5) clearState(); };

            // Render loop, started when the window loads
            Action recomputeAndRedraw = null;
            recomputeAndRedraw = delegate
            {
                Dispatcher.BeginInvoke((Action)delegate
                {
                    PerformSimulationStep();
                    recomputeAndRedraw();
                }, DispatcherPriority.Background);
            };
            Loaded += delegate
            {
                _framesPerSecondStopwatch.Start();
                recomputeAndRedraw();
            };
        }

        /// <summary>
        /// Called when the size of the RoomParent (the control containing the canvas that
        /// displays the robots) changes.
        /// </summary>
        private void RoomParent_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            // Set size to the width/height of the largest square that fits within
            // RoomParent (the control containing the canvas that holds robots)
            double size = Math.Min(RoomParent.ActualWidth, RoomParent.ActualHeight);

            // Room is set to be 1.0 units wide x 1.0 units high -- apply a scaling
            // transform so that it fills RoomParent
            RoomScaleTransform.ScaleX = size;
            RoomScaleTransform.ScaleY = size;

            // Center Room within the RoomParent
            double marginX = (RoomParent.ActualWidth - size) / 2;
            double marginY = (RoomParent.ActualHeight - size) / 2;
            Room.Margin = new Thickness(marginX, marginY, 0, 0);
        }

        /// <summary>Called when the user clicks on the canvas containing the robots.</summary>
        private void Room_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CreateRobot(MousePositionToRoomPoint(e));
        }

        /// <summary>
        /// Called when the users moves the mouse, or holds the mouse button, over the canvas
        /// containing the robots.
        /// </summary>
        private void Room_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.MouseDevice.LeftButton == MouseButtonState.Pressed)
                CreateRobot(MousePositionToRoomPoint(e));
        }

        /// <summary>Creates a robot, which is placed at a given location with the room.</summary>
        /// <param name="pt">Where the robot should be placed, in RoomPoint coordinates.</param>
        void CreateRobot(RoomPoint pt)
        {
            // Do nothing if there's already a robot here
            if (_roomCells[pt.X, pt.Y] != null) return;

            // Create the new robot
            Robot robot = new Robot()
            {
                Location = pt,
                Element = new Ellipse()
                {
                    Width = 1.0 / ROOM_SIZE,
                    Height = 1.0 / ROOM_SIZE,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Fill = new SolidColorBrush(_nextColor)
                }
            };

            // Set the position of the robot within Room
            SetRobotElementPosition(robot, pt);

            // Add the robot to Room
            Room.Children.Add(robot.Element);

            // Add the robot to our data structures
            _robots.Add(robot);
            _roomCells[pt.X, pt.Y] = robot;

            // Advance _nextColor to the next color to use
            MoveNextColor();
        }

        /// <summary>Advances to the next color in the rotation.</summary>
        private void MoveNextColor()
        {
            if (_nextColor.B == 0)
            {
                _nextColor.R = (byte)Math.Max((int)_nextColor.R - 10, 0);
                _nextColor.G = (byte)Math.Max((int)_nextColor.G + 10, 0);
                if (_nextColor.R == 0)
                {
                    _nextColor.G = 240;
                    _nextColor.B = 10;
                }
            }
            else if (_nextColor.G > 0)
            {
                _nextColor.G = (byte)Math.Max((int)_nextColor.G - 10, 0);
                _nextColor.B = (byte)Math.Max((int)_nextColor.B + 10, 0);
                if (_nextColor.G == 0)
                {
                    _nextColor.B = 240;
                    _nextColor.R = 10;
                }
            }
            else
            {
                _nextColor.B = (byte)Math.Max((int)_nextColor.B - 10, 0);
                _nextColor.R = (byte)Math.Max((int)_nextColor.R + 10, 0);
                if (_nextColor.B == 0)
                {
                    _nextColor.R = 240;
                    _nextColor.G = 10;
                }
            }
        }

        /// <summary>Sets the position of the Robot.Element for a given robot to a given point.</summary>
        /// <param name="robot">The robot.</param>
        /// <param name="pt">The location in RoomPoint coordinates.</param>
        void SetRobotElementPosition(Robot robot, RoomPoint pt)
        {
            Canvas.SetLeft(robot.Element, ((double)pt.X) / ROOM_SIZE);
            Canvas.SetTop(robot.Element, ((double)pt.Y) / ROOM_SIZE);
        }

        /// <summary>Converts a mouse position to a RoomPoint.</summary>
        /// <param name="e">The event arguments containing the mouse position.</param>
        RoomPoint MousePositionToRoomPoint(MouseEventArgs e)
        {
            Point pt = e.GetPosition(Room);
            return new RoomPoint((int)(pt.X * ROOM_SIZE), (int)(pt.Y * ROOM_SIZE));
        }

        /// <summary>Performs one step of the simulation.</summary>
        void PerformSimulationStep()
        {
            // Calculate a new position for each robot, update _roomCells and each
            // Robot.Location with that information
            if (chkParallel.IsChecked.Value)
            {
                for (int stripe = 0; stripe < 9; stripe++) // use striping to avoid races
                {
                    Parallel.ForEach(_robots, robot =>
                    {
                        if (robot.LastMovedFrame < _frameIndex && (robot.Location.X % 3) == (stripe % 3) && (robot.Location.Y % 3) == (stripe / 3))
                        {
                            SimulateOneStep(robot);
                            robot.LastMovedFrame = _frameIndex;
                        }
                    });
                }
            }
            else
            {
                foreach (Robot robot in _robots)
                {
                    SimulateOneStep(robot);
                    robot.LastMovedFrame = _frameIndex;
                }
            }

            // update the on-screen position of all robots
            foreach (Robot robot in _robots)
                SetRobotElementPosition(robot, robot.Location);

            // Update statistics
            if ((++_frameIndex % FramesPerSample) == 0)
            {
                double fps = (1000 / (double)_framesPerSecondStopwatch.ElapsedMilliseconds) * FramesPerSample;
                txtStatus.Text = String.Format("{0} robots, {1:n1} fps", _robots.Count, fps);
                _framesPerSecondStopwatch.Restart();
            }
        }

        /// <summary>Performs one step of the simulation for one robot.</summary>
        /// <param name="r">The robot to perform the simulation step for.</param>
        void SimulateOneStep(Robot r)
        {
            // Set ptR to the location of the robot in room coordinates
            RoomPoint ptR = r.Location;
            double vectorX = 0, vectorY = 0;

            foreach (Robot s in _robots)
            {
                if (r == s) continue;
                RoomPoint ptS = s.Location;
                double inverseSquareDistance = 1.0 / RoomPoint.Square(ptR.DistanceTo(ptS));
                double angle = ptR.AngleTo(ptS);
                vectorX -= inverseSquareDistance * Math.Cos(angle);
                vectorY -= inverseSquareDistance * Math.Sin(angle);
            }

            double degrees = Math.Atan2(vectorY, vectorX) * 180 / Math.PI;

            degrees += 22.5;
            while (degrees < 0) degrees += 360;
            while (degrees >= 360) degrees -= 360;

            int direction = (int)(degrees * 8 / 360);

            if ((direction == 7) || (direction == 0) || (direction == 1))
                ptR.X = Math.Min(ptR.X + 1, ROOM_SIZE - 1);
            else if ((direction == 3) || (direction == 4) || (direction == 5))
                ptR.X = Math.Max(ptR.X - 1, 0);

            if ((direction == 1) || (direction == 2) || (direction == 3))
                ptR.Y = Math.Min(ptR.Y + 1, ROOM_SIZE - 1);
            else if ((direction == 5) || (direction == 6) || (direction == 7))
                ptR.Y = Math.Max(ptR.Y - 1, 0);

            if (((ptR.X != r.Location.X) || (ptR.Y != r.Location.Y)) && _roomCells[ptR.X, ptR.Y] == null)
            {
                _roomCells[r.Location.X, r.Location.Y] = null;
                _roomCells[ptR.X, ptR.Y] = r;
                r.Location = new RoomPoint(ptR.X, ptR.Y);
            }
        }
    }
}