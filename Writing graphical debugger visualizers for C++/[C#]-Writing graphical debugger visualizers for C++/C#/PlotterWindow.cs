//********************************************************* 
// Copyright (c) Microsoft. All rights reserved. 
// This code is licensed under the Microsoft Public License. 
// THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF 
// ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY 
// IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR 
// PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT. 
//********************************************************* 
namespace VectorVisualizer
{
    using System.Drawing;
    using System.Windows;
    using System.Windows.Forms.DataVisualization.Charting;
    using System.Windows.Input;

    /// <summary>
    /// Interaction logic for PlotterWindow.xaml
    /// </summary>
    public partial class PlotterWindow : Window
    {
        private static readonly Color TranslucentGray = Color.FromArgb(64, 64, 64, 64);

        public PlotterWindow()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler((o, e) =>
            {
                if (e.Key == Key.Escape)
                {
                    this.Close();
                }
            });
        }

        public bool? ShowModal(Series series)
        {
            this.Title = series.Name;
            CreateChart(series);
            return this.ShowDialog();
        }

        public void CreateChart(Series series)
        {
            ChartArea chartArea = new ChartArea();
            chartArea.BackColor = Color.AliceBlue;
            chartArea.BackGradientStyle = GradientStyle.TopBottom;
            chartArea.BackSecondaryColor = Color.White;
            chartArea.BorderColor = TranslucentGray;
            chartArea.BorderDashStyle = ChartDashStyle.Solid;

            chartArea.AxisX.MajorGrid.LineColor = TranslucentGray;
            chartArea.AxisY.MajorGrid.LineColor = TranslucentGray;
            chartArea.AxisX.MajorTickMark.LineColor = Color.Transparent;

            chartArea.AxisX.Minimum = 0;
            chartArea.AxisX.Maximum = series.Points.Count - 1;
   
            chartArea.AxisX.Title = "Index";
            chartArea.AxisY.Title = series.Name + "[Index]";
            chartArea.CursorX.IsUserEnabled = false;
            
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series.MarkerSize = 8;
            series.MarkerStyle = MarkerStyle.Circle;
            series.BorderColor = TranslucentGray;
            series.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;

            chart.ChartAreas.Add(chartArea);
            chart.Series.Add(series);
        }
    }
}
