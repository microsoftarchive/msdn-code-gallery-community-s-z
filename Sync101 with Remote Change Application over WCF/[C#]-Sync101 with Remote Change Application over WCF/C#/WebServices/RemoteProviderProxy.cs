// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections.Generic;

using Microsoft.Synchronization;
using Sync101;

namespace Sync101WebService
{
    public class RemoteProviderProxy : KnowledgeSyncProvider
    {
        private SyncIdFormatGroup idFormats;
        private Sync101WebServiceClient client;
        private SyncSessionContext syncSessionContext;
        private string folderPath;
        private string storeName;
        private string endpointConfigurationName;

        public RemoteProviderProxy(
            string folderPath,
            string storeName,
            string endpointConfigurationName)
        {
            this.folderPath = folderPath;
            this.storeName = storeName;
            this.endpointConfigurationName = endpointConfigurationName;

            // Create a client
            this.client = new Sync101WebServiceClient(
                endpointConfigurationName);

            this.client.CreateProviderForSyncSession(folderPath, this.storeName);
            this.idFormats = this.client.GetIdFormats();
        }

        public override SyncIdFormatGroup IdFormats
        {
            get
            {
                return this.idFormats;
            }
        }

        public override void BeginSession(
            SyncProviderPosition position, 
            SyncSessionContext syncSessionContext)
        {
            if (this.client == null)
            {
                // Allow for the same proxy to be use in several unidirectional session
                this.client = new Sync101WebServiceClient(
                    endpointConfigurationName);

                this.client.CreateProviderForSyncSession(folderPath, this.storeName);
            }

            this.syncSessionContext = syncSessionContext;
            this.client.BeginSession();
        }

        public override void EndSession(
            SyncSessionContext syncSessionContext)
        {
            this.syncSessionContext = null;
            this.client.EndSession();
            this.client = null;
        }

        public override ChangeBatch GetChangeBatch(
            uint batchSize, 
            SyncKnowledge destinationKnowledge, 
            out object changeDataRetriever)
        {
            CachedChangeDataRetriever cachedChangeDataRetriever;

            ChangeBatch changeBatch = this.client.GetChangeBatch(
                batchSize,
                destinationKnowledge,
                out cachedChangeDataRetriever);

            changeDataRetriever = cachedChangeDataRetriever;

            return changeBatch;
        }

        public override FullEnumerationChangeBatch GetFullEnumerationChangeBatch(
            uint batchSize, 
            SyncId lowerEnumerationBound, 
            SyncKnowledge knowledgeForDataRetrieval, 
            out object changeDataRetriever)
        {
            CachedChangeDataRetriever cachedChangeDataRetriever;

            FullEnumerationChangeBatch fullEnumerationChangeBatch = this.client.GetFullEnumerationChangeBatch(
                batchSize,
                lowerEnumerationBound,
                knowledgeForDataRetrieval,
                out cachedChangeDataRetriever);

            changeDataRetriever = cachedChangeDataRetriever;

            return fullEnumerationChangeBatch;
        }

        public override void GetSyncBatchParameters(
            out uint batchSize, 
            out SyncKnowledge knowledge)
        {
            this.client.GetSyncBatchParameters(
                out batchSize,
                out knowledge);
        }

        public override void ProcessChangeBatch(
            ConflictResolutionPolicy resolutionPolicy, 
            ChangeBatch sourceChanges, 
            object changeDataRetriever, 
            SyncCallbacks syncCallback, 
            SyncSessionStatistics sessionStatistics)
        {
            CachedChangeDataRetriever cachedChangeDataRetriever = new CachedChangeDataRetriever(
                    changeDataRetriever as IChangeDataRetriever,
                    sourceChanges);

            byte[] newChangeApplierInfo = this.client.ProcessChangeBatch(
                resolutionPolicy,
                sourceChanges,
                cachedChangeDataRetriever,
                this.syncSessionContext.ChangeApplierInfo);

            this.syncSessionContext.ChangeApplierInfo = newChangeApplierInfo;
        }

        public override void ProcessFullEnumerationChangeBatch(
            ConflictResolutionPolicy resolutionPolicy, 
            FullEnumerationChangeBatch sourceChanges, 
            object changeDataRetriever, 
            SyncCallbacks syncCallback, 
            SyncSessionStatistics sessionStatistics)
        {
            CachedChangeDataRetriever cachedChangeDataRetriever = new CachedChangeDataRetriever(
                changeDataRetriever as IChangeDataRetriever,
                sourceChanges);

            byte[] newChangeApplierInfo = this.client.ProcessFullEnumerationChangeBatch(
                resolutionPolicy,
                sourceChanges,
                cachedChangeDataRetriever,
                this.syncSessionContext.ChangeApplierInfo);

            this.syncSessionContext.ChangeApplierInfo = newChangeApplierInfo;
        }

        #region For demo purpose, not required for RCA pattern
        public void CleanupTombstones(TimeSpan timespan)
        {
            this.client.CleanupTombstones(timespan);
        }
        #endregion
    }
}
