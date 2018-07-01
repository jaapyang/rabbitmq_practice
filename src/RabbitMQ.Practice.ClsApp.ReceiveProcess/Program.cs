using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Practice.Core.Extensions;
using RabbitMQ.Practice.Core.Services;

namespace RabbitMQ.Practice.ClsApp.ReceiveProcess
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() {HostName = ApplicationContext.Instance.RabbitMq.HostName};
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: ApplicationContext.Instance.RabbitMq.Queue,
                    durable: ApplicationContext.Instance.RabbitMq.Durable,
                    exclusive: ApplicationContext.Instance.RabbitMq.Exclusive,
                    autoDelete: ApplicationContext.Instance.RabbitMq.AutoDelete,
                    arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += OnMessageReceived;

                channel.BasicConsume(queue: ApplicationContext.Instance.RabbitMq.Queue,
                    autoAck: ApplicationContext.Instance.RabbitMq.AutoAck,
                    consumer: consumer);
                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }

        private static void OnMessageReceived(object sender, BasicDeliverEventArgs e)
        {
            var message = e.Body.GetStringByUtf8();
            ApplicationContext.Instance.Logger.Debug(message);
            Console.WriteLine($" [x] Received message: {message}");
        }
    }
}
