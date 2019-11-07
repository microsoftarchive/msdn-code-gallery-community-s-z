using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using WpfEfDAL;


namespace WpfEfSampleApp
{
    class CustomerCollection : MyBaseCollection<Customer>
    {
        /// <summary>
        // Return true if any customer in this collection has a validation error
        /// <summary>
        public Boolean HasErrors
        {
            get {
                return (from cust in this where cust.HasErrors select cust).Count() > 0;
            }
        }

        public CustomerCollection(IEnumerable<Customer> customers, OMSEntities context):base(customers, context)
        {
        }

        protected override void InsertItem(int index, Customer item)
        {
            if (! this.IsLoading)
            {
                // Tell the ObjectContext to start tracking this customer entity
                this.Context.AddToCustomers(item);
            }
            
            base.InsertItem(index, item);
        }

        protected override void RemoveItem(int index)
        {
            // Tell the ObjectContext to delete this customer entity
            this.Context.DeleteObject(this[index]);
            base.RemoveItem(index);
        }
    }
}
