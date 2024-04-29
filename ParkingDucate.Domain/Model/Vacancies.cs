namespace ParkingDucate.Domain.Model
{
    public class Vacancies
    {
        public Guid Id { get; set; }
        public int baseCar { get; set; }
        public int baseBike { get; set; }
        public int baseVan { get; set; }
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
            v.baseCar = 10;
            v.baseVan = 10;
            v.baseBike = 10;
            return v;
        }
    }
}
