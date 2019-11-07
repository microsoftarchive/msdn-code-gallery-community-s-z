using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace SolidEdge.SheetMetal.PhysicalProperties
{
    /// <summary>
    /// Class that implements the OLE IMessageFilter interface.
    /// </summary>
    internal class OleMessageFilter : IMessageFilter
    {
        /// <summary>
        /// Private constructor.
        /// </summary>
        /// <remarks>
        /// Instance of this class is only created by Register().
        /// </remarks>
        private OleMessageFilter()
        {
        }

        /// <summary>
        /// Destructor.
        /// </summary>
        ~OleMessageFilter()
        {
            // Call Unregister() for good measure. It's fine if this gets called twice.
            Unregister();
        }

        /// <summary>
        /// Registers this instance of IMessageFilter with OLE to handle concurrency issues on the current thread. 
        /// </summary>
        /// <remarks>
        /// Only one message filter can be registered for each thread.
        /// Threads in multithreaded apartments cannot have message filters.
        /// Thread.CurrentThread.GetApartmentState() must equal ApartmentState.STA. In console applications, this can
        /// be achieved by applying the STAThreadAttribute to the Main() method. In WinForm applications, it is default.
        /// </remarks>
        public static void Register()
        {
            IMessageFilter newFilter = new OleMessageFilter();
            IMessageFilter oldFilter = null;

            // 1st check the current thread's apartment state. It must be STA!
            if (Thread.CurrentThread.GetApartmentState() == ApartmentState.STA)
            {
                // Call CoRegisterMessageFilter().
                Marshal.ThrowExceptionForHR(NativeMethods.CoRegisterMessageFilter(newFilter: newFilter, oldFilter: out oldFilter));
            }
            else
            {
                throw new System.Exception("The current thread's apartment state must be STA.");
            }
        }

        /// <summary>
        /// Unregisters a previous instance of IMessageFilter with OLE on the current thread. 
        /// </summary>
        /// <remarks>
        /// It is not necessary to call Unregister() unless you need to explicitly do so as it is handled
        /// in the destructor.
        /// </remarks>
        public static void Unregister()
        {
            IMessageFilter oldFilter = null;

            // Call CoRegisterMessageFilter().
            NativeMethods.CoRegisterMessageFilter(newFilter: null, oldFilter: out oldFilter);
        }

        #region IMessageFilter

        public int HandleInComingCall(int dwCallType, IntPtr hTaskCaller, int dwTickCount, IntPtr lpInterfaceInfo)
        {
            return (int)NativeMethods.SERVERCALL.SERVERCALL_ISHANDLED;
        }

        public int MessagePending(IntPtr hTaskCallee, int dwTickCount, int dwPendingType)
        {
            // Cancel the outgoing call. This should be returned only under extreme conditions. Canceling a call that
            // has not replied or been rejected can create orphan transactions and lose resources. COM fails the original
            // call and returns RPC_E_CALL_CANCELLED.
            //return (int)NativeMethods.PENDINGMSG.PENDINGMSG_CANCELCALL;

            // Continue waiting for the reply, and do not dispatch the message unless it is a task-switching or
            // window-activation message. A subsequent message will trigger another call to MessagePending.
            //return (int)NativeMethods.PENDINGMSG.PENDINGMSG_WAITNOPROCESS;

            // Keyboard and mouse messages are no longer dispatched. However there are some cases where mouse and
            // keyboard messages could cause the system to deadlock, and in these cases, mouse and keyboard messages
            // are discarded. WM_PAINT messages are dispatched. Task-switching and activation messages are handled as before.
            return (int)NativeMethods.PENDINGMSG.PENDINGMSG_WAITDEFPROCESS;
        }

        public int RetryRejectedCall(IntPtr hTaskCallee, int dwTickCount, int dwRejectType)
        {
            if (dwRejectType == (int)NativeMethods.SERVERCALL.SERVERCALL_RETRYLATER)
            {
                // 0 ≤ value < 100
                // The call is to be retried immediately.
                return 99;

                // 100 ≤ value
                // COM will wait for this many milliseconds and then retry the call.
                // return 1000; // Wait 1 second before retrying the call.
            }

            // The call should be canceled. COM then returns RPC_E_CALL_REJECTED from the original method call.
            return -1;
        }

        #endregion
    }
}
