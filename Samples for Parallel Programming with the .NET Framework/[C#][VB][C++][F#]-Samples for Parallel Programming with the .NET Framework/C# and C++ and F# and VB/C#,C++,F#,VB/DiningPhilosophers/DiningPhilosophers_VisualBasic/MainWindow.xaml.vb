'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: MainWindow.xaml.vb
'
'--------------------------------------------------------------------------
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Threading
Imports System.Threading.Async
Imports System.Threading.Tasks
Imports System.Windows
Imports System.Windows.Media
Imports System.Windows.Shapes


Namespace DiningPhilosophers
    ''' <summary>Application logic.</summary>
    Partial Public Class MainWindow
        Inherits Window
        ''' <summary>The number of philosophers to employ in the simulation.</summary>
        Private Const NUM_PHILOSOPHERS As Integer = 5
        ''' <summary>The timescale to use for thinking and eating (any positive value; the larger, the linearly longer amount of time).</summary>
        Private Const TIMESCALE As Integer = 200
        ''' <summary>The philosophers, represented as Ellipse WPF objects.</summary>
        Private _philosophers() As Ellipse
        ''' <summary>A TaskFactory for running tasks on the UI.</summary>
        Private _ui As TaskFactory

        ''' <summary>Initializes the MainWindow.</summary>
        Public Sub New()
            ' Initialize the component's layout.
            InitializeComponent()

            ' Grab a TaskFactory for creating Tasks that run on the UI.
            _ui = New TaskFactory(TaskScheduler.FromCurrentSynchronizationContext())

            ' Initialize the philosophers, and then run them.
            ConfigurePhilosophers()

            ' Uncomment one of the following three lines.
            RunWithSemaphoresSyncWithOrderedForks() ' 1. use synchronous semaphores, with ordered forks.
            'RunWithSemaphoresSyncWithWaitAll()  ' 2. use synchronous semaphores, with WaitAll.
        End Sub

#Region "Colors"
        ''' <summary>A brush for rendering thinking philosophers.</summary>
        Private _think As Brush = Brushes.Yellow
        ''' <summary>A brush for rendering eating philosophers.</summary>
        Private _eat As Brush = Brushes.Green
        ''' <summary>A brush for rendering waiting philosophers.</summary>
        Private _wait As Brush = Brushes.Red
#End Region

#Region "Helpers"
        ''' <summary>Initialize the philosophers.</summary>
        ''' <param name="numPhilosophers">The number of philosophers to initialize.</param>
        Private Sub ConfigurePhilosophers()
            _philosophers = (
             From i In Enumerable.Range(0, NUM_PHILOSOPHERS)
             Select New Ellipse With {.Height = 75, .Width = 75, .Fill = Brushes.Red, .Stroke = Brushes.Black}).ToArray()
            For Each philosopher In _philosophers
                circularPanel1.Children.Add(philosopher)
            Next philosopher
        End Sub

        ''' <summary>Gets the fork IDs of the forks for a particular philosopher.</summary>
        ''' <param name="philosopherIndex">The index of the philosopher whose IDs are being retrieved.</param>
        ''' <param name="numForks">The number of forks that exist.</param>
        ''' <param name="left">The ID of the philosopher's left fork.</param>
        ''' <param name="right">The ID of the philosopher's right fork.</param>
        ''' <param name="sort">Whether to sort the forks, so that the left fork is always smaller than the right.</param>
        Private Sub GetForkIds(ByVal philosopherIndex As Integer, ByVal numForks As Integer,
                               <System.Runtime.InteropServices.Out()> ByRef left As Integer,
                               <System.Runtime.InteropServices.Out()> ByRef right As Integer, ByVal sort As Boolean)
            ' The forks for a philosopher are the ones at philosopherIndex and philosopherIndex+1, though
            ' the latter can wrap around.  We need to ensure they're always acquired in the right order, to
            ' prevent deadlock, so order them.
            left = philosopherIndex
            right = (philosopherIndex + 1) Mod numForks
            If sort AndAlso left > right Then
                Dim tmp = left
                left = right
                right = tmp
            End If
        End Sub
#End Region

#Region "Synchronous, Ordered"
        ''' <summary>Runs the philosophers utilizing one thread per philosopher.</summary>
        Private Sub RunWithSemaphoresSyncWithOrderedForks()
            Dim forks = (
             From i In Enumerable.Range(0, _philosophers.Length)
             Select New SemaphoreSlim(1, 1)).ToArray()
            For i = 0 To _philosophers.Length - 1
                Dim index = i
                Task.Factory.StartNew(Sub() RunPhilosopherSyncWithOrderedForks(forks, index), TaskCreationOptions.LongRunning)
            Next i
        End Sub

        ''' <summary>Runs a philosopher synchronously.</summary>
        ''' <param name="forks">The forks, represented as semaphores.</param>
        ''' <param name="index">The philosopher's index number.</param>
        Private Sub RunPhilosopherSyncWithOrderedForks(ByVal forks() As SemaphoreSlim, ByVal index As Integer)
            ' Assign forks.
            Dim fork1Id, fork2Id As Integer
            GetForkIds(index, forks.Length, fork1Id, fork2Id, True)
            Dim fork1 = forks(fork1Id), fork2 = forks(fork2Id)

            ' Think and Eat, repeatedly.
            Dim rand = New Random(index)
            While True
                ' Think (Yellow).
                _ui.StartNew(Sub()
                                 _philosophers(index).Fill = _think
                             End Sub).Wait()
                Thread.Sleep(rand.Next(10) * TIMESCALE)

                ' Wait for forks (Red).
                fork1.Wait()

                _ui.StartNew(Sub() _philosophers(index).Fill = _wait).Wait()
                fork2.Wait()

                ' Eat (Green).
                _ui.StartNew(Sub() _philosophers(index).Fill = _eat).Wait()
                Thread.Sleep(rand.Next(10) * TIMESCALE)

                ' Done with forks.
                fork1.Release()
                fork2.Release()
            End While
        End Sub
#End Region

#Region "Synchronous, WaitAll"
        ''' <summary>Runs the philosophers utilizing one thread per philosopher.</summary>
        Private Sub RunWithSemaphoresSyncWithWaitAll()
            Dim forks = (
             From i In Enumerable.Range(0, _philosophers.Length)
             Select New Semaphore(1, 1)).ToArray()
            For i = 0 To _philosophers.Length - 1
                Dim index = i
                Task.Factory.StartNew(Sub() RunPhilosopherSyncWithWaitAll(forks, index), TaskCreationOptions.LongRunning)
            Next i
        End Sub

        ''' <summary>Runs a philosopher synchronously.</summary>
        ''' <param name="forks">The forks, represented as semaphores.</param>
        ''' <param name="index">The philosopher's index number.</param>
        Private Sub RunPhilosopherSyncWithWaitAll(ByVal forks() As Semaphore, ByVal index As Integer)
            ' Assign forks.
            Dim fork1Id, fork2Id As Integer
            GetForkIds(index, forks.Length, fork1Id, fork2Id, False)
            Dim fork1 = forks(fork1Id), fork2 = forks(fork2Id)

            ' Think and Eat, repeatedly.
            Dim rand = New Random(index)
            While True
                ' Think (Yellow).
                _ui.StartNew(Sub() _philosophers(index).Fill = _think).Wait()
                Thread.Sleep(rand.Next(10) * TIMESCALE)

                ' Wait for forks (Red).
                _ui.StartNew(Sub() _philosophers(index).Fill = _wait).Wait()
                WaitHandle.WaitAll({fork1, fork2})

                ' Eat (Green).
                _ui.StartNew(Sub() _philosophers(index).Fill = _eat).Wait()
                Thread.Sleep(rand.Next(10) * TIMESCALE)

                ' Done with forks.
                fork1.Release()
                fork2.Release()
            End While
        End Sub
#End Region

    End Class
End Namespace