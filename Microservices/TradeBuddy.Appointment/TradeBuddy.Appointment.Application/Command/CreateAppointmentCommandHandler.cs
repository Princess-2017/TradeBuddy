using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeBuddy.Appointment.Domain.Entities;
using TradeBuddy.Appointment.Domain.Interfaces;

namespace TradeBuddy.Appointment.Application.Command
{
    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, AppointmentId>
    {
        private readonly IRepository<TradeBuddy.Appointment.Domain.Entities.Appointment, AppointmentId> _appointmentRepository;

        public CreateAppointmentCommandHandler(IRepository<TradeBuddy.Appointment.Domain.Entities.Appointment, AppointmentId> appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<AppointmentId> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = new TradeBuddy.Appointment.Domain.Entities.Appointment(
                request.BusinessId,
                request.CustomerId,
                request.Time,
                request.AppointmentDate,
                request.Status
            );

            await _appointmentRepository.AddAsync(appointment);

            return appointment.Id;
        }
    }
}
