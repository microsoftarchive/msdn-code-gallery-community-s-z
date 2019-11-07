using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.CompilerServices;

namespace ChapterFive
{
    public sealed class Singleton
    {
        private static Singleton uniqueInstance;
        private static Singleton uniqueInstanceVolatile;
        private static readonly Singleton uniqueInstanceEager = new Singleton();

        private static object syncRoot = new object();

        //Construction
        private Singleton() 
        {
            Console.WriteLine("Singleton Instance Created.");
        }

        /// <summary>
        /// Normal GetInstance() , not thread safe
        /// </summary>
        /// <returns>Singleton Object</returns>
        public static Singleton GetInstance()
        {
            if (uniqueInstance == null)
            {
                Console.WriteLine("Creating Singleton Instance first time .....");
                uniqueInstance = new Singleton();
            }
            else
            {
                Console.WriteLine("Singleton Instance already present .....");
            }

            return uniqueInstance;
        }

        /// <summary>
        /// Mostly used, Thread Safe by Default
        /// </summary>
        /// <returns></returns>
        public static Singleton GetInstanceEager()
        {
            return uniqueInstanceEager;
        }

        /// <summary>
        /// By Marking as Synchronized we force every thread to wait its turn so no 2 threads enters the method at same time.
        /// Synchronization is expensive operation :-(
        /// </summary>
        /// <returns>Singleton Object</returns>
        [MethodImpl(MethodImplOptions.Synchronized)] 
        public static Singleton GetInstanceSynchronized()
        {
            if (uniqueInstance == null)
            {
                Console.WriteLine("Creating Singleton Instance first time .....");
                uniqueInstance = new Singleton();
            }
            else
            {
                Console.WriteLine("Singleton Instance already present .....");
            }
            
            return uniqueInstance;
        }

        /// <summary>
        /// Multithreaded Singleton by avoiding expensive Synchronization operation.
        /// double-check locking approach, rarely used
        /// </summary>
        /// <returns></returns>
        public static Singleton GetInstanceVolatile()
        {
            if (uniqueInstanceVolatile == null)
            {
                lock (syncRoot)
                {
                    if (uniqueInstanceVolatile == null)
                    {
                        Console.WriteLine("Creating Singleton Instance first time .....");
                        uniqueInstanceVolatile = new Singleton();
                    }
                    else
                    {
                        Console.WriteLine("Singleton Instance already present .....");
                    }
                }
            }
            else
            {
                Console.WriteLine("Singleton Instance already present .....");
            }
            return uniqueInstanceVolatile;
        }

    }
}
