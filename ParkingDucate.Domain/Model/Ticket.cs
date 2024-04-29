using ParkingDucate.Domain.Model.Enums;

namespace ParkingDucate.Domain.Model
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Plate { get; set; }
        public DateTime? Entry { get; set; }
        public DateTime? Departure { get; set; }
        public Double TotalValue { get; set; }
        public ParkingStatus Status { get; set; }
        public Ticket(string plate, DateTime entry, DateTime departure, Double totalValue, ParkingStatus status)
        {
            Plate = plate;
            Entry = entry;
            Departure = departure;
            TotalValue = totalValue;
            Status = status;
        }

        public Ticket(Vehicle vehicle)
        {
            Plate = vehicle.Plate;
            Entry = DateTime.Now;
            TotalValue = 0;
            Status = ParkingStatus.Started;
        }

        public void CalculateStayPrice()
        {
            this.Departure = DateTime.Now;
            TimeSpan ts = this.Entry.Value - this.Departure.Value;
            this.TotalValue = ts.TotalMinutes * 0.075; //60 * 0.075 = 4.5h
        }
    }
}
