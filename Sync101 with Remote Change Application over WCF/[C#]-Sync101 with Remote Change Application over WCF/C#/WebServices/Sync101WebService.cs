// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Description;

using Microsoft.Synchronization;
using Sync101;

namespace Sync101WebService
{
    [ServiceBehavior(
         ConcurrencyMode = ConcurrencyMode.Single,
         InstanceContextMode = InstanceContextMode.PerSession,
         IncludeExceptionDetailInFaults = true)]
    public class Sync101WebService : ISync101WebService
    {
        MySyncProvider provider;

        public Sync101WebService()
        {
        }

        public SyncIdFormatGroup GetIdFormats()
        {
            return provider.IdFormats;
        }

        public void CreateProviderForSyncSession(string dataAndMetadataFolderPath, string name)
        {
            this.provider = new MySyncProvider(dataAndMetadataFolderPath, name);
        }

        public void BeginSession()
        {
            provider.BeginSession();
        }

        public void EndSession()
        {
            provider.EndSession();
        }

        public ChangeBatch GetChangeBatch(
            uint batchSize,
            SyncKnowledge destinationKnowledge,
            out CachedChangeDataRetriever changeDataRetriever)
        {
            object dataRetriever;

            ChangeBatch changeBatch = provider.GetChangeBatch(
                batchSize,
                destinationKnowledge,
                out dataRetriever);

            changeDataRetriever = new CachedChangeDataRetriever(
                dataRetriever as IChangeDataRetriever,
                changeBatch);

            return changeBatch;
        }

        public FullEnumerationChangeBatch GetFullEnumerationChangeBatch(
            uint batchSize,
            SyncId lowerEnumerationBound,
            SyncKnowledge knowledgeForDataRetrieval,
            out CachedChangeDataRetriever changeDataRetriever)
        {
            object dataRetriever;

            FullEnumerationChangeBatch changeBatch = provider.GetFullEnumerationChangeBatch(
                batchSize,
                lowerEnumerationBound,
                knowledgeForDataRetrieval,
                out dataRetriever);

            changeDataRetriever = new CachedChangeDataRetriever(
                dataRetriever as IChangeDataRetriever,
                changeBatch);

            return changeBatch;
        }

        public void GetSyncBatchParameters(
            out uint batchSize,
            out SyncKnowledge knowledge)
        {
            provider.GetSyncBatchParameters(
                out batchSize,
                out knowledge);
        }

        public byte[] ProcessChangeBatch(
            ConflictResolutionPolicy resolutionPolicy,
            ChangeBatch sourceChanges,
            CachedChangeDataRetriever changeDataRetriever,
            byte[] changeApplierInfo)
        {
            return provider.ProcessRemoteChangeBatch(
                resolutionPolicy,
                sourceChanges,
                changeDataRetriever,
                changeApplierInfo);
        }

        public byte[] ProcessFullEnumerationChangeBatch(
            ConflictResolutionPolicy resolutionPolicy,
            FullEnumerationChangeBatch sourceChanges,
            CachedChangeDataRetriever changeDataRetriever,
            byte[] changeApplierInfo)
        {
            return provider.ProcessRemoteFullEnumerationChangeBatch(
                resolutionPolicy,
                sourceChanges,
                changeDataRetriever,
                changeApplierInfo);
        }

        #region For demo purpose, not required for RCA pattern
        public void CleanupTombstones(TimeSpan timespan)
        {
            provider.CleanupTombstones(timespan);
        }
        #endregion
    }
}
