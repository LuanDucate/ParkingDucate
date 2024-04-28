namespace ParkingDucate.Domain.Model
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Plate { get; set; }
        public DateTime? Entry { get; set; }
        public DateTime? Departure { get; set; }
        public Double TotalValue { get; set; }

        public Ticket(string plate, DateTime entry, DateTime departure, Double totalValue)
        {
            Plate = plate;
            Entry = entry;
            Departure = departure;
            TotalValue = totalValue;
        }
    }
}
