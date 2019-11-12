// -----------------------------------------------------------------------
// <copyright file="CallbackLock.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Kinect.Toolkit
{
    using System;
    using System.Threading;

    /// <summary>
    /// Utility class that encapsulates critical section-like locking
    /// and an event that gets fired after we exit the lock.  It's
    /// purpose in life is to delay calling event handlers until after
    /// we exit the lock.  If you call event handlers while you hold a
    /// lock it's easy to deadlock.  Those event handlers could
    /// choose to block on something on a diffrent thread that's
    /// waiting on our lock.
    /// </summary>
    internal class CallbackLock : IDisposable
    {
        private readonly object lockObject;

        public CallbackLock(object lockObject)
        {
            this.lockObject = lockObject;
            Monitor.Enter(lockObject);
        }

        public delegate void LockExitEventHandler();

        public event LockExitEventHandler LockExit;

        public void Dispose()
        {
            Monitor.Exit(lockObject);
            if (LockExit != null)
            {
                LockExit();
            }
        }
    }
}
