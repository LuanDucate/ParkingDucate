using ParkingDucate.Domain.Model;
using ParkingDucate.Domain.Model.Enums;
using ParkingDucate.Domain.Repository.Interfaces;
using ParkingDucate.Domain.Services.Interfaces;

namespace ParkingDucate.Domain.Services
{
    public class ParkingService : IParkingService
    {
        private readonly IRepository _repository;

        public ParkingService(IRepository repository)
        {
            _repository = repository;
        }

        public void AddVehicle(Vehicle vehicle)
        {
            _repository.AddVehicle(vehicle);
            CalculetaVacancies();
            Ticket ticket = new Ticket(vehicle.Plate);
            _repository.AddTicket(ticket);
        }

        public bool CreateInitialValues()
        {
            _repository.AddVacancies(Vacancies.CreateInitialValues());
            _repository.AddVehicle(new Vehicle("CAR2R00", 2, VehicleType.Car, ParkingStatus.Started));
            _repository.AddVehicle(new Vehicle("BIK1R00", 1, VehicleType.Bike, ParkingStatus.Started));
            _repository.AddVehicle(new Vehicle("VAN3R00", 3, VehicleType.Van, ParkingStatus.Started));
            _repository.AddTicket(new Ticket
            {
                Id = Guid.NewGuid(),
                Plate = "CAR2R00",
                Entry = DateTime.Now.AddHours(-3)
            });
            _repository.AddTicket(new Ticket
            {
                Id = Guid.NewGuid(),
                Plate = "BIK1R00",
                Entry = DateTime.Now.AddHours(-2)
            });
            _repository.AddTicket(new Ticket
            {
                Id = Guid.NewGuid(),
                Plate = "Van1R00",
                Entry = DateTime.Now.AddHours(-2)
            });
            CalculetaVacancies();
            return true;
        }

        public Ticket FinalizeVehicleStay(string plate)
        {
            Vehicle vehicle = _repository.GetVehicleByPlate(plate);
            vehicle.Status = ParkingStatus.Finished;
            _repository.UpdateVehicle(vehicle);

            CalculetaVacancies();
            Ticket ticket = _repository.getTicketByPlate(plate);
            ticket.CalculateStayPrice();
            _repository.UpdateTicket(ticket);
            return ticket;
        }

        private Vacancies CalculetaVacancies()
        {
            IEnumerable<Vehicle> vehicles = new List<Vehicle>();
            vehicles = _repository.GetAllParkedVehicles();

            Vacancies v = _repository.GetVacancies();
            v.OccupiedByCars = vehicles.Where(x => x.Size.Equals(2) && x.Status == ParkingStatus.Started).Count();
            v.AvailableCar = v.baseCar - v.OccupiedByCars;

            v.OccupiedByBikes = vehicles.Where(x => x.Size.Equals(1) && x.Status == ParkingStatus.Started).Count();
            v.AvailableBike = v.baseBike - v.OccupiedByBikes;

            v.OccupiedByVans = vehicles.Where(x => x.Size.Equals(3) && x.Status == ParkingStatus.Started).Count();
            v.AvailableVan = v.baseVan - v.OccupiedByVans;

            v.TotalAvailable = v.AvailableBike + v.AvailableCar + v.AvailableVan;

            _repository.UpdateVacancies(v);
            return v;
        }

        public IEnumerable<Vehicle> GetParkedVehicles()
        {
            return _repository.GetAllParkedVehicles();
        }

        public Vacancies GetVacancies()
        {
            return CalculetaVacancies();
        }

        public Vacancies SetNumberOfVacancies(int bike, int car, int van)
        {
            var v = _repository.GetVacancies();
            v.baseBike = bike;
            v.baseCar = car;
            v.baseVan = van;
            _repository.UpdateVacancies(v);
            return CalculetaVacancies();
        }
    }
}
