using Newtonsoft.Json;

namespace RabbitMQ.Practice.WinApp
{
    public class ExchangeEntity
    {
        public MessageStatsEntity message_stats { get; set; }
        public string name { get; set; }
        public string vhost { get; set; }
        public string type { get; set; }
        public bool durable { get; set; }
        [JsonProperty("internal")]
        public bool internalFlag { get; set; }
        public bool auto_delete { get; set; }
    }
}