namespace ParkingDucate.Domain.Model
{
    public class Vacancies
    {
        public Guid Id { get; set; }
        public int AvailableCar { get; set; }
        public int AvailableBike { get; set; }
        public int AvailableVan { get; set; }
        public int OccupiedByCars { get; set; }
        public int OccupiedByBikes { get; set; }
        public int OccupiedByVans { get; set; }
        public int TotalAvailable { get; set; }

        public static Vacancies CreateInitialValues()
        {
            Vacancies v = new Vacancies();
            v.Id = Guid.NewGuid();
            v.AvailableCar = 10;
            v.AvailableBike = 10;
            v.AvailableVan = 10;
            v.OccupiedByBikes = 1;
            v.OccupiedByBikes = 1;
            v.OccupiedByVans = 1;
            v.TotalAvailable = 27;
            return v;
        }
    }
}
