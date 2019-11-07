// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Diagnostics;
using Microsoft.Synchronization;
using Microsoft.Synchronization.MetadataStorage;


namespace Sync101
{
    public class MySyncProvider : KnowledgeSyncProvider, IChangeDataRetriever, INotifyingChangeApplierTarget
    {
        // The name of the metadata store custom column that is used to save a timestamp of last change on an 
        // item in the metadata store so we can do change detection.
        const string TIMESTAMP_COLUMNNAME = "timestamp";

        // This is our sample in memory data store which for simplicty, stores sets of string name-value pairs 
        // referenced by identifiers of the type 'Guid'
        MySimpleDataStore _store;

        // Use the Sync Framework's optional metadata store to track version information
        SqlMetadataStore _metadataStore = null;
        ReplicaMetadata _metadata = null;
        private string _name = null;
        private string _folderPath = null;
        private string _replicaMetadataFile = null;
        private string _replicaIdFile = null;

        // The provider's unique identifier...
        SyncId _replicaId = null;

        SyncIdFormatGroup _idFormats = null;
        SyncSessionContext _currentSessionContext = null;

        // Construct a data store by providing a name for the endpoint (replica) and 
        // a file to which we'll persist the sync metadata (file)
        public MySyncProvider(string folderPath, string name)
        {
            _name = name;
            _folderPath = folderPath;

            _replicaMetadataFile = _folderPath.ToString() + "\\" + _name.ToString() + ".Metadata";
            _replicaIdFile = _folderPath.ToString() + "\\" + _name.ToString() + ".Replicaid";

            // Set ItemIdFormat and ReplicaIdFormat for using Guid ids.
            _idFormats = new SyncIdFormatGroup();
            _idFormats.ItemIdFormat.IsVariableLength = false;
            _idFormats.ItemIdFormat.Length = 16;
            _idFormats.ReplicaIdFormat.IsVariableLength = false;
            _idFormats.ReplicaIdFormat.Length = 16;
        }

        public SyncId ReplicaId
        {
            get 
            {
                if (_replicaId == null)
                {
                    _replicaId = GetReplicaIdFromFile( _replicaIdFile);
                }

                return _replicaId; 
            }
        }

        #region Metadata Store Related Methods
        private void InitializeMetadataStore()
        {
            // Values for adding a custom field to the metadata store
            List<FieldSchema> fields = new List<FieldSchema>();
            SyncId id = ReplicaId;

            // Create or open the metadata store, initializing it with the id formats we'll use to reference our items and endpoints
            if (!File.Exists(_replicaMetadataFile))
            {
                fields.Add(new FieldSchema(TIMESTAMP_COLUMNNAME, typeof(System.UInt64)));
                _metadataStore = SqlMetadataStore.CreateStore(_replicaMetadataFile);
                _metadata = _metadataStore.InitializeReplicaMetadata(_idFormats, _replicaId, fields, null/*No indexes to create*/);
            }
            else
            {
                _metadataStore = SqlMetadataStore.OpenStore(_replicaMetadataFile);
                _metadata = _metadataStore.GetReplicaMetadata(_idFormats, _replicaId);
            }
        }

        private void CloseMetadataStore()
        {
            _metadataStore.Dispose();
            _metadataStore = null;
        }

        //Update the metadata store with changes that have occured on the data store since the last time it was updated.
        public void UpdateMetadataStoreWithLocalChanges()
        {
            SyncVersion newVersion = new SyncVersion(0, _metadata.GetNextTickCount());

            _metadata.DeleteDetector.MarkAllItemsUnreported();
            foreach (Guid id in _store.Ids)
            {
                ItemData data = _store.Get(id);
                ItemMetadata item = null;

                //Look up an item's metadata by its ID... 
                item = _metadata.FindItemMetadataById(new SyncId(id));
                if (null == item)
                {
                    //New item, must have been created since that last time the metadata was updated.
                    //Create the item metadata required for sync (giving it a SyncID and a version, defined to be a DWORD and a ULONGLONG
                    //For creates, simply provide the relative replica ID (0) and the tick count for the provider (ever increasing)
                    item = _metadata.CreateItemMetadata(new SyncId(id), newVersion);
                    item.ChangeVersion = newVersion;
                    SaveItemMetadata(item, data.TimeStamp);
                }
                else
                {
                    if (data.TimeStamp > item.GetUInt64Field(TIMESTAMP_COLUMNNAME)) // the item has changed since the last sync operation.
                    {
                        //Changed Item, this item has changed since the last time the metadata was updated.
                        //Assign a new version by simply stating "who" modified this item (0 = local/me) and "when" (tick count for the store)
                        item.ChangeVersion = newVersion;
                        SaveItemMetadata(item, data.TimeStamp);
                    }
                    else
                    {
                        //Unchanged item, nothing has changes so just mark it as live so that the metadata knows it has not been deleted.
                        _metadata.DeleteDetector.ReportLiveItemById(new SyncId(id));
                    }
                }
            }

            //Now go back through the items that are no longer in the store and mark them as deleted in the metadata.  
            //This sets the item as a tombstone.
            foreach (ItemMetadata item in _metadata.DeleteDetector.FindUnreportedItems())
            {
                item.MarkAsDeleted(newVersion);
                SaveItemMetadata(item, 0); // set timestamp to 0 for tombstones
            }
        }

        private void SaveItemMetadata(ItemMetadata item, ulong timeStamp)
        {
            item.SetCustomField(TIMESTAMP_COLUMNNAME, timeStamp);
            SaveItemMetadata(item);
        }

        private void SaveItemMetadata(ItemMetadata item)
        {
            _metadata.SaveItemMetadata(item);
        }

        // Method for cleaning up tombstones older than a certain TimeSpan
        public void CleanupTombstones(TimeSpan timespan)
        {
            InitializeMetadataStore();
            _metadataStore.BeginTransaction();
            _metadata.CleanupDeletedItems(timespan);
            _metadataStore.CommitTransaction();
            CloseMetadataStore();
        }        
        #endregion Metadata Store Related Methods

        #region KnowledgeSyncProvider Overrides
        //BeginSession is called at the beginning of each sync operation.  Do initialization here.  For example update 
        //metadata if it was not updated as the actual data was changed.
        public override void BeginSession(SyncProviderPosition position, SyncSessionContext syncSessionContext)
        {
            BeginSession();

            _currentSessionContext = syncSessionContext;
        }

        //EndSession is called after the sync operation is completed.  Cleanup happens here.
        public override void EndSession(SyncSessionContext syncSessionContext)
        {
            EndSession();
        }

        //Simply ask the metadata store to compute my change batch for me, providing the batch size and the knowledge of the other endpoint!
        //The engine is asking for the list of changes that the destination provider does not know about.
        public override ChangeBatch GetChangeBatch(uint batchSize, SyncKnowledge destinationKnowledge, out object changeDataRetriever)
        {
            ChangeBatch batch = _metadata.GetChangeBatch(batchSize, destinationKnowledge);
            changeDataRetriever = this; //this is where the transfer mechanism/protocol would go. For an in memory provider, this is sufficient
            return batch;
        }

        //This is only called when the engine has detected that the destination is out of date due to Tombstone cleanup.
        public override FullEnumerationChangeBatch GetFullEnumerationChangeBatch(uint batchSize, SyncId lowerEnumerationBound, SyncKnowledge knowledgeForDataRetrieval, out object changeDataRetriever)
        {
            FullEnumerationChangeBatch batch = _metadata.GetFullEnumerationChangeBatch(batchSize, lowerEnumerationBound, knowledgeForDataRetrieval);
            changeDataRetriever = this; //this is where the transfer mechanism/protocol would go. For an in memory provider, this is sufficient
            return batch;
        }

        //Specify that we'd like to get batches of size 10 and what our knowledge is
        public override void GetSyncBatchParameters(out uint batchSize, out SyncKnowledge knowledge)
        {
            batchSize = 10;
            knowledge = _metadata.GetKnowledge();
        }

        //Change application!
        public override void ProcessChangeBatch(ConflictResolutionPolicy resolutionPolicy, ChangeBatch sourceChanges,
            object changeDataRetriever, SyncCallbacks syncCallback, SyncSessionStatistics sessionStatistics)
        {
            _metadataStore.BeginTransaction();

            //Get all my local change versions from the metadata store
            IEnumerable<ItemChange> localChanges = _metadata.GetLocalVersions(sourceChanges);

            //Create a changeapplier object to make change application easier (make the engine call me 
            //when it needs data and when I should save data)
            NotifyingChangeApplier changeApplier = new NotifyingChangeApplier(_idFormats);

            changeApplier.ApplyChanges(resolutionPolicy, sourceChanges, changeDataRetriever as IChangeDataRetriever, localChanges, _metadata.GetKnowledge(),
                _metadata.GetForgottenKnowledge(), this, _currentSessionContext, syncCallback);

            _metadataStore.CommitTransaction();
        }

        //If full enumeration is needed because  this provider is out of date due to tombstone cleanup, then this method will be called by the engine.
        public override void ProcessFullEnumerationChangeBatch(ConflictResolutionPolicy resolutionPolicy, FullEnumerationChangeBatch sourceChanges, object changeDataRetriever, SyncCallbacks syncCallback, SyncSessionStatistics sessionStatistics)
        {
            _metadataStore.BeginTransaction();

            //Get all my local change versions from the metadata store
            IEnumerable<ItemChange> localChanges = _metadata.GetFullEnumerationLocalVersions(sourceChanges);

            //Create a changeapplier object to make change application easier (make the engine call me 
            //when it needs data and when I should save data)
            NotifyingChangeApplier changeApplier = new NotifyingChangeApplier(_idFormats);
            changeApplier.ApplyFullEnumerationChanges(resolutionPolicy, sourceChanges, changeDataRetriever as IChangeDataRetriever, localChanges, _metadata.GetKnowledge(),
                _metadata.GetForgottenKnowledge(), this, _currentSessionContext, syncCallback);

            _metadataStore.CommitTransaction();
        }
        #endregion KnowledgeSyncProvider Overrides

        #region INotifyingChangeApplierTarget Implementation
        public IChangeDataRetriever GetDataRetriever()
        {
            return this;
        }

        //Simply up my tick count everytime I'm asked for it to ensure conflict resolution and detection work!
        public ulong GetNextTickCount()
        {
            return _metadata.GetNextTickCount();
        }

        public void SaveChangeWithChangeUnits(ItemChange change, SaveChangeWithChangeUnitsContext context)
        {
            //Change units are not supported by this sample provider.  
            throw new NotImplementedException();
        }

        public void SaveConflict(ItemChange conflictingChange, object conflictingChangeData, SyncKnowledge conflictingChangeKnowledge)
        {
            //The resolution policy is set to DestinationWins so there is never a conflict to save.  
            throw new NotImplementedException();
        }

        //Save the item, taking the appropriate action for the 'change' and the data from the item (in 'context')
        public void SaveItemChange(SaveChangeAction saveChangeAction, ItemChange change, SaveChangeContext context)
        {
            ulong timeStamp = 0;
            ItemMetadata item = null;
            ItemData data = null;
            switch (saveChangeAction)
            {
                case SaveChangeAction.Create:
                    //Do duplicate detection here
                    item = _metadata.FindItemMetadataById(change.ItemId);
                    if (null != item)
                    {
                        throw new Exception("SaveItemChange must not have Create action for existing items.");
                    }
                    item = _metadata.CreateItemMetadata(change.ItemId, change.CreationVersion);
                    item.ChangeVersion = change.ChangeVersion;
                    data = new ItemData( (ItemData)context.ChangeData);
                    //We are using the same id for both the local and global item id.
                    _store.CreateItem( data, change.ItemId.GetGuidId());
                    SaveItemMetadata(item, _store.Get(change.ItemId.GetGuidId()).TimeStamp);
                    break;

                case SaveChangeAction.UpdateVersionAndData:
                case SaveChangeAction.UpdateVersionOnly:
                    item = _metadata.FindItemMetadataById(change.ItemId);
                    if (null == item)
                    {
                        throw new Exception("Item Not Found in Store!?");
                    }

                    item.ChangeVersion = change.ChangeVersion;
                    if (saveChangeAction == SaveChangeAction.UpdateVersionOnly)
                    {
                        SaveItemMetadata(item);
                    }
                    else  //Also update the data and the timestamp.
                    {
                        data = new ItemData((ItemData)context.ChangeData);
                        timeStamp = _store.UpdateItem(item.GlobalId.GetGuidId(), data);
                        SaveItemMetadata(item, timeStamp);
                    }
                    break;

                case SaveChangeAction.DeleteAndStoreTombstone:
                    item = _metadata.FindItemMetadataById(change.ItemId);
                    if (null == item)
                    {
                        item = _metadata.CreateItemMetadata(change.ItemId, change.CreationVersion);
                    }

                    if (change.ChangeKind == ChangeKind.Deleted)
                    {
                        item.MarkAsDeleted(change.ChangeVersion);
                    }
                    else
                    {
                        // This should never happen in Sync Framework V1.0
                        throw new Exception("Invalid ChangeType");
                    }

                    item.ChangeVersion = change.ChangeVersion;
                    SaveItemMetadata(item, 0);  // set timestamp to 0 for tombstones
                    _store.DeleteItem(item.GlobalId.GetGuidId());
                    break;

                //Merge the changes! (Take the data from the local item + the remote item),noting to update the tick count to propagate the resolution!
                case SaveChangeAction.UpdateVersionAndMergeData:
                    item = _metadata.FindItemMetadataById(change.ItemId);

                    if (null == item)
                    {
                        throw new Exception("Item Not Found in Store!?");
                    }
                    if (item.IsDeleted != true)
                    {
                        //Note - you must update the change version to propagate the resolution!
                        item.ChangeVersion = new SyncVersion(0, _metadata.GetNextTickCount());

                        //Combine the conflicting data...
                        ItemData mergedData = (_store.Get(item.GlobalId.GetGuidId())).Merge( (ItemData)context.ChangeData);
                        timeStamp = _store.UpdateItem(item.GlobalId.GetGuidId(), mergedData);
                        SaveItemMetadata(item, timeStamp);
                    }
                    break;

                case SaveChangeAction.DeleteAndRemoveTombstone:
                    item = _metadata.FindItemMetadataById(change.ItemId);
                    if (item != null)
                    {
                        List<SyncId> ids = new List<SyncId>();
                        ids.Add(item.GlobalId);
                        _metadata.RemoveItemMetadata(ids);
                    }
                    _store.DeleteItem(change.ItemId.GetGuidId());
                    break;
            }
        }

        //Simply store the knowlege given to us
        public void StoreKnowledgeForScope(SyncKnowledge knowledge, ForgottenKnowledge forgottenKnowledge)
        {
            _metadata.SetKnowledge(knowledge);
            _metadata.SetForgottenKnowledge(forgottenKnowledge);

            _metadata.SaveReplicaMetadata();
        }

        public bool TryGetDestinationVersion(ItemChange sourceChange, out ItemChange destinationVersion)
        {
            ItemMetadata metadata = _metadata.FindItemMetadataById(sourceChange.ItemId);

            if (metadata == null)
            {
                destinationVersion = null;
                return false;
            }
            else
            {
                destinationVersion = new ItemChange(_idFormats, _replicaId, sourceChange.ItemId,
                        metadata.IsDeleted ? ChangeKind.Deleted : ChangeKind.Update,
                        metadata.CreationVersion, metadata.ChangeVersion);
                return true;
            }
        }
        #endregion INotifyingChangeApplierTarget Implementation

        #region IChangeDataRetriever Implementation
        public override SyncIdFormatGroup IdFormats
        {
            get { return _idFormats; }
        }

        //This is where we load data to provide to the other endpoint...
        public object LoadChangeData(LoadChangeContext loadChangeContext)
        {
            //return a copy of the data.
            return new ItemData(_store.Get(loadChangeContext.ItemChange.ItemId.GetGuidId()));
        }

        #endregion IChangeDataRetriever Implementation

        #region ReplicaId Initialization Methods
        private static SyncId GetReplicaIdFromFile(string replicaIdFile)
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

        private static void WriteReplicaIdToFile(string file, SyncId replicaId)
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

        private static SyncId ReadReplicaIdFromFile(string file)
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

        #region Methods necessary for Remote Change Application
        public void BeginSession()
        {
            InitializeMetadataStore();
            _store = MySimpleDataStore.ReadStoreFromFile(_folderPath, _name);

            //Make sure the metadata store is updated to reflect the state of the data before each sync operation.
            _metadataStore.BeginTransaction();
            UpdateMetadataStoreWithLocalChanges();
            _metadataStore.CommitTransaction();
        }

        public void EndSession()
        {
            _store.WriteStoreToFile(_folderPath, _name);
            CloseMetadataStore();
        }

        //Change application!
        public byte[] ProcessRemoteChangeBatch(
            ConflictResolutionPolicy resolutionPolicy, 
            ChangeBatch sourceChanges,
            CachedChangeDataRetriever changeDataRetriever, 
            byte[] changeApplierInfo)
        {
            _metadataStore.BeginTransaction();

            //Get all my local change versions from the metadata store
            IEnumerable<ItemChange> localChanges = _metadata.GetLocalVersions(sourceChanges);

            NotifyingChangeApplier changeApplier = new NotifyingChangeApplier(_idFormats);

            // The following step is required because we are remote change application
            changeApplier.LoadChangeApplierInfo(changeApplierInfo);

            changeApplier.ApplyChanges(
                resolutionPolicy, 
                sourceChanges, 
                changeDataRetriever, 
                localChanges, 
                _metadata.GetKnowledge(),
                _metadata.GetForgottenKnowledge(), 
                this, 
                null,                     // Note that we do not pass a sync session context
                new SyncCallbacks());                    

            _metadataStore.CommitTransaction();

            // Return the ChangeApplierInfo
            return changeApplier.GetChangeApplierInfo();
        }

        //If full enumeration is needed because  this provider is out of date due to tombstone cleanup, then this method will be called by the engine.
        public byte[] ProcessRemoteFullEnumerationChangeBatch(
            ConflictResolutionPolicy resolutionPolicy, 
            FullEnumerationChangeBatch sourceChanges,
            CachedChangeDataRetriever changeDataRetriever,
            byte[] changeApplierInfo)
        {
            _metadataStore.BeginTransaction();

            //Get all my local change versions from the metadata store
            IEnumerable<ItemChange> localChanges = _metadata.GetFullEnumerationLocalVersions(sourceChanges);

            NotifyingChangeApplier changeApplier = new NotifyingChangeApplier(_idFormats);

            // The following step is required because we are remote change application
            changeApplier.LoadChangeApplierInfo(changeApplierInfo);

            changeApplier.ApplyFullEnumerationChanges(
                resolutionPolicy, 
                sourceChanges, 
                changeDataRetriever as IChangeDataRetriever, 
                localChanges, 
                _metadata.GetKnowledge(),
                _metadata.GetForgottenKnowledge(), 
                this,
                null,                   // Note that we do not pass a sync session context
                new SyncCallbacks());

            _metadataStore.CommitTransaction();

            // Return the ChangeApplierInfo
            return changeApplier.GetChangeApplierInfo();
        }
        #endregion

        //Quick debug mechanism to show what the store "knows" and what it contains...
        public override string ToString()
        {
            StringBuilder buffer = new StringBuilder();
            if (_metadataStore == null)
            {
                InitializeMetadataStore();
                buffer.AppendFormat("{2}Provider {0} has the following for Knowledge: {1}{2}", _replicaId.GetGuidId(), _metadata.GetKnowledge().ToString(), Environment.NewLine);
                CloseMetadataStore();
            }
            else
            {
                buffer.AppendFormat("{2}Provider {0} has the following for Knowledge: {1}{2}", _replicaId.GetGuidId(), _metadata.GetKnowledge().ToString(), Environment.NewLine);
            }
            return buffer.ToString();
        }
    }
}
