using ParkingDucate.Domain.Model;
using ParkingDucate.Domain.Model.Enums;

namespace ParkingDucate.Domain.Repository.Interfaces
{
    public interface IRepository
    {
        void AddTicket(Ticket ticket);
        void AddVacancies(Vacancies v);
        void AddVehicle(Vehicle vehicle);
        IEnumerable<Vehicle> GetAllParkedVehicles();
        Ticket getTicketByPlate(string plate);
        Vacancies GetVacancies();
        Vehicle GetVehicleByPlate(string plate);
        void UpdateTicket(Ticket ticket);
        void UpdateVacancies(Vacancies v);
        void UpdateVehicle(Vehicle vehicle);
    }
}
