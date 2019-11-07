using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows;

namespace Tasks.Show.Controls
{
    public class CalloutShape : Shape
    {
        #region Fields

        Rect _rect;

        #endregion Fields

        #region Properties

        protected override Geometry DefiningGeometry
        {
            get
            {
                // calculate the geometry for the rectangle

                double top = Math.Max(0, _rect.Top);
                double left = Math.Max(0, _rect.Left);
                double width = Math.Max(0, _rect.Width);
                double height = Math.Max(0, _rect.Height);

                switch (ArrowPlacement)
                {
                    case ArrowPlacement.Top: top += ArrowHeight; height -= ArrowHeight; break;
                    case ArrowPlacement.Bottom: height -= ArrowHeight; break;
                }

                height = Math.Max(height, 0);
                width = Math.Max(width, 0);

                RectangleGeometry rectangle = new RectangleGeometry(new Rect(left, top, width, height), CornerRadius, CornerRadius);

                // if the width or height of the arrow is 0 then we can return the
                // rectangle we just created

                if (ArrowWidth == 0 || ArrowHeight == 0 || ArrowPlacement == ArrowPlacement.None) return rectangle;

                // otherwise, we calculate the geometry for the arrow

                Point p1, p2, p3;
                double s = GetStrokeThickness();

                switch (ArrowPlacement)
                {
                    case ArrowPlacement.Top:
                        if (this.ArrowAlignment == ArrowAlignment.Left)
                        {
                            p1 = new Point(s / 2, ArrowHeight + s / 2);
                            p2 = new Point(s / 2, 0);
                            p3 = new Point(ArrowWidth, ArrowHeight + s);
                        }
                        else if (this.ArrowAlignment == ArrowAlignment.Right)
                        {
                            p1 = new Point(width - (ArrowWidth + s / 2), ArrowHeight + s);
                            p2 = new Point(width + s / 2, 0);
                            p3 = new Point(width + s / 2, ArrowHeight + s);
                        }
                        else
                        {
                            p1 = new Point();
                            p2 = new Point();
                            p3 = new Point();
                        }
                        break;

                    case ArrowPlacement.Bottom:
                        if (this.ArrowAlignment == ArrowAlignment.Left)
                        {
                            p1 = new Point(s / 2, height - s);
                            p2 = new Point(s / 2, height + ArrowHeight);
                            p3 = new Point(ArrowWidth, height - s / 2);
                        }
                        else if (this.ArrowAlignment == ArrowAlignment.Right)
                        {
                            p1 = new Point(width - (ArrowWidth + StrokeThickness / 2), height - s);
                            p2 = new Point(width + s / 2, height + ArrowHeight);
                            p3 = new Point(width + s / 2, height - s);
                        }
                        else
                        {
                            p1 = new Point((width / 2) + (ArrowWidth / 2), height - s);
                            p2 = new Point(width / 2, height + ArrowHeight);
                            p3 = new Point((width / 2) - (ArrowWidth / 2), height - s / 2);
                        }
                        break;

                    default:
                        p1 = new Point();
                        p2 = new Point();
                        p3 = new Point();
                        break;
                }

                Geometry finalRectangle = rectangle;

                if (this.ArrowAlignment != ArrowAlignment.Center && this.CornerRadius > 0)
                {
                    // combine our rectangle with one that doesn't have a rounded corners to remvoe the
                    // rounded corner in the corner with the arrow
                    double cornerTop = this.ArrowPlacement == ArrowPlacement.Top ? this.ArrowHeight : height - this.CornerRadius;
                    double cornerLeft = this.ArrowAlignment == ArrowAlignment.Left ? this.StrokeThickness / 2 : width - this.CornerRadius;

                    RectangleGeometry cornerRectangle = new RectangleGeometry(new Rect(cornerLeft, cornerTop, this.CornerRadius * 2, this.CornerRadius * 2));
                    finalRectangle = new CombinedGeometry(GeometryCombineMode.Union, finalRectangle, cornerRectangle);
                }


                // now create the arrow geometry with the points we've already calculated

                PathFigure p = new PathFigure();
                p.StartPoint = p1;

                p.Segments = new PathSegmentCollection();
                p.Segments.Add(new LineSegment(p1, false));
                p.Segments.Add(new LineSegment(p2, true));
                p.Segments.Add(new LineSegment(p3, true));
                p.Segments.Add(new LineSegment(p1, false));

                PathGeometry arrow = new PathGeometry();
                arrow.Figures.Add(p);

                // combine the geometries and return

                return new CombinedGeometry(GeometryCombineMode.Union, arrow, finalRectangle);
            }
        }

        #endregion Properties

        #region Protected Methods

        protected override Size ArrangeOverride(Size finalSize)
        {
            double penThickness = GetStrokeThickness();
            double margin = penThickness / 2;

            _rect = new Rect(margin, margin,
                 Math.Max(0, finalSize.Width - penThickness),
                 Math.Max(0, finalSize.Height - penThickness));

            return base.ArrangeOverride(finalSize);
        }

        protected override Size MeasureOverride(Size constraint)
        {
            return GetNaturalSize();
        }

        #endregion Protected Methods

        #region Private Methods

        private Size GetNaturalSize()
        {
            double strokeThickness = GetStrokeThickness();
            return new Size(strokeThickness, strokeThickness);
        }

        private double GetStrokeThickness()
        {
            double strokeThickness = StrokeThickness;
            bool isPenNoOp = true;
            if ((Stroke != null) && !double.IsNaN(strokeThickness))
            {
                isPenNoOp = (strokeThickness == 0);
            }
            return isPenNoOp ? 0.0d : Math.Abs(strokeThickness);
        }

        #endregion Private Methods

        #region ArrowWidth

        /// <summary>
        /// ArrowWidth Dependency Property
        /// </summary>
        public static readonly DependencyProperty ArrowWidthProperty =
            DependencyProperty.Register("ArrowWidth", typeof(double), typeof(CalloutShape),
                new FrameworkPropertyMetadata((double)18.0,
                    FrameworkPropertyMetadataOptions.AffectsRender));

        /// <summary>
        /// Gets or sets the ArrowWidth property.  This dependency property 
        /// indicates the width of the arrow on the callout.
        /// </summary>
        public double ArrowWidth
        {
            get { return (double)GetValue(ArrowWidthProperty); }
            set { SetValue(ArrowWidthProperty, value); }
        }

        #endregion

        #region ArrowHeight

        /// <summary>
        /// ArrowHeight Dependency Property
        /// </summary>
        public static readonly DependencyProperty ArrowHeightProperty =
            DependencyProperty.Register("ArrowHeight", typeof(double), typeof(CalloutShape),
                new FrameworkPropertyMetadata((double)12.0,
                    FrameworkPropertyMetadataOptions.AffectsRender));

        /// <summary>
        /// Gets or sets the ArrowHeight property.  This dependency property 
        /// indicates the Height of the arrow on the callout.
        /// </summary>
        public double ArrowHeight
        {
            get { return (double)GetValue(ArrowHeightProperty); }
            set { SetValue(ArrowHeightProperty, value); }
        }

        #endregion

        #region ArrowPlacement

        /// <summary>
        /// ArrowPlacement Dependency Property
        /// </summary>
        public static readonly DependencyProperty ArrowPlacementProperty =
            DependencyProperty.Register("ArrowPlacement", typeof(ArrowPlacement), typeof(CalloutShape),
                new FrameworkPropertyMetadata((ArrowPlacement)ArrowPlacement.Top,
                    FrameworkPropertyMetadataOptions.AffectsRender));

        /// <summary>
        /// Gets or sets the ArrowPlacement property.  This dependency property specifies which 
        /// edge the arrow is placed on (Top, Bottom, Left, Right).
        /// </summary>
        public ArrowPlacement ArrowPlacement
        {
            get { return (ArrowPlacement)GetValue(ArrowPlacementProperty); }
            set { SetValue(ArrowPlacementProperty, value); }
        }

        #endregion

        #region ArrowAlignment

        /// <summary>
        /// ArrowAlignment Dependency Property
        /// </summary>
        public static readonly DependencyProperty ArrowAlignmentProperty =
            DependencyProperty.Register("ArrowAlignment", typeof(ArrowAlignment), typeof(CalloutShape),
                new FrameworkPropertyMetadata((ArrowAlignment)ArrowAlignment.Left,
                    FrameworkPropertyMetadataOptions.AffectsRender));

        /// <summary>
        /// Gets or sets the ArrowAlignment property.  This dependency property 
        /// indicates the offset of the arrow relative to its placement.
        /// 
        /// If the arrow is placed along the top or bottom edge (ArrowPlacement = Top/Bottom), then 
        /// ArrowAlignment specifies whether the arrow is located on the left or right side of the
        /// edge.
        /// 
        /// If the arrow is placed along the left or right edge (ArrowPlacement = Left/Right), then
        /// ArrowAlignment specifies whether the arrow is located on the top or bottom side of the
        /// edge.
        /// </summary>
        public ArrowAlignment ArrowAlignment
        {
            get { return (ArrowAlignment)GetValue(ArrowAlignmentProperty); }
            set { SetValue(ArrowAlignmentProperty, value); }
        }

        #endregion

        #region CornerRadius

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(double), typeof(CalloutShape),
                new FrameworkPropertyMetadata((double)0.0));

        public double CornerRadius
        {
            get { return (double)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        #endregion


    }

    public enum ArrowPlacement
    {
        Top,
        Bottom,
        None
    }

    public enum ArrowAlignment
    {
        Left,
        Right,
        Center
    }

}
