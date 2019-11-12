// -----------------------------------------------------------------------
// <copyright file="KinectChangedEventArgs.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Kinect.Toolkit
{
    using System;
    using Microsoft.Kinect;

    /// <summary>
    /// Args for the KinectChanged event
    /// </summary>
    public class KinectChangedEventArgs : EventArgs
    {
        public KinectChangedEventArgs(KinectSensor oldSensor, KinectSensor newSensor)
        {
            this.OldSensor = oldSensor;
            this.NewSensor = newSensor;
        }

        public KinectSensor OldSensor { get; private set; }

        public KinectSensor NewSensor { get; private set; }
    }
}