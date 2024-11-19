using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;
using TradeBuddy.Business.Application.Common.Interfaces;

namespace TradeBuddy.Business.Application.Service
{
    public class MessageListenerService : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public MessageListenerService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // تابعی که پیام‌ها را پردازش می‌کند
            Func<AppointmentRequestMessage, Task> onMessageReceived = async message =>
            {
                if (message.Action == "RequestAppointments")
                {
                    var responseMessage = new
                    {
                        Action = "ResponseAppointments",
                        Data = "Response Princess appointment data from Business service.",
                        CorrelationId = message.CorrelationId  // افزودن شناسه یکتا به پیام
                    };

                    // ایجاد scope جدید برای دسترسی به سرویس‌های scoped
                    using (var scope = _serviceScopeFactory.CreateScope())
                    {
                        var scopedMessagingService = scope.ServiceProvider.GetRequiredService<IMessagingService>();
                        await scopedMessagingService.PublishAsync(responseMessage);
                    }
                }
            };

            // اشتراک در پیام‌ها
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var scopedMessagingService = scope.ServiceProvider.GetRequiredService<IMessagingService>();

                // ارسال تابع onMessageReceived با نوع صحیح
                await scopedMessagingService.SubscribeAsync(onMessageReceived);
            }
        }
    }
}
