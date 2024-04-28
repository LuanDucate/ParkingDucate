using ParkingDucate.Domain.Model;

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
        void UpdateVacancies(int size, Model.Enums.ParkingStatus finished);
        void UpdateVacancies(Vacancies v);
        void UpdateVehicle(Vehicle vehicle);
    }
}
