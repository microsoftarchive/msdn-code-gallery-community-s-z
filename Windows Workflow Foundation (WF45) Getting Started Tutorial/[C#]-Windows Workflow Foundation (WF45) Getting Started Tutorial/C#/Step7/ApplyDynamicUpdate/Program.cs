using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NumberGuessWorkflowHost;
using System.Data;
using System.Data.SqlClient;
using System.Activities;
using System.Activities.DynamicUpdate;
using System.IO;
using System.Runtime.Serialization;
using System.Activities.DurableInstancing;

namespace ApplyDynamicUpdate
{
    class Program
    {
        const string connectionString = "Server=.\\SQLEXPRESS;Initial Catalog=WF45GettingStartedTutorial;Integrated Security=SSPI";

        static void Main(string[] args)
        {
            SqlWorkflowInstanceStore store = new SqlWorkflowInstanceStore(connectionString);
            WorkflowApplication.CreateDefaultInstanceOwner(store, null, WorkflowIdentityFilter.Any);

            IDictionary<WorkflowIdentity, DynamicUpdateInfo> updateMaps = LoadMaps();

            foreach (Guid id in GetIds())
            {
                // Get a proxy to the instance. 
                WorkflowApplicationInstance instance =
                    WorkflowApplication.GetInstance(id, store);

                Console.WriteLine("Inspecting: {0}", instance.DefinitionIdentity);

                // Only update v1 workflows.
                if (instance.DefinitionIdentity != null &&
                    instance.DefinitionIdentity.Version.Equals(new Version(1, 0, 0, 0)))
                {
                    DynamicUpdateInfo info = updateMaps[instance.DefinitionIdentity];

                    // Associate the persisted WorkflowApplicationInstance with
                    // a WorkflowApplication that is configured with the updated
                    // definition and updated WorkflowIdentity.
                    Activity wf = WorkflowVersionMap.GetWorkflowDefinition(info.newIdentity);
                    WorkflowApplication wfApp =
                        new WorkflowApplication(wf, info.newIdentity);

                    // Apply the Dynamic Update.             
                    wfApp.Load(instance, info.updateMap);

                    // Persist the updated instance.
                    wfApp.Unload();

                    Console.WriteLine("Updated to: {0}", info.newIdentity);
                }
                else
                {
                    // Not updating this instance, so unload it.
                    instance.Abandon();
                }
            }
        }

        static IList<Guid> GetIds()
        {
            List<Guid> Ids = new List<Guid>();
            string localCmd = string.Format("Select [InstanceId] from [System.Activities.DurableInstancing].[Instances] Order By [CreationTime]");
            using (SqlConnection localCon = new SqlConnection(connectionString))
            {
                SqlCommand cmd = localCon.CreateCommand();
                cmd.CommandText = localCmd;
                localCon.Open();
                using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        // Get the InstanceId of the persisted Workflow
                        Guid id = Guid.Parse(reader[0].ToString());

                        // Add it to the list.
                        Ids.Add(id);
                    }
                }
            }

            return Ids;
        }

        static DynamicUpdateMap LoadMap(string mapName)
        {
            string path = Path.Combine(@"..\..\..\PreviousVersions", mapName);

            DynamicUpdateMap map;
            using (FileStream fs = File.Open(path, FileMode.Open))
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(DynamicUpdateMap));
                object updateMap = serializer.ReadObject(fs);
                if (updateMap == null)
                {
                    throw new ApplicationException("DynamicUpdateMap is null.");
                }

                map = updateMap as DynamicUpdateMap;
            }

            return map;
        }

        static IDictionary<WorkflowIdentity, DynamicUpdateInfo> LoadMaps()
        {
            // There are 3 update maps to describe the changes to update v1 workflows,
            // one for reach of the 3 workflow types in the tutorial.
            Dictionary<WorkflowIdentity, DynamicUpdateInfo> maps =
                new Dictionary<WorkflowIdentity, DynamicUpdateInfo>();

            DynamicUpdateMap sequentialMap = LoadMap("SequentialNumberGuessWorkflow.map");
            DynamicUpdateInfo sequentialInfo = new DynamicUpdateInfo
            {
                updateMap = sequentialMap,
                newIdentity = WorkflowVersionMap.SequentialNumberGuessIdentity_v15
            };
            maps.Add(WorkflowVersionMap.SequentialNumberGuessIdentity_v1, sequentialInfo);

            DynamicUpdateMap stateMap = LoadMap("StateMachineNumberGuessWorkflow.map");
            DynamicUpdateInfo stateInfo = new DynamicUpdateInfo
            {
                updateMap = stateMap,
                newIdentity = WorkflowVersionMap.StateMachineNumberGuessIdentity_v15
            };
            maps.Add(WorkflowVersionMap.StateMachineNumberGuessIdentity_v1, stateInfo);

            DynamicUpdateMap flowchartMap = LoadMap("FlowchartNumberGuessWorkflow.map");
            DynamicUpdateInfo flowchartInfo = new DynamicUpdateInfo
            {
                updateMap = flowchartMap,
                newIdentity = WorkflowVersionMap.FlowchartNumberGuessIdentity_v15
            };
            maps.Add(WorkflowVersionMap.FlowchartNumberGuessIdentity_v1, flowchartInfo);

            return maps;
        }

    }
}
