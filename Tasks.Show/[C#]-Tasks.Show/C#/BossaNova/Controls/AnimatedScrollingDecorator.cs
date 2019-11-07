using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Diagnostics;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Windows.Input;

namespace Tasks.Show.Controls
{
    public class AnimatedScrollDecorator : Decorator
    {
		#region Fields 

        private double _DragThreshold = 5.0;
        double _hDownOffset = 0;
        bool _isAnimationValid = true;
        bool _isDragging = false;
        private bool _IsDraggingEnabled = true;
        bool _isInitialLayout = true;
        private Rect _lastChildArrange;
        Point? _lastDown = null;
        double _vDownOffset = 0;
        DispatcherTimer firstLayoutTimer;
        DoubleAnimationUsingKeyFrames PrevAnim = null;

		#endregion Fields 

		#region Properties 

        public bool CanDragHorizontally
        {
            get { return (this.DragDirection == DragDirection.HorizontalOnly || this.DragDirection == DragDirection.Both); }
        }

        public bool CanDragVertically
        {
            get { return (this.DragDirection == DragDirection.VerticalOnly || this.DragDirection == DragDirection.Both); }
        }

        public double DragThreshold
        {
            get { return _DragThreshold; }
            set { _DragThreshold = value; }
        }

        private bool IsAnimationEnabled
        {
            get
            {
                if (this.AnimationBehavior == AnimationBehavior.Never) return false;
                if (this.AnimationBehavior == AnimationBehavior.Always) return true;
                return _isDragging;
            }
        }

        public bool IsDraggingEnabled
        {
            get { return _IsDraggingEnabled; }
            set 
            {
                if (!value)
                {
                    _lastDown = null;

                    if (_isDragging)
                    {
                        _isDragging = false;
                        this.ReleaseMouseCapture();
                    }
                }

                _IsDraggingEnabled = value; 
            }
        }

		#endregion Properties 

		#region Event Handlers 

        void hPrevAnim_Completed(object sender, EventArgs e)
        {
            EndAnimation();
        }

		#endregion Event Handlers 

		#region Protected Methods 

        protected override Size ArrangeOverride(Size finalSize)
        {
            if (this.Child == null) return new Size();

            if (_isInitialLayout && firstLayoutTimer == null)
            {
                firstLayoutTimer = new DispatcherTimer();
                firstLayoutTimer.Interval = TimeSpan.FromMilliseconds(500);

                EventHandler handler = null;
                handler = delegate(object s, EventArgs e)
                {
                    firstLayoutTimer.Tick -= handler;
                    firstLayoutTimer.Stop();
                    _isInitialLayout = false;
                };

                firstLayoutTimer.Tick += handler;
                firstLayoutTimer.Start();
            }

            double left = 0;
            double top = 0;
            double width = finalSize.Width;
            double height = finalSize.Height;
            bool requiresScrolling = false;

            if (this.CanDragHorizontally && Child.DesiredSize.Width > finalSize.Width)
            {
                // use the relative offset property to determine the placement of the content
                double delta = Child.DesiredSize.Width - finalSize.Width;
                double offset = (this.IsReversed ? this.RelativeHorizontalOffset : (1 - this.RelativeHorizontalOffset)) * (delta * -1);
                left = offset;

                left = Math.Round(left);
                width = Child.DesiredSize.Width;

                requiresScrolling = true;
            }

            if (this.CanDragVertically && Child.DesiredSize.Height > finalSize.Height)
            {
                // use the relative offset property to determine the placement of the content
                double delta = Child.DesiredSize.Height - finalSize.Height;
                double offset = (this.IsReversed ? this.RelativeVerticalOffset : (1 - this.RelativeVerticalOffset)) * (delta * -1);
                top = offset;

                top = Math.Round(top);
                height = Child.DesiredSize.Height;

                requiresScrolling = true;
            }

            SetRequiresScrolling(requiresScrolling);
            SetActualContentHeight(Child.DesiredSize.Height);
            SetActualContentWidth(Child.DesiredSize.Width);

            if ((left == _lastChildArrange.Left && top == _lastChildArrange.Top) || (!this.IsAnimationEnabled) || (_isInitialLayout))
            {
                this.EndAnimation();

                this.ArrangeChildLeft = left;
                this.ArrangeChildTop = top;
                this.Child.Arrange(new Rect(left, top, width, height));
            }
            else
            {
                // Leaving left as 0 to emphasize that the value for left will be provided when we
                // animate the ArrangeChildLeft property.

                _lastChildArrange = new Rect(left, top, width, height);
                StartAnimation(left, top);
            }

            return finalSize;
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            UIElement child = this.Child;
            if (child != null)
            {
                double w = this.CanDragHorizontally ? double.PositiveInfinity : availableSize.Width;
                double h = this.CanDragVertically ? double.PositiveInfinity : availableSize.Height;

                child.Measure(new Size(w, h));

                return availableSize;
            }
            return new Size();
        }

        protected override void OnMouseWheel(System.Windows.Input.MouseWheelEventArgs e)
        {
            if (this.DesiredSize.Height < this.ActualHeight) return;

            double relPixel = (this.Child.DesiredSize.Height / (this.ActualHeight - this.Child.DesiredSize.Height)) / -60;
            relPixel = e.Delta >= 0 ? relPixel : relPixel * -1;
            this.RelativeVerticalOffset += relPixel;
        }

        protected override void OnPreviewMouseDown(System.Windows.Input.MouseButtonEventArgs e)
        {
            if (IsDraggingEnabled && ((CanDragHorizontally && this.ActualWidth < this.Child.DesiredSize.Width) || (CanDragVertically && this.ActualHeight < this.Child.DesiredSize.Height)))
            {
                _lastDown = e.GetPosition(this);
                _hDownOffset = this.RelativeHorizontalOffset;
                _vDownOffset = this.RelativeVerticalOffset;
            }
            else
            {
                _lastDown = null;
                base.OnPreviewMouseDown(e);
            }
        }

        protected override void OnPreviewMouseMove(System.Windows.Input.MouseEventArgs e)
        {
            if (IsDraggingEnabled && ((CanDragHorizontally && this.ActualWidth < this.Child.DesiredSize.Width) || (CanDragVertically && this.ActualHeight < this.Child.DesiredSize.Height)))
            {
                if (_lastDown != null)
                {
                    Point m = _lastDown.Value;
                    Point p = e.GetPosition(this);

                    if (_isDragging || Math.Abs(m.X - p.X) >= DragThreshold || Math.Abs(m.Y - p.Y) >= DragThreshold)
                    {
                        _isDragging = true;
                        this.CaptureMouse();

                        double hRelOffset = (m.X - p.X) / ((this.Child.DesiredSize.Width - this.ActualWidth) * this.DragScaler);
                        this.RelativeHorizontalOffset = _hDownOffset - hRelOffset;

                        double vRelOffset = (m.Y - p.Y) / ((this.Child.DesiredSize.Height - this.ActualHeight) * this.DragScaler);
                        this.RelativeVerticalOffset = _vDownOffset - vRelOffset;

                        if (this.EatMouseEventsOnDrag) e.Handled = true;
                    }
                }
            }
            else
            {
                base.OnPreviewMouseMove(e);
            }
        }

        protected override void OnPreviewMouseUp(System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!IsDraggingEnabled)
            {
                base.OnMouseUp(e);
                return;
            }

            _lastDown = null;

            if (_isDragging)
            {
                _isDragging = false;
                if (this.EatMouseEventsOnDrag) e.Handled = true;
                this.ReleaseMouseCapture();
            }
            else
            {
                base.OnPreviewMouseUp(e);
            }
        }

		#endregion Protected Methods 

		#region Private Methods 

        private void EndAnimation()
        {
            _isAnimationValid = false;
            if (PrevAnim != null)
            {
                RaiseAnimationCompleted();
                PrevAnim.Completed -= new EventHandler(hPrevAnim_Completed);
                PrevAnim = null;
            }
        }

        private void StartAnimation(double left, double top)
        {
            DoubleAnimationUsingKeyFrames hOffsetAnimation = new DoubleAnimationUsingKeyFrames();
            DoubleAnimationUsingKeyFrames vOffsetAnimation = new DoubleAnimationUsingKeyFrames();

            // track animation started stopped (using horizontal only, which is fine because horizontal and vertical always run together)
            if (PrevAnim == null)
            {
                RaiseAnimationStarted();
            }
            else
            {
                PrevAnim.Completed -= new EventHandler(hPrevAnim_Completed);
            }

            PrevAnim = hOffsetAnimation;
            PrevAnim.Completed += new EventHandler(hPrevAnim_Completed);

            // create the horizontal animation
            hOffsetAnimation.KeyFrames.Clear();
            SplineDoubleKeyFrame hK = new SplineDoubleKeyFrame(left, KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(this.Duration)));
            hK.KeySpline = this.Easing;
            hOffsetAnimation.KeyFrames.Add(hK);

            // create the vertical animation
            vOffsetAnimation.KeyFrames.Clear();
            SplineDoubleKeyFrame vK = new SplineDoubleKeyFrame(top, KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(this.Duration)));
            vK.KeySpline = this.Easing;
            vOffsetAnimation.KeyFrames.Add(vK);

            // start the animations
            _isAnimationValid = true;
            this.BeginAnimation(ArrangeChildLeftProperty, hOffsetAnimation);
            this.BeginAnimation(ArrangeChildTopProperty, vOffsetAnimation);
        }

		#endregion Private Methods 

        #region EatMouseEventsOnDrag

        /// <summary>
        /// EatMouseEventsOnDrag Dependency Property
        /// </summary>
        public static readonly DependencyProperty EatMouseEventsOnDragProperty =
            DependencyProperty.Register("EatMouseEventsOnDrag", typeof(bool), typeof(AnimatedScrollDecorator),
                new FrameworkPropertyMetadata((bool)true));

        /// <summary>
        /// Gets or sets the EatMouseEventsOnDrag property.  This dependency property 
        /// indicates ....
        /// </summary>
        public bool EatMouseEventsOnDrag
        {
            get { return (bool)GetValue(EatMouseEventsOnDragProperty); }
            set { SetValue(EatMouseEventsOnDragProperty, value); }
        }

        #endregion

        #region Duration

        /// <summary>
        /// Duration Dependency Property
        /// </summary>
        public static readonly DependencyProperty DurationProperty =
            DependencyProperty.Register("Duration", typeof(double), typeof(AnimatedScrollDecorator),
                new FrameworkPropertyMetadata((double)1000));

        /// <summary>
        /// Gets or sets the Duration property.  This dependency property 
        /// indicates ....
        /// </summary>
        public double Duration
        {
            get { return (double)GetValue(DurationProperty); }
            set { SetValue(DurationProperty, value); }
        }

        #endregion

        #region Easing

        /// <summary>
        /// Easing Dependency Property
        /// </summary>
        public static readonly DependencyProperty EasingProperty =
            DependencyProperty.Register("Easing", typeof(KeySpline), typeof(AnimatedScrollDecorator),
                new FrameworkPropertyMetadata((KeySpline)new KeySpline(0, 0.25, 0, 1)));

        /// <summary>
        /// Gets or sets the Easing property.  This dependency property 
        /// indicates ....
        /// </summary>
        public KeySpline Easing
        {
            get { return (KeySpline)GetValue(EasingProperty); }
            set { SetValue(EasingProperty, value); }
        }

        #endregion

        #region ArrangeChildLeft (Private DependencyProperty / Treat as Write-only)

        /// <summary>
        /// ArrangeChildLeft Dependency Property
        /// </summary>
        private static readonly DependencyProperty ArrangeChildLeftProperty =
            DependencyProperty.Register("ArrangeChildLeft", typeof(double), typeof(AnimatedScrollDecorator),
                new FrameworkPropertyMetadata((double)0.0,
                    new PropertyChangedCallback(OnArrangeChildLeftChanged)));

        /// <summary>
        /// Gets or sets the ArrangeChildLeft property.  This dependency property 
        /// indicates ....
        /// </summary>
        private double ArrangeChildLeft
        {
            get { return (double)GetValue(ArrangeChildLeftProperty); }
            set { SetValue(ArrangeChildLeftProperty, value); }
        }

        /// <summary>
        /// Handles changes to the ArrangeChildLeft property.
        /// </summary>
        private static void OnArrangeChildLeftChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((AnimatedScrollDecorator)d).OnArrangeChildLeftChanged(e);
        }

        /// <summary>
        /// Provides derived classes an opportunity to handle changes to the ArrangeChildLeft property.
        /// </summary>
        private void OnArrangeChildLeftChanged(DependencyPropertyChangedEventArgs e)
        {
            if (_isAnimationValid)
            {
                _lastChildArrange.X = (double)e.NewValue;
                this.Child.Arrange(_lastChildArrange);
            }
        }

        #endregion

        #region ArrangeChildTop (Private DependencyProperty / Treat as Write-only)

        /// <summary>
        /// ArrangeChildTop Dependency Property
        /// </summary>
        private static readonly DependencyProperty ArrangeChildTopProperty =
            DependencyProperty.Register("ArrangeChildTop", typeof(double), typeof(AnimatedScrollDecorator),
                new FrameworkPropertyMetadata((double)0.0,
                    new PropertyChangedCallback(OnArrangeChildTopChanged)));

        /// <summary>
        /// Gets or sets the ArrangeChildTop property.  This dependency property 
        /// indicates ....
        /// </summary>
        private double ArrangeChildTop
        {
            get { return (double)GetValue(ArrangeChildTopProperty); }
            set { SetValue(ArrangeChildTopProperty, value); }
        }

        /// <summary>
        /// Handles changes to the ArrangeChildTop property.
        /// </summary>
        private static void OnArrangeChildTopChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((AnimatedScrollDecorator)d).OnArrangeChildTopChanged(e);
        }

        /// <summary>
        /// Provides derived classes an opportunity to handle changes to the ArrangeChildTop property.
        /// </summary>
        private void OnArrangeChildTopChanged(DependencyPropertyChangedEventArgs e)
        {
            if (_isAnimationValid)
            {
                _lastChildArrange.Y = (double)e.NewValue;
                this.Child.Arrange(_lastChildArrange);
            }
        }

        #endregion

        #region RelativeHorizontalOffset

        /// <summary>
        /// RelativeHorizontalOffset Dependency Property
        /// </summary>
        public static readonly DependencyProperty RelativeHorizontalOffsetProperty =
            DependencyProperty.Register("RelativeHorizontalOffset", typeof(double), typeof(AnimatedScrollDecorator),
                new FrameworkPropertyMetadata((double)0.5,
                    FrameworkPropertyMetadataOptions.AffectsArrange,
                    new PropertyChangedCallback(OnRelativeHorizontalOffsetChanged),
                    new CoerceValueCallback(CoerceRelativeHorizontalOffsetValue)));

        /// <summary>
        /// Gets or sets the RelativeHorizontalOffset property.  This dependency property 
        /// indicates ....
        /// </summary>
        public double RelativeHorizontalOffset
        {
            get { return (double)GetValue(RelativeHorizontalOffsetProperty); }
            set { SetValue(RelativeHorizontalOffsetProperty, value); }
        }

        /// <summary>
        /// Handles changes to the RelativeHorizontalOffset property.
        /// </summary>
        private static void OnRelativeHorizontalOffsetChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((AnimatedScrollDecorator)d).OnRelativeHorizontalOffsetChanged(e);
        }

        /// <summary>
        /// Provides derived classes an opportunity to handle changes to the RelativeHorizontalOffset property.
        /// </summary>
        protected virtual void OnRelativeHorizontalOffsetChanged(DependencyPropertyChangedEventArgs e)
        {

        }

        /// <summary>
        /// Coerces the RelativeHorizontalOffset value.
        /// </summary>
        private static object CoerceRelativeHorizontalOffsetValue(DependencyObject d, object value)
        {
            return Math.Min(1.0, Math.Max(0.0, (double)value));
        }

        #endregion

        #region RelativeVerticalOffset

        /// <summary>
        /// RelativeVerticalOffset Dependency Property
        /// </summary>
        public static readonly DependencyProperty RelativeVerticalOffsetProperty =
            DependencyProperty.Register("RelativeVerticalOffset", typeof(double), typeof(AnimatedScrollDecorator),
                new FrameworkPropertyMetadata((double)1.0,
                    FrameworkPropertyMetadataOptions.AffectsArrange,
                    new PropertyChangedCallback(OnRelativeVerticalOffsetChanged),
                    new CoerceValueCallback(CoerceRelativeVerticalOffsetValue)));

        /// <summary>
        /// Gets or sets the RelativeVerticalOffset property.  This dependency property 
        /// indicates ....
        /// </summary>
        public double RelativeVerticalOffset
        {
            get { return (double)GetValue(RelativeVerticalOffsetProperty); }
            set { SetValue(RelativeVerticalOffsetProperty, value); }
        }

        /// <summary>
        /// Handles changes to the RelativeVerticalOffset property.
        /// </summary>
        private static void OnRelativeVerticalOffsetChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((AnimatedScrollDecorator)d).OnRelativeVerticalOffsetChanged(e);
        }

        /// <summary>
        /// Provides derived classes an opportunity to handle changes to the RelativeVerticalOffset property.
        /// </summary>
        protected virtual void OnRelativeVerticalOffsetChanged(DependencyPropertyChangedEventArgs e)
        {

        }

        /// <summary>
        /// Coerces the RelativeVerticalOffset value.
        /// </summary>
        private static object CoerceRelativeVerticalOffsetValue(DependencyObject d, object value)
        {
            return Math.Min(1.0, Math.Max(0.0, (double)value));
        }

        #endregion

        #region IsReversed

        /// <summary>
        /// IsReversed Dependency Property
        /// </summary>
        public static readonly DependencyProperty IsReversedProperty =
            DependencyProperty.Register("IsReversed", typeof(bool), typeof(AnimatedScrollDecorator),
                new FrameworkPropertyMetadata((bool)false,
                    FrameworkPropertyMetadataOptions.AffectsArrange));

        /// <summary>
        /// Gets or sets the IsReversed property.  This dependency property 
        /// indicates ....
        /// </summary>
        public bool IsReversed
        {
            get { return (bool)GetValue(IsReversedProperty); }
            set { SetValue(IsReversedProperty, value); }
        }

        #endregion

        #region AnimationStarted

        public event EventHandler AnimationStarted;

        private void RaiseAnimationStarted()
        {
            if (AnimationStarted != null)
            {
                AnimationStarted(this, new EventArgs());
            }
        }

        #endregion

        #region AnimationCompleted

        public event EventHandler AnimationCompleted;

        private void RaiseAnimationCompleted()
        {
            if (AnimationCompleted != null)
            {
                AnimationCompleted(this, new EventArgs());
            }
        }

        #endregion

        #region DragScaler

        /// <summary>
        /// DragScaler Dependency Property
        /// </summary>
        public static readonly DependencyProperty DragScalerProperty =
            DependencyProperty.Register("DragScaler", typeof(double), typeof(AnimatedScrollDecorator),
                new FrameworkPropertyMetadata((double)1.0));

        /// <summary>
        /// Gets or sets the DragScaler property.  This dependency property 
        /// indicates ....
        /// </summary>
        public double DragScaler
        {
            get { return (double)GetValue(DragScalerProperty); }
            set { SetValue(DragScalerProperty, value); }
        }

        #endregion

        #region DragDirection

        /// <summary>
        /// DragDirection Dependency Property
        /// </summary>
        public static readonly DependencyProperty DragDirectionProperty =
            DependencyProperty.Register("DragDirection", typeof(DragDirection), typeof(AnimatedScrollDecorator),
                new FrameworkPropertyMetadata((DragDirection)DragDirection.VerticalOnly));

        /// <summary>
        /// Gets or sets the DragDirection property.  This dependency property 
        /// indicates ....
        /// </summary>
        public DragDirection DragDirection
        {
            get { return (DragDirection)GetValue(DragDirectionProperty); }
            set { SetValue(DragDirectionProperty, value); }
        }

        #endregion

        #region AnimationBehavior

        /// <summary>
        /// AnimationBehavior Dependency Property
        /// </summary>
        public static readonly DependencyProperty AnimationBehaviorProperty =
            DependencyProperty.Register("AnimationBehavior", typeof(AnimationBehavior), typeof(AnimatedScrollDecorator),
                new FrameworkPropertyMetadata((AnimationBehavior)AnimationBehavior.OnDrag));

        /// <summary>
        /// Gets or sets the AnimationBehavior property.  This dependency property 
        /// indicates ....
        /// </summary>
        public AnimationBehavior AnimationBehavior
        {
            get { return (AnimationBehavior)GetValue(AnimationBehaviorProperty); }
            set { SetValue(AnimationBehaviorProperty, value); }
        }

        #endregion

        #region RequiresScrolling

        /// <summary>
        /// RequiresScrolling Read-Only Dependency Property
        /// </summary>
        private static readonly DependencyPropertyKey RequiresScrollingPropertyKey
            = DependencyProperty.RegisterReadOnly("RequiresScrolling", typeof(bool), typeof(AnimatedScrollDecorator),
                new FrameworkPropertyMetadata((bool)false,
                    new PropertyChangedCallback(OnRequiresScrollingChanged)));

        public static readonly DependencyProperty RequiresScrollingProperty
            = RequiresScrollingPropertyKey.DependencyProperty;

        /// <summary>
        /// Gets the RequiresScrolling property.  This dependency property 
        /// indicates ....
        /// </summary>
        public bool RequiresScrolling
        {
            get { return (bool)GetValue(RequiresScrollingProperty); }
        }

        /// <summary>
        /// Provides a secure method for setting the RequiresScrolling property.  
        /// This dependency property indicates ....
        /// </summary>
        /// <param name="value">The new value for the property.</param>
        protected void SetRequiresScrolling(bool value)
        {
            SetValue(RequiresScrollingPropertyKey, value);
        }

        /// <summary>
        /// Handles changes to the RequiresScrolling property.
        /// </summary>
        private static void OnRequiresScrollingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((AnimatedScrollDecorator)d).OnRequiresScrollingChanged(e);
        }

        /// <summary>
        /// Provides derived classes an opportunity to handle changes to the RequiresScrolling property.
        /// </summary>
        protected virtual void OnRequiresScrollingChanged(DependencyPropertyChangedEventArgs e)
        {
            RaiseRequiresScrollingChangedEvent();
        }

        #endregion

        #region RequireScrollChanged (Routed Event)

        public static readonly RoutedEvent RequiresScrollingChangedEvent = EventManager.RegisterRoutedEvent("RequiresScrollingChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(AnimatedScrollDecorator));

        public event RoutedEventHandler RequiresScrollingChanged
        {
            add { AddHandler(RequiresScrollingChangedEvent, value); }
            remove { RemoveHandler(RequiresScrollingChangedEvent, value); }
        }

        void RaiseRequiresScrollingChangedEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(AnimatedScrollDecorator.RequiresScrollingChangedEvent);
            RaiseEvent(newEventArgs);
        }

        #endregion

        #region ActualContentHeight

        private static readonly DependencyPropertyKey ActualContentHeightPropertyKey
            = DependencyProperty.RegisterReadOnly("ActualContentHeight", typeof(double), typeof(AnimatedScrollDecorator),
                new FrameworkPropertyMetadata((double)0.0));

        public static readonly DependencyProperty ActualContentHeightProperty
            = ActualContentHeightPropertyKey.DependencyProperty;

        public double ActualContentHeight
        {
            get { return (double)GetValue(ActualContentHeightProperty); }
        }

        protected void SetActualContentHeight(double value)
        {
            SetValue(ActualContentHeightPropertyKey, value);
        }

        #endregion

        #region ActualContentWidth

        private static readonly DependencyPropertyKey ActualContentWidthPropertyKey
            = DependencyProperty.RegisterReadOnly("ActualContentWidth", typeof(double), typeof(AnimatedScrollDecorator),
                new FrameworkPropertyMetadata((double)0.0));

        public static readonly DependencyProperty ActualContentWidthProperty
            = ActualContentWidthPropertyKey.DependencyProperty;

        public double ActualContentWidth
        {
            get { return (double)GetValue(ActualContentWidthProperty); }
        }

        protected void SetActualContentWidth(double value)
        {
            SetValue(ActualContentWidthPropertyKey, value);
        }

        #endregion
    }

    public enum DragDirection
    {
        Both, HorizontalOnly, VerticalOnly
    }

    public enum AnimationBehavior
    {
        OnDrag, Never, Always
    }

}
