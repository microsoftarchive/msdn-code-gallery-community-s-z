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
using System.Linq;
using System.Windows;
using System.Windows.Browser;
using System.Windows.Controls;
using System.Windows.Input;
using TimelineLibrary;

namespace Timeline
{
    [ScriptableType]
    public partial class TimelinePage : UserControl
    {
        private string                                  m_urls;

        public TimelinePage(
        )
        {
            InitializeComponent();
            HtmlPage.RegisterScriptableObject("Instance", this);

            this.KeyDown += new KeyEventHandler(OnKeyDown);
        }

        void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Application.Current.Host.Content.IsFullScreen = 
                    !Application.Current.Host.Content.IsFullScreen;
            }
        }

        #region Scriptable Members

        [ScriptableMember]
        public string Urls
        {
            get
            {
                return m_urls;
            }
            set
            {
                string[]                                urls;
                UriInfo                                 info;

                urls = value.Split(';');
                
                for (int i = 0; i < urls.Count(); ++i)
                {
                    info = new UriInfo();
                    info.Url = new Uri(urls[i], UriKind.RelativeOrAbsolute);

                    Timeline.Urls.Add(info);
                }

                m_urls = value;
            }
        }

        [ScriptableMember]
        public void AddTimelineToolbox(
        )
        {
           Timeline.AddTimelineToolbox();
        }

        [ScriptableMember]
        public string CurrentDateTime
        {
            get
            {
                return Timeline.CurrentDateTime.ToString();
            }
            set
            {
                Timeline.CurrentDateTime = DateTime.Parse(value, Timeline.CultureInfo);
            }
        }

        [ScriptableMember]
        public string MoreLinkText
        {
            get
            {
                return Timeline.MoreLinkText;
            }
            set
            {
                Timeline.MoreLinkText = value;
            }
        }

        [ScriptableMember]
        public int TeaserSize
        {
            get
            {
                return Timeline.TeaserSize;
            }
            set
            {
                Timeline.TeaserSize = value;
            }
        }

        [ScriptableMember]
        public string CultureID
        {
            get
            {
                return Timeline.CultureID;
            }
            set
            {
                Timeline.CultureID = value;
            }
        }

        [ScriptableMember]
        public string CalendarType
        {
            get
            {
                return Timeline.CalendarType;
            }
            set
            {
                Timeline.CalendarType = value;
            }
        }

        [ScriptableMember]
        public void AddTimelineBand(
            int                                         height,
            bool                                        isMain, 
            string                                      srcType, 
            int                                         columnsCount,
            int                                         maxEventHeight
        )
        {
            Timeline.AddTimelineBand(height, isMain, srcType, columnsCount, maxEventHeight);
        }

        [ScriptableMember]
        public void Run()
        {
            Timeline.Run();           
        }

        [ScriptableMember]
        public string MinDateTime
        {
            get
            {
                return Timeline.MinDateTime.ToString();
            }
            set
            {
                Timeline.MinDateTime = DateTime.Parse(value, Timeline.CultureInfo);
            }
        }

        [ScriptableMember]
        public string MaxDateTime
        {
            get
            {
                return Timeline.MaxDateTime.ToString();
            }
            set
            {
                Timeline.MaxDateTime = DateTime.Parse(value, Timeline.CultureInfo);
            }
        }

        [ScriptableMember]
        public bool ImmediateDisplay
        {
            get
            {
                return Timeline.ImmediateDisplay;
            }
            set
            {
                Timeline.ImmediateDisplay = (bool) value;
            }
        }

        [ScriptableMember]
        public void ResetEvents(
            string                                      xml
        )
        {
            Timeline.ResetEvents(xml);
        }

        [ScriptableMember]
        public void ClearEvents(
        )
        {
            Timeline.ClearEvents();
        }

        #endregion
    }
}
