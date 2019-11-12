// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.IO;
using System.Linq;
using EFProviderWrapperToolkit;
using EFTracingProvider;
using EFCachingProvider.Caching;
using EFCachingProvider;

//
// This sample demonstrates using Caching and Tracing providers together.
// We get log output to the console and also observe caching behavior by printing cache statistics.
//
// In order to use this technique in your application you must copy ExtendedNorthwindEntities.cs
// and add it to your project, rename the class as appropriate and modify the connection strings then use instead
// of a regular object context class.
//
// Also you must add the following lines to your App.config file:
//
// <system.data>
//   <DbProviderFactories>
//     <add name="EF Caching Data Provider" invariant="EFCachingProvider" description="Caching Provider Wrapper" type="EFCachingProvider.EFCachingProviderFactory, EFCachingProvider, Version=1.0.0.0, Culture=neutral, PublicKeyToken=def642f226e0e59b" />
//     <add name="EF Tracing Data Provider" invariant="EFTracingProvider" description="Tracing Provider Wrapper" type="EFTracingProvider.EFTracingProviderFactory, EFTracingProvider, Version=1.0.0.0, Culture=neutral, PublicKeyToken=def642f226e0e59b" />
//     <add name="EF Generic Provider Wrapper" invariant="EFProviderWrapper" description="Generic Provider Wrapper" type="EFProviderWrapperToolkit.EFProviderWrapperFactory, EFProviderWrapperToolkit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=def642f226e0e59b" />
//   </DbProviderFactories>
// </system.data>
//

namespace EFProviderWrapperDemo
{
    static class Program
    {
        static void Main(string[] args)
        {
            EFTracingProviderConfiguration.RegisterProvider();
            EFCachingProviderConfiguration.RegisterProvider();

            // tracing + caching demos
            SimpleCachingDemo();
            CacheInvalidationDemo();
            NonDeterministicQueryCachingDemo();

            // tracing demos
            SimpleTracingDemo();
            AdvancedTracingDemo();
        }

        private static void DdlMethodsDemo()
        {
            using (var context = new ExtendedNorthwindEntities())
            {
                Console.WriteLine(context.CreateDatabaseScript());
            }
        }

        /// <summary>
        /// In this demo we are running a set of queries 3 times and logging SQL commands to the console.
        /// Note that queries are actually executed only in the first pass, while in second and third they are fulfilled
        /// completely from the cache.
        /// </summary>
        private static void SimpleCachingDemo()
        {
            ICache cache = new InMemoryCache();
            CachingPolicy cachingPolicy = CachingPolicy.CacheAll;

            // log SQL from all connections to the console
            EFTracingProviderConfiguration.LogToConsole = true;

            for (int i = 0; i < 3; ++i)
            {
                Console.WriteLine();
                Console.WriteLine("*** Pass #{0}...", i);
                Console.WriteLine();
                using (var context = new ExtendedNorthwindEntities())
                {
                    // set up caching
                    context.Cache = cache;
                    context.CachingPolicy = cachingPolicy;

                    Console.WriteLine("Loading customer...");
                    var cust = context.Customers.First(c => c.CustomerID == "ALFKI");
                    Console.WriteLine("Customer name: {0}", cust.ContactName);
                    Console.WriteLine("Loading orders...");
                    cust.Orders.Load();
                    Console.WriteLine("Order count: {0}", cust.Orders.Count);
                }
            }

            Console.WriteLine();

            //Console.WriteLine("*** Cache statistics: Hits:{0} Misses:{1} Hit ratio:{2}% Adds:{3} Invalidations:{4}",
            //    cache.CacheHits,
            //    cache.CacheMisses,
            //    100.0 * cache.CacheHits / (cache.CacheHits + cache.CacheMisses),
            //    cache.CacheItemAdds,
            //    cache.CacheItemInvalidations);
        }

        /// <summary>
        /// In this demo we are running a set of queries and updates and 3 times and logging SQL commands to the console.
        /// Notice how performing an update on Customer table causes the cache entry to be invalidated so we get 
        /// a query in each pass. Because we aren't modifying OrderDetails table, the collection of order details
        /// for the customer doesn't require a query in second and third pass.
        /// </summary>
        private static void CacheInvalidationDemo()
        {
            var cache = new InMemoryCache();

            // log SQL from all connections to the console
            EFTracingProviderConfiguration.LogToConsole = true;

            for (int i = 0; i < 3; ++i)
            {
                Console.WriteLine();
                Console.WriteLine("*** Pass #{0}...", i);
                Console.WriteLine();
                using (var context = new ExtendedNorthwindEntities())
                {
                    // set up caching
                    context.Cache = cache;
                    context.CachingPolicy = CachingPolicy.CacheAll;

                    Console.WriteLine("Loading customer...");
                    var cust = context.Customers.First(c => c.CustomerID == "ALFKI");
                    Console.WriteLine("Customer name: {0}", cust.ContactName);
                    cust.ContactName = "Change" + Environment.TickCount;
                    Console.WriteLine("Loading orders...");
                    cust.Orders.Load();

                    for (int o = 0; o < 10; ++o)
                    {
                        var order = new Order();
                        order.OrderDate = DateTime.Now;
                        cust.Orders.Add(order);
                    }

                    Console.WriteLine("Order count: {0}", cust.Orders.Count);
                    context.SaveChanges();
                }
            }

            Console.WriteLine();
        }

        /// <summary>
        /// In this demo we are a query based on time (whose results are non-deterministic, because it uses DateTime.Now)
        /// Such queries are not cached, so we get a store query every time.
        ///
        /// Note that non-cacheable queries don't count as cache misses.
        /// </summary>
        private static void NonDeterministicQueryCachingDemo()
        {
            var cache = new InMemoryCache();

            // log SQL from all connections to the console
            EFTracingProviderConfiguration.LogToConsole = true;

            for (int i = 0; i < 3; ++i)
            {
                Console.WriteLine();
                Console.WriteLine("*** Pass #{0}...", i);
                Console.WriteLine();
                using (var context = new ExtendedNorthwindEntities())
                {
                    // set up caching
                    context.Cache = cache;
                    context.CachingPolicy = CachingPolicy.CacheAll;

                    Console.WriteLine("Loading orders...");
                    context.Orders.Where(c => c.ShippedDate < DateTime.Now).ToList();
                }
            }

            Console.WriteLine();

            Console.WriteLine("*** Cache statistics: Hits:{0} Misses:{1} Hit ratio:{2}% Adds:{3} Invalidations:{4}",
                cache.CacheHits,
                cache.CacheMisses,
                100.0 * cache.CacheHits / (cache.CacheHits + cache.CacheMisses),
                cache.CacheItemAdds,
                cache.CacheItemInvalidations);
        }

        /// <summary>
        /// In this demo we are running simple queries and updates and we're logging the SQL commands
        /// to the file.
        /// </summary>
        private static void SimpleTracingDemo()
        {
            // disable global logging to console
            EFTracingProviderConfiguration.LogToConsole = false;

            using (TextWriter logFile = File.CreateText("sqllogfile.txt"))
            {
                using (var context = new ExtendedNorthwindEntities())
                {
                    context.Log = logFile;

                    // this will produce LIKE 'ALFKI%' T-SQL
                    var customer = context.Customers.Single(c => c.CustomerID.StartsWith("ALFKI"));
                    customer.Orders.Load();

                    customer.ContactName = "Change" + Environment.TickCount;

                    var newCustomer = new Customer()
                    {
                        CustomerID = "BELLA",
                        CompanyName = "Bella Vision",
                        ContactName = "Bella Bellissima",
                    };

                    context.AddToCustomers(newCustomer);
                    context.SaveChanges();

                    context.DeleteObject(newCustomer);

                    context.SaveChanges();
                }
            }

            Console.WriteLine("LOG FILE CONTENTS:");
            Console.WriteLine(File.ReadAllText("sqllogfile.txt"));
        }

        /// <summary>
        /// In this demo we are running simple queries and updates and we're logging the SQL commands
        /// using tracing events.
        /// </summary>
        private static void AdvancedTracingDemo()
        {
            // disable global logging to console
            EFTracingProviderConfiguration.LogToConsole = false;

            using (var context = new ExtendedNorthwindEntities())
            {
                context.CommandExecuting += (sender, e) =>
                    {
                        Console.WriteLine("Command is executing: {0}", e.ToTraceString());
                    };

                context.CommandFinished += (sender, e) =>
                    {
                        Console.WriteLine("Command has finished: {0}", e.ToTraceString());
                    };

                var customer = context.Customers.First(c => c.CustomerID == "ALFKI");
                customer.Orders.Load();

                customer.ContactName = "Change" + Environment.TickCount;

                var newCustomer = new Customer()
                {
                    CustomerID = "BELLA",
                    CompanyName = "Bella Vision",
                    ContactName = "Bella Bellissima",
                };

                context.AddToCustomers(newCustomer);
                context.SaveChanges();

                context.DeleteObject(newCustomer);

                context.SaveChanges();
            }

            Console.WriteLine("LOG FILE CONTENTS:");
            Console.WriteLine(File.ReadAllText("sqllogfile.txt"));
        }
    }
}
