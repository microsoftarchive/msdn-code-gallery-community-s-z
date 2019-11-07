//---------------------------------------------------------------------------------
// Copyright (c) 2014, Microsoft Corporation
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//---------------------------------------------------------------------------------


namespace Microsoft.ServiceBus.Samples.EventHubHttpClient
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization.Json;
    using System.Threading.Tasks;
    using Microsoft.ServiceBus.Messaging;

    public class DeviceEventProcessor : IEventProcessor
    {
        static DataContractJsonSerializer telemetryEventSerializer = new DataContractJsonSerializer(typeof(TelemetryData));
        
        public Task OpenAsync(PartitionContext context)
        {
            return Task.FromResult<object>(null);
        }

        public Task ProcessEventsAsync(PartitionContext context, IEnumerable<EventData> events)
        {
            foreach (var telemetryEvent in events)
            {
                var telemetryData = telemetryEvent.GetBody<TelemetryData>(telemetryEventSerializer);
                Console.WriteLine("Processing EVENT [(Temperature: {0}, Humidity: {1}) Publisher: {2}, PartitionKey: {3}] at PartitionId: {4}",
                    telemetryData.Temperature, 
                    telemetryData.Humidity, 
                    telemetryEvent.SystemProperties["Publisher"], 
                    telemetryEvent.PartitionKey,
                    context.Lease.PartitionId);

                foreach (KeyValuePair<string, object> p in telemetryEvent.Properties)
                {
                    if (!p.Key.Equals("ContentType"))
                    {
                        Console.WriteLine("   [Property: {0} = {1}]", p.Key, p.Value);
                    }
                }
            }

            return Task.FromResult<object>(null);
        }

        public Task CloseAsync(PartitionContext context, CloseReason reason)
        {
            return Task.FromResult<object>(null);
        }
    }

    public class DeviceProcessorCheckpointManager : ICheckpointManager
    {
        public Task CheckpointAsync(Lease lease, string offset, long sequenceNumber)
        {
            throw new NotImplementedException();
        }
    }
}
