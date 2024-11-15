using TradeBuddy.Reservation.Domain.Entities;
using TradeBuddy.Reservation.Domain.ValueObjects;
namespace TradeBuddy.Reservation.Domain.Entities;
public class Reservation : BaseEntity<ReservationId>
{
    public CustomerId CustomerId { get; private set; }
    public ServiceId ServiceId { get; private set; }
    public BranchId BranchId { get; private set; }
    public DateTime ReservationDate { get; private set; }
    public ReservationStatus Status { get; private set; }

    public Reservation(ReservationId id, CustomerId customerId, ServiceId serviceId, BranchId branchId, DateTime reservationDate, ReservationStatus status)
    {
        Id = id;
        CustomerId = customerId;
        ServiceId = serviceId;
        BranchId = branchId;
        ReservationDate = reservationDate;
        Status = status;
    }

    public Guid CustomerIdValue => CustomerId.Value; // Expose the Guid value
    public Guid ServiceIdValue => ServiceId.Value; // Expose the Guid value
    public Guid BranchIdValue => BranchId.Value; // Expose the Guid value

    public void UpdateStatus(ReservationStatus newStatus)
    {
        Status = newStatus;
    }
}
