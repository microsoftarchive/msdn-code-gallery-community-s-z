using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Diagnostics;
using Microsoft.WindowsAzure.StorageClient;
using Microsoft.Synchronization;
using Microsoft.Synchronization.MetadataStorage;
using Microsoft.Synchronization.SimpleProviders;
using Microsoft.Synchronization.Files;
using System.Globalization;

namespace AzureBlobSync
{
    internal static class ItemFields
    {
        public const uint CUSTOM_FIELD_NAME = 1;
        public const uint CUSTOM_FIELD_TIMESTAMP = 2;
    }


    internal class ApplyingBlobEventArgs : EventArgs
    {
        ChangeType _changeType;
        string _currentBlobName;
        string _newBlobName;

        
        public ApplyingBlobEventArgs(ChangeType changeType, string currentBlobName) :
            this(changeType, currentBlobName, "") 
        {
        }

        public ApplyingBlobEventArgs(ChangeType changeType, string currentBlobName, string newBlobName)
        {
            _changeType = changeType;
            _currentBlobName = currentBlobName;
            _newBlobName = newBlobName;
        }

        public ChangeType ChangeType
        {
            get { return _changeType; }
        }

        public string CurrentBlobName
        {
            get { return _currentBlobName; }
        }

        public string NewBlobName
        {
            get { return _newBlobName; }
        }
    }

    internal class AzureBlobSyncProvider : FullEnumerationSimpleSyncProvider
    {
        // The name of the metadata store custom column that is used to save a timestamp of last change on an 
        // item in the metadata store so we can do change detection.
        const string TIMESTAMP_COLUMN_NAME = "timestamp";

        // The actual data store in this case is an Azure blob store.
        AzureBlobStore _store;

        // Use the Sync Framework's optional metadata store to track version information
        SqlMetadataStore _metadataStore = null;
        private string _name = null;
        private string _replicaMetadataFile = null;
        private string _replicaIdFile = null;

        // The provider's unique identifier...
        SyncId _replicaId = null;

        SyncIdFormatGroup _idFormats = null;

        // Storage for the metadata directory cache
        private string _metadataDirectory = "";

        // Construct a data store by providing a name for the endpoint (replica) and 
        // a file to which we'll persist the sync metadata (file)
        internal AzureBlobSyncProvider(
            string name, 
            AzureBlobStore store
            )
        {
            _name = name;
            _store = store;

            _replicaMetadataFile = MetadataDirectory + _name + ".Metadata";
            _replicaIdFile = MetadataDirectory + _name + ".Replicaid";

            // Set ItemIdFormat and ReplicaIdFormat for using Guid ids.
            _idFormats = new SyncIdFormatGroup();
            _idFormats.ChangeUnitIdFormat.IsVariableLength = false;
            _idFormats.ChangeUnitIdFormat.Length = 4;
            _idFormats.ItemIdFormat.IsVariableLength = false;
            _idFormats.ItemIdFormat.Length = 24;
            _idFormats.ReplicaIdFormat.IsVariableLength = false;
            _idFormats.ReplicaIdFormat.Length = 16;
        }

        //
        // Summary:
        //     Occurs when a file change is about to be tried.
        public event EventHandler<ApplyingBlobEventArgs> ApplyingChange;

        public SyncId ReplicaId
        {
            get
            {
                if (_replicaId == null)
                {
                    _replicaId = GetReplicaIdFromFile(_replicaIdFile);
                }

                return _replicaId;
            }
        }

        public override SyncIdFormatGroup IdFormats
        {
            get { return _idFormats; }
        }


        string MetadataDirectory
        {
            get
            {
                // note that this is not thread safe but in the worst case an extra string is garbage collected.
                if (_metadataDirectory == "")
                {
                    string localAppData = Environment.GetEnvironmentVariable("LOCALAPPDATA");
                    if (localAppData.Substring(localAppData.Length - 1) != "\\")
                    {
                        localAppData += "\\";
                    }
                    localAppData += "AzureSyncConsole\\";
                    _metadataDirectory = localAppData;
                    
                    // Ensure that the directory exists
                    Directory.CreateDirectory(localAppData);
                }
                return _metadataDirectory;
            }
        }

        
        internal AzureBlobStore DataStore
        {
            get
            {
                return _store;
            }
        }


        //BeginSession is called at the beginning of each sync operation.  Do initialization here.
        public override void BeginSession()
        {
        }


        // GetMetadataStore is called by the framework to get an object that can be used to store sync metadata.
        // This provider will use the Sync Framework built in MetadataStore
        public override MetadataStore GetMetadataStore(
            out SyncId replicaId, 
            out System.Globalization.CultureInfo culture
            )
        {
            InitializeMetadataStore();

            replicaId = ReplicaId;
            culture = CultureInfo.CurrentCulture;
            return _metadataStore;
        }


        // The provider can be versioned to support upgrade.  This provider implementation is version 1.
        public override short ProviderVersion
        {
	        get 
            {
                return 1;
            }
        }


        // MetadataSchema is called by the framework to get information about the extra info to keep for items for identity and change detection
        public override ItemMetadataSchema MetadataSchema
        {
            get
            {
                CustomFieldDefinition[] customFields = new CustomFieldDefinition[2];
                customFields[0] = new CustomFieldDefinition(ItemFields.CUSTOM_FIELD_NAME, typeof(string), AzureBlobStore.MaxFileNameLength);
                customFields[1] = new CustomFieldDefinition(ItemFields.CUSTOM_FIELD_TIMESTAMP, typeof(ulong));

                IdentityRule[] identityRule = new IdentityRule[1];
                identityRule[0] = new IdentityRule(new uint[] { ItemFields.CUSTOM_FIELD_NAME });

                return new ItemMetadataSchema(customFields, identityRule);
            }
        }


        // EnumerateItems is called by the framework to look for changes (inserts, updates, deletes) in the data store.
        // It should enumerate all of the items currently in the store and return the properties that were specified by the MetadataSchema property.
        public override void EnumerateItems(FullEnumerationContext context)
        {
            List<ItemFieldDictionary> items = DataStore.ListBlobs();
            context.ReportItems(items);
        }

        
        //This is where we load data to provide to the other endpoint.
        public override object LoadChangeData(
            ItemFieldDictionary keyAndExpectedVersion, 
            IEnumerable<SyncId> changeUnitsToLoad, 
            RecoverableErrorReportingContext recoverableErrorReportingContext
            )
        {
            IDictionary<uint, ItemField> expectedFields = (IDictionary<uint, ItemField>)keyAndExpectedVersion;
            string name = (string)expectedFields[ItemFields.CUSTOM_FIELD_NAME].Value;
            DateTime expectedLastUpdate = DateTime.FromBinary((long)(ulong)expectedFields[ItemFields.CUSTOM_FIELD_TIMESTAMP].Value);

            object changeData = null;
            try
            {
                changeData = DataStore.GetFileRetriever(name, expectedLastUpdate);
            }
            catch (ApplicationException e)
            {
                recoverableErrorReportingContext.RecordRecoverableErrorForChange(new RecoverableErrorData(e));
            }

            return changeData;
        }

        
        // Called by the framework when an item (file) needs to be added to the store.
        public override void InsertItem(
            object itemData,
            IEnumerable<SyncId> changeUnitsToCreate,
            RecoverableErrorReportingContext recoverableErrorReportingContext,
            out ItemFieldDictionary keyAndUpdatedVersion,
            out bool commitKnowledgeAfterThisItem
            )
        {
            IFileDataRetriever dataRetriever = (IFileDataRetriever)itemData;

            string relativePath = dataRetriever.RelativeDirectoryPath;
            keyAndUpdatedVersion = null;
            commitKnowledgeAfterThisItem = false;

            ApplyingBlobEventArgs args = new ApplyingBlobEventArgs(ChangeType.Create, dataRetriever.FileData.Name);
            EventHandler<ApplyingBlobEventArgs> applyingDelegate = ApplyingChange;
            applyingDelegate(this, args);
            
            try
            {
                Stream dataStream = null;
                if (!dataRetriever.FileData.IsDirectory)
                {
                    dataStream = dataRetriever.FileStream;
                }

                SyncedBlobAttributes attrs = DataStore.InsertFile(dataRetriever.FileData, dataRetriever.RelativeDirectoryPath, dataStream);
                keyAndUpdatedVersion = new ItemFieldDictionary();
                keyAndUpdatedVersion.Add(new ItemField(ItemFields.CUSTOM_FIELD_NAME, typeof(string), attrs._name));
                keyAndUpdatedVersion.Add(new ItemField(ItemFields.CUSTOM_FIELD_TIMESTAMP, typeof(ulong), (ulong)attrs._lastModifiedTime.ToBinary()));
            }
            catch (ApplicationException e)
            {
                recoverableErrorReportingContext.RecordRecoverableErrorForChange(new RecoverableErrorData(e));
            }
        }


        // Called by the framework when an item (file) needs to be updated.
        public override void UpdateItem(
            object itemData,
            IEnumerable<SyncId> changeUnitsToUpdate,
            ItemFieldDictionary keyAndExpectedVersion,
            RecoverableErrorReportingContext recoverableErrorReportingContext,
            out ItemFieldDictionary keyAndUpdatedVersion,
            out bool commitKnowledgeAfterThisItem
            )
        {
            keyAndUpdatedVersion = null;
            commitKnowledgeAfterThisItem = false;
            IFileDataRetriever dataRetriever = (IFileDataRetriever)itemData;

            IDictionary<uint, ItemField> expectedFields = (IDictionary<uint, ItemField>)keyAndExpectedVersion;
            DateTime expectedLastUpdate = DateTime.FromBinary((long)(ulong)expectedFields[ItemFields.CUSTOM_FIELD_TIMESTAMP].Value);
            string oldName = (string)expectedFields[ItemFields.CUSTOM_FIELD_NAME].Value;

            try
            {
                Stream dataStream = null;
                if (!dataRetriever.FileData.IsDirectory)
                {
                    dataStream = dataRetriever.FileStream;
                }

                string newName = CreateNewName(dataRetriever.FileData);
                SyncedBlobAttributes attrs;
                if (IsMoveOrRename(oldName, newName))
                {
                    ApplyingBlobEventArgs args = new ApplyingBlobEventArgs(ChangeType.Rename, oldName, newName);
                    EventHandler<ApplyingBlobEventArgs> applyingDelegate = ApplyingChange;
                    applyingDelegate(this, args);

                    // Handle moves and renames as a delete and create.
                    DataStore.DeleteFile(oldName, expectedLastUpdate);
                    attrs = DataStore.InsertFile(dataRetriever.FileData, dataRetriever.RelativeDirectoryPath, dataStream);
                }
                else
                {
                    ApplyingBlobEventArgs args = new ApplyingBlobEventArgs(ChangeType.Update, dataRetriever.FileData.Name);
                    EventHandler<ApplyingBlobEventArgs> applyingDelegate = ApplyingChange;
                    applyingDelegate(this, args);

                    attrs = DataStore.UpdateFile(oldName, dataRetriever.FileData, dataRetriever.RelativeDirectoryPath, dataStream, expectedLastUpdate);
                }

                // Record new data after update.
                keyAndUpdatedVersion = new ItemFieldDictionary();
                keyAndUpdatedVersion.Add(new ItemField(ItemFields.CUSTOM_FIELD_NAME, typeof(string), attrs._name));
                keyAndUpdatedVersion.Add(new ItemField(ItemFields.CUSTOM_FIELD_TIMESTAMP, typeof(ulong), (ulong)attrs._lastModifiedTime.ToBinary()));
            }
            catch (ApplicationException e)
            {
                recoverableErrorReportingContext.RecordRecoverableErrorForChange(new RecoverableErrorData(e));
            }
            commitKnowledgeAfterThisItem = false;
        }
        
        
        // Called by the framework when an item needs to be deleted.
        public override void DeleteItem(
            ItemFieldDictionary keyAndExpectedVersion,
            RecoverableErrorReportingContext recoverableErrorReportingContext,
            out bool commitKnowledgeAfterThisItem
            )
        {
            commitKnowledgeAfterThisItem = false;

            IDictionary<uint, ItemField> expectedFields = (IDictionary<uint, ItemField>)keyAndExpectedVersion;
            string name = (string)expectedFields[ItemFields.CUSTOM_FIELD_NAME].Value;

            ApplyingBlobEventArgs args = new ApplyingBlobEventArgs(ChangeType.Delete, name);
            EventHandler<ApplyingBlobEventArgs> applyingDelegate = ApplyingChange;
            applyingDelegate(this, args);

            DateTime expectedLastUpdate = DateTime.FromBinary((long)(ulong)expectedFields[ItemFields.CUSTOM_FIELD_TIMESTAMP].Value);
            try
            {
                DataStore.DeleteFile(name, expectedLastUpdate);
            }
            catch (ApplicationException e)
            {
                recoverableErrorReportingContext.RecordRecoverableErrorForChange(new RecoverableErrorData(e));
            }
        }


        //EndSession is called after the sync operation is completed.  Cleanup happens here.
        public override void EndSession()
        {
            CloseMetadataStore();
        }


        //Implementation helpers
        private string CreateNewName(
            FileData fileData
            )
        {
            return DataStore.GetRootPath() + "/" + fileData.RelativePath.Replace("\\", "/").ToLower();
        }

        
        private bool IsMoveOrRename(
            string oldName,
            string newName
            )
        {
            return oldName != newName;
        }

        #region Metadata Store Related Methods
        private void InitializeMetadataStore()
        {

            SyncId id = ReplicaId;

            // Create or open the metadata store, initializing it with the id formats we'll use to reference our items and endpoints
            if (!File.Exists(_replicaMetadataFile))
            {
                _metadataStore = SqlMetadataStore.CreateStore(_replicaMetadataFile);
            }
            else
            {
                _metadataStore = SqlMetadataStore.OpenStore(_replicaMetadataFile);
            }
        }


        private void CloseMetadataStore()
        {
            _metadataStore.Dispose();
            _metadataStore = null;
        }


        // Method for cleaning up tombstones older than a certain TimeSpan
        internal void CleanupDeletedItems(
            TimeSpan timespan
            )
        {
            InitializeMetadataStore();
            SimpleSyncServices simpleSyncServices = new SimpleSyncServices(_idFormats, _metadataStore, ReplicaId, CultureInfo.CurrentCulture, 0);
            simpleSyncServices.CleanupDeletedItems(timespan);
            CloseMetadataStore();
        }
        #endregion Metadata Store Related Methods


        #region ReplicaId Initialization Methods
        private static SyncId GetReplicaIdFromFile(
            string replicaIdFile
            )
        {
            SyncId replicaId;

            if (System.IO.File.Exists(replicaIdFile))
            {
                replicaId = ReadReplicaIdFromFile(replicaIdFile);
            }
            else
            {
                // Create the replica id and save it.
                replicaId = new SyncId(Guid.NewGuid());
                WriteReplicaIdToFile(replicaIdFile, replicaId);
            }

            return replicaId;
        }


        private static void WriteReplicaIdToFile(
            string file, 
            SyncId replicaId
            )
        {
            FileStream fs = new FileStream(file, FileMode.Create);

            // Construct a BinaryFormatter and use it to serialize the data to the stream.
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, replicaId);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize replica id to file. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }


        private static SyncId ReadReplicaIdFromFile(
            string file
            )
        {
            FileStream fs = new FileStream(file, FileMode.Open);
            SyncId replicaId;

            // Construct a BinaryFormatter and use it to serialize the data to the stream.
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                replicaId = (SyncId)formatter.Deserialize(fs);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize replica id from file. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }

            return replicaId;
        }
        #endregion ReplicaId Initialization Methods
    }
}
