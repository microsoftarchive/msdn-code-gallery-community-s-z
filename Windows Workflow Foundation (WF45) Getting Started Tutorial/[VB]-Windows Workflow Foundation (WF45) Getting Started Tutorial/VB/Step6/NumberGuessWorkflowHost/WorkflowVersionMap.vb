Imports NumberGuessWorkflowActivities
Imports System.Activities
Imports System.Reflection
Imports System.IO

Public Module WorkflowVersionMap
    Dim map As Dictionary(Of WorkflowIdentity, Activity)

    'Current version identities.
    Public StateMachineNumberGuessIdentity As WorkflowIdentity
    Public FlowchartNumberGuessIdentity As WorkflowIdentity
    Public SequentialNumberGuessIdentity As WorkflowIdentity

    'v1 Identities.
    Public StateMachineNumberGuessIdentity_v1 As WorkflowIdentity
    Public FlowchartNumberGuessIdentity_v1 As WorkflowIdentity
    Public SequentialNumberGuessIdentity_v1 As WorkflowIdentity

    Sub New()
        map = New Dictionary(Of WorkflowIdentity, Activity)

        'Add the current workflow version identities.
        StateMachineNumberGuessIdentity = New WorkflowIdentity With
        {
            .Name = "StateMachineNumberGuessWorkflow",
            .Version = New Version(2, 0, 0, 0)
        }

        FlowchartNumberGuessIdentity = New WorkflowIdentity With
        {
            .Name = "FlowchartNumberGuessWorkflow",
            .Version = New Version(2, 0, 0, 0)
        }

        SequentialNumberGuessIdentity = New WorkflowIdentity With
        {
            .Name = "SequentialNumberGuessWorkflow",
            .Version = New Version(2, 0, 0, 0)
        }

        map.Add(StateMachineNumberGuessIdentity, New StateMachineNumberGuessWorkflow())
        map.Add(FlowchartNumberGuessIdentity, New FlowchartNumberGuessWorkflow())
        map.Add(SequentialNumberGuessIdentity, New SequentialNumberGuessWorkflow())

        'Initialize the previous workflow version identities.
        StateMachineNumberGuessIdentity_v1 = New WorkflowIdentity With
        {
            .Name = "StateMachineNumberGuessWorkflow",
            .Version = New Version(1, 0, 0, 0)
        }

        FlowchartNumberGuessIdentity_v1 = New WorkflowIdentity With
        {
            .Name = "FlowchartNumberGuessWorkflow",
            .Version = New Version(1, 0, 0, 0)
        }

        SequentialNumberGuessIdentity_v1 = New WorkflowIdentity With
        {
            .Name = "SequentialNumberGuessWorkflow",
            .Version = New Version(1, 0, 0, 0)
        }

        'Add the previous version workflow identities to the dictionary along with
        'the corresponding workflow definitions loaded from the v1 assembly.
        'Assembly.LoadFile requires an absolute path so convert this relative path
        'to an absolute path.
        Dim v1AssemblyPath As String = "..\..\..\PreviousVersions\NumberGuessWorkflowActivities_v1.dll"
        v1AssemblyPath = Path.GetFullPath(v1AssemblyPath)
        Dim v1Assembly As Assembly = Assembly.LoadFile(v1AssemblyPath)

        map.Add(StateMachineNumberGuessIdentity_v1,
            v1Assembly.CreateInstance("NumberGuessWorkflowActivities.StateMachineNumberGuessWorkflow"))

        map.Add(SequentialNumberGuessIdentity_v1,
            v1Assembly.CreateInstance("NumberGuessWorkflowActivities.SequentialNumberGuessWorkflow"))

        map.Add(FlowchartNumberGuessIdentity_v1,
            v1Assembly.CreateInstance("NumberGuessWorkflowActivities.FlowchartNumberGuessWorkflow"))
    End Sub

    Public Function GetWorkflowDefinition(identity As WorkflowIdentity) As Activity
        Return map(identity)
    End Function

    Public Function GetIdentityDescription(identity As WorkflowIdentity) As String
        Return identity.ToString()
    End Function
End Module
