// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections.Generic;
using System.ServiceModel;

using Microsoft.Synchronization;

namespace Sync101WebService
{
    [ServiceContract(
      Name = "Sync101WebService",
      Namespace = "http://microsoft.synchronization",
      SessionMode = SessionMode.Required)]
    [ServiceKnownType(typeof(SyncIdFormatGroup))]
    [ServiceKnownType(typeof(SyncId))]
    public interface ISync101WebService
    {
        [OperationContract(
            IsInitiating = true,
            IsTerminating = false)]
        void CreateProviderForSyncSession(
            string dataAndMetadataFolderPath, 
            string storeName);

        [OperationContract(
            IsInitiating = false,
            IsTerminating = false)]
        SyncIdFormatGroup GetIdFormats();

        [OperationContract(
            IsInitiating = false,
            IsTerminating = false)]
        void BeginSession();

        [OperationContract(
            IsInitiating = false,
            IsTerminating = true)]
        void EndSession();

        [OperationContract(
            IsInitiating = false,
            IsTerminating = false)]
        ChangeBatch GetChangeBatch(
            uint batchSize,
            SyncKnowledge destinationKnowledge,
            out Sync101.CachedChangeDataRetriever changeDataRetriever);

        [OperationContract(
            IsInitiating = false,
            IsTerminating = false)]
        FullEnumerationChangeBatch GetFullEnumerationChangeBatch(
            uint batchSize,
            SyncId lowerEnumerationBound,
            SyncKnowledge knowledgeForDataRetrieval,
            out Sync101.CachedChangeDataRetriever changeDataRetriever);

        [OperationContract(
            IsInitiating = false,
            IsTerminating = false)]
        void GetSyncBatchParameters(
            out uint batchSize,
            out SyncKnowledge knowledge);

        [OperationContract(
            IsInitiating = false,
            IsTerminating = false)]
        byte[] ProcessChangeBatch(
            ConflictResolutionPolicy resolutionPolicy,
            ChangeBatch sourceChanges,
            Sync101.CachedChangeDataRetriever changeDataRetriever,
            byte[] changeApplierInfo);

        [OperationContract(
            IsInitiating = false,
            IsTerminating = false)]
        byte[] ProcessFullEnumerationChangeBatch(
            ConflictResolutionPolicy resolutionPolicy,
            FullEnumerationChangeBatch sourceChanges,
            Sync101.CachedChangeDataRetriever changeDataRetriever,
            byte[] changeApplierInfo);

        #region For demo purpose, not required for RCA pattern
        [OperationContract(
            IsInitiating = false,
            IsTerminating = false)]
        void CleanupTombstones(TimeSpan timespan);
        #endregion
    }
}
