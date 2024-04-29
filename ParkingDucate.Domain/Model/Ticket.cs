using ParkingDucate.Domain.Model.Enums;
using System.ComponentModel.DataAnnotations;

namespace ParkingDucate.Domain.Model
{
    public class Ticket
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Plate { get; set; }
        public DateTime? Entry { get; set; }
        public DateTime? Departure { get; set; }
        public Double TotalValue { get; set; }
        public ParkingStatus Status { get; set; }
        public Ticket(string Plate, DateTime Entry, DateTime Departure, Double TotalValue, ParkingStatus Status)
        {
            this.Id = Guid.NewGuid();
            this.Plate = Plate;
            this.Entry = Entry;
            this.Departure = Departure;
            this.TotalValue = TotalValue;
            this.Status = Status;
            //Status = (ParkingStatus)status;
        }
        public Ticket()
        {
        }

        public Ticket(string plate)
        {
            Plate = plate;
            Entry = DateTime.Now;
            TotalValue = 0;
            Status = ParkingStatus.Started;
        }

        public void CalculateStayPrice()
        {
            this.Departure = DateTime.Now;
            TimeSpan ts = this.Departure.Value - this.Entry.Value;
            this.TotalValue = Math.Round(ts.TotalMinutes * 0.075, 2); //60 * 0.075 = 4.5h
            this.Status = ParkingStatus.Finished;
        }
    }
}
