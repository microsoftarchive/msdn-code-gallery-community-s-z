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
using System.Net;
using System.Collections;
using System.Diagnostics;
using System.Globalization;

namespace TimelineLibrary
{
    public enum TimelineCalendarType
    {
        Decades,
        Years,
        Months,
        Days,
        Hours,
        Minutes10,
        Minutes,
        Seconds,
        Milliseconds100,
        Milliseconds10,
        Milliseconds
    }

    /// 
    /// <summary>
    /// Time calculator used by timeline bands</summary>
    /// 
    public class TimelineCalendar
    {
        private TimelineCalendarType                    m_type;
        private static TimeSpan                         TICK = new TimeSpan((long)1);
        private Calendar                                m_calendar;  
        private DateTime                                m_minDate;
        private DateTime                                m_maxDate;
        private bool                                    m_is24hFormat = false;
    
        public TimelineCalendar(             
            string                                      cultureCalendar,
            TimelineCalendarType                        itemType,
            DateTime                                    minDateTime,
            DateTime                                    maxDateTime
        )
        {
            m_type = itemType;
            m_calendar = CalendarFromString(cultureCalendar);
            m_minDate = minDateTime;
            m_maxDate = maxDateTime;
        }

        public bool TimeFormat24
        {
            get
            {
                return m_is24hFormat;
            }
            set
            {
                m_is24hFormat = value;
            }
        }

        public DateTime MinDateTime
        {
            set
            {
                m_minDate = value;
            }

            get
            {
                return m_minDate;
            }
        }

        public DateTime MaxDateTime
        {
            set
            {
                m_maxDate = value;
            }

            get
            {
                return m_maxDate;
            }
        }

        public TimelineCalendarType LineType
        {
            get
            {
                return m_type;
            }
        }

        public Calendar Calendar
        {
            get
            {
                return m_calendar;
            }
        }

        public long IndexOf(
            DateTime                                    value
            )
        {
            DateTime                                    d;
            long                                        ret;
            TimeSpan                                    span;
            DateTime                                    start;

            Debug.Assert(value != null);

            d = (DateTime) value;
            start = DateTime.MinValue;
            span = d - start;

            switch (m_type)
            {
                case TimelineCalendarType.Decades:
                    ret = d.Year / 10 - start.Year / 10;
                    break;

                case TimelineCalendarType.Years:
                    ret = d.Year - start.Year;
                    break;

                case TimelineCalendarType.Months:
                    ret = d.Year * 12 + d.Month - start.Year * 12 - start.Month;
                    break;

                case TimelineCalendarType.Days:
                    ret = (long) span.TotalDays;
                    break;

                case TimelineCalendarType.Hours:
                    ret = (long) span.TotalHours;
                    break;

                case TimelineCalendarType.Minutes10:
                    ret = (long) (span.TotalMinutes / 10);
                    break;

                case TimelineCalendarType.Minutes: 
                    ret = (long) span.TotalMinutes;
                    break;

                case TimelineCalendarType.Seconds:
                    ret = (long) span.TotalSeconds;
                    break;

                case TimelineCalendarType.Milliseconds100:
                    ret = (long) span.TotalMilliseconds / 100;
                    break;                

                case TimelineCalendarType.Milliseconds10:
                    ret = (long) span.TotalMilliseconds / 10;
                    break;

                case TimelineCalendarType.Milliseconds:
                    ret = (long) span.TotalMilliseconds;
                    break;

                default:
                   throw new ArgumentOutOfRangeException();
            }
            
            return ret;
        }
     
        public DateTime this[
            long                                        index
        ]
        {
            get
            {
                DateTime                                ret;
                DateTime                                start;
                DateTime                                end;

                Debug.Assert(index > -1);

                start = DateTime.MinValue;
                end = DateTime.MaxValue;

                switch (m_type)
                {
                    case TimelineCalendarType.Decades:
                        ret = start.AddYears((int) index * 10);
                        break;

                    case TimelineCalendarType.Years:
                        ret = start.AddYears((int) index);
                        break;

                    case TimelineCalendarType.Months:
                        ret = start.AddMonths((int) index);
                        break;

                    case TimelineCalendarType.Days:
                        ret = start.AddDays(index);
                        break;

                    case TimelineCalendarType.Hours:
                        ret = start.AddHours(index);
                        break;

                    case TimelineCalendarType.Minutes10:
                        ret = start.AddMinutes(index * 10);
                        break;

                    case TimelineCalendarType.Minutes: 
                        ret = start.AddMinutes(index);
                        break;

                    case TimelineCalendarType.Seconds:
                        ret = start.AddSeconds(index);
                        break;

                    case TimelineCalendarType.Milliseconds100:
                        ret = start.AddMilliseconds(index * 100);
                        break;                

                    case TimelineCalendarType.Milliseconds10:
                        ret = start.AddMilliseconds(index * 10);
                        break;

                    case TimelineCalendarType.Milliseconds:
                        ret = start.AddMilliseconds(index);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                
                return ret;
            }
        }

        public bool IsValidIndex(long index)
        {
            bool                                    ret;
            DateTime                                start;
            DateTime                                end;
            DateTime                                d;

            ret = false;

            if (index >= 0)
            {
                start = DateTime.MinValue;
                end = DateTime.MaxValue;

                try
                {
                    switch (m_type)
                    {
                        case TimelineCalendarType.Decades:
                            d = start.AddYears((int) index * 10);
                            break;

                        case TimelineCalendarType.Years:
                            d = start.AddYears((int) index);
                            break;

                        case TimelineCalendarType.Months:
                            d = start.AddMonths((int) index);
                            break;

                        case TimelineCalendarType.Days:
                            d = start.AddDays(index);
                            break;

                        case TimelineCalendarType.Hours:
                            d = start.AddHours(index);
                            break;

                        case TimelineCalendarType.Minutes10:
                            d = start.AddMinutes(index * 10);
                            break;

                        case TimelineCalendarType.Minutes: 
                            d = start.AddMinutes(index);
                            break;

                        case TimelineCalendarType.Seconds:
                            d = start.AddSeconds(index);
                            break;

                        case TimelineCalendarType.Milliseconds100:
                            d = start.AddMilliseconds(index * 100);
                            break;                

                        case TimelineCalendarType.Milliseconds10:
                            d = start.AddMilliseconds(index * 10);
                            break;

                        case TimelineCalendarType.Milliseconds:
                            d = start.AddMilliseconds(index);
                            break;

                    }
                    ret = true;
                }
                catch(ArgumentOutOfRangeException)
                {
                    ret = false;
                }
            }
            
            return ret;
        }

        public static string ItemToString(
            TimelineCalendar                            src,
            DateTime                                    value
            )
        {
            DateTime                                    d;
            string                                      ret;
            TimelineCalendarType                        type;

            Debug.Assert(src as TimelineCalendar != null);
            Debug.Assert(value != null);

            d = (DateTime) value;
            type = ((TimelineCalendar) src).LineType;

            switch (type)
            {
                    
                case TimelineCalendarType.Decades:
                    ret = DateTimeConverter.GetDecades(d);
                    break;

                case TimelineCalendarType.Years:
                    ret = DateTimeConverter.GetYear(d);
                    break;

                case TimelineCalendarType.Months:
                    ret = DateTimeConverter.GetMonth(d);
                    break;

                case TimelineCalendarType.Days:
                    ret = DateTimeConverter.GetDay(d);
                    break;
                
                case TimelineCalendarType.Hours:
                    if (!src.m_is24hFormat)
                    {
                        ret = d.ToString("hh tt");
                    }
                    else
                    {
                        ret = d.ToString("HH");
                    }
                    break;

                case TimelineCalendarType.Minutes10:
                    if (d.Minute == 0)
                    {
                        ret = d.Hour.ToString() + ":00";
                    }
                    else 
                    {
                        ret = ((d.Minute / 10) * 10).ToString();
                    }
                    break;

                case TimelineCalendarType.Minutes: 
                    ret = d.ToString("mm");
                    break;

                case TimelineCalendarType.Seconds:
                    ret = d.Second.ToString();
                    break;

                case TimelineCalendarType.Milliseconds100:
                    ret = (d.Millisecond / 100).ToString();
                    break;                

                case TimelineCalendarType.Milliseconds10:
                    ret = (d.Millisecond / 10).ToString();
                    break;

                case TimelineCalendarType.Milliseconds:
                    ret = (d.Millisecond).ToString();
                    break;

                default:
                   throw new ArgumentOutOfRangeException();
            }
            
            return ret;
        }

        public DateTime GetFloorTime(
            DateTime                                    dt
        )
        {
            DateTime                                    date;
            int                                         year;

            date = dt;

            switch (m_type)
            {
                case TimelineCalendarType.Milliseconds:
                    date = new DateTime(date.Year, date.Month, date.Day, date.Hour,
                        date.Minute, date.Second, date.Millisecond);
                    break;

                case TimelineCalendarType.Milliseconds10:
                    date = new DateTime(date.Year, date.Month, date.Day, date.Hour,
                        date.Minute, date.Second, date.Millisecond - date.Millisecond % 10);
                    break;

                case TimelineCalendarType.Milliseconds100:
                    date = new DateTime(date.Year, date.Month, date.Day, date.Hour,
                        date.Minute, date.Second, date.Millisecond - date.Millisecond % 100);
                    break;

                case TimelineCalendarType.Seconds:
                    date = new DateTime(date.Year, date.Month, date.Day, date.Hour,
                        date.Minute, date.Second);
                    break;
               
                case TimelineCalendarType.Minutes10:
                    date = new DateTime(date.Year, date.Month, date.Day, date.Hour, 
                        date.Minute - date.Minute % 10, 0); 
                    break;

                case TimelineCalendarType.Minutes: 
                    date = new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, 
                        0);
                    break;

                case TimelineCalendarType.Hours:
                    date = new DateTime(date.Year, date.Month, date.Day, date.Hour, 0, 0, 
                        m_calendar);
                    break;

                case TimelineCalendarType.Days:
                    date = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 
                        m_calendar);
                    break;

                case TimelineCalendarType.Months:
                    date = new DateTime(date.Year, date.Month, 1, 0, 0, 0, 
                        m_calendar);
                    break;

                case TimelineCalendarType.Years:
                    date = new DateTime(date.Year, 1, 1, 0, 0, 0);
                    break;

                case TimelineCalendarType.Decades:
                    year = Math.Max(DateTime.MinValue.Year, date.Year - date.Year % 10);
                    date = new DateTime(year, 1, 1, 0, 0, 0);
                    break;

                default:
                   throw new ArgumentOutOfRangeException();
            }

            return date;
        }

        public DateTime GetCeilingTime(
            DateTime                                    dt
        )
        {
            long                                        index;
            DateTime                                    ret;

            Debug.Assert(dt != null); 

            index = IndexOf(dt);
            if (index >= IndexOf(DateTime.MaxValue))
            {
                ret = MaxDateTime;
            }
            else
            {
                if (this.IsValidIndex(IndexOf(dt) + 1))
                {
                    ret = this[IndexOf(dt) + 1] - TICK;
                }
                else
                {
                    ret = DateTime.MaxValue - TICK;
                }
            }

            if (ret > DateTime.MaxValue)
            {
                ret = MaxDateTime;
            }

            return ret;
        }

        public static Calendar CalendarFromString(
            string                                      name
        )
        {
            Calendar                                    c;

            if (name == null)
            {
                name = String.Empty;
            }

            switch (name.ToLower())
            {
                case "hebrew":
                    c = new HebrewCalendar();
                    break;

                case "hijri":
                    c = new HijriCalendar();
                    break;

                case "japanese":
                    c = new JapaneseCalendar();
                    break;

                case "korean":
                    c = new KoreanCalendar();
                    break;

                case "taiwan":
                    c = new TaiwanCalendar();
                    break;

                case "thaibuddhist":
                    c = new ThaiBuddhistCalendar();
                    break;

                case "umalqura":
                    c = new UmAlQuraCalendar();
                    break;
#if !SILVERLIGHT
                case "persian":
                    c = new PersianCalendar();
                    break;
#endif 
                default:
                    c = new GregorianCalendar();
                    break;
            }

            return c;
        }
    }
}

