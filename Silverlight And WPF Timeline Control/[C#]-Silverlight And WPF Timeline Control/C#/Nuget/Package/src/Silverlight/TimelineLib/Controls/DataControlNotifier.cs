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
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows;

namespace TimelineLibrary
{
    /// 
    /// <summary>
    /// This class aggregates resize events of TimelineBand controls and loadcomplete of datasources, so
    /// that we know when all controls are resized and all xml files downloaded.</summary>
    /// 
    public class DataControlNotifier
    {
        #region Private Fields
        
        List<TimelineBand>                              m_elements;
        private TimelineUrlCollection                   m_urls;
        private List<Stream>                            m_streams;

        private int                                     m_dataLoadCount;
        private int                                     m_sizeCount;
        private bool                                    m_started;
        
        #endregion

        public event EventHandler                       LoadComplete;

        #region Ctors

        public DataControlNotifier(
        )
        {
            m_elements = new List<TimelineBand>();
            m_urls = new TimelineUrlCollection();
            m_streams = new List<Stream>();
        }

        public DataControlNotifier(
            TimelineUrlCollection                       urls,
            List<TimelineBand>                          bands
        )
        {
            m_elements = bands;
            m_urls = urls;
            m_streams = new List<Stream>();

            foreach (FrameworkElement e in m_elements)
            {
                if (e.ActualWidth != 0)
                {
                    m_sizeCount++;
#if !SILVERLIGHT
                    CheckCompleted();
#endif
                }
                else
                {
                    e.SizeChanged += OnSizeChanged;
                }
            }

            StartDataDownload();
        }

        #endregion

        #region Public Methods and Properties

        public void AddElement(
            TimelineBand                                band
        )
        {
            Debug.Assert(band != null);

            band.SizeChanged += OnSizeChanged;
            m_elements.Add(band);
        }

        public void AddUrls(
            TimelineUrlCollection                       urls
        )
        {
           Debug.Assert(urls != null);

           m_urls = urls;
           StartDataDownload();
        }

        /// 
        /// <summary>
        /// After the class issues LoadComplete event this list contains
        /// all streams with data xmls from urls passed through AddUrls method</summary>
        /// 
        public List<Stream> StreamList
        {
            get
            {
                return m_streams;
            }
        }

        public void Start(
        )
        {
            Debug.Assert(LoadComplete != null);

            Utilities.Trace(this);

            m_started = true;
        }

        /// 
        /// <summary>
        /// Checks that all controls resized and all data received</summary>
        /// 
        public void CheckCompleted(
        )
        {
            if (m_started && 
                m_sizeCount == m_elements.Count && 
                m_dataLoadCount == m_urls.Count &&
                LoadComplete != null)
            {
                Utilities.Trace(this, "All data collected and all controls resized.");
                LoadComplete(this, new EventArgs());
                m_started = false;
                m_sizeCount = 0;
            }
        }

        #endregion

        #region Private Methods and Properties

        private void StartDataDownload(
        )
        {
            WebClient                                   client;

            foreach (UriInfo i in m_urls)
            {
                client = new WebClient();
                client.OpenReadCompleted += OnDataReadCompleted;
                client.OpenReadAsync(i.Url);
            }
        }


        private void OnSizeChanged(
            object                                      sender, 
            RoutedEventArgs                             e
        )
        {
            ((FrameworkElement) sender).SizeChanged -= OnSizeChanged;
            
            ++m_sizeCount;

            CheckCompleted();
        }

        /// 
        /// <summary>
        /// Occures every time next xml data file is available or error</summary>
        /// 
        private void OnDataReadCompleted(
            object                                      sender, 
            OpenReadCompletedEventArgs                  args
        )
        {
            Utilities.Trace(this);

            ++m_dataLoadCount;

            if (!args.Cancelled && args.Error == null)
            {
                m_streams.Add(args.Result);
            }
            CheckCompleted();

        }
        #endregion 
    }
}
