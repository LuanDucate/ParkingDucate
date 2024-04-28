namespace ParkingDucate.Domain.Entities
{
    public class Vacancies
    {
        public int OccupiedCars { get; set; }
        public int OccupiedBikes { get; set; }
        public int OccupiedVans { get; set; }
        public int FreeCars { get; set; }
        public int FreeBikes { get; set; }
        public int FreeVans { get; set; }
        public int TotalFree { get; set; }
    }
}
