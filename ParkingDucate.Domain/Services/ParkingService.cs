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
            _repository.AddTicket(new Ticket(vehicle));
        }

        public Ticket FinalizeVehicleStay(string plate)
        {
            Vehicle vehicle = _repository.GetVehicleByPlate(plate);
            vehicle.Status = ParkingStatus.Finished;
            _repository.UpdateVehicle(vehicle);

            _repository.UpdateVacancies(vehicle.Type, ParkingStatus.Finished);
            Ticket ticket = _repository.getTicketByPlate(plate);
            ticket.CalculateStayPrice();
            return ticket;
        }

        public Vacancies GetVacancies()
        {
            return _repository.GetVacancies();
        }

        public Vacancies SetNumberOfVacancies(int bike, int car, int van)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            vehicles = _repository.GetAllParkedVehicles();

            Vacancies v = new Vacancies();
            v.occupiedByCars = vehicles.Select(x => x.Type.Equals(VehicleType.Car)).Count();
            v.AvailableCar = car - v.occupiedByCars;

            v.occupiedByBikes = vehicles.Select(x => x.Type.Equals(VehicleType.Bike)).Count();
            v.AvailableBike = bike - v.occupiedByBikes;

            v.occupiedByVans = vehicles.Select(x => x.Type.Equals(VehicleType.Van)).Count();
            v.AvailableVan = van - v.occupiedByVans;

            int total = bike + (car * 2) + (van * 3);
            v.TotalAvailable = total - vehicles.Select(x => x.Size).Count();

            _repository.UpdateVacancies(v);
            return v;
        }
    }
}
