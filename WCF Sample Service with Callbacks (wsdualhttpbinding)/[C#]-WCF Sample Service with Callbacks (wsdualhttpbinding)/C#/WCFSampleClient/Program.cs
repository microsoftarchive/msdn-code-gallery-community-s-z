using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFSampleClient.DataServiceProxy;
using System.ServiceModel;

namespace WCFSampleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // warm up ignore
            // run tests for client version 1
            RunTest<ClientV1>(1);
            RunTest<ClientV2>(1);

            Console.WriteLine("Enter y to run tests:");
            while (Console.ReadLine() == "y")
            {
                Console.WriteLine("************* Client Version 1 *******************");
                // run tests for client version 1
                RunTest<ClientV1>(15);

                Console.WriteLine("************* Client Version 1 Alternate *******************");
                // run tests for client version 1
                RunTest<ClientV1a>(15);

                Console.WriteLine("************* Client Version 2 *******************");
                // run tests for client version 2
                RunTest<ClientV2>(15);
                
                Console.WriteLine("Enter y to run tests:");
            }
        }

        static void RunTest<T>(int count) where T : IClient, new()
        {
            DateTime start = DateTime.Now;
            var tasks = new List<Task>();

            for (int i = 0; i < count; i++)
            {
                var task = new Task((customerId) =>
                {
                    T client = new T();
                    client.RunGetCustomer((int)customerId);
                }, i);

                task.Start();
                tasks.Add(task);
            }

            Console.WriteLine("All tasks have started: {0}", DateTime.Now.Subtract(start).TotalMilliseconds);

            try
            {
                Task.WaitAll(tasks.ToArray());
            }
            catch (Exception ex)
            {
                if(ex.InnerException!=null)
                    Console.WriteLine("Failed" + ex.InnerException.Message);
                else 
                    Console.WriteLine("Failed" + ex.Message);
            }

            Console.WriteLine("All tasks have  completed: {0}", DateTime.Now.Subtract(start).TotalMilliseconds);   
        }

    }
}
