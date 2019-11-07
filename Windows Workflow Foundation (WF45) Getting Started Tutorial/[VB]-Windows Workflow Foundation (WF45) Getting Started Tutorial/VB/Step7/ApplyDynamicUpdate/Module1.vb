Imports NumberGuessWorkflowHost
Imports System.Data.SqlClient
Imports System.Activities.DynamicUpdate
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Activities
Imports System.Activities.DurableInstancing

Module Module1
    Const connectionString = "Server=.\SQLEXPRESS;Initial Catalog=WF45GettingStartedTutorial;Integrated Security=SSPI"

    Sub Main()
        Dim store = New SqlWorkflowInstanceStore(connectionString)
        WorkflowApplication.CreateDefaultInstanceOwner(store, Nothing, WorkflowIdentityFilter.Any)

        Dim updateMaps As IDictionary(Of WorkflowIdentity, DynamicUpdateInfo) = LoadMaps()

        For Each id As Guid In GetIds()
            'Get a proxy to the instance. 
            Dim instance As WorkflowApplicationInstance = WorkflowApplication.GetInstance(id, store)

            Console.WriteLine("Inspecting: {0}", instance.DefinitionIdentity)

            'Only update v1 workflows.
            If Not instance.DefinitionIdentity Is Nothing AndAlso _
                instance.DefinitionIdentity.Version.Equals(New Version(1, 0, 0, 0)) Then

                Dim info As DynamicUpdateInfo = updateMaps(instance.DefinitionIdentity)

                'Associate the persisted WorkflowApplicationInstance with
                'a WorkflowApplication that is configured with the updated
                'definition and updated WorkflowIdentity.
                Dim wf As Activity = WorkflowVersionMap.GetWorkflowDefinition(info.newIdentity)
                Dim wfApp = New WorkflowApplication(wf, info.newIdentity)

                'Apply the Dynamic Update.             
                wfApp.Load(instance, info.updateMap)

                'Persist the updated instance.
                wfApp.Unload()

                Console.WriteLine("Updated to: {0}", info.newIdentity)
            Else
                'Not updating this instance, so unload it.
                instance.Abandon()
            End If
        Next
    End Sub

    Function GetIds() As IList(Of Guid)
        Dim Ids As New List(Of Guid)
        Dim localCmd = _
            String.Format("Select [InstanceId] from [System.Activities.DurableInstancing].[Instances] Order By [CreationTime]")
        Using localCon = New SqlConnection(connectionString)
            Dim cmd As SqlCommand = localCon.CreateCommand()
            cmd.CommandText = localCmd
            localCon.Open()
            Using reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                While reader.Read()
                    'Get the InstanceId of the persisted Workflow
                    Dim id As Guid = Guid.Parse(reader(0).ToString())

                    'Add it to the list.
                    Ids.Add(id)
                End While
            End Using
        End Using

        Return Ids
    End Function

    Function LoadMap(mapName As String) As DynamicUpdateMap
        Dim mapPath As String = Path.Combine("..\..\..\PreviousVersions", mapName)

        Dim map As DynamicUpdateMap
        Using fs As FileStream = File.Open(mapPath, FileMode.Open)
            Dim serializer As DataContractSerializer = New DataContractSerializer(GetType(DynamicUpdateMap))
            Dim updateMap = serializer.ReadObject(fs)
            If updateMap Is Nothing Then
                Throw New ApplicationException("DynamicUpdateMap is null.")
            End If

            map = updateMap
        End Using

        Return map
    End Function

    Function LoadMaps() As IDictionary(Of WorkflowIdentity, DynamicUpdateInfo)
        'There are 3 update maps to describe the changes to update v1 workflows,
        'one for reach of the 3 workflow types in the tutorial.
        Dim maps = New Dictionary(Of WorkflowIdentity, DynamicUpdateInfo)()

        Dim sequentialMap As DynamicUpdateMap = LoadMap("SequentialNumberGuessWorkflow.map")
        Dim sequentialInfo = New DynamicUpdateInfo With
        {
            .updateMap = sequentialMap,
            .newIdentity = WorkflowVersionMap.SequentialNumberGuessIdentity_v15
        }
        maps.Add(WorkflowVersionMap.SequentialNumberGuessIdentity_v1, sequentialInfo)

        Dim stateMap As DynamicUpdateMap = LoadMap("StateMachineNumberGuessWorkflow.map")
        Dim stateInfo = New DynamicUpdateInfo With
        {
            .updateMap = stateMap,
            .newIdentity = WorkflowVersionMap.StateMachineNumberGuessIdentity_v15
        }
        maps.Add(WorkflowVersionMap.StateMachineNumberGuessIdentity_v1, stateInfo)

        Dim flowchartMap As DynamicUpdateMap = LoadMap("FlowchartNumberGuessWorkflow.map")
        Dim flowchartInfo = New DynamicUpdateInfo With
        {
            .updateMap = flowchartMap,
            .newIdentity = WorkflowVersionMap.FlowchartNumberGuessIdentity_v15
        }
        maps.Add(WorkflowVersionMap.FlowchartNumberGuessIdentity_v1, flowchartInfo)

        Return maps
    End Function



End Module
