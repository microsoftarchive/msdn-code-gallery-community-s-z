// -----------------------------------------------------------------------
// <copyright file="KinectSensorChooser.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Kinect.Toolkit
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.IO;
    using Microsoft.Kinect;

    /// <summary>
    /// Sensor chooser has three high-level states:
    ///    ChooserStatus.None - chooser hasn't been started or is stopped
    ///    ChooserStatus.SensorStarted - chooser has found and started a sensor for you.
    ///    ChooserStatus.[everything else] - chooser has not found you a sensor and here is why.
    /// Because there may be multiple sensors connected to the system, multiple flags
    /// may get set when the chooser cannot get you a sensor.
    /// </summary>
    [Flags]
    public enum ChooserStatus
    {
        /// <summary>
        /// Chooser has not been started or it has been stopped
        /// </summary>
        None = 0x00000000,

        /// <summary>
        /// Don't have a sensor yet, some sensor is initializing, you may not get it
        /// </summary>
        SensorInitializing = 0x00000001,

        /// <summary>
        /// This KinectSensorChooser has a connected and started sensor.
        /// </summary>
        SensorStarted = 0x00000002,

        /// <summary>
        /// There are no sensors available on the system.  If one shows up
        /// we will try to use it automatically.
        /// </summary>
        NoAvailableSensors = 0x00000010,

        /// <summary>
        /// Available sensor is in use by another application
        /// </summary>
        SensorConflict = 0x00000020,

        /// <summary>
        /// The available sensor is not powered.  If it receives power we
        /// will try to use it automatically.
        /// </summary>
        SensorNotPowered = 0x00000040,

        /// <summary>
        /// There is not enough bandwidth on the USB controller available
        /// for this sensor.
        /// </summary>
        SensorInsufficientBandwidth = 0x00000080,

        /// <summary>
        /// Available sensor is not genuine.
        /// </summary>
        SensorNotGenuine = 0x00000100,

        /// <summary>
        /// Available sensor is not supported
        /// </summary>
        SensorNotSupported = 0x00000200,

        /// <summary>
        /// Available sensor has an error
        /// </summary>
        SensorError = 0x00000400,
    }

    /// <summary>
    /// Component that automatically finds a Kinect and handles updates
    /// to the sensor.
    /// </summary>
    public class KinectSensorChooser : INotifyPropertyChanged
    {
        private readonly object lockObject = new object();

        private readonly ContextEventWrapper<KinectChangedEventArgs> kinectChangedContextWrapper =
            new ContextEventWrapper<KinectChangedEventArgs>(ContextSynchronizationMethod.Post);

        private readonly ContextEventWrapper<PropertyChangedEventArgs> propertyChangedContextWrapper =
            new ContextEventWrapper<PropertyChangedEventArgs>(ContextSynchronizationMethod.Post);

        private readonly Dictionary<PropertyChangedEventHandler, EventHandler<PropertyChangedEventArgs>> changedHandlers =
            new Dictionary<PropertyChangedEventHandler, EventHandler<PropertyChangedEventArgs>>();

        private bool isStarted;
        private string requiredConnectionId;

        /// <summary>
        /// Event triggered when the choosen KinectSensor changed.  This is
        /// roughly equivalent to monitoring the PropertyChanged event
        /// and watching for the "Kinect" property.
        /// </summary>
        public event EventHandler<KinectChangedEventArgs> KinectChanged
        {
            // ContextEventWrapper<> is already thread safe so no locking
            add { this.kinectChangedContextWrapper.AddHandler(value); }

            remove { this.kinectChangedContextWrapper.RemoveHandler(value); }
        }

        public event PropertyChangedEventHandler PropertyChanged
        {
            // ContextEventWrapper<> needs EvendHandler<> defined
            // handlers.  PropertyChangedEventHandler is not like
            // that so we wrap it in a handler that is.  These
            // handlers need to be tracked so the proper thing
            // gets removed.
            // Need to lock to protect the changedHandlers data.
            add
            {
                lock (lockObject)
                {
                    EventHandler<PropertyChangedEventArgs> handler = (sender, args) => value(sender, args);
                    changedHandlers[value] = handler;
                    this.propertyChangedContextWrapper.AddHandler(handler);
                }
            }

            remove
            {
                lock (lockObject)
                {
                    EventHandler<PropertyChangedEventArgs> handler = changedHandlers[value];
                    changedHandlers.Remove(value);
                    this.propertyChangedContextWrapper.RemoveHandler(handler);
                }
            }
        }

        /// <summary>
        /// The DeviceConnectionId for the sensor.  Set this to null to
        /// have the KinectSensorChooser find the first available sensor.
        /// </summary>
        public string RequiredConnectionId
        {
            get
            {
                return requiredConnectionId;
            }

            set
            {
                if (value == requiredConnectionId)
                {
                    return;
                }

                using (var callbackLock = new CallbackLock(lockObject))
                {
                    // Check again in case someone else changed something
                    // while we were waiting on the lock.
                    if (value == requiredConnectionId)
                    {
                        // We are already looking for the sensor they want.
                        return;
                    }

                    requiredConnectionId = value;

                    if (requiredConnectionId == null)
                    {
                        // We went from having a required connection id
                        // to not having one.  Nothing more to do.
                        return;
                    }

                    if (this.Kinect != null && this.Kinect.DeviceConnectionId == requiredConnectionId)
                    {
                        // The sensor we have happens to be the one they asked for.
                        return;
                    }

                    // We either have no sensor or the sensor we have isn't the one they asked for
                    TryFindAndStartKinect(callbackLock);
                }
            }
        }

        /// <summary>
        /// The sensor that this component has connected to.
        /// When this changes clients will get INotifyPropertyChanged events.
        /// </summary>
        public KinectSensor Kinect { get; private set; }

        /// <summary>
        /// The status of the current sensor or why we cannot retrieve a sensor.
        /// When this changes clients will get INotifyPropertyChanged events.
        /// </summary>
        public ChooserStatus Status { get; private set; }

        /// <summary>
        /// Starts choosing a sensor.  In the typical case, a sensor will
        /// be found and events will be fired before this function returns.
        /// </summary>
        public void Start()
        {
            if (!isStarted)
            {
                using (var callbackLock = new CallbackLock(lockObject))
                {
                    // Check again in case someone else started while
                    // we were waiting on the lock.
                    if (!isStarted)
                    {
                        isStarted = true;

                        KinectSensor.KinectSensors.StatusChanged += KinectSensorsOnStatusChanged;

                        TryFindAndStartKinect(callbackLock);
                    }
                }
            }
        }

        /// <summary>
        /// Gives up the current sensor if it has one.  Stops watching for new sensors.
        /// </summary>
        public void Stop()
        {
            if (isStarted)
            {
                using (var callbackLock = new CallbackLock(lockObject))
                {
                    // Check again in case someone stopped us while
                    // we were waiting on the lock.
                    if (isStarted)
                    {
                        isStarted = false;

                        KinectSensor.KinectSensors.StatusChanged -= KinectSensorsOnStatusChanged;

                        SetSensorAndStatus(callbackLock, null, ChooserStatus.None);
                    }
                }
            }
        }

        /// <summary>
        /// Called to retry finding a sensor when the SensorConflict or
        /// NoAvailableSensors flags are set.
        /// </summary>
        public void TryResolveConflict()
        {
            using (var callbackLock = new CallbackLock(lockObject))
            {
                TryFindAndStartKinect(callbackLock);
            }
        }

        private static ChooserStatus GetErrorStatusFromSensor(KinectSensor sensor)
        {
            ChooserStatus retval;
            switch (sensor.Status)
            {
            case KinectStatus.Undefined:
                retval = ChooserStatus.SensorError;
                break;
            case KinectStatus.Disconnected:
                retval = ChooserStatus.SensorError;
                break;
            case KinectStatus.Connected:
                // not an error state
                retval = 0;
                break;
            case KinectStatus.Initializing:
                retval = ChooserStatus.SensorInitializing;
                break;
            case KinectStatus.Error:
                retval = ChooserStatus.SensorError;
                break;
            case KinectStatus.NotPowered:
                retval = ChooserStatus.SensorNotPowered;
                break;
            case KinectStatus.NotReady:
                retval = ChooserStatus.SensorError;
                break;
            case KinectStatus.DeviceNotGenuine:
                retval = ChooserStatus.SensorNotGenuine;
                break;
            case KinectStatus.DeviceNotSupported:
                retval = ChooserStatus.SensorNotSupported;
                break;
            case KinectStatus.InsufficientBandwidth:
                retval = ChooserStatus.SensorInsufficientBandwidth;
                break;
            default:
                throw new ArgumentOutOfRangeException("sensor");
            }

            return retval;
        }

        private void KinectSensorsOnStatusChanged(object sender, StatusChangedEventArgs e)
        {
            if (e != null)
            {
                if ((e.Sensor == this.Kinect) || (this.Kinect == null))
                {
                    using (var callbackLock = new CallbackLock(lockObject))
                    {
                        // Check again in case things changed while we were
                        // waiting on the lock.
                        if ((e.Sensor == this.Kinect) || (this.Kinect == null))
                        {
                            // Something about our sensor changed or we don't have a sensor.
                            TryFindAndStartKinect(callbackLock);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Helper to update our external status.
        /// </summary>
        /// <param name="callbackLock">Used to delay notifications to the client until after we exit the lock.</param>
        /// <param name="newKinect">The new sensor</param>
        /// <param name="newChooserStatus">The status we want to report to clients</param>
        private void SetSensorAndStatus(CallbackLock callbackLock, KinectSensor newKinect, ChooserStatus newChooserStatus)
        {
            KinectSensor oldKinect = Kinect;
            if (oldKinect != newKinect)
            {
                if (oldKinect != null)
                {
                    oldKinect.Stop();
                }

                Kinect = newKinect;

                callbackLock.LockExit += () => this.kinectChangedContextWrapper.Invoke(this, new KinectChangedEventArgs(oldKinect, newKinect));
                callbackLock.LockExit += () => RaisePropertyChanged("Kinect");
            }

            if (Status != newChooserStatus)
            {
                Status = newChooserStatus;

                callbackLock.LockExit += () => RaisePropertyChanged("Status");
            }
        }

        /// <summary>
        /// Called when we don't have a sensor or possibly have the wrong sensor
        /// and we want to see if we can get one.
        /// </summary>
        private void TryFindAndStartKinect(CallbackLock callbackLock)
        {
            if (!isStarted)
            {
                // We aren't started so we don't need to be finding anything.
                Debug.Assert(Status == ChooserStatus.None, "isStarted and Status out of sync");
                return;
            }

            if (Kinect != null && Kinect.Status == KinectStatus.Connected)
            {
                if (requiredConnectionId == null)
                {
                    // we already have an appropriate sensor
                    Debug.Assert(Status == ChooserStatus.SensorStarted, "Chooser in unexpected state");
                    return;
                }

                if (Kinect.DeviceConnectionId == requiredConnectionId)
                {
                    // we already have the requested sensor
                    Debug.Assert(Status == ChooserStatus.SensorStarted, "Chooser in unexpected state");
                    return;
                }
            }

            KinectSensor newSensor = null;
            ChooserStatus newStatus = 0;

            if (KinectSensor.KinectSensors.Count == 0)
            {
                newStatus = ChooserStatus.NoAvailableSensors;
            }
            else
            {
                foreach (KinectSensor sensor in KinectSensor.KinectSensors)
                {
                    if (requiredConnectionId != null && sensor.DeviceConnectionId != requiredConnectionId)
                    {
                        // client has set a required connection Id and this
                        // sensor does not have that Id
                        newStatus |= ChooserStatus.NoAvailableSensors;
                        continue;
                    }

                    if (sensor.Status != KinectStatus.Connected)
                    {
                        // Sensor is in some unusable state
                        newStatus |= GetErrorStatusFromSensor(sensor);
                        continue;
                    }

                    if (sensor.IsRunning)
                    {
                        // Sensor is already in use by this application
                        newStatus |= ChooserStatus.NoAvailableSensors;
                        continue;
                    }

                    // There is a potentially available sensor, try to start it
                    try
                    {
                        sensor.Start();
                    }
                    catch (IOException)
                    {
                        // some other app has this sensor.
                        newStatus |= ChooserStatus.SensorConflict;
                        continue;
                    }
                    catch (InvalidOperationException)
                    {
                        // TODO: In multi-proc scenarios, this is getting thrown at the start before we see IOException.  Need to understand.
                        // some other app has this sensor.
                        newStatus |= ChooserStatus.SensorConflict;
                        continue;
                    }

                    // Woo hoo, we have a started sensor.
                    newStatus = ChooserStatus.SensorStarted;
                    newSensor = sensor;
                    break;
                }
            }

            SetSensorAndStatus(callbackLock, newSensor, newStatus);
        }

        private void RaisePropertyChanged(string propertyName)
        {
            // We should never be in a lock at this point.
            this.propertyChangedContextWrapper.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
