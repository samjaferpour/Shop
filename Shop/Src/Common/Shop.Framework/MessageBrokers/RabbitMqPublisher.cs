
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Framework.MessageBrokers
{
    public class RabbitMqPublisher : IRabbitMqPublisher
    {

        public async Task<bool> SendMessageAsync<T>(T message)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                VirtualHost = "/",
                UserName = "guest",
                Password = "guest",
                Port = 5672
            };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.ExchangeDeclare(exchange: "shop.exchange", type: ExchangeType.Direct, durable: true, autoDelete: false);
            channel.QueueDeclare(queue: "shop_queue", durable: true, exclusive: false, autoDelete: false);

            var json = JsonConvert.SerializeObject(message);
            var messageBytes = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: "shop.exchange", routingKey: "shop_queue", body: messageBytes);
            return true;
        }
        public async Task<bool> SendMessagesAsync<T>(List<T> messages)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                VirtualHost = "/",
                UserName = "guest",
                Password = "guest",
                Port = 5672
            };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.ExchangeDeclare(exchange: "shop.exchange", type: ExchangeType.Direct, durable: true, autoDelete: false);
            channel.QueueDeclare(queue: "shop_queue", durable: true, exclusive: false, autoDelete: false);
            channel.QueueBind(queue: "shop_queue", exchange: "shop.exchange", routingKey: "shop_queue");
            foreach (var message in messages)
            {
                var json = JsonConvert.SerializeObject(message);
                var messageBytes = Encoding.UTF8.GetBytes(json);
                channel.BasicPublish(exchange: "shop.exchange", routingKey: "shop_queue", body: messageBytes);
            }
            return true;
        }
    }
}
