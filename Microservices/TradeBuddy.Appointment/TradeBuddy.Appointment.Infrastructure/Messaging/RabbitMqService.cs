using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading.Tasks;
using TradeBuddy.Appointment.Application.Common.Interfaces;

namespace TradeBuddy.Appointment.Infrastructure.Messaging
{
    public class RabbitMqService : IMessagingService, IDisposable
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly string _queueName;

        public RabbitMqService(IConfiguration configuration)
        {
            var factory = new ConnectionFactory()
            {
                HostName = configuration["RabbitMqSettings:HostName"],
                AutomaticRecoveryEnabled = true, // فعال‌سازی خودکار بازیابی
                NetworkRecoveryInterval = TimeSpan.FromSeconds(10), // مدت زمان بازیابی
                RequestedHeartbeat = TimeSpan.FromSeconds(60) // تنظیم زمان خواب و برقراری اتصال
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _queueName = configuration["RabbitMqSettings:QueueName"];

            // اطمینان از ایجاد صف در زمان شروع برنامه
            _channel.QueueDeclare(queue: _queueName,
                                  durable: true, // Durable queue
                                  exclusive: false,
                                  autoDelete: false,
                                  arguments: null);
        }

        // ارسال پیام به صف
        public async Task PublishAsync<T>(T message)
        {
            try
            {
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                // ارسال پیام به صف
                _channel.BasicPublish(exchange: "",
                                      routingKey: _queueName,
                                      basicProperties: null,
                                      body: body);

                Console.WriteLine($"Message published to queue: {JsonConvert.SerializeObject(message)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error publishing message: {ex.Message}");
            }
        }
        public async Task SubscribeAsync<TMessage>(Func<TMessage, Task> onMessageReceived)
        {
            // اطمینان از این که صف به درستی اعلام شده باشد
            _channel.QueueDeclare(queue: _queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                try
                {
                    // تبدیل پیام به نوع TMessage به صورت generic
                    var appointmentRequest = JsonConvert.DeserializeObject<TMessage>(message);

                    // پردازش پیام اگر نوع درست باشد
                    if (appointmentRequest != null)
                    {
                        await onMessageReceived(appointmentRequest);  // فراخوانی با نوع صحیح
                    }
                }
                catch (Exception ex)
                {
                    // مدیریت خطا در صورتی که تبدیل به نوع مورد نظر مشکل داشته باشد
                    Console.WriteLine($"Error deserializing message: {ex.Message}");
                }
            };

            // شروع به دریافت پیام‌ها
            _channel.BasicConsume(queue: _queueName, autoAck: true, consumer: consumer);
        }

        // بستن منابع (اتصال و کانال)
        public void Dispose()
        {
            _channel?.Close();
            _connection?.Close();
            Console.WriteLine("Connection and channel closed.");
        }
    }
}
