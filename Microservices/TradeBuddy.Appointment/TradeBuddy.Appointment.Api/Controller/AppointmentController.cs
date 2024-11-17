using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetAppointments()
        {
            var message = new
            {
                Action = "RequestAppointments",
                Data = "Requesting appointment data from Business service."
            };

            _messagingService.Publish(message); // ارسال پیام به صف

            string responseMessage = null;

            // اشتراک‌گذاری برای دریافت پاسخ
            _messagingService.Subscribe<string>(response =>
            {
                responseMessage = response;
            });

            // منتظر پاسخ
            await Task.Delay(2000);  // منتظر 2 ثانیه برای پاسخ

            if (responseMessage != null)
            {
                return Ok(new { Message = "Received response from Business service", Response = responseMessage });
            }
            else
            {
                return StatusCode(504, "No response received from Business service.");
            }
        }
    }
}



//using Microsoft.AspNetCore.Mvc;

//namespace TradeBuddy.Appointment.Api.Controller
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class AppointmentController : ControllerBase
//    {
//        [HttpGet("GetAppointments")]
//        public IActionResult GetAppointments()
//        {
//            // Logic to get appointments
//            return Ok(new List<string> { "Appointment1", "Appointment2" }); // نمونه داده
//        }
//    }
//}

