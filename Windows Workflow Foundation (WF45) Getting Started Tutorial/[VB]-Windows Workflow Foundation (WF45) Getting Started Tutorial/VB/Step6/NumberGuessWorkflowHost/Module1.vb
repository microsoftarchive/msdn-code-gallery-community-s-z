Imports System.Activities
Imports System.Activities.Statements
Imports System.Diagnostics
Imports System.Linq
Imports NumberGuessWorkflowActivities
Imports System.Threading
Imports System.Collections.Generic
Imports System.Windows.Forms

Module Module1

    Sub Main()
        Application.EnableVisualStyles()
        Application.Run(New WorkflowHostForm())
    End Sub

    'Dim s As Sequence

    'Sub Main()
    '    Dim syncEvent As New AutoResetEvent(False)
    '    Dim idleEvent As New AutoResetEvent(False)

    '    Dim inputs As New Dictionary(Of String, Object)
    '    inputs.Add("MaxNumber", 100)

    '    Dim wfApp As New WorkflowApplication(New StateMachineNumberGuessWorkflow(), inputs)

    '    wfApp.Completed = _
    '        Sub(e As WorkflowApplicationCompletedEventArgs)
    '            Dim Turns As Integer = Convert.ToInt32(e.Outputs("Turns"))
    '            Console.WriteLine("Congratulations, you guessed the number in {0} turns.", Turns)

    '            syncEvent.Set()
    '        End Sub

    '    wfApp.Aborted = _
    '        Sub(e As WorkflowApplicationAbortedEventArgs)
    '            Console.WriteLine(e.Reason)
    '            syncEvent.Set()
    '        End Sub

    '    wfApp.OnUnhandledException = _
    '        Function(e As WorkflowApplicationUnhandledExceptionEventArgs)
    '            Console.WriteLine(e.UnhandledException)
    '            Return UnhandledExceptionAction.Terminate
    '        End Function

    '    wfApp.Idle = _
    '        Sub(e As WorkflowApplicationIdleEventArgs)
    '            idleEvent.Set()
    '        End Sub

    '    wfApp.Run()

    '    ' Loop until the workflow completes.
    '    Dim waitHandles As WaitHandle() = New WaitHandle() {syncEvent, idleEvent}
    '    Do While WaitHandle.WaitAny(waitHandles) <> 0
    '        'Gather the user input and resume the bookmark.
    '        Dim validEntry As Boolean = False
    '        Do While validEntry = False
    '            Dim Guess As Integer
    '            If Int32.TryParse(Console.ReadLine(), Guess) = False Then
    '                Console.WriteLine("Please enter an integer.")
    '            Else
    '                validEntry = True
    '                wfApp.ResumeBookmark("EnterGuess", Guess)
    '            End If
    '        Loop
    '    Loop
    'End Sub

End Module
