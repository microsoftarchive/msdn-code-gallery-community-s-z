using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using WCFSampleClient.DataServiceProxy;
using System.Threading;

namespace WCFSampleClient
{
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    class ClientV2 : IClient, IDataServiceCallback, IDisposable
    {
        // when the client is constructed
        private DateTime start = DateTime.Now;

        private DataService1Client client;

        public void RunGetCustomer(int customerId)
        {
            CustomerId = customerId;

            InstanceContext context = new InstanceContext(this);
            client = new DataService1Client(context, "dual");

            var customer = client.GetCustomer(customerId);

            if (Helper.ValidateCustomer(customerId, customer))
                Console.WriteLine("RunTest {0} Customer successful Elapsed={1}", customerId,
                                  DateTime.Now.Subtract(start).TotalMilliseconds);
            else
                Console.WriteLine("RunTest {0} Customer failure Elapsed={1} **************", customerId,
                                  DateTime.Now.Subtract(start).TotalMilliseconds);

       
            while (CustomerAddress==null || CustomerInvoices==null)
            {
                Thread.CurrentThread.Join(200);    
            }  
        }

        public int CustomerId { get; set; }
        public CustomerAddress CustomerAddress { get; set; }
        public CustomerInvoices CustomerInvoices { get; set; }


        public void OnCustomerAddressComplete(CustomerAddress address)
        {
            if (Helper.ValidateCustomerAddress(CustomerId, address))
                Console.WriteLine("RunTest {0} Address successful Elapsed={1}", CustomerId, DateTime.Now.Subtract(start).TotalMilliseconds);
            else
                Console.WriteLine("RunTest {0} Address failure Elapsed={1} **************", CustomerId, DateTime.Now.Subtract(start).TotalMilliseconds);

            CustomerAddress = address;
        }

        public void OnCustomerInvoicesComplete(CustomerInvoices invoices)
        {
            if (Helper.ValidateCustomerInvoices(CustomerId, invoices))
                Console.WriteLine("RunTest {0} Invoices successful Elapsed={1}", CustomerId, DateTime.Now.Subtract(start).TotalMilliseconds);
            else
                Console.WriteLine("RunTest {0} Invoices failure Elapsed={1} **************", CustomerId, DateTime.Now.Subtract(start).TotalMilliseconds);

            CustomerInvoices = invoices;
        }

        public void Dispose()
        {
            client.Close();
        }
    }
}
