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

        public void AddVacancies(Vacancies v)
        {
            if (!_context.Vacancies.Any())
            {
                _context.Vacancies.Add(v);
                _context.SaveChanges();
            }
        }

        public void AddVehicle(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();
        }

        public IEnumerable<Vehicle> GetAllParkedVehicles()
        {
            var retorno = _context.Vehicles.Where(x => x.Status.Equals(ParkingStatus.Started)).ToList();
            return retorno.AsEnumerable();
        }

        public Ticket? getTicketByPlate(string plate)
        {
            return _context.Tickets.FirstOrDefault(x => x.Plate.Equals(plate)
            && x.Status.Equals(ParkingStatus.Started));
        }

        public Vacancies GetVacancies()
        {
            return _context.Vacancies.First();
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
                    v.OccupiedByCars = status == ParkingStatus.Started ? v.OccupiedByCars++ : v.OccupiedByCars--;
                    v.AvailableCar = status == ParkingStatus.Started ? v.AvailableCar-- : v.AvailableCar++;
                    break;
                case VehicleType.Bike:
                    v.OccupiedByBikes = status == ParkingStatus.Started ? v.OccupiedByBikes++ : v.OccupiedByBikes--;
                    v.AvailableBike = status == ParkingStatus.Started ? v.AvailableBike-- : v.AvailableBike++;
                    break;
                case VehicleType.Van:
                    v.OccupiedByVans = status == ParkingStatus.Started ? v.OccupiedByVans++ : v.OccupiedByVans--;
                    v.AvailableVan = status == ParkingStatus.Started ? v.AvailableVan-- : v.AvailableVan++;
                    break;
            }
            v.TotalAvailable = status == ParkingStatus.Started ? v.TotalAvailable-- : v.TotalAvailable++;
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
        public void UpdateTicket(Ticket ticket)
        {
            _context.Tickets.Update(ticket);
            _context.SaveChanges();
        }
    }
}
