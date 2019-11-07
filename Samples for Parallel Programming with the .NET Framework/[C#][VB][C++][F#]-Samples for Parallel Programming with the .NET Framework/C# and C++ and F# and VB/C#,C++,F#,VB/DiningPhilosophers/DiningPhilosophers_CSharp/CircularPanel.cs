//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: CircularPanel.xaml.cs
//
//--------------------------------------------------------------------------

using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DiningPhilosophers
{
    public class CircularPanel : Panel
    {
        protected override Size MeasureOverride(Size availableSize)
        {
            var maxChildSize = new Size();
            foreach (UIElement child in InternalChildren)
            {
                child.Measure(availableSize);
                if (maxChildSize.Width < child.DesiredSize.Width) maxChildSize.Width = child.DesiredSize.Width;
                if (maxChildSize.Height < child.DesiredSize.Height) maxChildSize.Height = child.DesiredSize.Height;
            }
            return maxChildSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            var children = InternalChildren.OfType<UIElement>().ToArray();
            if (children.Length > 0)
            {
                var midPanel = new Point(finalSize.Width / 2, finalSize.Height / 2);
                var maxChild = new Size(children.Max(u => u.DesiredSize.Width), children.Max(u => u.DesiredSize.Height));
                var radius = new Size((finalSize.Width - maxChild.Width) / 2, (finalSize.Height - maxChild.Height) / 2);
                double arcRadiansPerChild = Math.PI * 2 / children.Length;

                int curPos = 0;
                foreach (var child in children)
                {
                    var childAngleInRadians = curPos * arcRadiansPerChild;
                    var childPosition = new Point(
                        (Math.Sin(childAngleInRadians) * radius.Width) + (midPanel.X - (child.DesiredSize.Width / 2)),
                        (Math.Cos(childAngleInRadians) * radius.Height) + (midPanel.Y - (child.DesiredSize.Height / 2)));
                    child.Arrange(new Rect(childPosition, child.DesiredSize));
                    curPos++;
                }
            }
            return finalSize;
        }
    }
}