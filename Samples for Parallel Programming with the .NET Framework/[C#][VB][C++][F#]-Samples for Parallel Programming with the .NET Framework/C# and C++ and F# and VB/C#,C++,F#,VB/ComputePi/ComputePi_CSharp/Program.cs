//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: Program.cs
//
//--------------------------------------------------------------------------

using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    const int num_steps = 100000000;

    /// <summary>Main method to time various implementations of computing PI.</summary>
    static void Main(string[] args)
    {
        while (true)
        {
            Time(() => SerialLinqPi());
            Time(() => ParallelLinqPi());
            Time(() => SerialPi());
            Time(() => ParallelPi());
            Time(() => ParallelPartitionerPi());

            Console.WriteLine("----");
            Console.ReadLine();
        }
    }

    /// <summary>Times the execution of a function and outputs both the elapsed time and the function's result.</summary>
    static void Time<T>(Func<T> work)
    {
        var sw = Stopwatch.StartNew();
        var result = work();
        Console.WriteLine(sw.Elapsed + ": " + result);
    }

    /// <summary>Estimates the value of PI using a LINQ-based implementation.</summary>
    static double SerialLinqPi()
    {
        double step = 1.0 / (double)num_steps;
        return (from i in Enumerable.Range(0, num_steps)
                let x = (i + 0.5) * step
                select 4.0 / (1.0 + x * x)).Sum() * step;
    }

    /// <summary>Estimates the value of PI using a PLINQ-based implementation.</summary>
    static double ParallelLinqPi()
    {
        double step = 1.0 / (double)num_steps;
        return (from i in ParallelEnumerable.Range(0, num_steps)
                let x = (i + 0.5) * step
                select 4.0 / (1.0 + x * x)).Sum() * step;
    }

    /// <summary>Estimates the value of PI using a for loop.</summary>
    static double SerialPi()
    {
        double sum = 0.0;
        double step = 1.0 / (double)num_steps;
        for (int i = 0; i < num_steps; i++)
        {
            double x = (i + 0.5) * step;
            sum = sum + 4.0 / (1.0 + x * x);
        }
        return step * sum;
    }

    /// <summary>Estimates the value of PI using a Parallel.For.</summary>
    static double ParallelPi()
    {
        double sum = 0.0;
        double step = 1.0 / (double)num_steps;
        object monitor = new object();
        Parallel.For(0, num_steps, () => 0.0, (i, state, local) =>
        {
            double x = (i + 0.5) * step;
            return local + 4.0 / (1.0 + x * x);
        }, local => { lock (monitor) sum += local; });
        return step * sum;
    }

    /// <summary>Estimates the value of PI using a Parallel.ForEach and a range partitioner.</summary>
    static double ParallelPartitionerPi()
    {
        double sum = 0.0;
        double step = 1.0 / (double)num_steps;
        object monitor = new object();
        Parallel.ForEach(Partitioner.Create(0, num_steps), () => 0.0, (range, state, local) =>
        {
            for (int i = range.Item1; i < range.Item2; i++)
            {
                double x = (i + 0.5) * step;
                local += 4.0 / (1.0 + x * x);
            }
            return local;
        }, local => { lock (monitor) sum += local; });
        return step * sum;
    }
}