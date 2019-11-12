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
using System.Linq;
using System.Windows.Controls;
using TimelineLibrary;

namespace SLEventGenerator
{
    public partial class MainPage : UserControl
    {
        private EventGenerator                          m_generator = new EventGenerator();

        public MainPage(
        )
        {
            InitializeComponent();
        }

        private void UpdateTimeline(
        )
        {
            List<TimelineEvent>                         tles;
            DateTime                                    minDate;
            DateTime                                    maxDate;
            DateTime                                    initDate;
            Double                                      totalDays;

            //
            // get sorted list of events
            //
            tles = (from TimelineEvent tle in m_generator.Events
                    orderby tle.StartDate select tle).ToList();

            if (tles.Count > 0)
            {
                //
                // calc the range to display so its nicer to look at
                //
                minDate = tles.First().StartDate;
                maxDate = tles.Last().StartDate;
                initDate = maxDate;

                minDate = minDate.AddDays(-5);
                maxDate = maxDate.AddDays(5);

                totalDays = (maxDate - minDate).TotalDays;

                EventTLT.CurrentDateTime = initDate;

                EventTLT.MaxDateTime = DateTime.MaxValue;
                EventTLT.MinDateTime = minDate;
                EventTLT.MaxDateTime = maxDate;

                EventTLB.TimelineWindowSize = 2;
                EventTLB.ItemSourceType = "months";

                if (totalDays > 550)
                {
                    //
                    // many days so use years. At least show two, max 6.
                    //
                    EventScaleTLB.TimelineWindowSize = (int) Math.Min(Math.Max(
                        Math.Ceiling(totalDays / 365), 2), 6);

                    EventScaleTLB.ItemSourceType = "years";
                }
                else
                {
                    //
                    // not that many days so display months
                    //
                    EventScaleTLB.TimelineWindowSize = 12;
                    EventScaleTLB.ItemSourceType = "months";
                }
            }
            else
            {
                EventTLT.CurrentDateTime = DateTime.Now;

                EventTLT.MaxDateTime = DateTime.MaxValue;
                EventTLT.MinDateTime = DateTime.Now.AddMonths(-2);
                EventTLT.MaxDateTime = DateTime.Now.AddMonths(1);

                EventTLB.TimelineWindowSize = 2;
                EventTLB.ItemSourceType = "months";

                EventScaleTLB.TimelineWindowSize = 12;
                EventScaleTLB.ItemSourceType = "months";
            }

            //
            // update event bands
            //
            EventTLT.ResetEvents(tles);
            EventTLT.Reload();
        }

        private void ClearBtn_Click(
            object                                      sender, 
            System.Windows.RoutedEventArgs              e
        )
        {
            m_generator.Events.Clear();
            UpdateTimeline();
        }

        private void GenerateBtn_Click(
            object                                      sender, 
            System.Windows.RoutedEventArgs              e
        )
        {
            m_generator.GenerateEvents(15);
            UpdateTimeline();
        }

        private void UserControl_Loaded(
            object                                      sender, 
            System.Windows.RoutedEventArgs              e
        )
        {
            m_generator.GenerateEvents(20);
            UpdateTimeline();
        }
    }
}
