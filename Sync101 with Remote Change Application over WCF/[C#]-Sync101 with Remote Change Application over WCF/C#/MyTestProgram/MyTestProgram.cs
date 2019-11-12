// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;

using Microsoft.Synchronization;
using Sync101WebService;

namespace Sync101
{
    class MyTestProgram
    {
        /// <summary>
        /// This is an extension of the Sync101 sample showing how to write a provider which implements
        /// the RCA ("remote change application") pattern. Implementing the RCA pattern allows us
        /// to synchronize with providers on remote machines. In this sample we use WCF as our transport
        /// layer.
        /// 
        /// Please note that this sample is most useful with breakpoints in MyTestProgram.cs to find out HOW synchronization using the 
        /// Microsoft Sync Framework works. This sample is not designed to be a boot-strapper like the NTFS providers for native and managed...
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            const string DATA = "data";

            //start clean
            CleanUpProvider(providerNameA);
            CleanUpProvider(providerNameB);
            CleanUpProvider(providerNameC);

            //Initialize the stores
            // We create all the stores on the same machine in this sample app. However we will
            // sync with B and C using the remote change application pattern over WCF as if they 
            // were on a remote machine.
            // For a real deployment, B and C would be created on remote machines.
            MySimpleDataStore storeA = new MySimpleDataStore();
            MySimpleDataStore storeB = new MySimpleDataStore();
            MySimpleDataStore storeC = new MySimpleDataStore();

            //Create items on each store using a global ID and the data of the item (Note, in order to verify results against 
            //a baseline we are using hardcoded global ids for the items. In a real application CreateItem should be called without
            //the Guid parameter, which would generate a new Guid id and return it.
            Guid[] itemIds = new Guid[7];
            itemIds[1] = new Guid("11111111-1111-1111-1111-111111111111");
            itemIds[2] = new Guid("22222222-2222-2222-2222-222222222222");
            itemIds[3] = new Guid("33333333-3333-3333-3333-333333333333");
            itemIds[4] = new Guid("44444444-4444-4444-4444-444444444444");
            itemIds[5] = new Guid("55555555-5555-5555-5555-555555555555");
            itemIds[6] = new Guid("66666666-6666-6666-6666-666666666666");

            storeA.CreateItem(new ItemData(DATA, "1"), itemIds[1]);
            storeA.CreateItem(new ItemData(DATA, "2"), itemIds[2]);
            storeB.CreateItem(new ItemData(DATA, "3"), itemIds[3]);
            storeB.CreateItem(new ItemData(DATA, "4"), itemIds[4]);
            storeC.CreateItem(new ItemData(DATA, "5"), itemIds[5]);
            storeC.CreateItem(new ItemData(DATA, "6"), itemIds[6]);

            // Save the stores to disk (this is a demo app, in a real deployment,
            // stores B and C would be on different machines and would not be 
            // accessed directly by the local app).
            storeA.WriteStoreToFile(folderPathForDataAndMetadata, providerNameA);
            storeB.WriteStoreToFile(folderPathForDataAndMetadata, providerNameB);
            storeC.WriteStoreToFile(folderPathForDataAndMetadata, providerNameC);

            //Show the contents of the stores, prior to ANY any synchronization...
            Console.WriteLine("Show the contents of the stores, prior to any synchronization...");
            Console.WriteLine(new MySyncProvider(folderPathForDataAndMetadata, providerNameA).ToString());
            Console.WriteLine(storeA.ToString());
            Console.WriteLine(new MySyncProvider(folderPathForDataAndMetadata, providerNameB).ToString());
            Console.WriteLine(storeB.ToString());
            Console.WriteLine(new MySyncProvider(folderPathForDataAndMetadata, providerNameC).ToString());
            Console.WriteLine(storeC.ToString());

            //Sync providers A and provider B
            DoBidirectionalSync(providerNameA, providerNameB);

            //Create an update-update conflict on item 1 ...
            Console.WriteLine("A and B are going to create a conflict on item 1. A writes \"UpdateA\" and B writes \"UpdateB\"");
            Console.WriteLine("We do Download first then Upload.");
            Console.WriteLine("Since the policy is DestinationWins, we expect UpdateA to win during the Download and the resolution to be uploaded back to B.");

            storeA = MySimpleDataStore.ReadStoreFromFile(folderPathForDataAndMetadata, providerNameA);
            storeB = MySimpleDataStore.ReadStoreFromFile(folderPathForDataAndMetadata, providerNameB);
            storeA.UpdateItem(itemIds[1], new ItemData(DATA, "UpdateA"));
            storeB.UpdateItem(itemIds[1], new ItemData(DATA, "UpdateB"));
            storeA.WriteStoreToFile(folderPathForDataAndMetadata, providerNameA);
            storeB.WriteStoreToFile(folderPathForDataAndMetadata, providerNameB);

            //Sync providers A and provider B
            //We do Download first then Upload. Since the policy is DestinationWins,
            //we expect UpdateA to win during the Download and be uploaded back to B.
            DoBidirectionalSync(providerNameA, providerNameB);

            //Delete an item on B and show that the delete propagates
            Console.WriteLine("Deleting item '4' on B");
            storeB = MySimpleDataStore.ReadStoreFromFile(folderPathForDataAndMetadata, providerNameB);
            storeB.DeleteItem(itemIds[4]);
            storeB.WriteStoreToFile(folderPathForDataAndMetadata, providerNameB);

            //Sync B and C
            DoBidirectionalSync(providerNameB, providerNameC);

            //Close the sync loop by syncing A and C
            Console.WriteLine("Closing the \"sync loop\" by syncing A and C...");
            DoBidirectionalSync(providerNameA, providerNameC);

            //Delete item 2 on B
            Console.WriteLine("\nDeleting item '2' on B.");
            storeB = MySimpleDataStore.ReadStoreFromFile(folderPathForDataAndMetadata, providerNameB);
            storeB.DeleteItem(itemIds[2]);
            storeB.WriteStoreToFile(folderPathForDataAndMetadata, providerNameB);

            //Cleanup Tombstones on B
            Console.WriteLine("\nClean up Tombstones on B.");
            new RemoteProviderProxy(
                folderPathForDataAndMetadata,
                providerNameB,
                endpointConfigurationName).CleanupTombstones(TimeSpan.Zero);

            // Sync B and C
            DoBidirectionalSync(providerNameB, providerNameC);

            //Close the sync loop by syncing A and C
            DoBidirectionalSync(providerNameA, providerNameC);

            List<string> arguments = new List<string>(args);
            if (arguments.Contains("-q") != true)
            {
                Console.WriteLine("Sync has finished...");
                Console.ReadLine();
            }
        }

        static void CleanUpProvider(string name)
        {
            string dataStore = Environment.CurrentDirectory + "\\" + name.ToString() + ".Store";
            string providerMetadata = Environment.CurrentDirectory + "\\" + name.ToString() + ".Metadata";
            string providerReplicaid = Environment.CurrentDirectory + "\\" + name.ToString() + ".Replicaid";

            // Remove the data store file
            if (System.IO.File.Exists(dataStore))
            {
                System.IO.File.Delete(dataStore);
            }

            //Remove the metadata file
            if (System.IO.File.Exists(providerMetadata))
            {
                System.IO.File.Delete(providerMetadata);
            }

            //Remove the ReplicaId file
            if (System.IO.File.Exists(providerReplicaid))
            {
                System.IO.File.Delete(providerReplicaid);
            }
        }

        static void DoBidirectionalSync(string nameA, string nameB)
        {
            SyncOperationStatistics stats;
            KnowledgeSyncProvider providerNameA = GetProviderForSynchronization(nameA);
            KnowledgeSyncProvider providerNameB = GetProviderForSynchronization(nameB);

            // Set the provider's conflict resolution policy since we are doing remote sync, we don't
            // want to see callbacks.
            providerNameA.Configuration.ConflictResolutionPolicy = ConflictResolutionPolicy.DestinationWins;
            providerNameB.Configuration.ConflictResolutionPolicy = ConflictResolutionPolicy.DestinationWins;

            //Sync providers
            Console.WriteLine("Sync {0} and {1}...", nameA, nameB);
            SyncOrchestrator agent = new SyncOrchestrator();
            agent.Direction = SyncDirectionOrder.DownloadAndUpload;
            agent.LocalProvider = providerNameA;
            agent.RemoteProvider = providerNameB;
            stats = agent.Synchronize();

            // Display the SyncOperationStatistics
            Console.WriteLine("Download Applied:\t {0}", stats.DownloadChangesApplied);
            Console.WriteLine("Download Failed:\t {0}", stats.DownloadChangesFailed);
            Console.WriteLine("Download Total:\t\t {0}", stats.DownloadChangesTotal);
            Console.WriteLine("Upload Total:\t\t {0}", stats.UploadChangesApplied);
            Console.WriteLine("Upload Total:\t\t {0}", stats.UploadChangesFailed);
            Console.WriteLine("Upload Total:\t\t {0}", stats.UploadChangesTotal);

            //Show the results of sync
            MySyncProvider mySyncproviderNameA = new MySyncProvider(folderPathForDataAndMetadata, nameA);
            MySyncProvider mySyncproviderNameB = new MySyncProvider(folderPathForDataAndMetadata, nameB);
            MySimpleDataStore storeA = MySimpleDataStore.ReadStoreFromFile(folderPathForDataAndMetadata, nameA);
            MySimpleDataStore storeB = MySimpleDataStore.ReadStoreFromFile(folderPathForDataAndMetadata, nameB);
            Console.WriteLine(mySyncproviderNameA.ToString());
            Console.WriteLine(storeA.ToString());
            Console.WriteLine(mySyncproviderNameB.ToString());
            Console.WriteLine(storeB.ToString());
        }

        static KnowledgeSyncProvider GetProviderForSynchronization(string name)
        {
            // Return the real provider for endpoint A.
            // Return the proxy for endpoints B and C.
            if (name == providerNameA)
            {
                return new MySyncProvider(folderPathForDataAndMetadata, providerNameA);
            }
            else if (name == providerNameB || name == providerNameC)
            {
                return new RemoteProviderProxy(
                    folderPathForDataAndMetadata,
                    name,
                    endpointConfigurationName);
            }
            else
            {
                throw new ArgumentOutOfRangeException("name");
            }
        }

        static string endpointConfigurationName = "WSHttpBinding_Sync101WebService";
        static string providerNameA = "A";
        static string providerNameB = "B";
        static string providerNameC = "C";
        static string folderPathForDataAndMetadata = Environment.CurrentDirectory;
    }
}
