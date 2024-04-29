using ParkingDucate.Domain.Model;
using ParkingDucate.Domain.Model.Enums;

namespace ParkingDucate.Domain.Repository.Interfaces
{
    public interface IRepository
    {
        void AddTicket(Ticket ticket);
        void AddVehicle(Vehicle vehicle);
        List<Vehicle> GetAllParkedVehicles();
        Ticket getTicketByPlate(string plate);
        Vacancies GetVacancies();
        Vehicle GetVehicleByPlate(string plate);
        void UpdateVacancies(VehicleType type, ParkingStatus status);
        void UpdateVehicle(Vehicle vehicle);
    }
}
