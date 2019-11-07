using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;

namespace NorthwindService
{
    public class Northwind : DataService<NorthwindEntities>
    {
        // This method is called only once to initialize service-wide policies.
        public static void InitializeService(IDataServiceConfiguration config)
        {
            // Make certain entity sets writable.
            config.SetEntitySetAccessRule("Customers", EntitySetRights.All);
            config.SetEntitySetAccessRule("Employees", EntitySetRights.All);
            config.SetEntitySetAccessRule("Orders", EntitySetRights.All);
            config.SetEntitySetAccessRule("Order_Details", EntitySetRights.All);
            config.SetEntitySetAccessRule("Products", EntitySetRights.All);

            // Make the remaining entity sets read-only.
            config.SetEntitySetAccessRule("*", EntitySetRights.AllRead);
        }
    }
}
