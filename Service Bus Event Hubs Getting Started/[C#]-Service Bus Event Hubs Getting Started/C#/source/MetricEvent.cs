using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Microsoft.ServiceBus.Samples
{
    [DataContract]
    public class MetricEvent
    {
        [DataMember]
        public int DeviceId { get; set; }
        [DataMember]
        public int Temperature { get; set; }
    }
}
