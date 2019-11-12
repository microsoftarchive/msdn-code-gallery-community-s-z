// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections.Generic;

using Microsoft.Synchronization;

namespace Sync101
{
    [Serializable()]
    public class CachedChangeDataRetriever : IChangeDataRetriever
    {
        private SyncIdFormatGroup idFormats;
        private Dictionary<SyncId, ItemData> cachedData;

        public CachedChangeDataRetriever(
            IChangeDataRetriever changeDataRetriever,
            ChangeBatchBase sourceChanges)
        {
            this.idFormats = changeDataRetriever.IdFormats;
            this.cachedData = new Dictionary<SyncId, Sync101.ItemData>();

            // Look at each change in the source batch
            foreach (ItemChange itemChange in sourceChanges)
            {
                if (itemChange.ChangeKind != ChangeKind.Deleted)
                {
                    // This is not delete, so there is some data associated
                    // with this change.

                    // Create a UserLoadChangeContext to retriever this data.
                    UserLoadChangeContext loadChangeContext = new UserLoadChangeContext(
                        idFormats,
                        itemChange);

                    // Retrieve the data (we know that our provider uses data of type ItemData.
                    ItemData itemData = changeDataRetriever.LoadChangeData(
                        loadChangeContext) as ItemData;

                    // Cache it
                    cachedData.Add(itemChange.ItemId, itemData);
                }
            }
        }

        public SyncIdFormatGroup IdFormats 
        {
            get
            {
                return this.idFormats;
            }
        }

        public object LoadChangeData(LoadChangeContext loadChangeContext)
        {
            return cachedData[loadChangeContext.ItemChange.ItemId];
        }
    }
}
