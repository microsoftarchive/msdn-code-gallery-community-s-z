//=======================================================================================
// Microsoft Windows Azure Customer Advisory Team (CAT) Best Practices Series
//
// This sample is supplemental to the technical guidance published on the community
// blog at http://windowsazurecat.com/. 
//
//=======================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
// EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
// MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=======================================================================================
namespace Microsoft.AzureCAT.Samples.InterRoleCommunication.Framework.Instrumentation
{
    #region Using statements
    using System;
    using System.Runtime.InteropServices;
    #endregion

    /// <summary>
    /// Provides the implementation of a high-resolution timer.
    /// </summary>
    public sealed class HighResolutionTimer
    {
        #region Private members
        private static readonly HighResolutionTimer singleton = new HighResolutionTimer();
        private static readonly double tickFrequency;
        
        private const long TicksPerMillisecond = 0x2710L;
        private const string KernelLib = "kernel32.dll";

        [DllImport(KernelLib)]
        private static extern bool QueryPerformanceCounter(out long value);

        [DllImport(KernelLib)]
        private static extern bool QueryPerformanceFrequency(out long value);
        #endregion

        #region Constructor
        static HighResolutionTimer()
        {
            long frequency = 0;

            if (QueryPerformanceFrequency(out frequency))
            {
                IsHighResolution = true;
                Frequency = frequency;
                tickFrequency = 10000000.0;
                tickFrequency /= (double)Frequency;
            }
            else
            {
                IsHighResolution = false;
                Frequency = 0x989680L;
                tickFrequency = 1.0;
            }
        } 
        #endregion

        #region Public methods
        /// <summary>
        /// Returns the frequency of the high-resolution timer, if one exists.
        /// </summary>
        public static long Frequency
        {
            get;
            private set;
        }

        /// <summary>
        /// Indicates whether the timer is based on a high-resolution performance counter.
        /// </summary>
        public static bool IsHighResolution
        {
            get;
            private set;
        }

        /// <summary>
        /// Returns the current value of the high-resolution timer. 
        /// </summary>
        public long TickCount
        {
            get
            {
                if (IsHighResolution)
                {
                    long tickCount = 0;

                    QueryPerformanceCounter(out tickCount);
                    return tickCount;
                }

                // Otherwise, use DateTime's tick count.
                return DateTime.UtcNow.Ticks;
            }
        }

        /// <summary>
        /// Returns a singleton instance of the <see cref="HighResolutionTimer"/> object.
        /// </summary>
        public static HighResolutionTimer Current
        {
            get { return singleton; }
        }

        /// <summary>
        /// Returns the current value of the high-resolution timer. 
        /// </summary>
        public static long CurrentTickCount
        {
            get { return singleton.TickCount; }
        }

        /// <summary>
        /// Gets the total elapsed time (in milliseconds) measured by taking into account the specified start timer value. 
        /// </summary>
        /// <param name="startTicks">The start timer value.</param>
        /// <returns>The total elapsed time in milliseconds.</returns>
        public long GetElapsedMilliseconds(long startTicks)
        {
            return GetElapsedDateTimeTicks(startTicks, TickCount) / TicksPerMillisecond;
        }

        /// <summary>
        /// Gets the total elapsed time (in milliseconds) measured between the two specified timer values. 
        /// </summary>
        /// <param name="startTicks">The start timer value.</param>
        /// <param name="finishTicks">The finish timer value.</param>
        /// <returns>The calculated the number of ticks.</returns>
        public long GetElapsedMilliseconds(long startTicks, long finishTicks)
        {
            return GetElapsedDateTimeTicks(startTicks, finishTicks) / TicksPerMillisecond;
        } 
        #endregion

        #region Private methods
        /// <summary>
        /// Gets the number of ticks that represent the date and time measured by taking into account the specified start timer value.
        /// </summary>
        /// <param name="startTicks">The start timer value.</param>
        /// <param name="finishTicks">The finish timer value.</param>
        /// <returns>The calculated the number of ticks.</returns>
        private long GetElapsedDateTimeTicks(long startTicks, long finishTicks)
        {
            if (finishTicks >= startTicks)
            {
                long rawElapsedTicks = finishTicks - startTicks;

                if (IsHighResolution)
                {
                    double ticks = rawElapsedTicks;
                    ticks *= tickFrequency;
                    return (long)ticks;
                }

                return rawElapsedTicks;
            }
            else return 0;
        } 
        #endregion
    }
}
