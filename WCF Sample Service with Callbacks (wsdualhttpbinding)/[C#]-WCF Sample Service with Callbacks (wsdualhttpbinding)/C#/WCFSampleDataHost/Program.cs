using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace WCFSampleDataHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost myService = new ServiceHost(typeof(WCFSampleDataService.DataService));
            
            myService.Open();
            Console.WriteLine("Press any key to stop.");
            Console.ReadKey();

            Console.WriteLine("Stopping, please wait...");
            if (myService.State != CommunicationState.Closed)
                myService.Close();
        }
    }
}
