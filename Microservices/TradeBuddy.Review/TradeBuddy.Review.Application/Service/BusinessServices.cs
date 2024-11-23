using System;
using System.Threading;
using System.Threading.Tasks;
using TradeBuddy.Review.Application.Common.Interfaces;

namespace TradeBuddy.Review.Application.Service
{
    // Create a model for messages received from the queue
    public class AppointmentRequestMessage
    {
        public string Action { get; set; }
        public string Data { get; set; }
        public string CorrelationId { get; set; }

    }

    public class ReviewService : IReviewService
    {
        private readonly IMessagingService _messagingService;

        public ReviewService(IMessagingService messagingService)
        {
            _messagingService = messagingService;

            Console.WriteLine("BusinessService is being initialized...");

            // شروع گوش دادن به پیام‌ها در پس‌زمینه
            StartListeningForMessages();
        }

        private void StartListeningForMessages()
        {
            // شروع اشتراک‌گذاری در پس‌زمینه
            Task.Run(async () =>
            {
                // استفاده از SubscribeAsync به صورت generic
                await _messagingService.SubscribeAsync<AppointmentRequestMessage>(async message =>
                {
                    if (message.Action == "RequestAppointments")
                    {
                        // پردازش پیام و ارسال پاسخ
                        var responseMessage = new
                        {
                            Action = "ResponseAppointments",
                            Data = "Response Princess appointment data from Business service.",
                            CorrelationId = message.CorrelationId  // افزودن شناسه یکتا به پیام
                        };

                        try
                        {
                            // ارسال پاسخ به صف
                            await _messagingService.PublishAsync(responseMessage);
                        }
                        catch (Exception ex)
                        {
                            // مدیریت خطا
                            Console.WriteLine($"Error publishing response: {ex.Message}");
                        }
                    }
                });
            });
        }

        public async Task<string> ProcessMessageAsync(string message)
        {
            // پردازش پیام (برای مثال، پیام را تجزیه کن)
            if (message.Contains("RequestAppointments"))
            {
                // ارسال درخواست برای دریافت اطلاعات نوبت‌ها
                var appointmentRequestMessage = new AppointmentRequestMessage
                {
                    Action = "RequestAppointments",
                    Data = "Response Princess appointment data from Business service.",
                };

                try
                {
                    // ارسال پیام به صف به صورت غیر همزمان
                    await _messagingService.PublishAsync(appointmentRequestMessage);
                    return "Request to Business service sent successfully.";
                }
                catch (Exception ex)
                {
                    // مدیریت خطا
                    return $"Error sending request to Business service: {ex.Message}";
                }
            }
            else
            {
                return "Unknown message type.";
            }
        }
    }

}
