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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace NBodySimulation
{
    /// <summary>Interaction logic for Window1.xaml</summary>
    public partial class MainWindow : Window
    {
        private double m_stepSize = 5000.0;

        Stopwatch m_stopwatch = new Stopwatch();
        DispatcherTimer m_timer = new DispatcherTimer();
        Dictionary<string, Action<double>> m_executeAlgorithm;

        public MainWindow()
        {
            InitializeComponent();

            SizeChanged += new SizeChangedEventHandler(WindowSizeChangedEvent);
            numParticlesSlider.ValueChanged += NumParticlesValueChanged;
            SetNumCoresSliderProperties();

            ResetSimulation(true, Convert.ToInt32(numParticlesSlider.Value));

            FillDelegateLists();
            algorithmList.ItemsSource = m_executeAlgorithm.Keys;

            m_timer.Interval = TimeSpan.FromMilliseconds(20);
            m_timer.Tick += new EventHandler(ComputeNextPosition);
        }

        private void SetNumCoresSliderProperties()
        {
            var numProcs = Environment.ProcessorCount;
            numCoresSlider.SelectionEnd = numProcs;
            numCoresSlider.Maximum = numProcs;
            numCoresSlider.Value = numProcs;
            numCoresLabel.Content = numProcs;
        }

        private void AlgorithmTypeSelection(object sender, SelectionChangedEventArgs e)
        {
            var selection = expanderSelection.SelectedIndex;
            if (selection != 0)
                throw new ArgumentOutOfRangeException("Expander selection has only one choice");
        }

        private void NumCoresValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Globals.gNumCoresUsed = (int)e.NewValue;
            numCoresLabel.Content = e.NewValue.ToString();
        }

        private void NumParticlesValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int newNumParticles = Convert.ToInt32(e.NewValue);
            ResetSimulation(true, newNumParticles);
            StartSimulation();
        }

        private void StepSizeValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            m_stepSize = e.NewValue;
            ResetSimulation(false, -1);
        }

        private void WindowSizeChangedEvent(object sender, SizeChangedEventArgs e)
        {
            var newCanvasHeight = (this.ActualHeight - windowTopBar.ActualHeight) / 2;
            var newCanvasWidth = (this.ActualWidth - windowSideBar.ActualWidth) / 2;
            ellipseCanvas.Height = newCanvasHeight;
            ellipseCanvas.Width = newCanvasWidth;
        }

        private void FillDelegateLists()
        {
            m_executeAlgorithm = new Dictionary<string, Action<double>>{
                {"Sequential", step => NBodyParallelized.UpdateParticlesParallelFor(step, false)},
                {"Parallel", step => NBodyParallelized.UpdateParticlesParallelFor(step, true)}};
        }

        void UpdateVelocity()
        {
            var algorithmListSelection = (string)algorithmList.SelectedItem;
            var expanderSelectionItem = expanderSelection.SelectedIndex;
            if (expanderSelectionItem == -1 || algorithmList.SelectedIndex == -1)
            {
                var defaultSelection = "Sequential";
                m_executeAlgorithm[defaultSelection](m_stepSize);
                algorithmName.Content = defaultSelection;
            }
            else
            {
                m_executeAlgorithm[algorithmListSelection](m_stepSize);
                algorithmName.Content = algorithmListSelection;
            }
        }

        void ComputeNextPosition(object sender, EventArgs evArg)
        {
            m_stopwatch.Restart();
            UpdateVelocity();

            int i = 0;
            foreach (var e in Globals.globalState)
            {
                var xDrag = e.px * Globals.particleSystemCentroid;
                var yDrag = e.py * Globals.particleSystemCentroid;
                var newXVel = Globals.globalState[i].vx;
                var newYVel = Globals.globalState[i].vy;
                var xVel = newXVel + xDrag;
                var yVel = newYVel + yDrag;

                Canvas.SetLeft(ellipseCanvas.Children[i], 100 * e.px);
                Canvas.SetTop(ellipseCanvas.Children[i], 100 * e.py);
                Globals.globalState[i].px = e.px + xVel * m_stepSize;

                Globals.globalState[i].py = e.py + yVel * m_stepSize;
                Globals.globalState[i].vx = xVel - xDrag;
                Globals.globalState[i].vy = yVel - yDrag;

                i++;
            }

            var fps = (1.0 / (m_stopwatch.Elapsed.TotalSeconds));
            displayTimeElapsed.Content = fps.ToString("F2");
        }

        private void StartSimulation()
        {
            InitParticles();
            startButton.IsEnabled = false;
            m_timer.Start();
            numParticlesLabel.Content = numParticlesSlider.Value;
            resetButton.IsEnabled = true;
        }

        private void ResetSimulation(bool changeNumber, int newNumParticles)
        {
            resetButton.IsEnabled = false;
            m_timer.Stop();
            ellipseCanvas.Children.Clear();
            if (changeNumber)
                Globals.changeNumberOfParticles(newNumParticles);
            else
                Globals.restart();
            startButton.IsEnabled = true;
        }

        private void StartButtonClick(object sender, RoutedEventArgs e)
        {
            StartSimulation();
        }

        private void ResetButtonClick(object sender, RoutedEventArgs e)
        {
            ResetSimulation(false, -1);
        }

        private Brush GetRadialBrush(Color edgeColor, Color focalColor)
        {
            return new RadialGradientBrush(focalColor, edgeColor) {
                GradientOrigin = new Point(0.5, 0.5),
                SpreadMethod = GradientSpreadMethod.Pad
            };
        }

        public void InitParticles()
        {
            var pList = Globals.globalState;
            int particleIndex = 0;
            foreach (var p in pList)
            {
                var edgeColor = Color.FromArgb(0x00, Globals.defaultFocalColor.R, Globals.defaultFocalColor.G, Globals.defaultFocalColor.B);
                var focalColor = Color.FromArgb(0x35, Globals.defaultFocalColor.R, Globals.defaultFocalColor.G, Globals.defaultFocalColor.B);

                // get radial brush
                var eBrush = GetRadialBrush(edgeColor, focalColor);

                var size = System.Math.Pow((p.mass / Globals.nominalMass), 0.3333) * Globals.drawParticleSizeScale;

                // create new ellipse!
                var curEllipse = new Ellipse() { Fill = eBrush, Height = size, Width = size };
                ellipseCanvas.Children.Add(curEllipse);
                Canvas.SetLeft(curEllipse, 100 * p.px);
                Canvas.SetTop(curEllipse, 100 * p.py);

                particleIndex++;
            }
        }
    }
}