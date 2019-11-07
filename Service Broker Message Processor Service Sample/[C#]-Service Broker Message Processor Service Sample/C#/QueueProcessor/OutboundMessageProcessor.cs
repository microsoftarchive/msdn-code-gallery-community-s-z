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
using System.Text;
using System.Xml.Linq;
using System.Diagnostics;
using System.Data.SqlClient;

namespace QueueProcessor
{
  class OutboundMessageProcessor
  {
    public static void ProcessMessage(byte[] message)
    {
      Trace.WriteLine("OutboundMessageProcessor Recieved Message");
      return;
    }

    public static void SaveFailedMessage(byte[] message, SqlConnection con, Exception errorInfo)
    {
      Trace.WriteLine("OutboundMessageProcessor Recieved Failed Message");
      return;
    }
  }
}
