Imports NumberGuessWorkflowActivities
Imports System.Activities

Public Module WorkflowVersionMap
    Dim map As Dictionary(Of WorkflowIdentity, Activity)

    'Current version identities.
    Public StateMachineNumberGuessIdentity As WorkflowIdentity
    Public FlowchartNumberGuessIdentity As WorkflowIdentity
    Public SequentialNumberGuessIdentity As WorkflowIdentity

    Sub New()
        map = New Dictionary(Of WorkflowIdentity, Activity)

        'Add the current workflow version identities.
        StateMachineNumberGuessIdentity = New WorkflowIdentity With
        {
            .Name = "StateMachineNumberGuessWorkflow",
            .Version = New Version(1, 0, 0, 0)
        }

        FlowchartNumberGuessIdentity = New WorkflowIdentity With
        {
            .Name = "FlowchartNumberGuessWorkflow",
            .Version = New Version(1, 0, 0, 0)
        }

        SequentialNumberGuessIdentity = New WorkflowIdentity With
        {
            .Name = "SequentialNumberGuessWorkflow",
            .Version = New Version(1, 0, 0, 0)
        }

        map.Add(StateMachineNumberGuessIdentity, New StateMachineNumberGuessWorkflow())
        map.Add(FlowchartNumberGuessIdentity, New FlowchartNumberGuessWorkflow())
        map.Add(SequentialNumberGuessIdentity, New SequentialNumberGuessWorkflow())
    End Sub

    Public Function GetWorkflowDefinition(identity As WorkflowIdentity) As Activity
        Return map(identity)
    End Function

    Public Function GetIdentityDescription(identity As WorkflowIdentity) As String
        Return identity.ToString()
    End Function
End Module
