using Microsoft.AspNetCore.Mvc;
using ParkingDucate.Domain.Model;
using ParkingDucate.Domain.Services.Interfaces;

namespace ParkingDucate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkingController : ControllerBase
    {
        private readonly ILogger<ParkingController> _logger;
        private readonly IParkingService _parkingService;

        public ParkingController(ILogger<ParkingController> logger, IParkingService parkingService)
        {
            _logger = logger;
            _parkingService = parkingService;
        }

        [HttpGet(Name = "GetVacancies")]
        public Vacancies GetVacancies()
        {
            return _parkingService.GetVacancies();
        }

        [HttpPost(Name = "AddVehicle")]
        public Vacancies AddVehicle(Vehicle Vehicle)
        {
            _parkingService.AddVehicle(Vehicle);

            return _parkingService.GetVacancies();
        }

        [HttpPost(Name = "FinalizeVehicleStay")]
        public Ticket FinalizeVehicleStay(string plate)
        {
            return _parkingService.FinalizeVehicleStay(plate);
        }
    }
}
