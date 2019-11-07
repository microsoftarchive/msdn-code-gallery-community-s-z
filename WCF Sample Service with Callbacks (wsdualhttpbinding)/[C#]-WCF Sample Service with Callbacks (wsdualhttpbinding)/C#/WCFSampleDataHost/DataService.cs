using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WCFSampleDataService
{    
    public class DataService : ServiceHost,  IDataService, IDataServiceV2
    {
        private Customer GetCustomer(int customerId)
        {
            // delay to simulate a downstream web service call
            Thread.CurrentThread.Join(500);

            return new Customer
            {
                CustomerId = customerId,
                Name = string.Format("Customer '{0}'", customerId)
            };
        }

        private CustomerAddress GetCustomerAddress(Customer customer)
        {
            // delay to simulate a downstream web service call
            Thread.CurrentThread.Join(300);

            return new CustomerAddress
            {
                CustomerId = customer.CustomerId,
                Address = string.Format("Customer '{0}' Address", customer.CustomerId)
            };
        }

        private CustomerInvoices GetCustomerInvoices(Customer customer)
        {
            // delay to simulate a downstream web service call
            // this is a slow legacy system hobbled together and held firm with duct tape
            Thread.CurrentThread.Join(800);

            return new CustomerInvoices
            {
                CustomerId = customer.CustomerId,
                Invoices = new CustomerInvoice[]
                    {
                        new CustomerInvoice
                            {
                                InvoiceId = 1,
                                InvoiceDate = DateTime.Now.Date.AddMonths(-2),
                                Amount = 100
                            },
                            new CustomerInvoice
                            {
                                InvoiceId = 2,
                                InvoiceDate = DateTime.Now.Date.AddMonths(-1),
                                Amount = 200
                            },
                    }
            };
        }

        

        Customer IDataServiceV2.GetCustomer(int customerId)
        {
            IDataCallback callback = OperationContext.Current.GetCallbackChannel<IDataCallback>();

            Customer customer = GetCustomer(customerId);

            t1 = new Task(() =>
            {
                var address = GetCustomerAddress(customer);

                if (callback == null)
                    Console.WriteLine("DataService.GetCustomer({0}) failed to get Address callback channel!", customerId);
                else
                    callback.OnCustomerAddressComplete(address);
                
            });

            t1.Start();

            t2 = new Task(() =>
            {
                var invoices = GetCustomerInvoices(customer);

                if (callback == null)
                    Console.WriteLine("DataService.GetCustomer({0}) failed to get Invoices callback channel!", customerId);
                else
                    callback.OnCustomerInvoicesComplete(invoices);
            });

            t2.Start();

            return customer;
        }

        Customer IDataService.GetCustomer(int customerId)
        {
            return GetCustomer(customerId);
        }

        CustomerAddress IDataService.GetCustomerAddress(int customerId)
        {
            Customer customer = GetCustomer(customerId);
            return GetCustomerAddress(customer);
        }

        CustomerInvoices IDataService.GetCustomerInvoices(int customerId)
        {
            Customer customer = GetCustomer(customerId);
            return GetCustomerInvoices(customer);
        }

        // TODO: investigate thread management but based on msdn, this should be ok for a sample: http://blogs.msdn.com/b/pfxteam/archive/2012/03/25/10287435.aspx
        private Task t1;
        private Task t2;

        protected override void OnClosed()
        {
            if(t1!=null)
                t1.Dispose();

            if(t2!=null)
                t2.Dispose();

            base.OnClosed();
        }
        
    }
}
