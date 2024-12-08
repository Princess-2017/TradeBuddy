using MediatR;
using TradeBuddy.Appointment.Domain.Interfaces;

namespace TradeBuddy.Appointment.Application.Command
{
    public class DeleteAppointmentCommandHandler : IRequestHandler<DeleteAppointmentCommand, bool>
    {
        private readonly IRepository<TradeBuddy.Appointment.Domain.Entities.Appointment, AppointmentId> _appointmentRepository;

        public DeleteAppointmentCommandHandler(IRepository<TradeBuddy.Appointment.Domain.Entities.Appointment, AppointmentId> appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<bool> Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(request.AppointmentId);

            if (appointment == null)
                return false;

            await _appointmentRepository.DeleteAsync(request.AppointmentId);

            return true;
        }
    }
}
