'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: Program.cs
'
'--------------------------------------------------------------------------

Imports System.Net
Imports System.Collections.Generic
Imports System.Threading.Tasks

Module Module1

    Sub Main()
        ' NOTE: Synchronous .Wait() calls added only for demo purposes

        ' Single async request
        Download("http://www.microsoft.com").ContinueWith(AddressOf CompletedDownloadData).Wait()

        ' Single async request with timeout
        Download("http://www.microsoft.com").WithTimeout(New TimeSpan(0, 0, 0, 0, 1)).ContinueWith(AddressOf CompletedDownloadData).Wait()

        ' Concurrent async requests
        Task.Factory.ContinueWhenAll(
        {
            Download("http://blogs.msdn.com/pfxteam"),
            Download("http://blogs.msdn.com/nativeconcurrency"),
            Download("http://exampleexampleexample.com"),
            Download("http://msdn.com/concurrency"),
            Download("http://bing.com")
        }, AddressOf ConcurrentTasksCompleted).Wait()

        ' Serial async requests
        Task.Factory.TrackedSequence(
            Function() Download("http://blogs.msdn.com/pfxteam"),
            Function() Download("http://blogs.msdn.com/nativeconcurrency"),
            Function() Download("http://exampleexampleexample.com"),
            Function() Download("http://msdn.com/concurrency"),
            Function() Download("http://bing.com")
        ).ContinueWith(AddressOf SerialTasksCompleted).Wait()

        ' Done
        Console.WriteLine()
        Console.WriteLine("Press <enter> to exit.")
        Console.ReadLine()
    End Sub

    Function Download(ByVal url As String) As Task(Of Byte())
        Dim wc As New WebClient
        Return wc.DownloadDataTask(url)
    End Function

    Sub CompletedDownloadData(ByVal task As Task(Of Byte()))
        If task.Status = TaskStatus.RanToCompletion Then
            Console.WriteLine("Request succeeded: {0}", task.Result.Length)
        ElseIf task.Status = TaskStatus.Faulted Then
            Console.WriteLine("Request failed: {0}", task.Exception.InnerException)
        ElseIf task.Status = TaskStatus.Canceled Then
            Console.WriteLine("Request was canceled")
        End If
    End Sub

    Sub SerialTasksCompleted(ByVal tasks As Task(Of IList(Of Task)))
        Dim failures = tasks.Result.Where(Function(t) t.Exception IsNot Nothing).Count()
        Console.WriteLine("Serial result: {0} successes and {1} failures", tasks.Result.Count() - failures, failures)
    End Sub

    Sub ConcurrentTasksCompleted(ByVal tasks As Task(Of Byte())())
        Dim failures = tasks.Where(Function(t) t.Exception IsNot Nothing).Count()
        Console.WriteLine("Concurrent result: {0} successes and {1} failures", tasks.Length - failures, failures)
    End Sub
End Module
