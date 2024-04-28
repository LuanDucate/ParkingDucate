namespace ParkingDucate.Domain.Model
{
    public class Vacancies
    {
        public int AvailableCar { get; set; }
        public int AvailableBike { get; set; }
        public int AvailableVan { get; set; }
        public int occupiedByCars { get; set; }
        public int occupiedByBikes { get; set; }
        public int occupiedByVans { get; set; }
        public int TotalAvailable { get; set; }
    }
}
