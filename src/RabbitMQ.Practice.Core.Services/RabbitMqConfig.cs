using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.Practice.Core.Services
{

    public class RabbitMqConfig
    {
        public string HostName { get; } = "localhost";

        public string Queue { get; } = "hello";

        public bool Durable { get; } = false;

        public bool Exclusive { get; } = false;

        public bool AutoDelete { get; } = false;

        public object Arguments { get; } = null;
        public string Exchange { get; } = string.Empty;
        public string RoutingKey { get; } = "hello";
        public bool AutoAck { get; } = true;
    }
}
