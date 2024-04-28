using ParkingDucate.Domain.Model;

namespace ParkingDucate.Domain.Services.Interfaces
{
    public interface IParkingService
    {
        void AddVehicle(Vehicle vehicle);
        Ticket FinalizeVehicleStay(string plate);
        Vacancies GetVacancies();
        Vacancies SetNumberOfVacancies(int bike, int car, int van);
    }
}
