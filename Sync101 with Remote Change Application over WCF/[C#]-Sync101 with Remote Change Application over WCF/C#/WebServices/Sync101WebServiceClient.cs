// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections.Generic;
using System.ServiceModel;

using Microsoft.Synchronization;

namespace Sync101WebService
{
    public class Sync101WebServiceClient : System.ServiceModel.ClientBase<ISync101WebService>, ISync101WebService
    {
        public Sync101WebServiceClient(
            System.ServiceModel.Channels.Binding binding, 
            System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }

        public Sync101WebServiceClient(string endpointConfigurationName)
            : base(endpointConfigurationName)
        {
        }

        public SyncIdFormatGroup GetIdFormats()
        {
            return base.Channel.GetIdFormats();
        }

        public void CreateProviderForSyncSession(
            string dataAndMetadataFolderPath, 
            string storeName)
        {
            base.Channel.CreateProviderForSyncSession(dataAndMetadataFolderPath, storeName);
        }

        public void BeginSession()
        {
            base.Channel.BeginSession();
        }

        public void EndSession()
        {
            base.Channel.EndSession();
        }

        public ChangeBatch GetChangeBatch(
            uint batchSize,
            SyncKnowledge destinationKnowledge,
            out Sync101.CachedChangeDataRetriever changeDataRetriever)
        {
            return base.Channel.GetChangeBatch(
                batchSize,
                destinationKnowledge,
                out changeDataRetriever);
        }

        public FullEnumerationChangeBatch GetFullEnumerationChangeBatch(
            uint batchSize,
            SyncId lowerEnumerationBound,
            SyncKnowledge knowledgeForDataRetrieval,
            out Sync101.CachedChangeDataRetriever changeDataRetriever)
        {
            return base.Channel.GetFullEnumerationChangeBatch(
                batchSize,
                lowerEnumerationBound,
                knowledgeForDataRetrieval,
                out changeDataRetriever);
        }

        public void GetSyncBatchParameters(
            out uint batchSize,
            out SyncKnowledge knowledge)
        {
            base.Channel.GetSyncBatchParameters(
                out batchSize,
                out knowledge);
        }

        public byte[] ProcessChangeBatch(
            ConflictResolutionPolicy resolutionPolicy,
            ChangeBatch sourceChanges,
            Sync101.CachedChangeDataRetriever changeDataRetriever,
            byte[] changeApplierInfo)
        {
            return base.Channel.ProcessChangeBatch(
                resolutionPolicy,
                sourceChanges,
                changeDataRetriever,
                changeApplierInfo);
        }

        public byte[] ProcessFullEnumerationChangeBatch(
            ConflictResolutionPolicy resolutionPolicy,
            FullEnumerationChangeBatch sourceChanges,
            Sync101.CachedChangeDataRetriever changeDataRetriever,
            byte[] changeApplierInfo)
        {
            return base.Channel.ProcessFullEnumerationChangeBatch(
                resolutionPolicy,
                sourceChanges,
                changeDataRetriever,
                changeApplierInfo);
        }

        #region For demo purpose, not required for RCA pattern
        public void CleanupTombstones(TimeSpan timespan)
        {
            base.Channel.CleanupTombstones(timespan);
        }
        #endregion
    }
}
