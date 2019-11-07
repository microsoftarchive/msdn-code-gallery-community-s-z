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
using System.Windows;
using System.Windows.Controls;

namespace TimelineLibrary
{
    [TemplatePart(Name = TimelineToolbox.TP_MAIN_GRID_PART, Type = typeof(Grid))]
    public class TimelineToolbox : Control, ITimelineToolbox
    {
        private const string                            TP_MAIN_GRID_PART = "MainGrid";
        ITimelineToolboxTarget                          m_target;
        Grid                                            m_grid;

		#region " Events "

		/// <summary>
		/// Fires when the find first event button is clicked.
		/// </summary>
		public event RoutedEventHandler FindingFirstEvent;

		/// <summary>
		/// Fires when the find last event button is clicked.
		/// </summary>
		public event RoutedEventHandler FindingLastEvent;

		/// <summary>
		/// Fires when the moving left button is clicked.
		/// </summary>
		public event RoutedEventHandler MovingLeft;

		/// <summary>
		/// Fires when the moving right button is clicked.
		/// </summary>
		public event RoutedEventHandler MovingRight;

		/// <summary>
		/// Fires when the zooming in button is clicked.
		/// </summary>
		public event RoutedEventHandler ZoomingIn;

		/// <summary>
		/// Fires when the zooming out button is clicked.
		/// </summary>
		public event RoutedEventHandler ZoomingOut;

		#endregion


		static TimelineToolbox()
        {
#if !SILVERLIGHT
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TimelineToolbox), 
                new FrameworkPropertyMetadata(typeof(TimelineToolbox)));
#endif
        }

        public TimelineToolbox()
        {
#if SILVERLIGHT
            this.DefaultStyleKey = typeof(TimelineToolbox);
#endif
        }

        public void SetSite(
            ITimelineToolboxTarget                      target
        )
        {
            m_target = target;
        }

        public override void OnApplyTemplate(
        )
        {
            Utilities.Trace(this);

            base.OnApplyTemplate();
            m_grid = (Grid) GetTemplateChild(TP_MAIN_GRID_PART);

            if (m_grid != null)
            {
                HookButtonEvents(m_grid.Children);
            }
        }

        private void HookButtonEvents(
            UIElementCollection                         col
        )
        {
            Button                                      b;
            Panel                                       p;

            
            foreach (FrameworkElement el in col)
            {
                b = el as Button;
                p = el as Panel;

                if (b != null)
                {
                    b.Click += OnButtonClick;
                }
                else if (p != null)
                {
                    HookButtonEvents(p.Children);
                }
            }
        }

		/// <summary>
		/// Represents the handler that fires when buttons are clicked within the UI.
		/// </summary>
		/// <param name="sender">The button of the event.</param>
		/// <param name="e">The routed event arguments.</param>
        public void OnButtonClick(
            object                                      sender, 
            RoutedEventArgs                             e
        )
        {
            FrameworkElement                            el;

            Debug.Assert(m_target != null);

            el = (FrameworkElement) sender;

            switch (el.Name.ToLower())
            {
                case "fullscreen":
#if SILVERLIGHT
                    Application.Current.Host.Content.IsFullScreen = 
                        !Application.Current.Host.Content.IsFullScreen;
#endif
                    break;

                case "zoomin":
                    m_target.ZoomIn();
					this.OnZoomingIn(e);
                    break;

                case "zoomout":
                    m_target.ZoomOut();
					this.OnZoomingOut(e);
                    break;

                case "findfirst":
                    m_target.FindMinDate();
					this.OnFindingFirstEvent(e);
                    break;

                case "findlast":
                    m_target.FindMaxDate();
					this.OnFindingLastEvent(e);
                    break;

                case "moveleft":
                    m_target.MoveLeft();
					this.OnMovingLeft(e);
                    break;

                case "moveright":
                    m_target.MoveRight();
					this.OnMovingRight(e);
                    break;

                default:
                    throw new ArgumentException("Toolbox command cannot be found");
            }

		}


		#region " Private Methods "

		protected virtual void OnFindingFirstEvent(RoutedEventArgs e)
		{
			if (FindingFirstEvent != null)
				FindingFirstEvent(this, e);
		}

		protected virtual void OnFindingLastEvent(RoutedEventArgs e)
		{
			if (FindingLastEvent != null)
				FindingLastEvent(this, e);
		}

		protected virtual void OnMovingLeft(RoutedEventArgs e)
		{
			if (MovingLeft != null)
				MovingLeft(this, e);
		}

		protected virtual void OnMovingRight(RoutedEventArgs e)
		{
			if (MovingRight != null)
				MovingRight(this, e);
		}

		protected virtual void OnZoomingIn(RoutedEventArgs e)
		{
			if (ZoomingIn != null)
				ZoomingIn(this, e);
		}

		protected virtual void OnZoomingOut(RoutedEventArgs e)
		{
			if (ZoomingOut != null)
				ZoomingOut(this, e);
		}

		#endregion
	}
}
