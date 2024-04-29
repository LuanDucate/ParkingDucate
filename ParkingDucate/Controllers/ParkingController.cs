using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using ParkingDucate.Domain.Model;
using ParkingDucate.Domain.Services.Interfaces;

namespace ParkingDucate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkingController : ControllerBase
    {
        private readonly IParkingService _parkingService;

        public ParkingController(IParkingService parkingService)
        {
            _parkingService = parkingService;
        }

        [HttpGet]
        [Route("GetVacancies")]
        public Vacancies GetVacancies()
        {
            return _parkingService.GetVacancies();
        }

        [HttpGet]
        [Route("GetVehicles")]
        public IEnumerable<Vehicle> GetVehicles()
        {
            return _parkingService.GetParkedVehicles();
        }

        [HttpPost]
        [Route("AddVehicle")]
        public Vacancies AddVehicle(Vehicle Vehicle)
        {
            _parkingService.AddVehicle(Vehicle);
            return _parkingService.GetVacancies();
        }

        [HttpPost]
        [Route("FinalizeVehicleStay")]
        public Ticket FinalizeVehicleStay(string plate)
        {
            return _parkingService.FinalizeVehicleStay(plate);
        }

        [HttpPost]
        [Route("SetNumberOfVacancies")]
        public Vacancies SetNumberOfVacancies(int bike, int car, int van)
        {
            return _parkingService.SetNumberOfVacancies(bike, car, van);
        }

        [HttpGet]
        [Route("InitialValues")]
        public bool InitialValues()
        {
            return _parkingService.CreateInitialValues();
        }
    }
}
