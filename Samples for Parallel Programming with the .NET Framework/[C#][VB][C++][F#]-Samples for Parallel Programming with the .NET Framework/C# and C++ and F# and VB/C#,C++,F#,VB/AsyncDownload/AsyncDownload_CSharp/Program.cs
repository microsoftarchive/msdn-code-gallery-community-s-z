//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: Program.cs
//
//--------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        // NOTE: Synchronous .Wait() calls added only for demo purposes

        // Single async request
        Download("http://www.microsoft.com").ContinueWith(CompletedDownloadData).Wait();

        // Single async request with timeout
        Download("http://www.microsoft.com").WithTimeout(new TimeSpan(0, 0, 0, 0, 1)).ContinueWith(CompletedDownloadData).Wait();

        // Serial async requests
        Task.Factory.TrackedSequence(
            () => Download("http://blogs.msdn.com/pfxteam"),
            () => Download("http://blogs.msdn.com/nativeconcurrency"),
            () => Download("http://exampleexampleexample.com"), // will fail
            () => Download("http://msdn.com/concurrency"),
            () => Download("http://bing.com")
        ).ContinueWith(SerialTasksCompleted).Wait();

        // Concurrent async requests
        Task.Factory.ContinueWhenAll(new []
        {
            Download("http://blogs.msdn.com/pfxteam"),
            Download("http://blogs.msdn.com/nativeconcurrency"),
            Download("http://exampleexampleexample.com"), // will fail
            Download("http://msdn.com/concurrency"),
            Download("http://bing.com")
        }, ConcurrentTasksCompleted).Wait();

        // Done
        Console.WriteLine();
        Console.WriteLine("Press <enter> to exit.");
        Console.ReadLine();
    }

    static Task<byte[]> Download(string url)
    {
        return new WebClient().DownloadDataTask(url);
    }

    static void CompletedDownloadData(Task<byte[]> task)
    {
        switch (task.Status)
        {
            case TaskStatus.RanToCompletion:
                Console.WriteLine("Request succeeded: {0}", task.Result.Length);
                break;
            case TaskStatus.Faulted:
                Console.WriteLine("Request failed: {0}", task.Exception.InnerException);
                break;
            case TaskStatus.Canceled:
                Console.WriteLine("Request was canceled");
                break;
        }
    }

    static void SerialTasksCompleted(Task<IList<Task>> tasks)
    {
        int failures = tasks.Result.Where(t => t.Exception != null).Count();
        Console.WriteLine("Serial result: {0} successes and {1} failures", tasks.Result.Count() - failures, failures);
    }

    static void ConcurrentTasksCompleted(Task<byte[]>[] tasks)
    {
        int failures = tasks.Where(t => t.Exception != null).Count();
        Console.WriteLine("Concurrent result: {0} successes and {1} failures", tasks.Length - failures, failures);
    }
}