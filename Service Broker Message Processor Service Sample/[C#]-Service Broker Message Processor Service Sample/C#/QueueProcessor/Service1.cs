//===============================================================================
// Copyright © 2010 Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Transactions;

namespace QueueProcessor
{
  public partial class Service1 : ServiceBase
  {

    class QueueListenerConfig
    {
      public string QueueName { get; set; }
      public int Threads { get; set; }
      public bool EnlistMessageProcessor { get; set; }
      public Action<byte[]> MessageProcessor { get; set; }
      public Action<byte[],SqlConnection, Exception> FailedMessageProcessor { get; set; }
      public string ConnectionString { get; set; }
    }

    static List<QueueListenerConfig> QueueSettings = new List<QueueListenerConfig>();
    static List<Thread> Listeners = new List<Thread>();

    static bool stopping = false;

    public Service1()
    {
      InitializeComponent();
    }

    public void StartService()
    {
      OnStart( null );
    }
    public void StopService()
    {
      OnStop();
    }
    protected override void OnStart(string[] args)
    {
      //load the config
      var l = new QueueListenerConfig();
      l.QueueName = "Inbound";  //The name of the service broker queue
      l.Threads = 1;
      l.EnlistMessageProcessor = false;  //Don't call the message processor in the context of the RECEIVE transaction
      l.MessageProcessor = InboundMessageProcessor.ProcessMessage;  //Wire up the message processors
      l.FailedMessageProcessor = InboundMessageProcessor.SaveFailedMessage;
      l.ConnectionString = "Data Source=(local);Initial Catalog=test;Integrated Security=true";
      QueueSettings.Add(l);

      //l = new QueueListenerConfig();
      //l.QueueName = "Outbound";
      //l.Threads = 2;
      //l.EnlistMessageProcessor = false;
      //l.MessageProcessor = OutboundMessageProcessor.ProcessMessage;
      //l.FailedMessageProcessor = OutboundMessageProcessor.SaveFailedMessage;
      //l.ConnectionString = "Data Source=(local);Initial Catalog=test;Integrated Security=true";


      foreach (var q in QueueSettings)
      {
        for (int i = 0; i < q.Threads; i++)
        {
          Thread listenerThread = new Thread(ListenerThreadProc);
          listenerThread.Name = "Listener Thread " + i.ToString() + " for " + q.QueueName;
          listenerThread.IsBackground = false;
          Listeners.Add(listenerThread);
          
          listenerThread.Start(q);
          Trace.WriteLine("Started thread " + listenerThread.Name);
        }
      }
      
    }

    public static void ListenerThreadProc(object queueListenerConfig)
    {

      QueueListenerConfig config = (QueueListenerConfig) queueListenerConfig;
      while (!stopping)
      {
        TransactionOptions to = new TransactionOptions();
        to.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
        to.Timeout = TimeSpan.MaxValue;

        CommittableTransaction tran = new CommittableTransaction(to);

        try
        {

          using (var con = new SqlConnection(config.ConnectionString))
          {
            con.Open();
            con.EnlistTransaction(tran);
            byte[] message = ServiceBrokerUtils.GetMessage(config.QueueName, con, TimeSpan.FromSeconds(10));
            if (message == null) //no message available
            {
              tran.Commit();
              con.Close();
              continue;
            }

            try
            {
              if (config.EnlistMessageProcessor)
              {
                using (var ts = new TransactionScope(tran))
                {
                  config.MessageProcessor(message);
                  ts.Complete();
                }
              }
              else
              {
                config.MessageProcessor(message);
              }

            }
            catch (SqlException ex) //catch selected exceptions thrown by the MessageProcessor
            {
              config.FailedMessageProcessor(message, con, ex);              
            }

            tran.Commit(); // the message processing succeeded or the FailedMessageProcessor ran so commit the RECEIVE
            con.Close();

          }
        }
        catch (SqlException ex)
        {
          System.Diagnostics.Trace.Write("Error processing message from " + config.QueueName + ": " + ex.Message);
          tran.Rollback();
          tran.Dispose();
          Thread.Sleep(1000);
        }
          ///catch any other non-fatal exceptions that should not stop the listener loop.
        catch (Exception ex)
        {
          Trace.WriteLine("Unexpected Exception in Thread Proc for " + config.QueueName + ".  Thread Proc is exiting: " + ex.Message);
          tran.Rollback();
          tran.Dispose();
          return;
        }

      }

    
    }


    protected override void OnStop()
    {
      stopping = true;
      foreach (var t in Listeners)
      {
        t.Join(20 + 1000);        
      }

    }
  }
}
