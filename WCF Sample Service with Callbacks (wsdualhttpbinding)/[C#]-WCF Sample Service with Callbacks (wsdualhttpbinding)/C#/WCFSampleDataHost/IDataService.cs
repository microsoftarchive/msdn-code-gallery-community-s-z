using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFSampleDataService
{
    [ServiceContract(Namespace = "uri:wcfsampledataservice:v1", Name = "IDataService")]
    public interface IDataService
    {
        [OperationContract]
        Customer GetCustomer(int customerId);

        [OperationContract]
        CustomerAddress GetCustomerAddress(int customerId);
        
        [OperationContract]
        CustomerInvoices GetCustomerInvoices(int customerId);        
    }

    [ServiceContract(CallbackContract = typeof(IDataCallback), Namespace = "uri:wcfsampledataservice:v2", Name = "IDataService")]
    public interface IDataServiceV2
    {
        [OperationContract]
        Customer GetCustomer(int customerId);
    }

    public interface IDataCallback
    {
        [OperationContract(IsOneWay = true)]
        void OnCustomerAddressComplete(CustomerAddress data);

        [OperationContract(IsOneWay = true)]
        void OnCustomerInvoicesComplete(CustomerInvoices data);
    }

    
    [DataContract]
    public class Customer
    {        
        [DataMember]
        public int CustomerId { get; set; }

        [DataMember]
        public string Name { get; set; }
    }

    [DataContract]
    public class CustomerAddress
    {
        [DataMember]
        public int CustomerId { get; set; }

        [DataMember]
        public string Address { get; set; }
    }

    [DataContract]
    public class CustomerInvoices
    {
        [DataMember]
        public int CustomerId { get; set; }

        [DataMember]
        public CustomerInvoice[] Invoices { get; set; }
    }

    public class CustomerInvoice
    {
        public int InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal Amount { get; set; }
    }

}
