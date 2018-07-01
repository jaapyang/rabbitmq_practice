namespace RabbitMQ.Practice.Core.Services
{
    public class ApplicationContext
    {
        public static ApplicationContext Instance { get; }

        static ApplicationContext()
        {
            Instance = new ApplicationContext
            {
                RabbitMq = new RabbitMqConfig(),
                Logger = new LocalLog()
            };
        }

        public RabbitMqConfig RabbitMq { get; private set; }
        public ILog Logger { get; private set; }
    }
}