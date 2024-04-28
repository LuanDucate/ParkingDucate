using ParkingDucate.Domain.Model.Enums;

namespace ParkingDucate.Domain.Model
{
    public class Vehicle
    {
        public string Plate { get; set; }
        public int Size { get; set; }
        public VehicleType Type { get; set; }
        public ParkingStatus Status { get; set; }

        public Vehicle(string plate, int size, VehicleType vehicleType, ParkingStatus parkingStatus = ParkingStatus.Started)
        {
            Plate = plate;
            Size = size;
            Type = vehicleType;
            Status = parkingStatus;
        }
    }
}
