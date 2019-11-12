using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;

namespace ChapterFive
{
    class Simulator
    {
        public static Singleton testSingleton;
        static void Main(string[] args)
        {
            //Singleton testSingleton = Singleton.GetInstance();
            //testSingleton = Singleton.GetInstance();

            ThreadStart start = new ThreadStart(Simulator.Create);
            Thread th1 = new Thread(start);
            Thread th2 = new Thread(start);

            th1.Start();
            th2.Start();
            
        }

        //Uncomment anyone to test the Thread Safety & comment others.
        public static void Create()
        {
            //testSingleton = Singleton.GetInstance(); //[NOT THREAD SAFE]
            //testSingleton = Singleton.GetInstanceSynchronized();
            //testSingleton = Singleton.GetInstanceVolatile();
            testSingleton = Singleton.GetInstanceEager();
        }
    }
}
