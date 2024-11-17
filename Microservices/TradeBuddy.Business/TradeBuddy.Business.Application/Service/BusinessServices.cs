using System;
using System.Threading.Tasks;
using TradeBuddy.Business.Application.Common.Interfaces;

namespace TradeBuddy.Business.Application.Service
{
    // Create a model for messages received from the queue
    public class AppointmentRequestMessage
    {
        public string Action { get; set; }
        public string RequestDetails { get; set; }
    }

    public class BusinessService : IBusinessService
    {
        private readonly IMessagingService _messagingService;

        public BusinessService(IMessagingService messagingService)
        {
            _messagingService = messagingService;

            // Subscribe to message processing
            _messagingService.SubscribeAsync<AppointmentRequestMessage>(async message =>
            {
                if (message.Action == "RequestAppointments")
                {
                    // Process the request
                    var responseMessage = new
                    {
                        Action = "ResponseAppointments",
                        ResponseDetails = "Appointments data processed."
                    };

                    try
                    {
                        // Publish the response to the queue
                        await _messagingService.PublishAsync(responseMessage);
                    }
                    catch (Exception ex)
                    {
                        // Handle any issues while publishing the response
                        Console.WriteLine($"Error publishing response: {ex.Message}");
                    }
                }
            });
        }

        /// <summary>
        /// Process the incoming message and send a response.
        /// </summary>
        /// <param name="message">The input message</param>
        /// <returns>A response message</returns>
        public async Task<string> ProcessMessageAsync(string message)
        {
            // Process the message (e.g., parse the message)
            if (message.Contains("RequestAppointments"))
            {
                // Send a message to the queue requesting appointment data
                var appointmentRequestMessage = new AppointmentRequestMessage
                {
                    Action = "RequestAppointments",
                    RequestDetails = "Details about appointments"
                };

                try
                {
                    // Publish the message asynchronously
                    await _messagingService.PublishAsync(appointmentRequestMessage);
                    return "Request to Business service sent successfully.";
                }
                catch (Exception ex)
                {
                    // Handle any issues while publishing the request
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
