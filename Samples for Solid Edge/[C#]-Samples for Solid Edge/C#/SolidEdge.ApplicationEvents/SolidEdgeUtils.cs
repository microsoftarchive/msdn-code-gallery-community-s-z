using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SolidEdge.ApplicationEvents 
{
    /// <summary>
    /// Solid Edge utility class.
    /// </summary>
    static class SolidEdgeUtils
    {
        /// <summary>
        /// Creates and returns a new instance of Solid Edge.
        /// </summary>
        /// <returns>
        /// An object of type SolidEdgeFramework.Application.
        /// </returns>
        public static SolidEdgeFramework.Application Start()
        {
            // On a system where Solid Edge is installed, the COM ProgID will be
            // defined in registry: HKEY_CLASSES_ROOT\SolidEdge.Application
            Type t = Type.GetTypeFromProgID(progID: "SolidEdge.Application", throwOnError: true);

            // Using the discovered Type, create and return a new instance of Solid Edge.
            return (SolidEdgeFramework.Application)Activator.CreateInstance(type: t);
        }

        /// <summary>
        /// Connects to a running instance of Solid Edge.
        /// </summary>
        /// <returns>
        /// An object of type SolidEdgeFramework.Application.
        /// </returns>
        public static SolidEdgeFramework.Application Connect()
        {
            return Connect(startIfNotRunning: false);
        }

        /// <summary>
        /// Connects to a running instance of Solid Edge with an option to start if not running.
        /// </summary>
        /// <returns>
        /// An object of type SolidEdgeFramework.Application.
        /// </returns>
        public static SolidEdgeFramework.Application Connect(bool startIfNotRunning)
        {
            try
            {
                // Attempt to connect to a running instance of Solid Edge.
                return (SolidEdgeFramework.Application)Marshal.GetActiveObject(progID: "SolidEdge.Application");
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                switch (ex.ErrorCode)
                {
                    // Solid Edge is not running.
                    case NativeMethods.MK_E_UNAVAILABLE:
                        if (startIfNotRunning)
                        {
                            // Start Solid Edge.
                            return Start();
                        }
                        else
                        {
                            // Rethrow exception.
                            throw;
                        }
                    default:
                        // Rethrow exception.
                        throw;
                }
            }
            catch
            {
                // Rethrow exception.
                throw;
            }
        }
    }
}
