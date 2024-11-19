using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;
using TradeBuddy.Appointment.Application.Common.Interfaces;

namespace TradeBuddy.Appointment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IMessagingService _messagingService;

        public AppointmentController(IMessagingService messagingService)
        {
            _messagingService = messagingService;
        }

        [HttpGet("GetAppointments")]
        public async Task<IActionResult> GetAppointments(CancellationToken cancellationToken)
        {
            // ایجاد شناسه یکتا برای درخواست
            var correlationId = Guid.NewGuid().ToString();

            var message = new
            {
                Action = "RequestAppointments",
                Data = "Requesting appointment data from Business service.",
                CorrelationId = correlationId  // افزودن شناسه یکتا به پیام
            };

            // ارسال پیام به صف
            await _messagingService.PublishAsync(message);

            string responseMessage = null;

            var tcs = new TaskCompletionSource<string>();  // برای به دست آوردن پاسخ


            // اشتراک‌گذاری برای دریافت پاسخ
            _messagingService.SubscribeAsync<string>(async response =>
            {
                try
                {
                    // بررسی اینکه آیا این پیام پاسخ مورد نظر است و CorrelationId مطابقت دارد
                    var responseMessageObject = JsonConvert.DeserializeObject<dynamic>(response);
                    if (responseMessageObject?.CorrelationId == correlationId && response.Contains("ResponseAppointments"))
                    {
                        // وقتی پاسخ دریافت شد، نتیجه را ذخیره کن
                        await Task.Run(() => tcs.SetResult(response)); // استفاده از async/await برای اطمینان از اجرای ناهمزمان
                    }
                }
                catch (Exception ex)
                {
                    // اضافه کردن لاگ برای بررسی خطا در پردازش پیام
                    Console.WriteLine($"Error processing response: {ex.Message}");
                }
            });

            // منتظر دریافت پاسخ
            var resultTask = await Task.WhenAny(tcs.Task, Task.Delay(50000, cancellationToken)); // مدت زمان بیشتر

            if (resultTask == tcs.Task)
            {
                // دریافت پاسخ و اطمینان از اینکه پیام از بیزینس سرویس آمده است
                responseMessage = tcs.Task.Result;
                return Ok(new { Message = "Received response from Business service", Response = responseMessage });
            }
            else
            {
                return StatusCode(504, "No response received from Business service.");
            }

        }

    }
}
