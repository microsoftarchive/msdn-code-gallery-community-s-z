//===============================================================================
// Copyright © 2010 Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace QueueProcessor
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    static void Main(string[] args)
    {
      if (args.Length > 0 && args[0] == "/console")
      {
        System.Diagnostics.Trace.Listeners.Add(new System.Diagnostics.ConsoleTraceListener());
        var s = new Service1();
        s.StartService();
        Console.WriteLine("Started, hit any key to stop");
        Console.ReadKey();
        s.StopService();
        return;
      }
      
      ServiceBase[] ServicesToRun;
      ServicesToRun = new ServiceBase[] 
      { 
        new Service1() 
      };
      ServiceBase.Run(ServicesToRun);
    }
  }
}
