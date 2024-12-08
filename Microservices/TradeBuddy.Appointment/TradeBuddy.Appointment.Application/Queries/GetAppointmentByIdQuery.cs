using MediatR;

namespace TradeBuddy.Appointment.Application.Queries
{
    public record GetAppointmentByIdQuery(AppointmentId AppointmentId) : IRequest<TradeBuddy.Appointment.Domain.Entities.Appointment?>;
}
