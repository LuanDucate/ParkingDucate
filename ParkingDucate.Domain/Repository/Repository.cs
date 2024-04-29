using ParkingDucate.Domain.Model;
using ParkingDucate.Domain.Model.Enums;
using ParkingDucate.Domain.Repository.Interfaces;

namespace ParkingDucate.Domain.Repository
{
    public class Repository : IRepository
    {
        private ParkingDucate.Domain.Context.Context _context;
        public Repository(ParkingDucate.Domain.Context.Context context)
        {
            _context = context;
        }
        public void AddTicket(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            _context.SaveChanges();
        }

        public void AddVehicle(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();
        }

        public List<Vehicle> GetAllParkedVehicles()
        {
            return _context.Vehicles.Where(x => x.Status.Equals(ParkingStatus.Started)).ToList();
        }

        public Ticket? getTicketByPlate(string plate)
        {
            return _context.Tickets.FirstOrDefault(x => x.Plate.Equals(plate)
            && x.Status.Equals(ParkingStatus.Started));
        }

        public Vacancies GetVacancies()
        {
            return _context.Vacancies.FirstOrDefault();
        }

        public Vehicle? GetVehicleByPlate(string plate)
        {
            return _context.Vehicles.FirstOrDefault(x => x.Plate.Equals(plate) && x.Status.Equals(ParkingStatus.Started));
        }

        public void UpdateVacancies(VehicleType type, ParkingStatus status)
        {
            Vacancies v = _context.Vacancies.First();
            switch (type)
            {
                case VehicleType.Car:
                    v.occupiedByCars = status == ParkingStatus.Started ? v.occupiedByCars++ : v.occupiedByCars--;
                    v.AvailableCar = status == ParkingStatus.Started ? v.AvailableCar-- : v.AvailableCar++;
                    break;
                case VehicleType.Bike:
                    v.occupiedByBikes = status == ParkingStatus.Started ? v.occupiedByBikes++ : v.occupiedByBikes--;
                    v.AvailableBike = status == ParkingStatus.Started ? v.AvailableBike-- : v.AvailableBike++;
                    break;
                case VehicleType.Van:
                    v.occupiedByVans = status == ParkingStatus.Started ? v.occupiedByVans++ : v.occupiedByVans--;
                    v.AvailableVan = status == ParkingStatus.Started ? v.AvailableVan-- : v.AvailableVan++;
                    break;
            }
            v.TotalAvailable = status == ParkingStatus.Started ? v.TotalAvailable - ((int)type) : v.TotalAvailable + ((int)type);
            _context.SaveChanges();
        }

        public void UpdateVacancies(Vacancies vacancies)
        {
            _context.Vacancies.Update(vacancies);
            _context.SaveChanges();
        }

        public void UpdateVehicle(Vehicle vehicle)
        {
            _context.Vehicles.Update(vehicle);
            _context.SaveChanges();
        }
    }
}
