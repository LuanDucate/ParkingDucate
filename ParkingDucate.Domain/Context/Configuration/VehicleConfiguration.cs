using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingDucate.Domain.Model;
using ParkingDucate.Domain.Model.Enums;

namespace ParkingDucate.Domain.Context.Configuration
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasKey(v => v.Id);

            builder.HasData(
                new Vehicle("CAR2R00", 2, VehicleType.Car, ParkingStatus.Started),
                new Vehicle("BIK1R00", 1, VehicleType.Bike, ParkingStatus.Started),
                new Vehicle("VAN3R00", 3, VehicleType.Van, ParkingStatus.Started)
            );
        }
    }
}