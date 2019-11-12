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
using System.Diagnostics;
using System.Windows.Data;
using System.Globalization;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Media.Animation;
using System.Collections.Generic;

namespace TimelineLibrary
{
    public class NullToUnsetConverter : IValueConverter
    {
        public object Convert(
            object                                      value, 
            Type                                        targetType,
            object                                      parameter, 
            CultureInfo                                 culture
        )
        {
            if (value == null || (value as string != null && String.IsNullOrEmpty(value as string)))
            {
                return DependencyProperty.UnsetValue;
            }

            return value;
        }

        public object ConvertBack(
            object                                      value, 
            Type                                        targetType,
            object                                      parameter, 
            CultureInfo                                 culture
        )
        {
            throw new NotImplementedException();
        }
    }

    /// 
    /// <summary>
    /// Misc utilities</summary>
    /// 
    public static class Utilities
    {
        private const string                            FMT_TRACE = "{0:000000}:{1}.{2} {3}";
        private static DateTime                         g_start = DateTime.Now;
        private const int                               METHOD_ALIGN = 30;

        /// 
        /// <summary>
        /// Outputs debug trace message</summary>
        /// 
        public static void Trace(
            this object                                 sender, 
            object                                      msgObject = null,
            bool                                        condition = true
        ) 
        {
#if DEBUG
            StackTrace                                  trace;
            string                                      method;
            string                                      message;

            if (condition && Debugger.IsLogging())
            { 
                trace = new System.Diagnostics.StackTrace();
                method = trace.GetFrame(1).GetMethod().Name;

                message = msgObject != null ? msgObject.ToString() : String.Empty;

                if (method.Length < METHOD_ALIGN)
                {
                    method += new String(' ', METHOD_ALIGN - method.Length); 
                }

                Debug.WriteLine(string.Format(
                    FMT_TRACE, 
                    (DateTime.Now - g_start).TotalMilliseconds,
                    sender.GetType().Name, 
                    method, 
                    message.Length == 0 ? sender.ToString() : message));
            }
#endif
        }
    }

    public class SingleDelayedInvoke
    {
        /// 
        /// <summary>
        /// Delays in milliseconds</summary>
        /// 
        public const int                                MINIMAL_UI_DELAY = 1000 / 24;  
        public const int                                MEDIUM_UI_DELAY = 1000 / 12;   
        public const int                                MAX_UI_DELAY = 1000 / 6;  

        private DispatcherTimer                         m_timer;
        private int                                     m_delay;
        private bool                                    m_cancel;
        private int                                     m_count;                               

        public SingleDelayedInvoke(
            int                                         delay = MINIMAL_UI_DELAY
        )
        {
            m_delay = delay;
        }

        public static void Invoke(
            Action                                      action,
            int                                         delay
        )
        {
            SingleDelayedInvoke                         d;

            d = new SingleDelayedInvoke(delay);
            d.Invoke(action);
        }

        public bool Cancel(
        )
        {
            if (m_timer != null)
            {
                return true;
            }
            return false;
        }

        public void Invoke(
            Action                                      action
        )
        {
            if (m_timer == null)
            {
#if SILVERLIGHT
                m_timer = new DispatcherTimer();
#else
                m_timer = new DispatcherTimer(DispatcherPriority.ApplicationIdle);
#endif
                m_cancel = false;
                m_count = 1;
                m_timer.Interval = TimeSpan.FromMilliseconds(m_delay);
                m_timer.Tick += (s, e) =>
                {
                    m_timer.Stop();
                    m_timer = null;

                    if (!m_cancel)
                    { 
                        action();
                    }
                    this.Trace(m_count.ToString(), m_count > 1);
                };
                m_timer.Start();
            }
            else
            {
                m_count++;
                Utilities.Trace(this, "invoke already scheduled");
            }
        }
    }

    /// 
    /// <summary>
    /// Extender methods for animation, storyboard</summary>
    ///
    public static class Animate
    {
        private const int                               KEYFRAME_INTERVAL = 1000 / 32;

        /// 
        /// <summary>
        /// Helper to create double animation based on keyframe</summary>
        /// 
        public static Storyboard AddDoubleKeyFrame(
            this Storyboard                             sb,
            int                                         durationMs,
            DependencyObject                            element,
            PropertyPath                                path,
            double                                      from,
            double                                      to
        )
        {
            DoubleAnimationUsingKeyFrames               da;
            double                                      step;

            step = (from - to) / (durationMs / KEYFRAME_INTERVAL);

            da = new DoubleAnimationUsingKeyFrames();
            da.Duration = new Duration(TimeSpan.FromMilliseconds(durationMs));

            for (int i = 0; i < durationMs; i += KEYFRAME_INTERVAL)
            {
                da.KeyFrames.Add(new LinearDoubleKeyFrame()
                {
                     Value = from + step * i,
                     KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(i * KEYFRAME_INTERVAL))
                });
            }

            da.KeyFrames.Add(new LinearDoubleKeyFrame()
            {
                Value = to,
                KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(durationMs))
            });

            Storyboard.SetTarget(da, element);
            Storyboard.SetTargetProperty(da, path);

            sb.Children.Add(da);
            return sb;
        }


        /// 
        /// <summary>
        /// Helper to create double animation</summary>
        /// 
        public static Storyboard AddDouble(
            this Storyboard                             sb,
            int                                         durationMs,
            DependencyObject                            element,
            PropertyPath                                path,
            double                                      from,
            double                                      to,
            IEasingFunction                             easing = null
        )
        {
            DoubleAnimation                             da;

            da = new DoubleAnimation();
            da.Duration = new Duration(TimeSpan.FromMilliseconds(durationMs));

            da.From = from;
            da.To =  to;

            if (easing != null)
            { 
                da.EasingFunction = easing;
            }

            Storyboard.SetTarget(da, element);
            Storyboard.SetTargetProperty(da, path);

            sb.Children.Add(da);
            return sb;
        }
    }
}
