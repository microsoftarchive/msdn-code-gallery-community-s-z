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
using System.Windows;
using System.Windows.Threading;
using System.Diagnostics;

namespace TimelineLibrary
{
    public class InertialTimelineScroll
    {
#if SILVERLIGHT
        private const int                               TRACKING_INTERVAL = 50;
#else
        private const int                               TRACKING_INTERVAL = 100;
#endif
        private const double                            DECELERATION = 0.977;
        private const int                               DECELERATION_INTERVAL = 1000 / 48;
        private const int                               MIN_POINTS = 1;
        private const int                               DOUBLE_CLICK_TIME = 500;


        DispatcherTimer                                 m_timer;
        FrameworkElement                                m_element;

        bool                                            m_manualDragging;
        bool                                            m_inertialDragging;

        private Point                                   m_p1;
        private Point                                   m_p2;
        private DateTime                                m_p1time;
        private DateTime                                m_p2time;

        private double                                  m_incrementX;
        private double                                  m_incrementY;
        private DateTime                                m_lastClick = DateTime.MinValue;
        
        public event Action<Point>                      OnDragStart;                             
        public event Action<Point>                      OnDragStop;                             
        public event Action<Point, Point>               OnDragMove;   
        public event Action<Point>                      OnDoubleClick;
     
        public static InertialTimelineScroll            MovingScroll;

        public InertialTimelineScroll(
            FrameworkElement                            fe
        )
        {
            m_element = fe;

            m_element.MouseLeftButtonUp += OnDragMouseUp;
            m_element.MouseLeftButtonDown += OnDragMouseDown;
            m_element.MouseMove += OnMouseMove;

#if SILVERLIGHT
            m_timer = new DispatcherTimer();
#else
            m_timer = new DispatcherTimer(DispatcherPriority.ApplicationIdle);
#endif
            m_timer.Tick += OnTick;
        }

        public static bool Moving
        {
            get
            {
                return MovingScroll != null;
            }
        }

        void OnTick(
            object                                      sender, 
            EventArgs                                   e
        )
        {
            if (m_manualDragging)
            {
                m_p1time = m_p2time;
                m_p1 = m_p2;
            }
            else if (m_inertialDragging)
            {
                InertialMove();
            }
        }

        /// 
        /// <summary>
        /// Send event for next inertial step</summary>
        /// 
        private void InertialMove(
        )
        {
            m_p2.X += m_incrementX;
            m_p2.Y += m_incrementY;

            m_incrementX *= DECELERATION;
            m_incrementY *= DECELERATION;

            if (OnDragMove != null)
            {
                OnDragMove(m_p1, m_p2);
            }

            if (Math.Abs(m_incrementX) <= MIN_POINTS && Math.Abs(m_incrementY) <= MIN_POINTS)
            {
                Release();
            }
            m_p1 = m_p2;
        }

        /// 
        /// <summary>
        /// Calculate distance in pixels for each inertial step and start deceleration timer</summary>
        /// 
        private void InitializeInertialMove(
        )
        {
            int                                         trackingTime;

            trackingTime = (int) (m_p2time - m_p1time).TotalMilliseconds;

            m_timer.Stop();
            m_element.ReleaseMouseCapture();

            m_timer.Interval = TimeSpan.FromMilliseconds(DECELERATION_INTERVAL);
            m_timer.Start();

            MovingScroll = this;

            m_incrementX = ((m_p2.X - m_p1.X) / trackingTime) * DECELERATION_INTERVAL;
            m_incrementY = ((m_p2.Y - m_p1.Y) / trackingTime) * DECELERATION_INTERVAL;
        }

        public void Release(
        )
        {
            bool                                        sendDragStop;

            MovingScroll = null;

            sendDragStop = (m_inertialDragging || m_manualDragging);
            m_inertialDragging = false;
            m_manualDragging = false;

            m_element.ReleaseMouseCapture();
            m_timer.Stop();

            if (OnDragStop != null && sendDragStop)
            {
                OnDragStop(m_p2);
            }
        }

        private void OnMouseMove(
            object                                      sender, 
            System.Windows.Input.MouseEventArgs         e
        )
        {
            Point                                       p;

            if (m_manualDragging)
            {
                p = e.GetPosition(m_element);

                if (OnDragMove != null)
                {
                    OnDragMove(m_p2, p);
                }
                m_p2 = p;
                m_p2time = DateTime.Now;
            }
        }

        private void OnDragMouseUp(
            object                                      sender, 
            System.Windows.Input.MouseButtonEventArgs   e
        )
        {
            Point                                       p;

            if (m_manualDragging)
            {
                m_manualDragging = false;
                m_p2 = e.GetPosition(m_element);
                m_p2time = DateTime.Now;
                
                if (m_p2time != m_p1time && m_p1 != m_p2)
                {
                    m_inertialDragging = true;
                    InitializeInertialMove();
                }
                else
                {
                    Release();
                }
                e.Handled = true;
            }
        }

        private void OnDragMouseDown(
            object                                      sender, 
            System.Windows.Input.MouseButtonEventArgs   e
        )
        {
            bool                                        capture;

            if (MovingScroll != null)
            {
                MovingScroll.Release();
            }

            if (DateTime.Now - m_lastClick < TimeSpan.FromMilliseconds(DOUBLE_CLICK_TIME) && OnDoubleClick != null)
            {
                OnDoubleClick(e.GetPosition(m_element));
            }
            else 
            {
                capture = m_element.CaptureMouse();
                Debug.Assert(capture);

                m_p1 = m_p2 = e.GetPosition(m_element);
                m_p1time = m_p2time = DateTime.Now;

                m_timer.Interval = TimeSpan.FromMilliseconds(TRACKING_INTERVAL);
                m_timer.Start();

                OnDragStart(m_p2);

                m_manualDragging = true;
                m_inertialDragging = false;

                e.Handled = true;
            }
            m_lastClick = DateTime.Now;
        }

    } 
}
