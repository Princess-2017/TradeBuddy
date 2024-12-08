using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeBuddy.Appointment.Domain.ValueObjects;

namespace TradeBuddy.Appointment.Application.Command
{
    public record UpdateAppointmentCommand(
    AppointmentId AppointmentId,
    BusinessId BusinessId,
    CustomerId CustomerId,
    Time Time,
    DateTime AppointmentDate,
    AppointmentStatus Status
) : IRequest<bool>;
}
