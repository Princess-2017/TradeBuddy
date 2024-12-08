using MediatR;
using TradeBuddy.Appointment.Domain.Interfaces;

namespace TradeBuddy.Appointment.Application.Command
{
    public class UpdateAppointmentCommandHandler : IRequestHandler<UpdateAppointmentCommand, bool>
    {
        private readonly IRepository<TradeBuddy.Appointment.Domain.Entities.Appointment, AppointmentId> _appointmentRepository;

        public UpdateAppointmentCommandHandler(IRepository<TradeBuddy.Appointment.Domain.Entities.Appointment, AppointmentId> appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<bool> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(request.AppointmentId);

            if (appointment == null)
                return false;

            appointment.Update(
                request.BusinessId,
                request.CustomerId,
                request.Time,
                request.AppointmentDate,
                request.Status
            );

            await _appointmentRepository.UpdateAsync(appointment);

            return true;
        }
    }
}
