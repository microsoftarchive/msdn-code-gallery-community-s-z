//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: Graph.cs
//
//--------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace BabyNames
{
    public class Graph : Control
    {
        static Graph()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Graph), new FrameworkPropertyMetadata(typeof(Graph)));
        }

        private List<BabyInfo> _babyResults;
        private int _minYear = -1, _maxYear = -1, _maxValue = -1;

        internal void Configure(List<BabyInfo> babyResults)
        {
            _babyResults = babyResults;
            if (_babyResults != null && _babyResults.Count > 0)
            {
                _maxValue = _babyResults.Max(b => b.Count);
                _minYear = _babyResults.Min(b => b.Year);
                _maxYear = _babyResults.Max(b => b.Year);
            }
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            ToolTip = new ToolTip { Content = "Results" };
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (_minYear >= 0 && _maxYear >= 0 && _maxValue >= 0)
            {
                Size s = RenderSize;
                Point p = e.GetPosition(this);
                int year = _minYear + (int)((p.X / s.Width) * (_maxYear - _minYear));

                ToolTip tt = (ToolTip)this.ToolTip;
                tt.Content = "Year: " + year;
                tt.Visibility = Visibility.Visible;
            }
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            // Draw the babies
            if (_babyResults != null && _babyResults.Count > 0)
            {
                int width = (int)RenderSize.Width, height = (int)RenderSize.Height;

                if (_minYear != _maxYear)
                {
                    // Note: X axis is years, Y axis is the counts per year.
                    // These are the dimensions everything will be scaled to.
                    float per_x = (float)width / (_maxYear - _minYear), per_y = (float)height / _maxValue;

                    // Draw axis lines:
                    Pen paxis = new Pen(new SolidColorBrush(Color.FromArgb(128, 128, 128, 128)), 1);
                    for (float i = (height / 10); i < height; i += (height / 10))
                    {
                        drawingContext.DrawLine(paxis, new Point(0, i), new Point(width, i));
                    }
                    int xvalues = (_maxYear - _minYear);
                    float xincrement = (float)width / xvalues;
                    for (float i = xincrement; i < width; i += xincrement)
                    {
                        drawingContext.DrawLine(paxis, new Point(i, 0), new Point(i, height));
                    }

                    // Draw data:
                    Pen p = new Pen(new SolidColorBrush(Colors.White), 4);
                    float curr_x = 0.0f, curr_y = 0.0f, last_x = -1, last_y = -1;
                    int last_year = -1;

                    foreach (BabyInfo b in _babyResults)
                    {
                        if (b.Year != last_year)
                        {
                            curr_x = (b.Year - _minYear) * per_x;
                            curr_y = height - (b.Count * per_y);
                            if (last_x != -1 && last_y != -1)
                            {
                                drawingContext.DrawLine(p, new Point(curr_x, height), new Point(curr_x, curr_y));
                            }
                            last_x = curr_x;
                            last_y = curr_y;
                            last_year = b.Year;
                        }
                    }
                }
            }
        }
    }
}
