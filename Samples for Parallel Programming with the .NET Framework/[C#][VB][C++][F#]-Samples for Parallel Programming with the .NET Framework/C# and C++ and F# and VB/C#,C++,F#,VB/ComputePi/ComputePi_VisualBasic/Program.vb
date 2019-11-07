'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: Program.vb
'
'--------------------------------------------------------------------------

Imports System.Threading.Tasks
Imports System.Collections.Concurrent

Module ComputePi

    Const num_steps As Integer = 100000000

    ''' <summary>Main method to time various implementations of computing PI.</summary>
    Sub Main()

        While True
            Time(Function() SerialLinqPi())
            Time(Function() ParallelLinqPi())
            Time(Function() SerialPi())
            Time(Function() ParallelPi())
            Time(Function() ParallelPartitionerPi())

            Console.WriteLine("----")
            Console.ReadLine()
        End While

    End Sub

    ''' <summary>Times the execution of a function and outputs both the elapsed time and the function's result.</summary>
    Sub Time(Of T)(ByVal work As Func(Of T))
        Dim sw = Stopwatch.StartNew()
        Dim result = work()
        Console.WriteLine(sw.Elapsed.ToString() & ": " & result.ToString())
    End Sub

    ''' <summary>Estimates the value of PI using a LINQ-based implementation.</summary>
    Function SerialLinqPi() As Double
        Dim stepSize = 1.0 / num_steps
        Return (From i In Enumerable.Range(0, num_steps)
                Let x = (i + 0.5) * stepSize
                Select 4.0 / (1.0 + x * x)).Sum() * stepSize
    End Function

    ''' <summary>Estimates the value of PI using a PLINQ-based implementation.</summary>
    Function ParallelLinqPi() As Double
        Dim stepSize = 1.0 / num_steps
        Return (From i In ParallelEnumerable.Range(0, num_steps)
                Let x = (i + 0.5) * stepSize
                Select 4.0 / (1.0 + x * x)).Sum() * stepSize
    End Function


    ''' <summary>Estimates the value of PI using a For loop.</summary>
    Function SerialPi() As Double
        Dim sum = 0.0
        Dim stepSize = 1.0 / num_steps
        For i = 0 To num_steps - 1
            Dim x = (i + 0.5) * stepSize
            sum = sum + 4.0 / (1.0 + x * x)
        Next
        Return stepSize * sum
    End Function

    ''' <summary>Estimates the value of PI using a Parallel.For.</summary>
    Function ParallelPi() As Double
        Dim sum = 0.0
        Dim stepSize = 1.0 / num_steps
        Dim monitor = New Object()
        Parallel.For(0, num_steps, Function() 0.0, Function(i, state, local)
                                                       Dim x = (i + 0.5) * stepSize
                                                       Return local + 4.0 / (1.0 + x * x)
                                                   End Function,
                                                   Sub(local)
                                                       SyncLock (monitor)
                                                           sum += local
                                                       End SyncLock
                                                   End Sub)
        Return stepSize * sum
    End Function

    ''' <summary>Estimates the value of PI using a Parallel.ForEach and a range partitioner.</summary>
    Function ParallelPartitionerPi() As Double
        Dim sum = 0.0
        Dim stepSize = 1.0 / num_steps
        Dim monitor = New Object()
        Parallel.ForEach(Partitioner.Create(0, num_steps),
                         Function() 0.0,
                         Function(range, state, local)
                             For i = range.Item1 To range.Item2 - 1
                                 Dim x = (i + 0.5) * stepSize
                                 local = local + 4.0 / (1.0 + x * x)
                             Next
                             Return local
                         End Function,
                         Sub(local)
                             SyncLock (monitor)
                                 sum += local
                             End SyncLock
                         End Sub)
        Return stepSize * sum
    End Function

End Module