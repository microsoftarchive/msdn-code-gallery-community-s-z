using System.Collections.Generic;
using System.Linq;
using System.Threading;
using RealTimeDataEditor.Core;

namespace RealTimeDataEditor.DataAccess
{
    // Emulation of the data storage.
    public class ProductsDataStore
    {
        private static readonly IDictionary<int, Product> products;

        private static readonly ReaderWriterLockSlim ProductsLock = new ReaderWriterLockSlim();

        static ProductsDataStore()
        {
            products = new Dictionary<int, Product>
            {
                { 1, new Product() { Id = 1, Name = "Product 1", Description = "Description 1" } },
                { 2, new Product() { Id = 2, Name = "Product 2", Description = "Description 2" } },
                { 3, new Product() { Id = 3, Name = "Product 3", Description = "Description 3" } },
                { 4, new Product() { Id = 4, Name = "Product 4", Description = "Description 4" } }
            };
        }

        public static IList<Product> Products
        {
            get
            {
                ProductsLock.EnterReadLock();
                try
                {
                    return products.Values.ToList();
                }
                finally
                {
                    ProductsLock.ExitReadLock();
                }
            }
        }

        public static void Insert(Product product)
        {
            //Contract.Requires<ArgumentNullException>(product != null);
            //Contract.Requires<ArgumentNullException>(product.Id != null);

            ProductsLock.EnterWriteLock();

            try
            {
                products.Add(product.Id.Value, product);
            }
            finally
            {
                ProductsLock.ExitWriteLock();
            }
        }

        public static void Update(Product product)
        {
            //Contract.Requires<ArgumentNullException>(product != null);
            //Contract.Requires<ArgumentNullException>(product.Id != null);

            ProductsLock.EnterWriteLock();
            try
            {
                products[product.Id.Value] = product;
            } 
            finally
            {
                ProductsLock.ExitWriteLock();
            }
        }

        public static void Delete(int productId)
        {
            ProductsLock.EnterWriteLock();
            try
            {
                products.Remove(productId);
            }
            finally
            {
                ProductsLock.ExitWriteLock();
            }
        }
    }
}