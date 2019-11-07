using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WpfEfDAL;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WpfEfSampleApp
{
    class OrdersCollection : MyBaseCollection<Order>
    {
        /// <summary>
        // Return true if any order in this collection has a validation error
        /// <summary>
        public Boolean HasErrors
        {
            get {
                return ( (from order in this where order.HasErrors select order).Count() > 0 );
            }
        }

        public OrdersCollection (IEnumerable<Order> orders, OMSEntities context) : base(orders, context)
        {
        }

        protected override void InsertItem(int index, Order item)
        {
            item.OrderDetails.AssociationChanged += new CollectionChangeEventHandler(Details_CollectionChanged);

            if (! this.IsLoading)
                this.Context.AddToOrders(item);

            base.InsertItem(index, item);
        }

        protected override void RemoveItem(int index)
        {
            Order order = this[index];

            order.OrderDetails.AssociationChanged -= new CollectionChangeEventHandler(Details_CollectionChanged);

            for (int i = 0; i <= order.OrderDetails.Count; i++)
            {
                // When deleting an order, delete any details if any exist
                this.Context.DeleteObject(order.OrderDetails.ElementAt(0));
            }

            this.Context.DeleteObject(order);
            base.RemoveItem(index);
        }

        private void Details_CollectionChanged(object sender, CollectionChangeEventArgs e)
        {
            if (e.Action == CollectionChangeAction.Remove)
            {
                // Adding a detail to an order is handled automatically for us but we need to tell the ObjectContext 
                // to delete the detail if a detail is removed from the OrderDetails EntityCollection 
                this.Context.DeleteObject((OrderDetail)e.Element);
            }
        }
    }
}
