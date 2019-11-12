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

using Microsoft.ServiceBus.Messaging;
using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace Microsoft.ServiceBus.ServicebusHttpClient
{
    [DataContract]
    class BrokerProperties
    {
        [DataMember(EmitDefaultValue = false)]
        public string CorrelationId;

        [DataMember(EmitDefaultValue = false)]
        public string SessionId;

        [DataMember(EmitDefaultValue = false)]
        public int? DeliveryCount;

        [DataMember(EmitDefaultValue = false)]
        public Guid? LockToken;

        [DataMember(EmitDefaultValue = false)]
        public string MessageId;

        [DataMember(EmitDefaultValue = false)]
        public string Label;

        [DataMember(EmitDefaultValue = false)]
        public string ReplyTo;

        [DataMember(EmitDefaultValue = false)]
        public long? SequenceNumber;

        [DataMember(EmitDefaultValue = false)]
        public string To;

        public DateTime? LockedUntilUtcDateTime;

        [DataMember(EmitDefaultValue = false)]
        public string LockedUntilUtc
        {
            get
            {
                if (LockedUntilUtcDateTime != null && LockedUntilUtcDateTime.HasValue)
                {
                    return LockedUntilUtcDateTime.Value.ToString("R", CultureInfo.InvariantCulture);
                }

                return null;
            }
            set
            {
                try
                {
                    LockedUntilUtcDateTime = DateTime.Parse(value, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);
                }
                catch
                {
                }
            }
        }

        public DateTime? ScheduledEnqueueTimeUtcDateTime;

        [DataMember(EmitDefaultValue = false)]
        public string ScheduledEnqueueTimeUtc
        {
            get
            {
                if (ScheduledEnqueueTimeUtcDateTime != null && ScheduledEnqueueTimeUtcDateTime.HasValue)
                {
                    return ScheduledEnqueueTimeUtcDateTime.Value.ToString("R", CultureInfo.InvariantCulture);
                }

                return null;
            }
            set
            {
                try
                {
                    ScheduledEnqueueTimeUtcDateTime = DateTime.Parse(value, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);
                }
                catch
                {
                }
            }
        }

        public TimeSpan? TimeToLiveTimeSpan;

        [DataMember(EmitDefaultValue = false)]
        public double TimeToLive
        {
            get
            {
                if (TimeToLiveTimeSpan != null && TimeToLiveTimeSpan.HasValue)
                {
                    return TimeToLiveTimeSpan.Value.TotalSeconds;
                }
                return 0;
            }
            set
            {
                // This is needed as TimeSpan.FromSeconds(TimeSpan.MaxValue.TotalSeconds) throws Overflow exception.
                if (TimeSpan.MaxValue.TotalSeconds == value)
                {
                    TimeToLiveTimeSpan = TimeSpan.MaxValue;
                }
                else
                {
                    TimeToLiveTimeSpan = TimeSpan.FromSeconds(value);
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public string ReplyToSessionId;

        public MessageState StateEnum;

        [DataMember(EmitDefaultValue = false)]
        public string State
        {
            get { return StateEnum.ToString(); }

            internal set { StateEnum = (MessageState)Enum.Parse(typeof(MessageState), value); }
        }

        [DataMember(EmitDefaultValue = false)]
        public long? EnqueuedSequenceNumber;

        [DataMember(EmitDefaultValue = false)]
        public string PartitionKey;

        public DateTime? EnqueuedTimeUtcDateTime;

        [DataMember(EmitDefaultValue = false)]
        public string EnqueuedTimeUtc
        {
            get
            {
                if (EnqueuedTimeUtcDateTime != null && EnqueuedTimeUtcDateTime.HasValue)
                {
                    return EnqueuedTimeUtcDateTime.Value.ToString("R", CultureInfo.InvariantCulture);
                }

                return null;
            }
            set
            {
                try
                {
                    EnqueuedTimeUtcDateTime = DateTime.Parse(value, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);
                }
                catch
                {
                }
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public string ViaPartitionKey;

        [DataMember(EmitDefaultValue = false)]
        public bool? ForcePersistence;
    }
}
