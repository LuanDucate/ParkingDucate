using ParkingDucate.Domain.Model.Enums;
using System.ComponentModel.DataAnnotations;

namespace ParkingDucate.Domain.Model
{
    public class Vehicle
    {
        [Key]
        public Guid Id { get; set; }
        public string Plate { get; set; }
        public int Size { get; set; }
        public VehicleType Type { get; set; }
        public ParkingStatus Status { get; set; }

        public Vehicle(string Plate, int Size, VehicleType Type, ParkingStatus Status)
        {
            this.Id = Guid.NewGuid();
            this.Plate = Plate;
            this.Size = Size;
            this.Type = Type;
            this.Status = Status;
            //Type = (VehicleType)vehicleType;
            //Status = (ParkingStatus)parkingStatus;
        }
    }
}
