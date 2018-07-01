using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Practice.Core.Extensions;
using RabbitMQ.Practice.Core.Services;

namespace RabbitMQ.Practice.ClsApp.SendProcesser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please type your message:");
            string message = Console.ReadLine();
            var body = message.GetBytesByUtf8();

            var factory = new ConnectionFactory() {HostName = GlobalContext.Instance.RabbitMq.HostName};

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: GlobalContext.Instance.RabbitMq.Queue,
                    durable:GlobalContext.Instance.RabbitMq.Durable,
                    exclusive: GlobalContext.Instance.RabbitMq.Exclusive,
                    autoDelete: GlobalContext.Instance.RabbitMq.AutoDelete,
                    arguments:null);
                
                channel.BasicPublish(exchange: GlobalContext.Instance.RabbitMq.Exchange,
                    routingKey: GlobalContext.Instance.RabbitMq.RoutingKey,
                    basicProperties:null,
                    body:body);

                Console.WriteLine($" [x] Sent message: {message}");
                GlobalContext.Instance.Logger.Debug(message.AppendLine(channel.GetType().FullName));
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}
