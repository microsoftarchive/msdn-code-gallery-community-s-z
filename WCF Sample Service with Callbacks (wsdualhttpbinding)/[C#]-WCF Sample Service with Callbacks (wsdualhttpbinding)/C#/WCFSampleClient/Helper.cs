using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WCFSampleClient.DataServiceProxy;

namespace WCFSampleClient
{
    static class Helper
    {
        public static bool ValidateCustomer(int customerId, Customer customer)
        {
            // is valid if the customer id matches and the name contains the customerid in single quotes
            return customerId==customer.CustomerId && customer.Name.Contains(string.Format("'{0}'", customerId));            
        }

        public static bool ValidateCustomerAddress(int customerId, CustomerAddress address)
        {
            // is valid if the customer id matches and the address contains the customerid in single quotes
            return customerId == address.CustomerId && address.Address.Contains(string.Format("'{0}'", customerId));
        }

        public static bool ValidateCustomerInvoices(int customerId, CustomerInvoices customer)
        {
            // is valid if the customer id matches
            return customerId == customer.CustomerId;
        }
    }
}
