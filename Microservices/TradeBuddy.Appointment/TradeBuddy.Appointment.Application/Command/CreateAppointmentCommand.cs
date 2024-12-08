using MediatR;
using TradeBuddy.Appointment.Domain.ValueObjects;

namespace TradeBuddy.Appointment.Application.Command
{
    public record CreateAppointmentCommand(
      BusinessId BusinessId,
      CustomerId CustomerId,
      Time Time,
      DateTime AppointmentDate,
      AppointmentStatus Status
  ) : IRequest<AppointmentId>;
}
