using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeBuddy.Appointment.Application.Command
{
    public record DeleteAppointmentCommand(AppointmentId AppointmentId) : IRequest<bool>;

}
