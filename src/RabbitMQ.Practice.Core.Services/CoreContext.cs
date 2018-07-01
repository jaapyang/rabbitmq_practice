namespace RabbitMQ.Practice.Core.Services
{
    public class CoreContext
    {
        public static CoreContext Instance { get; }

        static CoreContext()
        {
            Instance = new CoreContext
            {
                RabbitMq = new RabbitMqConfig(),
                Logger = new LocalLog()
            };
        }

        public RabbitMqConfig RabbitMq { get; private set; }
        public ILog Logger { get; private set; }
    }
}