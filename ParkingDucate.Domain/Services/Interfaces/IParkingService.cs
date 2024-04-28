using Microsoft.AspNetCore.Mvc;
using ParkingDucate.Domain.Entities;

namespace ParkingDucate.Domain.Services.Interfaces
{
    public interface IParkingService
    {
        void AddVehicle(Vehicle vehicle);
        Ticket FinalizeVehicleStay(string plate);
        Vacancies GetVacancies();
    }
}
