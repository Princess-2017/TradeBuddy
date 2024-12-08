using MediatR;
using TradeBuddy.Appointment.Domain.Entities;
using TradeBuddy.Appointment.Domain.Interfaces;

namespace TradeBuddy.Appointment.Application.Queries
{
    public class GetAppointmentByIdQueryHandler : IRequestHandler<GetAppointmentByIdQuery, TradeBuddy.Appointment.Domain.Entities.Appointment?>
    {
        private readonly IRepository<TradeBuddy.Appointment.Domain.Entities.Appointment, AppointmentId> _appointmentRepository;

        public GetAppointmentByIdQueryHandler(IRepository<TradeBuddy.Appointment.Domain.Entities.Appointment, AppointmentId> appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<TradeBuddy.Appointment.Domain.Entities.Appointment?> Handle(GetAppointmentByIdQuery request, CancellationToken cancellationToken)
        {
            return await _appointmentRepository.GetByIdAsync(request.AppointmentId);
        }
    }
}
