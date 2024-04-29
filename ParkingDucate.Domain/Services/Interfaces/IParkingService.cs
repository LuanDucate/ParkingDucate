using ParkingDucate.Domain.Model;

namespace ParkingDucate.Domain.Services.Interfaces
{
    public interface IParkingService
    {
        void AddVehicle(Vehicle vehicle);
        bool CreateInitialValues();
        Ticket FinalizeVehicleStay(string plate);
        IEnumerable<Vehicle> GetParkedVehicles();
        Vacancies GetVacancies();
        Vacancies SetNumberOfVacancies(int bike, int car, int van);
    }
}
