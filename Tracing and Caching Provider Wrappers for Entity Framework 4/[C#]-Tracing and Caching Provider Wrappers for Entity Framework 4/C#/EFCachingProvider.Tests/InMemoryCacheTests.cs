// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using EFCachingProvider.Caching;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EFCachingProvider.Tests
{
    [TestClass]
    public class InMemoryCacheTests
    {
        [TestMethod]
        public void InMemoryCacheInitialStatisticsAreAllZero()
        {
            InMemoryCache cache = new InMemoryCache();
            Assert.AreEqual(0, cache.CacheHits);
            Assert.AreEqual(0, cache.CacheItemAdds);
            Assert.AreEqual(0, cache.CacheItemInvalidations);
            Assert.AreEqual(0, cache.CacheMisses);
        }

        [TestMethod]
        public void InMemoryCacheCacheMissTests()
        {
            InMemoryCache cache = new InMemoryCache();
            object value;

            Assert.IsFalse(cache.GetItem("NoSuchItem", out value));
            Assert.IsNull(value);
            Assert.AreEqual(0, cache.CacheHits);
            Assert.AreEqual(1, cache.CacheMisses);
            Assert.AreEqual(0, cache.CacheItemInvalidations);
            Assert.AreEqual(0, cache.CacheItemAdds);
        }

        [TestMethod]
        public void InMemoryCacheCacheHitTests()
        {
            InMemoryCache cache = new InMemoryCache();
            object value;

            cache.PutItem("Item1", "someValue", new string[0], TimeSpan.Zero, DateTime.MaxValue);
            Assert.IsTrue(cache.GetItem("Item1", out value));
            Assert.AreEqual(value, "someValue");
            Assert.AreEqual(1, cache.CacheHits);
            Assert.AreEqual(0, cache.CacheMisses);
            Assert.AreEqual(0, cache.CacheItemInvalidations);
            Assert.AreEqual(1, cache.CacheItemAdds);
        }

        [TestMethod]
        public void InMemoryCacheCacheReplaceTests()
        {
            InMemoryCache cache = new InMemoryCache();

            object value;

            cache.PutItem("Item1", "someValue", new string[0], TimeSpan.Zero, DateTime.MaxValue);
            cache.PutItem("Item1", "someOtherValue", new string[0], TimeSpan.Zero, DateTime.MaxValue);
            Assert.IsTrue(cache.GetItem("Item1", out value));
            Assert.AreEqual(value, "someOtherValue");
            Assert.AreEqual(1, cache.CacheHits);
            Assert.AreEqual(0, cache.CacheMisses);
            Assert.AreEqual(1, cache.CacheItemInvalidations);
            Assert.AreEqual(2, cache.CacheItemAdds);
        }


        [TestMethod]
        public void InMemoryCacheCacheExpirationTest1()
        {
            InMemoryCache cache = new InMemoryCache();

            object value;

            // current time is 10:00
            cache.GetCurrentDate = () => new DateTime(2009,1,1,10,0,0);

            // set expiration time to 11:00
            cache.PutItem("Item1", "someValue", new string[0], TimeSpan.Zero, new DateTime(2009, 1, 1, 11, 0, 0));

            // make sure the item is still there
            cache.GetCurrentDate = () => new DateTime(2009, 1, 1, 10, 59, 59);
            Assert.IsTrue(cache.GetItem("Item1", out value));
            Assert.AreEqual(value, "someValue");
            Assert.AreEqual(0, cache.CacheItemInvalidations);

            // make sure the item gets evicted at 11:00
            cache.GetCurrentDate = () => new DateTime(2009, 1, 1, 11, 00, 00);
            Assert.IsFalse(cache.GetItem("Item1", out value));
            Assert.AreEqual(1, cache.CacheItemInvalidations);
        }

        [TestMethod]
        public void InMemoryCacheCacheExpirationTest2()
        {
            InMemoryCache cache = new InMemoryCache();

            object value;

            // current time is 10:00
            cache.GetCurrentDate = () => new DateTime(2009, 1, 1, 10, 0, 0);

            // set expiration time to 1 hour from the last access
            cache.PutItem("Item1", "someValue", new string[0], TimeSpan.FromHours(1), DateTime.MaxValue);

            // make sure the item is still there
            cache.GetCurrentDate = () => new DateTime(2009, 1, 1, 10, 59, 59);
            Assert.IsTrue(cache.GetItem("Item1", out value));
            Assert.AreEqual(value, "someValue");
            Assert.AreEqual(0, cache.CacheItemInvalidations);

            // make sure the item does not get evicted at 11:00 because we have touched it a second ago
            cache.GetCurrentDate = () => new DateTime(2009, 1, 1, 11, 00, 00);
            Assert.IsTrue(cache.GetItem("Item1", out value));
            Assert.AreEqual(value, "someValue");
            Assert.AreEqual(0, cache.CacheItemInvalidations);

            Assert.IsNotNull(cache.LruChainHead);

            // make sure the item does not get evicted at 12:00 because we have touched it an hour ago
            cache.GetCurrentDate = () => new DateTime(2009, 1, 1, 12, 00, 00);
            Assert.IsFalse(cache.GetItem("Item1", out value));
            Assert.AreEqual(1, cache.CacheItemInvalidations);

            Assert.IsNull(cache.LruChainHead);
            Assert.IsNull(cache.LruChainTail);
        }

        [TestMethod]
        public void InMemoryCacheCacheExpirationTest3()
        {
            InMemoryCache cache = new InMemoryCache();

            object value;

            // current time is 10:00
            cache.GetCurrentDate = () => new DateTime(2009, 1, 1, 10, 0, 0);
            cache.PutItem("Item1", "someValue", new string[0], TimeSpan.Zero, new DateTime(2009, 1, 1, 10, 0, 0));
            cache.PutItem("Item2", "someValue", new string[0], TimeSpan.Zero, new DateTime(2009, 1, 1, 10, 1, 0));
            cache.PutItem("Item3", "someValue", new string[0], TimeSpan.Zero, new DateTime(2009, 1, 1, 10, 2, 0));
            cache.PutItem("Item4", "someValue", new string[0], TimeSpan.Zero, new DateTime(2009, 1, 1, 10, 3, 0));

            cache.GetCurrentDate = () => new DateTime(2009, 1, 1, 10, 2, 0);

            // no invalidation happens until we try to get an item
            Assert.AreEqual("Item4|Item3|Item2|Item1", GetItemKeysInLruOrder(cache));

            Assert.IsFalse(cache.GetItem("Item1", out value));
            Assert.AreEqual("Item4", GetItemKeysInLruOrder(cache));

        }

        [TestMethod]
        public void LruTest1()
        {
            InMemoryCache imc = new InMemoryCache();
            Assert.AreEqual(Int32.MaxValue, imc.MaxItems);

            imc.PutItem("A", "A1", new string[0], TimeSpan.Zero, DateTime.MaxValue);
            imc.PutItem("B", "B1", new string[0], TimeSpan.Zero, DateTime.MaxValue);
            imc.PutItem("C", "C1", new string[0], TimeSpan.Zero, DateTime.MaxValue);
            imc.PutItem("D", "D1", new string[0], TimeSpan.Zero, DateTime.MaxValue);

            Assert.AreEqual("D|C|B|A", GetItemKeysInLruOrder(imc));

            object value;
            imc.GetItem("D", out value);
            Assert.AreEqual("D|C|B|A", GetItemKeysInLruOrder(imc));
            imc.GetItem("C", out value);
            Assert.AreEqual("C|D|B|A", GetItemKeysInLruOrder(imc));
            imc.GetItem("D", out value);
            Assert.AreEqual("D|C|B|A", GetItemKeysInLruOrder(imc));
            imc.GetItem("A", out value);
            Assert.AreEqual("A|D|C|B", GetItemKeysInLruOrder(imc));
            imc.GetItem("B", out value);
            Assert.AreEqual("B|A|D|C", GetItemKeysInLruOrder(imc));
            imc.InvalidateItem("B");
            Assert.AreEqual("A|D|C", GetItemKeysInLruOrder(imc));
            imc.InvalidateItem("C");
            Assert.AreEqual("A|D", GetItemKeysInLruOrder(imc));
            imc.InvalidateItem("A");
            Assert.AreEqual("D", GetItemKeysInLruOrder(imc));
            imc.InvalidateItem("D");
            Assert.AreEqual("", GetItemKeysInLruOrder(imc));
        }

        [TestMethod]
        public void LruWithLimitTest2()
        {
            InMemoryCache imc = new InMemoryCache(3);

            Assert.AreEqual(3, imc.MaxItems);

            imc.PutItem("A", "A1", new string[0], TimeSpan.Zero, DateTime.MaxValue);
            imc.PutItem("B", "B1", new string[0], TimeSpan.Zero, DateTime.MaxValue);
            imc.PutItem("C", "C1", new string[0], TimeSpan.Zero, DateTime.MaxValue);
            imc.PutItem("D", "D1", new string[0], TimeSpan.Zero, DateTime.MaxValue);

            Assert.AreEqual("D|C|B", GetItemKeysInLruOrder(imc));
            imc.PutItem("E", "E1", new string[0], TimeSpan.Zero, DateTime.MaxValue);
            Assert.AreEqual("E|D|C", GetItemKeysInLruOrder(imc));
            imc.PutItem("F", "F1", new string[0], TimeSpan.Zero, DateTime.MaxValue);
            Assert.AreEqual("F|E|D", GetItemKeysInLruOrder(imc));
        }

        [TestMethod]
        public void DependenciesTest()
        {
            InMemoryCache imc = new InMemoryCache();

            imc.PutItem("A", "A1", new string[] { "set1" }, TimeSpan.Zero, DateTime.MaxValue);
            imc.PutItem("B", "B1", new string[] { "set1", "set2" }, TimeSpan.Zero, DateTime.MaxValue);
            imc.PutItem("C", "C1", new string[] { "set2", "set3" }, TimeSpan.Zero, DateTime.MaxValue);
            imc.PutItem("D", "D1", new string[] { "set3", "set1" }, TimeSpan.Zero, DateTime.MaxValue);

            Assert.AreEqual("D|C|B|A", GetItemKeysInLruOrder(imc));

            imc.InvalidateSets(new string[] { "set2" });
            Assert.AreEqual("D|A", GetItemKeysInLruOrder(imc));
        }

        [TestMethod]
        public void DependenciesTest2()
        {
            InMemoryCache imc = new InMemoryCache();

            imc.PutItem("A", "A1", new string[] { "set1" }, TimeSpan.Zero, DateTime.MaxValue);
            imc.PutItem("B", "B1", new string[] { "set1", "set2" }, TimeSpan.Zero, DateTime.MaxValue);
            imc.PutItem("C", "C1", new string[] { "set2", "set3" }, TimeSpan.Zero, DateTime.MaxValue);
            imc.PutItem("D", "D1", new string[] { "set3", "set1" }, TimeSpan.Zero, DateTime.MaxValue);

            Assert.AreEqual("D|C|B|A", GetItemKeysInLruOrder(imc));

            imc.InvalidateSets(new string[] { "set1" });
            Assert.AreEqual("C", GetItemKeysInLruOrder(imc));
        }

        [TestMethod]
        public void DependenciesTest3()
        {
            InMemoryCache imc = new InMemoryCache();

            imc.PutItem("A", "A1", new string[] { "set1" }, TimeSpan.Zero, DateTime.MaxValue);
            imc.PutItem("B", "B1", new string[] { "set1", "set2" }, TimeSpan.Zero, DateTime.MaxValue);
            imc.PutItem("C", "C1", new string[] { "set2", "set3" }, TimeSpan.Zero, DateTime.MaxValue);
            imc.PutItem("D", "D1", new string[] { "set3", "set1" }, TimeSpan.Zero, DateTime.MaxValue);

            Assert.AreEqual("D|C|B|A", GetItemKeysInLruOrder(imc));

            imc.InvalidateSets(new string[] { "set77" });
            Assert.AreEqual("D|C|B|A", GetItemKeysInLruOrder(imc));
        }

        [TestMethod]
        public void DependenciesTest4()
        {
            InMemoryCache imc = new InMemoryCache();

            imc.PutItem("A", "A1", new string[] { "set1" }, TimeSpan.Zero, DateTime.MaxValue);
            imc.PutItem("B", "B1", new string[] { "set1", "set2" }, TimeSpan.Zero, DateTime.MaxValue);
            imc.PutItem("C", "C1", new string[] { "set2", "set3" }, TimeSpan.Zero, DateTime.MaxValue);
            imc.PutItem("D", "D1", new string[] { "set3", "set1" }, TimeSpan.Zero, DateTime.MaxValue);

            Assert.AreEqual("D|C|B|A", GetItemKeysInLruOrder(imc));
            imc.PutItem("B", "C1", new string[] { "set3" }, TimeSpan.Zero, DateTime.MaxValue);
            Assert.AreEqual("B|D|C|A", GetItemKeysInLruOrder(imc));

            imc.InvalidateSets(new string[] { "set3" });
            Assert.AreEqual("A", GetItemKeysInLruOrder(imc));

        }

        [TestMethod]
        public void MicroStressTest()
        {
            // run a bunch of concurrent reads and writes, make sure we get no exceptions

            var imc = new InMemoryCache(100);
            int numberOfRequestBatches = 50; // will be multiplied by 5 (3 readers + 1 writer + 1 invalidator)
            int numberOfIterationsPerThread = 10000;

            ManualResetEvent startEvent = new ManualResetEvent(false);

            Action writer = () =>
            {
                startEvent.WaitOne();
                Random random = new Random();

                for (int i = 0; i < numberOfIterationsPerThread; ++i)
                {
                    string randomKey = Guid.NewGuid().ToString("N").Substring(0, 4);
                    string randomValue = randomKey + "_V";
                    List<string> dependentSets = new List<string>();
                    int numberOfDependencies = random.Next(5);
                    for (int j = 0; j < numberOfDependencies; ++j)
                    {
                        string randomSetName = new string((char)('A' + random.Next(26)), 1);
                        dependentSets.Add(randomSetName);
                    }

                    imc.PutItem(randomKey, randomValue, dependentSets, TimeSpan.Zero, DateTime.MaxValue);
                }
            };

            Action invalidator = () =>
            {
                startEvent.WaitOne();
                Random random = new Random();

                for (int i = 0; i < numberOfIterationsPerThread; ++i)
                {
                    List<string> dependentSets = new List<string>();
                    int numberOfDependencies = random.Next(5);
                    for (int j = 0; j < numberOfDependencies; ++j)
                    {
                        string randomSetName = new string((char)('A' + random.Next(26)), 1);
                        dependentSets.Add(randomSetName);
                    }

                    imc.InvalidateSets(dependentSets);
                }
            };

            Action reader = () =>
            {
                startEvent.WaitOne();
                Random random = new Random();

                for (int i = 0; i < numberOfIterationsPerThread; ++i)
                {
                    string randomKey = Guid.NewGuid().ToString("N").Substring(0, 4);
                    object value;

                    if (imc.GetItem(randomKey, out value))
                    {
                        Assert.AreEqual(randomKey + "_V", value);
                    }
                }
            };

            List<Thread> threads = new List<Thread>();

            for (int i = 0; i < numberOfRequestBatches; ++i)
            {
                threads.Add(new Thread(() => writer()));
                threads.Add(new Thread(() => invalidator()));
                threads.Add(new Thread(() => reader()));
                threads.Add(new Thread(() => reader()));
                threads.Add(new Thread(() => reader()));
            }

            foreach (Thread t in threads)
            {
                t.Start();
            }

            startEvent.Set();

            foreach (Thread t in threads)
            {
                t.Join();
            }
        }

        private static string GetItemKeysInLruOrder(InMemoryCache imc)
        {
            StringBuilder sb = new StringBuilder();
            string separator = "";
            HashSet<string> visisted = new HashSet<string>();

            InMemoryCache.CacheEntry lastEntry = null;

            for (InMemoryCache.CacheEntry ce = imc.LruChainHead; ce != null; ce = ce.NextEntry)
            {
                if (visisted.Contains(ce.Key))
                {
                    throw new InvalidOperationException("Cycle in the LRU chain on: " + ce);
                }

                if (ce.PreviousEntry != lastEntry)
                {
                    throw new InvalidOperationException("Invalid previous pointer on LRU chain: " + ce + " Is: " + ce.PreviousEntry + " expected: " + lastEntry);
                }

                if (lastEntry != null && ce.LastAccessTime < lastEntry.LastAccessTime)
                {
                    throw new InvalidOperationException("Invalid LastAccess time. Current: " + ce.LastAccessTime.Ticks + " previous: " + lastEntry.LastAccessTime.Ticks);
                }

                sb.Append(separator);
                sb.Append(ce.Key);
                separator = "|";
                visisted.Add(ce.Key);
                lastEntry = ce;
            }

            Assert.AreSame(lastEntry, imc.LruChainTail);

            return sb.ToString();
        }
    }
}
