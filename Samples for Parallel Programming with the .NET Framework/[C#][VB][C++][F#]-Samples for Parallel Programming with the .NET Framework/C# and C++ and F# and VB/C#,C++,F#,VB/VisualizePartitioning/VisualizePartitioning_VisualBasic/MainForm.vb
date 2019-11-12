
Imports System
Imports System.Collections.Concurrent
Imports System.Collections.Concurrent.Partitioners
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Drawing
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports Microsoft.Drawing

Namespace VisualizePartitioning
    Partial Public Class MainForm
        Inherits Form
        ''' <summary>Name and identifier for turning on stripe partitioning with PLINQ.</summary>
        Const PartitioningStripe As String = "Stripe"
        ''' <summary>Name and identifier for turning on hash partitioning with PLINQ.</summary>
        Const PartitioningHash As String = "Hash"

        ''' <summary>Color palette to use when rendering threads.</summary>
        Private _colors As Color()
        ''' <summary>A multiplicative factor of how much work to do for each rendered line.</summary>
        Private _workFactor As Integer

        ''' <summary>Provides a source of seeds for thread-local random instances.</summary>
        Private Shared _randomnessSeed As New Random()
        ''' <summary>A thread-safe source of randomness for all threads that need random values.</summary>
        Private Shared _localRandom As New ThreadLocal(Of Random)(Function()
                                                                      SyncLock _randomnessSeed
                                                                          Return New Random(_randomnessSeed.[Next]())
                                                                      End SyncLock
                                                                  End Function)

        Public Sub New()
            InitializeComponent()

            ' Configure the workloads and the color palette. The partitioning methods initialization will be done
            ' when the radio button is changed to Parallel.ForEach or PLINQ. The color palette will be
            ' initialized when the cores trackbar changes value.
            InitializeWorkloads()

            ' Configure number of cores.
            With tbCores
                .Minimum = 1
                .Maximum = Environment.ProcessorCount * 2
                .Value = Environment.ProcessorCount
            End With
           
        End Sub

        ''' <summary>Initializes the color palette to use when rendering threads.</summary>
        Private Sub InitializeColorPalette()
            Dim random As New Random(8)
            ' Change seed value to change the palette used.
            _colors = (From i In Enumerable.Range(0, tbCores.Value)
                Select Color.FromArgb(random.[Next](128) + 127, random.[Next](128) + 127, random.[Next](128) + 127)).ToArray()
        End Sub

        ''' <summary>Initializes the workloads list view.</summary>
        Private Sub InitializeWorkloads()
            lvWorkloads.Items.Clear()
            Dim workloads = New List(Of Tuple(Of String, Func(Of Integer, Integer, Integer)))()
            ' NOTE: To add a new workload, simply add a new entry below with a name and corresponding function.
            With workloads
                .Add(Tuple.Create(Of String, Func(Of Integer, Integer, Integer))("Constant", Function(size, current) 1000 * _workFactor))
                .Add(Tuple.Create(Of String, Func(Of Integer, Integer, Integer))("Increasing Linear", Function(size, current) 200 * current * _workFactor))
                .Add(Tuple.Create(Of String, Func(Of Integer, Integer, Integer))("Decreasing Linear", Function(size, current) 200 * (size - current) * _workFactor))
                .Add(Tuple.Create(Of String, Func(Of Integer, Integer, Integer))("Random", Function(size, current) _localRandom.Value.[Next](100, 10000) * _workFactor))
            End With

            For Each workload In workloads
                lvWorkloads.Items.Add(New ListViewItem(workload.Item1) With {.Tag = workload})
            Next
            lvWorkloads.Items(0).Selected = True
        End Sub

        ''' <summary>Initializes the partitioning methods list view.</summary>
        Private Sub InitializePartitioningMethods()
            lvPartitioningMethods.Items.Clear()
            Dim usingPLINQ As Boolean = rbPLINQ.Checked
            Dim partitioningMethods = New List(Of Tuple(Of String, Func(Of Integer(), Partitioner(Of Integer))))()

            ' Static partitioning using the Partitioner.Create overload requires static partitioner support,
            ' which Parallel.ForEach does not provide.
            If usingPLINQ Then
                partitioningMethods.Add(Tuple.Create(Of String, Func(Of Integer(), Partitioner(Of Integer)))("Static", Function(e) partitioner.Create(e, False)))
            End If

            ' Add a bunch of partitioning approaches that work with both PLINQ and Parallel.ForEach.
            With partitioningMethods
                .Add(Tuple.Create(Of String, Func(Of Integer(), Partitioner(Of Integer)))("Load Balance", Function(e) partitioner.Create(e, True)))
                .Add(Tuple.Create(Of String, Func(Of Integer(), Partitioner(Of Integer)))("Dynamic(1)", Function(e) ChunkPartitioner.Create(e, 1)))
                .Add(Tuple.Create(Of String, Func(Of Integer(), Partitioner(Of Integer)))("Dynamic(16)", Function(e) ChunkPartitioner.Create(e, 16)))
                .Add(Tuple.Create(Of String,  _
                Func(Of Integer(), Partitioner(Of Integer)))("Guided", Function(e) ChunkPartitioner.Create(e, Function(prev)
                                                                                                                  If prev <= 0 Then
                                                                                                                      Return If(e.Length <= 1, 1,
                                                                                                                                CType(e.Length /
                                                                                                                                    (Environment.ProcessorCount * 3), Integer))
                                                                                                                  End If
                                                                                                                  Dim [next] = CType(prev / 2, Integer)
                                                                                                                  Return If([next] <= 0, prev, [next])
                                                                                                              End Function)))
                .Add(Tuple.Create(Of String,  _
                                        Func(Of Integer(),  _
                                             Partitioner(Of Integer)))("Grow Exponential", Function(e) ChunkPartitioner.Create(e, Function(prev) If(prev <= 0, 1, prev * 2))))
                .Add(Tuple.Create(Of String,  _
                                        Func(Of Integer(), Partitioner(Of Integer)))("Random", Function(e) ChunkPartitioner.Create(e, Function(prev) _localRandom.Value.[Next](e.Length))))

            End With

            ' Special-case some PLINQ-only hashing.
            If usingPLINQ Then
                ' The actual enabling of these partitioning schemes is done later, as they can't 
                ' be encoded in a partitioner but rather are based on what operators are used in the PLINQ query.
                partitioningMethods.Add(Tuple.Create(Of String, Func(Of Integer(), Partitioner(Of Integer)))(PartitioningStripe, Function(e) partitioner.Create(e)))
                partitioningMethods.Add(Tuple.Create(Of String, Func(Of Integer(), Partitioner(Of Integer)))(PartitioningHash, Function(e) partitioner.Create(e)))
            End If

            ' Dump the partitioners into the list view.
            For Each method In partitioningMethods
                lvPartitioningMethods.Items.Add(New ListViewItem(method.Item1) With {.Tag = method})
            Next
            lvPartitioningMethods.Items(0).Selected = True
        End Sub

        ''' <summary>Visualize the partitioning.</summary>
        Private Sub btnVisualize_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnVisualize.Click
            Dim numProcs = tbCores.Value
            Dim width = pbPartitionedImage.Width
            Dim height = pbPartitionedImage.Height
            Dim useParallelFor = rbParallelFor.Checked
            Dim useParallelForEach = rbParallelForEach.Checked
            _workFactor = tbWorkFactor.Value

            ' If we're using Parallel.ForEach or PLINQ, ensure a partitioning scheme was selected and use it.
            Dim selectedMethod As Tuple(Of String, Func(Of Integer(), Partitioner(Of Integer))) = Nothing
            If Not useParallelFor Then
                If lvPartitioningMethods.SelectedIndices.Count = 0 Then
                    Exit Sub
                Else
                    selectedMethod = DirectCast(lvPartitioningMethods.SelectedItems(0).Tag, Tuple(Of String, Func(Of Integer(), Partitioner(Of Integer))))
                End If
            End If

            ' Make sure a workload was selected and use it.
            If lvWorkloads.SelectedItems.Count = 0 Then
                Exit Sub
            End If

            Dim selectedWorkload = DirectCast(lvWorkloads.SelectedItems(0).Tag, Tuple(Of String, Func(Of Integer, Integer, Integer)))

            ' Create a new Bitmap to store the rendered output
            Dim bmp = New Bitmap(width, height)

            ' Disable the start button and kick off the background work.
            btnVisualize.Enabled = False
            ' Assign each thread a unique id.
            ' Get faster access to the Bitmap's contents.
            ' Time the operation.
            ' Create the partitioner to be used.
            ' Run the work with Parallel.ForEach
            ' PLINQ.
            ' Run the work with PLINQ. If a special partitioning method was selected, use relevant query operators
            ' to get PLINQ to use that partitioning approach.
            ' Return the total time from the task
            ' When the work completes, run the following on the UI thread.

            Task.Factory.StartNew(Function()
                                      Dim nextId = -1
                                      Dim threadId = New ThreadLocal(Of Integer)(Function() Interlocked.Increment(nextId))
                                      Using fastBmp As New FastBitmap(bmp)
                                          Dim sw = Stopwatch.StartNew()
                                          If useParallelFor Then
                                              If fastBmp Is Nothing Then
                                                  MsgBox("FastBmp Disposed")
                                              End If
                                              Parallel.[For](0, height, New ParallelOptions(), Sub(i)
                                                                                                   Dim id = threadId.Value
                                                                                                   DoWork(selectedWorkload.Item2(height, i))

                                                                                                   For j = 0 To width - 1
                                                                                                       fastBmp.SetColor(j, i, _colors(id Mod _colors.Length))
                                                                                                   Next
                                                                                               End Sub)
                                          Else
                                              Dim partitioner = selectedMethod.Item2(Enumerable.Range(0, height).ToArray())
                                              If useParallelForEach Then
                                                  Parallel.ForEach(partitioner, New ParallelOptions(), Sub(i)
                                                                                                           Dim id = threadId.Value
                                                                                                           DoWork(selectedWorkload.Item2(height, i))
                                                                                                           For j = 0 To width - 1
                                                                                                               fastBmp.SetColor(j, i, _colors(id Mod _colors.Length))
                                                                                                           Next
                                                                                                       End Sub)
                                              Else
                                                  Dim source = partitioner.AsParallel().WithDegreeOfParallelism(numProcs)
                                                  If selectedMethod.Item1 = PartitioningStripe Then
                                                      source = source.TakeWhile(Function(elem) True)
                                                  ElseIf selectedMethod.Item1 = PartitioningHash Then
                                                      source = source.Join(Enumerable.Range(0, height).AsParallel(), Function(i) i, Function(i) i, Function(i, ignore) i)
                                                  End If
                                                  source.ForAll(Sub(i)
                                                                    Dim id = threadId.Value
                                                                    DoWork(selectedWorkload.Item2(height, i))
                                                                    For j = 0 To width - 1
                                                                        fastBmp.SetColor(j, i, _colors(id Mod _colors.Length))
                                                                    Next
                                                                End Sub)
                                              End If
                                          End If
                                          Return sw.Elapsed
                                      End Using
                                  End Function).ContinueWith(Sub(t)
                                                                 ' Dispose of the old image (if there was one) and display the new one.
                                                                 Dim old = pbPartitionedImage.Image
                                                                 pbPartitionedImage.Image = bmp
                                                                 If old IsNot Nothing Then
                                                                     old.Dispose()
                                                                 End If

                                                                 ' Re-enable controls on the form and display the elapsed time.
                                                                 btnVisualize.Enabled = True
                                                                 lblTime.Text = "Time: " & t.Result.ToString()
                                                             End Sub, TaskScheduler.FromCurrentSynchronizationContext())
        End Sub

        ''' <summary>Does an amount of work relative to the amount requested.</summary>
        ''' <param name="workAmount">The amount of work to perform.</param>
        <MethodImpl(MethodImplOptions.NoOptimization Or MethodImplOptions.NoInlining)>
        Private Shared Function DoWork(ByVal workAmount As Integer) As Integer
            Try
                Dim value = 1
                For i = 0 To workAmount - 1
                    value = value * workAmount
                Next i
                Return value
            Catch
                Return 0
            End Try
        End Function

        ''' <summary>Update relevant portions of the form when the API radio buttons are checked.</summary>
        ''' <param name="sender">The radio button.</param>
        ''' <param name="e">The event args.</param>
        Private Sub rbAPI_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles rbParallelForEach.CheckedChanged,
            rbPLINQ.CheckedChanged, rbParallelFor.CheckedChanged
            lvPartitioningMethods.Enabled = Not rbParallelFor.Checked
            lvPartitioningMethods.HideSelection = Not lvPartitioningMethods.Enabled

            ' Recreate partitioning methods every time a radio button is checked,
            ' as which API is selected determines which partitioning methods are available.
            InitializePartitioningMethods()
        End Sub

        Private Sub tbCores_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles tbCores.ValueChanged
            toolTip1.SetToolTip(tbCores, tbCores.Value.ToString())
            InitializeColorPalette()
            Dim worker As Integer
            Dim io As Integer
            ThreadPool.GetMinThreads(worker, io)
            ThreadPool.SetMinThreads(tbCores.Value, io)
        End Sub

        Private Sub tbWorkFactor_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles tbWorkFactor.ValueChanged
            toolTip1.SetToolTip(tbWorkFactor, tbWorkFactor.Value.ToString())
        End Sub
    End Class
End Namespace