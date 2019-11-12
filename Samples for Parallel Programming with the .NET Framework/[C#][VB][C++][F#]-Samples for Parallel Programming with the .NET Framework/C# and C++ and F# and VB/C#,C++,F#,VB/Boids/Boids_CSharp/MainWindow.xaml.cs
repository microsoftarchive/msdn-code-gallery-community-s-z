//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: MainWindow.xaml.cs
//
//--------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Threading;
using System.Media;

namespace ParallelBoids
{
    /// <summary>Interaction logic for MainWindow.xaml</summary>
    public partial class MainWindow : Window
    {
        #region Configurable Control Values
        /// <summary>Desired number of frames per second to be computed and rendered.</summary>
        private const int FRAMES_PER_SECOND = 24;
        /// <summary>The number of boids to simulate.</summary>
        private const int NUM_BOIDS = 900;
        /// <summary>The size of a neighborhood that affects a boid.</summary>
        private const int NEIGHBORHOOD_SIZE = 100;
        /// <summary>The minimum distance one boid tries to maintain from another.</summary>
        private const int MIN_DISTANCE_FROM_NEIGHBOR = 20;
        /// <summary>The angle that a boid can see around it.</summary>
        private const double DEGREES_OF_SIGHT = 180;
        /// <summary>The duration in milliseconds of a scatter event.</summary>
        private const long SCATTER_TIME = 4000;
        /// <summary>The maximum speed of a boid.</summary>
        private double m_speedLimit = 10.0;
        /// <summary>Multiplicative factor used when determining how much to move a boid towards the average position of boids in its neighborhood.</summary>
        private const double PERCENTAGE_TO_MOVE_TOWARDS_AVERAGE_POSITION = .01 * GLOBAL_MODIFICATION_RATE;
        /// <summary>Multiplicative factor used when determining how much to move a boid towards the average velocity of boids in its neighborhood.</summary>
        private const double PERCENTAGE_TO_MOVE_TOWARDS_AVERAGE_VELOCITY = .01 * GLOBAL_MODIFICATION_RATE;
        /// <summary>Multiplicative factor used when determining how much to move a boid towards staying in bounds if it's currently out of bounds.</summary>
        private const double PERCENTAGE_TO_MOVE_TOWARDS_INBOUNDS = .2 * GLOBAL_MODIFICATION_RATE;
        /// <summary>Multiplicative factor used when determining how much to move a boid towards its "home" position.</summary>
        private const double PERCENTAGE_TO_MOVE_TOWARDS_HOME = .01 * GLOBAL_MODIFICATION_RATE;
        /// <summary>Multiplicative factor included in all velocity-modifying rates.</summary>
        private const double GLOBAL_MODIFICATION_RATE = 1.0;
        /// <summary>Base weight to use for rule #1: flying towards the center of the neighborhood.</summary>
        private double m_rule1Weight = 1.0;
        /// <summary>Base weight to use for rule #2: staying away from neighbors too close to it.</summary>
        private double m_rule2Weight = 1.1;
        /// <summary>Base weight to use for rule #3: maintaining a similar velocity to its neighbors.</summary>
        private double m_rule3Weight = 1.0;
        /// <summary>Base weight to use for rule #4: staying within the aviary.</summary>
        private double m_rule4Weight = 0.9;
        /// <summary>Base weight to use for rule #5: staying close to home.</summary>
        private double m_rule5Weight = 0.8;
        #endregion

        #region Member Variables
        /// <summary>The boids.</summary>
        private Boid[] m_boidModels;
        /// <summary>The bounds of the aviary in which the boids fly.</summary>
        private Rect3D m_aviary;
        /// <summary>The "home" position boids tend towards.</summary>
        private Vector3D m_home;
        /// <summary>Parallel options to use for parallelized loops.</summary>
        private ParallelOptions m_parallelOptions = new ParallelOptions() { MaxDegreeOfParallelism = 1 };
        /// <summary>Whether to move the camera automatically to keep boids in view.</summary>
        private bool m_autoPanCamera = true;
        /// <summary>Timer used to control scattering behavior when boids get spooked.</summary>
        private Timer m_scatterTimer;
        /// <summary>Timer used to control the rendering signal.</summary>
        private System.Timers.Timer m_renderTimer;
        /// <summary>Event used to signal the background processing thread that it should compute a new frame.</summary>
        private AutoResetEvent m_renderSignal = new AutoResetEvent(false);
        /// <summary>Stopwatch used to time how long it takes to compute a frame.</summary>
        private Stopwatch m_frameStopwatch = new Stopwatch();
        /// <summary>The number of frames rendered since the last time the value was displayed to the user.</summary>
        private int m_numRendersSinceLastUserPresentation = 0;
        /// <summary>The total time spent rendering since the last time the value was displayed to the user.</summary>
        private long m_totalRenderingMillisecondsSinceLastUserPresentation = 0;
        /// <summary>The next time the sec/frame value should be displayed to the user.</summary>
        private DateTimeOffset m_nextUserPresentation = DateTimeOffset.Now;
        /// <summary>The last mouse position while it was down.</summary>
        private Point _lastMousePosition;
        #endregion

        #region Initialization
        /// <summary>Initializes the window.</summary>
        public MainWindow() { InitializeComponent(); }

        /// <summary>Initialize the scene.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The eventargs</param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Hand;

            // Set up the aviary.  This should match the size of the grass geometry configured in the XAML.
            m_aviary = new Rect3D(-300, 0, -400, 600, 180, 800);
            m_home = new Vector3D(0, 15, 0); // home is close to 0,0,0, just a bit off the ground

            // The color combinations to use for boids.  At least one combination is necessary,
            // but more can be added to get more variations.
            var colorCombinations = new Tuple<Color, Color>[]
            {
                Tuple.Create(Colors.SeaGreen, Colors.Silver),
                Tuple.Create(Colors.Pink, Colors.Purple),
                Tuple.Create(Colors.Yellow, Colors.Gold)
            };

            // Generate all of the boids, with random color, position, and velocity assignments.  Then add them to the scene.
            var rand = new Random();
            m_boidModels = Enumerable.Range(0, NUM_BOIDS).Select(_ => new Boid(colorCombinations[rand.Next(0, colorCombinations.Length)])).ToArray();
            RandomizeBoidPositionsAndVelocities(rand);
            foreach (var boidModel in m_boidModels) viewport3D.Children.Add(boidModel);

            // Configure and start the rendering timer.  A System.Timers.Timer is used to make it easy to turn on and off.
            var renderTimerPeriod = (int)(1000.0 / FRAMES_PER_SECOND);
            m_renderTimer = new System.Timers.Timer(renderTimerPeriod);
            m_renderTimer.Elapsed += (_, __) => m_renderSignal.Set();
            m_renderTimer.Enabled = true;

            // Start the rendering loop on a background thread
            Task.Factory.StartNew(RenderUpdateLoop);
        }

        /// <summary>Move the boids to random positions and velocities.</summary>
        /// <param name="rand">The random number generator to use.</param>
        private void RandomizeBoidPositionsAndVelocities(Random rand = null)
        {
            if (rand == null) rand = new Random();
            foreach (var boid in m_boidModels)
            {
                boid.Position = new Vector3D(
                           rand.Next((int)m_aviary.X, (int)(m_aviary.X + m_aviary.SizeX)),
                           rand.Next((int)m_aviary.Y, (int)(m_aviary.Y + m_aviary.SizeY)),
                           rand.Next((int)m_aviary.Z, (int)(m_aviary.Z + m_aviary.SizeZ)));
                boid.Velocity = new Vector3D(
                           rand.NextDouble() * 2 - 1,
                           rand.NextDouble() * 2 - 1,
                           rand.NextDouble() * 2 - 1);
            }
        }
        #endregion

        #region Window Interaction Controls
        /// <summary>Handle keydown events.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The eventargs.</param>
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            // If escape is pressed, normalize the window size
            if (e.Key == Key.Escape)
            {
                Topmost = false;
                WindowStyle = WindowStyle.ThreeDBorderWindow;
                WindowState = WindowState.Normal;
            }

                // If 'P' is pressed, switch back and forth between serial and parallel
            else if (e.Key == Key.P)
            {
                int procCount = Environment.ProcessorCount;
                m_parallelOptions.MaxDegreeOfParallelism = m_parallelOptions.MaxDegreeOfParallelism == 1 ? procCount : 1;
            }

                // If 'b' is pressed, break/pause the scene until 'b' is pressed again
            else if (e.Key == Key.B)
            {
                m_renderTimer.Enabled = !m_renderTimer.Enabled;
            }

                // If 't' is pressed, toggle translucency to enable following just one boid
            else if (e.Key == Key.T)
            {
                for (int i = 1; i < m_boidModels.Length; i++) m_boidModels[i].ToggleTranslucency();
            }

                // If 'a' is pressed, turn auto-panning/zoom of the camera on/off
            else if (e.Key == Key.A)
            {
                m_autoPanCamera = !m_autoPanCamera;
            }

                // If up or down is pressed and we're in auto-pan mode, 
            else if ((e.Key == Key.Up || e.Key == Key.Down) && !m_autoPanCamera)
            {
                Zoom(e.Key == Key.Up ? 1 : -1);
            }

                // If 'r' is pressed, reset all of the boids to random positions and velocities
            else if (e.Key == Key.R)
            {
                RandomizeBoidPositionsAndVelocities();
            }

                // If 'h', display usage instructions to the user
            else if (e.Key == Key.H)
            {
                string instructions =
                    "** Window Controls **" + Environment.NewLine +
                    "Auto-Camera Positioning: 'a'" + Environment.NewLine +
                    "Pan: Click Left And Drag" + Environment.NewLine +
                    "Zoom In / Out: Mousewheel (or) Up/Down Keys (or) Ctrl+Middle Mouse Move" + Environment.NewLine +
                    "Full Screen: Right Double-Click" + Environment.NewLine +
                    "Restore to Normal Window Size: Right Double-Click (or) Escape Key" + Environment.NewLine +
                    "Pause: 'b'" + Environment.NewLine +
                    "Translucency: 't'" + Environment.NewLine +
                    Environment.NewLine +
                    "** Boid Controls **" + Environment.NewLine +
                    "Scatter: Left Double-Click" + Environment.NewLine +
                    "Change Max Speed: Ctrl + Mousewheel" + Environment.NewLine +
                    "Randomize: 'r'" + Environment.NewLine +
                    Environment.NewLine +
                    "** Parallelism Controls **" + Environment.NewLine +
                    "Go Parallel: 'p'" + Environment.NewLine;
                MessageBox.Show(this, instructions, "Instructions", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        /// <summary>Handle mousedown events.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The eventargs.</param>
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Log the last mouse position
            _lastMousePosition = e.GetPosition(this);
        }

        /// <summary>Handle mousewheel events.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The eventargs.</param>
        private void Window_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            // If ctrl is pressed, change the max bird speed based on the number of mousewheel turns
            if ((Keyboard.Modifiers & ModifierKeys.Control) != 0)
            {
                const int MIN_SPEED = 2, MAX_SPEED = 10;
                if (e.Delta > 0 && m_speedLimit < MAX_SPEED) m_speedLimit++;
                else if (e.Delta < 0 && m_speedLimit > MIN_SPEED) m_speedLimit--;
            }
                // Otherwise, as long as we're not in auto-panning/zooming mode,
                // zoom in or out based on the number of mousewheel turns
            else if (!m_autoPanCamera) Zoom(e.Delta / Mouse.MouseWheelDeltaForOneLine); 
        }

        /// <summary>Handle mousedoubleclick events.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The eventargs.</param>
        private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // If the right mouse button is double clicked, alternate between maximized and normal view
            if (e.ChangedButton == MouseButton.Right)
            {
                if (WindowState == WindowState.Maximized)
                {
                    Topmost = false;
                    WindowStyle = WindowStyle.ThreeDBorderWindow;
                    WindowState = WindowState.Normal;
                }
                else
                {
                    Topmost = true;
                    WindowStyle = WindowStyle.None;
                    WindowState = WindowState.Maximized;
                }
            }
                // If the left mouse button is double clicked, scatter the boids
            else if (e.ChangedButton == MouseButton.Left)
            {
                Scatter();
            }
        }

        /// <summary>Scatter the boids.</summary>
        private void Scatter()
        {
            // Start scatterring if a scatter isn't already in process
            if (m_scatterTimer == null)
            {
                // Ka'boom.  Something scares the boids.
                SystemSounds.Hand.Play();

                // Store original settings
                var origHome = m_home;
                var origRule1Weight = m_rule1Weight;
                var origRule2Weight = m_rule2Weight;
                var origRule4Weight = m_rule4Weight;
                var origRule5Weight = m_rule5Weight;

                // Create new scatter settings
                m_home = new Vector3D(0, 0, 0);
                m_rule1Weight = origRule1Weight * -5;
                m_rule2Weight = origRule2Weight * 2;
                m_rule4Weight = 0;
                m_rule5Weight = origRule5Weight * -5;

                // Start a timer to restore the original settings
                m_scatterTimer = new Timer(_ =>
                {
                    // Restore the original settings
                    m_home = origHome;
                    m_rule1Weight = origRule1Weight;
                    m_rule2Weight = origRule2Weight;
                    m_rule4Weight = origRule4Weight;
                    m_rule5Weight = origRule5Weight;

                    // Clean up the timer
                    m_scatterTimer.Dispose();
                    m_scatterTimer = null;
                }, null, SCATTER_TIME, -1);
            }
        }

        /// <summary>Handle mousemove events.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The eventargs.</param>
        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            // If we're not auto-panning
            if (!m_autoPanCamera)
            {
                // Get the new mouse position and compute the difference from the previous
                var newPosition = e.GetPosition(this);
                var diff = _lastMousePosition - newPosition;

                // If the left mouse position was pressed, pan based on the x/y differences
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    camMain.Position = new Point3D(camMain.Position.X + diff.X * .4, camMain.Position.Y - diff.Y * .4, camMain.Position.Z);
                }
                    // If the middle button was pressed, zoom based on the y difference
                else if (e.MiddleButton == MouseButtonState.Pressed)
                {
                    Zoom((int)diff.Y);
                }

                // Store the new position
                _lastMousePosition = newPosition;
            }
        }

        /// <summary>Zoom in or out based on the specified degree of zoom.</summary>
        /// <param name="amountOfChange">Amount to zoom in (positive) or out (negative).</param>
        private void Zoom(int amountOfChange)
        {
            const int ZOOM_FACTOR = 3;
            camMain.Position = Point3D.Add(camMain.Position, camMain.LookDirection * amountOfChange * ZOOM_FACTOR);
        }
        #endregion

        #region Step and Render
        /// <summary>Runs the rendering loop.</summary>
        private void RenderUpdateLoop()
        {
            // Loop forever...
            while (true)
            {
                // Wait to receive a signal that we should render another frame
                m_renderSignal.WaitOne();

                // Start timing.
                m_frameStopwatch.Restart();

                // Update the positions and velocities of all of the boids.
                StepBoids();

                // Update our rendering stats for display to the user
                m_totalRenderingMillisecondsSinceLastUserPresentation += m_frameStopwatch.ElapsedMilliseconds;
                m_numRendersSinceLastUserPresentation++;

                // Render the boids to the UI
                Dispatcher.Invoke((Action)RenderBoids, DispatcherPriority.Send, null);
            }
        }

        /// <summary>Step the boids one step, updating their velocities and positions.</summary>
        private void StepBoids()
        {
            // Store the current velocities and positions so that we can operate on an immutable copy
            foreach (var boid in m_boidModels) boid.StorePositionAndVelocityIntoPrevious();

            // For each boid, analyze how the various boid rules influence its velocity and position,
            // then store this new information.  After this step, we'll be able to render the boids.
            Parallel.ForEach(m_boidModels, m_parallelOptions, boid =>
            {
                var v1_2_3 = PrimaryRules_1_2_3(boid); // weights factored in already in PrimaryRules
                var v4 = m_rule4Weight * Rule4_EncourageStayingWithinAviary(boid);
                var v5 = m_rule5Weight * Rule5_TendendcyTowardsHome(boid);

                boid.Velocity = BoundVelocity(boid.PreviousVelocity + v1_2_3 + v4 + v5, m_speedLimit);
                boid.Velocity.Normalize();

                var tmpPosition = boid.PreviousPosition + boid.Velocity;
                if (tmpPosition.Y >= 0) boid.Position = tmpPosition;
            });
        }

        /// <summary>Render the boids.</summary>
        private void RenderBoids()
        {
            // Make sure the boids are all positioned and pointing correctly
            foreach (var boid in m_boidModels) boid.TransformByPositionAndVelocity();

            // Every once in a while, update the user-displayed stats on timings
            var now = DateTimeOffset.Now;
            if (now >= m_nextUserPresentation)
            {
                Title = string.Format("Procs: {0}, Time: {1:F2}", m_parallelOptions.MaxDegreeOfParallelism, 
                    m_numRendersSinceLastUserPresentation > 0 ? 
                    m_totalRenderingMillisecondsSinceLastUserPresentation / (double)m_numRendersSinceLastUserPresentation : 
                    0);
                m_nextUserPresentation = now.AddSeconds(1);
                m_numRendersSinceLastUserPresentation = 0;
                m_totalRenderingMillisecondsSinceLastUserPresentation = 0;
            }

            // If we're in auto-panning mode, move the camera appropriately
            if (m_autoPanCamera)
            {
                // Compute the maximum Z value of all of the boids and the center of their mass
                double maxZ = double.MinValue;
                Vector3D totalPos = new Vector3D();
                foreach (var boid in m_boidModels)
                {
                    if (boid.Position.Z > maxZ) maxZ = boid.Position.Z;
                    totalPos += boid.Position;
                }
                var newCameraPos = totalPos / m_boidModels.Length;
                
                // Move the camera to point at the center of the boids, a ways back from the max boid's Z
                const int CAMERA_DISTANCE_FROM_MAXZ = 100;
                const double CAMERA_SPEED_LIMIT = .01;
                var newPos = new Point3D(newCameraPos.X, newCameraPos.Y, maxZ + CAMERA_DISTANCE_FROM_MAXZ);
                var cameraVelocity = newPos - camMain.Position;
                camMain.Position = camMain.Position + (cameraVelocity * CAMERA_SPEED_LIMIT);
            }
        }
        #endregion

        #region Boid Rules
        /// <summary>Run the three primary rules of boidom.</summary>
        /// <param name="boid">The boid to process.</param>
        /// <returns>The velocity vector resulting from the three primary rules and their associated weights.</returns>
        private Vector3D PrimaryRules_1_2_3(Boid boid)
        {
            int numNearby = 0;
            Vector3D summedPosition = new Vector3D();
            Vector3D summedVelocity = new Vector3D();
            Vector3D summedSeparation = new Vector3D();

            // For rule #1, we want the boid to fly towards the center of all of those in its neighborhood.
            // We find all of those boids, average their positions, and create a velocity vector to move the
            // boid a bit of the way there.

            // For rule #2, we want the boid to move away from each other boid it's a bit too close to.
            // Find all of those boids in its immediate vicinity, and push it away.

            // For rule #3, we want the boid to match velocities with those boids in its neighborhood.
            // Sum their velocities, find the average, and move this boid's velocity a bit in that direction.

            foreach (var other in m_boidModels)
            {
                if (other != boid && 
                    (other.PreviousPosition - boid.PreviousPosition).Length <= NEIGHBORHOOD_SIZE &&
                    boid.ComputeAngle(other) <= 135)
                {
                    summedPosition += other.PreviousPosition;
                    summedVelocity += other.PreviousVelocity;
                    numNearby++;

                    if ((other.PreviousPosition - boid.PreviousPosition).Length < MIN_DISTANCE_FROM_NEIGHBOR)
                    {
                        summedSeparation -= (other.PreviousPosition - boid.PreviousPosition);
                    }
                }
            }

            var rule1_flyTowardsCenter = (numNearby > 0 ? (summedPosition - boid.PreviousPosition) / numNearby : new Vector3D()) * PERCENTAGE_TO_MOVE_TOWARDS_AVERAGE_POSITION;
            var rule2_separateFromNearby = summedSeparation;
            var rule3_matchVelocities = (numNearby > 0 ? (summedVelocity - boid.PreviousVelocity) / numNearby : new Vector3D()) * PERCENTAGE_TO_MOVE_TOWARDS_AVERAGE_VELOCITY;

            return
                (m_rule1Weight * rule1_flyTowardsCenter) +
                (m_rule2Weight * rule2_separateFromNearby) +
                (m_rule3Weight * rule3_matchVelocities);
        }

        /// <summary>Encourage a boid to stay within its aviary.</summary>
        /// <param name="boid">The boid.</param>
        /// <returns>The velocity vector encouraging a boid to stay within its bounds.</returns>
        private Vector3D Rule4_EncourageStayingWithinAviary(Boid boid)
        {
            var v = new Vector3D();

            // X
            if (boid.PreviousPosition.X < m_aviary.X)
                v.X = m_aviary.X - boid.PreviousPosition.X;
            else if (boid.PreviousPosition.X > m_aviary.X + m_aviary.SizeX)
                v.X = (m_aviary.X + m_aviary.SizeX) - boid.PreviousPosition.X;

            // Y
            if (boid.PreviousPosition.Y < m_aviary.Y)
                v.Y = m_speedLimit;
            else if (boid.PreviousPosition.Y > m_aviary.Y + m_aviary.SizeY)
                v.Y = (m_aviary.Y + m_aviary.SizeY) - boid.PreviousPosition.Y;

            // Z
            if (boid.PreviousPosition.Z < m_aviary.Z)
                v.Z = m_aviary.Z - boid.PreviousPosition.Z;
            else if (boid.PreviousPosition.Z > m_aviary.Z + m_aviary.SizeZ)
                v.Z = (m_aviary.Z + m_aviary.SizeZ) - boid.PreviousPosition.Z;

            return v * PERCENTAGE_TO_MOVE_TOWARDS_INBOUNDS;
        }

        /// <summary>Encourage a boid to stay close to its home position.</summary>
        /// <param name="boid">The boid.</param>
        /// <returns>The velocity vector encouraging a boid to stay at home.</returns>
        private Vector3D Rule5_TendendcyTowardsHome(Boid boid)
        {
            return (m_home - boid.PreviousPosition) * PERCENTAGE_TO_MOVE_TOWARDS_HOME;
        }

        /// <summary>Bound a velocity to the max speed limit.</summary>
        /// <param name="velocity">The velocity to bound.</param>
        /// <returns>The bounded velocity.</returns>
        private static Vector3D BoundVelocity(Vector3D velocity, double speedLimit)
        {
            return (velocity.Length > speedLimit) ?
                (velocity / velocity.Length) * speedLimit : 
                velocity;
        }
        #endregion
    }
}