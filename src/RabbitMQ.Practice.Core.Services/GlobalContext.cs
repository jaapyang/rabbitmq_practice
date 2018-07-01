namespace RabbitMQ.Practice.Core.Services
{
    public class GlobalContext
    {
        public static GlobalContext Instance { get; }

        static GlobalContext()
        {
            Instance = new GlobalContext
            {
                RabbitMq = new RabbitMqConfig(),
                Logger = new LocalLog()
            };
        }

        public RabbitMqConfig RabbitMq { get; private set; }
        public ILog Logger { get; private set; }
    }
}