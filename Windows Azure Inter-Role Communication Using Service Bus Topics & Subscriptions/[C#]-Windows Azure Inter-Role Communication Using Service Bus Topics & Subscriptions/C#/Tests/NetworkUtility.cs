using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using ROOT.CIMV2.Win32;

namespace Microsoft.AzureCAT.Samples.InterRoleCommunication.Tests
{
    public static class NetworkUtility
    {
        public static void DisableNetworkAdapter()
        {
            SelectQuery query = new SelectQuery("Win32_NetworkAdapter", "NetConnectionStatus=2");  
            ManagementObjectSearcher search = new ManagementObjectSearcher(query);  
            
            foreach (ManagementObject mo in search.Get())
            {
                // Used "mgmtclassgen Win32_NetworkAdapter -p NetworkAdapter.cs" to generate the NetworkAdapter class.
                NetworkAdapter adapter = new NetworkAdapter(mo);
                adapter.Disable();
            }
        }

        public static void EnableNetworkAdapter()
        {
            SelectQuery query = new SelectQuery("Win32_NetworkAdapter", "NetConnectionStatus=0");
            ManagementObjectSearcher search = new ManagementObjectSearcher(query);

            foreach (ManagementObject mo in search.Get())
            {
                // Used "mgmtclassgen Win32_NetworkAdapter -p NetworkAdapter.cs" to generate the NetworkAdapter class.
                NetworkAdapter adapter = new NetworkAdapter(mo);
                adapter.Enable();
            }
        }
    }
}
