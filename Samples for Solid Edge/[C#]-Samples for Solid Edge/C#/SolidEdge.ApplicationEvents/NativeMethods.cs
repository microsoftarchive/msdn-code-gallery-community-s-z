using System;
using System.Runtime.InteropServices;

namespace SolidEdge.ApplicationEvents
{
    /// <summary>
    /// Static class containing PInvoke signatures.
    /// </summary>
    static class NativeMethods
    {
        #region ObjIdl.h

        internal enum SERVERCALL
        {
            SERVERCALL_ISHANDLED = 0,
            SERVERCALL_REJECTED = 1,
            SERVERCALL_RETRYLATER = 2
        }

        internal enum PENDINGMSG
        {
            PENDINGMSG_CANCELCALL = 0,
            PENDINGMSG_WAITNOPROCESS = 1,
            PENDINGMSG_WAITDEFPROCESS = 2
        }

        #endregion

        #region WinError.h

        internal const int MK_E_UNAVAILABLE = (int)(0x800401E3 - 0x100000000);
        internal const int CO_E_NOT_SUPPORTED = (int)(0x80004021 - 0x100000000);

        #endregion

        [DllImport("Ole32.dll")]
        internal static extern int CoRegisterMessageFilter(IMessageFilter newFilter, out IMessageFilter oldFilter);
    }
}
