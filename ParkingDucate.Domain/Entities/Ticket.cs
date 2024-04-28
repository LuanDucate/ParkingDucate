using ParkingDucate.Domain.Enums;

namespace ParkingDucate.Domain.Entities
{
    public class Ticket
    {
        public string VehiclePlate { get; set; }
        public DateTime? EntryTime { get; set; } = DateTime.Now;
        public DateTime? DepartureTime { get; set; }
        public Double TotalValue { get; set; }
        public ParkingStatus status { get; set; } = ParkingStatus.Started;
    }
}
