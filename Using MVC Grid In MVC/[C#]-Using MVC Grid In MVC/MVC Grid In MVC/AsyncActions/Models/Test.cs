using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
namespace AsyncActions.Models
{
    public class Test
    {
        public List<Customer> GetData()
        {
            try
            {
                List<Customer> cst = new List<Customer>();
                for (int i = 0; i < 100; i++)
                {
                    Customer c = new Customer();
                    c.CustomerID = i;
                    c.CustomerCode = "CST" + i;
                    cst.Add(c);
                }
                return cst;
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }

        }
    }
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerCode { get; set; }
    }
}