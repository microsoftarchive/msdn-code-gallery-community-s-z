/* 
 * Copyright (c) 2010, Andriy Syrov
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without modification, are permitted provided 
 * that the following conditions are met:
 * 
 * Redistributions of source code must retain the above copyright notice, this list of conditions and the 
 * following disclaimer.
 * 
 * Redistributions in binary form must reproduce the above copyright notice, this list of conditions and 
 * the following disclaimer in the documentation and/or other materials provided with the distribution.
 *
 * Neither the name of Andriy Syrov nor the names of his contributors may be used to endorse or promote 
 * products derived from this software without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED 
 * WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A 
 * PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY 
 * DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED 
 * TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS 
 * INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, 
 * OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN 
 * IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE. 
 *   
 */

using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TimelineLibrary;
using System.Windows.Controls.Primitives;
using System.Diagnostics;

//
// TODO: this difference in namespace name needs to be fixed...
//
#if !SILVERLIGHT
    namespace TimelineEx
#else 
    namespace TimelineExLib
#endif
{
    /// 
    /// <summary>
    /// This class demonstrate how the functionality of basic TimelineEvent may be extended to 
    /// include new attributes from XML, see CreateEvent, ReadEvent implementation of 
    /// TimelineTrayEx for more details</summary>
    /// 
    public class TimelineEventEx: TimelineEvent
    {
        private string                                  m_video;

        public string Video
        {
            get
            {
                return m_video;
            }
            set
            {
                m_video = value;
                FirePropertyChanged("Video");
            }
        }
    }

    /// 
    /// <summary>
    /// This class demonstrates extending functionality of TimelineTray with more features 
    /// like editing of events and event dragging, etc.</summary>
    /// 
    public class TimelineTrayEx: TimelineTray, INotifyPropertyChanged
    {
        private const double                            MIN_SIZE = 50;

        bool                                            m_mouseCaptured;
        Point                                           m_init;

        public new event PropertyChangedEventHandler    PropertyChanged;
        public event Action<TimelineEventEx>            EditClick;
           
        private bool                                    m_editMode = false;
        private bool                                    m_editDates = false;
        private DragElement                             m_dragElement;

        private enum DragElement
        {
            Duration,
            Position,
            Size
        }

        public TimelineTrayEx(
        )
        {
            base.OnEventDeleted += OnEventDeleted;
            base.OnEventCreated += OnEventCreated;
        }

        /// 
        /// <summary>
        /// Event factory method which allows TimelineTray to create extended
        /// version of TimelineEvent with new attributes</summary>
        /// 
        public override TimelineEvent CreateEvent()
        {
            return new TimelineEventEx();
        }

        /// 
        /// <summary>
        /// Here we override ReadEvent and read additional Video property</summary>
        /// 
        public override TimelineEvent ReadEvent(
            System.Xml.Linq.XElement                    row
        )
        {
            TimelineEventEx                             e;

            e = base.ReadEvent(row) as TimelineEventEx;
            e.Video = GetAttribute(row.Attribute("video")); 

            return e;
        }

        /// 
        /// <summary>
        /// Specifies if the user may change positions of events using 
        /// mouse drag/drop</summary>
        /// 
        public bool EditMode
        {
            get
            {
                return m_editMode;
            }
            set
            {
                m_editMode = value;
                if (MainBand != null)
                {
                    MainBand.DisplayEvents();
                }
                FirePropertyChanged("EditMode");
            }
        }

        /// 
        /// <summary>
        /// Specifies if the user may change event StartDate/EndDate while changing 
        /// event positions on the screen in EditMode</summary>
        /// 
        public bool AllowEditDates
        {
            get
            {
                return m_editDates;
            }
            set
            {
                m_editDates = value;
                FirePropertyChanged("AllowEditDates");
            }
        }

        internal void FirePropertyChanged(
            string                                      property
        )
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        #region Create/Delete timeline events handlers

        /// 
        /// <summary>
        /// Once new visual element is created for timeline event we attach 
        /// event handlers to it's elements</summary>
        /// 
        private new void OnEventCreated(
            FrameworkElement                            element, 
            TimelineDisplayEvent                        de
        )
        {
            Grid                                        b;
            Border                                      bsize;
            Border                                      bdescr;
            Border                                      bduration;
            Hyperlink                                   hlink;

            b = element.FindName("EventTemplateRoot") as Grid;
            bsize = element.FindName("ResizeButton") as Border;
            bdescr = element.FindName("EventDescriptionBorder") as Border;
            bduration = element.FindName("DurationChangeBorder") as Border;

            hlink = element.FindName("EditButton") as Hyperlink;

            if (hlink != null)
            {
                hlink.Click += OnEditClick;
                hlink.Tag = de;
            }

            if (bdescr != null)
            {
                bdescr.MouseLeftButtonDown += CaptureMouse;
                bdescr.MouseLeftButtonUp += ReleaseMouse;
                bdescr.MouseMove += OnDescriptionMouseMove;
                bdescr.Tag = element;
            }

            if (bduration != null)
            {
                bduration.MouseLeftButtonDown += CaptureMouse;
                bduration.MouseLeftButtonUp += ReleaseMouse;
                bduration.MouseMove += OnBDurationMouseMove;
                bduration.Tag = element;
            }

            if (bsize != null)
            {
                bsize.MouseLeftButtonDown += CaptureMouse;
                bsize.MouseLeftButtonUp += ReleaseMouse;
                bsize.MouseMove += OnResizeMouseMove;
                bsize.Tag = b;
            }
        }

        void OnEditClick(
            object                                      sender, 
            RoutedEventArgs                             e
        )
        {
            if (EditClick != null)
            {
                EditClick(((sender as Hyperlink).DataContext as TimelineDisplayEvent).Event as TimelineEventEx);
            }
        }

        /// 
        /// <summary>
        /// Once visual element is deleted we mark that there are no currently 
        /// playing videos</summary>
        /// 
        private new void OnEventDeleted(
            FrameworkElement                            element, 
            TimelineLibrary.TimelineDisplayEvent        de
        )
        {
        }

        #endregion

        #region Mouse Event Handing

        /// 
        /// <summary>
        /// This changes event duration according to current mouse 
        /// position</summary>
        /// 
        private void OnBDurationMouseMove(
            object                                          sender, 
            MouseEventArgs                                  e
        )
        {
            Point                                           p;

            if (m_mouseCaptured && AllowEditDates)
            {
                FrameworkElement                            root;
                TimelineDisplayEvent                        de;
                TimeSpan                                    span;
                double                                      inc;

                p = e.GetPosition(null);
                inc = p.X - m_init.X;

                root = (sender as FrameworkElement).Tag as FrameworkElement;
                de = root.DataContext as TimelineDisplayEvent;

                span = de.TimelineBuilder.PixelsToTimeSpan(inc);

                if (de.Event.EndDate + span < de.Event.StartDate)
                {
                    span = new TimeSpan(0);
                    de.Event.EndDate = de.Event.StartDate;
                }
                else
                {
                    m_init = p;
                }

                de.Event.EndDate += span;

                de.EventPixelWidth = de.TimelineBuilder.TimeSpanToPixels(de.Event.EndDate - 
                    de.Event.StartDate);

                de.Event.IsDuration = (de.Event.EndDate != de.Event.StartDate);

#if !SILVERLIGHT
                e.Handled = true;
#endif
            }
        }


        /// 
        /// <summary>
        /// This changes event position size according to current mouse 
        /// position</summary>
        /// 
        private void OnDescriptionMouseMove(
            object                                      sender, 
            MouseEventArgs                              e
        )
        {
            if (m_mouseCaptured)
            {
                FrameworkElement                            root;
                TimelineDisplayEvent                        de;
                TimeSpan                                    span;
                double                                      inc;
                Point                                       pos;

                pos = e.GetPosition(null);

                root = (sender as FrameworkElement).Tag as FrameworkElement;
                de = root.DataContext as TimelineDisplayEvent;

                //
                // first we moving event to a new postion
                //
                de.TopWithoutOffset = Math.Max(0, de.TopWithoutOffset + (pos.Y - m_init.Y));
                de.TimelineBuilder.SetTopWithScrollOffset(root, de.TopWithoutOffset, false);

                if (AllowEditDates)
                {
                    inc = pos.X - m_init.X;

                    root.SetValue(Canvas.LeftProperty, 
                        (double) root.GetValue(Canvas.LeftProperty) + inc);

                    //
                    // now we updating Start and End time of event so it 
                    // matches new position
                    //
                    span = de.TimelineBuilder.PixelsToTimeSpan(inc);

                    de.Event.StartDate += span;

                    if (de.Event.IsDuration)
                    {
                        de.Event.EndDate += span;
                    }
                    else
                    {
                        de.Event.EndDate = de.Event.StartDate;
                    }
                }

                m_init = pos;

#if !SILVERLIGHT
                e.Handled = true;
#endif
            }
        }

        /// 
        /// <summary>
        /// This changes event description size according to current mouse 
        /// position</summary>
        /// 
        private void OnResizeMouseMove(
            object                                      sender, 
            MouseEventArgs                              e
        )
        {
            Grid                                        b;
            Point                                       p;
            TimelineDisplayEvent                        de;
            double                                      dx;
            double                                      dy;
            
            if (m_mouseCaptured)
            {
                b = (sender as Border).Tag as Grid;
                p = e.GetPosition(null);
                de = b.DataContext as TimelineDisplayEvent;

                dx = p.X - m_init.X;
                dy = p.Y - m_init.Y;

                if (de.DescriptionHeight + dy >= MIN_SIZE)
                {
                    de.DescriptionHeight += dy;
                    m_init.Y = p.Y;
                }

                if (de.DescriptionWidth + dx >= MIN_SIZE)
                {
                    de.DescriptionWidth += dx;
                    m_init.X = p.X;
                }
#if !SILVERLIGHT
                e.Handled = true;
#endif
            }
        }

        /// 
        /// <summary>
        /// Mouse release is common code for moving, resizing and duration change 
        /// events</summary>
        /// 
        void ReleaseMouse(
            object                                      sender, 
            MouseButtonEventArgs                        e
        )
        {
            FrameworkElement                            ep;

            if (EditMode)
            {
                Debug.Assert(m_mouseCaptured);

                m_mouseCaptured = false;
                (sender as FrameworkElement).ReleaseMouseCapture();
                (sender as FrameworkElement).Cursor = Cursors.Arrow;

                ep = ((sender as FrameworkElement).Tag as FrameworkElement);
                ep.SetValue(Canvas.ZIndexProperty, (int) ep.GetValue(Canvas.ZIndexProperty) - 1000);

                e.Handled = true;
            }
        }

        /// 
        /// <summary>
        /// Mouse capture is common code for moving, resizing and duration change 
        /// events</summary>
        /// 
        private void CaptureMouse(
            object                                      sender, 
            MouseButtonEventArgs                        e
        )
        {
            FrameworkElement                            ep;

            if (EditMode)
            {
                Debug.Assert(!m_mouseCaptured);

                (sender as FrameworkElement).CaptureMouse();
                (sender as FrameworkElement).Cursor = Cursors.Hand;
                m_init = e.GetPosition(null);

                ep = ((sender as FrameworkElement).Tag as FrameworkElement);
                ep.SetValue(Canvas.ZIndexProperty, (int) ep.GetValue(Canvas.ZIndexProperty) + 1000);

                m_mouseCaptured = true;
                e.Handled = true;
            }
        }

        #endregion
    }

    /// 
    /// <summary>
    /// This class demonstartes extending of functionality of TimelineTray with more features
    /// like scroll bar</summary>
    /// 
    public class TimelineBandEx: TimelineBand
    {
        private const int                               SCROLLBAR_BOTTOM_MARGIN = 0;
        private ScrollBar                               m_scroll;
        private bool                                    m_scrollPositioned;

        static TimelineBandEx(
        )
        {
#if !SILVERLIGHT
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TimelineBandEx), 
                new FrameworkPropertyMetadata(typeof(TimelineBandEx)));
#endif
        }

        public TimelineBandEx(
        )
        {
#if SILVERLIGHT         
            DefaultStyleKey = typeof(TimelineBandEx);
#endif
        }

        #region ScrollBarStyle

        public static readonly DependencyProperty ScrollBarStyleProperty =
            DependencyProperty.Register("ScrollBarStyle", typeof(Style),
            typeof(TimelineBandEx), new PropertyMetadata(ScrollBarStyleChanged));

        public static void ScrollBarStyleChanged(
            DependencyObject                           d,
            DependencyPropertyChangedEventArgs         e
        )
        {
            TimelineBandEx                             band;
            band = (TimelineBandEx)                    d;

            if (band != null)
            {
                band.OnScrollBarStyleChanged(e);
            }
        }

        protected virtual void OnScrollBarStyleChanged(
            DependencyPropertyChangedEventArgs e
        )
        {
            ScrollBarStyle = (Style) e.NewValue;
        }

        public Style ScrollBarStyle
        {
            get
            {
                return (Style) GetValue(ScrollBarStyleProperty);
            }
            set
            {
                SetValue(ScrollBarStyleProperty, value);
            }
        }

        #endregion

        public override void OnApplyTemplate(
        )
        {
            base.OnApplyTemplate();

            if (this.IsMainBand)
            {
                m_scroll = new ScrollBar()
                {
                    Name = "scroll",
                    Orientation = Orientation.Vertical
                };

                if (ScrollBarStyle != null)
                {
                    m_scroll.Style = ScrollBarStyle;
                }

                m_scroll.SetValue(Canvas.ZIndexProperty, 200000);
                m_scroll.ValueChanged += OnScrollValueChanged;
                CanvasPart.Children.Add(m_scroll);

                SizeChanged += (o, v) => ResizeScrollbar();
                m_scroll.Loaded += (o, v) => ResizeScrollbar();

                ResizeScrollbar();
            }
        }

        public override void OnScrollPositionChanged(
        )
        {
            base.OnScrollPositionChanged();

            if (m_scrollPositioned)
            {
                UpdateScrollbar();
            }
            else
            {
                ResizeScrollbar();
            }
        }

        private void ResizeScrollbar(
        )
        {
            if (m_scroll != null && m_scroll.ActualWidth > 0 && CanvasPart.ActualWidth > 0)
            {
                m_scroll.SetValue(Canvas.TopProperty, 0.0);
                m_scroll.SetValue(Canvas.LeftProperty, CanvasPart.ActualWidth - m_scroll.ActualWidth);

                if (CanvasPart.ActualHeight > SCROLLBAR_BOTTOM_MARGIN)
                {
                    m_scroll.Height = CanvasPart.ActualHeight - SCROLLBAR_BOTTOM_MARGIN;
                }
                UpdateScrollbar();
                m_scrollPositioned = true;
            }
        }

        private void OnScrollValueChanged(
            object                                      sender, 
            RoutedPropertyChangedEventArgs<double>      e
        )
        {
            if (TimelineTray.EventCanvasOffset != e.NewValue)
            { 
                TimelineTray.EventCanvasOffset = e.NewValue;
                TimelineTray.MainBand.DisplayEvents();
            }
        }

        private void UpdateScrollbar(
        )
        {
            Visibility                                  v;
            double                                      max;
            double                                      val;
            double                                      view;

            if (m_scroll != null && TimelineTray != null)
            { 
                max  = Math.Max(0, VerticalScrollableSize - ActualHeight);
                view = Math.Min(VerticalScrollableSize, ActualHeight);

                val  = TimelineTray.EventCanvasOffset;

                if (max == 0)
                {
                    view = val = 0;
                }

                if (m_scroll.Value != val)
                {
                    if (m_scroll.Maximum < max)
                    {
                        m_scroll.Maximum = max;
                    }
                    m_scroll.Value = val;
                }

                if (m_scroll.Maximum != max)
                { 
                    m_scroll.Maximum = max;
                }

                if (m_scroll.ViewportSize != view)
                { 
                    m_scroll.ViewportSize = view;
                    m_scroll.LargeChange = Math.Max(10, view / 10);
                    m_scroll.SmallChange = 1;
                }

                v = (max == 0 ? Visibility.Collapsed : Visibility.Visible);

                if (v != m_scroll.Visibility)
                { 
                    m_scroll.Visibility = v;
                }
            }
        }
    }
}
