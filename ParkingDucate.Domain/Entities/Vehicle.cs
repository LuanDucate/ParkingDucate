using ParkingDucate.Domain.Enums;

namespace ParkingDucate.Domain.Entities
{
    public class Vehicle
    {
        public int Size { get; private set; }
        public VehicleTypeEnum Type { get; set; }
        public string Plate { get; set; }
        public ParkingStatus status { get; set; } = ParkingStatus.Started;
        public Vehicle(int size, VehicleTypeEnum type, string plate)
        {
            Size = size;
            Type = type;
            Plate = plate;
        }
    }
}
