using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daenet.WcfWebSocketListener
{
    enum MessageType
    {
        Send,
        Broadcast,
        Join,
        Leave
    }

    class Message
    {
        public MessageType Type { get; set; }
        public string Value { get; set; }
        public string Nick { get; set; }
    }
}
