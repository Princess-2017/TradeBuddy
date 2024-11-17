using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading.Tasks;
using TradeBuddy.Business.Application.Common.Interfaces;

namespace TradeBuddy.Business.Infrastructure.Messaging
{
    public class RabbitMqService : IMessagingService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly string _queueName;

        public RabbitMqService(IConfiguration configuration)
        {
            var factory = new ConnectionFactory() { HostName = configuration["RabbitMqSettings:HostName"] };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _queueName = configuration["RabbitMqSettings:QueueName"];
        }

        public async Task PublishAsync<T>(T message)
        {
            await Task.Run(() =>
            {
                _channel.QueueDeclare(queue: _queueName,
                                      durable: true, // Durable queue
                                      exclusive: false,
                                      autoDelete: false,
                                      arguments: null);

                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                _channel.BasicPublish(exchange: "",
                                      routingKey: _queueName,
                                      basicProperties: null,
                                      body: body);
            });
        }

        public async Task SubscribeAsync<T>(Func<T, Task> onMessageReceived)
        {
            // Declare the queue, ensuring it's durable and persistent
            _channel.QueueDeclare(queue: _queueName,
                                  durable: true, // Durable queue
                                  exclusive: false,
                                  autoDelete: false,
                                  arguments: null);

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                var obj = JsonConvert.DeserializeObject<T>(message);

                // Await the asynchronous processing of the message
                await onMessageReceived(obj);
            };

            // Start consuming messages
            await Task.Run(() =>
            {
                _channel.BasicConsume(queue: _queueName,
                                     autoAck: true,
                                     consumer: consumer);
            });
        }

    }
}
