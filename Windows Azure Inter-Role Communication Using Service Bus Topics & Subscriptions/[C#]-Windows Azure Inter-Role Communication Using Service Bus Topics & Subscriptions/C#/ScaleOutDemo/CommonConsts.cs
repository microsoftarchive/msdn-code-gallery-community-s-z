//=======================================================================================
// Microsoft Windows Azure Customer Advisory Team (CAT) Best Practices Series
//
// This sample is supplemental to the technical guidance published on the community
// blog at http://windowsazurecat.com/. 
//
//=======================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
// EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
// MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=======================================================================================
namespace ScaleOutDemo
{
    #region Using references
    using System;
    #endregion

    public static class CommonConsts
    {
        public const string TopicServiceBusEndpointName = "IRC-Topic";
        public const string EventRelayServiceBusEndpointName = "IRC-EventRelay";
        public const string ConfigSettingPubSubType = "PubSubType";
        public const string ConfigSettingStorageAccount = "StorageAccount";
        public const string ConfigSettingStorageAccountKey = "StorageAccountKey";
        public const string ConfigSettingPubSubTypeValueTopic = "TOPIC";
        public const string ConfigSettingTestResultsTableName = "TestResultsTableName";
        public const string ConfigSettingTestRunsTableName = "TestRunsTableName";
        public const string DiagnosticTraceLogsTableName = "WADLogsTable";
        public const string SessionKeyTestRunFinishEvent = "TestRunFinishEvent";
    }
}
