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
            _repository.UpdateVacancies(vehicle.Type, ParkingStatus.Started);
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
            return true;
        }

        public Ticket FinalizeVehicleStay(string plate)
        {
            Vehicle vehicle = _repository.GetVehicleByPlate(plate);
            vehicle.Status = ParkingStatus.Finished;
            _repository.UpdateVehicle(vehicle);

            _repository.UpdateVacancies(vehicle.Type, ParkingStatus.Finished);
            Ticket ticket = _repository.getTicketByPlate(plate);
            ticket.CalculateStayPrice();
            _repository.UpdateTicket(ticket);
            return ticket;
        }

        public IEnumerable<Vehicle> GetParkedVehicles()
        {
            return _repository.GetAllParkedVehicles();
        }

        public Vacancies GetVacancies()
        {
            return _repository.GetVacancies();
        }

        public Vacancies SetNumberOfVacancies(int bike, int car, int van)
        {
            IEnumerable<Vehicle> vehicles = new List<Vehicle>();
            vehicles = _repository.GetAllParkedVehicles();

            Vacancies v = new Vacancies();
            v.OccupiedByCars = vehicles.Select(x => x.Type.Equals(VehicleType.Car)).Count();
            v.AvailableCar = car - v.OccupiedByCars;

            v.OccupiedByBikes = vehicles.Select(x => x.Type.Equals(VehicleType.Bike)).Count();
            v.AvailableBike = bike - v.OccupiedByBikes;

            v.OccupiedByVans = vehicles.Select(x => x.Type.Equals(VehicleType.Van)).Count();
            v.AvailableVan = van - v.OccupiedByVans;

            int total = bike + (car * 2) + (van * 3);
            v.TotalAvailable = total - vehicles.Select(x => x.Size).Count();

            _repository.UpdateVacancies(v);
            return v;
        }
    }
}
