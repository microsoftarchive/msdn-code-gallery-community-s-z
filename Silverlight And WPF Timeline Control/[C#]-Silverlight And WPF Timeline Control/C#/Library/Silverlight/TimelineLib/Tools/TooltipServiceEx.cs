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
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace TimelineLibrary
{
    /// 
    /// <summary>
    /// This service extends functionality of standard ToolTipService by allowing tooltip stay on 
    /// the screen till timeout occurs</summary>
    /// 
    public static class TooltipServiceEx
    {
        public static readonly DependencyProperty ToolTipExProperty = 
            DependencyProperty.RegisterAttached("ToolTipEx", typeof(ToolTipEx), 
            typeof(TooltipServiceEx), new PropertyMetadata(OnEventToolTipPropertyChanged));


        public static ToolTipEx                        LastTooltip;

        private static void OnEventToolTipPropertyChanged(
            DependencyObject                            d, 
            DependencyPropertyChangedEventArgs          e
        )
        {
            FrameworkElement                            element;

            element = (FrameworkElement) d;

            element.Loaded += OnParentLoaded;
            element.MouseLeftButtonDown += OnMouseDown;
            element.MouseLeave += OnMouseLeave;
        }

        public static void HideLastTooltip()
        {
            if (TooltipServiceEx.LastTooltip != null)
            {
                TooltipServiceEx.LastTooltip.Hide();
                TooltipServiceEx.LastTooltip = null;
            }
        }

        static void OnMouseLeave(
            object                                      sender, 
            MouseEventArgs                              e
        )
        {
            HideTooltip(sender);
        }

        static void OnMouseDown(
            object                                      sender, 
            MouseButtonEventArgs                        e
        )
        {
            HideTooltip(sender);
        }

        static void HideTooltip(
            object                                      sender
        )
        {
            FrameworkElement                            owner;
            ToolTipEx                                   tooltip;

            owner = (FrameworkElement) sender;
            tooltip = owner.GetValue(TooltipServiceEx.ToolTipExProperty) as ToolTipEx;

            if (tooltip != null)
            {
                tooltip.Hide();
            }
            LastTooltip = null;
        }

        static void OnParentLoaded(
            object                                      sender, 
            RoutedEventArgs                             e
        )
        {
            FrameworkElement                            owner;
            ToolTipEx                                   tooltip;
            ToolTip                                     orgTooltip;

            owner = (FrameworkElement) sender;

            owner.Loaded -= OnParentLoaded;
            tooltip = owner.GetValue(TooltipServiceEx.ToolTipExProperty) as ToolTipEx;
            orgTooltip = owner.GetValue(ToolTipService.ToolTipProperty) as ToolTip;

            tooltip.Tooltip = orgTooltip;
        }

        public static void SetToolTipEx(
            DependencyObject                            o,
            ToolTipEx                                   t
        )
        {
            o.SetValue(ToolTipExProperty, t);
        }

        public static ToolTipEx GetToolTipEx(
            DependencyObject                            o
        )
        {
            return o.GetValue(ToolTipExProperty) as ToolTipEx;
        }
    }

    public class ToolTipEx
    {
        private DispatcherTimer                          m_timer;
        private int                                      m_timeLeft;
        private ToolTip                                  m_tooltip;

        public ToolTip Tooltip
        {
            get
            {
                return m_tooltip;
            }

            set 
            {
                if (m_tooltip != null)
                {
                    m_tooltip.Opened -= OnTooltipOpened;
                    m_tooltip.Closed -= OnTooltipClosed;
                }

                m_tooltip = value;

                if (m_tooltip != null)
                {
                    m_tooltip.Opened += OnTooltipOpened;
                    m_tooltip.Closed += OnTooltipClosed;
                }
            }
        }

        public void Hide(
        )
        {
            if (m_tooltip != null && m_tooltip.IsOpen)
            {
                StopTimer();
                m_tooltip.IsOpen = false;
            }
        }

        /// 
        /// <summary>
        /// Tooltip timeout interval in seconds, 0 for infinite</summary>
        /// 
        public int HideToolTipTimeout
        {
            get;
            set;
        }

        void OnTooltipClosed(
            object                                      sender, 
            RoutedEventArgs                             e
        )
        {
            if (m_timeLeft > 0)
            {
#if SILVERLIGHT
                m_tooltip.IsOpen = true;
#else
                TooltipServiceEx.LastTooltip = null;
#endif
            }
            else
            {
                StopTimer();
                TooltipServiceEx.LastTooltip = null;
            }

            
        }

        private void StopTimer(
        )
        {
            if (m_timer != null)
            {
                m_timer.Stop();
                m_timer.Tick -= OnTimerTick;
                m_timer = null;
                m_timeLeft = 0;
            }
        }

        void OnTooltipOpened(
            object                                      sender, 
            RoutedEventArgs                             e
        )
        {
            m_timer = new DispatcherTimer();
            
            m_timer.Interval = new TimeSpan(0, 0, 1);
            m_timer.Tick += OnTimerTick;
            m_timeLeft = HideToolTipTimeout;
            m_timer.Start();

            TooltipServiceEx.HideLastTooltip();
            TooltipServiceEx.LastTooltip = this;
        }

        void OnTimerTick(
            object                                      sender, 
            EventArgs                                   e
        )
        {
            --m_timeLeft;
            m_tooltip.IsOpen = m_timeLeft > 0;
        }
    }
}
